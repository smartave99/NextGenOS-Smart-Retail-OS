Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000541 RID: 1345
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptEstimateA5
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006624 RID: 26148
		' (get) Token: 0x0601086D RID: 67693 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601086E RID: 67694 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006625 RID: 26149
		' (get) Token: 0x0601086F RID: 67695 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010870 RID: 67696 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006626 RID: 26150
		' (get) Token: 0x06010871 RID: 67697 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010872 RID: 67698 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010873 RID: 67699 RVA: 0x009B042C File Offset: 0x009AE62C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptEstimateA5() With { .Site = Me.Site }
		End Function

		' Token: 0x06010874 RID: 67700 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
