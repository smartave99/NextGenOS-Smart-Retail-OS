Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002B4 RID: 692
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedrptBarcodeCipher2_1
		Inherits Component
		Implements ICachedReport

		' Token: 0x170044F5 RID: 17653
		' (get) Token: 0x0600B270 RID: 45680 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B271 RID: 45681 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170044F6 RID: 17654
		' (get) Token: 0x0600B272 RID: 45682 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600B273 RID: 45683 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170044F7 RID: 17655
		' (get) Token: 0x0600B274 RID: 45684 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600B275 RID: 45685 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600B276 RID: 45686 RVA: 0x00770BAC File Offset: 0x0076EDAC
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New rptBarcodeCipher2_1() With { .Site = Me.Site }
		End Function

		' Token: 0x0600B277 RID: 45687 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
