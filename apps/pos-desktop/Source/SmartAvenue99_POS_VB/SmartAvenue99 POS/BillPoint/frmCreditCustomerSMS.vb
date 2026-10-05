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
	' Token: 0x020004B7 RID: 1207
	<DesignerGenerated()>
	Public Partial Class frmCreditCustomerSMS
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F1D1 RID: 61905 RVA: 0x00069D4A File Offset: 0x00067F4A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCreditCustomerSMS_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCreditCustomerSMS_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005CA5 RID: 23717
		' (get) Token: 0x0600F1D4 RID: 61908 RVA: 0x00069D7C File Offset: 0x00067F7C
		' (set) Token: 0x0600F1D5 RID: 61909 RVA: 0x00069D86 File Offset: 0x00067F86
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005CA6 RID: 23718
		' (get) Token: 0x0600F1D6 RID: 61910 RVA: 0x00069D8F File Offset: 0x00067F8F
		' (set) Token: 0x0600F1D7 RID: 61911 RVA: 0x00069D99 File Offset: 0x00067F99
		Friend Overridable Property cmbCustomerName As ComboBox

		' Token: 0x17005CA7 RID: 23719
		' (get) Token: 0x0600F1D8 RID: 61912 RVA: 0x00069DA2 File Offset: 0x00067FA2
		' (set) Token: 0x0600F1D9 RID: 61913 RVA: 0x00069DAC File Offset: 0x00067FAC
		Friend Overridable Property Label4 As Label

		' Token: 0x17005CA8 RID: 23720
		' (get) Token: 0x0600F1DA RID: 61914 RVA: 0x00069DB5 File Offset: 0x00067FB5
		' (set) Token: 0x0600F1DB RID: 61915 RVA: 0x00069DBF File Offset: 0x00067FBF
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005CA9 RID: 23721
		' (get) Token: 0x0600F1DC RID: 61916 RVA: 0x00069DC8 File Offset: 0x00067FC8
		' (set) Token: 0x0600F1DD RID: 61917 RVA: 0x00069DD2 File Offset: 0x00067FD2
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005CAA RID: 23722
		' (get) Token: 0x0600F1DE RID: 61918 RVA: 0x00069DDB File Offset: 0x00067FDB
		' (set) Token: 0x0600F1DF RID: 61919 RVA: 0x00069DE5 File Offset: 0x00067FE5
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17005CAB RID: 23723
		' (get) Token: 0x0600F1E0 RID: 61920 RVA: 0x00069DEE File Offset: 0x00067FEE
		' (set) Token: 0x0600F1E1 RID: 61921 RVA: 0x00069DF8 File Offset: 0x00067FF8
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x17005CAC RID: 23724
		' (get) Token: 0x0600F1E2 RID: 61922 RVA: 0x00069E01 File Offset: 0x00068001
		' (set) Token: 0x0600F1E3 RID: 61923 RVA: 0x00069E0B File Offset: 0x0006800B
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17005CAD RID: 23725
		' (get) Token: 0x0600F1E4 RID: 61924 RVA: 0x00069E14 File Offset: 0x00068014
		' (set) Token: 0x0600F1E5 RID: 61925 RVA: 0x00913DBC File Offset: 0x00911FBC
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CAE RID: 23726
		' (get) Token: 0x0600F1E6 RID: 61926 RVA: 0x00069E1E File Offset: 0x0006801E
		' (set) Token: 0x0600F1E7 RID: 61927 RVA: 0x00069E28 File Offset: 0x00068028
		Friend Overridable Property Label5 As Label

		' Token: 0x17005CAF RID: 23727
		' (get) Token: 0x0600F1E8 RID: 61928 RVA: 0x00069E31 File Offset: 0x00068031
		' (set) Token: 0x0600F1E9 RID: 61929 RVA: 0x00069E3B File Offset: 0x0006803B
		Friend Overridable Property ListView1 As ListView

		' Token: 0x17005CB0 RID: 23728
		' (get) Token: 0x0600F1EA RID: 61930 RVA: 0x00069E44 File Offset: 0x00068044
		' (set) Token: 0x0600F1EB RID: 61931 RVA: 0x00069E4E File Offset: 0x0006804E
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17005CB1 RID: 23729
		' (get) Token: 0x0600F1EC RID: 61932 RVA: 0x00069E57 File Offset: 0x00068057
		' (set) Token: 0x0600F1ED RID: 61933 RVA: 0x00069E61 File Offset: 0x00068061
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17005CB2 RID: 23730
		' (get) Token: 0x0600F1EE RID: 61934 RVA: 0x00069E6A File Offset: 0x0006806A
		' (set) Token: 0x0600F1EF RID: 61935 RVA: 0x00069E74 File Offset: 0x00068074
		Friend Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17005CB3 RID: 23731
		' (get) Token: 0x0600F1F0 RID: 61936 RVA: 0x00069E7D File Offset: 0x0006807D
		' (set) Token: 0x0600F1F1 RID: 61937 RVA: 0x00913E00 File Offset: 0x00912000
		Private _Timer2 As Timer
		Friend Overridable Property Timer2 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer2_Tick
				Dim timer As Timer = Me._Timer2
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer2 = value
				timer = Me._Timer2
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CB4 RID: 23732
		' (get) Token: 0x0600F1F2 RID: 61938 RVA: 0x00069E87 File Offset: 0x00068087
		' (set) Token: 0x0600F1F3 RID: 61939 RVA: 0x00069E91 File Offset: 0x00068091
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17005CB5 RID: 23733
		' (get) Token: 0x0600F1F4 RID: 61940 RVA: 0x00069E9A File Offset: 0x0006809A
		' (set) Token: 0x0600F1F5 RID: 61941 RVA: 0x00069EA4 File Offset: 0x000680A4
		Friend Overridable Property Label1 As Label

		' Token: 0x17005CB6 RID: 23734
		' (get) Token: 0x0600F1F6 RID: 61942 RVA: 0x00069EAD File Offset: 0x000680AD
		' (set) Token: 0x0600F1F7 RID: 61943 RVA: 0x00913E44 File Offset: 0x00912044
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

		' Token: 0x17005CB7 RID: 23735
		' (get) Token: 0x0600F1F8 RID: 61944 RVA: 0x00069EB7 File Offset: 0x000680B7
		' (set) Token: 0x0600F1F9 RID: 61945 RVA: 0x00913E88 File Offset: 0x00912088
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

		' Token: 0x17005CB8 RID: 23736
		' (get) Token: 0x0600F1FA RID: 61946 RVA: 0x00069EC1 File Offset: 0x000680C1
		' (set) Token: 0x0600F1FB RID: 61947 RVA: 0x00913ECC File Offset: 0x009120CC
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

		' Token: 0x0600F1FC RID: 61948 RVA: 0x00069ECB File Offset: 0x000680CB
		Private Sub frmCreditCustomerSMS_Load(sender As Object, e As EventArgs)
			Me.FillCustomer()
			Me.GetCompanyState()
			Me.chkSelectAll.Checked = True
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F1FD RID: 61949 RVA: 0x00913F10 File Offset: 0x00912110
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

		' Token: 0x0600F1FE RID: 61950 RVA: 0x00914088 File Offset: 0x00912288
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

		' Token: 0x0600F1FF RID: 61951 RVA: 0x00914144 File Offset: 0x00912344
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

		' Token: 0x0600F200 RID: 61952 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F201 RID: 61953 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F202 RID: 61954 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F203 RID: 61955 RVA: 0x00914210 File Offset: 0x00912410
		Public Sub FillCustomer()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT CustomerID, RTRIM(Name) AS Name FROM Customer ORDER BY Name", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.con.Close()
				Me.cmbCustomerName.DisplayMember = "Name"
				Me.cmbCustomerName.ValueMember = "CustomerID"
				Me.cmbCustomerName.DataSource = ModCommonClasses.ds.Tables(0)
				Me.cmbCustomerName.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F204 RID: 61956 RVA: 0x00914304 File Offset: 0x00912504
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.ListView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.ListView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.ListView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.ListView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x0600F205 RID: 61957 RVA: 0x00069EF0 File Offset: 0x000680F0
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer2.Enabled = False
		End Sub

		' Token: 0x0600F206 RID: 61958 RVA: 0x009143F0 File Offset: 0x009125F0
		Private Sub Reset()
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.ListView1.Items.Clear()
			Me.cmbCustomerName.SelectedIndex = -1
			Me.TextBox2.Text = "Please pay as soon as possible."
			Me.dtpDateFrom.Focus()
		End Sub

		' Token: 0x0600F207 RID: 61959 RVA: 0x0091445C File Offset: 0x0091265C
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F208 RID: 61960 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCreditCustomerSMS_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F209 RID: 61961 RVA: 0x0091454C File Offset: 0x0091274C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo, Customer.State, Customer.GSTIN, count(1) as cnt, (Sum(CustomerLedgerBook.Debit)-Sum(CustomerLedgerBook.Credit)) FROM CustomerLedgerBook INNER JOIN Customer ON CustomerLedgerBook.PartyID = Customer.CustomerID where CustomerLedgerBook.Date between @d1 and @d2 AND CustomerLedgerBook.PartyID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "CustomerLedgerBook.PartyID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN having (Sum(CustomerLedgerBook.Credit)-Sum(CustomerLedgerBook.Debit))<0 ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(Math.Abs(5)).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F20A RID: 61962 RVA: 0x00914800 File Offset: 0x00912A00
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ListView1.Items.Count = 0
			If flag Then
				MessageBox.Show("Please retrieve customers list", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.ListView1.CheckedItems.Count = 0
				If flag2 Then
					MessageBox.Show("Please select at least one customer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Try
						Dim flag3 As Boolean = Me.ListView1.CheckedItems.Count > 0
						If flag3 Then
							Dim num As Integer = 0
							Dim num2 As Integer = Me.ListView1.CheckedItems.Count - 1
							Dim num3 As Integer = num
							While True
								Dim num4 As Integer = num3
								Dim num5 As Integer = num2
								Dim flag4 As Boolean = num4 > num5
								If flag4 Then
									Exit While
								End If
								Dim flag5 As Boolean = Strings.Len(Me.ListView1.CheckedItems(num3).SubItems(1).Text) >= 10
								If flag5 Then
									Dim flag6 As Boolean = ModFunc.CheckForInternetConnection()
									If flag6 Then
										Me.Cursor = Cursors.WaitCursor
										Me.Timer2.Enabled = True
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text As String = "Select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
										ModCommonClasses.cmd = New SqlCommand(text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
										If flag7 Then
											Dim text2 As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
											Dim text3 As String = ""
											Dim flag8 As Boolean = Operators.CompareString(Me.ListView1.CheckedItems(num3).SubItems(0).Text.ToUpper(), "Cash", False) <> 0
											If flag8 Then
												text3 = String.Concat(New String() { "Dear Sir/Madam ", Me.ListView1.CheckedItems(num3).SubItems(0).Text.ToUpper(), ", Your pending amount is Rs. ", Me.ListView1.CheckedItems(num3).SubItems(5).Text, ", ", Me.TextBox2.Text.Trim(), " , Best wishes from : ", Me.TextBox1.Text.Trim(), " " })
											End If
											ModFunc.SMSFunc(Me.ListView1.CheckedItems(num3).SubItems(1).Text, text3, text2)
											ModFunc.SMS(text3)
											num += 1
										End If
										Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag9 Then
											ModCommonClasses.rdr.Close()
										End If
									End If
								End If
								num3 += 1
							End While
							Dim flag10 As Boolean = num > 0
							If flag10 Then
								MessageBox.Show("Successfully SMS Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Else
								MessageBox.Show("Unsuccessfully SMS Sending", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End If
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600F20B RID: 61963 RVA: 0x00069F0C File Offset: 0x0006810C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x04005C6F RID: 23663
		Private st1 As String

		' Token: 0x04005C70 RID: 23664
		Private st2 As String

		' Token: 0x04005C71 RID: 23665
		Private st3 As String
	End Class
End Namespace
