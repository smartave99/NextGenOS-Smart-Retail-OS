Namespace BillPoint
	' Token: 0x020001D0 RID: 464
		Public Partial Class frmPos_Cursor_Setting
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007954 RID: 31060 RVA: 0x005AA3A4 File Offset: 0x005A85A4
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

		' Token: 0x06007955 RID: 31061 RVA: 0x005AA3F4 File Offset: 0x005A85F4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.cmbComboPack = New Global.System.Windows.Forms.ComboBox()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.GroupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.cmbComboPack.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.cmbComboPack.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbComboPack.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbComboPack.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbComboPack.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbComboPack.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbComboPack.FormattingEnabled = True
			Me.cmbComboPack.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbComboPack.Location = New Global.System.Drawing.Point(101, 57)
			Me.cmbComboPack.Name = "cmbComboPack"
			Me.cmbComboPack.Size = New Global.System.Drawing.Size(219, 28)
			Me.cmbComboPack.TabIndex = 1802
			label.AutoSize = True
			label.BackColor = Global.System.Drawing.Color.Transparent
			label.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold)
			label.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			label.Location = New Global.System.Drawing.Point(97, 35)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label224"
			label.Size = New Global.System.Drawing.Size(127, 19)
			label.TabIndex = 1803
			label.Text = "Select Input Field:"
			label.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.GroupBox1.Controls.Add(Me.Button1)
			Me.GroupBox1.Controls.Add(Me.cmbComboPack)
			Me.GroupBox1.Controls.Add(label)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(14, 12)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(499, 123)
			Me.GroupBox1.TabIndex = 1804
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "POS Cursor Setting"
			Me.Button1.Font = New Global.System.Drawing.Font("Arial Narrow", 10F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.Blue
			Me.Button1.Location = New Global.System.Drawing.Point(326, 58)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(77, 27)
			Me.Button1.TabIndex = 1804
			Me.Button1.Text = "Default"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button1.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(539, 152)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Name = "frmPos_Cursor_Setting"
			Me.Text = "Pos Cursor Setting"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040035AC RID: 13740
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
