Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200059A RID: 1434
	Public Class rptPurchaseOrder
		Inherits ReportClass

		' Token: 0x17006D42 RID: 27970
		' (get) Token: 0x060119CA RID: 72138 RVA: 0x00A34064 File Offset: 0x00A32264
		' (set) Token: 0x060119CB RID: 72139 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptPurchaseOrder.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006D43 RID: 27971
		' (get) Token: 0x060119CC RID: 72140 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x060119CD RID: 72141 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006D44 RID: 27972
		' (get) Token: 0x060119CE RID: 72142 RVA: 0x00A3407C File Offset: 0x00A3227C
		' (set) Token: 0x060119CF RID: 72143 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptPurchaseOrder.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006D45 RID: 27973
		' (get) Token: 0x060119D0 RID: 72144 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006D46 RID: 27974
		' (get) Token: 0x060119D1 RID: 72145 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006D47 RID: 27975
		' (get) Token: 0x060119D2 RID: 72146 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006D48 RID: 27976
		' (get) Token: 0x060119D3 RID: 72147 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006D49 RID: 27977
		' (get) Token: 0x060119D4 RID: 72148 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006D4A RID: 27978
		' (get) Token: 0x060119D5 RID: 72149 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006D4B RID: 27979
		' (get) Token: 0x060119D6 RID: 72150 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17006D4C RID: 27980
		' (get) Token: 0x060119D7 RID: 72151 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
