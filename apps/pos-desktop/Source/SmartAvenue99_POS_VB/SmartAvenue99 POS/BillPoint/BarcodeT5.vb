Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200031D RID: 797
	Public Class BarcodeT5
		Inherits ReportClass

		' Token: 0x17004B4F RID: 19279
		' (get) Token: 0x0600BD07 RID: 48391 RVA: 0x007902C0 File Offset: 0x0078E4C0
		' (set) Token: 0x0600BD08 RID: 48392 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeT5.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B50 RID: 19280
		' (get) Token: 0x0600BD09 RID: 48393 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BD0A RID: 48394 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B51 RID: 19281
		' (get) Token: 0x0600BD0B RID: 48395 RVA: 0x007902D8 File Offset: 0x0078E4D8
		' (set) Token: 0x0600BD0C RID: 48396 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeT5.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B52 RID: 19282
		' (get) Token: 0x0600BD0D RID: 48397 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004B53 RID: 19283
		' (get) Token: 0x0600BD0E RID: 48398 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004B54 RID: 19284
		' (get) Token: 0x0600BD0F RID: 48399 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004B55 RID: 19285
		' (get) Token: 0x0600BD10 RID: 48400 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004B56 RID: 19286
		' (get) Token: 0x0600BD11 RID: 48401 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004B57 RID: 19287
		' (get) Token: 0x0600BD12 RID: 48402 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
