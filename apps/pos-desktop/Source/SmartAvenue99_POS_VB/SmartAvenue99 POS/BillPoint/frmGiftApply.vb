Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000115 RID: 277
	<DesignerGenerated()>
	Public Partial Class frmGiftApply
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002F7A RID: 12154 RVA: 0x001D38F0 File Offset: 0x001D1AF0
		Public Sub New()
			AddHandler MyBase.KeyDown, AddressOf Me.frmGiftApply_KeyDown
			AddHandler MyBase.FormClosed, AddressOf Me.frmGiftApply_FormClosed
			AddHandler MyBase.Load, AddressOf Me.frmGiftApply_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001284 RID: 4740
		' (get) Token: 0x06002F7D RID: 12157 RVA: 0x0001DD9E File Offset: 0x0001BF9E
		' (set) Token: 0x06002F7E RID: 12158 RVA: 0x0001DDA8 File Offset: 0x0001BFA8
		Friend Overridable Property Label9 As Label

		' Token: 0x17001285 RID: 4741
		' (get) Token: 0x06002F7F RID: 12159 RVA: 0x0001DDB1 File Offset: 0x0001BFB1
		' (set) Token: 0x06002F80 RID: 12160 RVA: 0x0001DDBB File Offset: 0x0001BFBB
		Friend Overridable Property Label8 As Label

		' Token: 0x17001286 RID: 4742
		' (get) Token: 0x06002F81 RID: 12161 RVA: 0x0001DDC4 File Offset: 0x0001BFC4
		' (set) Token: 0x06002F82 RID: 12162 RVA: 0x0001DDCE File Offset: 0x0001BFCE
		Friend Overridable Property Label7 As Label

		' Token: 0x17001287 RID: 4743
		' (get) Token: 0x06002F83 RID: 12163 RVA: 0x0001DDD7 File Offset: 0x0001BFD7
		' (set) Token: 0x06002F84 RID: 12164 RVA: 0x001D4378 File Offset: 0x001D2578
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001288 RID: 4744
		' (get) Token: 0x06002F85 RID: 12165 RVA: 0x0001DDE1 File Offset: 0x0001BFE1
		' (set) Token: 0x06002F86 RID: 12166 RVA: 0x0001DDEB File Offset: 0x0001BFEB
		Friend Overridable Property Label6 As Label

		' Token: 0x17001289 RID: 4745
		' (get) Token: 0x06002F87 RID: 12167 RVA: 0x0001DDF4 File Offset: 0x0001BFF4
		' (set) Token: 0x06002F88 RID: 12168 RVA: 0x0001DDFE File Offset: 0x0001BFFE
		Friend Overridable Property Label5 As Label

		' Token: 0x1700128A RID: 4746
		' (get) Token: 0x06002F89 RID: 12169 RVA: 0x0001DE07 File Offset: 0x0001C007
		' (set) Token: 0x06002F8A RID: 12170 RVA: 0x0001DE11 File Offset: 0x0001C011
		Friend Overridable Property Label4 As Label

		' Token: 0x1700128B RID: 4747
		' (get) Token: 0x06002F8B RID: 12171 RVA: 0x0001DE1A File Offset: 0x0001C01A
		' (set) Token: 0x06002F8C RID: 12172 RVA: 0x0001DE24 File Offset: 0x0001C024
		Friend Overridable Property Label3 As Label

		' Token: 0x1700128C RID: 4748
		' (get) Token: 0x06002F8D RID: 12173 RVA: 0x0001DE2D File Offset: 0x0001C02D
		' (set) Token: 0x06002F8E RID: 12174 RVA: 0x0001DE37 File Offset: 0x0001C037
		Friend Overridable Property Label2 As Label

		' Token: 0x1700128D RID: 4749
		' (get) Token: 0x06002F8F RID: 12175 RVA: 0x0001DE40 File Offset: 0x0001C040
		' (set) Token: 0x06002F90 RID: 12176 RVA: 0x001D43BC File Offset: 0x001D25BC
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700128E RID: 4750
		' (get) Token: 0x06002F91 RID: 12177 RVA: 0x0001DE4A File Offset: 0x0001C04A
		' (set) Token: 0x06002F92 RID: 12178 RVA: 0x0001DE54 File Offset: 0x0001C054
		Friend Overridable Property Label1 As Label

		' Token: 0x1700128F RID: 4751
		' (get) Token: 0x06002F93 RID: 12179 RVA: 0x0001DE5D File Offset: 0x0001C05D
		' (set) Token: 0x06002F94 RID: 12180 RVA: 0x001D4400 File Offset: 0x001D2600
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001290 RID: 4752
		' (get) Token: 0x06002F95 RID: 12181 RVA: 0x0001DE67 File Offset: 0x0001C067
		' (set) Token: 0x06002F96 RID: 12182 RVA: 0x0001DE71 File Offset: 0x0001C071
		Friend Overridable Property Label10 As Label

		' Token: 0x06002F97 RID: 12183 RVA: 0x001D4444 File Offset: 0x001D2644
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Select Validfrom, Validto from GiftInfo where GiftCode=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Dim dateTime As DateTime = Conversions.ToDate(ModCommonClasses.rdr.GetValue(0))
				Dim dateTime2 As DateTime = Conversions.ToDate(ModCommonClasses.rdr.GetValue(1))
				Dim num As Double = CDbl((dateTime2 - dateTime).Days)
				Dim flag2 As Boolean = num <= 0.0
				If flag2 Then
					MessageBox.Show("Gift voucher has already been expired !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.TextBox1.Focus()
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Return
				End If
				Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag4 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			ModCommonClasses.con.Close()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text2 As String = "Select GiftCode from GiftInfo where Status='USED' and GiftCode=@d1"
			ModCommonClasses.cmd = New SqlCommand(text2)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
			If flag5 Then
				MessageBox.Show("Gift voucher has already been Used !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.TextBox1.Focus()
				Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag6 Then
					ModCommonClasses.rdr.Close()
				End If
			Else
				ModCommonClasses.con.Close()
				Try
					ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
					ModCommonClasses.con1.Open()
					ModCommonClasses.cmd1 = ModCommonClasses.con1.CreateCommand()
					ModCommonClasses.cmd1.CommandText = "SELECT RTRIM(CustName),RTRIM(Contact),(GiftAmt),RTRIM(Status),(Validfrom),(Validto),RTRIM(InvNo) from GiftInfo where GiftCode=@d1"
					ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.TextBox1.Text).ToString()
					ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
					Dim flag7 As Boolean = ModCommonClasses.rdr1.Read()
					If flag7 Then
						Me.Label2.Text = "Name : " + ModCommonClasses.rdr1.GetValue(0).ToString()
						Me.Label3.Text = "Contact No : " + ModCommonClasses.rdr1.GetValue(1).ToString()
						Me.Label4.Text = "Amount : " + Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
						Me.Label8.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
						Me.Label5.Text = "Status : " + ModCommonClasses.rdr1.GetValue(3).ToString()
						Me.Label6.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Validity : ", ModCommonClasses.rdr1.GetValue(4)), " To "), ModCommonClasses.rdr1.GetValue(5)))
						Me.Label10.Text = "Bill No : " + ModCommonClasses.rdr1.GetValue(6).ToString()
					Else
						Me.Label2.Text = "Name : "
						Me.Label3.Text = "Contact No : "
						Me.Label4.Text = "Amount : "
						Me.Label5.Text = "Status : "
						Me.Label6.Text = "Validity : "
						Me.Label8.Text = ""
						Me.Label10.Text = "Bill No : "
						MessageBox.Show("Gift voucher Not Found !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End If
					Dim flag8 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
					If flag8 Then
						ModCommonClasses.rdr1.Close()
					End If
					Dim flag9 As Boolean = ModCommonClasses.con1.State = ConnectionState.Open
					If flag9 Then
						ModCommonClasses.con1.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06002F98 RID: 12184 RVA: 0x001D4968 File Offset: 0x001D2B68
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select Validfrom, Validto from GiftInfo where GiftCode=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim dateTime As DateTime = Conversions.ToDate(ModCommonClasses.rdr.GetValue(0))
					Dim dateTime2 As DateTime = Conversions.ToDate(ModCommonClasses.rdr.GetValue(1))
					Dim num As Double = CDbl((dateTime2 - dateTime).Days)
					Dim flag3 As Boolean = num <= 0.0
					If flag3 Then
						MessageBox.Show("Gift voucher has already been expired !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox1.Focus()
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
						Return
					End If
					Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag5 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "Select GiftCode from GiftInfo where Status='USED' and GiftCode=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
				If flag6 Then
					MessageBox.Show("Gift voucher has already been Used !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.TextBox1.Focus()
					Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag7 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					Try
						ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
						ModCommonClasses.con1.Open()
						ModCommonClasses.cmd1 = ModCommonClasses.con1.CreateCommand()
						ModCommonClasses.cmd1.CommandText = "SELECT RTRIM(CustName),RTRIM(Contact),(GiftAmt),RTRIM(Status),(Validfrom),(Validto),RTRIM(InvNo) from GiftInfo where GiftCode=@d1"
						ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.TextBox1.Text).ToString()
						ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
						Dim flag8 As Boolean = ModCommonClasses.rdr1.Read()
						If flag8 Then
							Me.Label2.Text = "Name : " + ModCommonClasses.rdr1.GetValue(0).ToString()
							Me.Label3.Text = "Contact No : " + ModCommonClasses.rdr1.GetValue(1).ToString()
							Me.Label4.Text = "Amount : " + Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
							Me.Label8.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
							Me.Label5.Text = "Status : " + ModCommonClasses.rdr1.GetValue(3).ToString()
							Me.Label6.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Validity : ", ModCommonClasses.rdr1.GetValue(4)), " To "), ModCommonClasses.rdr1.GetValue(5)))
							Me.Label10.Text = "Bill No : " + ModCommonClasses.rdr1.GetValue(6).ToString()
						Else
							Me.Label2.Text = "Name : "
							Me.Label3.Text = "Contact No : "
							Me.Label4.Text = "Amount : "
							Me.Label5.Text = "Status : "
							Me.Label6.Text = "Validity : "
							Me.Label8.Text = ""
							Me.Label10.Text = "Bill No : "
							MessageBox.Show("Gift voucher Not Found !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End If
						Dim flag9 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
						If flag9 Then
							ModCommonClasses.rdr1.Close()
						End If
						Dim flag10 As Boolean = ModCommonClasses.con1.State = ConnectionState.Open
						If flag10 Then
							ModCommonClasses.con1.Close()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06002F99 RID: 12185 RVA: 0x001D4EA0 File Offset: 0x001D30A0
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Are you sure to use gift voucher code ?" & vbCrLf & vbCrLf & "Note : If you once confirm, Gift voucher code will be Invalid", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
			If flag Then
				Dim flag2 As Boolean = Conversion.Val(Me.Label8.Text) <= 0.0
				If flag2 Then
					MessageBox.Show("Gift voucher Code has no sufficient balance !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Update GiftInfo set Status=@d1 where GiftCode=@d0"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "USED")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.TextBox1.Text).ToString()
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					Dim flag3 As Boolean = Operators.CompareString(Me.Label9.Text, "POS ENTRY", False) = 0
					If flag3 Then
						MyProject.Forms.frmPOS.txtgiftamt.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
						MyProject.Forms.frmPOS.alldiscountcalc()
					End If
					Dim flag4 As Boolean = Operators.CompareString(Me.Label9.Text, "TOUCH POS ENTRY", False) = 0
					If flag4 Then
						MyProject.Forms.frmPOSTouch.txtgiftamt.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
						MyProject.Forms.frmPOSTouch.alldiscountcalc()
					End If
					Dim flag5 As Boolean = Operators.CompareString(Me.Label9.Text, "TOUCH POS ENTRY New", False) = 0
					If flag5 Then
						MyProject.Forms.frmPOSNewTuch.txtgiftamt.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
						MyProject.Forms.frmPOSNewTuch.alldiscountcalc()
					End If
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06002F9A RID: 12186 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmGiftApply_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub

		' Token: 0x06002F9B RID: 12187 RVA: 0x0001DE7A File Offset: 0x0001C07A
		Private Sub frmGiftApply_FormClosed(sender As Object, e As FormClosedEventArgs)
			Me.Label9.Text = ""
		End Sub

		' Token: 0x06002F9C RID: 12188 RVA: 0x0001DE8E File Offset: 0x0001C08E
		Private Sub frmGiftApply_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x06002F9D RID: 12189 RVA: 0x001D50E4 File Offset: 0x001D32E4
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						GlobalVariables.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not GlobalVariables.translations.ContainsKey(text2)
								If flag Then
									GlobalVariables.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
										End If
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06002F9E RID: 12190 RVA: 0x001D5384 File Offset: 0x001D3584
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
				End If
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.UpdateAllControls(control, translations)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06002F9F RID: 12191 RVA: 0x00087088 File Offset: 0x00085288
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub
	End Class
End Namespace
