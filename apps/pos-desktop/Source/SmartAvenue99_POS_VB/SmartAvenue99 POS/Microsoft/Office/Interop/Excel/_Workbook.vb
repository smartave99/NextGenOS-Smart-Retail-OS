Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace Microsoft.Office.Interop.Excel
	' Token: 0x0200061D RID: 1565
	<CompilerGenerated()>
	<Guid("000208DA-0000-0000-C000-000000000046")>
	<TypeIdentifier()>
	<ComImport()>
	Public Interface _Workbook
		' Token: 0x06012DEB RID: 77291
		Sub _VtblGap1_20()

		' Token: 0x06012DEC RID: 77292
		<LCIDConversion(3)>
		<DispId(277)>
		<MethodImpl(MethodImplOptions.InternalCall, MethodCodeType := MethodCodeType.Runtime)>
		Sub Close(<MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> SaveChanges As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> Filename As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> RouteWorkbook As Object)

		' Token: 0x06012DED RID: 77293
		Sub _VtblGap2_84()

		' Token: 0x1700751B RID: 29979
		' (get) Token: 0x06012DEE RID: 77294
		<DispId(485)>
		ReadOnly Property Sheets As Sheets

		' Token: 0x06012DEF RID: 77295
		Sub _VtblGap3_18()

		' Token: 0x1700751C RID: 29980
		' (get) Token: 0x06012DF0 RID: 77296
		<DispId(494)>
		ReadOnly Property Worksheets As Sheets

		' Token: 0x06012DF1 RID: 77297
		Sub _VtblGap4_40()

		' Token: 0x06012DF2 RID: 77298
		<DispId(1925)>
		<LCIDConversion(12)>
		<MethodImpl(MethodImplOptions.InternalCall, MethodCodeType := MethodCodeType.Runtime)>
		Sub SaveAs(<MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> Filename As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> FileFormat As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> Password As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> WriteResPassword As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> ReadOnlyRecommended As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> CreateBackup As Object, <[In]()> Optional AccessMode As XlSaveAsAccessMode = XlSaveAsAccessMode.xlNoChange, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> ConflictResolution As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> AddToMru As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> TextCodepage As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> TextVisualLayout As Object, <MarshalAs(UnmanagedType.Struct)> <[In]()> <[Optional]()> Local As Object)
	End Interface
End Namespace
