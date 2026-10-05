Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200028A RID: 650
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCrystalReport1
		Inherits Component
		Implements ICachedReport

		' Token: 0x170040BB RID: 16571
		' (get) Token: 0x0600A6DD RID: 42717 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A6DE RID: 42718 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040BC RID: 16572
		' (get) Token: 0x0600A6DF RID: 42719 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A6E0 RID: 42720 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040BD RID: 16573
		' (get) Token: 0x0600A6E1 RID: 42721 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A6E2 RID: 42722 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A6E3 RID: 42723 RVA: 0x00700DD8 File Offset: 0x006FEFD8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New CrystalReport1() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A6E4 RID: 42724 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
