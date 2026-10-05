Namespace BillPoint
	' Token: 0x02000362 RID: 866
		Public Partial Class frmPromotionalOffers
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600CD33 RID: 52531 RVA: 0x00803354 File Offset: 0x00801554
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

		' Token: 0x0600CD34 RID: 52532 RVA: 0x008033A4 File Offset: 0x008015A4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmPromotionalOffers))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle9 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnDisable = New Global.GelButtons.GelButton()
			Me.btnDelete2 = New Global.GelButtons.GelButton()
			Me.btnDelete1 = New Global.GelButtons.GelButton()
			Me.GelButton4 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.btnShowAll = New Global.GelButtons.GelButton()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.cmbSubCat = New Global.System.Windows.Forms.ComboBox()
			Me.ListView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Category = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.dtpExpiryDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.chkIsExpired = New Global.System.Windows.Forms.CheckBox()
			Me.lblBarcode = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.dtpEntryDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.cmbProductName = New Global.System.Windows.Forms.ComboBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.txtBuyMinqty = New Global.System.Windows.Forms.TextBox()
			Me.cmbCategory = New Global.System.Windows.Forms.ComboBox()
			Me.chkActive = New Global.System.Windows.Forms.CheckBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtGetFreeQty = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtProductName = New Global.System.Windows.Forms.TextBox()
			Me.txtProductCode = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtProductID = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.btnProductData = New Global.GelButtons.GelButton()
			Me.txtSearchByProduct = New Global.System.Windows.Forms.TextBox()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Description = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnSelection = New Global.System.Windows.Forms.Button()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.btnDisable)
			Me.Panel1.Controls.Add(Me.btnDelete2)
			Me.Panel1.Controls.Add(Me.btnDelete1)
			Me.Panel1.Controls.Add(Me.GelButton4)
			Me.Panel1.Controls.Add(Me.GelButton3)
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.btnUpdate)
			Me.Panel1.Controls.Add(Me.btnDelete)
			Me.Panel1.Controls.Add(Me.btnNew)
			Me.Panel1.Controls.Add(Me.btnSave)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.txtID)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.txtProductName)
			Me.Panel1.Controls.Add(Me.txtProductCode)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.txtProductID)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.GroupBox3)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.btnSelection)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1172, 598)
			Me.Panel1.TabIndex = 2
			Me.btnDisable.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDisable.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDisable.FlatAppearance.BorderSize = 0
			Me.btnDisable.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDisable.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDisable.ForeColor = Global.System.Drawing.Color.White
			Me.btnDisable.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnDisable.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnDisable.Image = CType(componentResourceManager.GetObject("btnDisable.Image"), Global.System.Drawing.Image)
			Me.btnDisable.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDisable.Location = New Global.System.Drawing.Point(954, 384)
			Me.btnDisable.Name = "btnDisable"
			Me.btnDisable.Size = New Global.System.Drawing.Size(213, 39)
			Me.btnDisable.TabIndex = 531
			Me.btnDisable.Text = "Deactivate All Active Offers"
			Me.btnDisable.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDisable.UseVisualStyleBackColor = False
			Me.btnDelete2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDelete2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDelete2.FlatAppearance.BorderSize = 0
			Me.btnDelete2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete2.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete2.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnDelete2.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnDelete2.Image = CType(componentResourceManager.GetObject("btnDelete2.Image"), Global.System.Drawing.Image)
			Me.btnDelete2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete2.Location = New Global.System.Drawing.Point(753, 384)
			Me.btnDelete2.Name = "btnDelete2"
			Me.btnDelete2.Size = New Global.System.Drawing.Size(196, 39)
			Me.btnDelete2.TabIndex = 530
			Me.btnDelete2.Text = "Delete All Inactive Offers"
			Me.btnDelete2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete2.UseVisualStyleBackColor = False
			Me.btnDelete1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDelete1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDelete1.FlatAppearance.BorderSize = 0
			Me.btnDelete1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete1.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnDelete1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnDelete1.Image = CType(componentResourceManager.GetObject("btnDelete1.Image"), Global.System.Drawing.Image)
			Me.btnDelete1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete1.Location = New Global.System.Drawing.Point(564, 384)
			Me.btnDelete1.Name = "btnDelete1"
			Me.btnDelete1.Size = New Global.System.Drawing.Size(185, 39)
			Me.btnDelete1.TabIndex = 529
			Me.btnDelete1.Text = "Delete All Expired Offers"
			Me.btnDelete1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete1.UseVisualStyleBackColor = False
			Me.GelButton4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton4.FlatAppearance.BorderSize = 0
			Me.GelButton4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton4.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton4.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton4.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton4.Image = CType(componentResourceManager.GetObject("GelButton4.Image"), Global.System.Drawing.Image)
			Me.GelButton4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton4.Location = New Global.System.Drawing.Point(375, 384)
			Me.GelButton4.Name = "GelButton4"
			Me.GelButton4.Size = New Global.System.Drawing.Size(185, 39)
			Me.GelButton4.TabIndex = 528
			Me.GelButton4.Text = "Show All Inactive Offers"
			Me.GelButton4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton4.UseVisualStyleBackColor = False
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(186, 384)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(185, 39)
			Me.GelButton3.TabIndex = 527
			Me.GelButton3.Text = "Show All Expired Offers"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(8, 383)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(174, 39)
			Me.GelButton1.TabIndex = 526
			Me.GelButton1.Text = "Show All Active Offers"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(1053, 141)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnUpdate.TabIndex = 523
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(1053, 188)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnDelete.TabIndex = 522
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
			Me.btnNew.Location = New Global.System.Drawing.Point(1053, 46)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnNew.TabIndex = 521
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
			Me.btnSave.Location = New Global.System.Drawing.Point(1053, 93)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnSave.TabIndex = 520
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.btnShowAll)
			Me.Panel4.Controls.Add(Me.Label16)
			Me.Panel4.Controls.Add(Me.cmbSubCat)
			Me.Panel4.Controls.Add(Me.ListView1)
			Me.Panel4.Controls.Add(Me.chkSelectAll)
			Me.Panel4.Controls.Add(Me.Label14)
			Me.Panel4.Controls.Add(Me.dtpExpiryDate)
			Me.Panel4.Controls.Add(Me.chkIsExpired)
			Me.Panel4.Controls.Add(Me.lblBarcode)
			Me.Panel4.Controls.Add(Me.Label10)
			Me.Panel4.Controls.Add(Me.Label12)
			Me.Panel4.Controls.Add(Me.Label9)
			Me.Panel4.Controls.Add(Me.Label13)
			Me.Panel4.Controls.Add(Me.dtpEntryDate)
			Me.Panel4.Controls.Add(Me.cmbProductName)
			Me.Panel4.Controls.Add(Me.Label15)
			Me.Panel4.Controls.Add(Me.txtBuyMinqty)
			Me.Panel4.Controls.Add(Me.cmbCategory)
			Me.Panel4.Controls.Add(Me.chkActive)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.txtGetFreeQty)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(8, 45)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(1039, 258)
			Me.Panel4.TabIndex = 0
			Me.btnShowAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnShowAll.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnShowAll.FlatAppearance.BorderSize = 0
			Me.btnShowAll.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnShowAll.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnShowAll.ForeColor = Global.System.Drawing.Color.White
			Me.btnShowAll.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnShowAll.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnShowAll.Image = CType(componentResourceManager.GetObject("btnShowAll.Image"), Global.System.Drawing.Image)
			Me.btnShowAll.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnShowAll.Location = New Global.System.Drawing.Point(911, 13)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnShowAll.TabIndex = 525
			Me.btnShowAll.Text = "Show &All"
			Me.btnShowAll.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnShowAll.UseVisualStyleBackColor = False
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(489, 4)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(144, 15)
			Me.Label16.TabIndex = 433
			Me.Label16.Text = "Search By Sub Category :"
			Me.cmbSubCat.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSubCat.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSubCat.FormattingEnabled = True
			Me.cmbSubCat.Location = New Global.System.Drawing.Point(492, 25)
			Me.cmbSubCat.Name = "cmbSubCat"
			Me.cmbSubCat.Size = New Global.System.Drawing.Size(170, 23)
			Me.cmbSubCat.TabIndex = 432
			Me.ListView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ListView1.CheckBoxes = True
			Me.ListView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader7, Me.Category, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader1 })
			Me.ListView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView1.GridLines = True
			Me.ListView1.HideSelection = False
			Me.ListView1.Location = New Global.System.Drawing.Point(3, 79)
			Me.ListView1.Name = "ListView1"
			Me.ListView1.Size = New Global.System.Drawing.Size(708, 174)
			Me.ListView1.TabIndex = 430
			Me.ListView1.UseCompatibleStateImageBehavior = False
			Me.ListView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader7.Text = "Product Code"
			Me.ColumnHeader7.Width = 100
			Me.Category.Text = "Product Name"
			Me.Category.Width = 350
			Me.ColumnHeader8.Text = "Category"
			Me.ColumnHeader8.Width = 120
			Me.ColumnHeader9.Text = "Sub Category"
			Me.ColumnHeader9.Width = 100
			Me.ColumnHeader1.Text = "ID"
			Me.ColumnHeader1.Width = 40
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.Black
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(3, 56)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(76, 19)
			Me.chkSelectAll.TabIndex = 431
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(4, 4)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(156, 15)
			Me.Label14.TabIndex = 423
			Me.Label14.Text = "Search By Category Name :"
			Me.dtpExpiryDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpExpiryDate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpExpiryDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpExpiryDate.Location = New Global.System.Drawing.Point(844, 203)
			Me.dtpExpiryDate.Name = "dtpExpiryDate"
			Me.dtpExpiryDate.Size = New Global.System.Drawing.Size(141, 26)
			Me.dtpExpiryDate.TabIndex = 7
			Me.chkIsExpired.AutoSize = True
			Me.chkIsExpired.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.chkIsExpired.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkIsExpired.Location = New Global.System.Drawing.Point(844, 178)
			Me.chkIsExpired.Name = "chkIsExpired"
			Me.chkIsExpired.Size = New Global.System.Drawing.Size(139, 19)
			Me.chkIsExpired.TabIndex = 6
			Me.chkIsExpired.Text = "Having Expiry Date ?"
			Me.chkIsExpired.UseVisualStyleBackColor = False
			Me.lblBarcode.AutoSize = True
			Me.lblBarcode.Location = New Global.System.Drawing.Point(264, 52)
			Me.lblBarcode.Name = "lblBarcode"
			Me.lblBarcode.Size = New Global.System.Drawing.Size(10, 15)
			Me.lblBarcode.TabIndex = 428
			Me.lblBarcode.Text = ":"
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(726, 151)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(83, 15)
			Me.Label10.TabIndex = 320
			Me.Label10.Text = "Get Free Qty. :"
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(176, 52)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(87, 15)
			Me.Label12.TabIndex = 427
			Me.Label12.Text = "Product Code :"
			Me.Label12.Visible = False
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(726, 124)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(112, 15)
			Me.Label9.TabIndex = 319
			Me.Label9.Text = "Buy Minimum Qty. :"
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(176, 6)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(150, 15)
			Me.Label13.TabIndex = 425
			Me.Label13.Text = "Search By Product Name :"
			Me.dtpEntryDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpEntryDate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpEntryDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpEntryDate.Location = New Global.System.Drawing.Point(842, 86)
			Me.dtpEntryDate.Name = "dtpEntryDate"
			Me.dtpEntryDate.Size = New Global.System.Drawing.Size(143, 26)
			Me.dtpEntryDate.TabIndex = 3
			Me.cmbProductName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbProductName.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbProductName.FormattingEnabled = True
			Me.cmbProductName.Location = New Global.System.Drawing.Point(179, 25)
			Me.cmbProductName.Name = "cmbProductName"
			Me.cmbProductName.Size = New Global.System.Drawing.Size(292, 23)
			Me.cmbProductName.TabIndex = 1
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(726, 203)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(75, 15)
			Me.Label15.TabIndex = 309
			Me.Label15.Text = "Expiry Date :"
			Me.txtBuyMinqty.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBuyMinqty.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBuyMinqty.Location = New Global.System.Drawing.Point(843, 124)
			Me.txtBuyMinqty.Name = "txtBuyMinqty"
			Me.txtBuyMinqty.Size = New Global.System.Drawing.Size(181, 21)
			Me.txtBuyMinqty.TabIndex = 4
			Me.txtBuyMinqty.Text = "0.00"
			Me.txtBuyMinqty.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.cmbCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCategory.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCategory.FormattingEnabled = True
			Me.cmbCategory.Location = New Global.System.Drawing.Point(7, 25)
			Me.cmbCategory.Name = "cmbCategory"
			Me.cmbCategory.Size = New Global.System.Drawing.Size(153, 23)
			Me.cmbCategory.TabIndex = 0
			Me.chkActive.AutoSize = True
			Me.chkActive.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.chkActive.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkActive.Location = New Global.System.Drawing.Point(844, 235)
			Me.chkActive.Name = "chkActive"
			Me.chkActive.Size = New Global.System.Drawing.Size(57, 19)
			Me.chkActive.TabIndex = 8
			Me.chkActive.Text = "Active"
			Me.chkActive.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(726, 86)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(69, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Entry Date :"
			Me.txtGetFreeQty.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtGetFreeQty.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGetFreeQty.Location = New Global.System.Drawing.Point(843, 151)
			Me.txtGetFreeQty.Name = "txtGetFreeQty"
			Me.txtGetFreeQty.Size = New Global.System.Drawing.Size(181, 21)
			Me.txtGetFreeQty.TabIndex = 5
			Me.txtGetFreeQty.Text = "0.00"
			Me.txtGetFreeQty.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(89, 133)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.txtID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtID.Location = New Global.System.Drawing.Point(134, 125)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(27, 21)
			Me.txtID.TabIndex = 8
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-9, 1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1180, 33)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Promotional Offer  (Buy 'X' and Get 'X')"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtProductName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtProductName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductName.Location = New Global.System.Drawing.Point(92, 100)
			Me.txtProductName.Name = "txtProductName"
			Me.txtProductName.[ReadOnly] = True
			Me.txtProductName.Size = New Global.System.Drawing.Size(70, 21)
			Me.txtProductName.TabIndex = 3
			Me.txtProductName.TabStop = False
			Me.txtProductName.Visible = False
			Me.txtProductCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtProductCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductCode.Location = New Global.System.Drawing.Point(94, 73)
			Me.txtProductCode.Name = "txtProductCode"
			Me.txtProductCode.[ReadOnly] = True
			Me.txtProductCode.Size = New Global.System.Drawing.Size(68, 21)
			Me.txtProductCode.TabIndex = 2
			Me.txtProductCode.TabStop = False
			Me.txtProductCode.Visible = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(5, 79)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label5.TabIndex = 325
			Me.Label5.Text = "Product Code :"
			Me.Label5.Visible = False
			Me.txtProductID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtProductID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductID.Location = New Global.System.Drawing.Point(94, 46)
			Me.txtProductID.Name = "txtProductID"
			Me.txtProductID.[ReadOnly] = True
			Me.txtProductID.Size = New Global.System.Drawing.Size(68, 21)
			Me.txtProductID.TabIndex = 1
			Me.txtProductID.TabStop = False
			Me.txtProductID.Visible = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(5, 52)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(64, 13)
			Me.Label4.TabIndex = 324
			Me.Label4.Text = "Product ID :"
			Me.Label4.Visible = False
			Me.GroupBox3.Controls.Add(Me.GelButton2)
			Me.GroupBox3.Controls.Add(Me.Label8)
			Me.GroupBox3.Controls.Add(Me.DateTimePicker1)
			Me.GroupBox3.Controls.Add(Me.Label11)
			Me.GroupBox3.Controls.Add(Me.DateTimePicker2)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(621, 309)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(351, 68)
			Me.GroupBox3.TabIndex = 7
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Search By Expiry Date :"
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(231, 30)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(114, 26)
			Me.GelButton2.TabIndex = 526
			Me.GelButton2.Text = "Get Data"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(116, 14)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label8.TabIndex = 13
			Me.Label8.Text = "To :"
			Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(119, 32)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(108, 21)
			Me.DateTimePicker1.TabIndex = 1
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(6, 16)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label11.TabIndex = 12
			Me.Label11.Text = "From :"
			Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker2.Location = New Global.System.Drawing.Point(6, 32)
			Me.DateTimePicker2.Name = "DateTimePicker2"
			Me.DateTimePicker2.Size = New Global.System.Drawing.Size(107, 21)
			Me.DateTimePicker2.TabIndex = 0
			Me.GroupBox2.Controls.Add(Me.btnGetData)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(256, 309)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(351, 68)
			Me.GroupBox2.TabIndex = 6
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search By Entry Date :"
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
			Me.btnGetData.Location = New Global.System.Drawing.Point(231, 29)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(114, 26)
			Me.btnGetData.TabIndex = 525
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(116, 14)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(119, 32)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(108, 21)
			Me.dtpDateTo.TabIndex = 1
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(6, 16)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(6, 32)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(107, 21)
			Me.dtpDateFrom.TabIndex = 0
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(5, 105)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Product Name :"
			Me.Label7.Visible = False
			Me.GroupBox1.Controls.Add(Me.btnProductData)
			Me.GroupBox1.Controls.Add(Me.txtSearchByProduct)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(6, 309)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(244, 68)
			Me.GroupBox1.TabIndex = 5
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search By Product Name :"
			Me.btnProductData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnProductData.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnProductData.FlatAppearance.BorderSize = 0
			Me.btnProductData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnProductData.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnProductData.ForeColor = Global.System.Drawing.Color.White
			Me.btnProductData.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnProductData.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnProductData.Image = CType(componentResourceManager.GetObject("btnProductData.Image"), Global.System.Drawing.Image)
			Me.btnProductData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnProductData.Location = New Global.System.Drawing.Point(161, 29)
			Me.btnProductData.Name = "btnProductData"
			Me.btnProductData.Size = New Global.System.Drawing.Size(76, 26)
			Me.btnProductData.TabIndex = 524
			Me.btnProductData.Text = "Get Data"
			Me.btnProductData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnProductData.UseVisualStyleBackColor = False
			Me.txtSearchByProduct.BackColor = Global.System.Drawing.Color.White
			Me.txtSearchByProduct.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSearchByProduct.Location = New Global.System.Drawing.Point(11, 29)
			Me.txtSearchByProduct.Name = "txtSearchByProduct"
			Me.txtSearchByProduct.Size = New Global.System.Drawing.Size(143, 22)
			Me.txtSearchByProduct.TabIndex = 0
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
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.SteelBlue
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.SteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Description, Me.Column3, Me.Column2, Me.Column4, Me.Column5, Me.Column9, Me.Column6, Me.Column10, Me.Column11 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(6, 433)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.NavajoWhite
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.Moccasin
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 21
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1157, 156)
			Me.dgw.TabIndex = 13
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			dataGridViewCellStyle6.Format = "dd/MM/yyyy hh:mm:ss tt"
			Me.Description.DefaultCellStyle = dataGridViewCellStyle6
			Me.Description.FillWeight = 100.232F
			Me.Description.HeaderText = "Entry Date"
			Me.Description.Name = "Description"
			Me.Description.[ReadOnly] = True
			Me.Column3.FillWeight = 94.5244F
			Me.Column3.HeaderText = "Product ID"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column2.FillWeight = 95.67721F
			Me.Column2.HeaderText = "Product Code"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column4.FillWeight = 193.4193F
			Me.Column4.HeaderText = "Product"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column5.FillWeight = 68.08435F
			Me.Column5.HeaderText = "Buy Min. Qty."
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column9.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column9.FillWeight = 71.12807F
			Me.Column9.HeaderText = "Get Free Qty."
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column6.FillWeight = 100.3263F
			Me.Column6.HeaderText = "Having Expiry Date ?"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle9.Format = "dd/MM/yyyy"
			Me.Column10.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column10.FillWeight = 101.9659F
			Me.Column10.HeaderText = "Expiry Date"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.FillWeight = 74.64245F
			Me.Column11.HeaderText = "Active"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.btnSelection.BackColor = Global.System.Drawing.Color.Green
			Me.btnSelection.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSelection.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSelection.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSelection.ForeColor = Global.System.Drawing.Color.White
			Me.btnSelection.Location = New Global.System.Drawing.Point(17, 127)
			Me.btnSelection.Name = "btnSelection"
			Me.btnSelection.Size = New Global.System.Drawing.Size(29, 21)
			Me.btnSelection.TabIndex = 1
			Me.btnSelection.Text = "F1"
			Me.btnSelection.UseVisualStyleBackColor = False
			Me.btnSelection.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1172, 598)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmPromotionalOffers"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005258 RID: 21080
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
