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
			cbCheckUnknownExtensionFiles.Checked = Main.Settings.CheckUnknownExtensionFiles;
			cbCheckEmptyExtensionFiles.Checked = Main.Settings.CheckEmptyExtensionFiles;
			cbShowDetectLanguageDialog.Checked = Main.Settings.ShowDetectLanguageDialog;
			cbShowAssociateExtensionDialog.Checked = Main.Settings.ShowAssociateExtensionDialog;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Main.Settings.DetectLanguageAutomatically = cbDetectLanguageAutomatically.Checked;
			Main.Settings.CheckUnknownExtensionFiles = cbCheckUnknownExtensionFiles.Checked;
			Main.Settings.CheckEmptyExtensionFiles = cbCheckEmptyExtensionFiles.Checked;
			Main.Settings.ShowDetectLanguageDialog = cbShowDetectLanguageDialog.Checked;
			Main.Settings.ShowAssociateExtensionDialog = cbShowAssociateExtensionDialog.Checked;

			Main.SaveSettings();
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
