Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200034A RID: 842
	<DesignerGenerated()>
	Public Partial Class frmLanChat
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C53F RID: 50495 RVA: 0x007D0520 File Offset: 0x007CE720
		Public Sub New()
			AddHandler MyBase.FormClosing, AddressOf Me.Form1_FormClosing
			AddHandler MyBase.Load, AddressOf Me.Form1_Load
			Me.listerner = New TcpListener(44444)
			Me.message = ""
			Me.h = Dns.GetHostByName(Dns.GetHostName())
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004E49 RID: 20041
		' (get) Token: 0x0600C542 RID: 50498 RVA: 0x00058406 File Offset: 0x00056606
		' (set) Token: 0x0600C543 RID: 50499 RVA: 0x00058410 File Offset: 0x00056610
		Friend Overridable Property Label1 As Label

		' Token: 0x17004E4A RID: 20042
		' (get) Token: 0x0600C544 RID: 50500 RVA: 0x00058419 File Offset: 0x00056619
		' (set) Token: 0x0600C545 RID: 50501 RVA: 0x00058423 File Offset: 0x00056623
		Friend Overridable Property Label2 As Label

		' Token: 0x17004E4B RID: 20043
		' (get) Token: 0x0600C546 RID: 50502 RVA: 0x0005842C File Offset: 0x0005662C
		' (set) Token: 0x0600C547 RID: 50503 RVA: 0x00058436 File Offset: 0x00056636
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17004E4C RID: 20044
		' (get) Token: 0x0600C548 RID: 50504 RVA: 0x0005843F File Offset: 0x0005663F
		' (set) Token: 0x0600C549 RID: 50505 RVA: 0x00058449 File Offset: 0x00056649
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17004E4D RID: 20045
		' (get) Token: 0x0600C54A RID: 50506 RVA: 0x00058452 File Offset: 0x00056652
		' (set) Token: 0x0600C54B RID: 50507 RVA: 0x0005845C File Offset: 0x0005665C
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17004E4E RID: 20046
		' (get) Token: 0x0600C54C RID: 50508 RVA: 0x00058465 File Offset: 0x00056665
		' (set) Token: 0x0600C54D RID: 50509 RVA: 0x007D1114 File Offset: 0x007CF314
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

		' Token: 0x17004E4F RID: 20047
		' (get) Token: 0x0600C54E RID: 50510 RVA: 0x0005846F File Offset: 0x0005666F
		' (set) Token: 0x0600C54F RID: 50511 RVA: 0x007D1158 File Offset: 0x007CF358
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

		' Token: 0x17004E50 RID: 20048
		' (get) Token: 0x0600C550 RID: 50512 RVA: 0x00058479 File Offset: 0x00056679
		' (set) Token: 0x0600C551 RID: 50513 RVA: 0x00058483 File Offset: 0x00056683
		Friend Overridable Property Label3 As Label

		' Token: 0x17004E51 RID: 20049
		' (get) Token: 0x0600C552 RID: 50514 RVA: 0x0005848C File Offset: 0x0005668C
		' (set) Token: 0x0600C553 RID: 50515 RVA: 0x00058496 File Offset: 0x00056696
		Friend Overridable Property Label4 As Label

		' Token: 0x17004E52 RID: 20050
		' (get) Token: 0x0600C554 RID: 50516 RVA: 0x0005849F File Offset: 0x0005669F
		' (set) Token: 0x0600C555 RID: 50517 RVA: 0x000584A9 File Offset: 0x000566A9
		Friend Overridable Property ImageList1 As ImageList

		' Token: 0x17004E53 RID: 20051
		' (get) Token: 0x0600C556 RID: 50518 RVA: 0x000584B2 File Offset: 0x000566B2
		' (set) Token: 0x0600C557 RID: 50519 RVA: 0x000584BC File Offset: 0x000566BC
		Friend Overridable Property ListBox1 As ListBox

		' Token: 0x17004E54 RID: 20052
		' (get) Token: 0x0600C558 RID: 50520 RVA: 0x000584C5 File Offset: 0x000566C5
		' (set) Token: 0x0600C559 RID: 50521 RVA: 0x007D119C File Offset: 0x007CF39C
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

		' Token: 0x17004E55 RID: 20053
		' (get) Token: 0x0600C55A RID: 50522 RVA: 0x000584CF File Offset: 0x000566CF
		' (set) Token: 0x0600C55B RID: 50523 RVA: 0x007D11E0 File Offset: 0x007CF3E0
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

		' Token: 0x17004E56 RID: 20054
		' (get) Token: 0x0600C55C RID: 50524 RVA: 0x000584D9 File Offset: 0x000566D9
		' (set) Token: 0x0600C55D RID: 50525 RVA: 0x000584E3 File Offset: 0x000566E3
		Friend Overridable Property Label5 As Label

		' Token: 0x17004E57 RID: 20055
		' (get) Token: 0x0600C55E RID: 50526 RVA: 0x000584EC File Offset: 0x000566EC
		' (set) Token: 0x0600C55F RID: 50527 RVA: 0x000584F6 File Offset: 0x000566F6
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004E58 RID: 20056
		' (get) Token: 0x0600C560 RID: 50528 RVA: 0x000584FF File Offset: 0x000566FF
		' (set) Token: 0x0600C561 RID: 50529 RVA: 0x00058509 File Offset: 0x00056709
		Friend Overridable Property Label6 As Label

		' Token: 0x17004E59 RID: 20057
		' (get) Token: 0x0600C562 RID: 50530 RVA: 0x00058512 File Offset: 0x00056712
		' (set) Token: 0x0600C563 RID: 50531 RVA: 0x0005851C File Offset: 0x0005671C
		Friend Overridable Property BackgroundWorker1 As BackgroundWorker

		' Token: 0x0600C564 RID: 50532 RVA: 0x00058525 File Offset: 0x00056725
		Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs)
			Me.listerner.[Stop]()
		End Sub

		' Token: 0x0600C565 RID: 50533 RVA: 0x007D1224 File Offset: 0x007CF424
		Private Sub Form1_Load(sender As Object, e As EventArgs)
			Me.TextBox1.Text = Dns.GetHostName()
			Me.Label5.Text = CType(Me.h.AddressList.GetValue(0), IPAddress).ToString()
			Me.listerner.Start()
			Me.Timer1.Enabled = True
			Me.Timer1.Start()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C566 RID: 50534 RVA: 0x007D1298 File Offset: 0x007CF498
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

		' Token: 0x0600C567 RID: 50535 RVA: 0x007D1410 File Offset: 0x007CF610
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

		' Token: 0x0600C568 RID: 50536 RVA: 0x007D14CC File Offset: 0x007CF6CC
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

		' Token: 0x0600C569 RID: 50537 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C56A RID: 50538 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C56B RID: 50539 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C56C RID: 50540 RVA: 0x007D1598 File Offset: 0x007CF798
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.listerner.Pending()
				If flag Then
					Me.message = ""
					Me.client = Me.listerner.AcceptTcpClient()
					Dim streamReader As StreamReader = New StreamReader(Me.client.GetStream())
					While streamReader.Peek() > -1
						Me.message += Convert.ToChar(streamReader.Read()).ToString()
					End While
					MyBase.Focus()
					Me.ListBox1.Items.Add(Me.message)
					Me.ListBox1.SelectedIndex = Me.ListBox1.SelectedIndex + 1
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600C56D RID: 50541 RVA: 0x007D1688 File Offset: 0x007CF888
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.TextBox2.Text.TrimEnd(New Char(-1) {}), Me.Label5.Text, False) = 0
			If flag Then
				MessageBox.Show("Client Local IP and Your Local IP should not be same !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Try
					Dim flag2 As Boolean = (Operators.CompareString(Me.TextBox1.Text, "", False) = 0) Or (Operators.CompareString(Me.TextBox2.Text, "", False) = 0) Or (Operators.CompareString(Me.TextBox3.Text, "", False) = 0)
					If flag2 Then
						Interaction.MsgBox("Sorry Uncomplete data", MsgBoxStyle.OkOnly, Nothing)
					Else
						Me.client = New TcpClient(Me.TextBox2.Text, 44444)
						Dim streamWriter As StreamWriter = New StreamWriter(Me.client.GetStream())
						streamWriter.Write(String.Concat(New String() { "{ ", Me.TextBox1.Text, " - ", Me.Label5.Text, " } : ", Me.TextBox3.Text }))
						streamWriter.Flush()
						Me.ListBox1.Items.Add("Me : " + Me.TextBox3.Text)
						Me.ListBox1.SelectedIndex = Me.ListBox1.SelectedIndex + 1
						Me.TextBox3.Text = ""
					End If
				Catch ex As Exception
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
				End Try
			End If
		End Sub

		' Token: 0x0600C56E RID: 50542 RVA: 0x00058534 File Offset: 0x00056734
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.ListBox1.Items.Clear()
			Me.TextBox3.Text = ""
			Me.TextBox3.Focus()
		End Sub

		' Token: 0x0600C56F RID: 50543 RVA: 0x007D1858 File Offset: 0x007CFA58
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.SaveFileDialog1.Filter = "Text files (*.txt)}|*.txt"
			Dim flag As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Using streamWriter As StreamWriter = New StreamWriter(Me.SaveFileDialog1.FileName)
					Try
						For Each obj As Object In Me.ListBox1.Items
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							streamWriter.WriteLine(RuntimeHelpers.GetObjectValue(objectValue))
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				End Using
			End If
		End Sub

		' Token: 0x04004F23 RID: 20259
		Private listerner As TcpListener

		' Token: 0x04004F24 RID: 20260
		Private client As TcpClient

		' Token: 0x04004F25 RID: 20261
		Private message As String

		' Token: 0x04004F26 RID: 20262
		Private tts As Object

		' Token: 0x04004F27 RID: 20263
		Private h As IPHostEntry

		' Token: 0x04004F28 RID: 20264
		Private w As String
	End Class
End Namespace
