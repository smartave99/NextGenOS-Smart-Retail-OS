namespace DevNetSR
{
	// Token: 0x02000002 RID: 2
	public partial class Configuration : global::System.Windows.Forms.Form
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002190 File Offset: 0x00000390
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021C8 File Offset: 0x000003C8
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::DevNetSR.Configuration));
			this.lblMsg = new global::System.Windows.Forms.Label();
			this.cBoxLanguages = new global::System.Windows.Forms.ComboBox();
			this.btnSave = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.lblMsg.Font = new global::System.Drawing.Font("Arial", 15.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMsg.ForeColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.lblMsg.Location = new global::System.Drawing.Point(54, 12);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new global::System.Drawing.Size(379, 36);
			this.lblMsg.TabIndex = 7;
			this.lblMsg.Text = "Configuration";
			this.lblMsg.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cBoxLanguages.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cBoxLanguages.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cBoxLanguages.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cBoxLanguages.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cBoxLanguages.ForeColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.cBoxLanguages.FormattingEnabled = true;
			this.cBoxLanguages.Location = new global::System.Drawing.Point(12, 104);
			this.cBoxLanguages.Name = "cBoxLanguages";
			this.cBoxLanguages.Size = new global::System.Drawing.Size(421, 27);
			this.cBoxLanguages.TabIndex = 9;
			this.btnSave.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnSave.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnSave.ForeColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.btnSave.Location = new global::System.Drawing.Point(227, 151);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new global::System.Drawing.Size(100, 30);
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new global::System.EventHandler(this.btnSave_Click);
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancel.ForeColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.btnCancel.Location = new global::System.Drawing.Point(333, 151);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(100, 30);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Arial", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.label1.Location = new global::System.Drawing.Point(45, 75);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(78, 18);
			this.label1.TabIndex = 14;
			this.label1.Text = "Language";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.label2.Location = new global::System.Drawing.Point(12, 159);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(161, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Developed By : NextGen OS";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Visible = false;
			this.pictureBox2.Image = global::DevNetSR.Properties.Resources.config_icon;
			this.pictureBox2.Location = new global::System.Drawing.Point(12, 12);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(36, 36);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 13;
			this.pictureBox2.TabStop = false;
			this.pictureBox1.Image = global::DevNetSR.Properties.Resources.language;
			this.pictureBox1.Location = new global::System.Drawing.Point(12, 71);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(27, 27);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(445, 193);
			base.ControlBox = false;
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnSave);
			base.Controls.Add(this.cBoxLanguages);
			base.Controls.Add(this.lblMsg);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Configuration";
			base.Opacity = 0.9;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuration";
			base.Load += new global::System.EventHandler(this.Configuration_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000002 RID: 2
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Label lblMsg;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.ComboBox cBoxLanguages;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Button btnSave;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Label label2;
	}
}
