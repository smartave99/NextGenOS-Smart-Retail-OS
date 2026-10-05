Namespace BillPoint
	' Token: 0x020001EA RID: 490
		Public Partial Class frmBulkProductSeting
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060083FD RID: 33789 RVA: 0x00620744 File Offset: 0x0061E944
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

		' Token: 0x060083FE RID: 33790 RVA: 0x00620794 File Offset: 0x0061E994
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.CheckedListBox1 = New Global.System.Windows.Forms.CheckedListBox()
			MyBase.SuspendLayout()
			Me.CheckedListBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.CheckedListBox1.BackColor = Global.System.Drawing.Color.AliceBlue
			Me.CheckedListBox1.FormattingEnabled = True
			Me.CheckedListBox1.Location = New Global.System.Drawing.Point(13, 1)
			Me.CheckedListBox1.Name = "CheckedListBox1"
			Me.CheckedListBox1.ScrollAlwaysVisible = True
			Me.CheckedListBox1.Size = New Global.System.Drawing.Size(191, 529)
			Me.CheckedListBox1.TabIndex = 526
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(216, 542)
			MyBase.Controls.Add(Me.CheckedListBox1)
			MyBase.Name = "frmBulkProductSeting"
			Me.Text = "Bulk Product Seting"
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04003A62 RID: 14946
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
