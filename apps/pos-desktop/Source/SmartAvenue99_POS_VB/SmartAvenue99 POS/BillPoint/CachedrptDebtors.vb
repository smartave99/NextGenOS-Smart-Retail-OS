Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200053D RID: 1341
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptDebtors
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006608 RID: 26120
		' (get) Token: 0x0601083D RID: 67645 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601083E RID: 67646 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006609 RID: 26121
		' (get) Token: 0x0601083F RID: 67647 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010840 RID: 67648 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700660A RID: 26122
		' (get) Token: 0x06010841 RID: 67649 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06010842 RID: 67650 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06010843 RID: 67651 RVA: 0x009B037C File Offset: 0x009AE57C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptDebtors() With { .Site = Me.Site }
		End Function

		' Token: 0x06010844 RID: 67652 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
