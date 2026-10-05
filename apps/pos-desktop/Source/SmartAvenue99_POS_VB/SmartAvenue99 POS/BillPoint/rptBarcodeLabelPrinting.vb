Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000597 RID: 1431
	Public Class rptBarcodeLabelPrinting
		Inherits ReportClass

		' Token: 0x17006D29 RID: 27945
		' (get) Token: 0x0601198E RID: 72078 RVA: 0x00A32ED4 File Offset: 0x00A310D4
		' (set) Token: 0x0601198F RID: 72079 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBarcodeLabelPrinting.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006D2A RID: 27946
		' (get) Token: 0x06011990 RID: 72080 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011991 RID: 72081 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006D2B RID: 27947
		' (get) Token: 0x06011992 RID: 72082 RVA: 0x00A32EEC File Offset: 0x00A310EC
		' (set) Token: 0x06011993 RID: 72083 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBarcodeLabelPrinting.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006D2C RID: 27948
		' (get) Token: 0x06011994 RID: 72084 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006D2D RID: 27949
		' (get) Token: 0x06011995 RID: 72085 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006D2E RID: 27950
		' (get) Token: 0x06011996 RID: 72086 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006D2F RID: 27951
		' (get) Token: 0x06011997 RID: 72087 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006D30 RID: 27952
		' (get) Token: 0x06011998 RID: 72088 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006D31 RID: 27953
		' (get) Token: 0x06011999 RID: 72089 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
