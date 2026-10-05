Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000551 RID: 1361
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptPurchaseC2
		Inherits Component
		Implements ICachedReport

		' Token: 0x170066A7 RID: 26279
		' (get) Token: 0x06010940 RID: 67904 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010941 RID: 67905 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170066A8 RID: 26280
		' (get) Token: 0x06010942 RID: 67906 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010943 RID: 67907 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170066A9 RID: 26281
		' (get) Token: 0x06010944 RID: 67908 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010945 RID: 67909 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010946 RID: 67910 RVA: 0x009B06EC File Offset: 0x009AE8EC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptPurchaseC2() With { .Site = Me.Site }
		End Function

		' Token: 0x06010947 RID: 67911 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
