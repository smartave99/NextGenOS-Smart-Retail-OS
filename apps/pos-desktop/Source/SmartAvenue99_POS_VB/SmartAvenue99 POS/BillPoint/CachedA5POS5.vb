Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000247 RID: 583
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA5POS5
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003DD2 RID: 15826
		' (get) Token: 0x0600A07E RID: 41086 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A07F RID: 41087 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003DD3 RID: 15827
		' (get) Token: 0x0600A080 RID: 41088 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A081 RID: 41089 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003DD4 RID: 15828
		' (get) Token: 0x0600A082 RID: 41090 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A083 RID: 41091 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A084 RID: 41092 RVA: 0x006F49C8 File Offset: 0x006F2BC8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A5POS5() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A085 RID: 41093 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
