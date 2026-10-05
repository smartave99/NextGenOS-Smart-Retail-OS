Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000321 RID: 801
	Public Class CryToken
		Inherits ReportClass

		' Token: 0x17004B6C RID: 19308
		' (get) Token: 0x0600BD38 RID: 48440 RVA: 0x00790370 File Offset: 0x0078E570
		' (set) Token: 0x0600BD39 RID: 48441 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "CryToken.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B6D RID: 19309
		' (get) Token: 0x0600BD3A RID: 48442 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BD3B RID: 48443 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B6E RID: 19310
		' (get) Token: 0x0600BD3C RID: 48444 RVA: 0x00790388 File Offset: 0x0078E588
		' (set) Token: 0x0600BD3D RID: 48445 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.CryToken.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B6F RID: 19311
		' (get) Token: 0x0600BD3E RID: 48446 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004B70 RID: 19312
		' (get) Token: 0x0600BD3F RID: 48447 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004B71 RID: 19313
		' (get) Token: 0x0600BD40 RID: 48448 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004B72 RID: 19314
		' (get) Token: 0x0600BD41 RID: 48449 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004B73 RID: 19315
		' (get) Token: 0x0600BD42 RID: 48450 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004B74 RID: 19316
		' (get) Token: 0x0600BD43 RID: 48451 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17004B75 RID: 19317
		' (get) Token: 0x0600BD44 RID: 48452 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17004B76 RID: 19318
		' (get) Token: 0x0600BD45 RID: 48453 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x17004B77 RID: 19319
		' (get) Token: 0x0600BD46 RID: 48454 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x17004B78 RID: 19320
		' (get) Token: 0x0600BD47 RID: 48455 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property
	End Class
End Namespace
