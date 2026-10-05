Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000504 RID: 1284
	Public Class rptDeduction
		Inherits ReportClass

		' Token: 0x170063E7 RID: 25575
		' (get) Token: 0x06010500 RID: 66816 RVA: 0x009AF9AC File Offset: 0x009ADBAC
		' (set) Token: 0x06010501 RID: 66817 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptDeduction.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063E8 RID: 25576
		' (get) Token: 0x06010502 RID: 66818 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010503 RID: 66819 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063E9 RID: 25577
		' (get) Token: 0x06010504 RID: 66820 RVA: 0x009AF9C4 File Offset: 0x009ADBC4
		' (set) Token: 0x06010505 RID: 66821 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptDeduction.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063EA RID: 25578
		' (get) Token: 0x06010506 RID: 66822 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170063EB RID: 25579
		' (get) Token: 0x06010507 RID: 66823 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170063EC RID: 25580
		' (get) Token: 0x06010508 RID: 66824 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170063ED RID: 25581
		' (get) Token: 0x06010509 RID: 66825 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170063EE RID: 25582
		' (get) Token: 0x0601050A RID: 66826 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170063EF RID: 25583
		' (get) Token: 0x0601050B RID: 66827 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_v2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170063F0 RID: 25584
		' (get) Token: 0x0601050C RID: 66828 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_v1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
