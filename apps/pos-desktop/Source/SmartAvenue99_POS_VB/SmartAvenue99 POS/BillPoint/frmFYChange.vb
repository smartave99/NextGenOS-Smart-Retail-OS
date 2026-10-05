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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C6 RID: 1222
	<DesignerGenerated()>
	Public Partial Class frmFYChange
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F5BD RID: 62909 RVA: 0x0006B9E6 File Offset: 0x00069BE6
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmFYChange_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmFYChange_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005E03 RID: 24067
		' (get) Token: 0x0600F5C0 RID: 62912 RVA: 0x0006BA18 File Offset: 0x00069C18
		' (set) Token: 0x0600F5C1 RID: 62913 RVA: 0x0006BA22 File Offset: 0x00069C22
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005E04 RID: 24068
		' (get) Token: 0x0600F5C2 RID: 62914 RVA: 0x0006BA2B File Offset: 0x00069C2B
		' (set) Token: 0x0600F5C3 RID: 62915 RVA: 0x0006BA35 File Offset: 0x00069C35
		Friend Overridable Property Label1 As Label

		' Token: 0x17005E05 RID: 24069
		' (get) Token: 0x0600F5C4 RID: 62916 RVA: 0x0006BA3E File Offset: 0x00069C3E
		' (set) Token: 0x0600F5C5 RID: 62917 RVA: 0x0006BA48 File Offset: 0x00069C48
		Friend Overridable Property Label3 As Label

		' Token: 0x17005E06 RID: 24070
		' (get) Token: 0x0600F5C6 RID: 62918 RVA: 0x0006BA51 File Offset: 0x00069C51
		' (set) Token: 0x0600F5C7 RID: 62919 RVA: 0x0006BA5B File Offset: 0x00069C5B
		Friend Overridable Property Label2 As Label

		' Token: 0x17005E07 RID: 24071
		' (get) Token: 0x0600F5C8 RID: 62920 RVA: 0x0006BA64 File Offset: 0x00069C64
		' (set) Token: 0x0600F5C9 RID: 62921 RVA: 0x009354AC File Offset: 0x009336AC
		Private _DTP2 As DateTimePicker
		Friend Overridable Property DTP2 As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._DTP2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DTP2_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._DTP2
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._DTP2 = value
				dateTimePicker = Me._DTP2
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E08 RID: 24072
		' (get) Token: 0x0600F5CA RID: 62922 RVA: 0x0006BA6E File Offset: 0x00069C6E
		' (set) Token: 0x0600F5CB RID: 62923 RVA: 0x009354F0 File Offset: 0x009336F0
		Private _DTP1 As DateTimePicker
		Friend Overridable Property DTP1 As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._DTP1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DTP1_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._DTP1
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._DTP1 = value
				dateTimePicker = Me._DTP1
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E09 RID: 24073
		' (get) Token: 0x0600F5CC RID: 62924 RVA: 0x0006BA78 File Offset: 0x00069C78
		' (set) Token: 0x0600F5CD RID: 62925 RVA: 0x0006BA82 File Offset: 0x00069C82
		Friend Overridable Property lblUser As Label

		' Token: 0x17005E0A RID: 24074
		' (get) Token: 0x0600F5CE RID: 62926 RVA: 0x0006BA8B File Offset: 0x00069C8B
		' (set) Token: 0x0600F5CF RID: 62927 RVA: 0x0006BA95 File Offset: 0x00069C95
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005E0B RID: 24075
		' (get) Token: 0x0600F5D0 RID: 62928 RVA: 0x0006BA9E File Offset: 0x00069C9E
		' (set) Token: 0x0600F5D1 RID: 62929 RVA: 0x0006BAA8 File Offset: 0x00069CA8
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x17005E0C RID: 24076
		' (get) Token: 0x0600F5D2 RID: 62930 RVA: 0x0006BAB1 File Offset: 0x00069CB1
		' (set) Token: 0x0600F5D3 RID: 62931 RVA: 0x00935534 File Offset: 0x00933734
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

		' Token: 0x17005E0D RID: 24077
		' (get) Token: 0x0600F5D4 RID: 62932 RVA: 0x0006BABB File Offset: 0x00069CBB
		' (set) Token: 0x0600F5D5 RID: 62933 RVA: 0x00935578 File Offset: 0x00933778
		Private _TextBox6 As TextBox
		Friend Overridable Property TextBox6 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox6_KeyPress
				Dim textBox As TextBox = Me._TextBox6
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox6 = value
				textBox = Me._TextBox6
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E0E RID: 24078
		' (get) Token: 0x0600F5D6 RID: 62934 RVA: 0x0006BAC5 File Offset: 0x00069CC5
		' (set) Token: 0x0600F5D7 RID: 62935 RVA: 0x0006BACF File Offset: 0x00069CCF
		Friend Overridable Property Label4 As Label

		' Token: 0x17005E0F RID: 24079
		' (get) Token: 0x0600F5D8 RID: 62936 RVA: 0x0006BAD8 File Offset: 0x00069CD8
		' (set) Token: 0x0600F5D9 RID: 62937 RVA: 0x009355BC File Offset: 0x009337BC
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

		' Token: 0x17005E10 RID: 24080
		' (get) Token: 0x0600F5DA RID: 62938 RVA: 0x0006BAE2 File Offset: 0x00069CE2
		' (set) Token: 0x0600F5DB RID: 62939 RVA: 0x00935600 File Offset: 0x00933800
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600F5DC RID: 62940 RVA: 0x00935644 File Offset: 0x00933844
		Private Sub FYSerrch()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F5DD RID: 62941 RVA: 0x00935758 File Offset: 0x00933958
		Private Sub frmFYChange_Load(sender As Object, e As EventArgs)
			Me.FYSerrch()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select count(*) from SaleGST Having count(*) >= 1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Me.TextBox6.[ReadOnly] = True
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			ModCommonClasses.con.Close()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text2 As String = "select count(*) from SaleNoTax Having count(*) >= 1"
			ModCommonClasses.cmd = New SqlCommand(text2)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
			If flag3 Then
				Me.TextBox6.[ReadOnly] = True
				Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag4 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox6.Text = ModFunc.ReadConfiguration()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F5DE RID: 62942 RVA: 0x009358A0 File Offset: 0x00933AA0
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
						Me.UpdateAllHeaders(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600F5DF RID: 62943 RVA: 0x00935A18 File Offset: 0x00933C18
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

		' Token: 0x0600F5E0 RID: 62944 RVA: 0x00935AD4 File Offset: 0x00933CD4
		Private Sub UpdateAllHeaders(container As Control)
			Try
				For Each obj As Object In container.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						Else
							Dim flag3 As Boolean = TypeOf control Is TabControl
							If flag3 Then
								Me.UpdateTabControlHeaders(CType(control, TabControl))
							End If
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateAllHeaders(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F5E1 RID: 62945 RVA: 0x00086F78 File Offset: 0x00085178
		Private Sub UpdateListViewHeaders(listView As ListView)
			Try
				For Each obj As Object In listView.Columns
					Dim columnHeader As ColumnHeader = CType(obj, ColumnHeader)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(columnHeader.Text)
					If flag Then
						columnHeader.Text = GlobalVariables.translations(columnHeader.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F5E2 RID: 62946 RVA: 0x00087000 File Offset: 0x00085200
		Private Sub UpdateTabControlHeaders(tabControl As TabControl)
			Try
				For Each obj As Object In tabControl.TabPages
					Dim tabPage As TabPage = CType(obj, TabPage)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(tabPage.Text)
					If flag Then
						tabPage.Text = GlobalVariables.translations(tabPage.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F5E3 RID: 62947 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F5E4 RID: 62948 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub DTP1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F5E5 RID: 62949 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub DTP2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F5E6 RID: 62950 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmFYChange_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F5E7 RID: 62951 RVA: 0x00935BA0 File Offset: 0x00933DA0
		Public Sub ResetNumbering()
			Try
				Dim flag As Boolean = MessageBox.Show("Do you want to reset voucher numbering ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "DELETE FROM SaleGST"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SaleNotax"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM PurcGST"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM PurcNoTax"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrEstimate"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrSaleReturn"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrQuotation"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrPurReturn"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrPurOrder"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrReceipt"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrPayment"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrIncome"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrExpenses"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrService"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					text = "DELETE FROM SrSerBill"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.ExecuteNonQuery()
					MyBase.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F5E8 RID: 62952 RVA: 0x00935E20 File Offset: 0x00934020
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim [readOnly] As Boolean = Me.TextBox6.[ReadOnly]
			If [readOnly] Then
				MessageBox.Show("You are not allowed. Sales Record found", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag As Boolean = Operators.CompareString(Me.TextBox6.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please fill Starting Invoice Number", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.TextBox6.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.TextBox6.Text, "0", False) = 0
					If flag2 Then
						MessageBox.Show("Zero value is not allowed to fill Starting Invoice Number", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox6.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "DELETE FROM SaleGST"
							ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
							ModCommonClasses.cmd.ExecuteNonQuery()
							text = "DELETE FROM SaleNotax"
							ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							Dim flag3 As Boolean = ModFunc.SaveConfiguration(Me.TextBox6.Text)
							If flag3 Then
							End If
							Me.TextBox6.Text = ModFunc.ReadConfiguration()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "insert into SaleNoTax(ID, InvNo) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.TextBox6.Text) - 1.0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", "Opening Serial No")
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into SaleGST(ID, InvNo) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.TextBox6.Text) - 1.0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", "Opening Serial No")
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600F5E9 RID: 62953 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600F5EA RID: 62954 RVA: 0x0006BAEC File Offset: 0x00069CEC
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.FYSerrch()
		End Sub

		' Token: 0x0600F5EB RID: 62955 RVA: 0x00936108 File Offset: 0x00934308
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Me.ProgressBar1.Visible = True
				Me.ProgressBar1.Value = Me.ProgressBar1.Value + 2
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				Dim text As String = "Update company set FYFrom=@d1, FYTo=@d2 where ID=@d3"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.DTP1.Value.[Date])
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.DTP2.Value.[Date])
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				Me.ProgressBar1.Value = 10
				Me.ProgressBar1.Value = 20
				Me.ProgressBar1.Value = 40
				Dim text2 As String = String.Concat(New String() { "Financial Year has been Saved from '", Me.DTP1.Text, "' to '", Me.DTP2.Text, "'" })
				ModFunc.LogFunc(Me.lblUser.Text, text2)
				Me.ProgressBar1.Value = 60
				Me.ProgressBar1.Value = 80
				Me.ProgressBar1.Value = 100
				Me.ResetNumbering()
				Dim flag As Boolean = ModFunc.SaveConfiguration("")
				If flag Then
				End If
				Me.TextBox6.Text = ModFunc.ReadConfiguration()
				MessageBox.Show("Successfully Saved", "Financial Year", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.FYSerrch()
				Me.ProgressBar1.Value = 0
				MyBase.Close()
			Catch ex As Exception
			End Try
		End Sub
	End Class
End Namespace
