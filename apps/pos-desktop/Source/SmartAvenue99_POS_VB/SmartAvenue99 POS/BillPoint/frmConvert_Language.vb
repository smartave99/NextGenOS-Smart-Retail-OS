Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports DevNet
Imports DevNetSR
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000D2 RID: 210
	<DesignerGenerated()>
	Public Partial Class frmConvert_Language
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002580 RID: 9600 RVA: 0x00019247 File Offset: 0x00017447
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmConvert_Language_Load
			Me.dtOtherlang = New DataTable()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000ECF RID: 3791
		' (get) Token: 0x06002583 RID: 9603 RVA: 0x00019275 File Offset: 0x00017475
		' (set) Token: 0x06002584 RID: 9604 RVA: 0x0001927F File Offset: 0x0001747F
		Friend Overridable Property Label4 As Label

		' Token: 0x17000ED0 RID: 3792
		' (get) Token: 0x06002585 RID: 9605 RVA: 0x00019288 File Offset: 0x00017488
		' (set) Token: 0x06002586 RID: 9606 RVA: 0x00019292 File Offset: 0x00017492
		Friend Overridable Property Label2 As Label

		' Token: 0x17000ED1 RID: 3793
		' (get) Token: 0x06002587 RID: 9607 RVA: 0x0001929B File Offset: 0x0001749B
		' (set) Token: 0x06002588 RID: 9608 RVA: 0x0017D450 File Offset: 0x0017B650
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

		' Token: 0x17000ED2 RID: 3794
		' (get) Token: 0x06002589 RID: 9609 RVA: 0x000192A5 File Offset: 0x000174A5
		' (set) Token: 0x0600258A RID: 9610 RVA: 0x000192AF File Offset: 0x000174AF
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17000ED3 RID: 3795
		' (get) Token: 0x0600258B RID: 9611 RVA: 0x000192B8 File Offset: 0x000174B8
		' (set) Token: 0x0600258C RID: 9612 RVA: 0x0017D494 File Offset: 0x0017B694
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox2_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.TextBox2_Leave
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000ED4 RID: 3796
		' (get) Token: 0x0600258D RID: 9613 RVA: 0x000192C2 File Offset: 0x000174C2
		' (set) Token: 0x0600258E RID: 9614 RVA: 0x000192CC File Offset: 0x000174CC
		Friend Overridable Property Label1 As Label

		' Token: 0x17000ED5 RID: 3797
		' (get) Token: 0x0600258F RID: 9615 RVA: 0x000192D5 File Offset: 0x000174D5
		' (set) Token: 0x06002590 RID: 9616 RVA: 0x0017D510 File Offset: 0x0017B710
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000ED6 RID: 3798
		' (get) Token: 0x06002591 RID: 9617 RVA: 0x000192DF File Offset: 0x000174DF
		' (set) Token: 0x06002592 RID: 9618 RVA: 0x000192E9 File Offset: 0x000174E9
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17000ED7 RID: 3799
		' (get) Token: 0x06002593 RID: 9619 RVA: 0x000192F2 File Offset: 0x000174F2
		' (set) Token: 0x06002594 RID: 9620 RVA: 0x0017D554 File Offset: 0x0017B754
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

		' Token: 0x17000ED8 RID: 3800
		' (get) Token: 0x06002595 RID: 9621 RVA: 0x000192FC File Offset: 0x000174FC
		' (set) Token: 0x06002596 RID: 9622 RVA: 0x0017D598 File Offset: 0x0017B798
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000ED9 RID: 3801
		' (get) Token: 0x06002597 RID: 9623 RVA: 0x00019306 File Offset: 0x00017506
		' (set) Token: 0x06002598 RID: 9624 RVA: 0x00019310 File Offset: 0x00017510
		Friend Overridable Property Lang_hin As DataGridViewTextBoxColumn

		' Token: 0x17000EDA RID: 3802
		' (get) Token: 0x06002599 RID: 9625 RVA: 0x00019319 File Offset: 0x00017519
		' (set) Token: 0x0600259A RID: 9626 RVA: 0x00019323 File Offset: 0x00017523
		Friend Overridable Property Label3 As Label

		' Token: 0x17000EDB RID: 3803
		' (get) Token: 0x0600259B RID: 9627 RVA: 0x0001932C File Offset: 0x0001752C
		' (set) Token: 0x0600259C RID: 9628 RVA: 0x00019336 File Offset: 0x00017536
		Friend Overridable Property Other_lang2 As DataGridViewTextBoxColumn

		' Token: 0x17000EDC RID: 3804
		' (get) Token: 0x0600259D RID: 9629 RVA: 0x0001933F File Offset: 0x0001753F
		' (set) Token: 0x0600259E RID: 9630 RVA: 0x00019349 File Offset: 0x00017549
		Friend Overridable Property id As DataGridViewTextBoxColumn

		' Token: 0x17000EDD RID: 3805
		' (get) Token: 0x0600259F RID: 9631 RVA: 0x00019352 File Offset: 0x00017552
		' (set) Token: 0x060025A0 RID: 9632 RVA: 0x0017D5DC File Offset: 0x0017B7DC
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellContentClick
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EDE RID: 3806
		' (get) Token: 0x060025A1 RID: 9633 RVA: 0x0001935C File Offset: 0x0001755C
		' (set) Token: 0x060025A2 RID: 9634 RVA: 0x00019366 File Offset: 0x00017566
		Friend Overridable Property English_lang2 As DataGridViewTextBoxColumn

		' Token: 0x17000EDF RID: 3807
		' (get) Token: 0x060025A3 RID: 9635 RVA: 0x0001936F File Offset: 0x0001756F
		' (set) Token: 0x060025A4 RID: 9636 RVA: 0x00019379 File Offset: 0x00017579
		Friend Overridable Property LblLanguage As Label

		' Token: 0x17000EE0 RID: 3808
		' (get) Token: 0x060025A5 RID: 9637 RVA: 0x00019382 File Offset: 0x00017582
		' (set) Token: 0x060025A6 RID: 9638 RVA: 0x0001938C File Offset: 0x0001758C
		Friend Overridable Property checkMark As DataGridViewCheckBoxColumn

		' Token: 0x17000EE1 RID: 3809
		' (get) Token: 0x060025A7 RID: 9639 RVA: 0x00019395 File Offset: 0x00017595
		' (set) Token: 0x060025A8 RID: 9640 RVA: 0x0001939F File Offset: 0x0001759F
		Friend Overridable Property Other_lang As DataGridViewTextBoxColumn

		' Token: 0x17000EE2 RID: 3810
		' (get) Token: 0x060025A9 RID: 9641 RVA: 0x000193A8 File Offset: 0x000175A8
		' (set) Token: 0x060025AA RID: 9642 RVA: 0x000193B2 File Offset: 0x000175B2
		Friend Overridable Property English_lang As DataGridViewTextBoxColumn

		' Token: 0x17000EE3 RID: 3811
		' (get) Token: 0x060025AB RID: 9643 RVA: 0x000193BB File Offset: 0x000175BB
		' (set) Token: 0x060025AC RID: 9644 RVA: 0x0017D620 File Offset: 0x0017B820
		Private _CheckBox1 As CheckBox
		Friend Overridable Property CheckBox1 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox1_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox1 = value
				checkBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EE4 RID: 3812
		' (get) Token: 0x060025AD RID: 9645 RVA: 0x000193C5 File Offset: 0x000175C5
		' (set) Token: 0x060025AE RID: 9646 RVA: 0x0017D664 File Offset: 0x0017B864
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EE5 RID: 3813
		' (get) Token: 0x060025AF RID: 9647 RVA: 0x000193CF File Offset: 0x000175CF
		' (set) Token: 0x060025B0 RID: 9648 RVA: 0x0017D6A8 File Offset: 0x0017B8A8
		Private _LinkLabel3 As LinkLabel
		Friend Overridable Property LinkLabel3 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel3_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel3 = value
				linkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EE6 RID: 3814
		' (get) Token: 0x060025B1 RID: 9649 RVA: 0x000193D9 File Offset: 0x000175D9
		' (set) Token: 0x060025B2 RID: 9650 RVA: 0x000193E3 File Offset: 0x000175E3
		Friend Overridable Property cBoxLangs As ComboBox

		' Token: 0x17000EE7 RID: 3815
		' (get) Token: 0x060025B3 RID: 9651 RVA: 0x000193EC File Offset: 0x000175EC
		' (set) Token: 0x060025B4 RID: 9652 RVA: 0x0017D6EC File Offset: 0x0017B8EC
		Private _Button8 As Button
		Friend Overridable Property Button8 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button8_Click
				Dim button As Button = Me._Button8
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button8 = value
				button = Me._Button8
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EE8 RID: 3816
		' (get) Token: 0x060025B5 RID: 9653 RVA: 0x000193F6 File Offset: 0x000175F6
		' (set) Token: 0x060025B6 RID: 9654 RVA: 0x00019400 File Offset: 0x00017600
		Public Property ReceivedDataTable As DataTable

		' Token: 0x060025B7 RID: 9655 RVA: 0x0017D730 File Offset: 0x0017B930
		Private Sub frmConvert_Language_Load(sender As Object, e As EventArgs)
			Me.LblLanguage.Text = Configuration.defaultLanguage()
			Dim flag As Boolean = Me.dtOtherlang.Columns.Count = 0
			If flag Then
				Me.dtOtherlang.Columns.Add("English_lang", GetType(String))
				Me.dtOtherlang.Columns.Add("Other_lang", GetType(String))
			End If
			Me.DataGridView1.DataSource = Me.ReceivedDataTable
			Dim list As List(Of Language) = [Enum].GetValues(GetType(Language)).Cast(Of Language)().ToList()
			Me.cBoxLangs.DataSource = list
			Me.cBoxLangs.Text = "Hindi"
		End Sub

		' Token: 0x060025B8 RID: 9656 RVA: 0x0017D7F4 File Offset: 0x0017B9F4
		Public Sub loadAll()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Try
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT id, default_lang_eng as English_lang2, other_lang as Other_lang2, lang_hin FROM Language_set order by id desc"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataTable As DataTable = New DataTable()
				sqlDataAdapter.Fill(dataTable)
				Me.DataGridView2.DataSource = dataTable
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag As Boolean = ModCommonClasses.con IsNot Nothing AndAlso ModCommonClasses.con.State = ConnectionState.Open
				If flag Then
					ModCommonClasses.con.Close()
				End If
			End Try
		End Sub

		' Token: 0x060025B9 RID: 9657 RVA: 0x0017D8D4 File Offset: 0x0017BAD4
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("checkMark").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewCheckBoxCell As DataGridViewCheckBoxCell = CType(Me.DataGridView1.Rows(e.RowIndex).Cells("checkMark"), DataGridViewCheckBoxCell)
				dataGridViewCheckBoxCell.Value = Not Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataGridViewCheckBoxCell.Value))
			End If
		End Sub

		' Token: 0x060025BA RID: 9658 RVA: 0x0017D964 File Offset: 0x0017BB64
		Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Internet connection not found", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Me.cBoxLangs.SelectedIndex = -1
				If flag2 Then
					MessageBox.Show("Please select correct language", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cBoxLangs.Focus()
				Else
					Me.dtOtherlang.Clear()
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag3 As Boolean = Not dataGridViewRow.IsNewRow
							If flag3 Then
								Dim text As String = (If(dataGridViewRow.Cells("English_lang").Value, "")).ToString().Trim()
								Dim text2 As String = (If(dataGridViewRow.Cells("English_lang").Value, "")).ToString().Trim()
								Dim flag4 As Boolean = Not String.IsNullOrEmpty(text)
								If flag4 Then
									text = Regex.Replace(text, "[\\\/!@#$%^&*()_+=\[{\]};:'""|<>,.?`~]", String.Empty)
									text = Regex.Replace(text, "\s+", " ")
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "select * from Language_set where default_lang_eng=@d1"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", text2)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag5 As Boolean = Not ModCommonClasses.rdr.Read()
									If flag5 Then
										Dim array As DataRow() = Me.dtOtherlang.[Select](String.Format("English_lang = '{0}'", text.Replace("'", "''")))
										Dim flag6 As Boolean = array.Length = 0
										If flag6 Then
											Dim array2 As String() = text.Split(New Char() { " "c })
											Dim list As List(Of String) = New List(Of String)()
											For Each text4 As String In array2
												Dim flag7 As Boolean = Not String.IsNullOrEmpty(text4)
												If flag7 Then
													Try
														Dim language As Language = LanguageExtensions.FromName(Me.cBoxLangs.Text)
														Dim response As Response = Translitration.Instance.DoWork(text4, language)
														Dim success As Boolean = response.Success
														If success Then
															Dim result As String() = response.Result
															list.Add(result(0))
														Else
															list.Add(text4)
														End If
													Catch ex As Exception
														MessageBox.Show(String.Format("Error transliterating '{0}': {1}", text4, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
														list.Add(text4)
													End Try
												End If
											Next
											Me.dtOtherlang.Rows.Add(New Object() { text2, String.Join(" ", list) })
										End If
									End If
									Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag8 Then
										ModCommonClasses.rdr.Close()
									End If
								End If
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Me.DataGridView1.DataSource = Nothing
					Me.DataGridView1.DataSource = Me.dtOtherlang
					Me.CheckBox1.Enabled = True
					Me.Button8.Enabled = True
				End If
			End If
		End Sub

		' Token: 0x060025BB RID: 9659 RVA: 0x0017DD1C File Offset: 0x0017BF1C
		Private Sub Button8_Click(sender As Object, e As EventArgs)
			Dim dataTable As DataTable = Me.dtOtherlang.Clone()
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Not dataGridViewRow.IsNewRow
					If flag Then
						Dim flag2 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("checkMark").Value))
						Dim flag3 As Boolean = flag2
						If flag3 Then
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "INSERT INTO Language_set(default_lang_eng, other_lang, lang_hin) VALUES (@d1, @d2, @d3)"
								ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells("English_lang").Value.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells("Other_lang").Value.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cBoxLangs.Text.ToString())
								ModCommonClasses.cmd.ExecuteNonQuery()
							Catch ex As Exception
								MessageBox.Show("Error: " + ex.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Finally
								Dim flag4 As Boolean = ModCommonClasses.con IsNot Nothing AndAlso ModCommonClasses.con.State = ConnectionState.Open
								If flag4 Then
									ModCommonClasses.con.Close()
								End If
							End Try
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			MessageBox.Show("Data Inserted Succesfully!")
			Try
				For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
					Dim flag5 As Boolean = Not dataGridViewRow2.IsNewRow
					If flag5 Then
						Dim flag6 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("checkMark").Value))
						Dim flag7 As Boolean = flag6
						If flag7 Then
							Dim dataRow As DataRow = dataTable.NewRow()
							Try
								For Each obj3 As Object In Me.dtOtherlang.Columns
									Dim dataColumn As DataColumn = CType(obj3, DataColumn)
									dataRow(dataColumn.ColumnName) = RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(dataColumn.ColumnName).Value)
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
							dataTable.Rows.Add(dataRow)
						End If
					End If
				Next
			Finally
				Dim enumerator2 As IEnumerator
				If TypeOf enumerator2 Is IDisposable Then
					TryCast(enumerator2, IDisposable).Dispose()
				End If
			End Try
			Me.DataGridView1.DataSource = Nothing
			Me.DataGridView1.DataSource = dataTable
			Me.loadAll()
			Me.CheckBox1.Enabled = False
			Me.Button8.Enabled = False
		End Sub

		' Token: 0x060025BC RID: 9660 RVA: 0x0017E0C0 File Offset: 0x0017C2C0
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Not dataGridViewRow.IsNewRow
					If flag Then
						dataGridViewRow.Cells("checkMark").Value = Me.CheckBox1.Checked
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060025BD RID: 9661 RVA: 0x0017E154 File Offset: 0x0017C354
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.DataGridView2.Columns.Count = 0) Or (Me.DataGridView2.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView2.Columns
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
						For Each obj2 As Object In CType(Me.DataGridView2.Rows, IEnumerable)
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

		' Token: 0x060025BE RID: 9662 RVA: 0x0017E400 File Offset: 0x0017C600
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Excel Files|*.xlsx"
			openFileDialog.Title = "Select an Excel File"
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Try
					Dim dataTable As DataTable = New DataTable()
					Using xlworkbook As XLWorkbook = New XLWorkbook(openFileDialog.FileName)
						Dim ixlworksheet As IXLWorksheet = xlworkbook.Worksheets.First()
						Try
							For Each ixlcell As IXLCell In ixlworksheet.Row(1).Cells()
								dataTable.Columns.Add(ixlcell.Value.ToString())
							Next
						Finally
							Dim enumerator As IEnumerator(Of IXLCell)
							If enumerator IsNot Nothing Then
								enumerator.Dispose()
							End If
						End Try
						Try
							For Each ixlrow As IXLRow In ixlworksheet.RowsUsed(XLCellsUsedOptions.AllContents, Nothing).Skip(1)
								Dim dataRow As DataRow = dataTable.NewRow()
								Dim num As Integer = dataTable.Columns.Count - 1
								For i As Integer = 0 To num
									dataRow(i) = If((ixlrow.Cell(i + 1).Value IsNot Nothing), ixlrow.Cell(i + 1).Value.ToString(), String.Empty)
								Next
								dataTable.Rows.Add(dataRow)
							Next
						Finally
							Dim enumerator2 As IEnumerator(Of IXLRow)
							If enumerator2 IsNot Nothing Then
								enumerator2.Dispose()
							End If
						End Try
					End Using
					Try
						For Each obj As Object In dataTable.Rows
							Dim dataRow2 As DataRow = CType(obj, DataRow)
							Dim flag2 As Boolean = dataRow2.RowState <> DataRowState.Detached
							If flag2 Then
								Try
									Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
										sqlConnection.Open()
										Dim text As String = "SELECT COUNT(*) FROM Language_set WHERE default_lang_eng = @d1 AND other_lang = @d2 AND lang_hin = @d3"
										Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
											sqlCommand.Parameters.AddWithValue("@d1", dataRow2("Englsih").ToString())
											sqlCommand.Parameters.AddWithValue("@d2", dataRow2("Other Language").ToString())
											sqlCommand.Parameters.AddWithValue("@d3", dataRow2("Language_code").ToString())
											Dim num2 As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
											Dim flag3 As Boolean = num2 >= 0
											If flag3 Then
												Dim text2 As String = "INSERT INTO Language_set (default_lang_eng, other_lang, lang_hin) VALUES (@d1, @d2, @d3)"
												Using sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection)
													sqlCommand2.Parameters.AddWithValue("@d1", dataRow2("Englsih").ToString())
													sqlCommand2.Parameters.AddWithValue("@d2", dataRow2("Other Language").ToString())
													sqlCommand2.Parameters.AddWithValue("@d3", dataRow2("Language_code").ToString())
													sqlCommand2.ExecuteNonQuery()
												End Using
											End If
										End Using
									End Using
								Catch ex As Exception
									MessageBox.Show("Error: " + ex.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						Next
					Finally
						Dim enumerator3 As IEnumerator
						If TypeOf enumerator3 Is IDisposable Then
							TryCast(enumerator3, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Data imported Succesfully!")
					Me.loadAll()
				Catch ex2 As Exception
					MessageBox.Show("Import Unsuccessful: " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060025BF RID: 9663 RVA: 0x0017E894 File Offset: 0x0017CA94
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Try
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
				Dim text As String
				If flag Then
					text = "SELECT id, default_lang_eng as English_lang2, other_lang as Other_lang2, lang_hin FROM Language_set Where default_lang_eng like '" + Me.TextBox1.Text.ToString() + "%' order by id desc"
				Else
					text = "SELECT top 5 id, default_lang_eng as English_lang2, other_lang as Other_lang2, lang_hin FROM Language_set Where default_lang_eng like '" + Me.TextBox1.Text.ToString() + "%' order by id desc"
				End If
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataTable As DataTable = New DataTable()
				sqlDataAdapter.Fill(dataTable)
				Me.DataGridView2.DataSource = dataTable
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = ModCommonClasses.con IsNot Nothing AndAlso ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			End Try
		End Sub

		' Token: 0x060025C0 RID: 9664 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060025C1 RID: 9665 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextBox2_Leave(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060025C2 RID: 9666 RVA: 0x0017E9D4 File Offset: 0x0017CBD4
		Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = e.RowIndex >= 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
					Me.Label4.Text = dataGridViewRow.Cells("id").Value.ToString()
					Me.TextBox2.Text = dataGridViewRow.Cells("English_lang2").Value.ToString()
					Me.TextBox3.Text = dataGridViewRow.Cells("Other_lang2").Value.ToString()
					Me.cBoxLangs.Text = dataGridViewRow.Cells("Lang_hin").Value.ToString()
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.TextBox2.Enabled = True
			Me.cBoxLangs.Enabled = False
			Me.Button1.Text = "Update"
		End Sub

		' Token: 0x060025C3 RID: 9667 RVA: 0x0017EB14 File Offset: 0x0017CD14
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox2.Enabled = True
			Me.cBoxLangs.Enabled = True
			Dim flag As Boolean = (Operators.CompareString(Me.TextBox2.Text.ToString(), "", False) <> 0) And (Operators.CompareString(Me.TextBox3.Text.ToString(), "", False) <> 0)
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.Label4.Text, "", False) = 0
				If flag2 Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "insert into Language_set(default_lang_eng,other_lang, lang_hin) VALUES (@d1,@d2,@d3)"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox2.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox3.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cBoxLangs.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "update Language_set set other_lang=@d1 where id=@d2"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox3.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.Label4.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
				Me.TextBox2.Text = ""
				Me.TextBox3.Text = ""
				Me.Label4.Text = ""
				Me.Button1.Text = "Save"
				Me.loadAll()
				Me.TextBox2.Focus()
			End If
		End Sub

		' Token: 0x060025C4 RID: 9668 RVA: 0x0017ED6C File Offset: 0x0017CF6C
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Try
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
				Dim text As String
				If flag Then
					text = String.Concat(New String() { "SELECT id, default_lang_eng as English_lang2, other_lang as Other_lang2, lang_hin FROM Language_set Where lang_hin= '", Me.cBoxLangs.Text.ToString(), "' and default_lang_eng like '", Me.TextBox2.Text.ToString(), "%' order by id desc" })
				Else
					text = String.Concat(New String() { "SELECT top 5 id, default_lang_eng as English_lang2, other_lang as Other_lang2, lang_hin FROM Language_set Where lang_hin= '", Me.cBoxLangs.Text.ToString(), "' and  default_lang_eng like '", Me.TextBox2.Text.ToString(), "%' order by id desc" })
				End If
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataTable As DataTable = New DataTable()
				sqlDataAdapter.Fill(dataTable)
				Me.DataGridView2.DataSource = dataTable
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = ModCommonClasses.con IsNot Nothing AndAlso ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			End Try
		End Sub

		' Token: 0x04000F5E RID: 3934
		Private dtOtherlang As DataTable
	End Class
End Namespace
