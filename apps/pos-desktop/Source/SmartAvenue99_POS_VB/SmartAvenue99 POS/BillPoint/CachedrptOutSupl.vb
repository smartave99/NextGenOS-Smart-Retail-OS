Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200054D RID: 1357
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptOutSupl
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006689 RID: 26249
		' (get) Token: 0x0601090E RID: 67854 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601090F RID: 67855 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700668A RID: 26250
		' (get) Token: 0x06010910 RID: 67856 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010911 RID: 67857 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700668B RID: 26251
		' (get) Token: 0x06010912 RID: 67858 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010913 RID: 67859 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010914 RID: 67860 RVA: 0x009B063C File Offset: 0x009AE83C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptOutSupl() With { .Site = Me.Site }
		End Function

		' Token: 0x06010915 RID: 67861 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
