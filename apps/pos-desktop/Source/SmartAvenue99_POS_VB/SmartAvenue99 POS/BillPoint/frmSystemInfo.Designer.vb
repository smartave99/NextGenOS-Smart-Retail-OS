Namespace BillPoint
	' Token: 0x020004E0 RID: 1248
		Public Partial Class frmSystemInfo
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FE58 RID: 65112 RVA: 0x00980E18 File Offset: 0x0097F018
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

		' Token: 0x0600FE59 RID: 65113 RVA: 0x00980E68 File Offset: 0x0097F068
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSystemInfo))
			Me.MenuStrip1 = New Global.System.Windows.Forms.MenuStrip()
			Me.FileToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.SaveToFileToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.ToolStripMenuItem1 = New Global.System.Windows.Forms.ToolStripSeparator()
			Me.ExitToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.TabControl1 = New Global.System.Windows.Forms.TabControl()
			Me.TabPage1 = New Global.System.Windows.Forms.TabPage()
			Me.txtProcessorFamily = New Global.System.Windows.Forms.TextBox()
			Me.txtProcessorExtClock = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtProcessorClockSpeed = New Global.System.Windows.Forms.TextBox()
			Me.txtProcessorDataWidth = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtProcessorL2CacheSize = New Global.System.Windows.Forms.TextBox()
			Me.txtProcessorManufacturer = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtProcessorDescription = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtProcessorID = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtProcessorName = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TabPage2 = New Global.System.Windows.Forms.TabPage()
			Me.txtBoardSerialNumber = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.txtBoardDescription = New Global.System.Windows.Forms.TextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.txtBoardManufacturer = New Global.System.Windows.Forms.TextBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.txtBoardName = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.TabPage3 = New Global.System.Windows.Forms.TabPage()
			Me.TextBox12 = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.TextBox11 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label22 = New Global.System.Windows.Forms.Label()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Label23 = New Global.System.Windows.Forms.Label()
			Me.Label25 = New Global.System.Windows.Forms.Label()
			Me.Label27 = New Global.System.Windows.Forms.Label()
			Me.Label32 = New Global.System.Windows.Forms.Label()
			Me.Label33 = New Global.System.Windows.Forms.Label()
			Me.Label34 = New Global.System.Windows.Forms.Label()
			Me.Label35 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.MenuStrip1.SuspendLayout()
			Me.TabControl1.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			Me.TabPage2.SuspendLayout()
			Me.TabPage3.SuspendLayout()
			MyBase.SuspendLayout()
			Me.MenuStrip1.Items.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.FileToolStripMenuItem })
			Me.MenuStrip1.Location = New Global.System.Drawing.Point(0, 0)
			Me.MenuStrip1.Name = "MenuStrip1"
			Me.MenuStrip1.Size = New Global.System.Drawing.Size(441, 24)
			Me.MenuStrip1.TabIndex = 0
			Me.MenuStrip1.Text = "MenuStrip1"
			Me.FileToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.SaveToFileToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem })
			Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
			Me.FileToolStripMenuItem.Size = New Global.System.Drawing.Size(37, 20)
			Me.FileToolStripMenuItem.Text = "&File"
			Me.SaveToFileToolStripMenuItem.Name = "SaveToFileToolStripMenuItem"
			Me.SaveToFileToolStripMenuItem.Size = New Global.System.Drawing.Size(131, 22)
			Me.SaveToFileToolStripMenuItem.Text = "&Save to file"
			Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
			Me.ToolStripMenuItem1.Size = New Global.System.Drawing.Size(128, 6)
			Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
			Me.ExitToolStripMenuItem.Size = New Global.System.Drawing.Size(131, 22)
			Me.ExitToolStripMenuItem.Text = "E&xit"
			Me.TabControl1.Controls.Add(Me.TabPage1)
			Me.TabControl1.Controls.Add(Me.TabPage2)
			Me.TabControl1.Controls.Add(Me.TabPage3)
			Me.TabControl1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.TabControl1.Location = New Global.System.Drawing.Point(4, 26)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New Global.System.Drawing.Size(433, 312)
			Me.TabControl1.TabIndex = 1
			Me.TabPage1.BackColor = Global.System.Drawing.Color.Yellow
			Me.TabPage1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TabPage1.Controls.Add(Me.txtProcessorFamily)
			Me.TabPage1.Controls.Add(Me.txtProcessorExtClock)
			Me.TabPage1.Controls.Add(Me.Label9)
			Me.TabPage1.Controls.Add(Me.Label8)
			Me.TabPage1.Controls.Add(Me.Label7)
			Me.TabPage1.Controls.Add(Me.txtProcessorClockSpeed)
			Me.TabPage1.Controls.Add(Me.txtProcessorDataWidth)
			Me.TabPage1.Controls.Add(Me.Label6)
			Me.TabPage1.Controls.Add(Me.Label5)
			Me.TabPage1.Controls.Add(Me.txtProcessorL2CacheSize)
			Me.TabPage1.Controls.Add(Me.txtProcessorManufacturer)
			Me.TabPage1.Controls.Add(Me.Label4)
			Me.TabPage1.Controls.Add(Me.txtProcessorDescription)
			Me.TabPage1.Controls.Add(Me.Label3)
			Me.TabPage1.Controls.Add(Me.txtProcessorID)
			Me.TabPage1.Controls.Add(Me.Label2)
			Me.TabPage1.Controls.Add(Me.txtProcessorName)
			Me.TabPage1.Controls.Add(Me.Label1)
			Me.TabPage1.Location = New Global.System.Drawing.Point(4, 25)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage1.Size = New Global.System.Drawing.Size(425, 283)
			Me.TabPage1.TabIndex = 0
			Me.TabPage1.Text = "Processor"
			Me.txtProcessorFamily.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorFamily.Location = New Global.System.Drawing.Point(218, 237)
			Me.txtProcessorFamily.Name = "txtProcessorFamily"
			Me.txtProcessorFamily.[ReadOnly] = True
			Me.txtProcessorFamily.Size = New Global.System.Drawing.Size(165, 22)
			Me.txtProcessorFamily.TabIndex = 37
			Me.txtProcessorFamily.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtProcessorExtClock.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorExtClock.Location = New Global.System.Drawing.Point(47, 237)
			Me.txtProcessorExtClock.Name = "txtProcessorExtClock"
			Me.txtProcessorExtClock.[ReadOnly] = True
			Me.txtProcessorExtClock.Size = New Global.System.Drawing.Size(165, 22)
			Me.txtProcessorExtClock.TabIndex = 36
			Me.txtProcessorExtClock.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(215, 221)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(48, 16)
			Me.Label9.TabIndex = 35
			Me.Label9.Text = "Family"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(43, 221)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(63, 16)
			Me.Label8.TabIndex = 34
			Me.Label8.Text = "Ext Clock"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(215, 180)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(74, 16)
			Me.Label7.TabIndex = 33
			Me.Label7.Text = "Data Width"
			Me.txtProcessorClockSpeed.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorClockSpeed.Location = New Global.System.Drawing.Point(47, 196)
			Me.txtProcessorClockSpeed.Name = "txtProcessorClockSpeed"
			Me.txtProcessorClockSpeed.[ReadOnly] = True
			Me.txtProcessorClockSpeed.Size = New Global.System.Drawing.Size(165, 22)
			Me.txtProcessorClockSpeed.TabIndex = 32
			Me.txtProcessorClockSpeed.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtProcessorDataWidth.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorDataWidth.Location = New Global.System.Drawing.Point(218, 196)
			Me.txtProcessorDataWidth.Name = "txtProcessorDataWidth"
			Me.txtProcessorDataWidth.[ReadOnly] = True
			Me.txtProcessorDataWidth.Size = New Global.System.Drawing.Size(165, 22)
			Me.txtProcessorDataWidth.TabIndex = 31
			Me.txtProcessorDataWidth.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(43, 180)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(86, 16)
			Me.Label6.TabIndex = 30
			Me.Label6.Text = "Clock Speed"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(215, 138)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(93, 16)
			Me.Label5.TabIndex = 29
			Me.Label5.Text = "L2 Cache Size"
			Me.txtProcessorL2CacheSize.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorL2CacheSize.Location = New Global.System.Drawing.Point(218, 154)
			Me.txtProcessorL2CacheSize.Name = "txtProcessorL2CacheSize"
			Me.txtProcessorL2CacheSize.[ReadOnly] = True
			Me.txtProcessorL2CacheSize.Size = New Global.System.Drawing.Size(165, 22)
			Me.txtProcessorL2CacheSize.TabIndex = 28
			Me.txtProcessorL2CacheSize.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtProcessorManufacturer.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorManufacturer.Location = New Global.System.Drawing.Point(46, 154)
			Me.txtProcessorManufacturer.Name = "txtProcessorManufacturer"
			Me.txtProcessorManufacturer.[ReadOnly] = True
			Me.txtProcessorManufacturer.Size = New Global.System.Drawing.Size(165, 22)
			Me.txtProcessorManufacturer.TabIndex = 27
			Me.txtProcessorManufacturer.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(43, 138)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(85, 16)
			Me.Label4.TabIndex = 26
			Me.Label4.Text = "Manufacturer"
			Me.txtProcessorDescription.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorDescription.Location = New Global.System.Drawing.Point(46, 113)
			Me.txtProcessorDescription.Name = "txtProcessorDescription"
			Me.txtProcessorDescription.[ReadOnly] = True
			Me.txtProcessorDescription.Size = New Global.System.Drawing.Size(337, 22)
			Me.txtProcessorDescription.TabIndex = 25
			Me.txtProcessorDescription.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(43, 97)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(76, 16)
			Me.Label3.TabIndex = 24
			Me.Label3.Text = "Description"
			Me.txtProcessorID.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorID.Location = New Global.System.Drawing.Point(46, 72)
			Me.txtProcessorID.Name = "txtProcessorID"
			Me.txtProcessorID.[ReadOnly] = True
			Me.txtProcessorID.Size = New Global.System.Drawing.Size(337, 22)
			Me.txtProcessorID.TabIndex = 23
			Me.txtProcessorID.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(43, 56)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(86, 16)
			Me.Label2.TabIndex = 22
			Me.Label2.Text = "Processor ID"
			Me.txtProcessorName.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtProcessorName.Location = New Global.System.Drawing.Point(46, 31)
			Me.txtProcessorName.Name = "txtProcessorName"
			Me.txtProcessorName.[ReadOnly] = True
			Me.txtProcessorName.Size = New Global.System.Drawing.Size(337, 22)
			Me.txtProcessorName.TabIndex = 21
			Me.txtProcessorName.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(43, 15)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(110, 16)
			Me.Label1.TabIndex = 20
			Me.Label1.Text = "Processor Name"
			Me.TabPage2.BackColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.TabPage2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TabPage2.Controls.Add(Me.txtBoardSerialNumber)
			Me.TabPage2.Controls.Add(Me.Label13)
			Me.TabPage2.Controls.Add(Me.txtBoardDescription)
			Me.TabPage2.Controls.Add(Me.Label12)
			Me.TabPage2.Controls.Add(Me.txtBoardManufacturer)
			Me.TabPage2.Controls.Add(Me.Label11)
			Me.TabPage2.Controls.Add(Me.txtBoardName)
			Me.TabPage2.Controls.Add(Me.Label10)
			Me.TabPage2.Location = New Global.System.Drawing.Point(4, 25)
			Me.TabPage2.Name = "TabPage2"
			Me.TabPage2.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage2.Size = New Global.System.Drawing.Size(425, 283)
			Me.TabPage2.TabIndex = 1
			Me.TabPage2.Text = "Motherboard"
			Me.txtBoardSerialNumber.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtBoardSerialNumber.Location = New Global.System.Drawing.Point(44, 225)
			Me.txtBoardSerialNumber.Name = "txtBoardSerialNumber"
			Me.txtBoardSerialNumber.[ReadOnly] = True
			Me.txtBoardSerialNumber.Size = New Global.System.Drawing.Size(337, 22)
			Me.txtBoardSerialNumber.TabIndex = 23
			Me.txtBoardSerialNumber.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(41, 206)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(94, 16)
			Me.Label13.TabIndex = 22
			Me.Label13.Text = "Serial Number"
			Me.txtBoardDescription.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtBoardDescription.Location = New Global.System.Drawing.Point(44, 169)
			Me.txtBoardDescription.Name = "txtBoardDescription"
			Me.txtBoardDescription.[ReadOnly] = True
			Me.txtBoardDescription.Size = New Global.System.Drawing.Size(337, 22)
			Me.txtBoardDescription.TabIndex = 21
			Me.txtBoardDescription.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(41, 150)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(76, 16)
			Me.Label12.TabIndex = 20
			Me.Label12.Text = "Description"
			Me.txtBoardManufacturer.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtBoardManufacturer.Location = New Global.System.Drawing.Point(44, 113)
			Me.txtBoardManufacturer.Name = "txtBoardManufacturer"
			Me.txtBoardManufacturer.[ReadOnly] = True
			Me.txtBoardManufacturer.Size = New Global.System.Drawing.Size(337, 22)
			Me.txtBoardManufacturer.TabIndex = 19
			Me.txtBoardManufacturer.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(41, 94)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(85, 16)
			Me.Label11.TabIndex = 18
			Me.Label11.Text = "Manufacturer"
			Me.txtBoardName.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtBoardName.Location = New Global.System.Drawing.Point(44, 57)
			Me.txtBoardName.Name = "txtBoardName"
			Me.txtBoardName.[ReadOnly] = True
			Me.txtBoardName.Size = New Global.System.Drawing.Size(337, 22)
			Me.txtBoardName.TabIndex = 17
			Me.txtBoardName.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(41, 38)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(125, 16)
			Me.Label10.TabIndex = 16
			Me.Label10.Text = "Motherboard Name"
			Me.TabPage3.BackColor = Global.System.Drawing.Color.Lime
			Me.TabPage3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TabPage3.Controls.Add(Me.TextBox12)
			Me.TabPage3.Controls.Add(Me.Label14)
			Me.TabPage3.Controls.Add(Me.TextBox11)
			Me.TabPage3.Controls.Add(Me.TextBox10)
			Me.TabPage3.Controls.Add(Me.TextBox9)
			Me.TabPage3.Controls.Add(Me.TextBox8)
			Me.TabPage3.Controls.Add(Me.TextBox7)
			Me.TabPage3.Controls.Add(Me.TextBox6)
			Me.TabPage3.Controls.Add(Me.TextBox5)
			Me.TabPage3.Controls.Add(Me.TextBox4)
			Me.TabPage3.Controls.Add(Me.TextBox3)
			Me.TabPage3.Controls.Add(Me.TextBox2)
			Me.TabPage3.Controls.Add(Me.TextBox1)
			Me.TabPage3.Controls.Add(Me.Label22)
			Me.TabPage3.Controls.Add(Me.Label20)
			Me.TabPage3.Controls.Add(Me.Label18)
			Me.TabPage3.Controls.Add(Me.Label16)
			Me.TabPage3.Controls.Add(Me.Label23)
			Me.TabPage3.Controls.Add(Me.Label25)
			Me.TabPage3.Controls.Add(Me.Label27)
			Me.TabPage3.Controls.Add(Me.Label32)
			Me.TabPage3.Controls.Add(Me.Label33)
			Me.TabPage3.Controls.Add(Me.Label34)
			Me.TabPage3.Controls.Add(Me.Label35)
			Me.TabPage3.Location = New Global.System.Drawing.Point(4, 25)
			Me.TabPage3.Name = "TabPage3"
			Me.TabPage3.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage3.Size = New Global.System.Drawing.Size(425, 283)
			Me.TabPage3.TabIndex = 2
			Me.TabPage3.Text = "My PC"
			Me.TextBox12.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox12.Location = New Global.System.Drawing.Point(127, 257)
			Me.TextBox12.Name = "TextBox12"
			Me.TextBox12.[ReadOnly] = True
			Me.TextBox12.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox12.TabIndex = 11
			Me.TextBox12.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label14.AutoSize = True
			Me.Label14.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.ForeColor = Global.System.Drawing.Color.Black
			Me.Label14.Location = New Global.System.Drawing.Point(1, 257)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(84, 16)
			Me.Label14.TabIndex = 82
			Me.Label14.Text = "Date / Time :"
			Me.TextBox11.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox11.Location = New Global.System.Drawing.Point(127, 234)
			Me.TextBox11.Name = "TextBox11"
			Me.TextBox11.[ReadOnly] = True
			Me.TextBox11.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox11.TabIndex = 10
			Me.TextBox11.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox10.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox10.Location = New Global.System.Drawing.Point(127, 211)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox10.TabIndex = 9
			Me.TextBox10.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox9.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox9.Location = New Global.System.Drawing.Point(127, 188)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.[ReadOnly] = True
			Me.TextBox9.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox9.TabIndex = 8
			Me.TextBox9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox8.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox8.Location = New Global.System.Drawing.Point(127, 165)
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.[ReadOnly] = True
			Me.TextBox8.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox8.TabIndex = 7
			Me.TextBox8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox7.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox7.Location = New Global.System.Drawing.Point(127, 142)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.[ReadOnly] = True
			Me.TextBox7.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox7.TabIndex = 6
			Me.TextBox7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox6.Location = New Global.System.Drawing.Point(127, 119)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.[ReadOnly] = True
			Me.TextBox6.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox6.TabIndex = 5
			Me.TextBox6.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox5.Location = New Global.System.Drawing.Point(127, 96)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox5.TabIndex = 4
			Me.TextBox5.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox4.Location = New Global.System.Drawing.Point(127, 73)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.[ReadOnly] = True
			Me.TextBox4.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox4.TabIndex = 3
			Me.TextBox4.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox3.Location = New Global.System.Drawing.Point(127, 50)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox3.TabIndex = 2
			Me.TextBox3.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox2.Location = New Global.System.Drawing.Point(127, 27)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox2.TabIndex = 1
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox1.Location = New Global.System.Drawing.Point(127, 4)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(293, 22)
			Me.TextBox1.TabIndex = 0
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label22.AutoSize = True
			Me.Label22.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label22.ForeColor = Global.System.Drawing.Color.Black
			Me.Label22.Location = New Global.System.Drawing.Point(1, 165)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(124, 16)
			Me.Label22.TabIndex = 69
			Me.Label22.Text = "Screen Resolution :"
			Me.Label20.AutoSize = True
			Me.Label20.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label20.ForeColor = Global.System.Drawing.Color.Black
			Me.Label20.Location = New Global.System.Drawing.Point(1, 142)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(60, 16)
			Me.Label20.TabIndex = 66
			Me.Label20.Text = "Version :"
			Me.Label18.AutoSize = True
			Me.Label18.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.ForeColor = Global.System.Drawing.Color.Black
			Me.Label18.Location = New Global.System.Drawing.Point(1, 119)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(63, 16)
			Me.Label18.TabIndex = 63
			Me.Label18.Text = "Platform :"
			Me.Label16.AutoSize = True
			Me.Label16.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label16.ForeColor = Global.System.Drawing.Color.Black
			Me.Label16.Location = New Global.System.Drawing.Point(1, 96)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(121, 16)
			Me.Label16.TabIndex = 60
			Me.Label16.Text = "Operating System :"
			Me.Label23.AutoSize = True
			Me.Label23.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label23.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label23.ForeColor = Global.System.Drawing.Color.Black
			Me.Label23.Location = New Global.System.Drawing.Point(1, 73)
			Me.Label23.Name = "Label23"
			Me.Label23.Size = New Global.System.Drawing.Size(120, 16)
			Me.Label23.TabIndex = 57
			Me.Label23.Text = "RAM Full Memory :"
			Me.Label25.AutoSize = True
			Me.Label25.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label25.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label25.ForeColor = Global.System.Drawing.Color.Black
			Me.Label25.Location = New Global.System.Drawing.Point(1, 50)
			Me.Label25.Name = "Label25"
			Me.Label25.Size = New Global.System.Drawing.Size(129, 16)
			Me.Label25.TabIndex = 54
			Me.Label25.Text = "RAM Avail Memory :"
			Me.Label27.AutoSize = True
			Me.Label27.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label27.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label27.ForeColor = Global.System.Drawing.Color.Black
			Me.Label27.Location = New Global.System.Drawing.Point(1, 211)
			Me.Label27.Name = "Label27"
			Me.Label27.Size = New Global.System.Drawing.Size(121, 16)
			Me.Label27.TabIndex = 51
			Me.Label27.Text = "Online IP Address :"
			Me.Label32.AutoSize = True
			Me.Label32.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label32.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label32.ForeColor = Global.System.Drawing.Color.Black
			Me.Label32.Location = New Global.System.Drawing.Point(1, 27)
			Me.Label32.Name = "Label32"
			Me.Label32.Size = New Global.System.Drawing.Size(83, 16)
			Me.Label32.TabIndex = 42
			Me.Label32.Text = "User Name :"
			Me.Label33.AutoSize = True
			Me.Label33.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label33.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label33.ForeColor = Global.System.Drawing.Color.Black
			Me.Label33.Location = New Global.System.Drawing.Point(1, 234)
			Me.Label33.Name = "Label33"
			Me.Label33.Size = New Global.System.Drawing.Size(97, 16)
			Me.Label33.TabIndex = 41
			Me.Label33.Text = "MAC Address :"
			Me.Label34.AutoSize = True
			Me.Label34.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label34.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label34.ForeColor = Global.System.Drawing.Color.Black
			Me.Label34.Location = New Global.System.Drawing.Point(1, 4)
			Me.Label34.Name = "Label34"
			Me.Label34.Size = New Global.System.Drawing.Size(112, 16)
			Me.Label34.TabIndex = 40
			Me.Label34.Text = "Computer Name :"
			Me.Label35.AutoSize = True
			Me.Label35.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label35.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label35.ForeColor = Global.System.Drawing.Color.Black
			Me.Label35.Location = New Global.System.Drawing.Point(1, 188)
			Me.Label35.Name = "Label35"
			Me.Label35.Size = New Global.System.Drawing.Size(116, 16)
			Me.Label35.TabIndex = 39
			Me.Label35.Text = "Local IP Address :"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(8F, 16F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DarkViolet
			MyBase.ClientSize = New Global.System.Drawing.Size(441, 342)
			MyBase.Controls.Add(Me.TabControl1)
			MyBase.Controls.Add(Me.MenuStrip1)
			Me.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MainMenuStrip = Me.MenuStrip1
			MyBase.Margin = New Global.System.Windows.Forms.Padding(4)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmSystemInfo"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "System Information"
			Me.MenuStrip1.ResumeLayout(False)
			Me.MenuStrip1.PerformLayout()
			Me.TabControl1.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			Me.TabPage1.PerformLayout()
			Me.TabPage2.ResumeLayout(False)
			Me.TabPage2.PerformLayout()
			Me.TabPage3.ResumeLayout(False)
			Me.TabPage3.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400615F RID: 24927
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
