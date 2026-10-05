Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000509 RID: 1289
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptEmployeePayment1
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006411 RID: 25617
		' (get) Token: 0x06010542 RID: 66882 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010543 RID: 66883 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006412 RID: 25618
		' (get) Token: 0x06010544 RID: 66884 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010545 RID: 66885 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006413 RID: 25619
		' (get) Token: 0x06010546 RID: 66886 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010547 RID: 66887 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010548 RID: 66888 RVA: 0x009AFA8C File Offset: 0x009ADC8C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptEmployeePayment1() With { .Site = Me.Site }
		End Function

		' Token: 0x06010549 RID: 66889 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
