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
	' Token: 0x0200035B RID: 859
	<DesignerGenerated()>
	Public Partial Class frmMultiBranchReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CB6C RID: 52076 RVA: 0x007F3F48 File Offset: 0x007F2148
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMultiBranchReport_Load
			AddHandler MyBase.Closing, AddressOf Me.frmMultiBranchReport_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmMultiBranchReport_KeyDown
			Me.UserButtons = New List(Of Button)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004FF9 RID: 20473
		' (get) Token: 0x0600CB6F RID: 52079 RVA: 0x0005A816 File Offset: 0x00058A16
		' (set) Token: 0x0600CB70 RID: 52080 RVA: 0x0005A820 File Offset: 0x00058A20
		Friend Overridable Property c As Panel

		' Token: 0x17004FFA RID: 20474
		' (get) Token: 0x0600CB71 RID: 52081 RVA: 0x0005A829 File Offset: 0x00058A29
		' (set) Token: 0x0600CB72 RID: 52082 RVA: 0x007F5594 File Offset: 0x007F3794
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

		' Token: 0x17004FFB RID: 20475
		' (get) Token: 0x0600CB73 RID: 52083 RVA: 0x0005A833 File Offset: 0x00058A33
		' (set) Token: 0x0600CB74 RID: 52084 RVA: 0x007F55D8 File Offset: 0x007F37D8
		Private _txtCompID As TextBox
		Friend Overridable Property txtCompID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCompID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCompID_KeyDown
				Dim textBox As TextBox = Me._txtCompID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCompID = value
				textBox = Me._txtCompID
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FFC RID: 20476
		' (get) Token: 0x0600CB75 RID: 52085 RVA: 0x0005A83D File Offset: 0x00058A3D
		' (set) Token: 0x0600CB76 RID: 52086 RVA: 0x007F5638 File Offset: 0x007F3838
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FFD RID: 20477
		' (get) Token: 0x0600CB77 RID: 52087 RVA: 0x0005A847 File Offset: 0x00058A47
		' (set) Token: 0x0600CB78 RID: 52088 RVA: 0x007F5698 File Offset: 0x007F3898
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004FFE RID: 20478
		' (get) Token: 0x0600CB79 RID: 52089 RVA: 0x0005A851 File Offset: 0x00058A51
		' (set) Token: 0x0600CB7A RID: 52090 RVA: 0x0005A85B File Offset: 0x00058A5B
		Friend Overridable Property Label1 As Label

		' Token: 0x17004FFF RID: 20479
		' (get) Token: 0x0600CB7B RID: 52091 RVA: 0x0005A864 File Offset: 0x00058A64
		' (set) Token: 0x0600CB7C RID: 52092 RVA: 0x0005A86E File Offset: 0x00058A6E
		Friend Overridable Property Label2 As Label

		' Token: 0x17005000 RID: 20480
		' (get) Token: 0x0600CB7D RID: 52093 RVA: 0x0005A877 File Offset: 0x00058A77
		' (set) Token: 0x0600CB7E RID: 52094 RVA: 0x0005A881 File Offset: 0x00058A81
		Friend Overridable Property Label3 As Label

		' Token: 0x17005001 RID: 20481
		' (get) Token: 0x0600CB7F RID: 52095 RVA: 0x0005A88A File Offset: 0x00058A8A
		' (set) Token: 0x0600CB80 RID: 52096 RVA: 0x0005A894 File Offset: 0x00058A94
		Friend Overridable Property Label4 As Label

		' Token: 0x17005002 RID: 20482
		' (get) Token: 0x0600CB81 RID: 52097 RVA: 0x0005A89D File Offset: 0x00058A9D
		' (set) Token: 0x0600CB82 RID: 52098 RVA: 0x0005A8A7 File Offset: 0x00058AA7
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17005003 RID: 20483
		' (get) Token: 0x0600CB83 RID: 52099 RVA: 0x0005A8B0 File Offset: 0x00058AB0
		' (set) Token: 0x0600CB84 RID: 52100 RVA: 0x007F56F8 File Offset: 0x007F38F8
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

		' Token: 0x17005004 RID: 20484
		' (get) Token: 0x0600CB85 RID: 52101 RVA: 0x0005A8BA File Offset: 0x00058ABA
		' (set) Token: 0x0600CB86 RID: 52102 RVA: 0x0005A8C4 File Offset: 0x00058AC4
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005005 RID: 20485
		' (get) Token: 0x0600CB87 RID: 52103 RVA: 0x0005A8CD File Offset: 0x00058ACD
		' (set) Token: 0x0600CB88 RID: 52104 RVA: 0x0005A8D7 File Offset: 0x00058AD7
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005006 RID: 20486
		' (get) Token: 0x0600CB89 RID: 52105 RVA: 0x0005A8E0 File Offset: 0x00058AE0
		' (set) Token: 0x0600CB8A RID: 52106 RVA: 0x0005A8EA File Offset: 0x00058AEA
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005007 RID: 20487
		' (get) Token: 0x0600CB8B RID: 52107 RVA: 0x0005A8F3 File Offset: 0x00058AF3
		' (set) Token: 0x0600CB8C RID: 52108 RVA: 0x0005A8FD File Offset: 0x00058AFD
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005008 RID: 20488
		' (get) Token: 0x0600CB8D RID: 52109 RVA: 0x0005A906 File Offset: 0x00058B06
		' (set) Token: 0x0600CB8E RID: 52110 RVA: 0x0005A910 File Offset: 0x00058B10
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17005009 RID: 20489
		' (get) Token: 0x0600CB8F RID: 52111 RVA: 0x0005A919 File Offset: 0x00058B19
		' (set) Token: 0x0600CB90 RID: 52112 RVA: 0x0005A923 File Offset: 0x00058B23
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x1700500A RID: 20490
		' (get) Token: 0x0600CB91 RID: 52113 RVA: 0x0005A92C File Offset: 0x00058B2C
		' (set) Token: 0x0600CB92 RID: 52114 RVA: 0x0005A936 File Offset: 0x00058B36
		Friend Overridable Property FlowLayoutPanel1 As FlowLayoutPanel

		' Token: 0x1700500B RID: 20491
		' (get) Token: 0x0600CB93 RID: 52115 RVA: 0x0005A93F File Offset: 0x00058B3F
		' (set) Token: 0x0600CB94 RID: 52116 RVA: 0x007F5758 File Offset: 0x007F3958
		Private _TextBox11 As TextBox
		Friend Overridable Property TextBox11 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox11_TextChanged
				Dim textBox As TextBox = Me._TextBox11
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox11 = value
				textBox = Me._TextBox11
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700500C RID: 20492
		' (get) Token: 0x0600CB95 RID: 52117 RVA: 0x0005A949 File Offset: 0x00058B49
		' (set) Token: 0x0600CB96 RID: 52118 RVA: 0x0005A953 File Offset: 0x00058B53
		Friend Overridable Property Label11 As Label

		' Token: 0x1700500D RID: 20493
		' (get) Token: 0x0600CB97 RID: 52119 RVA: 0x0005A95C File Offset: 0x00058B5C
		' (set) Token: 0x0600CB98 RID: 52120 RVA: 0x007F579C File Offset: 0x007F399C
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

		' Token: 0x1700500E RID: 20494
		' (get) Token: 0x0600CB99 RID: 52121 RVA: 0x0005A966 File Offset: 0x00058B66
		' (set) Token: 0x0600CB9A RID: 52122 RVA: 0x007F57E0 File Offset: 0x007F39E0
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700500F RID: 20495
		' (get) Token: 0x0600CB9B RID: 52123 RVA: 0x0005A970 File Offset: 0x00058B70
		' (set) Token: 0x0600CB9C RID: 52124 RVA: 0x007F5824 File Offset: 0x007F3A24
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005010 RID: 20496
		' (get) Token: 0x0600CB9D RID: 52125 RVA: 0x0005A97A File Offset: 0x00058B7A
		' (set) Token: 0x0600CB9E RID: 52126 RVA: 0x007F5868 File Offset: 0x007F3A68
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005011 RID: 20497
		' (get) Token: 0x0600CB9F RID: 52127 RVA: 0x0005A984 File Offset: 0x00058B84
		' (set) Token: 0x0600CBA0 RID: 52128 RVA: 0x007F58AC File Offset: 0x007F3AAC
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

		' Token: 0x0600CBA1 RID: 52129 RVA: 0x007F58F0 File Offset: 0x007F3AF0
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.c.Controls.Clear()
			Dim frmRecClose As New Receiver() With { .Size = Me.c.Size, .TopLevel = False, .Parent = Me.c } : frmRecClose.Close()
			MyProject.Forms.Receiver.Close()
		End Sub

		' Token: 0x0600CBA2 RID: 52130 RVA: 0x007F5954 File Offset: 0x007F3B54
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(c1), RTRIM(c2),RTRIM(c3) from Android_Apps order by ID", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CBA3 RID: 52131 RVA: 0x007F5A60 File Offset: 0x007F3C60
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.TextBox3.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtCompID.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.TextBox1.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.TextBox2.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CBA4 RID: 52132 RVA: 0x007F5B70 File Offset: 0x007F3D70
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Android_Apps where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.TextBox3.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CBA5 RID: 52133 RVA: 0x007F5C90 File Offset: 0x007F3E90
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

		' Token: 0x0600CBA6 RID: 52134 RVA: 0x007F5D78 File Offset: 0x007F3F78
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtCompID.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtCompID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCompID, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.TextBox1.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.TextBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.TextBox1, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.TextBox2.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.TextBox2, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.TextBox2, String.Empty)
			End If
		End Sub

		' Token: 0x0600CBA7 RID: 52135 RVA: 0x007F5E6C File Offset: 0x007F406C
		Private Sub frmMultiBranchReport_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.FillCompanyID()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CBA8 RID: 52136 RVA: 0x007F5EFC File Offset: 0x007F40FC
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

		' Token: 0x0600CBA9 RID: 52137 RVA: 0x007F6074 File Offset: 0x007F4274
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

		' Token: 0x0600CBAA RID: 52138 RVA: 0x007F6130 File Offset: 0x007F4330
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

		' Token: 0x0600CBAB RID: 52139 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CBAC RID: 52140 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CBAD RID: 52141 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CBAE RID: 52142 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCompID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600CBAF RID: 52143 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600CBB0 RID: 52144 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600CBB1 RID: 52145 RVA: 0x007F61FC File Offset: 0x007F43FC
		Public Sub Reset()
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.txtCompID.Focus()
			Me.txtCompID.Text = ""
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.Getdata()
			Me.FillCompanyID()
		End Sub

		' Token: 0x0600CBB2 RID: 52146 RVA: 0x007F58F0 File Offset: 0x007F3AF0
		Private Sub frmMultiBranchReport_Closing(sender As Object, e As CancelEventArgs)
			Me.c.Controls.Clear()
			Dim frmRecClose As New Receiver() With { .Size = Me.c.Size, .TopLevel = False, .Parent = Me.c } : frmRecClose.Close()
			MyProject.Forms.Receiver.Close()
		End Sub

		' Token: 0x0600CBB3 RID: 52147 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmMultiBranchReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CBB4 RID: 52148 RVA: 0x007F6290 File Offset: 0x007F4490
		Public Sub FillCompanyID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ID,RTRIM(c1), RTRIM(c2),RTRIM(c3) from Android_Apps order by c2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.FlowLayoutPanel1.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim button As Button = New Button()
					button.Text = String.Concat(New String() { "Company ID : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Name : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim(), vbCrLf, "Address : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim() })
					button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim() })
					button.TextAlign = ContentAlignment.MiddleLeft
					Dim dodgerBlue As Color = Color.DodgerBlue
					button.BackColor = dodgerBlue
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Cursor = Cursors.Hand
					button.Width = 180
					button.Height = 130
					button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.FlowLayoutPanel1.Controls.Add(button)
					AddHandler button.Click, AddressOf Me.Buttonx_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CBB5 RID: 52149 RVA: 0x007F64FC File Offset: 0x007F46FC
		Private Sub Buttonx_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(button.Tag))
				Dim text2 As String = text.Split(New Char() { ","c })(0).ToString()
				Dim flag As Boolean = Operators.CompareString(text2, "", False) = 0
				If flag Then
					MessageBox.Show("You have not selected Company ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
					If flag2 Then
						Me.c.Controls.Clear()
						Dim frmRecClose As New Receiver() With { .Size = Me.c.Size, .TopLevel = False, .Parent = Me.c } : frmRecClose.Close()
						MyProject.Forms.Receiver.Close()
						Dim frmRec As New Receiver()
			frmRec.Size = Me.c.Size
			frmRec.TopLevel = False
			frmRec.Parent = Me.c
			frmRec.TBoxCompId.Text = text2
			frmRec.Show()
					Else
						MessageBox.Show("Internet connection not found", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CBB6 RID: 52150 RVA: 0x007F6674 File Offset: 0x007F4874
		Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ID,RTRIM(c1), RTRIM(c2),RTRIM(c3) from Android_Apps where c2 like N'" + Me.TextBox11.Text + "%' order by c2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.FlowLayoutPanel1.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim button As Button = New Button()
					button.Text = String.Concat(New String() { "Company ID : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Name : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim(), vbCrLf, "Address : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim() })
					button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim() })
					button.TextAlign = ContentAlignment.MiddleLeft
					Dim dodgerBlue As Color = Color.DodgerBlue
					button.BackColor = dodgerBlue
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Cursor = Cursors.Hand
					button.Width = 180
					button.Height = 130
					button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.FlowLayoutPanel1.Controls.Add(button)
					AddHandler button.Click, AddressOf Me.Buttonx_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CBB7 RID: 52151 RVA: 0x007F68F4 File Offset: 0x007F4AF4
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you want to save this image?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
			If flag Then
				Try
					Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
					saveFileDialog.Title = "Save Image"
					saveFileDialog.CheckPathExists = True
					saveFileDialog.DefaultExt = "png"
					saveFileDialog.Filter = "Image (*.png)|*.png|All files (*.*)|*.*"
					saveFileDialog.FilterIndex = 0
					saveFileDialog.RestoreDirectory = True
					Dim flag2 As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
					If flag2 Then
						Using bitmap As Bitmap = New Bitmap(Me.c.Width, Me.c.Height)
							Me.c.DrawToBitmap(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
							bitmap.Save(saveFileDialog.FileName)
						End Using
						MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				Catch ex As Exception
					MessageBox.Show("Failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End Try
			End If
		End Sub

		' Token: 0x0600CBB8 RID: 52152 RVA: 0x0005A98E File Offset: 0x00058B8E
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600CBB9 RID: 52153 RVA: 0x007F6A1C File Offset: 0x007F4C1C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtCompID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter company id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCompID.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.TextBox1.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please enter company name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox1.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please enter company address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.TextBox2.Focus()
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "insert into Android_Apps(c1,c2,c3) VALUES (@d1,@d2,@d3)"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompID.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox2.Text)
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnSave.Enabled = False
								Me.Getdata()
								Me.Reset()
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600CBBA RID: 52154 RVA: 0x007F6CA4 File Offset: 0x007F4EA4
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCompID.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter company id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtCompID.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.TextBox1.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter company name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.TextBox1.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please enter company address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox2.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "Update Android_Apps set c1=@d1,c2=@d2,c3=@d3 where ID=@d4"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.TextBox3.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompID.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox2.Text)
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnUpdate.Enabled = False
							Me.Getdata()
							Me.FillCompanyID()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600CBBB RID: 52155 RVA: 0x007F6EC4 File Offset: 0x007F50C4
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x040051A6 RID: 20902
		Private UserButtons As List(Of Button)
	End Class
End Namespace
