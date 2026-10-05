Namespace BillPoint
	' Token: 0x020000C8 RID: 200
		Public Partial Class frmGSTR1_HSNC
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002235 RID: 8757 RVA: 0x0015C930 File Offset: 0x0015AB30
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

		' Token: 0x06002236 RID: 8758 RVA: 0x0015C980 File Offset: 0x0015AB80
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
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.TableLayoutPanel1 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnGetData = New Global.CButtonLib.CButton()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.btnExportExcel = New Global.CButtonLib.CButton()
			Me.btnReset = New Global.CButtonLib.CButton()
			Me.Panel1.SuspendLayout()
			Me.TableLayoutPanel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel5.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1000, 627)
			Me.Panel1.TabIndex = 4
			Me.TableLayoutPanel1.CellBorderStyle = Global.System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
			Me.TableLayoutPanel1.ColumnCount = 6
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 16.66667F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 16.66667F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 16.66667F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 16.66667F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 16.66667F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 16.66667F))
			Me.TableLayoutPanel1.Controls.Add(Me.Label17, 5, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label16, 4, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label15, 3, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label14, 2, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label13, 1, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label11, 5, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label10, 4, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label9, 3, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label8, 2, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label7, 1, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 0)
			Me.TableLayoutPanel1.Location = New Global.System.Drawing.Point(9, 521)
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 2
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 38.88889F))
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 61.11111F))
			Me.TableLayoutPanel1.Size = New Global.System.Drawing.Size(965, 78)
			Me.TableLayoutPanel1.TabIndex = 63
			Me.Label17.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label17.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Label17.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label17.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(804, 31)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(157, 46)
			Me.Label17.TabIndex = 11
			Me.Label17.Text = "Label17"
			Me.Label17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label16.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label16.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Label16.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label16.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label16.Location = New Global.System.Drawing.Point(644, 31)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(153, 46)
			Me.Label16.TabIndex = 10
			Me.Label16.Text = "Label16"
			Me.Label16.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label15.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label15.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Label15.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label15.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label15.Location = New Global.System.Drawing.Point(484, 31)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(153, 46)
			Me.Label15.TabIndex = 9
			Me.Label15.Text = "Label15"
			Me.Label15.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label14.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label14.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Label14.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label14.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.Location = New Global.System.Drawing.Point(324, 31)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(153, 46)
			Me.Label14.TabIndex = 8
			Me.Label14.Text = "Label14"
			Me.Label14.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label13.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label13.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Label13.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label13.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(164, 31)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(153, 46)
			Me.Label13.TabIndex = 7
			Me.Label13.Text = "Label13"
			Me.Label13.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label12.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label12.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Label12.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label12.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(4, 31)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(153, 46)
			Me.Label12.TabIndex = 6
			Me.Label12.Text = "Label12"
			Me.Label12.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label11.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label11.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label11.Font = New Global.System.Drawing.Font("Arial Narrow", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.ForeColor = Global.System.Drawing.Color.White
			Me.Label11.Location = New Global.System.Drawing.Point(804, 1)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(157, 29)
			Me.Label11.TabIndex = 5
			Me.Label11.Text = "Total CESS Amount"
			Me.Label11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label10.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label10.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label10.Font = New Global.System.Drawing.Font("Arial Narrow", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.ForeColor = Global.System.Drawing.Color.White
			Me.Label10.Location = New Global.System.Drawing.Point(644, 1)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(153, 29)
			Me.Label10.TabIndex = 4
			Me.Label10.Text = "Total SGST Amont"
			Me.Label10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label9.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label9.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label9.Font = New Global.System.Drawing.Font("Arial Narrow", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.White
			Me.Label9.Location = New Global.System.Drawing.Point(484, 1)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(153, 29)
			Me.Label9.TabIndex = 3
			Me.Label9.Text = "Total CGST Amount"
			Me.Label9.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label8.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label8.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label8.Font = New Global.System.Drawing.Font("Arial Narrow", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.ForeColor = Global.System.Drawing.Color.White
			Me.Label8.Location = New Global.System.Drawing.Point(324, 1)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(153, 29)
			Me.Label8.TabIndex = 2
			Me.Label8.Text = "Total IGST Amount"
			Me.Label8.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label7.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label7.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label7.Font = New Global.System.Drawing.Font("Arial Narrow", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(164, 1)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(153, 29)
			Me.Label7.TabIndex = 1
			Me.Label7.Text = "Total Taxable Amount"
			Me.Label7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label6.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label6.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label6.Font = New Global.System.Drawing.Font("Arial Narrow", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(4, 1)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(153, 29)
			Me.Label6.TabIndex = 0
			Me.Label6.Text = "Total Quantities"
			Me.Label6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(538, 48)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(95, 13)
			Me.Label5.TabIndex = 62
			Me.Label5.Text = "Search By HSNC :"
			Me.TextBox2.Location = New Global.System.Drawing.Point(541, 67)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(100, 20)
			Me.TextBox2.TabIndex = 61
			Me.TextBox2.TabStop = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(393, 48)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(98, 13)
			Me.Label3.TabIndex = 14
			Me.Label3.Text = "Search By GST % :"
			Me.TextBox1.Location = New Global.System.Drawing.Point(396, 67)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(100, 20)
			Me.TextBox1.TabIndex = 60
			Me.TextBox1.TabStop = False
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.btnGetData)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(9, 26)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(337, 76)
			Me.GroupBox2.TabIndex = 0
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Invoice Date"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(131, 41)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(128, 22)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.btnGetData.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnGetData.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnGetData.Corners.All = 5
			Me.btnGetData.Corners.LowerLeft = 5
			Me.btnGetData.Corners.LowerRight = 5
			Me.btnGetData.Corners.UpperLeft = 5
			Me.btnGetData.Corners.UpperRight = 5
			Me.btnGetData.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnGetData.DesignerSelected = True
			Me.btnGetData.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ImageIndex = 0
			Me.btnGetData.ImageSize = New Global.System.Drawing.Size(28, 28)
			Me.btnGetData.Location = New Global.System.Drawing.Point(256, 39)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(76, 24)
			Me.btnGetData.TabIndex = 2
			Me.btnGetData.Text = "Get Data"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(3, 22)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(6, 41)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 0
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.btnExportExcel)
			Me.Panel5.Controls.Add(Me.btnReset)
			Me.Panel5.Location = New Global.System.Drawing.Point(739, 32)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(235, 70)
			Me.Panel5.TabIndex = 2
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column5, Me.Column2, Me.Column3, Me.Column14, Me.Column6, Me.Column16, Me.Column17, Me.Column13, Me.Column15, Me.Column18, Me.Column1, Me.Column4 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(9, 108)
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
			Me.dgw.Size = New Global.System.Drawing.Size(982, 423)
			Me.dgw.TabIndex = 43
			Me.dgw.TabStop = False
			dataGridViewCellStyle6.Format = "dd/MM/yyyy"
			dataGridViewCellStyle6.NullValue = Nothing
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column5.HeaderText = "Date"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column2.HeaderText = "HSNC"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			dataGridViewCellStyle7.Format = "d"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column3.HeaderText = "Description"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column14.HeaderText = "Product Name"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column6.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column6.HeaderText = "UQC"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column16.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column16.HeaderText = "Total Qty"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle10.Format = "N2"
			Me.Column17.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column17.HeaderText = "Total Taxable Value"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column13.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column13.HeaderText = "GST%"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle12.Format = "N2"
			Me.Column15.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column15.HeaderText = "IGST Amount"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle13.Format = "N2"
			Me.Column18.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column18.HeaderText = "CGST Amount"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle14.Format = "N2"
			Me.Column1.DefaultCellStyle = dataGridViewCellStyle14
			Me.Column1.HeaderText = "SGST Amount"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle15.Format = "N2"
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle15
			Me.Column4.HeaderText = "CESS Amount"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1000, 26)
			Me.Label1.TabIndex = 57
			Me.Label1.Text = "GSTR-1 Report by HSN Code"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnExportExcel.BackgroundImage = Global.BillPoint.My.Resources.Resources.Export_Excel_copy
			Me.btnExportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExportExcel.Corners.All = 5
			Me.btnExportExcel.Corners.LowerLeft = 5
			Me.btnExportExcel.Corners.LowerRight = 5
			Me.btnExportExcel.Corners.UpperLeft = 5
			Me.btnExportExcel.Corners.UpperRight = 5
			Me.btnExportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnExportExcel.DesignerSelected = False
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.ImageIndex = 0
			Me.btnExportExcel.ImageSize = New Global.System.Drawing.Size(28, 28)
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(119, 15)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(110, 37)
			Me.btnExportExcel.TabIndex = 1
			Me.btnExportExcel.Text = ""
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnReset.BackgroundImage = Global.BillPoint.My.Resources.Resources.Reset_copy
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Corners.All = 5
			Me.btnReset.Corners.LowerLeft = 5
			Me.btnReset.Corners.LowerRight = 5
			Me.btnReset.Corners.UpperLeft = 5
			Me.btnReset.Corners.UpperRight = 5
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.DesignerSelected = False
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.ImageIndex = 0
			Me.btnReset.ImageSize = New Global.System.Drawing.Size(28, 28)
			Me.btnReset.Location = New Global.System.Drawing.Point(3, 15)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(110, 37)
			Me.btnReset.TabIndex = 0
			Me.btnReset.Text = ""
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(1000, 627)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmGSTR1_HSNC"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.TableLayoutPanel1.ResumeLayout(False)
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000DF5 RID: 3573
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
