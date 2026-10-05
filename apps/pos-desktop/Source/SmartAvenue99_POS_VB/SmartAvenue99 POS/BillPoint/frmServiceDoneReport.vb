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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005C8 RID: 1480
	<DesignerGenerated()>
	Public Partial Class frmServiceDoneReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012026 RID: 73766 RVA: 0x0007B710 File Offset: 0x00079910
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmServiceDoneReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmServiceDoneReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006FD8 RID: 28632
		' (get) Token: 0x06012029 RID: 73769 RVA: 0x0007B742 File Offset: 0x00079942
		' (set) Token: 0x0601202A RID: 73770 RVA: 0x0007B74C File Offset: 0x0007994C
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006FD9 RID: 28633
		' (get) Token: 0x0601202B RID: 73771 RVA: 0x0007B755 File Offset: 0x00079955
		' (set) Token: 0x0601202C RID: 73772 RVA: 0x0007B75F File Offset: 0x0007995F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006FDA RID: 28634
		' (get) Token: 0x0601202D RID: 73773 RVA: 0x0007B768 File Offset: 0x00079968
		' (set) Token: 0x0601202E RID: 73774 RVA: 0x0007B772 File Offset: 0x00079972
		Friend Overridable Property Label1 As Label

		' Token: 0x17006FDB RID: 28635
		' (get) Token: 0x0601202F RID: 73775 RVA: 0x0007B77B File Offset: 0x0007997B
		' (set) Token: 0x06012030 RID: 73776 RVA: 0x00A5FC70 File Offset: 0x00A5DE70
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

		' Token: 0x17006FDC RID: 28636
		' (get) Token: 0x06012031 RID: 73777 RVA: 0x0007B785 File Offset: 0x00079985
		' (set) Token: 0x06012032 RID: 73778 RVA: 0x0007B78F File Offset: 0x0007998F
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006FDD RID: 28637
		' (get) Token: 0x06012033 RID: 73779 RVA: 0x0007B798 File Offset: 0x00079998
		' (set) Token: 0x06012034 RID: 73780 RVA: 0x0007B7A2 File Offset: 0x000799A2
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006FDE RID: 28638
		' (get) Token: 0x06012035 RID: 73781 RVA: 0x0007B7AB File Offset: 0x000799AB
		' (set) Token: 0x06012036 RID: 73782 RVA: 0x0007B7B5 File Offset: 0x000799B5
		Friend Overridable Property Label2 As Label

		' Token: 0x17006FDF RID: 28639
		' (get) Token: 0x06012037 RID: 73783 RVA: 0x0007B7BE File Offset: 0x000799BE
		' (set) Token: 0x06012038 RID: 73784 RVA: 0x0007B7C8 File Offset: 0x000799C8
		Friend Overridable Property Label4 As Label

		' Token: 0x17006FE0 RID: 28640
		' (get) Token: 0x06012039 RID: 73785 RVA: 0x0007B7D1 File Offset: 0x000799D1
		' (set) Token: 0x0601203A RID: 73786 RVA: 0x0007B7DB File Offset: 0x000799DB
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006FE1 RID: 28641
		' (get) Token: 0x0601203B RID: 73787 RVA: 0x0007B7E4 File Offset: 0x000799E4
		' (set) Token: 0x0601203C RID: 73788 RVA: 0x00A5FCB4 File Offset: 0x00A5DEB4
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

		' Token: 0x17006FE2 RID: 28642
		' (get) Token: 0x0601203D RID: 73789 RVA: 0x0007B7EE File Offset: 0x000799EE
		' (set) Token: 0x0601203E RID: 73790 RVA: 0x00A5FCF8 File Offset: 0x00A5DEF8
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

		' Token: 0x0601203F RID: 73791 RVA: 0x00A5FD3C File Offset: 0x00A5DF3C
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x06012040 RID: 73792 RVA: 0x0007B7F8 File Offset: 0x000799F8
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
		End Sub

		' Token: 0x06012041 RID: 73793 RVA: 0x0007B813 File Offset: 0x00079A13
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06012042 RID: 73794 RVA: 0x0007B82F File Offset: 0x00079A2F
		Private Sub frmServiceDoneReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x06012043 RID: 73795 RVA: 0x00A5FE18 File Offset: 0x00A5E018
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

		' Token: 0x06012044 RID: 73796 RVA: 0x00A600B8 File Offset: 0x00A5E2B8
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

		' Token: 0x06012045 RID: 73797 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012046 RID: 73798 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmServiceDoneReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06012047 RID: 73799 RVA: 0x00A60174 File Offset: 0x00A5E374
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptServiceBilling As rptServiceBilling = New rptServiceBilling()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT * FROM Service INNER JOIN Customer ON Service.CustomerID = Customer.ID INNER JOIN InvoiceInfo1 ON Service.S_ID = InvoiceInfo1.ServiceID where InvoiceInfo1.InvoiceDate between @d1 and @d2 order by invoiceDate"
				sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "InvoiceInfo1")
				sqlDataAdapter.Fill(dataSet, "Service")
				sqlDataAdapter.Fill(dataSet, "Customer")
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptServiceBilling.SetDataSource(dataSet)
				rptServiceBilling.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
				rptServiceBilling.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
				rptServiceBilling.SetParameterValue("p3", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptServiceBilling
				MyProject.Forms.frmReport.ShowDialog()
				rptServiceBilling.Close()
				rptServiceBilling.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012048 RID: 73800 RVA: 0x0007B840 File Offset: 0x00079A40
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub
	End Class
End Namespace
