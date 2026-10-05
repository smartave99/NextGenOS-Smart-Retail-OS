Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002EB RID: 747
	Public Class T3InchPOSD
		Inherits ReportClass

		' Token: 0x17004858 RID: 18520
		' (get) Token: 0x0600B6E7 RID: 46823 RVA: 0x00771540 File Offset: 0x0076F740
		' (set) Token: 0x0600B6E8 RID: 46824 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "T3InchPOSD.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004859 RID: 18521
		' (get) Token: 0x0600B6E9 RID: 46825 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B6EA RID: 46826 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700485A RID: 18522
		' (get) Token: 0x0600B6EB RID: 46827 RVA: 0x00771558 File Offset: 0x0076F758
		' (set) Token: 0x0600B6EC RID: 46828 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.T3InchPOSD.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700485B RID: 18523
		' (get) Token: 0x0600B6ED RID: 46829 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700485C RID: 18524
		' (get) Token: 0x0600B6EE RID: 46830 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700485D RID: 18525
		' (get) Token: 0x0600B6EF RID: 46831 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700485E RID: 18526
		' (get) Token: 0x0600B6F0 RID: 46832 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700485F RID: 18527
		' (get) Token: 0x0600B6F1 RID: 46833 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004860 RID: 18528
		' (get) Token: 0x0600B6F2 RID: 46834 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17004861 RID: 18529
		' (get) Token: 0x0600B6F3 RID: 46835 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_ItemD As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17004862 RID: 18530
		' (get) Token: 0x0600B6F4 RID: 46836 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TotalQtyD As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17004863 RID: 18531
		' (get) Token: 0x0600B6F5 RID: 46837 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TotalDisD As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17004864 RID: 18532
		' (get) Token: 0x0600B6F6 RID: 46838 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Company As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17004865 RID: 18533
		' (get) Token: 0x0600B6F7 RID: 46839 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x17004866 RID: 18534
		' (get) Token: 0x0600B6F8 RID: 46840 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompContact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x17004867 RID: 18535
		' (get) Token: 0x0600B6F9 RID: 46841 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompEmail As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x17004868 RID: 18536
		' (get) Token: 0x0600B6FA RID: 46842 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x17004869 RID: 18537
		' (get) Token: 0x0600B6FB RID: 46843 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property

		' Token: 0x1700486A RID: 18538
		' (get) Token: 0x0600B6FC RID: 46844 RVA: 0x006E86EC File Offset: 0x006E68EC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerName As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(10)
			End Get
		End Property

		' Token: 0x1700486B RID: 18539
		' (get) Token: 0x0600B6FD RID: 46845 RVA: 0x006E8710 File Offset: 0x006E6910
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(11)
			End Get
		End Property

		' Token: 0x1700486C RID: 18540
		' (get) Token: 0x0600B6FE RID: 46846 RVA: 0x006E8734 File Offset: 0x006E6934
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerMobile As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(12)
			End Get
		End Property

		' Token: 0x1700486D RID: 18541
		' (get) Token: 0x0600B6FF RID: 46847 RVA: 0x006E8758 File Offset: 0x006E6958
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(13)
			End Get
		End Property

		' Token: 0x1700486E RID: 18542
		' (get) Token: 0x0600B700 RID: 46848 RVA: 0x006E877C File Offset: 0x006E697C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(14)
			End Get
		End Property

		' Token: 0x1700486F RID: 18543
		' (get) Token: 0x0600B701 RID: 46849 RVA: 0x006E87A0 File Offset: 0x006E69A0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_INVNO As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(15)
			End Get
		End Property

		' Token: 0x17004870 RID: 18544
		' (get) Token: 0x0600B702 RID: 46850 RVA: 0x006E87C4 File Offset: 0x006E69C4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TotalAmtMRP As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(16)
			End Get
		End Property

		' Token: 0x17004871 RID: 18545
		' (get) Token: 0x0600B703 RID: 46851 RVA: 0x006E87E8 File Offset: 0x006E69E8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TotalAmtD As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(17)
			End Get
		End Property

		' Token: 0x17004872 RID: 18546
		' (get) Token: 0x0600B704 RID: 46852 RVA: 0x006E880C File Offset: 0x006E6A0C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_INVDate As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(18)
			End Get
		End Property
	End Class
End Namespace
