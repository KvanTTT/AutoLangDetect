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
	public partial class dlgShowPasteClipboardText : Form
	{
		private string _clipboardText;

		public dlgShowPasteClipboardText(string clipboardText)
		{
			_clipboardText = clipboardText;

			InitializeComponent();
		}

		private void cbShowDialogEveryTime_CheckedChanged(object sender, EventArgs e)
		{
			Main.Settings.ShowPasteTextFromClipboardDialog = cbShowDialogEveryTime.Checked;
			Main.SaveSettings();
		}

		private void btnYesNo_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgShowPasteClipboardText_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.Yes)
			{
				if (!Main.Settings.PasteClipboardTextToNewlyCreatedFile)
				{
					Main.Settings.PasteClipboardTextToNewlyCreatedFile = true;
					Main.SaveSettings();
				}
				PluginBase.SetCurrentFileText(_clipboardText);
			}
			else
			{
				if (Main.Settings.PasteClipboardTextToNewlyCreatedFile)
				{
					Main.Settings.PasteClipboardTextToNewlyCreatedFile = false;
					Main.SaveSettings();
				}
			}
		}
	}
}
