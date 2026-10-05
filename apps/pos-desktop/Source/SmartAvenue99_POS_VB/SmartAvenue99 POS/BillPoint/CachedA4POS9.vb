Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000231 RID: 561
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4POS9
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003B5B RID: 15195
		' (get) Token: 0x06009CC0 RID: 40128 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009CC1 RID: 40129 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003B5C RID: 15196
		' (get) Token: 0x06009CC2 RID: 40130 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06009CC3 RID: 40131 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003B5D RID: 15197
		' (get) Token: 0x06009CC4 RID: 40132 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06009CC5 RID: 40133 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06009CC6 RID: 40134 RVA: 0x006E8ED8 File Offset: 0x006E70D8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4POS9() With { .Site = Me.Site }
		End Function

		' Token: 0x06009CC7 RID: 40135 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
