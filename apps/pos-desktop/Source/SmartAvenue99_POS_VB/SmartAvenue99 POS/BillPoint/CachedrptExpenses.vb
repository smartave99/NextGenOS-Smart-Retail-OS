Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005C6 RID: 1478
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptExpenses
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006FBF RID: 28607
		' (get) Token: 0x06011FDD RID: 73693 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011FDE RID: 73694 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006FC0 RID: 28608
		' (get) Token: 0x06011FDF RID: 73695 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011FE0 RID: 73696 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006FC1 RID: 28609
		' (get) Token: 0x06011FE1 RID: 73697 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011FE2 RID: 73698 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011FE3 RID: 73699 RVA: 0x00A5CF08 File Offset: 0x00A5B108
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptExpenses() With { .Site = Me.Site }
		End Function

		' Token: 0x06011FE4 RID: 73700 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
