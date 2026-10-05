Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x02000289 RID: 649
	Public Class CrystalReport1
		Inherits ReportClass

		' Token: 0x170040B3 RID: 16563
		' (get) Token: 0x0600A6D1 RID: 42705 RVA: 0x00700DA8 File Offset: 0x006FEFA8
		' (set) Token: 0x0600A6D2 RID: 42706 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "CrystalReport1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170040B4 RID: 16564
		' (get) Token: 0x0600A6D3 RID: 42707 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A6D4 RID: 42708 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170040B5 RID: 16565
		' (get) Token: 0x0600A6D5 RID: 42709 RVA: 0x00700DC0 File Offset: 0x006FEFC0
		' (set) Token: 0x0600A6D6 RID: 42710 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.CrystalReport1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170040B6 RID: 16566
		' (get) Token: 0x0600A6D7 RID: 42711 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170040B7 RID: 16567
		' (get) Token: 0x0600A6D8 RID: 42712 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170040B8 RID: 16568
		' (get) Token: 0x0600A6D9 RID: 42713 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170040B9 RID: 16569
		' (get) Token: 0x0600A6DA RID: 42714 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170040BA RID: 16570
		' (get) Token: 0x0600A6DB RID: 42715 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property
	End Class
End Namespace
