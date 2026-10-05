Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002F4 RID: 756
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedThermal4InchSaleCustomise
		Inherits Component
		Implements ICachedReport

		' Token: 0x170048E4 RID: 18660
		' (get) Token: 0x0600B79F RID: 47007 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B7A0 RID: 47008 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170048E5 RID: 18661
		' (get) Token: 0x0600B7A1 RID: 47009 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B7A2 RID: 47010 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170048E6 RID: 18662
		' (get) Token: 0x0600B7A3 RID: 47011 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B7A4 RID: 47012 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B7A5 RID: 47013 RVA: 0x00771718 File Offset: 0x0076F918
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New Thermal4InchSaleCustomise() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B7A6 RID: 47014 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
