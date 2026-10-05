Imports System
Imports System.Collections
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace Microsoft.Office.Interop.Excel
	' Token: 0x02000616 RID: 1558
	<CompilerGenerated()>
	<Guid("000208DB-0000-0000-C000-000000000046")>
	<TypeIdentifier()>
	<ComImport()>
	Public Interface Workbooks
		Inherits IEnumerable

		' Token: 0x06012DDC RID: 77276
		Sub _VtblGap1_3()

		' Token: 0x06012DDD RID: 77277
		<DispId(181)>
		<LCIDConversion(1)>
		<MethodImpl(MethodImplOptions.InternalCall, MethodCodeType := MethodCodeType.Runtime)>
		Function Add(<MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> Template As Object) As <MarshalAs(UnmanagedType.[Interface])> Workbook

		' Token: 0x06012DDE RID: 77278
		Sub _VtblGap2_6()

		' Token: 0x17007516 RID: 29974
		<DispId(0)>
		<IndexerName("_Default")>
		ReadOnly Default Property Item(<MarshalAs(UnmanagedType.Struct)> <[In]()> Index As Object) As Workbook
	End Interface
End Namespace
