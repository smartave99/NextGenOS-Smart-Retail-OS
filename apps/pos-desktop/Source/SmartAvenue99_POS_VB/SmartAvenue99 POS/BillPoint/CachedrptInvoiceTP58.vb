Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000547 RID: 1351
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptInvoiceTP58
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006650 RID: 26192
		' (get) Token: 0x060108B7 RID: 67767 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060108B8 RID: 67768 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006651 RID: 26193
		' (get) Token: 0x060108B9 RID: 67769 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060108BA RID: 67770 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006652 RID: 26194
		' (get) Token: 0x060108BB RID: 67771 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060108BC RID: 67772 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060108BD RID: 67773 RVA: 0x009B0534 File Offset: 0x009AE734
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptInvoiceTP58() With { .Site = Me.Site }
		End Function

		' Token: 0x060108BE RID: 67774 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
