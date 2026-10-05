Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005EC RID: 1516
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSales
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700736F RID: 29551
		' (get) Token: 0x06012A16 RID: 76310 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A17 RID: 76311 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007370 RID: 29552
		' (get) Token: 0x06012A18 RID: 76312 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06012A19 RID: 76313 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007371 RID: 29553
		' (get) Token: 0x06012A1A RID: 76314 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06012A1B RID: 76315 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06012A1C RID: 76316 RVA: 0x00AB9560 File Offset: 0x00AB7760
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSales() With { .Site = Me.Site }
		End Function

		' Token: 0x06012A1D RID: 76317 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
