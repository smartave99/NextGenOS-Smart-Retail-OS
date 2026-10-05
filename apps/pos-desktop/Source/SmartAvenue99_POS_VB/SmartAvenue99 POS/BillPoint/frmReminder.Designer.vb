Namespace BillPoint
	' Token: 0x02000364 RID: 868
		Public Partial Class frmReminder
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600CE34 RID: 52788 RVA: 0x0080C178 File Offset: 0x0080A378
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

		' Token: 0x0600CE35 RID: 52789 RVA: 0x0080C1C8 File Offset: 0x0080A3C8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmReminder))
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.dtRemind = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtMsg = New Global.System.Windows.Forms.TextBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.GroupBox1.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.GroupBox1.Controls.Add(Me.lblUser)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.dtRemind)
			Me.GroupBox1.Controls.Add(Me.txtMsg)
			Me.GroupBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox1.ForeColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Location = New Global.System.Drawing.Point(12, 12)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(652, 226)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Set Reminder"
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(402, 191)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(46, 15)
			Me.lblUser.TabIndex = 6
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(6, 183)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(87, 15)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = "Reminder On :"
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(6, 28)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(122, 15)
			Me.Label1.TabIndex = 3
			Me.Label1.Text = "Reminder Message :"
			Me.dtRemind.CustomFormat = "dd/MM/yyyy"
			Me.dtRemind.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtRemind.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtRemind.Location = New Global.System.Drawing.Point(146, 183)
			Me.dtRemind.Name = "dtRemind"
			Me.dtRemind.Size = New Global.System.Drawing.Size(137, 26)
			Me.dtRemind.TabIndex = 2
			Me.txtMsg.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMsg.Location = New Global.System.Drawing.Point(146, 28)
			Me.txtMsg.Multiline = True
			Me.txtMsg.Name = "txtMsg"
			Me.txtMsg.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtMsg.Size = New Global.System.Drawing.Size(481, 135)
			Me.txtMsg.TabIndex = 0
			Me.Button1.BackColor = Global.System.Drawing.Color.White
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.Black
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(532, 242)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(132, 41)
			Me.Button1.TabIndex = 1
			Me.Button1.Text = "Set Reminder"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(676, 287)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmReminder"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Set Reminder"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040052BF RID: 21183
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
