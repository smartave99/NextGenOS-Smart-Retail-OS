Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000477 RID: 1143
	Public Class rptAdvanceEntry
		Inherits ReportClass

		' Token: 0x1700596F RID: 22895
		' (get) Token: 0x0600E901 RID: 59649 RVA: 0x008D9168 File Offset: 0x008D7368
		' (set) Token: 0x0600E902 RID: 59650 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptAdvanceEntry.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17005970 RID: 22896
		' (get) Token: 0x0600E903 RID: 59651 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E904 RID: 59652 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17005971 RID: 22897
		' (get) Token: 0x0600E905 RID: 59653 RVA: 0x008D9180 File Offset: 0x008D7380
		' (set) Token: 0x0600E906 RID: 59654 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptAdvanceEntry.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17005972 RID: 22898
		' (get) Token: 0x0600E907 RID: 59655 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17005973 RID: 22899
		' (get) Token: 0x0600E908 RID: 59656 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17005974 RID: 22900
		' (get) Token: 0x0600E909 RID: 59657 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17005975 RID: 22901
		' (get) Token: 0x0600E90A RID: 59658 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17005976 RID: 22902
		' (get) Token: 0x0600E90B RID: 59659 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17005977 RID: 22903
		' (get) Token: 0x0600E90C RID: 59660 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_v2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17005978 RID: 22904
		' (get) Token: 0x0600E90D RID: 59661 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_v1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
