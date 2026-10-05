Namespace BillPoint
	' Token: 0x020000A6 RID: 166
		Public Partial Class frmHoldrecord_Purchase
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600188B RID: 6283 RVA: 0x0010AA04 File Offset: 0x00108C04
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

		' Token: 0x0600188C RID: 6284 RVA: 0x0010AA54 File Offset: 0x00108C54
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmHoldrecord_Purchase))
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
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.btnunhold = New Global.System.Windows.Forms.Button()
			Me.btnhold = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtHold = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewImageColumn1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.DataGridViewTextBoxColumn28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn30 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn31 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn32 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.DataGridView1)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.txtHold)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(7, 7)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(695, 273)
			Me.Panel1.TabIndex = 0
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(645, 6)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label4.TabIndex = 1679
			Me.Label4.Text = "Label4"
			Me.Label4.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblUser.Location = New Global.System.Drawing.Point(523, 11)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 414
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.Button2)
			Me.Panel2.Controls.Add(Me.ComboBox1)
			Me.Panel2.Controls.Add(Me.Button1)
			Me.Panel2.Controls.Add(Me.Label3)
			Me.Panel2.Controls.Add(Me.btnunhold)
			Me.Panel2.Controls.Add(Me.btnhold)
			Me.Panel2.Location = New Global.System.Drawing.Point(596, 33)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(92, 222)
			Me.Panel2.TabIndex = 413
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(1, 124)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(88, 33)
			Me.Button2.TabIndex = 1681
			Me.Button2.TabStop = False
			Me.Button2.Text = "All PC Record"
			Me.Button2.UseVisualStyleBackColor = False
			Me.ComboBox1.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.ComboBox1.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Location = New Global.System.Drawing.Point(1, 197)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(88, 21)
			Me.ComboBox1.TabIndex = 1680
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(1, 83)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(88, 33)
			Me.Button1.TabIndex = 1679
			Me.Button1.TabStop = False
			Me.Button1.Text = "Reset"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label3.Location = New Global.System.Drawing.Point(0, 167)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(87, 28)
			Me.Label3.TabIndex = 1678
			Me.Label3.Text = "Search By Hold No. :"
			Me.btnunhold.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnunhold.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnunhold.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnunhold.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnunhold.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnunhold.ForeColor = Global.System.Drawing.Color.White
			Me.btnunhold.Image = CType(componentResourceManager.GetObject("btnunhold.Image"), Global.System.Drawing.Image)
			Me.btnunhold.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnunhold.Location = New Global.System.Drawing.Point(1, 43)
			Me.btnunhold.Name = "btnunhold"
			Me.btnunhold.Size = New Global.System.Drawing.Size(88, 33)
			Me.btnunhold.TabIndex = 1676
			Me.btnunhold.TabStop = False
			Me.btnunhold.Text = "Delete"
			Me.btnunhold.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnunhold.UseVisualStyleBackColor = False
			Me.btnhold.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnhold.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnhold.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnhold.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnhold.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnhold.ForeColor = Global.System.Drawing.Color.White
			Me.btnhold.Image = CType(componentResourceManager.GetObject("btnhold.Image"), Global.System.Drawing.Image)
			Me.btnhold.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnhold.Location = New Global.System.Drawing.Point(1, 3)
			Me.btnhold.Name = "btnhold"
			Me.btnhold.Size = New Global.System.Drawing.Size(88, 33)
			Me.btnhold.TabIndex = 1675
			Me.btnhold.TabStop = False
			Me.btnhold.Text = "Delete All"
			Me.btnhold.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnhold.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label2.Location = New Global.System.Drawing.Point(1, 257)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(221, 13)
			Me.Label2.TabIndex = 412
			Me.Label2.Text = "( PS :- Double click on rows to retrieve data. )"
			Me.txtHold.Location = New Global.System.Drawing.Point(600, 6)
			Me.txtHold.Name = "txtHold"
			Me.txtHold.[ReadOnly] = True
			Me.txtHold.Size = New Global.System.Drawing.Size(11, 20)
			Me.txtHold.TabIndex = 1677
			Me.txtHold.TabStop = False
			Me.txtHold.Visible = False
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(693, 30)
			Me.Label1.TabIndex = 410
			Me.Label1.Text = "Hold Record"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 30
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(3, 33)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView1.RowTemplate.Height = 25
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(587, 219)
			Me.DataGridView1.TabIndex = 1680
			Me.DataGridView1.TabStop = False
			Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
			Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
			Me.DataGridViewTextBoxColumn1.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn1.Visible = False
			Me.DataGridViewTextBoxColumn2.HeaderText = "Hold No."
			Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
			Me.DataGridViewTextBoxColumn2.[ReadOnly] = True
			dataGridViewCellStyle6.Format = "dd/MM/yyyy"
			Me.DataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6
			Me.DataGridViewTextBoxColumn3.HeaderText = "Date"
			Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
			Me.DataGridViewTextBoxColumn3.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn4.HeaderText = "Reference No."
			Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
			Me.DataGridViewTextBoxColumn4.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn4.Visible = False
			Me.DataGridViewTextBoxColumn5.HeaderText = "Reverse Charges"
			Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
			Me.DataGridViewTextBoxColumn5.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn5.Visible = False
			Me.DataGridViewTextBoxColumn6.HeaderText = "Purchase Type"
			Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
			Me.DataGridViewTextBoxColumn6.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn7.HeaderText = "Tax Type"
			Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
			Me.DataGridViewTextBoxColumn7.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn7.Visible = False
			Me.DataGridViewTextBoxColumn8.HeaderText = "Supplier's Invoice No."
			Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
			Me.DataGridViewTextBoxColumn8.[ReadOnly] = True
			dataGridViewCellStyle7.Format = "dd/MM/yyyy"
			Me.DataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle7
			Me.DataGridViewTextBoxColumn9.HeaderText = "Supplier's Invoice Date"
			Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
			Me.DataGridViewTextBoxColumn9.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn10.HeaderText = "SID"
			Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
			Me.DataGridViewTextBoxColumn10.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn10.Visible = False
			Me.DataGridViewTextBoxColumn11.HeaderText = "Supplier ID"
			Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
			Me.DataGridViewTextBoxColumn11.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn12.HeaderText = "Supplier Name"
			Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
			Me.DataGridViewTextBoxColumn12.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle8
			Me.DataGridViewTextBoxColumn13.HeaderText = "Sub Total"
			Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
			Me.DataGridViewTextBoxColumn13.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle9
			Me.DataGridViewTextBoxColumn14.HeaderText = "CGST"
			Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
			Me.DataGridViewTextBoxColumn14.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle10
			Me.DataGridViewTextBoxColumn15.HeaderText = "SGST/UTGST"
			Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
			Me.DataGridViewTextBoxColumn15.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle11
			Me.DataGridViewTextBoxColumn16.HeaderText = "IGST"
			Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
			Me.DataGridViewTextBoxColumn16.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle12
			Me.DataGridViewTextBoxColumn17.HeaderText = "CESS"
			Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
			Me.DataGridViewTextBoxColumn17.[ReadOnly] = True
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle13
			Me.DataGridViewTextBoxColumn18.HeaderText = "Bill Sundry Charges"
			Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
			Me.DataGridViewTextBoxColumn18.[ReadOnly] = True
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle14
			Me.DataGridViewTextBoxColumn19.HeaderText = "Bill Discount"
			Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
			Me.DataGridViewTextBoxColumn19.[ReadOnly] = True
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle15
			Me.DataGridViewTextBoxColumn20.HeaderText = "Previous Due"
			Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
			Me.DataGridViewTextBoxColumn20.[ReadOnly] = True
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle16
			Me.DataGridViewTextBoxColumn21.HeaderText = "Total"
			Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
			Me.DataGridViewTextBoxColumn21.[ReadOnly] = True
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle17
			Me.DataGridViewTextBoxColumn22.HeaderText = "Round Off"
			Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
			Me.DataGridViewTextBoxColumn22.[ReadOnly] = True
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			Me.DataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle18
			Me.DataGridViewTextBoxColumn23.HeaderText = "Grand Total"
			Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
			Me.DataGridViewTextBoxColumn23.[ReadOnly] = True
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			Me.DataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle19
			Me.DataGridViewTextBoxColumn24.HeaderText = "Total Paid"
			Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
			Me.DataGridViewTextBoxColumn24.[ReadOnly] = True
			dataGridViewCellStyle20.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			Me.DataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle20
			Me.DataGridViewTextBoxColumn25.HeaderText = "Balance"
			Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
			Me.DataGridViewTextBoxColumn25.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn26.HeaderText = "Remarks"
			Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
			Me.DataGridViewTextBoxColumn26.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn27.HeaderText = "Bill Sundry Type"
			Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
			Me.DataGridViewTextBoxColumn27.[ReadOnly] = True
			Me.DataGridViewImageColumn1.HeaderText = "Document"
			Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
			Me.DataGridViewImageColumn1.[ReadOnly] = True
			Me.DataGridViewImageColumn1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridViewImageColumn1.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.DataGridViewImageColumn1.Visible = False
			Me.DataGridViewTextBoxColumn28.HeaderText = "Trfr from Bank A/c No"
			Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
			Me.DataGridViewTextBoxColumn28.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn29.HeaderText = "S Address"
			Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
			Me.DataGridViewTextBoxColumn29.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn30.HeaderText = "S GSTNO"
			Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
			Me.DataGridViewTextBoxColumn30.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn31.HeaderText = "State"
			Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
			Me.DataGridViewTextBoxColumn31.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn32.HeaderText = "Mobile"
			Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
			Me.DataGridViewTextBoxColumn32.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(255, 192, 128)
			MyBase.ClientSize = New Global.System.Drawing.Size(709, 286)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmHoldrecord_Purchase"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000976 RID: 2422
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
