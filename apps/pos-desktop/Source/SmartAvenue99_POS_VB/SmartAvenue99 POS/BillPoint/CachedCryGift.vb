Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000286 RID: 646
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCryGift
		Inherits Component
		Implements ICachedReport

		' Token: 0x170040A1 RID: 16545
		' (get) Token: 0x0600A6AF RID: 42671 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A6B0 RID: 42672 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040A2 RID: 16546
		' (get) Token: 0x0600A6B1 RID: 42673 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600A6B2 RID: 42674 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040A3 RID: 16547
		' (get) Token: 0x0600A6B3 RID: 42675 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600A6B4 RID: 42676 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600A6B5 RID: 42677 RVA: 0x00700D28 File Offset: 0x006FEF28
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New CryGift() With { .Site = Me.Site }
		End Function

		' Token: 0x0600A6B6 RID: 42678 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
