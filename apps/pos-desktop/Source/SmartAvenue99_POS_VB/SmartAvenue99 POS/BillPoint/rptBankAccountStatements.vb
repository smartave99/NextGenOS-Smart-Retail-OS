Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200055A RID: 1370
	Public Class rptBankAccountStatements
		Inherits ReportClass

		' Token: 0x170067D3 RID: 26579
		' (get) Token: 0x06010C6D RID: 68717 RVA: 0x009CB208 File Offset: 0x009C9408
		' (set) Token: 0x06010C6E RID: 68718 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBankAccountStatements.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170067D4 RID: 26580
		' (get) Token: 0x06010C6F RID: 68719 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010C70 RID: 68720 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170067D5 RID: 26581
		' (get) Token: 0x06010C71 RID: 68721 RVA: 0x009CB220 File Offset: 0x009C9420
		' (set) Token: 0x06010C72 RID: 68722 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBankAccountStatements.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170067D6 RID: 26582
		' (get) Token: 0x06010C73 RID: 68723 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170067D7 RID: 26583
		' (get) Token: 0x06010C74 RID: 68724 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170067D8 RID: 26584
		' (get) Token: 0x06010C75 RID: 68725 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170067D9 RID: 26585
		' (get) Token: 0x06010C76 RID: 68726 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170067DA RID: 26586
		' (get) Token: 0x06010C77 RID: 68727 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170067DB RID: 26587
		' (get) Token: 0x06010C78 RID: 68728 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170067DC RID: 26588
		' (get) Token: 0x06010C79 RID: 68729 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
