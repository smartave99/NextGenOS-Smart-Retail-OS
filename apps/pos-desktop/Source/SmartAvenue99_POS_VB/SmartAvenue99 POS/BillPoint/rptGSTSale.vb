Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000542 RID: 1346
	Public Class rptGSTSale
		Inherits ReportClass

		' Token: 0x17006627 RID: 26151
		' (get) Token: 0x06010876 RID: 67702 RVA: 0x009B0454 File Offset: 0x009AE654
		' (set) Token: 0x06010877 RID: 67703 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptGSTSale.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006628 RID: 26152
		' (get) Token: 0x06010878 RID: 67704 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010879 RID: 67705 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006629 RID: 26153
		' (get) Token: 0x0601087A RID: 67706 RVA: 0x009B046C File Offset: 0x009AE66C
		' (set) Token: 0x0601087B RID: 67707 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptGSTSale.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700662A RID: 26154
		' (get) Token: 0x0601087C RID: 67708 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700662B RID: 26155
		' (get) Token: 0x0601087D RID: 67709 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700662C RID: 26156
		' (get) Token: 0x0601087E RID: 67710 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700662D RID: 26157
		' (get) Token: 0x0601087F RID: 67711 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700662E RID: 26158
		' (get) Token: 0x06010880 RID: 67712 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700662F RID: 26159
		' (get) Token: 0x06010881 RID: 67713 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006630 RID: 26160
		' (get) Token: 0x06010882 RID: 67714 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
