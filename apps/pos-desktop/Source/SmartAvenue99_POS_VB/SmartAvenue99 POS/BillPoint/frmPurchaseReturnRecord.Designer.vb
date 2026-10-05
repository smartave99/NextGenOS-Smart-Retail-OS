Namespace BillPoint
	' Token: 0x02000595 RID: 1429
		Public Partial Class frmPurchaseReturnRecord
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060118FB RID: 71931 RVA: 0x00A2E6A0 File Offset: 0x00A2C8A0
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

		' Token: 0x060118FC RID: 71932 RVA: 0x00A2E6F0 File Offset: 0x00A2C8F0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmPurchaseReturnRecord))
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
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.lblTotalAmount = New Global.System.Windows.Forms.Label()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.txtSupplierName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel1.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.lblTotalAmount)
			Me.Panel1.Controls.Add(Me.lblSet)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1077, 633)
			Me.Panel1.TabIndex = 2
			Me.lblTotalAmount.AutoSize = True
			Me.lblTotalAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblTotalAmount.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblTotalAmount.Location = New Global.System.Drawing.Point(793, 594)
			Me.lblTotalAmount.Name = "lblTotalAmount"
			Me.lblTotalAmount.Size = New Global.System.Drawing.Size(89, 15)
			Me.lblTotalAmount.TabIndex = 58
			Me.lblTotalAmount.Text = "lblTotalAmount"
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(888, 22)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 57
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, -3)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1077, 41)
			Me.Label1.TabIndex = 56
			Me.Label1.Text = "Purchase Return Record"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.GelButton2)
			Me.Panel5.Controls.Add(Me.GelButton1)
			Me.Panel5.Location = New Global.System.Drawing.Point(576, 44)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(265, 70)
			Me.Panel5.TabIndex = 3
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(4, 14)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(123, 43)
			Me.GelButton2.TabIndex = 527
			Me.GelButton2.Text = "&Reset"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(132, 14)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(123, 43)
			Me.GelButton1.TabIndex = 528
			Me.GelButton1.Text = "&Export Excel"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.dtpDateTo)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.GelButton3)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.dtpDateFrom)
			Me.Panel4.Location = New Global.System.Drawing.Point(182, 44)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(388, 70)
			Me.Panel4.TabIndex = 2
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(153, 27)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 14
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(150, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(291, 22)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(74, 30)
			Me.GelButton3.TabIndex = 526
			Me.GelButton3.Text = "Get Data"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(10, 8)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(13, 27)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 11
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.txtSupplierName)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(10, 44)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(168, 70)
			Me.Panel3.TabIndex = 1
			Me.txtSupplierName.BackColor = Global.System.Drawing.Color.White
			Me.txtSupplierName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSupplierName.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtSupplierName.Name = "txtSupplierName"
			Me.txtSupplierName.Size = New Global.System.Drawing.Size(144, 21)
			Me.txtSupplierName.TabIndex = 10
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(134, 13)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Search By Supplier Name :"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column28, Me.Column2, Me.Column4, Me.Column3, Me.Column20, Me.Column21, Me.Column5, Me.Column6, Me.Column12, Me.Column13, Me.Column14, Me.Column24, Me.Column25, Me.Column8, Me.Column9, Me.Column18, Me.Column19, Me.Column7, Me.Column10, Me.Column11, Me.Column15, Me.Column16, Me.Column17, Me.Column22, Me.Column23 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(9, 123)
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
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 25
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1055, 489)
			Me.dgw.TabIndex = 43
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "PR ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column28.HeaderText = "PR No."
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			dataGridViewCellStyle6.Format = "dd/MM/yyyy"
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column2.HeaderText = "PR Date"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column4.HeaderText = "Tax Type"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column3.HeaderText = "Purchase ID"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Visible = False
			Me.Column20.HeaderText = "Purchase Invoice No."
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			dataGridViewCellStyle7.Format = "dd/MM/yyyy"
			Me.Column21.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column21.HeaderText = "Purchase Date"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			Me.Column5.HeaderText = "Supplier ID"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Supplier Name"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column12.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column12.HeaderText = "Sub Total"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column13.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column13.HeaderText = "CGST"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column14.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column14.HeaderText = "SGST"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column24.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column24.HeaderText = "IGST"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column25.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column25.HeaderText = "CESS"
			Me.Column25.Name = "Column25"
			Me.Column25.[ReadOnly] = True
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column8.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column8.HeaderText = "Bill Sundry Charges"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column9.DefaultCellStyle = dataGridViewCellStyle14
			Me.Column9.HeaderText = "Bill Discount"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column18.DefaultCellStyle = dataGridViewCellStyle15
			Me.Column18.HeaderText = "Total"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column19.DefaultCellStyle = dataGridViewCellStyle16
			Me.Column19.HeaderText = "Round Off"
			Me.Column19.Name = "Column19"
			Me.Column19.[ReadOnly] = True
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle17
			Me.Column7.HeaderText = "Grand Total"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column10.HeaderText = "Reverse Charges"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.HeaderText = "Payment Mode"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column15.HeaderText = "Bill Sundry Type"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column16.HeaderText = "Column16"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column17.HeaderText = "Column17"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column22.HeaderText = "Column22"
			Me.Column22.Name = "Column22"
			Me.Column22.[ReadOnly] = True
			Me.Column23.HeaderText = "Column23"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1077, 633)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmPurchaseReturnRecord"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006A03 RID: 27139
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
