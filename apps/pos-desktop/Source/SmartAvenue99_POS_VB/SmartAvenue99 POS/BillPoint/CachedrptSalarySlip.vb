Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000519 RID: 1305
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSalarySlip
		Inherits Component
		Implements ICachedReport

		' Token: 0x170064A3 RID: 25763
		' (get) Token: 0x06010624 RID: 67108 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010625 RID: 67109 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170064A4 RID: 25764
		' (get) Token: 0x06010626 RID: 67110 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010627 RID: 67111 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170064A5 RID: 25765
		' (get) Token: 0x06010628 RID: 67112 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010629 RID: 67113 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601062A RID: 67114 RVA: 0x009AFD4C File Offset: 0x009ADF4C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSalarySlip() With { .Site = Me.Site }
		End Function

		' Token: 0x0601062B RID: 67115 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
