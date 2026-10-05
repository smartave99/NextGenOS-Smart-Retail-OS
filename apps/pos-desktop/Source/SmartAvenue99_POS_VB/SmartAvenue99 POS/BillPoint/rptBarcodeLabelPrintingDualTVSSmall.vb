Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000489 RID: 1161
	Public Class rptBarcodeLabelPrintingDualTVSSmall
		Inherits ReportClass

		' Token: 0x170059DC RID: 23004
		' (get) Token: 0x0600E9C8 RID: 59848 RVA: 0x008D9480 File Offset: 0x008D7680
		' (set) Token: 0x0600E9C9 RID: 59849 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBarcodeLabelPrintingDualTVSSmall.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059DD RID: 23005
		' (get) Token: 0x0600E9CA RID: 59850 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E9CB RID: 59851 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059DE RID: 23006
		' (get) Token: 0x0600E9CC RID: 59852 RVA: 0x008D9498 File Offset: 0x008D7698
		' (set) Token: 0x0600E9CD RID: 59853 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBarcodeLabelPrintingDualTVSSmall.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059DF RID: 23007
		' (get) Token: 0x0600E9CE RID: 59854 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170059E0 RID: 23008
		' (get) Token: 0x0600E9CF RID: 59855 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170059E1 RID: 23009
		' (get) Token: 0x0600E9D0 RID: 59856 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170059E2 RID: 23010
		' (get) Token: 0x0600E9D1 RID: 59857 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170059E3 RID: 23011
		' (get) Token: 0x0600E9D2 RID: 59858 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170059E4 RID: 23012
		' (get) Token: 0x0600E9D3 RID: 59859 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
