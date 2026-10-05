Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000251 RID: 593
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedBarcodeCustomiseX
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003EB2 RID: 16050
		' (get) Token: 0x0600A190 RID: 41360 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A191 RID: 41361 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003EB3 RID: 16051
		' (get) Token: 0x0600A192 RID: 41362 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A193 RID: 41363 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003EB4 RID: 16052
		' (get) Token: 0x0600A194 RID: 41364 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A195 RID: 41365 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A196 RID: 41366 RVA: 0x006F4B80 File Offset: 0x006F2D80
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New BarcodeCustomiseX() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A197 RID: 41367 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
