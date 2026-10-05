Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200057E RID: 1406
	Public Class rptLowSellingItems
		Inherits ReportClass

		' Token: 0x170069CE RID: 27086
		' (get) Token: 0x060110E3 RID: 69859 RVA: 0x009E4080 File Offset: 0x009E2280
		' (set) Token: 0x060110E4 RID: 69860 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptLowSellingItems.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170069CF RID: 27087
		' (get) Token: 0x060110E5 RID: 69861 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060110E6 RID: 69862 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170069D0 RID: 27088
		' (get) Token: 0x060110E7 RID: 69863 RVA: 0x009E4098 File Offset: 0x009E2298
		' (set) Token: 0x060110E8 RID: 69864 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptLowSellingItems.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170069D1 RID: 27089
		' (get) Token: 0x060110E9 RID: 69865 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170069D2 RID: 27090
		' (get) Token: 0x060110EA RID: 69866 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170069D3 RID: 27091
		' (get) Token: 0x060110EB RID: 69867 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170069D4 RID: 27092
		' (get) Token: 0x060110EC RID: 69868 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170069D5 RID: 27093
		' (get) Token: 0x060110ED RID: 69869 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170069D6 RID: 27094
		' (get) Token: 0x060110EE RID: 69870 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
