Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000305 RID: 773
	Public Class BarcodeCustomise
		Inherits ReportClass

		' Token: 0x1700499A RID: 18842
		' (get) Token: 0x0600B8AB RID: 47275 RVA: 0x00771A00 File Offset: 0x0076FC00
		' (set) Token: 0x0600B8AC RID: 47276 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeCustomise.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700499B RID: 18843
		' (get) Token: 0x0600B8AD RID: 47277 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B8AE RID: 47278 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700499C RID: 18844
		' (get) Token: 0x0600B8AF RID: 47279 RVA: 0x00771A18 File Offset: 0x0076FC18
		' (set) Token: 0x0600B8B0 RID: 47280 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeCustomise.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700499D RID: 18845
		' (get) Token: 0x0600B8B1 RID: 47281 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700499E RID: 18846
		' (get) Token: 0x0600B8B2 RID: 47282 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700499F RID: 18847
		' (get) Token: 0x0600B8B3 RID: 47283 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x170049A0 RID: 18848
		' (get) Token: 0x0600B8B4 RID: 47284 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x170049A1 RID: 18849
		' (get) Token: 0x0600B8B5 RID: 47285 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x170049A2 RID: 18850
		' (get) Token: 0x0600B8B6 RID: 47286 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
