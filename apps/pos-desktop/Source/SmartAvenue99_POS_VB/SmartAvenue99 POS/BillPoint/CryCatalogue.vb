Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200031F RID: 799
	Public Class CryCatalogue
		Inherits ReportClass

		' Token: 0x17004B5B RID: 19291
		' (get) Token: 0x0600BD1D RID: 48413 RVA: 0x00790318 File Offset: 0x0078E518
		' (set) Token: 0x0600BD1E RID: 48414 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "CryCatalogue.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B5C RID: 19292
		' (get) Token: 0x0600BD1F RID: 48415 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BD20 RID: 48416 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B5D RID: 19293
		' (get) Token: 0x0600BD21 RID: 48417 RVA: 0x00790330 File Offset: 0x0078E530
		' (set) Token: 0x0600BD22 RID: 48418 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.CryCatalogue.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B5E RID: 19294
		' (get) Token: 0x0600BD23 RID: 48419 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004B5F RID: 19295
		' (get) Token: 0x0600BD24 RID: 48420 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004B60 RID: 19296
		' (get) Token: 0x0600BD25 RID: 48421 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004B61 RID: 19297
		' (get) Token: 0x0600BD26 RID: 48422 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004B62 RID: 19298
		' (get) Token: 0x0600BD27 RID: 48423 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004B63 RID: 19299
		' (get) Token: 0x0600BD28 RID: 48424 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17004B64 RID: 19300
		' (get) Token: 0x0600BD29 RID: 48425 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17004B65 RID: 19301
		' (get) Token: 0x0600BD2A RID: 48426 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17004B66 RID: 19302
		' (get) Token: 0x0600BD2B RID: 48427 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17004B67 RID: 19303
		' (get) Token: 0x0600BD2C RID: 48428 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x17004B68 RID: 19304
		' (get) Token: 0x0600BD2D RID: 48429 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P6 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property
	End Class
End Namespace
