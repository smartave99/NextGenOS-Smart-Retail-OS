Namespace BillPoint
	' Token: 0x020005E2 RID: 1506
		Public Partial Class frmRegistration
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012828 RID: 75816 RVA: 0x00AA7678 File Offset: 0x00AA5878
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

		' Token: 0x06012829 RID: 75817 RVA: 0x00AA76C8 File Offset: 0x00AA58C8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmRegistration))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.txtEmail = New Global.System.Windows.Forms.TextBox()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtSign = New Global.System.Windows.Forms.TextBox()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.BStartCapture = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Button9 = New Global.System.Windows.Forms.Button()
			Me.Button10 = New Global.System.Windows.Forms.Button()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.btnCheckAvailability = New Global.System.Windows.Forms.Button()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.txtName = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.cmbUserType = New Global.System.Windows.Forms.ComboBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtUserID = New Global.System.Windows.Forms.TextBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.chkActive = New Global.System.Windows.Forms.CheckBox()
			Me.txtPassword = New Global.System.Windows.Forms.TextBox()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Description = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel5.SuspendLayout()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.BackColor = Global.System.Drawing.Color.Transparent
			label.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(601, 188)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label9"
			label.Size = New Global.System.Drawing.Size(25, 15)
			label.TabIndex = 295
			label.Text = "OR"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.txtEmail)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(862, 548)
			Me.Panel1.TabIndex = 2
			Me.txtEmail.Location = New Global.System.Drawing.Point(839, 237)
			Me.txtEmail.Name = "txtEmail"
			Me.txtEmail.[ReadOnly] = True
			Me.txtEmail.Size = New Global.System.Drawing.Size(10, 20)
			Me.txtEmail.TabIndex = 8
			Me.txtEmail.TabStop = False
			Me.txtEmail.Visible = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Button2)
			Me.Panel4.Controls.Add(Me.Button1)
			Me.Panel4.Controls.Add(Me.Label10)
			Me.Panel4.Controls.Add(Me.txtSign)
			Me.Panel4.Controls.Add(Me.PictureBox1)
			Me.Panel4.Controls.Add(Me.BStartCapture)
			Me.Panel4.Controls.Add(Me.Browse)
			Me.Panel4.Controls.Add(label)
			Me.Panel4.Controls.Add(Me.BRemove)
			Me.Panel4.Controls.Add(Me.Button9)
			Me.Panel4.Controls.Add(Me.Button10)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.btnCheckAvailability)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.txtContactNo)
			Me.Panel4.Controls.Add(Me.txtEmailID)
			Me.Panel4.Controls.Add(Me.txtName)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.cmbUserType)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.txtUserID)
			Me.Panel4.Controls.Add(Me.Panel5)
			Me.Panel4.Controls.Add(Me.txtPassword)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(3, 37)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(712, 237)
			Me.Panel4.TabIndex = 0
			Me.Button2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(438, 207)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(67, 24)
			Me.Button2.TabIndex = 409
			Me.Button2.TabStop = False
			Me.Button2.Text = "Clear"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(359, 207)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(73, 24)
			Me.Button1.TabIndex = 7
			Me.Button1.Text = "Browse"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(7, 209)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(132, 15)
			Me.Label10.TabIndex = 298
			Me.Label10.Text = "Signature Image Path :"
			Me.txtSign.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSign.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSign.Location = New Global.System.Drawing.Point(141, 209)
			Me.txtSign.Name = "txtSign"
			Me.txtSign.[ReadOnly] = True
			Me.txtSign.Size = New Global.System.Drawing.Size(212, 21)
			Me.txtSign.TabIndex = 7
			Me.txtSign.TabStop = False
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.PictureBox1.Location = New Global.System.Drawing.Point(520, 4)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(186, 152)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 296
			Me.PictureBox1.TabStop = False
			Me.BStartCapture.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BStartCapture.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BStartCapture.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BStartCapture.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BStartCapture.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BStartCapture.ForeColor = Global.System.Drawing.Color.White
			Me.BStartCapture.Location = New Global.System.Drawing.Point(520, 207)
			Me.BStartCapture.Name = "BStartCapture"
			Me.BStartCapture.Size = New Global.System.Drawing.Size(186, 24)
			Me.BStartCapture.TabIndex = 294
			Me.BStartCapture.Text = "Use Webcam"
			Me.BStartCapture.UseVisualStyleBackColor = False
			Me.Browse.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.White
			Me.Browse.Location = New Global.System.Drawing.Point(520, 161)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(80, 24)
			Me.Browse.TabIndex = 292
			Me.Browse.Text = "Browse..."
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(626, 161)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(80, 24)
			Me.BRemove.TabIndex = 293
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Button9.BackColor = Global.System.Drawing.Color.White
			Me.Button9.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button9.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button9.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button9.ForeColor = Global.System.Drawing.Color.White
			Me.Button9.Image = CType(componentResourceManager.GetObject("Button9.Image"), Global.System.Drawing.Image)
			Me.Button9.Location = New Global.System.Drawing.Point(315, 69)
			Me.Button9.Name = "Button9"
			Me.Button9.Size = New Global.System.Drawing.Size(37, 18)
			Me.Button9.TabIndex = 110
			Me.Button9.TabStop = False
			Me.Button9.UseVisualStyleBackColor = False
			Me.Button10.BackColor = Global.System.Drawing.Color.White
			Me.Button10.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button10.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button10.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button10.ForeColor = Global.System.Drawing.Color.White
			Me.Button10.Image = CType(componentResourceManager.GetObject("Button10.Image"), Global.System.Drawing.Image)
			Me.Button10.Location = New Global.System.Drawing.Point(315, 69)
			Me.Button10.Name = "Button10"
			Me.Button10.Size = New Global.System.Drawing.Size(37, 18)
			Me.Button10.TabIndex = 109
			Me.Button10.TabStop = False
			Me.Button10.UseVisualStyleBackColor = False
			Me.Button10.Visible = False
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(7, 175)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(47, 15)
			Me.Label8.TabIndex = 16
			Me.Label8.Text = "Status :"
			Me.btnCheckAvailability.BackColor = Global.System.Drawing.Color.White
			Me.btnCheckAvailability.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnCheckAvailability.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnCheckAvailability.Image = CType(componentResourceManager.GetObject("btnCheckAvailability.Image"), Global.System.Drawing.Image)
			Me.btnCheckAvailability.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCheckAvailability.Location = New Global.System.Drawing.Point(373, 11)
			Me.btnCheckAvailability.Name = "btnCheckAvailability"
			Me.btnCheckAvailability.Size = New Global.System.Drawing.Size(139, 36)
			Me.btnCheckAvailability.TabIndex = 7
			Me.btnCheckAvailability.TabStop = False
			Me.btnCheckAvailability.Text = "Check Availability"
			Me.btnCheckAvailability.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCheckAvailability.UseVisualStyleBackColor = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(7, 148)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(73, 15)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Contact No :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(7, 121)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(60, 15)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "Email ID :"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(7, 94)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(47, 15)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Name :"
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(118, 148)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(235, 21)
			Me.txtContactNo.TabIndex = 5
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.Location = New Global.System.Drawing.Point(118, 121)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(235, 21)
			Me.txtEmailID.TabIndex = 4
			Me.txtName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtName.Location = New Global.System.Drawing.Point(118, 94)
			Me.txtName.Name = "txtName"
			Me.txtName.Size = New Global.System.Drawing.Size(235, 21)
			Me.txtName.TabIndex = 3
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(7, 67)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(67, 15)
			Me.Label4.TabIndex = 6
			Me.Label4.Text = "Password :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(7, 41)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(68, 15)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "User Type :"
			Me.cmbUserType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbUserType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbUserType.FormattingEnabled = True
			Me.cmbUserType.Items.AddRange(New Object() { "Admin", "Moderator", "Sales Person", "Inventory Manager" })
			Me.cmbUserType.Location = New Global.System.Drawing.Point(118, 38)
			Me.cmbUserType.Name = "cmbUserType"
			Me.cmbUserType.Size = New Global.System.Drawing.Size(235, 23)
			Me.cmbUserType.TabIndex = 1
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(7, 14)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(54, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "User ID :"
			Me.txtUserID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtUserID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUserID.Location = New Global.System.Drawing.Point(118, 11)
			Me.txtUserID.Name = "txtUserID"
			Me.txtUserID.Size = New Global.System.Drawing.Size(235, 21)
			Me.txtUserID.TabIndex = 0
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.PictureBox2)
			Me.Panel5.Controls.Add(Me.chkActive)
			Me.Panel5.Location = New Global.System.Drawing.Point(118, 175)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(113, 27)
			Me.Panel5.TabIndex = 112
			Me.PictureBox2.BackColor = Global.System.Drawing.Color.White
			Me.PictureBox2.Image = CType(componentResourceManager.GetObject("PictureBox2.Image"), Global.System.Drawing.Image)
			Me.PictureBox2.Location = New Global.System.Drawing.Point(81, -4)
			Me.PictureBox2.Name = "PictureBox2"
			Me.PictureBox2.Size = New Global.System.Drawing.Size(31, 31)
			Me.PictureBox2.TabIndex = 113
			Me.PictureBox2.TabStop = False
			Me.chkActive.AutoSize = True
			Me.chkActive.BackColor = Global.System.Drawing.Color.White
			Me.chkActive.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkActive.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkActive.ForeColor = Global.System.Drawing.Color.Red
			Me.chkActive.Location = New Global.System.Drawing.Point(3, 2)
			Me.chkActive.Name = "chkActive"
			Me.chkActive.Size = New Global.System.Drawing.Size(75, 25)
			Me.chkActive.TabIndex = 6
			Me.chkActive.Text = "Active"
			Me.chkActive.UseVisualStyleBackColor = False
			Me.txtPassword.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPassword.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPassword.Location = New Global.System.Drawing.Point(118, 67)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.PasswordChar = "♥"c
			Me.txtPassword.Size = New Global.System.Drawing.Size(235, 21)
			Me.txtPassword.TabIndex = 2
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(721, 37)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(130, 237)
			Me.Panel3.TabIndex = 2
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(5, 98)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(118, 43)
			Me.btnUpdate.TabIndex = 521
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(5, 145)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(118, 43)
			Me.btnDelete.TabIndex = 520
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
			Me.btnNew.Location = New Global.System.Drawing.Point(5, 3)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(118, 43)
			Me.btnNew.TabIndex = 519
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
			Me.btnSave.Location = New Global.System.Drawing.Point(5, 50)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(118, 43)
			Me.btnSave.TabIndex = 518
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
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
			Me.dgw.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Description, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column7, Me.Column6, Me.Column8, Me.Column9 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(3, 280)
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
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.MediumPurple
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(848, 255)
			Me.dgw.TabIndex = 1
			Me.dgw.TabStop = False
			Me.Description.HeaderText = "User ID"
			Me.Description.Name = "Description"
			Me.Description.[ReadOnly] = True
			Me.Column1.HeaderText = "User Type"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			dataGridViewCellStyle6.NullValue = Nothing
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column2.HeaderText = "Password"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Email ID"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "Contact No."
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column7.HeaderText = "Active"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			dataGridViewCellStyle7.Format = "dd/MM/yyyy hh:mm:ss tt"
			Me.Column6.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column6.HeaderText = "Registered Date"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column8.HeaderText = "Photo"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column8.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column8.Visible = False
			Me.Column9.HeaderText = "Sign"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column9.Visible = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.TextBox1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-2, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(863, 31)
			Me.Panel2.TabIndex = 0
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(690, 5)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(320, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(230, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "List of Registered Users"
			Me.TextBox1.Location = New Global.System.Drawing.Point(668, 21)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(111, 20)
			Me.TextBox1.TabIndex = 4
			Me.TextBox1.Visible = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(862, 548)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmRegistration"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel5.ResumeLayout(False)
			Me.Panel5.PerformLayout()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006F68 RID: 28520
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
