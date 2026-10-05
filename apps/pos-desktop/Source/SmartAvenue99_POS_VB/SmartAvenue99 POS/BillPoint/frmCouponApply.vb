Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000D3 RID: 211
	<DesignerGenerated()>
	Public Partial Class frmCouponApply
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060025C5 RID: 9669 RVA: 0x0017EF18 File Offset: 0x0017D118
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCouponApply_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCouponApply_KeyDown
			AddHandler MyBase.FormClosed, AddressOf Me.frmCouponApply_FormClosed
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000EE9 RID: 3817
		' (get) Token: 0x060025C8 RID: 9672 RVA: 0x00019409 File Offset: 0x00017609
		' (set) Token: 0x060025C9 RID: 9673 RVA: 0x0017F8F8 File Offset: 0x0017DAF8
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EEA RID: 3818
		' (get) Token: 0x060025CA RID: 9674 RVA: 0x00019413 File Offset: 0x00017613
		' (set) Token: 0x060025CB RID: 9675 RVA: 0x0001941D File Offset: 0x0001761D
		Friend Overridable Property Label1 As Label

		' Token: 0x17000EEB RID: 3819
		' (get) Token: 0x060025CC RID: 9676 RVA: 0x00019426 File Offset: 0x00017626
		' (set) Token: 0x060025CD RID: 9677 RVA: 0x0017F93C File Offset: 0x0017DB3C
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

		' Token: 0x17000EEC RID: 3820
		' (get) Token: 0x060025CE RID: 9678 RVA: 0x00019430 File Offset: 0x00017630
		' (set) Token: 0x060025CF RID: 9679 RVA: 0x0001943A File Offset: 0x0001763A
		Friend Overridable Property Label2 As Label

		' Token: 0x17000EED RID: 3821
		' (get) Token: 0x060025D0 RID: 9680 RVA: 0x00019443 File Offset: 0x00017643
		' (set) Token: 0x060025D1 RID: 9681 RVA: 0x0001944D File Offset: 0x0001764D
		Friend Overridable Property Label3 As Label

		' Token: 0x17000EEE RID: 3822
		' (get) Token: 0x060025D2 RID: 9682 RVA: 0x00019456 File Offset: 0x00017656
		' (set) Token: 0x060025D3 RID: 9683 RVA: 0x00019460 File Offset: 0x00017660
		Friend Overridable Property Label4 As Label

		' Token: 0x17000EEF RID: 3823
		' (get) Token: 0x060025D4 RID: 9684 RVA: 0x00019469 File Offset: 0x00017669
		' (set) Token: 0x060025D5 RID: 9685 RVA: 0x00019473 File Offset: 0x00017673
		Friend Overridable Property Label5 As Label

		' Token: 0x17000EF0 RID: 3824
		' (get) Token: 0x060025D6 RID: 9686 RVA: 0x0001947C File Offset: 0x0001767C
		' (set) Token: 0x060025D7 RID: 9687 RVA: 0x00019486 File Offset: 0x00017686
		Friend Overridable Property Label6 As Label

		' Token: 0x17000EF1 RID: 3825
		' (get) Token: 0x060025D8 RID: 9688 RVA: 0x0001948F File Offset: 0x0001768F
		' (set) Token: 0x060025D9 RID: 9689 RVA: 0x0017F980 File Offset: 0x0017DB80
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

		' Token: 0x17000EF2 RID: 3826
		' (get) Token: 0x060025DA RID: 9690 RVA: 0x00019499 File Offset: 0x00017699
		' (set) Token: 0x060025DB RID: 9691 RVA: 0x000194A3 File Offset: 0x000176A3
		Friend Overridable Property Label7 As Label

		' Token: 0x17000EF3 RID: 3827
		' (get) Token: 0x060025DC RID: 9692 RVA: 0x000194AC File Offset: 0x000176AC
		' (set) Token: 0x060025DD RID: 9693 RVA: 0x000194B6 File Offset: 0x000176B6
		Friend Overridable Property Label8 As Label

		' Token: 0x17000EF4 RID: 3828
		' (get) Token: 0x060025DE RID: 9694 RVA: 0x000194BF File Offset: 0x000176BF
		' (set) Token: 0x060025DF RID: 9695 RVA: 0x000194C9 File Offset: 0x000176C9
		Friend Overridable Property Label9 As Label

		' Token: 0x060025E0 RID: 9696 RVA: 0x0017F9C4 File Offset: 0x0017DBC4
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Select CouponCode from Coupondb where ValidUpto < cast(getdate() as date) and CouponCode=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Coupon Code has already been expired !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.TextBox1.Focus()
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
			Else
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "Select CouponCode from Coupondb where CouponStatus='USED' and CouponCode=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
				If flag3 Then
					MessageBox.Show("Coupon Code has already been Used !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.TextBox1.Focus()
					Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag4 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "Select CouponCode from Coupondb where OfferStatus='Disabled' and CouponCode=@d1"
					ModCommonClasses.cmd = New SqlCommand(text3)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
					If flag5 Then
						MessageBox.Show("Coupon Code Offer has already been disabled !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox1.Focus()
						Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag6 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						Try
							ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
							ModCommonClasses.con1.Open()
							ModCommonClasses.cmd1 = ModCommonClasses.con1.CreateCommand()
							ModCommonClasses.cmd1.CommandText = "SELECT RTRIM(Name),RTRIM(Contact),(OfferAmt),RTRIM(CouponStatus),(IssueDate) from Coupondb where CouponCode=@d1"
							ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
							ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
							Dim flag7 As Boolean = ModCommonClasses.rdr1.Read()
							If flag7 Then
								Me.Label2.Text = "Name : " + ModCommonClasses.rdr1.GetValue(0).ToString()
								Me.Label3.Text = "Contact No : " + ModCommonClasses.rdr1.GetValue(1).ToString()
								Me.Label4.Text = "Amount : " + Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
								Me.Label8.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
								Me.Label5.Text = "Status : " + ModCommonClasses.rdr1.GetValue(3).ToString()
								Me.Label6.Text = "Issue Date : " + ModCommonClasses.rdr1.GetValue(4).ToString().Substring(0, 10)
							Else
								Me.Label2.Text = "Name : "
								Me.Label3.Text = "Contact No : "
								Me.Label4.Text = "Amount : "
								Me.Label5.Text = "Status : "
								Me.Label6.Text = "Issue Date : "
								Me.Label8.Text = ""
								MessageBox.Show("Coupon Code Not Found !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End If
							Dim flag8 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
							If flag8 Then
								ModCommonClasses.rdr1.Close()
							End If
							Dim flag9 As Boolean = ModCommonClasses.con1.State = ConnectionState.Open
							If flag9 Then
								ModCommonClasses.con1.Close()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060025E1 RID: 9697 RVA: 0x0017FEF8 File Offset: 0x0017E0F8
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select CouponCode from Coupondb where ValidUpto < cast(getdate() as date) and CouponCode=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Coupon Code has already been expired !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.TextBox1.Focus()
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "Select CouponCode from Coupondb where CouponStatus='USED' and CouponCode=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
					If flag4 Then
						MessageBox.Show("Coupon Code has already been Used !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox1.Focus()
						Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag5 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "Select CouponCode from Coupondb where OfferStatus='Disabled' and CouponCode=@d1"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
						If flag6 Then
							MessageBox.Show("Coupon Code Offer has already been disabled !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.TextBox1.Focus()
							Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag7 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							Try
								ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
								ModCommonClasses.con1.Open()
								ModCommonClasses.cmd1 = ModCommonClasses.con1.CreateCommand()
								ModCommonClasses.cmd1.CommandText = "SELECT RTRIM(Name),RTRIM(Contact),(OfferAmt),RTRIM(CouponStatus),(IssueDate) from Coupondb where CouponCode=@d1"
								ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.TextBox1.Text.ToString())
								ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
								Dim flag8 As Boolean = ModCommonClasses.rdr1.Read()
								If flag8 Then
									Me.Label2.Text = "Name : " + ModCommonClasses.rdr1.GetValue(0).ToString()
									Me.Label3.Text = "Contact No : " + ModCommonClasses.rdr1.GetValue(1).ToString()
									Me.Label4.Text = "Amount : " + Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
									Me.Label8.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(2), 2 }, Nothing, Nothing, Nothing)), "0.00")
									Me.Label5.Text = "Status : " + ModCommonClasses.rdr1.GetValue(3).ToString()
									Me.Label6.Text = "Issue Date : " + ModCommonClasses.rdr1.GetValue(4).ToString().Substring(0, 10)
								Else
									Me.Label2.Text = "Name : "
									Me.Label3.Text = "Contact No : "
									Me.Label4.Text = "Amount : "
									Me.Label5.Text = "Status : "
									Me.Label6.Text = "Issue Date : "
									Me.Label8.Text = ""
									MessageBox.Show("Coupon Code Not Found !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End If
								Dim flag9 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
								If flag9 Then
									ModCommonClasses.rdr1.Close()
								End If
								Dim flag10 As Boolean = ModCommonClasses.con1.State = ConnectionState.Open
								If flag10 Then
									ModCommonClasses.con1.Close()
								End If
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060025E2 RID: 9698 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmCouponApply_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060025E3 RID: 9699 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmCouponApply_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub

		' Token: 0x060025E4 RID: 9700 RVA: 0x00180470 File Offset: 0x0017E670
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Are you sure to use coupon code ?" & vbCrLf & vbCrLf & "Note : If you once confirm, Coupon code will be Invalid", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
			If flag Then
				Dim flag2 As Boolean = Conversion.Val(Me.Label8.Text) <= 0.0
				If flag2 Then
					MessageBox.Show("Coupon Code has no sufficient balance !", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Update Coupondb set CouponStatus=@d1 where CouponCode=@d0"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "USED")
					ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.TextBox1.Text).ToString()
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					Dim flag3 As Boolean = Operators.CompareString(Me.Label9.Text, "POS ENTRY", False) = 0
					If flag3 Then
						MyProject.Forms.frmPOS.txtCoupAmt.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
						MyProject.Forms.frmPOS.alldiscountcalc()
						MyProject.Forms.frmPOS.txtNar.Text = "Used Coupen Code : " + Me.TextBox1.Text.TrimEnd(New Char(-1) {}) + ", Amount : " + Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
					End If
					Dim flag4 As Boolean = Operators.CompareString(Me.Label9.Text, "TOUCH POS ENTRY", False) = 0
					If flag4 Then
						MyProject.Forms.frmPOSTouch.txtCoupAmt.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
						MyProject.Forms.frmPOSTouch.alldiscountcalc()
						MyProject.Forms.frmPOSTouch.txtNar.Text = "Used Coupen Code : " + Me.TextBox1.Text.TrimEnd(New Char(-1) {}) + ", Amount : " + Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
					End If
					Dim flag5 As Boolean = Operators.CompareString(Me.Label9.Text, "TOUCH POS ENTRY New", False) = 0
					If flag5 Then
						MyProject.Forms.frmPOSNewTuch.txtCoupAmt.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
						MyProject.Forms.frmPOSNewTuch.alldiscountcalc()
						MyProject.Forms.frmPOSNewTuch.txtNar.Text = "Used Coupen Code : " + Me.TextBox1.Text.TrimEnd(New Char(-1) {}) + ", Amount : " + Strings.Format(Math.Round(Conversion.Val(Me.Label8.Text), 2), "0.00")
					End If
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060025E5 RID: 9701 RVA: 0x000194D2 File Offset: 0x000176D2
		Private Sub frmCouponApply_FormClosed(sender As Object, e As FormClosedEventArgs)
			Me.Label9.Text = ""
		End Sub
	End Class
End Namespace
