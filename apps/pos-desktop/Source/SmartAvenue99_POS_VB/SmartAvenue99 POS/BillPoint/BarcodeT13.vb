Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000273 RID: 627
	Public Class BarcodeT13
		Inherits ReportClass

		' Token: 0x1700401F RID: 16415
		' (get) Token: 0x0600A5CF RID: 42447 RVA: 0x007009BC File Offset: 0x006FEBBC
		' (set) Token: 0x0600A5D0 RID: 42448 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT13.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004020 RID: 16416
		' (get) Token: 0x0600A5D1 RID: 42449 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A5D2 RID: 42450 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004021 RID: 16417
		' (get) Token: 0x0600A5D3 RID: 42451 RVA: 0x007009D4 File Offset: 0x006FEBD4
		' (set) Token: 0x0600A5D4 RID: 42452 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT13.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004022 RID: 16418
		' (get) Token: 0x0600A5D5 RID: 42453 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004023 RID: 16419
		' (get) Token: 0x0600A5D6 RID: 42454 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004024 RID: 16420
		' (get) Token: 0x0600A5D7 RID: 42455 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004025 RID: 16421
		' (get) Token: 0x0600A5D8 RID: 42456 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004026 RID: 16422
		' (get) Token: 0x0600A5D9 RID: 42457 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004027 RID: 16423
		' (get) Token: 0x0600A5DA RID: 42458 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
