using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoLangDetect.Forms
{
	public partial class frmDetectLanguage : Form
	{
		public frmDetectLanguage()
		{
			InitializeComponent();
		}

		private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btnYes_Click(object sender, EventArgs e)
		{
			Main.Settings.ShowDetectLanguageDialog = cbShowDialogEveryTime.Checked;
			Main.SaveSettings();
			Close();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			Main.Settings.ShowDetectLanguageDialog = cbShowDialogEveryTime.Checked;
			Main.SaveSettings();
			Close();
		}
	}
}
