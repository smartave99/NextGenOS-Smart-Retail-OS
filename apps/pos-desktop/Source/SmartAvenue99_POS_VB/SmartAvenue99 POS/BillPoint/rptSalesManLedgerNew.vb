Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x020002CB RID: 715
	Public Class rptSalesManLedgerNew
		Inherits ReportClass

		' Token: 0x170045B5 RID: 17845
		' (get) Token: 0x0600B3A4 RID: 45988 RVA: 0x00770FC0 File Offset: 0x0076F1C0
		' (set) Token: 0x0600B3A5 RID: 45989 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptSalesManLedgerNew.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170045B6 RID: 17846
		' (get) Token: 0x0600B3A6 RID: 45990 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B3A7 RID: 45991 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170045B7 RID: 17847
		' (get) Token: 0x0600B3A8 RID: 45992 RVA: 0x00770FD8 File Offset: 0x0076F1D8
		' (set) Token: 0x0600B3A9 RID: 45993 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptSalesManLedgerNew.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170045B8 RID: 17848
		' (get) Token: 0x0600B3AA RID: 45994 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170045B9 RID: 17849
		' (get) Token: 0x0600B3AB RID: 45995 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170045BA RID: 17850
		' (get) Token: 0x0600B3AC RID: 45996 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170045BB RID: 17851
		' (get) Token: 0x0600B3AD RID: 45997 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170045BC RID: 17852
		' (get) Token: 0x0600B3AE RID: 45998 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170045BD RID: 17853
		' (get) Token: 0x0600B3AF RID: 45999 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x170045BE RID: 17854
		' (get) Token: 0x0600B3B0 RID: 46000 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x170045BF RID: 17855
		' (get) Token: 0x0600B3B1 RID: 46001 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P7 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property

		' Token: 0x170045C0 RID: 17856
		' (get) Token: 0x0600B3B2 RID: 46002 RVA: 0x006E85F0 File Offset: 0x006E67F0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P6 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(3)
			End Get
		End Property

		' Token: 0x170045C1 RID: 17857
		' (get) Token: 0x0600B3B3 RID: 46003 RVA: 0x006E8614 File Offset: 0x006E6814
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P5 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(4)
			End Get
		End Property

		' Token: 0x170045C2 RID: 17858
		' (get) Token: 0x0600B3B4 RID: 46004 RVA: 0x006E8638 File Offset: 0x006E6838
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P4 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(5)
			End Get
		End Property

		' Token: 0x170045C3 RID: 17859
		' (get) Token: 0x0600B3B5 RID: 46005 RVA: 0x006E865C File Offset: 0x006E685C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(6)
			End Get
		End Property

		' Token: 0x170045C4 RID: 17860
		' (get) Token: 0x0600B3B6 RID: 46006 RVA: 0x006E8680 File Offset: 0x006E6880
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P8 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(7)
			End Get
		End Property

		' Token: 0x170045C5 RID: 17861
		' (get) Token: 0x0600B3B7 RID: 46007 RVA: 0x006E86A4 File Offset: 0x006E68A4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p9 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(8)
			End Get
		End Property
	End Class
End Namespace
