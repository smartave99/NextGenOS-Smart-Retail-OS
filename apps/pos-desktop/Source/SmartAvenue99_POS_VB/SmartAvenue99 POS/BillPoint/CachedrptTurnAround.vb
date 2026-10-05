Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005F8 RID: 1528
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptTurnAround
		Inherits Component
		Implements ICachedReport

		' Token: 0x170073C1 RID: 29633
		' (get) Token: 0x06012AA4 RID: 76452 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012AA5 RID: 76453 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073C2 RID: 29634
		' (get) Token: 0x06012AA6 RID: 76454 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06012AA7 RID: 76455 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073C3 RID: 29635
		' (get) Token: 0x06012AA8 RID: 76456 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06012AA9 RID: 76457 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06012AAA RID: 76458 RVA: 0x00AB9770 File Offset: 0x00AB7970
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptTurnAround() With { .Site = Me.Site }
		End Function

		' Token: 0x06012AAB RID: 76459 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
