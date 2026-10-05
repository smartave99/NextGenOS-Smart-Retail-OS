Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000539 RID: 1337
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptCustomerEnvolve
		Inherits Component
		Implements ICachedReport

		' Token: 0x170065EA RID: 26090
		' (get) Token: 0x0601080B RID: 67595 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601080C RID: 67596 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065EB RID: 26091
		' (get) Token: 0x0601080D RID: 67597 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0601080E RID: 67598 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065EC RID: 26092
		' (get) Token: 0x0601080F RID: 67599 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010810 RID: 67600 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010811 RID: 67601 RVA: 0x009B02CC File Offset: 0x009AE4CC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptCustomerEnvolve() With { .Site = Me.Site }
		End Function

		' Token: 0x06010812 RID: 67602 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
