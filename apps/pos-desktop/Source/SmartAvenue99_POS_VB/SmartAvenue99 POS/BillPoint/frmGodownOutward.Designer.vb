Namespace BillPoint
	' Token: 0x0200011A RID: 282
		Public Partial Class frmGodownOutward
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06003054 RID: 12372 RVA: 0x001E0354 File Offset: 0x001DE554
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

		' Token: 0x06003055 RID: 12373 RVA: 0x001E03A4 File Offset: 0x001DE5A4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
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
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmGodownOutward))
			Dim dataGridViewCellStyle19 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle20 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle21 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle22 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle23 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.lblCompID = New Global.System.Windows.Forms.Label()
			Me.lblDB = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.lblCurStk = New Global.System.Windows.Forms.Label()
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
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column39 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column41 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column42 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column43 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column44 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column45 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column47 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column48 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnExportExcel = New Global.CButtonLib.CButton()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.CButtonLib.CButton()
			Me.TableLayoutPanel1 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.DateTimePicker2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.btnSearch = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.btnGetData = New Global.CButtonLib.CButton()
			Me.DGVUserData = New Global.System.Windows.Forms.DataGridView()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtSendtoCompID = New Global.System.Windows.Forms.TextBox()
			Me.btnSave = New Global.CButtonLib.CButton()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtNewBCode = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.lblIMEI2 = New Global.System.Windows.Forms.Label()
			Me.lblIMEI1 = New Global.System.Windows.Forms.Label()
			Me.lblExp = New Global.System.Windows.Forms.Label()
			Me.lblMfg = New Global.System.Windows.Forms.Label()
			Me.lblBatch = New Global.System.Windows.Forms.Label()
			Me.lblSize = New Global.System.Windows.Forms.Label()
			Me.lblColour = New Global.System.Windows.Forms.Label()
			Me.lblPTax = New Global.System.Windows.Forms.Label()
			Me.lblSTax = New Global.System.Windows.Forms.Label()
			Me.lblMin = New Global.System.Windows.Forms.Label()
			Me.lblConv = New Global.System.Windows.Forms.Label()
			Me.lblRPrice = New Global.System.Windows.Forms.Label()
			Me.lblWPrice = New Global.System.Windows.Forms.Label()
			Me.lblSAltUnit = New Global.System.Windows.Forms.Label()
			Me.lblSUnit = New Global.System.Windows.Forms.Label()
			Me.lblPUnit = New Global.System.Windows.Forms.Label()
			Me.lblCESS = New Global.System.Windows.Forms.Label()
			Me.lblSGST = New Global.System.Windows.Forms.Label()
			Me.lblCGST = New Global.System.Windows.Forms.Label()
			Me.lblDisc = New Global.System.Windows.Forms.Label()
			Me.lblMRP = New Global.System.Windows.Forms.Label()
			Me.lblPPrice = New Global.System.Windows.Forms.Label()
			Me.lblPartNo = New Global.System.Windows.Forms.Label()
			Me.lblHSN = New Global.System.Windows.Forms.Label()
			Me.lblCat = New Global.System.Windows.Forms.Label()
			Me.lblPCode = New Global.System.Windows.Forms.Label()
			Me.lblUnit = New Global.System.Windows.Forms.Label()
			Me.lblPID = New Global.System.Windows.Forms.Label()
			Me.txtBCode = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtQty = New Global.System.Windows.Forms.TextBox()
			Me.txtProductName = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ContextMenuStrip1 = New Global.System.Windows.Forms.ContextMenuStrip(Me.components)
			Me.DeleteToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Panel1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw4, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.TableLayoutPanel1.SuspendLayout()
			CType(Me.DGVUserData, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.ContextMenuStrip1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.lblCompID)
			Me.Panel1.Controls.Add(Me.lblDB)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(7, 7)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(880, 482)
			Me.Panel1.TabIndex = 0
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(828, 18)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1720
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.lblCompID.AutoSize = True
			Me.lblCompID.Location = New Global.System.Drawing.Point(6, 18)
			Me.lblCompID.Name = "lblCompID"
			Me.lblCompID.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCompID.TabIndex = 1719
			Me.lblCompID.Text = "lblCompID"
			Me.lblCompID.Visible = False
			Me.lblDB.AutoSize = True
			Me.lblDB.Location = New Global.System.Drawing.Point(784, 18)
			Me.lblDB.Name = "lblDB"
			Me.lblDB.Size = New Global.System.Drawing.Size(32, 13)
			Me.lblDB.TabIndex = 1718
			Me.lblDB.Text = "lblDB"
			Me.lblDB.Visible = False
			Me.GroupBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GroupBox1.Controls.Add(Me.lblCurStk)
			Me.GroupBox1.Controls.Add(Me.dgw4)
			Me.GroupBox1.Controls.Add(Me.btnExportExcel)
			Me.GroupBox1.Controls.Add(Me.ComboBox1)
			Me.GroupBox1.Controls.Add(Me.Label10)
			Me.GroupBox1.Controls.Add(Me.Button2)
			Me.GroupBox1.Controls.Add(Me.btnReset)
			Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
			Me.GroupBox1.Controls.Add(Me.Button1)
			Me.GroupBox1.Controls.Add(Me.btnGetData)
			Me.GroupBox1.Controls.Add(Me.DGVUserData)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.txtSendtoCompID)
			Me.GroupBox1.Controls.Add(Me.btnSave)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.txtNewBCode)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.lblIMEI2)
			Me.GroupBox1.Controls.Add(Me.lblIMEI1)
			Me.GroupBox1.Controls.Add(Me.lblExp)
			Me.GroupBox1.Controls.Add(Me.lblMfg)
			Me.GroupBox1.Controls.Add(Me.lblBatch)
			Me.GroupBox1.Controls.Add(Me.lblSize)
			Me.GroupBox1.Controls.Add(Me.lblColour)
			Me.GroupBox1.Controls.Add(Me.lblPTax)
			Me.GroupBox1.Controls.Add(Me.lblSTax)
			Me.GroupBox1.Controls.Add(Me.lblMin)
			Me.GroupBox1.Controls.Add(Me.lblConv)
			Me.GroupBox1.Controls.Add(Me.lblRPrice)
			Me.GroupBox1.Controls.Add(Me.lblWPrice)
			Me.GroupBox1.Controls.Add(Me.lblSAltUnit)
			Me.GroupBox1.Controls.Add(Me.lblSUnit)
			Me.GroupBox1.Controls.Add(Me.lblPUnit)
			Me.GroupBox1.Controls.Add(Me.lblCESS)
			Me.GroupBox1.Controls.Add(Me.lblSGST)
			Me.GroupBox1.Controls.Add(Me.lblCGST)
			Me.GroupBox1.Controls.Add(Me.lblDisc)
			Me.GroupBox1.Controls.Add(Me.lblMRP)
			Me.GroupBox1.Controls.Add(Me.lblPPrice)
			Me.GroupBox1.Controls.Add(Me.lblPartNo)
			Me.GroupBox1.Controls.Add(Me.lblHSN)
			Me.GroupBox1.Controls.Add(Me.lblCat)
			Me.GroupBox1.Controls.Add(Me.lblPCode)
			Me.GroupBox1.Controls.Add(Me.lblUnit)
			Me.GroupBox1.Controls.Add(Me.lblPID)
			Me.GroupBox1.Controls.Add(Me.txtBCode)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.txtQty)
			Me.GroupBox1.Controls.Add(Me.txtProductName)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 40)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(869, 436)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.lblCurStk.AutoSize = True
			Me.lblCurStk.Location = New Global.System.Drawing.Point(174, 10)
			Me.lblCurStk.Name = "lblCurStk"
			Me.lblCurStk.Size = New Global.System.Drawing.Size(49, 13)
			Me.lblCurStk.TabIndex = 1763
			Me.lblCurStk.Text = "lblCurStk"
			Me.lblCurStk.Visible = False
			Me.dgw4.AllowUserToAddRows = False
			Me.dgw4.AllowUserToResizeColumns = False
			Me.dgw4.AllowUserToResizeRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw4.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw4.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw4.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw4.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgw4.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw4.ColumnHeadersHeight = 20
			Me.dgw4.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgw4.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column25, Me.Column39, Me.Column41, Me.Column42, Me.Column43, Me.Column44, Me.Column45, Me.Column47, Me.Column48 })
			Me.dgw4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw4.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw4.EnableHeadersVisualStyles = False
			Me.dgw4.GridColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.dgw4.Location = New Global.System.Drawing.Point(107, 45)
			Me.dgw4.MultiSelect = False
			Me.dgw4.Name = "dgw4"
			Me.dgw4.[ReadOnly] = True
			Me.dgw4.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.YellowGreen
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw4.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw4.RowHeadersVisible = False
			Me.dgw4.RowHeadersWidth = 25
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw4.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw4.RowTemplate.Height = 25
			Me.dgw4.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw4.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw4.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw4.Size = New Global.System.Drawing.Size(482, 136)
			Me.dgw4.TabIndex = 1714
			Me.dgw4.TabStop = False
			Me.dgw4.Visible = False
			Me.DataGridViewTextBoxColumn23.FillWeight = 300F
			Me.DataGridViewTextBoxColumn23.HeaderText = "PID"
			Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
			Me.DataGridViewTextBoxColumn23.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn23.Visible = False
			Me.DataGridViewTextBoxColumn24.HeaderText = "Product Code"
			Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
			Me.DataGridViewTextBoxColumn24.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn24.Visible = False
			Me.DataGridViewTextBoxColumn25.FillWeight = 300F
			Me.DataGridViewTextBoxColumn25.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
			Me.DataGridViewTextBoxColumn25.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn26.HeaderText = "HSN Code"
			Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
			Me.DataGridViewTextBoxColumn26.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn26.Visible = False
			Me.DataGridViewTextBoxColumn27.HeaderText = "Part/Group"
			Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
			Me.DataGridViewTextBoxColumn27.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn27.Visible = False
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			Me.DataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle6
			Me.DataGridViewTextBoxColumn28.FillWeight = 130F
			Me.DataGridViewTextBoxColumn28.HeaderText = "Barcode"
			Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
			Me.DataGridViewTextBoxColumn28.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			Me.DataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle7
			Me.DataGridViewTextBoxColumn29.HeaderText = "Purchase Price"
			Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
			Me.DataGridViewTextBoxColumn29.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn29.Visible = False
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			dataGridViewCellStyle8.NullValue = Nothing
			Me.DataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle8
			Me.DataGridViewTextBoxColumn30.HeaderText = "MRP"
			Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
			Me.DataGridViewTextBoxColumn30.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn30.Visible = False
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn31.DefaultCellStyle = dataGridViewCellStyle9
			Me.DataGridViewTextBoxColumn31.HeaderText = "Discount"
			Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
			Me.DataGridViewTextBoxColumn31.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn31.Visible = False
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle10
			Me.DataGridViewTextBoxColumn32.HeaderText = "CGST"
			Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
			Me.DataGridViewTextBoxColumn32.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn32.Visible = False
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn33.DefaultCellStyle = dataGridViewCellStyle11
			Me.DataGridViewTextBoxColumn33.HeaderText = "SGST"
			Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
			Me.DataGridViewTextBoxColumn33.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn33.Visible = False
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle12
			Me.DataGridViewTextBoxColumn34.HeaderText = "CESS"
			Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
			Me.DataGridViewTextBoxColumn34.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn34.Visible = False
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle13
			Me.DataGridViewTextBoxColumn35.HeaderText = "Current Stock"
			Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
			Me.DataGridViewTextBoxColumn35.[ReadOnly] = True
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle14
			Me.DataGridViewTextBoxColumn36.HeaderText = "Main Unit"
			Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
			Me.DataGridViewTextBoxColumn36.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn36.Visible = False
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle15
			Me.DataGridViewTextBoxColumn37.HeaderText = "Wholesale Sale Price"
			Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
			Me.DataGridViewTextBoxColumn37.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn37.Visible = False
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle16.Format = "N2"
			dataGridViewCellStyle16.NullValue = Nothing
			Me.DataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle16
			Me.DataGridViewTextBoxColumn38.HeaderText = "Retail Sale Price"
			Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
			Me.DataGridViewTextBoxColumn38.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn38.Visible = False
			Me.DataGridViewTextBoxColumn39.HeaderText = "Category"
			Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
			Me.DataGridViewTextBoxColumn39.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn39.Visible = False
			Me.DataGridViewTextBoxColumn40.HeaderText = "Sub Category"
			Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
			Me.DataGridViewTextBoxColumn40.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn40.Visible = False
			Me.Column20.HeaderText = "AltUnit"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			Me.Column20.Visible = False
			Me.Column21.HeaderText = "Con Value"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			Me.Column21.Visible = False
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column22.DefaultCellStyle = dataGridViewCellStyle17
			Me.Column22.HeaderText = "Damage Qty"
			Me.Column22.Name = "Column22"
			Me.Column22.[ReadOnly] = True
			Me.Column22.Visible = False
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column23.DefaultCellStyle = dataGridViewCellStyle18
			Me.Column23.HeaderText = "Min Stock Limit"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			Me.Column23.Visible = False
			Me.Column25.HeaderText = "Purchase Tax Type"
			Me.Column25.Name = "Column25"
			Me.Column25.[ReadOnly] = True
			Me.Column25.Visible = False
			Me.Column39.HeaderText = "Category"
			Me.Column39.Name = "Column39"
			Me.Column39.[ReadOnly] = True
			Me.Column39.Visible = False
			Me.Column41.HeaderText = "Colour"
			Me.Column41.Name = "Column41"
			Me.Column41.[ReadOnly] = True
			Me.Column41.Visible = False
			Me.Column42.HeaderText = "Size"
			Me.Column42.Name = "Column42"
			Me.Column42.[ReadOnly] = True
			Me.Column42.Visible = False
			Me.Column43.HeaderText = "Batch"
			Me.Column43.Name = "Column43"
			Me.Column43.[ReadOnly] = True
			Me.Column43.Visible = False
			Me.Column44.HeaderText = "Mfg"
			Me.Column44.Name = "Column44"
			Me.Column44.[ReadOnly] = True
			Me.Column44.Visible = False
			Me.Column45.HeaderText = "Exp"
			Me.Column45.Name = "Column45"
			Me.Column45.[ReadOnly] = True
			Me.Column45.Visible = False
			Me.Column47.HeaderText = "IMEI-1"
			Me.Column47.Name = "Column47"
			Me.Column47.[ReadOnly] = True
			Me.Column47.Visible = False
			Me.Column48.HeaderText = "IMEI-2"
			Me.Column48.Name = "Column48"
			Me.Column48.[ReadOnly] = True
			Me.Column48.Visible = False
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnExportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExportExcel.Corners.All = 5
			Me.btnExportExcel.Corners.LowerLeft = 5
			Me.btnExportExcel.Corners.LowerRight = 5
			Me.btnExportExcel.Corners.UpperLeft = 5
			Me.btnExportExcel.Corners.UpperRight = 5
			Me.btnExportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnExportExcel.DesignerSelected = False
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.ImageIndex = 0
			Me.btnExportExcel.ImageSize = New Global.System.Drawing.Size(28, 28)
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(762, 100)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(101, 41)
			Me.btnExportExcel.TabIndex = 1759
			Me.btnExportExcel.TabStop = False
			Me.btnExportExcel.Text = "Export"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Transferred", "Accepted", "Rejected" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(514, 201)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(148, 25)
			Me.ComboBox1.TabIndex = 1757
			Me.ComboBox1.TabStop = False
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.Label10.Location = New Global.System.Drawing.Point(511, 181)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(117, 17)
			Me.Label10.TabIndex = 1758
			Me.Label10.Text = "Search By Status :"
			Me.Button2.Location = New Global.System.Drawing.Point(459, 17)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button2.TabIndex = 1753
			Me.Button2.Text = "Delete All"
			Me.Button2.UseVisualStyleBackColor = True
			Me.Button2.Visible = False
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Corners.All = 5
			Me.btnReset.Corners.LowerLeft = 5
			Me.btnReset.Corners.LowerRight = 5
			Me.btnReset.Corners.UpperLeft = 5
			Me.btnReset.Corners.UpperRight = 5
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.DesignerSelected = False
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.ImageIndex = 0
			Me.btnReset.ImageSize = New Global.System.Drawing.Size(32, 32)
			Me.btnReset.Location = New Global.System.Drawing.Point(762, 56)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(101, 41)
			Me.btnReset.TabIndex = 4
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.TableLayoutPanel1.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 192)
			Me.TableLayoutPanel1.CellBorderStyle = Global.System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
			Me.TableLayoutPanel1.ColumnCount = 5
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 10F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 15F))
			Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker2, 3, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label9, 2, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker1, 1, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.btnSearch, 4, 0)
			Me.TableLayoutPanel1.Location = New Global.System.Drawing.Point(3, 186)
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 1
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 100F))
			Me.TableLayoutPanel1.Size = New Global.System.Drawing.Size(503, 40)
			Me.TableLayoutPanel1.TabIndex = 6
			Me.DateTimePicker2.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.DateTimePicker2.CalendarFont = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker2.CustomFormat = "dd-MM-yyyy"
			Me.DateTimePicker2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker2.Location = New Global.System.Drawing.Point(303, 6)
			Me.DateTimePicker2.Margin = New Global.System.Windows.Forms.Padding(2, 4, 2, 4)
			Me.DateTimePicker2.Name = "DateTimePicker2"
			Me.DateTimePicker2.Size = New Global.System.Drawing.Size(120, 29)
			Me.DateTimePicker2.TabIndex = 1
			Me.Label9.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label9.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.Black
			Me.Label9.Location = New Global.System.Drawing.Point(253, 1)
			Me.Label9.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(45, 38)
			Me.Label9.TabIndex = 35
			Me.Label9.Text = "To"
			Me.Label9.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label7.AutoSize = True
			Me.Label7.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label7.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.ForeColor = Global.System.Drawing.Color.Black
			Me.Label7.Location = New Global.System.Drawing.Point(3, 1)
			Me.Label7.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(120, 38)
			Me.Label7.TabIndex = 3
			Me.Label7.Text = "Entry Date From"
			Me.Label7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.DateTimePicker1.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.DateTimePicker1.CalendarFont = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker1.CustomFormat = "dd-MM-yyyy"
			Me.DateTimePicker1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(128, 6)
			Me.DateTimePicker1.Margin = New Global.System.Windows.Forms.Padding(2, 4, 2, 4)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(120, 29)
			Me.DateTimePicker1.TabIndex = 0
			Me.btnSearch.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSearch.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnSearch.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.btnSearch.Location = New Global.System.Drawing.Point(429, 4)
			Me.btnSearch.Name = "btnSearch"
			Me.btnSearch.Size = New Global.System.Drawing.Size(70, 32)
			Me.btnSearch.TabIndex = 2
			Me.btnSearch.Text = "Search"
			Me.btnSearch.UseVisualStyleBackColor = True
			Me.Button1.Location = New Global.System.Drawing.Point(540, 17)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button1.TabIndex = 1752
			Me.Button1.Text = "Update"
			Me.Button1.UseVisualStyleBackColor = True
			Me.Button1.Visible = False
			Me.btnGetData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGetData.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnGetData.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnGetData.Corners.All = 5
			Me.btnGetData.Corners.LowerLeft = 5
			Me.btnGetData.Corners.LowerRight = 5
			Me.btnGetData.Corners.UpperLeft = 5
			Me.btnGetData.Corners.UpperRight = 5
			Me.btnGetData.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnGetData.DesignerSelected = False
			Me.btnGetData.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnGetData.ImageIndex = 0
			Me.btnGetData.ImageSize = New Global.System.Drawing.Size(32, 32)
			Me.btnGetData.Location = New Global.System.Drawing.Point(762, 145)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(101, 81)
			Me.btnGetData.TabIndex = 5
			Me.btnGetData.Text = "Show &Data By Company ID / Bracnch ID"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.DGVUserData.AllowUserToAddRows = False
			Me.DGVUserData.AllowUserToDeleteRows = False
			dataGridViewCellStyle19.BackColor = Global.System.Drawing.Color.Cornsilk
			Me.DGVUserData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19
			Me.DGVUserData.BackgroundColor = Global.System.Drawing.Color.White
			Me.DGVUserData.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			dataGridViewCellStyle20.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle20.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle20.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle20.SelectionBackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle20.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle20.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DGVUserData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20
			Me.DGVUserData.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			dataGridViewCellStyle21.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle21.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle21.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle21.SelectionBackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle21.SelectionForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle21.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DGVUserData.DefaultCellStyle = dataGridViewCellStyle21
			Me.DGVUserData.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.DGVUserData.GridColor = Global.System.Drawing.Color.DeepSkyBlue
			Me.DGVUserData.Location = New Global.System.Drawing.Point(3, 229)
			Me.DGVUserData.Margin = New Global.System.Windows.Forms.Padding(2, 4, 2, 4)
			Me.DGVUserData.Name = "DGVUserData"
			Me.DGVUserData.[ReadOnly] = True
			dataGridViewCellStyle22.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle22.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle22.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle22.SelectionBackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle22.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle22.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DGVUserData.RowHeadersDefaultCellStyle = dataGridViewCellStyle22
			dataGridViewCellStyle23.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle23.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle23.SelectionBackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle23.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DGVUserData.RowsDefaultCellStyle = dataGridViewCellStyle23
			Me.DGVUserData.RowTemplate.Height = 30
			Me.DGVUserData.RowTemplate.[ReadOnly] = True
			Me.DGVUserData.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DGVUserData.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DGVUserData.Size = New Global.System.Drawing.Size(863, 204)
			Me.DGVUserData.TabIndex = 1750
			Me.DGVUserData.TabStop = False
			Me.Label6.Location = New Global.System.Drawing.Point(20, 136)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(78, 48)
			Me.Label6.TabIndex = 1749
			Me.Label6.Text = "Receiver (Company / Branch ID)  :"
			Me.txtSendtoCompID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSendtoCompID.Location = New Global.System.Drawing.Point(107, 136)
			Me.txtSendtoCompID.Name = "txtSendtoCompID"
			Me.txtSendtoCompID.Size = New Global.System.Drawing.Size(277, 20)
			Me.txtSendtoCompID.TabIndex = 2
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnSave.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSave.Corners.All = 5
			Me.btnSave.Corners.LowerLeft = 5
			Me.btnSave.Corners.LowerRight = 5
			Me.btnSave.Corners.UpperLeft = 5
			Me.btnSave.Corners.UpperRight = 5
			Me.btnSave.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSave.DesignerSelected = False
			Me.btnSave.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.ImageIndex = 0
			Me.btnSave.ImageSize = New Global.System.Drawing.Size(32, 32)
			Me.btnSave.Location = New Global.System.Drawing.Point(762, 13)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(101, 40)
			Me.btnSave.TabIndex = 3
			Me.btnSave.Text = "&Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 6.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label3.Location = New Global.System.Drawing.Point(104, 88)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(200, 11)
			Me.Label3.TabIndex = 1746
			Me.Label3.Text = "New Barcode Format (Barcode No * Token No)"
			Me.txtNewBCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNewBCode.Location = New Global.System.Drawing.Point(107, 103)
			Me.txtNewBCode.Name = "txtNewBCode"
			Me.txtNewBCode.[ReadOnly] = True
			Me.txtNewBCode.Size = New Global.System.Drawing.Size(277, 20)
			Me.txtNewBCode.TabIndex = 1745
			Me.txtNewBCode.TabStop = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(20, 103)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label2.TabIndex = 1744
			Me.Label2.Text = "New Barcode :"
			Me.lblIMEI2.AutoSize = True
			Me.lblIMEI2.Location = New Global.System.Drawing.Point(708, 356)
			Me.lblIMEI2.Name = "lblIMEI2"
			Me.lblIMEI2.Size = New Global.System.Drawing.Size(45, 13)
			Me.lblIMEI2.TabIndex = 1743
			Me.lblIMEI2.Text = "lblIMEI2"
			Me.lblIMEI2.Visible = False
			Me.lblIMEI1.AutoSize = True
			Me.lblIMEI1.Location = New Global.System.Drawing.Point(708, 340)
			Me.lblIMEI1.Name = "lblIMEI1"
			Me.lblIMEI1.Size = New Global.System.Drawing.Size(45, 13)
			Me.lblIMEI1.TabIndex = 1742
			Me.lblIMEI1.Text = "lblIMEI1"
			Me.lblIMEI1.Visible = False
			Me.lblExp.AutoSize = True
			Me.lblExp.Location = New Global.System.Drawing.Point(708, 324)
			Me.lblExp.Name = "lblExp"
			Me.lblExp.Size = New Global.System.Drawing.Size(35, 13)
			Me.lblExp.TabIndex = 1741
			Me.lblExp.Text = "lblExp"
			Me.lblExp.Visible = False
			Me.lblMfg.AutoSize = True
			Me.lblMfg.Location = New Global.System.Drawing.Point(708, 309)
			Me.lblMfg.Name = "lblMfg"
			Me.lblMfg.Size = New Global.System.Drawing.Size(35, 13)
			Me.lblMfg.TabIndex = 1740
			Me.lblMfg.Text = "lblMfg"
			Me.lblMfg.Visible = False
			Me.lblBatch.AutoSize = True
			Me.lblBatch.Location = New Global.System.Drawing.Point(708, 291)
			Me.lblBatch.Name = "lblBatch"
			Me.lblBatch.Size = New Global.System.Drawing.Size(45, 13)
			Me.lblBatch.TabIndex = 1739
			Me.lblBatch.Text = "lblBatch"
			Me.lblBatch.Visible = False
			Me.lblSize.AutoSize = True
			Me.lblSize.Location = New Global.System.Drawing.Point(708, 271)
			Me.lblSize.Name = "lblSize"
			Me.lblSize.Size = New Global.System.Drawing.Size(37, 13)
			Me.lblSize.TabIndex = 1738
			Me.lblSize.Text = "lblSize"
			Me.lblSize.Visible = False
			Me.lblColour.AutoSize = True
			Me.lblColour.Location = New Global.System.Drawing.Point(708, 252)
			Me.lblColour.Name = "lblColour"
			Me.lblColour.Size = New Global.System.Drawing.Size(47, 13)
			Me.lblColour.TabIndex = 1737
			Me.lblColour.Text = "lblColour"
			Me.lblColour.Visible = False
			Me.lblPTax.AutoSize = True
			Me.lblPTax.Location = New Global.System.Drawing.Point(622, 333)
			Me.lblPTax.Name = "lblPTax"
			Me.lblPTax.Size = New Global.System.Drawing.Size(42, 13)
			Me.lblPTax.TabIndex = 1736
			Me.lblPTax.Text = "lblPTax"
			Me.lblPTax.Visible = False
			Me.lblSTax.AutoSize = True
			Me.lblSTax.Location = New Global.System.Drawing.Point(622, 316)
			Me.lblSTax.Name = "lblSTax"
			Me.lblSTax.Size = New Global.System.Drawing.Size(42, 13)
			Me.lblSTax.TabIndex = 1735
			Me.lblSTax.Text = "lblSTax"
			Me.lblSTax.Visible = False
			Me.lblMin.AutoSize = True
			Me.lblMin.Location = New Global.System.Drawing.Point(625, 291)
			Me.lblMin.Name = "lblMin"
			Me.lblMin.Size = New Global.System.Drawing.Size(34, 13)
			Me.lblMin.TabIndex = 1734
			Me.lblMin.Text = "lblMin"
			Me.lblMin.Visible = False
			Me.lblConv.AutoSize = True
			Me.lblConv.Location = New Global.System.Drawing.Point(623, 271)
			Me.lblConv.Name = "lblConv"
			Me.lblConv.Size = New Global.System.Drawing.Size(42, 13)
			Me.lblConv.TabIndex = 1733
			Me.lblConv.Text = "lblConv"
			Me.lblConv.Visible = False
			Me.lblRPrice.AutoSize = True
			Me.lblRPrice.Location = New Global.System.Drawing.Point(699, 106)
			Me.lblRPrice.Name = "lblRPrice"
			Me.lblRPrice.Size = New Global.System.Drawing.Size(49, 13)
			Me.lblRPrice.TabIndex = 1732
			Me.lblRPrice.Text = "lblRPrice"
			Me.lblRPrice.Visible = False
			Me.lblWPrice.AutoSize = True
			Me.lblWPrice.Location = New Global.System.Drawing.Point(699, 88)
			Me.lblWPrice.Name = "lblWPrice"
			Me.lblWPrice.Size = New Global.System.Drawing.Size(52, 13)
			Me.lblWPrice.TabIndex = 1731
			Me.lblWPrice.Text = "lblWPrice"
			Me.lblWPrice.Visible = False
			Me.lblSAltUnit.AutoSize = True
			Me.lblSAltUnit.Location = New Global.System.Drawing.Point(623, 254)
			Me.lblSAltUnit.Name = "lblSAltUnit"
			Me.lblSAltUnit.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblSAltUnit.TabIndex = 1730
			Me.lblSAltUnit.Text = "lblSAltUnit"
			Me.lblSAltUnit.Visible = False
			Me.lblSUnit.AutoSize = True
			Me.lblSUnit.Location = New Global.System.Drawing.Point(622, 232)
			Me.lblSUnit.Name = "lblSUnit"
			Me.lblSUnit.Size = New Global.System.Drawing.Size(43, 13)
			Me.lblSUnit.TabIndex = 1729
			Me.lblSUnit.Text = "lblSUnit"
			Me.lblSUnit.Visible = False
			Me.lblPUnit.AutoSize = True
			Me.lblPUnit.Location = New Global.System.Drawing.Point(622, 211)
			Me.lblPUnit.Name = "lblPUnit"
			Me.lblPUnit.Size = New Global.System.Drawing.Size(43, 13)
			Me.lblPUnit.TabIndex = 1728
			Me.lblPUnit.Text = "lblPUnit"
			Me.lblPUnit.Visible = False
			Me.lblCESS.AutoSize = True
			Me.lblCESS.Location = New Global.System.Drawing.Point(625, 188)
			Me.lblCESS.Name = "lblCESS"
			Me.lblCESS.Size = New Global.System.Drawing.Size(45, 13)
			Me.lblCESS.TabIndex = 1727
			Me.lblCESS.Text = "lblCESS"
			Me.lblCESS.Visible = False
			Me.lblSGST.AutoSize = True
			Me.lblSGST.Location = New Global.System.Drawing.Point(623, 171)
			Me.lblSGST.Name = "lblSGST"
			Me.lblSGST.Size = New Global.System.Drawing.Size(46, 13)
			Me.lblSGST.TabIndex = 1726
			Me.lblSGST.Text = "lblSGST"
			Me.lblSGST.Visible = False
			Me.lblCGST.AutoSize = True
			Me.lblCGST.Location = New Global.System.Drawing.Point(623, 152)
			Me.lblCGST.Name = "lblCGST"
			Me.lblCGST.Size = New Global.System.Drawing.Size(46, 13)
			Me.lblCGST.TabIndex = 1725
			Me.lblCGST.Text = "lblCGST"
			Me.lblCGST.Visible = False
			Me.lblDisc.AutoSize = True
			Me.lblDisc.Location = New Global.System.Drawing.Point(623, 124)
			Me.lblDisc.Name = "lblDisc"
			Me.lblDisc.Size = New Global.System.Drawing.Size(38, 13)
			Me.lblDisc.TabIndex = 1724
			Me.lblDisc.Text = "lblDisc"
			Me.lblDisc.Visible = False
			Me.lblMRP.AutoSize = True
			Me.lblMRP.Location = New Global.System.Drawing.Point(623, 106)
			Me.lblMRP.Name = "lblMRP"
			Me.lblMRP.Size = New Global.System.Drawing.Size(41, 13)
			Me.lblMRP.TabIndex = 1723
			Me.lblMRP.Text = "lblMRP"
			Me.lblMRP.Visible = False
			Me.lblPPrice.AutoSize = True
			Me.lblPPrice.Location = New Global.System.Drawing.Point(622, 88)
			Me.lblPPrice.Name = "lblPPrice"
			Me.lblPPrice.Size = New Global.System.Drawing.Size(48, 13)
			Me.lblPPrice.TabIndex = 1722
			Me.lblPPrice.Text = "lblPPrice"
			Me.lblPPrice.Visible = False
			Me.lblPartNo.AutoSize = True
			Me.lblPartNo.Location = New Global.System.Drawing.Point(623, 63)
			Me.lblPartNo.Name = "lblPartNo"
			Me.lblPartNo.Size = New Global.System.Drawing.Size(50, 13)
			Me.lblPartNo.TabIndex = 1721
			Me.lblPartNo.Text = "lblPartNo"
			Me.lblPartNo.Visible = False
			Me.lblHSN.AutoSize = True
			Me.lblHSN.Location = New Global.System.Drawing.Point(622, 45)
			Me.lblHSN.Name = "lblHSN"
			Me.lblHSN.Size = New Global.System.Drawing.Size(40, 13)
			Me.lblHSN.TabIndex = 1720
			Me.lblHSN.Text = "lblHSN"
			Me.lblHSN.Visible = False
			Me.lblCat.AutoSize = True
			Me.lblCat.Location = New Global.System.Drawing.Point(622, 353)
			Me.lblCat.Name = "lblCat"
			Me.lblCat.Size = New Global.System.Drawing.Size(33, 13)
			Me.lblCat.TabIndex = 1719
			Me.lblCat.Text = "lblCat"
			Me.lblCat.Visible = False
			Me.lblPCode.AutoSize = True
			Me.lblPCode.Location = New Global.System.Drawing.Point(622, 25)
			Me.lblPCode.Name = "lblPCode"
			Me.lblPCode.Size = New Global.System.Drawing.Size(49, 13)
			Me.lblPCode.TabIndex = 1718
			Me.lblPCode.Text = "lblPCode"
			Me.lblPCode.Visible = False
			Me.lblUnit.AutoSize = True
			Me.lblUnit.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblUnit.Location = New Global.System.Drawing.Point(388, 58)
			Me.lblUnit.Name = "lblUnit"
			Me.lblUnit.Size = New Global.System.Drawing.Size(19, 13)
			Me.lblUnit.TabIndex = 1717
			Me.lblUnit.Text = "..."
			Me.lblPID.AutoSize = True
			Me.lblPID.Location = New Global.System.Drawing.Point(390, 25)
			Me.lblPID.Name = "lblPID"
			Me.lblPID.Size = New Global.System.Drawing.Size(35, 13)
			Me.lblPID.TabIndex = 1716
			Me.lblPID.Text = "lblPID"
			Me.lblPID.Visible = False
			Me.txtBCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBCode.Location = New Global.System.Drawing.Point(107, 55)
			Me.txtBCode.Name = "txtBCode"
			Me.txtBCode.[ReadOnly] = True
			Me.txtBCode.Size = New Global.System.Drawing.Size(131, 20)
			Me.txtBCode.TabIndex = 1715
			Me.txtBCode.TabStop = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(20, 25)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label5.TabIndex = 1713
			Me.Label5.Text = "Product Name :"
			Me.txtQty.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtQty.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtQty.Location = New Global.System.Drawing.Point(302, 55)
			Me.txtQty.Name = "txtQty"
			Me.txtQty.Size = New Global.System.Drawing.Size(82, 21)
			Me.txtQty.TabIndex = 1
			Me.txtQty.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtProductName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtProductName.Location = New Global.System.Drawing.Point(107, 25)
			Me.txtProductName.Name = "txtProductName"
			Me.txtProductName.Size = New Global.System.Drawing.Size(277, 20)
			Me.txtProductName.TabIndex = 0
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(244, 55)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label4.TabIndex = 1712
			Me.Label4.Text = "Quantity :"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(20, 55)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label8.TabIndex = 1711
			Me.Label8.Text = "Barcode :"
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.Red
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Black", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(4, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(869, 33)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "Outward Stock Transfer"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.ContextMenuStrip1.Items.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.DeleteToolStripMenuItem })
			Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
			Me.ContextMenuStrip1.Size = New Global.System.Drawing.Size(108, 26)
			Me.DeleteToolStripMenuItem.BackColor = Global.System.Drawing.Color.Red
			Me.DeleteToolStripMenuItem.Image = CType(componentResourceManager.GetObject("DeleteToolStripMenuItem.Image"), Global.System.Drawing.Image)
			Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
			Me.DeleteToolStripMenuItem.Size = New Global.System.Drawing.Size(107, 22)
			Me.DeleteToolStripMenuItem.Text = "Delete"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(894, 496)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmGodownOutward"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.dgw4, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.TableLayoutPanel1.ResumeLayout(False)
			Me.TableLayoutPanel1.PerformLayout()
			CType(Me.DGVUserData, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.ContextMenuStrip1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040014AC RID: 5292
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
