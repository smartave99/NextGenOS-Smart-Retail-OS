Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000287 RID: 647
	Public Class CryPrivilege
		Inherits ReportClass

		' Token: 0x170040A4 RID: 16548
		' (get) Token: 0x0600A6B8 RID: 42680 RVA: 0x00700D50 File Offset: 0x006FEF50
		' (set) Token: 0x0600A6B9 RID: 42681 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "CryPrivilege.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170040A5 RID: 16549
		' (get) Token: 0x0600A6BA RID: 42682 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A6BB RID: 42683 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040A6 RID: 16550
		' (get) Token: 0x0600A6BC RID: 42684 RVA: 0x00700D68 File Offset: 0x006FEF68
		' (set) Token: 0x0600A6BD RID: 42685 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.CryPrivilege.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170040A7 RID: 16551
		' (get) Token: 0x0600A6BE RID: 42686 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170040A8 RID: 16552
		' (get) Token: 0x0600A6BF RID: 42687 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170040A9 RID: 16553
		' (get) Token: 0x0600A6C0 RID: 42688 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170040AA RID: 16554
		' (get) Token: 0x0600A6C1 RID: 42689 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170040AB RID: 16555
		' (get) Token: 0x0600A6C2 RID: 42690 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170040AC RID: 16556
		' (get) Token: 0x0600A6C3 RID: 42691 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CName As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170040AD RID: 16557
		' (get) Token: 0x0600A6C4 RID: 42692 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CContact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170040AE RID: 16558
		' (get) Token: 0x0600A6C5 RID: 42693 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CardNo As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x170040AF RID: 16559
		' (get) Token: 0x0600A6C6 RID: 42694 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CardAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property
	End Class
End Namespace
