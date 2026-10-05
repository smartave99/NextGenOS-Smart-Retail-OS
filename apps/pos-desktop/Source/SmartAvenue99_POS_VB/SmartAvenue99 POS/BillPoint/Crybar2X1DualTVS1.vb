Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000319 RID: 793
	Public Class Crybar2X1DualTVS1
		Inherits ReportClass

		' Token: 0x17004B35 RID: 19253
		' (get) Token: 0x0600BCD9 RID: 48345 RVA: 0x00790210 File Offset: 0x0078E410
		' (set) Token: 0x0600BCDA RID: 48346 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "Crybar2X1DualTVS1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B36 RID: 19254
		' (get) Token: 0x0600BCDB RID: 48347 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600BCDC RID: 48348 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004B37 RID: 19255
		' (get) Token: 0x0600BCDD RID: 48349 RVA: 0x00790228 File Offset: 0x0078E428
		' (set) Token: 0x0600BCDE RID: 48350 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.Crybar2X1DualTVS1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004B38 RID: 19256
		' (get) Token: 0x0600BCDF RID: 48351 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17004B39 RID: 19257
		' (get) Token: 0x0600BCE0 RID: 48352 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17004B3A RID: 19258
		' (get) Token: 0x0600BCE1 RID: 48353 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17004B3B RID: 19259
		' (get) Token: 0x0600BCE2 RID: 48354 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17004B3C RID: 19260
		' (get) Token: 0x0600BCE3 RID: 48355 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17004B3D RID: 19261
		' (get) Token: 0x0600BCE4 RID: 48356 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property

		' Token: 0x17004B3E RID: 19262
		' (get) Token: 0x0600BCE5 RID: 48357 RVA: 0x006E85A8 File Offset: 0x006E67A8
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p2 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(1)
			End Get
		End Property

		' Token: 0x17004B3F RID: 19263
		' (get) Token: 0x0600BCE6 RID: 48358 RVA: 0x006E85CC File Offset: 0x006E67CC
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p3 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(2)
			End Get
		End Property
	End Class
End Namespace
