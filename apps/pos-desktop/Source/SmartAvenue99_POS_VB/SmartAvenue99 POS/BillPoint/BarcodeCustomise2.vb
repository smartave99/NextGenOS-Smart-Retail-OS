Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000271 RID: 625
	Public Class BarcodeCustomise2
		Inherits ReportClass

		' Token: 0x17004013 RID: 16403
		' (get) Token: 0x0600A5B9 RID: 42425 RVA: 0x00700964 File Offset: 0x006FEB64
		' (set) Token: 0x0600A5BA RID: 42426 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeCustomise2.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004014 RID: 16404
		' (get) Token: 0x0600A5BB RID: 42427 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A5BC RID: 42428 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004015 RID: 16405
		' (get) Token: 0x0600A5BD RID: 42429 RVA: 0x0070097C File Offset: 0x006FEB7C
		' (set) Token: 0x0600A5BE RID: 42430 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeCustomise2.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004016 RID: 16406
		' (get) Token: 0x0600A5BF RID: 42431 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004017 RID: 16407
		' (get) Token: 0x0600A5C0 RID: 42432 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004018 RID: 16408
		' (get) Token: 0x0600A5C1 RID: 42433 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004019 RID: 16409
		' (get) Token: 0x0600A5C2 RID: 42434 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700401A RID: 16410
		' (get) Token: 0x0600A5C3 RID: 42435 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700401B RID: 16411
		' (get) Token: 0x0600A5C4 RID: 42436 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
