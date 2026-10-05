Namespace BillPoint
	' Token: 0x0200021B RID: 539
		Public Partial Class frmMigrate_test
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06009A4D RID: 39501 RVA: 0x006E8450 File Offset: 0x006E6650
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

		' Token: 0x06009A4E RID: 39502 RVA: 0x0004B50E File Offset: 0x0004970E
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 450)
			Me.Text = "frmMigrate_test"
		End Sub

		' Token: 0x04004461 RID: 17505
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
