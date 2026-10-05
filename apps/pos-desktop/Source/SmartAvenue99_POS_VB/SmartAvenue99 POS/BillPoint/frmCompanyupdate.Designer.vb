Namespace BillPoint
	' Token: 0x020004B1 RID: 1201
		Public Partial Class frmCompanyupdate
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600F10A RID: 61706 RVA: 0x0090C2D4 File Offset: 0x0090A4D4
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

		' Token: 0x0600F10B RID: 61707 RVA: 0x0090C324 File Offset: 0x0090A524
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCompanyupdate))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.lblProgress = New Global.System.Windows.Forms.Label()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.btnUpgrade = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.PictureBox3 = New Global.System.Windows.Forms.PictureBox()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.txtAdminCode = New Global.System.Windows.Forms.TextBox()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.btnbranchUpdate = New Global.GelButtons.GelButton()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.txtDB = New Global.System.Windows.Forms.TextBox()
			Me.txtBcode = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.PictureBox4 = New Global.System.Windows.Forms.PictureBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtLoyality = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.Label22 = New Global.System.Windows.Forms.Label()
			Me.Label24 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtCompanyName = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtGSTIN = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtCIN = New Global.System.Windows.Forms.TextBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.cmbState = New Global.System.Windows.Forms.ComboBox()
			Me.txtCity = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.txtWeb = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.lbl_Result = New Global.System.Windows.Forms.Label()
			Me.btnprint = New Global.GelButtons.GelButton()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.Button23 = New Global.System.Windows.Forms.Button()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.txtCurrencySymb = New Global.System.Windows.Forms.TextBox()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.btnBrowse = New Global.System.Windows.Forms.Button()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.txtEmail = New Global.System.Windows.Forms.TextBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.txtCName = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtCompanyID = New Global.System.Windows.Forms.TextBox()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox4, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(5, 7)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(817, 579)
			Me.Panel1.TabIndex = 3
			Me.Panel4.BackColor = Global.System.Drawing.Color.Azure
			Me.Panel4.Controls.Add(Me.lblProgress)
			Me.Panel4.Controls.Add(Me.ProgressBar1)
			Me.Panel4.Controls.Add(Me.btnUpgrade)
			Me.Panel4.Controls.Add(Me.GroupBox1)
			Me.Panel4.Controls.Add(Me.TextBox5)
			Me.Panel4.Controls.Add(Me.Label16)
			Me.Panel4.Controls.Add(Me.txtAdminCode)
			Me.Panel4.Controls.Add(Me.Label19)
			Me.Panel4.Controls.Add(Me.btnbranchUpdate)
			Me.Panel4.Controls.Add(Me.Button1)
			Me.Panel4.Controls.Add(Me.Label15)
			Me.Panel4.Controls.Add(Me.txtDB)
			Me.Panel4.Controls.Add(Me.txtBcode)
			Me.Panel4.Controls.Add(Me.Label1)
			Me.Panel4.Controls.Add(Me.PictureBox4)
			Me.Panel4.Controls.Add(Me.GroupBox2)
			Me.Panel4.Controls.Add(Me.lbl_Result)
			Me.Panel4.Controls.Add(Me.btnprint)
			Me.Panel4.Controls.Add(Me.btnReset)
			Me.Panel4.Controls.Add(Me.Button23)
			Me.Panel4.Controls.Add(Me.Label17)
			Me.Panel4.Controls.Add(Me.txtCurrencySymb)
			Me.Panel4.Controls.Add(Me.btnSave)
			Me.Panel4.Controls.Add(Me.Label18)
			Me.Panel4.Controls.Add(Me.btnBrowse)
			Me.Panel4.Controls.Add(Me.PictureBox1)
			Me.Panel4.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(815, 577)
			Me.Panel4.TabIndex = 0
			Me.lblProgress.AutoSize = True
			Me.lblProgress.BackColor = Global.System.Drawing.Color.FromArgb(224, 224, 224)
			Me.lblProgress.ForeColor = Global.System.Drawing.Color.White
			Me.lblProgress.Location = New Global.System.Drawing.Point(559, 9)
			Me.lblProgress.Name = "lblProgress"
			Me.lblProgress.Size = New Global.System.Drawing.Size(25, 15)
			Me.lblProgress.TabIndex = 1757
			Me.lblProgress.Text = "0%"
			Me.lblProgress.Visible = False
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(460, 3)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(340, 27)
			Me.ProgressBar1.TabIndex = 10
			Me.ProgressBar1.Visible = False
			Me.btnUpgrade.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpgrade.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnUpgrade.FlatAppearance.BorderSize = 0
			Me.btnUpgrade.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpgrade.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpgrade.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpgrade.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpgrade.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnUpgrade.Image = CType(componentResourceManager.GetObject("btnUpgrade.Image"), Global.System.Drawing.Image)
			Me.btnUpgrade.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpgrade.Location = New Global.System.Drawing.Point(644, 180)
			Me.btnUpgrade.Name = "btnUpgrade"
			Me.btnUpgrade.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnUpgrade.TabIndex = 1756
			Me.btnUpgrade.Text = "Upgrade Online"
			Me.btnUpgrade.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpgrade.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.ComboBox1)
			Me.GroupBox1.Controls.Add(Me.PictureBox2)
			Me.GroupBox1.Controls.Add(Me.PictureBox3)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(467, 355)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(342, 135)
			Me.GroupBox1.TabIndex = 1749
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Mobile Android App and Multi Branch  Status :"
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Enabled", "Disabled" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(202, 64)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(134, 23)
			Me.ComboBox1.TabIndex = 339
			Me.ComboBox1.TabStop = False
			Me.PictureBox2.Image = CType(componentResourceManager.GetObject("PictureBox2.Image"), Global.System.Drawing.Image)
			Me.PictureBox2.Location = New Global.System.Drawing.Point(276, 13)
			Me.PictureBox2.Name = "PictureBox2"
			Me.PictureBox2.Size = New Global.System.Drawing.Size(62, 45)
			Me.PictureBox2.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox2.TabIndex = 343
			Me.PictureBox2.TabStop = False
			Me.PictureBox3.Location = New Global.System.Drawing.Point(6, 19)
			Me.PictureBox3.Name = "PictureBox3"
			Me.PictureBox3.Size = New Global.System.Drawing.Size(129, 110)
			Me.PictureBox3.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox3.TabIndex = 344
			Me.PictureBox3.TabStop = False
			Me.TextBox5.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.TextBox5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox5.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox5.Location = New Global.System.Drawing.Point(460, 322)
			Me.TextBox5.Multiline = True
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(290, 24)
			Me.TextBox5.TabIndex = 337
			Me.TextBox5.TabStop = False
			Me.Label16.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label16.Location = New Global.System.Drawing.Point(458, 493)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(99, 23)
			Me.Label16.TabIndex = 1755
			Me.Label16.Text = "Admin Code"
			Me.Label16.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label16.Visible = False
			Me.txtAdminCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAdminCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAdminCode.ForeColor = Global.System.Drawing.Color.Blue
			Me.txtAdminCode.Location = New Global.System.Drawing.Point(467, 517)
			Me.txtAdminCode.Multiline = True
			Me.txtAdminCode.Name = "txtAdminCode"
			Me.txtAdminCode.Size = New Global.System.Drawing.Size(169, 24)
			Me.txtAdminCode.TabIndex = 1754
			Me.txtAdminCode.TabStop = False
			Me.txtAdminCode.Visible = False
			Me.Label19.AutoSize = True
			Me.Label19.Location = New Global.System.Drawing.Point(457, 303)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(80, 15)
			Me.Label19.TabIndex = 341
			Me.Label19.Text = "Company ID ;"
			Me.btnbranchUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnbranchUpdate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnbranchUpdate.FlatAppearance.BorderSize = 0
			Me.btnbranchUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnbranchUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnbranchUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnbranchUpdate.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnbranchUpdate.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnbranchUpdate.Image = CType(componentResourceManager.GetObject("btnbranchUpdate.Image"), Global.System.Drawing.Image)
			Me.btnbranchUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnbranchUpdate.Location = New Global.System.Drawing.Point(642, 496)
			Me.btnbranchUpdate.Name = "btnbranchUpdate"
			Me.btnbranchUpdate.Size = New Global.System.Drawing.Size(157, 44)
			Me.btnbranchUpdate.TabIndex = 1753
			Me.btnbranchUpdate.Text = "Branch Update"
			Me.btnbranchUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnbranchUpdate.UseVisualStyleBackColor = False
			Me.btnbranchUpdate.Visible = False
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.Transparent
			Me.Button1.Location = New Global.System.Drawing.Point(756, 320)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(53, 24)
			Me.Button1.TabIndex = 342
			Me.Button1.TabStop = False
			Me.Button1.Text = "&Copy"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label15.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label15.Location = New Global.System.Drawing.Point(563, 249)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(99, 23)
			Me.Label15.TabIndex = 1752
			Me.Label15.Text = "Barcode Code"
			Me.Label15.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtDB.Location = New Global.System.Drawing.Point(576, 300)
			Me.txtDB.Multiline = True
			Me.txtDB.Name = "txtDB"
			Me.txtDB.[ReadOnly] = True
			Me.txtDB.Size = New Global.System.Drawing.Size(38, 20)
			Me.txtDB.TabIndex = 12
			Me.txtDB.TabStop = False
			Me.txtBcode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBcode.ForeColor = Global.System.Drawing.Color.Blue
			Me.txtBcode.Location = New Global.System.Drawing.Point(573, 273)
			Me.txtBcode.Multiline = True
			Me.txtBcode.Name = "txtBcode"
			Me.txtBcode.Size = New Global.System.Drawing.Size(97, 24)
			Me.txtBcode.TabIndex = 1751
			Me.txtBcode.TabStop = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(289, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(166, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Company Master"
			Me.PictureBox4.Image = CType(componentResourceManager.GetObject("PictureBox4.Image"), Global.System.Drawing.Image)
			Me.PictureBox4.Location = New Global.System.Drawing.Point(694, 226)
			Me.PictureBox4.Name = "PictureBox4"
			Me.PictureBox4.Size = New Global.System.Drawing.Size(90, 89)
			Me.PictureBox4.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox4.TabIndex = 345
			Me.PictureBox4.TabStop = False
			Me.PictureBox4.Visible = False
			Me.GroupBox2.Controls.Add(Me.Label10)
			Me.GroupBox2.Controls.Add(Me.txtLoyality)
			Me.GroupBox2.Controls.Add(Me.GroupBox3)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Controls.Add(Me.txtCompanyName)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.txtContactNo)
			Me.GroupBox2.Controls.Add(Me.txtEmailID)
			Me.GroupBox2.Controls.Add(Me.Label5)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.Label7)
			Me.GroupBox2.Controls.Add(Me.txtGSTIN)
			Me.GroupBox2.Controls.Add(Me.Label8)
			Me.GroupBox2.Controls.Add(Me.txtCIN)
			Me.GroupBox2.Controls.Add(Me.txtAddress)
			Me.GroupBox2.Controls.Add(Me.cmbState)
			Me.GroupBox2.Controls.Add(Me.txtCity)
			Me.GroupBox2.Controls.Add(Me.Label13)
			Me.GroupBox2.Controls.Add(Me.txtWeb)
			Me.GroupBox2.Controls.Add(Me.Label14)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(6, 26)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(449, 518)
			Me.GroupBox2.TabIndex = 1750
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Company Info"
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(20, 390)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(137, 15)
			Me.Label10.TabIndex = 1753
			Me.Label10.Text = "Loyality Per Pont Value :"
			Me.txtLoyality.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtLoyality.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtLoyality.Location = New Global.System.Drawing.Point(165, 387)
			Me.txtLoyality.Name = "txtLoyality"
			Me.txtLoyality.Size = New Global.System.Drawing.Size(120, 21)
			Me.txtLoyality.TabIndex = 1752
			Me.GroupBox3.Controls.Add(Me.Label21)
			Me.GroupBox3.Controls.Add(Me.Label20)
			Me.GroupBox3.Controls.Add(Me.Label22)
			Me.GroupBox3.Controls.Add(Me.Label24)
			Me.GroupBox3.Controls.Add(Me.TextBox1)
			Me.GroupBox3.Controls.Add(Me.TextBox2)
			Me.GroupBox3.Controls.Add(Me.TextBox3)
			Me.GroupBox3.Controls.Add(Me.TextBox4)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(10, 267)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(421, 112)
			Me.GroupBox3.TabIndex = 1751
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Bank Details"
			Me.Label21.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label21.AutoSize = True
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label21.ForeColor = Global.System.Drawing.Color.Black
			Me.Label21.Location = New Global.System.Drawing.Point(12, 24)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label21.TabIndex = 1762
			Me.Label21.Text = "Account Name"
			Me.Label20.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label20.AutoSize = True
			Me.Label20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label20.ForeColor = Global.System.Drawing.Color.Black
			Me.Label20.Location = New Global.System.Drawing.Point(12, 47)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(64, 13)
			Me.Label20.TabIndex = 1761
			Me.Label20.Text = "Account No"
			Me.Label22.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label22.AutoSize = True
			Me.Label22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label22.ForeColor = Global.System.Drawing.Color.Black
			Me.Label22.Location = New Global.System.Drawing.Point(12, 91)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(57, 13)
			Me.Label22.TabIndex = 1764
			Me.Label22.Text = "IFSC code"
			Me.Label24.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label24.AutoSize = True
			Me.Label24.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label24.ForeColor = Global.System.Drawing.Color.Black
			Me.Label24.Location = New Global.System.Drawing.Point(12, 70)
			Me.Label24.Name = "Label24"
			Me.Label24.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label24.TabIndex = 1763
			Me.Label24.Text = "Branch"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(133, 16)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(275, 21)
			Me.TextBox1.TabIndex = 9
			Me.TextBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(133, 39)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(275, 21)
			Me.TextBox2.TabIndex = 10
			Me.TextBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(133, 62)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(275, 21)
			Me.TextBox3.TabIndex = 11
			Me.TextBox4.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox4.Location = New Global.System.Drawing.Point(133, 85)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.Size = New Global.System.Drawing.Size(275, 21)
			Me.TextBox4.TabIndex = 12
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(7, 18)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(96, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Company Name"
			Me.txtCompanyName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCompanyName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCompanyName.Location = New Global.System.Drawing.Point(125, 17)
			Me.txtCompanyName.Name = "txtCompanyName"
			Me.txtCompanyName.Size = New Global.System.Drawing.Size(305, 21)
			Me.txtCompanyName.TabIndex = 0
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(7, 43)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(51, 15)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Address"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(7, 139)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(67, 15)
			Me.Label4.TabIndex = 6
			Me.Label4.Text = "Contact No"
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(125, 139)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(305, 21)
			Me.txtContactNo.TabIndex = 4
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.Location = New Global.System.Drawing.Point(125, 165)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(305, 21)
			Me.txtEmailID.TabIndex = 5
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(7, 165)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(54, 15)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Email ID"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(7, 191)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(43, 15)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "GSTIN"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(7, 111)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(35, 15)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "State"
			Me.txtGSTIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtGSTIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGSTIN.Location = New Global.System.Drawing.Point(125, 191)
			Me.txtGSTIN.Name = "txtGSTIN"
			Me.txtGSTIN.Size = New Global.System.Drawing.Size(305, 21)
			Me.txtGSTIN.TabIndex = 6
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(7, 217)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(27, 15)
			Me.Label8.TabIndex = 14
			Me.Label8.Text = "CIN"
			Me.txtCIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCIN.Location = New Global.System.Drawing.Point(125, 217)
			Me.txtCIN.Name = "txtCIN"
			Me.txtCIN.Size = New Global.System.Drawing.Size(305, 21)
			Me.txtCIN.TabIndex = 7
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(125, 43)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(305, 37)
			Me.txtAddress.TabIndex = 1
			Me.cmbState.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbState.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbState.FormattingEnabled = True
			Me.cmbState.Items.AddRange(New Object() { "Andaman and Nicobar Islands", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra and Nagar Haveli and Daman and Diu", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Ladakh", "Lakshadweep", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Puducherry", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal", "SriLanka" })
			Me.cmbState.Location = New Global.System.Drawing.Point(125, 111)
			Me.cmbState.Name = "cmbState"
			Me.cmbState.Size = New Global.System.Drawing.Size(305, 23)
			Me.cmbState.TabIndex = 3
			Me.txtCity.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCity.Location = New Global.System.Drawing.Point(125, 85)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.Size = New Global.System.Drawing.Size(305, 21)
			Me.txtCity.TabIndex = 2
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(7, 243)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(51, 15)
			Me.Label13.TabIndex = 325
			Me.Label13.Text = "Website"
			Me.txtWeb.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtWeb.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtWeb.Location = New Global.System.Drawing.Point(125, 243)
			Me.txtWeb.Name = "txtWeb"
			Me.txtWeb.Size = New Global.System.Drawing.Size(305, 21)
			Me.txtWeb.TabIndex = 8
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(7, 85)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(26, 15)
			Me.Label14.TabIndex = 326
			Me.Label14.Text = "City"
			Me.lbl_Result.AutoSize = True
			Me.lbl_Result.Location = New Global.System.Drawing.Point(449, 186)
			Me.lbl_Result.Name = "lbl_Result"
			Me.lbl_Result.Size = New Global.System.Drawing.Size(0, 15)
			Me.lbl_Result.TabIndex = 1748
			Me.btnprint.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnprint.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnprint.FlatAppearance.BorderSize = 0
			Me.btnprint.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnprint.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnprint.ForeColor = Global.System.Drawing.Color.White
			Me.btnprint.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnprint.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnprint.Image = CType(componentResourceManager.GetObject("btnprint.Image"), Global.System.Drawing.Image)
			Me.btnprint.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnprint.Location = New Global.System.Drawing.Point(644, 133)
			Me.btnprint.Name = "btnprint"
			Me.btnprint.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnprint.TabIndex = 515
			Me.btnprint.Text = "Envelope Print"
			Me.btnprint.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnprint.UseVisualStyleBackColor = False
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnReset.FlatAppearance.BorderSize = 0
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnReset.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(644, 86)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnReset.TabIndex = 516
			Me.btnReset.Text = "Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.Button23.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button23.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button23.ForeColor = Global.System.Drawing.Color.White
			Me.Button23.Image = CType(componentResourceManager.GetObject("Button23.Image"), Global.System.Drawing.Image)
			Me.Button23.Location = New Global.System.Drawing.Point(673, 251)
			Me.Button23.Name = "Button23"
			Me.Button23.Size = New Global.System.Drawing.Size(19, 19)
			Me.Button23.TabIndex = 1690
			Me.Button23.TabStop = False
			Me.Button23.UseVisualStyleBackColor = True
			Me.Button23.Visible = False
			Me.Label17.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label17.Location = New Global.System.Drawing.Point(459, 249)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(99, 23)
			Me.Label17.TabIndex = 1692
			Me.Label17.Text = "Currency Symbol"
			Me.Label17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtCurrencySymb.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCurrencySymb.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCurrencySymb.ForeColor = Global.System.Drawing.Color.Blue
			Me.txtCurrencySymb.Location = New Global.System.Drawing.Point(461, 273)
			Me.txtCurrencySymb.Multiline = True
			Me.txtCurrencySymb.Name = "txtCurrencySymb"
			Me.txtCurrencySymb.Size = New Global.System.Drawing.Size(97, 24)
			Me.txtCurrencySymb.TabIndex = 16
			Me.txtCurrencySymb.TabStop = False
			Me.txtCurrencySymb.Text = "₹"
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
			Me.btnSave.Location = New Global.System.Drawing.Point(644, 38)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnSave.TabIndex = 514
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Label18.BackColor = Global.System.Drawing.Color.Crimson
			Me.Label18.ForeColor = Global.System.Drawing.Color.White
			Me.Label18.Location = New Global.System.Drawing.Point(449, 229)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(263, 19)
			Me.Label18.TabIndex = 340
			Me.Label18.Text = "Mobile Android App and Multi Branch  Status :"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Label18.Visible = False
			Me.btnBrowse.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnBrowse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnBrowse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnBrowse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnBrowse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBrowse.ForeColor = Global.System.Drawing.Color.White
			Me.btnBrowse.Image = CType(componentResourceManager.GetObject("btnBrowse.Image"), Global.System.Drawing.Image)
			Me.btnBrowse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnBrowse.Location = New Global.System.Drawing.Point(461, 176)
			Me.btnBrowse.Name = "btnBrowse"
			Me.btnBrowse.Size = New Global.System.Drawing.Size(153, 33)
			Me.btnBrowse.TabIndex = 13
			Me.btnBrowse.Text = "&Browse..."
			Me.btnBrowse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnBrowse.UseVisualStyleBackColor = False
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.Nologo
			Me.PictureBox1.Location = New Global.System.Drawing.Point(461, 35)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(153, 140)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 17
			Me.PictureBox1.TabStop = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.lblCPhone)
			Me.Panel2.Controls.Add(Me.txtEmail)
			Me.Panel2.Controls.Add(Me.txtID)
			Me.Panel2.Controls.Add(Me.lblSet)
			Me.Panel2.Controls.Add(Me.txtCName)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.txtCompanyID)
			Me.Panel2.Location = New Global.System.Drawing.Point(-7, -2)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(823, 28)
			Me.Panel2.TabIndex = 0
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(337, 25)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCPhone.TabIndex = 1776
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.txtEmail.Location = New Global.System.Drawing.Point(691, 23)
			Me.txtEmail.Name = "txtEmail"
			Me.txtEmail.[ReadOnly] = True
			Me.txtEmail.Size = New Global.System.Drawing.Size(10, 20)
			Me.txtEmail.TabIndex = 8
			Me.txtEmail.TabStop = False
			Me.txtEmail.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(570, 36)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(68, 20)
			Me.txtID.TabIndex = 4
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(644, 4)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(33, 13)
			Me.lblSet.TabIndex = 8
			Me.lblSet.Text = "lblSet"
			Me.lblSet.Visible = False
			Me.txtCName.Location = New Global.System.Drawing.Point(50, 23)
			Me.txtCName.Name = "txtCName"
			Me.txtCName.[ReadOnly] = True
			Me.txtCName.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtCName.TabIndex = 8
			Me.txtCName.TabStop = False
			Me.txtCName.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(644, 45)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.txtCompanyID.Location = New Global.System.Drawing.Point(398, 18)
			Me.txtCompanyID.Name = "txtCompanyID"
			Me.txtCompanyID.[ReadOnly] = True
			Me.txtCompanyID.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtCompanyID.TabIndex = 7
			Me.txtCompanyID.TabStop = False
			Me.txtCompanyID.Visible = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DodgerBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(827, 589)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCompanyupdate"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox4, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005BFE RID: 23550
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
