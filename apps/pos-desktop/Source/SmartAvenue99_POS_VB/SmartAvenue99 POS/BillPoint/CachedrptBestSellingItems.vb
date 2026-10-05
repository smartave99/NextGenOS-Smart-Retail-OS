Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200057B RID: 1403
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBestSellingItems
		Inherits Component
		Implements ICachedReport

		' Token: 0x170069BA RID: 27066
		' (get) Token: 0x060110BF RID: 69823 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060110C0 RID: 69824 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170069BB RID: 27067
		' (get) Token: 0x060110C1 RID: 69825 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060110C2 RID: 69826 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170069BC RID: 27068
		' (get) Token: 0x060110C3 RID: 69827 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060110C4 RID: 69828 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060110C5 RID: 69829 RVA: 0x009E4000 File Offset: 0x009E2200
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBestSellingItems() With { .Site = Me.Site }
		End Function

		' Token: 0x060110C6 RID: 69830 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
