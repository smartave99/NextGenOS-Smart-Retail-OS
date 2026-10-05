Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports FireSharp
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x020005EA RID: 1514
	Friend Module ModFunc
		' Token: 0x060129BE RID: 76222 RVA: 0x007049DC File Offset: 0x00702BDC
		Public Function CheckForInternetConnection() As Boolean
			Thread.Sleep(1000)
			Dim flag As Boolean
			Try
				Using webClient As WebClient = New WebClient()
					Using webClient.OpenRead("http://www.google.com")
						flag = True
					End Using
				End Using
			Catch ex As Exception
				flag = False
			End Try
			Return flag
		End Function

		' Token: 0x060129BF RID: 76223 RVA: 0x00AB5FD4 File Offset: 0x00AB41D4
		Public Function CheckGoogleChromeInstalledVersion() As String
			Dim text As String = "SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Google Chrome"
			Dim text2 As String = "DisplayVersion"
			Try
				Using registryKey As RegistryKey = Registry.LocalMachine.OpenSubKey(text)
					Dim flag As Boolean = registryKey IsNot Nothing
					If flag Then
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(registryKey.GetValue(text2))
						Dim flag2 As Boolean = objectValue IsNot Nothing
						If flag2 Then
							Return objectValue.ToString()
						End If
					End If
				End Using
			Catch ex As Exception
			End Try
			Return Nothing
		End Function

		' Token: 0x060129C0 RID: 76224 RVA: 0x00AB6070 File Offset: 0x00AB4270
		Public Function GetValue(Id As String) As String
			Dim firebaseClient As IFirebaseClient = New FirebaseClient(New FirebaseConfig() With { .AuthSecret = NextGenOS.Licensing.CloudSettings.Secret("data"), .BasePath = NextGenOS.Licensing.CloudSettings.Url("data") })
			Return firebaseClient.[Get]("/" + Id + "/Data2").ResultAs(Of String)()
		End Function

		' Token: 0x060129C1 RID: 76225 RVA: 0x00AB60C8 File Offset: 0x00AB42C8
		Public Function GetValue1(Id As String) As String
			Dim firebaseClient As IFirebaseClient = New FirebaseClient(New FirebaseConfig() With { .AuthSecret = NextGenOS.Licensing.CloudSettings.Secret("updates"), .BasePath = NextGenOS.Licensing.CloudSettings.Url("updates") })
			Return firebaseClient.[Get]("/" + Id + "/Data2").ResultAs(Of String)()
		End Function

		' Token: 0x060129C2 RID: 76226 RVA: 0x00AB6120 File Offset: 0x00AB4320
		Public Sub ProductSMSave(st1 As Integer, st3 As Decimal, st4 As Decimal, st5 As Decimal, st6 As DateTime, st7 As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into StockMovement(ProductID,OpeningStock,StockIn,StockOut,Date,TransID) VALUES (@d1,@d3,@d4,@d5,@d6,@d7)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", st1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", st3)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", st4)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", st5)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", st6)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", st7)
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129C3 RID: 76227 RVA: 0x00AB6220 File Offset: 0x00AB4420
		Public Sub SMS(st1 As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into SMS(Message,Date) VALUES (@d1,@d2)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", st1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", DateTime.Now)
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129C4 RID: 76228 RVA: 0x00AB62B4 File Offset: 0x00AB44B4
		Public Sub LogFunc(st1 As String, st2 As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into Logs(UserID,Date,Operation) VALUES (@d1,@d2,@d3)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", st1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", DateTime.Now)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", st2)
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129C5 RID: 76229 RVA: 0x00AB6360 File Offset: 0x00AB4560
		Public Function SMSFunc(st1 As String, st2 As String, st3 As String) As Object
			st3 = st3.Replace("@MobileNo", st1).Replace("@Message", System.Web.HttpUtility.UrlEncode(st2))
			Dim webClient As WebClient = New WebClient()
			Dim text As String = webClient.DownloadString(st3)
			Console.WriteLine(text)
			Return text
		End Function

		' Token: 0x060129C6 RID: 76230 RVA: 0x00AB63A8 File Offset: 0x00AB45A8
		Public Function Encrypt(password As String) As String
			Dim empty As String = String.Empty
			Dim array As Byte() = New Byte(password.Length - 1 + 1 - 1) {}
			array = Encoding.UTF8.GetBytes(password)
			Return Convert.ToBase64String(array)
		End Function

		' Token: 0x060129C7 RID: 76231 RVA: 0x00AB63E4 File Offset: 0x00AB45E4
		Public Function Decrypt(encryptpwd As String) As String
			Dim empty As String = String.Empty
			Dim utf8Encoding As UTF8Encoding = New UTF8Encoding()
			Dim decoder As Decoder = utf8Encoding.GetDecoder()
			Dim array As Byte() = Convert.FromBase64String(encryptpwd)
			Dim charCount As Integer = decoder.GetCharCount(array, 0, array.Length)
			Dim array2 As Char() = New Char(charCount - 1 + 1 - 1) {}
			decoder.GetChars(array, 0, array.Length, array2, 0)
			Return New String(array2)
		End Function

		' Token: 0x060129C8 RID: 76232 RVA: 0x00AB6448 File Offset: 0x00AB4648
		Public Function MD5Encrypt(strtext As String) As String
			Dim md5CryptoServiceProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
			Dim array As Byte() = md5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(strtext))
			Dim text As String
			For Each b As Byte In array
				text += b.ToString("x2")
			Next
			Return text
		End Function

		' Token: 0x060129C9 RID: 76233 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub RefreshRecords()
		End Sub

		' Token: 0x060129CA RID: 76234 RVA: 0x00AB64AC File Offset: 0x00AB46AC
		Public Sub ExportExcel(obj As Object)
			Cursor.Current = Cursors.WaitCursor
			Dim application As Microsoft.Office.Interop.Excel.Application = CType(Activator.CreateInstance(Marshal.GetTypeFromCLSID(New Guid("00024500-0000-0000-C000-000000000046"))), Microsoft.Office.Interop.Excel.Application)
			Try
				Dim workbook As Workbook = application.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value))
				Dim worksheet As Worksheet = CType(workbook.Worksheets(1), Worksheet)
				application.Visible = True
				Dim num As Short = Conversions.ToShort(NewLateBinding.LateGet(obj, Nothing, "RowCount", New Object(-1) {}, Nothing, Nothing, Nothing))
				Dim num2 As Short = Conversions.ToShort(Operators.SubtractObject(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, Nothing, "Columns", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Count", New Object(-1) {}, Nothing, Nothing, Nothing), 1))
				Dim worksheet2 As Worksheet = worksheet
				worksheet2.Cells.[Select]()
				worksheet2.Cells.Delete(RuntimeHelpers.GetObjectValue(Missing.Value))
				Dim num3 As Short = num2
				For num4 As Short = 0S To num3
					' The following expression was wrapped in a checked-expression
					Dim obj2 As Object = worksheet2.Cells(1, CInt((num4 + 1S)))
					Dim type As Type = Nothing
					Dim text As String = "Value"
					Dim array As Object() = New Object(0) {}
					Dim num5 As Integer = 0
					Dim type2 As Type = Nothing
					Dim text2 As String = "Columns"
					Dim array2 As Object() = New Object() { num4 }
					Dim array3 As Object() = array2
					Dim array4 As String() = Nothing
					Dim array5 As Type() = Nothing
					Dim array6 As Boolean() = New Boolean() { True }
					Dim array7 As Boolean() = array6
					Dim obj3 As Object = NewLateBinding.LateGet(obj, type2, text2, array2, array4, array5, array6)
					If array7(0) Then
						num4 = CShort(Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3(0)), GetType(Short)))
					End If
					array(num5) = NewLateBinding.LateGet(obj3, Nothing, "HeaderText", New Object(-1) {}, Nothing, Nothing, Nothing)
					NewLateBinding.LateSetComplex(obj2, type, text, array, Nothing, Nothing, False, True)
				Next
				Dim num6 As Short = num - 1S
				For num7 As Short = 0S To num6
					Dim num8 As Short = num2
					For num9 As Short = 0S To num8
						' The following expression was wrapped in a checked-expression
						Dim obj4 As Object = worksheet2.Cells(CInt((num7 + 2S)), CInt((num9 + 1S)))
						Dim type3 As Type = Nothing
						Dim text3 As String = "value"
						Dim array8 As Object() = New Object(0) {}
						Dim num10 As Integer = 0
						Dim type4 As Type = Nothing
						Dim text4 As String = "Rows"
						Dim array9 As Object() = New Object() { num7 }
						Dim array10 As Object() = array9
						Dim array11 As String() = Nothing
						Dim array12 As Type() = Nothing
						Dim array13 As Boolean() = New Boolean() { True }
						Dim array14 As Boolean() = array13
						Dim obj5 As Object = NewLateBinding.LateGet(obj, type4, text4, array9, array11, array12, array13)
						If array14(0) Then
							num7 = CShort(Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array10(0)), GetType(Short)))
						End If
						Dim obj6 As Object = obj5
						Dim type5 As Type = Nothing
						Dim text5 As String = "Cells"
						Dim array15 As Object() = New Object() { num9 }
						Dim array3 As Object() = array15
						Dim array16 As String() = Nothing
						Dim array17 As Type() = Nothing
						Dim array18 As Boolean() = New Boolean() { True }
						Dim array7 As Boolean() = array18
						Dim obj3 As Object = NewLateBinding.LateGet(obj6, type5, text5, array15, array16, array17, array18)
						If array7(0) Then
							num9 = CShort(Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3(0)), GetType(Short)))
						End If
						array8(num10) = NewLateBinding.LateGet(obj3, Nothing, "Value", New Object(-1) {}, Nothing, Nothing, Nothing)
						NewLateBinding.LateSetComplex(obj4, type3, text3, array8, Nothing, Nothing, False, True)
					Next
				Next
				NewLateBinding.LateSetComplex(NewLateBinding.LateGet(worksheet2.Rows("1:1", RuntimeHelpers.GetObjectValue(Missing.Value)), Nothing, "Font", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "FontStyle", New Object() { "Bold" }, Nothing, Nothing, False, True)
				NewLateBinding.LateSetComplex(NewLateBinding.LateGet(worksheet2.Rows("1:1", RuntimeHelpers.GetObjectValue(Missing.Value)), Nothing, "Font", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Size", New Object() { 12 }, Nothing, Nothing, False, True)
				worksheet2.Cells.Columns.AutoFit()
				worksheet2.Cells.[Select]()
				worksheet2.Cells.EntireColumn.AutoFit()
				NewLateBinding.LateCall(worksheet2.Cells(1, 1), Nothing, "Select", New Object(-1) {}, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Cursor.Current = Cursors.[Default]
			End Try
		End Sub

		' Token: 0x060129CB RID: 76235 RVA: 0x00AB68EC File Offset: 0x00AB4AEC
		Public Sub LedgerSave(a As DateTime, b As String, c As String, d As String, e As Decimal, f As Decimal, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into LedgerBook(Date, Name, LedgerNo, Label,Debit,Credit,PartyID,PartyName) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129CC RID: 76236 RVA: 0x00AB6A10 File Offset: 0x00AB4C10
		Public Sub LedgerDelete(a As String, b As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from LedgerBook where LedgerNo=@d1 and Label=@d2"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129CD RID: 76237 RVA: 0x00AB6A9C File Offset: 0x00AB4C9C
		Public Sub SaleNOTax(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SaleNoTax where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129CE RID: 76238 RVA: 0x00AB6B14 File Offset: 0x00AB4D14
		Public Sub SaleGST(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SaleGST where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129CF RID: 76239 RVA: 0x00AB6B8C File Offset: 0x00AB4D8C
		Public Sub QuotationNOTax(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from QuotationNoTax where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D0 RID: 76240 RVA: 0x00AB6C04 File Offset: 0x00AB4E04
		Public Sub QuotationGST(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from QuotationGST where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D1 RID: 76241 RVA: 0x00AB6C7C File Offset: 0x00AB4E7C
		Public Sub PurcNOTax(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from PurcNoTax where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D2 RID: 76242 RVA: 0x00AB6CF4 File Offset: 0x00AB4EF4
		Public Sub PurcGST(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from PurcGST where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D3 RID: 76243 RVA: 0x00AB6D6C File Offset: 0x00AB4F6C
		Public Sub SrEstimateDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrEstimate where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D4 RID: 76244 RVA: 0x00AB6DE4 File Offset: 0x00AB4FE4
		Public Sub SrSaleReturnDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrSaleReturn where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D5 RID: 76245 RVA: 0x00AB6E5C File Offset: 0x00AB505C
		Public Sub SrQuotationDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrQuotation where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D6 RID: 76246 RVA: 0x00AB6ED4 File Offset: 0x00AB50D4
		Public Sub SrPurReturnDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrPurReturn where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D7 RID: 76247 RVA: 0x00AB6F4C File Offset: 0x00AB514C
		Public Sub SrPurOrderDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrPurOrder where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D8 RID: 76248 RVA: 0x00AB6FC4 File Offset: 0x00AB51C4
		Public Sub SrReceiptDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrReceipt where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129D9 RID: 76249 RVA: 0x00AB703C File Offset: 0x00AB523C
		Public Sub SrPaymentDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrPayment where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129DA RID: 76250 RVA: 0x00AB70B4 File Offset: 0x00AB52B4
		Public Sub SrIncomeDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrIncome where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129DB RID: 76251 RVA: 0x00AB712C File Offset: 0x00AB532C
		Public Sub SrExpensesDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrExpenses where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129DC RID: 76252 RVA: 0x00AB71A4 File Offset: 0x00AB53A4
		Public Sub SrServiceDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrService where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129DD RID: 76253 RVA: 0x00AB721C File Offset: 0x00AB541C
		Public Sub SrSerBillDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SrSerBill where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129DE RID: 76254 RVA: 0x00AB7294 File Offset: 0x00AB5494
		Public Sub LedgerUpdate(a As DateTime, b As String, e As Decimal, f As Decimal, g As String, h As String, i As String, j As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update LedgerBook set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4,PartyID=@d5,PartyName=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", i)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", j)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129DF RID: 76255 RVA: 0x00AB73B8 File Offset: 0x00AB55B8
		Public Sub LedgerUpdate1(b As String, e As Decimal, f As Decimal, g As String, h As String, i As String, j As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update LedgerBook set Name=@d2,Debit=@d3,Credit=@d4,PartyID=@d5,PartyName=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", i)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", j)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129E0 RID: 76256 RVA: 0x00AB74C0 File Offset: 0x00AB56C0
		Public Sub SupplierLedgerSave(a As DateTime, b As String, c As String, d As String, e As Decimal, f As Decimal, g As String, h As String, i As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into SupplierLedgerBook(Date, Name, LedgerNo, Label,Debit,Credit,PartyID,SuplNameid,Remarks) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d9", i)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129E1 RID: 76257 RVA: 0x00AB75FC File Offset: 0x00AB57FC
		Public Sub CustDiscSave(a As String, b As DateTime, c As String, d As String, e As String, f As Decimal, g As Decimal, h As String, i As Decimal, j As String, k As String, l As String, m As String, n As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into CustDiscApply(InvNo, InvDate, CustName, CustAddress, CustContact, InvAmt, InvTaxAmt, AppliedDiscPer, AppliedDiscAmt, ByBroker, BrokerID, BrokerContact, Item, BCode) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d9", i)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d10", j)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d11", k)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d12", l)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d13", m)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d14", n)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129E2 RID: 76258 RVA: 0x00AB77B0 File Offset: 0x00AB59B0
		Public Sub CustDiscDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from CustDiscApply where InvNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129E3 RID: 76259 RVA: 0x00AB7828 File Offset: 0x00AB5A28
		Public Sub SendMail(s1 As String, s2 As String, s3 As String, s5 As String, s6 As String, s7 As Integer, s8 As String, s9 As String)
			Dim mailMessage As MailMessage = New MailMessage()
			Try
				mailMessage.From = New MailAddress(s1)
				mailMessage.[To].Add(s2)
				mailMessage.Body = s3
				mailMessage.IsBodyHtml = True
				mailMessage.Subject = s5
				Dim smtpClient1 As New SmtpClient(s6) With { .Port = s7, .Credentials = New NetworkCredential(s8, s9), .EnableSsl = True }
				smtpClient1.Send(mailMessage)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060129E4 RID: 76260 RVA: 0x00AB78D8 File Offset: 0x00AB5AD8
		Public Sub SendMail1(s1 As String, s2 As String, s3 As String, s4 As String, s5 As String, s6 As String, s7 As Integer, s8 As String, s9 As String)
			Dim mailMessage As MailMessage = New MailMessage()
			Try
				mailMessage.From = New MailAddress(s1)
				mailMessage.[To].Add(s2)
				mailMessage.Body = s3
				mailMessage.Attachments.Add(New Attachment(s4))
				mailMessage.IsBodyHtml = True
				mailMessage.Subject = s5
				Dim smtpClient1 As New SmtpClient(s6) With { .Port = s7, .Credentials = New NetworkCredential(s8, s9), .EnableSsl = True }
				smtpClient1.Send(mailMessage)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060129E5 RID: 76261 RVA: 0x00AB799C File Offset: 0x00AB5B9C
		Public Sub SupplierLedgerDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from SupplierLedgerBook where LedgerNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129E6 RID: 76262 RVA: 0x00AB7A14 File Offset: 0x00AB5C14
		Public Sub SupplierLedgerUpdate(a As DateTime, b As String, e As Decimal, f As Decimal, f1 As String, f2 As String, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update SupplierLedgerBook set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4,SuplNameid=@d5,Remarks=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", f1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", f2)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129E7 RID: 76263 RVA: 0x00AB7B38 File Offset: 0x00AB5D38
		Public Sub SupplierLedgerUpdate1(b As String, e As Decimal, f As Decimal, f1 As String, f2 As String, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update SupplierLedgerBook set Name=@d2,Debit=@d3,Credit=@d4,SuplNameid=@d5,Remarks=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", f1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", f2)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129E8 RID: 76264 RVA: 0x00AB7C40 File Offset: 0x00AB5E40
		Public Sub CustomerLedgerSave(a As DateTime, b As String, c As String, d As String, e As Decimal, f As Decimal, g As String, h As String, i As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into CustomerLedgerBook(Date, Name, LedgerNo, Label, Debit, Credit, PartyID, CustNameid, Remarks) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d9", i)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129E9 RID: 76265 RVA: 0x00AB7D7C File Offset: 0x00AB5F7C
		Public Sub CustomerLedgerDelete(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from CustomerLedgerBook where LedgerNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129EA RID: 76266 RVA: 0x00AB7DF4 File Offset: 0x00AB5FF4
		Public Sub CustomerLedgerUpdate(a As DateTime, b As String, e As Decimal, f As Decimal, n As String, m As String, k As String, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update CustomerLedgerBook set Date=@d1,Name=@d2,Debit=@d3,Credit=@d4,PartyId=@d9,CustNameid=@d5,Remarks=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d9", n.Trim())
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", m)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", k)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129EB RID: 76267 RVA: 0x00AB7F34 File Offset: 0x00AB6134
		Public Sub CustomerLedgerUpdate1(b As String, e As Decimal, f As Decimal, f1 As String, f2 As String, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update CustomerLedgerBook set Name=@d2,Debit=@d3,Credit=@d4,CustNameid=@d5,Remarks=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", f1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", f2)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129EC RID: 76268 RVA: 0x00AB803C File Offset: 0x00AB623C
		Public Sub BankAccountLedgerSave(a As DateTime, b As String, c As String, d As String, e As Decimal, f As Decimal)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into BankAccountLedger(Date,AccNo, LedgerNo, Label,Debit,Credit) Values (@d1,@d2,@d3,@d4,@d5,@d6)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129ED RID: 76269 RVA: 0x00AB8130 File Offset: 0x00AB6330
		Public Sub BankAccountLedgerDelete(a As String, b As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from BankAccountLedger where LedgerNo=@d1 and Label=@d2"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129EE RID: 76270 RVA: 0x00AB81BC File Offset: 0x00AB63BC
		Public Sub BankAccountLedgerUpdate(a As DateTime, b As String, e As Decimal, f As Decimal, h As String, i As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update BankAccountLedger set Date=@d1, AccNo=@d2,Debit=@d3,Credit=@d4 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", i)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129EF RID: 76271 RVA: 0x00AB82B0 File Offset: 0x00AB64B0
		Public Function SaveConfiguration(Starting_Number As String) As Boolean
			Dim registryKey As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\NextGenOS\iCB")
			Dim flag As Boolean = registryKey IsNot Nothing
			Dim flag2 As Boolean
			If flag Then
				registryKey.SetValue("Starting_Number", Starting_Number)
				registryKey.Close()
				flag2 = True
			Else
				flag2 = False
			End If
			Return flag2
		End Function

		' Token: 0x060129F0 RID: 76272 RVA: 0x00AB82F4 File Offset: 0x00AB64F4
		Public Function ReadConfiguration() As String
			Dim text As String = Nothing
			Try
				Dim registryKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\NextGenOS\iCB")
				If registryKey Is Nothing Then
					registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Raintech\iCB")
				End If
				Dim flag As Boolean = registryKey IsNot Nothing
				If flag Then
					Dim flag2 As Boolean = registryKey.GetValueNames().Contains("Starting_Number")
					If flag2 Then
						text = registryKey.GetValue("Starting_Number").ToString()
					End If
					registryKey.Close()
				End If
			Catch ex As Exception
			End Try
			Return text
		End Function

		' Token: 0x060129F1 RID: 76273 RVA: 0x00AB8374 File Offset: 0x00AB6574
		Public Sub LedgerSaveSalesman(a As DateTime, b As String, c As String, d As String, e As Decimal, f As Decimal, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into LedgerBooksalesman1(Date, Name, LedgerNo, Label,Debit,Credit,PartyID,PartyName) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129F2 RID: 76274 RVA: 0x00AB8498 File Offset: 0x00AB6698
		Public Sub LedgerDeleteSalesman(a As String, b As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from LedgerBooksalesman1 where PartyName=@d1 and Label=@d2"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129F3 RID: 76275 RVA: 0x00AB8524 File Offset: 0x00AB6724
		Public Sub LedgerUpdateSalesman(a As DateTime, b As String, e As Decimal, f As Decimal, g As String, h As String, i As String, j As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update LedgerBooksalesman1 set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4,PartyID=@d5,PartyName=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", i)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", j)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129F4 RID: 76276 RVA: 0x00AB8648 File Offset: 0x00AB6848
		Public Sub LedgerSave_Loyality(a As DateTime, b As String, c As String, d As String, e As Decimal, f As Decimal, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into LedgerBook_Loyality(Date, Name, LedgerNo, Label,Debit,Credit,PartyID,PartyName) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129F5 RID: 76277 RVA: 0x00AB876C File Offset: 0x00AB696C
		Public Sub CustomerLedgerSave_Loyality(a As DateTime, b As String, c As String, d As String, e As Decimal, f As Decimal, g As String, h As String, i As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into CustomerLedgerBook_Loyality(Date, Name, LedgerNo, Label, Debit, Credit, PartyID, CustNameid, Remarks) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d9", i)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129F6 RID: 76278 RVA: 0x00AB88A8 File Offset: 0x00AB6AA8
		Public Sub LedgerUpdate_Loyality(a As DateTime, b As String, e As Decimal, f As Decimal, g As String, h As String, i As String, j As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update LedgerBook_Loyality set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4,PartyID=@d5,PartyName=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", i)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", j)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129F7 RID: 76279 RVA: 0x00AB89CC File Offset: 0x00AB6BCC
		Public Sub LedgerUpdate1_Loyality(b As String, e As Decimal, f As Decimal, g As String, h As String, i As String, j As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update LedgerBook_Loyality set Name=@d2,Debit=@d3,Credit=@d4,PartyID=@d5,PartyName=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", i)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", j)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129F8 RID: 76280 RVA: 0x00AB8AD4 File Offset: 0x00AB6CD4
		Public Sub CustomerLedgerUpdate_Loyality(a As DateTime, b As String, e As Decimal, f As Decimal, n As String, m As String, k As String, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update CustomerLedgerBook_Loyality set Date=@d1,Name=@d2,Debit=@d3,Credit=@d4,PartyId=@d9,CustNameid=@d5,Remarks=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d9", n.Trim())
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", m)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", k)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129F9 RID: 76281 RVA: 0x00AB8C14 File Offset: 0x00AB6E14
		Public Sub CustomerLedgerUpdate1_Loyality(b As String, e As Decimal, f As Decimal, f1 As String, f2 As String, g As String, h As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update CustomerLedgerBook_Loyality set Name=@d2,Debit=@d3,Credit=@d4,CustNameid=@d5,Remarks=@d8 where LedgerNo=@d6 and Label=@d7"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", f1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", f2)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", g)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", h)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129FA RID: 76282 RVA: 0x00AB8D1C File Offset: 0x00AB6F1C
		Public Sub LedgerDelete_Loyality(a As String, b As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from LedgerBook_Loyality where LedgerNo=@d1 and Label=@d2"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129FB RID: 76283 RVA: 0x00AB8DA8 File Offset: 0x00AB6FA8
		Public Sub CustomerLedgerDelete_Loyality(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from CustomerLedgerBook_Loyality where LedgerNo=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129FC RID: 76284 RVA: 0x00AB8E20 File Offset: 0x00AB7020
		Public Sub LedgerDelete_Loyality1(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from LedgerBook_Loyality where Label=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129FD RID: 76285 RVA: 0x00AB8E98 File Offset: 0x00AB7098
		Public Sub CustomerLedgerDelete_Loyality1(a As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "delete from CustomerLedgerBook_Loyality where Label=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129FE RID: 76286 RVA: 0x00AB8F10 File Offset: 0x00AB7110
		Public Sub AuditTrial_Master(st1 As String, st2 As String, st3 As String, st4 As String, st5 As String)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into AuditM(Mastername, Type, Tillid, Userid, Dateandtime, Action) VALUES (@d1,@d2,@d3,@d4,@ddt,@d5)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", st1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", st2)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", st3)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", st4)
			ModCommonClasses.cmd.Parameters.AddWithValue("@ddt", DateTime.Now)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", st5)
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060129FF RID: 76287 RVA: 0x00AB9000 File Offset: 0x00AB7200
		Public Sub AuditTrial_Inventory(st1 As String, st2 As String, st3 As String, st4 As String, st5 As String, st6 As DateTime, st7 As String, st8 As String, st9 As Decimal, st10 As Decimal, st11 As Decimal)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "insert into AuditI(Tillid, Userid, Dateandtime, Action, Type, Voucherno, Voucherdate, Particulars, Itemname, Qty, Price, TotAmt) VALUES (@d1,@d2,@ddt,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", st1)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", st2)
			ModCommonClasses.cmd.Parameters.AddWithValue("@ddt", DateTime.Now)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", st3)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d4", st4)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d5", st5)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d6", st6)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d7", st7)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d8", st8)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d9", st9)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d10", st10)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d11", st11)
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06012A00 RID: 76288 RVA: 0x00AB918C File Offset: 0x00AB738C
		Public Function GetAuthToken(url As String, username As String, password As String) As String
			Dim text As String = String.Empty
			Try
				ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
				Dim text2 As String = JsonConvert.SerializeObject(New With{ username, password })
				Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "application/json"
				httpWebRequest.ContentLength = CLng(Encoding.UTF8.GetByteCount(text2))
				Using requestStream As Stream = httpWebRequest.GetRequestStream()
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(text2)
					requestStream.Write(bytes, 0, bytes.Length)
				End Using
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text3 As String = streamReader.ReadToEnd()
					Dim dictionary As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(text3)
					Dim flag As Boolean = dictionary.ContainsKey("token")
					If flag Then
						text = dictionary("token").ToString()
					End If
				End Using
			Catch ex As WebException
				Dim flag2 As Boolean = ex.Response IsNot Nothing
				If flag2 Then
					Using streamReader2 As StreamReader = New StreamReader(ex.Response.GetResponseStream())
						Dim text4 As String = streamReader2.ReadToEnd()
						MessageBox.Show("Error Response: " + text4)
					End Using
				Else
					MessageBox.Show("Error: " + ex.Message)
				End If
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message)
			End Try
			Return text
		End Function

		' Token: 0x06012A01 RID: 76289 RVA: 0x00AB9378 File Offset: 0x00AB7578
		Public Function GenerateEwayBill(url As String, token As String, payload As String) As String
			Dim text As String = String.Empty
			Try
				ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
				Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "application/json"
				httpWebRequest.Headers("Authorization") = "JWT " + token
				Using requestStream As Stream = httpWebRequest.GetRequestStream()
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(payload)
					requestStream.Write(bytes, 0, bytes.Length)
				End Using
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text2 As String = streamReader.ReadToEnd()
					text = text2
				End Using
			Catch ex As WebException
				Dim flag As Boolean = ex.Response IsNot Nothing
				If flag Then
					Using streamReader2 As StreamReader = New StreamReader(ex.Response.GetResponseStream())
						Dim text3 As String = streamReader2.ReadToEnd()
						MessageBox.Show("Error Response: " + text3)
					End Using
				Else
					MessageBox.Show("Error: " + ex.Message)
				End If
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message)
			End Try
			Return text
		End Function

		' Token: 0x06012A02 RID: 76290 RVA: 0x00AB9378 File Offset: 0x00AB7578
		Public Function CancelEwayBill(url As String, token As String, payload As String) As String
			Dim text As String = String.Empty
			Try
				ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
				Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "application/json"
				httpWebRequest.Headers("Authorization") = "JWT " + token
				Using requestStream As Stream = httpWebRequest.GetRequestStream()
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(payload)
					requestStream.Write(bytes, 0, bytes.Length)
				End Using
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text2 As String = streamReader.ReadToEnd()
					text = text2
				End Using
			Catch ex As WebException
				Dim flag As Boolean = ex.Response IsNot Nothing
				If flag Then
					Using streamReader2 As StreamReader = New StreamReader(ex.Response.GetResponseStream())
						Dim text3 As String = streamReader2.ReadToEnd()
						MessageBox.Show("Error Response: " + text3)
					End Using
				Else
					MessageBox.Show("Error: " + ex.Message)
				End If
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message)
			End Try
			Return text
		End Function
	End Module
End Namespace
