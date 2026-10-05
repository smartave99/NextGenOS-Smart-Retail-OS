Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200027B RID: 635
	Public Class BarcodeT17
		Inherits ReportClass

		' Token: 0x1700404F RID: 16463
		' (get) Token: 0x0600A627 RID: 42535 RVA: 0x00700B1C File Offset: 0x006FED1C
		' (set) Token: 0x0600A628 RID: 42536 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT17.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004050 RID: 16464
		' (get) Token: 0x0600A629 RID: 42537 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A62A RID: 42538 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004051 RID: 16465
		' (get) Token: 0x0600A62B RID: 42539 RVA: 0x00700B34 File Offset: 0x006FED34
		' (set) Token: 0x0600A62C RID: 42540 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT17.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004052 RID: 16466
		' (get) Token: 0x0600A62D RID: 42541 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004053 RID: 16467
		' (get) Token: 0x0600A62E RID: 42542 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004054 RID: 16468
		' (get) Token: 0x0600A62F RID: 42543 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004055 RID: 16469
		' (get) Token: 0x0600A630 RID: 42544 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004056 RID: 16470
		' (get) Token: 0x0600A631 RID: 42545 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004057 RID: 16471
		' (get) Token: 0x0600A632 RID: 42546 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
