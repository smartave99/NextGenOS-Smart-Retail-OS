Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200053B RID: 1339
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptCustomerPaid
		Inherits Component
		Implements ICachedReport

		' Token: 0x170065FA RID: 26106
		' (get) Token: 0x06010825 RID: 67621 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010826 RID: 67622 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065FB RID: 26107
		' (get) Token: 0x06010827 RID: 67623 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010828 RID: 67624 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065FC RID: 26108
		' (get) Token: 0x06010829 RID: 67625 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0601082A RID: 67626 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601082B RID: 67627 RVA: 0x009B0324 File Offset: 0x009AE524
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptCustomerPaid() With { .Site = Me.Site }
		End Function

		' Token: 0x0601082C RID: 67628 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
