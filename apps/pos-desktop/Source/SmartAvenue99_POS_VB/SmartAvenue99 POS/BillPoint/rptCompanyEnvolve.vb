Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x02000502 RID: 1282
	Public Class rptCompanyEnvolve
		Inherits ReportClass

		' Token: 0x170063DC RID: 25564
		' (get) Token: 0x060104EB RID: 66795 RVA: 0x009AF954 File Offset: 0x009ADB54
		' (set) Token: 0x060104EC RID: 66796 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptCompanyEnvolve.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063DD RID: 25565
		' (get) Token: 0x060104ED RID: 66797 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060104EE RID: 66798 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063DE RID: 25566
		' (get) Token: 0x060104EF RID: 66799 RVA: 0x009AF96C File Offset: 0x009ADB6C
		' (set) Token: 0x060104F0 RID: 66800 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptCompanyEnvolve.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063DF RID: 25567
		' (get) Token: 0x060104F1 RID: 66801 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170063E0 RID: 25568
		' (get) Token: 0x060104F2 RID: 66802 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170063E1 RID: 25569
		' (get) Token: 0x060104F3 RID: 66803 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170063E2 RID: 25570
		' (get) Token: 0x060104F4 RID: 66804 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170063E3 RID: 25571
		' (get) Token: 0x060104F5 RID: 66805 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property
	End Class
End Namespace
