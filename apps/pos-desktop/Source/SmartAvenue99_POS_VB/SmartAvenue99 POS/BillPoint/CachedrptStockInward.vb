Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002D0 RID: 720
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptStockInward
		Inherits Component
		Implements ICachedReport

		' Token: 0x170045E6 RID: 17894
		' (get) Token: 0x0600B3ED RID: 46061 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B3EE RID: 46062 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045E7 RID: 17895
		' (get) Token: 0x0600B3EF RID: 46063 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B3F0 RID: 46064 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045E8 RID: 17896
		' (get) Token: 0x0600B3F1 RID: 46065 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B3F2 RID: 46066 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B3F3 RID: 46067 RVA: 0x007710A0 File Offset: 0x0076F2A0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptStockInward() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B3F4 RID: 46068 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
