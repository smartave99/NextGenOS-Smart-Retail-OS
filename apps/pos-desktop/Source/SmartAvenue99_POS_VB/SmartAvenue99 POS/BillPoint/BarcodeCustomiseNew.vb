Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000309 RID: 777
	Public Class BarcodeCustomiseNew
		Inherits ReportClass

		' Token: 0x170049B2 RID: 18866
		' (get) Token: 0x0600B8D7 RID: 47319 RVA: 0x00771AB0 File Offset: 0x0076FCB0
		' (set) Token: 0x0600B8D8 RID: 47320 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeCustomiseNew.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170049B3 RID: 18867
		' (get) Token: 0x0600B8D9 RID: 47321 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B8DA RID: 47322 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049B4 RID: 18868
		' (get) Token: 0x0600B8DB RID: 47323 RVA: 0x00771AC8 File Offset: 0x0076FCC8
		' (set) Token: 0x0600B8DC RID: 47324 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeCustomiseNew.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170049B5 RID: 18869
		' (get) Token: 0x0600B8DD RID: 47325 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170049B6 RID: 18870
		' (get) Token: 0x0600B8DE RID: 47326 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170049B7 RID: 18871
		' (get) Token: 0x0600B8DF RID: 47327 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170049B8 RID: 18872
		' (get) Token: 0x0600B8E0 RID: 47328 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170049B9 RID: 18873
		' (get) Token: 0x0600B8E1 RID: 47329 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170049BA RID: 18874
		' (get) Token: 0x0600B8E2 RID: 47330 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
