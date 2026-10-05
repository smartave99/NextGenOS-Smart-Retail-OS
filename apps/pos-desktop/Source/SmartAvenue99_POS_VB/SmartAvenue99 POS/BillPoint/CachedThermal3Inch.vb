Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002F0 RID: 752
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedThermal3Inch
		Inherits Component
		Implements ICachedReport

		' Token: 0x170048B9 RID: 18617
		' (get) Token: 0x0600B760 RID: 46944 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B761 RID: 46945 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170048BA RID: 18618
		' (get) Token: 0x0600B762 RID: 46946 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B763 RID: 46947 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170048BB RID: 18619
		' (get) Token: 0x0600B764 RID: 46948 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B765 RID: 46949 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B766 RID: 46950 RVA: 0x00771620 File Offset: 0x0076F820
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New Thermal3Inch() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B767 RID: 46951 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
