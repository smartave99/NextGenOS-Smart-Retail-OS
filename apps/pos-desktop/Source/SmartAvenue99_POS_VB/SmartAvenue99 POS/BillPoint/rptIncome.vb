Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x02000544 RID: 1348
	Public Class rptIncome
		Inherits ReportClass

		' Token: 0x17006634 RID: 26164
		' (get) Token: 0x0601088D RID: 67725 RVA: 0x009B04AC File Offset: 0x009AE6AC
		' (set) Token: 0x0601088E RID: 67726 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptIncome.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006635 RID: 26165
		' (get) Token: 0x0601088F RID: 67727 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010890 RID: 67728 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006636 RID: 26166
		' (get) Token: 0x06010891 RID: 67729 RVA: 0x009B04C4 File Offset: 0x009AE6C4
		' (set) Token: 0x06010892 RID: 67730 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptIncome.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006637 RID: 26167
		' (get) Token: 0x06010893 RID: 67731 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006638 RID: 26168
		' (get) Token: 0x06010894 RID: 67732 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006639 RID: 26169
		' (get) Token: 0x06010895 RID: 67733 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700663A RID: 26170
		' (get) Token: 0x06010896 RID: 67734 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700663B RID: 26171
		' (get) Token: 0x06010897 RID: 67735 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property
	End Class
End Namespace
