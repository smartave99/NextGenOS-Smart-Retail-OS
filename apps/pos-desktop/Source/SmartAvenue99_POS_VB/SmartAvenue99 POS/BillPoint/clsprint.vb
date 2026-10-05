Imports System
Imports System.Data

Namespace BillPoint
	' Token: 0x0200001C RID: 28
	Public Class clsprint
		' Token: 0x060007A8 RID: 1960 RVA: 0x0009EC5C File Offset: 0x0009CE5C
		Public Function PrintDatatable() As DataTable
			Dim dataTable As DataTable = Nothing
			Dim dataTable2 As DataTable = Me.PrintDatatable()
			dataTable2.Columns.Add("PID")
			dataTable2.Columns.Add("HSNC")
			dataTable2.Columns.Add("ProductName")
			dataTable2.Columns.Add("Barcode")
			dataTable2.Columns.Add("MainQty")
			dataTable2.Columns.Add("Rate")
			dataTable2.Columns.Add("DiscPer")
			dataTable2.Columns.Add("Disc")
			dataTable2.Columns.Add("CGSTPer")
			dataTable2.Columns.Add("CGST")
			dataTable2.Columns.Add("SGSTPer")
			dataTable2.Columns.Add("SGST")
			dataTable2.Columns.Add("IGSTPer")
			dataTable2.Columns.Add("IGST")
			dataTable2.Columns.Add("CESSPer")
			dataTable2.Columns.Add("CESS")
			dataTable2.Columns.Add("Total")
			dataTable2.Columns.Add("AltQty")
			dataTable2.Columns.Add("AltUnit")
			dataTable2.Columns.Add("TaxableAmt")
			dataTable2.Columns.Add("MainUnit")
			dataTable2.Columns.Add("PImage")
			Return dataTable
		End Function
	End Class
End Namespace
