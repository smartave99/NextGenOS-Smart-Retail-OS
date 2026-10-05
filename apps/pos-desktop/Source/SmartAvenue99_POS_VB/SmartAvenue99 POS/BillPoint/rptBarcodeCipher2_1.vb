Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002B3 RID: 691
	Public Class rptBarcodeCipher2_1
		Inherits ReportClass

		' Token: 0x170044EC RID: 17644
		' (get) Token: 0x0600B263 RID: 45667 RVA: 0x00770B7C File Offset: 0x0076ED7C
		' (set) Token: 0x0600B264 RID: 45668 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBarcodeCipher2_1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170044ED RID: 17645
		' (get) Token: 0x0600B265 RID: 45669 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B266 RID: 45670 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170044EE RID: 17646
		' (get) Token: 0x0600B267 RID: 45671 RVA: 0x00770B94 File Offset: 0x0076ED94
		' (set) Token: 0x0600B268 RID: 45672 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBarcodeCipher2_1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170044EF RID: 17647
		' (get) Token: 0x0600B269 RID: 45673 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170044F0 RID: 17648
		' (get) Token: 0x0600B26A RID: 45674 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170044F1 RID: 17649
		' (get) Token: 0x0600B26B RID: 45675 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170044F2 RID: 17650
		' (get) Token: 0x0600B26C RID: 45676 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170044F3 RID: 17651
		' (get) Token: 0x0600B26D RID: 45677 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170044F4 RID: 17652
		' (get) Token: 0x0600B26E RID: 45678 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
