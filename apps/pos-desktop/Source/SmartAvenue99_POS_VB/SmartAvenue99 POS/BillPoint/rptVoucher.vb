Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x020005F9 RID: 1529
	Public Class rptVoucher
		Inherits ReportClass

		' Token: 0x170073C4 RID: 29636
		' (get) Token: 0x06012AAD RID: 76461 RVA: 0x00AB9798 File Offset: 0x00AB7998
		' (set) Token: 0x06012AAE RID: 76462 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptVoucher.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170073C5 RID: 29637
		' (get) Token: 0x06012AAF RID: 76463 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012AB0 RID: 76464 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073C6 RID: 29638
		' (get) Token: 0x06012AB1 RID: 76465 RVA: 0x00AB97B0 File Offset: 0x00AB79B0
		' (set) Token: 0x06012AB2 RID: 76466 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptVoucher.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170073C7 RID: 29639
		' (get) Token: 0x06012AB3 RID: 76467 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170073C8 RID: 29640
		' (get) Token: 0x06012AB4 RID: 76468 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170073C9 RID: 29641
		' (get) Token: 0x06012AB5 RID: 76469 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170073CA RID: 29642
		' (get) Token: 0x06012AB6 RID: 76470 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170073CB RID: 29643
		' (get) Token: 0x06012AB7 RID: 76471 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170073CC RID: 29644
		' (get) Token: 0x06012AB8 RID: 76472 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x170073CD RID: 29645
		' (get) Token: 0x06012AB9 RID: 76473 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property
	End Class
End Namespace
