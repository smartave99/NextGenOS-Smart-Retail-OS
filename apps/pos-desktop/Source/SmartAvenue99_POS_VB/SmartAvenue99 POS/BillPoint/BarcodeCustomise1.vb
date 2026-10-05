Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]

Namespace BillPoint
	' Token: 0x02000479 RID: 1145
	Public Class BarcodeCustomise1
		Inherits ReportClass

		' Token: 0x1700597C RID: 22908
		' (get) Token: 0x0600E918 RID: 59672 RVA: 0x008D91C0 File Offset: 0x008D73C0
		' (set) Token: 0x0600E919 RID: 59673 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "BarcodeCustomise1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700597D RID: 22909
		' (get) Token: 0x0600E91A RID: 59674 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600E91B RID: 59675 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x1700597E RID: 22910
		' (get) Token: 0x0600E91C RID: 59676 RVA: 0x008D91D8 File Offset: 0x008D73D8
		' (set) Token: 0x0600E91D RID: 59677 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.BarcodeCustomise1.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700597F RID: 22911
		' (get) Token: 0x0600E91E RID: 59678 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17005980 RID: 22912
		' (get) Token: 0x0600E91F RID: 59679 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17005981 RID: 22913
		' (get) Token: 0x0600E920 RID: 59680 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17005982 RID: 22914
		' (get) Token: 0x0600E921 RID: 59681 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17005983 RID: 22915
		' (get) Token: 0x0600E922 RID: 59682 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property

		' Token: 0x17005984 RID: 22916
		' (get) Token: 0x0600E923 RID: 59683 RVA: 0x006E8584 File Offset: 0x006E6784
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Parameter_P1 As IParameterField
			Get
				Return Me.DataDefinition.ParameterFields(0)
			End Get
		End Property
	End Class
End Namespace
