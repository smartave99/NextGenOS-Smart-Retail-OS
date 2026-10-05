Namespace BillPoint
	' Token: 0x020001D6 RID: 470
		Public Partial Class frmProductBulkUpdate
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007D09 RID: 32009 RVA: 0x005D4E58 File Offset: 0x005D3058
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

		' Token: 0x06007D0A RID: 32010 RVA: 0x005D4EA8 File Offset: 0x005D30A8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductBulkUpdate))
			Me.listView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader31 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader19 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader10 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader11 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader12 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader13 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader15 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader16 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader17 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader18 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader14 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader20 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader21 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader22 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader23 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader24 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader25 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader26 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader27 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader28 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader29 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader30 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader32 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader33 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader34 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader35 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader36 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader37 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader40 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader41 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader38 = New Global.System.Windows.Forms.ColumnHeader()
			Me.TextBox42 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.cBoxLangs = New Global.System.Windows.Forms.ComboBox()
			Me.btnPrevious = New Global.System.Windows.Forms.Button()
			Me.btnNext = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.lblPageInfo = New Global.System.Windows.Forms.Label()
			Me.btnChangebarcode = New Global.GelButtons.GelButton()
			Me.GelButton4 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.btnProductSeting = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.btnStatus = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.btnReset = New Global.GelButtons.GelButton()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.listView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.listView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 128)
			Me.listView1.CheckBoxes = True
			Me.listView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader31, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader19, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader14, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader32, Me.ColumnHeader33, Me.ColumnHeader34, Me.ColumnHeader35, Me.ColumnHeader36, Me.ColumnHeader37, Me.ColumnHeader40, Me.ColumnHeader41, Me.ColumnHeader38 })
			Me.listView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.listView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.listView1.FullRowSelect = True
			Me.listView1.GridLines = True
			Me.listView1.HeaderStyle = Global.System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.listView1.HideSelection = False
			Me.listView1.Location = New Global.System.Drawing.Point(8, 80)
			Me.listView1.MultiSelect = False
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(1232, 373)
			Me.listView1.TabIndex = 68
			Me.listView1.TabStop = False
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader1.Text = "ID"
			Me.ColumnHeader2.Text = "Product Code"
			Me.ColumnHeader2.Width = 100
			Me.ColumnHeader31.Text = "Barcode"
			Me.ColumnHeader31.Width = 100
			Me.ColumnHeader3.Text = "Product Name"
			Me.ColumnHeader3.Width = 200
			Me.ColumnHeader4.Text = "HSNC"
			Me.ColumnHeader4.Width = 80
			Me.ColumnHeader5.Text = "Part/Group"
			Me.ColumnHeader5.Width = 80
			Me.ColumnHeader6.Text = "Description"
			Me.ColumnHeader6.Width = 100
			Me.ColumnHeader7.Text = "Purchase Price"
			Me.ColumnHeader7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader7.Width = 100
			Me.ColumnHeader19.Text = "MRP"
			Me.ColumnHeader19.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader19.Width = 100
			Me.ColumnHeader8.Text = "R.Sale Price"
			Me.ColumnHeader8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader8.Width = 100
			Me.ColumnHeader9.Text = "W.Sale Price"
			Me.ColumnHeader9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader9.Width = 100
			Me.ColumnHeader10.Text = "Disc%"
			Me.ColumnHeader10.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader10.Width = 100
			Me.ColumnHeader11.Text = "CGST%"
			Me.ColumnHeader11.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader11.Width = 100
			Me.ColumnHeader12.Text = "SGST%"
			Me.ColumnHeader12.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader12.Width = 100
			Me.ColumnHeader13.Text = "CESS%"
			Me.ColumnHeader13.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader13.Width = 100
			Me.ColumnHeader15.Text = "Purchase Unit"
			Me.ColumnHeader15.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader15.Width = 100
			Me.ColumnHeader16.Text = "Sale Unit"
			Me.ColumnHeader16.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader16.Width = 100
			Me.ColumnHeader17.Text = "Alter Unit"
			Me.ColumnHeader17.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader17.Width = 100
			Me.ColumnHeader18.Text = "Con Value"
			Me.ColumnHeader18.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader18.Width = 80
			Me.ColumnHeader14.Text = "Minimum Stock"
			Me.ColumnHeader14.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader14.Width = 100
			Me.ColumnHeader20.Text = "Godown"
			Me.ColumnHeader20.Width = 120
			Me.ColumnHeader21.Text = "Rack"
			Me.ColumnHeader21.Width = 100
			Me.ColumnHeader22.Text = "Def Sale Qty"
			Me.ColumnHeader22.Width = 80
			Me.ColumnHeader23.Text = "OS_Purchase Price"
			Me.ColumnHeader23.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader23.Width = 100
			Me.ColumnHeader24.Text = "OS_MRP"
			Me.ColumnHeader24.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader24.Width = 130
			Me.ColumnHeader25.Text = "OS_R.Sale Price"
			Me.ColumnHeader25.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader25.Width = 130
			Me.ColumnHeader26.Text = "OS_W.Sale Price"
			Me.ColumnHeader26.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader26.Width = 130
			Me.ColumnHeader27.Text = "Batch"
			Me.ColumnHeader27.Width = 100
			Me.ColumnHeader28.Text = "Mfg Date"
			Me.ColumnHeader28.Width = 100
			Me.ColumnHeader29.Text = "Exp Date"
			Me.ColumnHeader29.Width = 100
			Me.ColumnHeader30.Text = "Colour"
			Me.ColumnHeader30.Width = 100
			Me.ColumnHeader32.Text = "Size"
			Me.ColumnHeader32.Width = 100
			Me.ColumnHeader33.Text = "IMEI-1"
			Me.ColumnHeader34.Text = "IMEI-2"
			Me.ColumnHeader35.Text = "Active"
			Me.ColumnHeader35.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader36.Text = "Qr Code"
			Me.ColumnHeader37.Text = "SalesMan%"
			Me.ColumnHeader40.DisplayIndex = 38
			Me.ColumnHeader40.Text = "loyality mode"
			Me.ColumnHeader41.DisplayIndex = 39
			Me.ColumnHeader41.Text = "loyality value"
			Me.ColumnHeader38.DisplayIndex = 37
			Me.ColumnHeader38.Text = "RowNum"
			Me.TextBox42.Location = New Global.System.Drawing.Point(511, 33)
			Me.TextBox42.Name = "TextBox42"
			Me.TextBox42.Size = New Global.System.Drawing.Size(21, 20)
			Me.TextBox42.TabIndex = 69
			Me.TextBox42.TabStop = False
			Me.TextBox42.Visible = False
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(218, 28)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(163, 22)
			Me.TextBox1.TabIndex = 1
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Red
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.White
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(12, 32)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(81, 21)
			Me.chkSelectAll.TabIndex = 72
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.Black
			Me.Label1.Location = New Global.System.Drawing.Point(215, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(166, 17)
			Me.Label1.TabIndex = 73
			Me.Label1.Text = "Search By Product Name :"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(381, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(127, 17)
			Me.Label2.TabIndex = 75
			Me.Label2.Text = "Search By Barcode :"
			Me.TextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(384, 28)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(124, 22)
			Me.TextBox2.TabIndex = 2
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Checked = True
			Me.CheckBox1.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(511, 8)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(128, 21)
			Me.CheckBox1.TabIndex = 76
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "Active / Deactive"
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Yes", "No" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(143, 26)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(71, 24)
			Me.ComboBox1.TabIndex = 0
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Black
			Me.Label3.Location = New Global.System.Drawing.Point(140, 8)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(52, 17)
			Me.Label3.TabIndex = 78
			Me.Label3.Text = "Active :"
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(93, 11)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label6.TabIndex = 441
			Me.Label6.Text = "Records"
			Me.Label7.AutoSize = True
			Me.Label7.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(6, 11)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label7.TabIndex = 440
			Me.Label7.Text = "Top"
			Me.txtTopResult.Location = New Global.System.Drawing.Point(33, 8)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(60, 20)
			Me.txtTopResult.TabIndex = 439
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "50"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.cBoxLangs.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cBoxLangs.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cBoxLangs.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cBoxLangs.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cBoxLangs.FormattingEnabled = True
			Me.cBoxLangs.Location = New Global.System.Drawing.Point(9, 55)
			Me.cBoxLangs.Name = "cBoxLangs"
			Me.cBoxLangs.Size = New Global.System.Drawing.Size(64, 23)
			Me.cBoxLangs.TabIndex = 1822
			Me.cBoxLangs.TabStop = False
			Me.btnPrevious.Location = New Global.System.Drawing.Point(172, 54)
			Me.btnPrevious.Name = "btnPrevious"
			Me.btnPrevious.Size = New Global.System.Drawing.Size(74, 23)
			Me.btnPrevious.TabIndex = 1823
			Me.btnPrevious.Text = "< Previous"
			Me.btnPrevious.UseVisualStyleBackColor = True
			Me.btnNext.Location = New Global.System.Drawing.Point(251, 55)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New Global.System.Drawing.Size(61, 23)
			Me.btnNext.TabIndex = 1824
			Me.btnNext.Text = "Next >"
			Me.btnNext.UseVisualStyleBackColor = True
			Me.Button1.Location = New Global.System.Drawing.Point(538, 32)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(59, 23)
			Me.Button1.TabIndex = 1825
			Me.Button1.Text = "Show All"
			Me.Button1.UseVisualStyleBackColor = True
			Me.Button1.Visible = False
			Me.lblPageInfo.AutoSize = True
			Me.lblPageInfo.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblPageInfo.ForeColor = Global.System.Drawing.Color.Black
			Me.lblPageInfo.Location = New Global.System.Drawing.Point(79, 56)
			Me.lblPageInfo.Name = "lblPageInfo"
			Me.lblPageInfo.Size = New Global.System.Drawing.Size(29, 17)
			Me.lblPageInfo.TabIndex = 1826
			Me.lblPageInfo.Text = "No."
			Me.btnChangebarcode.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnChangebarcode.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnChangebarcode.FlatAppearance.BorderSize = 0
			Me.btnChangebarcode.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnChangebarcode.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnChangebarcode.ForeColor = Global.System.Drawing.Color.White
			Me.btnChangebarcode.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnChangebarcode.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnChangebarcode.Image = CType(componentResourceManager.GetObject("btnChangebarcode.Image"), Global.System.Drawing.Image)
			Me.btnChangebarcode.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnChangebarcode.Location = New Global.System.Drawing.Point(1115, 2)
			Me.btnChangebarcode.Name = "btnChangebarcode"
			Me.btnChangebarcode.Size = New Global.System.Drawing.Size(125, 29)
			Me.btnChangebarcode.TabIndex = 1830
			Me.btnChangebarcode.Text = "Change Barcode"
			Me.btnChangebarcode.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnChangebarcode.UseVisualStyleBackColor = False
			Me.GelButton4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton4.FlatAppearance.BorderSize = 0
			Me.GelButton4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton4.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton4.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton4.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton4.Image = CType(componentResourceManager.GetObject("GelButton4.Image"), Global.System.Drawing.Image)
			Me.GelButton4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton4.Location = New Global.System.Drawing.Point(859, 2)
			Me.GelButton4.Name = "GelButton4"
			Me.GelButton4.Size = New Global.System.Drawing.Size(123, 29)
			Me.GelButton4.TabIndex = 1829
			Me.GelButton4.Text = "Set Default"
			Me.GelButton4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton4.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(721, 35)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(132, 29)
			Me.GelButton3.TabIndex = 1828
			Me.GelButton3.Text = "&Loyality Update"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.btnProductSeting.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnProductSeting.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnProductSeting.FlatAppearance.BorderSize = 0
			Me.btnProductSeting.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnProductSeting.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnProductSeting.ForeColor = Global.System.Drawing.Color.White
			Me.btnProductSeting.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnProductSeting.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnProductSeting.Image = CType(componentResourceManager.GetObject("btnProductSeting.Image"), Global.System.Drawing.Image)
			Me.btnProductSeting.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnProductSeting.Location = New Global.System.Drawing.Point(721, 2)
			Me.btnProductSeting.Name = "btnProductSeting"
			Me.btnProductSeting.Size = New Global.System.Drawing.Size(132, 29)
			Me.btnProductSeting.TabIndex = 1827
			Me.btnProductSeting.Text = "&Seting"
			Me.btnProductSeting.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnProductSeting.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 10F, Global.System.Drawing.FontStyle.Bold)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(859, 33)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(123, 31)
			Me.GelButton2.TabIndex = 1800
			Me.GelButton2.Text = "2nd Lang Update"
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(988, 2)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(123, 29)
			Me.GelButton1.TabIndex = 1799
			Me.GelButton1.Text = "&Barcode Print"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(96, 147)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(84, 82)
			Me.pbgiftqr.TabIndex = 1798
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.btnStatus.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnStatus.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnStatus.FlatAppearance.BorderSize = 0
			Me.btnStatus.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnStatus.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnStatus.ForeColor = Global.System.Drawing.Color.White
			Me.btnStatus.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnStatus.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnStatus.Image = CType(componentResourceManager.GetObject("btnStatus.Image"), Global.System.Drawing.Image)
			Me.btnStatus.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnStatus.Location = New Global.System.Drawing.Point(988, 33)
			Me.btnStatus.Name = "btnStatus"
			Me.btnStatus.Size = New Global.System.Drawing.Size(123, 33)
			Me.btnStatus.TabIndex = 518
			Me.btnStatus.Text = "Status Update"
			Me.btnStatus.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnStatus.UseVisualStyleBackColor = False
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(1115, 33)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(61, 34)
			Me.btnSave.TabIndex = 517
			Me.btnSave.Text = "&Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
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
			Me.btnReset.Location = New Global.System.Drawing.Point(1181, 33)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(59, 34)
			Me.btnReset.TabIndex = 516
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(1244, 467)
			MyBase.Controls.Add(Me.btnChangebarcode)
			MyBase.Controls.Add(Me.GelButton4)
			MyBase.Controls.Add(Me.GelButton3)
			MyBase.Controls.Add(Me.btnProductSeting)
			MyBase.Controls.Add(Me.lblPageInfo)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.btnNext)
			MyBase.Controls.Add(Me.btnPrevious)
			MyBase.Controls.Add(Me.cBoxLangs)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.btnStatus)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.btnReset)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.txtTopResult)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.ComboBox1)
			MyBase.Controls.Add(Me.CheckBox1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.TextBox2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.TextBox42)
			MyBase.Controls.Add(Me.listView1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.Name = "frmProductBulkUpdate"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Product Bulk Editor"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04003745 RID: 14149
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
