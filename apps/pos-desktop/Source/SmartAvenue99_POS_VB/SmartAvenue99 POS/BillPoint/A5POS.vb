Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000234 RID: 564
	Public Class A5POS
		Inherits ReportClass

		' Token: 0x17003B88 RID: 15240
		' (get) Token: 0x06009CFD RID: 40189 RVA: 0x006E8F58 File Offset: 0x006E7158
		' (set) Token: 0x06009CFE RID: 40190 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "A5POS.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003B89 RID: 15241
		' (get) Token: 0x06009CFF RID: 40191 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009D00 RID: 40192 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003B8A RID: 15242
		' (get) Token: 0x06009D01 RID: 40193 RVA: 0x006E8F70 File Offset: 0x006E7170
		' (set) Token: 0x06009D02 RID: 40194 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.A5POS.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003B8B RID: 15243
		' (get) Token: 0x06009D03 RID: 40195 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17003B8C RID: 15244
		' (get) Token: 0x06009D04 RID: 40196 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17003B8D RID: 15245
		' (get) Token: 0x06009D05 RID: 40197 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17003B8E RID: 15246
		' (get) Token: 0x06009D06 RID: 40198 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17003B8F RID: 15247
		' (get) Token: 0x06009D07 RID: 40199 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17003B90 RID: 15248
		' (get) Token: 0x06009D08 RID: 40200 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PaidAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17003B91 RID: 15249
		' (get) Token: 0x06009D09 RID: 40201 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17003B92 RID: 15250
		' (get) Token: 0x06009D0A RID: 40202 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17003B93 RID: 15251
		' (get) Token: 0x06009D0B RID: 40203 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17003B94 RID: 15252
		' (get) Token: 0x06009D0C RID: 40204 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PendingAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17003B95 RID: 15253
		' (get) Token: 0x06009D0D RID: 40205 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x17003B96 RID: 15254
		' (get) Token: 0x06009D0E RID: 40206 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_RefundAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x17003B97 RID: 15255
		' (get) Token: 0x06009D0F RID: 40207 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x17003B98 RID: 15256
		' (get) Token: 0x06009D10 RID: 40208 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x17003B99 RID: 15257
		' (get) Token: 0x06009D11 RID: 40209 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TendAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property

		' Token: 0x17003B9A RID: 15258
		' (get) Token: 0x06009D12 RID: 40210 RVA: 0x006E86EC File Offset: 0x006E68EC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P10 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(10)
			End Get
		End Property

		' Token: 0x17003B9B RID: 15259
		' (get) Token: 0x06009D13 RID: 40211 RVA: 0x006E8710 File Offset: 0x006E6910
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Sundry As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(11)
			End Get
		End Property

		' Token: 0x17003B9C RID: 15260
		' (get) Token: 0x06009D14 RID: 40212 RVA: 0x006E8734 File Offset: 0x006E6934
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Discount As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(12)
			End Get
		End Property

		' Token: 0x17003B9D RID: 15261
		' (get) Token: 0x06009D15 RID: 40213 RVA: 0x006E8758 File Offset: 0x006E6958
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Grand_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(13)
			End Get
		End Property

		' Token: 0x17003B9E RID: 15262
		' (get) Token: 0x06009D16 RID: 40214 RVA: 0x006E877C File Offset: 0x006E697C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Roundoff As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(14)
			End Get
		End Property

		' Token: 0x17003B9F RID: 15263
		' (get) Token: 0x06009D17 RID: 40215 RVA: 0x006E87A0 File Offset: 0x006E69A0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Net_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(15)
			End Get
		End Property

		' Token: 0x17003BA0 RID: 15264
		' (get) Token: 0x06009D18 RID: 40216 RVA: 0x006E87C4 File Offset: 0x006E69C4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Invoice_No As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(16)
			End Get
		End Property

		' Token: 0x17003BA1 RID: 15265
		' (get) Token: 0x06009D19 RID: 40217 RVA: 0x006E87E8 File Offset: 0x006E69E8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Date As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(17)
			End Get
		End Property

		' Token: 0x17003BA2 RID: 15266
		' (get) Token: 0x06009D1A RID: 40218 RVA: 0x006E880C File Offset: 0x006E6A0C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Tax_Type As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(18)
			End Get
		End Property

		' Token: 0x17003BA3 RID: 15267
		' (get) Token: 0x06009D1B RID: 40219 RVA: 0x006E8830 File Offset: 0x006E6A30
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_EWay As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(19)
			End Get
		End Property

		' Token: 0x17003BA4 RID: 15268
		' (get) Token: 0x06009D1C RID: 40220 RVA: 0x006E8854 File Offset: 0x006E6A54
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Salesman As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(20)
			End Get
		End Property

		' Token: 0x17003BA5 RID: 15269
		' (get) Token: 0x06009D1D RID: 40221 RVA: 0x006E8878 File Offset: 0x006E6A78
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Company As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(21)
			End Get
		End Property

		' Token: 0x17003BA6 RID: 15270
		' (get) Token: 0x06009D1E RID: 40222 RVA: 0x006E889C File Offset: 0x006E6A9C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(22)
			End Get
		End Property

		' Token: 0x17003BA7 RID: 15271
		' (get) Token: 0x06009D1F RID: 40223 RVA: 0x006E88C0 File Offset: 0x006E6AC0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompContact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(23)
			End Get
		End Property

		' Token: 0x17003BA8 RID: 15272
		' (get) Token: 0x06009D20 RID: 40224 RVA: 0x006E88E4 File Offset: 0x006E6AE4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompEmail As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(24)
			End Get
		End Property

		' Token: 0x17003BA9 RID: 15273
		' (get) Token: 0x06009D21 RID: 40225 RVA: 0x006E8908 File Offset: 0x006E6B08
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(25)
			End Get
		End Property

		' Token: 0x17003BAA RID: 15274
		' (get) Token: 0x06009D22 RID: 40226 RVA: 0x006E892C File Offset: 0x006E6B2C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(26)
			End Get
		End Property

		' Token: 0x17003BAB RID: 15275
		' (get) Token: 0x06009D23 RID: 40227 RVA: 0x006E8950 File Offset: 0x006E6B50
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(27)
			End Get
		End Property

		' Token: 0x17003BAC RID: 15276
		' (get) Token: 0x06009D24 RID: 40228 RVA: 0x006E8974 File Offset: 0x006E6B74
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerName As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(28)
			End Get
		End Property

		' Token: 0x17003BAD RID: 15277
		' (get) Token: 0x06009D25 RID: 40229 RVA: 0x006E8998 File Offset: 0x006E6B98
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerMobile As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(29)
			End Get
		End Property

		' Token: 0x17003BAE RID: 15278
		' (get) Token: 0x06009D26 RID: 40230 RVA: 0x006E89BC File Offset: 0x006E6BBC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(30)
			End Get
		End Property

		' Token: 0x17003BAF RID: 15279
		' (get) Token: 0x06009D27 RID: 40231 RVA: 0x006E89E0 File Offset: 0x006E6BE0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(31)
			End Get
		End Property

		' Token: 0x17003BB0 RID: 15280
		' (get) Token: 0x06009D28 RID: 40232 RVA: 0x006E8A04 File Offset: 0x006E6C04
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerBalance As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(32)
			End Get
		End Property

		' Token: 0x17003BB1 RID: 15281
		' (get) Token: 0x06009D29 RID: 40233 RVA: 0x006E8A28 File Offset: 0x006E6C28
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(33)
			End Get
		End Property

		' Token: 0x17003BB2 RID: 15282
		' (get) Token: 0x06009D2A RID: 40234 RVA: 0x006E8A4C File Offset: 0x006E6C4C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_SGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(34)
			End Get
		End Property

		' Token: 0x17003BB3 RID: 15283
		' (get) Token: 0x06009D2B RID: 40235 RVA: 0x006E8A70 File Offset: 0x006E6C70
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_IGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(35)
			End Get
		End Property

		' Token: 0x17003BB4 RID: 15284
		' (get) Token: 0x06009D2C RID: 40236 RVA: 0x006E8A94 File Offset: 0x006E6C94
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CESSTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(36)
			End Get
		End Property

		' Token: 0x17003BB5 RID: 15285
		' (get) Token: 0x06009D2D RID: 40237 RVA: 0x006E8AB8 File Offset: 0x006E6CB8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Transport As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(37)
			End Get
		End Property

		' Token: 0x17003BB6 RID: 15286
		' (get) Token: 0x06009D2E RID: 40238 RVA: 0x006E8ADC File Offset: 0x006E6CDC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_UPI As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(38)
			End Get
		End Property

		' Token: 0x17003BB7 RID: 15287
		' (get) Token: 0x06009D2F RID: 40239 RVA: 0x006E8B00 File Offset: 0x006E6D00
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Naration As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(39)
			End Get
		End Property

		' Token: 0x17003BB8 RID: 15288
		' (get) Token: 0x06009D30 RID: 40240 RVA: 0x006E8B24 File Offset: 0x006E6D24
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Coupon As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(40)
			End Get
		End Property

		' Token: 0x17003BB9 RID: 15289
		' (get) Token: 0x06009D31 RID: 40241 RVA: 0x006E8B48 File Offset: 0x006E6D48
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_ByReturn As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(41)
			End Get
		End Property

		' Token: 0x17003BBA RID: 15290
		' (get) Token: 0x06009D32 RID: 40242 RVA: 0x006E8CFC File Offset: 0x006E6EFC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_LoyalityReedemPoints As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(42)
			End Get
		End Property

		' Token: 0x17003BBB RID: 15291
		' (get) Token: 0x06009D33 RID: 40243 RVA: 0x006E8F88 File Offset: 0x006E7188
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_LoyalityReedemAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(43)
			End Get
		End Property

		' Token: 0x17003BBC RID: 15292
		' (get) Token: 0x06009D34 RID: 40244 RVA: 0x006E8FAC File Offset: 0x006E71AC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TotalLoyalityPoints As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(44)
			End Get
		End Property

		' Token: 0x17003BBD RID: 15293
		' (get) Token: 0x06009D35 RID: 40245 RVA: 0x006E8FD0 File Offset: 0x006E71D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_LoyalityBalance As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(45)
			End Get
		End Property
	End Class
End Namespace
