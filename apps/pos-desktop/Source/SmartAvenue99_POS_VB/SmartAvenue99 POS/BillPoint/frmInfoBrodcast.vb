Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports FireSharp
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000124 RID: 292
	<DesignerGenerated()>
	Public Partial Class frmInfoBrodcast
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060031D2 RID: 12754 RVA: 0x001ED4C4 File Offset: 0x001EB6C4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmInfoBrodcast_Load
			AddHandler MyBase.Closing, AddressOf Me.frmInfoBrodcast_Closing
			Me.autoUpdateTimer = New Global.System.Windows.Forms.Timer()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001368 RID: 4968
		' (get) Token: 0x060031D5 RID: 12757 RVA: 0x0001EE56 File Offset: 0x0001D056
		' (set) Token: 0x060031D6 RID: 12758 RVA: 0x0001EE60 File Offset: 0x0001D060
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17001369 RID: 4969
		' (get) Token: 0x060031D7 RID: 12759 RVA: 0x0001EE69 File Offset: 0x0001D069
		' (set) Token: 0x060031D8 RID: 12760 RVA: 0x0001EE73 File Offset: 0x0001D073
		Friend Overridable Property btnSave As Button

		' Token: 0x1700136A RID: 4970
		' (get) Token: 0x060031D9 RID: 12761 RVA: 0x0001EE7C File Offset: 0x0001D07C
		' (set) Token: 0x060031DA RID: 12762 RVA: 0x0001EE86 File Offset: 0x0001D086
		Friend Overridable Property TextBox11 As TextBox

		' Token: 0x1700136B RID: 4971
		' (get) Token: 0x060031DB RID: 12763 RVA: 0x0001EE8F File Offset: 0x0001D08F
		' (set) Token: 0x060031DC RID: 12764 RVA: 0x0001EE99 File Offset: 0x0001D099
		Friend Overridable Property TextBox12 As TextBox

		' Token: 0x1700136C RID: 4972
		' (get) Token: 0x060031DD RID: 12765 RVA: 0x0001EEA2 File Offset: 0x0001D0A2
		' (set) Token: 0x060031DE RID: 12766 RVA: 0x0001EEAC File Offset: 0x0001D0AC
		Friend Overridable Property Label23 As Label

		' Token: 0x1700136D RID: 4973
		' (get) Token: 0x060031DF RID: 12767 RVA: 0x0001EEB5 File Offset: 0x0001D0B5
		' (set) Token: 0x060031E0 RID: 12768 RVA: 0x0001EEBF File Offset: 0x0001D0BF
		Friend Overridable Property Label22 As Label

		' Token: 0x1700136E RID: 4974
		' (get) Token: 0x060031E1 RID: 12769 RVA: 0x0001EEC8 File Offset: 0x0001D0C8
		' (set) Token: 0x060031E2 RID: 12770 RVA: 0x0001EED2 File Offset: 0x0001D0D2
		Friend Overridable Property Label21 As Label

		' Token: 0x1700136F RID: 4975
		' (get) Token: 0x060031E3 RID: 12771 RVA: 0x0001EEDB File Offset: 0x0001D0DB
		' (set) Token: 0x060031E4 RID: 12772 RVA: 0x0001EEE5 File Offset: 0x0001D0E5
		Friend Overridable Property TextBox10 As TextBox

		' Token: 0x17001370 RID: 4976
		' (get) Token: 0x060031E5 RID: 12773 RVA: 0x0001EEEE File Offset: 0x0001D0EE
		' (set) Token: 0x060031E6 RID: 12774 RVA: 0x0001EEF8 File Offset: 0x0001D0F8
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17001371 RID: 4977
		' (get) Token: 0x060031E7 RID: 12775 RVA: 0x0001EF01 File Offset: 0x0001D101
		' (set) Token: 0x060031E8 RID: 12776 RVA: 0x0001EF0B File Offset: 0x0001D10B
		Friend Overridable Property Label15 As Label

		' Token: 0x17001372 RID: 4978
		' (get) Token: 0x060031E9 RID: 12777 RVA: 0x0001EF14 File Offset: 0x0001D114
		' (set) Token: 0x060031EA RID: 12778 RVA: 0x0001EF1E File Offset: 0x0001D11E
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x17001373 RID: 4979
		' (get) Token: 0x060031EB RID: 12779 RVA: 0x0001EF27 File Offset: 0x0001D127
		' (set) Token: 0x060031EC RID: 12780 RVA: 0x0001EF31 File Offset: 0x0001D131
		Friend Overridable Property Label14 As Label

		' Token: 0x17001374 RID: 4980
		' (get) Token: 0x060031ED RID: 12781 RVA: 0x0001EF3A File Offset: 0x0001D13A
		' (set) Token: 0x060031EE RID: 12782 RVA: 0x0001EF44 File Offset: 0x0001D144
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17001375 RID: 4981
		' (get) Token: 0x060031EF RID: 12783 RVA: 0x0001EF4D File Offset: 0x0001D14D
		' (set) Token: 0x060031F0 RID: 12784 RVA: 0x0001EF57 File Offset: 0x0001D157
		Friend Overridable Property Label13 As Label

		' Token: 0x17001376 RID: 4982
		' (get) Token: 0x060031F1 RID: 12785 RVA: 0x0001EF60 File Offset: 0x0001D160
		' (set) Token: 0x060031F2 RID: 12786 RVA: 0x0001EF6A File Offset: 0x0001D16A
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17001377 RID: 4983
		' (get) Token: 0x060031F3 RID: 12787 RVA: 0x0001EF73 File Offset: 0x0001D173
		' (set) Token: 0x060031F4 RID: 12788 RVA: 0x0001EF7D File Offset: 0x0001D17D
		Friend Overridable Property Label12 As Label

		' Token: 0x17001378 RID: 4984
		' (get) Token: 0x060031F5 RID: 12789 RVA: 0x0001EF86 File Offset: 0x0001D186
		' (set) Token: 0x060031F6 RID: 12790 RVA: 0x0001EF90 File Offset: 0x0001D190
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17001379 RID: 4985
		' (get) Token: 0x060031F7 RID: 12791 RVA: 0x0001EF99 File Offset: 0x0001D199
		' (set) Token: 0x060031F8 RID: 12792 RVA: 0x0001EFA3 File Offset: 0x0001D1A3
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x1700137A RID: 4986
		' (get) Token: 0x060031F9 RID: 12793 RVA: 0x0001EFAC File Offset: 0x0001D1AC
		' (set) Token: 0x060031FA RID: 12794 RVA: 0x0001EFB6 File Offset: 0x0001D1B6
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700137B RID: 4987
		' (get) Token: 0x060031FB RID: 12795 RVA: 0x0001EFBF File Offset: 0x0001D1BF
		' (set) Token: 0x060031FC RID: 12796 RVA: 0x0001EFC9 File Offset: 0x0001D1C9
		Friend Overridable Property Label10 As Label

		' Token: 0x1700137C RID: 4988
		' (get) Token: 0x060031FD RID: 12797 RVA: 0x0001EFD2 File Offset: 0x0001D1D2
		' (set) Token: 0x060031FE RID: 12798 RVA: 0x0001EFDC File Offset: 0x0001D1DC
		Friend Overridable Property Label9 As Label

		' Token: 0x1700137D RID: 4989
		' (get) Token: 0x060031FF RID: 12799 RVA: 0x0001EFE5 File Offset: 0x0001D1E5
		' (set) Token: 0x06003200 RID: 12800 RVA: 0x0001EFEF File Offset: 0x0001D1EF
		Friend Overridable Property Label8 As Label

		' Token: 0x1700137E RID: 4990
		' (get) Token: 0x06003201 RID: 12801 RVA: 0x0001EFF8 File Offset: 0x0001D1F8
		' (set) Token: 0x06003202 RID: 12802 RVA: 0x0001F002 File Offset: 0x0001D202
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700137F RID: 4991
		' (get) Token: 0x06003203 RID: 12803 RVA: 0x0001F00B File Offset: 0x0001D20B
		' (set) Token: 0x06003204 RID: 12804 RVA: 0x0001F015 File Offset: 0x0001D215
		Friend Overridable Property Label7 As Label

		' Token: 0x17001380 RID: 4992
		' (get) Token: 0x06003205 RID: 12805 RVA: 0x0001F01E File Offset: 0x0001D21E
		' (set) Token: 0x06003206 RID: 12806 RVA: 0x0001F028 File Offset: 0x0001D228
		Friend Overridable Property txtAndroidID As TextBox

		' Token: 0x17001381 RID: 4993
		' (get) Token: 0x06003207 RID: 12807 RVA: 0x0001F031 File Offset: 0x0001D231
		' (set) Token: 0x06003208 RID: 12808 RVA: 0x0001F03B File Offset: 0x0001D23B
		Friend Overridable Property Label6 As Label

		' Token: 0x17001382 RID: 4994
		' (get) Token: 0x06003209 RID: 12809 RVA: 0x0001F044 File Offset: 0x0001D244
		' (set) Token: 0x0600320A RID: 12810 RVA: 0x0001F04E File Offset: 0x0001D24E
		Friend Overridable Property Label3 As Label

		' Token: 0x17001383 RID: 4995
		' (get) Token: 0x0600320B RID: 12811 RVA: 0x0001F057 File Offset: 0x0001D257
		' (set) Token: 0x0600320C RID: 12812 RVA: 0x0001F061 File Offset: 0x0001D261
		Friend Overridable Property btnNew As Button

		' Token: 0x17001384 RID: 4996
		' (get) Token: 0x0600320D RID: 12813 RVA: 0x0001F06A File Offset: 0x0001D26A
		' (set) Token: 0x0600320E RID: 12814 RVA: 0x0001F074 File Offset: 0x0001D274
		Friend Overridable Property Label5 As Label

		' Token: 0x17001385 RID: 4997
		' (get) Token: 0x0600320F RID: 12815 RVA: 0x0001F07D File Offset: 0x0001D27D
		' (set) Token: 0x06003210 RID: 12816 RVA: 0x0001F087 File Offset: 0x0001D287
		Friend Overridable Property Label4 As Label

		' Token: 0x17001386 RID: 4998
		' (get) Token: 0x06003211 RID: 12817 RVA: 0x0001F090 File Offset: 0x0001D290
		' (set) Token: 0x06003212 RID: 12818 RVA: 0x0001F09A File Offset: 0x0001D29A
		Friend Overridable Property Label2 As Label

		' Token: 0x17001387 RID: 4999
		' (get) Token: 0x06003213 RID: 12819 RVA: 0x0001F0A3 File Offset: 0x0001D2A3
		' (set) Token: 0x06003214 RID: 12820 RVA: 0x0001F0AD File Offset: 0x0001D2AD
		Friend Overridable Property txtCID As TextBox

		' Token: 0x17001388 RID: 5000
		' (get) Token: 0x06003215 RID: 12821 RVA: 0x0001F0B6 File Offset: 0x0001D2B6
		' (set) Token: 0x06003216 RID: 12822 RVA: 0x001EEEC0 File Offset: 0x001ED0C0
		Private _txtCustID As TextBox
		Friend Overridable Property txtCustID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustID_TextChanged
				Dim textBox As TextBox = Me._txtCustID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustID = value
				textBox = Me._txtCustID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001389 RID: 5001
		' (get) Token: 0x06003217 RID: 12823 RVA: 0x0001F0C0 File Offset: 0x0001D2C0
		' (set) Token: 0x06003218 RID: 12824 RVA: 0x0001F0CA File Offset: 0x0001D2CA
		Friend Overridable Property txtCustContact As TextBox

		' Token: 0x1700138A RID: 5002
		' (get) Token: 0x06003219 RID: 12825 RVA: 0x0001F0D3 File Offset: 0x0001D2D3
		' (set) Token: 0x0600321A RID: 12826 RVA: 0x0001F0DD File Offset: 0x0001D2DD
		Friend Overridable Property txtCustAddress As TextBox

		' Token: 0x1700138B RID: 5003
		' (get) Token: 0x0600321B RID: 12827 RVA: 0x0001F0E6 File Offset: 0x0001D2E6
		' (set) Token: 0x0600321C RID: 12828 RVA: 0x001EEF04 File Offset: 0x001ED104
		Private _cmbCustomerName As ComboBox
		Friend Overridable Property cmbCustomerName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCustomerName_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCustomerName = value
				comboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600321D RID: 12829 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600321E RID: 12830 RVA: 0x001EEF48 File Offset: 0x001ED148
		Private Sub frmInfoBrodcast_Load(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ID, RTRIM(CustomerID),RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN), RTRIM(EmailID), RTRIM(PAN),RTRIM(Tcs),RTRIM(CardNo),RTRIM(Status),RTRIM(Limit),RTRIM(Lstatus),RTRIM(Address),DiscPer,RTRIM(DiscStatus) from Customer where Name=@d1 order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.txtCustID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtCustContact.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtCustAddress.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.TextBox9.Text = ModCommonClasses.rdr.GetValue(8).ToString()
				Else
					Me.TextBox9.Text = "Not Provided"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.AndroidIDGenerate()
			Try
				Me.AutoUpdater()
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x0600321F RID: 12831 RVA: 0x001EF108 File Offset: 0x001ED308
		Private Sub AutoUpdater()
			Me.Config = New FirebaseConfig() With { .AuthSecret = NextGenOS.Licensing.CloudSettings.Secret("reports"), .BasePath = NextGenOS.Licensing.CloudSettings.Url("reports") }
			Me.Client = New FirebaseClient(Me.Config)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_name", Me.txtAndroidID.Text), Me.cmbCustomerName.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_address", Me.txtAndroidID.Text), Me.txtCustAddress.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_state", Me.txtAndroidID.Text), "")
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_gstin", Me.txtAndroidID.Text), Me.TextBox11.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_contactno", Me.txtAndroidID.Text), Me.txtCustContact.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_email", Me.txtAndroidID.Text), "")
			Me.todayData = New Dictionary(Of String, Dictionary(Of String, String))()
			Me.todayData.Add("Coupon Discount Amount".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Discount Amount" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox1.Text.ToString() } })
			Me.todayData.Add("Coupon Valid From".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Valid From" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox2.Text.ToString() } })
			Me.todayData.Add("Coupon Valid Upto".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Valid Upto" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox4.Text.ToString() } })
			Me.todayData.Add("Offer Status".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Offer Status" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox5.Text.ToString() } })
			Me.todayData.Add("Coupon Code".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Code" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox6.Text.ToString() } })
			Me.todayData.Add("Coupon Status".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Status" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox7.Text.ToString() } })
			Me.todayData.Add("Coupon Issue Date".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Issue Date" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox8.Text.ToString() } })
			Me.todayData.Add("Loyalty Card No".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Loyalty Card No" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox9.Text.ToString() } })
			Me.todayData.Add("Loyalty Point".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Loyalty Point" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox10.Text.ToString() } })
			Dim thread As New Thread(AddressOf Me.UploadThreadEvent)
			thread.Start()
		End Sub

		' Token: 0x06003220 RID: 12832 RVA: 0x001EF8B8 File Offset: 0x001EDAB8
		Private Sub UploadThreadEvent()
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Try
					Me.Client.[Set](Of Dictionary(Of String, Dictionary(Of String, String)))(String.Format("comp/{0}/today/", Me.txtAndroidID.Text), Me.todayData)
				Catch ex As Exception
				End Try
			End If
		End Sub

		' Token: 0x06003221 RID: 12833 RVA: 0x001EF91C File Offset: 0x001EDB1C
		Private Sub AndroidIDGenerate()
			Me.txtAndroidID.Text = ModFunc.MD5Encrypt(Me.txtCustID.Text.TrimEnd(New Char(-1) {}).ToString() + Me.txtCustContact.Text.TrimEnd(New Char(-1) {}).ToString())
		End Sub

		' Token: 0x06003222 RID: 12834 RVA: 0x0001F0F0 File Offset: 0x0001D2F0
		Private Sub txtCustID_TextChanged(sender As Object, e As EventArgs)
			Me.Coupon_Details()
			Me.Loyalty_Details()
		End Sub

		' Token: 0x06003223 RID: 12835 RVA: 0x001EF978 File Offset: 0x001EDB78
		Private Sub Coupon_Details()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = ModCommonClasses.con1.CreateCommand()
				ModCommonClasses.cmd1.CommandText = "SELECT (OfferAmt),(ValidFrom),(ValidUpto),RTRIM(OfferStatus),RTRIM(CouponCode),RTRIM(CouponStatus),(IssueDate) from Coupondb where CustomerID=@d1 order by IssueDate DESC"
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.txtCustID.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr1.Read()
				If flag Then
					Me.TextBox1.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(0), 2 }, Nothing, Nothing, Nothing)), "0.00")
					Me.TextBox2.Text = ModCommonClasses.rdr1.GetValue(1).ToString().Substring(0, 10)
					Me.TextBox4.Text = ModCommonClasses.rdr1.GetValue(2).ToString().Substring(0, 10)
					Me.TextBox5.Text = ModCommonClasses.rdr1.GetValue(3).ToString()
					Me.TextBox6.Text = ModCommonClasses.rdr1.GetValue(4).ToString()
					Me.TextBox7.Text = ModCommonClasses.rdr1.GetValue(5).ToString()
					Me.TextBox8.Text = ModCommonClasses.rdr1.GetValue(6).ToString().Substring(0, 10)
				Else
					Me.TextBox1.Text = "0.00"
					Me.TextBox2.Text = "NA"
					Me.TextBox4.Text = "NA"
					Me.TextBox5.Text = "NA"
					Me.TextBox6.Text = "NA"
					Me.TextBox7.Text = "NA"
					Me.TextBox8.Text = "NA"
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
				MessageBox.Show(ex.Message, "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003224 RID: 12836 RVA: 0x001EFC0C File Offset: 0x001EDE0C
		Private Sub Loyalty_Details()
			Try
				ModCommonClasses.con29 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con29.Open()
				Dim text As String = "SELECT isNULL(Sum(Addpoint),0)-IsNull(Sum(Usepoint),0) from LPoint where Custid=@d1 group By Custid"
				ModCommonClasses.cmd555 = New SqlCommand(text, ModCommonClasses.con29)
				ModCommonClasses.cmd555.Parameters.AddWithValue("@d1", Me.txtCustID.Text.ToString())
				ModCommonClasses.rdr5551 = ModCommonClasses.cmd555.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr5551.Read()
				If flag Then
					Me.TextBox10.Text = ModCommonClasses.rdr5551.GetValue(0).ToString()
				Else
					Me.TextBox10.Text = "0"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr5551 IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr5551.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con29.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con29.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003225 RID: 12837 RVA: 0x0001F101 File Offset: 0x0001D301
		Private Sub frmInfoBrodcast_Closing(sender As Object, e As CancelEventArgs)
			Me.RefreshX()
		End Sub

		' Token: 0x06003226 RID: 12838 RVA: 0x001EFD30 File Offset: 0x001EDF30
		Public Sub RefreshX()
			Me.cmbCustomerName.SelectedIndex = -1
			Me.cmbCustomerName.Text = ""
			Me.cmbCustomerName.Focus()
			Me.txtCID.Text = ""
			Me.txtCustID.Text = ""
			Me.txtCustAddress.Text = ""
			Me.txtCustContact.Text = ""
			Me.txtAndroidID.Text = ""
			Me.TextBox1.Text = "0.00"
			Me.TextBox2.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox5.Text = ""
			Me.TextBox6.Text = ""
			Me.TextBox7.Text = ""
			Me.TextBox8.Text = ""
			Me.TextBox9.Text = ""
			Me.TextBox10.Text = ""
			Me.TextBox11.Text = ""
		End Sub

		' Token: 0x040015B8 RID: 5560
		Private autoUpdateTimer As Global.System.Windows.Forms.Timer

		' Token: 0x040015B9 RID: 5561
		Private Config As IFirebaseConfig

		' Token: 0x040015BA RID: 5562
		Private Client As IFirebaseClient

		' Token: 0x040015BB RID: 5563
		Private todayData As Dictionary(Of String, Dictionary(Of String, String))

		' Token: 0x040015BC RID: 5564
		Private fyData As Dictionary(Of String, Dictionary(Of String, String))
	End Class
End Namespace
