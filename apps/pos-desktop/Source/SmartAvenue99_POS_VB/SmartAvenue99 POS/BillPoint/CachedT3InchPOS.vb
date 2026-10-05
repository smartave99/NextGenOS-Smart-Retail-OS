Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002D6 RID: 726
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedT3InchPOS
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700463F RID: 17983
		' (get) Token: 0x0600B464 RID: 46180 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B465 RID: 46181 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004640 RID: 17984
		' (get) Token: 0x0600B466 RID: 46182 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B467 RID: 46183 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004641 RID: 17985
		' (get) Token: 0x0600B468 RID: 46184 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B469 RID: 46185 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B46A RID: 46186 RVA: 0x007711A8 File Offset: 0x0076F3A8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New T3InchPOS() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B46B RID: 46187 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
