Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005C3 RID: 1475
	Public Class rptCreditors
		Inherits ReportClass

		' Token: 0x17006FA3 RID: 28579
		' (get) Token: 0x06011FB3 RID: 73651 RVA: 0x00A5CE80 File Offset: 0x00A5B080
		' (set) Token: 0x06011FB4 RID: 73652 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptCreditors.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006FA4 RID: 28580
		' (get) Token: 0x06011FB5 RID: 73653 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011FB6 RID: 73654 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006FA5 RID: 28581
		' (get) Token: 0x06011FB7 RID: 73655 RVA: 0x00A5CE98 File Offset: 0x00A5B098
		' (set) Token: 0x06011FB8 RID: 73656 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptCreditors.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006FA6 RID: 28582
		' (get) Token: 0x06011FB9 RID: 73657 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006FA7 RID: 28583
		' (get) Token: 0x06011FBA RID: 73658 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006FA8 RID: 28584
		' (get) Token: 0x06011FBB RID: 73659 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006FA9 RID: 28585
		' (get) Token: 0x06011FBC RID: 73660 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006FAA RID: 28586
		' (get) Token: 0x06011FBD RID: 73661 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006FAB RID: 28587
		' (get) Token: 0x06011FBE RID: 73662 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
