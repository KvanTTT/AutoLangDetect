using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NppPluginNET;
using System.Reflection;

namespace AutoLangDetect
{
	class Main
	{
		#region " Fields "
		
		internal const string PluginName = "AutoLangDetect";
		
		internal static string IniFileName = null;

		internal static Settings Settings = new Settings();

		internal static LangParser LangParser;

		static int idMyDlg = -1;
		
		static Bitmap tbBmp = Properties.Resources.star;
		
		static Bitmap tbBmp_tbTab = Properties.Resources.star_bmp;
		
		#endregion

		#region " StartUp/CleanUp "

		internal static void CommandMenuInit()
		{
			try
			{
				StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
				Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
				string IniFilePath = sbIniFilePath.ToString();
				if (!Directory.Exists(IniFilePath))
					Directory.CreateDirectory(IniFilePath);
				IniFileName = Path.Combine(IniFilePath, PluginName + ".ini");

				string langsPath = Path.Combine(IniFilePath, @"..\..\langs.xml");
				string langs = File.ReadAllText(langsPath);
				LangParser = new LangParser();
				LangParser.Parse(langs);

				LoadSettings();

				PluginBase.SetCommand(0, "Detect Language", DetectLanguage, new ShortcutKey(true, true, false, Keys.NumPad5));
				PluginBase.SetCommand(1, "Settings", OpenSettingWindow);
				PluginBase.SetCommand(2, "About", OpenAboutWindow);
				idMyDlg = 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		internal static void SetToolBarIcon()
		{
			toolbarIcons tbIcons = new toolbarIcons();
			tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
			IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
			Marshal.StructureToPtr(tbIcons, pTbIcons, false);
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
			Marshal.FreeHGlobal(pTbIcons);
		}

		internal static void PluginCleanUp()
		{
		}

		#endregion

		#region " Menu functions "

		internal static void DetectLanguage()
		{
			MessageBox.Show("Language detected");
		}

		internal static void OpenSettingWindow()
		{
			var frmSettings = new frmSettings();
			frmSettings.Show();
		}

		internal static void OpenAboutWindow()
		{
			var frmAbout = new frmAbout();
			frmAbout.Show();
		}
		
		#endregion

		#region Settings

		internal static void LoadSettings()
		{
			Settings.DetectLanguageAutomatically =
				Win32.GetPrivateProfileInt("Settings", "DetectLanguageAutomatically", 1, Main.IniFileName) != 0;
			Settings.CheckUnknownExtensionFiles =
				Win32.GetPrivateProfileInt("Settings", "CheckUnknownExtension", 1, Main.IniFileName) != 0;
			Settings.CheckEmptyExtensionFiles =
				Win32.GetPrivateProfileInt("Settings", "CheckEmptyExtension", 1, Main.IniFileName) != 0;
			Settings.ShowDetectLanguageDialog =
				Win32.GetPrivateProfileInt("Settings", "ShowDetectLanguageDialog", 1, Main.IniFileName) != 0;
			Settings.ShowAssociateExtensionDialog = 
				Win32.GetPrivateProfileInt("Settings", "ShowAssociateExtensionDialog", 1, Main.IniFileName) != 0;
		}

		internal static void SaveSettings()
		{
			Win32.WritePrivateProfileString("Settings", "DetectLanguageAutomatically",
				Convert.ToInt32(Settings.DetectLanguageAutomatically).ToString(), Main.IniFileName);
			Win32.WritePrivateProfileString("Settings", "CheckUnknownExtension",
				Convert.ToInt32(Settings.CheckUnknownExtensionFiles).ToString(), Main.IniFileName);
			Win32.WritePrivateProfileString("Settings", "CheckEmptyExtension",
				Convert.ToInt32(Settings.CheckEmptyExtensionFiles).ToString(), Main.IniFileName);
			Win32.WritePrivateProfileString("Settings", "ShowDetectLanguageDialog",
				Convert.ToInt32(Settings.ShowDetectLanguageDialog).ToString(), Main.IniFileName);
			Win32.WritePrivateProfileString("Settings", "ShowAssociateExtensionDialog",
				Convert.ToInt32(Settings.ShowAssociateExtensionDialog).ToString(), Main.IniFileName);
		}

		#endregion
	}
}