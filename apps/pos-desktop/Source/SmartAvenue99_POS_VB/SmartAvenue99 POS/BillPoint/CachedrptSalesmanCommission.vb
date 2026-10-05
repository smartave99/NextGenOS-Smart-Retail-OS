Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005AC RID: 1452
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSalesmanCommission
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006E3F RID: 28223
		' (get) Token: 0x06011BFE RID: 72702 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011BFF RID: 72703 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E40 RID: 28224
		' (get) Token: 0x06011C00 RID: 72704 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011C01 RID: 72705 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E41 RID: 28225
		' (get) Token: 0x06011C02 RID: 72706 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011C03 RID: 72707 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011C04 RID: 72708 RVA: 0x00A402FC File Offset: 0x00A3E4FC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSalesmanCommission() With { .Site = Me.Site }
		End Function

		' Token: 0x06011C05 RID: 72709 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
