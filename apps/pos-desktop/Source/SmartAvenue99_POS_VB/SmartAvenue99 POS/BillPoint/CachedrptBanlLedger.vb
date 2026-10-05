Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020004F9 RID: 1273
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBanlLedger
		Inherits Component
		Implements ICachedReport

		' Token: 0x170063A8 RID: 25512
		' (get) Token: 0x06010489 RID: 66697 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601048A RID: 66698 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063A9 RID: 25513
		' (get) Token: 0x0601048B RID: 66699 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0601048C RID: 66700 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063AA RID: 25514
		' (get) Token: 0x0601048D RID: 66701 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0601048E RID: 66702 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601048F RID: 66703 RVA: 0x009AF7CC File Offset: 0x009AD9CC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBanlLedger() With { .Site = Me.Site }
		End Function

		' Token: 0x06010490 RID: 66704 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
