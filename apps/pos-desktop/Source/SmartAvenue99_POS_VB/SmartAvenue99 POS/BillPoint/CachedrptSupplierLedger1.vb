Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002D2 RID: 722
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSupplierLedger1
		Inherits Component
		Implements ICachedReport

		' Token: 0x170045FA RID: 17914
		' (get) Token: 0x0600B40B RID: 46091 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B40C RID: 46092 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045FB RID: 17915
		' (get) Token: 0x0600B40D RID: 46093 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B40E RID: 46094 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045FC RID: 17916
		' (get) Token: 0x0600B40F RID: 46095 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B410 RID: 46096 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B411 RID: 46097 RVA: 0x007710F8 File Offset: 0x0076F2F8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSupplierLedger1() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B412 RID: 46098 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
