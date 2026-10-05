Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020004F6 RID: 1270
	Public Class rptBalancesheet
		Inherits ReportClass

		' Token: 0x17006391 RID: 25489
		' (get) Token: 0x06010464 RID: 66660 RVA: 0x009AF744 File Offset: 0x009AD944
		' (set) Token: 0x06010465 RID: 66661 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBalancesheet.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006392 RID: 25490
		' (get) Token: 0x06010466 RID: 66662 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010467 RID: 66663 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006393 RID: 25491
		' (get) Token: 0x06010468 RID: 66664 RVA: 0x009AF75C File Offset: 0x009AD95C
		' (set) Token: 0x06010469 RID: 66665 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBalancesheet.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006394 RID: 25492
		' (get) Token: 0x0601046A RID: 66666 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006395 RID: 25493
		' (get) Token: 0x0601046B RID: 66667 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006396 RID: 25494
		' (get) Token: 0x0601046C RID: 66668 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006397 RID: 25495
		' (get) Token: 0x0601046D RID: 66669 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006398 RID: 25496
		' (get) Token: 0x0601046E RID: 66670 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006399 RID: 25497
		' (get) Token: 0x0601046F RID: 66671 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x1700639A RID: 25498
		' (get) Token: 0x06010470 RID: 66672 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property
	End Class
End Namespace
