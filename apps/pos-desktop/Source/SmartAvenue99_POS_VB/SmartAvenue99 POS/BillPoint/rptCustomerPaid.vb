Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200053A RID: 1338
	Public Class rptCustomerPaid
		Inherits ReportClass

		' Token: 0x170065ED RID: 26093
		' (get) Token: 0x06010814 RID: 67604 RVA: 0x009B02F4 File Offset: 0x009AE4F4
		' (set) Token: 0x06010815 RID: 67605 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptCustomerPaid.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170065EE RID: 26094
		' (get) Token: 0x06010816 RID: 67606 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010817 RID: 67607 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065EF RID: 26095
		' (get) Token: 0x06010818 RID: 67608 RVA: 0x009B030C File Offset: 0x009AE50C
		' (set) Token: 0x06010819 RID: 67609 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptCustomerPaid.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170065F0 RID: 26096
		' (get) Token: 0x0601081A RID: 67610 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170065F1 RID: 26097
		' (get) Token: 0x0601081B RID: 67611 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170065F2 RID: 26098
		' (get) Token: 0x0601081C RID: 67612 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170065F3 RID: 26099
		' (get) Token: 0x0601081D RID: 67613 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170065F4 RID: 26100
		' (get) Token: 0x0601081E RID: 67614 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170065F5 RID: 26101
		' (get) Token: 0x0601081F RID: 67615 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170065F6 RID: 26102
		' (get) Token: 0x06010820 RID: 67616 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170065F7 RID: 26103
		' (get) Token: 0x06010821 RID: 67617 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x170065F8 RID: 26104
		' (get) Token: 0x06010822 RID: 67618 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x170065F9 RID: 26105
		' (get) Token: 0x06010823 RID: 67619 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property
	End Class
End Namespace
