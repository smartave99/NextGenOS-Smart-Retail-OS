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
Imports ClosedXML.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200037B RID: 891
	<DesignerGenerated()>
	Public Partial Class GSTSaleReturn
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600D1BA RID: 53690 RVA: 0x0005D46E File Offset: 0x0005B66E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.GSTSaleReturn_Load
			AddHandler MyBase.KeyDown, AddressOf Me.GSTSaleReturn_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700522D RID: 21037
		' (get) Token: 0x0600D1BD RID: 53693 RVA: 0x0005D4A0 File Offset: 0x0005B6A0
		' (set) Token: 0x0600D1BE RID: 53694 RVA: 0x0005D4AA File Offset: 0x0005B6AA
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700522E RID: 21038
		' (get) Token: 0x0600D1BF RID: 53695 RVA: 0x0005D4B3 File Offset: 0x0005B6B3
		' (set) Token: 0x0600D1C0 RID: 53696 RVA: 0x0005D4BD File Offset: 0x0005B6BD
		Friend Overridable Property Label11 As Label

		' Token: 0x1700522F RID: 21039
		' (get) Token: 0x0600D1C1 RID: 53697 RVA: 0x0005D4C6 File Offset: 0x0005B6C6
		' (set) Token: 0x0600D1C2 RID: 53698 RVA: 0x0005D4D0 File Offset: 0x0005B6D0
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17005230 RID: 21040
		' (get) Token: 0x0600D1C3 RID: 53699 RVA: 0x0005D4D9 File Offset: 0x0005B6D9
		' (set) Token: 0x0600D1C4 RID: 53700 RVA: 0x0005D4E3 File Offset: 0x0005B6E3
		Friend Overridable Property Label10 As Label

		' Token: 0x17005231 RID: 21041
		' (get) Token: 0x0600D1C5 RID: 53701 RVA: 0x0005D4EC File Offset: 0x0005B6EC
		' (set) Token: 0x0600D1C6 RID: 53702 RVA: 0x0005D4F6 File Offset: 0x0005B6F6
		Friend Overridable Property Label9 As Label

		' Token: 0x17005232 RID: 21042
		' (get) Token: 0x0600D1C7 RID: 53703 RVA: 0x0005D4FF File Offset: 0x0005B6FF
		' (set) Token: 0x0600D1C8 RID: 53704 RVA: 0x0005D509 File Offset: 0x0005B709
		Friend Overridable Property Label8 As Label

		' Token: 0x17005233 RID: 21043
		' (get) Token: 0x0600D1C9 RID: 53705 RVA: 0x0005D512 File Offset: 0x0005B712
		' (set) Token: 0x0600D1CA RID: 53706 RVA: 0x0005D51C File Offset: 0x0005B71C
		Friend Overridable Property Label7 As Label

		' Token: 0x17005234 RID: 21044
		' (get) Token: 0x0600D1CB RID: 53707 RVA: 0x0005D525 File Offset: 0x0005B725
		' (set) Token: 0x0600D1CC RID: 53708 RVA: 0x0005D52F File Offset: 0x0005B72F
		Friend Overridable Property Label6 As Label

		' Token: 0x17005235 RID: 21045
		' (get) Token: 0x0600D1CD RID: 53709 RVA: 0x0005D538 File Offset: 0x0005B738
		' (set) Token: 0x0600D1CE RID: 53710 RVA: 0x0005D542 File Offset: 0x0005B742
		Friend Overridable Property Label5 As Label

		' Token: 0x17005236 RID: 21046
		' (get) Token: 0x0600D1CF RID: 53711 RVA: 0x0005D54B File Offset: 0x0005B74B
		' (set) Token: 0x0600D1D0 RID: 53712 RVA: 0x0005D555 File Offset: 0x0005B755
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005237 RID: 21047
		' (get) Token: 0x0600D1D1 RID: 53713 RVA: 0x0005D55E File Offset: 0x0005B75E
		' (set) Token: 0x0600D1D2 RID: 53714 RVA: 0x0005D568 File Offset: 0x0005B768
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17005238 RID: 21048
		' (get) Token: 0x0600D1D3 RID: 53715 RVA: 0x0005D571 File Offset: 0x0005B771
		' (set) Token: 0x0600D1D4 RID: 53716 RVA: 0x0005D57B File Offset: 0x0005B77B
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17005239 RID: 21049
		' (get) Token: 0x0600D1D5 RID: 53717 RVA: 0x0005D584 File Offset: 0x0005B784
		' (set) Token: 0x0600D1D6 RID: 53718 RVA: 0x0005D58E File Offset: 0x0005B78E
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x1700523A RID: 21050
		' (get) Token: 0x0600D1D7 RID: 53719 RVA: 0x0005D597 File Offset: 0x0005B797
		' (set) Token: 0x0600D1D8 RID: 53720 RVA: 0x0005D5A1 File Offset: 0x0005B7A1
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x1700523B RID: 21051
		' (get) Token: 0x0600D1D9 RID: 53721 RVA: 0x0005D5AA File Offset: 0x0005B7AA
		' (set) Token: 0x0600D1DA RID: 53722 RVA: 0x0005D5B4 File Offset: 0x0005B7B4
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x1700523C RID: 21052
		' (get) Token: 0x0600D1DB RID: 53723 RVA: 0x0005D5BD File Offset: 0x0005B7BD
		' (set) Token: 0x0600D1DC RID: 53724 RVA: 0x0005D5C7 File Offset: 0x0005B7C7
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x1700523D RID: 21053
		' (get) Token: 0x0600D1DD RID: 53725 RVA: 0x0005D5D0 File Offset: 0x0005B7D0
		' (set) Token: 0x0600D1DE RID: 53726 RVA: 0x0005D5DA File Offset: 0x0005B7DA
		Friend Overridable Property Label3 As Label

		' Token: 0x1700523E RID: 21054
		' (get) Token: 0x0600D1DF RID: 53727 RVA: 0x0005D5E3 File Offset: 0x0005B7E3
		' (set) Token: 0x0600D1E0 RID: 53728 RVA: 0x0005D5ED File Offset: 0x0005B7ED
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700523F RID: 21055
		' (get) Token: 0x0600D1E1 RID: 53729 RVA: 0x0005D5F6 File Offset: 0x0005B7F6
		' (set) Token: 0x0600D1E2 RID: 53730 RVA: 0x0005D600 File Offset: 0x0005B800
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005240 RID: 21056
		' (get) Token: 0x0600D1E3 RID: 53731 RVA: 0x0005D609 File Offset: 0x0005B809
		' (set) Token: 0x0600D1E4 RID: 53732 RVA: 0x0005D613 File Offset: 0x0005B813
		Friend Overridable Property Label2 As Label

		' Token: 0x17005241 RID: 21057
		' (get) Token: 0x0600D1E5 RID: 53733 RVA: 0x0005D61C File Offset: 0x0005B81C
		' (set) Token: 0x0600D1E6 RID: 53734 RVA: 0x0005D626 File Offset: 0x0005B826
		Friend Overridable Property Label4 As Label

		' Token: 0x17005242 RID: 21058
		' (get) Token: 0x0600D1E7 RID: 53735 RVA: 0x0005D62F File Offset: 0x0005B82F
		' (set) Token: 0x0600D1E8 RID: 53736 RVA: 0x0005D639 File Offset: 0x0005B839
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005243 RID: 21059
		' (get) Token: 0x0600D1E9 RID: 53737 RVA: 0x0005D642 File Offset: 0x0005B842
		' (set) Token: 0x0600D1EA RID: 53738 RVA: 0x00829B44 File Offset: 0x00827D44
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005244 RID: 21060
		' (get) Token: 0x0600D1EB RID: 53739 RVA: 0x0005D64C File Offset: 0x0005B84C
		' (set) Token: 0x0600D1EC RID: 53740 RVA: 0x0005D656 File Offset: 0x0005B856
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005245 RID: 21061
		' (get) Token: 0x0600D1ED RID: 53741 RVA: 0x0005D65F File Offset: 0x0005B85F
		' (set) Token: 0x0600D1EE RID: 53742 RVA: 0x0005D669 File Offset: 0x0005B869
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005246 RID: 21062
		' (get) Token: 0x0600D1EF RID: 53743 RVA: 0x0005D672 File Offset: 0x0005B872
		' (set) Token: 0x0600D1F0 RID: 53744 RVA: 0x0005D67C File Offset: 0x0005B87C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005247 RID: 21063
		' (get) Token: 0x0600D1F1 RID: 53745 RVA: 0x0005D685 File Offset: 0x0005B885
		' (set) Token: 0x0600D1F2 RID: 53746 RVA: 0x0005D68F File Offset: 0x0005B88F
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005248 RID: 21064
		' (get) Token: 0x0600D1F3 RID: 53747 RVA: 0x0005D698 File Offset: 0x0005B898
		' (set) Token: 0x0600D1F4 RID: 53748 RVA: 0x0005D6A2 File Offset: 0x0005B8A2
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005249 RID: 21065
		' (get) Token: 0x0600D1F5 RID: 53749 RVA: 0x0005D6AB File Offset: 0x0005B8AB
		' (set) Token: 0x0600D1F6 RID: 53750 RVA: 0x0005D6B5 File Offset: 0x0005B8B5
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700524A RID: 21066
		' (get) Token: 0x0600D1F7 RID: 53751 RVA: 0x0005D6BE File Offset: 0x0005B8BE
		' (set) Token: 0x0600D1F8 RID: 53752 RVA: 0x0005D6C8 File Offset: 0x0005B8C8
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700524B RID: 21067
		' (get) Token: 0x0600D1F9 RID: 53753 RVA: 0x0005D6D1 File Offset: 0x0005B8D1
		' (set) Token: 0x0600D1FA RID: 53754 RVA: 0x0005D6DB File Offset: 0x0005B8DB
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700524C RID: 21068
		' (get) Token: 0x0600D1FB RID: 53755 RVA: 0x0005D6E4 File Offset: 0x0005B8E4
		' (set) Token: 0x0600D1FC RID: 53756 RVA: 0x0005D6EE File Offset: 0x0005B8EE
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700524D RID: 21069
		' (get) Token: 0x0600D1FD RID: 53757 RVA: 0x0005D6F7 File Offset: 0x0005B8F7
		' (set) Token: 0x0600D1FE RID: 53758 RVA: 0x0005D701 File Offset: 0x0005B901
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700524E RID: 21070
		' (get) Token: 0x0600D1FF RID: 53759 RVA: 0x0005D70A File Offset: 0x0005B90A
		' (set) Token: 0x0600D200 RID: 53760 RVA: 0x0005D714 File Offset: 0x0005B914
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700524F RID: 21071
		' (get) Token: 0x0600D201 RID: 53761 RVA: 0x0005D71D File Offset: 0x0005B91D
		' (set) Token: 0x0600D202 RID: 53762 RVA: 0x0005D727 File Offset: 0x0005B927
		Friend Overridable Property Label1 As Label

		' Token: 0x17005250 RID: 21072
		' (get) Token: 0x0600D203 RID: 53763 RVA: 0x0005D730 File Offset: 0x0005B930
		' (set) Token: 0x0600D204 RID: 53764 RVA: 0x00829B88 File Offset: 0x00827D88
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

		' Token: 0x17005251 RID: 21073
		' (get) Token: 0x0600D205 RID: 53765 RVA: 0x0005D73A File Offset: 0x0005B93A
		' (set) Token: 0x0600D206 RID: 53766 RVA: 0x0005D744 File Offset: 0x0005B944
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005252 RID: 21074
		' (get) Token: 0x0600D207 RID: 53767 RVA: 0x0005D74D File Offset: 0x0005B94D
		' (set) Token: 0x0600D208 RID: 53768 RVA: 0x00829BCC File Offset: 0x00827DCC
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

		' Token: 0x17005253 RID: 21075
		' (get) Token: 0x0600D209 RID: 53769 RVA: 0x0005D757 File Offset: 0x0005B957
		' (set) Token: 0x0600D20A RID: 53770 RVA: 0x0005D761 File Offset: 0x0005B961
		Friend Overridable Property btnAddCustomer As GelButton

		' Token: 0x17005254 RID: 21076
		' (get) Token: 0x0600D20B RID: 53771 RVA: 0x0005D76A File Offset: 0x0005B96A
		' (set) Token: 0x0600D20C RID: 53772 RVA: 0x00829C10 File Offset: 0x00827E10
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

		' Token: 0x17005255 RID: 21077
		' (get) Token: 0x0600D20D RID: 53773 RVA: 0x0005D774 File Offset: 0x0005B974
		' (set) Token: 0x0600D20E RID: 53774 RVA: 0x00829C54 File Offset: 0x00827E54
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

		' Token: 0x17005256 RID: 21078
		' (get) Token: 0x0600D20F RID: 53775 RVA: 0x0005D77E File Offset: 0x0005B97E
		' (set) Token: 0x0600D210 RID: 53776 RVA: 0x00829C98 File Offset: 0x00827E98
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

		' Token: 0x0600D211 RID: 53777 RVA: 0x00829CDC File Offset: 0x00827EDC
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
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

		' Token: 0x0600D212 RID: 53778 RVA: 0x00829DB0 File Offset: 0x00827FB0
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(Customer.Name), RTRIM(Customer.GSTIN),  SalesReturn.GrandTotal, ((SalesReturn.GrandTotal - SalesReturn.FreightCharges + SalesReturn.OtherCharges)-(SalesReturn.CGST + SalesReturn.SGST + SalesReturn.IGST + SalesReturn.CESS)), SalesReturn.CGST, SalesReturn.SGST, SalesReturn.IGST, SalesReturn.CESS, (SalesReturn.GrandTotal-(((SalesReturn.GrandTotal - SalesReturn.FreightCharges + SalesReturn.OtherCharges)-(SalesReturn.CGST + SalesReturn.SGST + SalesReturn.IGST + SalesReturn.CESS)) + (SalesReturn.CGST + SalesReturn.SGST + SalesReturn.IGST + SalesReturn.CESS))) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID and SalesReturn.Date between @d1 and @d2 and NOT InvoiceInfo.TaxType='NON GST' order by SalesReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D213 RID: 53779 RVA: 0x00829FB0 File Offset: 0x008281B0
		Private Sub GSTSaleReturn_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.cal()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600D214 RID: 53780 RVA: 0x0082A048 File Offset: 0x00828248
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

		' Token: 0x0600D215 RID: 53781 RVA: 0x0082A1C0 File Offset: 0x008283C0
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x0600D216 RID: 53782 RVA: 0x0082A28C File Offset: 0x0082848C
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

		' Token: 0x0600D217 RID: 53783 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600D218 RID: 53784 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600D219 RID: 53785 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600D21A RID: 53786 RVA: 0x0082A358 File Offset: 0x00828558
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

		' Token: 0x0600D21B RID: 53787 RVA: 0x0082A440 File Offset: 0x00828640
		Private Sub cal()
			Me.TextBox1.Text = "0.00"
			Me.TextBox2.Text = "0.00"
			Me.TextBox3.Text = "0.00"
			Me.TextBox4.Text = "0.00"
			Me.TextBox5.Text = "0.00"
			Me.TextBox6.Text = "0.00"
			Me.TextBox7.Text = "0.00"
			Dim num As Integer = Me.dgw.Rows.Count - 1
			Dim num2 As Double
			For i As Integer = 0 To num
				Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))

					If flag Then
						num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))
					End If

			Next
			Me.TextBox1.Text = Conversions.ToString(num2)
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
			Dim num3 As Integer = Me.dgw.Rows.Count - 1
			Dim num4 As Double
			For j As Integer = 0 To num3
				Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column6").Value))

					If flag2 Then
						num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column6").Value))
					End If

			Next
			Me.TextBox2.Text = Conversions.ToString(num4)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text), 2), "0.00")
			Dim num5 As Integer = Me.dgw.Rows.Count - 1
			Dim num6 As Double
			For k As Integer = 0 To num5
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column7").Value))

					If flag3 Then
						num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column7").Value))
					End If

			Next
			Me.TextBox3.Text = Conversions.ToString(num6)
			Me.TextBox3.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox3.Text), 2), "0.00")
			Dim num7 As Integer = Me.dgw.Rows.Count - 1
			Dim num8 As Double
			For l As Integer = 0 To num7
				Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column8").Value))

					If flag4 Then
						num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column8").Value))
					End If

			Next
			Me.TextBox4.Text = Conversions.ToString(num8)
			Me.TextBox4.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox4.Text), 2), "0.00")
			Dim num9 As Integer = Me.dgw.Rows.Count - 1
			Dim num10 As Double
			For m As Integer = 0 To num9
				Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column9").Value))

					If flag5 Then
						num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column9").Value))
					End If

			Next
			Me.TextBox5.Text = Conversions.ToString(num10)
			Me.TextBox5.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox5.Text), 2), "0.00")
			Dim num11 As Integer = Me.dgw.Rows.Count - 1
			Dim num12 As Double
			For n As Integer = 0 To num11
				Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column10").Value))

					If flag6 Then
						num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column10").Value))
					End If

			Next
			Me.TextBox6.Text = Conversions.ToString(num12)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox6.Text), 2), "0.00")
			Dim num13 As Integer = Me.dgw.Rows.Count - 1
			Dim num15 As Double
			For num14 As Integer = 0 To num13
				Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(num14).Cells("Column11").Value))

					If flag7 Then
						num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(num14).Cells("Column11").Value))
					End If

			Next
			Me.TextBox7.Text = Conversions.ToString(num15)
			Me.TextBox7.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox7.Text), 2), "0.00")
		End Sub

		' Token: 0x0600D21C RID: 53788 RVA: 0x0005D788 File Offset: 0x0005B988
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600D21D RID: 53789 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub GSTSaleReturn_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600D21E RID: 53790 RVA: 0x0005D7A4 File Offset: 0x0005B9A4
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
			Me.cal()
		End Sub

		' Token: 0x0600D21F RID: 53791 RVA: 0x0005D7CD File Offset: 0x0005B9CD
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.cal()
		End Sub

		' Token: 0x0600D220 RID: 53792 RVA: 0x0082AAA8 File Offset: 0x00828CA8
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dgw.RowCount = 0
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = dataTable
				dataTable2.Columns.Add("BillNo")
				dataTable2.Columns.Add("Date")
				dataTable2.Columns.Add("CName")
				dataTable2.Columns.Add("GSTIN")
				dataTable2.Columns.Add("BillAmt")
				dataTable2.Columns.Add("TxblAmt")
				dataTable2.Columns.Add("CGSTAmt")
				dataTable2.Columns.Add("SGSTAmt")
				dataTable2.Columns.Add("IGSTAmt")
				dataTable2.Columns.Add("CESSAmt")
				dataTable2.Columns.Add("OtherAmt")
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataTable.Rows.Add(New Object() { dataGridViewRow.Cells(0).Value, dataGridViewRow.Cells(1).Value, dataGridViewRow.Cells(2).Value, dataGridViewRow.Cells(3).Value, dataGridViewRow.Cells(4).Value, dataGridViewRow.Cells(5).Value, dataGridViewRow.Cells(6).Value, dataGridViewRow.Cells(7).Value, dataGridViewRow.Cells(8).Value, dataGridViewRow.Cells(9).Value, dataGridViewRow.Cells(10).Value })
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim reportDocument As ReportDocument = New rptGSTSale()
				reportDocument.SetDataSource(dataTable)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				Dim textObject As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text27"), TextObject)
				textObject.Text = Me.dtpDateFrom.Text
				Dim textObject2 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text28"), TextObject)
				textObject2.Text = Me.dtpDateTo.Text
				Dim textObject3 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text22"), TextObject)
				textObject3.Text = Me.Label1.Text
				Dim textObject4 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text3"), TextObject)
				textObject4.Text = "Customer Name"
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub

		' Token: 0x0600D221 RID: 53793 RVA: 0x0082AE70 File Offset: 0x00829070
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
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
	End Class
End Namespace
