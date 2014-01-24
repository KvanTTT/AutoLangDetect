using AutoLangDetect.Properties;
using NppPluginNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoLangDetect
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();

			cbDetectLanguageAutomatically.Checked = Main.Settings.DetectLanguageAutomatically;
			cbCheckEmptyExtensionFiles.Checked = Main.Settings.CheckEmptyExtensionFiles;
			cbShowDetectLanguageDialog.Checked = Main.Settings.ShowDetectLanguageDialog;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Main.Settings.DetectLanguageAutomatically = cbDetectLanguageAutomatically.Checked;
			Main.Settings.CheckEmptyExtensionFiles = cbCheckEmptyExtensionFiles.Checked;
			Main.Settings.ShowDetectLanguageDialog = cbShowDetectLanguageDialog.Checked;

			Main.SaveSettings();
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnResetExtensions_Click(object sender, EventArgs e)
		{
			var origLangsData = Resources.langs;
			File.WriteAllText(Main.LangsFileName, origLangsData);

			var stylersFileName = Path.Combine(Utils.GetPluginsConfigDir(), @"..\..\stylers.xml");
			string encoding;
			var langs = Parser.DeserializeLangs(origLangsData, File.ReadAllText(stylersFileName), out encoding);
			Main.LangDetector.InitLanguages(langs, encoding);

			NotificationHandler.ResetNewlyAddedExtensions();

			var openedFiles = Utils.GetOpenedFiles();
			foreach (var file in openedFiles)
			{
				NppLanguage lang;
				var ext = Utils.ExtensionWithoutDot(Path.GetExtension(file.Path));
				Main.LangDetector.Languages.TryGetValue(ext, out lang);
				if (lang != null)
				{
					Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, file.View, file.Index);
					Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)lang.LangType);
				}
				else if (ext != "")
				{
					Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, file.View, file.Index);
					Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)Main.LangDetector.DefaultLang.LangType);
				}
			}
		}
	}
}
