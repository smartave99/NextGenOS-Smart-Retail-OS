Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002D4 RID: 724
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSupplierLedger
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700460E RID: 17934
		' (get) Token: 0x0600B429 RID: 46121 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B42A RID: 46122 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700460F RID: 17935
		' (get) Token: 0x0600B42B RID: 46123 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B42C RID: 46124 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004610 RID: 17936
		' (get) Token: 0x0600B42D RID: 46125 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B42E RID: 46126 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B42F RID: 46127 RVA: 0x00771150 File Offset: 0x0076F350
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSupplierLedger() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B430 RID: 46128 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
