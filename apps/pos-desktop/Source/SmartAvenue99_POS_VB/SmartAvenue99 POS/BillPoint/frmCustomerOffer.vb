Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevNetWP.Classes
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004BA RID: 1210
	<DesignerGenerated()>
	Public Partial Class frmCustomerOffer
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F2AE RID: 62126 RVA: 0x00919B8C File Offset: 0x00917D8C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerOffer_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerOffer_KeyDown
			Me.cmpnm = ""
			Me.sts = ""
			Me.sts2 = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005CF2 RID: 23794
		' (get) Token: 0x0600F2B1 RID: 62129 RVA: 0x0006A38E File Offset: 0x0006858E
		' (set) Token: 0x0600F2B2 RID: 62130 RVA: 0x0006A398 File Offset: 0x00068598
		Friend Overridable Property Label5 As Label

		' Token: 0x17005CF3 RID: 23795
		' (get) Token: 0x0600F2B3 RID: 62131 RVA: 0x0006A3A1 File Offset: 0x000685A1
		' (set) Token: 0x0600F2B4 RID: 62132 RVA: 0x0006A3AB File Offset: 0x000685AB
		Friend Overridable Property Label4 As Label

		' Token: 0x17005CF4 RID: 23796
		' (get) Token: 0x0600F2B5 RID: 62133 RVA: 0x0006A3B4 File Offset: 0x000685B4
		' (set) Token: 0x0600F2B6 RID: 62134 RVA: 0x0006A3BE File Offset: 0x000685BE
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005CF5 RID: 23797
		' (get) Token: 0x0600F2B7 RID: 62135 RVA: 0x0006A3C7 File Offset: 0x000685C7
		' (set) Token: 0x0600F2B8 RID: 62136 RVA: 0x0006A3D1 File Offset: 0x000685D1
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005CF6 RID: 23798
		' (get) Token: 0x0600F2B9 RID: 62137 RVA: 0x0006A3DA File Offset: 0x000685DA
		' (set) Token: 0x0600F2BA RID: 62138 RVA: 0x0006A3E4 File Offset: 0x000685E4
		Friend Overridable Property cmbCustomerName As ComboBox

		' Token: 0x17005CF7 RID: 23799
		' (get) Token: 0x0600F2BB RID: 62139 RVA: 0x0006A3ED File Offset: 0x000685ED
		' (set) Token: 0x0600F2BC RID: 62140 RVA: 0x0006A3F7 File Offset: 0x000685F7
		Friend Overridable Property ListView1 As ListView

		' Token: 0x17005CF8 RID: 23800
		' (get) Token: 0x0600F2BD RID: 62141 RVA: 0x0006A400 File Offset: 0x00068600
		' (set) Token: 0x0600F2BE RID: 62142 RVA: 0x0006A40A File Offset: 0x0006860A
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17005CF9 RID: 23801
		' (get) Token: 0x0600F2BF RID: 62143 RVA: 0x0006A413 File Offset: 0x00068613
		' (set) Token: 0x0600F2C0 RID: 62144 RVA: 0x0006A41D File Offset: 0x0006861D
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17005CFA RID: 23802
		' (get) Token: 0x0600F2C1 RID: 62145 RVA: 0x0006A426 File Offset: 0x00068626
		' (set) Token: 0x0600F2C2 RID: 62146 RVA: 0x0006A430 File Offset: 0x00068630
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x17005CFB RID: 23803
		' (get) Token: 0x0600F2C3 RID: 62147 RVA: 0x0006A439 File Offset: 0x00068639
		' (set) Token: 0x0600F2C4 RID: 62148 RVA: 0x0006A443 File Offset: 0x00068643
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17005CFC RID: 23804
		' (get) Token: 0x0600F2C5 RID: 62149 RVA: 0x0006A44C File Offset: 0x0006864C
		' (set) Token: 0x0600F2C6 RID: 62150 RVA: 0x0006A456 File Offset: 0x00068656
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17005CFD RID: 23805
		' (get) Token: 0x0600F2C7 RID: 62151 RVA: 0x0006A45F File Offset: 0x0006865F
		' (set) Token: 0x0600F2C8 RID: 62152 RVA: 0x0006A469 File Offset: 0x00068669
		Friend Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17005CFE RID: 23806
		' (get) Token: 0x0600F2C9 RID: 62153 RVA: 0x0006A472 File Offset: 0x00068672
		' (set) Token: 0x0600F2CA RID: 62154 RVA: 0x0091AB10 File Offset: 0x00918D10
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

		' Token: 0x17005CFF RID: 23807
		' (get) Token: 0x0600F2CB RID: 62155 RVA: 0x0006A47C File Offset: 0x0006867C
		' (set) Token: 0x0600F2CC RID: 62156 RVA: 0x0091AB54 File Offset: 0x00918D54
		Private _Button6 As Button
		Friend Overridable Property Button6 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim button As Button = Me._Button6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button6 = value
				button = Me._Button6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D00 RID: 23808
		' (get) Token: 0x0600F2CD RID: 62157 RVA: 0x0006A486 File Offset: 0x00068686
		' (set) Token: 0x0600F2CE RID: 62158 RVA: 0x0091AB98 File Offset: 0x00918D98
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

		' Token: 0x17005D01 RID: 23809
		' (get) Token: 0x0600F2CF RID: 62159 RVA: 0x0006A490 File Offset: 0x00068690
		' (set) Token: 0x0600F2D0 RID: 62160 RVA: 0x0006A49A File Offset: 0x0006869A
		Friend Overridable Property txtMessage As TextBox

		' Token: 0x17005D02 RID: 23810
		' (get) Token: 0x0600F2D1 RID: 62161 RVA: 0x0006A4A3 File Offset: 0x000686A3
		' (set) Token: 0x0600F2D2 RID: 62162 RVA: 0x0006A4AD File Offset: 0x000686AD
		Friend Overridable Property Label1 As Label

		' Token: 0x17005D03 RID: 23811
		' (get) Token: 0x0600F2D3 RID: 62163 RVA: 0x0006A4B6 File Offset: 0x000686B6
		' (set) Token: 0x0600F2D4 RID: 62164 RVA: 0x0006A4C0 File Offset: 0x000686C0
		Friend Overridable Property Label2 As Label

		' Token: 0x17005D04 RID: 23812
		' (get) Token: 0x0600F2D5 RID: 62165 RVA: 0x0006A4C9 File Offset: 0x000686C9
		' (set) Token: 0x0600F2D6 RID: 62166 RVA: 0x0091ABDC File Offset: 0x00918DDC
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D05 RID: 23813
		' (get) Token: 0x0600F2D7 RID: 62167 RVA: 0x0006A4D3 File Offset: 0x000686D3
		' (set) Token: 0x0600F2D8 RID: 62168 RVA: 0x0006A4DD File Offset: 0x000686DD
		Friend Overridable Property ListBox1 As ListBox

		' Token: 0x17005D06 RID: 23814
		' (get) Token: 0x0600F2D9 RID: 62169 RVA: 0x0006A4E6 File Offset: 0x000686E6
		' (set) Token: 0x0600F2DA RID: 62170 RVA: 0x0006A4F0 File Offset: 0x000686F0
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17005D07 RID: 23815
		' (get) Token: 0x0600F2DB RID: 62171 RVA: 0x0006A4F9 File Offset: 0x000686F9
		' (set) Token: 0x0600F2DC RID: 62172 RVA: 0x0091AC20 File Offset: 0x00918E20
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

		' Token: 0x17005D08 RID: 23816
		' (get) Token: 0x0600F2DD RID: 62173 RVA: 0x0006A503 File Offset: 0x00068703
		' (set) Token: 0x0600F2DE RID: 62174 RVA: 0x0091AC64 File Offset: 0x00918E64
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

		' Token: 0x0600F2DF RID: 62175 RVA: 0x0091ACA8 File Offset: 0x00918EA8
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmpnm = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.cmpnm = ""
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

		' Token: 0x0600F2E0 RID: 62176 RVA: 0x0006A50D File Offset: 0x0006870D
		Private Sub frmCustomerOffer_Load(sender As Object, e As EventArgs)
			Me.statusdisplay()
			Me.FillCustomer()
			Me.GetCompanyState()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F2E1 RID: 62177 RVA: 0x0091ADA0 File Offset: 0x00918FA0
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

		' Token: 0x0600F2E2 RID: 62178 RVA: 0x0091AF18 File Offset: 0x00919118
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

		' Token: 0x0600F2E3 RID: 62179 RVA: 0x0091AFD4 File Offset: 0x009191D4
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

		' Token: 0x0600F2E4 RID: 62180 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F2E5 RID: 62181 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F2E6 RID: 62182 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F2E7 RID: 62183 RVA: 0x0091B0A0 File Offset: 0x009192A0
		Public Sub FillCustomer()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID, RTRIM(Name) AS Name FROM Customer ORDER BY Name", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.con.Close()
				Me.cmbCustomerName.DisplayMember = "Name"
				Me.cmbCustomerName.ValueMember = "ID"
				Me.cmbCustomerName.DataSource = ModCommonClasses.ds.Tables(0)
				Me.cmbCustomerName.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F2E8 RID: 62184 RVA: 0x0091B194 File Offset: 0x00919394
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

		' Token: 0x0600F2E9 RID: 62185 RVA: 0x0091B280 File Offset: 0x00919480
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtMessage.Text)) = 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					MessageBox.Show("Please enter message", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtMessage.Focus()
				Else
					flag = Me.ListView1.Items.Count = 0
					Dim flag3 As Boolean = flag
					If flag3 Then
						MessageBox.Show("Please retrieve customers list", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						flag = Me.ListView1.CheckedItems.Count = 0
						Dim flag4 As Boolean = flag
						If flag4 Then
							MessageBox.Show("Please select at least one customer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							flag = ModFunc.CheckForInternetConnection()
							Dim flag5 As Boolean = flag
							If flag5 Then
								Me.Cursor = Cursors.WaitCursor
								Me.Timer2.Enabled = True
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Dim sqlDataReader As SqlDataReader = ModCommonClasses.cmd.ExecuteReader()
								flag = sqlDataReader.Read()
								Dim flag6 As Boolean = flag
								If flag6 Then
									Me.st2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(sqlDataReader.GetValue(0)))
									Me.st1 = ""
									Dim num As Integer = 0
									Dim num2 As Integer = Me.ListView1.Items.Count - 1
									Dim num3 As Integer = num
									While True
										Dim num4 As Integer = num3
										Dim num5 As Integer = num2
										Dim flag7 As Boolean = num4 > num5
										If flag7 Then
											Exit While
										End If
										flag = Me.ListView1.Items(num3).Checked
										Dim flag8 As Boolean = flag
										If flag8 Then
											Me.st1 = Me.st1 + Me.ListView1.Items(num3).SubItems(1).Text + ","
										End If
										num3 += 1
									End While
									Me.st1 = Me.st1.Trim().Remove(Me.st1.Length - 1)
									ModFunc.SMSFunc(Me.st1, Me.txtMessage.Text, Me.st2)
									ModFunc.SMS(Me.txtMessage.Text)
									MessageBox.Show("Successfully SMS Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								End If
							End If
							Me.Reset()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F2EA RID: 62186 RVA: 0x0006A52C File Offset: 0x0006872C
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer2.Enabled = False
		End Sub

		' Token: 0x0600F2EB RID: 62187 RVA: 0x0091B530 File Offset: 0x00919730
		Private Sub Reset()
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.ListView1.Items.Clear()
			Me.cmbCustomerName.SelectedIndex = -1
			Me.txtMessage.Text = ""
		End Sub

		' Token: 0x0600F2EC RID: 62188 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerOffer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F2ED RID: 62189 RVA: 0x0091B590 File Offset: 0x00919790
		Public Sub statusdisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT c1, c2 FROM WappApi"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.sts = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.sts = "91"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F2EE RID: 62190 RVA: 0x0091B684 File Offset: 0x00919884
		Private Async Sub Button3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Internet Connection not found", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Me.ListView1.Items.Count = 0
					If flag3 Then
						MessageBox.Show("Please retrieve customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = Me.ListView1.CheckedItems.Count = 0
						If flag4 Then
							MessageBox.Show("Please select customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Try
								Me.Cursor = Cursors.WaitCursor
								Me.Timer2.Enabled = True
								Try
									For Each obj As Object In Me.ListView1.Items
										Dim item As ListViewItem = CType(obj, ListViewItem)
										Dim checked As Boolean = item.Checked
										If checked Then
											Dim customerName As String = item.SubItems(0).Text
											Dim textsms As String = Me.txtMessage.Text
											Dim phone As String = Me.sts + item.SubItems(1).Text
											Dim attach As String = ""
											Dim message As String = String.Format("Dear {0}, {1}, {2}, _Best wishes from : *{3}*_", New Object() { customerName, textsms, "", Me.cmpnm })
											Dim flag5 As Boolean = phone IsNot Nothing AndAlso (message IsNot Nothing OrElse attach <> Nothing)
											If flag5 Then
												Dim WP As DevNetWP.Classes.clsWhatsapp = New DevNetWP.Classes.clsWhatsapp()
												Dim dct As Dictionary(Of String, Object) = WP.WhatsAppTextSender(phone, message, frmLogin.InstanceID)
												Dim newresult As String = ""
												Dim flag6 As Boolean = Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(dct("success")))
												If flag6 Then
													newresult = dct("result").ToString()
													item.SubItems(6).Text = "Success"
												Else
													newresult = dct("message").ToString()
													MessageBox.Show(newresult)
												End If
											End If
										End If
										Await Task.Delay(10000)
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
							Catch ex As Exception
								MessageBox.Show("Engine is not active")
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600F2EF RID: 62191 RVA: 0x0091B6CC File Offset: 0x009198CC
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo, Customer.State, Customer.GSTIN, count(1) as cnt, Sum(InvoiceInfo.GrandTotal) FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.InvoiceDate between @d1 and @d2 AND InvoiceInfo.Customer_ID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "InvoiceInfo.Customer_ID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN order by Sum(InvoiceInfo.GrandTotal) desc ;")))
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
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add("")
					Me.ListView1.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F2F0 RID: 62192 RVA: 0x0006A548 File Offset: 0x00068748
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x04005CC8 RID: 23752
		Private cmpnm As String

		' Token: 0x04005CC9 RID: 23753
		Private st1 As String

		' Token: 0x04005CCA RID: 23754
		Private st2 As String

		' Token: 0x04005CCB RID: 23755
		Private st3 As String

		' Token: 0x04005CCC RID: 23756
		Private sts As String

		' Token: 0x04005CCD RID: 23757
		Private sts2 As String
	End Class
End Namespace
