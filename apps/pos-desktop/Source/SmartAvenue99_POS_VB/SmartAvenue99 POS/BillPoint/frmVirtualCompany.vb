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
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004E9 RID: 1257
	<DesignerGenerated()>
	Public Partial Class frmVirtualCompany
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010268 RID: 66152 RVA: 0x000717BC File Offset: 0x0006F9BC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmVirtualCompany_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmVirtualCompany_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170062D9 RID: 25305
		' (get) Token: 0x0601026B RID: 66155 RVA: 0x000717EE File Offset: 0x0006F9EE
		' (set) Token: 0x0601026C RID: 66156 RVA: 0x000717F8 File Offset: 0x0006F9F8
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170062DA RID: 25306
		' (get) Token: 0x0601026D RID: 66157 RVA: 0x00071801 File Offset: 0x0006FA01
		' (set) Token: 0x0601026E RID: 66158 RVA: 0x0007180B File Offset: 0x0006FA0B
		Friend Overridable Property Label1 As Label

		' Token: 0x170062DB RID: 25307
		' (get) Token: 0x0601026F RID: 66159 RVA: 0x00071814 File Offset: 0x0006FA14
		' (set) Token: 0x06010270 RID: 66160 RVA: 0x0007181E File Offset: 0x0006FA1E
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170062DC RID: 25308
		' (get) Token: 0x06010271 RID: 66161 RVA: 0x00071827 File Offset: 0x0006FA27
		' (set) Token: 0x06010272 RID: 66162 RVA: 0x009A0BA8 File Offset: 0x0099EDA8
		Private _cmbState As ComboBox
		Friend Overridable Property cmbState As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbState
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbState_KeyDown
				Dim comboBox As ComboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbState = value
				comboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062DD RID: 25309
		' (get) Token: 0x06010273 RID: 66163 RVA: 0x00071831 File Offset: 0x0006FA31
		' (set) Token: 0x06010274 RID: 66164 RVA: 0x009A0BEC File Offset: 0x0099EDEC
		Private _txtAddress As TextBox
		Friend Overridable Property txtAddress As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAddress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAddress_KeyDown
				Dim textBox As TextBox = Me._txtAddress
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtAddress = value
				textBox = Me._txtAddress
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062DE RID: 25310
		' (get) Token: 0x06010275 RID: 66165 RVA: 0x0007183B File Offset: 0x0006FA3B
		' (set) Token: 0x06010276 RID: 66166 RVA: 0x009A0C30 File Offset: 0x0099EE30
		Private _txtCIN As TextBox
		Friend Overridable Property txtCIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCIN_KeyDown
				Dim textBox As TextBox = Me._txtCIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCIN = value
				textBox = Me._txtCIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062DF RID: 25311
		' (get) Token: 0x06010277 RID: 66167 RVA: 0x00071845 File Offset: 0x0006FA45
		' (set) Token: 0x06010278 RID: 66168 RVA: 0x0007184F File Offset: 0x0006FA4F
		Friend Overridable Property Label8 As Label

		' Token: 0x170062E0 RID: 25312
		' (get) Token: 0x06010279 RID: 66169 RVA: 0x00071858 File Offset: 0x0006FA58
		' (set) Token: 0x0601027A RID: 66170 RVA: 0x009A0C74 File Offset: 0x0099EE74
		Private _txtGSTIN As TextBox
		Friend Overridable Property txtGSTIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtGSTIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtGSTIN_KeyDown
				Dim textBox As TextBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtGSTIN = value
				textBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062E1 RID: 25313
		' (get) Token: 0x0601027B RID: 66171 RVA: 0x00071862 File Offset: 0x0006FA62
		' (set) Token: 0x0601027C RID: 66172 RVA: 0x0007186C File Offset: 0x0006FA6C
		Friend Overridable Property Label7 As Label

		' Token: 0x170062E2 RID: 25314
		' (get) Token: 0x0601027D RID: 66173 RVA: 0x00071875 File Offset: 0x0006FA75
		' (set) Token: 0x0601027E RID: 66174 RVA: 0x0007187F File Offset: 0x0006FA7F
		Friend Overridable Property Label6 As Label

		' Token: 0x170062E3 RID: 25315
		' (get) Token: 0x0601027F RID: 66175 RVA: 0x00071888 File Offset: 0x0006FA88
		' (set) Token: 0x06010280 RID: 66176 RVA: 0x00071892 File Offset: 0x0006FA92
		Friend Overridable Property Label5 As Label

		' Token: 0x170062E4 RID: 25316
		' (get) Token: 0x06010281 RID: 66177 RVA: 0x0007189B File Offset: 0x0006FA9B
		' (set) Token: 0x06010282 RID: 66178 RVA: 0x009A0CB8 File Offset: 0x0099EEB8
		Private _txtEmailID As TextBox
		Friend Overridable Property txtEmailID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmailID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtEmailID_KeyDown
				Dim textBox As TextBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtEmailID = value
				textBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062E5 RID: 25317
		' (get) Token: 0x06010283 RID: 66179 RVA: 0x000718A5 File Offset: 0x0006FAA5
		' (set) Token: 0x06010284 RID: 66180 RVA: 0x009A0CFC File Offset: 0x0099EEFC
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062E6 RID: 25318
		' (get) Token: 0x06010285 RID: 66181 RVA: 0x000718AF File Offset: 0x0006FAAF
		' (set) Token: 0x06010286 RID: 66182 RVA: 0x000718B9 File Offset: 0x0006FAB9
		Friend Overridable Property Label4 As Label

		' Token: 0x170062E7 RID: 25319
		' (get) Token: 0x06010287 RID: 66183 RVA: 0x000718C2 File Offset: 0x0006FAC2
		' (set) Token: 0x06010288 RID: 66184 RVA: 0x000718CC File Offset: 0x0006FACC
		Friend Overridable Property Label2 As Label

		' Token: 0x170062E8 RID: 25320
		' (get) Token: 0x06010289 RID: 66185 RVA: 0x000718D5 File Offset: 0x0006FAD5
		' (set) Token: 0x0601028A RID: 66186 RVA: 0x000718DF File Offset: 0x0006FADF
		Friend Overridable Property Label3 As Label

		' Token: 0x170062E9 RID: 25321
		' (get) Token: 0x0601028B RID: 66187 RVA: 0x000718E8 File Offset: 0x0006FAE8
		' (set) Token: 0x0601028C RID: 66188 RVA: 0x009A0D40 File Offset: 0x0099EF40
		Private _txtCompanyName As TextBox
		Friend Overridable Property txtCompanyName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCompanyName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCompanyName_KeyDown
				Dim textBox As TextBox = Me._txtCompanyName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCompanyName = value
				textBox = Me._txtCompanyName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062EA RID: 25322
		' (get) Token: 0x0601028D RID: 66189 RVA: 0x000718F2 File Offset: 0x0006FAF2
		' (set) Token: 0x0601028E RID: 66190 RVA: 0x000718FC File Offset: 0x0006FAFC
		Friend Overridable Property Label9 As Label

		' Token: 0x170062EB RID: 25323
		' (get) Token: 0x0601028F RID: 66191 RVA: 0x00071905 File Offset: 0x0006FB05
		' (set) Token: 0x06010290 RID: 66192 RVA: 0x009A0D84 File Offset: 0x0099EF84
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox1_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170062EC RID: 25324
		' (get) Token: 0x06010291 RID: 66193 RVA: 0x0007190F File Offset: 0x0006FB0F
		' (set) Token: 0x06010292 RID: 66194 RVA: 0x00071919 File Offset: 0x0006FB19
		Friend Overridable Property txtID As TextBox

		' Token: 0x170062ED RID: 25325
		' (get) Token: 0x06010293 RID: 66195 RVA: 0x00071922 File Offset: 0x0006FB22
		' (set) Token: 0x06010294 RID: 66196 RVA: 0x009A0DC8 File Offset: 0x0099EFC8
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

		' Token: 0x170062EE RID: 25326
		' (get) Token: 0x06010295 RID: 66197 RVA: 0x0007192C File Offset: 0x0006FB2C
		' (set) Token: 0x06010296 RID: 66198 RVA: 0x009A0E0C File Offset: 0x0099F00C
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

		' Token: 0x06010297 RID: 66199 RVA: 0x009A0E50 File Offset: 0x0099F050
		Private Sub clear()
			Me.txtCompanyName.Text = ""
			Me.txtAddress.Text = ""
			Me.cmbState.SelectedIndex = -1
			Me.txtContactNo.Text = ""
			Me.txtEmailID.Text = ""
			Me.txtGSTIN.Text = ""
			Me.txtCIN.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.txtCompanyName.Focus()
		End Sub

		' Token: 0x06010298 RID: 66200 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCompanyName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010299 RID: 66201 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601029A RID: 66202 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601029B RID: 66203 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601029C RID: 66204 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmailID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601029D RID: 66205 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtGSTIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601029E RID: 66206 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601029F RID: 66207 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060102A0 RID: 66208 RVA: 0x009A0EEC File Offset: 0x0099F0EC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(c1), RTRIM(c2),RTRIM(c3), RTRIM(c4), RTRIM(c5), RTRIM(c6), RTRIM(c7),RTRIM(c8) from VCompany", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtID.Text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
					Me.txtCompanyName.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.cmbState.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtEmailID.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtCIN.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.ComboBox1.Text = ModCommonClasses.rdr.GetValue(8).ToString()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060102A1 RID: 66209 RVA: 0x00071936 File Offset: 0x0006FB36
		Private Sub frmVirtualCompany_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x060102A2 RID: 66210 RVA: 0x009A10A0 File Offset: 0x0099F2A0
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

		' Token: 0x060102A3 RID: 66211 RVA: 0x009A1218 File Offset: 0x0099F418
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

		' Token: 0x060102A4 RID: 66212 RVA: 0x009A12D4 File Offset: 0x0099F4D4
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

		' Token: 0x060102A5 RID: 66213 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060102A6 RID: 66214 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060102A7 RID: 66215 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060102A8 RID: 66216 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmVirtualCompany_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060102A9 RID: 66217 RVA: 0x00071947 File Offset: 0x0006FB47
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.clear()
		End Sub

		' Token: 0x060102AA RID: 66218 RVA: 0x009A13A0 File Offset: 0x0099F5A0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
				If flag Then
					MessageBox.Show("Please fill Activate status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Update VCompany set c1=@d1,c2=@d2,c3=@d3,c4=@d4,c5=@d5,c6=@d6,c7=@d7,c8=@d8 where ID=@d0"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompanyName.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAddress.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbState.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtContactNo.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtEmailID.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtGSTIN.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtCIN.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox1.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.txtID.Text.Trim())
					ModCommonClasses.cmd.ExecuteReader()
					MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
