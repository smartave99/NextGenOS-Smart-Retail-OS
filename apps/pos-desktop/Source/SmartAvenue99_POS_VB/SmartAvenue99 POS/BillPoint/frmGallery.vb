Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C7 RID: 1223
	<DesignerGenerated()>
	Public Partial Class frmGallery
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F5EC RID: 62956 RVA: 0x0006BAF6 File Offset: 0x00069CF6
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGallery_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGallery_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005E11 RID: 24081
		' (get) Token: 0x0600F5EF RID: 62959 RVA: 0x0006BB28 File Offset: 0x00069D28
		' (set) Token: 0x0600F5F0 RID: 62960 RVA: 0x0006BB32 File Offset: 0x00069D32
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17005E12 RID: 24082
		' (get) Token: 0x0600F5F1 RID: 62961 RVA: 0x0006BB3B File Offset: 0x00069D3B
		' (set) Token: 0x0600F5F2 RID: 62962 RVA: 0x00937938 File Offset: 0x00935B38
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
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellEnter
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellEnter, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellEnter, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E13 RID: 24083
		' (get) Token: 0x0600F5F3 RID: 62963 RVA: 0x0006BB45 File Offset: 0x00069D45
		' (set) Token: 0x0600F5F4 RID: 62964 RVA: 0x0006BB4F File Offset: 0x00069D4F
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005E14 RID: 24084
		' (get) Token: 0x0600F5F5 RID: 62965 RVA: 0x0006BB58 File Offset: 0x00069D58
		' (set) Token: 0x0600F5F6 RID: 62966 RVA: 0x009379B4 File Offset: 0x00935BB4
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
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E15 RID: 24085
		' (get) Token: 0x0600F5F7 RID: 62967 RVA: 0x0006BB62 File Offset: 0x00069D62
		' (set) Token: 0x0600F5F8 RID: 62968 RVA: 0x009379F8 File Offset: 0x00935BF8
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox3_TextChanged
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E16 RID: 24086
		' (get) Token: 0x0600F5F9 RID: 62969 RVA: 0x0006BB6C File Offset: 0x00069D6C
		' (set) Token: 0x0600F5FA RID: 62970 RVA: 0x00937A3C File Offset: 0x00935C3C
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

		' Token: 0x17005E17 RID: 24087
		' (get) Token: 0x0600F5FB RID: 62971 RVA: 0x0006BB76 File Offset: 0x00069D76
		' (set) Token: 0x0600F5FC RID: 62972 RVA: 0x0006BB80 File Offset: 0x00069D80
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17005E18 RID: 24088
		' (get) Token: 0x0600F5FD RID: 62973 RVA: 0x0006BB89 File Offset: 0x00069D89
		' (set) Token: 0x0600F5FE RID: 62974 RVA: 0x0006BB93 File Offset: 0x00069D93
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005E19 RID: 24089
		' (get) Token: 0x0600F5FF RID: 62975 RVA: 0x0006BB9C File Offset: 0x00069D9C
		' (set) Token: 0x0600F600 RID: 62976 RVA: 0x00937A80 File Offset: 0x00935C80
		Private _Button6 As Button
		Friend Overridable Property Button6 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim button As Button = Me._Button6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button6 = value
				button = Me._Button6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E1A RID: 24090
		' (get) Token: 0x0600F601 RID: 62977 RVA: 0x0006BBA6 File Offset: 0x00069DA6
		' (set) Token: 0x0600F602 RID: 62978 RVA: 0x00937AC4 File Offset: 0x00935CC4
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E1B RID: 24091
		' (get) Token: 0x0600F603 RID: 62979 RVA: 0x0006BBB0 File Offset: 0x00069DB0
		' (set) Token: 0x0600F604 RID: 62980 RVA: 0x00937B08 File Offset: 0x00935D08
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

		' Token: 0x17005E1C RID: 24092
		' (get) Token: 0x0600F605 RID: 62981 RVA: 0x0006BBBA File Offset: 0x00069DBA
		' (set) Token: 0x0600F606 RID: 62982 RVA: 0x00937B4C File Offset: 0x00935D4C
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

		' Token: 0x17005E1D RID: 24093
		' (get) Token: 0x0600F607 RID: 62983 RVA: 0x0006BBC4 File Offset: 0x00069DC4
		' (set) Token: 0x0600F608 RID: 62984 RVA: 0x00937B90 File Offset: 0x00935D90
		Private _Button5 As Button
		Friend Overridable Property Button5 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button5_Click
				Dim button As Button = Me._Button5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button5 = value
				button = Me._Button5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E1E RID: 24094
		' (get) Token: 0x0600F609 RID: 62985 RVA: 0x0006BBCE File Offset: 0x00069DCE
		' (set) Token: 0x0600F60A RID: 62986 RVA: 0x0006BBD8 File Offset: 0x00069DD8
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005E1F RID: 24095
		' (get) Token: 0x0600F60B RID: 62987 RVA: 0x0006BBE1 File Offset: 0x00069DE1
		' (set) Token: 0x0600F60C RID: 62988 RVA: 0x0006BBEB File Offset: 0x00069DEB
		Friend Overridable Property Label1 As Label

		' Token: 0x17005E20 RID: 24096
		' (get) Token: 0x0600F60D RID: 62989 RVA: 0x0006BBF4 File Offset: 0x00069DF4
		' (set) Token: 0x0600F60E RID: 62990 RVA: 0x00937BD4 File Offset: 0x00935DD4
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005E21 RID: 24097
		' (get) Token: 0x0600F60F RID: 62991 RVA: 0x0006BBFE File Offset: 0x00069DFE
		' (set) Token: 0x0600F610 RID: 62992 RVA: 0x0006BC08 File Offset: 0x00069E08
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005E22 RID: 24098
		' (get) Token: 0x0600F611 RID: 62993 RVA: 0x0006BC11 File Offset: 0x00069E11
		' (set) Token: 0x0600F612 RID: 62994 RVA: 0x0006BC1B File Offset: 0x00069E1B
		Friend Overridable Property Label13 As Label

		' Token: 0x17005E23 RID: 24099
		' (get) Token: 0x0600F613 RID: 62995 RVA: 0x0006BC24 File Offset: 0x00069E24
		' (set) Token: 0x0600F614 RID: 62996 RVA: 0x00937C18 File Offset: 0x00935E18
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

		' Token: 0x17005E24 RID: 24100
		' (get) Token: 0x0600F615 RID: 62997 RVA: 0x0006BC2E File Offset: 0x00069E2E
		' (set) Token: 0x0600F616 RID: 62998 RVA: 0x0006BC38 File Offset: 0x00069E38
		Friend Overridable Property Label2 As Label

		' Token: 0x17005E25 RID: 24101
		' (get) Token: 0x0600F617 RID: 62999 RVA: 0x0006BC41 File Offset: 0x00069E41
		' (set) Token: 0x0600F618 RID: 63000 RVA: 0x0006BC4B File Offset: 0x00069E4B
		Friend Overridable Property ComboBox2 As ComboBox

		' Token: 0x17005E26 RID: 24102
		' (get) Token: 0x0600F619 RID: 63001 RVA: 0x0006BC54 File Offset: 0x00069E54
		' (set) Token: 0x0600F61A RID: 63002 RVA: 0x0006BC5E File Offset: 0x00069E5E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005E27 RID: 24103
		' (get) Token: 0x0600F61B RID: 63003 RVA: 0x0006BC67 File Offset: 0x00069E67
		' (set) Token: 0x0600F61C RID: 63004 RVA: 0x0006BC71 File Offset: 0x00069E71
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005E28 RID: 24104
		' (get) Token: 0x0600F61D RID: 63005 RVA: 0x0006BC7A File Offset: 0x00069E7A
		' (set) Token: 0x0600F61E RID: 63006 RVA: 0x0006BC84 File Offset: 0x00069E84
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005E29 RID: 24105
		' (get) Token: 0x0600F61F RID: 63007 RVA: 0x0006BC8D File Offset: 0x00069E8D
		' (set) Token: 0x0600F620 RID: 63008 RVA: 0x0006BC97 File Offset: 0x00069E97
		Friend Overridable Property Column4 As DataGridViewImageColumn

		' Token: 0x17005E2A RID: 24106
		' (get) Token: 0x0600F621 RID: 63009 RVA: 0x0006BCA0 File Offset: 0x00069EA0
		' (set) Token: 0x0600F622 RID: 63010 RVA: 0x0006BCAA File Offset: 0x00069EAA
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x0600F623 RID: 63011 RVA: 0x00937C5C File Offset: 0x00935E5C
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.PictureBox1.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F624 RID: 63012 RVA: 0x00937D04 File Offset: 0x00935F04
		Private Sub autocustid()
			ModCommonClasses.con.Open()
			Dim sqlCommand As SqlCommand = New SqlCommand("SELECT MAX(c1) FROM Gallery", ModCommonClasses.con)
			Dim text As String = sqlCommand.ExecuteScalar().ToString()
			Dim flag As Boolean = String.IsNullOrEmpty(text)
			If flag Then
				text = "0"
				Me.TextBox2.Text = text
			End If
			text = text.Substring(0)
			Dim num As Integer
			Integer.TryParse(text, num)
			num += 1
			text = If(num.ToString(""), "")
			Me.TextBox2.Text = text
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600F625 RID: 63013 RVA: 0x00937D9C File Offset: 0x00935F9C
		Private Sub frmGallery_Load(sender As Object, e As EventArgs)
			Me.ComboBox2.SelectedIndex = 0
			Me.autocustid()
			Me.GetData()
			Me.imageisplay()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600F626 RID: 63014 RVA: 0x00937E38 File Offset: 0x00936038
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(c1),RTRIM(c2),c3,RTRIM(c4) from Gallery ORDER BY c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.dgw.ClearSelection()
		End Sub

		' Token: 0x0600F627 RID: 63015 RVA: 0x0006BCB3 File Offset: 0x00069EB3
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox3.Text = "IMG-" + Me.TextBox2.Text
		End Sub

		' Token: 0x0600F628 RID: 63016 RVA: 0x0006BCB3 File Offset: 0x00069EB3
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox3.Text = "IMG-" + Me.TextBox2.Text
		End Sub

		' Token: 0x0600F629 RID: 63017 RVA: 0x00937F54 File Offset: 0x00936154
		Private Sub Clear()
			Me.autocustid()
			Me.PictureBox1.Image = Resources.Noimage
			Me.dgw.ClearSelection()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = 0
		End Sub

		' Token: 0x0600F62A RID: 63018 RVA: 0x00937FA0 File Offset: 0x009361A0
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
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
					Dim flag3 As Boolean = Operators.CompareString(Me.ComboBox2.Text, "Yes", False) = 0
					If flag3 Then
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select c4 from Gallery where c4='Yes'"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("Display screen image is already selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
							Return
						End If
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "Insert into Gallery(c1,c2,c3,c4) VALUES (@d1,@d2,@d3,@d4)"
					ModCommonClasses.cmd = New SqlCommand(text3)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox2.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox3.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.ComboBox2.Text)
					Dim memoryStream As MemoryStream = New MemoryStream()
					Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
					bitmap.Save(memoryStream, ImageFormat.Jpeg)
					Dim buffer As Byte() = memoryStream.GetBuffer()
					Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.VarBinary)
					sqlParameter.Value = buffer
					ModCommonClasses.cmd.Parameters.Add(sqlParameter)
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.imageisplay()
					Me.Button1.Enabled = True
					Me.Button3.Enabled = False
					Me.Button4.Enabled = False
					Me.GetData()
					Me.Clear()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F62B RID: 63019 RVA: 0x009382B4 File Offset: 0x009364B4
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
					Me.Button1.Enabled = False
					Me.Button3.Enabled = True
					Me.Button4.Enabled = True
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.TextBox1.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.TextBox2.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.TextBox3.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.ComboBox2.Text = dataGridViewRow.Cells(4).Value.ToString()
				Dim array As Byte() = CType(dataGridViewRow.Cells(3).Value, Byte())
				Dim memoryStream As MemoryStream = New MemoryStream(array)
				Me.PictureBox1.Image = Image.FromStream(memoryStream)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F62C RID: 63020 RVA: 0x0006BCD7 File Offset: 0x00069ED7
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.Button1.Enabled = True
			Me.Button3.Enabled = False
			Me.Button4.Enabled = False
			Me.GetData()
			Me.imageisplay()
		End Sub

		' Token: 0x0600F62D RID: 63021 RVA: 0x009383FC File Offset: 0x009365FC
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update Gallery set c4='No'"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = If(("Update Gallery set c1=@d1, c2=@d2, c3=@d3, c4=@d4 where ID=" + Me.TextBox1.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox2.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox3.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.ComboBox2.Text)
				Dim memoryStream As MemoryStream = New MemoryStream()
				Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
				bitmap.Save(memoryStream, ImageFormat.Jpeg)
				Dim buffer As Byte() = memoryStream.GetBuffer()
				Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.VarBinary)
				sqlParameter.Value = buffer
				ModCommonClasses.cmd.Parameters.Add(sqlParameter)
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.imageisplay()
				Me.GetData()
				Me.Clear()
				Me.Button1.Enabled = True
				Me.Button3.Enabled = False
				Me.Button4.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F62E RID: 63022 RVA: 0x0093861C File Offset: 0x0093681C
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM Gallery WHERE ID = " + Me.TextBox1.Text
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim flag As Boolean = sqlCommand.ExecuteNonQuery() > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.imageisplay()
					Me.GetData()
					Me.Clear()
					ModCommonClasses.con.Close()
					Me.Button1.Enabled = True
					Me.Button3.Enabled = False
					Me.Button4.Enabled = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F62F RID: 63023 RVA: 0x00938704 File Offset: 0x00936904
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F630 RID: 63024 RVA: 0x0006BD16 File Offset: 0x00069F16
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Me.PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
			Me.PictureBox1.Refresh()
		End Sub

		' Token: 0x0600F631 RID: 63025 RVA: 0x0093876C File Offset: 0x0093696C
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

		' Token: 0x0600F632 RID: 63026 RVA: 0x009382B4 File Offset: 0x009364B4
		Private Sub dgw_CellEnter(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
					Me.Button1.Enabled = False
					Me.Button3.Enabled = True
					Me.Button4.Enabled = True
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.TextBox1.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.TextBox2.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.TextBox3.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.ComboBox2.Text = dataGridViewRow.Cells(4).Value.ToString()
				Dim array As Byte() = CType(dataGridViewRow.Cells(3).Value, Byte())
				Dim memoryStream As MemoryStream = New MemoryStream(array)
				Me.PictureBox1.Image = Image.FromStream(memoryStream)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F633 RID: 63027 RVA: 0x00938854 File Offset: 0x00936A54
		Private Sub imageisplay()
			Try
				ModCommonClasses.con.Close()
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT c2 FROM Gallery ORDER BY c1 ASC"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.ComboBox1.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox1.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F634 RID: 63028 RVA: 0x00938964 File Offset: 0x00936B64
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(c1), RTRIM(c2), c3, c4 from Gallery where c2 like N'%" + Me.ComboBox1.Text + "%' order by c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F635 RID: 63029 RVA: 0x0006BD37 File Offset: 0x00069F37
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600F636 RID: 63030 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGallery_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
