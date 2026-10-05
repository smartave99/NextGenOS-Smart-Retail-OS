Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005C5 RID: 1477
	Public Class rptExpenses
		Inherits ReportClass

		' Token: 0x17006FAF RID: 28591
		' (get) Token: 0x06011FC9 RID: 73673 RVA: 0x00A5CED8 File Offset: 0x00A5B0D8
		' (set) Token: 0x06011FCA RID: 73674 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptExpenses.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006FB0 RID: 28592
		' (get) Token: 0x06011FCB RID: 73675 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011FCC RID: 73676 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006FB1 RID: 28593
		' (get) Token: 0x06011FCD RID: 73677 RVA: 0x00A5CEF0 File Offset: 0x00A5B0F0
		' (set) Token: 0x06011FCE RID: 73678 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptExpenses.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006FB2 RID: 28594
		' (get) Token: 0x06011FCF RID: 73679 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006FB3 RID: 28595
		' (get) Token: 0x06011FD0 RID: 73680 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006FB4 RID: 28596
		' (get) Token: 0x06011FD1 RID: 73681 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006FB5 RID: 28597
		' (get) Token: 0x06011FD2 RID: 73682 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection2 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006FB6 RID: 28598
		' (get) Token: 0x06011FD3 RID: 73683 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006FB7 RID: 28599
		' (get) Token: 0x06011FD4 RID: 73684 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection2 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006FB8 RID: 28600
		' (get) Token: 0x06011FD5 RID: 73685 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17006FB9 RID: 28601
		' (get) Token: 0x06011FD6 RID: 73686 RVA: 0x00770D64 File Offset: 0x0076EF64
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(7)
			End Get
		End Property

		' Token: 0x17006FBA RID: 28602
		' (get) Token: 0x06011FD7 RID: 73687 RVA: 0x00771678 File Offset: 0x0076F878
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(8)
			End Get
		End Property

		' Token: 0x17006FBB RID: 28603
		' (get) Token: 0x06011FD8 RID: 73688 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006FBC RID: 28604
		' (get) Token: 0x06011FD9 RID: 73689 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17006FBD RID: 28605
		' (get) Token: 0x06011FDA RID: 73690 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17006FBE RID: 28606
		' (get) Token: 0x06011FDB RID: 73691 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property
	End Class
End Namespace
