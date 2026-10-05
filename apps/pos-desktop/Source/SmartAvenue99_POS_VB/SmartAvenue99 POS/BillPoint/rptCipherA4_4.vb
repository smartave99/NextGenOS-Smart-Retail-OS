Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002B7 RID: 695
	Public Class rptCipherA4_4
		Inherits ReportClass

		' Token: 0x17004504 RID: 17668
		' (get) Token: 0x0600B28F RID: 45711 RVA: 0x00770C2C File Offset: 0x0076EE2C
		' (set) Token: 0x0600B290 RID: 45712 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptCipherA4_4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004505 RID: 17669
		' (get) Token: 0x0600B291 RID: 45713 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B292 RID: 45714 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004506 RID: 17670
		' (get) Token: 0x0600B293 RID: 45715 RVA: 0x00770C44 File Offset: 0x0076EE44
		' (set) Token: 0x0600B294 RID: 45716 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptCipherA4_4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004507 RID: 17671
		' (get) Token: 0x0600B295 RID: 45717 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004508 RID: 17672
		' (get) Token: 0x0600B296 RID: 45718 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004509 RID: 17673
		' (get) Token: 0x0600B297 RID: 45719 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700450A RID: 17674
		' (get) Token: 0x0600B298 RID: 45720 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700450B RID: 17675
		' (get) Token: 0x0600B299 RID: 45721 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700450C RID: 17676
		' (get) Token: 0x0600B29A RID: 45722 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
