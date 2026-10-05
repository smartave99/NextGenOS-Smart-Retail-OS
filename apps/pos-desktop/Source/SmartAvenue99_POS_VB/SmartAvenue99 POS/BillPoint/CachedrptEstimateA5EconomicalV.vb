Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200050B RID: 1291
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptEstimateA5EconomicalV
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006425 RID: 25637
		' (get) Token: 0x06010560 RID: 66912 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010561 RID: 66913 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006426 RID: 25638
		' (get) Token: 0x06010562 RID: 66914 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010563 RID: 66915 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006427 RID: 25639
		' (get) Token: 0x06010564 RID: 66916 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010565 RID: 66917 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010566 RID: 66918 RVA: 0x009AFAE4 File Offset: 0x009ADCE4
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptEstimateA5EconomicalV() With { .Site = Me.Site }
		End Function

		' Token: 0x06010567 RID: 66919 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
