Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200021E RID: 542
	Public Class A4POS1
		Inherits ReportClass

		' Token: 0x1700394A RID: 14666
		' (get) Token: 0x06009A51 RID: 39505 RVA: 0x006E84A0 File Offset: 0x006E66A0
		' (set) Token: 0x06009A52 RID: 39506 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "A4POS1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700394B RID: 14667
		' (get) Token: 0x06009A53 RID: 39507 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009A54 RID: 39508 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700394C RID: 14668
		' (get) Token: 0x06009A55 RID: 39509 RVA: 0x006E84B8 File Offset: 0x006E66B8
		' (set) Token: 0x06009A56 RID: 39510 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.A4POS1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700394D RID: 14669
		' (get) Token: 0x06009A57 RID: 39511 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700394E RID: 14670
		' (get) Token: 0x06009A58 RID: 39512 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700394F RID: 14671
		' (get) Token: 0x06009A59 RID: 39513 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17003950 RID: 14672
		' (get) Token: 0x06009A5A RID: 39514 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17003951 RID: 14673
		' (get) Token: 0x06009A5B RID: 39515 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17003952 RID: 14674
		' (get) Token: 0x06009A5C RID: 39516 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PaidAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17003953 RID: 14675
		' (get) Token: 0x06009A5D RID: 39517 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17003954 RID: 14676
		' (get) Token: 0x06009A5E RID: 39518 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17003955 RID: 14677
		' (get) Token: 0x06009A5F RID: 39519 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17003956 RID: 14678
		' (get) Token: 0x06009A60 RID: 39520 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PendingAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17003957 RID: 14679
		' (get) Token: 0x06009A61 RID: 39521 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x17003958 RID: 14680
		' (get) Token: 0x06009A62 RID: 39522 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_RefundAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x17003959 RID: 14681
		' (get) Token: 0x06009A63 RID: 39523 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x1700395A RID: 14682
		' (get) Token: 0x06009A64 RID: 39524 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x1700395B RID: 14683
		' (get) Token: 0x06009A65 RID: 39525 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TendAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property

		' Token: 0x1700395C RID: 14684
		' (get) Token: 0x06009A66 RID: 39526 RVA: 0x006E86EC File Offset: 0x006E68EC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P10 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(10)
			End Get
		End Property

		' Token: 0x1700395D RID: 14685
		' (get) Token: 0x06009A67 RID: 39527 RVA: 0x006E8710 File Offset: 0x006E6910
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Sundry As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(11)
			End Get
		End Property

		' Token: 0x1700395E RID: 14686
		' (get) Token: 0x06009A68 RID: 39528 RVA: 0x006E8734 File Offset: 0x006E6934
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Discount As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(12)
			End Get
		End Property

		' Token: 0x1700395F RID: 14687
		' (get) Token: 0x06009A69 RID: 39529 RVA: 0x006E8758 File Offset: 0x006E6958
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Grand_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(13)
			End Get
		End Property

		' Token: 0x17003960 RID: 14688
		' (get) Token: 0x06009A6A RID: 39530 RVA: 0x006E877C File Offset: 0x006E697C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Roundoff As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(14)
			End Get
		End Property

		' Token: 0x17003961 RID: 14689
		' (get) Token: 0x06009A6B RID: 39531 RVA: 0x006E87A0 File Offset: 0x006E69A0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Net_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(15)
			End Get
		End Property

		' Token: 0x17003962 RID: 14690
		' (get) Token: 0x06009A6C RID: 39532 RVA: 0x006E87C4 File Offset: 0x006E69C4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Invoice_No As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(16)
			End Get
		End Property

		' Token: 0x17003963 RID: 14691
		' (get) Token: 0x06009A6D RID: 39533 RVA: 0x006E87E8 File Offset: 0x006E69E8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Date As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(17)
			End Get
		End Property

		' Token: 0x17003964 RID: 14692
		' (get) Token: 0x06009A6E RID: 39534 RVA: 0x006E880C File Offset: 0x006E6A0C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Tax_Type As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(18)
			End Get
		End Property

		' Token: 0x17003965 RID: 14693
		' (get) Token: 0x06009A6F RID: 39535 RVA: 0x006E8830 File Offset: 0x006E6A30
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_EWay As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(19)
			End Get
		End Property

		' Token: 0x17003966 RID: 14694
		' (get) Token: 0x06009A70 RID: 39536 RVA: 0x006E8854 File Offset: 0x006E6A54
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Salesman As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(20)
			End Get
		End Property

		' Token: 0x17003967 RID: 14695
		' (get) Token: 0x06009A71 RID: 39537 RVA: 0x006E8878 File Offset: 0x006E6A78
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Company As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(21)
			End Get
		End Property

		' Token: 0x17003968 RID: 14696
		' (get) Token: 0x06009A72 RID: 39538 RVA: 0x006E889C File Offset: 0x006E6A9C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(22)
			End Get
		End Property

		' Token: 0x17003969 RID: 14697
		' (get) Token: 0x06009A73 RID: 39539 RVA: 0x006E88C0 File Offset: 0x006E6AC0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompContact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(23)
			End Get
		End Property

		' Token: 0x1700396A RID: 14698
		' (get) Token: 0x06009A74 RID: 39540 RVA: 0x006E88E4 File Offset: 0x006E6AE4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompEmail As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(24)
			End Get
		End Property

		' Token: 0x1700396B RID: 14699
		' (get) Token: 0x06009A75 RID: 39541 RVA: 0x006E8908 File Offset: 0x006E6B08
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(25)
			End Get
		End Property

		' Token: 0x1700396C RID: 14700
		' (get) Token: 0x06009A76 RID: 39542 RVA: 0x006E892C File Offset: 0x006E6B2C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(26)
			End Get
		End Property

		' Token: 0x1700396D RID: 14701
		' (get) Token: 0x06009A77 RID: 39543 RVA: 0x006E8950 File Offset: 0x006E6B50
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(27)
			End Get
		End Property

		' Token: 0x1700396E RID: 14702
		' (get) Token: 0x06009A78 RID: 39544 RVA: 0x006E8974 File Offset: 0x006E6B74
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerName As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(28)
			End Get
		End Property

		' Token: 0x1700396F RID: 14703
		' (get) Token: 0x06009A79 RID: 39545 RVA: 0x006E8998 File Offset: 0x006E6B98
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerMobile As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(29)
			End Get
		End Property

		' Token: 0x17003970 RID: 14704
		' (get) Token: 0x06009A7A RID: 39546 RVA: 0x006E89BC File Offset: 0x006E6BBC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(30)
			End Get
		End Property

		' Token: 0x17003971 RID: 14705
		' (get) Token: 0x06009A7B RID: 39547 RVA: 0x006E89E0 File Offset: 0x006E6BE0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(31)
			End Get
		End Property

		' Token: 0x17003972 RID: 14706
		' (get) Token: 0x06009A7C RID: 39548 RVA: 0x006E8A04 File Offset: 0x006E6C04
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerBalance As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(32)
			End Get
		End Property

		' Token: 0x17003973 RID: 14707
		' (get) Token: 0x06009A7D RID: 39549 RVA: 0x006E8A28 File Offset: 0x006E6C28
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(33)
			End Get
		End Property

		' Token: 0x17003974 RID: 14708
		' (get) Token: 0x06009A7E RID: 39550 RVA: 0x006E8A4C File Offset: 0x006E6C4C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_SGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(34)
			End Get
		End Property

		' Token: 0x17003975 RID: 14709
		' (get) Token: 0x06009A7F RID: 39551 RVA: 0x006E8A70 File Offset: 0x006E6C70
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_IGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(35)
			End Get
		End Property

		' Token: 0x17003976 RID: 14710
		' (get) Token: 0x06009A80 RID: 39552 RVA: 0x006E8A94 File Offset: 0x006E6C94
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CESSTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(36)
			End Get
		End Property

		' Token: 0x17003977 RID: 14711
		' (get) Token: 0x06009A81 RID: 39553 RVA: 0x006E8AB8 File Offset: 0x006E6CB8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Transport As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(37)
			End Get
		End Property

		' Token: 0x17003978 RID: 14712
		' (get) Token: 0x06009A82 RID: 39554 RVA: 0x006E8ADC File Offset: 0x006E6CDC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_UPI As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(38)
			End Get
		End Property

		' Token: 0x17003979 RID: 14713
		' (get) Token: 0x06009A83 RID: 39555 RVA: 0x006E8B00 File Offset: 0x006E6D00
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Naration As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(39)
			End Get
		End Property

		' Token: 0x1700397A RID: 14714
		' (get) Token: 0x06009A84 RID: 39556 RVA: 0x006E8B24 File Offset: 0x006E6D24
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Coupon As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(40)
			End Get
		End Property

		' Token: 0x1700397B RID: 14715
		' (get) Token: 0x06009A85 RID: 39557 RVA: 0x006E8B48 File Offset: 0x006E6D48
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_ByReturn As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(41)
			End Get
		End Property
	End Class
End Namespace
