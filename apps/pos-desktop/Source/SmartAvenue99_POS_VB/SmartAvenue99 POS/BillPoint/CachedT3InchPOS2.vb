Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002DC RID: 732
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedT3InchPOS2
		Inherits Component
		Implements ICachedReport

		' Token: 0x170046E2 RID: 18146
		' (get) Token: 0x0600B525 RID: 46373 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B526 RID: 46374 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170046E3 RID: 18147
		' (get) Token: 0x0600B527 RID: 46375 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B528 RID: 46376 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170046E4 RID: 18148
		' (get) Token: 0x0600B529 RID: 46377 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B52A RID: 46378 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B52B RID: 46379 RVA: 0x007712B0 File Offset: 0x0076F4B0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New T3InchPOS2() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B52C RID: 46380 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
