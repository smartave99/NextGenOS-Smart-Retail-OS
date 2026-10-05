Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000545 RID: 1349
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptIncome
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700663C RID: 26172
		' (get) Token: 0x06010899 RID: 67737 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601089A RID: 67738 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700663D RID: 26173
		' (get) Token: 0x0601089B RID: 67739 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0601089C RID: 67740 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700663E RID: 26174
		' (get) Token: 0x0601089D RID: 67741 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0601089E RID: 67742 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601089F RID: 67743 RVA: 0x009B04DC File Offset: 0x009AE6DC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptIncome() With { .Site = Me.Site }
		End Function

		' Token: 0x060108A0 RID: 67744 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
