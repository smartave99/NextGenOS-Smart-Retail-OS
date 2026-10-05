Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000549 RID: 1353
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptInvoiceTP_Express3Inch
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006665 RID: 26213
		' (get) Token: 0x060108D6 RID: 67798 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060108D7 RID: 67799 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006666 RID: 26214
		' (get) Token: 0x060108D8 RID: 67800 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060108D9 RID: 67801 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006667 RID: 26215
		' (get) Token: 0x060108DA RID: 67802 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060108DB RID: 67803 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060108DC RID: 67804 RVA: 0x009B058C File Offset: 0x009AE78C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptInvoiceTP_Express3Inch() With { .Site = Me.Site }
		End Function

		' Token: 0x060108DD RID: 67805 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
