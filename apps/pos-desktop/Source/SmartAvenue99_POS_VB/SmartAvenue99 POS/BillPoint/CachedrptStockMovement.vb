Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000535 RID: 1333
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptStockMovement
		Inherits Component
		Implements ICachedReport

		' Token: 0x170065D4 RID: 26068
		' (get) Token: 0x060107E1 RID: 67553 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060107E2 RID: 67554 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065D5 RID: 26069
		' (get) Token: 0x060107E3 RID: 67555 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060107E4 RID: 67556 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065D6 RID: 26070
		' (get) Token: 0x060107E5 RID: 67557 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060107E6 RID: 67558 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060107E7 RID: 67559 RVA: 0x009B021C File Offset: 0x009AE41C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptStockMovement() With { .Site = Me.Site }
		End Function

		' Token: 0x060107E8 RID: 67560 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
