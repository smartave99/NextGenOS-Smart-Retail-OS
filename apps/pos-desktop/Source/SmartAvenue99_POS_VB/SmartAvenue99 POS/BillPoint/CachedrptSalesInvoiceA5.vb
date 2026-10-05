Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200059F RID: 1439
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSalesInvoiceA5
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006D79 RID: 28025
		' (get) Token: 0x06011A19 RID: 72217 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011A1A RID: 72218 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006D7A RID: 28026
		' (get) Token: 0x06011A1B RID: 72219 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011A1C RID: 72220 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006D7B RID: 28027
		' (get) Token: 0x06011A1D RID: 72221 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011A1E RID: 72222 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011A1F RID: 72223 RVA: 0x00A34144 File Offset: 0x00A32344
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSalesInvoiceA5() With { .Site = Me.Site }
		End Function

		' Token: 0x06011A20 RID: 72224 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
