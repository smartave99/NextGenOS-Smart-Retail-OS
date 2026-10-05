Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace Microsoft.Office.Interop.Excel
	' Token: 0x0200061E RID: 1566
	<CompilerGenerated()>
	<Guid("000208D8-0000-0000-C000-000000000046")>
	<TypeIdentifier()>
	<ComImport()>
	Public Interface _Worksheet
		' Token: 0x06012DF3 RID: 77299
		Sub _VtblGap1_11()

		' Token: 0x1700751D RID: 29981
		' (get) Token: 0x06012DF4 RID: 77300
		' (set) Token: 0x06012DF5 RID: 77301
		<DispId(110)>
		Property Name As String

		' Token: 0x06012DF6 RID: 77302
		Sub _VtblGap2_32()

		' Token: 0x1700751E RID: 29982
		' (get) Token: 0x06012DF7 RID: 77303
		<DispId(238)>
		ReadOnly Property Cells As Range

		' Token: 0x06012DF8 RID: 77304
		Sub _VtblGap3_5()

		' Token: 0x1700751F RID: 29983
		' (get) Token: 0x06012DF9 RID: 77305
		<DispId(241)>
		ReadOnly Property Columns As Range

		' Token: 0x06012DFA RID: 77306
		Sub _VtblGap4_41()

		' Token: 0x17007520 RID: 29984
		' (get) Token: 0x06012DFB RID: 77307
		<DispId(197)>
		ReadOnly Property Range(Cell1 As Object, Cell2 As Object) As Range

		' Token: 0x06012DFC RID: 77308
		Sub _VtblGap5_1()

		' Token: 0x17007521 RID: 29985
		' (get) Token: 0x06012DFD RID: 77309
		<DispId(258)>
		ReadOnly Property Rows As Range
	End Interface
End Namespace
