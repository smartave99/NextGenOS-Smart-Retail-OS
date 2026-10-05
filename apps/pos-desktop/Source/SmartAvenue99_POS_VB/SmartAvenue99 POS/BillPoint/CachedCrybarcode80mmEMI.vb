Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000484 RID: 1156
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCrybarcode80mmEMI
		Inherits Component
		Implements ICachedReport

		' Token: 0x170059C1 RID: 22977
		' (get) Token: 0x0600E993 RID: 59795 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E994 RID: 59796 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059C2 RID: 22978
		' (get) Token: 0x0600E995 RID: 59797 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600E996 RID: 59798 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059C3 RID: 22979
		' (get) Token: 0x0600E997 RID: 59799 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600E998 RID: 59800 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600E999 RID: 59801 RVA: 0x008D93A8 File Offset: 0x008D75A8
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New Crybarcode80mmEMI() With { .Site = Me.Site }
		End Function

		' Token: 0x0600E99A RID: 59802 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
