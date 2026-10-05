Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace Microsoft.Office.Interop.Excel
	' Token: 0x02000611 RID: 1553
	<CompilerGenerated()>
	<Guid("00020846-0000-0000-C000-000000000046")>
	<InterfaceType(2S)>
	<TypeIdentifier()>
	<ComImport()>
	Public Interface Range
		' Token: 0x06012DC9 RID: 77257
		Sub _VtblGap1_15()

		' Token: 0x06012DCA RID: 77258
		<DispId(237)>
		<MethodImpl(MethodImplOptions.PreserveSig Or MethodImplOptions.InternalCall, MethodCodeType := MethodCodeType.Runtime)>
		Function AutoFit() As <MarshalAs(UnmanagedType.Struct)> Object

		' Token: 0x06012DCB RID: 77259
		Sub _VtblGap2_15()

		' Token: 0x17007510 RID: 29968
		' (get) Token: 0x06012DCC RID: 77260
		<DispId(241)>
		ReadOnly Property Columns As Range

		' Token: 0x06012DCD RID: 77261
		Sub _VtblGap3_13()

		' Token: 0x17007511 RID: 29969
		<DispId(0)>
		<IndexerName("_Default")>
		Default Property Item(<MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> RowIndex As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> ColumnIndex As Object) As Object

		' Token: 0x06012DD0 RID: 77264
		<DispId(117)>
		<MethodImpl(MethodImplOptions.PreserveSig Or MethodImplOptions.InternalCall, MethodCodeType := MethodCodeType.Runtime)>
		Function Delete(<MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> Shift As Object) As <MarshalAs(UnmanagedType.Struct)> Object

		' Token: 0x06012DD1 RID: 77265
		Sub _VtblGap4_6()

		' Token: 0x17007512 RID: 29970
		' (get) Token: 0x06012DD2 RID: 77266
		<DispId(246)>
		ReadOnly Property EntireColumn As Range

		' Token: 0x06012DD3 RID: 77267
		Sub _VtblGap5_8()

		' Token: 0x17007513 RID: 29971
		' (get) Token: 0x06012DD4 RID: 77268
		<DispId(146)>
		ReadOnly Property Font As Font

		' Token: 0x06012DD5 RID: 77269
		Sub _VtblGap6_81()

		' Token: 0x06012DD6 RID: 77270
		<DispId(235)>
		<MethodImpl(MethodImplOptions.PreserveSig Or MethodImplOptions.InternalCall, MethodCodeType := MethodCodeType.Runtime)>
		Function [Select]() As <MarshalAs(UnmanagedType.Struct)> Object

		' Token: 0x06012DD7 RID: 77271
		Sub _VtblGap7_27()

		' Token: 0x17007514 RID: 29972
		' (get) Token: 0x06012DD8 RID: 77272
		' (set) Token: 0x06012DD9 RID: 77273
		<DispId(6)>
		Property Value(RangeValueDataType As Object) As Object
	End Interface
End Namespace
