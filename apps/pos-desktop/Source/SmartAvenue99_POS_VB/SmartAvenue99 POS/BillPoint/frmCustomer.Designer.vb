Namespace BillPoint
	' Token: 0x02000583 RID: 1411
		Public Partial Class frmCustomer
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0601113F RID: 69951 RVA: 0x009E52D4 File Offset: 0x009E34D4
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

		' Token: 0x06011140 RID: 69952 RVA: 0x009E5324 File Offset: 0x009E3524
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomer))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.chksameAddress = New Global.System.Windows.Forms.CheckBox()
			Me.txtpermentAddress = New Global.System.Windows.Forms.TextBox()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.btnExtract = New Global.GelButtons.GelButton()
			Me.chkLoyality = New Global.System.Windows.Forms.CheckBox()
			Me.cboxLoyality = New Global.System.Windows.Forms.ComboBox()
			Me.Label23 = New Global.System.Windows.Forms.Label()
			Me.txtLoyalitypts = New Global.System.Windows.Forms.TextBox()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.lblCode = New Global.System.Windows.Forms.Label()
			Me.cmbDiscStatus = New Global.System.Windows.Forms.ComboBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.txtDiscItem = New Global.System.Windows.Forms.TextBox()
			Me.lbl_Result = New Global.System.Windows.Forms.Label()
			Me.Num1 = New Global.System.Windows.Forms.NumericUpDown()
			Me.Label30 = New Global.System.Windows.Forms.Label()
			Me.cmbRoute = New Global.System.Windows.Forms.ComboBox()
			Me.Label29 = New Global.System.Windows.Forms.Label()
			Me.btnNext = New Global.System.Windows.Forms.Button()
			Me.cmbcrlimit = New Global.System.Windows.Forms.ComboBox()
			Me.btnFirst = New Global.System.Windows.Forms.Button()
			Me.txtPrev = New Global.System.Windows.Forms.Button()
			Me.Label28 = New Global.System.Windows.Forms.Label()
			Me.btnLast = New Global.System.Windows.Forms.Button()
			Me.txtcrlimit = New Global.System.Windows.Forms.TextBox()
			Me.cmbCustomerName = New Global.System.Windows.Forms.ComboBox()
			Me.cmbTCS = New Global.System.Windows.Forms.ComboBox()
			Me.Label27 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtBank = New Global.System.Windows.Forms.TextBox()
			Me.Label22 = New Global.System.Windows.Forms.Label()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.txtIFSCcode = New Global.System.Windows.Forms.TextBox()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.txtBranch = New Global.System.Windows.Forms.TextBox()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.txtAccountNo = New Global.System.Windows.Forms.TextBox()
			Me.txtAccountName = New Global.System.Windows.Forms.TextBox()
			Me.BStartCapture = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.txtCustNameId = New Global.System.Windows.Forms.TextBox()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.cmbOpeningBalanceType = New Global.System.Windows.Forms.ComboBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.txtOpeningBalance = New Global.System.Windows.Forms.TextBox()
			Me.txtPAN = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtGSTIN = New Global.System.Windows.Forms.TextBox()
			Me.txtCIN = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.txtCustName = New Global.System.Windows.Forms.TextBox()
			Me.cmbState = New Global.System.Windows.Forms.ComboBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtZipCode = New Global.System.Windows.Forms.TextBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtCity = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtCustomerID = New Global.System.Windows.Forms.TextBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.txtRemarks = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.Label31 = New Global.System.Windows.Forms.Label()
			Me.cmbNP = New Global.System.Windows.Forms.ComboBox()
			Me.txtNP = New Global.System.Windows.Forms.TextBox()
			Me.txtPhNo = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.ToolTip1 = New Global.System.Windows.Forms.ToolTip(Me.components)
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.Panel4.SuspendLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Num1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(728, 181)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label26"
			label.Size = New Global.System.Drawing.Size(25, 15)
			label.TabIndex = 321
			label.Text = "OR"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton2)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(8, 8)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1020, 565)
			Me.Panel1.TabIndex = 2
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(837, 399)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(157, 43)
			Me.GelButton2.TabIndex = 520
			Me.GelButton2.Text = "New"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.Panel3.Controls.Add(Me.btnGetData)
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(837, 52)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(169, 248)
			Me.Panel3.TabIndex = 1747
			Me.btnGetData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGetData.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnGetData.FlatAppearance.BorderSize = 0
			Me.btnGetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetData.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetData.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGetData.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGetData.Location = New Global.System.Drawing.Point(7, 193)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnGetData.TabIndex = 519
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.btnUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpdate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnUpdate.FlatAppearance.BorderSize = 0
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpdate.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnUpdate.Image = CType(componentResourceManager.GetObject("btnUpdate.Image"), Global.System.Drawing.Image)
			Me.btnUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdate.Location = New Global.System.Drawing.Point(7, 100)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnUpdate.TabIndex = 517
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.btnDelete.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDelete.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDelete.FlatAppearance.BorderSize = 0
			Me.btnDelete.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnDelete.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnDelete.Image = CType(componentResourceManager.GetObject("btnDelete.Image"), Global.System.Drawing.Image)
			Me.btnDelete.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete.Location = New Global.System.Drawing.Point(7, 147)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnDelete.TabIndex = 516
			Me.btnDelete.Text = "Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
			Me.btnNew.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNew.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnNew.FlatAppearance.BorderSize = 0
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNew.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnNew.Image = CType(componentResourceManager.GetObject("btnNew.Image"), Global.System.Drawing.Image)
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(7, 5)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnNew.TabIndex = 515
			Me.btnNew.Text = "New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
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
			Me.btnSave.Location = New Global.System.Drawing.Point(7, 52)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnSave.TabIndex = 514
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 192)
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.Location = New Global.System.Drawing.Point(649, 419)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(108, 23)
			Me.Button2.TabIndex = 1746
			Me.Button2.TabStop = False
			Me.Button2.Text = "Mobile ID"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button2.Visible = False
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(649, 506)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(108, 51)
			Me.Button1.TabIndex = 17
			Me.Button1.TabStop = False
			Me.Button1.Text = "Envelope Print"
			Me.Button1.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageBeforeText
			Me.Button1.UseVisualStyleBackColor = False
			Me.Button1.Visible = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.GelButton1)
			Me.Panel4.Controls.Add(Me.chksameAddress)
			Me.Panel4.Controls.Add(Me.txtpermentAddress)
			Me.Panel4.Controls.Add(Me.ProgressBar1)
			Me.Panel4.Controls.Add(Me.btnExtract)
			Me.Panel4.Controls.Add(Me.chkLoyality)
			Me.Panel4.Controls.Add(Me.cboxLoyality)
			Me.Panel4.Controls.Add(Me.Label23)
			Me.Panel4.Controls.Add(Me.txtLoyalitypts)
			Me.Panel4.Controls.Add(Me.pbgiftqr)
			Me.Panel4.Controls.Add(Me.lblCode)
			Me.Panel4.Controls.Add(Me.cmbDiscStatus)
			Me.Panel4.Controls.Add(Me.Label11)
			Me.Panel4.Controls.Add(Me.txtDiscItem)
			Me.Panel4.Controls.Add(Me.lbl_Result)
			Me.Panel4.Controls.Add(Me.Num1)
			Me.Panel4.Controls.Add(Me.Label30)
			Me.Panel4.Controls.Add(Me.cmbRoute)
			Me.Panel4.Controls.Add(Me.Label29)
			Me.Panel4.Controls.Add(Me.btnNext)
			Me.Panel4.Controls.Add(Me.cmbcrlimit)
			Me.Panel4.Controls.Add(Me.btnFirst)
			Me.Panel4.Controls.Add(Me.txtPrev)
			Me.Panel4.Controls.Add(Me.Label28)
			Me.Panel4.Controls.Add(Me.btnLast)
			Me.Panel4.Controls.Add(Me.txtcrlimit)
			Me.Panel4.Controls.Add(Me.cmbCustomerName)
			Me.Panel4.Controls.Add(Me.cmbTCS)
			Me.Panel4.Controls.Add(Me.Label27)
			Me.Panel4.Controls.Add(Me.GroupBox1)
			Me.Panel4.Controls.Add(Me.BStartCapture)
			Me.Panel4.Controls.Add(label)
			Me.Panel4.Controls.Add(Me.Browse)
			Me.Panel4.Controls.Add(Me.BRemove)
			Me.Panel4.Controls.Add(Me.Picture)
			Me.Panel4.Controls.Add(Me.txtCustNameId)
			Me.Panel4.Controls.Add(Me.LinkLabel1)
			Me.Panel4.Controls.Add(Me.cmbOpeningBalanceType)
			Me.Panel4.Controls.Add(Me.Label15)
			Me.Panel4.Controls.Add(Me.txtOpeningBalance)
			Me.Panel4.Controls.Add(Me.txtPAN)
			Me.Panel4.Controls.Add(Me.Label14)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.txtGSTIN)
			Me.Panel4.Controls.Add(Me.txtCIN)
			Me.Panel4.Controls.Add(Me.Label13)
			Me.Panel4.Controls.Add(Me.txtCustName)
			Me.Panel4.Controls.Add(Me.cmbState)
			Me.Panel4.Controls.Add(Me.Label12)
			Me.Panel4.Controls.Add(Me.Label9)
			Me.Panel4.Controls.Add(Me.txtZipCode)
			Me.Panel4.Controls.Add(Me.txtID)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.txtCity)
			Me.Panel4.Controls.Add(Me.Label10)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.txtCustomerID)
			Me.Panel4.Controls.Add(Me.txtAddress)
			Me.Panel4.Controls.Add(Me.txtRemarks)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.txtEmailID)
			Me.Panel4.Controls.Add(Me.txtContactNo)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(7, 52)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(824, 505)
			Me.Panel4.TabIndex = 0
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 192, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(469, 34)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(106, 25)
			Me.GelButton1.TabIndex = 1852
			Me.GelButton1.Text = "Get (GSheet)"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.chksameAddress.AutoSize = True
			Me.chksameAddress.Location = New Global.System.Drawing.Point(109, 143)
			Me.chksameAddress.Name = "chksameAddress"
			Me.chksameAddress.Size = New Global.System.Drawing.Size(106, 19)
			Me.chksameAddress.TabIndex = 1851
			Me.chksameAddress.Text = "Same Address"
			Me.chksameAddress.UseVisualStyleBackColor = True
			Me.txtpermentAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtpermentAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtpermentAddress.Location = New Global.System.Drawing.Point(109, 167)
			Me.txtpermentAddress.Multiline = True
			Me.txtpermentAddress.Name = "txtpermentAddress"
			Me.txtpermentAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtpermentAddress.Size = New Global.System.Drawing.Size(352, 51)
			Me.txtpermentAddress.TabIndex = 1850
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(297, 10)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(163, 22)
			Me.ProgressBar1.TabIndex = 1849
			Me.ProgressBar1.Visible = False
			Me.btnExtract.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnExtract.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnExtract.FlatAppearance.BorderSize = 0
			Me.btnExtract.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExtract.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExtract.ForeColor = Global.System.Drawing.Color.White
			Me.btnExtract.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnExtract.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnExtract.Image = CType(componentResourceManager.GetObject("btnExtract.Image"), Global.System.Drawing.Image)
			Me.btnExtract.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExtract.Location = New Global.System.Drawing.Point(395, 34)
			Me.btnExtract.Name = "btnExtract"
			Me.btnExtract.Size = New Global.System.Drawing.Size(68, 25)
			Me.btnExtract.TabIndex = 1802
			Me.btnExtract.Text = "Get"
			Me.btnExtract.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExtract.UseVisualStyleBackColor = False
			Me.chkLoyality.AutoSize = True
			Me.chkLoyality.Location = New Global.System.Drawing.Point(297, 333)
			Me.chkLoyality.Name = "chkLoyality"
			Me.chkLoyality.Size = New Global.System.Drawing.Size(153, 19)
			Me.chkLoyality.TabIndex = 1801
			Me.chkLoyality.Text = "Loyality Enable/Disable"
			Me.chkLoyality.UseVisualStyleBackColor = True
			Me.cboxLoyality.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cboxLoyality.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboxLoyality.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cboxLoyality.FormattingEnabled = True
			Me.cboxLoyality.Items.AddRange(New Object() { "CR", "DR" })
			Me.cboxLoyality.Location = New Global.System.Drawing.Point(413, 306)
			Me.cboxLoyality.Name = "cboxLoyality"
			Me.cboxLoyality.Size = New Global.System.Drawing.Size(50, 21)
			Me.cboxLoyality.TabIndex = 1799
			Me.Label23.AutoSize = True
			Me.Label23.Location = New Global.System.Drawing.Point(294, 288)
			Me.Label23.Name = "Label23"
			Me.Label23.Size = New Global.System.Drawing.Size(84, 15)
			Me.Label23.TabIndex = 1800
			Me.Label23.Text = "Loyality Point :"
			Me.txtLoyalitypts.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtLoyalitypts.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtLoyalitypts.Location = New Global.System.Drawing.Point(297, 306)
			Me.txtLoyalitypts.Name = "txtLoyalitypts"
			Me.txtLoyalitypts.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtLoyalitypts.TabIndex = 1798
			Me.txtLoyalitypts.Text = "0.00"
			Me.txtLoyalitypts.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(716, 257)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(100, 90)
			Me.pbgiftqr.TabIndex = 1797
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.lblCode.AutoSize = True
			Me.lblCode.Font = New Global.System.Drawing.Font("Segoe UI", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblCode.ForeColor = Global.System.Drawing.Color.Green
			Me.lblCode.Location = New Global.System.Drawing.Point(478, 256)
			Me.lblCode.Name = "lblCode"
			Me.lblCode.Size = New Global.System.Drawing.Size(16, 13)
			Me.lblCode.TabIndex = 1745
			Me.lblCode.Text = "..."
			Me.cmbDiscStatus.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbDiscStatus.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbDiscStatus.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbDiscStatus.FormattingEnabled = True
			Me.cmbDiscStatus.Items.AddRange(New Object() { "No", "Yes" })
			Me.cmbDiscStatus.Location = New Global.System.Drawing.Point(241, 477)
			Me.cmbDiscStatus.Name = "cmbDiscStatus"
			Me.cmbDiscStatus.Size = New Global.System.Drawing.Size(50, 21)
			Me.cmbDiscStatus.TabIndex = 21
			Me.cmbDiscStatus.Visible = False
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(10, 478)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(98, 15)
			Me.Label11.TabIndex = 1744
			Me.Label11.Text = "Disc% on Items :"
			Me.Label11.Visible = False
			Me.txtDiscItem.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDiscItem.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDiscItem.Location = New Global.System.Drawing.Point(125, 477)
			Me.txtDiscItem.Name = "txtDiscItem"
			Me.txtDiscItem.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtDiscItem.TabIndex = 20
			Me.txtDiscItem.Text = "0"
			Me.txtDiscItem.Visible = False
			Me.lbl_Result.AutoSize = True
			Me.lbl_Result.Location = New Global.System.Drawing.Point(294, 234)
			Me.lbl_Result.Name = "lbl_Result"
			Me.lbl_Result.Size = New Global.System.Drawing.Size(0, 15)
			Me.lbl_Result.TabIndex = 1741
			Me.Num1.Location = New Global.System.Drawing.Point(125, 452)
			Me.Num1.Name = "Num1"
			Me.Num1.Size = New Global.System.Drawing.Size(112, 21)
			Me.Num1.TabIndex = 19
			Me.Label30.AutoSize = True
			Me.Label30.Location = New Global.System.Drawing.Point(10, 452)
			Me.Label30.Name = "Label30"
			Me.Label30.Size = New Global.System.Drawing.Size(110, 15)
			Me.Label30.TabIndex = 1740
			Me.Label30.Text = "Turn Around Days :"
			Me.cmbRoute.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbRoute.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbRoute.FormattingEnabled = True
			Me.cmbRoute.Location = New Global.System.Drawing.Point(125, 425)
			Me.cmbRoute.Name = "cmbRoute"
			Me.cmbRoute.Size = New Global.System.Drawing.Size(166, 23)
			Me.cmbRoute.TabIndex = 18
			Me.Label29.AutoSize = True
			Me.Label29.Location = New Global.System.Drawing.Point(10, 427)
			Me.Label29.Name = "Label29"
			Me.Label29.Size = New Global.System.Drawing.Size(46, 15)
			Me.Label29.TabIndex = 1739
			Me.Label29.Text = "Route :"
			Me.btnNext.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNext.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNext.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Image = CType(componentResourceManager.GetObject("btnNext.Image"), Global.System.Drawing.Image)
			Me.btnNext.Location = New Global.System.Drawing.Point(368, 11)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnNext.TabIndex = 1734
			Me.btnNext.TabStop = False
			Me.btnNext.UseVisualStyleBackColor = False
			Me.btnNext.Visible = False
			Me.cmbcrlimit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbcrlimit.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbcrlimit.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbcrlimit.FormattingEnabled = True
			Me.cmbcrlimit.Items.AddRange(New Object() { "No", "Yes" })
			Me.cmbcrlimit.Location = New Global.System.Drawing.Point(241, 400)
			Me.cmbcrlimit.Name = "cmbcrlimit"
			Me.cmbcrlimit.Size = New Global.System.Drawing.Size(50, 21)
			Me.cmbcrlimit.TabIndex = 17
			Me.btnFirst.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnFirst.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnFirst.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Image = CType(componentResourceManager.GetObject("btnFirst.Image"), Global.System.Drawing.Image)
			Me.btnFirst.Location = New Global.System.Drawing.Point(428, 11)
			Me.btnFirst.Name = "btnFirst"
			Me.btnFirst.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnFirst.TabIndex = 1737
			Me.btnFirst.TabStop = False
			Me.btnFirst.UseVisualStyleBackColor = False
			Me.btnFirst.Visible = False
			Me.txtPrev.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.txtPrev.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.txtPrev.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Image = CType(componentResourceManager.GetObject("txtPrev.Image"), Global.System.Drawing.Image)
			Me.txtPrev.Location = New Global.System.Drawing.Point(398, 11)
			Me.txtPrev.Name = "txtPrev"
			Me.txtPrev.Size = New Global.System.Drawing.Size(26, 21)
			Me.txtPrev.TabIndex = 1735
			Me.txtPrev.TabStop = False
			Me.txtPrev.UseVisualStyleBackColor = False
			Me.txtPrev.Visible = False
			Me.Label28.AutoSize = True
			Me.Label28.Location = New Global.System.Drawing.Point(10, 400)
			Me.Label28.Name = "Label28"
			Me.Label28.Size = New Global.System.Drawing.Size(110, 15)
			Me.Label28.TabIndex = 324
			Me.Label28.Text = "Credit Limit (Max) :"
			Me.btnLast.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLast.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnLast.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Image = CType(componentResourceManager.GetObject("btnLast.Image"), Global.System.Drawing.Image)
			Me.btnLast.Location = New Global.System.Drawing.Point(338, 11)
			Me.btnLast.Name = "btnLast"
			Me.btnLast.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnLast.TabIndex = 1736
			Me.btnLast.TabStop = False
			Me.btnLast.UseVisualStyleBackColor = False
			Me.btnLast.Visible = False
			Me.txtcrlimit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtcrlimit.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtcrlimit.Location = New Global.System.Drawing.Point(125, 400)
			Me.txtcrlimit.Name = "txtcrlimit"
			Me.txtcrlimit.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtcrlimit.TabIndex = 16
			Me.txtcrlimit.Text = "0.00"
			Me.txtcrlimit.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.cmbCustomerName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbCustomerName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCustomerName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCustomerName.FormattingEnabled = True
			Me.cmbCustomerName.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbCustomerName.Location = New Global.System.Drawing.Point(109, 36)
			Me.cmbCustomerName.Name = "cmbCustomerName"
			Me.cmbCustomerName.Size = New Global.System.Drawing.Size(277, 23)
			Me.cmbCustomerName.TabIndex = 1
			Me.cmbTCS.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbTCS.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbTCS.FormattingEnabled = True
			Me.cmbTCS.Items.AddRange(New Object() { "Yes", "No" })
			Me.cmbTCS.Location = New Global.System.Drawing.Point(125, 373)
			Me.cmbTCS.Name = "cmbTCS"
			Me.cmbTCS.Size = New Global.System.Drawing.Size(112, 23)
			Me.cmbTCS.TabIndex = 15
			Me.Label27.AutoSize = True
			Me.Label27.Location = New Global.System.Drawing.Point(10, 374)
			Me.Label27.Name = "Label27"
			Me.Label27.Size = New Global.System.Drawing.Size(80, 15)
			Me.Label27.TabIndex = 322
			Me.Label27.Text = "TCS Applied :"
			Me.GroupBox1.Controls.Add(Me.txtBank)
			Me.GroupBox1.Controls.Add(Me.Label22)
			Me.GroupBox1.Controls.Add(Me.Label17)
			Me.GroupBox1.Controls.Add(Me.txtIFSCcode)
			Me.GroupBox1.Controls.Add(Me.Label18)
			Me.GroupBox1.Controls.Add(Me.txtBranch)
			Me.GroupBox1.Controls.Add(Me.Label20)
			Me.GroupBox1.Controls.Add(Me.Label21)
			Me.GroupBox1.Controls.Add(Me.txtAccountNo)
			Me.GroupBox1.Controls.Add(Me.txtAccountName)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(323, 366)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(307, 134)
			Me.GroupBox1.TabIndex = 21
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Bank Details"
			Me.txtBank.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBank.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBank.Location = New Global.System.Drawing.Point(120, 63)
			Me.txtBank.Name = "txtBank"
			Me.txtBank.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtBank.TabIndex = 2
			Me.Label22.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label22.AutoSize = True
			Me.Label22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label22.ForeColor = Global.System.Drawing.Color.Black
			Me.Label22.Location = New Global.System.Drawing.Point(23, 109)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(63, 13)
			Me.Label22.TabIndex = 338
			Me.Label22.Text = "IFSC code :"
			Me.Label17.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label17.AutoSize = True
			Me.Label17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.ForeColor = Global.System.Drawing.Color.Black
			Me.Label17.Location = New Global.System.Drawing.Point(23, 40)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label17.TabIndex = 326
			Me.Label17.Text = "Account No. :"
			Me.txtIFSCcode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtIFSCcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIFSCcode.Location = New Global.System.Drawing.Point(120, 109)
			Me.txtIFSCcode.Name = "txtIFSCcode"
			Me.txtIFSCcode.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtIFSCcode.TabIndex = 4
			Me.Label18.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label18.AutoSize = True
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.ForeColor = Global.System.Drawing.Color.Black
			Me.Label18.Location = New Global.System.Drawing.Point(23, 18)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label18.TabIndex = 327
			Me.Label18.Text = "Account Name :"
			Me.txtBranch.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBranch.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranch.Location = New Global.System.Drawing.Point(120, 86)
			Me.txtBranch.Name = "txtBranch"
			Me.txtBranch.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtBranch.TabIndex = 3
			Me.Label20.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label20.AutoSize = True
			Me.Label20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label20.ForeColor = Global.System.Drawing.Color.Black
			Me.Label20.Location = New Global.System.Drawing.Point(24, 63)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label20.TabIndex = 328
			Me.Label20.Text = "Bank :"
			Me.Label21.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label21.AutoSize = True
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label21.ForeColor = Global.System.Drawing.Color.Black
			Me.Label21.Location = New Global.System.Drawing.Point(24, 86)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label21.TabIndex = 329
			Me.Label21.Text = "Branch :"
			Me.txtAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAccountNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAccountNo.Location = New Global.System.Drawing.Point(120, 40)
			Me.txtAccountNo.Name = "txtAccountNo"
			Me.txtAccountNo.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtAccountNo.TabIndex = 1
			Me.txtAccountName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAccountName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAccountName.Location = New Global.System.Drawing.Point(120, 18)
			Me.txtAccountName.Name = "txtAccountName"
			Me.txtAccountName.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtAccountName.TabIndex = 0
			Me.BStartCapture.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BStartCapture.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BStartCapture.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BStartCapture.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BStartCapture.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BStartCapture.ForeColor = Global.System.Drawing.Color.White
			Me.BStartCapture.Location = New Global.System.Drawing.Point(664, 198)
			Me.BStartCapture.Name = "BStartCapture"
			Me.BStartCapture.Size = New Global.System.Drawing.Size(155, 24)
			Me.BStartCapture.TabIndex = 320
			Me.BStartCapture.Text = "Use Webcam"
			Me.BStartCapture.UseVisualStyleBackColor = False
			Me.Browse.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.White
			Me.Browse.Location = New Global.System.Drawing.Point(680, 158)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(69, 24)
			Me.Browse.TabIndex = 318
			Me.Browse.Text = "Browse..."
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(750, 158)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(69, 24)
			Me.BRemove.TabIndex = 319
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(664, 4)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(155, 152)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 317
			Me.Picture.TabStop = False
			Me.txtCustNameId.Location = New Global.System.Drawing.Point(609, 62)
			Me.txtCustNameId.Name = "txtCustNameId"
			Me.txtCustNameId.[ReadOnly] = True
			Me.txtCustNameId.Size = New Global.System.Drawing.Size(15, 21)
			Me.txtCustNameId.TabIndex = 311
			Me.txtCustNameId.TabStop = False
			Me.txtCustNameId.Visible = False
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(718, 232)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(101, 15)
			Me.LinkLabel1.TabIndex = 8
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "GSTIN VALIDATE"
			Me.cmbOpeningBalanceType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbOpeningBalanceType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbOpeningBalanceType.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbOpeningBalanceType.FormattingEnabled = True
			Me.cmbOpeningBalanceType.Items.AddRange(New Object() { "CR", "DR" })
			Me.cmbOpeningBalanceType.Location = New Global.System.Drawing.Point(241, 306)
			Me.cmbOpeningBalanceType.Name = "cmbOpeningBalanceType"
			Me.cmbOpeningBalanceType.Size = New Global.System.Drawing.Size(50, 21)
			Me.cmbOpeningBalanceType.TabIndex = 13
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(10, 306)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(108, 15)
			Me.Label15.TabIndex = 309
			Me.Label15.Text = "Opening Balance :"
			Me.txtOpeningBalance.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtOpeningBalance.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtOpeningBalance.Location = New Global.System.Drawing.Point(125, 306)
			Me.txtOpeningBalance.Name = "txtOpeningBalance"
			Me.txtOpeningBalance.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtOpeningBalance.TabIndex = 12
			Me.txtOpeningBalance.Text = "0.00"
			Me.txtOpeningBalance.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtPAN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPAN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPAN.Location = New Global.System.Drawing.Point(125, 281)
			Me.txtPAN.Name = "txtPAN"
			Me.txtPAN.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtPAN.TabIndex = 11
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(10, 281)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(37, 15)
			Me.Label14.TabIndex = 304
			Me.Label14.Text = "PAN :"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(10, 252)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(73, 15)
			Me.Label8.TabIndex = 302
			Me.Label8.Text = "GSTIN/UID :"
			Me.txtGSTIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtGSTIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGSTIN.Location = New Global.System.Drawing.Point(109, 252)
			Me.txtGSTIN.Name = "txtGSTIN"
			Me.txtGSTIN.Size = New Global.System.Drawing.Size(123, 21)
			Me.txtGSTIN.TabIndex = 8
			Me.txtCIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCIN.Location = New Global.System.Drawing.Point(288, 252)
			Me.txtCIN.Name = "txtCIN"
			Me.txtCIN.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtCIN.TabIndex = 10
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(243, 255)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(33, 15)
			Me.Label13.TabIndex = 300
			Me.Label13.Text = "CIN :"
			Me.txtCustName.Location = New Global.System.Drawing.Point(609, 33)
			Me.txtCustName.Name = "txtCustName"
			Me.txtCustName.[ReadOnly] = True
			Me.txtCustName.Size = New Global.System.Drawing.Size(15, 21)
			Me.txtCustName.TabIndex = 296
			Me.txtCustName.Visible = False
			Me.cmbState.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbState.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbState.FormattingEnabled = True
			Me.cmbState.Items.AddRange(New Object() { "Andaman and Nicobar Islands", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra and Nagar Haveli and Daman and Diu", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Ladakh", "Lakshadweep", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Puducherry", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal", "SriLanka" })
			Me.cmbState.Location = New Global.System.Drawing.Point(338, 92)
			Me.cmbState.Name = "cmbState"
			Me.cmbState.Size = New Global.System.Drawing.Size(122, 23)
			Me.cmbState.TabIndex = 4
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(295, 123)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(63, 15)
			Me.Label12.TabIndex = 295
			Me.Label12.Text = "Pin Code :"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(294, 89)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(41, 15)
			Me.Label9.TabIndex = 294
			Me.Label9.Text = "State :"
			Me.txtZipCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtZipCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtZipCode.Location = New Global.System.Drawing.Point(364, 120)
			Me.txtZipCode.Name = "txtZipCode"
			Me.txtZipCode.Size = New Global.System.Drawing.Size(96, 21)
			Me.txtZipCode.TabIndex = 5
			Me.txtID.Location = New Global.System.Drawing.Point(609, 8)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(15, 21)
			Me.txtID.TabIndex = 4
			Me.txtID.Visible = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(295, 64)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(32, 15)
			Me.Label4.TabIndex = 24
			Me.Label4.Text = "City :"
			Me.txtCity.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCity.Location = New Global.System.Drawing.Point(338, 65)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.Size = New Global.System.Drawing.Size(123, 21)
			Me.txtCity.TabIndex = 3
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(10, 331)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(63, 15)
			Me.Label10.TabIndex = 21
			Me.Label10.Text = "Remarks :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(10, 36)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(103, 15)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Customer Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 11)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(81, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Customer ID :"
			Me.txtCustomerID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCustomerID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerID.Location = New Global.System.Drawing.Point(125, 11)
			Me.txtCustomerID.Name = "txtCustomerID"
			Me.txtCustomerID.[ReadOnly] = True
			Me.txtCustomerID.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtCustomerID.TabIndex = 0
			Me.txtCustomerID.TabStop = False
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(109, 63)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(175, 79)
			Me.txtAddress.TabIndex = 2
			Me.txtRemarks.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemarks.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRemarks.Location = New Global.System.Drawing.Point(125, 331)
			Me.txtRemarks.Multiline = True
			Me.txtRemarks.Name = "txtRemarks"
			Me.txtRemarks.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtRemarks.Size = New Global.System.Drawing.Size(166, 38)
			Me.txtRemarks.TabIndex = 14
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(10, 63)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(57, 15)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Address :"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(10, 227)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(73, 15)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Contact No :"
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.Location = New Global.System.Drawing.Point(338, 227)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(116, 21)
			Me.txtEmailID.TabIndex = 7
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(109, 225)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(160, 21)
			Me.txtContactNo.TabIndex = 6
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(275, 230)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(60, 15)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "Email ID :"
			Me.Panel2.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label19)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.Label16)
			Me.Panel2.Controls.Add(Me.lblCPhone)
			Me.Panel2.Controls.Add(Me.Label31)
			Me.Panel2.Controls.Add(Me.cmbNP)
			Me.Panel2.Controls.Add(Me.txtNP)
			Me.Panel2.Controls.Add(Me.txtPhNo)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(840, 39)
			Me.Panel2.TabIndex = 0
			Me.Label19.AutoSize = True
			Me.Label19.Location = New Global.System.Drawing.Point(187, 15)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(15, 13)
			Me.Label19.TabIndex = 1778
			Me.Label19.Text = "N"
			Me.Label19.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Label19.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(287, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(153, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Customer Entry"
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(12, 11)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(45, 13)
			Me.Label16.TabIndex = 1776
			Me.Label16.Text = "Label16"
			Me.Label16.Visible = False
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(348, 13)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCPhone.TabIndex = 1775
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.Label31.AutoSize = True
			Me.Label31.Location = New Global.System.Drawing.Point(655, 15)
			Me.Label31.Name = "Label31"
			Me.Label31.Size = New Global.System.Drawing.Size(45, 13)
			Me.Label31.TabIndex = 1727
			Me.Label31.Text = "Label31"
			Me.Label31.Visible = False
			Me.cmbNP.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbNP.FormattingEnabled = True
			Me.cmbNP.Location = New Global.System.Drawing.Point(546, 7)
			Me.cmbNP.Name = "cmbNP"
			Me.cmbNP.Size = New Global.System.Drawing.Size(49, 21)
			Me.cmbNP.TabIndex = 1726
			Me.cmbNP.TabStop = False
			Me.cmbNP.Visible = False
			Me.txtNP.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNP.Location = New Global.System.Drawing.Point(601, 8)
			Me.txtNP.Name = "txtNP"
			Me.txtNP.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.txtNP.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtNP.TabIndex = 1724
			Me.txtNP.TabStop = False
			Me.txtNP.Visible = False
			Me.txtPhNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtPhNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPhNo.Location = New Global.System.Drawing.Point(87, 11)
			Me.txtPhNo.Name = "txtPhNo"
			Me.txtPhNo.[ReadOnly] = True
			Me.txtPhNo.Size = New Global.System.Drawing.Size(27, 21)
			Me.txtPhNo.TabIndex = 11
			Me.txtPhNo.TabStop = False
			Me.txtPhNo.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(487, 17)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DodgerBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(1040, 582)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCustomer"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel3.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Num1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400668A RID: 26250
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
