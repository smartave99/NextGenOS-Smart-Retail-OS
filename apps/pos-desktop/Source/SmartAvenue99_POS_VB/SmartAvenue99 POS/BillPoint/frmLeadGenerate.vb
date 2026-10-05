Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000129 RID: 297
	<DesignerGenerated()>
	Public Partial Class frmLeadGenerate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06003362 RID: 13154 RVA: 0x0001FC36 File Offset: 0x0001DE36
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLeadGenerate_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170013EB RID: 5099
		' (get) Token: 0x06003365 RID: 13157 RVA: 0x0001FC56 File Offset: 0x0001DE56
		' (set) Token: 0x06003366 RID: 13158 RVA: 0x0001FC60 File Offset: 0x0001DE60
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170013EC RID: 5100
		' (get) Token: 0x06003367 RID: 13159 RVA: 0x0001FC69 File Offset: 0x0001DE69
		' (set) Token: 0x06003368 RID: 13160 RVA: 0x0001FC73 File Offset: 0x0001DE73
		Friend Overridable Property Label1 As Label

		' Token: 0x170013ED RID: 5101
		' (get) Token: 0x06003369 RID: 13161 RVA: 0x0001FC7C File Offset: 0x0001DE7C
		' (set) Token: 0x0600336A RID: 13162 RVA: 0x0001FC86 File Offset: 0x0001DE86
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170013EE RID: 5102
		' (get) Token: 0x0600336B RID: 13163 RVA: 0x0001FC8F File Offset: 0x0001DE8F
		' (set) Token: 0x0600336C RID: 13164 RVA: 0x0001FC99 File Offset: 0x0001DE99
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170013EF RID: 5103
		' (get) Token: 0x0600336D RID: 13165 RVA: 0x0001FCA2 File Offset: 0x0001DEA2
		' (set) Token: 0x0600336E RID: 13166 RVA: 0x0001FCAC File Offset: 0x0001DEAC
		Friend Overridable Property btnGetData As GelButton

		' Token: 0x170013F0 RID: 5104
		' (get) Token: 0x0600336F RID: 13167 RVA: 0x0001FCB5 File Offset: 0x0001DEB5
		' (set) Token: 0x06003370 RID: 13168 RVA: 0x0001FCBF File Offset: 0x0001DEBF
		Friend Overridable Property btnUpdate As GelButton

		' Token: 0x170013F1 RID: 5105
		' (get) Token: 0x06003371 RID: 13169 RVA: 0x0001FCC8 File Offset: 0x0001DEC8
		' (set) Token: 0x06003372 RID: 13170 RVA: 0x0001FCD2 File Offset: 0x0001DED2
		Friend Overridable Property btnDelete As GelButton

		' Token: 0x170013F2 RID: 5106
		' (get) Token: 0x06003373 RID: 13171 RVA: 0x0001FCDB File Offset: 0x0001DEDB
		' (set) Token: 0x06003374 RID: 13172 RVA: 0x001FE0F8 File Offset: 0x001FC2F8
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

		' Token: 0x170013F3 RID: 5107
		' (get) Token: 0x06003375 RID: 13173 RVA: 0x0001FCE5 File Offset: 0x0001DEE5
		' (set) Token: 0x06003376 RID: 13174 RVA: 0x001FE13C File Offset: 0x001FC33C
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

		' Token: 0x170013F4 RID: 5108
		' (get) Token: 0x06003377 RID: 13175 RVA: 0x0001FCEF File Offset: 0x0001DEEF
		' (set) Token: 0x06003378 RID: 13176 RVA: 0x0001FCF9 File Offset: 0x0001DEF9
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170013F5 RID: 5109
		' (get) Token: 0x06003379 RID: 13177 RVA: 0x0001FD02 File Offset: 0x0001DF02
		' (set) Token: 0x0600337A RID: 13178 RVA: 0x0001FD0C File Offset: 0x0001DF0C
		Friend Overridable Property Label13 As Label

		' Token: 0x170013F6 RID: 5110
		' (get) Token: 0x0600337B RID: 13179 RVA: 0x0001FD15 File Offset: 0x0001DF15
		' (set) Token: 0x0600337C RID: 13180 RVA: 0x0001FD1F File Offset: 0x0001DF1F
		Friend Overridable Property Lead_Date As DateTimePicker

		' Token: 0x170013F7 RID: 5111
		' (get) Token: 0x0600337D RID: 13181 RVA: 0x0001FD28 File Offset: 0x0001DF28
		' (set) Token: 0x0600337E RID: 13182 RVA: 0x0001FD32 File Offset: 0x0001DF32
		Friend Overridable Property Label9 As Label

		' Token: 0x170013F8 RID: 5112
		' (get) Token: 0x0600337F RID: 13183 RVA: 0x0001FD3B File Offset: 0x0001DF3B
		' (set) Token: 0x06003380 RID: 13184 RVA: 0x0001FD45 File Offset: 0x0001DF45
		Friend Overridable Property Label8 As Label

		' Token: 0x170013F9 RID: 5113
		' (get) Token: 0x06003381 RID: 13185 RVA: 0x0001FD4E File Offset: 0x0001DF4E
		' (set) Token: 0x06003382 RID: 13186 RVA: 0x0001FD58 File Offset: 0x0001DF58
		Friend Overridable Property cmbInterestMode As ComboBox

		' Token: 0x170013FA RID: 5114
		' (get) Token: 0x06003383 RID: 13187 RVA: 0x0001FD61 File Offset: 0x0001DF61
		' (set) Token: 0x06003384 RID: 13188 RVA: 0x0001FD6B File Offset: 0x0001DF6B
		Friend Overridable Property Label4 As Label

		' Token: 0x170013FB RID: 5115
		' (get) Token: 0x06003385 RID: 13189 RVA: 0x0001FD74 File Offset: 0x0001DF74
		' (set) Token: 0x06003386 RID: 13190 RVA: 0x0001FD7E File Offset: 0x0001DF7E
		Friend Overridable Property cboxCordinateMode As ComboBox

		' Token: 0x170013FC RID: 5116
		' (get) Token: 0x06003387 RID: 13191 RVA: 0x0001FD87 File Offset: 0x0001DF87
		' (set) Token: 0x06003388 RID: 13192 RVA: 0x0001FD91 File Offset: 0x0001DF91
		Friend Overridable Property Label10 As Label

		' Token: 0x170013FD RID: 5117
		' (get) Token: 0x06003389 RID: 13193 RVA: 0x0001FD9A File Offset: 0x0001DF9A
		' (set) Token: 0x0600338A RID: 13194 RVA: 0x0001FDA4 File Offset: 0x0001DFA4
		Friend Overridable Property txtRemarks As TextBox

		' Token: 0x170013FE RID: 5118
		' (get) Token: 0x0600338B RID: 13195 RVA: 0x0001FDAD File Offset: 0x0001DFAD
		' (set) Token: 0x0600338C RID: 13196 RVA: 0x0001FDB7 File Offset: 0x0001DFB7
		Friend Overridable Property Label7 As Label

		' Token: 0x170013FF RID: 5119
		' (get) Token: 0x0600338D RID: 13197 RVA: 0x0001FDC0 File Offset: 0x0001DFC0
		' (set) Token: 0x0600338E RID: 13198 RVA: 0x0001FDCA File Offset: 0x0001DFCA
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x17001400 RID: 5120
		' (get) Token: 0x0600338F RID: 13199 RVA: 0x0001FDD3 File Offset: 0x0001DFD3
		' (set) Token: 0x06003390 RID: 13200 RVA: 0x0001FDDD File Offset: 0x0001DFDD
		Friend Overridable Property cmbCustomerName As ComboBox

		' Token: 0x17001401 RID: 5121
		' (get) Token: 0x06003391 RID: 13201 RVA: 0x0001FDE6 File Offset: 0x0001DFE6
		' (set) Token: 0x06003392 RID: 13202 RVA: 0x0001FDF0 File Offset: 0x0001DFF0
		Friend Overridable Property cmbState As ComboBox

		' Token: 0x17001402 RID: 5122
		' (get) Token: 0x06003393 RID: 13203 RVA: 0x0001FDF9 File Offset: 0x0001DFF9
		' (set) Token: 0x06003394 RID: 13204 RVA: 0x0001FE03 File Offset: 0x0001E003
		Friend Overridable Property Label2 As Label

		' Token: 0x17001403 RID: 5123
		' (get) Token: 0x06003395 RID: 13205 RVA: 0x0001FE0C File Offset: 0x0001E00C
		' (set) Token: 0x06003396 RID: 13206 RVA: 0x0001FE16 File Offset: 0x0001E016
		Friend Overridable Property Label3 As Label

		' Token: 0x17001404 RID: 5124
		' (get) Token: 0x06003397 RID: 13207 RVA: 0x0001FE1F File Offset: 0x0001E01F
		' (set) Token: 0x06003398 RID: 13208 RVA: 0x0001FE29 File Offset: 0x0001E029
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17001405 RID: 5125
		' (get) Token: 0x06003399 RID: 13209 RVA: 0x0001FE32 File Offset: 0x0001E032
		' (set) Token: 0x0600339A RID: 13210 RVA: 0x0001FE3C File Offset: 0x0001E03C
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x17001406 RID: 5126
		' (get) Token: 0x0600339B RID: 13211 RVA: 0x0001FE45 File Offset: 0x0001E045
		' (set) Token: 0x0600339C RID: 13212 RVA: 0x0001FE4F File Offset: 0x0001E04F
		Friend Overridable Property Label5 As Label

		' Token: 0x17001407 RID: 5127
		' (get) Token: 0x0600339D RID: 13213 RVA: 0x0001FE58 File Offset: 0x0001E058
		' (set) Token: 0x0600339E RID: 13214 RVA: 0x0001FE62 File Offset: 0x0001E062
		Friend Overridable Property Label14 As Label

		' Token: 0x17001408 RID: 5128
		' (get) Token: 0x0600339F RID: 13215 RVA: 0x0001FE6B File Offset: 0x0001E06B
		' (set) Token: 0x060033A0 RID: 13216 RVA: 0x0001FE75 File Offset: 0x0001E075
		Friend Overridable Property txtProductName As TextBox

		' Token: 0x17001409 RID: 5129
		' (get) Token: 0x060033A1 RID: 13217 RVA: 0x0001FE7E File Offset: 0x0001E07E
		' (set) Token: 0x060033A2 RID: 13218 RVA: 0x0001FE88 File Offset: 0x0001E088
		Friend Overridable Property lblUser As Label

		' Token: 0x060033A3 RID: 13219 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmLeadGenerate_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060033A4 RID: 13220 RVA: 0x001FE180 File Offset: 0x001FC380
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter Customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbCustomerName.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbState.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbState.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtContactNo.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select RTRIM(customer_name) from tbl_lead_master where customer_name=@d1"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								MessageBox.Show("Entered name is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.cmbCustomerName.Focus()
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "select RTRIM(mobile) from tbl_lead_master where mobile=@d1"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactNo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
								If flag6 Then
									MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.txtContactNo.Focus()
									Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag7 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "INSERT INTO tbl_lead_master " & vbCrLf & "    (lead_date, customer_name, coordinate_mode, mobile, state, address, interest_mode, productname, remarks, alloted_user) " & vbCrLf & "    VALUES (@lead_date, @customer_name, @coordinate_mode, @mobile, @state, @address, @interest_mode, @productname, @remarks, @alloted_user)"
									ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.AddWithValue("@lead_date", Me.Lead_Date.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@customer_name", Me.cmbCustomerName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@coordinate_mode", Me.cboxCordinateMode.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@mobile", Me.txtContactNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@state", Me.cmbState.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@address", Me.txtAddress.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@interest_mode", Me.cmbInterestMode.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@productname", Me.txtProductName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@remarks", Me.txtRemarks.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@alloted_user", Me.lblUser.Text)
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									MessageBox.Show("Successfully Saved", "Customer Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnSave.Enabled = False
									Me.Reset()
								End If
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060033A5 RID: 13221 RVA: 0x0001FE91 File Offset: 0x0001E091
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060033A6 RID: 13222 RVA: 0x001FE5E0 File Offset: 0x001FC7E0
		Public Sub Reset()
			Me.txtAddress.Text = ""
			Me.txtRemarks.Text = ""
			Me.cmbCustomerName.Text = ""
			Me.txtCustomerID.Text = ""
			Me.txtContactNo.Text = ""
			Me.cmbState.SelectedIndex = -1
			Me.cmbCustomerName.Focus()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
		End Sub
	End Class
End Namespace
