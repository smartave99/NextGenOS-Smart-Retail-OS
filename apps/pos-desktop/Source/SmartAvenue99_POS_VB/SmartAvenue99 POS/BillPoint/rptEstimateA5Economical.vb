Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200050C RID: 1292
	Public Class rptEstimateA5Economical
		Inherits ReportClass

		' Token: 0x17006428 RID: 25640
		' (get) Token: 0x06010569 RID: 66921 RVA: 0x009AFB0C File Offset: 0x009ADD0C
		' (set) Token: 0x0601056A RID: 66922 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptEstimateA5Economical.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006429 RID: 25641
		' (get) Token: 0x0601056B RID: 66923 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0601056C RID: 66924 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700642A RID: 25642
		' (get) Token: 0x0601056D RID: 66925 RVA: 0x009AFB24 File Offset: 0x009ADD24
		' (set) Token: 0x0601056E RID: 66926 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptEstimateA5Economical.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700642B RID: 25643
		' (get) Token: 0x0601056F RID: 66927 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700642C RID: 25644
		' (get) Token: 0x06010570 RID: 66928 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700642D RID: 25645
		' (get) Token: 0x06010571 RID: 66929 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700642E RID: 25646
		' (get) Token: 0x06010572 RID: 66930 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700642F RID: 25647
		' (get) Token: 0x06010573 RID: 66931 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006430 RID: 25648
		' (get) Token: 0x06010574 RID: 66932 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006431 RID: 25649
		' (get) Token: 0x06010575 RID: 66933 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property

		' Token: 0x17006432 RID: 25650
		' (get) Token: 0x06010576 RID: 66934 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
