Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000537 RID: 1335
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSupplierEnvolve
		Inherits Component
		Implements ICachedReport

		' Token: 0x170065DF RID: 26079
		' (get) Token: 0x060107F6 RID: 67574 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060107F7 RID: 67575 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065E0 RID: 26080
		' (get) Token: 0x060107F8 RID: 67576 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060107F9 RID: 67577 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065E1 RID: 26081
		' (get) Token: 0x060107FA RID: 67578 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060107FB RID: 67579 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060107FC RID: 67580 RVA: 0x009B0274 File Offset: 0x009AE474
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSupplierEnvolve() With { .Site = Me.Site }
		End Function

		' Token: 0x060107FD RID: 67581 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
