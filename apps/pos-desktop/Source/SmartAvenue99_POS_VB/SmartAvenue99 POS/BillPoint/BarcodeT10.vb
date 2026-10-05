Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000485 RID: 1157
	Public Class BarcodeT10
		Inherits ReportClass

		' Token: 0x170059C4 RID: 22980
		' (get) Token: 0x0600E99C RID: 59804 RVA: 0x008D93D0 File Offset: 0x008D75D0
		' (set) Token: 0x0600E99D RID: 59805 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT10.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059C5 RID: 22981
		' (get) Token: 0x0600E99E RID: 59806 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E99F RID: 59807 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059C6 RID: 22982
		' (get) Token: 0x0600E9A0 RID: 59808 RVA: 0x008D93E8 File Offset: 0x008D75E8
		' (set) Token: 0x0600E9A1 RID: 59809 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT10.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059C7 RID: 22983
		' (get) Token: 0x0600E9A2 RID: 59810 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170059C8 RID: 22984
		' (get) Token: 0x0600E9A3 RID: 59811 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170059C9 RID: 22985
		' (get) Token: 0x0600E9A4 RID: 59812 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170059CA RID: 22986
		' (get) Token: 0x0600E9A5 RID: 59813 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170059CB RID: 22987
		' (get) Token: 0x0600E9A6 RID: 59814 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170059CC RID: 22988
		' (get) Token: 0x0600E9A7 RID: 59815 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
