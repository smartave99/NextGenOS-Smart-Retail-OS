Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002E8 RID: 744
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedT3InchPOS8
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004820 RID: 18464
		' (get) Token: 0x0600B69F RID: 46751 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B6A0 RID: 46752 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004821 RID: 18465
		' (get) Token: 0x0600B6A1 RID: 46753 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B6A2 RID: 46754 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004822 RID: 18466
		' (get) Token: 0x0600B6A3 RID: 46755 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B6A4 RID: 46756 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B6A5 RID: 46757 RVA: 0x007714C0 File Offset: 0x0076F6C0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New T3InchPOS8() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B6A6 RID: 46758 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
