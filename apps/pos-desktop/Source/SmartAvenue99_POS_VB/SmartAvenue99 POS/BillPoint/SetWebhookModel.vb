Imports System
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x02000379 RID: 889
	Public Class SetWebhookModel
		' Token: 0x17005201 RID: 20993
		' (get) Token: 0x0600D14E RID: 53582 RVA: 0x0005D0D8 File Offset: 0x0005B2D8
		' (set) Token: 0x0600D14F RID: 53583 RVA: 0x0005D0E2 File Offset: 0x0005B2E2
		<JsonProperty("status")>
		Public Property Status As String

		' Token: 0x17005202 RID: 20994
		' (get) Token: 0x0600D150 RID: 53584 RVA: 0x0005D0EB File Offset: 0x0005B2EB
		' (set) Token: 0x0600D151 RID: 53585 RVA: 0x0005D0F5 File Offset: 0x0005B2F5
		<JsonProperty("message")>
		Public Property Message As String
	End Class
End Namespace
