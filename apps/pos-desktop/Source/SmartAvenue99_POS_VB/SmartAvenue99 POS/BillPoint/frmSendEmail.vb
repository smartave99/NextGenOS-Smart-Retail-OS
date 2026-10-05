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
	' Token: 0x020004DA RID: 1242
	<DesignerGenerated()>
	Public Partial Class frmSendEmail
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FCEB RID: 64747 RVA: 0x0006EE11 File Offset: 0x0006D011
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSendSMS_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSendEmail_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170060B3 RID: 24755
		' (get) Token: 0x0600FCEE RID: 64750 RVA: 0x0006EE43 File Offset: 0x0006D043
		' (set) Token: 0x0600FCEF RID: 64751 RVA: 0x0006EE4D File Offset: 0x0006D04D
		Friend Overridable Property Label1 As Label

		' Token: 0x170060B4 RID: 24756
		' (get) Token: 0x0600FCF0 RID: 64752 RVA: 0x0006EE56 File Offset: 0x0006D056
		' (set) Token: 0x0600FCF1 RID: 64753 RVA: 0x0006EE60 File Offset: 0x0006D060
		Friend Overridable Property listView1 As ListView

		' Token: 0x170060B5 RID: 24757
		' (get) Token: 0x0600FCF2 RID: 64754 RVA: 0x0006EE69 File Offset: 0x0006D069
		' (set) Token: 0x0600FCF3 RID: 64755 RVA: 0x0006EE73 File Offset: 0x0006D073
		Friend Overridable Property columnHeader3 As ColumnHeader

		' Token: 0x170060B6 RID: 24758
		' (get) Token: 0x0600FCF4 RID: 64756 RVA: 0x0006EE7C File Offset: 0x0006D07C
		' (set) Token: 0x0600FCF5 RID: 64757 RVA: 0x0006EE86 File Offset: 0x0006D086
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x170060B7 RID: 24759
		' (get) Token: 0x0600FCF6 RID: 64758 RVA: 0x0006EE8F File Offset: 0x0006D08F
		' (set) Token: 0x0600FCF7 RID: 64759 RVA: 0x0006EE99 File Offset: 0x0006D099
		Friend Overridable Property txtBody As RichTextBox

		' Token: 0x170060B8 RID: 24760
		' (get) Token: 0x0600FCF8 RID: 64760 RVA: 0x0006EEA2 File Offset: 0x0006D0A2
		' (set) Token: 0x0600FCF9 RID: 64761 RVA: 0x0006EEAC File Offset: 0x0006D0AC
		Friend Overridable Property Label2 As Label

		' Token: 0x170060B9 RID: 24761
		' (get) Token: 0x0600FCFA RID: 64762 RVA: 0x0006EEB5 File Offset: 0x0006D0B5
		' (set) Token: 0x0600FCFB RID: 64763 RVA: 0x0006EEBF File Offset: 0x0006D0BF
		Friend Overridable Property Timer1 As Timer

		' Token: 0x170060BA RID: 24762
		' (get) Token: 0x0600FCFC RID: 64764 RVA: 0x0006EEC8 File Offset: 0x0006D0C8
		' (set) Token: 0x0600FCFD RID: 64765 RVA: 0x0097578C File Offset: 0x0097398C
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

		' Token: 0x170060BB RID: 24763
		' (get) Token: 0x0600FCFE RID: 64766 RVA: 0x0006EED2 File Offset: 0x0006D0D2
		' (set) Token: 0x0600FCFF RID: 64767 RVA: 0x0006EEDC File Offset: 0x0006D0DC
		Friend Overridable Property txtSubject As TextBox

		' Token: 0x170060BC RID: 24764
		' (get) Token: 0x0600FD00 RID: 64768 RVA: 0x0006EEE5 File Offset: 0x0006D0E5
		' (set) Token: 0x0600FD01 RID: 64769 RVA: 0x0006EEEF File Offset: 0x0006D0EF
		Friend Overridable Property Label3 As Label

		' Token: 0x170060BD RID: 24765
		' (get) Token: 0x0600FD02 RID: 64770 RVA: 0x0006EEF8 File Offset: 0x0006D0F8
		' (set) Token: 0x0600FD03 RID: 64771 RVA: 0x0006EF02 File Offset: 0x0006D102
		Friend Overridable Property txtFilePath As TextBox

		' Token: 0x170060BE RID: 24766
		' (get) Token: 0x0600FD04 RID: 64772 RVA: 0x0006EF0B File Offset: 0x0006D10B
		' (set) Token: 0x0600FD05 RID: 64773 RVA: 0x009757D0 File Offset: 0x009739D0
		Private _btnBrowse As Button
		Friend Overridable Property btnBrowse As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBrowse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBrowse_Click
				Dim button As Button = Me._btnBrowse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBrowse = value
				button = Me._btnBrowse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060BF RID: 24767
		' (get) Token: 0x0600FD06 RID: 64774 RVA: 0x0006EF15 File Offset: 0x0006D115
		' (set) Token: 0x0600FD07 RID: 64775 RVA: 0x0006EF1F File Offset: 0x0006D11F
		Friend Overridable Property Label4 As Label

		' Token: 0x170060C0 RID: 24768
		' (get) Token: 0x0600FD08 RID: 64776 RVA: 0x0006EF28 File Offset: 0x0006D128
		' (set) Token: 0x0600FD09 RID: 64777 RVA: 0x0006EF32 File Offset: 0x0006D132
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x170060C1 RID: 24769
		' (get) Token: 0x0600FD0A RID: 64778 RVA: 0x0006EF3B File Offset: 0x0006D13B
		' (set) Token: 0x0600FD0B RID: 64779 RVA: 0x00975814 File Offset: 0x00973A14
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

		' Token: 0x170060C2 RID: 24770
		' (get) Token: 0x0600FD0C RID: 64780 RVA: 0x0006EF45 File Offset: 0x0006D145
		' (set) Token: 0x0600FD0D RID: 64781 RVA: 0x00975858 File Offset: 0x00973A58
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

		' Token: 0x170060C3 RID: 24771
		' (get) Token: 0x0600FD0E RID: 64782 RVA: 0x0006EF4F File Offset: 0x0006D14F
		' (set) Token: 0x0600FD0F RID: 64783 RVA: 0x0097589C File Offset: 0x00973A9C
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

		' Token: 0x0600FD10 RID: 64784 RVA: 0x009758E0 File Offset: 0x00973AE0
		Public Sub Reset()
			Me.listView1.Items.Clear()
			Me.txtBody.Text = ""
			Me.txtSubject.Text = ""
			Me.txtFilePath.Text = ""
			Me.st1 = ""
			Me.GetData()
		End Sub

		' Token: 0x0600FD11 RID: 64785 RVA: 0x00975944 File Offset: 0x00973B44
		Public Sub GetData()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select distinct RTRIM(Name),RTRIM(EmailID) from Customer where EmailID is NOT NULL and EmailID <> '' order by 1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FD12 RID: 64786 RVA: 0x0006EF59 File Offset: 0x0006D159
		Private Sub frmSendSMS_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FD13 RID: 64787 RVA: 0x00975A84 File Offset: 0x00973C84
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

		' Token: 0x0600FD14 RID: 64788 RVA: 0x00975BFC File Offset: 0x00973DFC
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

		' Token: 0x0600FD15 RID: 64789 RVA: 0x00975CB8 File Offset: 0x00973EB8
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

		' Token: 0x0600FD16 RID: 64790 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FD17 RID: 64791 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FD18 RID: 64792 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FD19 RID: 64793 RVA: 0x0006EF6A File Offset: 0x0006D16A
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer2.Enabled = False
		End Sub

		' Token: 0x0600FD1A RID: 64794 RVA: 0x00975D84 File Offset: 0x00973F84
		Private Sub btnBrowse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "All Files |*.*;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim dialogResult As DialogResult = Me.OpenFileDialog1.ShowDialog()
				Dim flag As Boolean = dialogResult = DialogResult.OK
				If flag Then
					Me.txtFilePath.Text = Me.OpenFileDialog1.FileName
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600FD1B RID: 64795 RVA: 0x0006EF86 File Offset: 0x0006D186
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600FD1C RID: 64796 RVA: 0x00975E20 File Offset: 0x00974020
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtSubject.Text)) = 0
				If flag Then
					MessageBox.Show("Please enter subject", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSubject.Focus()
				Else
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtBody.Text)) = 0
					If flag2 Then
						MessageBox.Show("Please enter body", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtBody.Focus()
					Else
						Dim flag3 As Boolean = Me.listView1.Items.Count = 0
						If flag3 Then
							MessageBox.Show("Please retrieve customers list", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag4 As Boolean = Me.listView1.CheckedItems.Count = 0
							If flag4 Then
								MessageBox.Show("Please select at least one customer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								Dim flag5 As Boolean = ModFunc.CheckForInternetConnection()
								If flag5 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text As String = "select count(*) from EmailSetting Having count(*) <=0"
									ModCommonClasses.cmd = New SqlCommand(text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
									If flag6 Then
										Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag7 Then
											ModCommonClasses.rdr.Close()
										End If
										Return
									End If
									ModCommonClasses.con.Close()
									Me.Cursor = Cursors.WaitCursor
									Me.Timer2.Enabled = True
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
									If flag8 Then
										Dim num As Integer = Me.listView1.Items.Count - 1
										For i As Integer = 0 To num
											Dim checked As Boolean = Me.listView1.Items(i).Checked
											If checked Then
												Me.st1 = Me.st1 + Me.listView1.Items(i).SubItems(1).Text + ","
											End If
										Next
										Me.st1 = Me.st1.Trim().Remove(Me.st1.Length - 1)
										Dim flag9 As Boolean = Operators.CompareString(Me.txtFilePath.Text, "", False) = 0
										If flag9 Then
											ModFunc.SendMail(ModCommonClasses.rdr.GetValue(0).ToString(), Me.st1, Me.txtBody.Text, Me.txtSubject.Text, Conversions.ToString(ModCommonClasses.rdr.GetValue(2)), Conversions.ToInteger(ModCommonClasses.rdr.GetValue(3)), Conversions.ToString(ModCommonClasses.rdr.GetValue(0)), ModFunc.Decrypt(Conversions.ToString(ModCommonClasses.rdr.GetValue(1))))
										Else
											ModFunc.SendMail1(ModCommonClasses.rdr.GetValue(0).ToString(), Me.st1, Me.txtBody.Text, Me.txtFilePath.Text, Me.txtSubject.Text, Conversions.ToString(ModCommonClasses.rdr.GetValue(2)), Conversions.ToInteger(ModCommonClasses.rdr.GetValue(3)), Conversions.ToString(ModCommonClasses.rdr.GetValue(0)), ModFunc.Decrypt(Conversions.ToString(ModCommonClasses.rdr.GetValue(1))))
										End If
										MessageBox.Show("Successfully Email Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag10 Then
											ModCommonClasses.rdr.Close()
										End If
									End If
								End If
								Me.Reset()
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FD1D RID: 64797 RVA: 0x0097625C File Offset: 0x0097445C
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

		' Token: 0x0600FD1E RID: 64798 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSendEmail_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x040060E6 RID: 24806
		Private st1 As String

		' Token: 0x040060E7 RID: 24807
		Private st2 As String

		' Token: 0x040060E8 RID: 24808
		Private st3 As String
	End Class
End Namespace
