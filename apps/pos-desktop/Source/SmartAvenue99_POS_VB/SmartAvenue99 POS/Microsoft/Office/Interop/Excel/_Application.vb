Imports System
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace Microsoft.Office.Interop.Excel
	' Token: 0x0200061C RID: 1564
	<CompilerGenerated()>
	<DefaultMember("_Default")>
	<Guid("000208D5-0000-0000-C000-000000000046")>
	<TypeIdentifier()>
	<ComImport()>
	Public Interface _Application
		' Token: 0x06012DE0 RID: 77280
		Sub _VtblGap1_9()

		' Token: 0x17007517 RID: 29975
		' (get) Token: 0x06012DE1 RID: 77281
		<DispId(307)>
		ReadOnly Property ActiveSheet As Object

		' Token: 0x06012DE2 RID: 77282
		Sub _VtblGap2_35()

		' Token: 0x17007518 RID: 29976
		' (get) Token: 0x06012DE3 RID: 77283
		<DispId(572)>
		ReadOnly Property Workbooks As Workbooks

		' Token: 0x06012DE4 RID: 77284
		Sub _VtblGap3_60()

		' Token: 0x17007519 RID: 29977
		' (get) Token: 0x06012DE5 RID: 77285
		<DispId(0)>
		<IndexerName("_Default")>
		ReadOnly Property _Default As String

		' Token: 0x06012DE6 RID: 77286
		Sub _VtblGap4_116()

		' Token: 0x06012DE7 RID: 77287
		<DispId(302)>
		<MethodImpl(MethodImplOptions.InternalCall, MethodCodeType := MethodCodeType.Runtime)>
		Sub Quit()

		' Token: 0x06012DE8 RID: 77288
		Sub _VtblGap5_51()

		' Token: 0x1700751A RID: 29978
		' (get) Token: 0x06012DE9 RID: 77289
		' (set) Token: 0x06012DEA RID: 77290
		<DispId(558)>
		Property Visible As Boolean
	End Interface
End Namespace
