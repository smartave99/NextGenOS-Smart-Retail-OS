Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000284 RID: 644
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCBarcode
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004091 RID: 16529
		' (get) Token: 0x0600A695 RID: 42645 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A696 RID: 42646 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004092 RID: 16530
		' (get) Token: 0x0600A697 RID: 42647 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A698 RID: 42648 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004093 RID: 16531
		' (get) Token: 0x0600A699 RID: 42649 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A69A RID: 42650 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A69B RID: 42651 RVA: 0x00700CD0 File Offset: 0x006FEED0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New CBarcode() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A69C RID: 42652 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
