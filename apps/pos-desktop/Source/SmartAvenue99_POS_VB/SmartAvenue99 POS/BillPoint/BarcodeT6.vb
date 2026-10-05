Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200047F RID: 1151
	Public Class BarcodeT6
		Inherits ReportClass

		' Token: 0x170059A0 RID: 22944
		' (get) Token: 0x0600E95A RID: 59738 RVA: 0x008D92C8 File Offset: 0x008D74C8
		' (set) Token: 0x0600E95B RID: 59739 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT6.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059A1 RID: 22945
		' (get) Token: 0x0600E95C RID: 59740 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E95D RID: 59741 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059A2 RID: 22946
		' (get) Token: 0x0600E95E RID: 59742 RVA: 0x008D92E0 File Offset: 0x008D74E0
		' (set) Token: 0x0600E95F RID: 59743 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT6.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059A3 RID: 22947
		' (get) Token: 0x0600E960 RID: 59744 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170059A4 RID: 22948
		' (get) Token: 0x0600E961 RID: 59745 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170059A5 RID: 22949
		' (get) Token: 0x0600E962 RID: 59746 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170059A6 RID: 22950
		' (get) Token: 0x0600E963 RID: 59747 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170059A7 RID: 22951
		' (get) Token: 0x0600E964 RID: 59748 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170059A8 RID: 22952
		' (get) Token: 0x0600E965 RID: 59749 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
