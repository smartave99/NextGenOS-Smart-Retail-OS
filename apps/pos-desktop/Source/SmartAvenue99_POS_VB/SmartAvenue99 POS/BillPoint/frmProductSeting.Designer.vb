Namespace BillPoint
	' Token: 0x020001EB RID: 491
		Public Partial Class frmProductSeting
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06008406 RID: 33798 RVA: 0x00620B3C File Offset: 0x0061ED3C
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

		' Token: 0x06008407 RID: 33799 RVA: 0x00620B8C File Offset: 0x0061ED8C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.CheckedListBox1 = New Global.System.Windows.Forms.CheckedListBox()
			MyBase.SuspendLayout()
			Me.CheckedListBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.CheckedListBox1.BackColor = Global.System.Drawing.Color.AliceBlue
			Me.CheckedListBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckedListBox1.ForeColor = Global.System.Drawing.Color.MidnightBlue
			Me.CheckedListBox1.FormattingEnabled = True
			Me.CheckedListBox1.Location = New Global.System.Drawing.Point(2, 1)
			Me.CheckedListBox1.Name = "CheckedListBox1"
			Me.CheckedListBox1.ScrollAlwaysVisible = True
			Me.CheckedListBox1.Size = New Global.System.Drawing.Size(305, 649)
			Me.CheckedListBox1.TabIndex = 526
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(307, 654)
			MyBase.Controls.Add(Me.CheckedListBox1)
			MyBase.Name = "frmProductSeting"
			Me.Text = "frmProductSeting"
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04003A64 RID: 14948
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
