Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000223 RID: 547
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4POS2
		Inherits Component
		Implements ICachedReport

		' Token: 0x170039E6 RID: 14822
		' (get) Token: 0x06009B05 RID: 39685 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009B06 RID: 39686 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170039E7 RID: 14823
		' (get) Token: 0x06009B07 RID: 39687 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06009B08 RID: 39688 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170039E8 RID: 14824
		' (get) Token: 0x06009B09 RID: 39689 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06009B0A RID: 39690 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06009B0B RID: 39691 RVA: 0x006E8C4C File Offset: 0x006E6E4C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4POS2() With { .Site = Me.Site }
		End Function

		' Token: 0x06009B0C RID: 39692 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
