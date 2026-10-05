Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x0200055E RID: 1374
	Public Class rptFundDepositReceipt
		Inherits ReportClass

		' Token: 0x170067EC RID: 26604
		' (get) Token: 0x06010C9A RID: 68762 RVA: 0x009CB2B8 File Offset: 0x009C94B8
		' (set) Token: 0x06010C9B RID: 68763 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptFundDepositReceipt.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170067ED RID: 26605
		' (get) Token: 0x06010C9C RID: 68764 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06010C9D RID: 68765 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170067EE RID: 26606
		' (get) Token: 0x06010C9E RID: 68766 RVA: 0x009CB2D0 File Offset: 0x009C94D0
		' (set) Token: 0x06010C9F RID: 68767 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptFundDepositReceipt.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170067EF RID: 26607
		' (get) Token: 0x06010CA0 RID: 68768 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170067F0 RID: 26608
		' (get) Token: 0x06010CA1 RID: 68769 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property ReportHeaderSection3 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170067F1 RID: 26609
		' (get) Token: 0x06010CA2 RID: 68770 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property ReportHeaderSection4 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170067F2 RID: 26610
		' (get) Token: 0x06010CA3 RID: 68771 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170067F3 RID: 26611
		' (get) Token: 0x06010CA4 RID: 68772 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170067F4 RID: 26612
		' (get) Token: 0x06010CA5 RID: 68773 RVA: 0x006E904C File Offset: 0x006E724C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(5)
			End Get
		End Property

		' Token: 0x170067F5 RID: 26613
		' (get) Token: 0x06010CA6 RID: 68774 RVA: 0x00700CAC File Offset: 0x006FEEAC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(6)
			End Get
		End Property
	End Class
End Namespace
