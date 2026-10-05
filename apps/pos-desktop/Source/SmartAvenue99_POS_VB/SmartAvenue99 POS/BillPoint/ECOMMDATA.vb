Imports System
Imports System.Runtime.Serialization

Namespace BillPoint
	' Token: 0x02000057 RID: 87
	<DataContract()>
	Public Class ECOMMDATA
		' Token: 0x170006D4 RID: 1748
		' (get) Token: 0x060010BC RID: 4284 RVA: 0x0000F1F3 File Offset: 0x0000D3F3
		' (set) Token: 0x060010BD RID: 4285 RVA: 0x0000F1FD File Offset: 0x0000D3FD
		<DataMember()>
		Public Property success As String

		' Token: 0x170006D5 RID: 1749
		' (get) Token: 0x060010BE RID: 4286 RVA: 0x0000F206 File Offset: 0x0000D406
		' (set) Token: 0x060010BF RID: 4287 RVA: 0x0000F210 File Offset: 0x0000D410
		<DataMember()>
		Public Property CID As String

		' Token: 0x170006D6 RID: 1750
		' (get) Token: 0x060010C0 RID: 4288 RVA: 0x0000F219 File Offset: 0x0000D419
		' (set) Token: 0x060010C1 RID: 4289 RVA: 0x0000F223 File Offset: 0x0000D423
		<DataMember()>
		Public Property SID As String

		' Token: 0x170006D7 RID: 1751
		' (get) Token: 0x060010C2 RID: 4290 RVA: 0x0000F22C File Offset: 0x0000D42C
		' (set) Token: 0x060010C3 RID: 4291 RVA: 0x0000F236 File Offset: 0x0000D436
		<DataMember()>
		Public Property message As String
	End Class
End Namespace
