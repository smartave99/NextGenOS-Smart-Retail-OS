Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005F1 RID: 1521
	Public Class rptStockIn
		Inherits ReportClass

		' Token: 0x17007394 RID: 29588
		' (get) Token: 0x06012A55 RID: 76373 RVA: 0x00AB9638 File Offset: 0x00AB7838
		' (set) Token: 0x06012A56 RID: 76374 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptStockIn.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17007395 RID: 29589
		' (get) Token: 0x06012A57 RID: 76375 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A58 RID: 76376 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17007396 RID: 29590
		' (get) Token: 0x06012A59 RID: 76377 RVA: 0x00AB9650 File Offset: 0x00AB7850
		' (set) Token: 0x06012A5A RID: 76378 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptStockIn.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17007397 RID: 29591
		' (get) Token: 0x06012A5B RID: 76379 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17007398 RID: 29592
		' (get) Token: 0x06012A5C RID: 76380 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17007399 RID: 29593
		' (get) Token: 0x06012A5D RID: 76381 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700739A RID: 29594
		' (get) Token: 0x06012A5E RID: 76382 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700739B RID: 29595
		' (get) Token: 0x06012A5F RID: 76383 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700739C RID: 29596
		' (get) Token: 0x06012A60 RID: 76384 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
