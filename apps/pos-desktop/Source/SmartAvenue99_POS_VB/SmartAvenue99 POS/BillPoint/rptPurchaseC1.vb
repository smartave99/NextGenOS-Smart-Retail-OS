Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000564 RID: 1380
	Public Class rptPurchaseC1
		Inherits ReportClass

		' Token: 0x1700681A RID: 26650
		' (get) Token: 0x06010CE6 RID: 68838 RVA: 0x009CB3C0 File Offset: 0x009C95C0
		' (set) Token: 0x06010CE7 RID: 68839 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptPurchaseC1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700681B RID: 26651
		' (get) Token: 0x06010CE8 RID: 68840 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010CE9 RID: 68841 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700681C RID: 26652
		' (get) Token: 0x06010CEA RID: 68842 RVA: 0x009CB3D8 File Offset: 0x009C95D8
		' (set) Token: 0x06010CEB RID: 68843 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptPurchaseC1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700681D RID: 26653
		' (get) Token: 0x06010CEC RID: 68844 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700681E RID: 26654
		' (get) Token: 0x06010CED RID: 68845 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700681F RID: 26655
		' (get) Token: 0x06010CEE RID: 68846 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006820 RID: 26656
		' (get) Token: 0x06010CEF RID: 68847 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property DetailSection2 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006821 RID: 26657
		' (get) Token: 0x06010CF0 RID: 68848 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006822 RID: 26658
		' (get) Token: 0x06010CF1 RID: 68849 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006823 RID: 26659
		' (get) Token: 0x06010CF2 RID: 68850 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006824 RID: 26660
		' (get) Token: 0x06010CF3 RID: 68851 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17006825 RID: 26661
		' (get) Token: 0x06010CF4 RID: 68852 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p6 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
