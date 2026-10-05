Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002C4 RID: 708
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptQuotation
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004572 RID: 17778
		' (get) Token: 0x0600B33D RID: 45885 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B33E RID: 45886 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004573 RID: 17779
		' (get) Token: 0x0600B33F RID: 45887 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B340 RID: 45888 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004574 RID: 17780
		' (get) Token: 0x0600B341 RID: 45889 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B342 RID: 45890 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B343 RID: 45891 RVA: 0x00770E90 File Offset: 0x0076F090
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptQuotation() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B344 RID: 45892 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
