Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000241 RID: 577
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA5POS2
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003D33 RID: 15667
		' (get) Token: 0x06009FC1 RID: 40897 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009FC2 RID: 40898 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003D34 RID: 15668
		' (get) Token: 0x06009FC3 RID: 40899 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06009FC4 RID: 40900 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003D35 RID: 15669
		' (get) Token: 0x06009FC5 RID: 40901 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06009FC6 RID: 40902 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06009FC7 RID: 40903 RVA: 0x006F48C0 File Offset: 0x006F2AC0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A5POS2() With { .Site = Me.Site }
		End Function

		' Token: 0x06009FC8 RID: 40904 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
