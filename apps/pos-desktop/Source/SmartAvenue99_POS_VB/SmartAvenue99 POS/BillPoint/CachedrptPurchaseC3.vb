Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000517 RID: 1303
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptPurchaseC3
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006497 RID: 25751
		' (get) Token: 0x0601060E RID: 67086 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601060F RID: 67087 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006498 RID: 25752
		' (get) Token: 0x06010610 RID: 67088 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010611 RID: 67089 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006499 RID: 25753
		' (get) Token: 0x06010612 RID: 67090 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010613 RID: 67091 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010614 RID: 67092 RVA: 0x009AFCF4 File Offset: 0x009ADEF4
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptPurchaseC3() With { .Site = Me.Site }
		End Function

		' Token: 0x06010615 RID: 67093 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
