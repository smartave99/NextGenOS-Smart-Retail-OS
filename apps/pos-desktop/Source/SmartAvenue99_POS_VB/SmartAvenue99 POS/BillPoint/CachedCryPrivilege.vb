Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000288 RID: 648
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCryPrivilege
		Inherits Component
		Implements ICachedReport

		' Token: 0x170040B0 RID: 16560
		' (get) Token: 0x0600A6C8 RID: 42696 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A6C9 RID: 42697 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040B1 RID: 16561
		' (get) Token: 0x0600A6CA RID: 42698 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A6CB RID: 42699 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040B2 RID: 16562
		' (get) Token: 0x0600A6CC RID: 42700 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A6CD RID: 42701 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A6CE RID: 42702 RVA: 0x00700D80 File Offset: 0x006FEF80
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New CryPrivilege() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A6CF RID: 42703 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
