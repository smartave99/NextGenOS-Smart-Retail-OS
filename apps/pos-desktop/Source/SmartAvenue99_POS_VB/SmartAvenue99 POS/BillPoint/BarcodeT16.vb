Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000279 RID: 633
	Public Class BarcodeT16
		Inherits ReportClass

		' Token: 0x17004043 RID: 16451
		' (get) Token: 0x0600A611 RID: 42513 RVA: 0x00700AC4 File Offset: 0x006FECC4
		' (set) Token: 0x0600A612 RID: 42514 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT16.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004044 RID: 16452
		' (get) Token: 0x0600A613 RID: 42515 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A614 RID: 42516 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004045 RID: 16453
		' (get) Token: 0x0600A615 RID: 42517 RVA: 0x00700ADC File Offset: 0x006FECDC
		' (set) Token: 0x0600A616 RID: 42518 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT16.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004046 RID: 16454
		' (get) Token: 0x0600A617 RID: 42519 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004047 RID: 16455
		' (get) Token: 0x0600A618 RID: 42520 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004048 RID: 16456
		' (get) Token: 0x0600A619 RID: 42521 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004049 RID: 16457
		' (get) Token: 0x0600A61A RID: 42522 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700404A RID: 16458
		' (get) Token: 0x0600A61B RID: 42523 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700404B RID: 16459
		' (get) Token: 0x0600A61C RID: 42524 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
