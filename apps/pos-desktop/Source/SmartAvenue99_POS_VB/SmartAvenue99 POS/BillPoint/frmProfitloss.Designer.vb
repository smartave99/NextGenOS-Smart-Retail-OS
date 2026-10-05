Namespace BillPoint
	' Token: 0x020002AA RID: 682
		Public Partial Class frmProfitloss
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600AE5B RID: 44635 RVA: 0x00745E84 File Offset: 0x00744084
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

		' Token: 0x0600AE5C RID: 44636 RVA: 0x00745ED4 File Offset: 0x007440D4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProfitloss))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label22 = New Global.System.Windows.Forms.Label()
			Me.TextBox20 = New Global.System.Windows.Forms.TextBox()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.Label30 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.TextBox19 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox18 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox17 = New Global.System.Windows.Forms.TextBox()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateTimePicker2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.TextBox16 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox15 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox14 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox13 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox12 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox11 = New Global.System.Windows.Forms.TextBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.ShapeContainer1 = New Global.Microsoft.VisualBasic.PowerPacks.ShapeContainer()
			Me.LineShape1 = New Global.Microsoft.VisualBasic.PowerPacks.LineShape()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label22)
			Me.Panel1.Controls.Add(Me.TextBox20)
			Me.Panel1.Controls.Add(Me.Label21)
			Me.Panel1.Controls.Add(Me.Label30)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.Panel7)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.Panel6)
			Me.Panel1.Controls.Add(Me.Label20)
			Me.Panel1.Controls.Add(Me.Label19)
			Me.Panel1.Controls.Add(Me.Label18)
			Me.Panel1.Controls.Add(Me.TextBox19)
			Me.Panel1.Controls.Add(Me.TextBox18)
			Me.Panel1.Controls.Add(Me.TextBox17)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.TextBox16)
			Me.Panel1.Controls.Add(Me.TextBox15)
			Me.Panel1.Controls.Add(Me.TextBox14)
			Me.Panel1.Controls.Add(Me.TextBox13)
			Me.Panel1.Controls.Add(Me.TextBox12)
			Me.Panel1.Controls.Add(Me.TextBox11)
			Me.Panel1.Controls.Add(Me.Label16)
			Me.Panel1.Controls.Add(Me.TextBox10)
			Me.Panel1.Controls.Add(Me.TextBox9)
			Me.Panel1.Controls.Add(Me.Label15)
			Me.Panel1.Controls.Add(Me.Label14)
			Me.Panel1.Controls.Add(Me.TextBox8)
			Me.Panel1.Controls.Add(Me.TextBox7)
			Me.Panel1.Controls.Add(Me.TextBox6)
			Me.Panel1.Controls.Add(Me.TextBox5)
			Me.Panel1.Controls.Add(Me.TextBox4)
			Me.Panel1.Controls.Add(Me.TextBox3)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Label11)
			Me.Panel1.Controls.Add(Me.Label10)
			Me.Panel1.Controls.Add(Me.Label9)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.ShapeContainer1)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(898, 447)
			Me.Panel1.TabIndex = 0
			Me.Label22.AutoSize = True
			Me.Label22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label22.Location = New Global.System.Drawing.Point(28, 115)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(139, 16)
			Me.Label22.TabIndex = 160
			Me.Label22.Text = "Opening Stock Value :"
			Me.TextBox20.BackColor = Global.System.Drawing.Color.White
			Me.TextBox20.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox20.Location = New Global.System.Drawing.Point(214, 115)
			Me.TextBox20.Name = "TextBox20"
			Me.TextBox20.[ReadOnly] = True
			Me.TextBox20.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox20.TabIndex = 159
			Me.TextBox20.TabStop = False
			Me.TextBox20.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label21.AutoSize = True
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label21.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label21.Location = New Global.System.Drawing.Point(812, 75)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(18, 18)
			Me.Label21.TabIndex = 158
			Me.Label21.Text = ".."
			Me.Label30.AutoSize = True
			Me.Label30.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label30.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label30.Location = New Global.System.Drawing.Point(372, 76)
			Me.Label30.Name = "Label30"
			Me.Label30.Size = New Global.System.Drawing.Size(18, 18)
			Me.Label30.TabIndex = 157
			Me.Label30.Text = ".."
			Me.Panel3.BackColor = Global.System.Drawing.Color.Gainsboro
			Me.Panel3.Location = New Global.System.Drawing.Point(7, 96)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(865, 10)
			Me.Panel3.TabIndex = 144
			Me.Panel7.BackColor = Global.System.Drawing.Color.Gainsboro
			Me.Panel7.Location = New Global.System.Drawing.Point(7, 325)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(865, 10)
			Me.Panel7.TabIndex = 143
			Me.Panel5.BackColor = Global.System.Drawing.Color.Gainsboro
			Me.Panel5.Location = New Global.System.Drawing.Point(434, 73)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(10, 298)
			Me.Panel5.TabIndex = 141
			Me.Panel6.BackColor = Global.System.Drawing.Color.Gainsboro
			Me.Panel6.Location = New Global.System.Drawing.Point(7, 361)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(866, 10)
			Me.Panel6.TabIndex = 142
			Me.Label20.AutoSize = True
			Me.Label20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Italic, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label20.ForeColor = Global.System.Drawing.Color.SaddleBrown
			Me.Label20.Location = New Global.System.Drawing.Point(68, 269)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(111, 16)
			Me.Label20.TabIndex = 138
			Me.Label20.Text = "Payroll Payment :"
			Me.Label19.AutoSize = True
			Me.Label19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Italic, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label19.ForeColor = Global.System.Drawing.Color.SaddleBrown
			Me.Label19.Location = New Global.System.Drawing.Point(68, 243)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(112, 16)
			Me.Label19.TabIndex = 137
			Me.Label19.Text = "Payroll Advance :"
			Me.Label18.AutoSize = True
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Italic, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.ForeColor = Global.System.Drawing.Color.SaddleBrown
			Me.Label18.Location = New Global.System.Drawing.Point(68, 217)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(104, 16)
			Me.Label18.TabIndex = 136
			Me.Label18.Text = "Misc Expenses :"
			Me.TextBox19.BackColor = Global.System.Drawing.Color.White
			Me.TextBox19.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox19.Location = New Global.System.Drawing.Point(235, 270)
			Me.TextBox19.Name = "TextBox19"
			Me.TextBox19.[ReadOnly] = True
			Me.TextBox19.Size = New Global.System.Drawing.Size(156, 13)
			Me.TextBox19.TabIndex = 135
			Me.TextBox19.TabStop = False
			Me.TextBox19.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox18.BackColor = Global.System.Drawing.Color.White
			Me.TextBox18.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox18.Location = New Global.System.Drawing.Point(235, 246)
			Me.TextBox18.Name = "TextBox18"
			Me.TextBox18.[ReadOnly] = True
			Me.TextBox18.Size = New Global.System.Drawing.Size(156, 13)
			Me.TextBox18.TabIndex = 134
			Me.TextBox18.TabStop = False
			Me.TextBox18.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox17.BackColor = Global.System.Drawing.Color.White
			Me.TextBox17.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox17.Location = New Global.System.Drawing.Point(235, 222)
			Me.TextBox17.Name = "TextBox17"
			Me.TextBox17.[ReadOnly] = True
			Me.TextBox17.Size = New Global.System.Drawing.Size(156, 13)
			Me.TextBox17.TabIndex = 133
			Me.TextBox17.TabStop = False
			Me.TextBox17.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Panel2.BackColor = Global.System.Drawing.Color.White
			Me.Panel2.Controls.Add(Me.GelButton2)
			Me.Panel2.Controls.Add(Me.GelButton3)
			Me.Panel2.Controls.Add(Me.GelButton1)
			Me.Panel2.Controls.Add(Me.Button4)
			Me.Panel2.Controls.Add(Me.Button3)
			Me.Panel2.Controls.Add(Me.Label17)
			Me.Panel2.Controls.Add(Me.DateTimePicker1)
			Me.Panel2.Controls.Add(Me.DateTimePicker2)
			Me.Panel2.Controls.Add(Me.Label13)
			Me.Panel2.Controls.Add(Me.Label12)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 28)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(894, 39)
			Me.Panel2.TabIndex = 72
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(466, 3)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 33)
			Me.GelButton3.TabIndex = 538
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(359, 3)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 33)
			Me.GelButton1.TabIndex = 537
			Me.GelButton1.Text = "&Generate"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.Button4.BackgroundImage = CType(componentResourceManager.GetObject("Button4.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatAppearance.BorderSize = 0
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Location = New Global.System.Drawing.Point(779, 2)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(33, 33)
			Me.Button4.TabIndex = 56
			Me.Button4.TabStop = False
			Me.Button4.UseVisualStyleBackColor = True
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatAppearance.BorderSize = 0
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.Location = New Global.System.Drawing.Point(819, 3)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(42, 33)
			Me.Button3.TabIndex = 55
			Me.Button3.TabStop = False
			Me.Button3.UseVisualStyleBackColor = True
			Me.Label17.AutoSize = True
			Me.Label17.ForeColor = Global.System.Drawing.Color.Black
			Me.Label17.Location = New Global.System.Drawing.Point(2, 1)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label17.TabIndex = 14
			Me.Label17.Text = "Search By Date :"
			Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(44, 15)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(125, 20)
			Me.DateTimePicker1.TabIndex = 0
			Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker2.Location = New Global.System.Drawing.Point(218, 15)
			Me.DateTimePicker2.Name = "DateTimePicker2"
			Me.DateTimePicker2.Size = New Global.System.Drawing.Size(125, 20)
			Me.DateTimePicker2.TabIndex = 1
			Me.Label13.AutoSize = True
			Me.Label13.ForeColor = Global.System.Drawing.Color.Black
			Me.Label13.Location = New Global.System.Drawing.Point(2, 18)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label13.TabIndex = 12
			Me.Label13.Text = "From :"
			Me.Label12.AutoSize = True
			Me.Label12.ForeColor = Global.System.Drawing.Color.Black
			Me.Label12.Location = New Global.System.Drawing.Point(176, 18)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label12.TabIndex = 13
			Me.Label12.Text = "To :"
			Me.TextBox16.Location = New Global.System.Drawing.Point(314, 385)
			Me.TextBox16.Name = "TextBox16"
			Me.TextBox16.[ReadOnly] = True
			Me.TextBox16.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox16.TabIndex = 71
			Me.TextBox16.TabStop = False
			Me.TextBox16.Visible = False
			Me.TextBox15.Location = New Global.System.Drawing.Point(250, 385)
			Me.TextBox15.Name = "TextBox15"
			Me.TextBox15.[ReadOnly] = True
			Me.TextBox15.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox15.TabIndex = 70
			Me.TextBox15.TabStop = False
			Me.TextBox15.Visible = False
			Me.TextBox14.Location = New Global.System.Drawing.Point(154, 385)
			Me.TextBox14.Name = "TextBox14"
			Me.TextBox14.[ReadOnly] = True
			Me.TextBox14.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox14.TabIndex = 69
			Me.TextBox14.TabStop = False
			Me.TextBox14.Visible = False
			Me.TextBox13.Location = New Global.System.Drawing.Point(90, 385)
			Me.TextBox13.Name = "TextBox13"
			Me.TextBox13.[ReadOnly] = True
			Me.TextBox13.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox13.TabIndex = 68
			Me.TextBox13.TabStop = False
			Me.TextBox13.Visible = False
			Me.TextBox12.BackColor = Global.System.Drawing.Color.White
			Me.TextBox12.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox12.Location = New Global.System.Drawing.Point(201, 338)
			Me.TextBox12.Name = "TextBox12"
			Me.TextBox12.[ReadOnly] = True
			Me.TextBox12.Size = New Global.System.Drawing.Size(216, 19)
			Me.TextBox12.TabIndex = 67
			Me.TextBox12.TabStop = False
			Me.TextBox12.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox11.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox11.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox11.Location = New Global.System.Drawing.Point(24, 385)
			Me.TextBox11.Name = "TextBox11"
			Me.TextBox11.[ReadOnly] = True
			Me.TextBox11.Size = New Global.System.Drawing.Size(34, 15)
			Me.TextBox11.TabIndex = 66
			Me.TextBox11.TabStop = False
			Me.TextBox11.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox11.Visible = False
			Me.Label16.AutoSize = True
			Me.Label16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label16.Location = New Global.System.Drawing.Point(28, 338)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(36, 20)
			Me.Label16.TabIndex = 65
			Me.Label16.Text = "PL :"
			Me.TextBox10.BackColor = Global.System.Drawing.Color.White
			Me.TextBox10.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox10.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox10.Location = New Global.System.Drawing.Point(662, 304)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox10.TabIndex = 64
			Me.TextBox10.TabStop = False
			Me.TextBox10.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox9.BackColor = Global.System.Drawing.Color.White
			Me.TextBox9.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox9.ForeColor = Global.System.Drawing.Color.Red
			Me.TextBox9.Location = New Global.System.Drawing.Point(214, 304)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.[ReadOnly] = True
			Me.TextBox9.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox9.TabIndex = 63
			Me.TextBox9.TabStop = False
			Me.TextBox9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label15.AutoSize = True
			Me.Label15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label15.ForeColor = Global.System.Drawing.Color.FromArgb(0, 64, 64)
			Me.Label15.Location = New Global.System.Drawing.Point(462, 304)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(122, 16)
			Me.Label15.TabIndex = 62
			Me.Label15.Text = "Grand Total Credit :"
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.ForeColor = Global.System.Drawing.Color.FromArgb(0, 64, 64)
			Me.Label14.Location = New Global.System.Drawing.Point(28, 304)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(119, 16)
			Me.Label14.TabIndex = 61
			Me.Label14.Text = "Grand Total Debit :"
			Me.TextBox8.BackColor = Global.System.Drawing.Color.White
			Me.TextBox8.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox8.Location = New Global.System.Drawing.Point(214, 193)
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.[ReadOnly] = True
			Me.TextBox8.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox8.TabIndex = 60
			Me.TextBox8.TabStop = False
			Me.TextBox8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox7.BackColor = Global.System.Drawing.Color.White
			Me.TextBox7.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox7.Location = New Global.System.Drawing.Point(214, 168)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.[ReadOnly] = True
			Me.TextBox7.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox7.TabIndex = 59
			Me.TextBox7.TabStop = False
			Me.TextBox7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox6.BackColor = Global.System.Drawing.Color.White
			Me.TextBox6.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox6.Location = New Global.System.Drawing.Point(214, 141)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.[ReadOnly] = True
			Me.TextBox6.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox6.TabIndex = 58
			Me.TextBox6.TabStop = False
			Me.TextBox6.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox5.BackColor = Global.System.Drawing.Color.White
			Me.TextBox5.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox5.Location = New Global.System.Drawing.Point(662, 257)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox5.TabIndex = 57
			Me.TextBox5.TabStop = False
			Me.TextBox5.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox4.BackColor = Global.System.Drawing.Color.White
			Me.TextBox4.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox4.Location = New Global.System.Drawing.Point(662, 225)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.[ReadOnly] = True
			Me.TextBox4.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox4.TabIndex = 56
			Me.TextBox4.TabStop = False
			Me.TextBox4.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox3.BackColor = Global.System.Drawing.Color.White
			Me.TextBox3.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(662, 192)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox3.TabIndex = 55
			Me.TextBox3.TabStop = False
			Me.TextBox3.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox2.BackColor = Global.System.Drawing.Color.White
			Me.TextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(662, 155)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox2.TabIndex = 54
			Me.TextBox2.TabStop = False
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(662, 114)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(203, 15)
			Me.TextBox1.TabIndex = 53
			Me.TextBox1.TabStop = False
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(462, 257)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(57, 16)
			Me.Label11.TabIndex = 11
			Me.Label11.Text = "Income :"
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(28, 192)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(73, 16)
			Me.Label10.TabIndex = 10
			Me.Label10.Text = "Expenses :"
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(28, 167)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(161, 16)
			Me.Label9.TabIndex = 9
			Me.Label9.Text = "Sale Return (Credit Note) :"
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(28, 141)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(70, 16)
			Me.Label8.TabIndex = 8
			Me.Label8.Text = "Purchase :"
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.Location = New Global.System.Drawing.Point(462, 225)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(88, 16)
			Me.Label7.TabIndex = 7
			Me.Label7.Text = "Service (Bill) :"
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.Location = New Global.System.Drawing.Point(462, 192)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(124, 16)
			Me.Label6.TabIndex = 6
			Me.Label6.Text = "Service (Advance) :"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.Location = New Global.System.Drawing.Point(462, 154)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(187, 16)
			Me.Label5.TabIndex = 5
			Me.Label5.Text = "Purchase Return (Debit Note) :"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(462, 114)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(48, 16)
			Me.Label4.TabIndex = 4
			Me.Label4.Text = "Sales :"
			Me.Label3.AutoSize = True
			Me.Label3.BackColor = Global.System.Drawing.Color.DimGray
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(631, 76)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(63, 16)
			Me.Label3.TabIndex = 3
			Me.Label3.Text = "CREDIT"
			Me.Label2.AutoSize = True
			Me.Label2.BackColor = Global.System.Drawing.Color.DimGray
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(198, 76)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(52, 16)
			Me.Label2.TabIndex = 2
			Me.Label2.Text = "DEBIT"
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(0, 1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(893, 27)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "PROFIT AND LOSS"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.ShapeContainer1.Location = New Global.System.Drawing.Point(0, 0)
			Me.ShapeContainer1.Margin = New Global.System.Windows.Forms.Padding(0)
			Me.ShapeContainer1.Name = "ShapeContainer1"
			Me.ShapeContainer1.Shapes.AddRange(New Global.Microsoft.VisualBasic.PowerPacks.Shape() { Me.LineShape1 })
			Me.ShapeContainer1.Size = New Global.System.Drawing.Size(896, 445)
			Me.ShapeContainer1.TabIndex = 0
			Me.ShapeContainer1.TabStop = False
			Me.LineShape1.Name = "LineShape1"
			Me.LineShape1.X1 = 7
			Me.LineShape1.X2 = 872
			Me.LineShape1.Y1 = 71
			Me.LineShape1.Y2 = 71
			Me.Panel4.BackColor = Global.System.Drawing.Color.Gainsboro
			Me.Panel4.Location = New Global.System.Drawing.Point(7, 289)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(866, 10)
			Me.Panel4.TabIndex = 140
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(601, 2)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(164, 33)
			Me.GelButton2.TabIndex = 539
			Me.GelButton2.Text = "&Billwise P/L Report"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(898, 447)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmProfitloss"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Profit and Loss"
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040048E5 RID: 18661
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
