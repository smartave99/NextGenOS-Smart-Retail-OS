Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002F6 RID: 758
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4SaleCustomise
		Inherits Component
		Implements ICachedReport

		' Token: 0x170048FC RID: 18684
		' (get) Token: 0x0600B7C1 RID: 47041 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B7C2 RID: 47042 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170048FD RID: 18685
		' (get) Token: 0x0600B7C3 RID: 47043 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B7C4 RID: 47044 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170048FE RID: 18686
		' (get) Token: 0x0600B7C5 RID: 47045 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B7C6 RID: 47046 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B7C7 RID: 47047 RVA: 0x00771770 File Offset: 0x0076F970
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4SaleCustomise() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B7C8 RID: 47048 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
