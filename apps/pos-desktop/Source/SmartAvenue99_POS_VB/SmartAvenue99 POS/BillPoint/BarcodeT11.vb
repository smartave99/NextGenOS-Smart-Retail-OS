Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200048B RID: 1163
	Public Class BarcodeT11
		Inherits ReportClass

		' Token: 0x170059E8 RID: 23016
		' (get) Token: 0x0600E9DE RID: 59870 RVA: 0x008D94D8 File Offset: 0x008D76D8
		' (set) Token: 0x0600E9DF RID: 59871 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT11.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059E9 RID: 23017
		' (get) Token: 0x0600E9E0 RID: 59872 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E9E1 RID: 59873 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059EA RID: 23018
		' (get) Token: 0x0600E9E2 RID: 59874 RVA: 0x008D94F0 File Offset: 0x008D76F0
		' (set) Token: 0x0600E9E3 RID: 59875 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT11.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059EB RID: 23019
		' (get) Token: 0x0600E9E4 RID: 59876 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170059EC RID: 23020
		' (get) Token: 0x0600E9E5 RID: 59877 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170059ED RID: 23021
		' (get) Token: 0x0600E9E6 RID: 59878 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170059EE RID: 23022
		' (get) Token: 0x0600E9E7 RID: 59879 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170059EF RID: 23023
		' (get) Token: 0x0600E9E8 RID: 59880 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170059F0 RID: 23024
		' (get) Token: 0x0600E9E9 RID: 59881 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
