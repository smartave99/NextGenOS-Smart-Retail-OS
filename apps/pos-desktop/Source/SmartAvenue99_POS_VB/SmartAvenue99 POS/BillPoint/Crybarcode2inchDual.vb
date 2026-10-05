Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200047D RID: 1149
	Public Class Crybarcode2inchDual
		Inherits ReportClass

		' Token: 0x17005994 RID: 22932
		' (get) Token: 0x0600E944 RID: 59716 RVA: 0x008D9270 File Offset: 0x008D7470
		' (set) Token: 0x0600E945 RID: 59717 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "Crybarcode2inchDual.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17005995 RID: 22933
		' (get) Token: 0x0600E946 RID: 59718 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E947 RID: 59719 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17005996 RID: 22934
		' (get) Token: 0x0600E948 RID: 59720 RVA: 0x008D9288 File Offset: 0x008D7488
		' (set) Token: 0x0600E949 RID: 59721 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.Crybarcode2inchDual.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17005997 RID: 22935
		' (get) Token: 0x0600E94A RID: 59722 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17005998 RID: 22936
		' (get) Token: 0x0600E94B RID: 59723 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17005999 RID: 22937
		' (get) Token: 0x0600E94C RID: 59724 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700599A RID: 22938
		' (get) Token: 0x0600E94D RID: 59725 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700599B RID: 22939
		' (get) Token: 0x0600E94E RID: 59726 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x1700599C RID: 22940
		' (get) Token: 0x0600E94F RID: 59727 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_p1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
