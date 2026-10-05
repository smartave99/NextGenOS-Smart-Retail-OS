Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005AB RID: 1451
	Public Class rptSalesmanCommission
		Inherits ReportClass

		' Token: 0x17006E35 RID: 28213
		' (get) Token: 0x06011BF0 RID: 72688 RVA: 0x00A402CC File Offset: 0x00A3E4CC
		' (set) Token: 0x06011BF1 RID: 72689 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptSalesmanCommission.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006E36 RID: 28214
		' (get) Token: 0x06011BF2 RID: 72690 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011BF3 RID: 72691 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E37 RID: 28215
		' (get) Token: 0x06011BF4 RID: 72692 RVA: 0x00A402E4 File Offset: 0x00A3E4E4
		' (set) Token: 0x06011BF5 RID: 72693 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptSalesmanCommission.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006E38 RID: 28216
		' (get) Token: 0x06011BF6 RID: 72694 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006E39 RID: 28217
		' (get) Token: 0x06011BF7 RID: 72695 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006E3A RID: 28218
		' (get) Token: 0x06011BF8 RID: 72696 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006E3B RID: 28219
		' (get) Token: 0x06011BF9 RID: 72697 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006E3C RID: 28220
		' (get) Token: 0x06011BFA RID: 72698 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006E3D RID: 28221
		' (get) Token: 0x06011BFB RID: 72699 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006E3E RID: 28222
		' (get) Token: 0x06011BFC RID: 72700 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
