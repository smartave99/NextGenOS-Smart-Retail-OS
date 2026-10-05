Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005F2 RID: 1522
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptStockIn
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700739D RID: 29597
		' (get) Token: 0x06012A62 RID: 76386 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A63 RID: 76387 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700739E RID: 29598
		' (get) Token: 0x06012A64 RID: 76388 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06012A65 RID: 76389 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700739F RID: 29599
		' (get) Token: 0x06012A66 RID: 76390 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06012A67 RID: 76391 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06012A68 RID: 76392 RVA: 0x00AB9668 File Offset: 0x00AB7868
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptStockIn() With { .Site = Me.Site }
		End Function

		' Token: 0x06012A69 RID: 76393 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
