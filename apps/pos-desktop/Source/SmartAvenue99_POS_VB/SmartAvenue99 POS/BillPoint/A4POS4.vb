Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000226 RID: 550
	Public Class A4POS4
		Inherits ReportClass

		' Token: 0x17003A1E RID: 14878
		' (get) Token: 0x06009B4D RID: 39757 RVA: 0x006E8CCC File Offset: 0x006E6ECC
		' (set) Token: 0x06009B4E RID: 39758 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "A4POS4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003A1F RID: 14879
		' (get) Token: 0x06009B4F RID: 39759 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009B50 RID: 39760 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003A20 RID: 14880
		' (get) Token: 0x06009B51 RID: 39761 RVA: 0x006E8CE4 File Offset: 0x006E6EE4
		' (set) Token: 0x06009B52 RID: 39762 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.A4POS4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003A21 RID: 14881
		' (get) Token: 0x06009B53 RID: 39763 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17003A22 RID: 14882
		' (get) Token: 0x06009B54 RID: 39764 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17003A23 RID: 14883
		' (get) Token: 0x06009B55 RID: 39765 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17003A24 RID: 14884
		' (get) Token: 0x06009B56 RID: 39766 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17003A25 RID: 14885
		' (get) Token: 0x06009B57 RID: 39767 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17003A26 RID: 14886
		' (get) Token: 0x06009B58 RID: 39768 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PaidAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17003A27 RID: 14887
		' (get) Token: 0x06009B59 RID: 39769 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17003A28 RID: 14888
		' (get) Token: 0x06009B5A RID: 39770 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17003A29 RID: 14889
		' (get) Token: 0x06009B5B RID: 39771 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17003A2A RID: 14890
		' (get) Token: 0x06009B5C RID: 39772 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PendingAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17003A2B RID: 14891
		' (get) Token: 0x06009B5D RID: 39773 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x17003A2C RID: 14892
		' (get) Token: 0x06009B5E RID: 39774 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_RefundAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x17003A2D RID: 14893
		' (get) Token: 0x06009B5F RID: 39775 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x17003A2E RID: 14894
		' (get) Token: 0x06009B60 RID: 39776 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x17003A2F RID: 14895
		' (get) Token: 0x06009B61 RID: 39777 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TendAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property

		' Token: 0x17003A30 RID: 14896
		' (get) Token: 0x06009B62 RID: 39778 RVA: 0x006E86EC File Offset: 0x006E68EC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P10 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(10)
			End Get
		End Property

		' Token: 0x17003A31 RID: 14897
		' (get) Token: 0x06009B63 RID: 39779 RVA: 0x006E8710 File Offset: 0x006E6910
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Sundry As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(11)
			End Get
		End Property

		' Token: 0x17003A32 RID: 14898
		' (get) Token: 0x06009B64 RID: 39780 RVA: 0x006E8734 File Offset: 0x006E6934
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Discount As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(12)
			End Get
		End Property

		' Token: 0x17003A33 RID: 14899
		' (get) Token: 0x06009B65 RID: 39781 RVA: 0x006E8758 File Offset: 0x006E6958
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Grand_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(13)
			End Get
		End Property

		' Token: 0x17003A34 RID: 14900
		' (get) Token: 0x06009B66 RID: 39782 RVA: 0x006E877C File Offset: 0x006E697C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Roundoff As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(14)
			End Get
		End Property

		' Token: 0x17003A35 RID: 14901
		' (get) Token: 0x06009B67 RID: 39783 RVA: 0x006E87A0 File Offset: 0x006E69A0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Net_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(15)
			End Get
		End Property

		' Token: 0x17003A36 RID: 14902
		' (get) Token: 0x06009B68 RID: 39784 RVA: 0x006E87C4 File Offset: 0x006E69C4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Invoice_No As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(16)
			End Get
		End Property

		' Token: 0x17003A37 RID: 14903
		' (get) Token: 0x06009B69 RID: 39785 RVA: 0x006E87E8 File Offset: 0x006E69E8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Date As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(17)
			End Get
		End Property

		' Token: 0x17003A38 RID: 14904
		' (get) Token: 0x06009B6A RID: 39786 RVA: 0x006E880C File Offset: 0x006E6A0C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Tax_Type As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(18)
			End Get
		End Property

		' Token: 0x17003A39 RID: 14905
		' (get) Token: 0x06009B6B RID: 39787 RVA: 0x006E8830 File Offset: 0x006E6A30
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_EWay As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(19)
			End Get
		End Property

		' Token: 0x17003A3A RID: 14906
		' (get) Token: 0x06009B6C RID: 39788 RVA: 0x006E8854 File Offset: 0x006E6A54
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Salesman As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(20)
			End Get
		End Property

		' Token: 0x17003A3B RID: 14907
		' (get) Token: 0x06009B6D RID: 39789 RVA: 0x006E8878 File Offset: 0x006E6A78
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Company As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(21)
			End Get
		End Property

		' Token: 0x17003A3C RID: 14908
		' (get) Token: 0x06009B6E RID: 39790 RVA: 0x006E889C File Offset: 0x006E6A9C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(22)
			End Get
		End Property

		' Token: 0x17003A3D RID: 14909
		' (get) Token: 0x06009B6F RID: 39791 RVA: 0x006E88C0 File Offset: 0x006E6AC0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompContact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(23)
			End Get
		End Property

		' Token: 0x17003A3E RID: 14910
		' (get) Token: 0x06009B70 RID: 39792 RVA: 0x006E88E4 File Offset: 0x006E6AE4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompEmail As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(24)
			End Get
		End Property

		' Token: 0x17003A3F RID: 14911
		' (get) Token: 0x06009B71 RID: 39793 RVA: 0x006E8908 File Offset: 0x006E6B08
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(25)
			End Get
		End Property

		' Token: 0x17003A40 RID: 14912
		' (get) Token: 0x06009B72 RID: 39794 RVA: 0x006E892C File Offset: 0x006E6B2C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(26)
			End Get
		End Property

		' Token: 0x17003A41 RID: 14913
		' (get) Token: 0x06009B73 RID: 39795 RVA: 0x006E8950 File Offset: 0x006E6B50
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(27)
			End Get
		End Property

		' Token: 0x17003A42 RID: 14914
		' (get) Token: 0x06009B74 RID: 39796 RVA: 0x006E8974 File Offset: 0x006E6B74
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerName As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(28)
			End Get
		End Property

		' Token: 0x17003A43 RID: 14915
		' (get) Token: 0x06009B75 RID: 39797 RVA: 0x006E8998 File Offset: 0x006E6B98
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerMobile As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(29)
			End Get
		End Property

		' Token: 0x17003A44 RID: 14916
		' (get) Token: 0x06009B76 RID: 39798 RVA: 0x006E89BC File Offset: 0x006E6BBC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(30)
			End Get
		End Property

		' Token: 0x17003A45 RID: 14917
		' (get) Token: 0x06009B77 RID: 39799 RVA: 0x006E89E0 File Offset: 0x006E6BE0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(31)
			End Get
		End Property

		' Token: 0x17003A46 RID: 14918
		' (get) Token: 0x06009B78 RID: 39800 RVA: 0x006E8A04 File Offset: 0x006E6C04
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerBalance As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(32)
			End Get
		End Property

		' Token: 0x17003A47 RID: 14919
		' (get) Token: 0x06009B79 RID: 39801 RVA: 0x006E8A28 File Offset: 0x006E6C28
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(33)
			End Get
		End Property

		' Token: 0x17003A48 RID: 14920
		' (get) Token: 0x06009B7A RID: 39802 RVA: 0x006E8A4C File Offset: 0x006E6C4C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_SGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(34)
			End Get
		End Property

		' Token: 0x17003A49 RID: 14921
		' (get) Token: 0x06009B7B RID: 39803 RVA: 0x006E8A70 File Offset: 0x006E6C70
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_IGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(35)
			End Get
		End Property

		' Token: 0x17003A4A RID: 14922
		' (get) Token: 0x06009B7C RID: 39804 RVA: 0x006E8A94 File Offset: 0x006E6C94
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CESSTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(36)
			End Get
		End Property

		' Token: 0x17003A4B RID: 14923
		' (get) Token: 0x06009B7D RID: 39805 RVA: 0x006E8AB8 File Offset: 0x006E6CB8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Transport As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(37)
			End Get
		End Property

		' Token: 0x17003A4C RID: 14924
		' (get) Token: 0x06009B7E RID: 39806 RVA: 0x006E8ADC File Offset: 0x006E6CDC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_UPI As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(38)
			End Get
		End Property

		' Token: 0x17003A4D RID: 14925
		' (get) Token: 0x06009B7F RID: 39807 RVA: 0x006E8B00 File Offset: 0x006E6D00
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Naration As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(39)
			End Get
		End Property

		' Token: 0x17003A4E RID: 14926
		' (get) Token: 0x06009B80 RID: 39808 RVA: 0x006E8B24 File Offset: 0x006E6D24
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Coupon As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(40)
			End Get
		End Property

		' Token: 0x17003A4F RID: 14927
		' (get) Token: 0x06009B81 RID: 39809 RVA: 0x006E8B48 File Offset: 0x006E6D48
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_My_Parameter As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(41)
			End Get
		End Property

		' Token: 0x17003A50 RID: 14928
		' (get) Token: 0x06009B82 RID: 39810 RVA: 0x006E8CFC File Offset: 0x006E6EFC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_ByReturn As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(42)
			End Get
		End Property
	End Class
End Namespace
