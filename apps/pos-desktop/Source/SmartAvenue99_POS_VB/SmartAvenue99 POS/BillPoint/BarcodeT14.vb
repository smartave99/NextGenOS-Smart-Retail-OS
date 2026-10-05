Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000275 RID: 629
	Public Class BarcodeT14
		Inherits ReportClass

		' Token: 0x1700402B RID: 16427
		' (get) Token: 0x0600A5E5 RID: 42469 RVA: 0x00700A14 File Offset: 0x006FEC14
		' (set) Token: 0x0600A5E6 RID: 42470 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT14.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700402C RID: 16428
		' (get) Token: 0x0600A5E7 RID: 42471 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A5E8 RID: 42472 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700402D RID: 16429
		' (get) Token: 0x0600A5E9 RID: 42473 RVA: 0x00700A2C File Offset: 0x006FEC2C
		' (set) Token: 0x0600A5EA RID: 42474 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT14.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700402E RID: 16430
		' (get) Token: 0x0600A5EB RID: 42475 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700402F RID: 16431
		' (get) Token: 0x0600A5EC RID: 42476 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004030 RID: 16432
		' (get) Token: 0x0600A5ED RID: 42477 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004031 RID: 16433
		' (get) Token: 0x0600A5EE RID: 42478 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004032 RID: 16434
		' (get) Token: 0x0600A5EF RID: 42479 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004033 RID: 16435
		' (get) Token: 0x0600A5F0 RID: 42480 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
