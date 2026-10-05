Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200047C RID: 1148
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBarcode2x1New
		Inherits Component
		Implements ICachedReport

		' Token: 0x17005991 RID: 22929
		' (get) Token: 0x0600E93B RID: 59707 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E93C RID: 59708 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17005992 RID: 22930
		' (get) Token: 0x0600E93D RID: 59709 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600E93E RID: 59710 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17005993 RID: 22931
		' (get) Token: 0x0600E93F RID: 59711 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600E940 RID: 59712 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600E941 RID: 59713 RVA: 0x008D9248 File Offset: 0x008D7448
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBarcode2x1New() With { .Site = Me.Site }
		End Function

		' Token: 0x0600E942 RID: 59714 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
