Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Sheets.v4
Imports Google.Apis.Sheets.v4.Data
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000C4 RID: 196
	<DesignerGenerated()>
	Public Partial Class frmCustomerSupportLog
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001F81 RID: 8065 RVA: 0x000164E7 File Offset: 0x000146E7
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerSupportLog_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000C6F RID: 3183
		' (get) Token: 0x06001F84 RID: 8068 RVA: 0x00016507 File Offset: 0x00014707
		' (set) Token: 0x06001F85 RID: 8069 RVA: 0x00016511 File Offset: 0x00014711
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000C70 RID: 3184
		' (get) Token: 0x06001F86 RID: 8070 RVA: 0x0001651A File Offset: 0x0001471A
		' (set) Token: 0x06001F87 RID: 8071 RVA: 0x00016524 File Offset: 0x00014724
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000C71 RID: 3185
		' (get) Token: 0x06001F88 RID: 8072 RVA: 0x0001652D File Offset: 0x0001472D
		' (set) Token: 0x06001F89 RID: 8073 RVA: 0x00148CBC File Offset: 0x00146EBC
		Private _btnGenerate As GelButton
		Friend Overridable Property btnGenerate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGenerate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGenerate_Click
				Dim gelButton As GelButton = Me._btnGenerate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGenerate = value
				gelButton = Me._btnGenerate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C72 RID: 3186
		' (get) Token: 0x06001F8A RID: 8074 RVA: 0x00016537 File Offset: 0x00014737
		' (set) Token: 0x06001F8B RID: 8075 RVA: 0x00016541 File Offset: 0x00014741
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17000C73 RID: 3187
		' (get) Token: 0x06001F8C RID: 8076 RVA: 0x0001654A File Offset: 0x0001474A
		' (set) Token: 0x06001F8D RID: 8077 RVA: 0x00016554 File Offset: 0x00014754
		Friend Overridable Property cmbCustomerName As ComboBox

		' Token: 0x17000C74 RID: 3188
		' (get) Token: 0x06001F8E RID: 8078 RVA: 0x0001655D File Offset: 0x0001475D
		' (set) Token: 0x06001F8F RID: 8079 RVA: 0x00016567 File Offset: 0x00014767
		Friend Overridable Property Label2 As Label

		' Token: 0x17000C75 RID: 3189
		' (get) Token: 0x06001F90 RID: 8080 RVA: 0x00016570 File Offset: 0x00014770
		' (set) Token: 0x06001F91 RID: 8081 RVA: 0x0001657A File Offset: 0x0001477A
		Friend Overridable Property lbl_Result As Label

		' Token: 0x17000C76 RID: 3190
		' (get) Token: 0x06001F92 RID: 8082 RVA: 0x00016583 File Offset: 0x00014783
		' (set) Token: 0x06001F93 RID: 8083 RVA: 0x0001658D File Offset: 0x0001478D
		Friend Overridable Property Label7 As Label

		' Token: 0x17000C77 RID: 3191
		' (get) Token: 0x06001F94 RID: 8084 RVA: 0x00016596 File Offset: 0x00014796
		' (set) Token: 0x06001F95 RID: 8085 RVA: 0x000165A0 File Offset: 0x000147A0
		Friend Overridable Property txtEmailID As TextBox

		' Token: 0x17000C78 RID: 3192
		' (get) Token: 0x06001F96 RID: 8086 RVA: 0x000165A9 File Offset: 0x000147A9
		' (set) Token: 0x06001F97 RID: 8087 RVA: 0x000165B3 File Offset: 0x000147B3
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x17000C79 RID: 3193
		' (get) Token: 0x06001F98 RID: 8088 RVA: 0x000165BC File Offset: 0x000147BC
		' (set) Token: 0x06001F99 RID: 8089 RVA: 0x000165C6 File Offset: 0x000147C6
		Friend Overridable Property Label6 As Label

		' Token: 0x17000C7A RID: 3194
		' (get) Token: 0x06001F9A RID: 8090 RVA: 0x000165CF File Offset: 0x000147CF
		' (set) Token: 0x06001F9B RID: 8091 RVA: 0x000165D9 File Offset: 0x000147D9
		Friend Overridable Property Label1 As Label

		' Token: 0x17000C7B RID: 3195
		' (get) Token: 0x06001F9C RID: 8092 RVA: 0x000165E2 File Offset: 0x000147E2
		' (set) Token: 0x06001F9D RID: 8093 RVA: 0x000165EC File Offset: 0x000147EC
		Friend Overridable Property txtCallingNo As TextBox

		' Token: 0x17000C7C RID: 3196
		' (get) Token: 0x06001F9E RID: 8094 RVA: 0x000165F5 File Offset: 0x000147F5
		' (set) Token: 0x06001F9F RID: 8095 RVA: 0x000165FF File Offset: 0x000147FF
		Friend Overridable Property txtIssue As TextBox

		' Token: 0x17000C7D RID: 3197
		' (get) Token: 0x06001FA0 RID: 8096 RVA: 0x00016608 File Offset: 0x00014808
		' (set) Token: 0x06001FA1 RID: 8097 RVA: 0x00016612 File Offset: 0x00014812
		Friend Overridable Property Label5 As Label

		' Token: 0x17000C7E RID: 3198
		' (get) Token: 0x06001FA2 RID: 8098 RVA: 0x0001661B File Offset: 0x0001481B
		' (set) Token: 0x06001FA3 RID: 8099 RVA: 0x00016625 File Offset: 0x00014825
		Friend Overridable Property Label8 As Label

		' Token: 0x17000C7F RID: 3199
		' (get) Token: 0x06001FA4 RID: 8100 RVA: 0x0001662E File Offset: 0x0001482E
		' (set) Token: 0x06001FA5 RID: 8101 RVA: 0x00016638 File Offset: 0x00014838
		Friend Overridable Property txtCurrentStatus As TextBox

		' Token: 0x17000C80 RID: 3200
		' (get) Token: 0x06001FA6 RID: 8102 RVA: 0x00016641 File Offset: 0x00014841
		' (set) Token: 0x06001FA7 RID: 8103 RVA: 0x0001664B File Offset: 0x0001484B
		Friend Overridable Property Label4 As Label

		' Token: 0x17000C81 RID: 3201
		' (get) Token: 0x06001FA8 RID: 8104 RVA: 0x00016654 File Offset: 0x00014854
		' (set) Token: 0x06001FA9 RID: 8105 RVA: 0x0001665E File Offset: 0x0001485E
		Friend Overridable Property txtValidity As TextBox

		' Token: 0x17000C82 RID: 3202
		' (get) Token: 0x06001FAA RID: 8106 RVA: 0x00016667 File Offset: 0x00014867
		' (set) Token: 0x06001FAB RID: 8107 RVA: 0x00016671 File Offset: 0x00014871
		Friend Overridable Property Label3 As Label

		' Token: 0x17000C83 RID: 3203
		' (get) Token: 0x06001FAC RID: 8108 RVA: 0x0001667A File Offset: 0x0001487A
		' (set) Token: 0x06001FAD RID: 8109 RVA: 0x00016684 File Offset: 0x00014884
		Friend Overridable Property txtSoftwareName As TextBox

		' Token: 0x17000C84 RID: 3204
		' (get) Token: 0x06001FAE RID: 8110 RVA: 0x0001668D File Offset: 0x0001488D
		' (set) Token: 0x06001FAF RID: 8111 RVA: 0x00016697 File Offset: 0x00014897
		Friend Overridable Property lblMessage As Label

		' Token: 0x17000C85 RID: 3205
		' (get) Token: 0x06001FB0 RID: 8112 RVA: 0x000166A0 File Offset: 0x000148A0
		' (set) Token: 0x06001FB1 RID: 8113 RVA: 0x000166AA File Offset: 0x000148AA
		Friend Overridable Property lblToken_Id As Label

		' Token: 0x17000C86 RID: 3206
		' (get) Token: 0x06001FB2 RID: 8114 RVA: 0x000166B3 File Offset: 0x000148B3
		' (set) Token: 0x06001FB3 RID: 8115 RVA: 0x000166BD File Offset: 0x000148BD
		Friend Overridable Property lbl_Id As Label

		' Token: 0x06001FB4 RID: 8116 RVA: 0x00148D00 File Offset: 0x00146F00
		Private Sub btnGenerate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Strings.Len(Strings.Trim(Me.txtIssue.Text)) = 0) Or (Me.txtIssue.Text = Nothing)
			If flag Then
				MessageBox.Show("Please enter Issue. ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtIssue.Focus()
			Else
				Me.InsertSupportLogToGoogleSheet()
			End If
		End Sub

		' Token: 0x06001FB5 RID: 8117 RVA: 0x00148D64 File Offset: 0x00146F64
		Private Sub frmCustomerSupportLog_Load(sender As Object, e As EventArgs)
			Me.lbl_Id.Text = ""
			Me.lblToken_Id.Text = ""
			Me.CompanyInfoDisplay()
			Me.btnGenerate.Enabled = True
			Me.lblMessage.Visible = False
			Dim registrydata As frmSplash.LicenseDataNew = MyProject.Forms.frmSplash.getRegistrydata()
			Me.txtSoftwareName.Text = registrydata.company
			Me.strSupport_number = "+91" + registrydata.phone
		End Sub

		' Token: 0x06001FB6 RID: 8118 RVA: 0x00148DF0 File Offset: 0x00146FF0
		Private Function GenerateID() As String
			Dim text As String = "T-000001"
			Try
				Dim text2 As String = Path.Combine(Application.StartupPath, "credentials_.json")
				Dim googleCredential As GoogleCredential
				Using fileStream As FileStream = New FileStream(text2, FileMode.Open, FileAccess.Read)
					googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(New String() { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets })
				End Using
				Dim sheetsService As SheetsService = New SheetsService(New BaseClientService.Initializer() With { .HttpClientInitializer = googleCredential, .ApplicationName = "Customer Support Logger" })
				Dim text3 As String = "10Jp2rmH0KQ-6mNWHH3fTVX1eKHPnsipglEwlex9LyHg"
				Dim text4 As String = "Form Responses 1"
				Dim getRequest As SpreadsheetsResource.ValuesResource.GetRequest = sheetsService.Spreadsheets.Values.[Get](text3, text4 + "!B2:B")
				Dim valueRange As ValueRange = getRequest.Execute()
				Dim flag As Boolean = valueRange.Values IsNot Nothing AndAlso valueRange.Values.Count > 0
				If flag Then
					Dim list As IList(Of Object) = valueRange.Values(valueRange.Values.Count - 1)
					Dim flag2 As Boolean = list.Count > 0
					If flag2 Then
						Dim text5 As String = list(0).ToString().Trim()
						Dim text6 As String = text5.Replace("T-", "")
						Dim num As Integer
						Dim flag3 As Boolean = Integer.TryParse(text6, num)
						If flag3 Then
							num += 1
							text = "T-" + num.ToString("D6")
						End If
					End If
				End If
			Catch ex As Exception
				text = "T-000001"
			End Try
			Return text
		End Function

		' Token: 0x06001FB7 RID: 8119 RVA: 0x00148FA4 File Offset: 0x001471A4
		Public Sub CompanyInfoDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(ID), RTRIM(CompanyName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(GSTIN), RTRIM(State), RTRIM(FYFrom), RTRIM(FYTo), RTRIM(AndroidID), RTRIM(CurSym) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.cmbCustomerName.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtEmailID.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtValidity.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(8))
					Dim dateTime As DateTime
					Dim flag3 As Boolean = DateTime.TryParse(ModCommonClasses.rdr.GetValue(8).ToString(), dateTime)
					If flag3 Then
						Dim flag4 As Boolean = DateTime.Compare(dateTime, DateTime.Today) >= 0
						If flag4 Then
							Me.txtCurrentStatus.Text = "Enabled"
						Else
							Me.txtCurrentStatus.Text = "Disabled"
						End If
					Else
						Me.txtCurrentStatus.Text = "Invalid FY Date"
					End If
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001FB8 RID: 8120 RVA: 0x00149150 File Offset: 0x00147350
		Public Sub DataInsert()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "                INSERT INTO CustomerSupportLog " & vbCrLf & "                (support_token_no, CustomerName, RegisteredMobileNumber, CallingNumber, CurrentIssue, " & vbCrLf & "                 SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, EmailAddress) " & vbCrLf & "                VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11);" & vbCrLf & "                SELECT CAST(SCOPE_IDENTITY() AS INT);" & vbCrLf & "            "
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d0", Me.lblToken_Id.Text)
						sqlCommand.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
						sqlCommand.Parameters.AddWithValue("@d2", Me.txtContactNo.Text)
						sqlCommand.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(If(String.IsNullOrEmpty(Me.txtCallingNo.Text), DBNull.Value, Me.txtCallingNo.Text)))
						sqlCommand.Parameters.AddWithValue("@d4", Me.txtIssue.Text)
						sqlCommand.Parameters.AddWithValue("@d5", Me.txtSoftwareName.Text)
						sqlCommand.Parameters.AddWithValue("@d6", Me.txtValidity.Text)
						sqlCommand.Parameters.AddWithValue("@d7", "Open")
						sqlCommand.Parameters.AddWithValue("@d8", DBNull.Value)
						sqlCommand.Parameters.AddWithValue("@d9", DBNull.Value)
						sqlCommand.Parameters.AddWithValue("@d10", DBNull.Value)
						sqlCommand.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(If(String.IsNullOrEmpty(Me.txtEmailID.Text), DBNull.Value, Me.txtEmailID.Text)))
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
						Me.lblMessage.Visible = True
						Me.lblMessage.Text = String.Concat(New String() { "✅ Your support request has been received." & vbCrLf & vbCrLf & "Support Token Number: ", Me.lblToken_Id.Text, vbCrLf & "Submitted: ", DateAndTime.Now.ToString("dd MMM yyyy HH:mm"), vbCrLf & vbCrLf & "We'll update you here. For urgent issues call ", Me.strSupport_number, "." })
						Me.btnGenerate.Enabled = False
					End Using
				End Using
				MessageBox.Show("Token Generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				MyProject.Forms.frmCustomerSupportLog_Report.LoadCustomerSupportLogs("")
			Catch ex As Exception
				MessageBox.Show("Error inserting support log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001FB9 RID: 8121 RVA: 0x00149448 File Offset: 0x00147648
		Public Sub InsertSupportLogToGoogleSheet()
			' The following expression was wrapped in a checked-statement
			Try
				Dim text As String = Path.Combine(Application.StartupPath, "credentials_.json")
				Dim googleCredential As GoogleCredential
				Using fileStream As FileStream = New FileStream(text, FileMode.Open, FileAccess.Read)
					googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(New String() { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets })
				End Using
				Dim sheetsService As SheetsService = New SheetsService(New BaseClientService.Initializer() With { .HttpClientInitializer = googleCredential, .ApplicationName = "Customer Support Logger" })
				Dim text2 As String = "10Jp2rmH0KQ-6mNWHH3fTVX1eKHPnsipglEwlex9LyHg"
				Dim text3 As String = "Form Responses 1"
				Dim getRequest As SpreadsheetsResource.ValuesResource.GetRequest = sheetsService.Spreadsheets.Values.[Get](text2, text3 + "!B2:B")
				Dim valueRange As ValueRange = getRequest.Execute()
				Dim num As Integer = 0
				Dim flag As Boolean = valueRange.Values IsNot Nothing AndAlso valueRange.Values.Count > 0
				If flag Then
					Dim list As IList(Of Object) = valueRange.Values(valueRange.Values.Count - 1)
					Dim flag2 As Boolean = list.Count > 0
					If flag2 Then
						Integer.TryParse(list(0).ToString(), num)
					End If
				End If
				Dim text4 As String = (num + 1).ToString("D6")
				Me.lblToken_Id.Text = Me.GenerateID()
				Dim list2 As IList(Of Object) = New List(Of Object)() From { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Me.lblToken_Id.Text, Me.cmbCustomerName.Text, Me.txtContactNo.Text, If(String.IsNullOrEmpty(Me.txtCallingNo.Text), "", Me.txtCallingNo.Text), Me.txtIssue.Text, Me.txtSoftwareName.Text, Me.txtValidity.Text, "Open", "", "", "", Me.txtEmailID.Text }
				Dim valueRange2 As ValueRange = New ValueRange()
				valueRange2.Values = New List(Of IList(Of Object))() From { list2 }
				Dim appendRequest As SpreadsheetsResource.ValuesResource.AppendRequest = sheetsService.Spreadsheets.Values.Append(valueRange2, text2, text3 + "!A1")
				appendRequest.ValueInputOption = New SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum?(SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED)
				appendRequest.Execute()
				Me.DataInsert()
			Catch ex As Exception
				MessageBox.Show("Error inserting row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04000CD8 RID: 3288
		Private strSupport_number As String
	End Class
End Namespace
