Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000285 RID: 645
	Public Class CryGift
		Inherits ReportClass

		' Token: 0x17004094 RID: 16532
		' (get) Token: 0x0600A69E RID: 42654 RVA: 0x00700CF8 File Offset: 0x006FEEF8
		' (set) Token: 0x0600A69F RID: 42655 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "CryGift.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004095 RID: 16533
		' (get) Token: 0x0600A6A0 RID: 42656 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600A6A1 RID: 42657 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004096 RID: 16534
		' (get) Token: 0x0600A6A2 RID: 42658 RVA: 0x00700D10 File Offset: 0x006FEF10
		' (set) Token: 0x0600A6A3 RID: 42659 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.CryGift.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004097 RID: 16535
		' (get) Token: 0x0600A6A4 RID: 42660 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004098 RID: 16536
		' (get) Token: 0x0600A6A5 RID: 42661 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004099 RID: 16537
		' (get) Token: 0x0600A6A6 RID: 42662 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700409A RID: 16538
		' (get) Token: 0x0600A6A7 RID: 42663 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700409B RID: 16539
		' (get) Token: 0x0600A6A8 RID: 42664 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700409C RID: 16540
		' (get) Token: 0x0600A6A9 RID: 42665 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Name As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x1700409D RID: 16541
		' (get) Token: 0x0600A6AA RID: 42666 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Contact As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x1700409E RID: 16542
		' (get) Token: 0x0600A6AB RID: 42667 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_GiftCode As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x1700409F RID: 16543
		' (get) Token: 0x0600A6AC RID: 42668 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_GiftAmt As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x170040A0 RID: 16544
		' (get) Token: 0x0600A6AD RID: 42669 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_Validity As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property
	End Class
End Namespace
