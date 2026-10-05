Imports System
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x02000378 RID: 888
	Public Class QRCodeModel
		' Token: 0x170051FE RID: 20990
		' (get) Token: 0x0600D147 RID: 53575 RVA: 0x0005D09F File Offset: 0x0005B29F
		' (set) Token: 0x0600D148 RID: 53576 RVA: 0x0005D0A9 File Offset: 0x0005B2A9
		<JsonProperty("status")>
		Public Property Status As String

		' Token: 0x170051FF RID: 20991
		' (get) Token: 0x0600D149 RID: 53577 RVA: 0x0005D0B2 File Offset: 0x0005B2B2
		' (set) Token: 0x0600D14A RID: 53578 RVA: 0x0005D0BC File Offset: 0x0005B2BC
		<JsonProperty("message")>
		Public Property Message As String

		' Token: 0x17005200 RID: 20992
		' (get) Token: 0x0600D14B RID: 53579 RVA: 0x0005D0C5 File Offset: 0x0005B2C5
		' (set) Token: 0x0600D14C RID: 53580 RVA: 0x0005D0CF File Offset: 0x0005B2CF
		<JsonProperty("base64")>
		Public Property base64 As String
	End Class
End Namespace
