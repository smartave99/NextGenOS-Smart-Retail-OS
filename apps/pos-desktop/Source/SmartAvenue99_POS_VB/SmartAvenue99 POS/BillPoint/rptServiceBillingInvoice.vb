Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005CA RID: 1482
	Public Class rptServiceBillingInvoice
		Inherits ReportClass

		' Token: 0x1700700D RID: 28685
		' (get) Token: 0x060120B6 RID: 73910 RVA: 0x00A63CE8 File Offset: 0x00A61EE8
		' (set) Token: 0x060120B7 RID: 73911 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptServiceBillingInvoice.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700700E RID: 28686
		' (get) Token: 0x060120B8 RID: 73912 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060120B9 RID: 73913 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700700F RID: 28687
		' (get) Token: 0x060120BA RID: 73914 RVA: 0x00A63D00 File Offset: 0x00A61F00
		' (set) Token: 0x060120BB RID: 73915 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptServiceBillingInvoice.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17007010 RID: 28688
		' (get) Token: 0x060120BC RID: 73916 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17007011 RID: 28689
		' (get) Token: 0x060120BD RID: 73917 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17007012 RID: 28690
		' (get) Token: 0x060120BE RID: 73918 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17007013 RID: 28691
		' (get) Token: 0x060120BF RID: 73919 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17007014 RID: 28692
		' (get) Token: 0x060120C0 RID: 73920 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17007015 RID: 28693
		' (get) Token: 0x060120C1 RID: 73921 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17007016 RID: 28694
		' (get) Token: 0x060120C2 RID: 73922 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17007017 RID: 28695
		' (get) Token: 0x060120C3 RID: 73923 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_0 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
