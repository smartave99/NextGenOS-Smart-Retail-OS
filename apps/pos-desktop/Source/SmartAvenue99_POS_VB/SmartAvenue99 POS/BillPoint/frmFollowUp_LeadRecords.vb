Imports System
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
	' Token: 0x02000113 RID: 275
	<DesignerGenerated()>
	Public Partial Class frmFollowUp_LeadRecords
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002EBF RID: 11967 RVA: 0x0001D835 File Offset: 0x0001BA35
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmFollowUp_LeadRecords_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001239 RID: 4665
		' (get) Token: 0x06002EC2 RID: 11970 RVA: 0x0001D855 File Offset: 0x0001BA55
		' (set) Token: 0x06002EC3 RID: 11971 RVA: 0x0001D85F File Offset: 0x0001BA5F
		Friend Overridable Property dgw As DataGridView

		' Token: 0x1700123A RID: 4666
		' (get) Token: 0x06002EC4 RID: 11972 RVA: 0x0001D868 File Offset: 0x0001BA68
		' (set) Token: 0x06002EC5 RID: 11973 RVA: 0x0001D872 File Offset: 0x0001BA72
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700123B RID: 4667
		' (get) Token: 0x06002EC6 RID: 11974 RVA: 0x0001D87B File Offset: 0x0001BA7B
		' (set) Token: 0x06002EC7 RID: 11975 RVA: 0x001CF2F4 File Offset: 0x001CD4F4
		Private _txtUser As TextBox
		Friend Overridable Property txtUser As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtUser
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtUser_TextChanged
				Dim textBox As TextBox = Me._txtUser
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtUser = value
				textBox = Me._txtUser
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700123C RID: 4668
		' (get) Token: 0x06002EC8 RID: 11976 RVA: 0x0001D885 File Offset: 0x0001BA85
		' (set) Token: 0x06002EC9 RID: 11977 RVA: 0x0001D88F File Offset: 0x0001BA8F
		Friend Overridable Property Label5 As Label

		' Token: 0x1700123D RID: 4669
		' (get) Token: 0x06002ECA RID: 11978 RVA: 0x0001D898 File Offset: 0x0001BA98
		' (set) Token: 0x06002ECB RID: 11979 RVA: 0x0001D8A2 File Offset: 0x0001BAA2
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700123E RID: 4670
		' (get) Token: 0x06002ECC RID: 11980 RVA: 0x0001D8AB File Offset: 0x0001BAAB
		' (set) Token: 0x06002ECD RID: 11981 RVA: 0x0001D8B5 File Offset: 0x0001BAB5
		Friend Overridable Property GelButton1 As GelButton

		' Token: 0x1700123F RID: 4671
		' (get) Token: 0x06002ECE RID: 11982 RVA: 0x0001D8BE File Offset: 0x0001BABE
		' (set) Token: 0x06002ECF RID: 11983 RVA: 0x0001D8C8 File Offset: 0x0001BAC8
		Friend Overridable Property GelButton3 As GelButton

		' Token: 0x17001240 RID: 4672
		' (get) Token: 0x06002ED0 RID: 11984 RVA: 0x0001D8D1 File Offset: 0x0001BAD1
		' (set) Token: 0x06002ED1 RID: 11985 RVA: 0x0001D8DB File Offset: 0x0001BADB
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17001241 RID: 4673
		' (get) Token: 0x06002ED2 RID: 11986 RVA: 0x0001D8E4 File Offset: 0x0001BAE4
		' (set) Token: 0x06002ED3 RID: 11987 RVA: 0x001CF338 File Offset: 0x001CD538
		Private _txtCustomer As TextBox
		Friend Overridable Property txtCustomer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomer_TextChanged
				Dim textBox As TextBox = Me._txtCustomer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomer = value
				textBox = Me._txtCustomer
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001242 RID: 4674
		' (get) Token: 0x06002ED4 RID: 11988 RVA: 0x0001D8EE File Offset: 0x0001BAEE
		' (set) Token: 0x06002ED5 RID: 11989 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
		Friend Overridable Property Label4 As Label

		' Token: 0x17001243 RID: 4675
		' (get) Token: 0x06002ED6 RID: 11990 RVA: 0x0001D901 File Offset: 0x0001BB01
		' (set) Token: 0x06002ED7 RID: 11991 RVA: 0x0001D90B File Offset: 0x0001BB0B
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17001244 RID: 4676
		' (get) Token: 0x06002ED8 RID: 11992 RVA: 0x0001D914 File Offset: 0x0001BB14
		' (set) Token: 0x06002ED9 RID: 11993 RVA: 0x0001D91E File Offset: 0x0001BB1E
		Friend Overridable Property Label2 As Label

		' Token: 0x17001245 RID: 4677
		' (get) Token: 0x06002EDA RID: 11994 RVA: 0x0001D927 File Offset: 0x0001BB27
		' (set) Token: 0x06002EDB RID: 11995 RVA: 0x0001D931 File Offset: 0x0001BB31
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17001246 RID: 4678
		' (get) Token: 0x06002EDC RID: 11996 RVA: 0x0001D93A File Offset: 0x0001BB3A
		' (set) Token: 0x06002EDD RID: 11997 RVA: 0x001CF37C File Offset: 0x001CD57C
		Private _txtLead_Id As TextBox
		Friend Overridable Property txtLead_Id As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtLead_Id
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtLead_Id_TextChanged
				Dim textBox As TextBox = Me._txtLead_Id
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtLead_Id = value
				textBox = Me._txtLead_Id
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001247 RID: 4679
		' (get) Token: 0x06002EDE RID: 11998 RVA: 0x0001D944 File Offset: 0x0001BB44
		' (set) Token: 0x06002EDF RID: 11999 RVA: 0x0001D94E File Offset: 0x0001BB4E
		Friend Overridable Property Label3 As Label

		' Token: 0x17001248 RID: 4680
		' (get) Token: 0x06002EE0 RID: 12000 RVA: 0x0001D957 File Offset: 0x0001BB57
		' (set) Token: 0x06002EE1 RID: 12001 RVA: 0x0001D961 File Offset: 0x0001BB61
		Friend Overridable Property dtpFrom As DateTimePicker

		' Token: 0x17001249 RID: 4681
		' (get) Token: 0x06002EE2 RID: 12002 RVA: 0x0001D96A File Offset: 0x0001BB6A
		' (set) Token: 0x06002EE3 RID: 12003 RVA: 0x0001D974 File Offset: 0x0001BB74
		Friend Overridable Property lblUserType As Label

		' Token: 0x1700124A RID: 4682
		' (get) Token: 0x06002EE4 RID: 12004 RVA: 0x0001D97D File Offset: 0x0001BB7D
		' (set) Token: 0x06002EE5 RID: 12005 RVA: 0x0001D987 File Offset: 0x0001BB87
		Friend Overridable Property lblUser As Label

		' Token: 0x1700124B RID: 4683
		' (get) Token: 0x06002EE6 RID: 12006 RVA: 0x0001D990 File Offset: 0x0001BB90
		' (set) Token: 0x06002EE7 RID: 12007 RVA: 0x0001D99A File Offset: 0x0001BB9A
		Friend Overridable Property Label6 As Label

		' Token: 0x1700124C RID: 4684
		' (get) Token: 0x06002EE8 RID: 12008 RVA: 0x0001D9A3 File Offset: 0x0001BBA3
		' (set) Token: 0x06002EE9 RID: 12009 RVA: 0x0001D9AD File Offset: 0x0001BBAD
		Friend Overridable Property Label7 As Label

		' Token: 0x1700124D RID: 4685
		' (get) Token: 0x06002EEA RID: 12010 RVA: 0x0001D9B6 File Offset: 0x0001BBB6
		' (set) Token: 0x06002EEB RID: 12011 RVA: 0x0001D9C0 File Offset: 0x0001BBC0
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x1700124E RID: 4686
		' (get) Token: 0x06002EEC RID: 12012 RVA: 0x0001D9C9 File Offset: 0x0001BBC9
		' (set) Token: 0x06002EED RID: 12013 RVA: 0x0001D9D3 File Offset: 0x0001BBD3
		Friend Overridable Property lblId As Label

		' Token: 0x1700124F RID: 4687
		' (get) Token: 0x06002EEE RID: 12014 RVA: 0x0001D9DC File Offset: 0x0001BBDC
		' (set) Token: 0x06002EEF RID: 12015 RVA: 0x0001D9E6 File Offset: 0x0001BBE6
		Friend Overridable Property dtpTo As DateTimePicker

		' Token: 0x17001250 RID: 4688
		' (get) Token: 0x06002EF0 RID: 12016 RVA: 0x0001D9EF File Offset: 0x0001BBEF
		' (set) Token: 0x06002EF1 RID: 12017 RVA: 0x001CF3C0 File Offset: 0x001CD5C0
		Private _btnSearch As Button
		Friend Overridable Property btnSearch As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSearch_Click
				Dim button As Button = Me._btnSearch
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSearch = value
				button = Me._btnSearch
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001251 RID: 4689
		' (get) Token: 0x06002EF2 RID: 12018 RVA: 0x0001D9F9 File Offset: 0x0001BBF9
		' (set) Token: 0x06002EF3 RID: 12019 RVA: 0x0001DA03 File Offset: 0x0001BC03
		Friend Overridable Property Id As DataGridViewTextBoxColumn

		' Token: 0x17001252 RID: 4690
		' (get) Token: 0x06002EF4 RID: 12020 RVA: 0x0001DA0C File Offset: 0x0001BC0C
		' (set) Token: 0x06002EF5 RID: 12021 RVA: 0x0001DA16 File Offset: 0x0001BC16
		Friend Overridable Property btnfollowup As DataGridViewTextBoxColumn

		' Token: 0x17001253 RID: 4691
		' (get) Token: 0x06002EF6 RID: 12022 RVA: 0x0001DA1F File Offset: 0x0001BC1F
		' (set) Token: 0x06002EF7 RID: 12023 RVA: 0x0001DA29 File Offset: 0x0001BC29
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17001254 RID: 4692
		' (get) Token: 0x06002EF8 RID: 12024 RVA: 0x0001DA32 File Offset: 0x0001BC32
		' (set) Token: 0x06002EF9 RID: 12025 RVA: 0x0001DA3C File Offset: 0x0001BC3C
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17001255 RID: 4693
		' (get) Token: 0x06002EFA RID: 12026 RVA: 0x0001DA45 File Offset: 0x0001BC45
		' (set) Token: 0x06002EFB RID: 12027 RVA: 0x0001DA4F File Offset: 0x0001BC4F
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17001256 RID: 4694
		' (get) Token: 0x06002EFC RID: 12028 RVA: 0x0001DA58 File Offset: 0x0001BC58
		' (set) Token: 0x06002EFD RID: 12029 RVA: 0x0001DA62 File Offset: 0x0001BC62
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17001257 RID: 4695
		' (get) Token: 0x06002EFE RID: 12030 RVA: 0x0001DA6B File Offset: 0x0001BC6B
		' (set) Token: 0x06002EFF RID: 12031 RVA: 0x0001DA75 File Offset: 0x0001BC75
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17001258 RID: 4696
		' (get) Token: 0x06002F00 RID: 12032 RVA: 0x0001DA7E File Offset: 0x0001BC7E
		' (set) Token: 0x06002F01 RID: 12033 RVA: 0x0001DA88 File Offset: 0x0001BC88
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17001259 RID: 4697
		' (get) Token: 0x06002F02 RID: 12034 RVA: 0x0001DA91 File Offset: 0x0001BC91
		' (set) Token: 0x06002F03 RID: 12035 RVA: 0x0001DA9B File Offset: 0x0001BC9B
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700125A RID: 4698
		' (get) Token: 0x06002F04 RID: 12036 RVA: 0x0001DAA4 File Offset: 0x0001BCA4
		' (set) Token: 0x06002F05 RID: 12037 RVA: 0x0001DAAE File Offset: 0x0001BCAE
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700125B RID: 4699
		' (get) Token: 0x06002F06 RID: 12038 RVA: 0x0001DAB7 File Offset: 0x0001BCB7
		' (set) Token: 0x06002F07 RID: 12039 RVA: 0x0001DAC1 File Offset: 0x0001BCC1
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700125C RID: 4700
		' (get) Token: 0x06002F08 RID: 12040 RVA: 0x0001DACA File Offset: 0x0001BCCA
		' (set) Token: 0x06002F09 RID: 12041 RVA: 0x0001DAD4 File Offset: 0x0001BCD4
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x06002F0A RID: 12042 RVA: 0x0001DADD File Offset: 0x0001BCDD
		Private Sub frmFollowUp_LeadRecords_Load(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06002F0B RID: 12043 RVA: 0x001CF404 File Offset: 0x001CD604
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id order by a.followup_date desc", ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id and b.alloted_user='", Me.lblUser.Text, "' order by a.followup_date desc" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), text })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002F0C RID: 12044 RVA: 0x001CF690 File Offset: 0x001CD890
		Private Sub txtLead_Id_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id where b.lead_id like '", Me.txtLead_Id.Text, "%'  order by a.followup_date desc" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id and b.alloted_user='", Me.lblUser.Text, "' and b.lead_id like '", Me.txtLead_Id.Text, "%' order by a.followup_date desc" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), text })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002F0D RID: 12045 RVA: 0x001CF95C File Offset: 0x001CDB5C
		Private Sub txtCustomer_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id where b.customer_name like '", Me.txtCustomer.Text, "%'  order by a.followup_date desc" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id and b.alloted_user='", Me.lblUser.Text, "' and b.customer_name like '", Me.txtCustomer.Text, "%' order by a.followup_date desc" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), text })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002F0E RID: 12046 RVA: 0x001CFC28 File Offset: 0x001CDE28
		Private Sub btnSearch_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " " & vbCrLf & "        a.lead_id id, " & vbCrLf & "        a.lead_status, " & vbCrLf & "        b.lead_id," & vbCrLf & "        CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "            RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "        a.remarks, " & vbCrLf & "        b.customer_name," & vbCrLf & "        b.mobile," & vbCrLf & "        b.state, " & vbCrLf & "        b.productname, " & vbCrLf & "        a.followup_by, " & vbCrLf & "        a.followup_date" & vbCrLf & "    FROM tbl_followup_lead a" & vbCrLf & "    INNER JOIN tbl_lead_master b ON a.lead_id = b.id" & vbCrLf & "    WHERE a.reminder_date BETWEEN @fromDate AND @toDate" & vbCrLf & "    ORDER BY a.followup_date DESC", ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " " & vbCrLf & "        a.lead_id id, " & vbCrLf & "        a.lead_status, " & vbCrLf & "        b.lead_id," & vbCrLf & "        CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "            RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "        a.remarks, " & vbCrLf & "        b.customer_name," & vbCrLf & "        b.mobile," & vbCrLf & "        b.state, " & vbCrLf & "        b.productname, " & vbCrLf & "        a.followup_by, " & vbCrLf & "        a.followup_date" & vbCrLf & "    FROM tbl_followup_lead a" & vbCrLf & "    INNER JOIN tbl_lead_master b ON a.lead_id = b.id" & vbCrLf & "    WHERE b.alloted_user = @user AND a.reminder_date BETWEEN @fromDate AND @toDate" & vbCrLf & "    ORDER BY a.followup_date DESC", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@user", Me.lblUser.Text)
					End If
				End If
				ModCommonClasses.cmd.Parameters.AddWithValue("@fromDate", Me.dtpFrom.Value.[Date])
				ModCommonClasses.cmd.Parameters.AddWithValue("@toDate", Me.dtpTo.Value.[Date])
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), text })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002F0F RID: 12047 RVA: 0x001CFF0C File Offset: 0x001CE10C
		Private Sub txtUser_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id where a.followup_by like '", Me.txtUser.Text, "%'  order by a.followup_date desc" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id and b.alloted_user='", Me.lblUser.Text, "' and a.followup_by like '", Me.txtUser.Text, "%' order by a.followup_date desc" }), ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
					If flag3 Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(11)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), text })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
