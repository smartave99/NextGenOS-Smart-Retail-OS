Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000566 RID: 1382
	Public Class rptOverallSales
		Inherits ReportClass

		' Token: 0x17006829 RID: 26665
		' (get) Token: 0x06010CFF RID: 68863 RVA: 0x009CB418 File Offset: 0x009C9618
		' (set) Token: 0x06010D00 RID: 68864 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptOverallSales.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700682A RID: 26666
		' (get) Token: 0x06010D01 RID: 68865 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010D02 RID: 68866 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700682B RID: 26667
		' (get) Token: 0x06010D03 RID: 68867 RVA: 0x009CB430 File Offset: 0x009C9630
		' (set) Token: 0x06010D04 RID: 68868 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptOverallSales.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700682C RID: 26668
		' (get) Token: 0x06010D05 RID: 68869 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700682D RID: 26669
		' (get) Token: 0x06010D06 RID: 68870 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property PageHeaderSection8 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700682E RID: 26670
		' (get) Token: 0x06010D07 RID: 68871 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property DetailSection2 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700682F RID: 26671
		' (get) Token: 0x06010D08 RID: 68872 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property DetailSection4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006830 RID: 26672
		' (get) Token: 0x06010D09 RID: 68873 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property DetailSection5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006831 RID: 26673
		' (get) Token: 0x06010D0A RID: 68874 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property DetailSection7 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006832 RID: 26674
		' (get) Token: 0x06010D0B RID: 68875 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17006833 RID: 26675
		' (get) Token: 0x06010D0C RID: 68876 RVA: 0x00770D64 File Offset: 0x0076EF64
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(7)
			End Get
		End Property

		' Token: 0x17006834 RID: 26676
		' (get) Token: 0x06010D0D RID: 68877 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006835 RID: 26677
		' (get) Token: 0x06010D0E RID: 68878 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17006836 RID: 26678
		' (get) Token: 0x06010D0F RID: 68879 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_pa As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17006837 RID: 26679
		' (get) Token: 0x06010D10 RID: 68880 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_rptRPOS2rpt_p3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17006838 RID: 26680
		' (get) Token: 0x06010D11 RID: 68881 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_rptRPOS2rpt_p4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17006839 RID: 26681
		' (get) Token: 0x06010D12 RID: 68882 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_rptRPOS2rpt_pf1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x1700683A RID: 26682
		' (get) Token: 0x06010D13 RID: 68883 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_rptRPOS4rpt_p5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x1700683B RID: 26683
		' (get) Token: 0x06010D14 RID: 68884 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_rptRPOS4rpt_p6 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x1700683C RID: 26684
		' (get) Token: 0x06010D15 RID: 68885 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_rptRPOS4rpt_pf2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property
	End Class
End Namespace
