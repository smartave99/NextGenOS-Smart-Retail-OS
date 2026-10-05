Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002CC RID: 716
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptSalesManLedgerNew
		Inherits Component
		Implements ICachedReport

		' Token: 0x170045C6 RID: 17862
		' (get) Token: 0x0600B3B9 RID: 46009 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B3BA RID: 46010 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045C7 RID: 17863
		' (get) Token: 0x0600B3BB RID: 46011 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B3BC RID: 46012 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045C8 RID: 17864
		' (get) Token: 0x0600B3BD RID: 46013 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B3BE RID: 46014 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B3BF RID: 46015 RVA: 0x00770FF0 File Offset: 0x0076F1F0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptSalesManLedgerNew() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B3C0 RID: 46016 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
