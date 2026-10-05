Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000483 RID: 1155
	Public Class Crybarcode80mmEMI
		Inherits ReportClass

		' Token: 0x170059B8 RID: 22968
		' (get) Token: 0x0600E986 RID: 59782 RVA: 0x008D9378 File Offset: 0x008D7578
		' (set) Token: 0x0600E987 RID: 59783 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "Crybarcode80mmEMI.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059B9 RID: 22969
		' (get) Token: 0x0600E988 RID: 59784 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E989 RID: 59785 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059BA RID: 22970
		' (get) Token: 0x0600E98A RID: 59786 RVA: 0x008D9390 File Offset: 0x008D7590
		' (set) Token: 0x0600E98B RID: 59787 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.Crybarcode80mmEMI.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059BB RID: 22971
		' (get) Token: 0x0600E98C RID: 59788 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170059BC RID: 22972
		' (get) Token: 0x0600E98D RID: 59789 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170059BD RID: 22973
		' (get) Token: 0x0600E98E RID: 59790 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170059BE RID: 22974
		' (get) Token: 0x0600E98F RID: 59791 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170059BF RID: 22975
		' (get) Token: 0x0600E990 RID: 59792 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170059C0 RID: 22976
		' (get) Token: 0x0600E991 RID: 59793 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
