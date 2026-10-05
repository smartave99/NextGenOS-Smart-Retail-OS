Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000239 RID: 569
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4PurchaseInv
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003C1E RID: 15390
		' (get) Token: 0x06009DAB RID: 40363 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009DAC RID: 40364 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003C1F RID: 15391
		' (get) Token: 0x06009DAD RID: 40365 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06009DAE RID: 40366 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003C20 RID: 15392
		' (get) Token: 0x06009DAF RID: 40367 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06009DB0 RID: 40368 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06009DB1 RID: 40369 RVA: 0x006E90C8 File Offset: 0x006E72C8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4PurchaseInv() With { .Site = Me.Site }
		End Function

		' Token: 0x06009DB2 RID: 40370 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
