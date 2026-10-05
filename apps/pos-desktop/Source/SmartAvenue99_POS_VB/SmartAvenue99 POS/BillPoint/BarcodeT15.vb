Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000277 RID: 631
	Public Class BarcodeT15
		Inherits ReportClass

		' Token: 0x17004037 RID: 16439
		' (get) Token: 0x0600A5FB RID: 42491 RVA: 0x00700A6C File Offset: 0x006FEC6C
		' (set) Token: 0x0600A5FC RID: 42492 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT15.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004038 RID: 16440
		' (get) Token: 0x0600A5FD RID: 42493 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A5FE RID: 42494 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004039 RID: 16441
		' (get) Token: 0x0600A5FF RID: 42495 RVA: 0x00700A84 File Offset: 0x006FEC84
		' (set) Token: 0x0600A600 RID: 42496 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT15.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700403A RID: 16442
		' (get) Token: 0x0600A601 RID: 42497 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700403B RID: 16443
		' (get) Token: 0x0600A602 RID: 42498 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700403C RID: 16444
		' (get) Token: 0x0600A603 RID: 42499 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700403D RID: 16445
		' (get) Token: 0x0600A604 RID: 42500 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700403E RID: 16446
		' (get) Token: 0x0600A605 RID: 42501 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700403F RID: 16447
		' (get) Token: 0x0600A606 RID: 42502 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
