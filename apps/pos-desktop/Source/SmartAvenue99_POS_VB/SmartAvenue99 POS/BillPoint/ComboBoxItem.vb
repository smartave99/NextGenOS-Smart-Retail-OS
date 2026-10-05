Imports System

Namespace BillPoint
	' Token: 0x020001E9 RID: 489
	Public Class ComboBoxItem
		' Token: 0x17003062 RID: 12386
		' (get) Token: 0x060083F7 RID: 33783 RVA: 0x000408D3 File Offset: 0x0003EAD3
		' (set) Token: 0x060083F8 RID: 33784 RVA: 0x000408DD File Offset: 0x0003EADD
		Public Property DisplayText As String

		' Token: 0x17003063 RID: 12387
		' (get) Token: 0x060083F9 RID: 33785 RVA: 0x000408E6 File Offset: 0x0003EAE6
		' (set) Token: 0x060083FA RID: 33786 RVA: 0x000408F0 File Offset: 0x0003EAF0
		Public Property CustomValue As Integer

		' Token: 0x060083FB RID: 33787 RVA: 0x000408F9 File Offset: 0x0003EAF9
		Public Sub New(text As String, value As Integer)
			Me.DisplayText = text
			Me.CustomValue = value
		End Sub
	End Class
End Namespace
