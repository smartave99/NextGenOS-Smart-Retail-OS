Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005B0 RID: 1456
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptGSTReport
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006E5B RID: 28251
		' (get) Token: 0x06011C2E RID: 72750 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011C2F RID: 72751 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E5C RID: 28252
		' (get) Token: 0x06011C30 RID: 72752 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011C31 RID: 72753 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E5D RID: 28253
		' (get) Token: 0x06011C32 RID: 72754 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011C33 RID: 72755 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011C34 RID: 72756 RVA: 0x00A403AC File Offset: 0x00A3E5AC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptGSTReport() With { .Site = Me.Site }
		End Function

		' Token: 0x06011C35 RID: 72757 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
