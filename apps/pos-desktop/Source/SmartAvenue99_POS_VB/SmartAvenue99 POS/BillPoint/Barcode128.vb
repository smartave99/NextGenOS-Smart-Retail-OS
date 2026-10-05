Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000307 RID: 775
	Public Class Barcode128
		Inherits ReportClass

		' Token: 0x170049A6 RID: 18854
		' (get) Token: 0x0600B8C1 RID: 47297 RVA: 0x00771A58 File Offset: 0x0076FC58
		' (set) Token: 0x0600B8C2 RID: 47298 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "Barcode128.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170049A7 RID: 18855
		' (get) Token: 0x0600B8C3 RID: 47299 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B8C4 RID: 47300 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x170049A8 RID: 18856
		' (get) Token: 0x0600B8C5 RID: 47301 RVA: 0x00771A70 File Offset: 0x0076FC70
		' (set) Token: 0x0600B8C6 RID: 47302 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.Barcode128.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x170049A9 RID: 18857
		' (get) Token: 0x0600B8C7 RID: 47303 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x170049AA RID: 18858
		' (get) Token: 0x0600B8C8 RID: 47304 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x170049AB RID: 18859
		' (get) Token: 0x0600B8C9 RID: 47305 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170049AC RID: 18860
		' (get) Token: 0x0600B8CA RID: 47306 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170049AD RID: 18861
		' (get) Token: 0x0600B8CB RID: 47307 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170049AE RID: 18862
		' (get) Token: 0x0600B8CC RID: 47308 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
