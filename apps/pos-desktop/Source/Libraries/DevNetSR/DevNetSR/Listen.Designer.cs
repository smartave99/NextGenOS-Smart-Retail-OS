namespace DevNetSR
{
	// Token: 0x02000004 RID: 4
	public partial class Listen : global::System.Windows.Forms.Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000035C8 File Offset: 0x000017C8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003600 File Offset: 0x00001800
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::DevNetSR.Listen));
			this.pBarAmplitude = new global::System.Windows.Forms.ProgressBar();
			this.breaker = new global::System.Windows.Forms.Timer(this.components);
			this.lblMsg = new global::System.Windows.Forms.Label();
			this.pBoxMic = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pBoxMic).BeginInit();
			base.SuspendLayout();
			this.pBarAmplitude.Location = new global::System.Drawing.Point(0, 246);
			this.pBarAmplitude.Name = "pBarAmplitude";
			this.pBarAmplitude.Size = new global::System.Drawing.Size(445, 8);
			this.pBarAmplitude.Step = 1;
			this.pBarAmplitude.TabIndex = 4;
			this.pBarAmplitude.Click += new global::System.EventHandler(this.pBarAmplitude_Click);
			this.breaker.Tick += new global::System.EventHandler(this.breaker_Tick);
			this.lblMsg.BackColor = global::System.Drawing.Color.Transparent;
			this.lblMsg.Font = new global::System.Drawing.Font("Arial", 27.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMsg.ForeColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.lblMsg.Location = new global::System.Drawing.Point(167, 152);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new global::System.Drawing.Size(266, 44);
			this.lblMsg.TabIndex = 10;
			this.lblMsg.Text = "Listening";
			this.lblMsg.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.pBoxMic.BackColor = global::System.Drawing.Color.Transparent;
			this.pBoxMic.Image = global::DevNetSR.Properties.Resources.Google_mic_svg;
			this.pBoxMic.Location = new global::System.Drawing.Point(12, 62);
			this.pBoxMic.Name = "pBoxMic";
			this.pBoxMic.Size = new global::System.Drawing.Size(149, 134);
			this.pBoxMic.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pBoxMic.TabIndex = 9;
			this.pBoxMic.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::DevNetSR.Properties.Resources.devstroop_bg_o25;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			base.ClientSize = new global::System.Drawing.Size(445, 254);
			base.ControlBox = false;
			base.Controls.Add(this.lblMsg);
			base.Controls.Add(this.pBoxMic);
			base.Controls.Add(this.pBarAmplitude);
			this.DoubleBuffered = true;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Listen";
			base.Opacity = 0.9;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmApp";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.FrmApp_Load);
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Listen_MouseDown);
			((global::System.ComponentModel.ISupportInitialize)this.pBoxMic).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000018 RID: 24
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.ProgressBar pBarAmplitude;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Timer breaker;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Label lblMsg;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.PictureBox pBoxMic;
	}
}
