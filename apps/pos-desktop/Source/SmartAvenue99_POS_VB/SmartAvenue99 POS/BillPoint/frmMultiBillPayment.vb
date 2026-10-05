Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000B0 RID: 176
	<DesignerGenerated()>
	Public Partial Class frmMultiBillPayment
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060019A7 RID: 6567 RVA: 0x0011A0F0 File Offset: 0x001182F0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMultiBillPayment_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmMultiBillPayment_FormClosing
			Me.NetAmount = 0.0
			Me.ChangeAmount = 0.0
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000A0E RID: 2574
		' (get) Token: 0x060019AA RID: 6570 RVA: 0x0001368C File Offset: 0x0001188C
		' (set) Token: 0x060019AB RID: 6571 RVA: 0x0011AAB4 File Offset: 0x00118CB4
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.dgw_EditingControlShowing
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellClick
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.dgw_CellValueChanged
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.CellValueChanged, dataGridViewCellEventHandler2
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler
					AddHandler dataGridView.CellValueChanged, dataGridViewCellEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17000A0F RID: 2575
		' (get) Token: 0x060019AC RID: 6572 RVA: 0x00013696 File Offset: 0x00011896
		' (set) Token: 0x060019AD RID: 6573 RVA: 0x0011AB54 File Offset: 0x00118D54
		Private _btnSettings As Button
		Friend Overridable Property btnSettings As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSettings
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPaymentModeSettings_Click
				Dim button As Button = Me._btnSettings
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSettings = value
				button = Me._btnSettings
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A10 RID: 2576
		' (get) Token: 0x060019AE RID: 6574 RVA: 0x000136A0 File Offset: 0x000118A0
		' (set) Token: 0x060019AF RID: 6575 RVA: 0x000136AA File Offset: 0x000118AA
		Friend Overridable Property BtnGrandTotal As GelButton

		' Token: 0x17000A11 RID: 2577
		' (get) Token: 0x060019B0 RID: 6576 RVA: 0x000136B3 File Offset: 0x000118B3
		' (set) Token: 0x060019B1 RID: 6577 RVA: 0x000136BD File Offset: 0x000118BD
		Friend Overridable Property btnPaidAmount As GelButton

		' Token: 0x17000A12 RID: 2578
		' (get) Token: 0x060019B2 RID: 6578 RVA: 0x000136C6 File Offset: 0x000118C6
		' (set) Token: 0x060019B3 RID: 6579 RVA: 0x000136D0 File Offset: 0x000118D0
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x17000A13 RID: 2579
		' (get) Token: 0x060019B4 RID: 6580 RVA: 0x000136D9 File Offset: 0x000118D9
		' (set) Token: 0x060019B5 RID: 6581 RVA: 0x000136E3 File Offset: 0x000118E3
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17000A14 RID: 2580
		' (get) Token: 0x060019B6 RID: 6582 RVA: 0x000136EC File Offset: 0x000118EC
		' (set) Token: 0x060019B7 RID: 6583 RVA: 0x000136F6 File Offset: 0x000118F6
		Friend Overridable Property DataGridViewComboBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17000A15 RID: 2581
		' (get) Token: 0x060019B8 RID: 6584 RVA: 0x000136FF File Offset: 0x000118FF
		' (set) Token: 0x060019B9 RID: 6585 RVA: 0x0011AB98 File Offset: 0x00118D98
		Private _btnSave As Button
		Friend Overridable Property btnSave As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim button As Button = Me._btnSave
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSave = value
				button = Me._btnSave
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A16 RID: 2582
		' (get) Token: 0x060019BA RID: 6586 RVA: 0x00013709 File Offset: 0x00011909
		' (set) Token: 0x060019BB RID: 6587 RVA: 0x00013713 File Offset: 0x00011913
		Friend Overridable Property lblCustomerId As Label

		' Token: 0x17000A17 RID: 2583
		' (get) Token: 0x060019BC RID: 6588 RVA: 0x0001371C File Offset: 0x0001191C
		' (set) Token: 0x060019BD RID: 6589 RVA: 0x00013726 File Offset: 0x00011926
		Friend Overridable Property lblLimit As Label

		' Token: 0x060019BE RID: 6590 RVA: 0x0001372F File Offset: 0x0001192F
		Private Sub frmMultiBillPayment_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.FetchCUstomerLimit()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x060019BF RID: 6591 RVA: 0x0011ABDC File Offset: 0x00118DDC
		Public Sub FetchCUstomerLimit()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Limit from Customer where ID=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblCustomerId.Text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Me.lblLimit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060019C0 RID: 6592 RVA: 0x0011AC8C File Offset: 0x00118E8C
		Public Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select Mode_Index , RTRIM(paymentmode) , amount from tbl_BillPaymentMode where [status] = 1 order by Mode_Index", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				Me.dgw.Rows.Add(New Object() { 0, "By Return", "0.00" })
				Me.dgw.Rows.Add(New Object() { 0, "Change", "0.00" })
				Me.btnPaidAmount.Text = "Paid Amount : 0.00"
				Me.ChangeAmount = 0.0
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
				Me.dgw.Rows(Me.dgw.RowCount - 1).[ReadOnly] = True
				Me.dgw.Rows(Me.dgw.RowCount - 2).[ReadOnly] = True
				Me.dgw.ClearSelection()
				Dim flag As Boolean = Me.dgw.RowCount > 0
				If flag Then
					MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
						Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(2)
						Me.dgw.BeginEdit(True)
					End Sub))
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060019C1 RID: 6593 RVA: 0x00013748 File Offset: 0x00011948
		Private Sub btnPaymentModeSettings_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmMultiPaymentModeSettings.ShowDialog()
		End Sub

		' Token: 0x060019C2 RID: 6594 RVA: 0x0011AEB8 File Offset: 0x001190B8
		Private Sub dgw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Dim flag As Boolean = Me.dgw.CurrentCell.ColumnIndex = 2
			If flag Then
				Dim textBox As TextBox = TryCast(e.Control, TextBox)
				Dim flag2 As Boolean = textBox IsNot Nothing
				If flag2 Then
					RemoveHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
					AddHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
				End If
			End If
		End Sub

		' Token: 0x060019C3 RID: 6595 RVA: 0x0011AF1C File Offset: 0x0011911C
		Private Sub NumericDecimal_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim textBox As TextBox = CType(sender, TextBox)
			Dim flag As Boolean = Char.IsControl(e.KeyChar)
			If Not flag Then
				Dim flag2 As Boolean = e.KeyChar = "."c
				If flag2 Then
					Dim flag3 As Boolean = textBox.Text.Contains(".")
					If flag3 Then
						e.Handled = True
					End If
				Else
					Dim flag4 As Boolean = Not Char.IsDigit(e.KeyChar)
					If flag4 Then
						e.Handled = True
					End If
				End If
			End If
		End Sub

		' Token: 0x060019C4 RID: 6596 RVA: 0x0011AF90 File Offset: 0x00119190
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 2
			If flag Then
				e.SuppressKeyPress = True
				Dim num As Integer = Me.dgw.CurrentCell.RowIndex
				Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
				Dim text As String = ""
				Dim flag2 As Boolean = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex).Cells(1).Value IsNot Nothing
				If flag2 Then
					text = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex).Cells(1).Value.ToString().Trim()
				End If
				Dim flag3 As Boolean = text.StartsWith("Credit Terms", StringComparison.OrdinalIgnoreCase)
				If flag3 Then
					Me.btnSave.Focus()
				Else
					Dim flag4 As Boolean = num < Me.dgw.Rows.Count - 1
					If flag4 Then
						num += 1
					Else
						num = 0
					End If
					Me.dgw.CurrentCell = Me.dgw.Rows(num).Cells(columnIndex)
					Me.DisableChangeRow(num)
				End If
			End If
		End Sub

		' Token: 0x060019C5 RID: 6597 RVA: 0x0011B0E4 File Offset: 0x001192E4
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Dim num As Integer = Me.dgw.CurrentCell.RowIndex
			Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
			Dim flag As Boolean = keyData = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Me.dgw.Focused OrElse (Me.dgw.IsCurrentCellInEditMode AndAlso Me.dgw.CurrentCell.ColumnIndex = 2)
				If flag2 Then
					Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
					Dim columnIndex2 As Integer = Me.dgw.CurrentCell.ColumnIndex
					Dim flag3 As Boolean = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex).Cells(1).Value IsNot Nothing
					If flag3 Then
						Dim text As String = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex).Cells(1).Value.ToString().Trim()
					End If
					Dim flag4 As Boolean = rowIndex < Me.dgw.Rows.Count - 3
					If flag4 Then
						num += 1
						Me.dgw.CurrentCell = Me.dgw.Rows(num).Cells(columnIndex2)
						Me.DisableChangeRow(num)
					Else
						Me.btnSave.Focus()
					End If
					Return True
				End If
			End If
			If keyData <> Keys.Up Then
				If keyData = Keys.Down Then
					Dim flag5 As Boolean = num < Me.dgw.Rows.Count - 1
					If flag5 Then
						num += 1
						Me.dgw.CurrentCell = Me.dgw.Rows(num).Cells(columnIndex)
						Me.DisableChangeRow(num)
						Return True
					End If
				End If
			Else
				Dim flag6 As Boolean = num > 0
				If flag6 Then
					num -= 1
					Me.dgw.CurrentCell = Me.dgw.Rows(num).Cells(columnIndex)
					Me.DisableChangeRow(num)
					Return True
				End If
			End If
			Return MyBase.ProcessCmdKey(msg, keyData)
		End Function

		' Token: 0x060019C6 RID: 6598 RVA: 0x0001375B File Offset: 0x0001195B
		Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Me.DisableChangeRow(e.RowIndex)
		End Sub

		' Token: 0x060019C7 RID: 6599 RVA: 0x0011B32C File Offset: 0x0011952C
		Private Sub dgw_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.RowIndex < 0 OrElse e.ColumnIndex <> 2
			If Not flag Then
				Dim text As String = (If(Me.dgw.Rows(e.RowIndex).Cells(1).Value, "")).ToString().Trim()
				Dim flag2 As Boolean = text.Equals("Change", StringComparison.OrdinalIgnoreCase)
				If Not flag2 Then
					Me.CalculateTotalPaid()
				End If
			End If
		End Sub

		' Token: 0x060019C8 RID: 6600 RVA: 0x0011B3AC File Offset: 0x001195AC
		Private Sub frmMultiBillPayment_FormClosing(sender As Object, e As FormClosingEventArgs)
			Try
				Me.NetAmount = 0.0
				Me.ChangeAmount = 0.0
				Me.dgw.Rows.Clear()
				Me.dgw.DataSource = Nothing
				Me.dgw.Refresh()
				Me.btnPaidAmount.Text = "Paid Amount : 0.00"
			Catch ex As Exception
				MessageBox.Show("Error during cleanup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060019C9 RID: 6601 RVA: 0x0011B454 File Offset: 0x00119654
		Public Sub DisableChangeRow(RowIndex As Integer)
			' The following expression was wrapped in a checked-expression
			Dim flag As Boolean = Me.dgw.RowCount - 2 <= RowIndex
			If flag Then
				Me.dgw.CurrentCell.[ReadOnly] = True
			Else
				Me.dgw.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060019CA RID: 6602 RVA: 0x0011B4A0 File Offset: 0x001196A0
		Public Sub CalculateByCashToChange(totalPaid As Double)
			Me.ChangeAmount = totalPaid - Me.NetAmount
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
					If Not isNewRow Then
						Dim text As String = (If(dataGridViewRow.Cells(1).Value, "")).ToString().Trim()
						Dim flag As Boolean = text.Equals("Change", StringComparison.OrdinalIgnoreCase)
						If flag Then
							dataGridViewRow.Cells(2).Value = Me.ChangeAmount.ToString("0.00")
							Exit For
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060019CB RID: 6603 RVA: 0x0011B57C File Offset: 0x0011977C
		Public Function IsValidRowToCalculate(mode As String) As Boolean
			mode = (If(mode, "")).Trim()
			Return Operators.CompareString(mode, "By Return", False) <> 0 AndAlso Operators.CompareString(mode, "Change", False) <> 0
		End Function

		' Token: 0x060019CC RID: 6604 RVA: 0x0011B5C0 File Offset: 0x001197C0
		Public Sub CalculateTotalPaid()
			Dim num As Double = 0.0
			Dim num2 As Double = 0.0
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
					If Not isNewRow Then
						Dim text As String = (If(dataGridViewRow.Cells(1).Value, "")).ToString().Trim()
						Dim num3 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
						Dim flag As Boolean = Me.IsValidRowToCalculate(text)
						If flag Then
							num += num3
							Dim flag2 As Boolean = Not text.Equals("By Cash", StringComparison.OrdinalIgnoreCase)
							If flag2 Then
								num2 += num3
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim flag3 As Boolean = num2 > Me.NetAmount
			If flag3 Then
				MessageBox.Show(String.Format("Cannot enter greater than {0}", Me.NetAmount), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Dim flag4 As Boolean = Me.dgw.CurrentCell IsNot Nothing AndAlso Me.dgw.CurrentCell.ColumnIndex = 2
				If flag4 Then
					Me.dgw.CurrentCell.Value = "0.00"
				End If
			Else
				Me.btnPaidAmount.Text = String.Format("Paid Amount : {0:0.00}", num)
				Me.CalculateByCashToChange(num)
			End If
		End Sub

		' Token: 0x060019CD RID: 6605 RVA: 0x0011B758 File Offset: 0x00119958
		Private Function GetAmountFromText(input As String) As Decimal
			Dim flag As Boolean = String.IsNullOrWhiteSpace(input)
			Dim num As Decimal
			If flag Then
				num = 0D
			Else
				Dim array As String() = input.Split(New Char() { ":"c })
				Dim text As String = If((array.Length > 1), array(1), array(0))
				Dim match As Match = Regex.Match(text, "[\-]?\d+(\.\d+)?")
				Dim success As Boolean = match.Success
				If success Then
					Dim value As String = match.Value
					Dim num2 As Decimal
					Dim flag2 As Boolean = Decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, num2)
					If flag2 Then
						Return num2
					End If
				End If
				num = 0D
			End If
			Return num
		End Function

		' Token: 0x060019CE RID: 6606 RVA: 0x0011B7E8 File Offset: 0x001199E8
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim num As Decimal = 0D
			Try
				Dim flag As Boolean = Me.dgw.Columns(1).HeaderText.Trim().ToLower().StartsWith("credit")
				If flag Then
					Try
						For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
							If flag2 Then
								Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value)
								Dim flag3 As Boolean = objectValue IsNot Nothing AndAlso Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(objectValue))
								If flag3 Then
									num = Decimal.Add(num, Convert.ToDecimal(RuntimeHelpers.GetObjectValue(objectValue)))
								End If
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				End If
				Dim flag4 As Boolean = Decimal.Compare(Convert.ToDecimal(Me.lblLimit.Text), num) > 0
				If flag4 Then
					MessageBox.Show("Your Credit Limit is Cross, Your Limit is " + Me.lblLimit.Text)
					Return
				End If
			Catch ex As Exception
				MessageBox.Show("Error calculating total: " + ex.Message)
			End Try
			Try
				Dim amountFromText As Decimal = Me.GetAmountFromText(Me.btnPaidAmount.Text)
				Dim amountFromText2 As Decimal = Me.GetAmountFromText(Me.BtnGrandTotal.Text)
				Dim flag5 As Boolean = Conversion.Val(amountFromText) < Conversion.Val(amountFromText2)
				If flag5 Then
					MessageBox.Show("Please Check Payment Method !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
					Me.dgw.BeginEdit(True)
				Else
					MyProject.Forms.frmPOSTouch.DataGridView2.Rows.Clear()
					Dim list As List(Of DataGridViewRow) = New List(Of DataGridViewRow)()
					Dim num2 As Double = 0.0
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							Dim flag6 As Boolean = dataGridViewRow2.Index > Me.dgw.RowCount - 3
							If flag6 Then
								Exit For
							End If
							Dim isNewRow As Boolean = dataGridViewRow2.IsNewRow
							If Not isNewRow Then
								Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(2).Value)
								Dim flag7 As Boolean = objectValue2 IsNot Nothing AndAlso Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(objectValue2)) AndAlso Decimal.Compare(Convert.ToDecimal(RuntimeHelpers.GetObjectValue(objectValue2)), 0D) > 0
								If flag7 Then
									num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(objectValue2))
									list.Add(dataGridViewRow2)
								End If
							End If
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Dim flag8 As Boolean = list.Count <= 0
					If flag8 Then
						MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim activeAccountInfo As String = Me.GetActiveAccountInfo()
						Try
							For Each dataGridViewRow3 As DataGridViewRow In list
								Dim flag9 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(2).Value)) > 0.0
								If flag9 Then
									Dim flag10 As Boolean = (Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)) > 0.0) And (Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)) < 8.0)
									If flag10 Then
										Dim flag11 As Boolean = Conversions.ToDouble(activeAccountInfo) <= 0.0
										If flag11 Then
											MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Return
										End If
									End If
									Dim flag12 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow3.Cells(2).Value, "Credit Terms - Adjust", False), Operators.CompareObjectEqual(dataGridViewRow3.Cells(0).Value, 15, False)))
									If flag12 Then
										MessageBox.Show("Sorry, you are not allowed to double Adjust Entry", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Return
									End If
									Dim flag13 As Boolean = Conversions.ToBoolean(Operators.AndObject(Conversion.Val(Me.NetAmount) > num2, Operators.CompareObjectEqual(dataGridViewRow3.Cells(0).Value, 15, False)))
									If flag13 Then
										MessageBox.Show("Sorry, you are not allowed to adjust excess amount than balance", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Return
									End If
									MyProject.Forms.frmPOSTouch.cmbPaymentMode.Text = Conversions.ToString(dataGridViewRow3.Cells(1).Value)
									MyProject.Forms.frmPOSTouch.dtpPaymentDate.Value = DateAndTime.Today
									MyProject.Forms.frmPOSTouch.txtPayment.Text = Conversions.ToString(dataGridViewRow3.Cells(2).Value)
									Dim flag14 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow3.Cells(0).Value, 0, False)
									If flag14 Then
										' The following expression was wrapped in a checked-expression
										MyProject.Forms.frmPOSTouch.txtPayment.Text = Conversions.ToString(Operators.SubtractObject(dataGridViewRow3.Cells(2).Value, Conversion.Val(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(Me.dgw.RowCount - 1).Cells(2).Value))))
									Else
										MyProject.Forms.frmPOSTouch.cmbAccountNo.Text = activeAccountInfo
									End If
									MyProject.Forms.frmPOSTouch.DataGridView2.Rows.Add(New Object() { MyProject.Forms.frmPOSTouch.cmbPaymentMode.Text, Strings.Format(Math.Round(Conversion.Val(MyProject.Forms.frmPOSTouch.txtPayment.Text), 2), "0.00"), MyProject.Forms.frmPOSTouch.dtpPaymentDate.Value.[Date], MyProject.Forms.frmPOSTouch.cmbAccountNo.Text })
								End If
							Next
						Finally
							Dim enumerator3 As List(Of DataGridViewRow).Enumerator
							CType(enumerator3, IDisposable).Dispose()
						End Try
						Dim num3 As Double = MyProject.Forms.frmPOSTouch.TotalPayment()
						num3 = Conversions.ToDouble(Strings.Format(Math.Round(num3, 2), "0.00"))
						MyProject.Forms.frmPOSTouch.txtTotalPayment.Text = Conversions.ToString(num3)
						Try
							Dim flag15 As Boolean = MyProject.Forms.frmPOSTouch.DataGridView6.Rows.Count > 0
							If flag15 Then
								MyProject.Forms.frmPOSTouch.InsertD_SaleProduct()
							End If
						Catch ex2 As Exception
						End Try
						MyProject.Forms.frmPOSTouch.Compute()
						MyProject.Forms.frmPOSTouch.btnSave_Click(RuntimeHelpers.GetObjectValue(sender), e)
						MyBase.Dispose()
					End If
				End If
			Catch ex3 As Exception
				Interaction.MsgBox(ex3.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060019CF RID: 6607 RVA: 0x0011C018 File Offset: 0x0011A218
		Private Function GetActiveAccountInfo() As String
			Dim text As String
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Dim flag As Boolean = (ModCommonClasses.dtable IsNot Nothing) And (ModCommonClasses.dtable.Rows.Count > 0)
				If flag Then
					text = Conversions.ToString(ModCommonClasses.dtable.AsEnumerable().ElementAtOrDefault(0)(0))
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return text
		End Function

		' Token: 0x04000A02 RID: 2562
		Public NetAmount As Double

		' Token: 0x04000A03 RID: 2563
		Public ChangeAmount As Double
	End Class
End Namespace
