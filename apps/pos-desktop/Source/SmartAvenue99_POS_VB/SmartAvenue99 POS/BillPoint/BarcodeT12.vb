Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200026F RID: 623
	Public Class BarcodeT12
		Inherits ReportClass

		' Token: 0x17004007 RID: 16391
		' (get) Token: 0x0600A5A3 RID: 42403 RVA: 0x0070090C File Offset: 0x006FEB0C
		' (set) Token: 0x0600A5A4 RID: 42404 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT12.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004008 RID: 16392
		' (get) Token: 0x0600A5A5 RID: 42405 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A5A6 RID: 42406 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004009 RID: 16393
		' (get) Token: 0x0600A5A7 RID: 42407 RVA: 0x00700924 File Offset: 0x006FEB24
		' (set) Token: 0x0600A5A8 RID: 42408 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT12.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700400A RID: 16394
		' (get) Token: 0x0600A5A9 RID: 42409 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700400B RID: 16395
		' (get) Token: 0x0600A5AA RID: 42410 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700400C RID: 16396
		' (get) Token: 0x0600A5AB RID: 42411 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700400D RID: 16397
		' (get) Token: 0x0600A5AC RID: 42412 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700400E RID: 16398
		' (get) Token: 0x0600A5AD RID: 42413 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700400F RID: 16399
		' (get) Token: 0x0600A5AE RID: 42414 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
