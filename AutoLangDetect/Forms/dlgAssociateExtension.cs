using NppPluginNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoLangDetect
{
	public partial class dlgAssociateExtension : Form
	{
		NppLanguage _defaultLanguage;
		List<FilePathViewIndex> _openedFiles;
		string _currentFileText;
		NppLanguage _selectedItem;

		public NppLanguage SelectedLanguage
		{
			get;
			private set;
		}

		public dlgAssociateExtension(string fileName, string fileText, List<FilePathViewIndex> openedFiles)
		{
			InitializeComponent();

			string shortFileName = Path.GetFileName(fileName);
			string ext = Path.GetExtension(fileName);
			Text = string.Format("Associate Extension of file \"{0}\"", shortFileName);
			tbExtension.Text = ext != "" ? ext.Substring(1) : ext;
			_currentFileText = fileText;
			_openedFiles = openedFiles;
			_selectedItem = null;
			foreach (var lang in Main.LangDetector.Languages)
			{
				if (_selectedItem == null && lang.Value.Extensions.Contains(tbExtension.Text))
					_selectedItem = lang.Value;
				cmbLanguage.Items.Add(lang.Value);
			}
			// TODO: Add lang autodetection
			_defaultLanguage = _selectedItem == null ? Main.LangDetector.Languages.First().Value : _selectedItem;
			cmbLanguage.SelectedItem = _defaultLanguage;
			SelectedLanguage = null;

			btnYes.Select();
		}

		private void btnYes_Click(object sender, EventArgs e)
		{
			AssociateOpenedFiles((NppLanguage)cmbLanguage.SelectedItem);
			
			Close();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			if (_selectedItem == null)
				AssociateOpenedFiles(_defaultLanguage);
			else
				Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)_defaultLanguage.LangType);

			Close();
		}

		private void AssociateOpenedFiles(NppLanguage lang)
		{
			SelectedLanguage = lang;

			Main.LangDetector.AddOrUpdateExtension(lang.Name, tbExtension.Text);
			Main.SaveLangs();

			//TODO: save and restore current active view and index
			string extWithPoint = tbExtension.Text != "" ? "." + tbExtension.Text : "";
			var langType = (int)lang.LangType;
			foreach (var file in _openedFiles)
			{
				if (!file.Path.StartsWith("new") && Path.GetExtension(file.Path) == extWithPoint)
				{
					Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, file.View, file.Index);
					Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, langType);
				}
			}
		}

		private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			var lang = (NppLanguage)cmbLanguage.SelectedItem;
			Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)lang.LangType);
		}
	}
}
