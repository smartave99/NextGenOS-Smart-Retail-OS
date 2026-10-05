Namespace BillPoint
	' Token: 0x020004C3 RID: 1219
		Public Partial Class frmEmailsender
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600F491 RID: 62609 RVA: 0x00929A00 File Offset: 0x00927C00
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

		' Token: 0x0600F492 RID: 62610 RVA: 0x00929A50 File Offset: 0x00927C50
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmEmailsender))
			Me.Timerdate = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.tbTo = New Global.System.Windows.Forms.TextBox()
			Me.tbUname = New Global.System.Windows.Forms.TextBox()
			Me.tbPass = New Global.System.Windows.Forms.TextBox()
			Me.tbCc = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Button6 = New Global.System.Windows.Forms.Button()
			Me.Button7 = New Global.System.Windows.Forms.Button()
			Me.lblerroruser = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.lblerrorccend = New Global.System.Windows.Forms.Label()
			Me.lblerrortoend = New Global.System.Windows.Forms.Label()
			Me.lblerrorsubject = New Global.System.Windows.Forms.Label()
			Me.lblerrorcc = New Global.System.Windows.Forms.Label()
			Me.lblerrorto = New Global.System.Windows.Forms.Label()
			Me.lblAttach = New Global.System.Windows.Forms.Label()
			Me.btnBrowse = New Global.System.Windows.Forms.Button()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.cbEndcc = New Global.System.Windows.Forms.ComboBox()
			Me.cbEnd = New Global.System.Windows.Forms.ComboBox()
			Me.ToolStrip1 = New Global.System.Windows.Forms.ToolStrip()
			Me.tbrFont = New Global.System.Windows.Forms.ToolStripButton()
			Me.ToolStripSeparator4 = New Global.System.Windows.Forms.ToolStripSeparator()
			Me.tbrLeft = New Global.System.Windows.Forms.ToolStripButton()
			Me.tbrCenter = New Global.System.Windows.Forms.ToolStripButton()
			Me.tbrRight = New Global.System.Windows.Forms.ToolStripButton()
			Me.ToolStripSeparator2 = New Global.System.Windows.Forms.ToolStripSeparator()
			Me.tbrBold = New Global.System.Windows.Forms.ToolStripButton()
			Me.tbrItalic = New Global.System.Windows.Forms.ToolStripButton()
			Me.tbrUnderline = New Global.System.Windows.Forms.ToolStripButton()
			Me.ToolStripSeparator3 = New Global.System.Windows.Forms.ToolStripSeparator()
			Me.tbrOpen = New Global.System.Windows.Forms.ToolStripButton()
			Me.tbBody = New Global.System.Windows.Forms.RichTextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.tbSubject = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.lblDate = New Global.System.Windows.Forms.Label()
			Me.lblTime = New Global.System.Windows.Forms.Label()
			Me.TimerProgressbar = New Global.System.Windows.Forms.Timer(Me.components)
			Me.FontDialog1 = New Global.System.Windows.Forms.FontDialog()
			Me.lblStatus = New Global.System.Windows.Forms.Label()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.OpenFileDialog2 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.btnSend = New Global.System.Windows.Forms.Button()
			Me.btnClear = New Global.System.Windows.Forms.Button()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.ToolStrip1.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.ProgressBar1.ForeColor = Global.System.Drawing.Color.Yellow
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(4, 507)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(708, 29)
			Me.ProgressBar1.TabIndex = 3
			Me.ProgressBar1.Visible = False
			Me.tbTo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.tbTo.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Lower
			Me.tbTo.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.tbTo.Location = New Global.System.Drawing.Point(113, 17)
			Me.tbTo.Multiline = True
			Me.tbTo.Name = "tbTo"
			Me.tbTo.Size = New Global.System.Drawing.Size(440, 21)
			Me.tbTo.TabIndex = 11
			Me.tbUname.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 255)
			Me.tbUname.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Lower
			Me.tbUname.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.tbUname.ForeColor = Global.System.Drawing.Color.Blue
			Me.tbUname.Location = New Global.System.Drawing.Point(78, 18)
			Me.tbUname.Multiline = True
			Me.tbUname.Name = "tbUname"
			Me.tbUname.[ReadOnly] = True
			Me.tbUname.Size = New Global.System.Drawing.Size(381, 23)
			Me.tbUname.TabIndex = 14
			Me.tbPass.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 255)
			Me.tbPass.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.tbPass.ForeColor = Global.System.Drawing.Color.Blue
			Me.tbPass.Location = New Global.System.Drawing.Point(78, 47)
			Me.tbPass.Multiline = True
			Me.tbPass.Name = "tbPass"
			Me.tbPass.PasswordChar = "♠"c
			Me.tbPass.[ReadOnly] = True
			Me.tbPass.Size = New Global.System.Drawing.Size(223, 22)
			Me.tbPass.TabIndex = 15
			Me.tbCc.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.tbCc.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Lower
			Me.tbCc.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.tbCc.Location = New Global.System.Drawing.Point(113, 63)
			Me.tbCc.Multiline = True
			Me.tbCc.Name = "tbCc"
			Me.tbCc.Size = New Global.System.Drawing.Size(440, 21)
			Me.tbCc.TabIndex = 16
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.Black
			Me.Label1.Location = New Global.System.Drawing.Point(3, 18)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(77, 15)
			Me.Label1.TabIndex = 17
			Me.Label1.Text = "Username:"
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(3, 49)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(73, 15)
			Me.Label2.TabIndex = 18
			Me.Label2.Text = "Password:"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(27, 18)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(27, 15)
			Me.Label3.TabIndex = 19
			Me.Label3.Text = "To:"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(27, 65)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(27, 15)
			Me.Label4.TabIndex = 20
			Me.Label4.Text = "Cc:"
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.TextBox1)
			Me.GroupBox1.Controls.Add(Me.Button6)
			Me.GroupBox1.Controls.Add(Me.Button7)
			Me.GroupBox1.Controls.Add(Me.lblerroruser)
			Me.GroupBox1.Controls.Add(Me.tbUname)
			Me.GroupBox1.Controls.Add(Me.tbPass)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox1.ForeColor = Global.System.Drawing.Color.Black
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 36)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(468, 76)
			Me.GroupBox1.TabIndex = 22
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Sender Details"
			Me.TextBox1.Location = New Global.System.Drawing.Point(43, 33)
			Me.TextBox1.Multiline = True
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(11, 19)
			Me.TextBox1.TabIndex = 37
			Me.TextBox1.TabStop = False
			Me.TextBox1.Visible = False
			Me.Button6.BackColor = Global.System.Drawing.Color.White
			Me.Button6.BackgroundImage = CType(componentResourceManager.GetObject("Button6.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			Me.Button6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button6.Enabled = False
			Me.Button6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button6.ForeColor = Global.System.Drawing.Color.White
			Me.Button6.Location = New Global.System.Drawing.Point(263, 49)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(38, 19)
			Me.Button6.TabIndex = 22
			Me.Button6.TabStop = False
			Me.Button6.UseVisualStyleBackColor = False
			Me.Button7.BackColor = Global.System.Drawing.Color.White
			Me.Button7.BackgroundImage = CType(componentResourceManager.GetObject("Button7.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button7.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			Me.Button7.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button7.Enabled = False
			Me.Button7.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button7.ForeColor = Global.System.Drawing.Color.White
			Me.Button7.Location = New Global.System.Drawing.Point(263, 49)
			Me.Button7.Name = "Button7"
			Me.Button7.Size = New Global.System.Drawing.Size(38, 19)
			Me.Button7.TabIndex = 23
			Me.Button7.TabStop = False
			Me.Button7.UseVisualStyleBackColor = False
			Me.Button7.Visible = False
			Me.lblerroruser.AutoSize = True
			Me.lblerroruser.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblerroruser.Location = New Global.System.Drawing.Point(305, 50)
			Me.lblerroruser.Name = "lblerroruser"
			Me.lblerroruser.Size = New Global.System.Drawing.Size(73, 15)
			Me.lblerroruser.TabIndex = 21
			Me.lblerroruser.Text = "Password:"
			Me.lblerroruser.Visible = False
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Controls.Add(Me.lblerrorccend)
			Me.GroupBox2.Controls.Add(Me.lblerrortoend)
			Me.GroupBox2.Controls.Add(Me.lblerrorsubject)
			Me.GroupBox2.Controls.Add(Me.lblerrorcc)
			Me.GroupBox2.Controls.Add(Me.lblerrorto)
			Me.GroupBox2.Controls.Add(Me.lblAttach)
			Me.GroupBox2.Controls.Add(Me.btnBrowse)
			Me.GroupBox2.Controls.Add(Me.Label8)
			Me.GroupBox2.Controls.Add(Me.cbEndcc)
			Me.GroupBox2.Controls.Add(Me.cbEnd)
			Me.GroupBox2.Controls.Add(Me.ToolStrip1)
			Me.GroupBox2.Controls.Add(Me.tbBody)
			Me.GroupBox2.Controls.Add(Me.Label7)
			Me.GroupBox2.Controls.Add(Me.tbSubject)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.tbCc)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.tbTo)
			Me.GroupBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox2.ForeColor = Global.System.Drawing.Color.Black
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 114)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(709, 336)
			Me.GroupBox2.TabIndex = 23
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Receiver Details"
			Me.lblerrorccend.AutoSize = True
			Me.lblerrorccend.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblerrorccend.Location = New Global.System.Drawing.Point(559, 87)
			Me.lblerrorccend.Name = "lblerrorccend"
			Me.lblerrorccend.Size = New Global.System.Drawing.Size(21, 15)
			Me.lblerrorccend.TabIndex = 36
			Me.lblerrorccend.Text = "cc"
			Me.lblerrorccend.Visible = False
			Me.lblerrortoend.AutoSize = True
			Me.lblerrortoend.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblerrortoend.Location = New Global.System.Drawing.Point(559, 40)
			Me.lblerrortoend.Name = "lblerrortoend"
			Me.lblerrortoend.Size = New Global.System.Drawing.Size(19, 15)
			Me.lblerrortoend.TabIndex = 35
			Me.lblerrortoend.Text = "to"
			Me.lblerrortoend.Visible = False
			Me.lblerrorsubject.AutoSize = True
			Me.lblerrorsubject.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblerrorsubject.Location = New Global.System.Drawing.Point(110, 140)
			Me.lblerrorsubject.Name = "lblerrorsubject"
			Me.lblerrorsubject.Size = New Global.System.Drawing.Size(53, 15)
			Me.lblerrorsubject.TabIndex = 34
			Me.lblerrorsubject.Text = "subject"
			Me.lblerrorsubject.Visible = False
			Me.lblerrorcc.AutoSize = True
			Me.lblerrorcc.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblerrorcc.Location = New Global.System.Drawing.Point(110, 87)
			Me.lblerrorcc.Name = "lblerrorcc"
			Me.lblerrorcc.Size = New Global.System.Drawing.Size(21, 15)
			Me.lblerrorcc.TabIndex = 33
			Me.lblerrorcc.Text = "cc"
			Me.lblerrorcc.Visible = False
			Me.lblerrorto.AutoSize = True
			Me.lblerrorto.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblerrorto.Location = New Global.System.Drawing.Point(113, 40)
			Me.lblerrorto.Name = "lblerrorto"
			Me.lblerrorto.Size = New Global.System.Drawing.Size(19, 15)
			Me.lblerrorto.TabIndex = 22
			Me.lblerrorto.Text = "to"
			Me.lblerrorto.Visible = False
			Me.lblAttach.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.lblAttach.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblAttach.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblAttach.ForeColor = Global.System.Drawing.Color.Red
			Me.lblAttach.Location = New Global.System.Drawing.Point(112, 158)
			Me.lblAttach.Name = "lblAttach"
			Me.lblAttach.Size = New Global.System.Drawing.Size(402, 32)
			Me.lblAttach.TabIndex = 32
			Me.lblAttach.Text = "attach"
			Me.lblAttach.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.lblAttach.Visible = False
			Me.btnBrowse.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnBrowse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnBrowse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnBrowse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnBrowse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBrowse.ForeColor = Global.System.Drawing.Color.White
			Me.btnBrowse.Image = CType(componentResourceManager.GetObject("btnBrowse.Image"), Global.System.Drawing.Image)
			Me.btnBrowse.ImageAlign = Global.System.Drawing.ContentAlignment.TopLeft
			Me.btnBrowse.Location = New Global.System.Drawing.Point(520, 154)
			Me.btnBrowse.Name = "btnBrowse"
			Me.btnBrowse.Size = New Global.System.Drawing.Size(180, 41)
			Me.btnBrowse.TabIndex = 31
			Me.btnBrowse.Text = "&Browse Attachment File"
			Me.btnBrowse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnBrowse.UseVisualStyleBackColor = False
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(27, 164)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(82, 15)
			Me.Label8.TabIndex = 30
			Me.Label8.Text = "Attachment:"
			Me.cbEndcc.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbEndcc.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbEndcc.FormattingEnabled = True
			Me.cbEndcc.Items.AddRange(New Object() { "@gmail.com", "@yahoo.com", "@yahoo.co.uk", "@ymail.com", "@hotmail.com" })
			Me.cbEndcc.Location = New Global.System.Drawing.Point(559, 63)
			Me.cbEndcc.Name = "cbEndcc"
			Me.cbEndcc.Size = New Global.System.Drawing.Size(121, 23)
			Me.cbEndcc.TabIndex = 29
			Me.cbEndcc.TabStop = False
			Me.cbEndcc.Visible = False
			Me.cbEnd.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbEnd.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbEnd.FormattingEnabled = True
			Me.cbEnd.Items.AddRange(New Object() { "@gmail.com", "@yahoo.com", "@yahoo.co.uk", "@ymail.com", "@hotmail.com" })
			Me.cbEnd.Location = New Global.System.Drawing.Point(559, 16)
			Me.cbEnd.Name = "cbEnd"
			Me.cbEnd.Size = New Global.System.Drawing.Size(121, 23)
			Me.cbEnd.TabIndex = 28
			Me.cbEnd.TabStop = False
			Me.cbEnd.Visible = False
			Me.ToolStrip1.Dock = Global.System.Windows.Forms.DockStyle.None
			Me.ToolStrip1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ToolStrip1.Items.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.tbrFont, Me.ToolStripSeparator4, Me.tbrLeft, Me.tbrCenter, Me.tbrRight, Me.ToolStripSeparator2, Me.tbrBold, Me.tbrItalic, Me.tbrUnderline, Me.ToolStripSeparator3, Me.tbrOpen })
			Me.ToolStrip1.Location = New Global.System.Drawing.Point(113, 198)
			Me.ToolStrip1.Name = "ToolStrip1"
			Me.ToolStrip1.RenderMode = Global.System.Windows.Forms.ToolStripRenderMode.Professional
			Me.ToolStrip1.Size = New Global.System.Drawing.Size(245, 25)
			Me.ToolStrip1.TabIndex = 27
			Me.ToolStrip1.Text = "ToolStrip1"
			Me.tbrFont.DisplayStyle = Global.System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.tbrFont.Image = CType(componentResourceManager.GetObject("tbrFont.Image"), Global.System.Drawing.Image)
			Me.tbrFont.ImageTransparentColor = Global.System.Drawing.Color.Magenta
			Me.tbrFont.Name = "tbrFont"
			Me.tbrFont.Size = New Global.System.Drawing.Size(23, 22)
			Me.tbrFont.Text = "Font"
			Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
			Me.ToolStripSeparator4.Size = New Global.System.Drawing.Size(6, 25)
			Me.tbrLeft.DisplayStyle = Global.System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.tbrLeft.Image = CType(componentResourceManager.GetObject("tbrLeft.Image"), Global.System.Drawing.Image)
			Me.tbrLeft.ImageTransparentColor = Global.System.Drawing.Color.Magenta
			Me.tbrLeft.Name = "tbrLeft"
			Me.tbrLeft.Size = New Global.System.Drawing.Size(23, 22)
			Me.tbrLeft.Text = "Left"
			Me.tbrCenter.DisplayStyle = Global.System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.tbrCenter.Image = CType(componentResourceManager.GetObject("tbrCenter.Image"), Global.System.Drawing.Image)
			Me.tbrCenter.ImageTransparentColor = Global.System.Drawing.Color.Magenta
			Me.tbrCenter.Name = "tbrCenter"
			Me.tbrCenter.Size = New Global.System.Drawing.Size(23, 22)
			Me.tbrCenter.Text = "Center"
			Me.tbrRight.DisplayStyle = Global.System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.tbrRight.Image = CType(componentResourceManager.GetObject("tbrRight.Image"), Global.System.Drawing.Image)
			Me.tbrRight.ImageTransparentColor = Global.System.Drawing.Color.Magenta
			Me.tbrRight.Name = "tbrRight"
			Me.tbrRight.Size = New Global.System.Drawing.Size(23, 22)
			Me.tbrRight.Text = "Right"
			Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
			Me.ToolStripSeparator2.Size = New Global.System.Drawing.Size(6, 25)
			Me.tbrBold.DisplayStyle = Global.System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.tbrBold.Image = CType(componentResourceManager.GetObject("tbrBold.Image"), Global.System.Drawing.Image)
			Me.tbrBold.ImageTransparentColor = Global.System.Drawing.Color.Magenta
			Me.tbrBold.Name = "tbrBold"
			Me.tbrBold.Size = New Global.System.Drawing.Size(23, 22)
			Me.tbrBold.Text = "Bold"
			Me.tbrItalic.DisplayStyle = Global.System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.tbrItalic.Image = CType(componentResourceManager.GetObject("tbrItalic.Image"), Global.System.Drawing.Image)
			Me.tbrItalic.ImageTransparentColor = Global.System.Drawing.Color.Magenta
			Me.tbrItalic.Name = "tbrItalic"
			Me.tbrItalic.Size = New Global.System.Drawing.Size(23, 22)
			Me.tbrItalic.Text = "Italic"
			Me.tbrUnderline.DisplayStyle = Global.System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.tbrUnderline.Image = CType(componentResourceManager.GetObject("tbrUnderline.Image"), Global.System.Drawing.Image)
			Me.tbrUnderline.ImageTransparentColor = Global.System.Drawing.Color.Magenta
			Me.tbrUnderline.Name = "tbrUnderline"
			Me.tbrUnderline.Size = New Global.System.Drawing.Size(23, 22)
			Me.tbrUnderline.Text = "Underline"
			Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
			Me.ToolStripSeparator3.Size = New Global.System.Drawing.Size(6, 25)
			Me.tbrOpen.DisplayStyle = Global.System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.tbrOpen.Image = CType(componentResourceManager.GetObject("tbrOpen.Image"), Global.System.Drawing.Image)
			Me.tbrOpen.ImageTransparentColor = Global.System.Drawing.Color.Magenta
			Me.tbrOpen.Name = "tbrOpen"
			Me.tbrOpen.Size = New Global.System.Drawing.Size(23, 22)
			Me.tbrOpen.Text = "Open"
			Me.tbBody.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.tbBody.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.tbBody.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.tbBody.Location = New Global.System.Drawing.Point(113, 223)
			Me.tbBody.Name = "tbBody"
			Me.tbBody.Size = New Global.System.Drawing.Size(587, 104)
			Me.tbBody.TabIndex = 26
			Me.tbBody.Text = ""
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.Location = New Global.System.Drawing.Point(27, 220)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(42, 15)
			Me.Label7.TabIndex = 25
			Me.Label7.Text = "Body:"
			Me.tbSubject.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.tbSubject.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.tbSubject.Location = New Global.System.Drawing.Point(113, 109)
			Me.tbSubject.Multiline = True
			Me.tbSubject.Name = "tbSubject"
			Me.tbSubject.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.tbSubject.Size = New Global.System.Drawing.Size(587, 28)
			Me.tbSubject.TabIndex = 23
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.Location = New Global.System.Drawing.Point(27, 109)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(59, 15)
			Me.Label6.TabIndex = 24
			Me.Label6.Text = "Subject:"
			Me.GroupBox3.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox3.Controls.Add(Me.lblDate)
			Me.GroupBox3.Controls.Add(Me.lblTime)
			Me.GroupBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox3.ForeColor = Global.System.Drawing.Color.Black
			Me.GroupBox3.Location = New Global.System.Drawing.Point(475, 36)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(238, 76)
			Me.GroupBox3.TabIndex = 28
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Current Time And Date"
			Me.lblDate.AutoSize = True
			Me.lblDate.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblDate.ForeColor = Global.System.Drawing.Color.Black
			Me.lblDate.Location = New Global.System.Drawing.Point(6, 52)
			Me.lblDate.Name = "lblDate"
			Me.lblDate.Size = New Global.System.Drawing.Size(36, 16)
			Me.lblDate.TabIndex = 3
			Me.lblDate.Text = "Date"
			Me.lblTime.AutoSize = True
			Me.lblTime.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblTime.ForeColor = Global.System.Drawing.Color.Black
			Me.lblTime.Location = New Global.System.Drawing.Point(6, 19)
			Me.lblTime.Name = "lblTime"
			Me.lblTime.Size = New Global.System.Drawing.Size(42, 16)
			Me.lblTime.TabIndex = 2
			Me.lblTime.Text = "Clock"
			Me.lblStatus.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.lblStatus.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblStatus.ForeColor = Global.System.Drawing.Color.Lime
			Me.lblStatus.Location = New Global.System.Drawing.Point(4, 453)
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New Global.System.Drawing.Size(490, 52)
			Me.lblStatus.TabIndex = 32
			Me.lblStatus.Text = "....."
			Me.lblStatus.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lblStatus.Visible = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.OpenFileDialog2.FileName = "OpenFileDialog2"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.lblStatus)
			Me.Panel1.Controls.Add(Me.GroupBox3)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.btnSend)
			Me.Panel1.Controls.Add(Me.btnClear)
			Me.Panel1.Controls.Add(Me.ProgressBar1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(734, 561)
			Me.Panel1.TabIndex = 33
			Me.Label5.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label5.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(2, 1)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(731, 27)
			Me.Label5.TabIndex = 2
			Me.Label5.Text = "E-Mail Sender"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.btnSend.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnSend.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSend.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSend.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSend.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSend.ForeColor = Global.System.Drawing.Color.White
			Me.btnSend.Image = CType(componentResourceManager.GetObject("btnSend.Image"), Global.System.Drawing.Image)
			Me.btnSend.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSend.Location = New Global.System.Drawing.Point(502, 453)
			Me.btnSend.Name = "btnSend"
			Me.btnSend.Size = New Global.System.Drawing.Size(102, 52)
			Me.btnSend.TabIndex = 1
			Me.btnSend.Text = "&Send"
			Me.btnSend.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSend.UseVisualStyleBackColor = False
			Me.btnClear.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnClear.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnClear.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnClear.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnClear.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnClear.ForeColor = Global.System.Drawing.Color.White
			Me.btnClear.Image = CType(componentResourceManager.GetObject("btnClear.Image"), Global.System.Drawing.Image)
			Me.btnClear.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnClear.Location = New Global.System.Drawing.Point(610, 453)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New Global.System.Drawing.Size(102, 52)
			Me.btnClear.TabIndex = 9
			Me.btnClear.Text = "&Clear"
			Me.btnClear.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnClear.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageBeforeText
			Me.btnClear.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			MyBase.ClientSize = New Global.System.Drawing.Size(734, 561)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmEmailsender"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "E-Mail Sender"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.ToolStrip1.ResumeLayout(False)
			Me.ToolStrip1.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			Me.Panel1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005D78 RID: 23928
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
