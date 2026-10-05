Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000518 RID: 1304
	Public Class rptSalarySlip
		Inherits ReportClass

		' Token: 0x1700649A RID: 25754
		' (get) Token: 0x06010617 RID: 67095 RVA: 0x009AFD1C File Offset: 0x009ADF1C
		' (set) Token: 0x06010618 RID: 67096 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptSalarySlip.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700649B RID: 25755
		' (get) Token: 0x06010619 RID: 67097 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601061A RID: 67098 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700649C RID: 25756
		' (get) Token: 0x0601061B RID: 67099 RVA: 0x009AFD34 File Offset: 0x009ADF34
		' (set) Token: 0x0601061C RID: 67100 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptSalarySlip.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700649D RID: 25757
		' (get) Token: 0x0601061D RID: 67101 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700649E RID: 25758
		' (get) Token: 0x0601061E RID: 67102 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700649F RID: 25759
		' (get) Token: 0x0601061F RID: 67103 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170064A0 RID: 25760
		' (get) Token: 0x06010620 RID: 67104 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170064A1 RID: 25761
		' (get) Token: 0x06010621 RID: 67105 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170064A2 RID: 25762
		' (get) Token: 0x06010622 RID: 67106 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_v1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
