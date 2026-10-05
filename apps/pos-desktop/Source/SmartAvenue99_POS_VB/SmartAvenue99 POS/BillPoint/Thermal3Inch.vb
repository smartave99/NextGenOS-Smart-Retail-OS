Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x020002EF RID: 751
	Public Class Thermal3Inch
		Inherits ReportClass

		' Token: 0x170048AF RID: 18607
		' (get) Token: 0x0600B752 RID: 46930 RVA: 0x007715F0 File Offset: 0x0076F7F0
		' (set) Token: 0x0600B753 RID: 46931 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "Thermal3Inch.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170048B0 RID: 18608
		' (get) Token: 0x0600B754 RID: 46932 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B755 RID: 46933 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170048B1 RID: 18609
		' (get) Token: 0x0600B756 RID: 46934 RVA: 0x00771608 File Offset: 0x0076F808
		' (set) Token: 0x0600B757 RID: 46935 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.Thermal3Inch.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170048B2 RID: 18610
		' (get) Token: 0x0600B758 RID: 46936 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170048B3 RID: 18611
		' (get) Token: 0x0600B759 RID: 46937 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170048B4 RID: 18612
		' (get) Token: 0x0600B75A RID: 46938 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupHeaderSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170048B5 RID: 18613
		' (get) Token: 0x0600B75B RID: 46939 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170048B6 RID: 18614
		' (get) Token: 0x0600B75C RID: 46940 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property GroupFooterSection1 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170048B7 RID: 18615
		' (get) Token: 0x0600B75D RID: 46941 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x170048B8 RID: 18616
		' (get) Token: 0x0600B75E RID: 46942 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property
	End Class
End Namespace
