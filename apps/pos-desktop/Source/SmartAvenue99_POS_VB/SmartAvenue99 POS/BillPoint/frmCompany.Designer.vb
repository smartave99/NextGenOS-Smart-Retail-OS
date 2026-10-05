Namespace BillPoint
	' Token: 0x020005D6 RID: 1494
		Public Partial Class frmCompany
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060124A1 RID: 74913 RVA: 0x00A839D8 File Offset: 0x00A81BD8
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

		' Token: 0x060124A2 RID: 74914 RVA: 0x00A83A28 File Offset: 0x00A81C28
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCompany))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.lblProgress = New Global.System.Windows.Forms.Label()
			Me.txtEmail = New Global.System.Windows.Forms.TextBox()
			Me.txtCompanyID = New Global.System.Windows.Forms.TextBox()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TabControl1 = New Global.System.Windows.Forms.TabControl()
			Me.TabPage1 = New Global.System.Windows.Forms.TabPage()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtLoyality = New Global.System.Windows.Forms.TextBox()
			Me.lbl_Result = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtCurrencySymb = New Global.System.Windows.Forms.TextBox()
			Me.txtWeb = New Global.System.Windows.Forms.TextBox()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.txtCity = New Global.System.Windows.Forms.TextBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker3 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.cmbState = New Global.System.Windows.Forms.ComboBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.btnBrowse = New Global.System.Windows.Forms.Button()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.txtCIN = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtGSTIN = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtCompanyName = New Global.System.Windows.Forms.TextBox()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.TabControl1.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.TabControl1)
			Me.Panel1.Location = New Global.System.Drawing.Point(7, 8)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(748, 437)
			Me.Panel1.TabIndex = 2
			Me.Panel2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.lblProgress)
			Me.Panel2.Controls.Add(Me.txtEmail)
			Me.Panel2.Controls.Add(Me.txtCompanyID)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.ProgressBar1)
			Me.Panel2.Location = New Global.System.Drawing.Point(9, 7)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(729, 62)
			Me.Panel2.TabIndex = 0
			Me.lblProgress.AutoSize = True
			Me.lblProgress.BackColor = Global.System.Drawing.Color.FromArgb(224, 224, 224)
			Me.lblProgress.ForeColor = Global.System.Drawing.Color.White
			Me.lblProgress.Location = New Global.System.Drawing.Point(353, 43)
			Me.lblProgress.Name = "lblProgress"
			Me.lblProgress.Size = New Global.System.Drawing.Size(21, 13)
			Me.lblProgress.TabIndex = 10
			Me.lblProgress.Text = "0%"
			Me.lblProgress.Visible = False
			Me.txtEmail.Location = New Global.System.Drawing.Point(647, 20)
			Me.txtEmail.Name = "txtEmail"
			Me.txtEmail.Size = New Global.System.Drawing.Size(10, 20)
			Me.txtEmail.TabIndex = 8
			Me.txtEmail.TabStop = False
			Me.txtEmail.Visible = False
			Me.txtCompanyID.Location = New Global.System.Drawing.Point(541, 20)
			Me.txtCompanyID.Name = "txtCompanyID"
			Me.txtCompanyID.[ReadOnly] = True
			Me.txtCompanyID.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtCompanyID.TabIndex = 7
			Me.txtCompanyID.TabStop = False
			Me.txtCompanyID.Visible = False
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(59, 42)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(614, 17)
			Me.ProgressBar1.TabIndex = 9
			Me.ProgressBar1.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(280, 16)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(165, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Create Company"
			Me.TabControl1.Controls.Add(Me.TabPage1)
			Me.TabControl1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.TabControl1.Location = New Global.System.Drawing.Point(9, 75)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New Global.System.Drawing.Size(729, 353)
			Me.TabControl1.TabIndex = 6
			Me.TabControl1.TabStop = False
			Me.TabPage1.Controls.Add(Me.Panel4)
			Me.TabPage1.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage1.Size = New Global.System.Drawing.Size(721, 327)
			Me.TabPage1.TabIndex = 0
			Me.TabPage1.Text = "Create"
			Me.TabPage1.UseVisualStyleBackColor = True
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Label10)
			Me.Panel4.Controls.Add(Me.txtLoyality)
			Me.Panel4.Controls.Add(Me.lbl_Result)
			Me.Panel4.Controls.Add(Me.Label9)
			Me.Panel4.Controls.Add(Me.txtCurrencySymb)
			Me.Panel4.Controls.Add(Me.txtWeb)
			Me.Panel4.Controls.Add(Me.Label18)
			Me.Panel4.Controls.Add(Me.txtCity)
			Me.Panel4.Controls.Add(Me.Label17)
			Me.Panel4.Controls.Add(Me.DateTimePicker3)
			Me.Panel4.Controls.Add(Me.Label15)
			Me.Panel4.Controls.Add(Me.Label14)
			Me.Panel4.Controls.Add(Me.DateTimePicker2)
			Me.Panel4.Controls.Add(Me.DateTimePicker1)
			Me.Panel4.Controls.Add(Me.Label13)
			Me.Panel4.Controls.Add(Me.Button5)
			Me.Panel4.Controls.Add(Me.Button3)
			Me.Panel4.Controls.Add(Me.lblUser)
			Me.Panel4.Controls.Add(Me.cmbState)
			Me.Panel4.Controls.Add(Me.txtID)
			Me.Panel4.Controls.Add(Me.lblSet)
			Me.Panel4.Controls.Add(Me.btnBrowse)
			Me.Panel4.Controls.Add(Me.PictureBox1)
			Me.Panel4.Controls.Add(Me.txtAddress)
			Me.Panel4.Controls.Add(Me.txtCIN)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.txtGSTIN)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.txtEmailID)
			Me.Panel4.Controls.Add(Me.txtContactNo)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.txtCompanyName)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(6, 6)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(709, 315)
			Me.Panel4.TabIndex = 0
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(448, 212)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(137, 15)
			Me.Label10.TabIndex = 1749
			Me.Label10.Text = "Loyality Per Pont Value :"
			Me.txtLoyality.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtLoyality.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtLoyality.Location = New Global.System.Drawing.Point(451, 232)
			Me.txtLoyality.Name = "txtLoyality"
			Me.txtLoyality.Size = New Global.System.Drawing.Size(120, 21)
			Me.txtLoyality.TabIndex = 1748
			Me.txtLoyality.Text = "0.10"
			Me.lbl_Result.AutoSize = True
			Me.lbl_Result.Location = New Global.System.Drawing.Point(448, 188)
			Me.lbl_Result.Name = "lbl_Result"
			Me.lbl_Result.Size = New Global.System.Drawing.Size(0, 15)
			Me.lbl_Result.TabIndex = 1747
			Me.Label9.AutoSize = True
			Me.Label9.ForeColor = Global.System.Drawing.Color.Red
			Me.Label9.Location = New Global.System.Drawing.Point(498, 261)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(105, 15)
			Me.Label9.TabIndex = 328
			Me.Label9.Text = "Currency Symbol :"
			Me.txtCurrencySymb.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCurrencySymb.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCurrencySymb.Location = New Global.System.Drawing.Point(501, 282)
			Me.txtCurrencySymb.Name = "txtCurrencySymb"
			Me.txtCurrencySymb.Size = New Global.System.Drawing.Size(98, 24)
			Me.txtCurrencySymb.TabIndex = 12
			Me.txtCurrencySymb.Text = "₹"
			Me.txtWeb.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtWeb.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtWeb.Location = New Global.System.Drawing.Point(121, 232)
			Me.txtWeb.Name = "txtWeb"
			Me.txtWeb.Size = New Global.System.Drawing.Size(324, 21)
			Me.txtWeb.TabIndex = 8
			Me.Label18.AutoSize = True
			Me.Label18.Location = New Global.System.Drawing.Point(3, 232)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(57, 15)
			Me.Label18.TabIndex = 326
			Me.Label18.Text = "Website :"
			Me.txtCity.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCity.Location = New Global.System.Drawing.Point(121, 79)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.Size = New Global.System.Drawing.Size(324, 21)
			Me.txtCity.TabIndex = 2
			Me.Label17.AutoSize = True
			Me.Label17.Location = New Global.System.Drawing.Point(3, 79)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(32, 15)
			Me.Label17.TabIndex = 324
			Me.Label17.Text = "City :"
			Me.DateTimePicker3.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker3.Enabled = False
			Me.DateTimePicker3.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker3.Location = New Global.System.Drawing.Point(577, 232)
			Me.DateTimePicker3.Name = "DateTimePicker3"
			Me.DateTimePicker3.Size = New Global.System.Drawing.Size(125, 21)
			Me.DateTimePicker3.TabIndex = 323
			Me.DateTimePicker3.TabStop = False
			Me.DateTimePicker3.Visible = False
			Me.Label15.AutoSize = True
			Me.Label15.ForeColor = Global.System.Drawing.Color.Red
			Me.Label15.Location = New Global.System.Drawing.Point(317, 261)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(60, 15)
			Me.Label15.TabIndex = 322
			Me.Label15.Text = "Ends On :"
			Me.Label14.AutoSize = True
			Me.Label14.ForeColor = Global.System.Drawing.Color.Red
			Me.Label14.Location = New Global.System.Drawing.Point(118, 261)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(83, 15)
			Me.Label14.TabIndex = 321
			Me.Label14.Text = "Begins From :"
			Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker2.Location = New Global.System.Drawing.Point(320, 282)
			Me.DateTimePicker2.Name = "DateTimePicker2"
			Me.DateTimePicker2.ShowUpDown = True
			Me.DateTimePicker2.Size = New Global.System.Drawing.Size(125, 24)
			Me.DateTimePicker2.TabIndex = 10
			Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(121, 282)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.ShowUpDown = True
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(125, 24)
			Me.DateTimePicker1.TabIndex = 9
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(3, 261)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(91, 15)
			Me.Label13.TabIndex = 318
			Me.Label13.Text = "Financial Year :"
			Me.Button5.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button5.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button5.ForeColor = Global.System.Drawing.Color.White
			Me.Button5.Image = CType(componentResourceManager.GetObject("Button5.Image"), Global.System.Drawing.Image)
			Me.Button5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button5.Location = New Global.System.Drawing.Point(604, 53)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(98, 40)
			Me.Button5.TabIndex = 14
			Me.Button5.Text = "&Reset"
			Me.Button5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button5.UseVisualStyleBackColor = False
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(604, 6)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(98, 40)
			Me.Button3.TabIndex = 13
			Me.Button3.Text = "&Create"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(589, 161)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(45, 15)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.cmbState.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbState.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbState.FormattingEnabled = True
			Me.cmbState.Items.AddRange(New Object() { "Andaman and Nicobar Islands", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra and Nagar Haveli and Daman and Diu", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Ladakh", "Lakshadweep", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Puducherry", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal", "SriLanka" })
			Me.cmbState.Location = New Global.System.Drawing.Point(121, 105)
			Me.cmbState.Name = "cmbState"
			Me.cmbState.Size = New Global.System.Drawing.Size(324, 23)
			Me.cmbState.TabIndex = 3
			Me.txtID.Location = New Global.System.Drawing.Point(634, 157)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(68, 21)
			Me.txtID.TabIndex = 4
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(633, 71)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(38, 15)
			Me.lblSet.TabIndex = 8
			Me.lblSet.Text = "lblSet"
			Me.btnBrowse.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnBrowse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnBrowse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnBrowse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnBrowse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBrowse.ForeColor = Global.System.Drawing.Color.White
			Me.btnBrowse.Image = CType(componentResourceManager.GetObject("btnBrowse.Image"), Global.System.Drawing.Image)
			Me.btnBrowse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnBrowse.Location = New Global.System.Drawing.Point(480, 150)
			Me.btnBrowse.Name = "btnBrowse"
			Me.btnBrowse.Size = New Global.System.Drawing.Size(100, 37)
			Me.btnBrowse.TabIndex = 11
			Me.btnBrowse.Text = "&Browse..."
			Me.btnBrowse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnBrowse.UseVisualStyleBackColor = False
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.Nologo
			Me.PictureBox1.Location = New Global.System.Drawing.Point(461, 7)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(138, 140)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 17
			Me.PictureBox1.TabStop = False
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(121, 32)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(324, 42)
			Me.txtAddress.TabIndex = 1
			Me.txtCIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCIN.Location = New Global.System.Drawing.Point(121, 207)
			Me.txtCIN.Name = "txtCIN"
			Me.txtCIN.Size = New Global.System.Drawing.Size(324, 21)
			Me.txtCIN.TabIndex = 7
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(3, 207)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(33, 15)
			Me.Label8.TabIndex = 14
			Me.Label8.Text = "CIN :"
			Me.txtGSTIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtGSTIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGSTIN.Location = New Global.System.Drawing.Point(121, 182)
			Me.txtGSTIN.Name = "txtGSTIN"
			Me.txtGSTIN.Size = New Global.System.Drawing.Size(324, 21)
			Me.txtGSTIN.TabIndex = 6
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(3, 105)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(110, 15)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "State [State Code] :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(3, 182)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(49, 15)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "GSTIN :"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(3, 157)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(60, 15)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Email ID :"
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.Location = New Global.System.Drawing.Point(121, 157)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(324, 21)
			Me.txtEmailID.TabIndex = 5
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(121, 132)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(324, 21)
			Me.txtContactNo.TabIndex = 4
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(3, 132)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(76, 15)
			Me.Label4.TabIndex = 6
			Me.Label4.Text = "Contact No. :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(3, 32)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(57, 15)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Address :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(3, 7)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(102, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Company Name :"
			Me.txtCompanyName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCompanyName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCompanyName.Location = New Global.System.Drawing.Point(121, 7)
			Me.txtCompanyName.Name = "txtCompanyName"
			Me.txtCompanyName.Size = New Global.System.Drawing.Size(324, 21)
			Me.txtCompanyName.TabIndex = 0
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(764, 453)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCompany"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Panel1.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.TabControl1.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006DE9 RID: 28137
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
