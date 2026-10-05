Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005F0 RID: 1520
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptServiceReceipt
		Inherits Component
		Implements ICachedReport

		' Token: 0x17007391 RID: 29585
		' (get) Token: 0x06012A4C RID: 76364 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A4D RID: 76365 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007392 RID: 29586
		' (get) Token: 0x06012A4E RID: 76366 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06012A4F RID: 76367 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007393 RID: 29587
		' (get) Token: 0x06012A50 RID: 76368 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06012A51 RID: 76369 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06012A52 RID: 76370 RVA: 0x00AB9610 File Offset: 0x00AB7810
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptServiceReceipt() With { .Site = Me.Site }
		End Function

		' Token: 0x06012A53 RID: 76371 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
