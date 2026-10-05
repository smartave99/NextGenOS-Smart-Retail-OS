Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000054 RID: 84
	<DesignerGenerated()>
	Public Partial Class frmEComSeting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06000F73 RID: 3955 RVA: 0x0000E6D2 File Offset: 0x0000C8D2
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000648 RID: 1608
		' (get) Token: 0x06000F76 RID: 3958 RVA: 0x0000E6E0 File Offset: 0x0000C8E0
		' (set) Token: 0x06000F77 RID: 3959 RVA: 0x0000E6EA File Offset: 0x0000C8EA
		Friend Overridable Property ImageList1 As ImageList

		' Token: 0x17000649 RID: 1609
		' (get) Token: 0x06000F78 RID: 3960 RVA: 0x0000E6F3 File Offset: 0x0000C8F3
		' (set) Token: 0x06000F79 RID: 3961 RVA: 0x0000E6FD File Offset: 0x0000C8FD
		Friend Overridable Property Timer1 As Timer

		' Token: 0x1700064A RID: 1610
		' (get) Token: 0x06000F7A RID: 3962 RVA: 0x0000E706 File Offset: 0x0000C906
		' (set) Token: 0x06000F7B RID: 3963 RVA: 0x0000E710 File Offset: 0x0000C910
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700064B RID: 1611
		' (get) Token: 0x06000F7C RID: 3964 RVA: 0x0000E719 File Offset: 0x0000C919
		' (set) Token: 0x06000F7D RID: 3965 RVA: 0x0000E723 File Offset: 0x0000C923
		Friend Overridable Property Panel6 As Panel

		' Token: 0x1700064C RID: 1612
		' (get) Token: 0x06000F7E RID: 3966 RVA: 0x0000E72C File Offset: 0x0000C92C
		' (set) Token: 0x06000F7F RID: 3967 RVA: 0x0000E736 File Offset: 0x0000C936
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700064D RID: 1613
		' (get) Token: 0x06000F80 RID: 3968 RVA: 0x0000E73F File Offset: 0x0000C93F
		' (set) Token: 0x06000F81 RID: 3969 RVA: 0x0000E749 File Offset: 0x0000C949
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700064E RID: 1614
		' (get) Token: 0x06000F82 RID: 3970 RVA: 0x0000E752 File Offset: 0x0000C952
		' (set) Token: 0x06000F83 RID: 3971 RVA: 0x0000E75C File Offset: 0x0000C95C
		Friend Overridable Property Button2 As Button

		' Token: 0x1700064F RID: 1615
		' (get) Token: 0x06000F84 RID: 3972 RVA: 0x0000E765 File Offset: 0x0000C965
		' (set) Token: 0x06000F85 RID: 3973 RVA: 0x0000E76F File Offset: 0x0000C96F
		Friend Overridable Property Button3 As Button

		' Token: 0x17000650 RID: 1616
		' (get) Token: 0x06000F86 RID: 3974 RVA: 0x0000E778 File Offset: 0x0000C978
		' (set) Token: 0x06000F87 RID: 3975 RVA: 0x000BA008 File Offset: 0x000B8208
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

		' Token: 0x17000651 RID: 1617
		' (get) Token: 0x06000F88 RID: 3976 RVA: 0x0000E782 File Offset: 0x0000C982
		' (set) Token: 0x06000F89 RID: 3977 RVA: 0x000BA04C File Offset: 0x000B824C
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

		' Token: 0x17000652 RID: 1618
		' (get) Token: 0x06000F8A RID: 3978 RVA: 0x0000E78C File Offset: 0x0000C98C
		' (set) Token: 0x06000F8B RID: 3979 RVA: 0x0000E796 File Offset: 0x0000C996
		Friend Overridable Property dgw As DataGridView

		' Token: 0x17000653 RID: 1619
		' (get) Token: 0x06000F8C RID: 3980 RVA: 0x0000E79F File Offset: 0x0000C99F
		' (set) Token: 0x06000F8D RID: 3981 RVA: 0x0000E7A9 File Offset: 0x0000C9A9
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000654 RID: 1620
		' (get) Token: 0x06000F8E RID: 3982 RVA: 0x0000E7B2 File Offset: 0x0000C9B2
		' (set) Token: 0x06000F8F RID: 3983 RVA: 0x0000E7BC File Offset: 0x0000C9BC
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000655 RID: 1621
		' (get) Token: 0x06000F90 RID: 3984 RVA: 0x0000E7C5 File Offset: 0x0000C9C5
		' (set) Token: 0x06000F91 RID: 3985 RVA: 0x0000E7CF File Offset: 0x0000C9CF
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000656 RID: 1622
		' (get) Token: 0x06000F92 RID: 3986 RVA: 0x0000E7D8 File Offset: 0x0000C9D8
		' (set) Token: 0x06000F93 RID: 3987 RVA: 0x0000E7E2 File Offset: 0x0000C9E2
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000657 RID: 1623
		' (get) Token: 0x06000F94 RID: 3988 RVA: 0x0000E7EB File Offset: 0x0000C9EB
		' (set) Token: 0x06000F95 RID: 3989 RVA: 0x0000E7F5 File Offset: 0x0000C9F5
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000658 RID: 1624
		' (get) Token: 0x06000F96 RID: 3990 RVA: 0x0000E7FE File Offset: 0x0000C9FE
		' (set) Token: 0x06000F97 RID: 3991 RVA: 0x0000E808 File Offset: 0x0000CA08
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000659 RID: 1625
		' (get) Token: 0x06000F98 RID: 3992 RVA: 0x0000E811 File Offset: 0x0000CA11
		' (set) Token: 0x06000F99 RID: 3993 RVA: 0x0000E81B File Offset: 0x0000CA1B
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700065A RID: 1626
		' (get) Token: 0x06000F9A RID: 3994 RVA: 0x0000E824 File Offset: 0x0000CA24
		' (set) Token: 0x06000F9B RID: 3995 RVA: 0x0000E82E File Offset: 0x0000CA2E
		Friend Overridable Property txtFileUrl As TextBox

		' Token: 0x1700065B RID: 1627
		' (get) Token: 0x06000F9C RID: 3996 RVA: 0x0000E837 File Offset: 0x0000CA37
		' (set) Token: 0x06000F9D RID: 3997 RVA: 0x0000E841 File Offset: 0x0000CA41
		Friend Overridable Property Label8 As Label

		' Token: 0x1700065C RID: 1628
		' (get) Token: 0x06000F9E RID: 3998 RVA: 0x0000E84A File Offset: 0x0000CA4A
		' (set) Token: 0x06000F9F RID: 3999 RVA: 0x0000E854 File Offset: 0x0000CA54
		Friend Overridable Property txtPassword As TextBox

		' Token: 0x1700065D RID: 1629
		' (get) Token: 0x06000FA0 RID: 4000 RVA: 0x0000E85D File Offset: 0x0000CA5D
		' (set) Token: 0x06000FA1 RID: 4001 RVA: 0x0000E867 File Offset: 0x0000CA67
		Friend Overridable Property Label7 As Label

		' Token: 0x1700065E RID: 1630
		' (get) Token: 0x06000FA2 RID: 4002 RVA: 0x0000E870 File Offset: 0x0000CA70
		' (set) Token: 0x06000FA3 RID: 4003 RVA: 0x0000E87A File Offset: 0x0000CA7A
		Friend Overridable Property txtUserId As TextBox

		' Token: 0x1700065F RID: 1631
		' (get) Token: 0x06000FA4 RID: 4004 RVA: 0x0000E883 File Offset: 0x0000CA83
		' (set) Token: 0x06000FA5 RID: 4005 RVA: 0x0000E88D File Offset: 0x0000CA8D
		Friend Overridable Property Label6 As Label

		' Token: 0x17000660 RID: 1632
		' (get) Token: 0x06000FA6 RID: 4006 RVA: 0x0000E896 File Offset: 0x0000CA96
		' (set) Token: 0x06000FA7 RID: 4007 RVA: 0x0000E8A0 File Offset: 0x0000CAA0
		Friend Overridable Property txtFtpUrl As TextBox

		' Token: 0x17000661 RID: 1633
		' (get) Token: 0x06000FA8 RID: 4008 RVA: 0x0000E8A9 File Offset: 0x0000CAA9
		' (set) Token: 0x06000FA9 RID: 4009 RVA: 0x0000E8B3 File Offset: 0x0000CAB3
		Friend Overridable Property Label5 As Label

		' Token: 0x17000662 RID: 1634
		' (get) Token: 0x06000FAA RID: 4010 RVA: 0x0000E8BC File Offset: 0x0000CABC
		' (set) Token: 0x06000FAB RID: 4011 RVA: 0x0000E8C6 File Offset: 0x0000CAC6
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17000663 RID: 1635
		' (get) Token: 0x06000FAC RID: 4012 RVA: 0x0000E8CF File Offset: 0x0000CACF
		' (set) Token: 0x06000FAD RID: 4013 RVA: 0x0000E8D9 File Offset: 0x0000CAD9
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17000664 RID: 1636
		' (get) Token: 0x06000FAE RID: 4014 RVA: 0x0000E8E2 File Offset: 0x0000CAE2
		' (set) Token: 0x06000FAF RID: 4015 RVA: 0x0000E8EC File Offset: 0x0000CAEC
		Friend Overridable Property Label2 As Label

		' Token: 0x17000665 RID: 1637
		' (get) Token: 0x06000FB0 RID: 4016 RVA: 0x0000E8F5 File Offset: 0x0000CAF5
		' (set) Token: 0x06000FB1 RID: 4017 RVA: 0x0000E8FF File Offset: 0x0000CAFF
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000666 RID: 1638
		' (get) Token: 0x06000FB2 RID: 4018 RVA: 0x0000E908 File Offset: 0x0000CB08
		' (set) Token: 0x06000FB3 RID: 4019 RVA: 0x0000E912 File Offset: 0x0000CB12
		Friend Overridable Property Label1 As Label

		' Token: 0x17000667 RID: 1639
		' (get) Token: 0x06000FB4 RID: 4020 RVA: 0x0000E91B File Offset: 0x0000CB1B
		' (set) Token: 0x06000FB5 RID: 4021 RVA: 0x0000E925 File Offset: 0x0000CB25
		Friend Overridable Property btnLogout As Button

		' Token: 0x17000668 RID: 1640
		' (get) Token: 0x06000FB6 RID: 4022 RVA: 0x0000E92E File Offset: 0x0000CB2E
		' (set) Token: 0x06000FB7 RID: 4023 RVA: 0x0000E938 File Offset: 0x0000CB38
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x06000FB8 RID: 4024 RVA: 0x0000E941 File Offset: 0x0000CB41
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x06000FB9 RID: 4025 RVA: 0x000BA090 File Offset: 0x000B8290
		Private Sub Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.txtFtpUrl.Text = ""
			Me.txtUserId.Text = ""
			Me.txtPassword.Text = ""
			Me.txtFileUrl.Text = ""
			Me.GetData()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x06000FBA RID: 4026 RVA: 0x000BA120 File Offset: 0x000B8320
		Private Sub Button4_Click(sender As Object, e As EventArgs)
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
					Dim flag3 As Boolean = (Operators.CompareString(Me.ComboBox1.Text, "", False) = 0) Or (Me.ComboBox1.SelectedIndex = -1)
					If flag3 Then
						MessageBox.Show("Please fill Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.ComboBox1.Focus()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.txtFtpUrl.Text, "", False) = 0
						If flag4 Then
							MessageBox.Show("Please enter FTP url", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtFtpUrl.Focus()
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtUserId.Text, "", False) = 0
							If flag5 Then
								MessageBox.Show("Please enter FTP user name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtUserId.Focus()
							Else
								Dim flag6 As Boolean = Operators.CompareString(Me.txtPassword.Text, "", False) = 0
								If flag6 Then
									MessageBox.Show("Please enter FTP password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtPassword.Focus()
								Else
									Dim flag7 As Boolean = Operators.CompareString(Me.txtFileUrl.Text, "", False) = 0
									If flag7 Then
										MessageBox.Show("Please enter file url", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtFileUrl.Focus()
									Else
										Try
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text2 As String = "Select count(*) from FTP_Category Having count(*) >= 1"
											ModCommonClasses.cmd = New SqlCommand(text2)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
											If flag8 Then
												MessageBox.Show("Record Already Exists" & vbCrLf & "Please update the information only", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag9 Then
													ModCommonClasses.rdr.Close()
												End If
											Else
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text3 As String = "insert into FTP_Category(c2,FtpUrl,FtpUser,FtpPassword,FileUrl) VALUES (@d1,@d2,@d3,@d4,@d5)"
												ModCommonClasses.cmd = New SqlCommand(text3)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtFtpUrl.Text.TrimEnd(New Char(-1) {}))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtUserId.Text.TrimEnd(New Char(-1) {}))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtPassword.Text.TrimEnd(New Char(-1) {}))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtFileUrl.Text.TrimEnd(New Char(-1) {}))
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
												MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Me.Button4.Enabled = True
												Me.Button3.Enabled = False
												Me.Button2.Enabled = False
												Me.GetData()
												Me.Clear()
											End If
										Catch ex As Exception
											MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End Try
									End If
								End If
							End If
						End If
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x06000FBB RID: 4027 RVA: 0x000BA584 File Offset: 0x000B8784
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT ID,RTRIM(c2),FtpUrl,FtpUser,FtpPassword,FileUrl from WappApi ORDER BY ID", ModCommonClasses.con)
				ModCommonClasses.rdr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
