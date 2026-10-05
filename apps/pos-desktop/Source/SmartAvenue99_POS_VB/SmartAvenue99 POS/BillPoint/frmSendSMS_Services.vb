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
	' Token: 0x02000599 RID: 1433
	<DesignerGenerated()>
	Public Partial Class frmSendSMS_Services
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060119A3 RID: 72099 RVA: 0x000793EB File Offset: 0x000775EB
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSendSMS_Services_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSendSMS_Services_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006D35 RID: 27957
		' (get) Token: 0x060119A6 RID: 72102 RVA: 0x0007941D File Offset: 0x0007761D
		' (set) Token: 0x060119A7 RID: 72103 RVA: 0x00079427 File Offset: 0x00077627
		Friend Overridable Property Label1 As Label

		' Token: 0x17006D36 RID: 27958
		' (get) Token: 0x060119A8 RID: 72104 RVA: 0x00079430 File Offset: 0x00077630
		' (set) Token: 0x060119A9 RID: 72105 RVA: 0x0007943A File Offset: 0x0007763A
		Friend Overridable Property lblUser As Label

		' Token: 0x17006D37 RID: 27959
		' (get) Token: 0x060119AA RID: 72106 RVA: 0x00079443 File Offset: 0x00077643
		' (set) Token: 0x060119AB RID: 72107 RVA: 0x0007944D File Offset: 0x0007764D
		Friend Overridable Property Label10 As Label

		' Token: 0x17006D38 RID: 27960
		' (get) Token: 0x060119AC RID: 72108 RVA: 0x00079456 File Offset: 0x00077656
		' (set) Token: 0x060119AD RID: 72109 RVA: 0x00079460 File Offset: 0x00077660
		Friend Overridable Property Label3 As Label

		' Token: 0x17006D39 RID: 27961
		' (get) Token: 0x060119AE RID: 72110 RVA: 0x00079469 File Offset: 0x00077669
		' (set) Token: 0x060119AF RID: 72111 RVA: 0x00079473 File Offset: 0x00077673
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17006D3A RID: 27962
		' (get) Token: 0x060119B0 RID: 72112 RVA: 0x0007947C File Offset: 0x0007767C
		' (set) Token: 0x060119B1 RID: 72113 RVA: 0x00079486 File Offset: 0x00077686
		Friend Overridable Property txtMessage As TextBox

		' Token: 0x17006D3B RID: 27963
		' (get) Token: 0x060119B2 RID: 72114 RVA: 0x0007948F File Offset: 0x0007768F
		' (set) Token: 0x060119B3 RID: 72115 RVA: 0x00079499 File Offset: 0x00077699
		Friend Overridable Property Label7 As Label

		' Token: 0x17006D3C RID: 27964
		' (get) Token: 0x060119B4 RID: 72116 RVA: 0x000794A2 File Offset: 0x000776A2
		' (set) Token: 0x060119B5 RID: 72117 RVA: 0x000794AC File Offset: 0x000776AC
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x17006D3D RID: 27965
		' (get) Token: 0x060119B6 RID: 72118 RVA: 0x000794B5 File Offset: 0x000776B5
		' (set) Token: 0x060119B7 RID: 72119 RVA: 0x000794BF File Offset: 0x000776BF
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x17006D3E RID: 27966
		' (get) Token: 0x060119B8 RID: 72120 RVA: 0x000794C8 File Offset: 0x000776C8
		' (set) Token: 0x060119B9 RID: 72121 RVA: 0x000794D2 File Offset: 0x000776D2
		Friend Overridable Property Label2 As Label

		' Token: 0x17006D3F RID: 27967
		' (get) Token: 0x060119BA RID: 72122 RVA: 0x000794DB File Offset: 0x000776DB
		' (set) Token: 0x060119BB RID: 72123 RVA: 0x00A33A10 File Offset: 0x00A31C10
		Private _btnSend As Button
		Friend Overridable Property btnSend As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSend
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSend_Click
				Dim button As Button = Me._btnSend
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSend = value
				button = Me._btnSend
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006D40 RID: 27968
		' (get) Token: 0x060119BC RID: 72124 RVA: 0x000794E5 File Offset: 0x000776E5
		' (set) Token: 0x060119BD RID: 72125 RVA: 0x00A33A54 File Offset: 0x00A31C54
		Private _btnListofServices As Button
		Friend Overridable Property btnListofServices As Button
			<CompilerGenerated()>
			Get
				Return Me._btnListofServices
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnListofServices_Click
				Dim button As Button = Me._btnListofServices
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnListofServices = value
				button = Me._btnListofServices
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006D41 RID: 27969
		' (get) Token: 0x060119BE RID: 72126 RVA: 0x000794EF File Offset: 0x000776EF
		' (set) Token: 0x060119BF RID: 72127 RVA: 0x00A33A98 File Offset: 0x00A31C98
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060119C0 RID: 72128 RVA: 0x00A33ADC File Offset: 0x00A31CDC
		Private Sub btnSend_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
				If flag Then
					MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtContactNo.Focus()
				Else
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtMessage.Text)) = 0
					If flag2 Then
						MessageBox.Show("Please Enter Message", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtMessage.Focus()
					Else
						Dim flag3 As Boolean = ModFunc.CheckForInternetConnection()
						If flag3 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								Me.st2 = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
								ModFunc.SMSFunc(Me.txtContactNo.Text, Me.txtMessage.Text, Me.st2)
								ModFunc.SMS(Me.txtMessage.Text)
								MessageBox.Show("Successfully SMS Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
							End If
						Else
							MessageBox.Show("SMS is not sent", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End If
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060119C1 RID: 72129 RVA: 0x00A33CB4 File Offset: 0x00A31EB4
		Public Sub Reset()
			Me.txtContactNo.Text = ""
			Me.txtCustomerID.Text = ""
			Me.txtCustomerName.Text = ""
			Me.txtMessage.Text = ""
		End Sub

		' Token: 0x060119C2 RID: 72130 RVA: 0x000794F9 File Offset: 0x000776F9
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060119C3 RID: 72131 RVA: 0x00079503 File Offset: 0x00077703
		Private Sub btnListofServices_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmServicesRecord1.Reset()
			MyProject.Forms.frmServicesRecord1.lblSet.Text = "Send SMS"
			MyProject.Forms.frmServicesRecord1.ShowDialog()
		End Sub

		' Token: 0x060119C4 RID: 72132 RVA: 0x00079540 File Offset: 0x00077740
		Private Sub frmSendSMS_Services_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x060119C5 RID: 72133 RVA: 0x00A33D08 File Offset: 0x00A31F08
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

		' Token: 0x060119C6 RID: 72134 RVA: 0x00A33FA8 File Offset: 0x00A321A8
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

		' Token: 0x060119C7 RID: 72135 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060119C8 RID: 72136 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSendSMS_Services_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006A4A RID: 27210
		Private st2 As String
	End Class
End Namespace
