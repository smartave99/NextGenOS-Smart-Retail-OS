Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200024F RID: 591
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA5POS9
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003EA6 RID: 16038
		' (get) Token: 0x0600A17A RID: 41338 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A17B RID: 41339 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003EA7 RID: 16039
		' (get) Token: 0x0600A17C RID: 41340 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A17D RID: 41341 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003EA8 RID: 16040
		' (get) Token: 0x0600A17E RID: 41342 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A17F RID: 41343 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A180 RID: 41344 RVA: 0x006F4B28 File Offset: 0x006F2D28
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A5POS9() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A181 RID: 41345 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
