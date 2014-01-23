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
	public partial class dlgDetectLanguage : Form
	{
		string _currentFileText;

		public dlgDetectLanguage(string fileName, string currentFileText)
		{
			InitializeComponent();

			if (string.IsNullOrEmpty(fileName) || fileName.StartsWith("new"))
				lblQuestion.Text = "Would you like to associate inserted text with following language?";
			else
				lblQuestion.Text = string.Format("Would you like to associate file \"{0}\" with following language?", Path.GetFileName(fileName));
			_currentFileText = currentFileText;
			foreach (var lang in Main.LangDetector.Languages)
				cmbLanguage.Items.Add(lang.Value);
			// TODO: Add lang autodetection
			cmbLanguage.SelectedIndex = 0;

			btnYes.Select();
		}

		private void btnYes_Click(object sender, EventArgs e)
		{
			//Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, _openedFiles[i].View, _openedFiles[i].Index);
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE,
									0, (int)((NppLanguage)cmbLanguage.SelectedItem).LangType);

			Close();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbShowDialogEveryTime_CheckedChanged(object sender, EventArgs e)
		{
			Main.Settings.ShowDetectLanguageDialog = cbShowDialogEveryTime.Checked;
			Main.SaveSettings();
		}
	}
}
