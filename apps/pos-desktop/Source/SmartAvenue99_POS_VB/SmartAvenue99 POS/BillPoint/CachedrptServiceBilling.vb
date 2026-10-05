Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005EE RID: 1518
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptServiceBilling
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700737F RID: 29567
		' (get) Token: 0x06012A30 RID: 76336 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A31 RID: 76337 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007380 RID: 29568
		' (get) Token: 0x06012A32 RID: 76338 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06012A33 RID: 76339 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007381 RID: 29569
		' (get) Token: 0x06012A34 RID: 76340 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06012A35 RID: 76341 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06012A36 RID: 76342 RVA: 0x00AB95B8 File Offset: 0x00AB77B8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptServiceBilling() With { .Site = Me.Site }
		End Function

		' Token: 0x06012A37 RID: 76343 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
