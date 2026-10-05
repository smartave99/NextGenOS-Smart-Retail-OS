Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000569 RID: 1385
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSales1
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006854 RID: 26708
		' (get) Token: 0x06010D38 RID: 68920 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010D39 RID: 68921 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006855 RID: 26709
		' (get) Token: 0x06010D3A RID: 68922 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010D3B RID: 68923 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006856 RID: 26710
		' (get) Token: 0x06010D3C RID: 68924 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010D3D RID: 68925 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010D3E RID: 68926 RVA: 0x009CB4A0 File Offset: 0x009C96A0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSales1() With { .Site = Me.Site }
		End Function

		' Token: 0x06010D3F RID: 68927 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
