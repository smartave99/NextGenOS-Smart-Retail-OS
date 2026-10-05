Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200030B RID: 779
	Public Class BarcodeT3
		Inherits ReportClass

		' Token: 0x170049BE RID: 18878
		' (get) Token: 0x0600B8ED RID: 47341 RVA: 0x00771B08 File Offset: 0x0076FD08
		' (set) Token: 0x0600B8EE RID: 47342 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT3.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170049BF RID: 18879
		' (get) Token: 0x0600B8EF RID: 47343 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B8F0 RID: 47344 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049C0 RID: 18880
		' (get) Token: 0x0600B8F1 RID: 47345 RVA: 0x00771B20 File Offset: 0x0076FD20
		' (set) Token: 0x0600B8F2 RID: 47346 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT3.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170049C1 RID: 18881
		' (get) Token: 0x0600B8F3 RID: 47347 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170049C2 RID: 18882
		' (get) Token: 0x0600B8F4 RID: 47348 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170049C3 RID: 18883
		' (get) Token: 0x0600B8F5 RID: 47349 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170049C4 RID: 18884
		' (get) Token: 0x0600B8F6 RID: 47350 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170049C5 RID: 18885
		' (get) Token: 0x0600B8F7 RID: 47351 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170049C6 RID: 18886
		' (get) Token: 0x0600B8F8 RID: 47352 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
