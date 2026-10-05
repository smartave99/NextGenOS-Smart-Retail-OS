Namespace BillPoint
	' Token: 0x020000C6 RID: 198
		Public Partial Class frmCustomerSupportLog_Dashboard
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002140 RID: 8512 RVA: 0x00154F5C File Offset: 0x0015315C
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

		' Token: 0x06002141 RID: 8513 RVA: 0x00154FAC File Offset: 0x001531AC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerSupportLog_Dashboard))
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnJoin = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.btnFollow = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.txtTokenNo = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.rdo_Closed = New Global.System.Windows.Forms.RadioButton()
			Me.rdo_Process = New Global.System.Windows.Forms.RadioButton()
			Me.rdo_Open = New Global.System.Windows.Forms.RadioButton()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.btnShowAll = New Global.GelButtons.GelButton()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.txtMobile = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.btnRefresh = New Global.GelButtons.GelButton()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.pnl_FollowUp = New Global.System.Windows.Forms.Panel()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.lblCurrentIssue = New Global.System.Windows.Forms.Label()
			Me.lblNumbers = New Global.System.Windows.Forms.Label()
			Me.lnkPanle_CLose = New Global.System.Windows.Forms.LinkLabel()
			Me.lblCount = New Global.System.Windows.Forms.Label()
			Me.lbl_tokenid = New Global.System.Windows.Forms.Label()
			Me.btnClosed = New Global.GelButtons.GelButton()
			Me.lbl_Id = New Global.System.Windows.Forms.Label()
			Me.btnTokenUpdate = New Global.GelButtons.GelButton()
			Me.txtRemarks = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.lblTokenNo = New Global.System.Windows.Forms.Label()
			Me.btnOffline_Online = New Global.GelButtons.GelButton()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel7.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.pnl_FollowUp.SuspendLayout()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle.BackColor = Global.System.Drawing.SystemColors.Control
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.ColumnHeadersHeight = 30
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column15, Me.Column14, Me.Column16, Me.Column17, Me.btnJoin, Me.btnFollow })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(0, 0)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Control
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(1803, 416)
			Me.DataGridView1.TabIndex = 0
			Me.Column1.HeaderText = "LogID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.HeaderText = "support_token_no"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Date"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "CurrentIssue"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "CustomerName"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Registered Mobile"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column7.HeaderText = "Software Name"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column8.HeaderText = "SoftwareValidity"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column9.HeaderText = "Status"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column10.HeaderText = "Remarks"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.HeaderText = "Feedback"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column12.HeaderText = "Rating"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column13.HeaderText = "Join_date"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column15.HeaderText = "Join_user"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column14.HeaderText = "Close_date"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column16.HeaderText = "Postpone_Days"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column17.HeaderText = "Calling Number"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column17.Visible = False
			Me.btnJoin.HeaderText = "Join"
			Me.btnJoin.Name = "btnJoin"
			Me.btnJoin.[ReadOnly] = True
			Me.btnJoin.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.btnJoin.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.btnJoin.Text = "Join"
			Me.btnJoin.UseColumnTextForButtonValue = True
			Me.btnFollow.HeaderText = "Follow"
			Me.btnFollow.Name = "btnFollow"
			Me.btnFollow.[ReadOnly] = True
			Me.btnFollow.Text = "Follow"
			Me.btnFollow.UseColumnTextForButtonValue = True
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.txtTokenNo)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(22, 12)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel3.TabIndex = 518
			Me.txtTokenNo.BackColor = Global.System.Drawing.Color.White
			Me.txtTokenNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTokenNo.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtTokenNo.Name = "txtTokenNo"
			Me.txtTokenNo.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtTokenNo.TabIndex = 13
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(116, 13)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Search By Token No. :"
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.rdo_Closed)
			Me.Panel6.Controls.Add(Me.rdo_Process)
			Me.Panel6.Controls.Add(Me.rdo_Open)
			Me.Panel6.Controls.Add(Me.Label4)
			Me.Panel6.Location = New Global.System.Drawing.Point(228, 12)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel6.TabIndex = 519
			Me.rdo_Closed.AutoSize = True
			Me.rdo_Closed.Location = New Global.System.Drawing.Point(134, 33)
			Me.rdo_Closed.Name = "rdo_Closed"
			Me.rdo_Closed.Size = New Global.System.Drawing.Size(57, 17)
			Me.rdo_Closed.TabIndex = 15
			Me.rdo_Closed.TabStop = True
			Me.rdo_Closed.Text = "Closed"
			Me.rdo_Closed.UseVisualStyleBackColor = True
			Me.rdo_Process.AutoSize = True
			Me.rdo_Process.Location = New Global.System.Drawing.Point(66, 33)
			Me.rdo_Process.Name = "rdo_Process"
			Me.rdo_Process.Size = New Global.System.Drawing.Size(63, 17)
			Me.rdo_Process.TabIndex = 14
			Me.rdo_Process.TabStop = True
			Me.rdo_Process.Text = "Process"
			Me.rdo_Process.UseVisualStyleBackColor = True
			Me.rdo_Open.AutoSize = True
			Me.rdo_Open.Location = New Global.System.Drawing.Point(9, 33)
			Me.rdo_Open.Name = "rdo_Open"
			Me.rdo_Open.Size = New Global.System.Drawing.Size(51, 17)
			Me.rdo_Open.TabIndex = 13
			Me.rdo_Open.TabStop = True
			Me.rdo_Open.Text = "Open"
			Me.rdo_Open.UseVisualStyleBackColor = True
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(95, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "Search By Status :"
			Me.GroupBox2.Controls.Add(Me.btnGetData)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.Label1)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(440, 12)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(337, 70)
			Me.GroupBox2.TabIndex = 520
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Date"
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
			Me.btnGetData.Location = New Global.System.Drawing.Point(256, 30)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(74, 30)
			Me.btnGetData.TabIndex = 516
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(131, 39)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(128, 20)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(3, 20)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label1.TabIndex = 12
			Me.Label1.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(6, 39)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 0
			Me.btnShowAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnShowAll.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnShowAll.FlatAppearance.BorderSize = 0
			Me.btnShowAll.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnShowAll.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnShowAll.ForeColor = Global.System.Drawing.Color.White
			Me.btnShowAll.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnShowAll.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnShowAll.Image = CType(componentResourceManager.GetObject("btnShowAll.Image"), Global.System.Drawing.Image)
			Me.btnShowAll.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnShowAll.Location = New Global.System.Drawing.Point(1294, 51)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(177, 31)
			Me.btnShowAll.TabIndex = 517
			Me.btnShowAll.Text = "Show All"
			Me.btnShowAll.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnShowAll.UseVisualStyleBackColor = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.FromArgb(255, 224, 192)
			Me.Panel1.Controls.Add(Me.btnOffline_Online)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.lblUserType)
			Me.Panel1.Controls.Add(Me.btnRefresh)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Panel7)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.Panel6)
			Me.Panel1.Controls.Add(Me.btnShowAll)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1803, 100)
			Me.Panel1.TabIndex = 521
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.txtMobile)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Location = New Global.System.Drawing.Point(783, 13)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel4.TabIndex = 519
			Me.txtMobile.BackColor = Global.System.Drawing.Color.White
			Me.txtMobile.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMobile.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtMobile.Name = "txtMobile"
			Me.txtMobile.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtMobile.TabIndex = 13
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(116, 13)
			Me.Label7.TabIndex = 12
			Me.Label7.Text = "Search By Mobile No. :"
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(1627, 77)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(63, 13)
			Me.lblUserType.TabIndex = 1862
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.btnRefresh.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnRefresh.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnRefresh.FlatAppearance.BorderSize = 0
			Me.btnRefresh.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRefresh.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRefresh.ForeColor = Global.System.Drawing.Color.White
			Me.btnRefresh.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnRefresh.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnRefresh.Image = CType(componentResourceManager.GetObject("btnRefresh.Image"), Global.System.Drawing.Image)
			Me.btnRefresh.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRefresh.Location = New Global.System.Drawing.Point(1294, 14)
			Me.btnRefresh.Name = "btnRefresh"
			Me.btnRefresh.Size = New Global.System.Drawing.Size(89, 33)
			Me.btnRefresh.TabIndex = 516
			Me.btnRefresh.Text = "Refresh"
			Me.btnRefresh.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRefresh.UseVisualStyleBackColor = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(1737, 77)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1861
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Panel7.BackColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.Panel7.Controls.Add(Me.Label18)
			Me.Panel7.Controls.Add(Me.Label21)
			Me.Panel7.Controls.Add(Me.txtTopResult)
			Me.Panel7.Location = New Global.System.Drawing.Point(991, 36)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(242, 47)
			Me.Panel7.TabIndex = 1824
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label18.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(131, 10)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(107, 30)
			Me.Label18.TabIndex = 1806
			Me.Label18.Text = "RECORDS"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(13, 10)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(64, 30)
			Me.Label21.TabIndex = 51
			Me.Label21.Text = "TOP :"
			Me.Label21.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtTopResult.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtTopResult.Location = New Global.System.Drawing.Point(76, 10)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(53, 26)
			Me.txtTopResult.TabIndex = 433
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "15"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label5.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(1389, 3)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(411, 33)
			Me.Label5.TabIndex = 521
			Me.Label5.Text = "Customer Support Log- Dashboard"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Panel2.Controls.Add(Me.pnl_FollowUp)
			Me.Panel2.Controls.Add(Me.DataGridView1)
			Me.Panel2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel2.Location = New Global.System.Drawing.Point(0, 100)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(1803, 416)
			Me.Panel2.TabIndex = 522
			Me.pnl_FollowUp.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.pnl_FollowUp.Controls.Add(Me.DataGridView2)
			Me.pnl_FollowUp.Controls.Add(Me.GroupBox1)
			Me.pnl_FollowUp.Location = New Global.System.Drawing.Point(749, 58)
			Me.pnl_FollowUp.Name = "pnl_FollowUp"
			Me.pnl_FollowUp.Size = New Global.System.Drawing.Size(731, 318)
			Me.pnl_FollowUp.TabIndex = 1
			Me.pnl_FollowUp.Visible = False
			Me.DataGridView2.AllowUserToAddRows = False
			Me.DataGridView2.AllowUserToDeleteRows = False
			Me.DataGridView2.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView2.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.SystemColors.Control
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView2.ColumnHeadersHeight = 30
			Me.DataGridView2.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12 })
			Me.DataGridView2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle5.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView2.DefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView2.EnableHeadersVisualStyles = False
			Me.DataGridView2.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView2.Location = New Global.System.Drawing.Point(10, 170)
			Me.DataGridView2.MultiSelect = False
			Me.DataGridView2.Name = "DataGridView2"
			Me.DataGridView2.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.SystemColors.Control
			dataGridViewCellStyle6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle6.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle6.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle6.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6
			Me.DataGridView2.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView2.Size = New Global.System.Drawing.Size(712, 145)
			Me.DataGridView2.TabIndex = 1
			Me.DataGridViewTextBoxColumn1.HeaderText = "LogID"
			Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
			Me.DataGridViewTextBoxColumn1.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn1.Visible = False
			Me.DataGridViewTextBoxColumn2.HeaderText = "support_token_no"
			Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
			Me.DataGridViewTextBoxColumn2.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn7.HeaderText = "Software Name"
			Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
			Me.DataGridViewTextBoxColumn7.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn5.HeaderText = "CustomerName"
			Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
			Me.DataGridViewTextBoxColumn5.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn6.HeaderText = "Registered Mobile"
			Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
			Me.DataGridViewTextBoxColumn6.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn3.HeaderText = "Date"
			Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
			Me.DataGridViewTextBoxColumn3.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn4.HeaderText = "CurrentIssue"
			Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
			Me.DataGridViewTextBoxColumn4.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn10.HeaderText = "Remarks"
			Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
			Me.DataGridViewTextBoxColumn10.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn15.HeaderText = "Close_date"
			Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
			Me.DataGridViewTextBoxColumn15.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn11.HeaderText = "Feedback"
			Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
			Me.DataGridViewTextBoxColumn11.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn12.HeaderText = "Rating"
			Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
			Me.DataGridViewTextBoxColumn12.[ReadOnly] = True
			Me.GroupBox1.Controls.Add(Me.lblCurrentIssue)
			Me.GroupBox1.Controls.Add(Me.lblNumbers)
			Me.GroupBox1.Controls.Add(Me.lnkPanle_CLose)
			Me.GroupBox1.Controls.Add(Me.lblCount)
			Me.GroupBox1.Controls.Add(Me.lbl_tokenid)
			Me.GroupBox1.Controls.Add(Me.btnClosed)
			Me.GroupBox1.Controls.Add(Me.lbl_Id)
			Me.GroupBox1.Controls.Add(Me.btnTokenUpdate)
			Me.GroupBox1.Controls.Add(Me.txtRemarks)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.lblTokenNo)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(10, 6)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(712, 158)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Token Follow-Up"
			Me.lblCurrentIssue.AutoSize = True
			Me.lblCurrentIssue.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblCurrentIssue.ForeColor = Global.System.Drawing.Color.Red
			Me.lblCurrentIssue.Location = New Global.System.Drawing.Point(17, 122)
			Me.lblCurrentIssue.Name = "lblCurrentIssue"
			Me.lblCurrentIssue.Size = New Global.System.Drawing.Size(110, 16)
			Me.lblCurrentIssue.TabIndex = 526
			Me.lblCurrentIssue.Text = "lblCurrentIssue"
			Me.lblNumbers.AutoSize = True
			Me.lblNumbers.Location = New Global.System.Drawing.Point(349, 22)
			Me.lblNumbers.Name = "lblNumbers"
			Me.lblNumbers.Size = New Global.System.Drawing.Size(59, 13)
			Me.lblNumbers.TabIndex = 525
			Me.lblNumbers.Text = "lblNumbers"
			Me.lnkPanle_CLose.AutoSize = True
			Me.lnkPanle_CLose.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lnkPanle_CLose.LinkColor = Global.System.Drawing.Color.Red
			Me.lnkPanle_CLose.Location = New Global.System.Drawing.Point(691, 10)
			Me.lnkPanle_CLose.Name = "lnkPanle_CLose"
			Me.lnkPanle_CLose.Size = New Global.System.Drawing.Size(15, 16)
			Me.lnkPanle_CLose.TabIndex = 524
			Me.lnkPanle_CLose.TabStop = True
			Me.lnkPanle_CLose.Text = "X"
			Me.lblCount.AutoSize = True
			Me.lblCount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblCount.Location = New Global.System.Drawing.Point(528, 39)
			Me.lblCount.Name = "lblCount"
			Me.lblCount.Size = New Global.System.Drawing.Size(152, 16)
			Me.lblCount.TabIndex = 523
			Me.lblCount.Text = "Total Support Log : X"
			Me.lbl_tokenid.AutoSize = True
			Me.lbl_tokenid.Location = New Global.System.Drawing.Point(323, 44)
			Me.lbl_tokenid.Name = "lbl_tokenid"
			Me.lbl_tokenid.Size = New Global.System.Drawing.Size(58, 13)
			Me.lbl_tokenid.TabIndex = 522
			Me.lbl_tokenid.Text = "lbl_tokenid"
			Me.lbl_tokenid.Visible = False
			Me.btnClosed.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnClosed.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnClosed.FlatAppearance.BorderSize = 0
			Me.btnClosed.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnClosed.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnClosed.ForeColor = Global.System.Drawing.Color.White
			Me.btnClosed.GradientBottom = Global.System.Drawing.Color.FromArgb(255, 192, 192)
			Me.btnClosed.GradientTop = Global.System.Drawing.Color.Red
			Me.btnClosed.Image = CType(componentResourceManager.GetObject("btnClosed.Image"), Global.System.Drawing.Image)
			Me.btnClosed.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnClosed.Location = New Global.System.Drawing.Point(562, 122)
			Me.btnClosed.Name = "btnClosed"
			Me.btnClosed.Size = New Global.System.Drawing.Size(129, 30)
			Me.btnClosed.TabIndex = 521
			Me.btnClosed.Text = "Token Closed"
			Me.btnClosed.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnClosed.UseVisualStyleBackColor = False
			Me.lbl_Id.AutoSize = True
			Me.lbl_Id.Location = New Global.System.Drawing.Point(285, 43)
			Me.lbl_Id.Name = "lbl_Id"
			Me.lbl_Id.Size = New Global.System.Drawing.Size(32, 13)
			Me.lbl_Id.TabIndex = 518
			Me.lbl_Id.Text = "lbl_Id"
			Me.lbl_Id.Visible = False
			Me.btnTokenUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnTokenUpdate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnTokenUpdate.FlatAppearance.BorderSize = 0
			Me.btnTokenUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnTokenUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTokenUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnTokenUpdate.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnTokenUpdate.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnTokenUpdate.Image = CType(componentResourceManager.GetObject("btnTokenUpdate.Image"), Global.System.Drawing.Image)
			Me.btnTokenUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnTokenUpdate.Location = New Global.System.Drawing.Point(427, 122)
			Me.btnTokenUpdate.Name = "btnTokenUpdate"
			Me.btnTokenUpdate.Size = New Global.System.Drawing.Size(129, 30)
			Me.btnTokenUpdate.TabIndex = 517
			Me.btnTokenUpdate.Text = "Token Update"
			Me.btnTokenUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnTokenUpdate.UseVisualStyleBackColor = False
			Me.txtRemarks.BackColor = Global.System.Drawing.Color.White
			Me.txtRemarks.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRemarks.Location = New Global.System.Drawing.Point(18, 60)
			Me.txtRemarks.Multiline = True
			Me.txtRemarks.Name = "txtRemarks"
			Me.txtRemarks.Size = New Global.System.Drawing.Size(673, 56)
			Me.txtRemarks.TabIndex = 15
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(17, 43)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label6.TabIndex = 14
			Me.Label6.Text = "Remarks :"
			Me.lblTokenNo.AutoSize = True
			Me.lblTokenNo.Location = New Global.System.Drawing.Point(17, 22)
			Me.lblTokenNo.Name = "lblTokenNo"
			Me.lblTokenNo.Size = New Global.System.Drawing.Size(58, 13)
			Me.lblTokenNo.TabIndex = 13
			Me.lblTokenNo.Text = "Token No."
			Me.btnOffline_Online.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnOffline_Online.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnOffline_Online.FlatAppearance.BorderSize = 0
			Me.btnOffline_Online.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnOffline_Online.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnOffline_Online.ForeColor = Global.System.Drawing.Color.White
			Me.btnOffline_Online.GradientBottom = Global.System.Drawing.Color.FromArgb(0, 0, 192)
			Me.btnOffline_Online.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnOffline_Online.Image = CType(componentResourceManager.GetObject("btnOffline_Online.Image"), Global.System.Drawing.Image)
			Me.btnOffline_Online.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnOffline_Online.Location = New Global.System.Drawing.Point(1477, 51)
			Me.btnOffline_Online.Name = "btnOffline_Online"
			Me.btnOffline_Online.Size = New Global.System.Drawing.Size(254, 31)
			Me.btnOffline_Online.TabIndex = 1863
			Me.btnOffline_Online.Text = "Completed Log Update Online"
			Me.btnOffline_Online.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnOffline_Online.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1803, 516)
			MyBase.Controls.Add(Me.Panel2)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Name = "frmCustomerSupportLog_Dashboard"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Customer Support Log - Dashboard"
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.pnl_FollowUp.ResumeLayout(False)
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000D8B RID: 3467
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
