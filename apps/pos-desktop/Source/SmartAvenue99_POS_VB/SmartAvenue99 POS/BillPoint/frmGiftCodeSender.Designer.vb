Namespace BillPoint
	' Token: 0x02000116 RID: 278
		Public Partial Class frmGiftCodeSender
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002FA1 RID: 12193 RVA: 0x001D54B8 File Offset: 0x001D36B8
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

		' Token: 0x06002FA2 RID: 12194 RVA: 0x001D5508 File Offset: 0x001D3708
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmGiftCodeSender))
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.Start = New Global.System.Windows.Forms.Button()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, -1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(690, 38)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "Digital Gift Voucher Sender"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label20)
			Me.Panel1.Controls.Add(Me.Label19)
			Me.Panel1.Controls.Add(Me.Label18)
			Me.Panel1.Controls.Add(Me.Label17)
			Me.Panel1.Controls.Add(Me.Label16)
			Me.Panel1.Controls.Add(Me.Label15)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.Label9)
			Me.Panel1.Controls.Add(Me.Label11)
			Me.Panel1.Controls.Add(Me.Label12)
			Me.Panel1.Controls.Add(Me.Label13)
			Me.Panel1.Controls.Add(Me.Label14)
			Me.Panel1.Controls.Add(Me.Label10)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.ComboBox1)
			Me.Panel1.Controls.Add(Me.btnReset)
			Me.Panel1.Controls.Add(Me.Start)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(682, 400)
			Me.Panel1.TabIndex = 2
			Me.Label20.AutoSize = True
			Me.Label20.BackColor = Global.System.Drawing.Color.White
			Me.Label20.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label20.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.Label20.Location = New Global.System.Drawing.Point(125, 290)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(13, 18)
			Me.Label20.TabIndex = 524
			Me.Label20.Text = ":"
			Me.Label19.AutoSize = True
			Me.Label19.BackColor = Global.System.Drawing.Color.White
			Me.Label19.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label19.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.Label19.Location = New Global.System.Drawing.Point(125, 260)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(13, 18)
			Me.Label19.TabIndex = 523
			Me.Label19.Text = ":"
			Me.Label18.AutoSize = True
			Me.Label18.BackColor = Global.System.Drawing.Color.White
			Me.Label18.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.Label18.Location = New Global.System.Drawing.Point(125, 229)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(13, 18)
			Me.Label18.TabIndex = 522
			Me.Label18.Text = ":"
			Me.Label17.AutoSize = True
			Me.Label17.BackColor = Global.System.Drawing.Color.White
			Me.Label17.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.Label17.Location = New Global.System.Drawing.Point(125, 202)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(13, 18)
			Me.Label17.TabIndex = 521
			Me.Label17.Text = ":"
			Me.Label16.AutoSize = True
			Me.Label16.BackColor = Global.System.Drawing.Color.White
			Me.Label16.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label16.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.Label16.Location = New Global.System.Drawing.Point(125, 175)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(13, 18)
			Me.Label16.TabIndex = 520
			Me.Label16.Text = ":"
			Me.Label15.AutoSize = True
			Me.Label15.BackColor = Global.System.Drawing.Color.White
			Me.Label15.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label15.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.Label15.Location = New Global.System.Drawing.Point(125, 150)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(13, 18)
			Me.Label15.TabIndex = 519
			Me.Label15.Text = ":"
			Me.Label8.AutoSize = True
			Me.Label8.BackColor = Global.System.Drawing.Color.White
			Me.Label8.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label8.Location = New Global.System.Drawing.Point(5, 202)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(82, 18)
			Me.Label8.TabIndex = 518
			Me.Label8.Text = "Gift Code"
			Me.Label9.AutoSize = True
			Me.Label9.BackColor = Global.System.Drawing.Color.White
			Me.Label9.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label9.Location = New Global.System.Drawing.Point(5, 260)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(66, 18)
			Me.Label9.TabIndex = 517
			Me.Label9.Text = "Validity"
			Me.Label11.AutoSize = True
			Me.Label11.BackColor = Global.System.Drawing.Color.White
			Me.Label11.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label11.Location = New Global.System.Drawing.Point(5, 290)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(60, 18)
			Me.Label11.TabIndex = 516
			Me.Label11.Text = "Status"
			Me.Label12.AutoSize = True
			Me.Label12.BackColor = Global.System.Drawing.Color.White
			Me.Label12.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label12.Location = New Global.System.Drawing.Point(5, 229)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(102, 18)
			Me.Label12.TabIndex = 515
			Me.Label12.Text = "Gift Amount"
			Me.Label13.AutoSize = True
			Me.Label13.BackColor = Global.System.Drawing.Color.White
			Me.Label13.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label13.Location = New Global.System.Drawing.Point(5, 175)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(72, 18)
			Me.Label13.TabIndex = 514
			Me.Label13.Text = "Contact"
			Me.Label14.AutoSize = True
			Me.Label14.BackColor = Global.System.Drawing.Color.White
			Me.Label14.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label14.Location = New Global.System.Drawing.Point(5, 150)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(54, 18)
			Me.Label14.TabIndex = 513
			Me.Label14.Text = "Name"
			Me.Label10.AutoSize = True
			Me.Label10.BackColor = Global.System.Drawing.Color.White
			Me.Label10.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label10.Location = New Global.System.Drawing.Point(144, 202)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(23, 18)
			Me.Label10.TabIndex = 512
			Me.Label10.Text = "..."
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.White
			Me.Label6.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label6.Location = New Global.System.Drawing.Point(144, 260)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(23, 18)
			Me.Label6.TabIndex = 511
			Me.Label6.Text = "..."
			Me.Label5.AutoSize = True
			Me.Label5.BackColor = Global.System.Drawing.Color.White
			Me.Label5.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label5.Location = New Global.System.Drawing.Point(144, 290)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(23, 18)
			Me.Label5.TabIndex = 510
			Me.Label5.Text = "..."
			Me.Label4.AutoSize = True
			Me.Label4.BackColor = Global.System.Drawing.Color.White
			Me.Label4.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label4.Location = New Global.System.Drawing.Point(144, 229)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(23, 18)
			Me.Label4.TabIndex = 509
			Me.Label4.Text = "..."
			Me.Label3.AutoSize = True
			Me.Label3.BackColor = Global.System.Drawing.Color.White
			Me.Label3.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label3.Location = New Global.System.Drawing.Point(144, 175)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(23, 18)
			Me.Label3.TabIndex = 508
			Me.Label3.Text = "..."
			Me.Label7.AutoSize = True
			Me.Label7.BackColor = Global.System.Drawing.Color.White
			Me.Label7.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label7.Location = New Global.System.Drawing.Point(144, 150)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(23, 18)
			Me.Label7.TabIndex = 507
			Me.Label7.Text = "..."
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(17, 62)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(189, 25)
			Me.Label2.TabIndex = 506
			Me.Label2.Text = "Invoice Number :"
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Location = New Global.System.Drawing.Point(206, 62)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(420, 33)
			Me.ComboBox1.TabIndex = 505
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.Transparent
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(27, 337)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(44, 34)
			Me.btnReset.TabIndex = 504
			Me.btnReset.TabStop = False
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.Start.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Start.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Start.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Start.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Start.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Start.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Start.ForeColor = Global.System.Drawing.Color.White
			Me.Start.Image = CType(componentResourceManager.GetObject("Start.Image"), Global.System.Drawing.Image)
			Me.Start.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Start.Location = New Global.System.Drawing.Point(542, 297)
			Me.Start.Name = "Start"
			Me.Start.Size = New Global.System.Drawing.Size(135, 74)
			Me.Start.TabIndex = 503
			Me.Start.Text = "Send"
			Me.Start.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Start.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(682, 400)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmGiftCodeSender"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04001452 RID: 5202
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
