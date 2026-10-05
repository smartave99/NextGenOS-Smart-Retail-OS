Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002CF RID: 719
	Public Class rptStockInward
		Inherits ReportClass

		' Token: 0x170045DD RID: 17885
		' (get) Token: 0x0600B3E0 RID: 46048 RVA: 0x00771070 File Offset: 0x0076F270
		' (set) Token: 0x0600B3E1 RID: 46049 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptStockInward.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170045DE RID: 17886
		' (get) Token: 0x0600B3E2 RID: 46050 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B3E3 RID: 46051 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045DF RID: 17887
		' (get) Token: 0x0600B3E4 RID: 46052 RVA: 0x00771088 File Offset: 0x0076F288
		' (set) Token: 0x0600B3E5 RID: 46053 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptStockInward.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170045E0 RID: 17888
		' (get) Token: 0x0600B3E6 RID: 46054 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170045E1 RID: 17889
		' (get) Token: 0x0600B3E7 RID: 46055 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170045E2 RID: 17890
		' (get) Token: 0x0600B3E8 RID: 46056 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170045E3 RID: 17891
		' (get) Token: 0x0600B3E9 RID: 46057 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170045E4 RID: 17892
		' (get) Token: 0x0600B3EA RID: 46058 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170045E5 RID: 17893
		' (get) Token: 0x0600B3EB RID: 46059 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
