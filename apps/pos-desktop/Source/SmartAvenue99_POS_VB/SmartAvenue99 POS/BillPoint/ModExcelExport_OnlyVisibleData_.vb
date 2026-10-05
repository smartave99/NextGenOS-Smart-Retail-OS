Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004F5 RID: 1269
	Friend Module ModExcelExport_OnlyVisibleData_
		' Token: 0x06010462 RID: 66658 RVA: 0x009AF394 File Offset: 0x009AD594
		Public Sub ExcelExport(obj As Object)
			Dim flag As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, Nothing, "Columns", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Count", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False), Operators.CompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, Nothing, "Rows", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Count", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)))
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim application As Microsoft.Office.Interop.Excel.Application = CType(Activator.CreateInstance(Marshal.GetTypeFromCLSID(New Guid("00024500-0000-0000-C000-000000000046"))), Microsoft.Office.Interop.Excel.Application)
				application.Visible = True
				Dim application2 As Microsoft.Office.Interop.Excel.Application = application
				application2.Workbooks.Add(XlSheetType.xlWorksheet)
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(application2.ActiveSheet)
				NewLateBinding.LateSet(objectValue, Nothing, "Name", New Object() { "Exported Data" }, Nothing, Nothing)
				Dim dataGridViewColumnCollection As DataGridViewColumnCollection = CType(NewLateBinding.LateGet(obj, Nothing, "Columns", New Object(-1) {}, Nothing, Nothing, Nothing), DataGridViewColumnCollection)
				Dim dataGridViewColumn As DataGridViewColumn = dataGridViewColumnCollection.GetFirstColumn(DataGridViewElementStates.Visible)
				Dim dataGridViewColumn2 As DataGridViewColumn = dataGridViewColumn
				Dim columnCount As Integer = dataGridViewColumnCollection.GetColumnCount(DataGridViewElementStates.Visible)
				Dim num As Integer = columnCount
				For i As Integer = 1 To num
					NewLateBinding.LateSet(objectValue, Nothing, "Cells", New Object() { 1, i, dataGridViewColumn.HeaderText }, Nothing, Nothing)
					dataGridViewColumn = dataGridViewColumnCollection.GetNextColumn(dataGridViewColumn2, DataGridViewElementStates.Visible, DataGridViewElementStates.None)
					dataGridViewColumn2 = dataGridViewColumn
				Next
				Dim objectValue2 As Object
				Dim obj2 As Object
				Dim flag2 As Boolean = ObjectFlowControl.ForLoopControl.ForLoopInitObj(objectValue2, 0, Operators.SubtractObject(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, Nothing, "Rows", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Count", New Object(-1) {}, Nothing, Nothing, Nothing), 1), 1, obj2, objectValue2)
				If flag2 Then
					Do
						dataGridViewColumn = dataGridViewColumnCollection.GetFirstColumn(DataGridViewElementStates.Visible)
						dataGridViewColumn2 = dataGridViewColumn
						Dim num2 As Integer = columnCount
						For j As Integer = 1 To num2
							Dim type As Type = Nothing
							Dim text As String = "Rows"
							Dim array As Object() = New Object() { objectValue2 }
							Dim array2 As Object() = array
							Dim array3 As String() = Nothing
							Dim array4 As Type() = Nothing
							Dim array5 As Boolean() = New Boolean() { True }
							Dim array6 As Boolean() = array5
							Dim obj3 As Object = NewLateBinding.LateGet(obj, type, text, array, array3, array4, array5)
							If array6(0) Then
								objectValue2 = RuntimeHelpers.GetObjectValue(array2(0))
							End If
							Dim objectValue3 As Object = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj3, Nothing, "Cells", New Object() { dataGridViewColumn.Index }, Nothing, Nothing, Nothing), Nothing, "Value", New Object(-1) {}, Nothing, Nothing, Nothing))
							NewLateBinding.LateSet(objectValue, Nothing, "Cells", New Object() { Operators.AddObject(objectValue2, 2), j, objectValue3.ToString() }, Nothing, Nothing)
							dataGridViewColumn = dataGridViewColumnCollection.GetNextColumn(dataGridViewColumn2, DataGridViewElementStates.Visible, DataGridViewElementStates.None)
							dataGridViewColumn2 = dataGridViewColumn
						Next
					Loop While ObjectFlowControl.ForLoopControl.ForNextCheckObj(objectValue2, obj2, objectValue2)
				End If
				Dim objectValue4 As Object = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, Nothing, "UsedRange", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Columns", New Object(-1) {}, Nothing, Nothing, Nothing))
				NewLateBinding.LateCall(objectValue4, Nothing, "AutoFit", New Object(-1) {}, Nothing, Nothing, Nothing, True)
				Dim objectValue5 As Object = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, Nothing, "UsedRange", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Rows", New Object() { "1:1" }, Nothing, Nothing, Nothing))
				NewLateBinding.LateSetComplex(NewLateBinding.LateGet(objectValue5, Nothing, "Font", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Bold", New Object() { True }, Nothing, Nothing, False, True)
				NewLateBinding.LateSet(objectValue5, Nothing, "HorizontalAlignment", New Object() { XlHAlign.xlHAlignCenter }, Nothing, Nothing)
			End If
		End Sub
	End Module
End Namespace
