Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000245 RID: 581
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA5POS4
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003D9D RID: 15773
		' (get) Token: 0x0600A03F RID: 41023 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A040 RID: 41024 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003D9E RID: 15774
		' (get) Token: 0x0600A041 RID: 41025 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A042 RID: 41026 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003D9F RID: 15775
		' (get) Token: 0x0600A043 RID: 41027 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A044 RID: 41028 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A045 RID: 41029 RVA: 0x006F4970 File Offset: 0x006F2B70
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A5POS4() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A046 RID: 41030 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
