Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200055F RID: 1375
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptFundDepositReceipt
		Inherits Component
		Implements ICachedReport

		' Token: 0x170067F6 RID: 26614
		' (get) Token: 0x06010CA8 RID: 68776 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010CA9 RID: 68777 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170067F7 RID: 26615
		' (get) Token: 0x06010CAA RID: 68778 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010CAB RID: 68779 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170067F8 RID: 26616
		' (get) Token: 0x06010CAC RID: 68780 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010CAD RID: 68781 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010CAE RID: 68782 RVA: 0x009CB2E8 File Offset: 0x009C94E8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptFundDepositReceipt() With { .Site = Me.Site }
		End Function

		' Token: 0x06010CAF RID: 68783 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
