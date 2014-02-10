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
		const int MinTextLength = 100;
		const int TimerMilliseconds = 200;

		static int _prevLength = 0;

		static int _lastPrimaryOpenedFilesCount = 0;
		static int _lastSecondaryOpenedFilesCount = 0;
		static int _lastPrimaryOpenedOrNewFilesCount = 0;
		static int _lastSecondaryOpenedOrNewFilesCount = 0;
		static bool _fileRecentlyOpened = false;
		static Dictionary<string, NppLanguage> _newlyAddedExtensions = new Dictionary<string, NppLanguage>();
		static Queue<FilePathViewIndex> _openedFiles = new Queue<FilePathViewIndex>();
		static System.Threading.Timer _openedFileTimer = new System.Threading.Timer(_ => ProcessOpenedFiles(), null, Timeout.Infinite, Timeout.Infinite);

		internal static void ResetNewlyAddedExtensions()
		{
			_newlyAddedExtensions = new Dictionary<string, NppLanguage>();
			foreach (var ext in Main.LangDetector.ExtensionLangs)
				_newlyAddedExtensions.Add(ext.Key, ext.Value);
		}

		internal static void TabSwitched()
		{
		}

		internal static void BufferActivated()
		{
			int currentPrimaryOpenedOrNewFilesCount = PluginBase.GetOpenedOrNewFilesCount((int)NppMsg.PRIMARY_VIEW);
			int currentSecondaryOpenedOrNewFilesCount = PluginBase.GetOpenedOrNewFilesCount((int)NppMsg.SECOND_VIEW);
			if (!_fileRecentlyOpened)
			{
				if ((currentPrimaryOpenedOrNewFilesCount > 1 &&
					currentPrimaryOpenedOrNewFilesCount > _lastPrimaryOpenedOrNewFilesCount) ||
					(currentSecondaryOpenedOrNewFilesCount > 1 &&
					currentSecondaryOpenedOrNewFilesCount > _lastSecondaryOpenedOrNewFilesCount) &&
					Utils.IsFileNew(PluginBase.GetFullCurrentFileName()))
				{
					if (Clipboard.ContainsText())
					{
						if (Main.Settings.ShowPasteTextFromClipboardDialog)
						{
							var dlg = new dlgShowPasteClipboardText(Clipboard.GetText());
							dlg.ShowDialog();
						}
						else
						{
							if (Main.Settings.PasteClipboardTextToNewlyCreatedFile)
								PluginBase.SetCurrentFileText(Clipboard.GetText());
						}
					}
				}
			}
			_lastPrimaryOpenedOrNewFilesCount = currentPrimaryOpenedOrNewFilesCount;
			_lastSecondaryOpenedOrNewFilesCount = currentSecondaryOpenedOrNewFilesCount;
		}

		internal static void FileOpened()
		{
			_fileRecentlyOpened = true;

			var openedFiles1 = PluginBase.GetOpenedFiles((int)NppMsg.PRIMARY_VIEW);
			FilePathViewIndex openedFileName = null;
			if (openedFiles1.Count > 0 && openedFiles1.Count != _lastPrimaryOpenedFilesCount)
			{
				openedFileName = openedFiles1.Last();
				_lastPrimaryOpenedFilesCount = openedFiles1.Count;
			}
			else
			{
				var openedFiles2 = PluginBase.GetOpenedFiles((int)NppMsg.SECOND_VIEW);
				if (openedFiles2.Count > 0 && openedFiles2.Count != _lastSecondaryOpenedFilesCount)
				{
					openedFileName = openedFiles2.Last();
				}
				_lastSecondaryOpenedFilesCount = openedFiles2.Count;
			}
			_lastPrimaryOpenedFilesCount = openedFiles1.Count;

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

				string extension = Utils.GetExtensionWithoutDot(openedFile.Path);
				if (extension == "")
				{
					if (!Main.PrevSessionFiles.Contains(openedFile.Path))
					{
						Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, openedFile.View, openedFile.Index);
						if (Main.Settings.CheckEmptyExtensionFiles)
						{
							var text = PluginBase.GetCurrentFileText();
							if (Main.Settings.ShowDetectLanguageDialog)
							{
								Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, openedFile.View, openedFile.Index);
								var detectLangDialog = new dlgDetectLanguage(openedFile.Path, text);
								detectLangDialog.ShowDialog(Control.FromHandle(PluginBase.nppData._nppHandle));
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
					if (!Main.LangDetector.ContainsExtension(extension))
					{
						Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, openedFile.View, openedFile.Index);
						var associateExtDialog = new dlgAssociateExtension(openedFile, PluginBase.GetCurrentFileText(), PluginBase.GetOpenedFiles());
						var dlgResult = associateExtDialog.ShowDialog(Control.FromHandle(PluginBase.nppData._nppHandle));
						if (associateExtDialog.SelectedLanguage != null && !_newlyAddedExtensions.ContainsKey(extension))
							_newlyAddedExtensions.Add(extension, associateExtDialog.SelectedLanguage);
					}
					else if (_newlyAddedExtensions.ContainsKey(extension))
					{
						Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, openedFile.View, openedFile.Index);
						Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)_newlyAddedExtensions[extension].LangType);
					}
				}
			}
			_fileRecentlyOpened = false;
		}

		internal static void FileModified()
		{
			int length = Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_GETLENGTH, 0, 0).ToInt32();
			if (_prevLength == 0 && length > MinTextLength)
			{
				_prevLength = length;

				if (Utils.IsFileNew(PluginBase.GetFullCurrentFileName()))
				{
					if (Main.Settings.DetectLanguageAutomatically)
					{
						var text = PluginBase.GetCurrentFileText(length);
						if (Main.Settings.ShowDetectLanguageDialog)
						{
							var detectLangDialog = new dlgDetectLanguage(PluginBase.GetFullCurrentFileName(), text);
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
			var openedFiles1 = PluginBase.GetOpenedFiles((int)NppMsg.PRIMARY_VIEW);
			if (openedFiles1.Count != _lastPrimaryOpenedFilesCount)
				_lastPrimaryOpenedFilesCount = openedFiles1.Count;
			else
			{
				var openedFiles2 = PluginBase.GetOpenedFiles((int)NppMsg.SECOND_VIEW);
				_lastSecondaryOpenedFilesCount = openedFiles2.Count;
			}
		}
	}
}
