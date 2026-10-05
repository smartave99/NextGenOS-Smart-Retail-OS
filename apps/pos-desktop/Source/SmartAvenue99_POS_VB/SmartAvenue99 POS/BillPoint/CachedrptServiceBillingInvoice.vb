Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005CB RID: 1483
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptServiceBillingInvoice
		Inherits Component
		Implements ICachedReport

		' Token: 0x17007018 RID: 28696
		' (get) Token: 0x060120C5 RID: 73925 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060120C6 RID: 73926 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007019 RID: 28697
		' (get) Token: 0x060120C7 RID: 73927 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060120C8 RID: 73928 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700701A RID: 28698
		' (get) Token: 0x060120C9 RID: 73929 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060120CA RID: 73930 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060120CB RID: 73931 RVA: 0x00A63D18 File Offset: 0x00A61F18
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptServiceBillingInvoice() With { .Site = Me.Site }
		End Function

		' Token: 0x060120CC RID: 73932 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
