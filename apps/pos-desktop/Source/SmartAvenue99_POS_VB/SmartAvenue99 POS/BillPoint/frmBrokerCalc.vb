Imports System
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
	' Token: 0x02000330 RID: 816
	<DesignerGenerated()>
	Public Partial Class frmBrokerCalc
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BFD0 RID: 49104 RVA: 0x007A2B5C File Offset: 0x007A0D5C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBrokerCalc_Load
			AddHandler MyBase.Closed, AddressOf Me.frmBrokerCalc_Closed
			AddHandler MyBase.KeyDown, AddressOf Me.frmBrokerCalc_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004C53 RID: 19539
		' (get) Token: 0x0600BFD3 RID: 49107 RVA: 0x00055B4D File Offset: 0x00053D4D
		' (set) Token: 0x0600BFD4 RID: 49108 RVA: 0x00055B57 File Offset: 0x00053D57
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004C54 RID: 19540
		' (get) Token: 0x0600BFD5 RID: 49109 RVA: 0x00055B60 File Offset: 0x00053D60
		' (set) Token: 0x0600BFD6 RID: 49110 RVA: 0x00055B6A File Offset: 0x00053D6A
		Friend Overridable Property F2 As TextBox

		' Token: 0x17004C55 RID: 19541
		' (get) Token: 0x0600BFD7 RID: 49111 RVA: 0x00055B73 File Offset: 0x00053D73
		' (set) Token: 0x0600BFD8 RID: 49112 RVA: 0x00055B7D File Offset: 0x00053D7D
		Friend Overridable Property F1 As TextBox

		' Token: 0x17004C56 RID: 19542
		' (get) Token: 0x0600BFD9 RID: 49113 RVA: 0x00055B86 File Offset: 0x00053D86
		' (set) Token: 0x0600BFDA RID: 49114 RVA: 0x00055B90 File Offset: 0x00053D90
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17004C57 RID: 19543
		' (get) Token: 0x0600BFDB RID: 49115 RVA: 0x00055B99 File Offset: 0x00053D99
		' (set) Token: 0x0600BFDC RID: 49116 RVA: 0x00055BA3 File Offset: 0x00053DA3
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17004C58 RID: 19544
		' (get) Token: 0x0600BFDD RID: 49117 RVA: 0x00055BAC File Offset: 0x00053DAC
		' (set) Token: 0x0600BFDE RID: 49118 RVA: 0x00055BB6 File Offset: 0x00053DB6
		Friend Overridable Property dtpDate As DateTimePicker

		' Token: 0x17004C59 RID: 19545
		' (get) Token: 0x0600BFDF RID: 49119 RVA: 0x00055BBF File Offset: 0x00053DBF
		' (set) Token: 0x0600BFE0 RID: 49120 RVA: 0x00055BC9 File Offset: 0x00053DC9
		Friend Overridable Property txtVoucherNo As TextBox

		' Token: 0x17004C5A RID: 19546
		' (get) Token: 0x0600BFE1 RID: 49121 RVA: 0x00055BD2 File Offset: 0x00053DD2
		' (set) Token: 0x0600BFE2 RID: 49122 RVA: 0x00055BDC File Offset: 0x00053DDC
		Friend Overridable Property txtVoucherID As TextBox

		' Token: 0x17004C5B RID: 19547
		' (get) Token: 0x0600BFE3 RID: 49123 RVA: 0x00055BE5 File Offset: 0x00053DE5
		' (set) Token: 0x0600BFE4 RID: 49124 RVA: 0x00055BEF File Offset: 0x00053DEF
		Friend Overridable Property Label3 As Label

		' Token: 0x17004C5C RID: 19548
		' (get) Token: 0x0600BFE5 RID: 49125 RVA: 0x00055BF8 File Offset: 0x00053DF8
		' (set) Token: 0x0600BFE6 RID: 49126 RVA: 0x00055C02 File Offset: 0x00053E02
		Friend Overridable Property Label2 As Label

		' Token: 0x17004C5D RID: 19549
		' (get) Token: 0x0600BFE7 RID: 49127 RVA: 0x00055C0B File Offset: 0x00053E0B
		' (set) Token: 0x0600BFE8 RID: 49128 RVA: 0x00055C15 File Offset: 0x00053E15
		Friend Overridable Property Label1 As Label

		' Token: 0x17004C5E RID: 19550
		' (get) Token: 0x0600BFE9 RID: 49129 RVA: 0x00055C1E File Offset: 0x00053E1E
		' (set) Token: 0x0600BFEA RID: 49130 RVA: 0x00055C28 File Offset: 0x00053E28
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17004C5F RID: 19551
		' (get) Token: 0x0600BFEB RID: 49131 RVA: 0x00055C31 File Offset: 0x00053E31
		' (set) Token: 0x0600BFEC RID: 49132 RVA: 0x00055C3B File Offset: 0x00053E3B
		Friend Overridable Property Label4 As Label

		' Token: 0x17004C60 RID: 19552
		' (get) Token: 0x0600BFED RID: 49133 RVA: 0x00055C44 File Offset: 0x00053E44
		' (set) Token: 0x0600BFEE RID: 49134 RVA: 0x007A3E20 File Offset: 0x007A2020
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

		' Token: 0x17004C61 RID: 19553
		' (get) Token: 0x0600BFEF RID: 49135 RVA: 0x00055C4E File Offset: 0x00053E4E
		' (set) Token: 0x0600BFF0 RID: 49136 RVA: 0x00055C58 File Offset: 0x00053E58
		Friend Overridable Property Label5 As Label

		' Token: 0x17004C62 RID: 19554
		' (get) Token: 0x0600BFF1 RID: 49137 RVA: 0x00055C61 File Offset: 0x00053E61
		' (set) Token: 0x0600BFF2 RID: 49138 RVA: 0x00055C6B File Offset: 0x00053E6B
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17004C63 RID: 19555
		' (get) Token: 0x0600BFF3 RID: 49139 RVA: 0x00055C74 File Offset: 0x00053E74
		' (set) Token: 0x0600BFF4 RID: 49140 RVA: 0x00055C7E File Offset: 0x00053E7E
		Friend Overridable Property Label7 As Label

		' Token: 0x17004C64 RID: 19556
		' (get) Token: 0x0600BFF5 RID: 49141 RVA: 0x00055C87 File Offset: 0x00053E87
		' (set) Token: 0x0600BFF6 RID: 49142 RVA: 0x00055C91 File Offset: 0x00053E91
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17004C65 RID: 19557
		' (get) Token: 0x0600BFF7 RID: 49143 RVA: 0x00055C9A File Offset: 0x00053E9A
		' (set) Token: 0x0600BFF8 RID: 49144 RVA: 0x00055CA4 File Offset: 0x00053EA4
		Friend Overridable Property Label6 As Label

		' Token: 0x17004C66 RID: 19558
		' (get) Token: 0x0600BFF9 RID: 49145 RVA: 0x00055CAD File Offset: 0x00053EAD
		' (set) Token: 0x0600BFFA RID: 49146 RVA: 0x00055CB7 File Offset: 0x00053EB7
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17004C67 RID: 19559
		' (get) Token: 0x0600BFFB RID: 49147 RVA: 0x00055CC0 File Offset: 0x00053EC0
		' (set) Token: 0x0600BFFC RID: 49148 RVA: 0x00055CCA File Offset: 0x00053ECA
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17004C68 RID: 19560
		' (get) Token: 0x0600BFFD RID: 49149 RVA: 0x00055CD3 File Offset: 0x00053ED3
		' (set) Token: 0x0600BFFE RID: 49150 RVA: 0x00055CDD File Offset: 0x00053EDD
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17004C69 RID: 19561
		' (get) Token: 0x0600BFFF RID: 49151 RVA: 0x00055CE6 File Offset: 0x00053EE6
		' (set) Token: 0x0600C000 RID: 49152 RVA: 0x007A3E64 File Offset: 0x007A2064
		Private _Button9 As Button
		Friend Overridable Property Button9 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button9_Click
				Dim button As Button = Me._Button9
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button9 = value
				button = Me._Button9
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C6A RID: 19562
		' (get) Token: 0x0600C001 RID: 49153 RVA: 0x00055CF0 File Offset: 0x00053EF0
		' (set) Token: 0x0600C002 RID: 49154 RVA: 0x007A3EA8 File Offset: 0x007A20A8
		Private _txtVID As TextBox
		Friend Overridable Property txtVID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtVID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtVID_TextChanged
				Dim textBox As TextBox = Me._txtVID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtVID = value
				textBox = Me._txtVID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C6B RID: 19563
		' (get) Token: 0x0600C003 RID: 49155 RVA: 0x00055CFA File Offset: 0x00053EFA
		' (set) Token: 0x0600C004 RID: 49156 RVA: 0x00055D04 File Offset: 0x00053F04
		Friend Overridable Property Label8 As Label

		' Token: 0x17004C6C RID: 19564
		' (get) Token: 0x0600C005 RID: 49157 RVA: 0x00055D0D File Offset: 0x00053F0D
		' (set) Token: 0x0600C006 RID: 49158 RVA: 0x00055D17 File Offset: 0x00053F17
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x17004C6D RID: 19565
		' (get) Token: 0x0600C007 RID: 49159 RVA: 0x00055D20 File Offset: 0x00053F20
		' (set) Token: 0x0600C008 RID: 49160 RVA: 0x00055D2A File Offset: 0x00053F2A
		Friend Overridable Property lblUser As Label

		' Token: 0x0600C009 RID: 49161 RVA: 0x007A3EEC File Offset: 0x007A20EC
		Private Function GenerateIDxyz() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Voucher ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600C00A RID: 49162 RVA: 0x007A4058 File Offset: 0x007A2258
		Private Sub Invoicecodexyz()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c9),RTRIM(c19) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "EXP"
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.txtInvCode1.Text, "", False) = 0
				If flag4 Then
					Me.txtInvCode1.Text = "EXP"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C00B RID: 49163 RVA: 0x007A4230 File Offset: 0x007A2430
		Public Sub autoxyz()
			Try
				Me.txtVoucherID.Text = Me.GenerateIDxyz()
				Me.txtVoucherNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDxyz(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C00C RID: 49164 RVA: 0x007A42D4 File Offset: 0x007A24D4
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(0).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(9, 2)
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

		' Token: 0x0600C00D RID: 49165 RVA: 0x007A4438 File Offset: 0x007A2638
		Public Sub GetInvNo()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Id,VoucherNo from Voucher where Details=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox2.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtVID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtVoucherNo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
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

		' Token: 0x0600C00E RID: 49166 RVA: 0x00055D33 File Offset: 0x00053F33
		Private Sub frmBrokerCalc_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.Invoicecodexyz()
			Me.autoxyz()
			Me.GetInvNo()
		End Sub

		' Token: 0x0600C00F RID: 49167 RVA: 0x007A4570 File Offset: 0x007A2770
		Private Sub Button9_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtVoucherNo.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please fill voucher number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtVoucherNo.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.TextBox1.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please fill details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox2.Focus()
					Else
						Dim flag4 As Boolean = Conversion.Val(Me.TextBox4.Text) = 0.0
						If flag4 Then
							MessageBox.Show("Please fill details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.TextBox4.Focus()
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select * from Company"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = Not ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
								ModCommonClasses.con.Close()
							Else
								Try
									Dim flag7 As Boolean = Me.txtVID.Text.Length > 0
									If flag7 Then
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "Update Voucher set VoucherNo=@d2, Date=@d3,Name=@d4,Details=@d5,GrandTotal=@d7,PMode=@d8 where ID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtVoucherNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.TextBox1.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.TextBox2.Text.TrimEnd(New Char(-1) {}).ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.TextBox4.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "Cash")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtVID.Text))
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteReader()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "delete from Voucher_OtherDetails where VoucherID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtVID.Text))
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text4 As String = "insert into Voucher_OtherDetails(VoucherID,Particulars,Amount,Note,Date,PModeD) VALUES (" + Conversions.ToString(Conversion.Val(Me.txtVID.Text)) + ",@d1,@d2,@d3,@d4,@d5)"
										ModCommonClasses.cmd = New SqlCommand(text4)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Prepare()
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox3.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.TextBox4.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox5.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "Cash")
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.cmd.Parameters.Clear()
										ModCommonClasses.con.Close()
										Dim text5 As String = "updated the Broker voucher having voucher no.'" + Me.txtVoucherNo.Text + "'"
										ModFunc.LogFunc(Me.lblUser.Text, text5)
										ModFunc.LedgerDelete(Me.txtVoucherNo.Text, "Expenses")
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtVoucherNo.Text, "Expenses", New Decimal(Conversion.Val(Me.TextBox4.Text)), 0D, "", Me.TextBox1.Text)
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.TextBox1.Text, Me.txtVoucherNo.Text, "Expenses", 0D, New Decimal(Conversion.Val(Me.TextBox4.Text)), "", Me.TextBox1.Text)
										MessageBox.Show("Successfully Updated", "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Else
										Dim flag8 As Boolean = Me.txtVID.Text.Length = 0
										If flag8 Then
											Me.autoxyz()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text6 As String = "insert into Voucher(Id, VoucherNo, Date,Name,Details,GrandTotal,PMode) Values (@d1,@d2,@d3,@d4,@d5,@d7,@d8)"
											ModCommonClasses.cmd = New SqlCommand(text6)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtVoucherID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtVoucherNo.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.TextBox1.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.TextBox2.Text.TrimEnd(New Char(-1) {}).ToString())
											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.TextBox4.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "Cash")
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.ExecuteReader()
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text7 As String = "insert into Voucher_OtherDetails(VoucherID,Particulars,Amount,Note,Date,PModeD) VALUES (" + Me.txtVoucherID.Text + ",@d1,@d2,@d3,@d4,@d5)"
											ModCommonClasses.cmd = New SqlCommand(text7)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Prepare()
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox3.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.TextBox4.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox5.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "Cash")
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.cmd.Parameters.Clear()
											ModCommonClasses.con.Close()
											Dim text8 As String = "added the new Broker voucher having voucher no.'" + Me.txtVoucherNo.Text + "'"
											ModFunc.LogFunc(Me.lblUser.Text, text8)
											ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtVoucherNo.Text, "Expenses", New Decimal(Conversion.Val(Me.TextBox4.Text)), 0D, "", Me.TextBox1.Text)
											ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.TextBox1.Text, Me.txtVoucherNo.Text, "Expenses", 0D, New Decimal(Conversion.Val(Me.TextBox4.Text)), "", Me.TextBox1.Text)
											MessageBox.Show("Successfully Saved", "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										End If
									End If
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
								MyBase.Close()
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600C010 RID: 49168 RVA: 0x00055D52 File Offset: 0x00053F52
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.GetInvNo()
		End Sub

		' Token: 0x0600C011 RID: 49169 RVA: 0x007A4F74 File Offset: 0x007A3174
		Private Sub frmBrokerCalc_Closed(sender As Object, e As EventArgs)
			Me.txtVID.Text = ""
			Me.txtVoucherNo.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox4.Text = ""
			Me.lblUser.Text = ""
		End Sub

		' Token: 0x0600C012 RID: 49170 RVA: 0x007A4FD8 File Offset: 0x007A31D8
		Private Sub txtVID_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con1.Close()
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = ModCommonClasses.con1.CreateCommand()
				ModCommonClasses.cmd1.CommandText = "SELECT VoucherNo from Voucher where Id=@d1"
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtVID.Text))
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr1.Read()
				If flag Then
					Me.txtVoucherNo.Text = ModCommonClasses.rdr1.GetValue(0).ToString()
				Else
					Me.txtVoucherNo.Text = ""
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr1.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con1.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con1.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C013 RID: 49171 RVA: 0x007A5114 File Offset: 0x007A3314
		Private Sub frmBrokerCalc_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F12
			If flag3 Then
				e.Handled = True
				Me.Button9.PerformClick()
			End If
		End Sub
	End Class
End Namespace
