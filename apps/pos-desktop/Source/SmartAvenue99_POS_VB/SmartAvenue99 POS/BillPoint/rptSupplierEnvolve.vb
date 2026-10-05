Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x02000536 RID: 1334
	Public Class rptSupplierEnvolve
		Inherits ReportClass

		' Token: 0x170065D7 RID: 26071
		' (get) Token: 0x060107EA RID: 67562 RVA: 0x009B0244 File Offset: 0x009AE444
		' (set) Token: 0x060107EB RID: 67563 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptSupplierEnvolve.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170065D8 RID: 26072
		' (get) Token: 0x060107EC RID: 67564 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060107ED RID: 67565 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065D9 RID: 26073
		' (get) Token: 0x060107EE RID: 67566 RVA: 0x009B025C File Offset: 0x009AE45C
		' (set) Token: 0x060107EF RID: 67567 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptSupplierEnvolve.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170065DA RID: 26074
		' (get) Token: 0x060107F0 RID: 67568 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170065DB RID: 26075
		' (get) Token: 0x060107F1 RID: 67569 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170065DC RID: 26076
		' (get) Token: 0x060107F2 RID: 67570 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170065DD RID: 26077
		' (get) Token: 0x060107F3 RID: 67571 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170065DE RID: 26078
		' (get) Token: 0x060107F4 RID: 67572 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property
	End Class
End Namespace
