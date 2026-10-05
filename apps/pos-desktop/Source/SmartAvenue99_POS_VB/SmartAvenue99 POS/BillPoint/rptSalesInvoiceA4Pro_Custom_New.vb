Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000520 RID: 1312
	Public Class rptSalesInvoiceA4Pro_Custom_New
		Inherits ReportClass

		' Token: 0x170064DD RID: 25821
		' (get) Token: 0x06010682 RID: 67202 RVA: 0x009AFE7C File Offset: 0x009AE07C
		' (set) Token: 0x06010683 RID: 67203 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptSalesInvoiceA4Pro_Custom_New.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170064DE RID: 25822
		' (get) Token: 0x06010684 RID: 67204 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010685 RID: 67205 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170064DF RID: 25823
		' (get) Token: 0x06010686 RID: 67206 RVA: 0x009AFE94 File Offset: 0x009AE094
		' (set) Token: 0x06010687 RID: 67207 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptSalesInvoiceA4Pro_Custom_New.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170064E0 RID: 25824
		' (get) Token: 0x06010688 RID: 67208 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170064E1 RID: 25825
		' (get) Token: 0x06010689 RID: 67209 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170064E2 RID: 25826
		' (get) Token: 0x0601068A RID: 67210 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170064E3 RID: 25827
		' (get) Token: 0x0601068B RID: 67211 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170064E4 RID: 25828
		' (get) Token: 0x0601068C RID: 67212 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170064E5 RID: 25829
		' (get) Token: 0x0601068D RID: 67213 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x170064E6 RID: 25830
		' (get) Token: 0x0601068E RID: 67214 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x170064E7 RID: 25831
		' (get) Token: 0x0601068F RID: 67215 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170064E8 RID: 25832
		' (get) Token: 0x06010690 RID: 67216 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170064E9 RID: 25833
		' (get) Token: 0x06010691 RID: 67217 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x170064EA RID: 25834
		' (get) Token: 0x06010692 RID: 67218 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x170064EB RID: 25835
		' (get) Token: 0x06010693 RID: 67219 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x170064EC RID: 25836
		' (get) Token: 0x06010694 RID: 67220 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x170064ED RID: 25837
		' (get) Token: 0x06010695 RID: 67221 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P6 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x170064EE RID: 25838
		' (get) Token: 0x06010696 RID: 67222 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x170064EF RID: 25839
		' (get) Token: 0x06010697 RID: 67223 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x170064F0 RID: 25840
		' (get) Token: 0x06010698 RID: 67224 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P9 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property
	End Class
End Namespace
