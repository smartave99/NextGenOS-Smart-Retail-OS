Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005F4 RID: 1524
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptStockOut
		Inherits Component
		Implements ICachedReport

		' Token: 0x170073A9 RID: 29609
		' (get) Token: 0x06012A78 RID: 76408 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A79 RID: 76409 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073AA RID: 29610
		' (get) Token: 0x06012A7A RID: 76410 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06012A7B RID: 76411 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073AB RID: 29611
		' (get) Token: 0x06012A7C RID: 76412 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06012A7D RID: 76413 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06012A7E RID: 76414 RVA: 0x00AB96C0 File Offset: 0x00AB78C0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptStockOut() With { .Site = Me.Site }
		End Function

		' Token: 0x06012A7F RID: 76415 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
