Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200021F RID: 543
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4POS1
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700397C RID: 14716
		' (get) Token: 0x06009A87 RID: 39559 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009A88 RID: 39560 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700397D RID: 14717
		' (get) Token: 0x06009A89 RID: 39561 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06009A8A RID: 39562 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700397E RID: 14718
		' (get) Token: 0x06009A8B RID: 39563 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06009A8C RID: 39564 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06009A8D RID: 39565 RVA: 0x006E8B84 File Offset: 0x006E6D84
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4POS1() With { .Site = Me.Site }
		End Function

		' Token: 0x06009A8E RID: 39566 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
