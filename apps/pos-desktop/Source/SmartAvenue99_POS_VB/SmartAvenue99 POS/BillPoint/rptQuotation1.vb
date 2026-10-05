Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002C5 RID: 709
	Public Class rptQuotation1
		Inherits ReportClass

		' Token: 0x17004575 RID: 17781
		' (get) Token: 0x0600B346 RID: 45894 RVA: 0x00770EB8 File Offset: 0x0076F0B8
		' (set) Token: 0x0600B347 RID: 45895 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptQuotation1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004576 RID: 17782
		' (get) Token: 0x0600B348 RID: 45896 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B349 RID: 45897 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004577 RID: 17783
		' (get) Token: 0x0600B34A RID: 45898 RVA: 0x00770ED0 File Offset: 0x0076F0D0
		' (set) Token: 0x0600B34B RID: 45899 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptQuotation1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004578 RID: 17784
		' (get) Token: 0x0600B34C RID: 45900 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004579 RID: 17785
		' (get) Token: 0x0600B34D RID: 45901 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700457A RID: 17786
		' (get) Token: 0x0600B34E RID: 45902 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700457B RID: 17787
		' (get) Token: 0x0600B34F RID: 45903 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property DetailSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700457C RID: 17788
		' (get) Token: 0x0600B350 RID: 45904 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700457D RID: 17789
		' (get) Token: 0x0600B351 RID: 45905 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x1700457E RID: 17790
		' (get) Token: 0x0600B352 RID: 45906 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x1700457F RID: 17791
		' (get) Token: 0x0600B353 RID: 45907 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17004580 RID: 17792
		' (get) Token: 0x0600B354 RID: 45908 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CGST As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17004581 RID: 17793
		' (get) Token: 0x0600B355 RID: 45909 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_SGST As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17004582 RID: 17794
		' (get) Token: 0x0600B356 RID: 45910 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_IGST As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17004583 RID: 17795
		' (get) Token: 0x0600B357 RID: 45911 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CESS As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x17004584 RID: 17796
		' (get) Token: 0x0600B358 RID: 45912 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TOTAL As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x17004585 RID: 17797
		' (get) Token: 0x0600B359 RID: 45913 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Roff As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x17004586 RID: 17798
		' (get) Token: 0x0600B35A RID: 45914 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Net As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x17004587 RID: 17799
		' (get) Token: 0x0600B35B RID: 45915 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Company As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property

		' Token: 0x17004588 RID: 17800
		' (get) Token: 0x0600B35C RID: 45916 RVA: 0x006E86EC File Offset: 0x006E68EC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Address As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(10)
			End Get
		End Property

		' Token: 0x17004589 RID: 17801
		' (get) Token: 0x0600B35D RID: 45917 RVA: 0x006E8710 File Offset: 0x006E6910
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_State As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(11)
			End Get
		End Property

		' Token: 0x1700458A RID: 17802
		' (get) Token: 0x0600B35E RID: 45918 RVA: 0x006E8734 File Offset: 0x006E6934
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Contact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(12)
			End Get
		End Property

		' Token: 0x1700458B RID: 17803
		' (get) Token: 0x0600B35F RID: 45919 RVA: 0x006E8758 File Offset: 0x006E6958
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Email As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(13)
			End Get
		End Property

		' Token: 0x1700458C RID: 17804
		' (get) Token: 0x0600B360 RID: 45920 RVA: 0x006E877C File Offset: 0x006E697C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_GSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(14)
			End Get
		End Property

		' Token: 0x1700458D RID: 17805
		' (get) Token: 0x0600B361 RID: 45921 RVA: 0x006E87A0 File Offset: 0x006E69A0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_QN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(15)
			End Get
		End Property

		' Token: 0x1700458E RID: 17806
		' (get) Token: 0x0600B362 RID: 45922 RVA: 0x006E87C4 File Offset: 0x006E69C4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_QDate As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(16)
			End Get
		End Property

		' Token: 0x1700458F RID: 17807
		' (get) Token: 0x0600B363 RID: 45923 RVA: 0x006E87E8 File Offset: 0x006E69E8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CName As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(17)
			End Get
		End Property

		' Token: 0x17004590 RID: 17808
		' (get) Token: 0x0600B364 RID: 45924 RVA: 0x006E880C File Offset: 0x006E6A0C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(18)
			End Get
		End Property

		' Token: 0x17004591 RID: 17809
		' (get) Token: 0x0600B365 RID: 45925 RVA: 0x006E8830 File Offset: 0x006E6A30
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(19)
			End Get
		End Property

		' Token: 0x17004592 RID: 17810
		' (get) Token: 0x0600B366 RID: 45926 RVA: 0x006E8854 File Offset: 0x006E6A54
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CContact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(20)
			End Get
		End Property

		' Token: 0x17004593 RID: 17811
		' (get) Token: 0x0600B367 RID: 45927 RVA: 0x006E8878 File Offset: 0x006E6A78
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CGstin As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(21)
			End Get
		End Property
	End Class
End Namespace
