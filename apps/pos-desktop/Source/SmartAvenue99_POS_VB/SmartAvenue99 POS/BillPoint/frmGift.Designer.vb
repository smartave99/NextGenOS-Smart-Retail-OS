Namespace BillPoint
	' Token: 0x02000114 RID: 276
		Public Partial Class frmGift
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002F11 RID: 12049 RVA: 0x001D01D8 File Offset: 0x001CE3D8
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

		' Token: 0x06002F12 RID: 12050 RVA: 0x001D0228 File Offset: 0x001CE428
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmGift))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.lblValid = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.lblDiscAmt = New Global.System.Windows.Forms.Label()
			Me.lblOfferDetail = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtFreeRs = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtSaleAmtTo = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.txtSaleAmtFrom = New Global.System.Windows.Forms.TextBox()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.Browse)
			Me.Panel1.Controls.Add(Me.BRemove)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(827, 448)
			Me.Panel1.TabIndex = 1
			Me.Button2.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.DimGray
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(703, 387)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(99, 34)
			Me.Button2.TabIndex = 418
			Me.Button2.TabStop = False
			Me.Button2.Text = "WhatsApp"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.DimGray
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(703, 347)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(99, 34)
			Me.Button1.TabIndex = 417
			Me.Button1.TabStop = False
			Me.Button1.Text = "Export"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.Browse.BackColor = Global.System.Drawing.Color.Transparent
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.DimGray
			Me.Browse.Image = CType(componentResourceManager.GetObject("Browse.Image"), Global.System.Drawing.Image)
			Me.Browse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Browse.Location = New Global.System.Drawing.Point(703, 267)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(99, 34)
			Me.Browse.TabIndex = 415
			Me.Browse.TabStop = False
			Me.Browse.Text = "Browse"
			Me.Browse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.Transparent
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.DimGray
			Me.BRemove.Image = CType(componentResourceManager.GetObject("BRemove.Image"), Global.System.Drawing.Image)
			Me.BRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BRemove.Location = New Global.System.Drawing.Point(703, 307)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(99, 34)
			Me.BRemove.TabIndex = 416
			Me.BRemove.TabStop = False
			Me.BRemove.Text = "Remove"
			Me.BRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Panel4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Panel6)
			Me.Panel4.Controls.Add(Me.lblValid)
			Me.Panel4.Controls.Add(Me.Panel5)
			Me.Panel4.Location = New Global.System.Drawing.Point(355, 190)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(346, 231)
			Me.Panel4.TabIndex = 414
			Me.Panel6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel6.BackgroundImage = Global.BillPoint.My.Resources.Resources.offer
			Me.Panel6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel6.Location = New Global.System.Drawing.Point(0, 22)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(344, 174)
			Me.Panel6.TabIndex = 416
			Me.lblValid.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			Me.lblValid.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.lblValid.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblValid.ForeColor = Global.System.Drawing.Color.White
			Me.lblValid.Location = New Global.System.Drawing.Point(0, 0)
			Me.lblValid.Name = "lblValid"
			Me.lblValid.Size = New Global.System.Drawing.Size(344, 23)
			Me.lblValid.TabIndex = 415
			Me.lblValid.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel5.BackColor = Global.System.Drawing.Color.PaleGreen
			Me.Panel5.Controls.Add(Me.lblDiscAmt)
			Me.Panel5.Controls.Add(Me.lblOfferDetail)
			Me.Panel5.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.Panel5.Location = New Global.System.Drawing.Point(0, 195)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(344, 34)
			Me.Panel5.TabIndex = 0
			Me.lblDiscAmt.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblDiscAmt.Location = New Global.System.Drawing.Point(3, 2)
			Me.lblDiscAmt.Name = "lblDiscAmt"
			Me.lblDiscAmt.Size = New Global.System.Drawing.Size(337, 14)
			Me.lblDiscAmt.TabIndex = 1
			Me.lblDiscAmt.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lblOfferDetail.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblOfferDetail.Location = New Global.System.Drawing.Point(2, 17)
			Me.lblOfferDetail.Name = "lblOfferDetail"
			Me.lblOfferDetail.Size = New Global.System.Drawing.Size(338, 14)
			Me.lblOfferDetail.TabIndex = 0
			Me.lblOfferDetail.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Location = New Global.System.Drawing.Point(251, 238)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(102, 197)
			Me.Panel3.TabIndex = 413
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
			Me.btnNew.Location = New Global.System.Drawing.Point(4, 2)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(94, 43)
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
			Me.btnSave.Location = New Global.System.Drawing.Point(4, 49)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(94, 43)
			Me.btnSave.TabIndex = 520
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(4, 144)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(94, 43)
			Me.btnDelete.TabIndex = 522
			Me.btnDelete.Text = "Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(4, 97)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(94, 43)
			Me.btnUpdate.TabIndex = 523
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.txtID)
			Me.Panel2.Controls.Add(Me.Label5)
			Me.Panel2.Controls.Add(Me.Label4)
			Me.Panel2.Controls.Add(Me.dtpDateTo)
			Me.Panel2.Controls.Add(Me.dtpDateFrom)
			Me.Panel2.Controls.Add(Me.Label3)
			Me.Panel2.Controls.Add(Me.txtFreeRs)
			Me.Panel2.Controls.Add(Me.Label2)
			Me.Panel2.Controls.Add(Me.txtSaleAmtTo)
			Me.Panel2.Controls.Add(Me.Label14)
			Me.Panel2.Controls.Add(Me.txtSaleAmtFrom)
			Me.Panel2.Location = New Global.System.Drawing.Point(5, 240)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(242, 181)
			Me.Panel2.TabIndex = 412
			Me.txtID.Location = New Global.System.Drawing.Point(77, 156)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(20, 20)
			Me.txtID.TabIndex = 422
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(3, 146)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label5.TabIndex = 421
			Me.Label5.Text = "To Date :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(3, 113)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label4.TabIndex = 420
			Me.Label4.Text = "From Date :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(108, 146)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 419
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(108, 113)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 416
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(3, 79)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(94, 13)
			Me.Label3.TabIndex = 415
			Me.Label3.Text = "Discount Amount :"
			Me.txtFreeRs.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtFreeRs.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtFreeRs.Location = New Global.System.Drawing.Point(108, 79)
			Me.txtFreeRs.Name = "txtFreeRs"
			Me.txtFreeRs.Size = New Global.System.Drawing.Size(120, 21)
			Me.txtFreeRs.TabIndex = 414
			Me.txtFreeRs.Text = "0.00"
			Me.txtFreeRs.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(3, 47)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(89, 13)
			Me.Label2.TabIndex = 413
			Me.Label2.Text = "Sale Amount To :"
			Me.txtSaleAmtTo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSaleAmtTo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSaleAmtTo.Location = New Global.System.Drawing.Point(108, 45)
			Me.txtSaleAmtTo.Name = "txtSaleAmtTo"
			Me.txtSaleAmtTo.Size = New Global.System.Drawing.Size(120, 21)
			Me.txtSaleAmtTo.TabIndex = 412
			Me.txtSaleAmtTo.Text = "0.00"
			Me.txtSaleAmtTo.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(3, 11)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(99, 13)
			Me.Label14.TabIndex = 411
			Me.Label14.Text = "Sale Amount From :"
			Me.txtSaleAmtFrom.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSaleAmtFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSaleAmtFrom.Location = New Global.System.Drawing.Point(108, 11)
			Me.txtSaleAmtFrom.Name = "txtSaleAmtFrom"
			Me.txtSaleAmtFrom.Size = New Global.System.Drawing.Size(120, 21)
			Me.txtSaleAmtFrom.TabIndex = 410
			Me.txtSaleAmtFrom.Text = "0.00"
			Me.txtSaleAmtFrom.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(5, 39)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
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
			Me.dgw.RowTemplate.Height = 25
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(815, 145)
			Me.dgw.TabIndex = 409
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.HeaderText = "Sale Amount From"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Sale Amount To"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Discount Amount"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "From Date"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "To Date"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(653, 15)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 408
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(827, 31)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Customer Gift Offer Validation"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(827, 448)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmGift"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel5.ResumeLayout(False)
			Me.Panel3.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400141B RID: 5147
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
