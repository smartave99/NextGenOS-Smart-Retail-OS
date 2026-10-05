Namespace BillPoint
	' Token: 0x020005E3 RID: 1507
		Public Partial Class frmSupplier
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060128B9 RID: 75961 RVA: 0x00AAC330 File Offset: 0x00AAA530
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

		' Token: 0x060128BA RID: 75962 RVA: 0x00AAC380 File Offset: 0x00AAA580
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSupplier))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.Label31 = New Global.System.Windows.Forms.Label()
			Me.cmbNP = New Global.System.Windows.Forms.ComboBox()
			Me.txtNP = New Global.System.Windows.Forms.TextBox()
			Me.txtPhNo = New Global.System.Windows.Forms.TextBox()
			Me.txtTransactionNo = New Global.System.Windows.Forms.TextBox()
			Me.txtT_ID = New Global.System.Windows.Forms.TextBox()
			Me.txtSTNo = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.lblCode = New Global.System.Windows.Forms.Label()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.lbl_Result = New Global.System.Windows.Forms.Label()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.txtSCode = New Global.System.Windows.Forms.TextBox()
			Me.Label29 = New Global.System.Windows.Forms.Label()
			Me.cmbcrlimit = New Global.System.Windows.Forms.ComboBox()
			Me.Label28 = New Global.System.Windows.Forms.Label()
			Me.txtcrlimit = New Global.System.Windows.Forms.TextBox()
			Me.cmbSupplierName = New Global.System.Windows.Forms.ComboBox()
			Me.BStartCapture = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.txtSuplNameId = New Global.System.Windows.Forms.TextBox()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.cmbOpeningBalanceType = New Global.System.Windows.Forms.ComboBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.txtOpeningBalance = New Global.System.Windows.Forms.TextBox()
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
			Me.txtPAN = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtGSTIN = New Global.System.Windows.Forms.TextBox()
			Me.txtCIN = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.txtSupName = New Global.System.Windows.Forms.TextBox()
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
			Me.txtSupplierID = New Global.System.Windows.Forms.TextBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.txtRemarks = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.ToolTip1 = New Global.System.Windows.Forms.ToolTip(Me.components)
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Button1 = New Global.GelButtons.GelButton()
			Me.btnExtract = New Global.GelButtons.GelButton()
			Me.btnNext = New Global.System.Windows.Forms.Button()
			Me.btnFirst = New Global.System.Windows.Forms.Button()
			Me.txtPrev = New Global.System.Windows.Forms.Button()
			Me.btnLast = New Global.System.Windows.Forms.Button()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(540, 180)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label26"
			label.Size = New Global.System.Drawing.Size(25, 15)
			label.TabIndex = 331
			label.Text = "OR"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Location = New Global.System.Drawing.Point(4, 5)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(825, 538)
			Me.Panel1.TabIndex = 2
			Me.Panel3.Controls.Add(Me.btnGetData)
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(650, 49)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(169, 248)
			Me.Panel3.TabIndex = 19
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.lblCPhone)
			Me.Panel2.Controls.Add(Me.Label31)
			Me.Panel2.Controls.Add(Me.cmbNP)
			Me.Panel2.Controls.Add(Me.txtNP)
			Me.Panel2.Controls.Add(Me.txtPhNo)
			Me.Panel2.Controls.Add(Me.txtTransactionNo)
			Me.Panel2.Controls.Add(Me.txtT_ID)
			Me.Panel2.Controls.Add(Me.txtSTNo)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(825, 39)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(294, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(142, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Supplier Entry"
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(348, 13)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCPhone.TabIndex = 1776
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.Label31.AutoSize = True
			Me.Label31.Location = New Global.System.Drawing.Point(193, 13)
			Me.Label31.Name = "Label31"
			Me.Label31.Size = New Global.System.Drawing.Size(45, 13)
			Me.Label31.TabIndex = 1728
			Me.Label31.Text = "Label31"
			Me.Label31.Visible = False
			Me.cmbNP.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbNP.FormattingEnabled = True
			Me.cmbNP.Location = New Global.System.Drawing.Point(546, 6)
			Me.cmbNP.Name = "cmbNP"
			Me.cmbNP.Size = New Global.System.Drawing.Size(49, 21)
			Me.cmbNP.TabIndex = 1727
			Me.cmbNP.TabStop = False
			Me.cmbNP.Visible = False
			Me.txtNP.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNP.Location = New Global.System.Drawing.Point(601, 7)
			Me.txtNP.Name = "txtNP"
			Me.txtNP.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.txtNP.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtNP.TabIndex = 1725
			Me.txtNP.TabStop = False
			Me.txtNP.Visible = False
			Me.txtPhNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtPhNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPhNo.Location = New Global.System.Drawing.Point(183, 11)
			Me.txtPhNo.Name = "txtPhNo"
			Me.txtPhNo.[ReadOnly] = True
			Me.txtPhNo.Size = New Global.System.Drawing.Size(27, 21)
			Me.txtPhNo.TabIndex = 10
			Me.txtPhNo.TabStop = False
			Me.txtPhNo.Visible = False
			Me.txtTransactionNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtTransactionNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTransactionNo.Location = New Global.System.Drawing.Point(44, 5)
			Me.txtTransactionNo.Name = "txtTransactionNo"
			Me.txtTransactionNo.[ReadOnly] = True
			Me.txtTransactionNo.Size = New Global.System.Drawing.Size(27, 21)
			Me.txtTransactionNo.TabIndex = 3
			Me.txtTransactionNo.TabStop = False
			Me.txtTransactionNo.Visible = False
			Me.txtT_ID.Location = New Global.System.Drawing.Point(3, 6)
			Me.txtT_ID.Name = "txtT_ID"
			Me.txtT_ID.[ReadOnly] = True
			Me.txtT_ID.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtT_ID.TabIndex = 2
			Me.txtT_ID.TabStop = False
			Me.txtT_ID.Visible = False
			Me.txtSTNo.BackColor = Global.System.Drawing.Color.White
			Me.txtSTNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSTNo.Location = New Global.System.Drawing.Point(122, 10)
			Me.txtSTNo.Name = "txtSTNo"
			Me.txtSTNo.[ReadOnly] = True
			Me.txtSTNo.Size = New Global.System.Drawing.Size(39, 21)
			Me.txtSTNo.TabIndex = 9
			Me.txtSTNo.TabStop = False
			Me.txtSTNo.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(77, 12)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.ProgressBar1)
			Me.Panel4.Controls.Add(Me.btnExtract)
			Me.Panel4.Controls.Add(Me.lblCode)
			Me.Panel4.Controls.Add(Me.Button2)
			Me.Panel4.Controls.Add(Me.lbl_Result)
			Me.Panel4.Controls.Add(Me.CheckBox1)
			Me.Panel4.Controls.Add(Me.txtSCode)
			Me.Panel4.Controls.Add(Me.Label29)
			Me.Panel4.Controls.Add(Me.btnNext)
			Me.Panel4.Controls.Add(Me.cmbcrlimit)
			Me.Panel4.Controls.Add(Me.btnFirst)
			Me.Panel4.Controls.Add(Me.txtPrev)
			Me.Panel4.Controls.Add(Me.Label28)
			Me.Panel4.Controls.Add(Me.btnLast)
			Me.Panel4.Controls.Add(Me.txtcrlimit)
			Me.Panel4.Controls.Add(Me.cmbSupplierName)
			Me.Panel4.Controls.Add(Me.BStartCapture)
			Me.Panel4.Controls.Add(label)
			Me.Panel4.Controls.Add(Me.Browse)
			Me.Panel4.Controls.Add(Me.BRemove)
			Me.Panel4.Controls.Add(Me.Picture)
			Me.Panel4.Controls.Add(Me.txtSuplNameId)
			Me.Panel4.Controls.Add(Me.LinkLabel1)
			Me.Panel4.Controls.Add(Me.cmbOpeningBalanceType)
			Me.Panel4.Controls.Add(Me.Label15)
			Me.Panel4.Controls.Add(Me.txtOpeningBalance)
			Me.Panel4.Controls.Add(Me.GroupBox1)
			Me.Panel4.Controls.Add(Me.txtPAN)
			Me.Panel4.Controls.Add(Me.Label14)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.txtGSTIN)
			Me.Panel4.Controls.Add(Me.txtCIN)
			Me.Panel4.Controls.Add(Me.Label13)
			Me.Panel4.Controls.Add(Me.txtSupName)
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
			Me.Panel4.Controls.Add(Me.txtSupplierID)
			Me.Panel4.Controls.Add(Me.txtAddress)
			Me.Panel4.Controls.Add(Me.txtRemarks)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.txtEmailID)
			Me.Panel4.Controls.Add(Me.txtContactNo)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(9, 49)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(636, 479)
			Me.Panel4.TabIndex = 0
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(318, 38)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(152, 20)
			Me.ProgressBar1.TabIndex = 1848
			Me.ProgressBar1.Visible = False
			Me.lblCode.AutoSize = True
			Me.lblCode.Font = New Global.System.Drawing.Font("Segoe UI", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblCode.ForeColor = Global.System.Drawing.Color.Green
			Me.lblCode.Location = New Global.System.Drawing.Point(409, 182)
			Me.lblCode.Name = "lblCode"
			Me.lblCode.Size = New Global.System.Drawing.Size(16, 13)
			Me.lblCode.TabIndex = 1748
			Me.lblCode.Text = "..."
			Me.Button2.BackColor = Global.System.Drawing.Color.PaleGreen
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.Font = New Global.System.Drawing.Font("Arial Narrow", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.Location = New Global.System.Drawing.Point(235, 34)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(56, 26)
			Me.Button2.TabIndex = 1747
			Me.Button2.TabStop = False
			Me.Button2.Text = "Generate"
			Me.Button2.UseVisualStyleBackColor = False
			Me.lbl_Result.AutoSize = True
			Me.lbl_Result.Location = New Global.System.Drawing.Point(295, 289)
			Me.lbl_Result.Name = "lbl_Result"
			Me.lbl_Result.Size = New Global.System.Drawing.Size(0, 15)
			Me.lbl_Result.TabIndex = 1746
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Checked = True
			Me.CheckBox1.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Location = New Global.System.Drawing.Point(297, 40)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(15, 14)
			Me.CheckBox1.TabIndex = 1744
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.CheckBox1.Visible = False
			Me.txtSCode.BackColor = Global.System.Drawing.Color.Coral
			Me.txtSCode.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.txtSCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSCode.Location = New Global.System.Drawing.Point(125, 36)
			Me.txtSCode.Name = "txtSCode"
			Me.txtSCode.Size = New Global.System.Drawing.Size(84, 21)
			Me.txtSCode.TabIndex = 0
			Me.txtSCode.TabStop = False
			Me.Label29.AutoSize = True
			Me.Label29.Location = New Global.System.Drawing.Point(10, 36)
			Me.Label29.Name = "Label29"
			Me.Label29.Size = New Global.System.Drawing.Size(91, 15)
			Me.Label29.TabIndex = 1743
			Me.Label29.Text = "Supplier Code :"
			Me.cmbcrlimit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbcrlimit.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbcrlimit.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbcrlimit.FormattingEnabled = True
			Me.cmbcrlimit.Items.AddRange(New Object() { "No", "Yes" })
			Me.cmbcrlimit.Location = New Global.System.Drawing.Point(241, 450)
			Me.cmbcrlimit.Name = "cmbcrlimit"
			Me.cmbcrlimit.Size = New Global.System.Drawing.Size(50, 21)
			Me.cmbcrlimit.TabIndex = 16
			Me.Label28.AutoSize = True
			Me.Label28.Location = New Global.System.Drawing.Point(10, 450)
			Me.Label28.Name = "Label28"
			Me.Label28.Size = New Global.System.Drawing.Size(110, 15)
			Me.Label28.TabIndex = 334
			Me.Label28.Text = "Credit Limit (Max) :"
			Me.txtcrlimit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtcrlimit.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtcrlimit.Location = New Global.System.Drawing.Point(125, 450)
			Me.txtcrlimit.Name = "txtcrlimit"
			Me.txtcrlimit.Size = New Global.System.Drawing.Size(95, 21)
			Me.txtcrlimit.TabIndex = 15
			Me.txtcrlimit.Text = "0.00"
			Me.txtcrlimit.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.cmbSupplierName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbSupplierName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbSupplierName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSupplierName.FormattingEnabled = True
			Me.cmbSupplierName.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbSupplierName.Location = New Global.System.Drawing.Point(125, 63)
			Me.cmbSupplierName.Name = "cmbSupplierName"
			Me.cmbSupplierName.Size = New Global.System.Drawing.Size(271, 23)
			Me.cmbSupplierName.TabIndex = 1
			Me.BStartCapture.BackColor = Global.System.Drawing.SystemColors.HotTrack
			Me.BStartCapture.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BStartCapture.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BStartCapture.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BStartCapture.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BStartCapture.ForeColor = Global.System.Drawing.Color.White
			Me.BStartCapture.Location = New Global.System.Drawing.Point(476, 197)
			Me.BStartCapture.Name = "BStartCapture"
			Me.BStartCapture.Size = New Global.System.Drawing.Size(155, 24)
			Me.BStartCapture.TabIndex = 330
			Me.BStartCapture.Text = "Use Webcam"
			Me.BStartCapture.UseVisualStyleBackColor = False
			Me.Browse.BackColor = Global.System.Drawing.SystemColors.HotTrack
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.White
			Me.Browse.Location = New Global.System.Drawing.Point(476, 157)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(69, 24)
			Me.Browse.TabIndex = 328
			Me.Browse.Text = "Browse..."
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.SystemColors.HotTrack
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(562, 157)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(69, 24)
			Me.BRemove.TabIndex = 329
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.txtSuplNameId.Location = New Global.System.Drawing.Point(589, 66)
			Me.txtSuplNameId.Name = "txtSuplNameId"
			Me.txtSuplNameId.[ReadOnly] = True
			Me.txtSuplNameId.Size = New Global.System.Drawing.Size(20, 21)
			Me.txtSuplNameId.TabIndex = 308
			Me.txtSuplNameId.TabStop = False
			Me.txtSuplNameId.Visible = False
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(530, 286)
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
			Me.cmbOpeningBalanceType.Location = New Global.System.Drawing.Point(241, 367)
			Me.cmbOpeningBalanceType.Name = "cmbOpeningBalanceType"
			Me.cmbOpeningBalanceType.Size = New Global.System.Drawing.Size(50, 21)
			Me.cmbOpeningBalanceType.TabIndex = 13
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(10, 367)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(108, 15)
			Me.Label15.TabIndex = 306
			Me.Label15.Text = "Opening Balance :"
			Me.txtOpeningBalance.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtOpeningBalance.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtOpeningBalance.Location = New Global.System.Drawing.Point(125, 367)
			Me.txtOpeningBalance.Name = "txtOpeningBalance"
			Me.txtOpeningBalance.Size = New Global.System.Drawing.Size(95, 21)
			Me.txtOpeningBalance.TabIndex = 12
			Me.txtOpeningBalance.Text = "0.00"
			Me.txtOpeningBalance.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
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
			Me.GroupBox1.Location = New Global.System.Drawing.Point(358, 318)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(269, 153)
			Me.GroupBox1.TabIndex = 17
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Bank Details"
			Me.txtBank.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBank.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBank.Location = New Global.System.Drawing.Point(92, 74)
			Me.txtBank.Name = "txtBank"
			Me.txtBank.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtBank.TabIndex = 2
			Me.Label22.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label22.AutoSize = True
			Me.Label22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label22.ForeColor = Global.System.Drawing.Color.Black
			Me.Label22.Location = New Global.System.Drawing.Point(7, 126)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(63, 13)
			Me.Label22.TabIndex = 338
			Me.Label22.Text = "IFSC code :"
			Me.Label17.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label17.AutoSize = True
			Me.Label17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.ForeColor = Global.System.Drawing.Color.Black
			Me.Label17.Location = New Global.System.Drawing.Point(7, 48)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label17.TabIndex = 326
			Me.Label17.Text = "Account No. :"
			Me.txtIFSCcode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtIFSCcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIFSCcode.Location = New Global.System.Drawing.Point(92, 126)
			Me.txtIFSCcode.Name = "txtIFSCcode"
			Me.txtIFSCcode.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtIFSCcode.TabIndex = 4
			Me.Label18.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label18.AutoSize = True
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.ForeColor = Global.System.Drawing.Color.Black
			Me.Label18.Location = New Global.System.Drawing.Point(7, 21)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label18.TabIndex = 327
			Me.Label18.Text = "Account Name :"
			Me.txtBranch.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBranch.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranch.Location = New Global.System.Drawing.Point(92, 100)
			Me.txtBranch.Name = "txtBranch"
			Me.txtBranch.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtBranch.TabIndex = 3
			Me.Label20.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label20.AutoSize = True
			Me.Label20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label20.ForeColor = Global.System.Drawing.Color.Black
			Me.Label20.Location = New Global.System.Drawing.Point(8, 74)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label20.TabIndex = 328
			Me.Label20.Text = "Bank :"
			Me.Label21.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label21.AutoSize = True
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label21.ForeColor = Global.System.Drawing.Color.Black
			Me.Label21.Location = New Global.System.Drawing.Point(8, 100)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label21.TabIndex = 329
			Me.Label21.Text = "Branch :"
			Me.txtAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAccountNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAccountNo.Location = New Global.System.Drawing.Point(92, 48)
			Me.txtAccountNo.Name = "txtAccountNo"
			Me.txtAccountNo.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtAccountNo.TabIndex = 1
			Me.txtAccountName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAccountName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAccountName.Location = New Global.System.Drawing.Point(92, 21)
			Me.txtAccountName.Name = "txtAccountName"
			Me.txtAccountName.Size = New Global.System.Drawing.Size(166, 20)
			Me.txtAccountName.TabIndex = 0
			Me.txtPAN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPAN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPAN.Location = New Global.System.Drawing.Point(125, 340)
			Me.txtPAN.Name = "txtPAN"
			Me.txtPAN.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtPAN.TabIndex = 11
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(10, 340)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(37, 15)
			Me.Label14.TabIndex = 304
			Me.Label14.Text = "PAN :"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(10, 286)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(73, 15)
			Me.Label8.TabIndex = 302
			Me.Label8.Text = "GSTIN/UID :"
			Me.txtGSTIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtGSTIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGSTIN.Location = New Global.System.Drawing.Point(125, 286)
			Me.txtGSTIN.Name = "txtGSTIN"
			Me.txtGSTIN.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtGSTIN.TabIndex = 8
			Me.txtCIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCIN.Location = New Global.System.Drawing.Point(125, 313)
			Me.txtCIN.Name = "txtCIN"
			Me.txtCIN.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtCIN.TabIndex = 10
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(10, 313)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(33, 15)
			Me.Label13.TabIndex = 300
			Me.Label13.Text = "CIN :"
			Me.txtSupName.Location = New Global.System.Drawing.Point(589, 31)
			Me.txtSupName.Name = "txtSupName"
			Me.txtSupName.[ReadOnly] = True
			Me.txtSupName.Size = New Global.System.Drawing.Size(20, 21)
			Me.txtSupName.TabIndex = 296
			Me.txtSupName.TabStop = False
			Me.txtSupName.Visible = False
			Me.cmbState.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbState.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbState.FormattingEnabled = True
			Me.cmbState.Items.AddRange(New Object() { "Andaman and Nicobar Islands", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra and Nagar Haveli and Daman and Diu", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Ladakh", "Lakshadweep", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Puducherry", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal", "SriLanka" })
			Me.cmbState.Location = New Global.System.Drawing.Point(125, 177)
			Me.cmbState.Name = "cmbState"
			Me.cmbState.Size = New Global.System.Drawing.Size(258, 23)
			Me.cmbState.TabIndex = 4
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(10, 205)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(79, 15)
			Me.Label12.TabIndex = 295
			Me.Label12.Text = "Postal Code :"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(10, 178)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(41, 15)
			Me.Label9.TabIndex = 294
			Me.Label9.Text = "State :"
			Me.txtZipCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtZipCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtZipCode.Location = New Global.System.Drawing.Point(125, 205)
			Me.txtZipCode.Name = "txtZipCode"
			Me.txtZipCode.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtZipCode.TabIndex = 5
			Me.txtID.Location = New Global.System.Drawing.Point(589, 6)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(20, 21)
			Me.txtID.TabIndex = 4
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(10, 152)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(32, 15)
			Me.Label4.TabIndex = 24
			Me.Label4.Text = "City :"
			Me.txtCity.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCity.Location = New Global.System.Drawing.Point(125, 151)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.Size = New Global.System.Drawing.Size(258, 21)
			Me.txtCity.TabIndex = 3
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(10, 394)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(63, 15)
			Me.Label10.TabIndex = 21
			Me.Label10.Text = "Remarks :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(10, 62)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(96, 15)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Supplier Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 9)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(74, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Supplier ID :"
			Me.txtSupplierID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSupplierID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSupplierID.Location = New Global.System.Drawing.Point(125, 9)
			Me.txtSupplierID.Name = "txtSupplierID"
			Me.txtSupplierID.[ReadOnly] = True
			Me.txtSupplierID.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtSupplierID.TabIndex = 0
			Me.txtSupplierID.TabStop = False
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(125, 91)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(329, 54)
			Me.txtAddress.TabIndex = 2
			Me.txtRemarks.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemarks.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRemarks.Location = New Global.System.Drawing.Point(125, 394)
			Me.txtRemarks.Multiline = True
			Me.txtRemarks.Name = "txtRemarks"
			Me.txtRemarks.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtRemarks.Size = New Global.System.Drawing.Size(166, 50)
			Me.txtRemarks.TabIndex = 14
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(10, 91)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(57, 15)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Address :"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(10, 232)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(73, 15)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Contact No :"
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.Location = New Global.System.Drawing.Point(125, 259)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(329, 21)
			Me.txtEmailID.TabIndex = 7
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(125, 232)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(258, 21)
			Me.txtContactNo.TabIndex = 6
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(10, 259)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(60, 15)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "Email ID :"
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(655, 372)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(157, 43)
			Me.GelButton1.TabIndex = 520
			Me.GelButton1.Text = "New"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
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
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(655, 432)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(157, 43)
			Me.Button1.TabIndex = 518
			Me.Button1.Text = "Envelope Print"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
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
			Me.btnExtract.Location = New Global.System.Drawing.Point(402, 62)
			Me.btnExtract.Name = "btnExtract"
			Me.btnExtract.Size = New Global.System.Drawing.Size(68, 25)
			Me.btnExtract.TabIndex = 520
			Me.btnExtract.Text = "Get"
			Me.btnExtract.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExtract.UseVisualStyleBackColor = False
			Me.btnNext.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNext.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNext.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Image = CType(componentResourceManager.GetObject("btnNext.Image"), Global.System.Drawing.Image)
			Me.btnNext.Location = New Global.System.Drawing.Point(370, 11)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnNext.TabIndex = 1738
			Me.btnNext.TabStop = False
			Me.btnNext.UseVisualStyleBackColor = False
			Me.btnFirst.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnFirst.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnFirst.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Image = CType(componentResourceManager.GetObject("btnFirst.Image"), Global.System.Drawing.Image)
			Me.btnFirst.Location = New Global.System.Drawing.Point(428, 11)
			Me.btnFirst.Name = "btnFirst"
			Me.btnFirst.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnFirst.TabIndex = 1741
			Me.btnFirst.TabStop = False
			Me.btnFirst.UseVisualStyleBackColor = False
			Me.txtPrev.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.txtPrev.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.txtPrev.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Image = CType(componentResourceManager.GetObject("txtPrev.Image"), Global.System.Drawing.Image)
			Me.txtPrev.Location = New Global.System.Drawing.Point(399, 11)
			Me.txtPrev.Name = "txtPrev"
			Me.txtPrev.Size = New Global.System.Drawing.Size(26, 21)
			Me.txtPrev.TabIndex = 1739
			Me.txtPrev.TabStop = False
			Me.txtPrev.UseVisualStyleBackColor = False
			Me.btnLast.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLast.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnLast.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Image = CType(componentResourceManager.GetObject("btnLast.Image"), Global.System.Drawing.Image)
			Me.btnLast.Location = New Global.System.Drawing.Point(341, 11)
			Me.btnLast.Name = "btnLast"
			Me.btnLast.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnLast.TabIndex = 1740
			Me.btnLast.TabStop = False
			Me.btnLast.UseVisualStyleBackColor = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(476, 3)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(155, 152)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 327
			Me.Picture.TabStop = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(832, 549)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSupplier"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel3.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006FA0 RID: 28576
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
