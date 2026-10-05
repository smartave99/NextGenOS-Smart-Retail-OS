Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005BC RID: 1468
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptGeneralLedger
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006F13 RID: 28435
		' (get) Token: 0x06011E1A RID: 73242 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011E1B RID: 73243 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006F14 RID: 28436
		' (get) Token: 0x06011E1C RID: 73244 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011E1D RID: 73245 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006F15 RID: 28437
		' (get) Token: 0x06011E1E RID: 73246 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011E1F RID: 73247 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011E20 RID: 73248 RVA: 0x00A4E7BC File Offset: 0x00A4C9BC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptGeneralLedger() With { .Site = Me.Site }
		End Function

		' Token: 0x06011E21 RID: 73249 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
