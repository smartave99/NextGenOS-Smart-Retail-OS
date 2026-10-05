Namespace BillPoint
	' Token: 0x020005BA RID: 1466
		Public Partial Class frmSqlServerSetting
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06011DD2 RID: 73170 RVA: 0x00A4CA34 File Offset: 0x00A4AC34
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

		' Token: 0x06011DD3 RID: 73171 RVA: 0x00A4CA84 File Offset: 0x00A4AC84
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSqlServerSetting))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.cmbServerName = New Global.System.Windows.Forms.ComboBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.txtPassword = New Global.System.Windows.Forms.TextBox()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.btnTestConnection = New Global.System.Windows.Forms.Button()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.txtUserName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.btnCreateDemoDataDB = New Global.System.Windows.Forms.Button()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.btnClose = New Global.System.Windows.Forms.Button()
			Me.Timer2 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(7, 7)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(604, 300)
			Me.Panel1.TabIndex = 2
			Me.GroupBox1.Controls.Add(Me.cmbServerName)
			Me.GroupBox1.Controls.Add(Me.Button1)
			Me.GroupBox1.Controls.Add(Me.PictureBox2)
			Me.GroupBox1.Controls.Add(Me.txtPassword)
			Me.GroupBox1.Controls.Add(Me.PictureBox1)
			Me.GroupBox1.Controls.Add(Me.btnTestConnection)
			Me.GroupBox1.Controls.Add(Me.LinkLabel1)
			Me.GroupBox1.Controls.Add(Me.txtUserName)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.btnCreateDemoDataDB)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(5, 47)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(592, 247)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "SQL Server Configuration"
			Me.cmbServerName.BackColor = Global.System.Drawing.Color.White
			Me.cmbServerName.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbServerName.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.cmbServerName.FormattingEnabled = True
			Me.cmbServerName.Location = New Global.System.Drawing.Point(190, 24)
			Me.cmbServerName.Name = "cmbServerName"
			Me.cmbServerName.Size = New Global.System.Drawing.Size(271, 29)
			Me.cmbServerName.TabIndex = 0
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(143, 196)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(144, 45)
			Me.Button1.TabIndex = 21
			Me.Button1.TabStop = False
			Me.Button1.Text = "Reset"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.PictureBox2.Image = CType(componentResourceManager.GetObject("PictureBox2.Image"), Global.System.Drawing.Image)
			Me.PictureBox2.Location = New Global.System.Drawing.Point(513, 49)
			Me.PictureBox2.Name = "PictureBox2"
			Me.PictureBox2.Size = New Global.System.Drawing.Size(39, 37)
			Me.PictureBox2.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox2.TabIndex = 20
			Me.PictureBox2.TabStop = False
			Me.txtPassword.BackColor = Global.System.Drawing.Color.White
			Me.txtPassword.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPassword.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.txtPassword.Location = New Global.System.Drawing.Point(190, 128)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.PasswordChar = "✹"c
			Me.txtPassword.Size = New Global.System.Drawing.Size(271, 29)
			Me.txtPassword.TabIndex = 6
			Me.txtPassword.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(2, 153)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(101, 89)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 19
			Me.PictureBox1.TabStop = False
			Me.btnTestConnection.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnTestConnection.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTestConnection.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTestConnection.FlatAppearance.BorderSize = 0
			Me.btnTestConnection.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnTestConnection.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTestConnection.ForeColor = Global.System.Drawing.Color.White
			Me.btnTestConnection.Image = Global.BillPoint.My.Resources.Resources.Database_Active_icon1
			Me.btnTestConnection.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnTestConnection.Location = New Global.System.Drawing.Point(293, 196)
			Me.btnTestConnection.Name = "btnTestConnection"
			Me.btnTestConnection.Size = New Global.System.Drawing.Size(144, 45)
			Me.btnTestConnection.TabIndex = 18
			Me.btnTestConnection.Text = "Test Data Base Connection"
			Me.btnTestConnection.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnTestConnection.UseVisualStyleBackColor = False
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(480, 28)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(110, 20)
			Me.LinkLabel1.TabIndex = 1
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Search Servers"
			Me.txtUserName.BackColor = Global.System.Drawing.Color.White
			Me.txtUserName.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUserName.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.txtUserName.Location = New Global.System.Drawing.Point(190, 76)
			Me.txtUserName.Name = "txtUserName"
			Me.txtUserName.Size = New Global.System.Drawing.Size(271, 29)
			Me.txtUserName.TabIndex = 5
			Me.txtUserName.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label3.Location = New Global.System.Drawing.Point(5, 76)
			Me.Label3.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(183, 21)
			Me.Label3.TabIndex = 8
			Me.Label3.Text = "SQL Server User Name :"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label2.Location = New Global.System.Drawing.Point(5, 128)
			Me.Label2.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(157, 21)
			Me.Label2.TabIndex = 7
			Me.Label2.Text = "SQL User Password :"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label5.Location = New Global.System.Drawing.Point(5, 24)
			Me.Label5.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(146, 21)
			Me.Label5.TabIndex = 10
			Me.Label5.Text = "SQL Server Name :"
			Me.btnCreateDemoDataDB.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnCreateDemoDataDB.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnCreateDemoDataDB.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnCreateDemoDataDB.FlatAppearance.BorderSize = 0
			Me.btnCreateDemoDataDB.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCreateDemoDataDB.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCreateDemoDataDB.ForeColor = Global.System.Drawing.Color.White
			Me.btnCreateDemoDataDB.Image = CType(componentResourceManager.GetObject("btnCreateDemoDataDB.Image"), Global.System.Drawing.Image)
			Me.btnCreateDemoDataDB.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCreateDemoDataDB.Location = New Global.System.Drawing.Point(442, 196)
			Me.btnCreateDemoDataDB.Name = "btnCreateDemoDataDB"
			Me.btnCreateDemoDataDB.Size = New Global.System.Drawing.Size(144, 45)
			Me.btnCreateDemoDataDB.TabIndex = 8
			Me.btnCreateDemoDataDB.Text = "Save SQL Server Setting"
			Me.btnCreateDemoDataDB.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCreateDemoDataDB.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.lblSet)
			Me.Panel2.Controls.Add(Me.btnClose)
			Me.Panel2.Location = New Global.System.Drawing.Point(5, 5)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(592, 33)
			Me.Panel2.TabIndex = 1
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(205, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(187, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "SQL Server Setting"
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(80, 15)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 21
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.btnClose.BackColor = Global.System.Drawing.Color.White
			Me.btnClose.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnClose.FlatAppearance.BorderSize = 0
			Me.btnClose.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnClose.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnClose.ForeColor = Global.System.Drawing.Color.White
			Me.btnClose.Image = CType(componentResourceManager.GetObject("btnClose.Image"), Global.System.Drawing.Image)
			Me.btnClose.Location = New Global.System.Drawing.Point(560, 1)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New Global.System.Drawing.Size(31, 31)
			Me.btnClose.TabIndex = 9
			Me.btnClose.Text = "                                         &Close"
			Me.btnClose.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnClose.UseVisualStyleBackColor = False
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AcceptButton = Me.btnCreateDemoDataDB
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(618, 315)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmSqlServerSetting"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006B70 RID: 27504
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
