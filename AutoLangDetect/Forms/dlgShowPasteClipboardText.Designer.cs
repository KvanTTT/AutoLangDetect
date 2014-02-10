namespace AutoLangDetect
{
	partial class dlgShowPasteClipboardText
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
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cbShowDialogEveryTime = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnYes
			// 
			this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnYes.Location = new System.Drawing.Point(46, 34);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(75, 23);
			this.btnYes.TabIndex = 0;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new System.EventHandler(this.btnYesNo_Click);
			// 
			// btnNo
			// 
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnNo.Location = new System.Drawing.Point(127, 34);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(75, 23);
			this.btnNo.TabIndex = 1;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new System.EventHandler(this.btnYesNo_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(213, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Would you like to paste text from clipboard?";
			// 
			// cbShowDialogEveryTime
			// 
			this.cbShowDialogEveryTime.AutoSize = true;
			this.cbShowDialogEveryTime.Checked = true;
			this.cbShowDialogEveryTime.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowDialogEveryTime.Location = new System.Drawing.Point(15, 72);
			this.cbShowDialogEveryTime.Name = "cbShowDialogEveryTime";
			this.cbShowDialogEveryTime.Size = new System.Drawing.Size(154, 17);
			this.cbShowDialogEveryTime.TabIndex = 3;
			this.cbShowDialogEveryTime.Text = "Show this dialog every time";
			this.cbShowDialogEveryTime.UseVisualStyleBackColor = true;
			this.cbShowDialogEveryTime.CheckedChanged += new System.EventHandler(this.cbShowDialogEveryTime_CheckedChanged);
			// 
			// dlgShowPasteClipboardText
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnNo;
			this.ClientSize = new System.Drawing.Size(249, 101);
			this.Controls.Add(this.cbShowDialogEveryTime);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnYes);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgShowPasteClipboardText";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Paste text";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgShowPasteClipboardText_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbShowDialogEveryTime;
	}
}