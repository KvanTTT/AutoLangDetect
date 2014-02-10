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
		List<FilePathViewIndex> _currentFiles;
		string _currentFileText;
		NppLanguage _selectedItem;

		public NppLanguage SelectedLanguage
		{
			get;
			private set;
		}

		public dlgAssociateExtension(FilePathViewIndex file, string fileText, List<FilePathViewIndex> openedFiles)
			: this(new List<FilePathViewIndex>() { file }, fileText, openedFiles)
		{
		}

		public dlgAssociateExtension(List<FilePathViewIndex> files, string fileText, List<FilePathViewIndex> openedFiles)
		{
			InitializeComponent();

			_currentFiles = files;
			string shortFileName = Path.GetFileName(files.First().Path);
			Text = string.Format("Associate Extension of file \"{0}\"", shortFileName);
			tbExtension.Text = Utils.GetExtensionWithoutDot(shortFileName);
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

		private void btnYesNo_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AssociateOpenedFiles(NppLanguage lang)
		{
			SelectedLanguage = lang;

			Main.LangDetector.AddOrUpdateExtension(lang.Name, tbExtension.Text);
			Main.SaveLangs();

			//TODO: save and restore current active view and index
			string extWithDot = Utils.AppendDotToExtension(tbExtension.Text);
			var langType = (int)lang.LangType;
			foreach (var file in _openedFiles)
			{
				if (!Utils.IsFileNew(file.Path) && Path.GetExtension(file.Path) == extWithDot)
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

		private void dlgAssociateExtension_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.Yes)
			{
				AssociateOpenedFiles((NppLanguage)cmbLanguage.SelectedItem);
			}
			else
			{
				if (_selectedItem == null)
					AssociateOpenedFiles(_defaultLanguage);
				else
					Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETCURRENTLANGTYPE, 0, (int)_defaultLanguage.LangType);
			}
		}
	}
}
