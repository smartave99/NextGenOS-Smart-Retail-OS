Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002C7 RID: 711
	Public Class rptSaleDayBook
		Inherits ReportClass

		' Token: 0x17004597 RID: 17815
		' (get) Token: 0x0600B372 RID: 45938 RVA: 0x00770F10 File Offset: 0x0076F110
		' (set) Token: 0x0600B373 RID: 45939 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptSaleDayBook.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004598 RID: 17816
		' (get) Token: 0x0600B374 RID: 45940 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B375 RID: 45941 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004599 RID: 17817
		' (get) Token: 0x0600B376 RID: 45942 RVA: 0x00770F28 File Offset: 0x0076F128
		' (set) Token: 0x0600B377 RID: 45943 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptSaleDayBook.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700459A RID: 17818
		' (get) Token: 0x0600B378 RID: 45944 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700459B RID: 17819
		' (get) Token: 0x0600B379 RID: 45945 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700459C RID: 17820
		' (get) Token: 0x0600B37A RID: 45946 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700459D RID: 17821
		' (get) Token: 0x0600B37B RID: 45947 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700459E RID: 17822
		' (get) Token: 0x0600B37C RID: 45948 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700459F RID: 17823
		' (get) Token: 0x0600B37D RID: 45949 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170045A0 RID: 17824
		' (get) Token: 0x0600B37E RID: 45950 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170045A1 RID: 17825
		' (get) Token: 0x0600B37F RID: 45951 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_pa As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
