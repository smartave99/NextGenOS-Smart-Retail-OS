Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200053C RID: 1340
	Public Class rptDebtors
		Inherits ReportClass

		' Token: 0x170065FD RID: 26109
		' (get) Token: 0x0601082E RID: 67630 RVA: 0x009B034C File Offset: 0x009AE54C
		' (set) Token: 0x0601082F RID: 67631 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptDebtors.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170065FE RID: 26110
		' (get) Token: 0x06010830 RID: 67632 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010831 RID: 67633 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065FF RID: 26111
		' (get) Token: 0x06010832 RID: 67634 RVA: 0x009B0364 File Offset: 0x009AE564
		' (set) Token: 0x06010833 RID: 67635 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptDebtors.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006600 RID: 26112
		' (get) Token: 0x06010834 RID: 67636 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006601 RID: 26113
		' (get) Token: 0x06010835 RID: 67637 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006602 RID: 26114
		' (get) Token: 0x06010836 RID: 67638 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006603 RID: 26115
		' (get) Token: 0x06010837 RID: 67639 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006604 RID: 26116
		' (get) Token: 0x06010838 RID: 67640 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006605 RID: 26117
		' (get) Token: 0x06010839 RID: 67641 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006606 RID: 26118
		' (get) Token: 0x0601083A RID: 67642 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17006607 RID: 26119
		' (get) Token: 0x0601083B RID: 67643 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
