Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000317 RID: 791
	Public Class BarcodeT8
		Inherits ReportClass

		' Token: 0x17004B29 RID: 19241
		' (get) Token: 0x0600BCC3 RID: 48323 RVA: 0x007901B8 File Offset: 0x0078E3B8
		' (set) Token: 0x0600BCC4 RID: 48324 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT8.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B2A RID: 19242
		' (get) Token: 0x0600BCC5 RID: 48325 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BCC6 RID: 48326 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B2B RID: 19243
		' (get) Token: 0x0600BCC7 RID: 48327 RVA: 0x007901D0 File Offset: 0x0078E3D0
		' (set) Token: 0x0600BCC8 RID: 48328 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT8.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B2C RID: 19244
		' (get) Token: 0x0600BCC9 RID: 48329 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004B2D RID: 19245
		' (get) Token: 0x0600BCCA RID: 48330 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004B2E RID: 19246
		' (get) Token: 0x0600BCCB RID: 48331 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004B2F RID: 19247
		' (get) Token: 0x0600BCCC RID: 48332 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004B30 RID: 19248
		' (get) Token: 0x0600BCCD RID: 48333 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004B31 RID: 19249
		' (get) Token: 0x0600BCCE RID: 48334 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
