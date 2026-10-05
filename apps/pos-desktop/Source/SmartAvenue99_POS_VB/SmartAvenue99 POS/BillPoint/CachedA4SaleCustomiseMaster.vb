Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002FE RID: 766
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4SaleCustomiseMaster
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700494F RID: 18767
		' (get) Token: 0x0600B83C RID: 47164 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B83D RID: 47165 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004950 RID: 18768
		' (get) Token: 0x0600B83E RID: 47166 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B83F RID: 47167 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004951 RID: 18769
		' (get) Token: 0x0600B840 RID: 47168 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B841 RID: 47169 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B842 RID: 47170 RVA: 0x007718D0 File Offset: 0x0076FAD0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4SaleCustomiseMaster() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B843 RID: 47171 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
