Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002EA RID: 746
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedT3InchPOS9
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004855 RID: 18517
		' (get) Token: 0x0600B6DE RID: 46814 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B6DF RID: 46815 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004856 RID: 18518
		' (get) Token: 0x0600B6E0 RID: 46816 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B6E1 RID: 46817 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004857 RID: 18519
		' (get) Token: 0x0600B6E2 RID: 46818 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B6E3 RID: 46819 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B6E4 RID: 46820 RVA: 0x00771518 File Offset: 0x0076F718
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New T3InchPOS9() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B6E5 RID: 46821 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
