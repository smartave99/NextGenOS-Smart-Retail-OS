Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports GelButtons
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NPOI.HSSF.UserModel
Imports NPOI.SS.UserModel
Imports NPOI.XSSF.UserModel
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020000AC RID: 172
	<DesignerGenerated()>
	Public Partial Class frmImportPro
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001955 RID: 6485 RVA: 0x00013453 File Offset: 0x00011653
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmImportPro_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170009F8 RID: 2552
		' (get) Token: 0x06001958 RID: 6488 RVA: 0x00013473 File Offset: 0x00011673
		' (set) Token: 0x06001959 RID: 6489 RVA: 0x00113E88 File Offset: 0x00112088
		Private _btnBrowse As GelButton
		Friend Overridable Property btnBrowse As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnBrowse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnBrowse_Click
				Dim gelButton As GelButton = Me._btnBrowse
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnBrowse = value
				gelButton = Me._btnBrowse
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170009F9 RID: 2553
		' (get) Token: 0x0600195A RID: 6490 RVA: 0x0001347D File Offset: 0x0001167D
		' (set) Token: 0x0600195B RID: 6491 RVA: 0x00013487 File Offset: 0x00011687
		Friend Overridable Property lblStatus As Label

		' Token: 0x170009FA RID: 2554
		' (get) Token: 0x0600195C RID: 6492 RVA: 0x00013490 File Offset: 0x00011690
		' (set) Token: 0x0600195D RID: 6493 RVA: 0x0001349A File Offset: 0x0001169A
		Friend Overridable Property BackgroundWorker1 As BackgroundWorker

		' Token: 0x170009FB RID: 2555
		' (get) Token: 0x0600195E RID: 6494 RVA: 0x000134A3 File Offset: 0x000116A3
		' (set) Token: 0x0600195F RID: 6495 RVA: 0x000134AD File Offset: 0x000116AD
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x170009FC RID: 2556
		' (get) Token: 0x06001960 RID: 6496 RVA: 0x000134B6 File Offset: 0x000116B6
		' (set) Token: 0x06001961 RID: 6497 RVA: 0x000134C0 File Offset: 0x000116C0
		Friend Overridable Property txtFilePath As TextBox

		' Token: 0x170009FD RID: 2557
		' (get) Token: 0x06001962 RID: 6498 RVA: 0x000134C9 File Offset: 0x000116C9
		' (set) Token: 0x06001963 RID: 6499 RVA: 0x000134D3 File Offset: 0x000116D3
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x170009FE RID: 2558
		' (get) Token: 0x06001964 RID: 6500 RVA: 0x000134DC File Offset: 0x000116DC
		' (set) Token: 0x06001965 RID: 6501 RVA: 0x00113ECC File Offset: 0x001120CC
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170009FF RID: 2559
		' (get) Token: 0x06001966 RID: 6502 RVA: 0x000134E6 File Offset: 0x000116E6
		' (set) Token: 0x06001967 RID: 6503 RVA: 0x000134F0 File Offset: 0x000116F0
		Friend Overridable Property GelButton3 As GelButton

		' Token: 0x17000A00 RID: 2560
		' (get) Token: 0x06001968 RID: 6504 RVA: 0x000134F9 File Offset: 0x000116F9
		' (set) Token: 0x06001969 RID: 6505 RVA: 0x00013503 File Offset: 0x00011703
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17000A01 RID: 2561
		' (get) Token: 0x0600196A RID: 6506 RVA: 0x0001350C File Offset: 0x0001170C
		' (set) Token: 0x0600196B RID: 6507 RVA: 0x00113F10 File Offset: 0x00112110
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A02 RID: 2562
		' (get) Token: 0x0600196C RID: 6508 RVA: 0x00013516 File Offset: 0x00011716
		' (set) Token: 0x0600196D RID: 6509 RVA: 0x00013520 File Offset: 0x00011720
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000A03 RID: 2563
		' (get) Token: 0x0600196E RID: 6510 RVA: 0x00013529 File Offset: 0x00011729
		' (set) Token: 0x0600196F RID: 6511 RVA: 0x00013533 File Offset: 0x00011733
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17000A04 RID: 2564
		' (get) Token: 0x06001970 RID: 6512 RVA: 0x0001353C File Offset: 0x0001173C
		' (set) Token: 0x06001971 RID: 6513 RVA: 0x00013546 File Offset: 0x00011746
		Friend Overridable Property txtID As TextBox

		' Token: 0x17000A05 RID: 2565
		' (get) Token: 0x06001972 RID: 6514 RVA: 0x0001354F File Offset: 0x0001174F
		' (set) Token: 0x06001973 RID: 6515 RVA: 0x00013559 File Offset: 0x00011759
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x17000A06 RID: 2566
		' (get) Token: 0x06001974 RID: 6516 RVA: 0x00013562 File Offset: 0x00011762
		' (set) Token: 0x06001975 RID: 6517 RVA: 0x0001356C File Offset: 0x0001176C
		Friend Overridable Property ProgressBar2 As ProgressBar

		' Token: 0x17000A07 RID: 2567
		' (get) Token: 0x06001976 RID: 6518 RVA: 0x00013575 File Offset: 0x00011775
		' (set) Token: 0x06001977 RID: 6519 RVA: 0x0001357F File Offset: 0x0001177F
		Friend Overridable Property Label1 As Label

		' Token: 0x17000A08 RID: 2568
		' (get) Token: 0x06001978 RID: 6520 RVA: 0x00013588 File Offset: 0x00011788
		' (set) Token: 0x06001979 RID: 6521 RVA: 0x00113F54 File Offset: 0x00112154
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton1 = value
				gelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600197A RID: 6522 RVA: 0x00013592 File Offset: 0x00011792
		Private Sub frmImportPro_Load(sender As Object, e As EventArgs)
			Me.BackgroundWorker1.WorkerReportsProgress = True
			Me.BackgroundWorker1.WorkerSupportsCancellation = True
			Me.CheckBox1.Checked = True
		End Sub

		' Token: 0x0600197B RID: 6523 RVA: 0x00113F98 File Offset: 0x00112198
		Private Function GenerateDate(mfgDate As String) As String
			Dim text As String = ""
			Try
				Dim list As List(Of String) = mfgDate.Split(New Char() { " "c }).First().Split(New Char() { "/"c }).ToList()
				Dim num As Integer = Convert.ToInt32(list(0))
				Dim num2 As Integer = Convert.ToInt32(list(1))
				Dim num3 As Integer = Convert.ToInt32(list(2))
				Dim flag As Boolean = num < 10
				Dim text2 As String
				If flag Then
					text2 = "0" + num.ToString()
				Else
					text2 = Conversions.ToString(num)
				End If
				Dim flag2 As Boolean = num2 < 10
				Dim text3 As String
				If flag2 Then
					text3 = "0" + num2.ToString()
				Else
					text3 = Conversions.ToString(num2)
				End If
				Dim flag3 As Boolean = num3 < 1000
				Dim text4 As String
				If flag3 Then
					text4 = "00" + num3.ToString()
				Else
					text4 = Conversions.ToString(num3)
				End If
				text = String.Concat(New String() { text2, "/", text3, "/", text4 })
			Catch ex As Exception
				text = ""
			End Try
			Return text
		End Function

		' Token: 0x0600197C RID: 6524 RVA: 0x0011410C File Offset: 0x0011230C
		Private Function IsProductExist(id As String, barcode As String) As Boolean
			Dim flag As Boolean = False
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT COUNT(*) FROM (" & vbCrLf & "                    SELECT PID AS ItemID FROM product WHERE PID = @d1" & vbCrLf & "                    UNION ALL" & vbCrLf & "                    SELECT Barcode AS ItemID FROM Product_OpeningStock WHERE Barcode =@d2" & vbCrLf & "                ) AS Combined"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d1", id)
						sqlCommand.Parameters.AddWithValue("@d2", barcode)
						Dim num As Integer = Conversions.ToInteger(sqlCommand.ExecuteScalar())
						Dim flag2 As Boolean = num > 0
						If flag2 Then
							flag = True
						End If
					End Using
				End Using
			Catch ex As Exception
				Console.WriteLine("Error: " + ex.Message)
			End Try
			Return flag
		End Function

		' Token: 0x0600197D RID: 6525 RVA: 0x001141F8 File Offset: 0x001123F8
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600197E RID: 6526 RVA: 0x0011427C File Offset: 0x0011247C
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600197F RID: 6527 RVA: 0x001143E8 File Offset: 0x001125E8
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001980 RID: 6528 RVA: 0x0011445C File Offset: 0x0011265C
		Private Sub btnBrowse_Click(sender As Object, e As EventArgs)
			Dim fileStream As FileStream = Nothing
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim fileName As String = openFileDialog.FileName
					Dim text As String = Path.GetExtension(fileName).ToLower()
					Dim workbook As IWorkbook = Nothing
					Try
						fileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
						Dim flag2 As Boolean = Operators.CompareString(text, ".xlsx", False) = 0
						If flag2 Then
							workbook = New XSSFWorkbook(fileStream, False)
						Else
							Dim flag3 As Boolean = Operators.CompareString(text, ".xls", False) = 0
							If Not flag3 Then
								MessageBox.Show("Only .xls or .xlsx files are supported.")
								Return
							End If
							workbook = New HSSFWorkbook(fileStream)
						End If
					Catch ex As Exception
						Dim array As String() = New String(5) {}
						array(0) = "Unable to read Excel file:" & vbCrLf
						array(1) = ex.Message
						array(2) = vbCrLf & "INNER: "
						Dim num As Integer = 3
						Dim innerException As Exception = ex.InnerException
						array(num) = If(If((innerException IsNot Nothing), innerException.Message, Nothing), "None")
						array(4) = vbCrLf & "STACK: "
						array(5) = ex.StackTrace
						MessageBox.Show(String.Concat(array))
						Return
					End Try
					Dim flag4 As Boolean = workbook Is Nothing
					If flag4 Then
						MessageBox.Show("Workbook is empty or unreadable.", "Error")
					Else
						Dim sheetAt As ISheet = workbook.GetSheetAt(0)
						Dim flag5 As Boolean = sheetAt Is Nothing
						If flag5 Then
							MessageBox.Show("No sheet found in the Excel file.", "Error")
						Else
							Dim dataTable As DataTable = New DataTable()
							Dim row As IRow = sheetAt.GetRow(0)
							Dim flag6 As Boolean = row Is Nothing
							If flag6 Then
								MessageBox.Show("The Excel file is empty.", "Error")
							Else
								Dim lastCellNum As Integer = CInt(row.LastCellNum)
								Dim num2 As Integer = lastCellNum - 1
								For i As Integer = 0 To num2
									Dim text2 As String = "Column" + Conversions.ToString(i + 1)
									Dim cell As ICell = row.GetCell(i)
									Dim flag7 As Boolean = cell IsNot Nothing
									If flag7 Then
										Dim text3 As String = cell.ToString().Trim()
										Dim flag8 As Boolean = Operators.CompareString(text3, "", False) <> 0
										If flag8 Then
											text2 = text3
										End If
									End If
									Dim flag9 As Boolean = dataTable.Columns.Contains(text2)
									If flag9 Then
										text2 = text2 + "_" + Conversions.ToString(i)
									End If
									dataTable.Columns.Add(text2)
								Next
								Dim lastRowNum As Integer = sheetAt.LastRowNum
								For j As Integer = 1 To lastRowNum
									Dim row2 As IRow = sheetAt.GetRow(j)
									Dim flag10 As Boolean = row2 Is Nothing
									If Not flag10 Then
										Dim dataRow As DataRow = dataTable.NewRow()
										Dim num3 As Integer = lastCellNum - 1
										For k As Integer = 0 To num3
											Dim cell2 As ICell = row2.GetCell(k)
											Dim flag11 As Boolean = cell2 Is Nothing
											If flag11 Then
												dataRow(k) = ""
											Else
												dataRow(k) = cell2.ToString().Trim()
											End If
										Next
										dataTable.Rows.Add(dataRow)
									End If
								Next
								Dim num4 As Integer = 0
								Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
									sqlConnection.Open()
									Dim sqlCommand As SqlCommand = New SqlCommand("SELECT ISNULL(MAX(ID), 0) FROM SubCategory", sqlConnection)
									num4 = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
								End Using
								Dim list As List(Of Integer) = New List(Of Integer)()
								Dim num5 As Integer = dataTable.Rows.Count - 1
								For l As Integer = 0 To num5
									Dim text4 As String = dataTable.Rows(l)(3).ToString()
									Dim flag12 As Boolean = Not String.IsNullOrWhiteSpace(text4)
									If flag12 Then
										Dim num6 As Integer
										Dim flag13 As Boolean = Integer.TryParse(text4, num6)
										If flag13 Then
											Dim flag14 As Boolean = num6 > num4
											If flag14 Then
												list.Add(l + 2)
											End If
										End If
									End If
								Next
								Dim flag15 As Boolean = list.Count > 0
								If flag15 Then
									MessageBox.Show("Invalid rows found: " & String.Join(", ", list) & vbCrLf & "Column 4 must be <= Max SubCategory ID (" & Conversions.ToString(num4) & ").", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Else
									Me.DataGridView1.Visible = True
									Me.DataGridView1.DataSource = dataTable
								End If
							End If
						End If
					End If
				End If
			Catch ex2 As Exception
				MessageBox.Show(String.Format("Error: {0}{1}{2}", ex2.Message, Environment.NewLine, Environment.NewLine) + String.Format("Source: {0}{1}{2}", ex2.Source, Environment.NewLine, Environment.NewLine) + String.Format("StackTrace:{0}{1}", Environment.NewLine, ex2.StackTrace), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.Cursor = Cursors.[Default]
				Me.Timer1.Enabled = False
				Try
					Dim flag16 As Boolean = fileStream IsNot Nothing
					If flag16 Then
						fileStream.Close()
					End If
				Catch ex3 As Exception
				End Try
			End Try
		End Sub

		' Token: 0x06001981 RID: 6529 RVA: 0x001149E0 File Offset: 0x00112BE0
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					ModCommonClasses.con.Close()
				Else
					Dim flag3 As Boolean = Me.DataGridView1.RowCount = 0
					If flag3 Then
						MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Dim num As Integer = Me.DataGridView1.RowCount - 1
						For i As Integer = 0 To num
							Dim flag4 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(0).Value.ToString(), "", False) = 0
							If flag4 Then
								MessageBox.Show("ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag5 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(1).Value.ToString(), "", False) = 0
							If flag5 Then
								MessageBox.Show("Product Code Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag6 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(2).Value.ToString(), "", False) = 0
							If flag6 Then
								MessageBox.Show("Product Name Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag7 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(3).Value.ToString(), "", False) = 0
							If flag7 Then
								MessageBox.Show("Sub Category ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag8 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(7).Value.ToString(), "", False) = 0
							If flag8 Then
								MessageBox.Show("Purchase Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag9 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(8).Value.ToString(), "", False) = 0
							If flag9 Then
								MessageBox.Show("Retail Sale Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag10 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(9).Value.ToString(), "", False) = 0
							If flag10 Then
								MessageBox.Show("Disc% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag11 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(10).Value.ToString(), "", False) = 0
							If flag11 Then
								MessageBox.Show("CGST% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag12 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(11).Value.ToString(), "", False) = 0
							If flag12 Then
								MessageBox.Show("SGST% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag13 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(12).Value.ToString(), "", False) = 0
							If flag13 Then
								MessageBox.Show("CESS% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag14 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(13).Value.ToString(), "", False) = 0
							If flag14 Then
								MessageBox.Show("Wholesale Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag15 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(14).Value.ToString(), "", False) = 0
							If flag15 Then
								MessageBox.Show("Purchase Unit Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag16 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(15).Value.ToString(), "", False) = 0
							If flag16 Then
								MessageBox.Show("Sale Unit Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag17 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(16).Value.ToString(), "", False) = 0
							If flag17 Then
								MessageBox.Show("Alter Unit Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag18 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(17).Value.ToString(), "", False) = 0
							If flag18 Then
								MessageBox.Show("Conversion Value Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag19 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(18).Value.ToString(), "", False) = 0
							If flag19 Then
								MessageBox.Show("Minimum Stock Value Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag20 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(19).Value.ToString(), "", False) = 0
							If flag20 Then
								MessageBox.Show("MRP Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag21 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(22).Value.ToString(), "", False) = 0
							If flag21 Then
								MessageBox.Show("Opening Qty Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag22 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(28).Value.ToString(), "", False) = 0
							If flag22 Then
								MessageBox.Show("Barcode Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag23 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(29).Value.ToString(), "", False) = 0
							If flag23 Then
								MessageBox.Show("Default Sale Qty Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim num2 As Integer = i + 1
							Dim num3 As Integer = Me.DataGridView1.RowCount - 1
							For j As Integer = num2 To num3
								Dim flag24 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(28).Value.ToString(), Me.DataGridView1.Rows(j).Cells(28).Value.ToString(), False) = 0
								If flag24 Then
									MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject("Duplicate Barcode Number found ", Me.DataGridView1.Rows(i).Cells(28).Value)))
									Return
								End If
							Next
						Next
						Try
							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim flag25 As Boolean = Not dataGridViewRow.IsNewRow
								If flag25 Then
									SqlConnection.ClearAllPools()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select Barcode from Product_OpeningStock Where Barcode=@d1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(28).Value.ToString())
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag26 As Boolean = ModCommonClasses.rdr.Read()
									If flag26 Then
										MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Barcode '", dataGridViewRow.Cells(28).Value), "' Already Exists")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag27 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag27 Then
											ModCommonClasses.rdr.Close()
										End If
										ModCommonClasses.con.Close()
										Return
									End If
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Try
							For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Dim flag28 As Boolean = Not dataGridViewRow2.IsNewRow
								If flag28 Then
									SqlConnection.ClearAllPools()
									Try
										Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
											sqlConnection.Open()
											Dim text3 As String = "select Barcode from Temp_Stock Where Barcode=@d1"
											Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection)
												sqlCommand.Parameters.AddWithValue("@d1", dataGridViewRow2.Cells(28).Value.ToString())
												Dim num4 As Integer = Conversions.ToInteger(sqlCommand.ExecuteScalar())
												Dim flag29 As Boolean = num4 > 0
												If flag29 Then
													MessageBox.Show("Barcode '" + dataGridViewRow2.Cells(28).Value.ToString() + "' Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Return
												End If
												Dim flag30 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag30 Then
													ModCommonClasses.rdr.Close()
												End If
											End Using
										End Using
									Catch ex As Exception
										Console.WriteLine("Error: " + ex.Message)
									End Try
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text4 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag31 As Boolean = ModCommonClasses.rdr.Read()
						Dim text5 As String
						Dim num5 As Double
						If flag31 Then
							text5 = ModCommonClasses.rdr(1).ToString()
							num5 = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
							Dim flag32 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag32 Then
								ModCommonClasses.rdr.Close()
							End If
						End If
						Try
							Try
								For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
									Dim text6 As String = ""
									Dim text7 As String = ""
									Dim flag33 As Boolean = False
									Try
										Dim flag34 As Boolean = Me.IsProductExist(dataGridViewRow3.Cells(0).Value.ToString(), dataGridViewRow3.Cells(28).Value.ToString())
										If flag34 Then
											Dim flag35 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(24).Value.ToString(), "", False) = 0
											If flag35 Then
												text6 = ""
											Else
												text6 = Me.GenerateDate(dataGridViewRow3.Cells(24).Value.ToString())
											End If
											Dim flag36 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(25).Value.ToString(), "", False) = 0
											If flag36 Then
												text7 = ""
											Else
												text7 = Me.GenerateDate(dataGridViewRow3.Cells(25).Value.ToString())
											End If
											flag33 = True
										End If
										Dim flag37 As Boolean = Not flag33
										If flag37 Then
											Dim flag38 As Boolean = Not dataGridViewRow3.IsNewRow
											If flag38 Then
												Me.Cursor = Cursors.WaitCursor
												Me.Timer1.Enabled = True
												SqlConnection.ClearAllPools()
												Me.auto()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text8 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID,HSNCode,PartNo, Description, CostPrice, SellingPrice," & vbCrLf & "                                                Discount,CGST,SGST,CESS, ReorderPoint,OpeningStock,Barcode,PurchaseUnit,SalesUnit,SalesAltUnit,Conv,MinStock,MRP,Status," & vbCrLf & "                                                STax,PTax,GDown,Rack,DefQty,AddDate, loyality_mode, loyality_value)" & vbCrLf & "                                                VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24," & vbCrLf & "                                                @d25,@d26,@d27,@d28,@d29,@d30)"
												ModCommonClasses.cmd = New SqlCommand(text8)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow3.Cells(1).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(2).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(3).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow3.Cells(4).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow3.Cells(5).Value.ToString())
												Dim flag39 As Boolean = dataGridViewRow3.Cells(6).Value IsNot Nothing
												If flag39 Then
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(6).Value.ToString())
												Else
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(2).Value.ToString())
												End If
												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(dataGridViewRow3.Cells(9).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(dataGridViewRow3.Cells(10).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(dataGridViewRow3.Cells(11).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(dataGridViewRow3.Cells(12).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(dataGridViewRow3.Cells(13).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "0")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "0")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(14).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(15).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(16).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(17).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(18).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(19).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d22", "Yes")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d23", "Inclusive")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d24", "Exclusive")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d25", dataGridViewRow3.Cells(20).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d26", dataGridViewRow3.Cells(21).Value.ToString())
												Dim flag40 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareString(dataGridViewRow3.Cells(29).Value.ToString(), "", False) = 0, Operators.CompareObjectEqual(dataGridViewRow3.Cells(29).Value, "0", False)))
												If flag40 Then
													ModCommonClasses.cmd.Parameters.AddWithValue("@d27", "1")
												Else
													ModCommonClasses.cmd.Parameters.AddWithValue("@d27", dataGridViewRow3.Cells(29).Value.ToString())
												End If
												ModCommonClasses.cmd.Parameters.AddWithValue("@d28", DateTime.Today)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d29", text5.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Conversion.Val(num5))
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.CommandTimeout = 0
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
												ModCommonClasses.cmd = New SqlCommand(text9)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(15).Value.ToString())
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text10 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
												ModCommonClasses.cmd = New SqlCommand(text10)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(16).Value.ToString())
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
												Dim flag41 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(28).Value.ToString(), "", False) <> 0
												If flag41 Then
													SqlConnection.ClearAllPools()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text11 As String = "Select Barcode from Product_OpeningStock where Barcode=@d1"
													ModCommonClasses.cmd = New SqlCommand(text11)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow3.Cells(28).Value.ToString())
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.CommandTimeout = 0
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag42 As Boolean = Not ModCommonClasses.rdr.Read()
													If flag42 Then
														SqlConnection.ClearAllPools()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim flag43 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(24).Value.ToString(), "", False) = 0
														If flag43 Then
															text6 = ""
														Else
															text6 = Me.GenerateDate(dataGridViewRow3.Cells(24).Value.ToString())
														End If
														Dim flag44 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(25).Value.ToString(), "", False) = 0
														If flag44 Then
															text7 = ""
														Else
															text7 = Me.GenerateDate(dataGridViewRow3.Cells(25).Value.ToString())
														End If
														Dim text12 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
														ModCommonClasses.cmd = New SqlCommand(text12)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(22).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(19).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(13).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(23).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", text6)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", text7)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(26).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(27).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(28).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
														Dim num6 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))
														Dim num7 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(22).Value))
														Dim num8 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(10).Value))
														Dim num9 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(11).Value))
														Dim num10 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d16", num6 * num7 + num6 * num7 * ((num8 + num9 + num10) / 100.0))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(30).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(31).Value.ToString())
														ModCommonClasses.cmd.CommandTimeout = 0
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														SqlConnection.ClearAllPools()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text13 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value))) + ",@img)"
														ModCommonClasses.cmd = New SqlCommand(text13)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														Dim memoryStream As MemoryStream = New MemoryStream()
														Dim bitmap As Bitmap = New Bitmap(Resources._12)
														bitmap.Save(memoryStream, ImageFormat.Jpeg)
														Dim buffer As Byte() = memoryStream.GetBuffer()
														Dim sqlParameter As SqlParameter = New SqlParameter("@img", SqlDbType.Image)
														sqlParameter.Value = buffer
														ModCommonClasses.cmd.Parameters.Add(sqlParameter)
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														Dim checked As Boolean = Me.CheckBox1.Checked
														If checked Then
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text14 As String = "select ProductID from StockMovement where ProductID=@d1"
															ModCommonClasses.cmd = New SqlCommand(text14)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.CommandTimeout = 0
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag45 As Boolean = Not ModCommonClasses.rdr.Read()
															If flag45 Then
																ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(22).Value))), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
															Else
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text15 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
																ModCommonClasses.cmd = New SqlCommand(text15)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
																ModCommonClasses.cmd.CommandTimeout = 0
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag46 As Boolean = ModCommonClasses.rdr.Read()
																Dim num11 As Double
																If flag46 Then
																	num11 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
																Else
																	num11 = 0.0
																End If
																ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), New Decimal(num11), New Decimal(Conversion.Val(dataGridViewRow3.Cells(22).Value.ToString())), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
															End If
														End If
													End If
												End If
											End If
											Dim checked2 As Boolean = Me.CheckBox1.Checked
											If checked2 Then
												Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow3.Cells(28).Value))
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text16 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode,SalesManPur,Variant_id) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22)"
												ModCommonClasses.cmd = New SqlCommand(text16)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(22).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow3.Cells(28).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(13).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(dataGridViewRow3.Cells(18).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(19).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(23).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d9", text6)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d10", text7)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(26).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow3.Cells(27).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Opening Stock")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(30).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(31).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
												Dim memoryStream2 As MemoryStream = New MemoryStream()
												Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
												bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
												Dim buffer2 As Byte() = memoryStream2.GetBuffer()
												Dim sqlParameter2 As SqlParameter = New SqlParameter("@d20", SqlDbType.Image)
												sqlParameter2.Value = buffer2
												ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d21", 0.0)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
												ModCommonClasses.cmd.CommandTimeout = 0
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
											End If
										End If
									Catch ex2 As Exception
										MessageBox.Show(ex2.Message)
									End Try
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.DataGridView1.DataSource = Nothing
							FileSystem.Reset()
						Catch ex3 As SqlException
							MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			Catch ex4 As Exception
			End Try
		End Sub

		' Token: 0x06001982 RID: 6530 RVA: 0x00116E0C File Offset: 0x0011500C
		Private Function CheckTableHasRecords(tableName As String, message As String) As Boolean
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = String.Format("SELECT TOP 1 1 FROM {0}", tableName)
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						Dim flag As Boolean = Not sqlDataReader.Read()
						If flag Then
							MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Return False
						End If
					End Using
				End Using
			End Using
			Return True
		End Function

		' Token: 0x06001983 RID: 6531 RVA: 0x00116EC8 File Offset: 0x001150C8
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Not Me.CheckTableHasRecords("Company", "Add company profile first in master entry")
				If Not flag Then
					Dim flag2 As Boolean = Not Me.CheckTableHasRecords("Category", "Add category profile first in master entry")
					If Not flag2 Then
						Dim flag3 As Boolean = Not Me.CheckTableHasRecords("SubCategory", "Add sub category profile first in master entry")
						If Not flag3 Then
							Dim flag4 As Boolean = Me.DataGridView1.RowCount = 0
							If flag4 Then
								MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Else
								Dim list As List(Of String) = New List(Of String)()
								Dim flag5 As Boolean = False
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
								Dim text2 As String
								Dim num As Double
								If flag6 Then
									text2 = ModCommonClasses.rdr(1).ToString()
									num = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
									Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag7 Then
										ModCommonClasses.rdr.Close()
									End If
								End If
								Me.lblStatus.Visible = True
								Me.ProgressBar1.Visible = True
								Me.ProgressBar1.Value = 0
								Me.ProgressBar1.Maximum = Me.DataGridView1.Rows.Count
								Me.ProgressBar1.Minimum = 0
								Me.ProgressBar1.[Step] = 1
								Dim count As Integer = Me.DataGridView1.Rows.Count
								Dim num2 As Integer = 0
								Dim dictionary As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)() From { { 0, "ID" }, { 1, "Product Code" }, { 2, "Product Name" }, { 3, "Sub Category ID" }, { 7, "Purchase Price" }, { 8, "Retail Sale Price" }, { 9, "Disc%" }, { 10, "CGST%" }, { 11, "SGST%" }, { 12, "CESS%" }, { 13, "Wholesale Price" }, { 14, "Purchase Unit" }, { 15, "Sale Unit" }, { 16, "Alter Unit" }, { 17, "Conversion Value" }, { 18, "Minimum Stock Value" }, { 19, "MRP" }, { 22, "Opening Qty" }, { 28, "Barcode" }, { 29, "Default Sale Qty" } }
								Dim num3 As Integer = 0
								Dim num4 As Integer = 0
								Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to start exporting blank/duplicate records?" & vbCrLf & "This will export all rows.", "Confirm Insertion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
								Dim flag8 As Boolean = dialogResult = DialogResult.Yes
								If flag8 Then
									Me.CheckAndExportDuplicateBarcodes_XLSX()
								End If
								Dim flag9 As Boolean = list.Count > 0
								If flag9 Then
									Dim text3 As String = "Duplicate PIDs found:" & vbCrLf + String.Join(vbCrLf, list)
									MessageBox.Show(text3, "Duplicate Products", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								End If
								Try
									For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
										Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
										Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
										If Not isNewRow Then
											Dim flag10 As Boolean = False
											Try
												For Each keyValuePair As KeyValuePair(Of Integer, String) In dictionary
													Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(keyValuePair.Key).Value)
													Dim text4 As String = If((objectValue Is Nothing OrElse Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue))), "", objectValue.ToString().Trim())
													Dim flag11 As Boolean = String.IsNullOrEmpty(text4)
													If flag11 Then
														flag10 = True
														Console.WriteLine(String.Format("Skipped Row {0}: {1} is blank.", dataGridViewRow.Index + 1, keyValuePair.Value))
														Exit For
													End If
												Next
											Finally
												Dim enumerator2 As Dictionary(Of Integer, String).Enumerator
												CType(enumerator2, IDisposable).Dispose()
											End Try
											Dim flag12 As Boolean = flag10
											If flag12 Then
												num3 += 1
											Else
												Dim text5 As String = ""
												Dim text6 As String = ""
												Try
													Dim flag13 As Boolean = Me.IsProductExist(dataGridViewRow.Cells(0).Value.ToString(), dataGridViewRow.Cells(28).Value.ToString())
													If flag13 Then
														Dim flag14 As Boolean = Operators.CompareString(dataGridViewRow.Cells(24).Value.ToString(), "", False) = 0
														If flag14 Then
															text5 = ""
														Else
															text5 = Me.GenerateDate(dataGridViewRow.Cells(24).Value.ToString())
														End If
														Dim flag15 As Boolean = Operators.CompareString(dataGridViewRow.Cells(25).Value.ToString(), "", False) = 0
														If flag15 Then
															text6 = ""
														Else
															text6 = Me.GenerateDate(dataGridViewRow.Cells(25).Value.ToString())
														End If
														list.Add(dataGridViewRow.Cells(0).Value.ToString())
														flag5 = True
													Else
														flag5 = False
													End If
													Dim flag16 As Boolean = Not flag5
													If flag16 Then
														Dim flag17 As Boolean = Not dataGridViewRow.IsNewRow
														If flag17 Then
															Me.Cursor = Cursors.WaitCursor
															Me.Timer1.Enabled = True
															SqlConnection.ClearAllPools()
															Me.auto()
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text7 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID,HSNCode,PartNo, Description, CostPrice, SellingPrice," & vbCrLf & "                                                Discount,CGST,SGST,CESS, ReorderPoint,OpeningStock,Barcode,PurchaseUnit,SalesUnit,SalesAltUnit,Conv,MinStock,MRP,Status," & vbCrLf & "                                                STax,PTax,GDown,Rack,DefQty,AddDate, loyality_mode, loyality_value)" & vbCrLf & "                                                VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24," & vbCrLf & "                                                @d25,@d26,@d27,@d28,@d29,@d30)"
															ModCommonClasses.cmd = New SqlCommand(text7)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(dataGridViewRow.Cells(0).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(1).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(2).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow.Cells(3).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow.Cells(4).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow.Cells(5).Value.ToString())
															Dim flag18 As Boolean = dataGridViewRow.Cells(6).Value IsNot Nothing
															If flag18 Then
																ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow.Cells(6).Value.ToString())
															Else
																ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow.Cells(2).Value.ToString())
															End If
															ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow.Cells(7).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow.Cells(8).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(dataGridViewRow.Cells(9).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(dataGridViewRow.Cells(10).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(dataGridViewRow.Cells(11).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(dataGridViewRow.Cells(12).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(dataGridViewRow.Cells(13).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "0")
															ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "0")
															ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow.Cells(14).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow.Cells(15).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow.Cells(16).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value)))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d22", "Yes")
															ModCommonClasses.cmd.Parameters.AddWithValue("@d23", "Inclusive")
															ModCommonClasses.cmd.Parameters.AddWithValue("@d24", "Exclusive")
															ModCommonClasses.cmd.Parameters.AddWithValue("@d25", dataGridViewRow.Cells(20).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d26", dataGridViewRow.Cells(21).Value.ToString())
															Dim flag19 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareString(dataGridViewRow.Cells(29).Value.ToString(), "", False) = 0, Operators.CompareObjectEqual(dataGridViewRow.Cells(29).Value, "0", False)))
															If flag19 Then
																ModCommonClasses.cmd.Parameters.AddWithValue("@d27", "1")
															Else
																ModCommonClasses.cmd.Parameters.AddWithValue("@d27", dataGridViewRow.Cells(29).Value.ToString())
															End If
															ModCommonClasses.cmd.Parameters.AddWithValue("@d28", DateTime.Today)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d29", text2.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Conversion.Val(num))
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.CommandTimeout = 0
															ModCommonClasses.cmd.ExecuteNonQuery()
															ModCommonClasses.con.Close()
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text8 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
															ModCommonClasses.cmd = New SqlCommand(text8)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow.Cells(0).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(15).Value.ToString())
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.ExecuteReader()
															ModCommonClasses.con.Close()
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
															ModCommonClasses.cmd = New SqlCommand(text9)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow.Cells(0).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(16).Value.ToString())
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.ExecuteReader()
															ModCommonClasses.con.Close()
															Dim flag20 As Boolean = Operators.CompareString(dataGridViewRow.Cells(28).Value.ToString(), "", False) <> 0
															If flag20 Then
																SqlConnection.ClearAllPools()
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text10 As String = "Select Barcode from Product_OpeningStock where Barcode=@d1"
																ModCommonClasses.cmd = New SqlCommand(text10)
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(28).Value.ToString())
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.cmd.CommandTimeout = 0
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag21 As Boolean = Not ModCommonClasses.rdr.Read()
																If flag21 Then
																	SqlConnection.ClearAllPools()
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim flag22 As Boolean = Operators.CompareString(dataGridViewRow.Cells(24).Value.ToString(), "", False) = 0
																	If flag22 Then
																		text5 = ""
																	Else
																		text5 = Me.GenerateDate(dataGridViewRow.Cells(24).Value.ToString())
																	End If
																	Dim flag23 As Boolean = Operators.CompareString(dataGridViewRow.Cells(25).Value.ToString(), "", False) = 0
																	If flag23 Then
																		text6 = ""
																	Else
																		text6 = Me.GenerateDate(dataGridViewRow.Cells(25).Value.ToString())
																	End If
																	Dim text11 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
																	ModCommonClasses.cmd = New SqlCommand(text11)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow.Cells(0).Value.ToString()))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow.Cells(22).Value.ToString()))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow.Cells(19).Value.ToString()))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow.Cells(8).Value.ToString()))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow.Cells(13).Value.ToString()))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow.Cells(23).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", text5)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", text6)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow.Cells(27).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(dataGridViewRow.Cells(7).Value.ToString()))
																	Dim num5 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value))
																	Dim num6 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(22).Value))
																	Dim num7 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value))
																	Dim num8 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value))
																	Dim num9 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", num5 * num6 + num5 * num6 * ((num7 + num8 + num9) / 100.0))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.CommandTimeout = 0
																	ModCommonClasses.cmd.ExecuteNonQuery()
																	ModCommonClasses.con.Close()
																	SqlConnection.ClearAllPools()
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text12 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))) + ",@img)"
																	ModCommonClasses.cmd = New SqlCommand(text12)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	Dim memoryStream As MemoryStream = New MemoryStream()
																	Dim bitmap As Bitmap = New Bitmap(Resources._12)
																	bitmap.Save(memoryStream, ImageFormat.Jpeg)
																	Dim buffer As Byte() = memoryStream.GetBuffer()
																	Dim sqlParameter As SqlParameter = New SqlParameter("@img", SqlDbType.Image)
																	sqlParameter.Value = buffer
																	ModCommonClasses.cmd.Parameters.Add(sqlParameter)
																	ModCommonClasses.cmd.ExecuteNonQuery()
																	ModCommonClasses.con.Close()
																	Dim checked As Boolean = Me.CheckBox1.Checked
																	If checked Then
																		ModCommonClasses.con = New SqlConnection(ModCS.cs)
																		ModCommonClasses.con.Open()
																		Dim text13 As String = "select ProductID from StockMovement where ProductID=@d1"
																		ModCommonClasses.cmd = New SqlCommand(text13)
																		ModCommonClasses.cmd.Connection = ModCommonClasses.con
																		ModCommonClasses.cmd.CommandTimeout = 0
																		ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
																		ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																		Dim flag24 As Boolean = Not ModCommonClasses.rdr.Read()
																		If flag24 Then
																			ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(22).Value))), 0D, DateAndTime.Today, dataGridViewRow.Cells(1).Value.ToString())
																		Else
																			ModCommonClasses.con = New SqlConnection(ModCS.cs)
																			ModCommonClasses.con.Open()
																			Dim text14 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
																			ModCommonClasses.cmd = New SqlCommand(text14)
																			ModCommonClasses.cmd.Connection = ModCommonClasses.con
																			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
																			ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
																			ModCommonClasses.cmd.CommandTimeout = 0
																			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																			Dim flag25 As Boolean = ModCommonClasses.rdr.Read()
																			Dim num10 As Double
																			If flag25 Then
																				num10 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
																			Else
																				num10 = 0.0
																			End If
																			ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))), New Decimal(num10), New Decimal(Conversion.Val(dataGridViewRow.Cells(22).Value.ToString())), 0D, DateAndTime.Today, dataGridViewRow.Cells(1).Value.ToString())
																		End If
																	End If
																End If
															End If
														End If
														num4 += 1
													End If
												Catch ex As Exception
													MessageBox.Show(ex.Message)
												End Try
												Try
													Dim flag26 As Boolean = Not flag5
													If flag26 Then
														Dim checked2 As Boolean = Me.CheckBox1.Checked
														If checked2 Then
															Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow.Cells(28).Value))
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text15 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode,SalesManPur,Variant_id) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22)"
															ModCommonClasses.cmd = New SqlCommand(text15)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow.Cells(0).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow.Cells(22).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow.Cells(28).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow.Cells(8).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow.Cells(13).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(dataGridViewRow.Cells(18).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow.Cells(19).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow.Cells(23).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d9", text5)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d10", text6)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow.Cells(26).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow.Cells(27).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
															ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
															ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Opening Stock")
															ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow.Cells(30).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow.Cells(31).Value.ToString())
															ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(dataGridViewRow.Cells(7).Value.ToString()))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow.Cells(7).Value.ToString()))
															Dim memoryStream2 As MemoryStream = New MemoryStream()
															Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
															bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
															Dim buffer2 As Byte() = memoryStream2.GetBuffer()
															Dim sqlParameter2 As SqlParameter = New SqlParameter("@d20", SqlDbType.Image)
															sqlParameter2.Value = buffer2
															ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d21", 0.0)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(dataGridViewRow.Cells(0).Value.ToString()))
															ModCommonClasses.cmd.CommandTimeout = 0
															ModCommonClasses.cmd.ExecuteNonQuery()
															ModCommonClasses.con.Close()
														End If
													End If
												Catch ex2 As Exception
												End Try
												num2 += 1
												Me.ProgressBar1.Value = num2
												Me.lblStatus.Text = String.Format("{0}%", CInt(Math.Round(CDbl(num2) / CDbl(count) * 100.0)))
												Global.System.Windows.Forms.Application.DoEvents()
											End If
										End If
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								MessageBox.Show("✅ Insert completed." & vbCrLf + String.Format("Inserted: {0}", num4) + vbCrLf + String.Format("Skipped: {0}", num3), "Process Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							End If
						End If
					End If
				End If
			Catch ex3 As Exception
				MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001984 RID: 6532 RVA: 0x00118B6C File Offset: 0x00116D6C
		Private Sub CheckAndExportDuplicateBarcodes_XLSX()
			' The following expression was wrapped in a checked-statement
			Try
				Me.Label1.Visible = True
				Me.ProgressBar2.Visible = True
				Me.ProgressBar2.Value = 0
				Me.ProgressBar2.Maximum = Me.DataGridView1.Rows.Count
				Me.ProgressBar2.Minimum = 0
								Dim list As List(Of DataGridViewRow) = Me.DataGridView1.Rows.Cast(Of DataGridViewRow)().Where(Function(r) Not r.IsNewRow).ToList()
				Dim list2 As List(Of String) = list.GroupBy(Function(r) If(r.Cells(28).Value IsNot Nothing, r.Cells(28).Value.ToString().Trim(), "")).Where(Function(g) g.Count() > 1 AndAlso Operators.CompareString(g.Key, "", False) <> 0).Select(Function(g) g.Key).ToList()
				Dim array As Integer() = New Integer() { 0, 1, 2, 3, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 22, 28, 29 }
				Dim dataTable As DataTable = New DataTable("Duplicate_Blank_Existing")
				Try
					For Each obj As Object In Me.DataGridView1.Columns
						Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
						dataTable.Columns.Add(dataGridViewColumn.HeaderText, GetType(String))
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each dataGridViewRow As DataGridViewRow In list
						Dim text As String = If((dataGridViewRow.Cells(28).Value IsNot Nothing), dataGridViewRow.Cells(28).Value.ToString().Trim(), "")
						Dim text2 As String = If((dataGridViewRow.Cells(0).Value IsNot Nothing), dataGridViewRow.Cells(0).Value.ToString().Trim(), "")
						Dim flag As Boolean = list2.Contains(text)
						Dim flag2 As Boolean = False
						For Each num As Integer In array
							Dim text3 As String = (If(dataGridViewRow.Cells(num).Value, "")).ToString().Trim()
							Dim flag3 As Boolean = Operators.CompareString(text3, "", False) = 0
							If flag3 Then
								flag2 = True
								Exit For
							End If
						Next
						Dim flag4 As Boolean = Me.IsProductExist(text2, text)
						Dim flag5 As Boolean = flag OrElse flag2 OrElse flag4
						If flag5 Then
							Dim dataRow As DataRow = dataTable.NewRow()
							Dim num2 As Integer = Me.DataGridView1.Columns.Count - 1
							For j As Integer = 0 To num2
								dataRow(j) = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(j).Value))
							Next
							dataTable.Rows.Add(dataRow)
						End If
						Dim flag6 As Boolean = Me.ProgressBar2.Value < Me.ProgressBar2.Maximum
						If flag6 Then
							Dim progressBar As ProgressBar = Me.ProgressBar2
							Dim progressBar2 As ProgressBar = progressBar
							progressBar.Value = progressBar2.Value + 1
							Global.System.Windows.Forms.Application.DoEvents()
						End If
					Next
				Finally
					Dim enumerator2 As List(Of DataGridViewRow).Enumerator
					CType(enumerator2, IDisposable).Dispose()
				End Try
				Dim flag7 As Boolean = dataTable.Rows.Count = 0
				If flag7 Then
					MessageBox.Show("✅ No duplicates, blanks, or existing products found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					Dim saveFileDialog As SaveFileDialog = New SaveFileDialog() With { .Filter = "Excel Workbook (*.xlsx)|*.xlsx", .FileName = String.Format("Duplicates_Blanks_Existing_{0:yyyyMMdd_HHmmss}.xlsx", DateTime.Now) }
					Dim flag8 As Boolean = saveFileDialog.ShowDialog() <> DialogResult.OK
					If Not flag8 Then
						Dim fileName As String = saveFileDialog.FileName
						Dim application As Excel.Application = CType(Activator.CreateInstance(Marshal.GetTypeFromCLSID(New Guid("00024500-0000-0000-C000-000000000046"))), Microsoft.Office.Interop.Excel.Application)
						Dim workbook As Excel.Workbook = application.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value))
						Dim worksheet As Excel.Worksheet = CType(workbook.Sheets(1), Excel.Worksheet)
						worksheet.Name = "Sheet1"
						Dim num3 As Integer = dataTable.Columns.Count - 1
						For k As Integer = 0 To num3
							worksheet.Cells(1, k + 1) = dataTable.Columns(k).ColumnName
						Next
						Dim array3 As Object(,) = New Object(dataTable.Rows.Count - 1 + 1 - 1, dataTable.Columns.Count - 1 + 1 - 1) {}
						Dim num4 As Integer = dataTable.Rows.Count - 1
						For l As Integer = 0 To num4
							Dim num5 As Integer = dataTable.Columns.Count - 1
							For m As Integer = 0 To num5
								array3(l, m) = RuntimeHelpers.GetObjectValue(dataTable.Rows(l)(m))
							Next
						Next
						Dim range As Excel.Range = CType(worksheet.Cells(2, 1), Excel.Range)
						Dim range2 As Excel.Range = CType(worksheet.Cells(dataTable.Rows.Count + 1, dataTable.Columns.Count), Excel.Range)
						Dim range3 As Excel.Range = worksheet.get_Range(range, range2)
						range3.set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), array3)
						Dim range4 As Excel.Range = worksheet.get_Range("A1", RuntimeHelpers.GetObjectValue(worksheet.Cells(1, dataTable.Columns.Count)))
						range4.Font.Bold = True
						worksheet.Columns.AutoFit()
						workbook.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), Excel.XlSaveAsAccessMode.xlNoChange, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value))
						workbook.Close(False, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value))
						application.Quit()
						Me.ReleaseObject(range4)
						Me.ReleaseObject(worksheet)
						Me.ReleaseObject(workbook)
						Me.ReleaseObject(application)
					MessageBox.Show(String.Format("Export complete: {0} duplicate rows saved to ''{1}''", list2.Count, fileName), "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("❌ Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001985 RID: 6533 RVA: 0x001192D4 File Offset: 0x001174D4
		Private Sub ReleaseObject(obj As Object)
			Try
				Marshal.ReleaseComObject(RuntimeHelpers.GetObjectValue(obj))
				obj = Nothing
			Catch ex As Exception
				obj = Nothing
			Finally
				GC.Collect()
			End Try
		End Sub

		' Token: 0x06001986 RID: 6534 RVA: 0x0011932C File Offset: 0x0011752C
		Private Sub ExportDuplicateBarcodes()
			Dim list As List(Of DataGridViewRow) = Me.DataGridView1.Rows.Cast(Of DataGridViewRow)().Where(Function(r) Not r.IsNewRow).ToList()
			Dim duplicateBarcodes As List(Of String) = list.GroupBy(Function(r) Convert.ToString(RuntimeHelpers.GetObjectValue(r.Cells(28).Value)).Trim()).Where(Function(g) g.Count() > 1 AndAlso Operators.CompareString(g.Key, "", False) <> 0).Select(Function(g) g.Key).ToList()
			If duplicateBarcodes.Count = 0 Then
				MessageBox.Show("âœ… No duplicate barcodes found in grid.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Else
				Dim list2 As List(Of DataGridViewRow) = list.Where(Function(r As DataGridViewRow) duplicateBarcodes.Contains(Convert.ToString(RuntimeHelpers.GetObjectValue(r.Cells(28).Value)).Trim())).ToList()
				Dim saveFileDialog As New SaveFileDialog() With { .Filter = "CSV Files (*.xls)|*.xls", .FileName = String.Format("Duplicate_Barcodes_{0:yyyyMMdd_HHmmss}.xls", DateTime.Now) }
				If saveFileDialog.ShowDialog() = DialogResult.OK Then
					Dim fileName As String = saveFileDialog.FileName
					Using streamWriter As New StreamWriter(fileName, False, Encoding.UTF8)
						Dim headers As IEnumerable(Of String) = Me.DataGridView1.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) String.Format("""{0}""", c.HeaderText.Replace("""", """""")))
						streamWriter.WriteLine(String.Join(",", headers))
						For Each dataGridViewRow As DataGridViewRow In list2
							Dim cellVals As IEnumerable(Of String) = dataGridViewRow.Cells.Cast(Of DataGridViewCell)().Select(Function(c) String.Format("""{0}""", Convert.ToString(RuntimeHelpers.GetObjectValue(c.Value)).Replace("""", """""")))
							streamWriter.WriteLine(String.Join(",", cellVals))
						Next
					End Using
					MessageBox.Show(String.Format("Export complete: {0} duplicate rows saved to ''{1}''", list2.Count, fileName), "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			End If
		End Sub

		' Token: 0x06001987 RID: 6535 RVA: 0x001195CC File Offset: 0x001177CC
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim text As String = Path.Combine(Global.System.Windows.Forms.Application.StartupPath, "Product_Format_samle.xlsx")
				Dim text2 As String = Path.Combine(Global.System.Windows.Forms.Application.StartupPath, "Product_Format_samle.xls")
				Dim flag As Boolean = File.Exists(text)
				Dim text3 As String
				If flag Then
					text3 = text
				Else
					Dim flag2 As Boolean = File.Exists(text2)
					If Not flag2 Then
						MessageBox.Show("Sample Excel file not found (.xls or .xlsx) in Debug folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Return
					End If
					text3 = text2
				End If
				Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
					saveFileDialog.Title = "Save Sample Excel File"
					saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls"
					saveFileDialog.FileName = Path.GetFileName(text3)
					Dim flag3 As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
					If flag3 Then
						File.Copy(text3, saveFileDialog.FileName, True)
						MessageBox.Show("Sample file saved successfully at: " + saveFileDialog.FileName, "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("Error while saving sample file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x040009E4 RID: 2532
		Private bgWorker As BackgroundWorker
	End Class
End Namespace
