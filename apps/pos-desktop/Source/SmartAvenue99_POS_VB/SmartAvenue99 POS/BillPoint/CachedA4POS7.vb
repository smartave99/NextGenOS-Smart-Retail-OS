Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200022D RID: 557
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4POS7
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003AF1 RID: 15089
		' (get) Token: 0x06009C42 RID: 40002 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009C43 RID: 40003 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003AF2 RID: 15090
		' (get) Token: 0x06009C44 RID: 40004 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06009C45 RID: 40005 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003AF3 RID: 15091
		' (get) Token: 0x06009C46 RID: 40006 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06009C47 RID: 40007 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06009C48 RID: 40008 RVA: 0x006E8E28 File Offset: 0x006E7028
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4POS7() With { .Site = Me.Site }
		End Function

		' Token: 0x06009C49 RID: 40009 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
