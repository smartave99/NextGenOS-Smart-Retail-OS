Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005C4 RID: 1476
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptCreditors
		Inherits Component
		Implements ICachedReport

		' Token: 0x17006FAC RID: 28588
		' (get) Token: 0x06011FC0 RID: 73664 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011FC1 RID: 73665 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006FAD RID: 28589
		' (get) Token: 0x06011FC2 RID: 73666 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x06011FC3 RID: 73667 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006FAE RID: 28590
		' (get) Token: 0x06011FC4 RID: 73668 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x06011FC5 RID: 73669 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x06011FC6 RID: 73670 RVA: 0x00A5CEB0 File Offset: 0x00A5B0B0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptCreditors() With { .Site = Me.Site }
		End Function

		' Token: 0x06011FC7 RID: 73671 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
