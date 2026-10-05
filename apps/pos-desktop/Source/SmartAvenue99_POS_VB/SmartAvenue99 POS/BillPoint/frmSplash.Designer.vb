Namespace BillPoint
	' Token: 0x020005CF RID: 1487
		Public Partial Class frmSplash
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012240 RID: 74304 RVA: 0x00A703FC File Offset: 0x00A6E5FC
		<Global.System.Diagnostics.DebuggerNonUserCode()>
		Protected Overrides Sub Dispose(disposing As Boolean)
			Try
				Dim flag As Boolean = disposing AndAlso Me.components IsNot Nothing
				If flag Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		' Token: 0x06012241 RID: 74305 RVA: 0x00A7044C File Offset: 0x00A6E64C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSplash))
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.ProgressBar2 = New Global.System.Windows.Forms.ProgressBar()
			Me.lblSet2 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.LabelVersion = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.Panel1.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Timer1.Enabled = True
			Me.Timer1.Interval = 50
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(0, 768)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(1367, 10)
			Me.ProgressBar1.TabIndex = 14
			Me.ProgressBar1.Visible = False
			Me.lblSet.AutoSize = True
			Me.lblSet.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblSet.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.lblSet.ForeColor = Global.System.Drawing.Color.SlateGray
			Me.lblSet.Location = New Global.System.Drawing.Point(635, 736)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(14, 21)
			Me.lblSet.TabIndex = 15
			Me.lblSet.Text = "."
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10F)
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(1179, 738)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(174, 17)
			Me.LinkLabel1.TabIndex = 19
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "NextGen OS"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10F)
			Me.Label3.Location = New Global.System.Drawing.Point(1068, 737)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(100, 17)
			Me.Label3.TabIndex = 20
			Me.Label3.Text = "Developed By:"
			Me.ProgressBar2.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.ProgressBar2.Location = New Global.System.Drawing.Point(0, 365)
			Me.ProgressBar2.Name = "ProgressBar2"
			Me.ProgressBar2.Size = New Global.System.Drawing.Size(303, 5)
			Me.ProgressBar2.TabIndex = 24
			Me.lblSet2.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblSet2.ForeColor = Global.System.Drawing.Color.Red
			Me.lblSet2.Location = New Global.System.Drawing.Point(169, 2)
			Me.lblSet2.Name = "lblSet2"
			Me.lblSet2.Size = New Global.System.Drawing.Size(131, 20)
			Me.lblSet2.TabIndex = 25
			Me.lblSet2.Text = ".."
			Me.lblSet2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Label2.Font = New Global.System.Drawing.Font("Impact", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.FromArgb(192, 0, 192)
			Me.Label2.Location = New Global.System.Drawing.Point(-1, 332)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(305, 29)
			Me.Label2.TabIndex = 27
			Me.Label2.Text = "Premium Edition"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.LabelVersion.AutoSize = True
			Me.LabelVersion.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.LabelVersion.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LabelVersion.ForeColor = Global.System.Drawing.Color.Navy
			Me.LabelVersion.Location = New Global.System.Drawing.Point(0, 0)
			Me.LabelVersion.Margin = New Global.System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.LabelVersion.MaximumSize = New Global.System.Drawing.Size(0, 17)
			Me.LabelVersion.Name = "LabelVersion"
			Me.LabelVersion.Size = New Global.System.Drawing.Size(46, 15)
			Me.LabelVersion.TabIndex = 28
			Me.LabelVersion.Text = "Version"
			Me.LabelVersion.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label1.Font = New Global.System.Drawing.Font("Impact", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label1.Location = New Global.System.Drawing.Point(2, 295)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(298, 29)
			Me.Label1.TabIndex = 29
			Me.Label1.Text = "Smart Retail OS"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Location = New Global.System.Drawing.Point(162, 203)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(138, 158)
			Me.Panel1.TabIndex = 30
			Me.Panel1.Visible = False
			Me.Label4.Font = New Global.System.Drawing.Font("Impact", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label4.Location = New Global.System.Drawing.Point(1, 273)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(298, 29)
			Me.Label4.TabIndex = 32
			Me.Label4.Text = ""
			Me.Label4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label5.Font = New Global.System.Drawing.Font("Impact", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.FromArgb(192, 0, 192)
			Me.Label5.Location = New Global.System.Drawing.Point(-2, 310)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(305, 29)
			Me.Label5.TabIndex = 31
			Me.Label5.Text = "Premium Edition"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.PictureBox1.ErrorImage = Nothing
			Me.PictureBox1.Image = Nothing
			Me.PictureBox1.Location = New Global.System.Drawing.Point(150, 157)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(127, 106)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 30
			Me.PictureBox1.TabStop = False
			Me.PictureBox2.ErrorImage = Nothing
			Me.PictureBox2.Location = New Global.System.Drawing.Point(22, 25)
			Me.PictureBox2.Name = "PictureBox2"
			Me.PictureBox2.Size = New Global.System.Drawing.Size(256, 260)
			Me.PictureBox2.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox2.TabIndex = 24
			Me.PictureBox2.TabStop = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.AutoSizeMode = Global.System.Windows.Forms.AutoSizeMode.GrowAndShrink
			Me.BackColor = Global.System.Drawing.Color.White
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			MyBase.ClientSize = New Global.System.Drawing.Size(303, 370)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.lblSet2)
			MyBase.Controls.Add(Me.LabelVersion)
			MyBase.Controls.Add(Me.PictureBox2)
			MyBase.Controls.Add(Me.ProgressBar2)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.LinkLabel1)
			MyBase.Controls.Add(Me.lblSet)
			MyBase.Controls.Add(Me.ProgressBar1)
			Me.DoubleBuffered = True
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.Name = "frmSplash"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "frmSplash1"
			Me.Panel1.ResumeLayout(False)
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04006CF6 RID: 27894
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
