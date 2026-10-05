Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200053F RID: 1343
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptEstimateA4
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006616 RID: 26134
		' (get) Token: 0x06010855 RID: 67669 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010856 RID: 67670 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006617 RID: 26135
		' (get) Token: 0x06010857 RID: 67671 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06010858 RID: 67672 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006618 RID: 26136
		' (get) Token: 0x06010859 RID: 67673 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0601085A RID: 67674 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0601085B RID: 67675 RVA: 0x009B03D4 File Offset: 0x009AE5D4
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptEstimateA4() With { .Site = Me.Site }
		End Function

		' Token: 0x0601085C RID: 67676 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
