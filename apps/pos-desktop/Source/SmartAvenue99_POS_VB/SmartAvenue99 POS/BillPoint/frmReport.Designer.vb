Namespace BillPoint
	' Token: 0x02000367 RID: 871
		Public Partial Class frmReport
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600CEA2 RID: 52898 RVA: 0x0080FA80 File Offset: 0x0080DC80
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

		' Token: 0x0600CEA3 RID: 52899 RVA: 0x0080FAD0 File Offset: 0x0080DCD0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmReport))
			Me.CrystalReportViewer1 = New Global.CrystalDecisions.Windows.Forms.CrystalReportViewer()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.PrintDialog1 = New Global.System.Windows.Forms.PrintDialog()
			Me.PrintDocument1 = New Global.System.Drawing.Printing.PrintDocument()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.txtcompname = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Num1 = New Global.System.Windows.Forms.NumericUpDown()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.lblwWork = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Button6 = New Global.System.Windows.Forms.Button()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.Button10 = New Global.GelButtons.GelButton()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.txtserverlink = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.StatusRetriever = New Global.System.Windows.Forms.Timer(Me.components)
			CType(Me.Num1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.CrystalReportViewer1.ActiveViewIndex = -1
			Me.CrystalReportViewer1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.CrystalReportViewer1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.CrystalReportViewer1.Cursor = Global.System.Windows.Forms.Cursors.[Default]
			Me.CrystalReportViewer1.DisplayBackgroundEdge = False
			Me.CrystalReportViewer1.Location = New Global.System.Drawing.Point(160, 0)
			Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
			Me.CrystalReportViewer1.ShowCloseButton = False
			Me.CrystalReportViewer1.ShowCopyButton = False
			Me.CrystalReportViewer1.ShowGotoPageButton = False
			Me.CrystalReportViewer1.ShowGroupTreeButton = False
			Me.CrystalReportViewer1.ShowLogo = False
			Me.CrystalReportViewer1.ShowParameterPanelButton = False
			Me.CrystalReportViewer1.ShowRefreshButton = False
			Me.CrystalReportViewer1.ShowTextSearchButton = False
			Me.CrystalReportViewer1.Size = New Global.System.Drawing.Size(880, 859)
			Me.CrystalReportViewer1.TabIndex = 0
			Me.CrystalReportViewer1.TabStop = False
			Me.CrystalReportViewer1.ToolPanelView = Global.CrystalDecisions.Windows.Forms.ToolPanelViewType.None
			Me.TextBox1.Location = New Global.System.Drawing.Point(122, 11)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(22, 20)
			Me.TextBox1.TabIndex = 4
			Me.TextBox1.TabStop = False
			Me.TextBox1.Visible = False
			Me.PrintDialog1.UseEXDialog = True
			Me.txtEmailID.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.White
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.ForeColor = Global.System.Drawing.Color.Blue
			Me.txtEmailID.Location = New Global.System.Drawing.Point(4, 279)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(150, 29)
			Me.txtEmailID.TabIndex = 3
			Me.Timer1.Interval = 5000
			Me.txtcompname.Location = New Global.System.Drawing.Point(109, 11)
			Me.txtcompname.Name = "txtcompname"
			Me.txtcompname.[ReadOnly] = True
			Me.txtcompname.Size = New Global.System.Drawing.Size(11, 20)
			Me.txtcompname.TabIndex = 6
			Me.txtcompname.TabStop = False
			Me.txtcompname.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(1, 260)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(122, 15)
			Me.Label1.TabIndex = 7
			Me.Label1.Text = "Enter Valid Email ID :"
			Me.Label2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label2.AutoSize = True
			Me.Label2.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(30, 3)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(77, 13)
			Me.Label2.TabIndex = 9
			Me.Label2.Text = "No(s) of Copy :"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Num1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Num1.BackColor = Global.System.Drawing.Color.White
			Me.Num1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Num1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Num1.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Num1.Location = New Global.System.Drawing.Point(33, 21)
			Me.Num1.Name = "Num1"
			Me.Num1.Size = New Global.System.Drawing.Size(94, 29)
			Me.Num1.TabIndex = 0
			Me.Num1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Panel1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.lblwWork)
			Me.Panel1.Controls.Add(Me.Label9)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.Button6)
			Me.Panel1.Controls.Add(Me.Button5)
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.Button10)
			Me.Panel1.Controls.Add(Me.Num1)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.TextBox3)
			Me.Panel1.Controls.Add(Me.txtserverlink)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.Button4)
			Me.Panel1.Controls.Add(Me.Button3)
			Me.Panel1.Controls.Add(Me.txtcompname)
			Me.Panel1.Controls.Add(Me.txtEmailID)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(161, 859)
			Me.Panel1.TabIndex = 11
			Me.lblwWork.AutoSize = True
			Me.lblwWork.Location = New Global.System.Drawing.Point(119, 255)
			Me.lblwWork.Name = "lblwWork"
			Me.lblwWork.Size = New Global.System.Drawing.Size(45, 13)
			Me.lblwWork.TabIndex = 524
			Me.lblwWork.Text = "Label10"
			Me.lblwWork.Visible = False
			Me.Label9.AutoSize = True
			Me.Label9.ForeColor = Global.System.Drawing.Color.White
			Me.Label9.Location = New Global.System.Drawing.Point(5, 172)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(0, 13)
			Me.Label9.TabIndex = 523
			Me.Label9.Visible = False
			Me.Label8.AutoSize = True
			Me.Label8.ForeColor = Global.System.Drawing.Color.White
			Me.Label8.Location = New Global.System.Drawing.Point(114, 145)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(0, 13)
			Me.Label8.TabIndex = 522
			Me.Label8.Visible = False
			Me.Label7.AutoSize = True
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(54, 146)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(0, 13)
			Me.Label7.TabIndex = 521
			Me.Label7.Visible = False
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(8, 148)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(0, 13)
			Me.Label6.TabIndex = 520
			Me.Label6.Visible = False
			Me.Button6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button6.BackColor = Global.System.Drawing.Color.White
			Me.Button6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button6.FlatAppearance.BorderColor = Global.System.Drawing.Color.LimeGreen
			Me.Button6.FlatAppearance.BorderSize = 4
			Me.Button6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button6.ForeColor = Global.System.Drawing.Color.FromArgb(0, 192, 0)
			Me.Button6.Image = CType(componentResourceManager.GetObject("Button6.Image"), Global.System.Drawing.Image)
			Me.Button6.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button6.Location = New Global.System.Drawing.Point(3, 595)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(155, 62)
			Me.Button6.TabIndex = 519
			Me.Button6.Text = "   Rocket"
			Me.Button6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button6.UseVisualStyleBackColor = False
			Me.Button5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button5.BackColor = Global.System.Drawing.Color.White
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatAppearance.BorderColor = Global.System.Drawing.Color.LimeGreen
			Me.Button5.FlatAppearance.BorderSize = 4
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button5.ForeColor = Global.System.Drawing.Color.FromArgb(0, 192, 0)
			Me.Button5.Image = CType(componentResourceManager.GetObject("Button5.Image"), Global.System.Drawing.Image)
			Me.Button5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button5.Location = New Global.System.Drawing.Point(3, 527)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(154, 62)
			Me.Button5.TabIndex = 518
			Me.Button5.Text = "   Tejas"
			Me.Button5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button5.UseVisualStyleBackColor = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(6, 789)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(149, 47)
			Me.GelButton1.TabIndex = 517
			Me.GelButton1.Text = "2nd WhatsApp"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton1.Visible = False
			Me.Button10.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button10.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button10.FlatAppearance.BorderSize = 0
			Me.Button10.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button10.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button10.ForeColor = Global.System.Drawing.Color.White
			Me.Button10.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button10.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button10.Image = CType(componentResourceManager.GetObject("Button10.Image"), Global.System.Drawing.Image)
			Me.Button10.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button10.Location = New Global.System.Drawing.Point(6, 795)
			Me.Button10.Name = "Button10"
			Me.Button10.Size = New Global.System.Drawing.Size(149, 47)
			Me.Button10.TabIndex = 516
			Me.Button10.Text = "3rd WhatsApp"
			Me.Button10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button10.UseVisualStyleBackColor = False
			Me.Button10.Visible = False
			Me.Label4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(-1, 462)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(161, 15)
			Me.Label4.TabIndex = 16
			Me.Label4.Text = "Text Message to WhatsApp :"
			Me.TextBox3.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox3.Location = New Global.System.Drawing.Point(4, 479)
			Me.TextBox3.Multiline = True
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.TextBox3.Size = New Global.System.Drawing.Size(150, 38)
			Me.TextBox3.TabIndex = 6
			Me.TextBox3.TabStop = False
			Me.TextBox3.Text = "Dear Sir/Madam, Please find the attachment file."
			Me.txtserverlink.AutoSize = True
			Me.txtserverlink.ForeColor = Global.System.Drawing.Color.White
			Me.txtserverlink.Location = New Global.System.Drawing.Point(8, 117)
			Me.txtserverlink.Name = "txtserverlink"
			Me.txtserverlink.Size = New Global.System.Drawing.Size(52, 13)
			Me.txtserverlink.TabIndex = 14
			Me.txtserverlink.Text = "serverlink"
			Me.txtserverlink.Visible = False
			Me.Label3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(3, 411)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(152, 15)
			Me.Label3.TabIndex = 13
			Me.Label3.Text = "Enter Valid WhatsApp No. :"
			Me.TextBox2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.TextBox2.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox2.Location = New Global.System.Drawing.Point(5, 428)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(149, 29)
			Me.TextBox2.TabIndex = 7
			Me.Button4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button4.BackColor = Global.System.Drawing.Color.White
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatAppearance.BorderColor = Global.System.Drawing.Color.LimeGreen
			Me.Button4.FlatAppearance.BorderSize = 4
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.FromArgb(0, 192, 0)
			Me.Button4.Image = CType(componentResourceManager.GetObject("Button4.Image"), Global.System.Drawing.Image)
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(2, 663)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(154, 62)
			Me.Button4.TabIndex = 8
			Me.Button4.Text = "Agni - F9"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.BottomRight
			Me.Button4.UseVisualStyleBackColor = False
			Me.Button4.Visible = False
			Me.Button3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button3.BackColor = Global.System.Drawing.Color.White
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatAppearance.BorderSize = 4
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.ForeColor = Global.System.Drawing.Color.Blue
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.Location = New Global.System.Drawing.Point(33, 56)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(94, 91)
			Me.Button3.TabIndex = 1
			Me.Button3.Text = "F6"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.BottomRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.White
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatAppearance.BorderSize = 4
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.ForeColor = Global.System.Drawing.Color.Red
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.Location = New Global.System.Drawing.Point(33, 161)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(94, 91)
			Me.Button1.TabIndex = 2
			Me.Button1.Text = "F7"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.BottomRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.Button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button2.BackColor = Global.System.Drawing.Color.White
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.Button2.FlatAppearance.BorderSize = 4
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.ForeColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.Location = New Global.System.Drawing.Point(33, 314)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(94, 91)
			Me.Button2.TabIndex = 4
			Me.Button2.Text = "F8"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.BottomRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(7, 25)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label5.TabIndex = 17
			Me.Label5.Text = "Label5"
			Me.Label5.Visible = False
			Me.StatusRetriever.Interval = 1000
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.AutoSizeMode = Global.System.Windows.Forms.AutoSizeMode.GrowAndShrink
			MyBase.ClientSize = New Global.System.Drawing.Size(1040, 859)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.CrystalReportViewer1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.Name = "frmReport"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Print Preview"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			CType(Me.Num1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040052E3 RID: 21219
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
