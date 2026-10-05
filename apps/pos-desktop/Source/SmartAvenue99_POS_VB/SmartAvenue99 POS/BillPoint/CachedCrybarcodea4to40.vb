Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200048E RID: 1166
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCrybarcodea4to40
		Inherits Component
		Implements ICachedReport

		' Token: 0x170059FD RID: 23037
		' (get) Token: 0x0600EA01 RID: 59905 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600EA02 RID: 59906 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059FE RID: 23038
		' (get) Token: 0x0600EA03 RID: 59907 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600EA04 RID: 59908 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059FF RID: 23039
		' (get) Token: 0x0600EA05 RID: 59909 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600EA06 RID: 59910 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600EA07 RID: 59911 RVA: 0x008D9560 File Offset: 0x008D7760
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New Crybarcodea4to40() With { .Site = Me.Site }
		End Function

		' Token: 0x0600EA08 RID: 59912 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
