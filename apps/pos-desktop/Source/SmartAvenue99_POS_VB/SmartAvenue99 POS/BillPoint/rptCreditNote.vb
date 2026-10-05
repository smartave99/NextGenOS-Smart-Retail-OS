Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200057C RID: 1404
	Public Class rptCreditNote
		Inherits ReportClass

		' Token: 0x170069BD RID: 27069
		' (get) Token: 0x060110C8 RID: 69832 RVA: 0x009E4028 File Offset: 0x009E2228
		' (set) Token: 0x060110C9 RID: 69833 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptCreditNote.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170069BE RID: 27070
		' (get) Token: 0x060110CA RID: 69834 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060110CB RID: 69835 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170069BF RID: 27071
		' (get) Token: 0x060110CC RID: 69836 RVA: 0x009E4040 File Offset: 0x009E2240
		' (set) Token: 0x060110CD RID: 69837 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptCreditNote.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170069C0 RID: 27072
		' (get) Token: 0x060110CE RID: 69838 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170069C1 RID: 27073
		' (get) Token: 0x060110CF RID: 69839 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170069C2 RID: 27074
		' (get) Token: 0x060110D0 RID: 69840 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170069C3 RID: 27075
		' (get) Token: 0x060110D1 RID: 69841 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170069C4 RID: 27076
		' (get) Token: 0x060110D2 RID: 69842 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170069C5 RID: 27077
		' (get) Token: 0x060110D3 RID: 69843 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x170069C6 RID: 27078
		' (get) Token: 0x060110D4 RID: 69844 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x170069C7 RID: 27079
		' (get) Token: 0x060110D5 RID: 69845 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170069C8 RID: 27080
		' (get) Token: 0x060110D6 RID: 69846 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170069C9 RID: 27081
		' (get) Token: 0x060110D7 RID: 69847 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_SINV As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x170069CA RID: 27082
		' (get) Token: 0x060110D8 RID: 69848 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_SDATE As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property
	End Class
End Namespace
