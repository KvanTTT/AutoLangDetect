namespace AutoLangDetect
{
	partial class dlgDetectLanguage
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
			this.cmbLanguage = new System.Windows.Forms.ComboBox();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.lblQuestion = new System.Windows.Forms.Label();
			this.cbShowDialogEveryTime = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// cmbLanguage
			// 
			this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cmbLanguage.FormattingEnabled = true;
			this.cmbLanguage.Location = new System.Drawing.Point(15, 37);
			this.cmbLanguage.Name = "cmbLanguage";
			this.cmbLanguage.Size = new System.Drawing.Size(401, 24);
			this.cmbLanguage.TabIndex = 0;
			this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
			// 
			// btnYes
			// 
			this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnYes.Location = new System.Drawing.Point(140, 77);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(75, 23);
			this.btnYes.TabIndex = 2;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnNo.Location = new System.Drawing.Point(221, 77);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(75, 23);
			this.btnNo.TabIndex = 3;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// lblQuestion
			// 
			this.lblQuestion.AutoSize = true;
			this.lblQuestion.Location = new System.Drawing.Point(12, 14);
			this.lblQuestion.Name = "lblQuestion";
			this.lblQuestion.Size = new System.Drawing.Size(316, 13);
			this.lblQuestion.TabIndex = 4;
			this.lblQuestion.Text = "Would you like to associate inserted text with following language?";
			// 
			// cbShowDialogEveryTime
			// 
			this.cbShowDialogEveryTime.AutoSize = true;
			this.cbShowDialogEveryTime.Checked = true;
			this.cbShowDialogEveryTime.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowDialogEveryTime.Location = new System.Drawing.Point(15, 106);
			this.cbShowDialogEveryTime.Name = "cbShowDialogEveryTime";
			this.cbShowDialogEveryTime.Size = new System.Drawing.Size(154, 17);
			this.cbShowDialogEveryTime.TabIndex = 5;
			this.cbShowDialogEveryTime.Text = "Show this dialog every time";
			this.cbShowDialogEveryTime.UseVisualStyleBackColor = true;
			this.cbShowDialogEveryTime.CheckedChanged += new System.EventHandler(this.cbShowDialogEveryTime_CheckedChanged);
			// 
			// dlgDetectLanguage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 136);
			this.Controls.Add(this.cbShowDialogEveryTime);
			this.Controls.Add(this.lblQuestion);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.cmbLanguage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgDetectLanguage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Detect Language";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbLanguage;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Label lblQuestion;
		private System.Windows.Forms.CheckBox cbShowDialogEveryTime;
	}
}