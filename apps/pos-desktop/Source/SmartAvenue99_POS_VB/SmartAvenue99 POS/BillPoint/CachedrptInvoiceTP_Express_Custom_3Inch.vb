Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000513 RID: 1299
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptInvoiceTP_Express_Custom_3Inch
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006472 RID: 25714
		' (get) Token: 0x060105D5 RID: 67029 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060105D6 RID: 67030 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006473 RID: 25715
		' (get) Token: 0x060105D7 RID: 67031 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060105D8 RID: 67032 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006474 RID: 25716
		' (get) Token: 0x060105D9 RID: 67033 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060105DA RID: 67034 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060105DB RID: 67035 RVA: 0x009AFC44 File Offset: 0x009ADE44
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptInvoiceTP_Express_Custom_3Inch() With { .Site = Me.Site }
		End Function

		' Token: 0x060105DC RID: 67036 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
