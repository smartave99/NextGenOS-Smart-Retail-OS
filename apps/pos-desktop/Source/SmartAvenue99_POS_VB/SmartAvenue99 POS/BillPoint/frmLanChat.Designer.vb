Namespace BillPoint
	' Token: 0x0200034A RID: 842
		Public Partial Class frmLanChat
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C540 RID: 50496 RVA: 0x007D058C File Offset: 0x007CE78C
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

		' Token: 0x0600C541 RID: 50497 RVA: 0x007D05DC File Offset: 0x007CE7DC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmLanChat))
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.ImageList1 = New Global.System.Windows.Forms.ImageList(Me.components)
			Me.ListBox1 = New Global.System.Windows.Forms.ListBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.BackgroundWorker1 = New Global.System.ComponentModel.BackgroundWorker()
			MyBase.SuspendLayout()
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(10, 24)
			Me.Label1.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(80, 13)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Terminal ID :"
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(10, 53)
			Me.Label2.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(147, 13)
			Me.Label2.TabIndex = 1
			Me.Label2.Text = "Client Local IP Address :"
			Me.TextBox1.Location = New Global.System.Drawing.Point(91, 21)
			Me.TextBox1.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(208, 20)
			Me.TextBox1.TabIndex = 2
			Me.TextBox1.TabStop = False
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox2.Location = New Global.System.Drawing.Point(154, 50)
			Me.TextBox2.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(145, 20)
			Me.TextBox2.TabIndex = 3
			Me.TextBox2.TabStop = False
			Me.TextBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(14, 105)
			Me.TextBox3.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.TextBox3.Multiline = True
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(285, 71)
			Me.TextBox3.TabIndex = 4
			Me.Button1.BackColor = Global.System.Drawing.Color.White
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.ForeColor = Global.System.Drawing.Color.Blue
			Me.Button1.Location = New Global.System.Drawing.Point(212, 180)
			Me.Button1.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(88, 32)
			Me.Button1.TabIndex = 5
			Me.Button1.Text = "Send"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Timer1.Interval = 1
			Me.Label3.AutoSize = True
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(10, 89)
			Me.Label3.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(106, 13)
			Me.Label3.TabIndex = 7
			Me.Label3.Text = "Create Message :"
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(303, 5)
			Me.Label4.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(66, 13)
			Me.Label4.TabIndex = 8
			Me.Label4.Text = "Chat Box :"
			Me.ImageList1.ImageStream = CType(componentResourceManager.GetObject("ImageList1.ImageStream"), Global.System.Windows.Forms.ImageListStreamer)
			Me.ImageList1.TransparentColor = Global.System.Drawing.Color.Transparent
			Me.ImageList1.Images.SetKeyName(0, "Computer.bmp")
			Me.ListBox1.BackColor = Global.System.Drawing.Color.White
			Me.ListBox1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListBox1.FormattingEnabled = True
			Me.ListBox1.Location = New Global.System.Drawing.Point(307, 22)
			Me.ListBox1.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.ListBox1.Name = "ListBox1"
			Me.ListBox1.Size = New Global.System.Drawing.Size(430, 342)
			Me.ListBox1.TabIndex = 10
			Me.ListBox1.TabStop = False
			Me.Button2.BackColor = Global.System.Drawing.Color.White
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.ForeColor = Global.System.Drawing.Color.Blue
			Me.Button2.Location = New Global.System.Drawing.Point(14, 180)
			Me.Button2.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(88, 32)
			Me.Button2.TabIndex = 11
			Me.Button2.Text = "Reset"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button3.BackColor = Global.System.Drawing.Color.White
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.ForeColor = Global.System.Drawing.Color.Blue
			Me.Button3.Location = New Global.System.Drawing.Point(113, 180)
			Me.Button3.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(88, 32)
			Me.Button3.TabIndex = 12
			Me.Button3.Text = "Save"
			Me.Button3.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(138, 356)
			Me.Label5.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(27, 13)
			Me.Label5.TabIndex = 13
			Me.Label5.Text = "....."
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(10, 356)
			Me.Label6.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(131, 13)
			Me.Label6.TabIndex = 14
			Me.Label6.Text = "My Local IP Address :"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(7F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(749, 375)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.ListBox1)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.TextBox3)
			MyBase.Controls.Add(Me.TextBox2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			Me.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			MyBase.MaximizeBox = False
			MyBase.Name = "frmLanChat"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "LAN Chat"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04004F11 RID: 20241
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
