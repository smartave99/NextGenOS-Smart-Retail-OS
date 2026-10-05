Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000501 RID: 1281
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptCashBook
		Inherits Component
		Implements ICachedReport

		' Token: 0x170063D9 RID: 25561
		' (get) Token: 0x060104E2 RID: 66786 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060104E3 RID: 66787 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063DA RID: 25562
		' (get) Token: 0x060104E4 RID: 66788 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060104E5 RID: 66789 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063DB RID: 25563
		' (get) Token: 0x060104E6 RID: 66790 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060104E7 RID: 66791 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060104E8 RID: 66792 RVA: 0x009AF92C File Offset: 0x009ADB2C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptCashBook() With { .Site = Me.Site }
		End Function

		' Token: 0x060104E9 RID: 66793 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
