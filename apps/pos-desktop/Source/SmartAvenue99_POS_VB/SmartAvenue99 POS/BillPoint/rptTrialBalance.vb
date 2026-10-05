Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005F5 RID: 1525
	Public Class rptTrialBalance
		Inherits ReportClass

		' Token: 0x170073AC RID: 29612
		' (get) Token: 0x06012A81 RID: 76417 RVA: 0x00AB96E8 File Offset: 0x00AB78E8
		' (set) Token: 0x06012A82 RID: 76418 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptTrialBalance.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170073AD RID: 29613
		' (get) Token: 0x06012A83 RID: 76419 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A84 RID: 76420 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073AE RID: 29614
		' (get) Token: 0x06012A85 RID: 76421 RVA: 0x00AB9700 File Offset: 0x00AB7900
		' (set) Token: 0x06012A86 RID: 76422 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptTrialBalance.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170073AF RID: 29615
		' (get) Token: 0x06012A87 RID: 76423 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170073B0 RID: 29616
		' (get) Token: 0x06012A88 RID: 76424 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170073B1 RID: 29617
		' (get) Token: 0x06012A89 RID: 76425 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170073B2 RID: 29618
		' (get) Token: 0x06012A8A RID: 76426 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170073B3 RID: 29619
		' (get) Token: 0x06012A8B RID: 76427 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170073B4 RID: 29620
		' (get) Token: 0x06012A8C RID: 76428 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170073B5 RID: 29621
		' (get) Token: 0x06012A8D RID: 76429 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
