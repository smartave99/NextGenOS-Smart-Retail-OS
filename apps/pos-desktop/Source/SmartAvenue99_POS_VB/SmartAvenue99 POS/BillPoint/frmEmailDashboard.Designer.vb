Namespace BillPoint
	' Token: 0x020000E0 RID: 224
		Public Partial Class frmEmailDashboard
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002885 RID: 10373 RVA: 0x001977AC File Offset: 0x001959AC
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

		' Token: 0x06002886 RID: 10374 RVA: 0x001977FC File Offset: 0x001959FC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.btnReply = New Global.System.Windows.Forms.Button()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtFrom = New Global.System.Windows.Forms.TextBox()
			Me.txtSubject = New Global.System.Windows.Forms.TextBox()
			Me.rtbBody = New Global.System.Windows.Forms.TextBox()
			Me.lstAttachments = New Global.System.Windows.Forms.ListBox()
			Me.btnRefresh = New Global.System.Windows.Forms.Button()
			Me.pnlCompose = New Global.System.Windows.Forms.Panel()
			Me.txtBody = New Global.System.Windows.Forms.RichTextBox()
			Me.chkAi = New Global.System.Windows.Forms.CheckBox()
			Me.btnAttach = New Global.System.Windows.Forms.Button()
			Me.txtCC = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtBCC = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.btnCompose_Exit = New Global.System.Windows.Forms.Button()
			Me.btnSend = New Global.System.Windows.Forms.Button()
			Me.txtSubject_compose = New Global.System.Windows.Forms.TextBox()
			Me.txtTo = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.pnlSentMail = New Global.System.Windows.Forms.Panel()
			Me.btnRefreshSent = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.flpAttachments = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.TabControl2 = New Global.System.Windows.Forms.TabControl()
			Me.TabPage1 = New Global.System.Windows.Forms.TabPage()
			Me.lblPage = New Global.System.Windows.Forms.Label()
			Me.btnPrevious = New Global.System.Windows.Forms.Button()
			Me.btnNext = New Global.System.Windows.Forms.Button()
			Me.TabPage2 = New Global.System.Windows.Forms.TabPage()
			Me.TabPage3 = New Global.System.Windows.Forms.TabPage()
			Me.TabPage4 = New Global.System.Windows.Forms.TabPage()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.txtTo_view = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.btnInbox = New Global.System.Windows.Forms.Button()
			Me.btnCompose = New Global.System.Windows.Forms.Button()
			Me.btnLoadSent = New Global.System.Windows.Forms.Button()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlCompose.SuspendLayout()
			Me.pnlSentMail.SuspendLayout()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.TabControl2.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			Me.TabPage2.SuspendLayout()
			Me.TabPage3.SuspendLayout()
			Me.TabPage4.SuspendLayout()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			Me.DataGridView1.AllowUserToOrderColumns = True
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			dataGridViewCellStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle.BackColor = Global.System.Drawing.SystemColors.Control
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.Location = New Global.System.Drawing.Point(3, 28)
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.Size = New Global.System.Drawing.Size(949, 366)
			Me.DataGridView1.TabIndex = 0
			Me.btnReply.ForeColor = Global.System.Drawing.Color.Red
			Me.btnReply.Location = New Global.System.Drawing.Point(686, 24)
			Me.btnReply.Name = "btnReply"
			Me.btnReply.Size = New Global.System.Drawing.Size(96, 21)
			Me.btnReply.TabIndex = 1
			Me.btnReply.Text = "Reply"
			Me.btnReply.UseVisualStyleBackColor = True
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(6, 3)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(30, 13)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "From"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(6, 48)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label2.TabIndex = 3
			Me.Label2.Text = "Subject"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(6, 64)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(50, 13)
			Me.Label3.TabIndex = 4
			Me.Label3.Text = "Message"
			Me.txtFrom.Location = New Global.System.Drawing.Point(89, 3)
			Me.txtFrom.Name = "txtFrom"
			Me.txtFrom.Size = New Global.System.Drawing.Size(274, 20)
			Me.txtFrom.TabIndex = 5
			Me.txtSubject.Location = New Global.System.Drawing.Point(89, 46)
			Me.txtSubject.Name = "txtSubject"
			Me.txtSubject.Size = New Global.System.Drawing.Size(693, 20)
			Me.txtSubject.TabIndex = 6
			Me.rtbBody.Location = New Global.System.Drawing.Point(89, 68)
			Me.rtbBody.Multiline = True
			Me.rtbBody.Name = "rtbBody"
			Me.rtbBody.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.rtbBody.Size = New Global.System.Drawing.Size(693, 223)
			Me.rtbBody.TabIndex = 7
			Me.lstAttachments.FormattingEnabled = True
			Me.lstAttachments.Location = New Global.System.Drawing.Point(6, 88)
			Me.lstAttachments.Name = "lstAttachments"
			Me.lstAttachments.Size = New Global.System.Drawing.Size(73, 43)
			Me.lstAttachments.TabIndex = 8
			Me.lstAttachments.Visible = False
			Me.btnRefresh.Location = New Global.System.Drawing.Point(3, 3)
			Me.btnRefresh.Name = "btnRefresh"
			Me.btnRefresh.Size = New Global.System.Drawing.Size(77, 21)
			Me.btnRefresh.TabIndex = 9
			Me.btnRefresh.Text = "Refresh"
			Me.btnRefresh.UseVisualStyleBackColor = True
			Me.pnlCompose.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.pnlCompose.BackColor = Global.System.Drawing.SystemColors.InactiveCaption
			Me.pnlCompose.Controls.Add(Me.txtBody)
			Me.pnlCompose.Controls.Add(Me.chkAi)
			Me.pnlCompose.Controls.Add(Me.btnAttach)
			Me.pnlCompose.Controls.Add(Me.txtCC)
			Me.pnlCompose.Controls.Add(Me.Label8)
			Me.pnlCompose.Controls.Add(Me.txtBCC)
			Me.pnlCompose.Controls.Add(Me.Label7)
			Me.pnlCompose.Controls.Add(Me.btnCompose_Exit)
			Me.pnlCompose.Controls.Add(Me.btnSend)
			Me.pnlCompose.Controls.Add(Me.txtSubject_compose)
			Me.pnlCompose.Controls.Add(Me.txtTo)
			Me.pnlCompose.Controls.Add(Me.Label4)
			Me.pnlCompose.Controls.Add(Me.Label5)
			Me.pnlCompose.Controls.Add(Me.Label6)
			Me.pnlCompose.Location = New Global.System.Drawing.Point(6, 6)
			Me.pnlCompose.Name = "pnlCompose"
			Me.pnlCompose.Size = New Global.System.Drawing.Size(959, 375)
			Me.pnlCompose.TabIndex = 11
			Me.txtBody.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.txtBody.Location = New Global.System.Drawing.Point(80, 115)
			Me.txtBody.Name = "txtBody"
			Me.txtBody.Size = New Global.System.Drawing.Size(876, 227)
			Me.txtBody.TabIndex = 21
			Me.txtBody.Text = ""
			Me.chkAi.AutoSize = True
			Me.chkAi.Location = New Global.System.Drawing.Point(874, 91)
			Me.chkAi.Name = "chkAi"
			Me.chkAi.Size = New Global.System.Drawing.Size(82, 17)
			Me.chkAi.TabIndex = 20
			Me.chkAi.Text = "AI Message"
			Me.chkAi.UseVisualStyleBackColor = True
			Me.btnAttach.Location = New Global.System.Drawing.Point(78, 348)
			Me.btnAttach.Name = "btnAttach"
			Me.btnAttach.Size = New Global.System.Drawing.Size(168, 21)
			Me.btnAttach.TabIndex = 19
			Me.btnAttach.Text = "Click Here to Attachments"
			Me.btnAttach.UseVisualStyleBackColor = True
			Me.txtCC.Location = New Global.System.Drawing.Point(80, 41)
			Me.txtCC.Name = "txtCC"
			Me.txtCC.Size = New Global.System.Drawing.Size(290, 20)
			Me.txtCC.TabIndex = 18
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(25, 44)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(21, 13)
			Me.Label8.TabIndex = 17
			Me.Label8.Text = "CC"
			Me.txtBCC.Location = New Global.System.Drawing.Point(80, 66)
			Me.txtBCC.Name = "txtBCC"
			Me.txtBCC.Size = New Global.System.Drawing.Size(290, 20)
			Me.txtBCC.TabIndex = 16
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(24, 69)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(28, 13)
			Me.Label7.TabIndex = 15
			Me.Label7.Text = "BCC"
			Me.btnCompose_Exit.ForeColor = Global.System.Drawing.Color.Red
			Me.btnCompose_Exit.Location = New Global.System.Drawing.Point(997, 3)
			Me.btnCompose_Exit.Name = "btnCompose_Exit"
			Me.btnCompose_Exit.Size = New Global.System.Drawing.Size(29, 21)
			Me.btnCompose_Exit.TabIndex = 14
			Me.btnCompose_Exit.Text = "X"
			Me.btnCompose_Exit.UseVisualStyleBackColor = True
			Me.btnCompose_Exit.Visible = False
			Me.btnSend.ForeColor = Global.System.Drawing.Color.CornflowerBlue
			Me.btnSend.Location = New Global.System.Drawing.Point(860, 345)
			Me.btnSend.Name = "btnSend"
			Me.btnSend.Size = New Global.System.Drawing.Size(96, 27)
			Me.btnSend.TabIndex = 12
			Me.btnSend.Text = "Send"
			Me.btnSend.UseVisualStyleBackColor = True
			Me.txtSubject_compose.Location = New Global.System.Drawing.Point(80, 89)
			Me.txtSubject_compose.Name = "txtSubject_compose"
			Me.txtSubject_compose.Size = New Global.System.Drawing.Size(788, 20)
			Me.txtSubject_compose.TabIndex = 12
			Me.txtTo.Location = New Global.System.Drawing.Point(80, 16)
			Me.txtTo.Name = "txtTo"
			Me.txtTo.Size = New Global.System.Drawing.Size(290, 20)
			Me.txtTo.TabIndex = 11
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(24, 115)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(50, 13)
			Me.Label4.TabIndex = 10
			Me.Label4.Text = "Message"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(24, 93)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label5.TabIndex = 9
			Me.Label5.Text = "Subject"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(25, 19)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(20, 13)
			Me.Label6.TabIndex = 8
			Me.Label6.Text = "To"
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.pnlSentMail.Controls.Add(Me.btnRefreshSent)
			Me.pnlSentMail.Controls.Add(Me.Button2)
			Me.pnlSentMail.Controls.Add(Me.Label9)
			Me.pnlSentMail.Controls.Add(Me.DataGridView2)
			Me.pnlSentMail.Location = New Global.System.Drawing.Point(3, 6)
			Me.pnlSentMail.Name = "pnlSentMail"
			Me.pnlSentMail.Size = New Global.System.Drawing.Size(1024, 364)
			Me.pnlSentMail.TabIndex = 13
			Me.btnRefreshSent.Location = New Global.System.Drawing.Point(5, 6)
			Me.btnRefreshSent.Name = "btnRefreshSent"
			Me.btnRefreshSent.Size = New Global.System.Drawing.Size(77, 21)
			Me.btnRefreshSent.TabIndex = 18
			Me.btnRefreshSent.Text = "Refresh"
			Me.btnRefreshSent.UseVisualStyleBackColor = True
			Me.Button2.ForeColor = Global.System.Drawing.SystemColors.MenuHighlight
			Me.Button2.Location = New Global.System.Drawing.Point(944, 2)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(77, 21)
			Me.Button2.TabIndex = 17
			Me.Button2.Text = "Load more.."
			Me.Button2.UseVisualStyleBackColor = True
			Me.Label9.AutoSize = True
			Me.Label9.ForeColor = Global.System.Drawing.SystemColors.Highlight
			Me.Label9.Location = New Global.System.Drawing.Point(88, 10)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label9.TabIndex = 16
			Me.Label9.Text = "Sent Mails List"
			Me.DataGridView2.AllowUserToAddRows = False
			Me.DataGridView2.AllowUserToDeleteRows = False
			Me.DataGridView2.AllowUserToOrderColumns = True
			Me.DataGridView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView2.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Control
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView2.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView2.DefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView2.Location = New Global.System.Drawing.Point(6, 30)
			Me.DataGridView2.Name = "DataGridView2"
			Me.DataGridView2.[ReadOnly] = True
			Me.DataGridView2.Size = New Global.System.Drawing.Size(1015, 331)
			Me.DataGridView2.TabIndex = 1
			Me.Button1.ForeColor = Global.System.Drawing.Color.Red
			Me.Button1.Location = New Global.System.Drawing.Point(998, 376)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(29, 21)
			Me.Button1.TabIndex = 15
			Me.Button1.Text = "X"
			Me.Button1.UseVisualStyleBackColor = True
			Me.Button1.Visible = False
			Me.flpAttachments.AutoScroll = True
			Me.flpAttachments.Location = New Global.System.Drawing.Point(89, 293)
			Me.flpAttachments.Name = "flpAttachments"
			Me.flpAttachments.Size = New Global.System.Drawing.Size(693, 69)
			Me.flpAttachments.TabIndex = 14
			Me.TabControl2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TabControl2.Controls.Add(Me.TabPage1)
			Me.TabControl2.Controls.Add(Me.TabPage2)
			Me.TabControl2.Controls.Add(Me.TabPage3)
			Me.TabControl2.Controls.Add(Me.TabPage4)
			Me.TabControl2.Location = New Global.System.Drawing.Point(170, 12)
			Me.TabControl2.Name = "TabControl2"
			Me.TabControl2.SelectedIndex = 0
			Me.TabControl2.Size = New Global.System.Drawing.Size(979, 426)
			Me.TabControl2.TabIndex = 16
			Me.TabPage1.Controls.Add(Me.lblPage)
			Me.TabPage1.Controls.Add(Me.btnPrevious)
			Me.TabPage1.Controls.Add(Me.btnNext)
			Me.TabPage1.Controls.Add(Me.DataGridView1)
			Me.TabPage1.Controls.Add(Me.btnRefresh)
			Me.TabPage1.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Size = New Global.System.Drawing.Size(971, 400)
			Me.TabPage1.TabIndex = 2
			Me.TabPage1.Text = "Inbox"
			Me.TabPage1.UseVisualStyleBackColor = True
			Me.lblPage.AutoSize = True
			Me.lblPage.Location = New Global.System.Drawing.Point(543, 7)
			Me.lblPage.Name = "lblPage"
			Me.lblPage.Size = New Global.System.Drawing.Size(13, 13)
			Me.lblPage.TabIndex = 12
			Me.lblPage.Text = "0"
			Me.lblPage.Visible = False
			Me.btnPrevious.Location = New Global.System.Drawing.Point(875, 1)
			Me.btnPrevious.Name = "btnPrevious"
			Me.btnPrevious.Size = New Global.System.Drawing.Size(77, 21)
			Me.btnPrevious.TabIndex = 11
			Me.btnPrevious.Text = "< Previous"
			Me.btnPrevious.UseVisualStyleBackColor = True
			Me.btnPrevious.Visible = False
			Me.btnNext.ForeColor = Global.System.Drawing.SystemColors.MenuHighlight
			Me.btnNext.Location = New Global.System.Drawing.Point(792, 3)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New Global.System.Drawing.Size(77, 21)
			Me.btnNext.TabIndex = 10
			Me.btnNext.Text = "Load more.."
			Me.btnNext.UseVisualStyleBackColor = True
			Me.TabPage2.Controls.Add(Me.pnlSentMail)
			Me.TabPage2.Controls.Add(Me.Button1)
			Me.TabPage2.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage2.Name = "TabPage2"
			Me.TabPage2.Size = New Global.System.Drawing.Size(971, 400)
			Me.TabPage2.TabIndex = 3
			Me.TabPage2.Text = "Sent"
			Me.TabPage2.UseVisualStyleBackColor = True
			Me.TabPage3.Controls.Add(Me.pnlCompose)
			Me.TabPage3.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage3.Name = "TabPage3"
			Me.TabPage3.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage3.Size = New Global.System.Drawing.Size(971, 400)
			Me.TabPage3.TabIndex = 0
			Me.TabPage3.Text = "Compose"
			Me.TabPage3.UseVisualStyleBackColor = True
			Me.TabPage4.Controls.Add(Me.Panel1)
			Me.TabPage4.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage4.Name = "TabPage4"
			Me.TabPage4.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage4.Size = New Global.System.Drawing.Size(971, 400)
			Me.TabPage4.TabIndex = 1
			Me.TabPage4.Text = "View Mail"
			Me.TabPage4.UseVisualStyleBackColor = True
			Me.Panel1.Controls.Add(Me.txtTo_view)
			Me.Panel1.Controls.Add(Me.Label10)
			Me.Panel1.Controls.Add(Me.txtFrom)
			Me.Panel1.Controls.Add(Me.btnReply)
			Me.Panel1.Controls.Add(Me.flpAttachments)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.lstAttachments)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.rtbBody)
			Me.Panel1.Controls.Add(Me.txtSubject)
			Me.Panel1.Location = New Global.System.Drawing.Point(6, 6)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(793, 365)
			Me.Panel1.TabIndex = 17
			Me.txtTo_view.Location = New Global.System.Drawing.Point(89, 25)
			Me.txtTo_view.Name = "txtTo_view"
			Me.txtTo_view.Size = New Global.System.Drawing.Size(274, 20)
			Me.txtTo_view.TabIndex = 16
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(6, 25)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(20, 13)
			Me.Label10.TabIndex = 15
			Me.Label10.Text = "To"
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(2, 195)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(162, 27)
			Me.ProgressBar1.TabIndex = 13
			Me.ProgressBar1.Visible = False
			Me.Button3.BackgroundImage = Global.BillPoint.My.Resources.Resources.E_mail_Login_copy
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.FlatAppearance.BorderSize = 0
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Location = New Global.System.Drawing.Point(5, 258)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(162, 54)
			Me.Button3.TabIndex = 18
			Me.Button3.UseVisualStyleBackColor = True
			Me.btnInbox.BackgroundImage = Global.BillPoint.My.Resources.Resources.Inbox_copy
			Me.btnInbox.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			Me.btnInbox.FlatAppearance.BorderSize = 0
			Me.btnInbox.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnInbox.Location = New Global.System.Drawing.Point(2, 68)
			Me.btnInbox.Name = "btnInbox"
			Me.btnInbox.Size = New Global.System.Drawing.Size(162, 54)
			Me.btnInbox.TabIndex = 17
			Me.btnInbox.UseVisualStyleBackColor = True
			Me.btnCompose.BackgroundImage = Global.BillPoint.My.Resources.Resources.Compose_copy
			Me.btnCompose.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnCompose.FlatAppearance.BorderSize = 0
			Me.btnCompose.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCompose.Location = New Global.System.Drawing.Point(2, 12)
			Me.btnCompose.Name = "btnCompose"
			Me.btnCompose.Size = New Global.System.Drawing.Size(162, 54)
			Me.btnCompose.TabIndex = 10
			Me.btnCompose.UseVisualStyleBackColor = True
			Me.btnLoadSent.BackgroundImage = Global.BillPoint.My.Resources.Resources.Send_Mail_copy
			Me.btnLoadSent.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			Me.btnLoadSent.FlatAppearance.BorderSize = 0
			Me.btnLoadSent.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnLoadSent.Location = New Global.System.Drawing.Point(2, 120)
			Me.btnLoadSent.Name = "btnLoadSent"
			Me.btnLoadSent.Size = New Global.System.Drawing.Size(162, 54)
			Me.btnLoadSent.TabIndex = 12
			Me.btnLoadSent.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(1150, 450)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.btnInbox)
			MyBase.Controls.Add(Me.ProgressBar1)
			MyBase.Controls.Add(Me.TabControl2)
			MyBase.Controls.Add(Me.btnCompose)
			MyBase.Controls.Add(Me.btnLoadSent)
			MyBase.Name = "frmEmailDashboard"
			Me.Text = "Email Dashboard"
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlCompose.ResumeLayout(False)
			Me.pnlCompose.PerformLayout()
			Me.pnlSentMail.ResumeLayout(False)
			Me.pnlSentMail.PerformLayout()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.TabControl2.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			Me.TabPage1.PerformLayout()
			Me.TabPage2.ResumeLayout(False)
			Me.TabPage3.ResumeLayout(False)
			Me.TabPage4.ResumeLayout(False)
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040010EC RID: 4332
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
