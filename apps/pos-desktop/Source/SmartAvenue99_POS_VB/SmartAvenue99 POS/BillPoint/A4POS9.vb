Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000230 RID: 560
	Public Class A4POS9
		Inherits ReportClass

		' Token: 0x17003B29 RID: 15145
		' (get) Token: 0x06009C8A RID: 40074 RVA: 0x006E8EA8 File Offset: 0x006E70A8
		' (set) Token: 0x06009C8B RID: 40075 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "A4POS9.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003B2A RID: 15146
		' (get) Token: 0x06009C8C RID: 40076 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009C8D RID: 40077 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003B2B RID: 15147
		' (get) Token: 0x06009C8E RID: 40078 RVA: 0x006E8EC0 File Offset: 0x006E70C0
		' (set) Token: 0x06009C8F RID: 40079 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.A4POS9.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003B2C RID: 15148
		' (get) Token: 0x06009C90 RID: 40080 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17003B2D RID: 15149
		' (get) Token: 0x06009C91 RID: 40081 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17003B2E RID: 15150
		' (get) Token: 0x06009C92 RID: 40082 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17003B2F RID: 15151
		' (get) Token: 0x06009C93 RID: 40083 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17003B30 RID: 15152
		' (get) Token: 0x06009C94 RID: 40084 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17003B31 RID: 15153
		' (get) Token: 0x06009C95 RID: 40085 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PaidAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17003B32 RID: 15154
		' (get) Token: 0x06009C96 RID: 40086 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17003B33 RID: 15155
		' (get) Token: 0x06009C97 RID: 40087 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17003B34 RID: 15156
		' (get) Token: 0x06009C98 RID: 40088 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17003B35 RID: 15157
		' (get) Token: 0x06009C99 RID: 40089 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PendingAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17003B36 RID: 15158
		' (get) Token: 0x06009C9A RID: 40090 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x17003B37 RID: 15159
		' (get) Token: 0x06009C9B RID: 40091 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_RefundAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x17003B38 RID: 15160
		' (get) Token: 0x06009C9C RID: 40092 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x17003B39 RID: 15161
		' (get) Token: 0x06009C9D RID: 40093 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x17003B3A RID: 15162
		' (get) Token: 0x06009C9E RID: 40094 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TendAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property

		' Token: 0x17003B3B RID: 15163
		' (get) Token: 0x06009C9F RID: 40095 RVA: 0x006E86EC File Offset: 0x006E68EC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P10 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(10)
			End Get
		End Property

		' Token: 0x17003B3C RID: 15164
		' (get) Token: 0x06009CA0 RID: 40096 RVA: 0x006E8710 File Offset: 0x006E6910
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Sundry As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(11)
			End Get
		End Property

		' Token: 0x17003B3D RID: 15165
		' (get) Token: 0x06009CA1 RID: 40097 RVA: 0x006E8734 File Offset: 0x006E6934
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Discount As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(12)
			End Get
		End Property

		' Token: 0x17003B3E RID: 15166
		' (get) Token: 0x06009CA2 RID: 40098 RVA: 0x006E8758 File Offset: 0x006E6958
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Grand_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(13)
			End Get
		End Property

		' Token: 0x17003B3F RID: 15167
		' (get) Token: 0x06009CA3 RID: 40099 RVA: 0x006E877C File Offset: 0x006E697C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Roundoff As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(14)
			End Get
		End Property

		' Token: 0x17003B40 RID: 15168
		' (get) Token: 0x06009CA4 RID: 40100 RVA: 0x006E87A0 File Offset: 0x006E69A0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Net_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(15)
			End Get
		End Property

		' Token: 0x17003B41 RID: 15169
		' (get) Token: 0x06009CA5 RID: 40101 RVA: 0x006E87C4 File Offset: 0x006E69C4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Invoice_No As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(16)
			End Get
		End Property

		' Token: 0x17003B42 RID: 15170
		' (get) Token: 0x06009CA6 RID: 40102 RVA: 0x006E87E8 File Offset: 0x006E69E8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Date As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(17)
			End Get
		End Property

		' Token: 0x17003B43 RID: 15171
		' (get) Token: 0x06009CA7 RID: 40103 RVA: 0x006E880C File Offset: 0x006E6A0C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Tax_Type As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(18)
			End Get
		End Property

		' Token: 0x17003B44 RID: 15172
		' (get) Token: 0x06009CA8 RID: 40104 RVA: 0x006E8830 File Offset: 0x006E6A30
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_EWay As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(19)
			End Get
		End Property

		' Token: 0x17003B45 RID: 15173
		' (get) Token: 0x06009CA9 RID: 40105 RVA: 0x006E8854 File Offset: 0x006E6A54
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Salesman As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(20)
			End Get
		End Property

		' Token: 0x17003B46 RID: 15174
		' (get) Token: 0x06009CAA RID: 40106 RVA: 0x006E8878 File Offset: 0x006E6A78
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Company As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(21)
			End Get
		End Property

		' Token: 0x17003B47 RID: 15175
		' (get) Token: 0x06009CAB RID: 40107 RVA: 0x006E889C File Offset: 0x006E6A9C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(22)
			End Get
		End Property

		' Token: 0x17003B48 RID: 15176
		' (get) Token: 0x06009CAC RID: 40108 RVA: 0x006E88C0 File Offset: 0x006E6AC0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompContact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(23)
			End Get
		End Property

		' Token: 0x17003B49 RID: 15177
		' (get) Token: 0x06009CAD RID: 40109 RVA: 0x006E88E4 File Offset: 0x006E6AE4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompEmail As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(24)
			End Get
		End Property

		' Token: 0x17003B4A RID: 15178
		' (get) Token: 0x06009CAE RID: 40110 RVA: 0x006E8908 File Offset: 0x006E6B08
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(25)
			End Get
		End Property

		' Token: 0x17003B4B RID: 15179
		' (get) Token: 0x06009CAF RID: 40111 RVA: 0x006E892C File Offset: 0x006E6B2C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(26)
			End Get
		End Property

		' Token: 0x17003B4C RID: 15180
		' (get) Token: 0x06009CB0 RID: 40112 RVA: 0x006E8950 File Offset: 0x006E6B50
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(27)
			End Get
		End Property

		' Token: 0x17003B4D RID: 15181
		' (get) Token: 0x06009CB1 RID: 40113 RVA: 0x006E8974 File Offset: 0x006E6B74
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerName As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(28)
			End Get
		End Property

		' Token: 0x17003B4E RID: 15182
		' (get) Token: 0x06009CB2 RID: 40114 RVA: 0x006E8998 File Offset: 0x006E6B98
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerMobile As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(29)
			End Get
		End Property

		' Token: 0x17003B4F RID: 15183
		' (get) Token: 0x06009CB3 RID: 40115 RVA: 0x006E89BC File Offset: 0x006E6BBC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(30)
			End Get
		End Property

		' Token: 0x17003B50 RID: 15184
		' (get) Token: 0x06009CB4 RID: 40116 RVA: 0x006E89E0 File Offset: 0x006E6BE0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(31)
			End Get
		End Property

		' Token: 0x17003B51 RID: 15185
		' (get) Token: 0x06009CB5 RID: 40117 RVA: 0x006E8A04 File Offset: 0x006E6C04
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerBalance As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(32)
			End Get
		End Property

		' Token: 0x17003B52 RID: 15186
		' (get) Token: 0x06009CB6 RID: 40118 RVA: 0x006E8A28 File Offset: 0x006E6C28
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(33)
			End Get
		End Property

		' Token: 0x17003B53 RID: 15187
		' (get) Token: 0x06009CB7 RID: 40119 RVA: 0x006E8A4C File Offset: 0x006E6C4C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_SGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(34)
			End Get
		End Property

		' Token: 0x17003B54 RID: 15188
		' (get) Token: 0x06009CB8 RID: 40120 RVA: 0x006E8A70 File Offset: 0x006E6C70
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_IGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(35)
			End Get
		End Property

		' Token: 0x17003B55 RID: 15189
		' (get) Token: 0x06009CB9 RID: 40121 RVA: 0x006E8A94 File Offset: 0x006E6C94
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CESSTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(36)
			End Get
		End Property

		' Token: 0x17003B56 RID: 15190
		' (get) Token: 0x06009CBA RID: 40122 RVA: 0x006E8AB8 File Offset: 0x006E6CB8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Transport As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(37)
			End Get
		End Property

		' Token: 0x17003B57 RID: 15191
		' (get) Token: 0x06009CBB RID: 40123 RVA: 0x006E8ADC File Offset: 0x006E6CDC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_UPI As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(38)
			End Get
		End Property

		' Token: 0x17003B58 RID: 15192
		' (get) Token: 0x06009CBC RID: 40124 RVA: 0x006E8B00 File Offset: 0x006E6D00
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Naration As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(39)
			End Get
		End Property

		' Token: 0x17003B59 RID: 15193
		' (get) Token: 0x06009CBD RID: 40125 RVA: 0x006E8B24 File Offset: 0x006E6D24
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Coupon As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(40)
			End Get
		End Property

		' Token: 0x17003B5A RID: 15194
		' (get) Token: 0x06009CBE RID: 40126 RVA: 0x006E8B48 File Offset: 0x006E6D48
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_ByReturn As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(41)
			End Get
		End Property
	End Class
End Namespace
