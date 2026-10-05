Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002B8 RID: 696
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptCipherA4_4
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700450D RID: 17677
		' (get) Token: 0x0600B29C RID: 45724 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B29D RID: 45725 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700450E RID: 17678
		' (get) Token: 0x0600B29E RID: 45726 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B29F RID: 45727 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700450F RID: 17679
		' (get) Token: 0x0600B2A0 RID: 45728 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B2A1 RID: 45729 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B2A2 RID: 45730 RVA: 0x00770C5C File Offset: 0x0076EE5C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptCipherA4_4() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B2A3 RID: 45731 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
