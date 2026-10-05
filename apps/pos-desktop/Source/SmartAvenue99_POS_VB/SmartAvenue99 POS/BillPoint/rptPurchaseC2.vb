Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000550 RID: 1360
	Public Class rptPurchaseC2
		Inherits ReportClass

		' Token: 0x1700669C RID: 26268
		' (get) Token: 0x06010931 RID: 67889 RVA: 0x009B06BC File Offset: 0x009AE8BC
		' (set) Token: 0x06010932 RID: 67890 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptPurchaseC2.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700669D RID: 26269
		' (get) Token: 0x06010933 RID: 67891 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010934 RID: 67892 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700669E RID: 26270
		' (get) Token: 0x06010935 RID: 67893 RVA: 0x009B06D4 File Offset: 0x009AE8D4
		' (set) Token: 0x06010936 RID: 67894 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptPurchaseC2.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700669F RID: 26271
		' (get) Token: 0x06010937 RID: 67895 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170066A0 RID: 26272
		' (get) Token: 0x06010938 RID: 67896 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170066A1 RID: 26273
		' (get) Token: 0x06010939 RID: 67897 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170066A2 RID: 26274
		' (get) Token: 0x0601093A RID: 67898 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170066A3 RID: 26275
		' (get) Token: 0x0601093B RID: 67899 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170066A4 RID: 26276
		' (get) Token: 0x0601093C RID: 67900 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170066A5 RID: 26277
		' (get) Token: 0x0601093D RID: 67901 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170066A6 RID: 26278
		' (get) Token: 0x0601093E RID: 67902 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p6 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
