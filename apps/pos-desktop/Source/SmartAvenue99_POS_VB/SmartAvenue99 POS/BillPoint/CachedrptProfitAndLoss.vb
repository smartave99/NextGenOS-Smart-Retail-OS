Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200054F RID: 1359
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptProfitAndLoss
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006699 RID: 26265
		' (get) Token: 0x06010928 RID: 67880 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010929 RID: 67881 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700669A RID: 26266
		' (get) Token: 0x0601092A RID: 67882 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0601092B RID: 67883 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700669B RID: 26267
		' (get) Token: 0x0601092C RID: 67884 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0601092D RID: 67885 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601092E RID: 67886 RVA: 0x009B0694 File Offset: 0x009AE894
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptProfitAndLoss() With { .Site = Me.Site }
		End Function

		' Token: 0x0601092F RID: 67887 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
