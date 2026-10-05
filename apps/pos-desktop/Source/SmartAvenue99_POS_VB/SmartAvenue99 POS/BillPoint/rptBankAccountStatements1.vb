Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002AF RID: 687
	Public Class rptBankAccountStatements1
		Inherits ReportClass

		' Token: 0x170044D2 RID: 17618
		' (get) Token: 0x0600B235 RID: 45621 RVA: 0x00770ACC File Offset: 0x0076ECCC
		' (set) Token: 0x0600B236 RID: 45622 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBankAccountStatements1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170044D3 RID: 17619
		' (get) Token: 0x0600B237 RID: 45623 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B238 RID: 45624 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170044D4 RID: 17620
		' (get) Token: 0x0600B239 RID: 45625 RVA: 0x00770AE4 File Offset: 0x0076ECE4
		' (set) Token: 0x0600B23A RID: 45626 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBankAccountStatements1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170044D5 RID: 17621
		' (get) Token: 0x0600B23B RID: 45627 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170044D6 RID: 17622
		' (get) Token: 0x0600B23C RID: 45628 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170044D7 RID: 17623
		' (get) Token: 0x0600B23D RID: 45629 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170044D8 RID: 17624
		' (get) Token: 0x0600B23E RID: 45630 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170044D9 RID: 17625
		' (get) Token: 0x0600B23F RID: 45631 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170044DA RID: 17626
		' (get) Token: 0x0600B240 RID: 45632 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170044DB RID: 17627
		' (get) Token: 0x0600B241 RID: 45633 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170044DC RID: 17628
		' (get) Token: 0x0600B242 RID: 45634 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CB As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
