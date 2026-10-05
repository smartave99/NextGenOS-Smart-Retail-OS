Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200047A RID: 1146
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedBarcodeCustomise1
		Inherits Component
		Implements ICachedReport

		' Token: 0x17005985 RID: 22917
		' (get) Token: 0x0600E925 RID: 59685 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E926 RID: 59686 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17005986 RID: 22918
		' (get) Token: 0x0600E927 RID: 59687 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600E928 RID: 59688 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17005987 RID: 22919
		' (get) Token: 0x0600E929 RID: 59689 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600E92A RID: 59690 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600E92B RID: 59691 RVA: 0x008D91F0 File Offset: 0x008D73F0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New BarcodeCustomise1() With { .Site = Me.Site }
		End Function

		' Token: 0x0600E92C RID: 59692 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
