Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005B8 RID: 1464
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptGeneralDayBook
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006EE5 RID: 28389
		' (get) Token: 0x06011DA3 RID: 73123 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011DA4 RID: 73124 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006EE6 RID: 28390
		' (get) Token: 0x06011DA5 RID: 73125 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011DA6 RID: 73126 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006EE7 RID: 28391
		' (get) Token: 0x06011DA7 RID: 73127 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011DA8 RID: 73128 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011DA9 RID: 73129 RVA: 0x00A4B93C File Offset: 0x00A49B3C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptGeneralDayBook() With { .Site = Me.Site }
		End Function

		' Token: 0x06011DAA RID: 73130 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
