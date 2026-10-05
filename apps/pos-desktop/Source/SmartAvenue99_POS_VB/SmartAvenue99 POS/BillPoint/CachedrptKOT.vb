Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002BE RID: 702
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptKOT
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004544 RID: 17732
		' (get) Token: 0x0600B2F1 RID: 45809 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B2F2 RID: 45810 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004545 RID: 17733
		' (get) Token: 0x0600B2F3 RID: 45811 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B2F4 RID: 45812 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004546 RID: 17734
		' (get) Token: 0x0600B2F5 RID: 45813 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B2F6 RID: 45814 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B2F7 RID: 45815 RVA: 0x00770D88 File Offset: 0x0076EF88
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptKOT() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B2F8 RID: 45816 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
