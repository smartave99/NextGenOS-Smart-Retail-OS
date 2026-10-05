Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x02000562 RID: 1378
	Public Class rptPayment_WithdrawalReceipt
		Inherits ReportClass

		' Token: 0x1700680D RID: 26637
		' (get) Token: 0x06010CCF RID: 68815 RVA: 0x009CB368 File Offset: 0x009C9568
		' (set) Token: 0x06010CD0 RID: 68816 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptPayment_WithdrawalReceipt.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700680E RID: 26638
		' (get) Token: 0x06010CD1 RID: 68817 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010CD2 RID: 68818 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700680F RID: 26639
		' (get) Token: 0x06010CD3 RID: 68819 RVA: 0x009CB380 File Offset: 0x009C9580
		' (set) Token: 0x06010CD4 RID: 68820 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptPayment_WithdrawalReceipt.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006810 RID: 26640
		' (get) Token: 0x06010CD5 RID: 68821 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006811 RID: 26641
		' (get) Token: 0x06010CD6 RID: 68822 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property ReportHeaderSection3 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006812 RID: 26642
		' (get) Token: 0x06010CD7 RID: 68823 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property ReportHeaderSection4 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006813 RID: 26643
		' (get) Token: 0x06010CD8 RID: 68824 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006814 RID: 26644
		' (get) Token: 0x06010CD9 RID: 68825 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17006815 RID: 26645
		' (get) Token: 0x06010CDA RID: 68826 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x17006816 RID: 26646
		' (get) Token: 0x06010CDB RID: 68827 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property
	End Class
End Namespace
