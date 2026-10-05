Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000563 RID: 1379
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptPayment_WithdrawalReceipt
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006817 RID: 26647
		' (get) Token: 0x06010CDD RID: 68829 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010CDE RID: 68830 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006818 RID: 26648
		' (get) Token: 0x06010CDF RID: 68831 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010CE0 RID: 68832 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006819 RID: 26649
		' (get) Token: 0x06010CE1 RID: 68833 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010CE2 RID: 68834 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010CE3 RID: 68835 RVA: 0x009CB398 File Offset: 0x009C9598
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptPayment_WithdrawalReceipt() With { .Site = Me.Site }
		End Function

		' Token: 0x06010CE4 RID: 68836 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
