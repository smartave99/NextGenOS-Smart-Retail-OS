Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200031C RID: 796
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedBarcodeT4
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004B4C RID: 19276
		' (get) Token: 0x0600BCFE RID: 48382 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BCFF RID: 48383 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B4D RID: 19277
		' (get) Token: 0x0600BD00 RID: 48384 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600BD01 RID: 48385 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B4E RID: 19278
		' (get) Token: 0x0600BD02 RID: 48386 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600BD03 RID: 48387 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600BD04 RID: 48388 RVA: 0x00790298 File Offset: 0x0078E498
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New BarcodeT4() With { .Site = Me.Site }
		End Function

		' Token: 0x0600BD05 RID: 48389 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
