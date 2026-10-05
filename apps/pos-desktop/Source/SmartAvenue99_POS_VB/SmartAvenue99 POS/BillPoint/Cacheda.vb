Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020004FD RID: 1277
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class Cacheda
		Inherits Component
		Implements ICachedReport

		' Token: 0x170063C0 RID: 25536
		' (get) Token: 0x060104B5 RID: 66741 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060104B6 RID: 66742 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063C1 RID: 25537
		' (get) Token: 0x060104B7 RID: 66743 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x060104B8 RID: 66744 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063C2 RID: 25538
		' (get) Token: 0x060104B9 RID: 66745 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x060104BA RID: 66746 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x060104BB RID: 66747 RVA: 0x009AF87C File Offset: 0x009ADA7C
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New a() With { .Site = Me.Site }
		End Function

		' Token: 0x060104BC RID: 66748 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
