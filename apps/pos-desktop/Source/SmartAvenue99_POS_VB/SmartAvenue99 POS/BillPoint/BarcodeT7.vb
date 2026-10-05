Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000481 RID: 1153
	Public Class BarcodeT7
		Inherits ReportClass

		' Token: 0x170059AC RID: 22956
		' (get) Token: 0x0600E970 RID: 59760 RVA: 0x008D9320 File Offset: 0x008D7520
		' (set) Token: 0x0600E971 RID: 59761 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT7.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059AD RID: 22957
		' (get) Token: 0x0600E972 RID: 59762 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E973 RID: 59763 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059AE RID: 22958
		' (get) Token: 0x0600E974 RID: 59764 RVA: 0x008D9338 File Offset: 0x008D7538
		' (set) Token: 0x0600E975 RID: 59765 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT7.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059AF RID: 22959
		' (get) Token: 0x0600E976 RID: 59766 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170059B0 RID: 22960
		' (get) Token: 0x0600E977 RID: 59767 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170059B1 RID: 22961
		' (get) Token: 0x0600E978 RID: 59768 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170059B2 RID: 22962
		' (get) Token: 0x0600E979 RID: 59769 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170059B3 RID: 22963
		' (get) Token: 0x0600E97A RID: 59770 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170059B4 RID: 22964
		' (get) Token: 0x0600E97B RID: 59771 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
