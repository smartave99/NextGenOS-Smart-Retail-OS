Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000505 RID: 1285
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptDeduction
		Inherits Component
		Implements ICachedReport

		' Token: 0x170063F1 RID: 25585
		' (get) Token: 0x0601050E RID: 66830 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601050F RID: 66831 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063F2 RID: 25586
		' (get) Token: 0x06010510 RID: 66832 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010511 RID: 66833 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063F3 RID: 25587
		' (get) Token: 0x06010512 RID: 66834 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010513 RID: 66835 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010514 RID: 66836 RVA: 0x009AF9DC File Offset: 0x009ADBDC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptDeduction() With { .Site = Me.Site }
		End Function

		' Token: 0x06010515 RID: 66837 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
