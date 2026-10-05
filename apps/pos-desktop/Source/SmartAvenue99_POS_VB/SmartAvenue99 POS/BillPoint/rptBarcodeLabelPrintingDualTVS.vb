Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000487 RID: 1159
	Public Class rptBarcodeLabelPrintingDualTVS
		Inherits ReportClass

		' Token: 0x170059D0 RID: 22992
		' (get) Token: 0x0600E9B2 RID: 59826 RVA: 0x008D9428 File Offset: 0x008D7628
		' (set) Token: 0x0600E9B3 RID: 59827 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBarcodeLabelPrintingDualTVS.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059D1 RID: 22993
		' (get) Token: 0x0600E9B4 RID: 59828 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E9B5 RID: 59829 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170059D2 RID: 22994
		' (get) Token: 0x0600E9B6 RID: 59830 RVA: 0x008D9440 File Offset: 0x008D7640
		' (set) Token: 0x0600E9B7 RID: 59831 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBarcodeLabelPrintingDualTVS.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170059D3 RID: 22995
		' (get) Token: 0x0600E9B8 RID: 59832 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170059D4 RID: 22996
		' (get) Token: 0x0600E9B9 RID: 59833 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170059D5 RID: 22997
		' (get) Token: 0x0600E9BA RID: 59834 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170059D6 RID: 22998
		' (get) Token: 0x0600E9BB RID: 59835 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170059D7 RID: 22999
		' (get) Token: 0x0600E9BC RID: 59836 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170059D8 RID: 23000
		' (get) Token: 0x0600E9BD RID: 59837 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
