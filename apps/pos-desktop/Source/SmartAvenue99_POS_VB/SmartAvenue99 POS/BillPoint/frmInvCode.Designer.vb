Namespace BillPoint
	' Token: 0x020004CE RID: 1230
		Public Partial Class frmInvCode
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FA7C RID: 64124 RVA: 0x00961190 File Offset: 0x0095F390
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

		' Token: 0x0600FA7D RID: 64125 RVA: 0x009611E0 File Offset: 0x0095F3E0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmInvCode))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.TextBox22 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox21 = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.TextBox11 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox12 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox13 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox14 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox15 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox16 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox17 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox18 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox19 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox20 = New Global.System.Windows.Forms.TextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox0 = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.Panel4.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(666, 488)
			Me.Panel1.TabIndex = 3
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.btnSave)
			Me.Panel2.Location = New Global.System.Drawing.Point(4, 425)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(641, 43)
			Me.Panel2.TabIndex = 47
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(257, 2)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(133, 36)
			Me.btnSave.TabIndex = 515
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-15, -1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(680, 31)
			Me.Label1.TabIndex = 46
			Me.Label1.Text = "Prefix and Suffix Invoice Code"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.TextBox22)
			Me.Panel4.Controls.Add(Me.TextBox21)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.Label14)
			Me.Panel4.Controls.Add(Me.Label13)
			Me.Panel4.Controls.Add(Me.TextBox11)
			Me.Panel4.Controls.Add(Me.TextBox12)
			Me.Panel4.Controls.Add(Me.TextBox13)
			Me.Panel4.Controls.Add(Me.TextBox14)
			Me.Panel4.Controls.Add(Me.TextBox15)
			Me.Panel4.Controls.Add(Me.TextBox16)
			Me.Panel4.Controls.Add(Me.TextBox17)
			Me.Panel4.Controls.Add(Me.TextBox18)
			Me.Panel4.Controls.Add(Me.TextBox19)
			Me.Panel4.Controls.Add(Me.TextBox20)
			Me.Panel4.Controls.Add(Me.Label12)
			Me.Panel4.Controls.Add(Me.TextBox10)
			Me.Panel4.Controls.Add(Me.Label11)
			Me.Panel4.Controls.Add(Me.TextBox9)
			Me.Panel4.Controls.Add(Me.Label10)
			Me.Panel4.Controls.Add(Me.TextBox8)
			Me.Panel4.Controls.Add(Me.TextBox7)
			Me.Panel4.Controls.Add(Me.Label9)
			Me.Panel4.Controls.Add(Me.TextBox6)
			Me.Panel4.Controls.Add(Me.TextBox5)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.TextBox4)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.TextBox3)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.TextBox2)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.TextBox1)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.TextBox0)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(4, 40)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(641, 386)
			Me.Panel4.TabIndex = 0
			Me.TextBox22.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox22.Location = New Global.System.Drawing.Point(463, 359)
			Me.TextBox22.Name = "TextBox22"
			Me.TextBox22.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox22.TabIndex = 21
			Me.TextBox21.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox21.Location = New Global.System.Drawing.Point(252, 359)
			Me.TextBox21.Name = "TextBox21"
			Me.TextBox21.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox21.TabIndex = 20
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(8, 359)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(134, 15)
			Me.Label8.TabIndex = 425
			Me.Label8.Text = "Estimate Invoice Code :"
			Me.Label14.BackColor = Global.System.Drawing.Color.Aqua
			Me.Label14.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label14.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.Location = New Global.System.Drawing.Point(463, 2)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(108, 26)
			Me.Label14.TabIndex = 424
			Me.Label14.Text = "SUFFIX CODE"
			Me.Label13.BackColor = Global.System.Drawing.Color.Aqua
			Me.Label13.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label13.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(252, 2)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(108, 26)
			Me.Label13.TabIndex = 423
			Me.Label13.Text = "PREFIX CODE"
			Me.TextBox11.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox11.Location = New Global.System.Drawing.Point(463, 30)
			Me.TextBox11.Name = "TextBox11"
			Me.TextBox11.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox11.TabIndex = 1
			Me.TextBox12.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox12.Location = New Global.System.Drawing.Point(463, 63)
			Me.TextBox12.Name = "TextBox12"
			Me.TextBox12.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox12.TabIndex = 3
			Me.TextBox13.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox13.Location = New Global.System.Drawing.Point(463, 96)
			Me.TextBox13.Name = "TextBox13"
			Me.TextBox13.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox13.TabIndex = 5
			Me.TextBox14.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox14.Location = New Global.System.Drawing.Point(463, 129)
			Me.TextBox14.Name = "TextBox14"
			Me.TextBox14.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox14.TabIndex = 7
			Me.TextBox15.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox15.Location = New Global.System.Drawing.Point(463, 162)
			Me.TextBox15.Name = "TextBox15"
			Me.TextBox15.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox15.TabIndex = 9
			Me.TextBox16.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox16.Location = New Global.System.Drawing.Point(463, 195)
			Me.TextBox16.Name = "TextBox16"
			Me.TextBox16.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox16.TabIndex = 11
			Me.TextBox17.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox17.Location = New Global.System.Drawing.Point(463, 228)
			Me.TextBox17.Name = "TextBox17"
			Me.TextBox17.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox17.TabIndex = 13
			Me.TextBox18.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox18.Location = New Global.System.Drawing.Point(463, 261)
			Me.TextBox18.Name = "TextBox18"
			Me.TextBox18.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox18.TabIndex = 15
			Me.TextBox19.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox19.Location = New Global.System.Drawing.Point(463, 294)
			Me.TextBox19.Name = "TextBox19"
			Me.TextBox19.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox19.TabIndex = 17
			Me.TextBox20.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox20.Location = New Global.System.Drawing.Point(463, 327)
			Me.TextBox20.Name = "TextBox20"
			Me.TextBox20.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox20.TabIndex = 19
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(8, 327)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(134, 15)
			Me.Label12.TabIndex = 422
			Me.Label12.Text = "Expense Invoice Code :"
			Me.TextBox10.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox10.Location = New Global.System.Drawing.Point(252, 327)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox10.TabIndex = 18
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(8, 294)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(127, 15)
			Me.Label11.TabIndex = 420
			Me.Label11.Text = "Income Invoice Code :"
			Me.TextBox9.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox9.Location = New Global.System.Drawing.Point(252, 294)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox9.TabIndex = 16
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(8, 261)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(134, 15)
			Me.Label10.TabIndex = 418
			Me.Label10.Text = "Payment Invoice Code :"
			Me.TextBox8.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox8.Location = New Global.System.Drawing.Point(252, 261)
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox8.TabIndex = 14
			Me.TextBox7.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox7.Location = New Global.System.Drawing.Point(252, 228)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox7.TabIndex = 12
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(8, 228)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(128, 15)
			Me.Label9.TabIndex = 416
			Me.Label9.Text = "Receipt Invoice Code :"
			Me.TextBox6.BackColor = Global.System.Drawing.SystemColors.Control
			Me.TextBox6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox6.Location = New Global.System.Drawing.Point(144, 30)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.[ReadOnly] = True
			Me.TextBox6.Size = New Global.System.Drawing.Size(27, 21)
			Me.TextBox6.TabIndex = 414
			Me.TextBox6.TabStop = False
			Me.TextBox6.Visible = False
			Me.TextBox5.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox5.Location = New Global.System.Drawing.Point(252, 195)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox5.TabIndex = 10
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(8, 195)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(172, 15)
			Me.Label7.TabIndex = 413
			Me.Label7.Text = "Purchase Order Invoice Code :"
			Me.TextBox4.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox4.Location = New Global.System.Drawing.Point(252, 162)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox4.TabIndex = 8
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(8, 162)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(139, 15)
			Me.Label6.TabIndex = 411
			Me.Label6.Text = "Quotation Invoice Code :"
			Me.TextBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(252, 129)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox3.TabIndex = 6
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(8, 129)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(178, 15)
			Me.Label5.TabIndex = 409
			Me.Label5.Text = "Purchase Return Invoice Code :"
			Me.TextBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(252, 96)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox2.TabIndex = 4
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(8, 96)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(151, 15)
			Me.Label4.TabIndex = 407
			Me.Label4.Text = "Sale Return Invoice Code :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(252, 63)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox1.TabIndex = 2
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(8, 63)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(138, 15)
			Me.Label2.TabIndex = 405
			Me.Label2.Text = "Purchase Invoice Code :"
			Me.TextBox0.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox0.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox0.Location = New Global.System.Drawing.Point(252, 30)
			Me.TextBox0.Name = "TextBox0"
			Me.TextBox0.Size = New Global.System.Drawing.Size(108, 21)
			Me.TextBox0.TabIndex = 0
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(8, 30)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(111, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Sale Invoice Code :"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(666, 488)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmInvCode"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005FDC RID: 24540
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
