Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000250 RID: 592
	Public Class BarcodeCustomiseX
		Inherits ReportClass

		' Token: 0x17003EA9 RID: 16041
		' (get) Token: 0x0600A183 RID: 41347 RVA: 0x006F4B50 File Offset: 0x006F2D50
		' (set) Token: 0x0600A184 RID: 41348 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeCustomiseX.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003EAA RID: 16042
		' (get) Token: 0x0600A185 RID: 41349 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A186 RID: 41350 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17003EAB RID: 16043
		' (get) Token: 0x0600A187 RID: 41351 RVA: 0x006F4B68 File Offset: 0x006F2D68
		' (set) Token: 0x0600A188 RID: 41352 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeCustomiseX.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17003EAC RID: 16044
		' (get) Token: 0x0600A189 RID: 41353 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17003EAD RID: 16045
		' (get) Token: 0x0600A18A RID: 41354 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17003EAE RID: 16046
		' (get) Token: 0x0600A18B RID: 41355 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17003EAF RID: 16047
		' (get) Token: 0x0600A18C RID: 41356 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17003EB0 RID: 16048
		' (get) Token: 0x0600A18D RID: 41357 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17003EB1 RID: 16049
		' (get) Token: 0x0600A18E RID: 41358 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
