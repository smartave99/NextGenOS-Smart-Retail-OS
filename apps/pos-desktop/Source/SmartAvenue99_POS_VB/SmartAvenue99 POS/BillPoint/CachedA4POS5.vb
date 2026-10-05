Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000229 RID: 553
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedA4POS5
		Inherits Component
		Implements ICachedReport

		' Token: 0x17003A86 RID: 14982
		' (get) Token: 0x06009BC3 RID: 39875 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009BC4 RID: 39876 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003A87 RID: 14983
		' (get) Token: 0x06009BC5 RID: 39877 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06009BC6 RID: 39878 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003A88 RID: 14984
		' (get) Token: 0x06009BC7 RID: 39879 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06009BC8 RID: 39880 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06009BC9 RID: 39881 RVA: 0x006E8D78 File Offset: 0x006E6F78
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New A4POS5() With { .Site = Me.Site }
		End Function

		' Token: 0x06009BCA RID: 39882 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
