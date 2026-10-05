Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x0200047B RID: 1147
	Public Class rptBarcode2x1New
		Inherits ReportClass

		' Token: 0x17005988 RID: 22920
		' (get) Token: 0x0600E92E RID: 59694 RVA: 0x008D9218 File Offset: 0x008D7418
		' (set) Token: 0x0600E92F RID: 59695 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptBarcode2x1New.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17005989 RID: 22921
		' (get) Token: 0x0600E930 RID: 59696 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E931 RID: 59697 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700598A RID: 22922
		' (get) Token: 0x0600E932 RID: 59698 RVA: 0x008D9230 File Offset: 0x008D7430
		' (set) Token: 0x0600E933 RID: 59699 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptBarcode2x1New.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700598B RID: 22923
		' (get) Token: 0x0600E934 RID: 59700 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700598C RID: 22924
		' (get) Token: 0x0600E935 RID: 59701 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700598D RID: 22925
		' (get) Token: 0x0600E936 RID: 59702 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700598E RID: 22926
		' (get) Token: 0x0600E937 RID: 59703 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700598F RID: 22927
		' (get) Token: 0x0600E938 RID: 59704 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17005990 RID: 22928
		' (get) Token: 0x0600E939 RID: 59705 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
