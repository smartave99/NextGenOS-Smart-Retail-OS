Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000302 RID: 770
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4SaleCustomiseMasterNonGST
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700497F RID: 18815
		' (get) Token: 0x0600B880 RID: 47232 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B881 RID: 47233 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004980 RID: 18816
		' (get) Token: 0x0600B882 RID: 47234 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B883 RID: 47235 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004981 RID: 18817
		' (get) Token: 0x0600B884 RID: 47236 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B885 RID: 47237 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B886 RID: 47238 RVA: 0x00771980 File Offset: 0x0076FB80
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4SaleCustomiseMasterNonGST() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B887 RID: 47239 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
