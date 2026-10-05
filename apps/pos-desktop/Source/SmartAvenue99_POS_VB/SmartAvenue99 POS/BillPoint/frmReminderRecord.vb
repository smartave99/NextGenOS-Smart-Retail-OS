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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000365 RID: 869
	<DesignerGenerated()>
	Public Partial Class frmReminderRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CE50 RID: 52816 RVA: 0x0005BBF7 File Offset: 0x00059DF7
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmReminderRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmReminderRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700510C RID: 20748
		' (get) Token: 0x0600CE53 RID: 52819 RVA: 0x0005BC29 File Offset: 0x00059E29
		' (set) Token: 0x0600CE54 RID: 52820 RVA: 0x0005BC33 File Offset: 0x00059E33
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700510D RID: 20749
		' (get) Token: 0x0600CE55 RID: 52821 RVA: 0x0005BC3C File Offset: 0x00059E3C
		' (set) Token: 0x0600CE56 RID: 52822 RVA: 0x0005BC46 File Offset: 0x00059E46
		Friend Overridable Property Label2 As Label

		' Token: 0x1700510E RID: 20750
		' (get) Token: 0x0600CE57 RID: 52823 RVA: 0x0005BC4F File Offset: 0x00059E4F
		' (set) Token: 0x0600CE58 RID: 52824 RVA: 0x0005BC59 File Offset: 0x00059E59
		Friend Overridable Property Panel8 As Panel

		' Token: 0x1700510F RID: 20751
		' (get) Token: 0x0600CE59 RID: 52825 RVA: 0x0005BC62 File Offset: 0x00059E62
		' (set) Token: 0x0600CE5A RID: 52826 RVA: 0x0005BC6C File Offset: 0x00059E6C
		Friend Overridable Property Label8 As Label

		' Token: 0x17005110 RID: 20752
		' (get) Token: 0x0600CE5B RID: 52827 RVA: 0x0005BC75 File Offset: 0x00059E75
		' (set) Token: 0x0600CE5C RID: 52828 RVA: 0x0005BC7F File Offset: 0x00059E7F
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005111 RID: 20753
		' (get) Token: 0x0600CE5D RID: 52829 RVA: 0x0005BC88 File Offset: 0x00059E88
		' (set) Token: 0x0600CE5E RID: 52830 RVA: 0x0005BC92 File Offset: 0x00059E92
		Friend Overridable Property Label1 As Label

		' Token: 0x17005112 RID: 20754
		' (get) Token: 0x0600CE5F RID: 52831 RVA: 0x0005BC9B File Offset: 0x00059E9B
		' (set) Token: 0x0600CE60 RID: 52832 RVA: 0x0005BCA5 File Offset: 0x00059EA5
		Friend Overridable Property Label4 As Label

		' Token: 0x17005113 RID: 20755
		' (get) Token: 0x0600CE61 RID: 52833 RVA: 0x0005BCAE File Offset: 0x00059EAE
		' (set) Token: 0x0600CE62 RID: 52834 RVA: 0x0005BCB8 File Offset: 0x00059EB8
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005114 RID: 20756
		' (get) Token: 0x0600CE63 RID: 52835 RVA: 0x0005BCC1 File Offset: 0x00059EC1
		' (set) Token: 0x0600CE64 RID: 52836 RVA: 0x0005BCCB File Offset: 0x00059ECB
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005115 RID: 20757
		' (get) Token: 0x0600CE65 RID: 52837 RVA: 0x0005BCD4 File Offset: 0x00059ED4
		' (set) Token: 0x0600CE66 RID: 52838 RVA: 0x0080E1C0 File Offset: 0x0080C3C0
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005116 RID: 20758
		' (get) Token: 0x0600CE67 RID: 52839 RVA: 0x0005BCDE File Offset: 0x00059EDE
		' (set) Token: 0x0600CE68 RID: 52840 RVA: 0x0005BCE8 File Offset: 0x00059EE8
		Friend Overridable Property txtID As TextBox

		' Token: 0x17005117 RID: 20759
		' (get) Token: 0x0600CE69 RID: 52841 RVA: 0x0005BCF1 File Offset: 0x00059EF1
		' (set) Token: 0x0600CE6A RID: 52842 RVA: 0x0005BCFB File Offset: 0x00059EFB
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005118 RID: 20760
		' (get) Token: 0x0600CE6B RID: 52843 RVA: 0x0005BD04 File Offset: 0x00059F04
		' (set) Token: 0x0600CE6C RID: 52844 RVA: 0x0005BD0E File Offset: 0x00059F0E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005119 RID: 20761
		' (get) Token: 0x0600CE6D RID: 52845 RVA: 0x0005BD17 File Offset: 0x00059F17
		' (set) Token: 0x0600CE6E RID: 52846 RVA: 0x0005BD21 File Offset: 0x00059F21
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700511A RID: 20762
		' (get) Token: 0x0600CE6F RID: 52847 RVA: 0x0005BD2A File Offset: 0x00059F2A
		' (set) Token: 0x0600CE70 RID: 52848 RVA: 0x0005BD34 File Offset: 0x00059F34
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700511B RID: 20763
		' (get) Token: 0x0600CE71 RID: 52849 RVA: 0x0005BD3D File Offset: 0x00059F3D
		' (set) Token: 0x0600CE72 RID: 52850 RVA: 0x0005BD47 File Offset: 0x00059F47
		Friend Overridable Property lblUser As Label

		' Token: 0x1700511C RID: 20764
		' (get) Token: 0x0600CE73 RID: 52851 RVA: 0x0005BD50 File Offset: 0x00059F50
		' (set) Token: 0x0600CE74 RID: 52852 RVA: 0x0080E220 File Offset: 0x0080C420
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700511D RID: 20765
		' (get) Token: 0x0600CE75 RID: 52853 RVA: 0x0005BD5A File Offset: 0x00059F5A
		' (set) Token: 0x0600CE76 RID: 52854 RVA: 0x0080E264 File Offset: 0x0080C464
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

		' Token: 0x1700511E RID: 20766
		' (get) Token: 0x0600CE77 RID: 52855 RVA: 0x0005BD64 File Offset: 0x00059F64
		' (set) Token: 0x0600CE78 RID: 52856 RVA: 0x0080E2A8 File Offset: 0x0080C4A8
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700511F RID: 20767
		' (get) Token: 0x0600CE79 RID: 52857 RVA: 0x0005BD6E File Offset: 0x00059F6E
		' (set) Token: 0x0600CE7A RID: 52858 RVA: 0x0080E2EC File Offset: 0x0080C4EC
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

		' Token: 0x17005120 RID: 20768
		' (get) Token: 0x0600CE7B RID: 52859 RVA: 0x0005BD78 File Offset: 0x00059F78
		' (set) Token: 0x0600CE7C RID: 52860 RVA: 0x0080E330 File Offset: 0x0080C530
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600CE7D RID: 52861 RVA: 0x0080E374 File Offset: 0x0080C574
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

		' Token: 0x0600CE7E RID: 52862 RVA: 0x0080E450 File Offset: 0x0080C650
		Private Sub frmReminderRecord_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Button2.Enabled = False
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CE7F RID: 52863 RVA: 0x0080E4EC File Offset: 0x0080C6EC
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

		' Token: 0x0600CE80 RID: 52864 RVA: 0x0080E664 File Offset: 0x0080C864
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

		' Token: 0x0600CE81 RID: 52865 RVA: 0x0080E720 File Offset: 0x0080C920
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

		' Token: 0x0600CE82 RID: 52866 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CE83 RID: 52867 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CE84 RID: 52868 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CE85 RID: 52869 RVA: 0x0080E7EC File Offset: 0x0080C9EC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID, mdate, msg from Reminder where mdate between @d1 and @d2 order by mdate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CE86 RID: 52870 RVA: 0x0005BD82 File Offset: 0x00059F82
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Now
			Me.Getdata()
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600CE87 RID: 52871 RVA: 0x0080E964 File Offset: 0x0080CB64
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.Button2.Enabled = True
				Else
					Me.Button2.Enabled = False
					MessageBox.Show("Reminder Message record is empty", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CE88 RID: 52872 RVA: 0x0080EA14 File Offset: 0x0080CC14
		Public Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from Reminder where ID=" + Me.txtID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag Then
					ModCommonClasses.con.Close()
				End If
				Dim flag2 As Boolean = num > 0
				If flag2 Then
					Dim text2 As String = "deleted the reminder message having id no.'" + Me.txtID.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CE89 RID: 52873 RVA: 0x0080EB58 File Offset: 0x0080CD58
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

		' Token: 0x0600CE8A RID: 52874 RVA: 0x0080EC40 File Offset: 0x0080CE40
		Public Sub DeleteRecordAll()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Reminder"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag Then
					ModCommonClasses.con.Close()
				End If
				Dim flag2 As Boolean = num > 0
				If flag2 Then
					Dim text2 As String = "deleted the all reminder messages"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted All Message", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CE8B RID: 52875 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmReminderRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CE8C RID: 52876 RVA: 0x0005BDB1 File Offset: 0x00059FB1
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600CE8D RID: 52877 RVA: 0x0080ED54 File Offset: 0x0080CF54
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CE8E RID: 52878 RVA: 0x0080F000 File Offset: 0x0080D200
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CE8F RID: 52879 RVA: 0x0080F068 File Offset: 0x0080D268
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete all records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecordAll()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CE90 RID: 52880 RVA: 0x0080E7EC File Offset: 0x0080C9EC
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID, mdate, msg from Reminder where mdate between @d1 and @d2 order by mdate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
