Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002C0 RID: 704
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptLoyaltyCard
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004550 RID: 17744
		' (get) Token: 0x0600B307 RID: 45831 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B308 RID: 45832 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004551 RID: 17745
		' (get) Token: 0x0600B309 RID: 45833 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B30A RID: 45834 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004552 RID: 17746
		' (get) Token: 0x0600B30B RID: 45835 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B30C RID: 45836 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B30D RID: 45837 RVA: 0x00770DE0 File Offset: 0x0076EFE0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptLoyaltyCard() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B30E RID: 45838 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
