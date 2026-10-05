Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000527 RID: 1319
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSalesInvoiceA5New1Economical_Desc
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006537 RID: 25911
		' (get) Token: 0x060106FE RID: 67326 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060106FF RID: 67327 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006538 RID: 25912
		' (get) Token: 0x06010700 RID: 67328 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010701 RID: 67329 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006539 RID: 25913
		' (get) Token: 0x06010702 RID: 67330 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010703 RID: 67331 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010704 RID: 67332 RVA: 0x009AFFB4 File Offset: 0x009AE1B4
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSalesInvoiceA5New1Economical_Desc() With { .Site = Me.Site }
		End Function

		' Token: 0x06010705 RID: 67333 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
