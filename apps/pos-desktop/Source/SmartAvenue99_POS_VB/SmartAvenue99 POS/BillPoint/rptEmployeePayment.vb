Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000506 RID: 1286
	Public Class rptEmployeePayment
		Inherits ReportClass

		' Token: 0x170063F4 RID: 25588
		' (get) Token: 0x06010517 RID: 66839 RVA: 0x009AFA04 File Offset: 0x009ADC04
		' (set) Token: 0x06010518 RID: 66840 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptEmployeePayment.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063F5 RID: 25589
		' (get) Token: 0x06010519 RID: 66841 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601051A RID: 66842 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063F6 RID: 25590
		' (get) Token: 0x0601051B RID: 66843 RVA: 0x009AFA1C File Offset: 0x009ADC1C
		' (set) Token: 0x0601051C RID: 66844 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptEmployeePayment.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063F7 RID: 25591
		' (get) Token: 0x0601051D RID: 66845 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170063F8 RID: 25592
		' (get) Token: 0x0601051E RID: 66846 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170063F9 RID: 25593
		' (get) Token: 0x0601051F RID: 66847 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170063FA RID: 25594
		' (get) Token: 0x06010520 RID: 66848 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection2 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170063FB RID: 25595
		' (get) Token: 0x06010521 RID: 66849 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170063FC RID: 25596
		' (get) Token: 0x06010522 RID: 66850 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection2 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x170063FD RID: 25597
		' (get) Token: 0x06010523 RID: 66851 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x170063FE RID: 25598
		' (get) Token: 0x06010524 RID: 66852 RVA: 0x00770D64 File Offset: 0x0076EF64
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(7)
			End Get
		End Property

		' Token: 0x170063FF RID: 25599
		' (get) Token: 0x06010525 RID: 66853 RVA: 0x00771678 File Offset: 0x0076F878
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(8)
			End Get
		End Property

		' Token: 0x17006400 RID: 25600
		' (get) Token: 0x06010526 RID: 66854 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_v2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006401 RID: 25601
		' (get) Token: 0x06010527 RID: 66855 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_v1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
