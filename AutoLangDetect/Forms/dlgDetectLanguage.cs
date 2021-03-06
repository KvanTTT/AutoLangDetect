﻿using NppPluginNET;
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

			if (string.IsNullOrEmpty(fileName) || Utils.IsFileNew(fileName))
				lblQuestion.Text = string.Format("Would you like to associate inserted text of file \"{0}\" with following language?", fileName);
			else
				lblQuestion.Text = string.Format("Would you like to associate file \"{0}\" with following language?", Path.GetFileName(fileName));
			_currentFileText = currentFileText;
			foreach (var lang in Main.LangDetector.Languages)
				cmbLanguage.Items.Add(lang.Value);
			// TODO: Add lang autodetection
			cmbLanguage.SelectedIndex = 0;

			btnYes.Select();
		}

		private void btnYesNo_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbShowDialogEveryTime_CheckedChanged(object sender, EventArgs e)
		{
			Main.Settings.ShowDetectLanguageDialog = cbShowDialogEveryTime.Checked;
			Main.SaveSettings();
		}

		private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			var lang = (NppLanguage)cmbLanguage.SelectedItem;
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)lang.LangType);
		}

		private void dlgDetectLanguage_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult != DialogResult.Yes)
				Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)Main.LangDetector.DefaultLang.LangType);
		}
	}
}
