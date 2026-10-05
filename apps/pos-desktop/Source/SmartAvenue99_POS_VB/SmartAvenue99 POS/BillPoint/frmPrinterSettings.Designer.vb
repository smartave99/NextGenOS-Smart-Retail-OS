Namespace BillPoint
	' Token: 0x020001D2 RID: 466
		Public Partial Class frmPrinterSettings
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007971 RID: 31089 RVA: 0x005AB300 File Offset: 0x005A9500
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

		' Token: 0x06007972 RID: 31090 RVA: 0x005AB350 File Offset: 0x005A9550
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmPrinterSettings))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.pnlPrinterSeting = New Global.System.Windows.Forms.Panel()
			Me.chkShowImageSetting = New Global.System.Windows.Forms.CheckBox()
			Me.chkSettingCashDraw = New Global.System.Windows.Forms.CheckBox()
			Me.Label196 = New Global.System.Windows.Forms.Label()
			Me.cmbPrinterType = New Global.System.Windows.Forms.ComboBox()
			Me.Label197 = New Global.System.Windows.Forms.Label()
			Me.txtTillID = New Global.System.Windows.Forms.TextBox()
			Me.pNlUpiSeting = New Global.System.Windows.Forms.Panel()
			Me.txtBrandName = New Global.System.Windows.Forms.TextBox()
			Me.Label191 = New Global.System.Windows.Forms.Label()
			Me.txtUPIid = New Global.System.Windows.Forms.TextBox()
			Me.Label192 = New Global.System.Windows.Forms.Label()
			Me.pnlCustomerDisplaySeting = New Global.System.Windows.Forms.Panel()
			Me.cmbSecDisplay = New Global.System.Windows.Forms.ComboBox()
			Me.Label193 = New Global.System.Windows.Forms.Label()
			Me.cboxportdisplay_status = New Global.System.Windows.Forms.ComboBox()
			Me.Label194 = New Global.System.Windows.Forms.Label()
			Me.cboxportdisplay_setting = New Global.System.Windows.Forms.ComboBox()
			Me.Label195 = New Global.System.Windows.Forms.Label()
			Me.pnlQRDisplay = New Global.System.Windows.Forms.Panel()
			Me.Label198 = New Global.System.Windows.Forms.Label()
			Me.baudrateTxt = New Global.System.Windows.Forms.TextBox()
			Me.cboxQR_display_status = New Global.System.Windows.Forms.ComboBox()
			Me.Label199 = New Global.System.Windows.Forms.Label()
			Me.cboxQR_display_setting = New Global.System.Windows.Forms.ComboBox()
			Me.Label200 = New Global.System.Windows.Forms.Label()
			Me.btnQrSeting = New Global.GelButtons.GelButton()
			Me.pnlWeightSeting = New Global.System.Windows.Forms.Panel()
			Me.cboxweight_machineport_status = New Global.System.Windows.Forms.ComboBox()
			Me.Label189 = New Global.System.Windows.Forms.Label()
			Me.cboxweight_machineport = New Global.System.Windows.Forms.ComboBox()
			Me.Label190 = New Global.System.Windows.Forms.Label()
			Me.btnWeightSeting = New Global.GelButtons.GelButton()
			Me.btnUpiSeting = New Global.GelButtons.GelButton()
			Me.btnCustomerdISPLAYSeting = New Global.GelButtons.GelButton()
			Me.btnPrinterSetting = New Global.GelButtons.GelButton()
			Me.cmbPrinter = New Global.System.Windows.Forms.ComboBox()
			Me.GelButton24 = New Global.GelButtons.GelButton()
			Me.GelButton25 = New Global.GelButtons.GelButton()
			Me.GelButton11 = New Global.GelButtons.GelButton()
			Me.dgwBill = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn46 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn48 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn53 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn54 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.RAll = New Global.System.Windows.Forms.RadioButton()
			Me.R3Inch = New Global.System.Windows.Forms.RadioButton()
			Me.RA5 = New Global.System.Windows.Forms.RadioButton()
			Me.RA4 = New Global.System.Windows.Forms.RadioButton()
			Me.PictureBox5 = New Global.System.Windows.Forms.PictureBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.TabControl1 = New Global.System.Windows.Forms.TabControl()
			Me.TabPage1 = New Global.System.Windows.Forms.TabPage()
			Me.FlowPanelBill = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.TabPage2 = New Global.System.Windows.Forms.TabPage()
			Me.pnlPrinterSeting.SuspendLayout()
			Me.pNlUpiSeting.SuspendLayout()
			Me.pnlCustomerDisplaySeting.SuspendLayout()
			Me.pnlQRDisplay.SuspendLayout()
			Me.pnlWeightSeting.SuspendLayout()
			CType(Me.dgwBill, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox5, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			Me.TabControl1.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.TabPage2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.pnlPrinterSeting.Controls.Add(Me.chkShowImageSetting)
			Me.pnlPrinterSeting.Controls.Add(Me.chkSettingCashDraw)
			Me.pnlPrinterSeting.Controls.Add(Me.Label196)
			Me.pnlPrinterSeting.Controls.Add(Me.cmbPrinterType)
			Me.pnlPrinterSeting.Controls.Add(Me.Label197)
			Me.pnlPrinterSeting.Controls.Add(Me.txtTillID)
			Me.pnlPrinterSeting.Location = New Global.System.Drawing.Point(164, 55)
			Me.pnlPrinterSeting.Name = "pnlPrinterSeting"
			Me.pnlPrinterSeting.Size = New Global.System.Drawing.Size(438, 172)
			Me.pnlPrinterSeting.TabIndex = 10042
			Me.pnlPrinterSeting.Visible = False
			Me.chkShowImageSetting.AutoSize = True
			Me.chkShowImageSetting.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkShowImageSetting.Location = New Global.System.Drawing.Point(226, 129)
			Me.chkShowImageSetting.Name = "chkShowImageSetting"
			Me.chkShowImageSetting.Size = New Global.System.Drawing.Size(199, 19)
			Me.chkShowImageSetting.TabIndex = 10016
			Me.chkShowImageSetting.Text = "Show Menu Item Images in POS"
			Me.chkShowImageSetting.UseVisualStyleBackColor = True
			Me.chkSettingCashDraw.AutoSize = True
			Me.chkSettingCashDraw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSettingCashDraw.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSettingCashDraw.Location = New Global.System.Drawing.Point(226, 104)
			Me.chkSettingCashDraw.Name = "chkSettingCashDraw"
			Me.chkSettingCashDraw.Size = New Global.System.Drawing.Size(183, 19)
			Me.chkSettingCashDraw.TabIndex = 12
			Me.chkSettingCashDraw.Text = "Cash Drawer Active (Yes / No)"
			Me.chkSettingCashDraw.UseVisualStyleBackColor = True
			Me.Label196.AutoSize = True
			Me.Label196.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label196.Location = New Global.System.Drawing.Point(5, 54)
			Me.Label196.Name = "Label196"
			Me.Label196.Size = New Global.System.Drawing.Size(132, 15)
			Me.Label196.TabIndex = 11
			Me.Label196.Text = "Invoice Template Type :"
			Me.cmbPrinterType.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbPrinterType.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbPrinterType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPrinterType.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbPrinterType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPrinterType.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbPrinterType.FormattingEnabled = True
			Me.cmbPrinterType.Items.AddRange(New Object() { "Laser Printer", "Thermal Printer" })
			Me.cmbPrinterType.Location = New Global.System.Drawing.Point(8, 72)
			Me.cmbPrinterType.Name = "cmbPrinterType"
			Me.cmbPrinterType.Size = New Global.System.Drawing.Size(417, 23)
			Me.cmbPrinterType.TabIndex = 9
			Me.Label197.AutoSize = True
			Me.Label197.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label197.Location = New Global.System.Drawing.Point(5, 5)
			Me.Label197.Name = "Label197"
			Me.Label197.Size = New Global.System.Drawing.Size(75, 15)
			Me.Label197.TabIndex = 10
			Me.Label197.Text = "Terminal ID :"
			Me.txtTillID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtTillID.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTillID.Location = New Global.System.Drawing.Point(8, 23)
			Me.txtTillID.Name = "txtTillID"
			Me.txtTillID.Size = New Global.System.Drawing.Size(417, 23)
			Me.txtTillID.TabIndex = 8
			Me.pNlUpiSeting.Controls.Add(Me.txtBrandName)
			Me.pNlUpiSeting.Controls.Add(Me.Label191)
			Me.pNlUpiSeting.Controls.Add(Me.txtUPIid)
			Me.pNlUpiSeting.Controls.Add(Me.Label192)
			Me.pNlUpiSeting.Location = New Global.System.Drawing.Point(160, 60)
			Me.pNlUpiSeting.Name = "pNlUpiSeting"
			Me.pNlUpiSeting.Size = New Global.System.Drawing.Size(438, 172)
			Me.pNlUpiSeting.TabIndex = 10038
			Me.pNlUpiSeting.Visible = False
			Me.txtBrandName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBrandName.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBrandName.Location = New Global.System.Drawing.Point(93, 37)
			Me.txtBrandName.Name = "txtBrandName"
			Me.txtBrandName.Size = New Global.System.Drawing.Size(308, 23)
			Me.txtBrandName.TabIndex = 10018
			Me.Label191.AutoSize = True
			Me.Label191.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label191.Location = New Global.System.Drawing.Point(6, 40)
			Me.Label191.Name = "Label191"
			Me.Label191.Size = New Global.System.Drawing.Size(79, 15)
			Me.Label191.TabIndex = 10017
			Me.Label191.Text = "Brand Name :"
			Me.txtUPIid.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtUPIid.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUPIid.Location = New Global.System.Drawing.Point(93, 8)
			Me.txtUPIid.Name = "txtUPIid"
			Me.txtUPIid.Size = New Global.System.Drawing.Size(308, 23)
			Me.txtUPIid.TabIndex = 10016
			Me.Label192.AutoSize = True
			Me.Label192.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label192.Location = New Global.System.Drawing.Point(6, 11)
			Me.Label192.Name = "Label192"
			Me.Label192.Size = New Global.System.Drawing.Size(48, 15)
			Me.Label192.TabIndex = 10015
			Me.Label192.Text = "UPI ID :"
			Me.pnlCustomerDisplaySeting.Controls.Add(Me.cmbSecDisplay)
			Me.pnlCustomerDisplaySeting.Controls.Add(Me.Label193)
			Me.pnlCustomerDisplaySeting.Controls.Add(Me.cboxportdisplay_status)
			Me.pnlCustomerDisplaySeting.Controls.Add(Me.Label194)
			Me.pnlCustomerDisplaySeting.Controls.Add(Me.cboxportdisplay_setting)
			Me.pnlCustomerDisplaySeting.Controls.Add(Me.Label195)
			Me.pnlCustomerDisplaySeting.Location = New Global.System.Drawing.Point(163, 62)
			Me.pnlCustomerDisplaySeting.Name = "pnlCustomerDisplaySeting"
			Me.pnlCustomerDisplaySeting.Size = New Global.System.Drawing.Size(438, 172)
			Me.pnlCustomerDisplaySeting.TabIndex = 10040
			Me.pnlCustomerDisplaySeting.Visible = False
			Me.cmbSecDisplay.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbSecDisplay.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSecDisplay.FormattingEnabled = True
			Me.cmbSecDisplay.Items.AddRange(New Object() { "No", "Yes" })
			Me.cmbSecDisplay.Location = New Global.System.Drawing.Point(286, 62)
			Me.cmbSecDisplay.Name = "cmbSecDisplay"
			Me.cmbSecDisplay.Size = New Global.System.Drawing.Size(140, 21)
			Me.cmbSecDisplay.TabIndex = 10007
			Me.Label193.AutoSize = True
			Me.Label193.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label193.Location = New Global.System.Drawing.Point(3, 70)
			Me.Label193.Name = "Label193"
			Me.Label193.Size = New Global.System.Drawing.Size(266, 15)
			Me.Label193.TabIndex = 10010
			Me.Label193.Text = "Customer Secondary Monitor Display (Yes / No) :"
			Me.cboxportdisplay_status.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cboxportdisplay_status.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboxportdisplay_status.FormattingEnabled = True
			Me.cboxportdisplay_status.Items.AddRange(New Object() { "No", "Yes" })
			Me.cboxportdisplay_status.Location = New Global.System.Drawing.Point(286, 27)
			Me.cboxportdisplay_status.Name = "cboxportdisplay_status"
			Me.cboxportdisplay_status.Size = New Global.System.Drawing.Size(138, 21)
			Me.cboxportdisplay_status.TabIndex = 10006
			Me.Label194.AutoSize = True
			Me.Label194.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label194.Location = New Global.System.Drawing.Point(280, 8)
			Me.Label194.Name = "Label194"
			Me.Label194.Size = New Global.System.Drawing.Size(46, 15)
			Me.Label194.TabIndex = 10009
			Me.Label194.Text = "Active :"
			Me.cboxportdisplay_setting.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cboxportdisplay_setting.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cboxportdisplay_setting.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cboxportdisplay_setting.FormattingEnabled = True
			Me.cboxportdisplay_setting.Location = New Global.System.Drawing.Point(6, 28)
			Me.cboxportdisplay_setting.Name = "cboxportdisplay_setting"
			Me.cboxportdisplay_setting.Size = New Global.System.Drawing.Size(256, 21)
			Me.cboxportdisplay_setting.TabIndex = 10005
			Me.Label195.AutoSize = True
			Me.Label195.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label195.Location = New Global.System.Drawing.Point(3, 10)
			Me.Label195.Name = "Label195"
			Me.Label195.Size = New Global.System.Drawing.Size(139, 15)
			Me.Label195.TabIndex = 10008
			Me.Label195.Text = "Customer Display PORT :"
			Me.pnlQRDisplay.Controls.Add(Me.Label198)
			Me.pnlQRDisplay.Controls.Add(Me.baudrateTxt)
			Me.pnlQRDisplay.Controls.Add(Me.cboxQR_display_status)
			Me.pnlQRDisplay.Controls.Add(Me.Label199)
			Me.pnlQRDisplay.Controls.Add(Me.cboxQR_display_setting)
			Me.pnlQRDisplay.Controls.Add(Me.Label200)
			Me.pnlQRDisplay.Location = New Global.System.Drawing.Point(169, 66)
			Me.pnlQRDisplay.Name = "pnlQRDisplay"
			Me.pnlQRDisplay.Size = New Global.System.Drawing.Size(438, 172)
			Me.pnlQRDisplay.TabIndex = 10044
			Me.pnlQRDisplay.Visible = False
			Me.Label198.AutoSize = True
			Me.Label198.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label198.Location = New Global.System.Drawing.Point(261, 68)
			Me.Label198.Name = "Label198"
			Me.Label198.Size = New Global.System.Drawing.Size(67, 13)
			Me.Label198.TabIndex = 10016
			Me.Label198.Text = "Baud Rate : "
			Me.baudrateTxt.Location = New Global.System.Drawing.Point(264, 84)
			Me.baudrateTxt.Name = "baudrateTxt"
			Me.baudrateTxt.Size = New Global.System.Drawing.Size(128, 20)
			Me.baudrateTxt.TabIndex = 10015
			Me.baudrateTxt.Text = "115200"
			Me.cboxQR_display_status.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cboxQR_display_status.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboxQR_display_status.FormattingEnabled = True
			Me.cboxQR_display_status.Items.AddRange(New Object() { "No", "Yes" })
			Me.cboxQR_display_status.Location = New Global.System.Drawing.Point(264, 32)
			Me.cboxQR_display_status.Name = "cboxQR_display_status"
			Me.cboxQR_display_status.Size = New Global.System.Drawing.Size(129, 21)
			Me.cboxQR_display_status.TabIndex = 10013
			Me.Label199.AutoSize = True
			Me.Label199.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label199.Location = New Global.System.Drawing.Point(261, 11)
			Me.Label199.Name = "Label199"
			Me.Label199.Size = New Global.System.Drawing.Size(46, 15)
			Me.Label199.TabIndex = 10014
			Me.Label199.Text = "Active :"
			Me.cboxQR_display_setting.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cboxQR_display_setting.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cboxQR_display_setting.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cboxQR_display_setting.FormattingEnabled = True
			Me.cboxQR_display_setting.Location = New Global.System.Drawing.Point(4, 32)
			Me.cboxQR_display_setting.Name = "cboxQR_display_setting"
			Me.cboxQR_display_setting.Size = New Global.System.Drawing.Size(249, 21)
			Me.cboxQR_display_setting.TabIndex = 10011
			Me.Label200.AutoSize = True
			Me.Label200.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label200.Location = New Global.System.Drawing.Point(3, 10)
			Me.Label200.Name = "Label200"
			Me.Label200.Size = New Global.System.Drawing.Size(104, 15)
			Me.Label200.TabIndex = 10012
			Me.Label200.Text = "QR Display PORT :"
			Me.btnQrSeting.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.btnQrSeting.FlatAppearance.BorderSize = 0
			Me.btnQrSeting.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnQrSeting.Font = New Global.System.Drawing.Font("Segoe UI Black", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnQrSeting.ForeColor = Global.System.Drawing.Color.White
			Me.btnQrSeting.GradientBottom = Global.System.Drawing.Color.SteelBlue
			Me.btnQrSeting.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnQrSeting.Location = New Global.System.Drawing.Point(12, 233)
			Me.btnQrSeting.Name = "btnQrSeting"
			Me.btnQrSeting.Size = New Global.System.Drawing.Size(146, 29)
			Me.btnQrSeting.TabIndex = 10043
			Me.btnQrSeting.Text = "QR Display"
			Me.btnQrSeting.UseVisualStyleBackColor = False
			Me.pnlWeightSeting.Controls.Add(Me.cboxweight_machineport_status)
			Me.pnlWeightSeting.Controls.Add(Me.Label189)
			Me.pnlWeightSeting.Controls.Add(Me.cboxweight_machineport)
			Me.pnlWeightSeting.Controls.Add(Me.Label190)
			Me.pnlWeightSeting.Location = New Global.System.Drawing.Point(169, 69)
			Me.pnlWeightSeting.Name = "pnlWeightSeting"
			Me.pnlWeightSeting.Size = New Global.System.Drawing.Size(438, 172)
			Me.pnlWeightSeting.TabIndex = 10037
			Me.pnlWeightSeting.Visible = False
			Me.cboxweight_machineport_status.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cboxweight_machineport_status.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboxweight_machineport_status.FormattingEnabled = True
			Me.cboxweight_machineport_status.Items.AddRange(New Object() { "No", "Yes" })
			Me.cboxweight_machineport_status.Location = New Global.System.Drawing.Point(335, 27)
			Me.cboxweight_machineport_status.Name = "cboxweight_machineport_status"
			Me.cboxweight_machineport_status.Size = New Global.System.Drawing.Size(91, 21)
			Me.cboxweight_machineport_status.TabIndex = 408
			Me.Label189.AutoSize = True
			Me.Label189.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label189.Location = New Global.System.Drawing.Point(332, 9)
			Me.Label189.Name = "Label189"
			Me.Label189.Size = New Global.System.Drawing.Size(46, 15)
			Me.Label189.TabIndex = 410
			Me.Label189.Text = "Active :"
			Me.cboxweight_machineport.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cboxweight_machineport.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cboxweight_machineport.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cboxweight_machineport.FormattingEnabled = True
			Me.cboxweight_machineport.Location = New Global.System.Drawing.Point(17, 27)
			Me.cboxweight_machineport.Name = "cboxweight_machineport"
			Me.cboxweight_machineport.Size = New Global.System.Drawing.Size(303, 21)
			Me.cboxweight_machineport.TabIndex = 407
			Me.Label190.AutoSize = True
			Me.Label190.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label190.Location = New Global.System.Drawing.Point(14, 9)
			Me.Label190.Name = "Label190"
			Me.Label190.Size = New Global.System.Drawing.Size(134, 15)
			Me.Label190.TabIndex = 409
			Me.Label190.Text = "Weight Machine PORT :"
			Me.btnWeightSeting.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.btnWeightSeting.FlatAppearance.BorderSize = 0
			Me.btnWeightSeting.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnWeightSeting.Font = New Global.System.Drawing.Font("Segoe UI Black", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnWeightSeting.ForeColor = Global.System.Drawing.Color.White
			Me.btnWeightSeting.GradientBottom = Global.System.Drawing.Color.SteelBlue
			Me.btnWeightSeting.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnWeightSeting.Location = New Global.System.Drawing.Point(12, 198)
			Me.btnWeightSeting.Name = "btnWeightSeting"
			Me.btnWeightSeting.Size = New Global.System.Drawing.Size(146, 29)
			Me.btnWeightSeting.TabIndex = 10036
			Me.btnWeightSeting.Text = "Weight Machine "
			Me.btnWeightSeting.UseVisualStyleBackColor = False
			Me.btnUpiSeting.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.btnUpiSeting.FlatAppearance.BorderSize = 0
			Me.btnUpiSeting.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpiSeting.Font = New Global.System.Drawing.Font("Segoe UI Black", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpiSeting.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpiSeting.GradientBottom = Global.System.Drawing.Color.SteelBlue
			Me.btnUpiSeting.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnUpiSeting.Location = New Global.System.Drawing.Point(12, 163)
			Me.btnUpiSeting.Name = "btnUpiSeting"
			Me.btnUpiSeting.Size = New Global.System.Drawing.Size(146, 29)
			Me.btnUpiSeting.TabIndex = 10035
			Me.btnUpiSeting.Text = "UPI Set"
			Me.btnUpiSeting.UseVisualStyleBackColor = False
			Me.btnCustomerdISPLAYSeting.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.btnCustomerdISPLAYSeting.FlatAppearance.BorderSize = 0
			Me.btnCustomerdISPLAYSeting.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCustomerdISPLAYSeting.Font = New Global.System.Drawing.Font("Segoe UI Black", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCustomerdISPLAYSeting.ForeColor = Global.System.Drawing.Color.White
			Me.btnCustomerdISPLAYSeting.GradientBottom = Global.System.Drawing.Color.SteelBlue
			Me.btnCustomerdISPLAYSeting.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnCustomerdISPLAYSeting.Location = New Global.System.Drawing.Point(12, 128)
			Me.btnCustomerdISPLAYSeting.Name = "btnCustomerdISPLAYSeting"
			Me.btnCustomerdISPLAYSeting.Size = New Global.System.Drawing.Size(146, 29)
			Me.btnCustomerdISPLAYSeting.TabIndex = 10034
			Me.btnCustomerdISPLAYSeting.Text = "Customer Dispaly"
			Me.btnCustomerdISPLAYSeting.UseVisualStyleBackColor = False
			Me.btnPrinterSetting.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.btnPrinterSetting.FlatAppearance.BorderSize = 0
			Me.btnPrinterSetting.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnPrinterSetting.Font = New Global.System.Drawing.Font("Segoe UI Black", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnPrinterSetting.ForeColor = Global.System.Drawing.Color.White
			Me.btnPrinterSetting.GradientBottom = Global.System.Drawing.Color.SteelBlue
			Me.btnPrinterSetting.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnPrinterSetting.Location = New Global.System.Drawing.Point(12, 93)
			Me.btnPrinterSetting.Name = "btnPrinterSetting"
			Me.btnPrinterSetting.Size = New Global.System.Drawing.Size(146, 29)
			Me.btnPrinterSetting.TabIndex = 10033
			Me.btnPrinterSetting.Text = "Printer Setting"
			Me.btnPrinterSetting.UseVisualStyleBackColor = False
			Me.cmbPrinter.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbPrinter.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPrinter.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 16F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbPrinter.FormattingEnabled = True
			Me.cmbPrinter.Location = New Global.System.Drawing.Point(12, 16)
			Me.cmbPrinter.Name = "cmbPrinter"
			Me.cmbPrinter.Size = New Global.System.Drawing.Size(356, 38)
			Me.cmbPrinter.TabIndex = 10032
			Me.GelButton24.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton24.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton24.FlatAppearance.BorderSize = 0
			Me.GelButton24.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton24.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton24.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton24.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton24.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton24.Image = CType(componentResourceManager.GetObject("GelButton24.Image"), Global.System.Drawing.Image)
			Me.GelButton24.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton24.Location = New Global.System.Drawing.Point(673, 16)
			Me.GelButton24.Name = "GelButton24"
			Me.GelButton24.Size = New Global.System.Drawing.Size(107, 36)
			Me.GelButton24.TabIndex = 10041
			Me.GelButton24.Text = "Update"
			Me.GelButton24.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton24.UseVisualStyleBackColor = False
			Me.GelButton24.Visible = False
			Me.GelButton25.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton25.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton25.FlatAppearance.BorderSize = 0
			Me.GelButton25.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton25.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton25.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton25.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton25.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton25.Image = CType(componentResourceManager.GetObject("GelButton25.Image"), Global.System.Drawing.Image)
			Me.GelButton25.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton25.Location = New Global.System.Drawing.Point(783, 16)
			Me.GelButton25.Name = "GelButton25"
			Me.GelButton25.Size = New Global.System.Drawing.Size(105, 36)
			Me.GelButton25.TabIndex = 10039
			Me.GelButton25.Text = "Delete"
			Me.GelButton25.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton25.UseVisualStyleBackColor = False
			Me.GelButton25.Visible = False
			Me.GelButton11.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.FlatAppearance.BorderSize = 0
			Me.GelButton11.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton11.Font = New Global.System.Drawing.Font("Segoe UI Black", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.GelButton11.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton11.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton11.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.Image = CType(componentResourceManager.GetObject("GelButton11.Image"), Global.System.Drawing.Image)
			Me.GelButton11.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton11.Location = New Global.System.Drawing.Point(12, 58)
			Me.GelButton11.Name = "GelButton11"
			Me.GelButton11.Size = New Global.System.Drawing.Size(146, 29)
			Me.GelButton11.TabIndex = 10031
			Me.GelButton11.Text = "Apply"
			Me.GelButton11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton11.UseVisualStyleBackColor = False
			Me.dgwBill.AllowUserToAddRows = False
			Me.dgwBill.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgwBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgwBill.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.dgwBill.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgwBill.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgwBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgwBill.ColumnHeadersHeight = 40
			Me.dgwBill.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn46, Me.DataGridViewTextBoxColumn48, Me.DataGridViewTextBoxColumn53, Me.DataGridViewTextBoxColumn54 })
			Me.dgwBill.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgwBill.EnableHeadersVisualStyles = False
			Me.dgwBill.GridColor = Global.System.Drawing.Color.White
			Me.dgwBill.Location = New Global.System.Drawing.Point(1124, 406)
			Me.dgwBill.MultiSelect = False
			Me.dgwBill.Name = "dgwBill"
			Me.dgwBill.[ReadOnly] = True
			Me.dgwBill.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgwBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgwBill.RowHeadersWidth = 29
			Me.dgwBill.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgwBill.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgwBill.RowTemplate.Height = 20
			Me.dgwBill.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgwBill.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgwBill.Size = New Global.System.Drawing.Size(117, 91)
			Me.dgwBill.TabIndex = 10045
			Me.dgwBill.TabStop = False
			Me.dgwBill.Visible = False
			Me.DataGridViewTextBoxColumn46.HeaderText = "Sr"
			Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
			Me.DataGridViewTextBoxColumn46.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn46.Visible = False
			Me.DataGridViewTextBoxColumn48.FillWeight = 163.6364F
			Me.DataGridViewTextBoxColumn48.HeaderText = "Bill Style Name"
			Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
			Me.DataGridViewTextBoxColumn48.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn48.Width = 200
			Me.DataGridViewTextBoxColumn53.HeaderText = "Column3"
			Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
			Me.DataGridViewTextBoxColumn53.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn53.Visible = False
			Me.DataGridViewTextBoxColumn54.HeaderText = "Column4"
			Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
			Me.DataGridViewTextBoxColumn54.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn54.Visible = False
			Me.RAll.AutoSize = True
			Me.RAll.Location = New Global.System.Drawing.Point(31, 27)
			Me.RAll.Name = "RAll"
			Me.RAll.Size = New Global.System.Drawing.Size(36, 17)
			Me.RAll.TabIndex = 10049
			Me.RAll.Text = "All"
			Me.RAll.UseVisualStyleBackColor = True
			Me.R3Inch.AutoSize = True
			Me.R3Inch.Location = New Global.System.Drawing.Point(31, 56)
			Me.R3Inch.Name = "R3Inch"
			Me.R3Inch.Size = New Global.System.Drawing.Size(55, 17)
			Me.R3Inch.TabIndex = 10048
			Me.R3Inch.Text = "3 Inch"
			Me.R3Inch.UseVisualStyleBackColor = True
			Me.RA5.AutoSize = True
			Me.RA5.Location = New Global.System.Drawing.Point(31, 114)
			Me.RA5.Name = "RA5"
			Me.RA5.Size = New Global.System.Drawing.Size(61, 17)
			Me.RA5.TabIndex = 10047
			Me.RA5.Text = "A5 Size"
			Me.RA5.UseVisualStyleBackColor = True
			Me.RA4.AutoSize = True
			Me.RA4.Checked = True
			Me.RA4.Location = New Global.System.Drawing.Point(31, 85)
			Me.RA4.Name = "RA4"
			Me.RA4.Size = New Global.System.Drawing.Size(61, 17)
			Me.RA4.TabIndex = 10046
			Me.RA4.TabStop = True
			Me.RA4.Text = "A4 Size"
			Me.RA4.UseVisualStyleBackColor = True
			Me.PictureBox5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.PictureBox5.Location = New Global.System.Drawing.Point(682, 41)
			Me.PictureBox5.Name = "PictureBox5"
			Me.PictureBox5.Size = New Global.System.Drawing.Size(561, 515)
			Me.PictureBox5.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox5.TabIndex = 10050
			Me.PictureBox5.TabStop = False
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Location = New Global.System.Drawing.Point(209, 247)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(121, 21)
			Me.ComboBox1.TabIndex = 10051
			Me.Panel1.Controls.Add(Me.cmbPrinter)
			Me.Panel1.Controls.Add(Me.pnlPrinterSeting)
			Me.Panel1.Controls.Add(Me.GelButton11)
			Me.Panel1.Controls.Add(Me.ComboBox1)
			Me.Panel1.Controls.Add(Me.GelButton25)
			Me.Panel1.Controls.Add(Me.GelButton24)
			Me.Panel1.Controls.Add(Me.btnPrinterSetting)
			Me.Panel1.Controls.Add(Me.btnCustomerdISPLAYSeting)
			Me.Panel1.Controls.Add(Me.btnUpiSeting)
			Me.Panel1.Controls.Add(Me.btnWeightSeting)
			Me.Panel1.Controls.Add(Me.pnlWeightSeting)
			Me.Panel1.Controls.Add(Me.pNlUpiSeting)
			Me.Panel1.Controls.Add(Me.btnQrSeting)
			Me.Panel1.Controls.Add(Me.pnlCustomerDisplaySeting)
			Me.Panel1.Controls.Add(Me.pnlQRDisplay)
			Me.Panel1.Location = New Global.System.Drawing.Point(24, 32)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(905, 344)
			Me.Panel1.TabIndex = 10052
			Me.TabControl1.Controls.Add(Me.TabPage1)
			Me.TabControl1.Controls.Add(Me.TabPage2)
			Me.TabControl1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TabControl1.Location = New Global.System.Drawing.Point(0, 0)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New Global.System.Drawing.Size(1257, 594)
			Me.TabControl1.TabIndex = 10053
			Me.TabPage1.Controls.Add(Me.FlowPanelBill)
			Me.TabPage1.Controls.Add(Me.Panel2)
			Me.TabPage1.Controls.Add(Me.GelButton1)
			Me.TabPage1.Controls.Add(Me.dgwBill)
			Me.TabPage1.Controls.Add(Me.PictureBox5)
			Me.TabPage1.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage1.Size = New Global.System.Drawing.Size(1249, 568)
			Me.TabPage1.TabIndex = 0
			Me.TabPage1.Text = "Bill Design"
			Me.TabPage1.UseVisualStyleBackColor = True
			Me.FlowPanelBill.AutoScroll = True
			Me.FlowPanelBill.Dock = Global.System.Windows.Forms.DockStyle.Left
			Me.FlowPanelBill.Location = New Global.System.Drawing.Point(128, 3)
			Me.FlowPanelBill.Name = "FlowPanelBill"
			Me.FlowPanelBill.Size = New Global.System.Drawing.Size(547, 562)
			Me.FlowPanelBill.TabIndex = 10054
			Me.Panel2.Controls.Add(Me.RA4)
			Me.Panel2.Controls.Add(Me.RAll)
			Me.Panel2.Controls.Add(Me.R3Inch)
			Me.Panel2.Controls.Add(Me.RA5)
			Me.Panel2.Dock = Global.System.Windows.Forms.DockStyle.Left
			Me.Panel2.Location = New Global.System.Drawing.Point(3, 3)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(125, 562)
			Me.Panel2.TabIndex = 10053
			Me.GelButton1.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Black", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.GelButton1.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(1100, 6)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(146, 29)
			Me.GelButton1.TabIndex = 10051
			Me.GelButton1.Text = "Apply"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.TabPage2.Controls.Add(Me.Panel1)
			Me.TabPage2.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage2.Name = "TabPage2"
			Me.TabPage2.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage2.Size = New Global.System.Drawing.Size(1249, 568)
			Me.TabPage2.TabIndex = 1
			Me.TabPage2.Text = "Bill Setting"
			Me.TabPage2.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(1257, 594)
			MyBase.Controls.Add(Me.TabControl1)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmPrinterSettings"
			Me.Text = "Printer Settings"
			Me.pnlPrinterSeting.ResumeLayout(False)
			Me.pnlPrinterSeting.PerformLayout()
			Me.pNlUpiSeting.ResumeLayout(False)
			Me.pNlUpiSeting.PerformLayout()
			Me.pnlCustomerDisplaySeting.ResumeLayout(False)
			Me.pnlCustomerDisplaySeting.PerformLayout()
			Me.pnlQRDisplay.ResumeLayout(False)
			Me.pnlQRDisplay.PerformLayout()
			Me.pnlWeightSeting.ResumeLayout(False)
			Me.pnlWeightSeting.PerformLayout()
			CType(Me.dgwBill, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox5, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.TabControl1.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.TabPage2.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040035B8 RID: 13752
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
