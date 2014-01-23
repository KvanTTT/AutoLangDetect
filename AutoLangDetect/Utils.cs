using NppPluginNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoLangDetect
{
	internal class Utils
	{
		internal static string GetFullCurrentFileName()
		{
			StringBuilder builder = new StringBuilder(Win32.MAX_PATH);
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFULLCURRENTPATH, 0, builder);
			return builder.ToString();
		}

		internal static List<FilePathViewIndex> GetOpenedFiles(int view = 0)
		{
			var result = new List<FilePathViewIndex>();

			int nbFile;
			ClikeStringArray cStrArray;
			int ind;

			if (view == 0 || view == 1)
			{
				nbFile = (int)Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETNBOPENFILES, 0, 1);
				using (cStrArray = new ClikeStringArray(nbFile, Win32.MAX_PATH))
				{
					ind = 0;
					if (Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETOPENFILENAMESPRIMARY, cStrArray.NativePointer, nbFile) != IntPtr.Zero)
						if (cStrArray.ManagedStringsUnicode.Count > 1 || !cStrArray.ManagedStringsUnicode[0].StartsWith("new"))
							result.AddRange(cStrArray.ManagedStringsUnicode.Select(str => new FilePathViewIndex(str, 0, ind++)));
				}
			}
			
			if (view == 0 || view == 2)
			{
				nbFile = (int)Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETNBOPENFILES, 0, 2);
				using (cStrArray = new ClikeStringArray(nbFile, Win32.MAX_PATH))
				{
					ind = 0;
					if (Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETOPENFILENAMESSECOND, cStrArray.NativePointer, nbFile) != IntPtr.Zero)
						if (cStrArray.ManagedStringsUnicode.Count > 1 || !cStrArray.ManagedStringsUnicode[0].StartsWith("new"))
							result.AddRange(cStrArray.ManagedStringsUnicode.Select(str => new FilePathViewIndex(str, 1, ind++)));
				}
			}

			return result;
		}

		internal static string GetCurrentFileText(int length = -1)
		{
			if (length == -1)
				length = Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_GETLENGTH, 0, 0).ToInt32();

			Sci_TextRange range = new Sci_TextRange(0, -1, length);
			Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_GETTEXTRANGE, 0, range.NativePointer);
			return range.lpstrTextUtf8;
		}
	}
}
