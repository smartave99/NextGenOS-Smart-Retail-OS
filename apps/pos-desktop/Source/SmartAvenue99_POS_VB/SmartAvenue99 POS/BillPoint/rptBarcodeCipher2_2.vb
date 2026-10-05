Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002B5 RID: 693
	Public Class rptBarcodeCipher2_2
		Inherits ReportClass

		' Token: 0x170044F8 RID: 17656
		' (get) Token: 0x0600B279 RID: 45689 RVA: 0x00770BD4 File Offset: 0x0076EDD4
		' (set) Token: 0x0600B27A RID: 45690 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBarcodeCipher2_2.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170044F9 RID: 17657
		' (get) Token: 0x0600B27B RID: 45691 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B27C RID: 45692 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170044FA RID: 17658
		' (get) Token: 0x0600B27D RID: 45693 RVA: 0x00770BEC File Offset: 0x0076EDEC
		' (set) Token: 0x0600B27E RID: 45694 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBarcodeCipher2_2.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170044FB RID: 17659
		' (get) Token: 0x0600B27F RID: 45695 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170044FC RID: 17660
		' (get) Token: 0x0600B280 RID: 45696 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170044FD RID: 17661
		' (get) Token: 0x0600B281 RID: 45697 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170044FE RID: 17662
		' (get) Token: 0x0600B282 RID: 45698 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170044FF RID: 17663
		' (get) Token: 0x0600B283 RID: 45699 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004500 RID: 17664
		' (get) Token: 0x0600B284 RID: 45700 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
