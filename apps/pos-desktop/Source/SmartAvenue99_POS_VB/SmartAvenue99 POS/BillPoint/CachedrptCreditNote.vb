Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200057D RID: 1405
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptCreditNote
		Inherits Component
		Implements ICachedReport

		' Token: 0x170069CB RID: 27083
		' (get) Token: 0x060110DA RID: 69850 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060110DB RID: 69851 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170069CC RID: 27084
		' (get) Token: 0x060110DC RID: 69852 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060110DD RID: 69853 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170069CD RID: 27085
		' (get) Token: 0x060110DE RID: 69854 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060110DF RID: 69855 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060110E0 RID: 69856 RVA: 0x009E4058 File Offset: 0x009E2258
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptCreditNote() With { .Site = Me.Site }
		End Function

		' Token: 0x060110E1 RID: 69857 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
