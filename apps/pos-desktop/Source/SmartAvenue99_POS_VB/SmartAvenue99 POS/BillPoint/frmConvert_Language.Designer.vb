Namespace BillPoint
	' Token: 0x020000D2 RID: 210
		Public Partial Class frmConvert_Language
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002581 RID: 9601 RVA: 0x0017BF38 File Offset: 0x0017A138
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

		' Token: 0x06002582 RID: 9602 RVA: 0x0017BF88 File Offset: 0x0017A188
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmConvert_Language))
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
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.btnExportExcel = New Global.GelButtons.GelButton()
			Me.Lang_hin = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Other_lang2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.id = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.English_lang2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.LblLanguage = New Global.System.Windows.Forms.Label()
			Me.checkMark = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.Other_lang = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.English_lang = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.LinkLabel3 = New Global.System.Windows.Forms.LinkLabel()
			Me.cBoxLangs = New Global.System.Windows.Forms.ComboBox()
			Me.Button8 = New Global.System.Windows.Forms.Button()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(590, 17)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(0, 13)
			Me.Label4.TabIndex = 1836
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(204, 17)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(98, 13)
			Me.Label2.TabIndex = 1834
			Me.Label2.Text = "English Languange"
			Me.Button1.ForeColor = Global.System.Drawing.Color.Red
			Me.Button1.Location = New Global.System.Drawing.Point(590, 37)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(66, 23)
			Me.Button1.TabIndex = 1833
			Me.Button1.Text = "Save"
			Me.Button1.UseVisualStyleBackColor = True
			Me.TextBox3.Location = New Global.System.Drawing.Point(308, 38)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(276, 20)
			Me.TextBox3.TabIndex = 1832
			Me.TextBox2.Location = New Global.System.Drawing.Point(308, 12)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(276, 20)
			Me.TextBox2.TabIndex = 1831
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(719, 37)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label1.TabIndex = 1830
			Me.Label1.Text = "Search"
			Me.TextBox1.Location = New Global.System.Drawing.Point(766, 34)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(261, 20)
			Me.TextBox1.TabIndex = 1829
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(1048, 11)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(123, 43)
			Me.GelButton1.TabIndex = 1828
			Me.GelButton1.Text = "Import"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.btnExportExcel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnExportExcel.FlatAppearance.BorderSize = 0
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnExportExcel.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(1177, 11)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnExportExcel.TabIndex = 1827
			Me.btnExportExcel.Text = "&Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.Lang_hin.DataPropertyName = "Lang_hin"
			Me.Lang_hin.HeaderText = "Language_code"
			Me.Lang_hin.Name = "Lang_hin"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(212, 42)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(90, 13)
			Me.Label3.TabIndex = 1835
			Me.Label3.Text = "Other Languange"
			Me.Other_lang2.DataPropertyName = "Other_lang2"
			dataGridViewCellStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Other_lang2.DefaultCellStyle = dataGridViewCellStyle
			Me.Other_lang2.FillWeight = 75F
			Me.Other_lang2.HeaderText = "Other Language"
			Me.Other_lang2.Name = "Other_lang2"
			Me.id.DataPropertyName = "id"
			Me.id.HeaderText = "ID"
			Me.id.Name = "id"
			Me.DataGridView2.AllowUserToAddRows = False
			Me.DataGridView2.AllowUserToDeleteRows = False
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView2.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView2.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView2.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView2.ColumnHeadersHeight = 40
			Me.DataGridView2.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.DataGridView2.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.id, Me.English_lang2, Me.Other_lang2, Me.Lang_hin })
			Me.DataGridView2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView2.DefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView2.EnableHeadersVisualStyles = False
			Me.DataGridView2.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView2.Location = New Global.System.Drawing.Point(593, 66)
			Me.DataGridView2.MultiSelect = False
			Me.DataGridView2.Name = "DataGridView2"
			Me.DataGridView2.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView2.RowHeadersWidth = 50
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle6.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle6.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle6.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle6
			Me.DataGridView2.RowTemplate.Height = 50
			Me.DataGridView2.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView2.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView2.Size = New Global.System.Drawing.Size(756, 665)
			Me.DataGridView2.TabIndex = 1826
			Me.English_lang2.DataPropertyName = "English_lang2"
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.English_lang2.DefaultCellStyle = dataGridViewCellStyle7
			Me.English_lang2.HeaderText = "Englsih"
			Me.English_lang2.Name = "English_lang2"
			Me.LblLanguage.AutoSize = True
			Me.LblLanguage.Location = New Global.System.Drawing.Point(238, 87)
			Me.LblLanguage.Name = "LblLanguage"
			Me.LblLanguage.Size = New Global.System.Drawing.Size(39, 13)
			Me.LblLanguage.TabIndex = 1825
			Me.LblLanguage.Text = "Label1"
			Me.LblLanguage.Visible = False
			Me.checkMark.FillWeight = 50F
			Me.checkMark.HeaderText = "Mark / Unmark"
			Me.checkMark.Name = "checkMark"
			Me.checkMark.[ReadOnly] = True
			Me.Other_lang.DataPropertyName = "Other_lang"
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Other_lang.DefaultCellStyle = dataGridViewCellStyle8
			Me.Other_lang.FillWeight = 75F
			Me.Other_lang.HeaderText = "Other Language"
			Me.Other_lang.Name = "Other_lang"
			Me.Other_lang.[ReadOnly] = True
			Me.English_lang.DataPropertyName = "English_lang"
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.English_lang.DefaultCellStyle = dataGridViewCellStyle9
			Me.English_lang.HeaderText = "Englsih"
			Me.English_lang.Name = "English_lang"
			Me.English_lang.[ReadOnly] = True
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.BackColor = Global.System.Drawing.Color.PaleGreen
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Enabled = False
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(12, 83)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(137, 17)
			Me.CheckBox1.TabIndex = 1824
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "All (Mark / Unmark)"
			Me.CheckBox1.UseVisualStyleBackColor = False
			Me.CheckBox1.Visible = False
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle10.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle11.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle11.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle11.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle11.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle11.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11
			Me.DataGridView1.ColumnHeadersHeight = 40
			Me.DataGridView1.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.English_lang, Me.Other_lang, Me.checkMark })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle12.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle12.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle12.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle12.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle12.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle12
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(12, 106)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle13.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle13.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle13.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle13.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle13.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle13
			Me.DataGridView1.RowHeadersWidth = 50
			dataGridViewCellStyle14.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle14.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle14.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle14.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle14
			Me.DataGridView1.RowTemplate.Height = 50
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(518, 625)
			Me.DataGridView1.TabIndex = 1823
			Me.DataGridView1.Visible = False
			Me.LinkLabel3.AutoSize = True
			Me.LinkLabel3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel3.Location = New Global.System.Drawing.Point(9, 38)
			Me.LinkLabel3.Name = "LinkLabel3"
			Me.LinkLabel3.Size = New Global.System.Drawing.Size(71, 13)
			Me.LinkLabel3.TabIndex = 1820
			Me.LinkLabel3.TabStop = True
			Me.LinkLabel3.Text = "Convert Lang"
			Me.cBoxLangs.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cBoxLangs.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cBoxLangs.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cBoxLangs.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cBoxLangs.FormattingEnabled = True
			Me.cBoxLangs.Location = New Global.System.Drawing.Point(12, 12)
			Me.cBoxLangs.Name = "cBoxLangs"
			Me.cBoxLangs.Size = New Global.System.Drawing.Size(181, 23)
			Me.cBoxLangs.TabIndex = 1821
			Me.cBoxLangs.TabStop = False
			Me.Button8.Enabled = False
			Me.Button8.Location = New Global.System.Drawing.Point(295, 79)
			Me.Button8.Name = "Button8"
			Me.Button8.Size = New Global.System.Drawing.Size(127, 23)
			Me.Button8.TabIndex = 1822
			Me.Button8.Text = "Store Marked Data"
			Me.Button8.UseVisualStyleBackColor = True
			Me.Button8.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1361, 743)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.TextBox3)
			MyBase.Controls.Add(Me.TextBox2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.btnExportExcel)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.DataGridView2)
			MyBase.Controls.Add(Me.LblLanguage)
			MyBase.Controls.Add(Me.CheckBox1)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.LinkLabel3)
			MyBase.Controls.Add(Me.cBoxLangs)
			MyBase.Controls.Add(Me.Button8)
			MyBase.Name = "frmConvert_Language"
			Me.Text = "frmConvert_Language"
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000F43 RID: 3907
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
