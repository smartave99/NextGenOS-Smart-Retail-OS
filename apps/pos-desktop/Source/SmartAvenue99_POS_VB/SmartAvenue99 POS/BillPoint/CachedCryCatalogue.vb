Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000320 RID: 800
	<ToolboxBitmap(GetType(ExportOptions), "report.bmp")>
	Public Class CachedCryCatalogue
		Inherits Component
		Implements ICachedReport

		' Token: 0x17004B69 RID: 19305
		' (get) Token: 0x0600BD2F RID: 48431 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BD30 RID: 48432 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property IsCacheable As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B6A RID: 19306
		' (get) Token: 0x0600BD31 RID: 48433 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		' (set) Token: 0x0600BD32 RID: 48434 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property ShareDBLogonInfo As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
			Get
				Return False
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B6B RID: 19307
		' (get) Token: 0x0600BD33 RID: 48435 RVA: 0x006E8B6C File Offset: 0x006E6D6C
		' (set) Token: 0x0600BD34 RID: 48436 RVA: 0x00009E98 File Offset: 0x00008098
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public Overridable Property CacheTimeOut As TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
			Get
				Return CachedReportConstants.DEFAULT_TIMEOUT
			End Get
			Set(value As TimeSpan)
			End Set
		End Property

		' Token: 0x0600BD35 RID: 48437 RVA: 0x00790348 File Offset: 0x0078E548
		Public Overridable Function CreateReport() As ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
			Return New CryCatalogue() With { .Site = Me.Site }
		End Function

		' Token: 0x0600BD36 RID: 48438 RVA: 0x006E8BAC File Offset: 0x006E6DAC
		Public Overridable Function GetCustomizedCacheKey(request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
			Return Nothing
		End Function
	End Class
End Namespace
