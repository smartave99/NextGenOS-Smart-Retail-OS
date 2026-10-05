Imports System
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x02000377 RID: 887
	Public Class instaceIDModel
		' Token: 0x170051FB RID: 20987
		' (get) Token: 0x0600D140 RID: 53568 RVA: 0x0005D066 File Offset: 0x0005B266
		' (set) Token: 0x0600D141 RID: 53569 RVA: 0x0005D070 File Offset: 0x0005B270
		<JsonProperty("status")>
		Public Property Status As String

		' Token: 0x170051FC RID: 20988
		' (get) Token: 0x0600D142 RID: 53570 RVA: 0x0005D079 File Offset: 0x0005B279
		' (set) Token: 0x0600D143 RID: 53571 RVA: 0x0005D083 File Offset: 0x0005B283
		<JsonProperty("message")>
		Public Property Message As String

		' Token: 0x170051FD RID: 20989
		' (get) Token: 0x0600D144 RID: 53572 RVA: 0x0005D08C File Offset: 0x0005B28C
		' (set) Token: 0x0600D145 RID: 53573 RVA: 0x0005D096 File Offset: 0x0005B296
		<JsonProperty("instance_id")>
		Public Property InstanceId As String
	End Class
End Namespace
