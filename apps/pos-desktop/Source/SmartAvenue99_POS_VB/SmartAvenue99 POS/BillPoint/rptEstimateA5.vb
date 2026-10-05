Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000540 RID: 1344
	Public Class rptEstimateA5
		Inherits ReportClass

		' Token: 0x17006619 RID: 26137
		' (get) Token: 0x0601085E RID: 67678 RVA: 0x009B03FC File Offset: 0x009AE5FC
		' (set) Token: 0x0601085F RID: 67679 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptEstimateA5.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700661A RID: 26138
		' (get) Token: 0x06010860 RID: 67680 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010861 RID: 67681 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700661B RID: 26139
		' (get) Token: 0x06010862 RID: 67682 RVA: 0x009B0414 File Offset: 0x009AE614
		' (set) Token: 0x06010863 RID: 67683 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptEstimateA5.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700661C RID: 26140
		' (get) Token: 0x06010864 RID: 67684 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700661D RID: 26141
		' (get) Token: 0x06010865 RID: 67685 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700661E RID: 26142
		' (get) Token: 0x06010866 RID: 67686 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700661F RID: 26143
		' (get) Token: 0x06010867 RID: 67687 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006620 RID: 26144
		' (get) Token: 0x06010868 RID: 67688 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006621 RID: 26145
		' (get) Token: 0x06010869 RID: 67689 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006622 RID: 26146
		' (get) Token: 0x0601086A RID: 67690 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17006623 RID: 26147
		' (get) Token: 0x0601086B RID: 67691 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
