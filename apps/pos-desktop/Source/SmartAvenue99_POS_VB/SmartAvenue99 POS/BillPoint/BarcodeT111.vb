Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200027F RID: 639
	Public Class BarcodeT111
		Inherits ReportClass

		' Token: 0x17004067 RID: 16487
		' (get) Token: 0x0600A653 RID: 42579 RVA: 0x00700BCC File Offset: 0x006FEDCC
		' (set) Token: 0x0600A654 RID: 42580 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT111.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004068 RID: 16488
		' (get) Token: 0x0600A655 RID: 42581 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A656 RID: 42582 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004069 RID: 16489
		' (get) Token: 0x0600A657 RID: 42583 RVA: 0x00700BE4 File Offset: 0x006FEDE4
		' (set) Token: 0x0600A658 RID: 42584 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT111.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700406A RID: 16490
		' (get) Token: 0x0600A659 RID: 42585 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700406B RID: 16491
		' (get) Token: 0x0600A65A RID: 42586 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700406C RID: 16492
		' (get) Token: 0x0600A65B RID: 42587 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700406D RID: 16493
		' (get) Token: 0x0600A65C RID: 42588 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700406E RID: 16494
		' (get) Token: 0x0600A65D RID: 42589 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700406F RID: 16495
		' (get) Token: 0x0600A65E RID: 42590 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
