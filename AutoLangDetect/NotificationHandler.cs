using NppPluginNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoLangDetect
{
	internal class NotificationHandler
	{
		const int MinTextLength = 10;
		const int TimerMilliseconds = 200;

		static int _prevLength = 0;
		static bool _tabSwitched = false;
		static string _currentFileName = "";
		static bool _newFile = false;

		static int _lastPrimaryViewOpenedCount = 0;
		static int _lastSecondaryViewOpenedCount = 0;
		static Dictionary<string, NppLanguage> _newlyAddedExtension = new Dictionary<string, NppLanguage>();
		static Queue<FilePathViewIndex> _openedFiles = new Queue<FilePathViewIndex>();
		static System.Threading.Timer _openedFileTimer = new System.Threading.Timer(_ => ProcessOpenedFiles(), null, Timeout.Infinite, Timeout.Infinite);

		internal static void TabSwitched()
		{
			_tabSwitched = true;
		}

		internal static void BufferActivated()
		{
			if (_tabSwitched)
			{
				//MessageBox.Show("BufferActivated tab");
				_currentFileName = Utils.GetFullCurrentFileName();
				_newFile = _currentFileName.StartsWith("new");
				_prevLength = Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_GETLENGTH, 0, 0).ToInt32();
				_tabSwitched = false;
			}
			else
			{
				StringBuilder builder = new StringBuilder(Win32.MAX_PATH);
				Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFULLCURRENTPATH, 0, builder);
				string fullPath = builder.ToString();
				if (fullPath.StartsWith("new"))
				{
					//MessageBox.Show("BufferActivated new");
					_currentFileName = Utils.GetFullCurrentFileName();
					_newFile = _currentFileName.StartsWith("new");
					_prevLength = Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_GETLENGTH, 0, 0).ToInt32();
					_tabSwitched = true;
				}
			}
		}

		internal static void FileOpened()
		{
			var openedFiles1 = Utils.GetOpenedFiles((int)NppMsg.PRIMARY_VIEW);
			FilePathViewIndex openedFileName = null;
			if (openedFiles1.Count > 0 && openedFiles1.Count != _lastPrimaryViewOpenedCount)
			{
				openedFileName = openedFiles1.Last();
				_lastPrimaryViewOpenedCount = openedFiles1.Count;
			}
			else
			{
				var openedFiles2 = Utils.GetOpenedFiles((int)NppMsg.SECOND_VIEW);
				if (openedFiles2.Count > 0 && openedFiles2.Count != _lastSecondaryViewOpenedCount)
				{
					openedFileName = openedFiles2.Last();
				}
				_lastSecondaryViewOpenedCount = openedFiles2.Count;
			}
			_lastPrimaryViewOpenedCount = openedFiles1.Count;

			if (openedFileName != null)
			{
				lock (_openedFiles)
				{
					if (_openedFiles.FirstOrDefault(file => file.Path == openedFileName.Path) == null)
						_openedFiles.Enqueue(openedFileName);
					_openedFileTimer.Change(TimerMilliseconds, Timeout.Infinite);
				}
			}
		}

		static void ProcessOpenedFiles()
		{
			while (_openedFiles.Count > 0)
			{
				var openedFile = _openedFiles.Dequeue();

				string extension = Path.GetExtension(openedFile.Path);
				if (extension == "")
				{
					if (!Main.PrevSessionFiles.Contains(openedFile.Path))
					{
						Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, openedFile.View, openedFile.Index);
						if (Main.Settings.CheckEmptyExtensionFiles)
						{
							var text = Utils.GetCurrentFileText();
							if (Main.Settings.ShowDetectLanguageDialog)
							{
								Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, openedFile.View, openedFile.Index);
								var detectLangDialog = new dlgDetectLanguage(openedFile.Path, text);
								detectLangDialog.ShowDialog();
							}
							else
							{
								// TODO: autodetection
							}
						}
					}
				}
				else
				{
					extension = extension.Substring(1);
					if (!Main.LangDetector.ContainsExtension(extension))
					{
						Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, openedFile.View, openedFile.Index);
						var associateExtDialog = new dlgAssociateExtension(openedFile.Path, Utils.GetCurrentFileText(), Utils.GetOpenedFiles());
						var dlgResult = associateExtDialog.ShowDialog();
						if (associateExtDialog.SelectedLanguage != null && !_newlyAddedExtension.ContainsKey(extension))
							_newlyAddedExtension.Add(extension, associateExtDialog.SelectedLanguage);
					}
					else if (_newlyAddedExtension.ContainsKey(extension))
					{
						Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, openedFile.View, openedFile.Index);
						Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)_newlyAddedExtension[extension].LangType);
					}
				}
			}
		}

		internal static void FileModified()
		{
			int length = Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_GETLENGTH, 0, 0).ToInt32();
			if (_prevLength == 0 && length > MinTextLength)
			{
				_prevLength = length;

				if (Utils.GetFullCurrentFileName().StartsWith("new"))
				{
					if (Main.Settings.DetectLanguageAutomatically)
					{
						var text = Utils.GetCurrentFileText(length);
						if (Main.Settings.ShowDetectLanguageDialog)
						{
							var detectLangDialog = new dlgDetectLanguage(Utils.GetFullCurrentFileName(), text);
							detectLangDialog.ShowDialog();
						}
						else
						{
							// TODO: autodetection
						}
					}
				}
			}
			else
				_prevLength = length;
		}

		internal static void FileClosed()
		{
			var openedFiles1 = Utils.GetOpenedFiles((int)NppMsg.PRIMARY_VIEW);
			if (openedFiles1.Count != _lastPrimaryViewOpenedCount)
				_lastPrimaryViewOpenedCount = openedFiles1.Count;
			else
			{
				var openedFiles2 = Utils.GetOpenedFiles((int)NppMsg.SECOND_VIEW);
				_lastSecondaryViewOpenedCount = openedFiles2.Count;
			}
		}
	}
}
