Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000308 RID: 776
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedBarcode128
		Inherits Component
		Implements ICachedReport

		' Token: 0x170049AF RID: 18863
		' (get) Token: 0x0600B8CE RID: 47310 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B8CF RID: 47311 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049B0 RID: 18864
		' (get) Token: 0x0600B8D0 RID: 47312 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B8D1 RID: 47313 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049B1 RID: 18865
		' (get) Token: 0x0600B8D2 RID: 47314 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B8D3 RID: 47315 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B8D4 RID: 47316 RVA: 0x00771A88 File Offset: 0x0076FC88
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New Barcode128() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B8D5 RID: 47317 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
