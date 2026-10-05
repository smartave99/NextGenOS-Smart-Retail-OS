Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005A4 RID: 1444
	Public Class rptServiceTaxReport
		Inherits ReportClass

		' Token: 0x17006DA9 RID: 28073
		' (get) Token: 0x06011A63 RID: 72291 RVA: 0x00A3421C File Offset: 0x00A3241C
		' (set) Token: 0x06011A64 RID: 72292 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptServiceTaxReport.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006DAA RID: 28074
		' (get) Token: 0x06011A65 RID: 72293 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011A66 RID: 72294 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006DAB RID: 28075
		' (get) Token: 0x06011A67 RID: 72295 RVA: 0x00A34234 File Offset: 0x00A32434
		' (set) Token: 0x06011A68 RID: 72296 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptServiceTaxReport.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006DAC RID: 28076
		' (get) Token: 0x06011A69 RID: 72297 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006DAD RID: 28077
		' (get) Token: 0x06011A6A RID: 72298 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006DAE RID: 28078
		' (get) Token: 0x06011A6B RID: 72299 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006DAF RID: 28079
		' (get) Token: 0x06011A6C RID: 72300 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006DB0 RID: 28080
		' (get) Token: 0x06011A6D RID: 72301 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006DB1 RID: 28081
		' (get) Token: 0x06011A6E RID: 72302 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006DB2 RID: 28082
		' (get) Token: 0x06011A6F RID: 72303 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
