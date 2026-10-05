Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002C2 RID: 706
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptP_Transfer
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004563 RID: 17763
		' (get) Token: 0x0600B324 RID: 45860 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B325 RID: 45861 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004564 RID: 17764
		' (get) Token: 0x0600B326 RID: 45862 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B327 RID: 45863 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004565 RID: 17765
		' (get) Token: 0x0600B328 RID: 45864 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B329 RID: 45865 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B32A RID: 45866 RVA: 0x00770E38 File Offset: 0x0076F038
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptP_Transfer() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B32B RID: 45867 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
