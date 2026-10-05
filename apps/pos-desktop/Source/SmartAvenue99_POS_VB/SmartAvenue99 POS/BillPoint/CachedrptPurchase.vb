Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005BE RID: 1470
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptPurchase
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006F25 RID: 28453
		' (get) Token: 0x06011E36 RID: 73270 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011E37 RID: 73271 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006F26 RID: 28454
		' (get) Token: 0x06011E38 RID: 73272 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011E39 RID: 73273 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006F27 RID: 28455
		' (get) Token: 0x06011E3A RID: 73274 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011E3B RID: 73275 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011E3C RID: 73276 RVA: 0x00A4E814 File Offset: 0x00A4CA14
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptPurchase() With { .Site = Me.Site }
		End Function

		' Token: 0x06011E3D RID: 73277 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
