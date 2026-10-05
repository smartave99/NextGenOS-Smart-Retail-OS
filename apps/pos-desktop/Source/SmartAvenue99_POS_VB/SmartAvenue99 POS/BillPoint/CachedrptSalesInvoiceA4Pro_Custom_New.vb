Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000521 RID: 1313
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSalesInvoiceA4Pro_Custom_New
		Inherits Component
		Implements ICachedReport

		' Token: 0x170064F1 RID: 25841
		' (get) Token: 0x0601069A RID: 67226 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601069B RID: 67227 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170064F2 RID: 25842
		' (get) Token: 0x0601069C RID: 67228 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0601069D RID: 67229 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170064F3 RID: 25843
		' (get) Token: 0x0601069E RID: 67230 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0601069F RID: 67231 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060106A0 RID: 67232 RVA: 0x009AFEAC File Offset: 0x009AE0AC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSalesInvoiceA4Pro_Custom_New() With { .Site = Me.Site }
		End Function

		' Token: 0x060106A1 RID: 67233 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
