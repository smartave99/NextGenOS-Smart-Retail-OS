Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200054B RID: 1355
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptInvoiceTP_Express4Inch
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700667B RID: 26235
		' (get) Token: 0x060108F6 RID: 67830 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060108F7 RID: 67831 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700667C RID: 26236
		' (get) Token: 0x060108F8 RID: 67832 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060108F9 RID: 67833 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700667D RID: 26237
		' (get) Token: 0x060108FA RID: 67834 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060108FB RID: 67835 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060108FC RID: 67836 RVA: 0x009B05E4 File Offset: 0x009AE7E4
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptInvoiceTP_Express4Inch() With { .Site = Me.Site }
		End Function

		' Token: 0x060108FD RID: 67837 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
