Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000236 RID: 566
	Public Class A4POS
		Inherits ReportClass

		' Token: 0x17003BC1 RID: 15297
		' (get) Token: 0x06009D40 RID: 40256 RVA: 0x006E901C File Offset: 0x006E721C
		' (set) Token: 0x06009D41 RID: 40257 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "A4POS.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003BC2 RID: 15298
		' (get) Token: 0x06009D42 RID: 40258 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06009D43 RID: 40259 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003BC3 RID: 15299
		' (get) Token: 0x06009D44 RID: 40260 RVA: 0x006E9034 File Offset: 0x006E7234
		' (set) Token: 0x06009D45 RID: 40261 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.A4POS.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003BC4 RID: 15300
		' (get) Token: 0x06009D46 RID: 40262 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17003BC5 RID: 15301
		' (get) Token: 0x06009D47 RID: 40263 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17003BC6 RID: 15302
		' (get) Token: 0x06009D48 RID: 40264 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17003BC7 RID: 15303
		' (get) Token: 0x06009D49 RID: 40265 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property DetailSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17003BC8 RID: 15304
		' (get) Token: 0x06009D4A RID: 40266 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17003BC9 RID: 15305
		' (get) Token: 0x06009D4B RID: 40267 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17003BCA RID: 15306
		' (get) Token: 0x06009D4C RID: 40268 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PaidAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17003BCB RID: 15307
		' (get) Token: 0x06009D4D RID: 40269 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17003BCC RID: 15308
		' (get) Token: 0x06009D4E RID: 40270 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17003BCD RID: 15309
		' (get) Token: 0x06009D4F RID: 40271 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17003BCE RID: 15310
		' (get) Token: 0x06009D50 RID: 40272 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_PendingAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17003BCF RID: 15311
		' (get) Token: 0x06009D51 RID: 40273 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x17003BD0 RID: 15312
		' (get) Token: 0x06009D52 RID: 40274 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_RefundAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x17003BD1 RID: 15313
		' (get) Token: 0x06009D53 RID: 40275 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x17003BD2 RID: 15314
		' (get) Token: 0x06009D54 RID: 40276 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property

		' Token: 0x17003BD3 RID: 15315
		' (get) Token: 0x06009D55 RID: 40277 RVA: 0x006E86C8 File Offset: 0x006E68C8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TendAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(9)
			End Get
		End Property

		' Token: 0x17003BD4 RID: 15316
		' (get) Token: 0x06009D56 RID: 40278 RVA: 0x006E86EC File Offset: 0x006E68EC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P10 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(10)
			End Get
		End Property

		' Token: 0x17003BD5 RID: 15317
		' (get) Token: 0x06009D57 RID: 40279 RVA: 0x006E8710 File Offset: 0x006E6910
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Sundry As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(11)
			End Get
		End Property

		' Token: 0x17003BD6 RID: 15318
		' (get) Token: 0x06009D58 RID: 40280 RVA: 0x006E8734 File Offset: 0x006E6934
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Bill_Discount As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(12)
			End Get
		End Property

		' Token: 0x17003BD7 RID: 15319
		' (get) Token: 0x06009D59 RID: 40281 RVA: 0x006E8758 File Offset: 0x006E6958
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Grand_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(13)
			End Get
		End Property

		' Token: 0x17003BD8 RID: 15320
		' (get) Token: 0x06009D5A RID: 40282 RVA: 0x006E877C File Offset: 0x006E697C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Roundoff As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(14)
			End Get
		End Property

		' Token: 0x17003BD9 RID: 15321
		' (get) Token: 0x06009D5B RID: 40283 RVA: 0x006E87A0 File Offset: 0x006E69A0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Net_Total As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(15)
			End Get
		End Property

		' Token: 0x17003BDA RID: 15322
		' (get) Token: 0x06009D5C RID: 40284 RVA: 0x006E87C4 File Offset: 0x006E69C4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Invoice_No As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(16)
			End Get
		End Property

		' Token: 0x17003BDB RID: 15323
		' (get) Token: 0x06009D5D RID: 40285 RVA: 0x006E87E8 File Offset: 0x006E69E8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Date As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(17)
			End Get
		End Property

		' Token: 0x17003BDC RID: 15324
		' (get) Token: 0x06009D5E RID: 40286 RVA: 0x006E880C File Offset: 0x006E6A0C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Tax_Type As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(18)
			End Get
		End Property

		' Token: 0x17003BDD RID: 15325
		' (get) Token: 0x06009D5F RID: 40287 RVA: 0x006E8830 File Offset: 0x006E6A30
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_EWay As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(19)
			End Get
		End Property

		' Token: 0x17003BDE RID: 15326
		' (get) Token: 0x06009D60 RID: 40288 RVA: 0x006E8854 File Offset: 0x006E6A54
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Salesman As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(20)
			End Get
		End Property

		' Token: 0x17003BDF RID: 15327
		' (get) Token: 0x06009D61 RID: 40289 RVA: 0x006E8878 File Offset: 0x006E6A78
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Company As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(21)
			End Get
		End Property

		' Token: 0x17003BE0 RID: 15328
		' (get) Token: 0x06009D62 RID: 40290 RVA: 0x006E889C File Offset: 0x006E6A9C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(22)
			End Get
		End Property

		' Token: 0x17003BE1 RID: 15329
		' (get) Token: 0x06009D63 RID: 40291 RVA: 0x006E88C0 File Offset: 0x006E6AC0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompContact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(23)
			End Get
		End Property

		' Token: 0x17003BE2 RID: 15330
		' (get) Token: 0x06009D64 RID: 40292 RVA: 0x006E88E4 File Offset: 0x006E6AE4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompEmail As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(24)
			End Get
		End Property

		' Token: 0x17003BE3 RID: 15331
		' (get) Token: 0x06009D65 RID: 40293 RVA: 0x006E8908 File Offset: 0x006E6B08
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(25)
			End Get
		End Property

		' Token: 0x17003BE4 RID: 15332
		' (get) Token: 0x06009D66 RID: 40294 RVA: 0x006E892C File Offset: 0x006E6B2C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CompState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(26)
			End Get
		End Property

		' Token: 0x17003BE5 RID: 15333
		' (get) Token: 0x06009D67 RID: 40295 RVA: 0x006E8950 File Offset: 0x006E6B50
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerAddress As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(27)
			End Get
		End Property

		' Token: 0x17003BE6 RID: 15334
		' (get) Token: 0x06009D68 RID: 40296 RVA: 0x006E8974 File Offset: 0x006E6B74
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerName As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(28)
			End Get
		End Property

		' Token: 0x17003BE7 RID: 15335
		' (get) Token: 0x06009D69 RID: 40297 RVA: 0x006E8998 File Offset: 0x006E6B98
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerMobile As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(29)
			End Get
		End Property

		' Token: 0x17003BE8 RID: 15336
		' (get) Token: 0x06009D6A RID: 40298 RVA: 0x006E89BC File Offset: 0x006E6BBC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerGSTIN As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(30)
			End Get
		End Property

		' Token: 0x17003BE9 RID: 15337
		' (get) Token: 0x06009D6B RID: 40299 RVA: 0x006E89E0 File Offset: 0x006E6BE0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerState As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(31)
			End Get
		End Property

		' Token: 0x17003BEA RID: 15338
		' (get) Token: 0x06009D6C RID: 40300 RVA: 0x006E8A04 File Offset: 0x006E6C04
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CustomerBalance As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(32)
			End Get
		End Property

		' Token: 0x17003BEB RID: 15339
		' (get) Token: 0x06009D6D RID: 40301 RVA: 0x006E8A28 File Offset: 0x006E6C28
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(33)
			End Get
		End Property

		' Token: 0x17003BEC RID: 15340
		' (get) Token: 0x06009D6E RID: 40302 RVA: 0x006E8A4C File Offset: 0x006E6C4C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_SGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(34)
			End Get
		End Property

		' Token: 0x17003BED RID: 15341
		' (get) Token: 0x06009D6F RID: 40303 RVA: 0x006E8A70 File Offset: 0x006E6C70
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_IGSTTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(35)
			End Get
		End Property

		' Token: 0x17003BEE RID: 15342
		' (get) Token: 0x06009D70 RID: 40304 RVA: 0x006E8A94 File Offset: 0x006E6C94
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_CESSTot As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(36)
			End Get
		End Property

		' Token: 0x17003BEF RID: 15343
		' (get) Token: 0x06009D71 RID: 40305 RVA: 0x006E8AB8 File Offset: 0x006E6CB8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Transport As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(37)
			End Get
		End Property

		' Token: 0x17003BF0 RID: 15344
		' (get) Token: 0x06009D72 RID: 40306 RVA: 0x006E8ADC File Offset: 0x006E6CDC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_UPI As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(38)
			End Get
		End Property

		' Token: 0x17003BF1 RID: 15345
		' (get) Token: 0x06009D73 RID: 40307 RVA: 0x006E8B00 File Offset: 0x006E6D00
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Naration As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(39)
			End Get
		End Property

		' Token: 0x17003BF2 RID: 15346
		' (get) Token: 0x06009D74 RID: 40308 RVA: 0x006E8B24 File Offset: 0x006E6D24
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Coupon As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(40)
			End Get
		End Property

		' Token: 0x17003BF3 RID: 15347
		' (get) Token: 0x06009D75 RID: 40309 RVA: 0x006E8B48 File Offset: 0x006E6D48
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_ByReturn As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(41)
			End Get
		End Property

		' Token: 0x17003BF4 RID: 15348
		' (get) Token: 0x06009D76 RID: 40310 RVA: 0x006E8CFC File Offset: 0x006E6EFC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_TotalLoyalityPoints As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(42)
			End Get
		End Property

		' Token: 0x17003BF5 RID: 15349
		' (get) Token: 0x06009D77 RID: 40311 RVA: 0x006E8F88 File Offset: 0x006E7188
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_LoyalityReedemAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(43)
			End Get
		End Property

		' Token: 0x17003BF6 RID: 15350
		' (get) Token: 0x06009D78 RID: 40312 RVA: 0x006E8FAC File Offset: 0x006E71AC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_LoyalityReedemPoints As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(44)
			End Get
		End Property

		' Token: 0x17003BF7 RID: 15351
		' (get) Token: 0x06009D79 RID: 40313 RVA: 0x006E8FD0 File Offset: 0x006E71D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_LoyalityBalance As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(45)
			End Get
		End Property
	End Class
End Namespace
