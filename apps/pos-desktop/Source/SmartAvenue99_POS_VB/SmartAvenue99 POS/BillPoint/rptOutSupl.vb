Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200054C RID: 1356
	Public Class rptOutSupl
		Inherits ReportClass

		' Token: 0x1700667E RID: 26238
		' (get) Token: 0x060108FF RID: 67839 RVA: 0x009B060C File Offset: 0x009AE80C
		' (set) Token: 0x06010900 RID: 67840 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptOutSupl.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700667F RID: 26239
		' (get) Token: 0x06010901 RID: 67841 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010902 RID: 67842 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006680 RID: 26240
		' (get) Token: 0x06010903 RID: 67843 RVA: 0x009B0624 File Offset: 0x009AE824
		' (set) Token: 0x06010904 RID: 67844 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptOutSupl.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006681 RID: 26241
		' (get) Token: 0x06010905 RID: 67845 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006682 RID: 26242
		' (get) Token: 0x06010906 RID: 67846 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006683 RID: 26243
		' (get) Token: 0x06010907 RID: 67847 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006684 RID: 26244
		' (get) Token: 0x06010908 RID: 67848 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006685 RID: 26245
		' (get) Token: 0x06010909 RID: 67849 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006686 RID: 26246
		' (get) Token: 0x0601090A RID: 67850 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006687 RID: 26247
		' (get) Token: 0x0601090B RID: 67851 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17006688 RID: 26248
		' (get) Token: 0x0601090C RID: 67852 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
