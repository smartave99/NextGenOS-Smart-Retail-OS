Namespace BillPoint
	' Token: 0x020005DF RID: 1503
		Public Partial Class frmSubCategory
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0601272D RID: 75565 RVA: 0x00A9E0D8 File Offset: 0x00A9C2D8
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

		' Token: 0x0601272E RID: 75566 RVA: 0x00A9E128 File Offset: 0x00A9C328
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSubCategory))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.lblSource1 = New Global.System.Windows.Forms.Label()
			Me.lblCurrentCellIndex = New Global.System.Windows.Forms.Label()
			Me.txtSelectedCategory = New Global.System.Windows.Forms.TextBox()
			Me.lblSource = New Global.System.Windows.Forms.Label()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.BStartCapture = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.cmbSubCategory = New Global.System.Windows.Forms.ComboBox()
			Me.cmbCategory = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtSearchBySubCategory = New Global.System.Windows.Forms.TextBox()
			Me.txtSearchByCategory = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.IsDefault = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel4.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(485, 143)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label8"
			label.Size = New Global.System.Drawing.Size(23, 13)
			label.TabIndex = 300
			label.Text = "OR"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton3)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.lblSource1)
			Me.Panel1.Controls.Add(Me.lblCurrentCellIndex)
			Me.Panel1.Controls.Add(Me.txtSelectedCategory)
			Me.Panel1.Controls.Add(Me.lblSource)
			Me.Panel1.Controls.Add(Me.GelButton2)
			Me.Panel1.Controls.Add(Me.Picture)
			Me.Panel1.Controls.Add(Me.BStartCapture)
			Me.Panel1.Controls.Add(Me.Browse)
			Me.Panel1.Controls.Add(label)
			Me.Panel1.Controls.Add(Me.BRemove)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.LinkLabel1)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(9, 8)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(752, 505)
			Me.Panel1.TabIndex = 2
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(590, 270)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(130, 43)
			Me.GelButton3.TabIndex = 518
			Me.GelButton3.Text = "New"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GelButton3.Visible = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(439, 6)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label3.TabIndex = 46
			Me.Label3.Text = "Label3"
			Me.Label3.Visible = False
			Me.lblSource1.AutoSize = True
			Me.lblSource1.Location = New Global.System.Drawing.Point(356, 207)
			Me.lblSource1.Name = "lblSource1"
			Me.lblSource1.Size = New Global.System.Drawing.Size(41, 13)
			Me.lblSource1.TabIndex = 548
			Me.lblSource1.Text = "Source"
			Me.lblCurrentCellIndex.AutoSize = True
			Me.lblCurrentCellIndex.Location = New Global.System.Drawing.Point(373, 221)
			Me.lblCurrentCellIndex.Name = "lblCurrentCellIndex"
			Me.lblCurrentCellIndex.Size = New Global.System.Drawing.Size(58, 13)
			Me.lblCurrentCellIndex.TabIndex = 547
			Me.lblCurrentCellIndex.Text = "CurrentCell"
			Me.txtSelectedCategory.BackColor = Global.System.Drawing.Color.White
			Me.txtSelectedCategory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSelectedCategory.Location = New Global.System.Drawing.Point(23, 199)
			Me.txtSelectedCategory.Name = "txtSelectedCategory"
			Me.txtSelectedCategory.Size = New Global.System.Drawing.Size(186, 21)
			Me.txtSelectedCategory.TabIndex = 546
			Me.txtSelectedCategory.TabStop = False
			Me.lblSource.AutoSize = True
			Me.lblSource.Location = New Global.System.Drawing.Point(356, 190)
			Me.lblSource.Name = "lblSource"
			Me.lblSource.Size = New Global.System.Drawing.Size(41, 13)
			Me.lblSource.TabIndex = 545
			Me.lblSource.Text = "Source"
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(452, 196)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(112, 35)
			Me.GelButton2.TabIndex = 541
			Me.GelButton2.Text = "&Import Excel"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = CType(componentResourceManager.GetObject("Picture.Image"), Global.System.Drawing.Image)
			Me.Picture.Location = New Global.System.Drawing.Point(442, 22)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(122, 89)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 301
			Me.Picture.TabStop = False
			Me.BStartCapture.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BStartCapture.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BStartCapture.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BStartCapture.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BStartCapture.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BStartCapture.ForeColor = Global.System.Drawing.Color.White
			Me.BStartCapture.Location = New Global.System.Drawing.Point(435, 159)
			Me.BStartCapture.Name = "BStartCapture"
			Me.BStartCapture.Size = New Global.System.Drawing.Size(129, 24)
			Me.BStartCapture.TabIndex = 299
			Me.BStartCapture.Text = "Use Webcam"
			Me.BStartCapture.UseVisualStyleBackColor = False
			Me.Browse.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.White
			Me.Browse.Location = New Global.System.Drawing.Point(435, 116)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(60, 24)
			Me.Browse.TabIndex = 297
			Me.Browse.Text = "Browse..."
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(498, 116)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(66, 24)
			Me.BRemove.TabIndex = 298
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Panel4.Controls.Add(Me.btnUpdate)
			Me.Panel4.Controls.Add(Me.btnDelete)
			Me.Panel4.Controls.Add(Me.btnNew)
			Me.Panel4.Controls.Add(Me.btnSave)
			Me.Panel4.Location = New Global.System.Drawing.Point(602, 35)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(137, 196)
			Me.Panel4.TabIndex = 46
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(3, 100)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(130, 43)
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(3, 147)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(130, 43)
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
			Me.btnNew.Location = New Global.System.Drawing.Point(3, 5)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(130, 43)
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
			Me.btnSave.Location = New Global.System.Drawing.Point(3, 52)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(130, 43)
			Me.btnSave.TabIndex = 514
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.GroupBox2.Controls.Add(Me.CheckBox1)
			Me.GroupBox2.Controls.Add(Me.cmbSubCategory)
			Me.GroupBox2.Controls.Add(Me.cmbCategory)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(13, 45)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(397, 83)
			Me.GroupBox2.TabIndex = 45
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Sub Category / Brand :"
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(314, 51)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(77, 17)
			Me.CheckBox1.TabIndex = 408
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "Is Default "
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.cmbSubCategory.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbSubCategory.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbSubCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSubCategory.FormattingEnabled = True
			Me.cmbSubCategory.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbSubCategory.Location = New Global.System.Drawing.Point(10, 19)
			Me.cmbSubCategory.Name = "cmbSubCategory"
			Me.cmbSubCategory.Size = New Global.System.Drawing.Size(374, 21)
			Me.cmbSubCategory.TabIndex = 0
			Me.cmbCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCategory.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCategory.FormattingEnabled = True
			Me.cmbCategory.Location = New Global.System.Drawing.Point(68, 47)
			Me.cmbCategory.Name = "cmbCategory"
			Me.cmbCategory.Size = New Global.System.Drawing.Size(240, 21)
			Me.cmbCategory.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(7, 50)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Category :"
			Me.GroupBox1.Controls.Add(Me.txtSearchBySubCategory)
			Me.GroupBox1.Controls.Add(Me.txtSearchByCategory)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(13, 132)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(397, 55)
			Me.GroupBox1.TabIndex = 44
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search By Category:"
			Me.txtSearchBySubCategory.BackColor = Global.System.Drawing.Color.White
			Me.txtSearchBySubCategory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSearchBySubCategory.Location = New Global.System.Drawing.Point(205, 25)
			Me.txtSearchBySubCategory.Name = "txtSearchBySubCategory"
			Me.txtSearchBySubCategory.Size = New Global.System.Drawing.Size(179, 21)
			Me.txtSearchBySubCategory.TabIndex = 0
			Me.txtSearchBySubCategory.TabStop = False
			Me.txtSearchByCategory.BackColor = Global.System.Drawing.Color.White
			Me.txtSearchByCategory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSearchByCategory.Location = New Global.System.Drawing.Point(10, 26)
			Me.txtSearchByCategory.Name = "txtSearchByCategory"
			Me.txtSearchByCategory.Size = New Global.System.Drawing.Size(186, 21)
			Me.txtSearchByCategory.TabIndex = 0
			Me.txtSearchByCategory.TabStop = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(202, 10)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(168, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "Search By Sub Category / Brand :"
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(163, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(209, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Sub Category / Brand"
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(250, 199)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(77, 13)
			Me.LinkLabel1.TabIndex = 43
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Export in Excel"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
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
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.IsDefault })
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
			Me.dgw.Location = New Global.System.Drawing.Point(9, 237)
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
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(730, 259)
			Me.dgw.TabIndex = 1
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Sub Category / Brand"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 210
			Me.Column3.HeaderText = "Category"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 200
			Me.Column4.HeaderText = "Photo"
			Me.Column4.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.IsDefault.HeaderText = "IsDefault"
			Me.IsDefault.Name = "IsDefault"
			Me.IsDefault.[ReadOnly] = True
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.txtID)
			Me.Panel2.Location = New Global.System.Drawing.Point(605, 8)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(115, 16)
			Me.Panel2.TabIndex = 0
			Me.Panel2.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(278, 40)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(3, 17)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(40, 20)
			Me.txtID.TabIndex = 4
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.ErrorProvider1.ContainerControl = Me
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(629, 551)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(130, 43)
			Me.GelButton1.TabIndex = 518
			Me.GelButton1.Text = "New"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton1.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(771, 517)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSubCategory"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel4.ResumeLayout(False)
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006EFC RID: 28412
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
