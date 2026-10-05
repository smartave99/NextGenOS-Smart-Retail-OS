Namespace BillPoint
	' Token: 0x02000345 RID: 837
		Public Partial Class FrmGDClientSample
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C3E1 RID: 50145 RVA: 0x007C5E0C File Offset: 0x007C400C
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

		' Token: 0x0600C3E2 RID: 50146 RVA: 0x007C5E5C File Offset: 0x007C405C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.FrmGDClientSample))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.textDataDirectory = New Global.System.Windows.Forms.TextBox()
			Me.btnBrowse = New Global.System.Windows.Forms.Button()
			Me.folderBrowserDialog = New Global.System.Windows.Forms.FolderBrowserDialog()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnBackup = New Global.GelButtons.GelButton()
			Me.btnRestore = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dataGridView = New Global.System.Windows.Forms.DataGridView()
			Me.txtDB = New Global.System.Windows.Forms.TextBox()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.dataGridView, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.textDataDirectory.BackColor = Global.System.Drawing.Color.LemonChiffon
			Me.textDataDirectory.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.textDataDirectory.Location = New Global.System.Drawing.Point(9, 60)
			Me.textDataDirectory.Multiline = True
			Me.textDataDirectory.Name = "textDataDirectory"
			Me.textDataDirectory.[ReadOnly] = True
			Me.textDataDirectory.Size = New Global.System.Drawing.Size(687, 23)
			Me.textDataDirectory.TabIndex = 0
			Me.textDataDirectory.TabStop = False
			Me.textDataDirectory.Text = "D:\SBPE_DATA"
			Me.btnBrowse.BackColor = Global.System.Drawing.Color.Black
			Me.btnBrowse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnBrowse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnBrowse.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 11.25F)
			Me.btnBrowse.ForeColor = Global.System.Drawing.Color.White
			Me.btnBrowse.Image = CType(componentResourceManager.GetObject("btnBrowse.Image"), Global.System.Drawing.Image)
			Me.btnBrowse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnBrowse.Location = New Global.System.Drawing.Point(571, 60)
			Me.btnBrowse.Name = "btnBrowse"
			Me.btnBrowse.Size = New Global.System.Drawing.Size(113, 50)
			Me.btnBrowse.TabIndex = 0
			Me.btnBrowse.TabStop = False
			Me.btnBrowse.Text = "Browse"
			Me.btnBrowse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnBrowse.UseVisualStyleBackColor = False
			Me.btnBrowse.Visible = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.btnBackup)
			Me.Panel1.Controls.Add(Me.btnRestore)
			Me.Panel1.Controls.Add(Me.GelButton2)
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.GelButton3)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.dataGridView)
			Me.Panel1.Controls.Add(Me.txtDB)
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.textDataDirectory)
			Me.Panel1.Controls.Add(Me.btnBrowse)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(709, 462)
			Me.Panel1.TabIndex = 5
			Me.btnBackup.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnBackup.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnBackup.FlatAppearance.BorderSize = 0
			Me.btnBackup.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnBackup.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBackup.ForeColor = Global.System.Drawing.Color.White
			Me.btnBackup.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnBackup.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnBackup.Image = CType(componentResourceManager.GetObject("btnBackup.Image"), Global.System.Drawing.Image)
			Me.btnBackup.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnBackup.Location = New Global.System.Drawing.Point(552, 388)
			Me.btnBackup.Name = "btnBackup"
			Me.btnBackup.Size = New Global.System.Drawing.Size(144, 53)
			Me.btnBackup.TabIndex = 529
			Me.btnBackup.Text = "Backup"
			Me.btnBackup.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnBackup.UseVisualStyleBackColor = False
			Me.btnRestore.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnRestore.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnRestore.FlatAppearance.BorderSize = 0
			Me.btnRestore.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRestore.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRestore.ForeColor = Global.System.Drawing.Color.White
			Me.btnRestore.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnRestore.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnRestore.Image = CType(componentResourceManager.GetObject("btnRestore.Image"), Global.System.Drawing.Image)
			Me.btnRestore.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRestore.Location = New Global.System.Drawing.Point(415, 388)
			Me.btnRestore.Name = "btnRestore"
			Me.btnRestore.Size = New Global.System.Drawing.Size(134, 53)
			Me.btnRestore.TabIndex = 528
			Me.btnRestore.Text = "Download"
			Me.btnRestore.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRestore.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(179, 388)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(104, 53)
			Me.GelButton2.TabIndex = 527
			Me.GelButton2.Text = "&Delete"
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(289, 388)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(123, 53)
			Me.GelButton1.TabIndex = 525
			Me.GelButton1.Text = "&Restore"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(69, 388)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 53)
			Me.GelButton3.TabIndex = 526
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.Label3)
			Me.Panel2.Location = New Global.System.Drawing.Point(9, 82)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(687, 22)
			Me.Panel2.TabIndex = 420
			Me.Label3.AutoSize = True
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(3, 5)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(570, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "S.No                                ID                                                                Name                                                               Date"
			Me.dataGridView.AllowUserToAddRows = False
			Me.dataGridView.AllowUserToDeleteRows = False
			Me.dataGridView.AllowUserToResizeColumns = False
			Me.dataGridView.AllowUserToResizeRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dataGridView.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dataGridView.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dataGridView.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dataGridView.BackgroundColor = Global.System.Drawing.Color.White
			Me.dataGridView.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dataGridView.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dataGridView.ColumnHeadersHeight = 29
			Me.dataGridView.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dataGridView.ColumnHeadersVisible = False
			Me.dataGridView.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dataGridView.DefaultCellStyle = dataGridViewCellStyle3
			Me.dataGridView.EnableHeadersVisualStyles = False
			Me.dataGridView.GridColor = Global.System.Drawing.Color.White
			Me.dataGridView.Location = New Global.System.Drawing.Point(9, 103)
			Me.dataGridView.MultiSelect = False
			Me.dataGridView.Name = "dataGridView"
			Me.dataGridView.[ReadOnly] = True
			Me.dataGridView.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dataGridView.RowHeadersWidth = 25
			Me.dataGridView.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dataGridView.RowTemplate.Height = 18
			Me.dataGridView.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dataGridView.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dataGridView.Size = New Global.System.Drawing.Size(687, 263)
			Me.dataGridView.TabIndex = 419
			Me.dataGridView.TabStop = False
			Me.txtDB.Location = New Global.System.Drawing.Point(586, 20)
			Me.txtDB.Multiline = True
			Me.txtDB.Name = "txtDB"
			Me.txtDB.[ReadOnly] = True
			Me.txtDB.Size = New Global.System.Drawing.Size(13, 11)
			Me.txtDB.TabIndex = 418
			Me.txtDB.TabStop = False
			Me.txtDB.Visible = False
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(6, 388)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(57, 53)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 11
			Me.PictureBox1.TabStop = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(605, 20)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 10
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold)
			Me.Label2.Location = New Global.System.Drawing.Point(6, 43)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(196, 15)
			Me.Label2.TabIndex = 7
			Me.Label2.Text = "Backup and Download Folder Path :"
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, -1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(709, 31)
			Me.Label1.TabIndex = 5
			Me.Label1.Text = "Cloud Backup and Restore"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(709, 462)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "FrmGDClientSample"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.dataGridView, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004E83 RID: 20099
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
