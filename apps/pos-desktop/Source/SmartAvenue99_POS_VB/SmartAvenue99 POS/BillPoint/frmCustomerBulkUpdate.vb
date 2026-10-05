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
	' Token: 0x020004B8 RID: 1208
	<DesignerGenerated()>
	Public Partial Class frmCustomerBulkUpdate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F20C RID: 61964 RVA: 0x00069F16 File Offset: 0x00068116
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerBulkUpdate_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerBulkUpdate_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005CB9 RID: 23737
		' (get) Token: 0x0600F20F RID: 61967 RVA: 0x00069F48 File Offset: 0x00068148
		' (set) Token: 0x0600F210 RID: 61968 RVA: 0x00069F52 File Offset: 0x00068152
		Friend Overridable Property Label2 As Label

		' Token: 0x17005CBA RID: 23738
		' (get) Token: 0x0600F211 RID: 61969 RVA: 0x00069F5B File Offset: 0x0006815B
		' (set) Token: 0x0600F212 RID: 61970 RVA: 0x00069F65 File Offset: 0x00068165
		Friend Overridable Property Label1 As Label

		' Token: 0x17005CBB RID: 23739
		' (get) Token: 0x0600F213 RID: 61971 RVA: 0x00069F6E File Offset: 0x0006816E
		' (set) Token: 0x0600F214 RID: 61972 RVA: 0x00915D24 File Offset: 0x00913F24
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

		' Token: 0x17005CBC RID: 23740
		' (get) Token: 0x0600F215 RID: 61973 RVA: 0x00069F78 File Offset: 0x00068178
		' (set) Token: 0x0600F216 RID: 61974 RVA: 0x00915D68 File Offset: 0x00913F68
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

		' Token: 0x17005CBD RID: 23741
		' (get) Token: 0x0600F217 RID: 61975 RVA: 0x00069F82 File Offset: 0x00068182
		' (set) Token: 0x0600F218 RID: 61976 RVA: 0x00915DAC File Offset: 0x00913FAC
		Private _TextBox42 As TextBox
		Friend Overridable Property TextBox42 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox42
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox42_LostFocus
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox42_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox42_KeyDown
				Dim textBox As TextBox = Me._TextBox42
				If textBox IsNot Nothing Then
					RemoveHandler textBox.LostFocus, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox42 = value
				textBox = Me._TextBox42
				If textBox IsNot Nothing Then
					AddHandler textBox.LostFocus, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CBE RID: 23742
		' (get) Token: 0x0600F219 RID: 61977 RVA: 0x00069F8C File Offset: 0x0006818C
		' (set) Token: 0x0600F21A RID: 61978 RVA: 0x00069F96 File Offset: 0x00068196
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x17005CBF RID: 23743
		' (get) Token: 0x0600F21B RID: 61979 RVA: 0x00069F9F File Offset: 0x0006819F
		' (set) Token: 0x0600F21C RID: 61980 RVA: 0x00069FA9 File Offset: 0x000681A9
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x17005CC0 RID: 23744
		' (get) Token: 0x0600F21D RID: 61981 RVA: 0x00069FB2 File Offset: 0x000681B2
		' (set) Token: 0x0600F21E RID: 61982 RVA: 0x00069FBC File Offset: 0x000681BC
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x17005CC1 RID: 23745
		' (get) Token: 0x0600F21F RID: 61983 RVA: 0x00069FC5 File Offset: 0x000681C5
		' (set) Token: 0x0600F220 RID: 61984 RVA: 0x00069FCF File Offset: 0x000681CF
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x17005CC2 RID: 23746
		' (get) Token: 0x0600F221 RID: 61985 RVA: 0x00069FD8 File Offset: 0x000681D8
		' (set) Token: 0x0600F222 RID: 61986 RVA: 0x00069FE2 File Offset: 0x000681E2
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x17005CC3 RID: 23747
		' (get) Token: 0x0600F223 RID: 61987 RVA: 0x00069FEB File Offset: 0x000681EB
		' (set) Token: 0x0600F224 RID: 61988 RVA: 0x00069FF5 File Offset: 0x000681F5
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x17005CC4 RID: 23748
		' (get) Token: 0x0600F225 RID: 61989 RVA: 0x00069FFE File Offset: 0x000681FE
		' (set) Token: 0x0600F226 RID: 61990 RVA: 0x0006A008 File Offset: 0x00068208
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x17005CC5 RID: 23749
		' (get) Token: 0x0600F227 RID: 61991 RVA: 0x0006A011 File Offset: 0x00068211
		' (set) Token: 0x0600F228 RID: 61992 RVA: 0x0006A01B File Offset: 0x0006821B
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17005CC6 RID: 23750
		' (get) Token: 0x0600F229 RID: 61993 RVA: 0x0006A024 File Offset: 0x00068224
		' (set) Token: 0x0600F22A RID: 61994 RVA: 0x0006A02E File Offset: 0x0006822E
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17005CC7 RID: 23751
		' (get) Token: 0x0600F22B RID: 61995 RVA: 0x0006A037 File Offset: 0x00068237
		' (set) Token: 0x0600F22C RID: 61996 RVA: 0x0006A041 File Offset: 0x00068241
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17005CC8 RID: 23752
		' (get) Token: 0x0600F22D RID: 61997 RVA: 0x0006A04A File Offset: 0x0006824A
		' (set) Token: 0x0600F22E RID: 61998 RVA: 0x0006A054 File Offset: 0x00068254
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17005CC9 RID: 23753
		' (get) Token: 0x0600F22F RID: 61999 RVA: 0x0006A05D File Offset: 0x0006825D
		' (set) Token: 0x0600F230 RID: 62000 RVA: 0x0006A067 File Offset: 0x00068267
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17005CCA RID: 23754
		' (get) Token: 0x0600F231 RID: 62001 RVA: 0x0006A070 File Offset: 0x00068270
		' (set) Token: 0x0600F232 RID: 62002 RVA: 0x0006A07A File Offset: 0x0006827A
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17005CCB RID: 23755
		' (get) Token: 0x0600F233 RID: 62003 RVA: 0x0006A083 File Offset: 0x00068283
		' (set) Token: 0x0600F234 RID: 62004 RVA: 0x0006A08D File Offset: 0x0006828D
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17005CCC RID: 23756
		' (get) Token: 0x0600F235 RID: 62005 RVA: 0x0006A096 File Offset: 0x00068296
		' (set) Token: 0x0600F236 RID: 62006 RVA: 0x0006A0A0 File Offset: 0x000682A0
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x17005CCD RID: 23757
		' (get) Token: 0x0600F237 RID: 62007 RVA: 0x0006A0A9 File Offset: 0x000682A9
		' (set) Token: 0x0600F238 RID: 62008 RVA: 0x0006A0B3 File Offset: 0x000682B3
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17005CCE RID: 23758
		' (get) Token: 0x0600F239 RID: 62009 RVA: 0x0006A0BC File Offset: 0x000682BC
		' (set) Token: 0x0600F23A RID: 62010 RVA: 0x0006A0C6 File Offset: 0x000682C6
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17005CCF RID: 23759
		' (get) Token: 0x0600F23B RID: 62011 RVA: 0x0006A0CF File Offset: 0x000682CF
		' (set) Token: 0x0600F23C RID: 62012 RVA: 0x00915E28 File Offset: 0x00914028
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CD0 RID: 23760
		' (get) Token: 0x0600F23D RID: 62013 RVA: 0x0006A0D9 File Offset: 0x000682D9
		' (set) Token: 0x0600F23E RID: 62014 RVA: 0x00915E6C File Offset: 0x0091406C
		Private _listView1 As ListView
		Friend Overridable Property listView1 As ListView
			<CompilerGenerated()>
			Get
				Return Me._listView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.listView1_MouseDoubleClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.listView1_KeyDown
				Dim listView As ListView = Me._listView1
				If listView IsNot Nothing Then
					RemoveHandler listView.MouseDoubleClick, mouseEventHandler
					RemoveHandler listView.KeyDown, keyEventHandler
				End If
				Me._listView1 = value
				listView = Me._listView1
				If listView IsNot Nothing Then
					AddHandler listView.MouseDoubleClick, mouseEventHandler
					AddHandler listView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CD1 RID: 23761
		' (get) Token: 0x0600F23F RID: 62015 RVA: 0x0006A0E3 File Offset: 0x000682E3
		' (set) Token: 0x0600F240 RID: 62016 RVA: 0x0006A0ED File Offset: 0x000682ED
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x17005CD2 RID: 23762
		' (get) Token: 0x0600F241 RID: 62017 RVA: 0x0006A0F6 File Offset: 0x000682F6
		' (set) Token: 0x0600F242 RID: 62018 RVA: 0x0006A100 File Offset: 0x00068300
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x17005CD3 RID: 23763
		' (get) Token: 0x0600F243 RID: 62019 RVA: 0x0006A109 File Offset: 0x00068309
		' (set) Token: 0x0600F244 RID: 62020 RVA: 0x0006A113 File Offset: 0x00068313
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x17005CD4 RID: 23764
		' (get) Token: 0x0600F245 RID: 62021 RVA: 0x0006A11C File Offset: 0x0006831C
		' (set) Token: 0x0600F246 RID: 62022 RVA: 0x0006A126 File Offset: 0x00068326
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x17005CD5 RID: 23765
		' (get) Token: 0x0600F247 RID: 62023 RVA: 0x0006A12F File Offset: 0x0006832F
		' (set) Token: 0x0600F248 RID: 62024 RVA: 0x0006A139 File Offset: 0x00068339
		Friend Overridable Property ColumnHeader22 As ColumnHeader

		' Token: 0x17005CD6 RID: 23766
		' (get) Token: 0x0600F249 RID: 62025 RVA: 0x0006A142 File Offset: 0x00068342
		' (set) Token: 0x0600F24A RID: 62026 RVA: 0x0006A14C File Offset: 0x0006834C
		Friend Overridable Property Label6 As Label

		' Token: 0x17005CD7 RID: 23767
		' (get) Token: 0x0600F24B RID: 62027 RVA: 0x0006A155 File Offset: 0x00068355
		' (set) Token: 0x0600F24C RID: 62028 RVA: 0x0006A15F File Offset: 0x0006835F
		Friend Overridable Property Label7 As Label

		' Token: 0x17005CD8 RID: 23768
		' (get) Token: 0x0600F24D RID: 62029 RVA: 0x0006A168 File Offset: 0x00068368
		' (set) Token: 0x0600F24E RID: 62030 RVA: 0x0006A172 File Offset: 0x00068372
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17005CD9 RID: 23769
		' (get) Token: 0x0600F24F RID: 62031 RVA: 0x0006A17B File Offset: 0x0006837B
		' (set) Token: 0x0600F250 RID: 62032 RVA: 0x00915ECC File Offset: 0x009140CC
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CDA RID: 23770
		' (get) Token: 0x0600F251 RID: 62033 RVA: 0x0006A185 File Offset: 0x00068385
		' (set) Token: 0x0600F252 RID: 62034 RVA: 0x00915F10 File Offset: 0x00914110
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CDB RID: 23771
		' (get) Token: 0x0600F253 RID: 62035 RVA: 0x0006A18F File Offset: 0x0006838F
		' (set) Token: 0x0600F254 RID: 62036 RVA: 0x0006A199 File Offset: 0x00068399
		Friend Overridable Property ColumnHeader23 As ColumnHeader

		' Token: 0x17005CDC RID: 23772
		' (get) Token: 0x0600F255 RID: 62037 RVA: 0x0006A1A2 File Offset: 0x000683A2
		' (set) Token: 0x0600F256 RID: 62038 RVA: 0x0006A1AC File Offset: 0x000683AC
		Friend Overridable Property ColumnHeader24 As ColumnHeader

		' Token: 0x17005CDD RID: 23773
		' (get) Token: 0x0600F257 RID: 62039 RVA: 0x0006A1B5 File Offset: 0x000683B5
		' (set) Token: 0x0600F258 RID: 62040 RVA: 0x0006A1BF File Offset: 0x000683BF
		Friend Overridable Property ColumnHeader25 As ColumnHeader

		' Token: 0x17005CDE RID: 23774
		' (get) Token: 0x0600F259 RID: 62041 RVA: 0x0006A1C8 File Offset: 0x000683C8
		' (set) Token: 0x0600F25A RID: 62042 RVA: 0x0006A1D2 File Offset: 0x000683D2
		Friend Overridable Property chkLoyality As CheckBox

		' Token: 0x17005CDF RID: 23775
		' (get) Token: 0x0600F25B RID: 62043 RVA: 0x0006A1DB File Offset: 0x000683DB
		' (set) Token: 0x0600F25C RID: 62044 RVA: 0x0006A1E5 File Offset: 0x000683E5
		Friend Overridable Property cboxLoyalityStatus As ComboBox

		' Token: 0x0600F25D RID: 62045 RVA: 0x0006A1EE File Offset: 0x000683EE
		Private Sub frmCustomerBulkUpdate_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F25E RID: 62046 RVA: 0x00915F54 File Offset: 0x00914154
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

		' Token: 0x0600F25F RID: 62047 RVA: 0x009160CC File Offset: 0x009142CC
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

		' Token: 0x0600F260 RID: 62048 RVA: 0x00916188 File Offset: 0x00914388
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

		' Token: 0x0600F261 RID: 62049 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F262 RID: 62050 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F263 RID: 62051 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F264 RID: 62052 RVA: 0x00916254 File Offset: 0x00914454
		Public Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP " + Me.txtTopResult.Text + " ID, RTRIM(CustomerID),RTRIM(Name), RTRIM(Address),RTRIM(City), RTRIM(State), RTRIM(ZipCode),RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountNumber),RTRIM(AccountName), RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(Tcs),Limit,RTRIM(Lstatus),RTRIM(Taround), OpbalLoyality, OpLoyalitytype, (case when is_loyalityDisable=0 then 'Enable' else 'Disable' end) as is_loyalityDisable from Customer where NOT Name='Cash' order by ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F265 RID: 62053 RVA: 0x009166E8 File Offset: 0x009148E8
		Private Sub listView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.CurrentItem = Me.listView1.GetItemAt(e.X, e.Y)
			Dim flag As Boolean = Me.CurrentItem Is Nothing
			Dim flag2 As Boolean = Not flag
			If flag2 Then
				Me.CurrentSB = Me.CurrentItem.GetSubItemAt(e.X, e.Y)
				Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
				If num - 2 <= 20 Then
					' The following expression was wrapped in a checked-statement
					Dim num2 As Integer = Me.CurrentSB.Bounds.Left + 2
					Dim width As Integer = Me.CurrentSB.Bounds.Width
					Dim textBox As TextBox = Me.TextBox42
					textBox.SetBounds(num2 + Me.listView1.Left, Me.CurrentSB.Bounds.Top + Me.listView1.Top, width, Me.CurrentSB.Bounds.Height)
					textBox.Text = Me.CurrentSB.Text
					textBox.Show()
					textBox.Focus()
				End If
			End If
		End Sub

		' Token: 0x0600F266 RID: 62054 RVA: 0x00916814 File Offset: 0x00914A14
		Private Sub TextBox42_LostFocus(sender As Object, e As EventArgs)
			Me.TextBox42.Hide()
			Dim flag As Boolean = Not Me.bCancelEdit
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Operators.CompareString(Me.TextBox42.Text.Trim(), "", False) <> 0
				Dim flag4 As Boolean = flag3
				If flag4 Then
					Me.CurrentSB.Text = Me.TextBox42.Text
					Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
					flag3 = num = 2
					Dim flag5 As Boolean = flag3
					If flag5 Then
					End If
				End If
			Else
				Me.bCancelEdit = False
			End If
			Me.listView1.Focus()
		End Sub

		' Token: 0x0600F267 RID: 62055 RVA: 0x009168BC File Offset: 0x00914ABC
		Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Operators.CompareString(Conversions.ToString(keyChar), vbCr, False) = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				Me.bCancelEdit = False
				e.Handled = True
				Me.TextBox1.Hide()
				Dim listView As ListView = Me.listView1
				Me.listView1 = listView
			Else
				flag = keyChar = ChrW(27)
				Dim flag3 As Boolean = flag
				If flag3 Then
					Me.bCancelEdit = True
					e.Handled = True
					Me.TextBox1.Hide()
				End If
			End If
		End Sub

		' Token: 0x0600F268 RID: 62056 RVA: 0x00916944 File Offset: 0x00914B44
		Private Sub listView1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = Me.listView1.SelectedItems.Count = 0
			Dim flag2 As Boolean = Not flag
			If flag2 Then
				Dim keyCode As Keys = e.KeyCode
				flag = keyCode = Keys.F2
				Dim flag3 As Boolean = flag
				If flag3 Then
					e.Handled = True
					Me.BeginEditListItem(Me.listView1.SelectedItems(0), 2)
				End If
			End If
		End Sub

		' Token: 0x0600F269 RID: 62057 RVA: 0x009169A8 File Offset: 0x00914BA8
		Private Sub BeginEditListItem(iTm As ListViewItem, SubItemIndex As Integer)
			Dim location As Point = iTm.SubItems(SubItemIndex).Bounds.Location
			Dim e As MouseEventArgs = New MouseEventArgs(MouseButtons.Left, 2, location.X, location.Y, 0)
			Me.listView1_MouseDoubleClick(Me.listView1, e)
		End Sub

		' Token: 0x0600F26A RID: 62058 RVA: 0x009169FC File Offset: 0x00914BFC
		Private Sub Updatelistdata(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			Dim text2 As String
			Dim text3 As String
			While True
				Dim num5 As Integer = num4
				Dim num6 As Integer = num3
				Dim flag As Boolean = num5 > num6
				If flag Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num4).Checked
				Dim flag2 As Boolean = checked
				If flag2 Then
					Dim text As String = String.Concat(New String() { "UPDATE Customer SET Name = N'", pListView.Items(num4).SubItems(2).Text, "', Address = N'", pListView.Items(num4).SubItems(3).Text, "', City = N'", pListView.Items(num4).SubItems(4).Text, "', State = N'", pListView.Items(num4).SubItems(5).Text, "', ZipCode = N'", pListView.Items(num4).SubItems(6).Text, "', ContactNo = N'", pListView.Items(num4).SubItems(7).Text, "', EmailID = N'", pListView.Items(num4).SubItems(8).Text, "', Remarks = N'", pListView.Items(num4).SubItems(9).Text, "', AccountNumber = N'", pListView.Items(num4).SubItems(10).Text, "', AccountName = N'", pListView.Items(num4).SubItems(11).Text, "', Bank = N'", pListView.Items(num4).SubItems(12).Text, "', Branch = N'", pListView.Items(num4).SubItems(13).Text, "', IFSCCode = N'", pListView.Items(num4).SubItems(14).Text, "', GSTIN = N'", pListView.Items(num4).SubItems(15).Text, "', PAN = N'", pListView.Items(num4).SubItems(16).Text, "', CIN = N'", pListView.Items(num4).SubItems(17).Text, "', Tcs = N'", pListView.Items(num4).SubItems(18).Text, "', Limit = N'", pListView.Items(num4).SubItems(19).Text, "', Lstatus = N'", pListView.Items(num4).SubItems(20).Text, "', Taround = N'", pListView.Items(num4).SubItems(21).Text, "' WHERE ID = N'", pListView.Items(num4).SubItems(0).Text, "' and CustomerID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Me.ExecNonQuery(text)
					text2 = text2 + pListView.Items(num4).SubItems(0).Text + ","
					text3 = text3 + pListView.Items(num4).SubItems(1).Text + ","
					pListView.Items(num4).Checked = False
					num += 1
				End If
				num4 += 1
			End While
			Interaction.MsgBox(String.Concat(New String() { "Total Record(s) Updated ", Conversions.ToString(num), ". Updated ID(s)  ", text2, " having Customer ID(s). ", text3 }), MsgBoxStyle.OkOnly, Nothing)
		End Sub

		' Token: 0x0600F26B RID: 62059 RVA: 0x00817A5C File Offset: 0x00815C5C
		Public Function ExecNonQuery(cmdText As String) As Integer
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim sqlCommand As SqlCommand = New SqlCommand(cmdText, sqlConnection)
			Dim num As Integer = sqlCommand.ExecuteNonQuery()
			sqlCommand.Dispose()
			sqlConnection.Close()
			Return num
		End Function

		' Token: 0x0600F26C RID: 62060 RVA: 0x00916ED8 File Offset: 0x009150D8
		Private Sub Updatelistdata1(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			While True
				Dim num5 As Integer = num4
				Dim num6 As Integer = num3
				Dim flag As Boolean = num5 > num6
				If flag Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num4).Checked
				Dim flag2 As Boolean = checked
				If flag2 Then
					Dim text As String = String.Concat(New String() { "Update LedgerBook set [Name]= N'", pListView.Items(num4).SubItems(2).Text, "' WHERE  PartyID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Me.ExecNonQuery(text)
					Dim text2 As String = text2 + pListView.Items(num4).SubItems(0).Text + ","
					Dim text3 As String = text3 + pListView.Items(num4).SubItems(1).Text + ","
					pListView.Items(num4).Checked = True
					num += 1
				End If
				num4 += 1
			End While
		End Sub

		' Token: 0x0600F26D RID: 62061 RVA: 0x00917024 File Offset: 0x00915224
		Private Sub Updatelistdata2(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			While True
				Dim num5 As Integer = num4
				Dim num6 As Integer = num3
				Dim flag As Boolean = num5 > num6
				If flag Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num4).Checked
				Dim flag2 As Boolean = checked
				If flag2 Then
					Dim text As String = String.Concat(New String() { "Update CustomerLedgerBook set Name= N'", pListView.Items(num4).SubItems(2).Text, "' WHERE  PartyID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Me.ExecNonQuery(text)
					Dim text2 As String = text2 + pListView.Items(num4).SubItems(0).Text + ","
					Dim text3 As String = text3 + pListView.Items(num4).SubItems(1).Text + ","
					pListView.Items(num4).Checked = True
					num += 1
				End If
				num4 += 1
			End While
		End Sub

		' Token: 0x0600F26E RID: 62062 RVA: 0x00917170 File Offset: 0x00915370
		Private Sub Updatelistdata3(ByRef pListView As ListView)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = pListView.Items.Count - 1
			Dim num4 As Integer = num2
			While True
				Dim num5 As Integer = num4
				Dim num6 As Integer = num3
				Dim flag As Boolean = num5 > num6
				If flag Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num4).Checked
				Dim flag2 As Boolean = checked
				If flag2 Then
					Dim text As String = String.Concat(New String() { "Update CustomerLedgerBook set CustNameid= N'", pListView.Items(num4).SubItems(2).Text + "-" + pListView.Items(num4).SubItems(1).Text, "' WHERE  PartyID = N'", pListView.Items(num4).SubItems(1).Text, "'" })
					Me.ExecNonQuery(text)
					Dim text2 As String = text2 + pListView.Items(num4).SubItems(0).Text + ","
					Dim text3 As String = text3 + pListView.Items(num4).SubItems(1).Text + ","
					pListView.Items(num4).Checked = True
					num += 1
				End If
				num4 += 1
			End While
		End Sub

		' Token: 0x0600F26F RID: 62063 RVA: 0x009172E4 File Offset: 0x009154E4
		Private Sub Updatelistdata4(ByRef pListView As ListView)
			Dim flag As Boolean = Operators.CompareString(Me.cboxLoyalityStatus.Text, "Enable", False) = 0
			Dim num As Integer
			If flag Then
				num = 0
			Else
				num = 1
			End If
			Dim num2 As Integer = 0
			Dim num3 As Integer = 0
			Dim num4 As Integer = pListView.Items.Count - 1
			Dim num5 As Integer = num3
			While True
				Dim num6 As Integer = num5
				Dim num7 As Integer = num4
				Dim flag2 As Boolean = num6 > num7
				If flag2 Then
					Exit While
				End If
				Dim checked As Boolean = pListView.Items(num5).Checked
				Dim flag3 As Boolean = checked
				If flag3 Then
					Dim text As String = String.Concat(New String() { "Update Customer set is_loyalityDisable= N'", Conversions.ToString(num), "' WHERE  ID = N'", pListView.Items(num5).SubItems(0).Text, "'" })
					Me.ExecNonQuery(text)
					Dim text2 As String = text2 + pListView.Items(num5).SubItems(0).Text + ","
					Dim text3 As String = text3 + pListView.Items(num5).SubItems(1).Text + ","
					pListView.Items(num5).Checked = True
					num2 += 1
				End If
				num5 += 1
			End While
		End Sub

		' Token: 0x0600F270 RID: 62064 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox42_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F271 RID: 62065 RVA: 0x00917448 File Offset: 0x00915648
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.listView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.listView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x0600F272 RID: 62066 RVA: 0x00917534 File Offset: 0x00915734
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " ID, RTRIM(CustomerID),RTRIM(Name), RTRIM(Address),RTRIM(City), RTRIM(State), RTRIM(ZipCode),RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountNumber),RTRIM(AccountName), RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(Tcs),Limit,RTRIM(Lstatus),RTRIM(Taround),OpbalLoyality, OpLoyalitytype, (case when is_loyalityDisable=0 then 'Enable' else 'Disable' end) as is_loyalityDisable from Customer where NOT Name='Cash' and Name like N'%", Me.TextBox1.Text, "%' order by ID" }), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F273 RID: 62067 RVA: 0x009179F0 File Offset: 0x00915BF0
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " ID, RTRIM(CustomerID),RTRIM(Name), RTRIM(Address),RTRIM(City), RTRIM(State), RTRIM(ZipCode),RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountNumber),RTRIM(AccountName), RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(Tcs),Limit,RTRIM(Lstatus),RTRIM(Taround),OpbalLoyality, OpLoyalitytype, (case when is_loyalityDisable=0 then 'Enable' else 'Disable' end) as is_loyalityDisable from Customer where NOT Name='Cash' and ContactNo like N'%", Me.TextBox2.Text, "%' order by ID" }), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(19).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(20).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(21).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(22).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(23).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(24).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag As Boolean = num4 > num5
					If flag Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = False
					num3 += 1
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F274 RID: 62068 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerBulkUpdate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F275 RID: 62069 RVA: 0x00917EAC File Offset: 0x009160AC
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.chkSelectAll.Checked = False
			Me.txtTopResult.Text = "50"
			Me.Getdata()
		End Sub

		' Token: 0x0600F276 RID: 62070 RVA: 0x00917F04 File Offset: 0x00916104
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Interaction.MsgBox("Are you sure to update record", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim listView As ListView = Me.listView1
				Dim checked As Boolean = Me.chkLoyality.Checked
				If checked Then
					Me.Updatelistdata4(listView)
				Else
					Me.Updatelistdata1(listView)
					Me.Updatelistdata2(listView)
					Me.Updatelistdata3(listView)
					Me.Updatelistdata(listView)
				End If
				Me.listView1 = listView
				Me.Getdata()
				Me.chkSelectAll.Checked = False
				Me.chkLoyality.Checked = False
			End If
		End Sub

		' Token: 0x04005C9A RID: 23706
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x04005C9B RID: 23707
		Private CurrentItem As ListViewItem

		' Token: 0x04005C9C RID: 23708
		Private bCancelEdit As Boolean
	End Class
End Namespace
