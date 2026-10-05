Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002DA RID: 730
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedT3InchPOS10
		Inherits Component
		Implements ICachedReport

		' Token: 0x170046AD RID: 18093
		' (get) Token: 0x0600B4E6 RID: 46310 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B4E7 RID: 46311 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170046AE RID: 18094
		' (get) Token: 0x0600B4E8 RID: 46312 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B4E9 RID: 46313 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170046AF RID: 18095
		' (get) Token: 0x0600B4EA RID: 46314 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B4EB RID: 46315 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B4EC RID: 46316 RVA: 0x00771258 File Offset: 0x0076F458
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New T3InchPOS10() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B4ED RID: 46317 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
