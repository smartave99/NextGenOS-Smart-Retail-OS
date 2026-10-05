Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002FC RID: 764
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA5SaleCustomiseMaster_Prof
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004937 RID: 18743
		' (get) Token: 0x0600B81A RID: 47130 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B81B RID: 47131 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004938 RID: 18744
		' (get) Token: 0x0600B81C RID: 47132 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B81D RID: 47133 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004939 RID: 18745
		' (get) Token: 0x0600B81E RID: 47134 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B81F RID: 47135 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B820 RID: 47136 RVA: 0x00771878 File Offset: 0x0076FA78
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A5SaleCustomiseMaster_Prof() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B821 RID: 47137 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
