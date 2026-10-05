Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005F3 RID: 1523
	Public Class rptStockOut
		Inherits ReportClass

		' Token: 0x170073A0 RID: 29600
		' (get) Token: 0x06012A6B RID: 76395 RVA: 0x00AB9690 File Offset: 0x00AB7890
		' (set) Token: 0x06012A6C RID: 76396 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptStockOut.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170073A1 RID: 29601
		' (get) Token: 0x06012A6D RID: 76397 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A6E RID: 76398 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073A2 RID: 29602
		' (get) Token: 0x06012A6F RID: 76399 RVA: 0x00AB96A8 File Offset: 0x00AB78A8
		' (set) Token: 0x06012A70 RID: 76400 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptStockOut.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170073A3 RID: 29603
		' (get) Token: 0x06012A71 RID: 76401 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170073A4 RID: 29604
		' (get) Token: 0x06012A72 RID: 76402 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170073A5 RID: 29605
		' (get) Token: 0x06012A73 RID: 76403 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170073A6 RID: 29606
		' (get) Token: 0x06012A74 RID: 76404 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170073A7 RID: 29607
		' (get) Token: 0x06012A75 RID: 76405 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170073A8 RID: 29608
		' (get) Token: 0x06012A76 RID: 76406 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
