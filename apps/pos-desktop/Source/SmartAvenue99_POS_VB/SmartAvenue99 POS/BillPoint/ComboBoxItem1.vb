Imports System

Namespace BillPoint
	' Token: 0x020001E4 RID: 484
	Public Class ComboBoxItem1
		' Token: 0x17002FB0 RID: 12208
		' (get) Token: 0x06008208 RID: 33288 RVA: 0x0003FBBF File Offset: 0x0003DDBF
		' (set) Token: 0x06008209 RID: 33289 RVA: 0x0003FBC9 File Offset: 0x0003DDC9
		Public Property DisplayText As String

		' Token: 0x17002FB1 RID: 12209
		' (get) Token: 0x0600820A RID: 33290 RVA: 0x0003FBD2 File Offset: 0x0003DDD2
		' (set) Token: 0x0600820B RID: 33291 RVA: 0x0003FBDC File Offset: 0x0003DDDC
		Public Property CustomValue As Integer

		' Token: 0x0600820C RID: 33292 RVA: 0x0003FBE5 File Offset: 0x0003DDE5
		Public Sub New(text As String, value As Integer)
			Me.DisplayText = text
			Me.CustomValue = value
		End Sub
	End Class
End Namespace
