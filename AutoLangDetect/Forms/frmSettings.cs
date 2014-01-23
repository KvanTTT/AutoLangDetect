using NppPluginNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
	}
}
