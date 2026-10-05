Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000488 RID: 1160
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBarcodeLabelPrintingDualTVS
		Inherits Component
		Implements ICachedReport

		' Token: 0x170059D9 RID: 23001
		' (get) Token: 0x0600E9BF RID: 59839 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E9C0 RID: 59840 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059DA RID: 23002
		' (get) Token: 0x0600E9C1 RID: 59841 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600E9C2 RID: 59842 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059DB RID: 23003
		' (get) Token: 0x0600E9C3 RID: 59843 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600E9C4 RID: 59844 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600E9C5 RID: 59845 RVA: 0x008D9458 File Offset: 0x008D7658
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBarcodeLabelPrintingDualTVS() With { .Site = Me.Site }
		End Function

		' Token: 0x0600E9C6 RID: 59846 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
