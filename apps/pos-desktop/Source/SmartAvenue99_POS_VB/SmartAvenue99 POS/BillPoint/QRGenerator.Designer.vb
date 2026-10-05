Namespace BillPoint
	' Token: 0x02000475 RID: 1141
		Public Partial Class QRGenerator
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600E821 RID: 59425 RVA: 0x008CE384 File Offset: 0x008CC584
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

		' Token: 0x0600E822 RID: 59426 RVA: 0x008CE3D4 File Offset: 0x008CC5D4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.QRGenerator))
			Me.txtCode = New Global.System.Windows.Forms.TextBox()
			Me.btnGenerate = New Global.System.Windows.Forms.Button()
			Me.btnExport = New Global.System.Windows.Forms.Button()
			Me.ToolTip1 = New Global.System.Windows.Forms.ToolTip(Me.components)
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.BunifuCards1 = New Global.Bunifu.Framework.UI.BunifuCards()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.BunifuCards1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.txtCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCode.Location = New Global.System.Drawing.Point(13, 323)
			Me.txtCode.Multiline = True
			Me.txtCode.Name = "txtCode"
			Me.txtCode.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtCode.Size = New Global.System.Drawing.Size(300, 79)
			Me.txtCode.TabIndex = 3
			Me.ToolTip1.SetToolTip(Me.txtCode, "Enter code here")
			Me.btnGenerate.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGenerate.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnGenerate.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnGenerate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGenerate.Font = New Global.System.Drawing.Font("Arial", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGenerate.ForeColor = Global.System.Drawing.Color.White
			Me.btnGenerate.Location = New Global.System.Drawing.Point(13, 411)
			Me.btnGenerate.Name = "btnGenerate"
			Me.btnGenerate.Size = New Global.System.Drawing.Size(91, 50)
			Me.btnGenerate.TabIndex = 4
			Me.btnGenerate.Text = "Generate Code"
			Me.ToolTip1.SetToolTip(Me.btnGenerate, "Click to generate code")
			Me.btnGenerate.UseVisualStyleBackColor = False
			Me.btnExport.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnExport.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExport.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnExport.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExport.Font = New Global.System.Drawing.Font("Arial", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExport.ForeColor = Global.System.Drawing.Color.White
			Me.btnExport.Location = New Global.System.Drawing.Point(120, 411)
			Me.btnExport.Name = "btnExport"
			Me.btnExport.Size = New Global.System.Drawing.Size(89, 50)
			Me.btnExport.TabIndex = 5
			Me.btnExport.Text = "Export to Image"
			Me.ToolTip1.SetToolTip(Me.btnExport, "Click to import into image")
			Me.btnExport.UseVisualStyleBackColor = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.PictureBox1.Location = New Global.System.Drawing.Point(13, 14)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(300, 300)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 1
			Me.PictureBox1.TabStop = False
			Me.BunifuCards1.BackColor = Global.System.Drawing.Color.White
			Me.BunifuCards1.BorderRadius = 5
			Me.BunifuCards1.BottomSahddow = True
			Me.BunifuCards1.color = Global.System.Drawing.Color.Lime
			Me.BunifuCards1.Controls.Add(Me.Button2)
			Me.BunifuCards1.Controls.Add(Me.btnExport)
			Me.BunifuCards1.Controls.Add(Me.btnGenerate)
			Me.BunifuCards1.Controls.Add(Me.txtCode)
			Me.BunifuCards1.Controls.Add(Me.PictureBox1)
			Me.BunifuCards1.LeftSahddow = False
			Me.BunifuCards1.Location = New Global.System.Drawing.Point(4, 30)
			Me.BunifuCards1.Name = "BunifuCards1"
			Me.BunifuCards1.RightSahddow = True
			Me.BunifuCards1.ShadowDepth = 20
			Me.BunifuCards1.Size = New Global.System.Drawing.Size(328, 470)
			Me.BunifuCards1.TabIndex = 6
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Arial", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Location = New Global.System.Drawing.Point(224, 411)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(89, 50)
			Me.Button2.TabIndex = 6
			Me.Button2.Text = "Reset"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Label2.BackColor = Global.System.Drawing.Color.Gold
			Me.Label2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label2.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label2.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(335, 31)
			Me.Label2.TabIndex = 149
			Me.Label2.Text = "QR Code Generator"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Button1.BackColor = Global.System.Drawing.Color.White
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.Location = New Global.System.Drawing.Point(305, 0)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(31, 31)
			Me.Button1.TabIndex = 150
			Me.Button1.TabStop = False
			Me.Button1.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.Red
			MyBase.ClientSize = New Global.System.Drawing.Size(335, 503)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.BunifuCards1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Name = "QRGenerator"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "QR Code Generator"
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.BunifuCards1.ResumeLayout(False)
			Me.BunifuCards1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400593F RID: 22847
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
