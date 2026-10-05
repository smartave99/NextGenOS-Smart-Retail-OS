Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200057A RID: 1402
	Public Class rptBestSellingItems
		Inherits ReportClass

		' Token: 0x170069B1 RID: 27057
		' (get) Token: 0x060110B2 RID: 69810 RVA: 0x009E3FD0 File Offset: 0x009E21D0
		' (set) Token: 0x060110B3 RID: 69811 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBestSellingItems.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170069B2 RID: 27058
		' (get) Token: 0x060110B4 RID: 69812 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060110B5 RID: 69813 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170069B3 RID: 27059
		' (get) Token: 0x060110B6 RID: 69814 RVA: 0x009E3FE8 File Offset: 0x009E21E8
		' (set) Token: 0x060110B7 RID: 69815 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBestSellingItems.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170069B4 RID: 27060
		' (get) Token: 0x060110B8 RID: 69816 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170069B5 RID: 27061
		' (get) Token: 0x060110B9 RID: 69817 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170069B6 RID: 27062
		' (get) Token: 0x060110BA RID: 69818 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170069B7 RID: 27063
		' (get) Token: 0x060110BB RID: 69819 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170069B8 RID: 27064
		' (get) Token: 0x060110BC RID: 69820 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170069B9 RID: 27065
		' (get) Token: 0x060110BD RID: 69821 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
