Namespace BillPoint
	' Token: 0x020000D4 RID: 212
		Public Partial Class frmCouponGenerate
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060025E7 RID: 9703 RVA: 0x00180858 File Offset: 0x0017EA58
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

		' Token: 0x060025E8 RID: 9704 RVA: 0x001808A8 File Offset: 0x0017EAA8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCouponGenerate))
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
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.DateTimePicker2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.ListView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker4 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateTimePicker3 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.lblCouponCode = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.lblCName = New Global.System.Windows.Forms.Label()
			Me.lblCContact = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
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
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.QrImage = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.CheckBox2 = New Global.System.Windows.Forms.CheckBox()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.DataGridViewImageColumn1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel4.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel5.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.pbgiftqr)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.LinkLabel1)
			Me.Panel1.Controls.Add(Me.chkSelectAll)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.ListView1)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.Button3)
			Me.Panel1.Controls.Add(Me.Browse)
			Me.Panel1.Controls.Add(Me.BRemove)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.DTP1)
			Me.Panel1.Controls.Add(Me.DTP2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.CheckBox2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(940, 546)
			Me.Panel1.TabIndex = 0
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(158, 356)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(96, 77)
			Me.pbgiftqr.TabIndex = 1797
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.TextBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TextBox1.Location = New Global.System.Drawing.Point(220, 44)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(186, 20)
			Me.TextBox1.TabIndex = 1699
			Me.TextBox1.TabStop = False
			Me.Button1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Button1.Image = Global.BillPoint.My.Resources.Resources.Database_Active_icon1
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(94, 34)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(121, 29)
			Me.Button1.TabIndex = 0
			Me.Button1.Text = "Customer List"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.LinkLabel1.ActiveLinkColor = Global.System.Drawing.Color.Blue
			Me.LinkLabel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Font = New Global.System.Drawing.Font("Arial Narrow", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel1.LinkColor = Global.System.Drawing.Color.Red
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(589, 258)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(122, 20)
			Me.LinkLabel1.TabIndex = 1696
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Delete All Records"
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.Font = New Global.System.Drawing.Font("Arial Narrow", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.White
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(4, 34)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(85, 29)
			Me.chkSelectAll.TabIndex = 1695
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.Panel2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.btnNew)
			Me.Panel2.Controls.Add(Me.btnSave)
			Me.Panel2.Controls.Add(Me.Label7)
			Me.Panel2.Controls.Add(Me.TextBox2)
			Me.Panel2.Controls.Add(Me.DateTimePicker2)
			Me.Panel2.Controls.Add(Me.Label8)
			Me.Panel2.Controls.Add(Me.DateTimePicker1)
			Me.Panel2.Controls.Add(Me.Label9)
			Me.Panel2.Controls.Add(Me.CheckBox1)
			Me.Panel2.Controls.Add(Me.Label12)
			Me.Panel2.Location = New Global.System.Drawing.Point(407, 35)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(130, 244)
			Me.Panel2.TabIndex = 1
			Me.btnNew.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNew.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnNew.FlatAppearance.BorderSize = 0
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnNew.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnNew.Image = CType(componentResourceManager.GetObject("btnNew.Image"), Global.System.Drawing.Image)
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(3, 211)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(121, 28)
			Me.btnNew.TabIndex = 518
			Me.btnNew.Text = "Reset"
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
			Me.btnSave.Location = New Global.System.Drawing.Point(3, 169)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(121, 38)
			Me.btnSave.TabIndex = 517
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label7.Location = New Global.System.Drawing.Point(2, 2)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(84, 15)
			Me.Label7.TabIndex = 428
			Me.Label7.Text = "Offer Amount :"
			Me.TextBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox2.Location = New Global.System.Drawing.Point(5, 19)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(120, 21)
			Me.TextBox2.TabIndex = 0
			Me.TextBox2.Text = "0.00"
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.DateTimePicker2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker2.Location = New Global.System.Drawing.Point(5, 101)
			Me.DateTimePicker2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DateTimePicker2.Name = "DateTimePicker2"
			Me.DateTimePicker2.Size = New Global.System.Drawing.Size(120, 21)
			Me.DateTimePicker2.TabIndex = 2
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label8.Location = New Global.System.Drawing.Point(2, 42)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(101, 15)
			Me.Label8.TabIndex = 429
			Me.Label8.Text = "Offer Valid From :"
			Me.DateTimePicker1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(5, 60)
			Me.DateTimePicker1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(120, 21)
			Me.DateTimePicker1.TabIndex = 1
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label9.Location = New Global.System.Drawing.Point(2, 83)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(98, 15)
			Me.Label9.TabIndex = 431
			Me.Label9.Text = "Offer Valid Upto :"
			Me.CheckBox1.BackColor = Global.System.Drawing.Color.Gainsboro
			Me.CheckBox1.Checked = True
			Me.CheckBox1.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(5, 142)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(120, 22)
			Me.CheckBox1.TabIndex = 5
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "Is Enabled"
			Me.CheckBox1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox1.UseVisualStyleBackColor = False
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label12.Location = New Global.System.Drawing.Point(2, 124)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(76, 15)
			Me.Label12.TabIndex = 437
			Me.Label12.Text = "Offer Status :"
			Me.ListView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.ListView1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.ListView1.CheckBoxes = True
			Me.ListView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5 })
			Me.ListView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ListView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView1.ForeColor = Global.System.Drawing.Color.White
			Me.ListView1.GridLines = True
			Me.ListView1.HideSelection = False
			Me.ListView1.Location = New Global.System.Drawing.Point(4, 66)
			Me.ListView1.Name = "ListView1"
			Me.ListView1.Size = New Global.System.Drawing.Size(402, 213)
			Me.ListView1.TabIndex = 1693
			Me.ListView1.TabStop = False
			Me.ListView1.UseCompatibleStateImageBehavior = False
			Me.ListView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader6.Text = "ID"
			Me.ColumnHeader6.Width = 50
			Me.ColumnHeader7.Text = "Customer ID"
			Me.ColumnHeader7.Width = 100
			Me.ColumnHeader1.Text = "Customer Name"
			Me.ColumnHeader1.Width = 230
			Me.ColumnHeader2.Text = "Address"
			Me.ColumnHeader2.Width = 250
			Me.ColumnHeader3.Text = "WhatsApp No"
			Me.ColumnHeader3.Width = 120
			Me.ColumnHeader4.Text = "Coupon Code"
			Me.ColumnHeader4.Width = 100
			Me.ColumnHeader5.Text = "Coupon Status"
			Me.ColumnHeader5.Width = 100
			Me.GroupBox2.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Controls.Add(Me.Label20)
			Me.GroupBox2.Controls.Add(Me.Label19)
			Me.GroupBox2.Controls.Add(Me.Button4)
			Me.GroupBox2.Controls.Add(Me.Label18)
			Me.GroupBox2.Controls.Add(Me.Label17)
			Me.GroupBox2.Controls.Add(Me.DateTimePicker4)
			Me.GroupBox2.Controls.Add(Me.DateTimePicker3)
			Me.GroupBox2.Controls.Add(Me.Label16)
			Me.GroupBox2.Controls.Add(Me.Label11)
			Me.GroupBox2.Controls.Add(Me.TextBox3)
			Me.GroupBox2.Controls.Add(Me.ComboBox1)
			Me.GroupBox2.ForeColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 486)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(931, 54)
			Me.GroupBox2.TabIndex = 1692
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search :"
			Me.Label20.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label20.AutoSize = True
			Me.Label20.ForeColor = Global.System.Drawing.Color.Green
			Me.Label20.Location = New Global.System.Drawing.Point(710, 34)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(216, 13)
			Me.Label20.TabIndex = 9
			Me.Label20.Text = "( Coupon Status :    NOT USED   /   USED )"
			Me.Label19.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label19.AutoSize = True
			Me.Label19.ForeColor = Global.System.Drawing.Color.Green
			Me.Label19.Location = New Global.System.Drawing.Point(710, 12)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(196, 13)
			Me.Label19.TabIndex = 8
			Me.Label19.Text = "( Offer Status :    Enabled   /   Disabled )"
			Me.Button4.BackColor = Global.System.Drawing.Color.White
			Me.Button4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(624, 21)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(61, 29)
			Me.Button4.TabIndex = 4
			Me.Button4.Text = "Getdata"
			Me.Button4.UseVisualStyleBackColor = False
			Me.Label18.AutoSize = True
			Me.Label18.Location = New Global.System.Drawing.Point(151, 11)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label18.TabIndex = 7
			Me.Label18.Text = "Upto :"
			Me.Label17.AutoSize = True
			Me.Label17.Location = New Global.System.Drawing.Point(40, 11)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label17.TabIndex = 6
			Me.Label17.Text = "From :"
			Me.DateTimePicker4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DateTimePicker4.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker4.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker4.Location = New Global.System.Drawing.Point(154, 27)
			Me.DateTimePicker4.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DateTimePicker4.Name = "DateTimePicker4"
			Me.DateTimePicker4.Size = New Global.System.Drawing.Size(108, 21)
			Me.DateTimePicker4.TabIndex = 1
			Me.DateTimePicker3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DateTimePicker3.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker3.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker3.Location = New Global.System.Drawing.Point(43, 27)
			Me.DateTimePicker3.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DateTimePicker3.Name = "DateTimePicker3"
			Me.DateTimePicker3.Size = New Global.System.Drawing.Size(108, 21)
			Me.DateTimePicker3.TabIndex = 0
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(417, 11)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label16.TabIndex = 3
			Me.Label16.Text = "Search :"
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(266, 11)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(92, 13)
			Me.Label11.TabIndex = 2
			Me.Label11.Text = "Search Category :"
			Me.TextBox3.Location = New Global.System.Drawing.Point(420, 27)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(198, 20)
			Me.TextBox3.TabIndex = 3
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.ItemHeight = 13
			Me.ComboBox1.Items.AddRange(New Object() { "Customer ID", "Customer Name", "Contact", "Offer Status", "Coupon Code", "Coupon Status", "Offer Valid From", "Offer Valid Upto", "Issue Date" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(267, 27)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(147, 21)
			Me.ComboBox1.TabIndex = 0
			Me.Button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button2.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button2.Location = New Global.System.Drawing.Point(855, 146)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(80, 102)
			Me.Button2.TabIndex = 1691
			Me.Button2.TabStop = False
			Me.Button2.Text = "Send"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button3.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.DimGray
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.Location = New Global.System.Drawing.Point(855, 109)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(80, 34)
			Me.Button3.TabIndex = 1690
			Me.Button3.TabStop = False
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Browse.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Browse.BackColor = Global.System.Drawing.Color.Transparent
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.DimGray
			Me.Browse.Image = CType(componentResourceManager.GetObject("Browse.Image"), Global.System.Drawing.Image)
			Me.Browse.Location = New Global.System.Drawing.Point(855, 35)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(80, 34)
			Me.Browse.TabIndex = 1688
			Me.Browse.TabStop = False
			Me.Browse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.BRemove.BackColor = Global.System.Drawing.Color.Transparent
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.DimGray
			Me.BRemove.Image = CType(componentResourceManager.GetObject("BRemove.Image"), Global.System.Drawing.Image)
			Me.BRemove.Location = New Global.System.Drawing.Point(855, 72)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(80, 34)
			Me.BRemove.TabIndex = 1689
			Me.BRemove.TabStop = False
			Me.BRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Panel4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel4.BackColor = Global.System.Drawing.Color.FromArgb(224, 224, 224)
			Me.Panel4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel4.Controls.Add(Me.PictureBox1)
			Me.Panel4.Controls.Add(Me.Panel6)
			Me.Panel4.Controls.Add(Me.lblCouponCode)
			Me.Panel4.Controls.Add(Me.Panel5)
			Me.Panel4.Location = New Global.System.Drawing.Point(540, 35)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(313, 213)
			Me.Panel4.TabIndex = 1687
			Me.PictureBox1.Location = New Global.System.Drawing.Point(5, 46)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(96, 77)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.PictureBox1.TabIndex = 1798
			Me.PictureBox1.TabStop = False
			Me.Panel6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel6.BackgroundImage = Global.BillPoint.My.Resources.Resources.GiftCard
			Me.Panel6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel6.Location = New Global.System.Drawing.Point(105, 22)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(208, 135)
			Me.Panel6.TabIndex = 416
			Me.lblCouponCode.BackColor = Global.System.Drawing.Color.Navy
			Me.lblCouponCode.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.lblCouponCode.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblCouponCode.ForeColor = Global.System.Drawing.Color.White
			Me.lblCouponCode.Location = New Global.System.Drawing.Point(0, 0)
			Me.lblCouponCode.Name = "lblCouponCode"
			Me.lblCouponCode.Size = New Global.System.Drawing.Size(313, 23)
			Me.lblCouponCode.TabIndex = 415
			Me.lblCouponCode.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel5.BackColor = Global.System.Drawing.Color.Navy
			Me.Panel5.Controls.Add(Me.lblCName)
			Me.Panel5.Controls.Add(Me.lblCContact)
			Me.Panel5.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.Panel5.Location = New Global.System.Drawing.Point(0, 158)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(313, 55)
			Me.Panel5.TabIndex = 0
			Me.lblCName.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblCName.ForeColor = Global.System.Drawing.Color.White
			Me.lblCName.Location = New Global.System.Drawing.Point(3, 2)
			Me.lblCName.Name = "lblCName"
			Me.lblCName.Size = New Global.System.Drawing.Size(307, 34)
			Me.lblCName.TabIndex = 1
			Me.lblCContact.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblCContact.ForeColor = Global.System.Drawing.Color.Yellow
			Me.lblCContact.Location = New Global.System.Drawing.Point(2, 36)
			Me.lblCContact.Name = "lblCContact"
			Me.lblCContact.Size = New Global.System.Drawing.Size(308, 14)
			Me.lblCContact.TabIndex = 0
			Me.lblCContact.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column1, Me.Column17, Me.Column18, Me.QrImage })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(4, 280)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
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
			Me.dgw.RowTemplate.Height = 35
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(932, 204)
			Me.dgw.TabIndex = 420
			Me.dgw.TabStop = False
			Me.Column2.HeaderText = "ID"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Visible = False
			Me.Column3.HeaderText = "CID"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Visible = False
			Me.Column4.HeaderText = "Customer ID"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "Customer Name"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Address"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column7.HeaderText = "Contact"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column8.HeaderText = "Disc Type"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Visible = False
			Me.Column9.HeaderText = "Disc (% or Amt)"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column9.Visible = False
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle6.Format = "N2"
			Me.Column10.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column10.HeaderText = "Offer Disc Amt"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			dataGridViewCellStyle7.Format = "d"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column11.HeaderText = "Offer Valid From"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			dataGridViewCellStyle8.Format = "d"
			Me.Column12.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column12.HeaderText = "Offer Valid Upto"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column13.HeaderText = "Offer Status"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column14.HeaderText = "Coupon Code"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column15.HeaderText = "Coupon Status"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			dataGridViewCellStyle9.Format = "d"
			Me.Column16.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column16.HeaderText = "Issue Date"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column1.HeaderText = "Mark/Unmark"
			Me.Column1.Name = "Column1"
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle10.BackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle10.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle10.NullValue = Nothing
			dataGridViewCellStyle10.SelectionBackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle10.SelectionForeColor = Global.System.Drawing.Color.White
			Me.Column17.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column17.FillWeight = 50F
			Me.Column17.HeaderText = "Delete"
			Me.Column17.Image = CType(componentResourceManager.GetObject("Column17.Image"), Global.System.Drawing.Image)
			Me.Column17.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column17.Name = "Column17"
			Me.Column17.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column17.ToolTipText = "Delete"
			Me.Column18.HeaderText = "Status"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			Me.QrImage.HeaderText = "QrImage"
			Me.QrImage.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.QrImage.Name = "QrImage"
			Me.QrImage.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(799, 14)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 7
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(10, 6)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(108, 21)
			Me.DTP1.TabIndex = 419
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(122, 6)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(108, 21)
			Me.DTP2.TabIndex = 418
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(943, 29)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Customer Coupon Management"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(218, 31)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(139, 13)
			Me.Label2.TabIndex = 1698
			Me.Label2.Text = "Search by Customer Name :"
			Me.CheckBox2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.CheckBox2.AutoSize = True
			Me.CheckBox2.BackColor = Global.System.Drawing.Color.Transparent
			Me.CheckBox2.CheckAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.CheckBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.CheckBox2.Font = New Global.System.Drawing.Font("Arial", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox2.ForeColor = Global.System.Drawing.Color.Blue
			Me.CheckBox2.Location = New Global.System.Drawing.Point(815, 248)
			Me.CheckBox2.Name = "CheckBox2"
			Me.CheckBox2.Size = New Global.System.Drawing.Size(127, 32)
			Me.CheckBox2.TabIndex = 1686
			Me.CheckBox2.TabStop = False
			Me.CheckBox2.Text = "All (Mark/Unmark)"
			Me.CheckBox2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox2.UseVisualStyleBackColor = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle11.BackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle11.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle11.NullValue = Nothing
			dataGridViewCellStyle11.SelectionBackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle11.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle11
			Me.DataGridViewImageColumn1.HeaderText = "Delete"
			Me.DataGridViewImageColumn1.Image = CType(componentResourceManager.GetObject("DataGridViewImageColumn1.Image"), Global.System.Drawing.Image)
			Me.DataGridViewImageColumn1.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
			Me.DataGridViewImageColumn1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridViewImageColumn1.ToolTipText = "Delete"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(940, 546)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.Name = "frmCouponGenerate"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel5.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000F6C RID: 3948
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
