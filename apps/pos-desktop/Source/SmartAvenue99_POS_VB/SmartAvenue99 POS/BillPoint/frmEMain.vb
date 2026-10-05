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
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000055 RID: 85
	<DesignerGenerated()>
	Public Partial Class frmEMain
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06000FBC RID: 4028 RVA: 0x0000E972 File Offset: 0x0000CB72
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEMain_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000669 RID: 1641
		' (get) Token: 0x06000FBF RID: 4031 RVA: 0x0000E992 File Offset: 0x0000CB92
		' (set) Token: 0x06000FC0 RID: 4032 RVA: 0x0000E99C File Offset: 0x0000CB9C
		Friend Overridable Property lblUser As Label

		' Token: 0x1700066A RID: 1642
		' (get) Token: 0x06000FC1 RID: 4033 RVA: 0x0000E9A5 File Offset: 0x0000CBA5
		' (set) Token: 0x06000FC2 RID: 4034 RVA: 0x000BAD90 File Offset: 0x000B8F90
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

		' Token: 0x1700066B RID: 1643
		' (get) Token: 0x06000FC3 RID: 4035 RVA: 0x0000E9AF File Offset: 0x0000CBAF
		' (set) Token: 0x06000FC4 RID: 4036 RVA: 0x000BADD4 File Offset: 0x000B8FD4
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

		' Token: 0x1700066C RID: 1644
		' (get) Token: 0x06000FC5 RID: 4037 RVA: 0x0000E9B9 File Offset: 0x0000CBB9
		' (set) Token: 0x06000FC6 RID: 4038 RVA: 0x000BAE18 File Offset: 0x000B9018
		Private _Button16 As GelButton
		Friend Overridable Property Button16 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button16_Click
				Dim gelButton As GelButton = Me._Button16
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button16 = value
				gelButton = Me._Button16
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700066D RID: 1645
		' (get) Token: 0x06000FC7 RID: 4039 RVA: 0x0000E9C3 File Offset: 0x0000CBC3
		' (set) Token: 0x06000FC8 RID: 4040 RVA: 0x000BAE5C File Offset: 0x000B905C
		Private _Button10 As GelButton
		Friend Overridable Property Button10 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button10_Click
				Dim gelButton As GelButton = Me._Button10
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button10 = value
				gelButton = Me._Button10
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06000FC9 RID: 4041 RVA: 0x0000E9CD File Offset: 0x0000CBCD
		Private Sub Button16_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmECategory.Show()
		End Sub

		' Token: 0x06000FCA RID: 4042 RVA: 0x0000E9E0 File Offset: 0x0000CBE0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmESubCategory.Show()
		End Sub

		' Token: 0x06000FCB RID: 4043 RVA: 0x0000E9F3 File Offset: 0x0000CBF3
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEProduct.Show()
		End Sub

		' Token: 0x06000FCC RID: 4044 RVA: 0x0000EA06 File Offset: 0x0000CC06
		Private Sub Button10_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmOrder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmOrder.Show()
		End Sub

		' Token: 0x06000FCD RID: 4045 RVA: 0x0000EA39 File Offset: 0x0000CC39
		Private Sub frmEMain_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x06000FCE RID: 4046 RVA: 0x000BAEA0 File Offset: 0x000B90A0
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

		' Token: 0x06000FCF RID: 4047 RVA: 0x000BB018 File Offset: 0x000B9218
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

		' Token: 0x06000FD0 RID: 4048 RVA: 0x000BB0D4 File Offset: 0x000B92D4
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

		' Token: 0x06000FD1 RID: 4049 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06000FD2 RID: 4050 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06000FD3 RID: 4051 RVA: 0x00087088 File Offset: 0x00085288
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
