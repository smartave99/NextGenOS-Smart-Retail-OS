Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000511 RID: 1297
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptEstimateA5A
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700645D RID: 25693
		' (get) Token: 0x060105B6 RID: 66998 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060105B7 RID: 66999 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700645E RID: 25694
		' (get) Token: 0x060105B8 RID: 67000 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060105B9 RID: 67001 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700645F RID: 25695
		' (get) Token: 0x060105BA RID: 67002 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060105BB RID: 67003 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060105BC RID: 67004 RVA: 0x009AFBEC File Offset: 0x009ADDEC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptEstimateA5A() With { .Site = Me.Site }
		End Function

		' Token: 0x060105BD RID: 67005 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
