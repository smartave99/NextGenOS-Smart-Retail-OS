Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002C8 RID: 712
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSaleDayBook
		Inherits Component
		Implements ICachedReport

		' Token: 0x170045A2 RID: 17826
		' (get) Token: 0x0600B381 RID: 45953 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B382 RID: 45954 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045A3 RID: 17827
		' (get) Token: 0x0600B383 RID: 45955 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B384 RID: 45956 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045A4 RID: 17828
		' (get) Token: 0x0600B385 RID: 45957 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B386 RID: 45958 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B387 RID: 45959 RVA: 0x00770F40 File Offset: 0x0076F140
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSaleDayBook() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B388 RID: 45960 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
