Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005EB RID: 1515
	Public Class rptSales
		Inherits ReportClass

		' Token: 0x17007361 RID: 29537
		' (get) Token: 0x06012A04 RID: 76292 RVA: 0x00AB9530 File Offset: 0x00AB7730
		' (set) Token: 0x06012A05 RID: 76293 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptSales.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17007362 RID: 29538
		' (get) Token: 0x06012A06 RID: 76294 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A07 RID: 76295 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007363 RID: 29539
		' (get) Token: 0x06012A08 RID: 76296 RVA: 0x00AB9548 File Offset: 0x00AB7748
		' (set) Token: 0x06012A09 RID: 76297 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptSales.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17007364 RID: 29540
		' (get) Token: 0x06012A0A RID: 76298 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17007365 RID: 29541
		' (get) Token: 0x06012A0B RID: 76299 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17007366 RID: 29542
		' (get) Token: 0x06012A0C RID: 76300 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17007367 RID: 29543
		' (get) Token: 0x06012A0D RID: 76301 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17007368 RID: 29544
		' (get) Token: 0x06012A0E RID: 76302 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17007369 RID: 29545
		' (get) Token: 0x06012A0F RID: 76303 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x1700736A RID: 29546
		' (get) Token: 0x06012A10 RID: 76304 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x1700736B RID: 29547
		' (get) Token: 0x06012A11 RID: 76305 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x1700736C RID: 29548
		' (get) Token: 0x06012A12 RID: 76306 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x1700736D RID: 29549
		' (get) Token: 0x06012A13 RID: 76307 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x1700736E RID: 29550
		' (get) Token: 0x06012A14 RID: 76308 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property
	End Class
End Namespace
