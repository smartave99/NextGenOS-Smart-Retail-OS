Namespace BillPoint
	' Token: 0x02000299 RID: 665
		Public Partial Class frmCreditCustomerReceipt
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600A7E9 RID: 42985 RVA: 0x00706D48 File Offset: 0x00704F48
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

		' Token: 0x0600A7EA RID: 42986 RVA: 0x00706D98 File Offset: 0x00704F98
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCreditCustomerReceipt))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Button29 = New Global.GelButtons.GelButton()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.cmbprintcopy = New Global.System.Windows.Forms.ComboBox()
			Me.Button2 = New Global.GelButtons.GelButton()
			Me.Button6 = New Global.GelButtons.GelButton()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnPrint = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label74 = New Global.System.Windows.Forms.Label()
			Me.cmbAccountNo = New Global.System.Windows.Forms.ComboBox()
			Me.txtPaymentModeDetails = New Global.System.Windows.Forms.RichTextBox()
			Me.txtRsToWords = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.cmbPaymentMode = New Global.System.Windows.Forms.ComboBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.dtpTranactionDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtTransactionNo = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtTransactionAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.txtCustNameId = New Global.System.Windows.Forms.TextBox()
			Me.gbPartyInfo = New Global.System.Windows.Forms.GroupBox()
			Me.btnNext = New Global.System.Windows.Forms.Button()
			Me.btnFirst = New Global.System.Windows.Forms.Button()
			Me.txtPrev = New Global.System.Windows.Forms.Button()
			Me.btnSelection = New Global.System.Windows.Forms.Button()
			Me.btnLast = New Global.System.Windows.Forms.Button()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtCustomerID = New Global.System.Windows.Forms.TextBox()
			Me.lblBalance = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label26 = New Global.System.Windows.Forms.Label()
			Me.Label30 = New Global.System.Windows.Forms.Label()
			Me.Label36 = New Global.System.Windows.Forms.Label()
			Me.txtRemarks = New Global.System.Windows.Forms.RichTextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.Button39 = New Global.System.Windows.Forms.Button()
			Me.F2 = New Global.System.Windows.Forms.TextBox()
			Me.F1 = New Global.System.Windows.Forms.TextBox()
			Me.cmbNP = New Global.System.Windows.Forms.ComboBox()
			Me.Button35 = New Global.System.Windows.Forms.Button()
			Me.txtNP = New Global.System.Windows.Forms.TextBox()
			Me.txtSuffix = New Global.System.Windows.Forms.TextBox()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtInvCode1 = New Global.System.Windows.Forms.TextBox()
			Me.txtcompname = New Global.System.Windows.Forms.TextBox()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.txtTempAmt = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtCustID = New Global.System.Windows.Forms.TextBox()
			Me.txtT_ID = New Global.System.Windows.Forms.TextBox()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.cmbCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			Me.gbPartyInfo.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Button29)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.txtCustNameId)
			Me.Panel1.Controls.Add(Me.gbPartyInfo)
			Me.Panel1.Controls.Add(Me.txtRemarks)
			Me.Panel1.Controls.Add(Me.Label12)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(6, 5)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(868, 548)
			Me.Panel1.TabIndex = 2
			Me.Button29.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button29.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button29.FlatAppearance.BorderSize = 0
			Me.Button29.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button29.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button29.ForeColor = Global.System.Drawing.Color.White
			Me.Button29.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button29.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button29.Image = CType(componentResourceManager.GetObject("Button29.Image"), Global.System.Drawing.Image)
			Me.Button29.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button29.Location = New Global.System.Drawing.Point(680, 495)
			Me.Button29.Name = "Button29"
			Me.Button29.Size = New Global.System.Drawing.Size(182, 43)
			Me.Button29.TabIndex = 522
			Me.Button29.Text = "QR Code Scan To Pay"
			Me.Button29.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button29.UseVisualStyleBackColor = False
			Me.Panel4.Controls.Add(Me.cmbprintcopy)
			Me.Panel4.Controls.Add(Me.Button2)
			Me.Panel4.Controls.Add(Me.Button6)
			Me.Panel4.Controls.Add(Me.btnGetData)
			Me.Panel4.Controls.Add(Me.btnPrint)
			Me.Panel4.Controls.Add(Me.btnUpdate)
			Me.Panel4.Controls.Add(Me.btnDelete)
			Me.Panel4.Controls.Add(Me.btnNew)
			Me.Panel4.Controls.Add(Me.btnSave)
			Me.Panel4.Location = New Global.System.Drawing.Point(685, 67)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(169, 414)
			Me.Panel4.TabIndex = 1742
			Me.cmbprintcopy.BackColor = Global.System.Drawing.Color.Yellow
			Me.cmbprintcopy.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbprintcopy.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbprintcopy.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbprintcopy.FormattingEnabled = True
			Me.cmbprintcopy.Items.AddRange(New Object() { "ORIGINAL COPY", "DUPLICATE COPY", "TRIPLICATE COPY", "EXTRA COPY" })
			Me.cmbprintcopy.Location = New Global.System.Drawing.Point(29, 381)
			Me.cmbprintcopy.Name = "cmbprintcopy"
			Me.cmbprintcopy.Size = New Global.System.Drawing.Size(105, 23)
			Me.cmbprintcopy.TabIndex = 8
			Me.Button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button2.FlatAppearance.BorderSize = 0
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button2.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(7, 332)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(157, 43)
			Me.Button2.TabIndex = 521
			Me.Button2.Text = "&WhatsApp"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button6.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button6.FlatAppearance.BorderSize = 0
			Me.Button6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button6.ForeColor = Global.System.Drawing.Color.White
			Me.Button6.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button6.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button6.Image = CType(componentResourceManager.GetObject("Button6.Image"), Global.System.Drawing.Image)
			Me.Button6.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button6.Location = New Global.System.Drawing.Point(7, 286)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(157, 43)
			Me.Button6.TabIndex = 520
			Me.Button6.Text = "SMS"
			Me.Button6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button6.UseVisualStyleBackColor = False
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
			Me.btnPrint.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnPrint.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnPrint.FlatAppearance.BorderSize = 0
			Me.btnPrint.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnPrint.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnPrint.ForeColor = Global.System.Drawing.Color.White
			Me.btnPrint.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnPrint.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnPrint.Image = CType(componentResourceManager.GetObject("btnPrint.Image"), Global.System.Drawing.Image)
			Me.btnPrint.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnPrint.Location = New Global.System.Drawing.Point(7, 240)
			Me.btnPrint.Name = "btnPrint"
			Me.btnPrint.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnPrint.TabIndex = 518
			Me.btnPrint.Text = "Print"
			Me.btnPrint.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnPrint.UseVisualStyleBackColor = False
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
			Me.Panel3.BackgroundImage = CType(componentResourceManager.GetObject("Panel3.BackgroundImage"), Global.System.Drawing.Image)
			Me.Panel3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.Label6)
			Me.Panel3.Controls.Add(Me.dgw)
			Me.Panel3.Location = New Global.System.Drawing.Point(9, 370)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(666, 169)
			Me.Panel3.TabIndex = 1705
			Me.Label6.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.Label6.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.Black
			Me.Label6.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(664, 23)
			Me.Label6.TabIndex = 1706
			Me.Label6.Text = "Customer Dashboard"
			Me.Label6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.dgw.AllowUserToAddRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.dgw.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 29
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(0, 22)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(664, 145)
			Me.dgw.TabIndex = 411
			Me.dgw.TabStop = False
			dataGridViewCellStyle6.Format = "d"
			dataGridViewCellStyle6.NullValue = Nothing
			Me.Column1.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column1.HeaderText = "Date"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Visible = False
			Me.Column3.HeaderText = "Invoice/Voucher No."
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Particulars"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column5.HeaderText = "Debit"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			dataGridViewCellStyle8.NullValue = Nothing
			Me.Column6.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column6.HeaderText = "Credit"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.GroupBox1.Controls.Add(Me.Label74)
			Me.GroupBox1.Controls.Add(Me.cmbAccountNo)
			Me.GroupBox1.Controls.Add(Me.txtPaymentModeDetails)
			Me.GroupBox1.Controls.Add(Me.txtRsToWords)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.cmbPaymentMode)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.dtpTranactionDate)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.txtTransactionNo)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtTransactionAmount)
			Me.GroupBox1.Controls.Add(Me.Label19)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(9, 234)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(666, 136)
			Me.GroupBox1.TabIndex = 1
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Transaction Info"
			Me.Label74.AutoSize = True
			Me.Label74.Location = New Global.System.Drawing.Point(8, 89)
			Me.Label74.Name = "Label74"
			Me.Label74.Size = New Global.System.Drawing.Size(76, 13)
			Me.Label74.TabIndex = 1731
			Me.Label74.Text = "Bank A/c No :"
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.Cursor = Global.System.Windows.Forms.Cursors.[Default]
			Me.cmbAccountNo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo.Enabled = False
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(109, 85)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(143, 21)
			Me.cmbAccountNo.TabIndex = 3
			Me.txtPaymentModeDetails.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPaymentModeDetails.Location = New Global.System.Drawing.Point(393, 29)
			Me.txtPaymentModeDetails.Name = "txtPaymentModeDetails"
			Me.txtPaymentModeDetails.Size = New Global.System.Drawing.Size(258, 60)
			Me.txtPaymentModeDetails.TabIndex = 5
			Me.txtPaymentModeDetails.Text = ""
			Me.txtRsToWords.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRsToWords.ForeColor = Global.System.Drawing.Color.Blue
			Me.txtRsToWords.Location = New Global.System.Drawing.Point(279, 92)
			Me.txtRsToWords.Name = "txtRsToWords"
			Me.txtRsToWords.Size = New Global.System.Drawing.Size(372, 41)
			Me.txtRsToWords.TabIndex = 1704
			Me.txtRsToWords.Text = "....."
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(390, 12)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(263, 13)
			Me.Label4.TabIndex = 97
			Me.Label4.Text = "Payment Mode Details : (Transaction ID/ Cheque No.)"
			Me.cmbPaymentMode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPaymentMode.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPaymentMode.FormattingEnabled = True
			Me.cmbPaymentMode.Items.AddRange(New Object() { "By Cash", "By Cheque", "By Online Transfer", "PhonePe", "Google Pay", "Paytm", "E-Wallet" })
			Me.cmbPaymentMode.Location = New Global.System.Drawing.Point(109, 61)
			Me.cmbPaymentMode.Name = "cmbPaymentMode"
			Me.cmbPaymentMode.Size = New Global.System.Drawing.Size(143, 21)
			Me.cmbPaymentMode.TabIndex = 2
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(8, 65)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label5.TabIndex = 6
			Me.Label5.Text = "Payment Mode :"
			Me.dtpTranactionDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpTranactionDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpTranactionDate.Location = New Global.System.Drawing.Point(109, 38)
			Me.dtpTranactionDate.Name = "dtpTranactionDate"
			Me.dtpTranactionDate.Size = New Global.System.Drawing.Size(143, 20)
			Me.dtpTranactionDate.TabIndex = 1
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(8, 18)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(89, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Transaction No. :"
			Me.txtTransactionNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtTransactionNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTransactionNo.Location = New Global.System.Drawing.Point(109, 14)
			Me.txtTransactionNo.Name = "txtTransactionNo"
			Me.txtTransactionNo.Size = New Global.System.Drawing.Size(143, 21)
			Me.txtTransactionNo.TabIndex = 0
			Me.txtTransactionNo.TabStop = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(8, 42)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(95, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Transaction Date :"
			Me.txtTransactionAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtTransactionAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTransactionAmount.Location = New Global.System.Drawing.Point(109, 109)
			Me.txtTransactionAmount.Name = "txtTransactionAmount"
			Me.txtTransactionAmount.Size = New Global.System.Drawing.Size(143, 20)
			Me.txtTransactionAmount.TabIndex = 4
			Me.txtTransactionAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label19.AutoSize = True
			Me.Label19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label19.Location = New Global.System.Drawing.Point(8, 113)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(49, 13)
			Me.Label19.TabIndex = 96
			Me.Label19.Text = "Amount :"
			Me.txtCustNameId.Location = New Global.System.Drawing.Point(561, 237)
			Me.txtCustNameId.Name = "txtCustNameId"
			Me.txtCustNameId.[ReadOnly] = True
			Me.txtCustNameId.Size = New Global.System.Drawing.Size(111, 20)
			Me.txtCustNameId.TabIndex = 412
			Me.txtCustNameId.TabStop = False
			Me.txtCustNameId.Visible = False
			Me.gbPartyInfo.Controls.Add(Me.cmbCustomerName)
			Me.gbPartyInfo.Controls.Add(Me.btnNext)
			Me.gbPartyInfo.Controls.Add(Me.btnFirst)
			Me.gbPartyInfo.Controls.Add(Me.txtPrev)
			Me.gbPartyInfo.Controls.Add(Me.btnSelection)
			Me.gbPartyInfo.Controls.Add(Me.btnLast)
			Me.gbPartyInfo.Controls.Add(Me.Label10)
			Me.gbPartyInfo.Controls.Add(Me.txtCustomerID)
			Me.gbPartyInfo.Controls.Add(Me.lblBalance)
			Me.gbPartyInfo.Controls.Add(Me.Label11)
			Me.gbPartyInfo.Controls.Add(Me.txtContactNo)
			Me.gbPartyInfo.Controls.Add(Me.txtAddress)
			Me.gbPartyInfo.Controls.Add(Me.Label26)
			Me.gbPartyInfo.Controls.Add(Me.Label30)
			Me.gbPartyInfo.Controls.Add(Me.Label36)
			Me.gbPartyInfo.Location = New Global.System.Drawing.Point(9, 51)
			Me.gbPartyInfo.Name = "gbPartyInfo"
			Me.gbPartyInfo.Size = New Global.System.Drawing.Size(440, 174)
			Me.gbPartyInfo.TabIndex = 0
			Me.gbPartyInfo.TabStop = False
			Me.gbPartyInfo.Text = "Credit Customer Information"
			Me.btnNext.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNext.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNext.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Image = CType(componentResourceManager.GetObject("btnNext.Image"), Global.System.Drawing.Image)
			Me.btnNext.Location = New Global.System.Drawing.Point(321, 25)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnNext.TabIndex = 1738
			Me.btnNext.TabStop = False
			Me.btnNext.UseVisualStyleBackColor = False
			Me.btnNext.Visible = False
			Me.btnFirst.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnFirst.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnFirst.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Image = CType(componentResourceManager.GetObject("btnFirst.Image"), Global.System.Drawing.Image)
			Me.btnFirst.Location = New Global.System.Drawing.Point(384, 25)
			Me.btnFirst.Name = "btnFirst"
			Me.btnFirst.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnFirst.TabIndex = 1741
			Me.btnFirst.TabStop = False
			Me.btnFirst.UseVisualStyleBackColor = False
			Me.btnFirst.Visible = False
			Me.txtPrev.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.txtPrev.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.txtPrev.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Image = CType(componentResourceManager.GetObject("txtPrev.Image"), Global.System.Drawing.Image)
			Me.txtPrev.Location = New Global.System.Drawing.Point(353, 25)
			Me.txtPrev.Name = "txtPrev"
			Me.txtPrev.Size = New Global.System.Drawing.Size(26, 21)
			Me.txtPrev.TabIndex = 1739
			Me.txtPrev.TabStop = False
			Me.txtPrev.UseVisualStyleBackColor = False
			Me.txtPrev.Visible = False
			Me.btnSelection.BackColor = Global.System.Drawing.Color.Lime
			Me.btnSelection.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSelection.Location = New Global.System.Drawing.Point(236, 25)
			Me.btnSelection.Name = "btnSelection"
			Me.btnSelection.Size = New Global.System.Drawing.Size(29, 21)
			Me.btnSelection.TabIndex = 0
			Me.btnSelection.Text = "..."
			Me.btnSelection.UseVisualStyleBackColor = False
			Me.btnLast.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLast.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnLast.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Image = CType(componentResourceManager.GetObject("btnLast.Image"), Global.System.Drawing.Image)
			Me.btnLast.Location = New Global.System.Drawing.Point(288, 25)
			Me.btnLast.Name = "btnLast"
			Me.btnLast.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnLast.TabIndex = 1740
			Me.btnLast.TabStop = False
			Me.btnLast.UseVisualStyleBackColor = False
			Me.btnLast.Visible = False
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(11, 53)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label10.TabIndex = 36
			Me.Label10.Text = "Name :"
			Me.txtCustomerID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCustomerID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerID.Location = New Global.System.Drawing.Point(95, 25)
			Me.txtCustomerID.Name = "txtCustomerID"
			Me.txtCustomerID.[ReadOnly] = True
			Me.txtCustomerID.Size = New Global.System.Drawing.Size(138, 21)
			Me.txtCustomerID.TabIndex = 0
			Me.txtCustomerID.TabStop = False
			Me.lblBalance.AutoSize = True
			Me.lblBalance.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblBalance.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.lblBalance.Location = New Global.System.Drawing.Point(131, 141)
			Me.lblBalance.Name = "lblBalance"
			Me.lblBalance.Size = New Global.System.Drawing.Size(44, 20)
			Me.lblBalance.TabIndex = 5
			Me.lblBalance.Text = "0.00"
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(10, 139)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(115, 20)
			Me.Label11.TabIndex = 34
			Me.Label11.Text = "A/c Balance :"
			Me.txtContactNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(95, 106)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.[ReadOnly] = True
			Me.txtContactNo.Size = New Global.System.Drawing.Size(315, 21)
			Me.txtContactNo.TabIndex = 4
			Me.txtContactNo.TabStop = False
			Me.txtAddress.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(95, 79)
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.[ReadOnly] = True
			Me.txtAddress.Size = New Global.System.Drawing.Size(315, 21)
			Me.txtAddress.TabIndex = 2
			Me.txtAddress.TabStop = False
			Me.Label26.AutoSize = True
			Me.Label26.Location = New Global.System.Drawing.Point(11, 106)
			Me.Label26.Name = "Label26"
			Me.Label26.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label26.TabIndex = 29
			Me.Label26.Text = "Contact No. :"
			Me.Label30.AutoSize = True
			Me.Label30.Location = New Global.System.Drawing.Point(11, 77)
			Me.Label30.Name = "Label30"
			Me.Label30.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label30.TabIndex = 26
			Me.Label30.Text = "Address :"
			Me.Label36.AutoSize = True
			Me.Label36.Location = New Global.System.Drawing.Point(11, 25)
			Me.Label36.Name = "Label36"
			Me.Label36.Size = New Global.System.Drawing.Size(71, 13)
			Me.Label36.TabIndex = 23
			Me.Label36.Text = "Customer ID :"
			Me.txtRemarks.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemarks.Location = New Global.System.Drawing.Point(455, 73)
			Me.txtRemarks.Name = "txtRemarks"
			Me.txtRemarks.Size = New Global.System.Drawing.Size(218, 152)
			Me.txtRemarks.TabIndex = 4
			Me.txtRemarks.Text = ""
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(452, 57)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label12.TabIndex = 5
			Me.Label12.Text = "Remarks :"
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.lblCPhone)
			Me.Panel2.Controls.Add(Me.Button39)
			Me.Panel2.Controls.Add(Me.F2)
			Me.Panel2.Controls.Add(Me.F1)
			Me.Panel2.Controls.Add(Me.cmbNP)
			Me.Panel2.Controls.Add(Me.Button35)
			Me.Panel2.Controls.Add(Me.txtNP)
			Me.Panel2.Controls.Add(Me.txtSuffix)
			Me.Panel2.Controls.Add(Me.DTP2)
			Me.Panel2.Controls.Add(Me.DTP1)
			Me.Panel2.Controls.Add(Me.txtInvCode1)
			Me.Panel2.Controls.Add(Me.txtcompname)
			Me.Panel2.Controls.Add(Me.TextBox10)
			Me.Panel2.Controls.Add(Me.TextBox9)
			Me.Panel2.Controls.Add(Me.TextBox3)
			Me.Panel2.Controls.Add(Me.txtTempAmt)
			Me.Panel2.Controls.Add(Me.TextBox2)
			Me.Panel2.Controls.Add(Me.TextBox1)
			Me.Panel2.Controls.Add(Me.lblUserType)
			Me.Panel2.Controls.Add(Me.lblSet)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.txtCustID)
			Me.Panel2.Controls.Add(Me.txtT_ID)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(868, 38)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(325, 6)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(135, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Receipt Entry"
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(366, 13)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCPhone.TabIndex = 1770
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.Button39.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button39.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button39.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button39.FlatAppearance.BorderColor = Global.System.Drawing.Color.White
			Me.Button39.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button39.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button39.ForeColor = Global.System.Drawing.Color.White
			Me.Button39.Location = New Global.System.Drawing.Point(764, 1)
			Me.Button39.Name = "Button39"
			Me.Button39.Size = New Global.System.Drawing.Size(69, 31)
			Me.Button39.TabIndex = 1762
			Me.Button39.TabStop = False
			Me.Button39.Text = "UPI PAY"
			Me.Button39.UseVisualStyleBackColor = False
			Me.F2.Location = New Global.System.Drawing.Point(167, 1)
			Me.F2.Name = "F2"
			Me.F2.[ReadOnly] = True
			Me.F2.Size = New Global.System.Drawing.Size(29, 20)
			Me.F2.TabIndex = 1761
			Me.F2.TabStop = False
			Me.F2.Visible = False
			Me.F1.Location = New Global.System.Drawing.Point(132, 1)
			Me.F1.Name = "F1"
			Me.F1.[ReadOnly] = True
			Me.F1.Size = New Global.System.Drawing.Size(33, 20)
			Me.F1.TabIndex = 1760
			Me.F1.TabStop = False
			Me.F1.Visible = False
			Me.cmbNP.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbNP.FormattingEnabled = True
			Me.cmbNP.Location = New Global.System.Drawing.Point(614, 5)
			Me.cmbNP.Name = "cmbNP"
			Me.cmbNP.Size = New Global.System.Drawing.Size(49, 21)
			Me.cmbNP.TabIndex = 1759
			Me.cmbNP.TabStop = False
			Me.cmbNP.Visible = False
			Me.Button35.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button35.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button35.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button35.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button35.ForeColor = Global.System.Drawing.Color.White
			Me.Button35.Image = CType(componentResourceManager.GetObject("Button35.Image"), Global.System.Drawing.Image)
			Me.Button35.Location = New Global.System.Drawing.Point(836, 1)
			Me.Button35.Name = "Button35"
			Me.Button35.Size = New Global.System.Drawing.Size(31, 30)
			Me.Button35.TabIndex = 1728
			Me.Button35.TabStop = False
			Me.Button35.UseVisualStyleBackColor = False
			Me.txtNP.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNP.Location = New Global.System.Drawing.Point(279, 4)
			Me.txtNP.Name = "txtNP"
			Me.txtNP.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.txtNP.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtNP.TabIndex = 1725
			Me.txtNP.TabStop = False
			Me.txtNP.Visible = False
			Me.txtSuffix.Location = New Global.System.Drawing.Point(494, 3)
			Me.txtSuffix.Name = "txtSuffix"
			Me.txtSuffix.[ReadOnly] = True
			Me.txtSuffix.Size = New Global.System.Drawing.Size(33, 20)
			Me.txtSuffix.TabIndex = 426
			Me.txtSuffix.TabStop = False
			Me.txtSuffix.Visible = False
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(646, 5)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 423
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(532, 4)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 422
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.txtInvCode1.Location = New Global.System.Drawing.Point(95, 6)
			Me.txtInvCode1.Name = "txtInvCode1"
			Me.txtInvCode1.[ReadOnly] = True
			Me.txtInvCode1.Size = New Global.System.Drawing.Size(42, 20)
			Me.txtInvCode1.TabIndex = 417
			Me.txtInvCode1.TabStop = False
			Me.txtInvCode1.Visible = False
			Me.txtcompname.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtcompname.Location = New Global.System.Drawing.Point(706, 10)
			Me.txtcompname.Name = "txtcompname"
			Me.txtcompname.[ReadOnly] = True
			Me.txtcompname.Size = New Global.System.Drawing.Size(44, 20)
			Me.txtcompname.TabIndex = 416
			Me.txtcompname.TabStop = False
			Me.txtcompname.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtcompname.Visible = False
			Me.TextBox10.Location = New Global.System.Drawing.Point(197, 9)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(20, 20)
			Me.TextBox10.TabIndex = 415
			Me.TextBox10.TabStop = False
			Me.TextBox10.Visible = False
			Me.TextBox9.Location = New Global.System.Drawing.Point(219, 10)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.[ReadOnly] = True
			Me.TextBox9.Size = New Global.System.Drawing.Size(100, 20)
			Me.TextBox9.TabIndex = 414
			Me.TextBox9.TabStop = False
			Me.TextBox9.Visible = False
			Me.TextBox3.Location = New Global.System.Drawing.Point(589, 9)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(31, 20)
			Me.TextBox3.TabIndex = 315
			Me.TextBox3.TabStop = False
			Me.TextBox3.Visible = False
			Me.txtTempAmt.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTempAmt.Location = New Global.System.Drawing.Point(646, 11)
			Me.txtTempAmt.Name = "txtTempAmt"
			Me.txtTempAmt.[ReadOnly] = True
			Me.txtTempAmt.Size = New Global.System.Drawing.Size(44, 20)
			Me.txtTempAmt.TabIndex = 11
			Me.txtTempAmt.TabStop = False
			Me.txtTempAmt.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtTempAmt.Visible = False
			Me.TextBox2.Location = New Global.System.Drawing.Point(552, 9)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(31, 20)
			Me.TextBox2.TabIndex = 314
			Me.TextBox2.TabStop = False
			Me.TextBox2.Visible = False
			Me.TextBox1.Location = New Global.System.Drawing.Point(515, 9)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(31, 20)
			Me.TextBox1.TabIndex = 313
			Me.TextBox1.TabStop = False
			Me.TextBox1.Visible = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(142, 16)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(56, 13)
			Me.lblUserType.TabIndex = 312
			Me.lblUserType.Text = "User Type"
			Me.lblUserType.Visible = False
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(187, 30)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 311
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(142, 29)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(29, 13)
			Me.lblUser.TabIndex = 6
			Me.lblUser.Text = "User"
			Me.lblUser.Visible = False
			Me.txtCustID.Location = New Global.System.Drawing.Point(60, 10)
			Me.txtCustID.Name = "txtCustID"
			Me.txtCustID.[ReadOnly] = True
			Me.txtCustID.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtCustID.TabIndex = 2
			Me.txtCustID.TabStop = False
			Me.txtCustID.Visible = False
			Me.txtT_ID.Location = New Global.System.Drawing.Point(19, 10)
			Me.txtT_ID.Name = "txtT_ID"
			Me.txtT_ID.[ReadOnly] = True
			Me.txtT_ID.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtT_ID.TabIndex = 1
			Me.txtT_ID.TabStop = False
			Me.txtT_ID.Visible = False
			Me.ErrorProvider1.ContainerControl = Me
			Me.cmbCustomerName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.cmbCustomerName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbCustomerName.Location = New Global.System.Drawing.Point(95, 53)
			Me.cmbCustomerName.Name = "cmbCustomerName"
			Me.cmbCustomerName.[ReadOnly] = True
			Me.cmbCustomerName.Size = New Global.System.Drawing.Size(315, 21)
			Me.cmbCustomerName.TabIndex = 1742
			Me.cmbCustomerName.TabStop = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(879, 558)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCreditCustomerReceipt"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel3.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.gbPartyInfo.ResumeLayout(False)
			Me.gbPartyInfo.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004633 RID: 17971
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
