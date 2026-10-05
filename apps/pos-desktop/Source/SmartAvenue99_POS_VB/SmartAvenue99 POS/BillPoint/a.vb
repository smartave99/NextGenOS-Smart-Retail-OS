Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020004FC RID: 1276
	Public Class a
		Inherits ReportClass

		' Token: 0x170063B7 RID: 25527
		' (get) Token: 0x060104A8 RID: 66728 RVA: 0x009AF84C File Offset: 0x009ADA4C
		' (set) Token: 0x060104A9 RID: 66729 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "a.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063B8 RID: 25528
		' (get) Token: 0x060104AA RID: 66730 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060104AB RID: 66731 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170063B9 RID: 25529
		' (get) Token: 0x060104AC RID: 66732 RVA: 0x009AF864 File Offset: 0x009ADA64
		' (set) Token: 0x060104AD RID: 66733 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.a.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170063BA RID: 25530
		' (get) Token: 0x060104AE RID: 66734 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170063BB RID: 25531
		' (get) Token: 0x060104AF RID: 66735 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170063BC RID: 25532
		' (get) Token: 0x060104B0 RID: 66736 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170063BD RID: 25533
		' (get) Token: 0x060104B1 RID: 66737 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170063BE RID: 25534
		' (get) Token: 0x060104B2 RID: 66738 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170063BF RID: 25535
		' (get) Token: 0x060104B3 RID: 66739 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
