namespace AutoLangDetect
{
	partial class frmSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbDetectLanguageAutomatically = new System.Windows.Forms.CheckBox();
			this.cbCheckEmptyExtensionFiles = new System.Windows.Forms.CheckBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.cbShowDetectLanguageDialog = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnResetExtensions = new System.Windows.Forms.Button();
			this.cbPasteClipboardTextToNewlyCreatedFile = new System.Windows.Forms.CheckBox();
			this.cbShowPasteTextDialog = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// cbDetectLanguageAutomatically
			// 
			this.cbDetectLanguageAutomatically.AutoSize = true;
			this.cbDetectLanguageAutomatically.Checked = true;
			this.cbDetectLanguageAutomatically.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbDetectLanguageAutomatically.Location = new System.Drawing.Point(12, 12);
			this.cbDetectLanguageAutomatically.Name = "cbDetectLanguageAutomatically";
			this.cbDetectLanguageAutomatically.Size = new System.Drawing.Size(169, 17);
			this.cbDetectLanguageAutomatically.TabIndex = 0;
			this.cbDetectLanguageAutomatically.Text = "Detect language automatically";
			this.cbDetectLanguageAutomatically.UseVisualStyleBackColor = true;
			// 
			// cbCheckEmptyExtensionFiles
			// 
			this.cbCheckEmptyExtensionFiles.AutoSize = true;
			this.cbCheckEmptyExtensionFiles.Checked = true;
			this.cbCheckEmptyExtensionFiles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbCheckEmptyExtensionFiles.Location = new System.Drawing.Point(12, 35);
			this.cbCheckEmptyExtensionFiles.Name = "cbCheckEmptyExtensionFiles";
			this.cbCheckEmptyExtensionFiles.Size = new System.Drawing.Size(157, 17);
			this.cbCheckEmptyExtensionFiles.TabIndex = 2;
			this.cbCheckEmptyExtensionFiles.Text = "Check empty extension files";
			this.cbCheckEmptyExtensionFiles.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(50, 163);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOkCancel_Click);
			// 
			// cbShowDetectLanguageDialog
			// 
			this.cbShowDetectLanguageDialog.AutoSize = true;
			this.cbShowDetectLanguageDialog.Checked = true;
			this.cbShowDetectLanguageDialog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowDetectLanguageDialog.Location = new System.Drawing.Point(12, 58);
			this.cbShowDetectLanguageDialog.Name = "cbShowDetectLanguageDialog";
			this.cbShowDetectLanguageDialog.Size = new System.Drawing.Size(164, 17);
			this.cbShowDetectLanguageDialog.TabIndex = 4;
			this.cbShowDetectLanguageDialog.Text = "Show detect language dialog";
			this.cbShowDetectLanguageDialog.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(131, 163);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnOkCancel_Click);
			// 
			// btnResetExtensions
			// 
			this.btnResetExtensions.Location = new System.Drawing.Point(50, 132);
			this.btnResetExtensions.Name = "btnResetExtensions";
			this.btnResetExtensions.Size = new System.Drawing.Size(156, 26);
			this.btnResetExtensions.TabIndex = 7;
			this.btnResetExtensions.Text = "Reset Extensions";
			this.btnResetExtensions.UseVisualStyleBackColor = true;
			this.btnResetExtensions.Click += new System.EventHandler(this.btnResetExtensions_Click);
			// 
			// cbPasteClipboardTextToNewlyCreatedFile
			// 
			this.cbPasteClipboardTextToNewlyCreatedFile.AutoSize = true;
			this.cbPasteClipboardTextToNewlyCreatedFile.Checked = true;
			this.cbPasteClipboardTextToNewlyCreatedFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbPasteClipboardTextToNewlyCreatedFile.Location = new System.Drawing.Point(12, 81);
			this.cbPasteClipboardTextToNewlyCreatedFile.Name = "cbPasteClipboardTextToNewlyCreatedFile";
			this.cbPasteClipboardTextToNewlyCreatedFile.Size = new System.Drawing.Size(216, 17);
			this.cbPasteClipboardTextToNewlyCreatedFile.TabIndex = 8;
			this.cbPasteClipboardTextToNewlyCreatedFile.Text = "Paste clipboard text to newly created file";
			this.cbPasteClipboardTextToNewlyCreatedFile.UseVisualStyleBackColor = true;
			// 
			// cbShowPasteTextDialog
			// 
			this.cbShowPasteTextDialog.AutoSize = true;
			this.cbShowPasteTextDialog.Checked = true;
			this.cbShowPasteTextDialog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowPasteTextDialog.Location = new System.Drawing.Point(12, 104);
			this.cbShowPasteTextDialog.Name = "cbShowPasteTextDialog";
			this.cbShowPasteTextDialog.Size = new System.Drawing.Size(133, 17);
			this.cbShowPasteTextDialog.TabIndex = 9;
			this.cbShowPasteTextDialog.Text = "Show paste text dialog";
			this.cbShowPasteTextDialog.UseVisualStyleBackColor = true;
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(244, 199);
			this.Controls.Add(this.cbShowPasteTextDialog);
			this.Controls.Add(this.cbPasteClipboardTextToNewlyCreatedFile);
			this.Controls.Add(this.btnResetExtensions);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.cbShowDetectLanguageDialog);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.cbCheckEmptyExtensionFiles);
			this.Controls.Add(this.cbDetectLanguageAutomatically);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Language Auto Detector";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbDetectLanguageAutomatically;
		private System.Windows.Forms.CheckBox cbCheckEmptyExtensionFiles;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.CheckBox cbShowDetectLanguageDialog;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnResetExtensions;
		private System.Windows.Forms.CheckBox cbPasteClipboardTextToNewlyCreatedFile;
		private System.Windows.Forms.CheckBox cbShowPasteTextDialog;
	}
}