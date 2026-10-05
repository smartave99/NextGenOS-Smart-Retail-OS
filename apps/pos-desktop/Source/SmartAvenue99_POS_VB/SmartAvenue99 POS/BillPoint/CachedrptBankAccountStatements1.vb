Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002B0 RID: 688
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBankAccountStatements1
		Inherits Component
		Implements ICachedReport

		' Token: 0x170044DD RID: 17629
		' (get) Token: 0x0600B244 RID: 45636 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B245 RID: 45637 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170044DE RID: 17630
		' (get) Token: 0x0600B246 RID: 45638 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B247 RID: 45639 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170044DF RID: 17631
		' (get) Token: 0x0600B248 RID: 45640 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B249 RID: 45641 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B24A RID: 45642 RVA: 0x00770AFC File Offset: 0x0076ECFC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBankAccountStatements1() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B24B RID: 45643 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
