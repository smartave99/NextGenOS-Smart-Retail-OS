Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005B2 RID: 1458
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptStockEntry
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006E66 RID: 28262
		' (get) Token: 0x06011C43 RID: 72771 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011C44 RID: 72772 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E67 RID: 28263
		' (get) Token: 0x06011C45 RID: 72773 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011C46 RID: 72774 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E68 RID: 28264
		' (get) Token: 0x06011C47 RID: 72775 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011C48 RID: 72776 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011C49 RID: 72777 RVA: 0x00A40404 File Offset: 0x00A3E604
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptStockEntry() With { .Site = Me.Site }
		End Function

		' Token: 0x06011C4A RID: 72778 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
