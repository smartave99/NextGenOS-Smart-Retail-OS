Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020004FF RID: 1279
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBarcodeLabelPrintinga4
		Inherits Component
		Implements ICachedReport

		' Token: 0x170063CC RID: 25548
		' (get) Token: 0x060104CB RID: 66763 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060104CC RID: 66764 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063CD RID: 25549
		' (get) Token: 0x060104CD RID: 66765 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060104CE RID: 66766 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063CE RID: 25550
		' (get) Token: 0x060104CF RID: 66767 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060104D0 RID: 66768 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060104D1 RID: 66769 RVA: 0x009AF8D4 File Offset: 0x009ADAD4
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBarcodeLabelPrintinga4() With { .Site = Me.Site }
		End Function

		' Token: 0x060104D2 RID: 66770 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
