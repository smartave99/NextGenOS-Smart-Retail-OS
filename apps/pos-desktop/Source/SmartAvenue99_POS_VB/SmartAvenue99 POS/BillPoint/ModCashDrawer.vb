Imports System
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004F1 RID: 1265
	Friend Module ModCashDrawer
		' Token: 0x020004F2 RID: 1266
		Public Class RawPrinter
			' Token: 0x06010458 RID: 66648
			Public Declare Unicode Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterW" (printerName As String, ByRef hPrinter As IntPtr, printerDefaults As Integer) As Boolean

			' Token: 0x06010459 RID: 66649
			Public Declare Unicode Function ClosePrinter Lib "winspool.drv" (hPrinter As IntPtr) As Boolean

			' Token: 0x0601045A RID: 66650
			Public Declare Unicode Function StartDocPrinter Lib "winspool.drv" Alias "StartDocPrinterW" (hPrinter As IntPtr, level As Integer, ByRef documentInfo As ModCashDrawer.RawPrinter.DOCINFO) As Boolean

			' Token: 0x0601045B RID: 66651
			Public Declare Unicode Function EndDocPrinter Lib "winspool.drv" (hPrinter As IntPtr) As Boolean

			' Token: 0x0601045C RID: 66652
			Public Declare Unicode Function StartPagePrinter Lib "winspool.drv" (hPrinter As IntPtr) As Boolean

			' Token: 0x0601045D RID: 66653
			Public Declare Unicode Function EndPagePrinter Lib "winspool.drv" (hPrinter As IntPtr) As Boolean

			' Token: 0x0601045E RID: 66654
			Public Declare Unicode Function WritePrinter Lib "winspool.drv" (hPrinter As IntPtr, buffer As IntPtr, bufferLength As Integer, ByRef bytesWritten As Integer) As Boolean

			' Token: 0x0601045F RID: 66655 RVA: 0x009AF22C File Offset: 0x009AD42C
			Public Shared Function PrintRaw(printerName As String, origString As String) As Boolean
				Dim docinfo As ModCashDrawer.RawPrinter.DOCINFO = Nothing
				Dim length As Integer = origString.Length
				Dim intPtr As IntPtr = Marshal.StringToCoTaskMemAnsi(origString)
				docinfo.pDocName = "OpenDrawer"
				docinfo.pDataType = "RAW"
				Dim flag As Boolean
				Try
					Dim intPtr2 As IntPtr
					ModCashDrawer.RawPrinter.OpenPrinter(printerName, intPtr2, 0)
					ModCashDrawer.RawPrinter.StartDocPrinter(intPtr2, 1, docinfo)
					ModCashDrawer.RawPrinter.StartPagePrinter(intPtr2)
					Dim num As Integer
					ModCashDrawer.RawPrinter.WritePrinter(intPtr2, intPtr, length, num)
					ModCashDrawer.RawPrinter.EndPagePrinter(intPtr2)
					ModCashDrawer.RawPrinter.EndDocPrinter(intPtr2)
					ModCashDrawer.RawPrinter.ClosePrinter(intPtr2)
					flag = True
				Catch ex As Exception
					Interaction.MsgBox("Error occurred: " + ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
					flag = False
				Finally
					Marshal.FreeCoTaskMem(intPtr)
				End Try
				Return flag
			End Function

			' Token: 0x020004F3 RID: 1267
			<StructLayout(LayoutKind.Sequential, CharSet := CharSet.Unicode)>
			Public Structure DOCINFO
				' Token: 0x040063ED RID: 25581
				<MarshalAs(UnmanagedType.LPWStr)>
				Public pDocName As String

				' Token: 0x040063EE RID: 25582
				<MarshalAs(UnmanagedType.LPWStr)>
				Public pOutputFile As String

				' Token: 0x040063EF RID: 25583
				<MarshalAs(UnmanagedType.LPWStr)>
				Public pDataType As String
			End Structure
		End Class
	End Module
End Namespace
