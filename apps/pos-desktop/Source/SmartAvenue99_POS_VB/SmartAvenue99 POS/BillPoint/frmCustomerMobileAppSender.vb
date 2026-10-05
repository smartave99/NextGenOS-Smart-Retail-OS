Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports DevNet.Models
Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000D9 RID: 217
	<DesignerGenerated()>
	Public Partial Class frmCustomerMobileAppSender
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060026EB RID: 9963 RVA: 0x00188DD0 File Offset: 0x00186FD0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerMobileAppSender_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerMobileAppSender_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmCustomerMobileAppSender_Closed
			Me.sts = ""
			Me.sts2 = ""
			Me.cmpnm = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000F53 RID: 3923
		' (get) Token: 0x060026EE RID: 9966 RVA: 0x00019C3C File Offset: 0x00017E3C
		' (set) Token: 0x060026EF RID: 9967 RVA: 0x00019C46 File Offset: 0x00017E46
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000F54 RID: 3924
		' (get) Token: 0x060026F0 RID: 9968 RVA: 0x00019C4F File Offset: 0x00017E4F
		' (set) Token: 0x060026F1 RID: 9969 RVA: 0x00019C59 File Offset: 0x00017E59
		Friend Overridable Property Label1 As Label

		' Token: 0x17000F55 RID: 3925
		' (get) Token: 0x060026F2 RID: 9970 RVA: 0x00019C62 File Offset: 0x00017E62
		' (set) Token: 0x060026F3 RID: 9971 RVA: 0x00019C6C File Offset: 0x00017E6C
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000F56 RID: 3926
		' (get) Token: 0x060026F4 RID: 9972 RVA: 0x00019C75 File Offset: 0x00017E75
		' (set) Token: 0x060026F5 RID: 9973 RVA: 0x00019C7F File Offset: 0x00017E7F
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17000F57 RID: 3927
		' (get) Token: 0x060026F6 RID: 9974 RVA: 0x00019C88 File Offset: 0x00017E88
		' (set) Token: 0x060026F7 RID: 9975 RVA: 0x00019C92 File Offset: 0x00017E92
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17000F58 RID: 3928
		' (get) Token: 0x060026F8 RID: 9976 RVA: 0x00019C9B File Offset: 0x00017E9B
		' (set) Token: 0x060026F9 RID: 9977 RVA: 0x00019CA5 File Offset: 0x00017EA5
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17000F59 RID: 3929
		' (get) Token: 0x060026FA RID: 9978 RVA: 0x00019CAE File Offset: 0x00017EAE
		' (set) Token: 0x060026FB RID: 9979 RVA: 0x00019CB8 File Offset: 0x00017EB8
		Friend Overridable Property CheckBox2 As CheckBox

		' Token: 0x17000F5A RID: 3930
		' (get) Token: 0x060026FC RID: 9980 RVA: 0x00019CC1 File Offset: 0x00017EC1
		' (set) Token: 0x060026FD RID: 9981 RVA: 0x00019CCB File Offset: 0x00017ECB
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17000F5B RID: 3931
		' (get) Token: 0x060026FE RID: 9982 RVA: 0x00019CD4 File Offset: 0x00017ED4
		' (set) Token: 0x060026FF RID: 9983 RVA: 0x00019CDE File Offset: 0x00017EDE
		Friend Overridable Property Label4 As Label

		' Token: 0x17000F5C RID: 3932
		' (get) Token: 0x06002700 RID: 9984 RVA: 0x00019CE7 File Offset: 0x00017EE7
		' (set) Token: 0x06002701 RID: 9985 RVA: 0x0018A150 File Offset: 0x00188350
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F5D RID: 3933
		' (get) Token: 0x06002702 RID: 9986 RVA: 0x00019CF1 File Offset: 0x00017EF1
		' (set) Token: 0x06002703 RID: 9987 RVA: 0x0018A194 File Offset: 0x00188394
		Private _CheckBox3 As CheckBox
		Friend Overridable Property CheckBox3 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox3_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox3
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox3 = value
				checkBox = Me._CheckBox3
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F5E RID: 3934
		' (get) Token: 0x06002704 RID: 9988 RVA: 0x00019CFB File Offset: 0x00017EFB
		' (set) Token: 0x06002705 RID: 9989 RVA: 0x0018A1D8 File Offset: 0x001883D8
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

		' Token: 0x17000F5F RID: 3935
		' (get) Token: 0x06002706 RID: 9990 RVA: 0x00019D05 File Offset: 0x00017F05
		' (set) Token: 0x06002707 RID: 9991 RVA: 0x00019D0F File Offset: 0x00017F0F
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000F60 RID: 3936
		' (get) Token: 0x06002708 RID: 9992 RVA: 0x00019D18 File Offset: 0x00017F18
		' (set) Token: 0x06002709 RID: 9993 RVA: 0x00019D22 File Offset: 0x00017F22
		Friend Overridable Property Label3 As Label

		' Token: 0x17000F61 RID: 3937
		' (get) Token: 0x0600270A RID: 9994 RVA: 0x00019D2B File Offset: 0x00017F2B
		' (set) Token: 0x0600270B RID: 9995 RVA: 0x00019D35 File Offset: 0x00017F35
		Friend Overridable Property Label2 As Label

		' Token: 0x17000F62 RID: 3938
		' (get) Token: 0x0600270C RID: 9996 RVA: 0x00019D3E File Offset: 0x00017F3E
		' (set) Token: 0x0600270D RID: 9997 RVA: 0x0018A21C File Offset: 0x0018841C
		Private _TextBox5 As TextBox
		Friend Overridable Property TextBox5 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox5_KeyDown
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F63 RID: 3939
		' (get) Token: 0x0600270E RID: 9998 RVA: 0x00019D48 File Offset: 0x00017F48
		' (set) Token: 0x0600270F RID: 9999 RVA: 0x0018A260 File Offset: 0x00188460
		Private _TextBox4 As TextBox
		Friend Overridable Property TextBox4 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox4_KeyDown
				Dim textBox As TextBox = Me._TextBox4
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox4 = value
				textBox = Me._TextBox4
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F64 RID: 3940
		' (get) Token: 0x06002710 RID: 10000 RVA: 0x00019D52 File Offset: 0x00017F52
		' (set) Token: 0x06002711 RID: 10001 RVA: 0x0018A2A4 File Offset: 0x001884A4
		Private _btnNew As Button
		Friend Overridable Property btnNew As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim button As Button = Me._btnNew
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNew = value
				button = Me._btnNew
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F65 RID: 3941
		' (get) Token: 0x06002712 RID: 10002 RVA: 0x00019D5C File Offset: 0x00017F5C
		' (set) Token: 0x06002713 RID: 10003 RVA: 0x00019D66 File Offset: 0x00017F66
		Friend Overridable Property PictureBox3 As PictureBox

		' Token: 0x17000F66 RID: 3942
		' (get) Token: 0x06002714 RID: 10004 RVA: 0x00019D6F File Offset: 0x00017F6F
		' (set) Token: 0x06002715 RID: 10005 RVA: 0x0018A2E8 File Offset: 0x001884E8
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F67 RID: 3943
		' (get) Token: 0x06002716 RID: 10006 RVA: 0x00019D79 File Offset: 0x00017F79
		' (set) Token: 0x06002717 RID: 10007 RVA: 0x00019D83 File Offset: 0x00017F83
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000F68 RID: 3944
		' (get) Token: 0x06002718 RID: 10008 RVA: 0x00019D8C File Offset: 0x00017F8C
		' (set) Token: 0x06002719 RID: 10009 RVA: 0x00019D96 File Offset: 0x00017F96
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000F69 RID: 3945
		' (get) Token: 0x0600271A RID: 10010 RVA: 0x00019D9F File Offset: 0x00017F9F
		' (set) Token: 0x0600271B RID: 10011 RVA: 0x00019DA9 File Offset: 0x00017FA9
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000F6A RID: 3946
		' (get) Token: 0x0600271C RID: 10012 RVA: 0x00019DB2 File Offset: 0x00017FB2
		' (set) Token: 0x0600271D RID: 10013 RVA: 0x00019DBC File Offset: 0x00017FBC
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000F6B RID: 3947
		' (get) Token: 0x0600271E RID: 10014 RVA: 0x00019DC5 File Offset: 0x00017FC5
		' (set) Token: 0x0600271F RID: 10015 RVA: 0x00019DCF File Offset: 0x00017FCF
		Friend Overridable Property Column1 As DataGridViewCheckBoxColumn

		' Token: 0x17000F6C RID: 3948
		' (get) Token: 0x06002720 RID: 10016 RVA: 0x00019DD8 File Offset: 0x00017FD8
		' (set) Token: 0x06002721 RID: 10017 RVA: 0x00019DE2 File Offset: 0x00017FE2
		Friend Overridable Property colStatus As DataGridViewTextBoxColumn

		' Token: 0x06002722 RID: 10018 RVA: 0x0018A32C File Offset: 0x0018852C
		Private Sub frmCustomerMobileAppSender_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.statusdisplay()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06002723 RID: 10019 RVA: 0x0018A3C4 File Offset: 0x001885C4
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

		' Token: 0x06002724 RID: 10020 RVA: 0x0018A53C File Offset: 0x0018873C
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

		' Token: 0x06002725 RID: 10021 RVA: 0x0018A5F8 File Offset: 0x001887F8
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

		' Token: 0x06002726 RID: 10022 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06002727 RID: 10023 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06002728 RID: 10024 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06002729 RID: 10025 RVA: 0x0018A6C4 File Offset: 0x001888C4
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600272A RID: 10026 RVA: 0x0018A7AC File Offset: 0x001889AC
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(CustomerID), RTRIM(Name), RTRIM(State), RTRIM(ContactNo) from Customer where Name not in('Cash') order by Name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ModFunc.MD5Encrypt(ModCommonClasses.rdr(0).ToString() + NewLateBinding.LateGet(ModCommonClasses.rdr(3), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString())
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), text, ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600272B RID: 10027 RVA: 0x0018A900 File Offset: 0x00188B00
		Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox3.Checked
			If checked Then
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Cells(4).Value = True
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Dim flag As Boolean = Not Me.CheckBox3.Checked
				If flag Then
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataGridViewRow2.Cells(4).Value = False
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600272C RID: 10028 RVA: 0x0018AA0C File Offset: 0x00188C0C
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

		' Token: 0x0600272D RID: 10029 RVA: 0x0018AB00 File Offset: 0x00188D00
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

		' Token: 0x0600272E RID: 10030 RVA: 0x001326D8 File Offset: 0x001308D8
		Public Sub WAPPIMAGE()
			Dim flag As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\WhatsApp")
			If flag Then
				Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\WhatsApp\")
			End If
			Dim text As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp"
			For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(text2)
			Next
		End Sub

		' Token: 0x0600272F RID: 10031 RVA: 0x0018ABF8 File Offset: 0x00188DF8
		Private Async Sub sendMessage(Row As DataGridViewRow)
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					Interaction.MsgBox("Internet Connection not avaliable !", MsgBoxStyle.Information, "Info")
				Else
					Try
						Dim customerName As String = Row.Cells(1).Value.ToString()
						Dim textsms As String = Me.TextBox3.Text.TrimEnd(New Char(-1) {}).ToString()
						Dim mobileapklink As String = Me.TextBox1.Text.TrimEnd(New Char(-1) {}).ToString()
						Dim videolink As String = Me.TextBox2.Text.TrimEnd(New Char(-1) {}).ToString()
						Dim mobileapkID As String = Row.Cells(2).Value.ToString()
						Dim phone As String = Row.Cells(3).Value.ToString()
						Try
							Dim qrCode As QRCodeEncoder = New QRCodeEncoder()
							qrCode.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
							qrCode.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
							Me.PictureBox3.Image = qrCode.Encode(mobileapkID, Encoding.UTF8)
						Catch ex2 As Exception
						End Try
						Me.WAPPIMAGE()
						Using bmp As Bitmap = New Bitmap(Me.PictureBox3.Width, Me.PictureBox3.Height)
							Me.PictureBox3.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
							bmp.Save(MyProject.Application.Info.DirectoryPath + "\WhatsApp\Report.png")
						End Using
						Dim flag3 As Boolean = Me.CheckBox1.Checked And Not Me.CheckBox2.Checked
						If flag3 Then
							Dim message As String = String.Format("Dear {0}, {1}, Mobile Apk Link :  {2}, Mobile Apk ID :  {3}, _Best wishes from : *{4}*_", New Object() { customerName, textsms, mobileapklink, mobileapkID, Me.cmpnm })
							Dim attach As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\Report.png"
							Me.SetWhatsappVariables(phone, message, attach, Row)
						End If
						Dim flag4 As Boolean = Me.CheckBox2.Checked And Not Me.CheckBox1.Checked
						If flag4 Then
							Dim message2 As String = String.Format("Dear {0}, {1}, Video Link :  {2}, _Best wishes from : *{3}*_", New Object() { customerName, textsms, videolink, Me.cmpnm })
							Dim attach2 As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\OfferImg.png"
							Me.SetWhatsappVariables(phone, message2, attach2, Row)
						End If
						Dim flag5 As Boolean = Me.CheckBox2.Checked And Me.CheckBox1.Checked
						If flag5 Then
							Dim message3 As String = String.Format("Dear {0}, {1}, Mobile Apk Link :  {2}, Video Link :  {3}, Mobile Apk ID :  {4}, _Best wishes from : *{5}*_", New Object() { customerName, textsms, mobileapklink, videolink, mobileapkID, Me.cmpnm })
							Dim attach3 As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\Report.png"
							Me.SetWhatsappVariables(phone, message3, attach3, Row)
						End If
						Dim flag6 As Boolean = Not Me.CheckBox2.Checked And Not Me.CheckBox1.Checked
						If flag6 Then
							Dim message4 As String = String.Format("Dear {0}, {1}, _Best wishes from : *{2}*_", customerName, textsms, Me.cmpnm)
							Dim attach4 As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\Report.png"
							Me.SetWhatsappVariables(phone, message4, attach4, Row)
						End If
					Catch ex3 As Exception
						Dim ex As Exception = ex3
						MessageBox.Show(ex.Message)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06002730 RID: 10032 RVA: 0x0018AC38 File Offset: 0x00188E38
		Private Function SetWhatsappVariables(phone As String, message As String, attach As String, row As DataGridViewRow) As Object
			Try
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c1,WApi,FtpUrl,FtpUser,FtpPassword,FileUrl from WappApi where c2='Enabled'")
				Dim webClient As WebClient = New WebClient()
				webClient.Credentials = New NetworkCredential(dataTable.Rows(0)("FtpUser").ToString(), dataTable.Rows(0)("FtpPassword").ToString())
				Dim text As String = attach.Split(New Char() { "/"c }).Last()
				Dim flag As Boolean = text.Contains(".pdf")
				If flag Then
					MyBase.Name = "Report.pdf"
				Else
					Dim flag2 As Boolean = text.Contains(".png")
					If flag2 Then
						MyBase.Name = "Report.png"
					Else
						MyBase.Name = "Report.jpg"
					End If
				End If
				Dim text2 As String = dataTable.Rows(0)("FtpUrl").ToString() + MyBase.Name
				webClient.UploadFile(text2, attach)
				Dim text3 As String = dataTable.Rows(0)("FileUrl").ToString() + MyBase.Name
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.WhatsAppSender(phone, message, text3))
				Dim flag3 As Boolean = objectValue.ToString().Equals("OK")
				If flag3 Then
					row.Cells("colStatus").Value = "Success"
				End If
				webClient.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06002731 RID: 10033 RVA: 0x0018ADEC File Offset: 0x00188FEC
		Private Function WhatsAppSender(contactNo As String, msg As String, FileUrl As String) As Object
			Dim dataTable As DataTable = New DataTable()
			dataTable = clsfun.ExecDataTable("Select c1,WApi from WappApi where c2='Enabled'")
			Me.Cursor = Cursors.WaitCursor
			Me.Timer1.Enabled = True
			Try
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Dim text As String = dataTable.Rows(0)("Wapi").ToString()
					text = text.Replace("{No}", dataTable.Rows(0)("c1").ToString() + contactNo).Replace("{Msg}", msg).Replace("{url}", FileUrl)
					Dim uri As Uri = New Uri(text)
					Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(uri), HttpWebRequest)
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06002732 RID: 10034 RVA: 0x0018AEFC File Offset: 0x001890FC
		Private Async Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim count As Integer = 0
					Try
						For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim row As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag3 As Boolean = Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(Operators.AndObject(row.Cells(4).Value IsNot Nothing, Operators.CompareObjectEqual(row.Cells(4).Value, True, False))))
							If flag3 Then
								count += 1
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim flag4 As Boolean = count <= 0
					If flag4 Then
						MessageBox.Show("Please select customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Try
								For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
									Dim row2 As DataGridViewRow = CType(obj2, DataGridViewRow)
									Try
										Dim flag5 As Boolean = Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(row2.Cells(4).Value))
										If flag5 Then
											Dim customerName As String = row2.Cells(1).Value.ToString()
											Dim textsms As String = Me.TextBox3.Text.TrimEnd(New Char(-1) {}).ToString()
											Dim mobileapklink As String = Me.TextBox1.Text.TrimEnd(New Char(-1) {}).ToString()
											Dim videolink As String = Me.TextBox2.Text.TrimEnd(New Char(-1) {}).ToString()
											Dim mobileapkID As String = row2.Cells(2).Value.ToString()
											Dim phone As String = Me.sts + row2.Cells(3).Value.ToString()
											Try
												Dim qrCode As QRCodeEncoder = New QRCodeEncoder()
												qrCode.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
												qrCode.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
												Me.PictureBox3.Image = qrCode.Encode(mobileapkID, Encoding.UTF8)
											Catch ex As Exception
											End Try
											Me.WAPPIMAGE()
											Using bmp As Bitmap = New Bitmap(Me.PictureBox3.Width, Me.PictureBox3.Height)
												Me.PictureBox3.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
												bmp.Save(MyProject.Application.Info.DirectoryPath + "\WhatsApp\OfferImg.png")
											End Using
											Dim flag6 As Boolean = Me.CheckBox1.Checked And Not Me.CheckBox2.Checked
											If flag6 Then
												Dim message As String = String.Format("Dear {0}, {1}, Mobile Apk Link :  {2}, Mobile Apk ID :  {3}, _Best wishes from : *{4}*_", New Object() { customerName, textsms, mobileapklink, mobileapkID, Me.cmpnm })
												Dim attach As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\OfferImg.png"
												Dim flag7 As Boolean = phone IsNot Nothing AndAlso (message IsNot Nothing OrElse attach <> Nothing)
												If flag7 Then
													Dim messageRequest As MessageRequest = New MessageRequest()
													messageRequest.Phone = phone
													messageRequest.Message = message
													messageRequest.AttachmentPath = attach
												End If
											End If
											Dim flag8 As Boolean = Me.CheckBox2.Checked And Not Me.CheckBox1.Checked
											If flag8 Then
												Dim message2 As String = String.Format("Dear {0}, {1}, Video Link :  {2}, _Best wishes from : *{3}*_", New Object() { customerName, textsms, videolink, Me.cmpnm })
												Dim attach2 As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\OfferImg.png"
												Dim flag9 As Boolean = phone IsNot Nothing AndAlso (message2 IsNot Nothing OrElse attach2 <> Nothing)
												If flag9 Then
													Dim messageRequest2 As MessageRequest = New MessageRequest()
													messageRequest2.Phone = phone
													messageRequest2.Message = message2
													messageRequest2.AttachmentPath = attach2
												End If
											End If
											Dim flag10 As Boolean = Me.CheckBox2.Checked And Me.CheckBox1.Checked
											If flag10 Then
												Dim message3 As String = String.Format("Dear {0}, {1}, Mobile Apk Link :  {2}, Video Link :  {3}, Mobile Apk ID :  {4}, _Best wishes from : *{5}*_", New Object() { customerName, textsms, mobileapklink, videolink, mobileapkID, Me.cmpnm })
												Dim attach3 As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\OfferImg.png"
												Dim flag11 As Boolean = phone IsNot Nothing AndAlso (message3 IsNot Nothing OrElse attach3 <> Nothing)
												If flag11 Then
													Dim messageRequest3 As MessageRequest = New MessageRequest()
													messageRequest3.Phone = phone
													messageRequest3.Message = message3
													messageRequest3.AttachmentPath = attach3
												End If
											End If
											Dim flag12 As Boolean = Not Me.CheckBox2.Checked And Not Me.CheckBox1.Checked
											If flag12 Then
												Dim message4 As String = String.Format("Dear {0}, {1}, _Best wishes from : *{2}*_", customerName, textsms, Me.cmpnm)
												Dim attach4 As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\OfferImg.png"
												Dim flag13 As Boolean = phone IsNot Nothing AndAlso (message4 IsNot Nothing OrElse attach4 <> Nothing)
												If flag13 Then
													Dim messageRequest4 As MessageRequest = New MessageRequest()
													messageRequest4.Phone = phone
													messageRequest4.Message = message4
													messageRequest4.AttachmentPath = attach4
												End If
											End If
										End If
									Catch ex2 As Exception
									End Try
									Await Task.Delay(7000)
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
						Catch ex3 As Exception
							MessageBox.Show("Engine is not active")
						End Try
						Me.PictureBox3.Image = Nothing
					End If
				End If
			End If
		End Sub

		' Token: 0x06002733 RID: 10035 RVA: 0x0018AF44 File Offset: 0x00189144
		Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(CustomerID), RTRIM(Name), RTRIM(State), RTRIM(ContactNo) from Customer where Name not in('Cash') and Name like N'" + Me.TextBox4.Text + "%' order by Name", ModCommonClasses.con)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim text As String = ModFunc.MD5Encrypt(ModCommonClasses.rdr(0).ToString() + NewLateBinding.LateGet(ModCommonClasses.rdr(3), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString())
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), text, ModCommonClasses.rdr(3) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06002734 RID: 10036 RVA: 0x0018B0C0 File Offset: 0x001892C0
		Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(CustomerID), RTRIM(Name), RTRIM(State), RTRIM(ContactNo) from Customer where Name not in('Cash') and ContactNo like N'" + Me.TextBox5.Text + "%' order by Name", ModCommonClasses.con)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim text As String = ModFunc.MD5Encrypt(ModCommonClasses.rdr(0).ToString() + NewLateBinding.LateGet(ModCommonClasses.rdr(3), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString())
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), text, ModCommonClasses.rdr(3) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06002735 RID: 10037 RVA: 0x0018B23C File Offset: 0x0018943C
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = "https://drive.google.com/file/d/1MEsc02hz0A3-b8sjyViGO22NMemFemap/view?usp=sharing"
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox5.Text = ""
			Me.CheckBox3.Checked = False
			Me.PictureBox3.Image = Nothing
			Me.Getdata()
		End Sub

		' Token: 0x06002736 RID: 10038 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerMobileAppSender_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06002737 RID: 10039 RVA: 0x00185090 File Offset: 0x00183290
		Private Sub frmCustomerMobileAppSender_Closed(sender As Object, e As EventArgs)
			Try
				Dim text As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp"
				For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
					File.Delete(text2)
				Next
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002738 RID: 10040 RVA: 0x00019DEB File Offset: 0x00017FEB
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x04001018 RID: 4120
		Private sts As String

		' Token: 0x04001019 RID: 4121
		Private sts2 As String

		' Token: 0x0400101A RID: 4122
		Private cmpnm As String
	End Class
End Namespace
