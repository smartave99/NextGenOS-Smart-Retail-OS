Namespace BillPoint
	' Token: 0x02000552 RID: 1362
		Public Partial Class frmStockAdjustment_Store
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06010949 RID: 67913 RVA: 0x009B0760 File Offset: 0x009AE960
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

		' Token: 0x0601094A RID: 67914 RVA: 0x009B07B0 File Offset: 0x009AE9B0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmStockAdjustment_Store))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle9 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle10 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle11 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle12 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle13 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle14 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle15 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle16 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle17 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle18 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle19 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle20 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle21 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.btnUpdate = New Global.System.Windows.Forms.Button()
			Me.btnNew = New Global.System.Windows.Forms.Button()
			Me.btnGetData = New Global.System.Windows.Forms.Button()
			Me.btnDelete = New Global.System.Windows.Forms.Button()
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.dgw4 = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn30 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn31 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn32 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn33 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn34 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn35 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn36 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn37 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn38 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn39 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn40 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column34 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column43 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column44 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column45 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column46 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column47 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column48 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column50 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column51 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column54 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column66 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column67 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.txtProductName = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.txtQty = New Global.System.Windows.Forms.TextBox()
			Me.txtReason = New Global.System.Windows.Forms.TextBox()
			Me.lblQty_S = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.gbAdjustment = New Global.System.Windows.Forms.GroupBox()
			Me.rbMinus = New Global.System.Windows.Forms.RadioButton()
			Me.rbPlus = New Global.System.Windows.Forms.RadioButton()
			Me.btnScanBarcode = New Global.System.Windows.Forms.Button()
			Me.dtpDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtAdjustmentID = New Global.System.Windows.Forms.TextBox()
			Me.txtProductCode = New Global.System.Windows.Forms.TextBox()
			Me.Label27 = New Global.System.Windows.Forms.Label()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label34 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtProductID = New Global.System.Windows.Forms.TextBox()
			Me.txtQ = New Global.System.Windows.Forms.TextBox()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw4, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.gbAdjustment.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.DTP2)
			Me.Panel1.Controls.Add(Me.DTP1)
			Me.Panel1.Controls.Add(Me.GroupBox3)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.txtProductID)
			Me.Panel1.Controls.Add(Me.txtQ)
			Me.Panel1.Location = New Global.System.Drawing.Point(9, 10)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(807, 299)
			Me.Panel1.TabIndex = 2
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(9, 7)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(791, 33)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Stock Adjustment"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(105, 15)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 435
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(16, 14)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 434
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.GroupBox3.Controls.Add(Me.btnUpdate)
			Me.GroupBox3.Controls.Add(Me.btnNew)
			Me.GroupBox3.Controls.Add(Me.btnGetData)
			Me.GroupBox3.Controls.Add(Me.btnDelete)
			Me.GroupBox3.Controls.Add(Me.btnSave)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(688, 43)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(112, 249)
			Me.GroupBox3.TabIndex = 314
			Me.GroupBox3.TabStop = False
			Me.btnUpdate.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpdate.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnUpdate.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate.Image = CType(componentResourceManager.GetObject("btnUpdate.Image"), Global.System.Drawing.Image)
			Me.btnUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdate.Location = New Global.System.Drawing.Point(11, 110)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(92, 37)
			Me.btnUpdate.TabIndex = 6
			Me.btnUpdate.Text = "&Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.btnNew.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNew.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnNew.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.Image = CType(componentResourceManager.GetObject("btnNew.Image"), Global.System.Drawing.Image)
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(11, 20)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnNew.TabIndex = 1
			Me.btnNew.Text = "&New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.btnGetData.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGetData.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnGetData.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnGetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetData.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGetData.Location = New Global.System.Drawing.Point(11, 194)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnGetData.TabIndex = 5
			Me.btnGetData.Text = "&Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.btnDelete.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnDelete.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnDelete.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnDelete.Enabled = False
			Me.btnDelete.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete.Image = CType(componentResourceManager.GetObject("btnDelete.Image"), Global.System.Drawing.Image)
			Me.btnDelete.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete.Location = New Global.System.Drawing.Point(11, 151)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnDelete.TabIndex = 4
			Me.btnDelete.Text = "&Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
			Me.btnSave.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSave.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSave.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(11, 66)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnSave.TabIndex = 2
			Me.btnSave.Text = "&Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.dgw4)
			Me.GroupBox1.Controls.Add(Me.txtProductName)
			Me.GroupBox1.Controls.Add(Me.TextBox1)
			Me.GroupBox1.Controls.Add(Me.txtQty)
			Me.GroupBox1.Controls.Add(Me.txtReason)
			Me.GroupBox1.Controls.Add(Me.lblQty_S)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.gbAdjustment)
			Me.GroupBox1.Controls.Add(Me.btnScanBarcode)
			Me.GroupBox1.Controls.Add(Me.dtpDate)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtAdjustmentID)
			Me.GroupBox1.Controls.Add(Me.txtProductCode)
			Me.GroupBox1.Controls.Add(Me.Label27)
			Me.GroupBox1.Controls.Add(Me.txtBarcode)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.Label34)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(9, 43)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(673, 249)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Stock Adjustment Info"
			Me.dgw4.AllowUserToAddRows = False
			Me.dgw4.AllowUserToResizeColumns = False
			Me.dgw4.AllowUserToResizeRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw4.Anchor = Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw4.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
			Me.dgw4.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw4.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.dgw4.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgw4.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.Color.Gray
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw4.ColumnHeadersHeight = 35
			Me.dgw4.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgw4.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.Column20, Me.Column21, Me.Column23, Me.Column24, Me.Column29, Me.Column34, Me.Column43, Me.Column44, Me.Column45, Me.Column46, Me.Column47, Me.Column48, Me.Column50, Me.Column51, Me.Column54, Me.Column66, Me.Column67 })
			Me.dgw4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgw4.EnableHeadersVisualStyles = False
			Me.dgw4.GridColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.dgw4.Location = New Global.System.Drawing.Point(15, 120)
			Me.dgw4.MultiSelect = False
			Me.dgw4.Name = "dgw4"
			Me.dgw4.[ReadOnly] = True
			Me.dgw4.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.YellowGreen
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw4.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw4.RowHeadersVisible = False
			Me.dgw4.RowHeadersWidth = 25
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw4.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw4.RowTemplate.Height = 25
			Me.dgw4.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw4.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw4.Size = New Global.System.Drawing.Size(652, 123)
			Me.dgw4.TabIndex = 1705
			Me.dgw4.TabStop = False
			Me.dgw4.Visible = False
			Me.DataGridViewTextBoxColumn23.FillWeight = 500F
			Me.DataGridViewTextBoxColumn23.HeaderText = "PID"
			Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
			Me.DataGridViewTextBoxColumn23.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn23.Visible = False
			Me.DataGridViewTextBoxColumn23.Width = 60
			Me.DataGridViewTextBoxColumn24.HeaderText = "Product Code"
			Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
			Me.DataGridViewTextBoxColumn24.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn24.Visible = False
			Me.DataGridViewTextBoxColumn24.Width = 136
			Me.DataGridViewTextBoxColumn25.FillWeight = 350F
			Me.DataGridViewTextBoxColumn25.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
			Me.DataGridViewTextBoxColumn25.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn25.Width = 140
			Me.DataGridViewTextBoxColumn26.HeaderText = "HSN Code"
			Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
			Me.DataGridViewTextBoxColumn26.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn26.Visible = False
			Me.DataGridViewTextBoxColumn26.Width = 111
			Me.DataGridViewTextBoxColumn27.HeaderText = "Part / Group"
			Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
			Me.DataGridViewTextBoxColumn27.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn27.Width = 125
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			Me.DataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridViewTextBoxColumn28.FillWeight = 200F
			Me.DataGridViewTextBoxColumn28.HeaderText = "Barcode"
			Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
			Me.DataGridViewTextBoxColumn28.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn28.Width = 96
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle6
			Me.DataGridViewTextBoxColumn29.FillWeight = 150F
			Me.DataGridViewTextBoxColumn29.HeaderText = "Purchase Price"
			Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
			Me.DataGridViewTextBoxColumn29.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn29.Visible = False
			Me.DataGridViewTextBoxColumn29.Width = 140
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.DataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle7
			Me.DataGridViewTextBoxColumn30.FillWeight = 150F
			Me.DataGridViewTextBoxColumn30.HeaderText = "Retail Sale Price"
			Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
			Me.DataGridViewTextBoxColumn30.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn30.Width = 150
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn31.DefaultCellStyle = dataGridViewCellStyle8
			Me.DataGridViewTextBoxColumn31.HeaderText = "Discount"
			Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
			Me.DataGridViewTextBoxColumn31.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn31.Width = 99
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle9
			Me.DataGridViewTextBoxColumn32.HeaderText = "CGST"
			Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
			Me.DataGridViewTextBoxColumn32.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn32.Visible = False
			Me.DataGridViewTextBoxColumn32.Width = 74
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn33.DefaultCellStyle = dataGridViewCellStyle10
			Me.DataGridViewTextBoxColumn33.HeaderText = "SGST"
			Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
			Me.DataGridViewTextBoxColumn33.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn33.Visible = False
			Me.DataGridViewTextBoxColumn33.Width = 73
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle11
			Me.DataGridViewTextBoxColumn34.HeaderText = "CESS"
			Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
			Me.DataGridViewTextBoxColumn34.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn34.Visible = False
			Me.DataGridViewTextBoxColumn34.Width = 71
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle12
			Me.DataGridViewTextBoxColumn35.HeaderText = "Qty"
			Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
			Me.DataGridViewTextBoxColumn35.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn35.Width = 61
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle13
			Me.DataGridViewTextBoxColumn36.HeaderText = "Main Unit"
			Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
			Me.DataGridViewTextBoxColumn36.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn36.Width = 105
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle14.Format = "N2"
			dataGridViewCellStyle14.NullValue = Nothing
			Me.DataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle14
			Me.DataGridViewTextBoxColumn37.HeaderText = "Wholesale Sale Price"
			Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
			Me.DataGridViewTextBoxColumn37.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn37.Width = 184
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle15.Format = "N2"
			dataGridViewCellStyle15.NullValue = Nothing
			Me.DataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle15
			Me.DataGridViewTextBoxColumn38.HeaderText = "Purchase Price"
			Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
			Me.DataGridViewTextBoxColumn38.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn38.Visible = False
			Me.DataGridViewTextBoxColumn38.Width = 140
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle16.NullValue = Nothing
			Me.DataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle16
			Me.DataGridViewTextBoxColumn39.HeaderText = "Alter Unit"
			Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
			Me.DataGridViewTextBoxColumn39.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn39.Visible = False
			Me.DataGridViewTextBoxColumn39.Width = 105
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn40.DefaultCellStyle = dataGridViewCellStyle17
			Me.DataGridViewTextBoxColumn40.HeaderText = "Conv Value"
			Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
			Me.DataGridViewTextBoxColumn40.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn40.Visible = False
			Me.DataGridViewTextBoxColumn40.Width = 115
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle18
			Me.Column20.HeaderText = "Last Sold Price"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			Me.Column20.Visible = False
			Me.Column20.Width = 141
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column21.DefaultCellStyle = dataGridViewCellStyle19
			Me.Column21.FillWeight = 60F
			Me.Column21.HeaderText = "Damage Qty"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			Me.Column21.Width = 125
			Me.Column23.HeaderText = "Description"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			Me.Column23.Visible = False
			Me.Column23.Width = 119
			dataGridViewCellStyle20.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column24.DefaultCellStyle = dataGridViewCellStyle20
			Me.Column24.HeaderText = "Min Stock Limit"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			Me.Column24.Visible = False
			Me.Column24.Width = 148
			dataGridViewCellStyle21.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle21.Format = "N2"
			Me.Column29.DefaultCellStyle = dataGridViewCellStyle21
			Me.Column29.HeaderText = "MRP"
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			Me.Column29.Width = 69
			Me.Column34.HeaderText = "Sale Tax Type"
			Me.Column34.Name = "Column34"
			Me.Column34.[ReadOnly] = True
			Me.Column34.Visible = False
			Me.Column34.Width = 131
			Me.Column43.HeaderText = "Batch"
			Me.Column43.Name = "Column43"
			Me.Column43.[ReadOnly] = True
			Me.Column43.Visible = False
			Me.Column43.Width = 76
			Me.Column44.HeaderText = "Mfg Date"
			Me.Column44.Name = "Column44"
			Me.Column44.[ReadOnly] = True
			Me.Column44.Visible = False
			Me.Column44.Width = 104
			Me.Column45.FillWeight = 120F
			Me.Column45.HeaderText = "Exp Date"
			Me.Column45.Name = "Column45"
			Me.Column45.[ReadOnly] = True
			Me.Column45.Visible = False
			Me.Column45.Width = 99
			Me.Column46.FillWeight = 80F
			Me.Column46.HeaderText = "Size"
			Me.Column46.Name = "Column46"
			Me.Column46.[ReadOnly] = True
			Me.Column46.Visible = False
			Me.Column46.Width = 64
			Me.Column47.HeaderText = "Colour"
			Me.Column47.Name = "Column47"
			Me.Column47.[ReadOnly] = True
			Me.Column47.Visible = False
			Me.Column47.Width = 84
			Me.Column48.HeaderText = "Def Qty"
			Me.Column48.Name = "Column48"
			Me.Column48.[ReadOnly] = True
			Me.Column48.Visible = False
			Me.Column48.Width = 91
			Me.Column50.HeaderText = "IMEI-1"
			Me.Column50.Name = "Column50"
			Me.Column50.[ReadOnly] = True
			Me.Column50.Visible = False
			Me.Column50.Width = 80
			Me.Column51.HeaderText = "IMEI-2"
			Me.Column51.Name = "Column51"
			Me.Column51.[ReadOnly] = True
			Me.Column51.Visible = False
			Me.Column51.Width = 83
			Me.Column54.HeaderText = "SalesMan%"
			Me.Column54.Name = "Column54"
			Me.Column54.[ReadOnly] = True
			Me.Column54.Width = 117
			Me.Column66.HeaderText = "Loyalty Mode"
			Me.Column66.Name = "Column66"
			Me.Column66.[ReadOnly] = True
			Me.Column66.Width = 135
			Me.Column67.HeaderText = "Loyalty Value"
			Me.Column67.Name = "Column67"
			Me.Column67.[ReadOnly] = True
			Me.Column67.Width = 130
			Me.txtProductName.Location = New Global.System.Drawing.Point(121, 96)
			Me.txtProductName.Name = "txtProductName"
			Me.txtProductName.Size = New Global.System.Drawing.Size(269, 20)
			Me.txtProductName.TabIndex = 1676
			Me.txtProductName.TabStop = False
			Me.TextBox1.Location = New Global.System.Drawing.Point(265, 26)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(67, 20)
			Me.TextBox1.TabIndex = 1675
			Me.TextBox1.TabStop = False
			Me.txtQty.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtQty.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtQty.Location = New Global.System.Drawing.Point(195, 194)
			Me.txtQty.Name = "txtQty"
			Me.txtQty.Size = New Global.System.Drawing.Size(80, 26)
			Me.txtQty.TabIndex = 5
			Me.txtReason.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtReason.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtReason.Location = New Global.System.Drawing.Point(297, 194)
			Me.txtReason.Name = "txtReason"
			Me.txtReason.Size = New Global.System.Drawing.Size(349, 26)
			Me.txtReason.TabIndex = 6
			Me.lblQty_S.AutoSize = True
			Me.lblQty_S.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblQty_S.Location = New Global.System.Drawing.Point(417, 96)
			Me.lblQty_S.Name = "lblQty_S"
			Me.lblQty_S.Size = New Global.System.Drawing.Size(30, 17)
			Me.lblQty_S.TabIndex = 337
			Me.lblQty_S.Text = "Qty"
			Me.lblQty_S.Visible = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(417, 78)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(117, 13)
			Me.Label7.TabIndex = 338
			Me.Label7.Text = "Qty. Available in Store :"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.Location = New Global.System.Drawing.Point(293, 171)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(73, 20)
			Me.Label5.TabIndex = 336
			Me.Label5.Text = "Reason :"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(191, 170)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(76, 20)
			Me.Label4.TabIndex = 334
			Me.Label4.Text = "Quantity :"
			Me.gbAdjustment.Controls.Add(Me.rbMinus)
			Me.gbAdjustment.Controls.Add(Me.rbPlus)
			Me.gbAdjustment.Location = New Global.System.Drawing.Point(15, 167)
			Me.gbAdjustment.Name = "gbAdjustment"
			Me.gbAdjustment.Size = New Global.System.Drawing.Size(172, 66)
			Me.gbAdjustment.TabIndex = 4
			Me.gbAdjustment.TabStop = False
			Me.gbAdjustment.Text = "Adjustment Type"
			Me.rbMinus.AutoSize = True
			Me.rbMinus.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.rbMinus.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.rbMinus.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.rbMinus.Location = New Global.System.Drawing.Point(81, 28)
			Me.rbMinus.Name = "rbMinus"
			Me.rbMinus.Size = New Global.System.Drawing.Size(79, 28)
			Me.rbMinus.TabIndex = 1
			Me.rbMinus.TabStop = True
			Me.rbMinus.Text = "Minus"
			Me.rbMinus.UseVisualStyleBackColor = False
			Me.rbPlus.AutoSize = True
			Me.rbPlus.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.rbPlus.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.rbPlus.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.rbPlus.Location = New Global.System.Drawing.Point(11, 28)
			Me.rbPlus.Name = "rbPlus"
			Me.rbPlus.Size = New Global.System.Drawing.Size(64, 28)
			Me.rbPlus.TabIndex = 0
			Me.rbPlus.TabStop = True
			Me.rbPlus.Text = "Plus"
			Me.rbPlus.UseVisualStyleBackColor = False
			Me.btnScanBarcode.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnScanBarcode.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnScanBarcode.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnScanBarcode.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnScanBarcode.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnScanBarcode.ForeColor = Global.System.Drawing.Color.White
			Me.btnScanBarcode.Image = CType(componentResourceManager.GetObject("btnScanBarcode.Image"), Global.System.Drawing.Image)
			Me.btnScanBarcode.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnScanBarcode.Location = New Global.System.Drawing.Point(269, 133)
			Me.btnScanBarcode.Name = "btnScanBarcode"
			Me.btnScanBarcode.Size = New Global.System.Drawing.Size(121, 34)
			Me.btnScanBarcode.TabIndex = 2
			Me.btnScanBarcode.Text = "Scan Barcode"
			Me.btnScanBarcode.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnScanBarcode.UseVisualStyleBackColor = False
			Me.dtpDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDate.Location = New Global.System.Drawing.Point(109, 52)
			Me.dtpDate.Name = "dtpDate"
			Me.dtpDate.Size = New Global.System.Drawing.Size(124, 20)
			Me.dtpDate.TabIndex = 1
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(11, 26)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(79, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Adjustment ID :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(12, 52)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Adjustment Date :"
			Me.txtAdjustmentID.Location = New Global.System.Drawing.Point(109, 26)
			Me.txtAdjustmentID.Name = "txtAdjustmentID"
			Me.txtAdjustmentID.[ReadOnly] = True
			Me.txtAdjustmentID.Size = New Global.System.Drawing.Size(124, 20)
			Me.txtAdjustmentID.TabIndex = 1
			Me.txtAdjustmentID.TabStop = False
			Me.txtProductCode.Location = New Global.System.Drawing.Point(15, 96)
			Me.txtProductCode.Name = "txtProductCode"
			Me.txtProductCode.[ReadOnly] = True
			Me.txtProductCode.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtProductCode.TabIndex = 9
			Me.txtProductCode.TabStop = False
			Me.Label27.AutoSize = True
			Me.Label27.Location = New Global.System.Drawing.Point(11, 121)
			Me.Label27.Name = "Label27"
			Me.Label27.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label27.TabIndex = 326
			Me.Label27.Text = "Barcode :"
			Me.txtBarcode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBarcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBarcode.Location = New Global.System.Drawing.Point(14, 139)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtBarcode.TabIndex = 3
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(12, 78)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label8.TabIndex = 22
			Me.Label8.Text = "Product Code :"
			Me.Label34.AutoSize = True
			Me.Label34.Location = New Global.System.Drawing.Point(118, 77)
			Me.Label34.Name = "Label34"
			Me.Label34.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label34.TabIndex = 332
			Me.Label34.Text = "Product Name :"
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(664, 19)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 402
			Me.lblUser.Text = "Label6"
			Me.txtProductID.Location = New Global.System.Drawing.Point(589, 16)
			Me.txtProductID.Name = "txtProductID"
			Me.txtProductID.[ReadOnly] = True
			Me.txtProductID.Size = New Global.System.Drawing.Size(28, 20)
			Me.txtProductID.TabIndex = 401
			Me.txtProductID.TabStop = False
			Me.txtProductID.Visible = False
			Me.txtQ.Location = New Global.System.Drawing.Point(555, 16)
			Me.txtQ.Name = "txtQ"
			Me.txtQ.[ReadOnly] = True
			Me.txtQ.Size = New Global.System.Drawing.Size(28, 20)
			Me.txtQ.TabIndex = 400
			Me.txtQ.TabStop = False
			Me.txtQ.Visible = False
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(825, 318)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmStockAdjustment_Store"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.dgw4, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.gbAdjustment.ResumeLayout(False)
			Me.gbAdjustment.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040063F5 RID: 25589
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
