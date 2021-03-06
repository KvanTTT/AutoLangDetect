﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NppPluginNET;
using System.Reflection;
using System.Collections.Generic;

namespace AutoLangDetect
{
	class Main
	{
		#region " Fields "
		
		internal const string PluginName = "AutoLangDetect";
		internal static string IniFileName = null;
		internal static string LangsFileName = null;

		internal static Settings Settings = new Settings();
		internal static LangDetector LangDetector = new LangDetector();
		internal static List<string> PrevSessionFiles;

		static int detectLanguageMenuId;
		static Bitmap tbBmp = Properties.Resources.star;
		static Bitmap tbBmp_tbTab = Properties.Resources.star_bmp;
		
		#endregion

		#region " StartUp/CleanUp "

		internal static void CommandMenuInit()
		{
			try
			{
				string pluginsConfigDir = PluginBase.GetPluginsConfigDir();
				if (!Directory.Exists(pluginsConfigDir))
					Directory.CreateDirectory(pluginsConfigDir);
				IniFileName = Path.Combine(pluginsConfigDir, PluginName + ".ini");

				LangsFileName = Path.Combine(pluginsConfigDir, @"..\..\langs.xml");
				var stylersFileName = Path.Combine(pluginsConfigDir, @"..\..\stylers.xml");
				string encoding;
				var langs = Parser.DeserializeLangs(File.ReadAllText(LangsFileName), File.ReadAllText(stylersFileName), out encoding);
				LangDetector.InitLanguages(langs, encoding);

				PrevSessionFiles = Parser.DeserializeOpenedFiles(File.ReadAllText(Path.Combine(pluginsConfigDir, @"..\..\session.xml")));

				LoadSettings();

				detectLanguageMenuId = 0;
				PluginBase.SetCommand(detectLanguageMenuId, "Detect Language", DetectLanguage);
				PluginBase.SetCommand(1, "Associate Extension", AssociateExtension);
				PluginBase.SetCommand(2, "Settings", OpenSettingWindow);
				PluginBase.SetCommand(3, "About", OpenAboutWindow);
				PluginBase.SetCommand(4, "Test", Test);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		internal static void SetToolBarIcon()
		{
			/*toolbarIcons tbIcons = new toolbarIcons();
			tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
			IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
			Marshal.StructureToPtr(tbIcons, pTbIcons, false);
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[detectLanguageMenuId]._cmdID, pTbIcons);
			Marshal.FreeHGlobal(pTbIcons);*/
		}

		internal static void PluginCleanUp()
		{
		}

		#endregion

		#region " Menu functions "

		internal static void DetectLanguage()
		{
			if (Settings.ShowDetectLanguageDialog)
			{
				var dlgDetectLanguage = new dlgDetectLanguage(PluginBase.GetFullCurrentFileName(), PluginBase.GetCurrentFileText());
				dlgDetectLanguage.ShowDialog();
			}
		}

		internal static void AssociateExtension()
		{
			var dlgAssociateExtension = new dlgAssociateExtension(PluginBase.GetCurrentFiles(), PluginBase.GetCurrentFileText(), PluginBase.GetOpenedFiles());
			dlgAssociateExtension.ShowDialog();
		}

		internal static void OpenSettingWindow()
		{
			var frmSettings = new frmSettings();
			frmSettings.ShowDialog();
		}

		internal static void OpenAboutWindow()
		{
			var frmAbout = new frmAbout();
			frmAbout.ShowDialog();
		}

		internal static void Test()
		{
			if (Clipboard.ContainsText())
				PluginBase.SetCurrentFileText(Clipboard.GetText());
			//Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, 1, 1);
			//MessageBox.Show(string.Join(",", Utils.GetOpenedFiles()));
			//Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)LangType.L_XML);
		}

		#endregion

		#region Settings

		internal static void LoadSettings()
		{
			Settings.DetectLanguageAutomatically =
				Win32.GetPrivateProfileInt("Settings", "DetectLanguageAutomatically", 1, Main.IniFileName) != 0;
			Settings.CheckEmptyExtensionFiles =
				Win32.GetPrivateProfileInt("Settings", "CheckEmptyExtension", 1, Main.IniFileName) != 0;
			Settings.ShowDetectLanguageDialog =
				Win32.GetPrivateProfileInt("Settings", "ShowDetectLanguageDialog", 1, Main.IniFileName) != 0;
			Settings.PasteClipboardTextToNewlyCreatedFile =
				Win32.GetPrivateProfileInt("Settings", "PasteClipboardTextToNewlyCreatedFile", 1, Main.IniFileName) != 0;
			Settings.ShowPasteTextFromClipboardDialog =
				Win32.GetPrivateProfileInt("Settings", "ShowPasteTextFromClipboardDialog", 1, Main.IniFileName) != 0;
		}

		internal static void SaveSettings()
		{
			Win32.WritePrivateProfileString("Settings", "DetectLanguageAutomatically",
				Convert.ToInt32(Settings.DetectLanguageAutomatically).ToString(), Main.IniFileName);
			Win32.WritePrivateProfileString("Settings", "CheckEmptyExtension",
				Convert.ToInt32(Settings.CheckEmptyExtensionFiles).ToString(), Main.IniFileName);
			Win32.WritePrivateProfileString("Settings", "ShowDetectLanguageDialog",
				Convert.ToInt32(Settings.ShowDetectLanguageDialog).ToString(), Main.IniFileName);
			Win32.WritePrivateProfileString("Settings", "PasteClipboardTextToNewlyCreatedFile",
				Convert.ToInt32(Settings.PasteClipboardTextToNewlyCreatedFile).ToString(), Main.IniFileName);
			Win32.WritePrivateProfileString("Settings", "ShowPasteTextFromClipboardDialog",
				Convert.ToInt32(Settings.ShowPasteTextFromClipboardDialog).ToString(), Main.IniFileName);
		}

		internal static void SaveLangs()
		{
			string langsData = Parser.SerializeLangs(LangDetector.Languages, LangDetector.Encoding);
			File.WriteAllText(LangsFileName, langsData);
		}

		#endregion
	}
}