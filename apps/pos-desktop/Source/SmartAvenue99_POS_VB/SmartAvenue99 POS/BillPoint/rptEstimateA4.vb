Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200053E RID: 1342
	Public Class rptEstimateA4
		Inherits ReportClass

		' Token: 0x1700660B RID: 26123
		' (get) Token: 0x06010846 RID: 67654 RVA: 0x009B03A4 File Offset: 0x009AE5A4
		' (set) Token: 0x06010847 RID: 67655 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptEstimateA4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700660C RID: 26124
		' (get) Token: 0x06010848 RID: 67656 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010849 RID: 67657 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700660D RID: 26125
		' (get) Token: 0x0601084A RID: 67658 RVA: 0x009B03BC File Offset: 0x009AE5BC
		' (set) Token: 0x0601084B RID: 67659 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptEstimateA4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700660E RID: 26126
		' (get) Token: 0x0601084C RID: 67660 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700660F RID: 26127
		' (get) Token: 0x0601084D RID: 67661 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006610 RID: 26128
		' (get) Token: 0x0601084E RID: 67662 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006611 RID: 26129
		' (get) Token: 0x0601084F RID: 67663 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006612 RID: 26130
		' (get) Token: 0x06010850 RID: 67664 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006613 RID: 26131
		' (get) Token: 0x06010851 RID: 67665 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006614 RID: 26132
		' (get) Token: 0x06010852 RID: 67666 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17006615 RID: 26133
		' (get) Token: 0x06010853 RID: 67667 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
