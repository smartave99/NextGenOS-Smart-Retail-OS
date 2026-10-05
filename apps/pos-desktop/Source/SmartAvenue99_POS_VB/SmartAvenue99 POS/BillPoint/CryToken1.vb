Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200028B RID: 651
	Public Class CryToken1
		Inherits ReportClass

		' Token: 0x170040BE RID: 16574
		' (get) Token: 0x0600A6E6 RID: 42726 RVA: 0x00700E00 File Offset: 0x006FF000
		' (set) Token: 0x0600A6E7 RID: 42727 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "CryToken1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170040BF RID: 16575
		' (get) Token: 0x0600A6E8 RID: 42728 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A6E9 RID: 42729 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040C0 RID: 16576
		' (get) Token: 0x0600A6EA RID: 42730 RVA: 0x00700E18 File Offset: 0x006FF018
		' (set) Token: 0x0600A6EB RID: 42731 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.CryToken1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170040C1 RID: 16577
		' (get) Token: 0x0600A6EC RID: 42732 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170040C2 RID: 16578
		' (get) Token: 0x0600A6ED RID: 42733 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170040C3 RID: 16579
		' (get) Token: 0x0600A6EE RID: 42734 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170040C4 RID: 16580
		' (get) Token: 0x0600A6EF RID: 42735 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170040C5 RID: 16581
		' (get) Token: 0x0600A6F0 RID: 42736 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170040C6 RID: 16582
		' (get) Token: 0x0600A6F1 RID: 42737 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170040C7 RID: 16583
		' (get) Token: 0x0600A6F2 RID: 42738 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170040C8 RID: 16584
		' (get) Token: 0x0600A6F3 RID: 42739 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x170040C9 RID: 16585
		' (get) Token: 0x0600A6F4 RID: 42740 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x170040CA RID: 16586
		' (get) Token: 0x0600A6F5 RID: 42741 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property
	End Class
End Namespace
