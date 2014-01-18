namespace AutoLangDetect.Forms
{
	partial class frmAssociateExtension
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
			this.cbShowDialogEveryTime = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.cmbLanguage = new System.Windows.Forms.ComboBox();
			this.tbExtension = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbShowDialogEveryTime
			// 
			this.cbShowDialogEveryTime.AutoSize = true;
			this.cbShowDialogEveryTime.Checked = true;
			this.cbShowDialogEveryTime.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowDialogEveryTime.Location = new System.Drawing.Point(15, 116);
			this.cbShowDialogEveryTime.Name = "cbShowDialogEveryTime";
			this.cbShowDialogEveryTime.Size = new System.Drawing.Size(154, 17);
			this.cbShowDialogEveryTime.TabIndex = 6;
			this.cbShowDialogEveryTime.Text = "Show this dialog every time";
			this.cbShowDialogEveryTime.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(258, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Associate following extension with language from list?";
			// 
			// btnYes
			// 
			this.btnYes.Location = new System.Drawing.Point(63, 83);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(75, 23);
			this.btnYes.TabIndex = 8;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.Location = new System.Drawing.Point(144, 83);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(75, 23);
			this.btnNo.TabIndex = 9;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// cmbLanguage
			// 
			this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLanguage.FormattingEnabled = true;
			this.cmbLanguage.Location = new System.Drawing.Point(135, 44);
			this.cmbLanguage.Name = "cmbLanguage";
			this.cmbLanguage.Size = new System.Drawing.Size(135, 21);
			this.cmbLanguage.TabIndex = 10;
			// 
			// tbExtension
			// 
			this.tbExtension.Location = new System.Drawing.Point(15, 45);
			this.tbExtension.Name = "tbExtension";
			this.tbExtension.ReadOnly = true;
			this.tbExtension.Size = new System.Drawing.Size(78, 20);
			this.tbExtension.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(105, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "→";
			// 
			// frmAssociateExtension
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 146);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbExtension);
			this.Controls.Add(this.cmbLanguage);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbShowDialogEveryTime);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAssociateExtension";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Associate Extension";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbShowDialogEveryTime;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.ComboBox cmbLanguage;
		private System.Windows.Forms.TextBox tbExtension;
		private System.Windows.Forms.Label label2;
	}
}