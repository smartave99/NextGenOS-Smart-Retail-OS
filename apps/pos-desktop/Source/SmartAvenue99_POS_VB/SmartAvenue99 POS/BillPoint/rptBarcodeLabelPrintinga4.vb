Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020004FE RID: 1278
	Public Class rptBarcodeLabelPrintinga4
		Inherits ReportClass

		' Token: 0x170063C3 RID: 25539
		' (get) Token: 0x060104BE RID: 66750 RVA: 0x009AF8A4 File Offset: 0x009ADAA4
		' (set) Token: 0x060104BF RID: 66751 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBarcodeLabelPrintinga4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063C4 RID: 25540
		' (get) Token: 0x060104C0 RID: 66752 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060104C1 RID: 66753 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063C5 RID: 25541
		' (get) Token: 0x060104C2 RID: 66754 RVA: 0x009AF8BC File Offset: 0x009ADABC
		' (set) Token: 0x060104C3 RID: 66755 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBarcodeLabelPrintinga4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063C6 RID: 25542
		' (get) Token: 0x060104C4 RID: 66756 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170063C7 RID: 25543
		' (get) Token: 0x060104C5 RID: 66757 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170063C8 RID: 25544
		' (get) Token: 0x060104C6 RID: 66758 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170063C9 RID: 25545
		' (get) Token: 0x060104C7 RID: 66759 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170063CA RID: 25546
		' (get) Token: 0x060104C8 RID: 66760 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170063CB RID: 25547
		' (get) Token: 0x060104C9 RID: 66761 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
