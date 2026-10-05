Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000516 RID: 1302
	Public Class rptPurchaseC3
		Inherits ReportClass

		' Token: 0x1700648B RID: 25739
		' (get) Token: 0x060105FE RID: 67070 RVA: 0x009AFCC4 File Offset: 0x009ADEC4
		' (set) Token: 0x060105FF RID: 67071 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptPurchaseC3.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700648C RID: 25740
		' (get) Token: 0x06010600 RID: 67072 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010601 RID: 67073 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700648D RID: 25741
		' (get) Token: 0x06010602 RID: 67074 RVA: 0x009AFCDC File Offset: 0x009ADEDC
		' (set) Token: 0x06010603 RID: 67075 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptPurchaseC3.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700648E RID: 25742
		' (get) Token: 0x06010604 RID: 67076 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700648F RID: 25743
		' (get) Token: 0x06010605 RID: 67077 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006490 RID: 25744
		' (get) Token: 0x06010606 RID: 67078 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006491 RID: 25745
		' (get) Token: 0x06010607 RID: 67079 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property DetailSection2 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006492 RID: 25746
		' (get) Token: 0x06010608 RID: 67080 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006493 RID: 25747
		' (get) Token: 0x06010609 RID: 67081 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006494 RID: 25748
		' (get) Token: 0x0601060A RID: 67082 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006495 RID: 25749
		' (get) Token: 0x0601060B RID: 67083 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17006496 RID: 25750
		' (get) Token: 0x0601060C RID: 67084 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p6 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
