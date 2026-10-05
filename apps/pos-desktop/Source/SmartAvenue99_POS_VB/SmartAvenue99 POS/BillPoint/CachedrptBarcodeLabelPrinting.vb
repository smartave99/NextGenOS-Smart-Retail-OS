Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000598 RID: 1432
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBarcodeLabelPrinting
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006D32 RID: 27954
		' (get) Token: 0x0601199B RID: 72091 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601199C RID: 72092 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006D33 RID: 27955
		' (get) Token: 0x0601199D RID: 72093 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0601199E RID: 72094 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006D34 RID: 27956
		' (get) Token: 0x0601199F RID: 72095 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060119A0 RID: 72096 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060119A1 RID: 72097 RVA: 0x00A32F04 File Offset: 0x00A31104
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBarcodeLabelPrinting() With { .Site = Me.Site }
		End Function

		' Token: 0x060119A2 RID: 72098 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
