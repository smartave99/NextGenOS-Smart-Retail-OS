Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200028C RID: 652
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCryToken1
		Inherits Component
		Implements ICachedReport

		' Token: 0x170040CB RID: 16587
		' (get) Token: 0x0600A6F7 RID: 42743 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A6F8 RID: 42744 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040CC RID: 16588
		' (get) Token: 0x0600A6F9 RID: 42745 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A6FA RID: 42746 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040CD RID: 16589
		' (get) Token: 0x0600A6FB RID: 42747 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A6FC RID: 42748 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A6FD RID: 42749 RVA: 0x00700E30 File Offset: 0x006FF030
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New CryToken1() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A6FE RID: 42750 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
