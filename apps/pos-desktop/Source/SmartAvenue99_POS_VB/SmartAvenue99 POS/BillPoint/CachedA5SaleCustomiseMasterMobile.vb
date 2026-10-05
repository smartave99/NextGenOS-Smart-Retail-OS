Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002F8 RID: 760
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA5SaleCustomiseMasterMobile
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004914 RID: 18708
		' (get) Token: 0x0600B7E3 RID: 47075 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B7E4 RID: 47076 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004915 RID: 18709
		' (get) Token: 0x0600B7E5 RID: 47077 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B7E6 RID: 47078 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004916 RID: 18710
		' (get) Token: 0x0600B7E7 RID: 47079 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B7E8 RID: 47080 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B7E9 RID: 47081 RVA: 0x007717C8 File Offset: 0x0076F9C8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A5SaleCustomiseMasterMobile() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B7EA RID: 47082 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
