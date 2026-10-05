Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200055C RID: 1372
	Public Class BarcodeT9
		Inherits ReportClass

		' Token: 0x170067E0 RID: 26592
		' (get) Token: 0x06010C84 RID: 68740 RVA: 0x009CB260 File Offset: 0x009C9460
		' (set) Token: 0x06010C85 RID: 68741 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT9.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170067E1 RID: 26593
		' (get) Token: 0x06010C86 RID: 68742 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010C87 RID: 68743 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170067E2 RID: 26594
		' (get) Token: 0x06010C88 RID: 68744 RVA: 0x009CB278 File Offset: 0x009C9478
		' (set) Token: 0x06010C89 RID: 68745 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT9.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170067E3 RID: 26595
		' (get) Token: 0x06010C8A RID: 68746 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170067E4 RID: 26596
		' (get) Token: 0x06010C8B RID: 68747 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170067E5 RID: 26597
		' (get) Token: 0x06010C8C RID: 68748 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170067E6 RID: 26598
		' (get) Token: 0x06010C8D RID: 68749 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170067E7 RID: 26599
		' (get) Token: 0x06010C8E RID: 68750 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170067E8 RID: 26600
		' (get) Token: 0x06010C8F RID: 68751 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
