using System;
using System.Runtime.InteropServices;
using NppPluginNET;
using NppPlugin.DllExport;
using System.Windows.Forms;
using System.Text;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace AutoLangDetect
{
    class UnmanagedExports
    {
		static List<string> _events;
		static NppMsg[] _nppMsgs;
		static SciMsg[] _sciMsgs;

		static UnmanagedExports()
		{
			try
			{
				_events = new List<string>();
				_nppMsgs = (NppMsg[])Enum.GetValues(typeof(NppMsg));
				_sciMsgs = (SciMsg[])Enum.GetValues(typeof(SciMsg));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

        [DllExport(CallingConvention=CallingConvention.Cdecl)]
        static bool isUnicode()
        {
            return true;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void setInfo(NppData notepadPlusData)
        {
			PluginBase.nppData = notepadPlusData;
            Main.CommandMenuInit();
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static IntPtr getFuncsArray(ref int nbF)
        {
            nbF = PluginBase._funcItems.Items.Count;
            return PluginBase._funcItems.NativePointer;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static uint messageProc(uint Message, IntPtr wParam, IntPtr lParam)
        {
            return 1;
        }

        static IntPtr _ptrPluginName = IntPtr.Zero;
        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static IntPtr getName()
        {
            if (_ptrPluginName == IntPtr.Zero)
                _ptrPluginName = Marshal.StringToHGlobalUni(Main.PluginName);
            return _ptrPluginName;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void beNotified(IntPtr notifyCode)
        {
            SCNotification nc = (SCNotification)Marshal.PtrToStructure(notifyCode, typeof(SCNotification));

			/*var nppMsg = _nppMsgs.Where(msg => (uint)msg == nc.nmhdr.code);
			if (nppMsg.Count() != 0)
				_events.Add(DateTime.Now.ToShortTimeString() + " " + nppMsg.First() + " " + "Event code: " + nc.nmhdr.code);
			else
			{
				var sciMsg = _sciMsgs.Where(msg => (uint)msg == nc.nmhdr.code);
				if (sciMsg.Count() != 0)
					_events.Add(DateTime.Now.ToShortTimeString() + " " + sciMsg.First() + " " + "Event code: " + nc.nmhdr.code);
				else
				{
					_events.Add(DateTime.Now.ToShortTimeString() + " " + "Event code: " + nc.nmhdr.code);
				}
			}*/

			switch (nc.nmhdr.code)
			{
				case (uint)NppMsg.NPPN_FILEOPENED:
					NotificationHandler.FileOpened();
					break;
				case 4294967294:
					// 4294966744 - tab before switching
					// 4294966745 - tab after switching
					// 4294967294 - tab has been swicthed
					NotificationHandler.TabSwitched();
					break;
				case (uint)NppMsg.NPPN_BUFFERACTIVATED:
					
					break;
				case (uint)NppMsg.NPPN_FILEBEFORECLOSE:
					Main.PrevSessionFiles.Remove(Utils.GetFullCurrentFileName());
					break;
				case (uint)NppMsg.NPPN_FILECLOSED:
					NotificationHandler.FileClosed();
					break;
				case (uint)NppMsg.NPPN_DOCORDERCHANGED:

					break;
				case (uint)SciMsg.SCN_MODIFIED:
					NotificationHandler.FileModified();
					break;
				case (uint)NppMsg.NPPN_TBMODIFICATION:
					PluginBase._funcItems.RefreshItems();
					Main.SetToolBarIcon();
					break;
				case (uint)NppMsg.NPPN_SHUTDOWN:
					//File.WriteAllLines(@"C:\Users\IvanKoch\AppData\Roaming\Notepad++\plugins\AutoLangDetect.log", _events.ToArray());
					Main.PluginCleanUp();
					Marshal.FreeHGlobal(_ptrPluginName);
					break;
			}
        }
    }
}
