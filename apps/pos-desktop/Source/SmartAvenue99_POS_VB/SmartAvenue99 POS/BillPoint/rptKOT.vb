Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002BD RID: 701
	Public Class rptKOT
		Inherits ReportClass

		' Token: 0x17004538 RID: 17720
		' (get) Token: 0x0600B2E1 RID: 45793 RVA: 0x00770D34 File Offset: 0x0076EF34
		' (set) Token: 0x0600B2E2 RID: 45794 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptKOT.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004539 RID: 17721
		' (get) Token: 0x0600B2E3 RID: 45795 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B2E4 RID: 45796 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700453A RID: 17722
		' (get) Token: 0x0600B2E5 RID: 45797 RVA: 0x00770D4C File Offset: 0x0076EF4C
		' (set) Token: 0x0600B2E6 RID: 45798 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptKOT.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700453B RID: 17723
		' (get) Token: 0x0600B2E7 RID: 45799 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property ReportHeaderSection3 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700453C RID: 17724
		' (get) Token: 0x0600B2E8 RID: 45800 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property PageHeaderSection4 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700453D RID: 17725
		' (get) Token: 0x0600B2E9 RID: 45801 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700453E RID: 17726
		' (get) Token: 0x0600B2EA RID: 45802 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700453F RID: 17727
		' (get) Token: 0x0600B2EB RID: 45803 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004540 RID: 17728
		' (get) Token: 0x0600B2EC RID: 45804 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17004541 RID: 17729
		' (get) Token: 0x0600B2ED RID: 45805 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17004542 RID: 17730
		' (get) Token: 0x0600B2EE RID: 45806 RVA: 0x00770D64 File Offset: 0x0076EF64
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(7)
			End Get
		End Property

		' Token: 0x17004543 RID: 17731
		' (get) Token: 0x0600B2EF RID: 45807 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
