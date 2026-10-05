Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200027D RID: 637
	Public Class BarcodeT18
		Inherits ReportClass

		' Token: 0x1700405B RID: 16475
		' (get) Token: 0x0600A63D RID: 42557 RVA: 0x00700B74 File Offset: 0x006FED74
		' (set) Token: 0x0600A63E RID: 42558 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT18.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700405C RID: 16476
		' (get) Token: 0x0600A63F RID: 42559 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A640 RID: 42560 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700405D RID: 16477
		' (get) Token: 0x0600A641 RID: 42561 RVA: 0x00700B8C File Offset: 0x006FED8C
		' (set) Token: 0x0600A642 RID: 42562 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT18.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700405E RID: 16478
		' (get) Token: 0x0600A643 RID: 42563 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700405F RID: 16479
		' (get) Token: 0x0600A644 RID: 42564 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004060 RID: 16480
		' (get) Token: 0x0600A645 RID: 42565 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004061 RID: 16481
		' (get) Token: 0x0600A646 RID: 42566 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004062 RID: 16482
		' (get) Token: 0x0600A647 RID: 42567 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004063 RID: 16483
		' (get) Token: 0x0600A648 RID: 42568 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
