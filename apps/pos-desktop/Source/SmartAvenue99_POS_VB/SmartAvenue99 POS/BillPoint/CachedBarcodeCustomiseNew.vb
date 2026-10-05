Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200030A RID: 778
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedBarcodeCustomiseNew
		Inherits Component
		Implements ICachedReport

		' Token: 0x170049BB RID: 18875
		' (get) Token: 0x0600B8E4 RID: 47332 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B8E5 RID: 47333 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049BC RID: 18876
		' (get) Token: 0x0600B8E6 RID: 47334 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B8E7 RID: 47335 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049BD RID: 18877
		' (get) Token: 0x0600B8E8 RID: 47336 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B8E9 RID: 47337 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B8EA RID: 47338 RVA: 0x00771AE0 File Offset: 0x0076FCE0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New BarcodeCustomiseNew() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B8EB RID: 47339 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
