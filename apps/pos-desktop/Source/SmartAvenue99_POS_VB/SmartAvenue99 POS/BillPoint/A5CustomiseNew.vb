Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x020002F9 RID: 761
	Public Class A5CustomiseNew
		Inherits ReportClass

		' Token: 0x17004917 RID: 18711
		' (get) Token: 0x0600B7EC RID: 47084 RVA: 0x007717F0 File Offset: 0x0076F9F0
		' (set) Token: 0x0600B7ED RID: 47085 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "A5CustomiseNew.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17004918 RID: 18712
		' (get) Token: 0x0600B7EE RID: 47086 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x0600B7EF RID: 47087 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17004919 RID: 18713
		' (get) Token: 0x0600B7F0 RID: 47088 RVA: 0x00771808 File Offset: 0x0076FA08
		' (set) Token: 0x0600B7F1 RID: 47089 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.A5CustomiseNew.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x1700491A RID: 18714
		' (get) Token: 0x0600B7F2 RID: 47090 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x1700491B RID: 18715
		' (get) Token: 0x0600B7F3 RID: 47091 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x1700491C RID: 18716
		' (get) Token: 0x0600B7F4 RID: 47092 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x1700491D RID: 18717
		' (get) Token: 0x0600B7F5 RID: 47093 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x1700491E RID: 18718
		' (get) Token: 0x0600B7F6 RID: 47094 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property
	End Class
End Namespace
