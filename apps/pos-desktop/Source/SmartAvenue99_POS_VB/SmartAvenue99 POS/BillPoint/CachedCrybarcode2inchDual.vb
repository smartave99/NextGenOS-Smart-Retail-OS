Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200047E RID: 1150
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCrybarcode2inchDual
		Inherits Component
		Implements ICachedReport

		' Token: 0x1700599D RID: 22941
		' (get) Token: 0x0600E951 RID: 59729 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E952 RID: 59730 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700599E RID: 22942
		' (get) Token: 0x0600E953 RID: 59731 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600E954 RID: 59732 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700599F RID: 22943
		' (get) Token: 0x0600E955 RID: 59733 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600E956 RID: 59734 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600E957 RID: 59735 RVA: 0x008D92A0 File Offset: 0x008D74A0
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New Crybarcode2inchDual() With { .Site = Me.Site }
		End Function

		' Token: 0x0600E958 RID: 59736 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
