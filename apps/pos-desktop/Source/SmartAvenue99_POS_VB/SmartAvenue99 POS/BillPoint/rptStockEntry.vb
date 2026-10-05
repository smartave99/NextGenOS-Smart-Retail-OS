Imports System
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Namespace BillPoint
	' Token: 0x020005B1 RID: 1457
	Public Class rptStockEntry
		Inherits ReportClass

		' Token: 0x17006E5E RID: 28254
		' (get) Token: 0x06011C37 RID: 72759 RVA: 0x00A403D4 File Offset: 0x00A3E5D4
		' (set) Token: 0x06011C38 RID: 72760 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property ResourceName As String
			Get
				Return "rptStockEntry.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006E5F RID: 28255
		' (get) Token: 0x06011C39 RID: 72761 RVA: 0x000B7488 File Offset: 0x000B5688
		' (set) Token: 0x06011C3A RID: 72762 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property NewGenerator As Boolean
			Get
				Return True
			End Get
			Set(value As Boolean)
			End Set
		End Property

		' Token: 0x17006E60 RID: 28256
		' (get) Token: 0x06011C3B RID: 72763 RVA: 0x00A403EC File Offset: 0x00A3E5EC
		' (set) Token: 0x06011C3C RID: 72764 RVA: 0x00009E98 File Offset: 0x00008098
		Public Overrides Property FullResourceName As String
			Get
				Return "BillPoint.rptStockEntry.rpt"
			End Get
			Set(value As String)
			End Set
		End Property

		' Token: 0x17006E61 RID: 28257
		' (get) Token: 0x06011C3D RID: 72765 RVA: 0x006E84D0 File Offset: 0x006E66D0
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section1 As Section
			Get
				Return Me.ReportDefinition.Sections(0)
			End Get
		End Property

		' Token: 0x17006E62 RID: 28258
		' (get) Token: 0x06011C3E RID: 72766 RVA: 0x006E84F4 File Offset: 0x006E66F4
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section2 As Section
			Get
				Return Me.ReportDefinition.Sections(1)
			End Get
		End Property

		' Token: 0x17006E63 RID: 28259
		' (get) Token: 0x06011C3F RID: 72767 RVA: 0x006E8518 File Offset: 0x006E6718
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section3 As Section
			Get
				Return Me.ReportDefinition.Sections(2)
			End Get
		End Property

		' Token: 0x17006E64 RID: 28260
		' (get) Token: 0x06011C40 RID: 72768 RVA: 0x006E853C File Offset: 0x006E673C
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section4 As Section
			Get
				Return Me.ReportDefinition.Sections(3)
			End Get
		End Property

		' Token: 0x17006E65 RID: 28261
		' (get) Token: 0x06011C41 RID: 72769 RVA: 0x006E8560 File Offset: 0x006E6760
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Section5 As Section
			Get
				Return Me.ReportDefinition.Sections(4)
			End Get
		End Property
	End Class
End Namespace
