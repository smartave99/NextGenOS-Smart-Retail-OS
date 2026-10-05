Namespace BillPoint
	' Token: 0x02000118 RID: 280
		Public Partial Class frmGodownConfig
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002FEA RID: 12266 RVA: 0x001D7C6C File Offset: 0x001D5E6C
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

		' Token: 0x06002FEB RID: 12267 RVA: 0x001D7CBC File Offset: 0x001D5EBC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmGodownConfig))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnDelete = New Global.CButtonLib.CButton()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.Button3 = New Global.CButtonLib.CButton()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.btnDelete)
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.lblUserType)
			Me.Panel1.Controls.Add(Me.Button3)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Location = New Global.System.Drawing.Point(6, 6)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(589, 258)
			Me.Panel1.TabIndex = 0
			Me.btnDelete.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnDelete.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnDelete.Corners.All = 5
			Me.btnDelete.Corners.LowerLeft = 5
			Me.btnDelete.Corners.LowerRight = 5
			Me.btnDelete.Corners.UpperLeft = 5
			Me.btnDelete.Corners.UpperRight = 5
			Me.btnDelete.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnDelete.DesignerSelected = False
			Me.btnDelete.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete.Image = CType(componentResourceManager.GetObject("btnDelete.Image"), Global.System.Drawing.Image)
			Me.btnDelete.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete.ImageIndex = 0
			Me.btnDelete.ImageSize = New Global.System.Drawing.Size(32, 32)
			Me.btnDelete.Location = New Global.System.Drawing.Point(6, 211)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(139, 40)
			Me.btnDelete.TabIndex = 1762
			Me.btnDelete.TabStop = False
			Me.btnDelete.Text = "&Delete All Cloud Records"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(126, 160)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(331, 91)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.PictureBox1.TabIndex = 1764
			Me.PictureBox1.TabStop = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Black", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(5, 5)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(577, 33)
			Me.Label1.TabIndex = 3
			Me.Label1.Text = "Multi Branch Cloud Stock Storage Configuration"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(485, 19)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(63, 13)
			Me.lblUserType.TabIndex = 1763
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.Button3.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Corners.All = 5
			Me.Button3.Corners.LowerLeft = 5
			Me.Button3.Corners.LowerRight = 5
			Me.Button3.Corners.UpperLeft = 5
			Me.Button3.Corners.UpperRight = 5
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.DesignerSelected = False
			Me.Button3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.ImageIndex = 0
			Me.Button3.ImageSize = New Global.System.Drawing.Size(27, 27)
			Me.Button3.Location = New Global.System.Drawing.Point(488, 214)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(94, 37)
			Me.Button3.TabIndex = 2
			Me.Button3.Text = "&Save"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.TextBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(6, 131)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(576, 23)
			Me.TextBox2.TabIndex = 1
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(6, 69)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.TextBox1.Size = New Global.System.Drawing.Size(576, 23)
			Me.TextBox1.TabIndex = 0
			Me.Label3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.Label3.Location = New Global.System.Drawing.Point(7, 111)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(79, 17)
			Me.Label3.TabIndex = 1758
			Me.Label3.Text = "Secret Key :"
			Me.Label2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.Label2.Location = New Global.System.Drawing.Point(3, 49)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(65, 17)
			Me.Label2.TabIndex = 1757
			Me.Label2.Text = "Domain :"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(601, 270)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmGodownConfig"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400147C RID: 5244
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
