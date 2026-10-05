Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002B1 RID: 689
	Public Class rptBarcodeCipher
		Inherits ReportClass

		' Token: 0x170044E0 RID: 17632
		' (get) Token: 0x0600B24D RID: 45645 RVA: 0x00770B24 File Offset: 0x0076ED24
		' (set) Token: 0x0600B24E RID: 45646 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBarcodeCipher.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170044E1 RID: 17633
		' (get) Token: 0x0600B24F RID: 45647 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B250 RID: 45648 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170044E2 RID: 17634
		' (get) Token: 0x0600B251 RID: 45649 RVA: 0x00770B3C File Offset: 0x0076ED3C
		' (set) Token: 0x0600B252 RID: 45650 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBarcodeCipher.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170044E3 RID: 17635
		' (get) Token: 0x0600B253 RID: 45651 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170044E4 RID: 17636
		' (get) Token: 0x0600B254 RID: 45652 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170044E5 RID: 17637
		' (get) Token: 0x0600B255 RID: 45653 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170044E6 RID: 17638
		' (get) Token: 0x0600B256 RID: 45654 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170044E7 RID: 17639
		' (get) Token: 0x0600B257 RID: 45655 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170044E8 RID: 17640
		' (get) Token: 0x0600B258 RID: 45656 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
