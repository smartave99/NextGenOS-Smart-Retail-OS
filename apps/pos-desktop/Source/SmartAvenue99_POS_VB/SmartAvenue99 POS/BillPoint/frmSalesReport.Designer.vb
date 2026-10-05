Namespace BillPoint
	' Token: 0x020002AD RID: 685
		Public Partial Class frmSalesReport
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600B193 RID: 45459 RVA: 0x00765810 File Offset: 0x00763A10
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

		' Token: 0x0600B194 RID: 45460 RVA: 0x00765860 File Offset: 0x00763A60
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSalesReport))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.cbox_saletype = New Global.System.Windows.Forms.ComboBox()
			Me.GelButton15 = New Global.GelButtons.GelButton()
			Me.GelButton14 = New Global.GelButtons.GelButton()
			Me.GelButton12 = New Global.GelButtons.GelButton()
			Me.GelButton13 = New Global.GelButtons.GelButton()
			Me.GelButton10 = New Global.GelButtons.GelButton()
			Me.GelButton11 = New Global.GelButtons.GelButton()
			Me.GelButton8 = New Global.GelButtons.GelButton()
			Me.GelButton9 = New Global.GelButtons.GelButton()
			Me.GelButton7 = New Global.GelButtons.GelButton()
			Me.GelButton6 = New Global.GelButtons.GelButton()
			Me.GelButton5 = New Global.GelButtons.GelButton()
			Me.GelButton4 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.ComboBox4 = New Global.System.Windows.Forms.ComboBox()
			Me.ComboBox3 = New Global.System.Windows.Forms.ComboBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.ComboBox2 = New Global.System.Windows.Forms.ComboBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.GelButton16 = New Global.GelButtons.GelButton()
			Me.Panel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(981, 453)
			Me.Panel1.TabIndex = 2
			Me.GroupBox2.Controls.Add(Me.GelButton16)
			Me.GroupBox2.Controls.Add(Me.Label9)
			Me.GroupBox2.Controls.Add(Me.cbox_saletype)
			Me.GroupBox2.Controls.Add(Me.GelButton15)
			Me.GroupBox2.Controls.Add(Me.GelButton14)
			Me.GroupBox2.Controls.Add(Me.GelButton12)
			Me.GroupBox2.Controls.Add(Me.GelButton13)
			Me.GroupBox2.Controls.Add(Me.GelButton10)
			Me.GroupBox2.Controls.Add(Me.GelButton11)
			Me.GroupBox2.Controls.Add(Me.GelButton8)
			Me.GroupBox2.Controls.Add(Me.GelButton9)
			Me.GroupBox2.Controls.Add(Me.GelButton7)
			Me.GroupBox2.Controls.Add(Me.GelButton6)
			Me.GroupBox2.Controls.Add(Me.GelButton5)
			Me.GroupBox2.Controls.Add(Me.GelButton4)
			Me.GroupBox2.Controls.Add(Me.GelButton2)
			Me.GroupBox2.Controls.Add(Me.GelButton3)
			Me.GroupBox2.Controls.Add(Me.GelButton1)
			Me.GroupBox2.Controls.Add(Me.Label7)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.ComboBox4)
			Me.GroupBox2.Controls.Add(Me.ComboBox3)
			Me.GroupBox2.Controls.Add(Me.Label5)
			Me.GroupBox2.Controls.Add(Me.ComboBox2)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Controls.Add(Me.ComboBox1)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(9, 51)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(961, 353)
			Me.GroupBox2.TabIndex = 50
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Invoice Date"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(6, 28)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(61, 13)
			Me.Label9.TabIndex = 565
			Me.Label9.Text = "Sale Type :"
			Me.cbox_saletype.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbox_saletype.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbox_saletype.FormattingEnabled = True
			Me.cbox_saletype.Items.AddRange(New Object() { "All", "Retail", "Wholesale" })
			Me.cbox_saletype.Location = New Global.System.Drawing.Point(6, 44)
			Me.cbox_saletype.Name = "cbox_saletype"
			Me.cbox_saletype.Size = New Global.System.Drawing.Size(89, 28)
			Me.cbox_saletype.TabIndex = 564
			Me.GelButton15.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton15.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton15.FlatAppearance.BorderSize = 0
			Me.GelButton15.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton15.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton15.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton15.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton15.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton15.Image = CType(componentResourceManager.GetObject("GelButton15.Image"), Global.System.Drawing.Image)
			Me.GelButton15.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton15.Location = New Global.System.Drawing.Point(870, 84)
			Me.GelButton15.Name = "GelButton15"
			Me.GelButton15.Size = New Global.System.Drawing.Size(86, 37)
			Me.GelButton15.TabIndex = 563
			Me.GelButton15.Text = "Net Sale"
			Me.GelButton15.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton15.UseVisualStyleBackColor = False
			Me.GelButton14.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton14.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton14.FlatAppearance.BorderSize = 0
			Me.GelButton14.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton14.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton14.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton14.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton14.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton14.Image = CType(componentResourceManager.GetObject("GelButton14.Image"), Global.System.Drawing.Image)
			Me.GelButton14.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton14.Location = New Global.System.Drawing.Point(585, 139)
			Me.GelButton14.Name = "GelButton14"
			Me.GelButton14.Size = New Global.System.Drawing.Size(65, 37)
			Me.GelButton14.TabIndex = 562
			Me.GelButton14.Text = "D-Sale"
			Me.GelButton14.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton14.UseVisualStyleBackColor = False
			Me.GelButton12.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton12.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton12.FlatAppearance.BorderSize = 0
			Me.GelButton12.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton12.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton12.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton12.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton12.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton12.Image = CType(componentResourceManager.GetObject("GelButton12.Image"), Global.System.Drawing.Image)
			Me.GelButton12.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton12.Location = New Global.System.Drawing.Point(418, 298)
			Me.GelButton12.Name = "GelButton12"
			Me.GelButton12.Size = New Global.System.Drawing.Size(161, 37)
			Me.GelButton12.TabIndex = 561
			Me.GelButton12.Text = "Details Report"
			Me.GelButton12.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton12.UseVisualStyleBackColor = False
			Me.GelButton13.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton13.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton13.FlatAppearance.BorderSize = 0
			Me.GelButton13.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton13.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton13.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton13.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton13.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton13.Image = CType(componentResourceManager.GetObject("GelButton13.Image"), Global.System.Drawing.Image)
			Me.GelButton13.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton13.Location = New Global.System.Drawing.Point(257, 298)
			Me.GelButton13.Name = "GelButton13"
			Me.GelButton13.Size = New Global.System.Drawing.Size(155, 37)
			Me.GelButton13.TabIndex = 560
			Me.GelButton13.Text = "Summary Report"
			Me.GelButton13.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton13.UseVisualStyleBackColor = False
			Me.GelButton10.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton10.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton10.FlatAppearance.BorderSize = 0
			Me.GelButton10.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton10.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton10.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton10.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton10.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton10.Image = CType(componentResourceManager.GetObject("GelButton10.Image"), Global.System.Drawing.Image)
			Me.GelButton10.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton10.Location = New Global.System.Drawing.Point(418, 244)
			Me.GelButton10.Name = "GelButton10"
			Me.GelButton10.Size = New Global.System.Drawing.Size(161, 37)
			Me.GelButton10.TabIndex = 559
			Me.GelButton10.Text = "Details Report"
			Me.GelButton10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton10.UseVisualStyleBackColor = False
			Me.GelButton11.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton11.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton11.FlatAppearance.BorderSize = 0
			Me.GelButton11.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton11.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton11.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton11.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton11.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton11.Image = CType(componentResourceManager.GetObject("GelButton11.Image"), Global.System.Drawing.Image)
			Me.GelButton11.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton11.Location = New Global.System.Drawing.Point(257, 244)
			Me.GelButton11.Name = "GelButton11"
			Me.GelButton11.Size = New Global.System.Drawing.Size(155, 37)
			Me.GelButton11.TabIndex = 558
			Me.GelButton11.Text = "Summary Report"
			Me.GelButton11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton11.UseVisualStyleBackColor = False
			Me.GelButton8.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton8.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton8.FlatAppearance.BorderSize = 0
			Me.GelButton8.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton8.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton8.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton8.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton8.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton8.Image = CType(componentResourceManager.GetObject("GelButton8.Image"), Global.System.Drawing.Image)
			Me.GelButton8.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton8.Location = New Global.System.Drawing.Point(418, 193)
			Me.GelButton8.Name = "GelButton8"
			Me.GelButton8.Size = New Global.System.Drawing.Size(161, 37)
			Me.GelButton8.TabIndex = 557
			Me.GelButton8.Text = "Details Report"
			Me.GelButton8.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton8.UseVisualStyleBackColor = False
			Me.GelButton9.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton9.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton9.FlatAppearance.BorderSize = 0
			Me.GelButton9.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton9.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton9.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton9.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton9.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton9.Image = CType(componentResourceManager.GetObject("GelButton9.Image"), Global.System.Drawing.Image)
			Me.GelButton9.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton9.Location = New Global.System.Drawing.Point(257, 193)
			Me.GelButton9.Name = "GelButton9"
			Me.GelButton9.Size = New Global.System.Drawing.Size(155, 37)
			Me.GelButton9.TabIndex = 556
			Me.GelButton9.Text = "Summary Report"
			Me.GelButton9.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton9.UseVisualStyleBackColor = False
			Me.GelButton7.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton7.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton7.FlatAppearance.BorderSize = 0
			Me.GelButton7.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton7.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton7.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton7.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton7.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton7.Image = CType(componentResourceManager.GetObject("GelButton7.Image"), Global.System.Drawing.Image)
			Me.GelButton7.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton7.Location = New Global.System.Drawing.Point(418, 139)
			Me.GelButton7.Name = "GelButton7"
			Me.GelButton7.Size = New Global.System.Drawing.Size(161, 37)
			Me.GelButton7.TabIndex = 555
			Me.GelButton7.Text = "Details Report"
			Me.GelButton7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton7.UseVisualStyleBackColor = False
			Me.GelButton6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton6.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton6.FlatAppearance.BorderSize = 0
			Me.GelButton6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton6.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton6.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton6.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton6.Image = CType(componentResourceManager.GetObject("GelButton6.Image"), Global.System.Drawing.Image)
			Me.GelButton6.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton6.Location = New Global.System.Drawing.Point(257, 139)
			Me.GelButton6.Name = "GelButton6"
			Me.GelButton6.Size = New Global.System.Drawing.Size(155, 37)
			Me.GelButton6.TabIndex = 554
			Me.GelButton6.Text = "Summary Report"
			Me.GelButton6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton6.UseVisualStyleBackColor = False
			Me.GelButton5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton5.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton5.FlatAppearance.BorderSize = 0
			Me.GelButton5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton5.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton5.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton5.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton5.Image = CType(componentResourceManager.GetObject("GelButton5.Image"), Global.System.Drawing.Image)
			Me.GelButton5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton5.Location = New Global.System.Drawing.Point(748, 84)
			Me.GelButton5.Name = "GelButton5"
			Me.GelButton5.Size = New Global.System.Drawing.Size(116, 37)
			Me.GelButton5.TabIndex = 553
			Me.GelButton5.Text = "Details Report"
			Me.GelButton5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton5.UseVisualStyleBackColor = False
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
			Me.GelButton4.Location = New Global.System.Drawing.Point(585, 84)
			Me.GelButton4.Name = "GelButton4"
			Me.GelButton4.Size = New Global.System.Drawing.Size(157, 37)
			Me.GelButton4.TabIndex = 552
			Me.GelButton4.Text = "Summary Report-3"
			Me.GelButton4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton4.UseVisualStyleBackColor = False
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
			Me.GelButton2.Location = New Global.System.Drawing.Point(418, 84)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(161, 37)
			Me.GelButton2.TabIndex = 551
			Me.GelButton2.Text = "Summary Report-2"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(840, 140)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(116, 34)
			Me.GelButton3.TabIndex = 549
			Me.GelButton3.Text = "&Reset"
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(255, 84)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(157, 37)
			Me.GelButton1.TabIndex = 550
			Me.GelButton1.Text = "Summary Report-1"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(5, 288)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(110, 13)
			Me.Label7.TabIndex = 30
			Me.Label7.Text = "Search By Tax Type :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(3, 234)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(106, 13)
			Me.Label6.TabIndex = 27
			Me.Label6.Text = "Search By Operator :"
			Me.ComboBox4.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox4.FormattingEnabled = True
			Me.ComboBox4.Items.AddRange(New Object() { "GST", "NON GST" })
			Me.ComboBox4.Location = New Global.System.Drawing.Point(6, 304)
			Me.ComboBox4.Name = "ComboBox4"
			Me.ComboBox4.Size = New Global.System.Drawing.Size(244, 28)
			Me.ComboBox4.TabIndex = 15
			Me.ComboBox3.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox3.FormattingEnabled = True
			Me.ComboBox3.Location = New Global.System.Drawing.Point(6, 250)
			Me.ComboBox3.Name = "ComboBox3"
			Me.ComboBox3.Size = New Global.System.Drawing.Size(244, 28)
			Me.ComboBox3.TabIndex = 12
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(3, 183)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(119, 13)
			Me.Label5.TabIndex = 24
			Me.Label5.Text = "Search By Terminal ID :"
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Location = New Global.System.Drawing.Point(6, 199)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(244, 28)
			Me.ComboBox2.TabIndex = 9
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(3, 132)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(140, 13)
			Me.Label3.TabIndex = 21
			Me.Label3.Text = "Search By Customer Name :"
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Location = New Global.System.Drawing.Point(6, 148)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(244, 28)
			Me.ComboBox1.TabIndex = 6
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(131, 99)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(128, 80)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(3, 80)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(6, 99)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 0
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-21, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(991, 34)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(274, 6)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(129, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Sales Report"
			Me.Label8.ForeColor = Global.System.Drawing.Color.Red
			Me.Label8.Location = New Global.System.Drawing.Point(6, 407)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(187, 28)
			Me.Label8.TabIndex = 31
			Me.Label8.Text = "NB : If you retrieve ""Details Report"", may be delayed."
			Me.GelButton16.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton16.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton16.FlatAppearance.BorderSize = 0
			Me.GelButton16.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton16.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton16.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton16.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton16.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton16.Image = CType(componentResourceManager.GetObject("GelButton16.Image"), Global.System.Drawing.Image)
			Me.GelButton16.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton16.Location = New Global.System.Drawing.Point(585, 19)
			Me.GelButton16.Name = "GelButton16"
			Me.GelButton16.Size = New Global.System.Drawing.Size(370, 59)
			Me.GelButton16.TabIndex = 566
			Me.GelButton16.Text = "&Sale Report(Multi_Payment)"
			Me.GelButton16.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton16.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(981, 453)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSalesReport"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004A47 RID: 19015
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
