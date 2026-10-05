Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000543 RID: 1347
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptGSTSale
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006631 RID: 26161
		' (get) Token: 0x06010884 RID: 67716 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010885 RID: 67717 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006632 RID: 26162
		' (get) Token: 0x06010886 RID: 67718 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010887 RID: 67719 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006633 RID: 26163
		' (get) Token: 0x06010888 RID: 67720 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010889 RID: 67721 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601088A RID: 67722 RVA: 0x009B0484 File Offset: 0x009AE684
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptGSTSale() With { .Site = Me.Site }
		End Function

		' Token: 0x0601088B RID: 67723 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
