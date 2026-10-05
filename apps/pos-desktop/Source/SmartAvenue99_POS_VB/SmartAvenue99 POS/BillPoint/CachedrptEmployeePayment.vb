Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000507 RID: 1287
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptEmployeePayment
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006402 RID: 25602
		' (get) Token: 0x06010529 RID: 66857 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601052A RID: 66858 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006403 RID: 25603
		' (get) Token: 0x0601052B RID: 66859 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0601052C RID: 66860 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006404 RID: 25604
		' (get) Token: 0x0601052D RID: 66861 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0601052E RID: 66862 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601052F RID: 66863 RVA: 0x009AFA34 File Offset: 0x009ADC34
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptEmployeePayment() With { .Site = Me.Site }
		End Function

		' Token: 0x06010530 RID: 66864 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
