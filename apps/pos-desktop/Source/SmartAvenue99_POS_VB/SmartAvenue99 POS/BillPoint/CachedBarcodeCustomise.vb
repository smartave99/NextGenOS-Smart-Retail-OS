Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000306 RID: 774
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedBarcodeCustomise
		Inherits Component
		Implements ICachedReport

		' Token: 0x170049A3 RID: 18851
		' (get) Token: 0x0600B8B8 RID: 47288 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B8B9 RID: 47289 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049A4 RID: 18852
		' (get) Token: 0x0600B8BA RID: 47290 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B8BB RID: 47291 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049A5 RID: 18853
		' (get) Token: 0x0600B8BC RID: 47292 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B8BD RID: 47293 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B8BE RID: 47294 RVA: 0x00771A30 File Offset: 0x0076FC30
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New BarcodeCustomise() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B8BF RID: 47295 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
