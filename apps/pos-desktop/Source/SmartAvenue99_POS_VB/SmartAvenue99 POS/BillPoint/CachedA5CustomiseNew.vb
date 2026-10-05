Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002FA RID: 762
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA5CustomiseNew
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700491F RID: 18719
		' (get) Token: 0x0600B7F8 RID: 47096 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B7F9 RID: 47097 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004920 RID: 18720
		' (get) Token: 0x0600B7FA RID: 47098 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B7FB RID: 47099 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004921 RID: 18721
		' (get) Token: 0x0600B7FC RID: 47100 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B7FD RID: 47101 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B7FE RID: 47102 RVA: 0x00771820 File Offset: 0x0076FA20
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A5CustomiseNew() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B7FF RID: 47103 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
