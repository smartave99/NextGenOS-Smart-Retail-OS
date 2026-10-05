Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x02000538 RID: 1336
	Public Class rptCustomerEnvolve
		Inherits ReportClass

		' Token: 0x170065E2 RID: 26082
		' (get) Token: 0x060107FF RID: 67583 RVA: 0x009B029C File Offset: 0x009AE49C
		' (set) Token: 0x06010800 RID: 67584 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptCustomerEnvolve.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170065E3 RID: 26083
		' (get) Token: 0x06010801 RID: 67585 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010802 RID: 67586 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170065E4 RID: 26084
		' (get) Token: 0x06010803 RID: 67587 RVA: 0x009B02B4 File Offset: 0x009AE4B4
		' (set) Token: 0x06010804 RID: 67588 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptCustomerEnvolve.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170065E5 RID: 26085
		' (get) Token: 0x06010805 RID: 67589 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170065E6 RID: 26086
		' (get) Token: 0x06010806 RID: 67590 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170065E7 RID: 26087
		' (get) Token: 0x06010807 RID: 67591 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170065E8 RID: 26088
		' (get) Token: 0x06010808 RID: 67592 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170065E9 RID: 26089
		' (get) Token: 0x06010809 RID: 67593 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property
	End Class
End Namespace
