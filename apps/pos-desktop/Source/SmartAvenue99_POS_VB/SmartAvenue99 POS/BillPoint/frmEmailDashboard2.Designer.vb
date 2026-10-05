Namespace BillPoint
	' Token: 0x020000F4 RID: 244
		Public Partial Class frmEmailDashboard2
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600295C RID: 10588 RVA: 0x0019C9C4 File Offset: 0x0019ABC4
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

		' Token: 0x0600295D RID: 10589 RVA: 0x0019CA14 File Offset: 0x0019AC14
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.ListBoxNav = New Global.System.Windows.Forms.ListBox()
			Me.TreeViewNav = New Global.System.Windows.Forms.TreeView()
			Me.lblFrom = New Global.System.Windows.Forms.Label()
			Me.lblSubject = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnLoadMore = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.btnRefresh = New Global.System.Windows.Forms.Button()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.lblUid = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.lblTo = New Global.System.Windows.Forms.Label()
			Me.pnlSend = New Global.System.Windows.Forms.Panel()
			Me.WebBrowser2 = New Global.System.Windows.Forms.WebBrowser()
			Me.RichTextBox1 = New Global.System.Windows.Forms.RichTextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtSubject = New Global.System.Windows.Forms.TextBox()
			Me.txtCc = New Global.System.Windows.Forms.TextBox()
			Me.txtTo_view = New Global.System.Windows.Forms.TextBox()
			Me.txtFrom = New Global.System.Windows.Forms.TextBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Panel8 = New Global.System.Windows.Forms.Panel()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lnkForward = New Global.System.Windows.Forms.LinkLabel()
			Me.lnkReplyAll = New Global.System.Windows.Forms.LinkLabel()
			Me.lnkReply = New Global.System.Windows.Forms.LinkLabel()
			Me.FlowLayoutAttachments = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.rtbBody = New Global.System.Windows.Forms.RichTextBox()
			Me.WebBrowser1 = New Global.System.Windows.Forms.WebBrowser()
			Me.btnAttach = New Global.System.Windows.Forms.Button()
			Me.txtBcc = New Global.System.Windows.Forms.TextBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.lblCacheStatus = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.pnlSend.SuspendLayout()
			Me.Panel8.SuspendLayout()
			Me.Panel7.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.Panel5.SuspendLayout()
			MyBase.SuspendLayout()
			Me.ListBoxNav.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.ListBoxNav.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 7.25F)
			Me.ListBoxNav.FormattingEnabled = True
			Me.ListBoxNav.Location = New Global.System.Drawing.Point(0, 0)
			Me.ListBoxNav.Name = "ListBoxNav"
			Me.ListBoxNav.Size = New Global.System.Drawing.Size(265, 434)
			Me.ListBoxNav.TabIndex = 3
			Me.TreeViewNav.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TreeViewNav.Location = New Global.System.Drawing.Point(0, 0)
			Me.TreeViewNav.Name = "TreeViewNav"
			Me.TreeViewNav.Size = New Global.System.Drawing.Size(169, 434)
			Me.TreeViewNav.TabIndex = 2
			Me.lblFrom.AutoSize = True
			Me.lblFrom.Location = New Global.System.Drawing.Point(24, 49)
			Me.lblFrom.Name = "lblFrom"
			Me.lblFrom.Size = New Global.System.Drawing.Size(40, 13)
			Me.lblFrom.TabIndex = 1
			Me.lblFrom.Text = "lblFrom"
			Me.lblSubject.AutoSize = True
			Me.lblSubject.Location = New Global.System.Drawing.Point(24, 26)
			Me.lblSubject.Name = "lblSubject"
			Me.lblSubject.Size = New Global.System.Drawing.Size(53, 13)
			Me.lblSubject.TabIndex = 0
			Me.lblSubject.Text = "lblSubject"
			Me.Panel1.BackColor = Global.System.Drawing.SystemColors.ActiveCaption
			Me.Panel1.Controls.Add(Me.btnLoadMore)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.ProgressBar1)
			Me.Panel1.Controls.Add(Me.btnRefresh)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1087, 65)
			Me.Panel1.TabIndex = 5
			Me.btnLoadMore.Location = New Global.System.Drawing.Point(918, 7)
			Me.btnLoadMore.Name = "btnLoadMore"
			Me.btnLoadMore.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnLoadMore.TabIndex = 16
			Me.btnLoadMore.Text = "Load more.."
			Me.btnLoadMore.UseVisualStyleBackColor = True
			Me.Button1.Location = New Global.System.Drawing.Point(103, 4)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(89, 56)
			Me.Button1.TabIndex = 15
			Me.Button1.Text = "Old Dashboard"
			Me.Button1.UseVisualStyleBackColor = True
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(918, 32)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(162, 27)
			Me.ProgressBar1.TabIndex = 14
			Me.ProgressBar1.Visible = False
			Me.btnRefresh.Location = New Global.System.Drawing.Point(8, 4)
			Me.btnRefresh.Name = "btnRefresh"
			Me.btnRefresh.Size = New Global.System.Drawing.Size(89, 56)
			Me.btnRefresh.TabIndex = 10
			Me.btnRefresh.Text = "Send/Receive All Folders"
			Me.btnRefresh.UseVisualStyleBackColor = True
			Me.Panel2.Controls.Add(Me.TreeViewNav)
			Me.Panel2.Dock = Global.System.Windows.Forms.DockStyle.Left
			Me.Panel2.Location = New Global.System.Drawing.Point(0, 65)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(169, 434)
			Me.Panel2.TabIndex = 6
			Me.Panel3.Controls.Add(Me.ListBoxNav)
			Me.Panel3.Dock = Global.System.Windows.Forms.DockStyle.Left
			Me.Panel3.Location = New Global.System.Drawing.Point(169, 65)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(265, 434)
			Me.Panel3.TabIndex = 7
			Me.Panel4.BackColor = Global.System.Drawing.Color.White
			Me.Panel4.Controls.Add(Me.lblCacheStatus)
			Me.Panel4.Controls.Add(Me.lblUid)
			Me.Panel4.Controls.Add(Me.pnlSend)
			Me.Panel4.Controls.Add(Me.lnkForward)
			Me.Panel4.Controls.Add(Me.lnkReplyAll)
			Me.Panel4.Controls.Add(Me.lnkReply)
			Me.Panel4.Controls.Add(Me.FlowLayoutAttachments)
			Me.Panel4.Controls.Add(Me.rtbBody)
			Me.Panel4.Controls.Add(Me.WebBrowser1)
			Me.Panel4.Controls.Add(Me.lblFrom)
			Me.Panel4.Controls.Add(Me.lblSubject)
			Me.Panel4.Controls.Add(Me.lblTo)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Dock = Global.System.Windows.Forms.DockStyle.Left
			Me.Panel4.Location = New Global.System.Drawing.Point(434, 65)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(650, 434)
			Me.Panel4.TabIndex = 8
			Me.lblUid.AutoSize = True
			Me.lblUid.Location = New Global.System.Drawing.Point(220, 6)
			Me.lblUid.Name = "lblUid"
			Me.lblUid.Size = New Global.System.Drawing.Size(33, 13)
			Me.lblUid.TabIndex = 23
			Me.lblUid.Text = "lblUid"
			Me.lblUid.Visible = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(394, 49)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(10, 13)
			Me.Label5.TabIndex = 22
			Me.Label5.Text = "I"
			Me.lblTo.AutoSize = True
			Me.lblTo.Location = New Global.System.Drawing.Point(399, 49)
			Me.lblTo.Name = "lblTo"
			Me.lblTo.Size = New Global.System.Drawing.Size(30, 13)
			Me.lblTo.TabIndex = 21
			Me.lblTo.Text = "lblTo"
			Me.pnlSend.BackColor = Global.System.Drawing.SystemColors.InactiveBorder
			Me.pnlSend.Controls.Add(Me.txtBcc)
			Me.pnlSend.Controls.Add(Me.Panel5)
			Me.pnlSend.Controls.Add(Me.btnAttach)
			Me.pnlSend.Controls.Add(Me.WebBrowser2)
			Me.pnlSend.Controls.Add(Me.RichTextBox1)
			Me.pnlSend.Controls.Add(Me.Label4)
			Me.pnlSend.Controls.Add(Me.txtSubject)
			Me.pnlSend.Controls.Add(Me.txtCc)
			Me.pnlSend.Controls.Add(Me.txtTo_view)
			Me.pnlSend.Controls.Add(Me.txtFrom)
			Me.pnlSend.Controls.Add(Me.Button2)
			Me.pnlSend.Controls.Add(Me.Panel8)
			Me.pnlSend.Controls.Add(Me.Panel7)
			Me.pnlSend.Controls.Add(Me.Panel6)
			Me.pnlSend.Location = New Global.System.Drawing.Point(7, 26)
			Me.pnlSend.Name = "pnlSend"
			Me.pnlSend.Size = New Global.System.Drawing.Size(634, 396)
			Me.pnlSend.TabIndex = 20
			Me.pnlSend.Visible = False
			Me.WebBrowser2.Location = New Global.System.Drawing.Point(11, 158)
			Me.WebBrowser2.MinimumSize = New Global.System.Drawing.Size(20, 20)
			Me.WebBrowser2.Name = "WebBrowser2"
			Me.WebBrowser2.Size = New Global.System.Drawing.Size(615, 230)
			Me.WebBrowser2.TabIndex = 23
			Me.WebBrowser2.Visible = False
			Me.RichTextBox1.BackColor = Global.System.Drawing.SystemColors.Info
			Me.RichTextBox1.Location = New Global.System.Drawing.Point(7, 158)
			Me.RichTextBox1.Name = "RichTextBox1"
			Me.RichTextBox1.Size = New Global.System.Drawing.Size(620, 231)
			Me.RichTextBox1.TabIndex = 22
			Me.RichTextBox1.Text = ""
			Me.RichTextBox1.Visible = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(96, 132)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label4.TabIndex = 2
			Me.Label4.Text = "Subject"
			Me.txtSubject.Location = New Global.System.Drawing.Point(148, 128)
			Me.txtSubject.Name = "txtSubject"
			Me.txtSubject.Size = New Global.System.Drawing.Size(479, 20)
			Me.txtSubject.TabIndex = 21
			Me.txtCc.Location = New Global.System.Drawing.Point(148, 76)
			Me.txtCc.Name = "txtCc"
			Me.txtCc.Size = New Global.System.Drawing.Size(274, 20)
			Me.txtCc.TabIndex = 20
			Me.txtTo_view.Location = New Global.System.Drawing.Point(148, 49)
			Me.txtTo_view.Name = "txtTo_view"
			Me.txtTo_view.Size = New Global.System.Drawing.Size(274, 20)
			Me.txtTo_view.TabIndex = 19
			Me.txtFrom.Location = New Global.System.Drawing.Point(148, 23)
			Me.txtFrom.Name = "txtFrom"
			Me.txtFrom.Size = New Global.System.Drawing.Size(274, 20)
			Me.txtFrom.TabIndex = 18
			Me.Button2.Location = New Global.System.Drawing.Point(3, 19)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(58, 77)
			Me.Button2.TabIndex = 17
			Me.Button2.Text = "Send"
			Me.Button2.UseVisualStyleBackColor = True
			Me.Panel8.BackColor = Global.System.Drawing.Color.Snow
			Me.Panel8.Controls.Add(Me.Label3)
			Me.Panel8.Location = New Global.System.Drawing.Point(67, 75)
			Me.Panel8.Name = "Panel8"
			Me.Panel8.Size = New Global.System.Drawing.Size(75, 21)
			Me.Panel8.TabIndex = 3
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(23, 4)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label3.TabIndex = 1
			Me.Label3.Text = "Cc.."
			Me.Panel7.BackColor = Global.System.Drawing.Color.Snow
			Me.Panel7.Controls.Add(Me.Label2)
			Me.Panel7.Location = New Global.System.Drawing.Point(67, 48)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(75, 21)
			Me.Panel7.TabIndex = 2
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(23, 4)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 1
			Me.Label2.Text = "To.."
			Me.Panel6.BackColor = Global.System.Drawing.Color.Snow
			Me.Panel6.Controls.Add(Me.Label1)
			Me.Panel6.Location = New Global.System.Drawing.Point(67, 21)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(75, 21)
			Me.Panel6.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(23, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "From.."
			Me.lnkForward.AutoSize = True
			Me.lnkForward.Location = New Global.System.Drawing.Point(112, 5)
			Me.lnkForward.Name = "lnkForward"
			Me.lnkForward.Size = New Global.System.Drawing.Size(45, 13)
			Me.lnkForward.TabIndex = 19
			Me.lnkForward.TabStop = True
			Me.lnkForward.Text = "Forward"
			Me.lnkReplyAll.AutoSize = True
			Me.lnkReplyAll.Location = New Global.System.Drawing.Point(58, 5)
			Me.lnkReplyAll.Name = "lnkReplyAll"
			Me.lnkReplyAll.Size = New Global.System.Drawing.Size(48, 13)
			Me.lnkReplyAll.TabIndex = 18
			Me.lnkReplyAll.TabStop = True
			Me.lnkReplyAll.Text = "Reply All"
			Me.lnkReply.AutoSize = True
			Me.lnkReply.Location = New Global.System.Drawing.Point(18, 5)
			Me.lnkReply.Name = "lnkReply"
			Me.lnkReply.Size = New Global.System.Drawing.Size(34, 13)
			Me.lnkReply.TabIndex = 17
			Me.lnkReply.TabStop = True
			Me.lnkReply.Text = "Reply"
			Me.FlowLayoutAttachments.AutoScroll = True
			Me.FlowLayoutAttachments.Location = New Global.System.Drawing.Point(21, 69)
			Me.FlowLayoutAttachments.Name = "FlowLayoutAttachments"
			Me.FlowLayoutAttachments.Size = New Global.System.Drawing.Size(620, 48)
			Me.FlowLayoutAttachments.TabIndex = 16
			Me.rtbBody.Location = New Global.System.Drawing.Point(21, 123)
			Me.rtbBody.Name = "rtbBody"
			Me.rtbBody.Size = New Global.System.Drawing.Size(620, 303)
			Me.rtbBody.TabIndex = 15
			Me.rtbBody.Text = ""
			Me.rtbBody.Visible = False
			Me.WebBrowser1.Location = New Global.System.Drawing.Point(21, 123)
			Me.WebBrowser1.MinimumSize = New Global.System.Drawing.Size(20, 20)
			Me.WebBrowser1.Name = "WebBrowser1"
			Me.WebBrowser1.Size = New Global.System.Drawing.Size(620, 300)
			Me.WebBrowser1.TabIndex = 7
			Me.WebBrowser1.Visible = False
			Me.btnAttach.Location = New Global.System.Drawing.Point(510, 102)
			Me.btnAttach.Name = "btnAttach"
			Me.btnAttach.Size = New Global.System.Drawing.Size(116, 21)
			Me.btnAttach.TabIndex = 24
			Me.btnAttach.Text = "Attachment File"
			Me.btnAttach.UseVisualStyleBackColor = True
			Me.txtBcc.Location = New Global.System.Drawing.Point(149, 102)
			Me.txtBcc.Name = "txtBcc"
			Me.txtBcc.Size = New Global.System.Drawing.Size(274, 20)
			Me.txtBcc.TabIndex = 26
			Me.Panel5.BackColor = Global.System.Drawing.Color.Snow
			Me.Panel5.Controls.Add(Me.Label6)
			Me.Panel5.Location = New Global.System.Drawing.Point(68, 101)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(75, 21)
			Me.Panel5.TabIndex = 25
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(23, 4)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(32, 13)
			Me.Label6.TabIndex = 1
			Me.Label6.Text = "Bcc.."
			Me.lblCacheStatus.AutoSize = True
			Me.lblCacheStatus.Location = New Global.System.Drawing.Point(467, 5)
			Me.lblCacheStatus.Name = "lblCacheStatus"
			Me.lblCacheStatus.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblCacheStatus.TabIndex = 24
			Me.lblCacheStatus.Text = "Label7"
			Me.lblCacheStatus.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1087, 499)
			MyBase.Controls.Add(Me.Panel4)
			MyBase.Controls.Add(Me.Panel3)
			MyBase.Controls.Add(Me.Panel2)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Name = "frmEmailDashboard2"
			Me.Text = "frmEmailDashboard2"
			Me.Panel1.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel3.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.pnlSend.ResumeLayout(False)
			Me.pnlSend.PerformLayout()
			Me.Panel8.ResumeLayout(False)
			Me.Panel8.PerformLayout()
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel5.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400117A RID: 4474
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
