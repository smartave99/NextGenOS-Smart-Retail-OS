Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200048D RID: 1165
	Public Class Crybarcodea4to40
		Inherits ReportClass

		' Token: 0x170059F4 RID: 23028
		' (get) Token: 0x0600E9F4 RID: 59892 RVA: 0x008D9530 File Offset: 0x008D7730
		' (set) Token: 0x0600E9F5 RID: 59893 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "Crybarcodea4to40.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059F5 RID: 23029
		' (get) Token: 0x0600E9F6 RID: 59894 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E9F7 RID: 59895 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059F6 RID: 23030
		' (get) Token: 0x0600E9F8 RID: 59896 RVA: 0x008D9548 File Offset: 0x008D7748
		' (set) Token: 0x0600E9F9 RID: 59897 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.Crybarcodea4to40.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059F7 RID: 23031
		' (get) Token: 0x0600E9FA RID: 59898 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170059F8 RID: 23032
		' (get) Token: 0x0600E9FB RID: 59899 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170059F9 RID: 23033
		' (get) Token: 0x0600E9FC RID: 59900 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170059FA RID: 23034
		' (get) Token: 0x0600E9FD RID: 59901 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170059FB RID: 23035
		' (get) Token: 0x0600E9FE RID: 59902 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170059FC RID: 23036
		' (get) Token: 0x0600E9FF RID: 59903 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
