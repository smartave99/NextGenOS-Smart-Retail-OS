Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200031B RID: 795
	Public Class BarcodeT4
		Inherits ReportClass

		' Token: 0x17004B43 RID: 19267
		' (get) Token: 0x0600BCF1 RID: 48369 RVA: 0x00790268 File Offset: 0x0078E468
		' (set) Token: 0x0600BCF2 RID: 48370 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B44 RID: 19268
		' (get) Token: 0x0600BCF3 RID: 48371 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BCF4 RID: 48372 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B45 RID: 19269
		' (get) Token: 0x0600BCF5 RID: 48373 RVA: 0x00790280 File Offset: 0x0078E480
		' (set) Token: 0x0600BCF6 RID: 48374 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT4.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B46 RID: 19270
		' (get) Token: 0x0600BCF7 RID: 48375 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004B47 RID: 19271
		' (get) Token: 0x0600BCF8 RID: 48376 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004B48 RID: 19272
		' (get) Token: 0x0600BCF9 RID: 48377 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004B49 RID: 19273
		' (get) Token: 0x0600BCFA RID: 48378 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004B4A RID: 19274
		' (get) Token: 0x0600BCFB RID: 48379 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004B4B RID: 19275
		' (get) Token: 0x0600BCFC RID: 48380 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
