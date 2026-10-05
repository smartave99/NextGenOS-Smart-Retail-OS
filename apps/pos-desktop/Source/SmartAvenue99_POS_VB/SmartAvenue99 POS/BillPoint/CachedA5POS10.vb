Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200023F RID: 575
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA5POS10
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003CFE RID: 15614
		' (get) Token: 0x06009F82 RID: 40834 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009F83 RID: 40835 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003CFF RID: 15615
		' (get) Token: 0x06009F84 RID: 40836 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06009F85 RID: 40837 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003D00 RID: 15616
		' (get) Token: 0x06009F86 RID: 40838 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06009F87 RID: 40839 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06009F88 RID: 40840 RVA: 0x006F4868 File Offset: 0x006F2A68
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A5POS10() With { .Site = Me.Site }
		End Function

		' Token: 0x06009F89 RID: 40841 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
