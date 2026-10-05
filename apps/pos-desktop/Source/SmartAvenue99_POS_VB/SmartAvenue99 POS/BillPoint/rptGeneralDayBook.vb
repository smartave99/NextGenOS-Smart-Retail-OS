Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020005B7 RID: 1463
	Public Class rptGeneralDayBook
		Inherits ReportClass

		' Token: 0x17006EDB RID: 28379
		' (get) Token: 0x06011D95 RID: 73109 RVA: 0x00A4B90C File Offset: 0x00A49B0C
		' (set) Token: 0x06011D96 RID: 73110 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptGeneralDayBook.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006EDC RID: 28380
		' (get) Token: 0x06011D97 RID: 73111 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011D98 RID: 73112 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006EDD RID: 28381
		' (get) Token: 0x06011D99 RID: 73113 RVA: 0x00A4B924 File Offset: 0x00A49B24
		' (set) Token: 0x06011D9A RID: 73114 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptGeneralDayBook.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006EDE RID: 28382
		' (get) Token: 0x06011D9B RID: 73115 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006EDF RID: 28383
		' (get) Token: 0x06011D9C RID: 73116 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006EE0 RID: 28384
		' (get) Token: 0x06011D9D RID: 73117 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006EE1 RID: 28385
		' (get) Token: 0x06011D9E RID: 73118 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006EE2 RID: 28386
		' (get) Token: 0x06011D9F RID: 73119 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006EE3 RID: 28387
		' (get) Token: 0x06011DA0 RID: 73120 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17006EE4 RID: 28388
		' (get) Token: 0x06011DA1 RID: 73121 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
