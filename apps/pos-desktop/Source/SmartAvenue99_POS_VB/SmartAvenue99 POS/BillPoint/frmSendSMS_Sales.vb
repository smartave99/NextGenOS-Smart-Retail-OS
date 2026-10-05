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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000578 RID: 1400
	<DesignerGenerated()>
	Public Partial Class frmSendSMS_Sales
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011063 RID: 69731 RVA: 0x000753D9 File Offset: 0x000735D9
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSendSMS_Sales_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSendSMS_Sales_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700699B RID: 27035
		' (get) Token: 0x06011066 RID: 69734 RVA: 0x0007540B File Offset: 0x0007360B
		' (set) Token: 0x06011067 RID: 69735 RVA: 0x00075415 File Offset: 0x00073615
		Friend Overridable Property Label1 As Label

		' Token: 0x1700699C RID: 27036
		' (get) Token: 0x06011068 RID: 69736 RVA: 0x0007541E File Offset: 0x0007361E
		' (set) Token: 0x06011069 RID: 69737 RVA: 0x00075428 File Offset: 0x00073628
		Friend Overridable Property lblUser As Label

		' Token: 0x1700699D RID: 27037
		' (get) Token: 0x0601106A RID: 69738 RVA: 0x00075431 File Offset: 0x00073631
		' (set) Token: 0x0601106B RID: 69739 RVA: 0x0007543B File Offset: 0x0007363B
		Friend Overridable Property Label10 As Label

		' Token: 0x1700699E RID: 27038
		' (get) Token: 0x0601106C RID: 69740 RVA: 0x00075444 File Offset: 0x00073644
		' (set) Token: 0x0601106D RID: 69741 RVA: 0x0007544E File Offset: 0x0007364E
		Friend Overridable Property txtMessage As TextBox

		' Token: 0x1700699F RID: 27039
		' (get) Token: 0x0601106E RID: 69742 RVA: 0x00075457 File Offset: 0x00073657
		' (set) Token: 0x0601106F RID: 69743 RVA: 0x00075461 File Offset: 0x00073661
		Friend Overridable Property Label7 As Label

		' Token: 0x170069A0 RID: 27040
		' (get) Token: 0x06011070 RID: 69744 RVA: 0x0007546A File Offset: 0x0007366A
		' (set) Token: 0x06011071 RID: 69745 RVA: 0x00075474 File Offset: 0x00073674
		Friend Overridable Property txtMobileNo As TextBox

		' Token: 0x170069A1 RID: 27041
		' (get) Token: 0x06011072 RID: 69746 RVA: 0x0007547D File Offset: 0x0007367D
		' (set) Token: 0x06011073 RID: 69747 RVA: 0x009E207C File Offset: 0x009E027C
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

		' Token: 0x170069A2 RID: 27042
		' (get) Token: 0x06011074 RID: 69748 RVA: 0x00075487 File Offset: 0x00073687
		' (set) Token: 0x06011075 RID: 69749 RVA: 0x009E20C0 File Offset: 0x009E02C0
		Private _btnGetSales As Button
		Friend Overridable Property btnGetSales As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetSales
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetSales_Click
				Dim button As Button = Me._btnGetSales
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetSales = value
				button = Me._btnGetSales
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170069A3 RID: 27043
		' (get) Token: 0x06011076 RID: 69750 RVA: 0x00075491 File Offset: 0x00073691
		' (set) Token: 0x06011077 RID: 69751 RVA: 0x009E2104 File Offset: 0x009E0304
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

		' Token: 0x170069A4 RID: 27044
		' (get) Token: 0x06011078 RID: 69752 RVA: 0x0007549B File Offset: 0x0007369B
		' (set) Token: 0x06011079 RID: 69753 RVA: 0x000754A5 File Offset: 0x000736A5
		Friend Overridable Property txtCompany As TextBox

		' Token: 0x170069A5 RID: 27045
		' (get) Token: 0x0601107A RID: 69754 RVA: 0x000754AE File Offset: 0x000736AE
		' (set) Token: 0x0601107B RID: 69755 RVA: 0x009E2148 File Offset: 0x009E0348
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

		' Token: 0x0601107C RID: 69756 RVA: 0x009E218C File Offset: 0x009E038C
		Public Sub GetCompany()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(CompanyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCompany.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0601107D RID: 69757 RVA: 0x009E227C File Offset: 0x009E047C
		Private Sub btnSend_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtMobileNo.Text)) = 0
				If flag Then
					MessageBox.Show("Please Enter Mobile No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtMobileNo.Focus()
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
								ModFunc.SMSFunc(Me.txtMobileNo.Text, Me.txtMessage.Text, Me.st2)
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

		' Token: 0x0601107E RID: 69758 RVA: 0x000754B8 File Offset: 0x000736B8
		Public Sub Reset()
			Me.txtMobileNo.Text = ""
			Me.txtMessage.Text = ""
			Me.txtMobileNo.Focus()
			Me.GetCompany()
		End Sub

		' Token: 0x0601107F RID: 69759 RVA: 0x000754F0 File Offset: 0x000736F0
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011080 RID: 69760 RVA: 0x000754FA File Offset: 0x000736FA
		Private Sub frmSendSMS_Sales_Load(sender As Object, e As EventArgs)
			Me.GetCompany()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011081 RID: 69761 RVA: 0x009E2454 File Offset: 0x009E0654
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

		' Token: 0x06011082 RID: 69762 RVA: 0x009E25CC File Offset: 0x009E07CC
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

		' Token: 0x06011083 RID: 69763 RVA: 0x009E2688 File Offset: 0x009E0888
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

		' Token: 0x06011084 RID: 69764 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011085 RID: 69765 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011086 RID: 69766 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011087 RID: 69767 RVA: 0x009E2754 File Offset: 0x009E0954
		Private Sub btnGetSales_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from InvoiceInfo where Day(InvoiceDate)=Day(GetDate()) and Month(InvoiceDate)=Month(GetDate()) and Year(InvoiceDate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtMessage.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Hi,Today's total sales of " + Me.txtCompany.Text + " is ", ModCommonClasses.rdr.GetValue(0)), ""))
					Me.txtMobileNo.Focus()
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011088 RID: 69768 RVA: 0x009E2868 File Offset: 0x009E0A68
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(Invoice_Payment.TotalPaid),0) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and Day(InvoiceDate)=Day(GetDate()) and Month(InvoiceDate)=Month(GetDate()) and Year(InvoiceDate)=Year(GetDate()) and Invoice_Payment.PaymentMode='By Cash'"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtMessage.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Hi,Today's total cash sales of " + Me.txtCompany.Text + " is ", ModCommonClasses.rdr.GetValue(0)), ""))
					Me.txtMobileNo.Focus()
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011089 RID: 69769 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSendSMS_Sales_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006668 RID: 26216
		Private st2 As String
	End Class
End Namespace
