Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005AF RID: 1455
	Public Class rptGSTReport
		Inherits ReportClass

		' Token: 0x17006E51 RID: 28241
		' (get) Token: 0x06011C20 RID: 72736 RVA: 0x00A4037C File Offset: 0x00A3E57C
		' (set) Token: 0x06011C21 RID: 72737 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptGSTReport.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006E52 RID: 28242
		' (get) Token: 0x06011C22 RID: 72738 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011C23 RID: 72739 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E53 RID: 28243
		' (get) Token: 0x06011C24 RID: 72740 RVA: 0x00A40394 File Offset: 0x00A3E594
		' (set) Token: 0x06011C25 RID: 72741 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptGSTReport.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006E54 RID: 28244
		' (get) Token: 0x06011C26 RID: 72742 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006E55 RID: 28245
		' (get) Token: 0x06011C27 RID: 72743 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006E56 RID: 28246
		' (get) Token: 0x06011C28 RID: 72744 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006E57 RID: 28247
		' (get) Token: 0x06011C29 RID: 72745 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006E58 RID: 28248
		' (get) Token: 0x06011C2A RID: 72746 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006E59 RID: 28249
		' (get) Token: 0x06011C2B RID: 72747 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006E5A RID: 28250
		' (get) Token: 0x06011C2C RID: 72748 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
