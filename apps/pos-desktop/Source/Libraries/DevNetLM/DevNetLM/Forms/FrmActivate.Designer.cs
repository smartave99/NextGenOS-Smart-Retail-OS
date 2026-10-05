namespace DevNetLM.Forms
{
	// Token: 0x02000008 RID: 8
	public partial class FrmActivate : global::System.Windows.Forms.Form
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00002FC8 File Offset: 0x000011C8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003000 File Offset: 0x00001200
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::DevNetLM.Forms.FrmActivate));
			this.lblLicenseKey = new global::System.Windows.Forms.Label();
			this.tBoxLKey1 = new global::System.Windows.Forms.TextBox();
			this.tBoxLKey2 = new global::System.Windows.Forms.TextBox();
			this.tBoxLKey3 = new global::System.Windows.Forms.TextBox();
			this.tBoxLKey4 = new global::System.Windows.Forms.TextBox();
			this.tBoxLKey5 = new global::System.Windows.Forms.TextBox();
			this.btnActivate = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.tBoxSystemId = new global::System.Windows.Forms.TextBox();
			this.lblSystemId = new global::System.Windows.Forms.Label();
			this.lblProduct = new global::System.Windows.Forms.Label();
			this.lblVersion = new global::System.Windows.Forms.Label();
			this.valProductName = new global::System.Windows.Forms.Label();
			this.valProductVersion = new global::System.Windows.Forms.Label();
			this.valCompany = new global::System.Windows.Forms.Label();
			this.lblCompany = new global::System.Windows.Forms.Label();
			this.cBoxBindWith = new global::System.Windows.Forms.ComboBox();
			this.lblBindWith = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.btnTrial = new global::System.Windows.Forms.Button();
			this.btnCopySystemId = new global::System.Windows.Forms.Button();
			this.btnPasteLKey = new global::System.Windows.Forms.Button();
			this.MainDashPic = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.MainDashPic).BeginInit();
			base.SuspendLayout();
			this.lblLicenseKey.AutoSize = true;
			this.lblLicenseKey.ForeColor = global::System.Drawing.Color.White;
			this.lblLicenseKey.Location = new global::System.Drawing.Point(12, 153);
			this.lblLicenseKey.Name = "lblLicenseKey";
			this.lblLicenseKey.Size = new global::System.Drawing.Size(65, 13);
			this.lblLicenseKey.TabIndex = 0;
			this.lblLicenseKey.Text = "License Key";
			this.tBoxLKey1.Location = new global::System.Drawing.Point(83, 150);
			this.tBoxLKey1.MaxLength = 6;
			this.tBoxLKey1.Name = "tBoxLKey1";
			this.tBoxLKey1.Size = new global::System.Drawing.Size(51, 20);
			this.tBoxLKey1.TabIndex = 1;
			this.tBoxLKey1.TextChanged += new global::System.EventHandler(this.tBoxLKey1_TextChanged);
			this.tBoxLKey2.Location = new global::System.Drawing.Point(140, 150);
			this.tBoxLKey2.MaxLength = 6;
			this.tBoxLKey2.Name = "tBoxLKey2";
			this.tBoxLKey2.Size = new global::System.Drawing.Size(51, 20);
			this.tBoxLKey2.TabIndex = 2;
			this.tBoxLKey2.TextChanged += new global::System.EventHandler(this.tBoxLKey2_TextChanged);
			this.tBoxLKey3.Location = new global::System.Drawing.Point(197, 150);
			this.tBoxLKey3.MaxLength = 6;
			this.tBoxLKey3.Name = "tBoxLKey3";
			this.tBoxLKey3.Size = new global::System.Drawing.Size(51, 20);
			this.tBoxLKey3.TabIndex = 3;
			this.tBoxLKey3.TextChanged += new global::System.EventHandler(this.tBoxLKey3_TextChanged);
			this.tBoxLKey4.Location = new global::System.Drawing.Point(254, 150);
			this.tBoxLKey4.MaxLength = 6;
			this.tBoxLKey4.Name = "tBoxLKey4";
			this.tBoxLKey4.Size = new global::System.Drawing.Size(51, 20);
			this.tBoxLKey4.TabIndex = 4;
			this.tBoxLKey4.TextChanged += new global::System.EventHandler(this.tBoxLKey4_TextChanged);
			this.tBoxLKey5.Location = new global::System.Drawing.Point(311, 150);
			this.tBoxLKey5.MaxLength = 6;
			this.tBoxLKey5.Name = "tBoxLKey5";
			this.tBoxLKey5.Size = new global::System.Drawing.Size(51, 20);
			this.tBoxLKey5.TabIndex = 5;
			this.tBoxLKey5.TextChanged += new global::System.EventHandler(this.tBoxLKey5_TextChanged);
			this.btnActivate.BackColor = global::System.Drawing.Color.Green;
			this.btnActivate.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnActivate.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnActivate.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnActivate.ForeColor = global::System.Drawing.Color.White;
			this.btnActivate.ImageAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.btnActivate.Location = new global::System.Drawing.Point(356, 184);
			this.btnActivate.Name = "btnActivate";
			this.btnActivate.Size = new global::System.Drawing.Size(87, 39);
			this.btnActivate.TabIndex = 7;
			this.btnActivate.Text = "&Activate";
			this.btnActivate.UseVisualStyleBackColor = false;
			this.btnActivate.Click += new global::System.EventHandler(this.btnActivate_Click);
			this.btnCancel.BackColor = global::System.Drawing.Color.Red;
			this.btnCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnCancel.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancel.ForeColor = global::System.Drawing.Color.White;
			this.btnCancel.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new global::System.Drawing.Point(263, 184);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(87, 39);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "&Exit";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.tBoxSystemId.Location = new global::System.Drawing.Point(83, 121);
			this.tBoxSystemId.MaxLength = 255;
			this.tBoxSystemId.Name = "tBoxSystemId";
			this.tBoxSystemId.ReadOnly = true;
			this.tBoxSystemId.Size = new global::System.Drawing.Size(279, 20);
			this.tBoxSystemId.TabIndex = 10;
			this.lblSystemId.AutoSize = true;
			this.lblSystemId.ForeColor = global::System.Drawing.Color.White;
			this.lblSystemId.Location = new global::System.Drawing.Point(12, 124);
			this.lblSystemId.Name = "lblSystemId";
			this.lblSystemId.Size = new global::System.Drawing.Size(55, 13);
			this.lblSystemId.TabIndex = 9;
			this.lblSystemId.Text = "System ID";
			this.lblProduct.AutoSize = true;
			this.lblProduct.ForeColor = global::System.Drawing.Color.White;
			this.lblProduct.Location = new global::System.Drawing.Point(12, 19);
			this.lblProduct.Name = "lblProduct";
			this.lblProduct.Size = new global::System.Drawing.Size(44, 13);
			this.lblProduct.TabIndex = 12;
			this.lblProduct.Text = "Product";
			this.lblVersion.AutoSize = true;
			this.lblVersion.ForeColor = global::System.Drawing.Color.White;
			this.lblVersion.Location = new global::System.Drawing.Point(12, 44);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new global::System.Drawing.Size(42, 13);
			this.lblVersion.TabIndex = 13;
			this.lblVersion.Text = "Version";
			this.valProductName.AutoSize = true;
			this.valProductName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.valProductName.ForeColor = global::System.Drawing.Color.Yellow;
			this.valProductName.Location = new global::System.Drawing.Point(80, 19);
			this.valProductName.Name = "valProductName";
			this.valProductName.Size = new global::System.Drawing.Size(38, 13);
			this.valProductName.TabIndex = 14;
			this.valProductName.Text = "<NA>";
			this.valProductVersion.AutoSize = true;
			this.valProductVersion.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.valProductVersion.ForeColor = global::System.Drawing.Color.Yellow;
			this.valProductVersion.Location = new global::System.Drawing.Point(80, 44);
			this.valProductVersion.Name = "valProductVersion";
			this.valProductVersion.Size = new global::System.Drawing.Size(38, 13);
			this.valProductVersion.TabIndex = 15;
			this.valProductVersion.Text = "<NA>";
			this.valCompany.AutoSize = true;
			this.valCompany.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.valCompany.ForeColor = global::System.Drawing.Color.Yellow;
			this.valCompany.Location = new global::System.Drawing.Point(80, 69);
			this.valCompany.Name = "valCompany";
			this.valCompany.Size = new global::System.Drawing.Size(38, 13);
			this.valCompany.TabIndex = 17;
			this.valCompany.Text = "<NA>";
			this.lblCompany.AutoSize = true;
			this.lblCompany.ForeColor = global::System.Drawing.Color.White;
			this.lblCompany.Location = new global::System.Drawing.Point(12, 69);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new global::System.Drawing.Size(51, 13);
			this.lblCompany.TabIndex = 16;
			this.lblCompany.Text = "Company";
			this.cBoxBindWith.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cBoxBindWith.FormattingEnabled = true;
			this.cBoxBindWith.Location = new global::System.Drawing.Point(83, 94);
			this.cBoxBindWith.Name = "cBoxBindWith";
			this.cBoxBindWith.Size = new global::System.Drawing.Size(360, 21);
			this.cBoxBindWith.TabIndex = 18;
			this.cBoxBindWith.TabStop = false;
			this.cBoxBindWith.Visible = false;
			this.cBoxBindWith.SelectedIndexChanged += new global::System.EventHandler(this.cBoxBindWith_SelectedIndexChanged);
			this.lblBindWith.AutoSize = true;
			this.lblBindWith.ForeColor = global::System.Drawing.Color.White;
			this.lblBindWith.Location = new global::System.Drawing.Point(12, 97);
			this.lblBindWith.Name = "lblBindWith";
			this.lblBindWith.Size = new global::System.Drawing.Size(50, 13);
			this.lblBindWith.TabIndex = 19;
			this.lblBindWith.Text = "Bind with";
			this.lblBindWith.Visible = false;
			this.panel1.BackColor = global::System.Drawing.Color.AliceBlue;
			this.panel1.Location = new global::System.Drawing.Point(-2, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(465, 10);
			this.panel1.TabIndex = 22;
			this.pictureBox1.Image = null;
			this.pictureBox1.Location = new global::System.Drawing.Point(611, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(185, 168);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 23;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			this.btnTrial.BackColor = global::System.Drawing.Color.Azure;
			this.btnTrial.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnTrial.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnTrial.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnTrial.ForeColor = global::System.Drawing.Color.Navy;
			this.btnTrial.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("btnTrial.Image");
			this.btnTrial.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTrial.Location = new global::System.Drawing.Point(15, 184);
			this.btnTrial.Name = "btnTrial";
			this.btnTrial.Size = new global::System.Drawing.Size(87, 39);
			this.btnTrial.TabIndex = 20;
			this.btnTrial.Text = "&Trial";
			this.btnTrial.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnTrial.UseVisualStyleBackColor = false;
			this.btnTrial.Visible = false;
			this.btnTrial.Click += new global::System.EventHandler(this.btnTrial_Click);
			this.btnCopySystemId.BackColor = global::System.Drawing.Color.Azure;
			this.btnCopySystemId.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnCopySystemId.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCopySystemId.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnCopySystemId.ForeColor = global::System.Drawing.Color.Navy;
			this.btnCopySystemId.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("btnCopySystemId.Image");
			this.btnCopySystemId.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCopySystemId.Location = new global::System.Drawing.Point(368, 119);
			this.btnCopySystemId.Name = "btnCopySystemId";
			this.btnCopySystemId.Size = new global::System.Drawing.Size(75, 23);
			this.btnCopySystemId.TabIndex = 0;
			this.btnCopySystemId.Text = "&Copy";
			this.btnCopySystemId.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnCopySystemId.UseVisualStyleBackColor = false;
			this.btnCopySystemId.Click += new global::System.EventHandler(this.btnCopySystemId_Click);
			this.btnPasteLKey.BackColor = global::System.Drawing.Color.Azure;
			this.btnPasteLKey.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnPasteLKey.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnPasteLKey.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnPasteLKey.ForeColor = global::System.Drawing.Color.Navy;
			this.btnPasteLKey.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("btnPasteLKey.Image");
			this.btnPasteLKey.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPasteLKey.Location = new global::System.Drawing.Point(368, 148);
			this.btnPasteLKey.Name = "btnPasteLKey";
			this.btnPasteLKey.Size = new global::System.Drawing.Size(75, 23);
			this.btnPasteLKey.TabIndex = 6;
			this.btnPasteLKey.Text = "&Paste";
			this.btnPasteLKey.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnPasteLKey.UseVisualStyleBackColor = false;
			this.btnPasteLKey.Click += new global::System.EventHandler(this.btnPasteLKey_Click);
			this.MainDashPic.BackgroundImage = global::DevNetLM.Properties.Resources._background;
			this.MainDashPic.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.MainDashPic.ErrorImage = global::DevNetLM.Properties.Resources._background;
			this.MainDashPic.Location = new global::System.Drawing.Point(600, 32);
			this.MainDashPic.Name = "MainDashPic";
			this.MainDashPic.Size = new global::System.Drawing.Size(196, 181);
			this.MainDashPic.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.MainDashPic.TabIndex = 94;
			this.MainDashPic.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.Chocolate;
			base.ClientSize = new global::System.Drawing.Size(463, 233);
			base.Controls.Add(this.MainDashPic);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.btnTrial);
			base.Controls.Add(this.lblBindWith);
			base.Controls.Add(this.cBoxBindWith);
			base.Controls.Add(this.valCompany);
			base.Controls.Add(this.lblCompany);
			base.Controls.Add(this.valProductVersion);
			base.Controls.Add(this.valProductName);
			base.Controls.Add(this.lblVersion);
			base.Controls.Add(this.lblProduct);
			base.Controls.Add(this.btnCopySystemId);
			base.Controls.Add(this.tBoxSystemId);
			base.Controls.Add(this.lblSystemId);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnActivate);
			base.Controls.Add(this.btnPasteLKey);
			base.Controls.Add(this.tBoxLKey5);
			base.Controls.Add(this.tBoxLKey4);
			base.Controls.Add(this.tBoxLKey3);
			base.Controls.Add(this.tBoxLKey2);
			base.Controls.Add(this.tBoxLKey1);
			base.Controls.Add(this.lblLicenseKey);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmActivate";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "License Activation";
			base.Load += new global::System.EventHandler(this.FrmActivate_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.MainDashPic).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000024 RID: 36
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Label lblLicenseKey;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.TextBox tBoxLKey1;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.TextBox tBoxLKey2;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.TextBox tBoxLKey3;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.TextBox tBoxLKey4;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.TextBox tBoxLKey5;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Button btnPasteLKey;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Button btnActivate;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.TextBox tBoxSystemId;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.Label lblSystemId;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.Button btnCopySystemId;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.Label lblProduct;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.Label lblVersion;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.Label valProductName;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Label valProductVersion;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Label valCompany;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Label lblCompany;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.ComboBox cBoxBindWith;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.Label lblBindWith;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Button btnTrial;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400003C RID: 60
		internal global::System.Windows.Forms.PictureBox MainDashPic;
	}
}
