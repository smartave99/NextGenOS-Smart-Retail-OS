Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace BillPoint
	' Token: 0x0200010C RID: 268
	<DesignerGenerated()>
	Public Partial Class frmEWayBill
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002B6A RID: 11114 RVA: 0x0001BCCC File Offset: 0x00019ECC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEWayBill_Load
			Me.token_no = ""
			Me.strJson = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x170010DA RID: 4314
		' (get) Token: 0x06002B6D RID: 11117 RVA: 0x0001BD05 File Offset: 0x00019F05
		' (set) Token: 0x06002B6E RID: 11118 RVA: 0x0001BD0F File Offset: 0x00019F0F
		Friend Overridable Property txtInvoiceNo As TextBox

		' Token: 0x170010DB RID: 4315
		' (get) Token: 0x06002B6F RID: 11119 RVA: 0x0001BD18 File Offset: 0x00019F18
		' (set) Token: 0x06002B70 RID: 11120 RVA: 0x0001BD22 File Offset: 0x00019F22
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170010DC RID: 4316
		' (get) Token: 0x06002B71 RID: 11121 RVA: 0x0001BD2B File Offset: 0x00019F2B
		' (set) Token: 0x06002B72 RID: 11122 RVA: 0x001AE0D4 File Offset: 0x001AC2D4
		Private _btnEwaybill_Gen As GelButton
		Friend Overridable Property btnEwaybill_Gen As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnEwaybill_Gen
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnEwaybill_Gen_Click
				Dim gelButton As GelButton = Me._btnEwaybill_Gen
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnEwaybill_Gen = value
				gelButton = Me._btnEwaybill_Gen
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170010DD RID: 4317
		' (get) Token: 0x06002B73 RID: 11123 RVA: 0x0001BD35 File Offset: 0x00019F35
		' (set) Token: 0x06002B74 RID: 11124 RVA: 0x0001BD3F File Offset: 0x00019F3F
		Friend Overridable Property txt_transporter_document_number As TextBox

		' Token: 0x170010DE RID: 4318
		' (get) Token: 0x06002B75 RID: 11125 RVA: 0x0001BD48 File Offset: 0x00019F48
		' (set) Token: 0x06002B76 RID: 11126 RVA: 0x0001BD52 File Offset: 0x00019F52
		Friend Overridable Property Label2 As Label

		' Token: 0x170010DF RID: 4319
		' (get) Token: 0x06002B77 RID: 11127 RVA: 0x0001BD5B File Offset: 0x00019F5B
		' (set) Token: 0x06002B78 RID: 11128 RVA: 0x0001BD65 File Offset: 0x00019F65
		Friend Overridable Property txt_transporter_name As TextBox

		' Token: 0x170010E0 RID: 4320
		' (get) Token: 0x06002B79 RID: 11129 RVA: 0x0001BD6E File Offset: 0x00019F6E
		' (set) Token: 0x06002B7A RID: 11130 RVA: 0x0001BD78 File Offset: 0x00019F78
		Friend Overridable Property Label1 As Label

		' Token: 0x170010E1 RID: 4321
		' (get) Token: 0x06002B7B RID: 11131 RVA: 0x0001BD81 File Offset: 0x00019F81
		' (set) Token: 0x06002B7C RID: 11132 RVA: 0x0001BD8B File Offset: 0x00019F8B
		Friend Overridable Property txtTransporterID As TextBox

		' Token: 0x170010E2 RID: 4322
		' (get) Token: 0x06002B7D RID: 11133 RVA: 0x0001BD94 File Offset: 0x00019F94
		' (set) Token: 0x06002B7E RID: 11134 RVA: 0x0001BD9E File Offset: 0x00019F9E
		Friend Overridable Property Label3 As Label

		' Token: 0x170010E3 RID: 4323
		' (get) Token: 0x06002B7F RID: 11135 RVA: 0x0001BDA7 File Offset: 0x00019FA7
		' (set) Token: 0x06002B80 RID: 11136 RVA: 0x0001BDB1 File Offset: 0x00019FB1
		Friend Overridable Property txt_transportation_mode As TextBox

		' Token: 0x170010E4 RID: 4324
		' (get) Token: 0x06002B81 RID: 11137 RVA: 0x0001BDBA File Offset: 0x00019FBA
		' (set) Token: 0x06002B82 RID: 11138 RVA: 0x0001BDC4 File Offset: 0x00019FC4
		Friend Overridable Property Label6 As Label

		' Token: 0x170010E5 RID: 4325
		' (get) Token: 0x06002B83 RID: 11139 RVA: 0x0001BDCD File Offset: 0x00019FCD
		' (set) Token: 0x06002B84 RID: 11140 RVA: 0x0001BDD7 File Offset: 0x00019FD7
		Friend Overridable Property Label4 As Label

		' Token: 0x170010E6 RID: 4326
		' (get) Token: 0x06002B85 RID: 11141 RVA: 0x0001BDE0 File Offset: 0x00019FE0
		' (set) Token: 0x06002B86 RID: 11142 RVA: 0x0001BDEA File Offset: 0x00019FEA
		Friend Overridable Property txt_vehicle_type As TextBox

		' Token: 0x170010E7 RID: 4327
		' (get) Token: 0x06002B87 RID: 11143 RVA: 0x0001BDF3 File Offset: 0x00019FF3
		' (set) Token: 0x06002B88 RID: 11144 RVA: 0x0001BDFD File Offset: 0x00019FFD
		Friend Overridable Property Label9 As Label

		' Token: 0x170010E8 RID: 4328
		' (get) Token: 0x06002B89 RID: 11145 RVA: 0x0001BE06 File Offset: 0x0001A006
		' (set) Token: 0x06002B8A RID: 11146 RVA: 0x0001BE10 File Offset: 0x0001A010
		Friend Overridable Property txt_vehicle_number As TextBox

		' Token: 0x170010E9 RID: 4329
		' (get) Token: 0x06002B8B RID: 11147 RVA: 0x0001BE19 File Offset: 0x0001A019
		' (set) Token: 0x06002B8C RID: 11148 RVA: 0x0001BE23 File Offset: 0x0001A023
		Friend Overridable Property Label8 As Label

		' Token: 0x170010EA RID: 4330
		' (get) Token: 0x06002B8D RID: 11149 RVA: 0x0001BE2C File Offset: 0x0001A02C
		' (set) Token: 0x06002B8E RID: 11150 RVA: 0x0001BE36 File Offset: 0x0001A036
		Friend Overridable Property txt_transportation_distance As TextBox

		' Token: 0x170010EB RID: 4331
		' (get) Token: 0x06002B8F RID: 11151 RVA: 0x0001BE3F File Offset: 0x0001A03F
		' (set) Token: 0x06002B90 RID: 11152 RVA: 0x0001BE49 File Offset: 0x0001A049
		Friend Overridable Property Label7 As Label

		' Token: 0x170010EC RID: 4332
		' (get) Token: 0x06002B91 RID: 11153 RVA: 0x0001BE52 File Offset: 0x0001A052
		' (set) Token: 0x06002B92 RID: 11154 RVA: 0x0001BE5C File Offset: 0x0001A05C
		Friend Overridable Property txt_transporter_document_date As TextBox

		' Token: 0x170010ED RID: 4333
		' (get) Token: 0x06002B93 RID: 11155 RVA: 0x0001BE65 File Offset: 0x0001A065
		' (set) Token: 0x06002B94 RID: 11156 RVA: 0x0001BE6F File Offset: 0x0001A06F
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170010EE RID: 4334
		' (get) Token: 0x06002B95 RID: 11157 RVA: 0x0001BE78 File Offset: 0x0001A078
		' (set) Token: 0x06002B96 RID: 11158 RVA: 0x0001BE82 File Offset: 0x0001A082
		Friend Overridable Property txtEwaybillno As TextBox

		' Token: 0x170010EF RID: 4335
		' (get) Token: 0x06002B97 RID: 11159 RVA: 0x0001BE8B File Offset: 0x0001A08B
		' (set) Token: 0x06002B98 RID: 11160 RVA: 0x0001BE95 File Offset: 0x0001A095
		Friend Overridable Property Label10 As Label

		' Token: 0x170010F0 RID: 4336
		' (get) Token: 0x06002B99 RID: 11161 RVA: 0x0001BE9E File Offset: 0x0001A09E
		' (set) Token: 0x06002B9A RID: 11162 RVA: 0x001AE118 File Offset: 0x001AC318
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

		' Token: 0x170010F1 RID: 4337
		' (get) Token: 0x06002B9B RID: 11163 RVA: 0x0001BEA8 File Offset: 0x0001A0A8
		' (set) Token: 0x06002B9C RID: 11164 RVA: 0x0001BEB2 File Offset: 0x0001A0B2
		Friend Overridable Property txtEwaybill_date As TextBox

		' Token: 0x170010F2 RID: 4338
		' (get) Token: 0x06002B9D RID: 11165 RVA: 0x0001BEBB File Offset: 0x0001A0BB
		' (set) Token: 0x06002B9E RID: 11166 RVA: 0x0001BEC5 File Offset: 0x0001A0C5
		Friend Overridable Property Label12 As Label

		' Token: 0x170010F3 RID: 4339
		' (get) Token: 0x06002B9F RID: 11167 RVA: 0x0001BECE File Offset: 0x0001A0CE
		' (set) Token: 0x06002BA0 RID: 11168 RVA: 0x0001BED8 File Offset: 0x0001A0D8
		Friend Overridable Property txtValidupto As TextBox

		' Token: 0x170010F4 RID: 4340
		' (get) Token: 0x06002BA1 RID: 11169 RVA: 0x0001BEE1 File Offset: 0x0001A0E1
		' (set) Token: 0x06002BA2 RID: 11170 RVA: 0x0001BEEB File Offset: 0x0001A0EB
		Friend Overridable Property Label11 As Label

		' Token: 0x170010F5 RID: 4341
		' (get) Token: 0x06002BA3 RID: 11171 RVA: 0x0001BEF4 File Offset: 0x0001A0F4
		' (set) Token: 0x06002BA4 RID: 11172 RVA: 0x0001BEFE File Offset: 0x0001A0FE
		Friend Overridable Property lblUrl As Label

		' Token: 0x170010F6 RID: 4342
		' (get) Token: 0x06002BA5 RID: 11173 RVA: 0x0001BF07 File Offset: 0x0001A107
		' (set) Token: 0x06002BA6 RID: 11174 RVA: 0x001AE15C File Offset: 0x001AC35C
		Private _btnEwaybill_Cancel As GelButton
		Friend Overridable Property btnEwaybill_Cancel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnEwaybill_Cancel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnEwaybill_Cancel_Click
				Dim gelButton As GelButton = Me._btnEwaybill_Cancel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnEwaybill_Cancel = value
				gelButton = Me._btnEwaybill_Cancel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170010F7 RID: 4343
		' (get) Token: 0x06002BA7 RID: 11175 RVA: 0x0001BF11 File Offset: 0x0001A111
		' (set) Token: 0x06002BA8 RID: 11176 RVA: 0x0001BF1B File Offset: 0x0001A11B
		Friend Overridable Property txt_reason_of_cancel As TextBox

		' Token: 0x170010F8 RID: 4344
		' (get) Token: 0x06002BA9 RID: 11177 RVA: 0x0001BF24 File Offset: 0x0001A124
		' (set) Token: 0x06002BAA RID: 11178 RVA: 0x0001BF2E File Offset: 0x0001A12E
		Friend Overridable Property Label13 As Label

		' Token: 0x170010F9 RID: 4345
		' (get) Token: 0x06002BAB RID: 11179 RVA: 0x0001BF37 File Offset: 0x0001A137
		' (set) Token: 0x06002BAC RID: 11180 RVA: 0x0001BF41 File Offset: 0x0001A141
		Friend Overridable Property txtCancel_date As TextBox

		' Token: 0x170010FA RID: 4346
		' (get) Token: 0x06002BAD RID: 11181 RVA: 0x0001BF4A File Offset: 0x0001A14A
		' (set) Token: 0x06002BAE RID: 11182 RVA: 0x0001BF54 File Offset: 0x0001A154
		Friend Overridable Property lblcancel As Label

		' Token: 0x170010FB RID: 4347
		' (get) Token: 0x06002BAF RID: 11183 RVA: 0x0001BF5D File Offset: 0x0001A15D
		' (set) Token: 0x06002BB0 RID: 11184 RVA: 0x001AE1A0 File Offset: 0x001AC3A0
		Private _btnUpdate_Vehicle As GelButton
		Friend Overridable Property btnUpdate_Vehicle As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate_Vehicle
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Vehicle_Click
				Dim gelButton As GelButton = Me._btnUpdate_Vehicle
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate_Vehicle = value
				gelButton = Me._btnUpdate_Vehicle
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170010FC RID: 4348
		' (get) Token: 0x06002BB1 RID: 11185 RVA: 0x0001BF67 File Offset: 0x0001A167
		' (set) Token: 0x06002BB2 RID: 11186 RVA: 0x0001BF71 File Offset: 0x0001A171
		Friend Overridable Property Label14 As Label

		' Token: 0x170010FD RID: 4349
		' (get) Token: 0x06002BB3 RID: 11187 RVA: 0x0001BF7A File Offset: 0x0001A17A
		' (set) Token: 0x06002BB4 RID: 11188 RVA: 0x0001BF84 File Offset: 0x0001A184
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170010FE RID: 4350
		' (get) Token: 0x06002BB5 RID: 11189 RVA: 0x0001BF8D File Offset: 0x0001A18D
		' (set) Token: 0x06002BB6 RID: 11190 RVA: 0x0001BF97 File Offset: 0x0001A197
		Friend Overridable Property txt_vehicle_number2 As TextBox

		' Token: 0x170010FF RID: 4351
		' (get) Token: 0x06002BB7 RID: 11191 RVA: 0x0001BFA0 File Offset: 0x0001A1A0
		' (set) Token: 0x06002BB8 RID: 11192 RVA: 0x0001BFAA File Offset: 0x0001A1AA
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17001100 RID: 4352
		' (get) Token: 0x06002BB9 RID: 11193 RVA: 0x0001BFB3 File Offset: 0x0001A1B3
		' (set) Token: 0x06002BBA RID: 11194 RVA: 0x0001BFBD File Offset: 0x0001A1BD
		Friend Overridable Property Label15 As Label

		' Token: 0x17001101 RID: 4353
		' (get) Token: 0x06002BBB RID: 11195 RVA: 0x0001BFC6 File Offset: 0x0001A1C6
		' (set) Token: 0x06002BBC RID: 11196 RVA: 0x0001BFD0 File Offset: 0x0001A1D0
		Friend Overridable Property TabControl1 As TabControl

		' Token: 0x17001102 RID: 4354
		' (get) Token: 0x06002BBD RID: 11197 RVA: 0x0001BFD9 File Offset: 0x0001A1D9
		' (set) Token: 0x06002BBE RID: 11198 RVA: 0x0001BFE3 File Offset: 0x0001A1E3
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x17001103 RID: 4355
		' (get) Token: 0x06002BBF RID: 11199 RVA: 0x0001BFEC File Offset: 0x0001A1EC
		' (set) Token: 0x06002BC0 RID: 11200 RVA: 0x0001BFF6 File Offset: 0x0001A1F6
		Friend Overridable Property TabPage2 As TabPage

		' Token: 0x17001104 RID: 4356
		' (get) Token: 0x06002BC1 RID: 11201 RVA: 0x0001BFFF File Offset: 0x0001A1FF
		' (set) Token: 0x06002BC2 RID: 11202 RVA: 0x0001C009 File Offset: 0x0001A209
		Friend Overridable Property TabPage3 As TabPage

		' Token: 0x17001105 RID: 4357
		' (get) Token: 0x06002BC3 RID: 11203 RVA: 0x0001C012 File Offset: 0x0001A212
		' (set) Token: 0x06002BC4 RID: 11204 RVA: 0x0001C01C File Offset: 0x0001A21C
		Friend Overridable Property Label16 As Label

		' Token: 0x06002BC5 RID: 11205 RVA: 0x001AE1E4 File Offset: 0x001AC3E4
		Private Sub btnEwaybill_Gen_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from tbl_transportation where invoice_no=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtInvoiceNo.Text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("This Invoice have already Eway Bill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
			Else
				Dim flag3 As Boolean = Operators.CompareString(Me.txt_transportation_mode.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Transportation Mode Can't Blank", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txt_transportation_mode.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txt_transportation_distance.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Transportation Distance Can't Blank", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txt_transportation_distance.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.txtTransporterID.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Transporter ID can't blank", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtTransporterID.Focus()
						Else
							Dim text2 As String = "^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$"
							Dim flag6 As Boolean = Not Regex.IsMatch(Me.txtTransporterID.Text.ToUpper(), text2)
							If flag6 Then
								MessageBox.Show("Invalid Transporter GSTIN format", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtTransporterID.Focus()
							Else
								Dim flag7 As Boolean = Operators.CompareString(Me.txt_vehicle_number.Text, "", False) = 0
								If flag7 Then
									MessageBox.Show("Vechile Number can't blank", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txt_vehicle_number.Focus()
								Else
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "select * from tbl_transportation where invoice_no=@d1"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtInvoiceNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
									If flag8 Then
										MessageBox.Show("This Invoice have already Eway Bill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag9 Then
											ModCommonClasses.rdr.Close()
										End If
									Else
										ModCommonClasses.con.Close()
										Me.InsertTransportation_dtl()
										Me.GenerateEwayBillJSONUsingDataTable()
										Me.GenerateToken()
										Me.Ewaybill_Gen()
										ModCommonClasses.con.Close()
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06002BC6 RID: 11206 RVA: 0x001AE4D8 File Offset: 0x001AC6D8
		Public Sub InsertTransportation_dtl()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "INSERT INTO tbl_transportation (transportation_mod, vehicle_type, transportation_distance, transporter_id, transporter_name, transporter_document_number, transporter_document_date, vehicle_number, invoice_no) " & vbCrLf & "                                VALUES (@transportation_mod, @vehicle_type, @transportation_distance, @transporter_id, @transporter_name, @transporter_document_number, @transporter_document_date, @vehicle_number, @invoice_no)"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@transportation_mod", Me.txt_transportation_mode.Text)
						sqlCommand.Parameters.AddWithValue("@vehicle_type", Me.txt_vehicle_type.Text)
						sqlCommand.Parameters.AddWithValue("@transportation_distance", Conversion.Val(Me.txt_transportation_distance.Text))
						sqlCommand.Parameters.AddWithValue("@transporter_id", Me.txtTransporterID.Text)
						sqlCommand.Parameters.AddWithValue("@transporter_name", Me.txt_transporter_name.Text)
						sqlCommand.Parameters.AddWithValue("@transporter_document_number", Me.txt_transporter_document_number.Text)
						sqlCommand.Parameters.AddWithValue("@transporter_document_date", Me.txt_transporter_document_date.Text)
						sqlCommand.Parameters.AddWithValue("@vehicle_number", Me.txt_vehicle_number.Text)
						sqlCommand.Parameters.AddWithValue("@invoice_no", Me.txtInvoiceNo.Text)
						sqlCommand.ExecuteNonQuery()
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(String.Format("An error occurred: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002BC7 RID: 11207 RVA: 0x001AE6B0 File Offset: 0x001AC8B0
		Public Sub DeleteTransportation_dtl()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "DELETE tbl_transportation WHERE invoice_no = @InvoiceNo AND ewayBillNo is Null"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@InvoiceNo", Me.txtInvoiceNo.Text)
						Dim num As Integer = sqlCommand.ExecuteNonQuery()
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(String.Format("An error occurred: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002BC8 RID: 11208 RVA: 0x001AE77C File Offset: 0x001AC97C
		Public Sub GenerateEwayBillJSONUsingDataTable()
			Dim invoiceInfo As DataTable = Me.GetInvoiceInfo()
			Dim invoiceProduct As DataTable = Me.GetInvoiceProduct()
			Dim companyInfo As DataTable = Me.GetCompanyInfo()
			Dim transportInfo As DataTable = Me.GetTransportInfo()
			Dim flag As Boolean = (invoiceInfo.Rows.Count = 0) Or (invoiceProduct.Rows.Count = 0)
			If flag Then
				MessageBox.Show("No data found in the Invoice DataTables.")
			Else
				Dim stringBuilder As StringBuilder = New StringBuilder()
				stringBuilder.AppendLine("{")
				Dim dataRow As DataRow = invoiceInfo.Rows(0)
				Dim dataRow2 As DataRow = companyInfo.Rows(0)
				Dim dataRow3 As DataRow = transportInfo.Rows(0)
				stringBuilder.AppendLine(String.Format("""userGstin"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow2("GSTIN"))))
				stringBuilder.AppendLine("""supply_type"": ""outward"",")
				stringBuilder.AppendLine("""sub_supply_type"": ""Supply"",")
				stringBuilder.AppendLine("""document_type"": ""Tax Invoice"",")
				stringBuilder.AppendLine(String.Format("""document_number"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow("InvoiceNo"))))
				stringBuilder.AppendLine(String.Format("""document_date"": ""{0}"",", Convert.ToDateTime(RuntimeHelpers.GetObjectValue(dataRow("InvoiceDate"))).ToString("dd/MM/yyyy")))
				stringBuilder.AppendLine(String.Format("""gstin_of_consignor"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow2("GSTIN"))))
				stringBuilder.AppendLine(String.Format("""legal_name_of_consignor"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow2("CompanyName"))))
				stringBuilder.AppendLine(String.Format("""address1_of_consignor"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow2("Address"))))
				stringBuilder.AppendLine(String.Format("""address2_of_consignor"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow2("Address"))))
				stringBuilder.AppendLine(String.Format("""place_of_consignor"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow2("City"))))
				stringBuilder.AppendLine(String.Format("""pincode_of_consignor"": {0},", RuntimeHelpers.GetObjectValue(dataRow2("CIN"))))
				stringBuilder.AppendLine(String.Format("""state_of_consignor"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow2("State"))))
				stringBuilder.AppendLine(String.Format("""actual_from_state_name"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow2("State"))))
				stringBuilder.AppendLine(String.Format("""gstin_of_consignee"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow("GSTIN"))))
				stringBuilder.AppendLine(String.Format("""legal_name_of_consignee"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow("Name"))))
				stringBuilder.AppendLine(String.Format("""address1_of_consignee"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow("Address"))))
				stringBuilder.AppendLine(String.Format("""address2_of_consignee"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow("Address"))))
				stringBuilder.AppendLine(String.Format("""place_ofconsignee"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow("City"))))
				stringBuilder.AppendLine(String.Format("""pincode_of_consignee"": {0},", RuntimeHelpers.GetObjectValue(dataRow("ZipCode"))))
				stringBuilder.AppendLine(String.Format("""state_of_supply"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow("State"))))
				stringBuilder.AppendLine(String.Format("""actual_to_state_name"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow("State"))))
				stringBuilder.AppendLine("""transaction_type"": 3,")
				stringBuilder.AppendLine("""other_value"": 0,")
				stringBuilder.AppendLine(String.Format("""total_invoice_value"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow("GrandTotal")))))
				stringBuilder.AppendLine(String.Format("""taxable_amount"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow("TaxableAmt")))))
				stringBuilder.AppendLine(String.Format("""cgst_amount"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow("CGST")))))
				stringBuilder.AppendLine(String.Format("""sgst_amount"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow("SGST")))))
				stringBuilder.AppendLine(String.Format("""igst_amount"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow("IGST")))))
				stringBuilder.AppendLine(String.Format("""cess_amount"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow("CESS")))))
				stringBuilder.AppendLine("""cess_nonadvol_value"": 0,")
				stringBuilder.AppendLine(String.Format("""transporter_id"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow3("transporter_id"))))
				stringBuilder.AppendLine(String.Format("""transporter_name"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow3("transporter_name"))))
				stringBuilder.AppendLine(String.Format("""transporter_document_number"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow3("transporter_document_number"))))
				stringBuilder.AppendLine(String.Format("""transporter_document_date"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow3("transporter_document_date"))))
				stringBuilder.AppendLine(String.Format("""transportation_mode"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow3("transportation_mod"))))
				stringBuilder.AppendLine(String.Format("""transportation_distance"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow3("transportation_distance"))))
				stringBuilder.AppendLine(String.Format("""vehicle_number"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow3("vehicle_number"))))
				stringBuilder.AppendLine(String.Format("""vehicle_type"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow3("vehicle_type"))))
				stringBuilder.AppendLine("""generate_status"": 1,")
				stringBuilder.AppendLine("""data_source"": ""erp"",")
				stringBuilder.AppendLine("""user_ref"": """",")
				stringBuilder.AppendLine("""location_code"": """",")
				stringBuilder.AppendLine("""eway_bill_status"": """",")
				stringBuilder.AppendLine("""auto_print"": ""N"",")
				stringBuilder.AppendLine("""email"": """",")
				stringBuilder.AppendLine("""delete_record"": ""N"",")
				stringBuilder.AppendLine("""itemList"": [")
				Try
					For Each obj As Object In invoiceProduct.Rows
						Dim dataRow4 As DataRow = CType(obj, DataRow)
						stringBuilder.AppendLine("{")
						stringBuilder.AppendLine(String.Format("""product_name"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow4("ProductName"))))
						stringBuilder.AppendLine(String.Format("""product_description"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow4("Description"))))
						stringBuilder.AppendLine(String.Format("""hsn_code"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow4("HSNCode"))))
						stringBuilder.AppendLine(String.Format("""quantity"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow4("Qty")))))
						stringBuilder.AppendLine(String.Format("""unit_of_product"": ""{0}"",", RuntimeHelpers.GetObjectValue(dataRow4("AltUnit"))))
						stringBuilder.AppendLine(String.Format("""cgst_rate"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow4("CGSTPer")))))
						stringBuilder.AppendLine(String.Format("""sgst_rate"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow4("SGSTPer")))))
						stringBuilder.AppendLine(String.Format("""igst_rate"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow4("IGSTPer")))))
						stringBuilder.AppendLine(String.Format("""cess_rate"": {0},", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow4("CESSPer")))))
						stringBuilder.AppendLine(String.Format("""cessNonAdvol"": {0},", Convert.ToDecimal("0")))
						stringBuilder.AppendLine(String.Format("""taxable_amount"": {0}", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataRow4("TaxableAmt")))))
						Dim flag2 As Boolean = dataRow4.Equals(invoiceProduct.Rows(invoiceProduct.Rows.Count - 1))
						If flag2 Then
							stringBuilder.AppendLine("}")
						Else
							stringBuilder.AppendLine("},")
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag3 As Boolean = stringBuilder.ToString().EndsWith(",")
				If flag3 Then
					stringBuilder.Remove(stringBuilder.Length - 3, 1)
				End If
				stringBuilder.AppendLine("]")
				stringBuilder.AppendLine("}")
				Me.strJson = stringBuilder.ToString()
			End If
		End Sub

		' Token: 0x06002BC9 RID: 11209 RVA: 0x001AF074 File Offset: 0x001AD274
		Public Sub CancelEwayBillJSONUsingDataTable()
			Try
				Dim transportInfo As DataTable = Me.GetTransportInfo()
				Dim companyInfo As DataTable = Me.GetCompanyInfo()
				Dim flag As Boolean = transportInfo.Rows.Count = 0 OrElse companyInfo.Rows.Count = 0
				If flag Then
					MessageBox.Show("Required data is missing. Please check the inputs.")
				Else
					Dim dataRow As DataRow = transportInfo.Rows(0)
					Dim dataRow2 As DataRow = companyInfo.Rows(0)
					Dim num As Long
					Dim flag2 As Boolean = Not Long.TryParse(dataRow("EwayBillNo").ToString(), num)
					If flag2 Then
						MessageBox.Show("Invalid Eway Bill Number.")
					Else
						Dim jobject As JObject = New JObject() From { { "userGstin", dataRow2("GSTIN").ToString() }, { "eway_bill_number", num }, { "reason_of_cancel", Me.txt_reason_of_cancel.Text }, { "cancel_remark", "Cancelled the order" }, { "data_source", "erp" } }
						Me.jsonString_canel = JsonConvert.SerializeObject(jobject, Formatting.Indented)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(String.Format("Error: {0}", ex.Message))
			End Try
		End Sub

		' Token: 0x06002BCA RID: 11210 RVA: 0x001AF1E8 File Offset: 0x001AD3E8
		Public Sub GenerateToken()
			Try
				Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag Then
					MessageBox.Show("Please Check your internet connection!")
				Else
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select APIUrl, Username, Password from EwaybillAPISetting where IsDefault='Yes' and IsEnabled='Yes'")
					Dim flag2 As Boolean = dataTable.Rows.Count = 0
					If flag2 Then
						MessageBox.Show("No API settings found!")
					Else
						Dim text As String = dataTable.Rows(0)("APIUrl").ToString().Trim() + "/token-auth/"
						Dim text2 As String = dataTable.Rows(0)("Username").ToString().Trim()
						Dim text3 As String = dataTable.Rows(0)("Password").ToString().Trim()
						Me.token_no = ModFunc.GetAuthToken(text, text2, text3)
					End If
				End If
			Catch ex As Exception
				Me.DeleteTransportation_dtl()
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002BCB RID: 11211 RVA: 0x001AF308 File Offset: 0x001AD508
		Public Sub Ewaybill_Gen()
			Try
				Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag Then
					MessageBox.Show("Please Check your internet connection!")
				Else
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select APIUrl, Username, Password from EwaybillAPISetting where IsDefault='Yes' and IsEnabled='Yes'")
					Dim flag2 As Boolean = dataTable.Rows.Count = 0
					If flag2 Then
						MessageBox.Show("No API settings found!")
					Else
						Dim text As String = dataTable.Rows(0)("APIUrl").ToString().Trim() + "/ewayBillsGenerate/"
						Dim text2 As String = ModFunc.GenerateEwayBill(text, Me.token_no, Me.strJson)
						Dim jobject As JObject = JObject.Parse(text2)
						Dim flag3 As Boolean = jobject("results")("message")("error").ToObject(Of Boolean)()
						Dim flag4 As Boolean = flag3
						If flag4 Then
							MessageBox.Show("An error occurred while generating the E-Way Bill. Please check the details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Else
							Dim text3 As String = jobject("results")("message")("ewayBillNo").ToString()
							Dim text4 As String = jobject("results")("message")("validUpto").ToString()
							Dim text5 As String = jobject("results")("message")("ewayBillDate").ToString()
							Dim text6 As String = jobject("results")("message")("url").ToString()
							Dim text7 As String = jobject("results")("message")("alert").ToString()
							Dim text8 As String = jobject("results")("status").ToString()
							Dim num As Integer = jobject("results")("code").ToObject(Of Integer)()
							Dim text9 As String = jobject("results")("requestId").ToString()
							Dim text10 As String = ""
							Dim flag5 As Boolean = Not String.IsNullOrWhiteSpace(text4)
							If flag5 Then
								text10 = DateTime.ParseExact(text4, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss")
							End If
							Dim text11 As String = ""
							Dim flag6 As Boolean = Not String.IsNullOrWhiteSpace(text5)
							If flag6 Then
								text11 = DateTime.ParseExact(text5, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss")
							End If
							Dim text12 As String = "UPDATE tbl_transportation " & vbCrLf & "                           SET ewayBillNo = @ewayBillNo, " & vbCrLf & "                               validUpto = @validUpto, " & vbCrLf & "                               ewayBillDate = @ewayBillDate, " & vbCrLf & "                               url = @url, " & vbCrLf & "                               requestId = @requestId, is_deleted = 0, alert_message=@alert_message" & vbCrLf & "                           WHERE invoice_no = @invoice_no"
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection.Open()
								Using sqlCommand As SqlCommand = New SqlCommand(text12, sqlConnection)
									sqlCommand.Parameters.AddWithValue("@ewayBillNo", text3)
									sqlCommand.Parameters.AddWithValue("@validUpto", text10)
									sqlCommand.Parameters.AddWithValue("@ewayBillDate", text11)
									sqlCommand.Parameters.AddWithValue("@url", text6)
									sqlCommand.Parameters.AddWithValue("@requestId", text9)
									sqlCommand.Parameters.AddWithValue("@alert_message", text7)
									sqlCommand.Parameters.AddWithValue("@invoice_no", Me.txtInvoiceNo.Text)
									Dim num2 As Integer = sqlCommand.ExecuteNonQuery()
									Dim flag7 As Boolean = num2 > 0
									If flag7 Then
										Me.GetData()
										Me.btnEwaybill_Gen.Visible = False
										Me.GroupBox2.Visible = True
										MessageBox.Show("E-Way Bill Generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Else
										Me.DeleteTransportation_dtl()
										MessageBox.Show("No matching record found for the given invoice number.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									End If
								End Using
							End Using
						End If
					End If
				End If
			Catch ex As Exception
				Me.DeleteTransportation_dtl()
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002BCC RID: 11212 RVA: 0x001AF744 File Offset: 0x001AD944
		Public Sub Ewaybill_Cancel()
			Try
				Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag Then
					MessageBox.Show("Please Check your internet connection!")
				Else
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select APIUrl, Username, Password from EwaybillAPISetting where IsDefault='Yes' and IsEnabled='Yes'")
					Dim flag2 As Boolean = dataTable.Rows.Count = 0
					If flag2 Then
						MessageBox.Show("No API settings found!")
					Else
						Dim text As String = dataTable.Rows(0)("APIUrl").ToString().Trim() + "/ewayBillCancel/"
						Dim text2 As String = ModFunc.CancelEwayBill(text, Me.token_no, Me.jsonString_canel)
						Dim jobject As JObject = JObject.Parse(text2)
						Dim flag3 As Boolean = jobject("results")("message")("error").ToObject(Of Boolean)()
						Dim flag4 As Boolean = flag3
						If flag4 Then
							MessageBox.Show("An error occurred while cancel the E-Way Bill. Please check the details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Else
							Dim text3 As String = jobject("results")("message")("ewayBillNo").ToString()
							Dim text4 As String = jobject("results")("message")("cancelDate").ToString()
							Dim text5 As String = DateTime.ParseExact(text4, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss")
							Dim text6 As String = "UPDATE tbl_transportation " & vbCrLf & "                           SET is_deleted = 1, " & vbCrLf & "                               reason_of_cancel = @reason_of_cancel, " & vbCrLf & "                               cancelDate = @cancelDate" & vbCrLf & "                           WHERE invoice_no = @invoice_no and ewayBillNo=@ewayBillNo"
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection.Open()
								Using sqlCommand As SqlCommand = New SqlCommand(text6, sqlConnection)
									sqlCommand.Parameters.AddWithValue("@reason_of_cancel", Me.txt_reason_of_cancel.Text)
									sqlCommand.Parameters.AddWithValue("@cancelDate", text5)
									sqlCommand.Parameters.AddWithValue("@invoice_no", Me.txtInvoiceNo.Text)
									sqlCommand.Parameters.AddWithValue("@ewayBillNo", Me.txtEwaybillno.Text)
									Dim num As Integer = sqlCommand.ExecuteNonQuery()
									Dim flag5 As Boolean = num > 0
									If flag5 Then
										Me.GetData()
										Me.btnEwaybill_Gen.Visible = False
										Me.GroupBox2.Visible = True
										Me.btnEwaybill_Cancel.Visible = False
										MessageBox.Show("E-Way Bill Cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Else
										Me.btnEwaybill_Cancel.Visible = True
										MessageBox.Show("No matching record found for the given invoice number.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									End If
								End Using
							End Using
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06002BCD RID: 11213 RVA: 0x001AFA48 File Offset: 0x001ADC48
		Public Function GetTransportInfo() As DataTable
			Dim dataTable As DataTable = New DataTable()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "SELECT id, transportation_mod, vehicle_type, transportation_distance, transporter_id, transporter_name, transporter_document_number, transporter_document_date, vehicle_number, invoice_no," & vbCrLf & "ewayBillNo," & vbCrLf & "validUpto," & vbCrLf & "ewayBillDate," & vbCrLf & "url," & vbCrLf & "requestId, reason_of_cancel, cancelDate, is_deleted  from tbl_transportation where invoice_no='" + Me.txtInvoiceNo.Text + "'"
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
			sqlDataAdapter.Fill(dataTable)
			Dim flag As Boolean = dataTable.Rows.Count = 0
			Dim dataTable2 As DataTable
			If Not flag Then
				sqlConnection.Close()
				dataTable2 = dataTable
			End If
			Return dataTable2
		End Function

		' Token: 0x06002BCE RID: 11214 RVA: 0x001AFAC0 File Offset: 0x001ADCC0
		Public Function GetCompanyInfo() As DataTable
			Dim dataTable As DataTable = New DataTable()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "SELECT RTRIM(CompanyName) as CompanyName, RTRIM(Address) As Address, RTRIM(City) As City, RTRIM(State) As State, RTRIM(CIN) As CIN, RTRIM(GSTIN) As GSTIN FROM Company"
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
			sqlDataAdapter.Fill(dataTable)
			Dim flag As Boolean = dataTable.Rows.Count = 0
			Dim dataTable2 As DataTable
			If Not flag Then
				sqlConnection.Close()
				dataTable2 = dataTable
			End If
			Return dataTable2
		End Function

		' Token: 0x06002BCF RID: 11215 RVA: 0x001AFB24 File Offset: 0x001ADD24
		Public Function GetInvoiceInfo() As DataTable
			Dim dataTable As DataTable = New DataTable()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "Select " & vbCrLf & "    RTRIM(a.InvoiceNo) AS InvoiceNo," & vbCrLf & "    a.InvoiceDate AS InvoiceDate, " & vbCrLf & "    RTRIM(b.Name) AS Name, " & vbCrLf & "    RTRIM(b.GSTIN) AS GSTIN, " & vbCrLf & "    RTRIM(b.Address) AS Address, " & vbCrLf & "    RTRIM(b.City) AS City, " & vbCrLf & "    RTRIM(b.State) AS State, " & vbCrLf & "    RTRIM(b.ZipCode) AS ZipCode, " & vbCrLf & "    a.TaxableAmt AS TaxableAmt, " & vbCrLf & "    a.CGST AS CGST, " & vbCrLf & "    a.SGST AS SGST, " & vbCrLf & "    a.IGST AS IGST, " & vbCrLf & "    a.CESS AS CESS, " & vbCrLf & "    a.OtherCharges AS OtherCharges, " & vbCrLf & "    a.RoundOff AS RoundOff, " & vbCrLf & "    a.GrandTotal AS GrandTotal" & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo a" & vbCrLf & "INNER JOIN " & vbCrLf & "    Customer b " & vbCrLf & "ON " & vbCrLf & "    a.Customer_ID = b.ID " & vbCrLf & "where a.InvoiceNo='" + Me.txtInvoiceNo.Text + "'"
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
			sqlDataAdapter.Fill(dataTable)
			Dim flag As Boolean = dataTable.Rows.Count = 0
			Dim dataTable2 As DataTable
			If Not flag Then
				sqlConnection.Close()
				dataTable2 = dataTable
			End If
			Return dataTable2
		End Function

		' Token: 0x06002BD0 RID: 11216 RVA: 0x001AFB9C File Offset: 0x001ADD9C
		Public Function GetInvoiceProduct() As DataTable
			Dim dataTable As DataTable = New DataTable()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "SELECT  " & vbCrLf & "    RTRIM(x.InvoiceNo) AS InvoiceNo, " & vbCrLf & "    RTRIM(b.ProductName) AS ProductName, " & vbCrLf & "    RTRIM(b.Description) AS Description, " & vbCrLf & "    RTRIM(b.HSNCode) AS HSNCode, " & vbCrLf & "    a.Qty AS Qty, " & vbCrLf & "    RTRIM(a.AltUnit) AS AltUnit, " & vbCrLf & "    a.CGSTPer AS CGSTPer, " & vbCrLf & "    a.SGSTPer AS SGSTPer, " & vbCrLf & "    a.IGSTPer AS IGSTPer, " & vbCrLf & "    a.CESSPer AS CESSPer, " & vbCrLf & "    a.TaxableAmt AS TaxableAmt  " & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo x" & vbCrLf & "INNER JOIN " & vbCrLf & "    Invoice_Product a " & vbCrLf & "ON " & vbCrLf & "    x.Inv_ID = a.InvoiceID" & vbCrLf & "INNER JOIN " & vbCrLf & "    Product b " & vbCrLf & "ON " & vbCrLf & "    a.ProductID = b.PID" & vbCrLf & " where x.InvoiceNo='" + Me.txtInvoiceNo.Text + "'"
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
			sqlDataAdapter.Fill(dataTable)
			Dim flag As Boolean = dataTable.Rows.Count = 0
			Dim dataTable2 As DataTable
			If Not flag Then
				sqlConnection.Close()
				dataTable2 = dataTable
			End If
			Return dataTable2
		End Function

		' Token: 0x06002BD1 RID: 11217 RVA: 0x001AFC14 File Offset: 0x001ADE14
		Public Sub GetData()
			Dim transportInfo As DataTable = Me.GetTransportInfo()
			Dim flag As Boolean = transportInfo IsNot Nothing AndAlso transportInfo.Rows.Count > 0
			If flag Then
				Dim dataRow As DataRow = transportInfo.Rows(0)
				Me.txt_transportation_mode.Text = dataRow("transportation_mod").ToString()
				Me.txt_vehicle_type.Text = dataRow("vehicle_type").ToString()
				Me.txt_transportation_distance.Text = dataRow("transportation_distance").ToString()
				Me.txtTransporterID.Text = dataRow("transporter_id").ToString()
				Me.txt_transporter_name.Text = dataRow("transporter_name").ToString()
				Me.txt_transporter_document_number.Text = dataRow("transporter_document_number").ToString()
				Me.txt_transporter_document_date.Text = dataRow("transporter_document_date").ToString()
				Me.txt_vehicle_number.Text = dataRow("vehicle_number").ToString()
				Me.txt_vehicle_number2.Text = dataRow("vehicle_number").ToString()
				Me.txtEwaybillno.Text = dataRow("ewayBillNo").ToString()
				Me.txtValidupto.Text = dataRow("validUpto").ToString()
				Me.txtEwaybill_date.Text = dataRow("ewayBillDate").ToString()
				Me.lblUrl.Text = dataRow("url").ToString()
				Me.txtCancel_date.Text = dataRow("cancelDate").ToString()
				Me.btnEwaybill_Gen.Visible = False
				Me.GroupBox2.Visible = True
				Dim flag2 As Boolean = Operators.CompareString(Me.txtCancel_date.Text, "", False) = 0
				If flag2 Then
					Me.btnEwaybill_Cancel.Visible = True
				Else
					Me.btnEwaybill_Cancel.Visible = False
				End If
			Else
				Me.txt_transportation_mode.Text = "Road"
				Me.txt_vehicle_type.Text = "Regular"
				Me.txt_transportation_distance.Text = "0"
				Me.txtTransporterID.Text = ""
				Me.txt_transporter_name.Text = ""
				Me.txt_transporter_document_number.Text = ""
				Me.txt_transporter_document_date.Text = ""
				Me.txt_vehicle_number.Text = ""
				Me.txtEwaybillno.Text = ""
				Me.txtValidupto.Text = ""
				Me.txtEwaybill_date.Text = ""
				Me.lblUrl.Text = ""
				Me.txt_reason_of_cancel.Text = "Others"
				Me.txtCancel_date.Text = ""
				Me.btnEwaybill_Gen.Visible = True
				Me.GroupBox2.Visible = False
				Me.btnEwaybill_Cancel.Visible = False
			End If
		End Sub

		' Token: 0x06002BD2 RID: 11218 RVA: 0x0001C025 File Offset: 0x0001A225
		Private Sub frmEWayBill_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.GetCompanyGSTIN()
		End Sub

		' Token: 0x06002BD3 RID: 11219 RVA: 0x001AFF4C File Offset: 0x001AE14C
		Public Sub GetCompanyGSTIN()
			Dim companyInfo As DataTable = Me.GetCompanyInfo()
			Dim dataRow As DataRow = companyInfo.Rows(0)
			Me.txtTransporterID.Text = Conversions.ToString(dataRow("GSTIN"))
		End Sub

		' Token: 0x06002BD4 RID: 11220 RVA: 0x001AFF8C File Offset: 0x001AE18C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim text As String = "https://" + Me.lblUrl.Text.Trim()
			Dim flag As Boolean = Uri.IsWellFormedUriString(text, UriKind.Absolute)
			If flag Then
				Try
					Process.Start(text)
				Catch ex As Exception
					MessageBox.Show("Failed to open the link. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				MessageBox.Show("Does not contain a valid URL.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		End Sub

		' Token: 0x06002BD5 RID: 11221 RVA: 0x001B0020 File Offset: 0x001AE220
		Private Sub btnEwaybill_Cancel_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Successfully Cancelled" & vbCrLf & "Do you Want to Cancel this E-Way Bill ?", "E-Way Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.txtEwaybillno.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Eway Bill No. Can't Blank", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtEwaybillno.Focus()
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.txt_reason_of_cancel.Text, "", False) = 0
						If flag3 Then
							MessageBox.Show("Reason of cancel Eway Bill Can't Blank", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txt_reason_of_cancel.Focus()
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select * from tbl_transportation where invoice_no=@d1 and is_deleted=0"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtInvoiceNo.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								Me.CancelEwayBillJSONUsingDataTable()
								Me.GenerateToken()
								Me.Ewaybill_Cancel()
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
								ModCommonClasses.con.Close()
							Else
								MessageBox.Show("This Eway Bill can't cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End If
						End If
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002BD6 RID: 11222 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnUpdate_Vehicle_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x040012BA RID: 4794
		Private token_no As String

		' Token: 0x040012BB RID: 4795
		Private strJson As String

		' Token: 0x040012BC RID: 4796
		Private jsonString_canel As String
	End Class
End Namespace
