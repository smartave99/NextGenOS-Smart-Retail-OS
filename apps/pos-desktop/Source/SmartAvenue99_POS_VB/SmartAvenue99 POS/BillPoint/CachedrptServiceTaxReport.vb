Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005A5 RID: 1445
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptServiceTaxReport
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006DB3 RID: 28083
		' (get) Token: 0x06011A71 RID: 72305 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011A72 RID: 72306 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006DB4 RID: 28084
		' (get) Token: 0x06011A73 RID: 72307 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011A74 RID: 72308 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006DB5 RID: 28085
		' (get) Token: 0x06011A75 RID: 72309 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011A76 RID: 72310 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011A77 RID: 72311 RVA: 0x00A3424C File Offset: 0x00A3244C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptServiceTaxReport() With { .Site = Me.Site }
		End Function

		' Token: 0x06011A78 RID: 72312 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
