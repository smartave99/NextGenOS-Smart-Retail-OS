Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002FB RID: 763
	Public Class A5SaleCustomiseMaster_Prof
		Inherits ReportClass

		' Token: 0x17004922 RID: 18722
		' (get) Token: 0x0600B801 RID: 47105 RVA: 0x00771848 File Offset: 0x0076FA48
		' (set) Token: 0x0600B802 RID: 47106 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "A5SaleCustomiseMaster_Prof.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004923 RID: 18723
		' (get) Token: 0x0600B803 RID: 47107 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B804 RID: 47108 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004924 RID: 18724
		' (get) Token: 0x0600B805 RID: 47109 RVA: 0x00771860 File Offset: 0x0076FA60
		' (set) Token: 0x0600B806 RID: 47110 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.A5SaleCustomiseMaster_Prof.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004925 RID: 18725
		' (get) Token: 0x0600B807 RID: 47111 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004926 RID: 18726
		' (get) Token: 0x0600B808 RID: 47112 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004927 RID: 18727
		' (get) Token: 0x0600B809 RID: 47113 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004928 RID: 18728
		' (get) Token: 0x0600B80A RID: 47114 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004929 RID: 18729
		' (get) Token: 0x0600B80B RID: 47115 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700492A RID: 18730
		' (get) Token: 0x0600B80C RID: 47116 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x1700492B RID: 18731
		' (get) Token: 0x0600B80D RID: 47117 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x1700492C RID: 18732
		' (get) Token: 0x0600B80E RID: 47118 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x1700492D RID: 18733
		' (get) Token: 0x0600B80F RID: 47119 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x1700492E RID: 18734
		' (get) Token: 0x0600B810 RID: 47120 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x1700492F RID: 18735
		' (get) Token: 0x0600B811 RID: 47121 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17004930 RID: 18736
		' (get) Token: 0x0600B812 RID: 47122 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17004931 RID: 18737
		' (get) Token: 0x0600B813 RID: 47123 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x17004932 RID: 18738
		' (get) Token: 0x0600B814 RID: 47124 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P6 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x17004933 RID: 18739
		' (get) Token: 0x0600B815 RID: 47125 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x17004934 RID: 18740
		' (get) Token: 0x0600B816 RID: 47126 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x17004935 RID: 18741
		' (get) Token: 0x0600B817 RID: 47127 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P9 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property

		' Token: 0x17004936 RID: 18742
		' (get) Token: 0x0600B818 RID: 47128 RVA: 0x006E86EC File Offset: 0x006E68EC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P10 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(10)
			End Get
		End Property
	End Class
End Namespace
