Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020004FA RID: 1274
	Public Class BarcodeT2
		Inherits ReportClass

		' Token: 0x170063AB RID: 25515
		' (get) Token: 0x06010492 RID: 66706 RVA: 0x009AF7F4 File Offset: 0x009AD9F4
		' (set) Token: 0x06010493 RID: 66707 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT2.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063AC RID: 25516
		' (get) Token: 0x06010494 RID: 66708 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010495 RID: 66709 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063AD RID: 25517
		' (get) Token: 0x06010496 RID: 66710 RVA: 0x009AF80C File Offset: 0x009ADA0C
		' (set) Token: 0x06010497 RID: 66711 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT2.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063AE RID: 25518
		' (get) Token: 0x06010498 RID: 66712 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170063AF RID: 25519
		' (get) Token: 0x06010499 RID: 66713 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170063B0 RID: 25520
		' (get) Token: 0x0601049A RID: 66714 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170063B1 RID: 25521
		' (get) Token: 0x0601049B RID: 66715 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170063B2 RID: 25522
		' (get) Token: 0x0601049C RID: 66716 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170063B3 RID: 25523
		' (get) Token: 0x0601049D RID: 66717 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
