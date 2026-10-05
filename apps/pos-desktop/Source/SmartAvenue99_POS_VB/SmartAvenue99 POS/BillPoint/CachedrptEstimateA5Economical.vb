Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200050D RID: 1293
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptEstimateA5Economical
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006433 RID: 25651
		' (get) Token: 0x06010578 RID: 66936 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010579 RID: 66937 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006434 RID: 25652
		' (get) Token: 0x0601057A RID: 66938 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0601057B RID: 66939 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006435 RID: 25653
		' (get) Token: 0x0601057C RID: 66940 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0601057D RID: 66941 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601057E RID: 66942 RVA: 0x009AFB3C File Offset: 0x009ADD3C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptEstimateA5Economical() With { .Site = Me.Site }
		End Function

		' Token: 0x0601057F RID: 66943 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
