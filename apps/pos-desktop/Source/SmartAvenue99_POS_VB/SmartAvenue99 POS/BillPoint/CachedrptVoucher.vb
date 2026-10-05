Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005FA RID: 1530
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptVoucher
		Inherits Component
		Implements ICachedReport

		' Token: 0x170073CE RID: 29646
		' (get) Token: 0x06012ABB RID: 76475 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012ABC RID: 76476 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073CF RID: 29647
		' (get) Token: 0x06012ABD RID: 76477 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06012ABE RID: 76478 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073D0 RID: 29648
		' (get) Token: 0x06012ABF RID: 76479 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06012AC0 RID: 76480 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06012AC1 RID: 76481 RVA: 0x00AB97C8 File Offset: 0x00AB79C8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptVoucher() With { .Site = Me.Site }
		End Function

		' Token: 0x06012AC2 RID: 76482 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
