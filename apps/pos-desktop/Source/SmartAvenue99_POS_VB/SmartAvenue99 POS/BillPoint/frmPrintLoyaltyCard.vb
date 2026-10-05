Imports System
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
	' Token: 0x020004D7 RID: 1239
	<DesignerGenerated()>
	Public Partial Class frmPrintLoyaltyCard
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FC4B RID: 64587 RVA: 0x0006E9D7 File Offset: 0x0006CBD7
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPrintCard_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPrintLoyaltyCard_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006082 RID: 24706
		' (get) Token: 0x0600FC4E RID: 64590 RVA: 0x0006EA09 File Offset: 0x0006CC09
		' (set) Token: 0x0600FC4F RID: 64591 RVA: 0x009703E4 File Offset: 0x0096E5E4
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

		' Token: 0x17006083 RID: 24707
		' (get) Token: 0x0600FC50 RID: 64592 RVA: 0x0006EA13 File Offset: 0x0006CC13
		' (set) Token: 0x0600FC51 RID: 64593 RVA: 0x0006EA1D File Offset: 0x0006CC1D
		Friend Overridable Property listView1 As ListView

		' Token: 0x17006084 RID: 24708
		' (get) Token: 0x0600FC52 RID: 64594 RVA: 0x0006EA26 File Offset: 0x0006CC26
		' (set) Token: 0x0600FC53 RID: 64595 RVA: 0x0006EA30 File Offset: 0x0006CC30
		Friend Overridable Property columnHeader1 As ColumnHeader

		' Token: 0x17006085 RID: 24709
		' (get) Token: 0x0600FC54 RID: 64596 RVA: 0x0006EA39 File Offset: 0x0006CC39
		' (set) Token: 0x0600FC55 RID: 64597 RVA: 0x0006EA43 File Offset: 0x0006CC43
		Friend Overridable Property columnHeader3 As ColumnHeader

		' Token: 0x17006086 RID: 24710
		' (get) Token: 0x0600FC56 RID: 64598 RVA: 0x0006EA4C File Offset: 0x0006CC4C
		' (set) Token: 0x0600FC57 RID: 64599 RVA: 0x0006EA56 File Offset: 0x0006CC56
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17006087 RID: 24711
		' (get) Token: 0x0600FC58 RID: 64600 RVA: 0x0006EA5F File Offset: 0x0006CC5F
		' (set) Token: 0x0600FC59 RID: 64601 RVA: 0x0006EA69 File Offset: 0x0006CC69
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17006088 RID: 24712
		' (get) Token: 0x0600FC5A RID: 64602 RVA: 0x0006EA72 File Offset: 0x0006CC72
		' (set) Token: 0x0600FC5B RID: 64603 RVA: 0x0006EA7C File Offset: 0x0006CC7C
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006089 RID: 24713
		' (get) Token: 0x0600FC5C RID: 64604 RVA: 0x0006EA85 File Offset: 0x0006CC85
		' (set) Token: 0x0600FC5D RID: 64605 RVA: 0x00970428 File Offset: 0x0096E628
		Private _txtMemberName As TextBox
		Friend Overridable Property txtMemberName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMemberName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtMemberName_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtMemberName_KeyDown
				Dim textBox As TextBox = Me._txtMemberName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtMemberName = value
				textBox = Me._txtMemberName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700608A RID: 24714
		' (get) Token: 0x0600FC5E RID: 64606 RVA: 0x0006EA8F File Offset: 0x0006CC8F
		' (set) Token: 0x0600FC5F RID: 64607 RVA: 0x0006EA99 File Offset: 0x0006CC99
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700608B RID: 24715
		' (get) Token: 0x0600FC60 RID: 64608 RVA: 0x0006EAA2 File Offset: 0x0006CCA2
		' (set) Token: 0x0600FC61 RID: 64609 RVA: 0x00970488 File Offset: 0x0096E688
		Private _txtMemberID As TextBox
		Friend Overridable Property txtMemberID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMemberID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtMemberID_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtMemberID_KeyDown
				Dim textBox As TextBox = Me._txtMemberID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtMemberID = value
				textBox = Me._txtMemberID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700608C RID: 24716
		' (get) Token: 0x0600FC62 RID: 64610 RVA: 0x0006EAAC File Offset: 0x0006CCAC
		' (set) Token: 0x0600FC63 RID: 64611 RVA: 0x0006EAB6 File Offset: 0x0006CCB6
		Friend Overridable Property txtHotelName As TextBox

		' Token: 0x1700608D RID: 24717
		' (get) Token: 0x0600FC64 RID: 64612 RVA: 0x0006EABF File Offset: 0x0006CCBF
		' (set) Token: 0x0600FC65 RID: 64613 RVA: 0x009704E8 File Offset: 0x0096E6E8
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

		' Token: 0x1700608E RID: 24718
		' (get) Token: 0x0600FC66 RID: 64614 RVA: 0x0006EAC9 File Offset: 0x0006CCC9
		' (set) Token: 0x0600FC67 RID: 64615 RVA: 0x0006EAD3 File Offset: 0x0006CCD3
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x1700608F RID: 24719
		' (get) Token: 0x0600FC68 RID: 64616 RVA: 0x0006EADC File Offset: 0x0006CCDC
		' (set) Token: 0x0600FC69 RID: 64617 RVA: 0x0097052C File Offset: 0x0096E72C
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006090 RID: 24720
		' (get) Token: 0x0600FC6A RID: 64618 RVA: 0x0006EAE6 File Offset: 0x0006CCE6
		' (set) Token: 0x0600FC6B RID: 64619 RVA: 0x0006EAF0 File Offset: 0x0006CCF0
		Friend Overridable Property Label6 As Label

		' Token: 0x17006091 RID: 24721
		' (get) Token: 0x0600FC6C RID: 64620 RVA: 0x0006EAF9 File Offset: 0x0006CCF9
		' (set) Token: 0x0600FC6D RID: 64621 RVA: 0x0006EB03 File Offset: 0x0006CD03
		Friend Overridable Property Label7 As Label

		' Token: 0x17006092 RID: 24722
		' (get) Token: 0x0600FC6E RID: 64622 RVA: 0x0006EB0C File Offset: 0x0006CD0C
		' (set) Token: 0x0600FC6F RID: 64623 RVA: 0x0006EB16 File Offset: 0x0006CD16
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17006093 RID: 24723
		' (get) Token: 0x0600FC70 RID: 64624 RVA: 0x0006EB1F File Offset: 0x0006CD1F
		' (set) Token: 0x0600FC71 RID: 64625 RVA: 0x0097058C File Offset: 0x0096E78C
		Private _btnViewReport As GelButton
		Friend Overridable Property btnViewReport As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnViewReport
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnViewReport_Click
				Dim gelButton As GelButton = Me._btnViewReport
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnViewReport = value
				gelButton = Me._btnViewReport
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006094 RID: 24724
		' (get) Token: 0x0600FC72 RID: 64626 RVA: 0x0006EB29 File Offset: 0x0006CD29
		' (set) Token: 0x0600FC73 RID: 64627 RVA: 0x009705D0 File Offset: 0x0096E7D0
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

		' Token: 0x0600FC74 RID: 64628 RVA: 0x00970614 File Offset: 0x0096E814
		Public Sub Reset()
			Me.txtMemberID.Text = ""
			Me.txtMemberName.Text = ""
			Me.TextBox1.Text = ""
			Me.chkSelectAll.Checked = True
			Me.GetData()
		End Sub

		' Token: 0x0600FC75 RID: 64629 RVA: 0x0006EB33 File Offset: 0x0006CD33
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600FC76 RID: 64630 RVA: 0x0097066C File Offset: 0x0096E86C
		Private Sub txtMemberName_TextChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " RTRIM(CustomerID),RTRIM(Name),RTRIM(Address),RTRIM(ContactNo) from Customer where Name not in ('Cash') and Name like N'%", Me.txtMemberName.Text, "%' order by Name" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
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

		' Token: 0x0600FC77 RID: 64631 RVA: 0x00970838 File Offset: 0x0096EA38
		Private Sub txtMemberID_TextChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, "  RTRIM(CustomerID),RTRIM(Name),RTRIM(Address),RTRIM(ContactNo) from Customer where Name not in ('Cash') and CustomerID like N'", Me.txtMemberID.Text, "%'  order by Name" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
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

		' Token: 0x0600FC78 RID: 64632 RVA: 0x00970A04 File Offset: 0x0096EC04
		Public Sub GetData()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP " + Me.txtTopResult.Text + " RTRIM(CustomerID),RTRIM(Name),RTRIM(Address),RTRIM(ContactNo) from Customer where Name not in ('Cash') order by Name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
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

		' Token: 0x0600FC79 RID: 64633 RVA: 0x00970BAC File Offset: 0x0096EDAC
		Public Sub GetHotelInfo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(CompanyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtHotelName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600FC7A RID: 64634 RVA: 0x0006EB4F File Offset: 0x0006CD4F
		Private Sub frmPrintCard_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.GetHotelInfo()
		End Sub

		' Token: 0x0600FC7B RID: 64635 RVA: 0x00970C9C File Offset: 0x0096EE9C
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

		' Token: 0x0600FC7C RID: 64636 RVA: 0x00970D88 File Offset: 0x0096EF88
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " RTRIM(CustomerID),RTRIM(Name),RTRIM(Address),RTRIM(ContactNo) from Customer where Name not in ('Cash') and ContactNo like N'", Me.TextBox1.Text, "%'  order by Name" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
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

		' Token: 0x0600FC7D RID: 64637 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtMemberName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FC7E RID: 64638 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtMemberID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FC7F RID: 64639 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FC80 RID: 64640 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPrintLoyaltyCard_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FC81 RID: 64641 RVA: 0x0006EB60 File Offset: 0x0006CD60
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600FC82 RID: 64642 RVA: 0x00970F54 File Offset: 0x0096F154
		Private Sub btnViewReport_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.listView1.Items.Count = 0
			If flag Then
				MessageBox.Show("There is no customer's record in listview to generate loyalty card ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Try
					Dim flag2 As Boolean = Me.listView1.CheckedItems.Count > 0
					If flag2 Then
						Dim text As String = ""
						Dim num As Integer = Me.listView1.CheckedItems.Count - 1
						For i As Integer = 0 To num
							text += String.Format("'{0}',", Me.listView1.CheckedItems(i).Text)
						Next
						text = text.Substring(0, text.Length - 1)
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "Select CustomerID, RTRIM(Name), RTRIM(Address), RTRIM(CardNo) from Customer where CustomerID in (" + text + ") order by Name"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.dtable = New DataTable()
						ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
						ModCommonClasses.ds.WriteXmlSchema("LoyaltyCard1.xml")
						Dim rptLoyaltyCard As rptLoyaltyCard = New rptLoyaltyCard()
						rptLoyaltyCard.SetDataSource(ModCommonClasses.ds)
						rptLoyaltyCard.SetParameterValue("p1", Me.txtHotelName.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptLoyaltyCard
						MyProject.Forms.frmReport.ShowDialog()
						rptLoyaltyCard.Close()
						rptLoyaltyCard.Dispose()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x040060B3 RID: 24755
		Private st As String
	End Class
End Namespace
