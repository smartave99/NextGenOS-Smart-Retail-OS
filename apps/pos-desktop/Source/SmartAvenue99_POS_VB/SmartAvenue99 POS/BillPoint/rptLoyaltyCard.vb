Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002BF RID: 703
	Public Class rptLoyaltyCard
		Inherits ReportClass

		' Token: 0x17004547 RID: 17735
		' (get) Token: 0x0600B2FA RID: 45818 RVA: 0x00770DB0 File Offset: 0x0076EFB0
		' (set) Token: 0x0600B2FB RID: 45819 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptLoyaltyCard.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004548 RID: 17736
		' (get) Token: 0x0600B2FC RID: 45820 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B2FD RID: 45821 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004549 RID: 17737
		' (get) Token: 0x0600B2FE RID: 45822 RVA: 0x00770DC8 File Offset: 0x0076EFC8
		' (set) Token: 0x0600B2FF RID: 45823 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptLoyaltyCard.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700454A RID: 17738
		' (get) Token: 0x0600B300 RID: 45824 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700454B RID: 17739
		' (get) Token: 0x0600B301 RID: 45825 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700454C RID: 17740
		' (get) Token: 0x0600B302 RID: 45826 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700454D RID: 17741
		' (get) Token: 0x0600B303 RID: 45827 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700454E RID: 17742
		' (get) Token: 0x0600B304 RID: 45828 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700454F RID: 17743
		' (get) Token: 0x0600B305 RID: 45829 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
