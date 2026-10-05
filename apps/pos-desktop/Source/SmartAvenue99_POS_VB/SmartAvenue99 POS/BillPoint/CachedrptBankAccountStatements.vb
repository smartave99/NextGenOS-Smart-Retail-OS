Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200055B RID: 1371
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBankAccountStatements
		Inherits Component
		Implements ICachedReport

		' Token: 0x170067DD RID: 26589
		' (get) Token: 0x06010C7B RID: 68731 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010C7C RID: 68732 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170067DE RID: 26590
		' (get) Token: 0x06010C7D RID: 68733 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010C7E RID: 68734 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170067DF RID: 26591
		' (get) Token: 0x06010C7F RID: 68735 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010C80 RID: 68736 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010C81 RID: 68737 RVA: 0x009CB238 File Offset: 0x009C9438
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBankAccountStatements() With { .Site = Me.Site }
		End Function

		' Token: 0x06010C82 RID: 68738 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
