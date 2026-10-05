Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005AD RID: 1453
	Public Class rptSalesmanLedger
		Inherits ReportClass

		' Token: 0x17006E42 RID: 28226
		' (get) Token: 0x06011C07 RID: 72711 RVA: 0x00A40324 File Offset: 0x00A3E524
		' (set) Token: 0x06011C08 RID: 72712 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptSalesmanLedger.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006E43 RID: 28227
		' (get) Token: 0x06011C09 RID: 72713 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011C0A RID: 72714 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E44 RID: 28228
		' (get) Token: 0x06011C0B RID: 72715 RVA: 0x00A4033C File Offset: 0x00A3E53C
		' (set) Token: 0x06011C0C RID: 72716 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptSalesmanLedger.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006E45 RID: 28229
		' (get) Token: 0x06011C0D RID: 72717 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006E46 RID: 28230
		' (get) Token: 0x06011C0E RID: 72718 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006E47 RID: 28231
		' (get) Token: 0x06011C0F RID: 72719 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006E48 RID: 28232
		' (get) Token: 0x06011C10 RID: 72720 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006E49 RID: 28233
		' (get) Token: 0x06011C11 RID: 72721 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006E4A RID: 28234
		' (get) Token: 0x06011C12 RID: 72722 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006E4B RID: 28235
		' (get) Token: 0x06011C13 RID: 72723 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17006E4C RID: 28236
		' (get) Token: 0x06011C14 RID: 72724 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006E4D RID: 28237
		' (get) Token: 0x06011C15 RID: 72725 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
