Namespace BillPoint
	' Token: 0x020000C0 RID: 192
		Public Partial Class frmCamera
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001B41 RID: 6977 RVA: 0x0012AFEC File Offset: 0x001291EC
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

		' Token: 0x06001B42 RID: 6978 RVA: 0x0012B03C File Offset: 0x0012923C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCamera))
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.picPreview = New Global.System.Windows.Forms.PictureBox()
			Me.saveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.btnCapture = New Global.System.Windows.Forms.Button()
			Me.cmbCamera = New Global.System.Windows.Forms.ComboBox()
			Me.lblCamera = New Global.System.Windows.Forms.Label()
			Me.picFeed = New Global.System.Windows.Forms.PictureBox()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.SaveFileDialog2 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			CType(Me.picPreview, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.picFeed, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.btnSave.BackColor = Global.System.Drawing.Color.DarkViolet
			Me.btnSave.BackgroundImage = CType(componentResourceManager.GetObject("btnSave.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnSave.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSave.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSave.Enabled = False
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(383, 261)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(127, 38)
			Me.btnSave.TabIndex = 11
			Me.btnSave.Text = "Copy"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.picPreview.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.picPreview.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.picPreview.Location = New Global.System.Drawing.Point(308, 39)
			Me.picPreview.Name = "picPreview"
			Me.picPreview.Size = New Global.System.Drawing.Size(276, 216)
			Me.picPreview.TabIndex = 10
			Me.picPreview.TabStop = False
			Me.btnCapture.BackColor = Global.System.Drawing.Color.DarkViolet
			Me.btnCapture.BackgroundImage = CType(componentResourceManager.GetObject("btnCapture.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnCapture.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnCapture.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnCapture.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCapture.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCapture.ForeColor = Global.System.Drawing.Color.White
			Me.btnCapture.Image = CType(componentResourceManager.GetObject("btnCapture.Image"), Global.System.Drawing.Image)
			Me.btnCapture.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCapture.Location = New Global.System.Drawing.Point(85, 261)
			Me.btnCapture.Name = "btnCapture"
			Me.btnCapture.Size = New Global.System.Drawing.Size(129, 38)
			Me.btnCapture.TabIndex = 9
			Me.btnCapture.Text = "Capture"
			Me.btnCapture.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCapture.UseVisualStyleBackColor = False
			Me.cmbCamera.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCamera.FormattingEnabled = True
			Me.cmbCamera.Location = New Global.System.Drawing.Point(95, 12)
			Me.cmbCamera.Name = "cmbCamera"
			Me.cmbCamera.Size = New Global.System.Drawing.Size(193, 21)
			Me.cmbCamera.TabIndex = 8
			Me.lblCamera.AutoSize = True
			Me.lblCamera.Location = New Global.System.Drawing.Point(12, 15)
			Me.lblCamera.Name = "lblCamera"
			Me.lblCamera.Size = New Global.System.Drawing.Size(82, 13)
			Me.lblCamera.TabIndex = 7
			Me.lblCamera.Text = "Select Camera :"
			Me.picFeed.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.picFeed.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.picFeed.Location = New Global.System.Drawing.Point(12, 39)
			Me.picFeed.Name = "picFeed"
			Me.picFeed.Size = New Global.System.Drawing.Size(276, 216)
			Me.picFeed.TabIndex = 6
			Me.picFeed.TabStop = False
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(305, 15)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(87, 13)
			Me.Label1.TabIndex = 12
			Me.Label1.Text = "Picture Preview :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(299, 287)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(31, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "........"
			Me.Label2.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.SystemColors.ButtonHighlight
			MyBase.ClientSize = New Global.System.Drawing.Size(596, 306)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.picPreview)
			MyBase.Controls.Add(Me.btnCapture)
			MyBase.Controls.Add(Me.cmbCamera)
			MyBase.Controls.Add(Me.lblCamera)
			MyBase.Controls.Add(Me.picFeed)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCamera"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Webcam"
			CType(Me.picPreview, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.picFeed, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000ABD RID: 2749
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
