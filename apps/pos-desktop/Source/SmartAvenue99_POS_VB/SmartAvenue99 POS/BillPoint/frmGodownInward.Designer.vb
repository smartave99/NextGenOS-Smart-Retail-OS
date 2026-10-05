Namespace BillPoint
	' Token: 0x02000119 RID: 281
		Public Partial Class frmGodownInward
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06003009 RID: 12297 RVA: 0x001D8C4C File Offset: 0x001D6E4C
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

		' Token: 0x0600300A RID: 12298 RVA: 0x001D8C9C File Offset: 0x001D6E9C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmGodownInward))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnExportExcel = New Global.CButtonLib.CButton()
			Me.lblProductCode = New Global.System.Windows.Forms.Label()
			Me.lblID = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnReset = New Global.CButtonLib.CButton()
			Me.btnGetData = New Global.CButtonLib.CButton()
			Me.TableLayoutPanel1 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.DateTimePicker2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.btnSearch = New Global.System.Windows.Forms.Button()
			Me.DGVUserData = New Global.System.Windows.Forms.DataGridView()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.lblCompID = New Global.System.Windows.Forms.Label()
			Me.lblDB = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ContextMenuStrip1 = New Global.System.Windows.Forms.ContextMenuStrip(Me.components)
			Me.AcceptToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.RejectToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.CopyBranchIDToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.Panel1.SuspendLayout()
			Me.TableLayoutPanel1.SuspendLayout()
			CType(Me.DGVUserData, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.ContextMenuStrip1.SuspendLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.pbgiftqr)
			Me.Panel1.Controls.Add(Me.btnExportExcel)
			Me.Panel1.Controls.Add(Me.lblProductCode)
			Me.Panel1.Controls.Add(Me.lblID)
			Me.Panel1.Controls.Add(Me.ComboBox1)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.btnReset)
			Me.Panel1.Controls.Add(Me.btnGetData)
			Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
			Me.Panel1.Controls.Add(Me.DGVUserData)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.lblCompID)
			Me.Panel1.Controls.Add(Me.lblDB)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(6, 6)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(883, 485)
			Me.Panel1.TabIndex = 0
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnExportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExportExcel.Corners.All = 5
			Me.btnExportExcel.Corners.LowerLeft = 5
			Me.btnExportExcel.Corners.LowerRight = 5
			Me.btnExportExcel.Corners.UpperLeft = 5
			Me.btnExportExcel.Corners.UpperRight = 5
			Me.btnExportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnExportExcel.DesignerSelected = False
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnExportExcel.ImageIndex = 0
			Me.btnExportExcel.ImageSize = New Global.System.Drawing.Size(28, 28)
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(154, 41)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(50, 49)
			Me.btnExportExcel.TabIndex = 1760
			Me.btnExportExcel.TabStop = False
			Me.btnExportExcel.Text = "Export"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.lblProductCode.AutoSize = True
			Me.lblProductCode.Location = New Global.System.Drawing.Point(126, 14)
			Me.lblProductCode.Name = "lblProductCode"
			Me.lblProductCode.Size = New Global.System.Drawing.Size(79, 13)
			Me.lblProductCode.TabIndex = 1758
			Me.lblProductCode.Text = "lblProductCode"
			Me.lblProductCode.Visible = False
			Me.lblID.AutoSize = True
			Me.lblID.Location = New Global.System.Drawing.Point(71, 14)
			Me.lblID.Name = "lblID"
			Me.lblID.Size = New Global.System.Drawing.Size(28, 13)
			Me.lblID.TabIndex = 1757
			Me.lblID.Text = "lblID"
			Me.lblID.Visible = False
			Me.ComboBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Transferred", "Accepted", "Rejected" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(218, 58)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(148, 25)
			Me.ComboBox1.TabIndex = 2
			Me.Label2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.Label2.Location = New Global.System.Drawing.Point(215, 38)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(117, 17)
			Me.Label2.TabIndex = 1756
			Me.Label2.Text = "Search By Status :"
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Corners.All = 5
			Me.btnReset.Corners.LowerLeft = 5
			Me.btnReset.Corners.LowerRight = 5
			Me.btnReset.Corners.UpperLeft = 5
			Me.btnReset.Corners.UpperRight = 5
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.DesignerSelected = False
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnReset.ImageIndex = 0
			Me.btnReset.ImageSize = New Global.System.Drawing.Size(32, 32)
			Me.btnReset.Location = New Global.System.Drawing.Point(95, 41)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(50, 49)
			Me.btnReset.TabIndex = 1
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.btnGetData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGetData.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnGetData.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnGetData.Corners.All = 5
			Me.btnGetData.Corners.LowerLeft = 5
			Me.btnGetData.Corners.LowerRight = 5
			Me.btnGetData.Corners.UpperLeft = 5
			Me.btnGetData.Corners.UpperRight = 5
			Me.btnGetData.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnGetData.DesignerSelected = False
			Me.btnGetData.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnGetData.ImageIndex = 0
			Me.btnGetData.ImageSize = New Global.System.Drawing.Size(32, 32)
			Me.btnGetData.Location = New Global.System.Drawing.Point(6, 41)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(81, 49)
			Me.btnGetData.TabIndex = 0
			Me.btnGetData.Text = "Show &Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.TableLayoutPanel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TableLayoutPanel1.BackColor = Global.System.Drawing.Color.FromArgb(192, 192, 255)
			Me.TableLayoutPanel1.CellBorderStyle = Global.System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
			Me.TableLayoutPanel1.ColumnCount = 5
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 10F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 15F))
			Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker2, 3, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label9, 2, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker1, 1, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.btnSearch, 4, 0)
			Me.TableLayoutPanel1.Location = New Global.System.Drawing.Point(372, 43)
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 1
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 100F))
			Me.TableLayoutPanel1.Size = New Global.System.Drawing.Size(503, 40)
			Me.TableLayoutPanel1.TabIndex = 1752
			Me.DateTimePicker2.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.DateTimePicker2.CalendarFont = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker2.CustomFormat = "dd-MM-yyyy"
			Me.DateTimePicker2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker2.Location = New Global.System.Drawing.Point(303, 6)
			Me.DateTimePicker2.Margin = New Global.System.Windows.Forms.Padding(2, 4, 2, 4)
			Me.DateTimePicker2.Name = "DateTimePicker2"
			Me.DateTimePicker2.Size = New Global.System.Drawing.Size(120, 29)
			Me.DateTimePicker2.TabIndex = 1
			Me.Label9.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label9.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.Black
			Me.Label9.Location = New Global.System.Drawing.Point(253, 1)
			Me.Label9.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(45, 38)
			Me.Label9.TabIndex = 35
			Me.Label9.Text = "To"
			Me.Label9.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label7.AutoSize = True
			Me.Label7.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label7.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.ForeColor = Global.System.Drawing.Color.Black
			Me.Label7.Location = New Global.System.Drawing.Point(3, 1)
			Me.Label7.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(120, 38)
			Me.Label7.TabIndex = 3
			Me.Label7.Text = "Entry Date From"
			Me.Label7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.DateTimePicker1.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.DateTimePicker1.CalendarFont = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker1.CustomFormat = "dd-MM-yyyy"
			Me.DateTimePicker1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTimePicker1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(128, 6)
			Me.DateTimePicker1.Margin = New Global.System.Windows.Forms.Padding(2, 4, 2, 4)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(120, 29)
			Me.DateTimePicker1.TabIndex = 0
			Me.btnSearch.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSearch.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnSearch.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.btnSearch.Location = New Global.System.Drawing.Point(429, 4)
			Me.btnSearch.Name = "btnSearch"
			Me.btnSearch.Size = New Global.System.Drawing.Size(70, 32)
			Me.btnSearch.TabIndex = 2
			Me.btnSearch.Text = "Search"
			Me.btnSearch.UseVisualStyleBackColor = True
			Me.DGVUserData.AllowUserToAddRows = False
			Me.DGVUserData.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.Cornsilk
			Me.DGVUserData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DGVUserData.BackgroundColor = Global.System.Drawing.Color.White
			Me.DGVUserData.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DGVUserData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DGVUserData.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DGVUserData.DefaultCellStyle = dataGridViewCellStyle3
			Me.DGVUserData.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.DGVUserData.GridColor = Global.System.Drawing.Color.DeepSkyBlue
			Me.DGVUserData.Location = New Global.System.Drawing.Point(0, 97)
			Me.DGVUserData.Margin = New Global.System.Windows.Forms.Padding(2, 4, 2, 4)
			Me.DGVUserData.Name = "DGVUserData"
			Me.DGVUserData.[ReadOnly] = True
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DGVUserData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DeepSkyBlue
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DGVUserData.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DGVUserData.RowTemplate.Height = 30
			Me.DGVUserData.RowTemplate.[ReadOnly] = True
			Me.DGVUserData.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DGVUserData.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DGVUserData.Size = New Global.System.Drawing.Size(881, 386)
			Me.DGVUserData.TabIndex = 1751
			Me.DGVUserData.TabStop = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(832, 14)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1723
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.lblCompID.AutoSize = True
			Me.lblCompID.Location = New Global.System.Drawing.Point(10, 14)
			Me.lblCompID.Name = "lblCompID"
			Me.lblCompID.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCompID.TabIndex = 1722
			Me.lblCompID.Text = "lblCompID"
			Me.lblCompID.Visible = False
			Me.lblDB.AutoSize = True
			Me.lblDB.Location = New Global.System.Drawing.Point(788, 14)
			Me.lblDB.Name = "lblDB"
			Me.lblDB.Size = New Global.System.Drawing.Size(32, 13)
			Me.lblDB.TabIndex = 1721
			Me.lblDB.Text = "lblDB"
			Me.lblDB.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.Green
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Black", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(6, 5)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(869, 33)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "Inward Stock Transfer"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.ContextMenuStrip1.Items.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.AcceptToolStripMenuItem, Me.RejectToolStripMenuItem, Me.CopyBranchIDToolStripMenuItem })
			Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
			Me.ContextMenuStrip1.Size = New Global.System.Drawing.Size(157, 70)
			Me.AcceptToolStripMenuItem.BackColor = Global.System.Drawing.Color.Lime
			Me.AcceptToolStripMenuItem.Image = CType(componentResourceManager.GetObject("AcceptToolStripMenuItem.Image"), Global.System.Drawing.Image)
			Me.AcceptToolStripMenuItem.Name = "AcceptToolStripMenuItem"
			Me.AcceptToolStripMenuItem.Size = New Global.System.Drawing.Size(156, 22)
			Me.AcceptToolStripMenuItem.Text = "Accept"
			Me.RejectToolStripMenuItem.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.RejectToolStripMenuItem.Image = CType(componentResourceManager.GetObject("RejectToolStripMenuItem.Image"), Global.System.Drawing.Image)
			Me.RejectToolStripMenuItem.Name = "RejectToolStripMenuItem"
			Me.RejectToolStripMenuItem.Size = New Global.System.Drawing.Size(156, 22)
			Me.RejectToolStripMenuItem.Text = "Reject"
			Me.CopyBranchIDToolStripMenuItem.BackColor = Global.System.Drawing.Color.Aqua
			Me.CopyBranchIDToolStripMenuItem.Image = CType(componentResourceManager.GetObject("CopyBranchIDToolStripMenuItem.Image"), Global.System.Drawing.Image)
			Me.CopyBranchIDToolStripMenuItem.Name = "CopyBranchIDToolStripMenuItem"
			Me.CopyBranchIDToolStripMenuItem.Size = New Global.System.Drawing.Size(156, 22)
			Me.CopyBranchIDToolStripMenuItem.Text = "Copy Branch ID"
			Me.pbgiftqr.Image = Global.BillPoint.My.Resources.Resources._12
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(323, 232)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(209, 229)
			Me.pbgiftqr.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbgiftqr.TabIndex = 1805
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(894, 496)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmGodownInward"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.TableLayoutPanel1.ResumeLayout(False)
			Me.TableLayoutPanel1.PerformLayout()
			CType(Me.DGVUserData, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.ContextMenuStrip1.ResumeLayout(False)
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400148A RID: 5258
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
