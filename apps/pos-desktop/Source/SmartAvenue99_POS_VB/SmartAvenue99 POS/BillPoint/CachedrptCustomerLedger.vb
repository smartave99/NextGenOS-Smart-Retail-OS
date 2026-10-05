Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002BA RID: 698
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptCustomerLedger
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004521 RID: 17697
		' (get) Token: 0x0600B2BA RID: 45754 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B2BB RID: 45755 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004522 RID: 17698
		' (get) Token: 0x0600B2BC RID: 45756 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B2BD RID: 45757 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004523 RID: 17699
		' (get) Token: 0x0600B2BE RID: 45758 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B2BF RID: 45759 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B2C0 RID: 45760 RVA: 0x00770CB4 File Offset: 0x0076EEB4
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptCustomerLedger() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B2C1 RID: 45761 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
