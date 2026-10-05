Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x020005F7 RID: 1527
	Public Class rptTurnAround
		Inherits ReportClass

		' Token: 0x170073B9 RID: 29625
		' (get) Token: 0x06012A98 RID: 76440 RVA: 0x00AB9740 File Offset: 0x00AB7940
		' (set) Token: 0x06012A99 RID: 76441 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptTurnAround.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170073BA RID: 29626
		' (get) Token: 0x06012A9A RID: 76442 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06012A9B RID: 76443 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170073BB RID: 29627
		' (get) Token: 0x06012A9C RID: 76444 RVA: 0x00AB9758 File Offset: 0x00AB7958
		' (set) Token: 0x06012A9D RID: 76445 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptTurnAround.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170073BC RID: 29628
		' (get) Token: 0x06012A9E RID: 76446 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170073BD RID: 29629
		' (get) Token: 0x06012A9F RID: 76447 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170073BE RID: 29630
		' (get) Token: 0x06012AA0 RID: 76448 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170073BF RID: 29631
		' (get) Token: 0x06012AA1 RID: 76449 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170073C0 RID: 29632
		' (get) Token: 0x06012AA2 RID: 76450 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property
	End Class
End Namespace
