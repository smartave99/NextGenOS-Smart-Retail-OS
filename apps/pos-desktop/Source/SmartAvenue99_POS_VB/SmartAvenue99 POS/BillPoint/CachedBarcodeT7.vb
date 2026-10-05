Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000482 RID: 1154
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedBarcodeT7
		Inherits Component
		Implements ICachedReport

		' Token: 0x170059B5 RID: 22965
		' (get) Token: 0x0600E97D RID: 59773 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E97E RID: 59774 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059B6 RID: 22966
		' (get) Token: 0x0600E97F RID: 59775 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600E980 RID: 59776 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059B7 RID: 22967
		' (get) Token: 0x0600E981 RID: 59777 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600E982 RID: 59778 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600E983 RID: 59779 RVA: 0x008D9350 File Offset: 0x008D7550
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New BarcodeT7() With { .Site = Me.Site }
		End Function

		' Token: 0x0600E984 RID: 59780 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
