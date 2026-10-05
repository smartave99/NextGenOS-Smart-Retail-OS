Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000574 RID: 1396
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptCreditTermsStatements
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006955 RID: 26965
		' (get) Token: 0x06010F9A RID: 69530 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010F9B RID: 69531 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006956 RID: 26966
		' (get) Token: 0x06010F9C RID: 69532 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010F9D RID: 69533 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006957 RID: 26967
		' (get) Token: 0x06010F9E RID: 69534 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010F9F RID: 69535 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010FA0 RID: 69536 RVA: 0x009DBB6C File Offset: 0x009D9D6C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptCreditTermsStatements() With { .Site = Me.Site }
		End Function

		' Token: 0x06010FA1 RID: 69537 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
