Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000560 RID: 1376
	Public Class rptInvoiceTP
		Inherits ReportClass

		' Token: 0x170067F9 RID: 26617
		' (get) Token: 0x06010CB1 RID: 68785 RVA: 0x009CB310 File Offset: 0x009C9510
		' (set) Token: 0x06010CB2 RID: 68786 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptInvoiceTP.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170067FA RID: 26618
		' (get) Token: 0x06010CB3 RID: 68787 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010CB4 RID: 68788 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170067FB RID: 26619
		' (get) Token: 0x06010CB5 RID: 68789 RVA: 0x009CB328 File Offset: 0x009C9528
		' (set) Token: 0x06010CB6 RID: 68790 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptInvoiceTP.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170067FC RID: 26620
		' (get) Token: 0x06010CB7 RID: 68791 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170067FD RID: 26621
		' (get) Token: 0x06010CB8 RID: 68792 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170067FE RID: 26622
		' (get) Token: 0x06010CB9 RID: 68793 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170067FF RID: 26623
		' (get) Token: 0x06010CBA RID: 68794 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006800 RID: 26624
		' (get) Token: 0x06010CBB RID: 68795 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006801 RID: 26625
		' (get) Token: 0x06010CBC RID: 68796 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006802 RID: 26626
		' (get) Token: 0x06010CBD RID: 68797 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property ReportFooterSection2 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17006803 RID: 26627
		' (get) Token: 0x06010CBE RID: 68798 RVA: 0x00770D64 File Offset: 0x0076EF64
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(7)
			End Get
		End Property

		' Token: 0x17006804 RID: 26628
		' (get) Token: 0x06010CBF RID: 68799 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006805 RID: 26629
		' (get) Token: 0x06010CC0 RID: 68800 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17006806 RID: 26630
		' (get) Token: 0x06010CC1 RID: 68801 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17006807 RID: 26631
		' (get) Token: 0x06010CC2 RID: 68802 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17006808 RID: 26632
		' (get) Token: 0x06010CC3 RID: 68803 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17006809 RID: 26633
		' (get) Token: 0x06010CC4 RID: 68804 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property
	End Class
End Namespace
