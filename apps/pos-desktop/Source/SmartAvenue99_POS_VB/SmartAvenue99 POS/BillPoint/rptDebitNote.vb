Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000580 RID: 1408
	Public Class rptDebitNote
		Inherits ReportClass

		' Token: 0x170069DA RID: 27098
		' (get) Token: 0x060110F9 RID: 69881 RVA: 0x009E40D8 File Offset: 0x009E22D8
		' (set) Token: 0x060110FA RID: 69882 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptDebitNote.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170069DB RID: 27099
		' (get) Token: 0x060110FB RID: 69883 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060110FC RID: 69884 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170069DC RID: 27100
		' (get) Token: 0x060110FD RID: 69885 RVA: 0x009E40F0 File Offset: 0x009E22F0
		' (set) Token: 0x060110FE RID: 69886 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptDebitNote.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170069DD RID: 27101
		' (get) Token: 0x060110FF RID: 69887 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170069DE RID: 27102
		' (get) Token: 0x06011100 RID: 69888 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170069DF RID: 27103
		' (get) Token: 0x06011101 RID: 69889 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170069E0 RID: 27104
		' (get) Token: 0x06011102 RID: 69890 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170069E1 RID: 27105
		' (get) Token: 0x06011103 RID: 69891 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170069E2 RID: 27106
		' (get) Token: 0x06011104 RID: 69892 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x170069E3 RID: 27107
		' (get) Token: 0x06011105 RID: 69893 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x170069E4 RID: 27108
		' (get) Token: 0x06011106 RID: 69894 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170069E5 RID: 27109
		' (get) Token: 0x06011107 RID: 69895 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170069E6 RID: 27110
		' (get) Token: 0x06011108 RID: 69896 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PINV As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x170069E7 RID: 27111
		' (get) Token: 0x06011109 RID: 69897 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PDATE As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property
	End Class
End Namespace
