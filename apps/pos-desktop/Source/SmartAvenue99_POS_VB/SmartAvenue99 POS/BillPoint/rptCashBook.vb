Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000500 RID: 1280
	Public Class rptCashBook
		Inherits ReportClass

		' Token: 0x170063CF RID: 25551
		' (get) Token: 0x060104D4 RID: 66772 RVA: 0x009AF8FC File Offset: 0x009ADAFC
		' (set) Token: 0x060104D5 RID: 66773 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptCashBook.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063D0 RID: 25552
		' (get) Token: 0x060104D6 RID: 66774 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060104D7 RID: 66775 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063D1 RID: 25553
		' (get) Token: 0x060104D8 RID: 66776 RVA: 0x009AF914 File Offset: 0x009ADB14
		' (set) Token: 0x060104D9 RID: 66777 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptCashBook.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063D2 RID: 25554
		' (get) Token: 0x060104DA RID: 66778 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170063D3 RID: 25555
		' (get) Token: 0x060104DB RID: 66779 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170063D4 RID: 25556
		' (get) Token: 0x060104DC RID: 66780 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170063D5 RID: 25557
		' (get) Token: 0x060104DD RID: 66781 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170063D6 RID: 25558
		' (get) Token: 0x060104DE RID: 66782 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170063D7 RID: 25559
		' (get) Token: 0x060104DF RID: 66783 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170063D8 RID: 25560
		' (get) Token: 0x060104E0 RID: 66784 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
