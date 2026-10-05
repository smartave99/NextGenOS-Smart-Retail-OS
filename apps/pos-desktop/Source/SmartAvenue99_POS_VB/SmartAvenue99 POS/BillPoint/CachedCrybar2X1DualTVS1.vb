Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200031A RID: 794
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCrybar2X1DualTVS1
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004B40 RID: 19264
		' (get) Token: 0x0600BCE8 RID: 48360 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BCE9 RID: 48361 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B41 RID: 19265
		' (get) Token: 0x0600BCEA RID: 48362 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600BCEB RID: 48363 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B42 RID: 19266
		' (get) Token: 0x0600BCEC RID: 48364 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600BCED RID: 48365 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600BCEE RID: 48366 RVA: 0x00790240 File Offset: 0x0078E440
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New Crybar2X1DualTVS1() With { .Site = Me.Site }
		End Function

		' Token: 0x0600BCEF RID: 48367 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
