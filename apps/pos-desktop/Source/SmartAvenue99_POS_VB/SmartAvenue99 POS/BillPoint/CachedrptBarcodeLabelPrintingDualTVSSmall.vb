Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200048A RID: 1162
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBarcodeLabelPrintingDualTVSSmall
		Inherits Component
		Implements ICachedReport

		' Token: 0x170059E5 RID: 23013
		' (get) Token: 0x0600E9D5 RID: 59861 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E9D6 RID: 59862 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059E6 RID: 23014
		' (get) Token: 0x0600E9D7 RID: 59863 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600E9D8 RID: 59864 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059E7 RID: 23015
		' (get) Token: 0x0600E9D9 RID: 59865 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600E9DA RID: 59866 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600E9DB RID: 59867 RVA: 0x008D94B0 File Offset: 0x008D76B0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBarcodeLabelPrintingDualTVSSmall() With { .Site = Me.Site }
		End Function

		' Token: 0x0600E9DC RID: 59868 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
