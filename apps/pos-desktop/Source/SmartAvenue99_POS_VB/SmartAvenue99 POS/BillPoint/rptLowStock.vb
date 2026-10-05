Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200056F RID: 1391
	Public Class rptLowStock
		Inherits ReportClass

		' Token: 0x1700692C RID: 26924
		' (get) Token: 0x06010F59 RID: 69465 RVA: 0x009DBA8C File Offset: 0x009D9C8C
		' (set) Token: 0x06010F5A RID: 69466 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptLowStock.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700692D RID: 26925
		' (get) Token: 0x06010F5B RID: 69467 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010F5C RID: 69468 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700692E RID: 26926
		' (get) Token: 0x06010F5D RID: 69469 RVA: 0x009DBAA4 File Offset: 0x009D9CA4
		' (set) Token: 0x06010F5E RID: 69470 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptLowStock.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700692F RID: 26927
		' (get) Token: 0x06010F5F RID: 69471 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006930 RID: 26928
		' (get) Token: 0x06010F60 RID: 69472 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006931 RID: 26929
		' (get) Token: 0x06010F61 RID: 69473 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006932 RID: 26930
		' (get) Token: 0x06010F62 RID: 69474 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006933 RID: 26931
		' (get) Token: 0x06010F63 RID: 69475 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006934 RID: 26932
		' (get) Token: 0x06010F64 RID: 69476 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
