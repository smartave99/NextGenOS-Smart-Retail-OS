Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020004F8 RID: 1272
	Public Class rptBanlLedger
		Inherits ReportClass

		' Token: 0x1700639E RID: 25502
		' (get) Token: 0x0601047B RID: 66683 RVA: 0x009AF79C File Offset: 0x009AD99C
		' (set) Token: 0x0601047C RID: 66684 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBanlLedger.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700639F RID: 25503
		' (get) Token: 0x0601047D RID: 66685 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601047E RID: 66686 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063A0 RID: 25504
		' (get) Token: 0x0601047F RID: 66687 RVA: 0x009AF7B4 File Offset: 0x009AD9B4
		' (set) Token: 0x06010480 RID: 66688 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBanlLedger.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063A1 RID: 25505
		' (get) Token: 0x06010481 RID: 66689 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170063A2 RID: 25506
		' (get) Token: 0x06010482 RID: 66690 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170063A3 RID: 25507
		' (get) Token: 0x06010483 RID: 66691 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170063A4 RID: 25508
		' (get) Token: 0x06010484 RID: 66692 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170063A5 RID: 25509
		' (get) Token: 0x06010485 RID: 66693 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170063A6 RID: 25510
		' (get) Token: 0x06010486 RID: 66694 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170063A7 RID: 25511
		' (get) Token: 0x06010487 RID: 66695 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
