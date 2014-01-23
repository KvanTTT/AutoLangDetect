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
			this.cbShowAssociateExtensionDialog = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
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
			this.btnOk.Location = new System.Drawing.Point(27, 116);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
			// cbShowAssociateExtensionDialog
			// 
			this.cbShowAssociateExtensionDialog.AutoSize = true;
			this.cbShowAssociateExtensionDialog.Checked = true;
			this.cbShowAssociateExtensionDialog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowAssociateExtensionDialog.Location = new System.Drawing.Point(12, 81);
			this.cbShowAssociateExtensionDialog.Name = "cbShowAssociateExtensionDialog";
			this.cbShowAssociateExtensionDialog.Size = new System.Drawing.Size(180, 17);
			this.cbShowAssociateExtensionDialog.TabIndex = 5;
			this.cbShowAssociateExtensionDialog.Text = "Show associate extension dialog";
			this.cbShowAssociateExtensionDialog.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(108, 116);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 155);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.cbShowAssociateExtensionDialog);
			this.Controls.Add(this.cbShowDetectLanguageDialog);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.cbCheckEmptyExtensionFiles);
			this.Controls.Add(this.cbDetectLanguageAutomatically);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Language Auto Detector";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbDetectLanguageAutomatically;
		private System.Windows.Forms.CheckBox cbCheckEmptyExtensionFiles;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.CheckBox cbShowDetectLanguageDialog;
		private System.Windows.Forms.CheckBox cbShowAssociateExtensionDialog;
		private System.Windows.Forms.Button btnCancel;
	}
}