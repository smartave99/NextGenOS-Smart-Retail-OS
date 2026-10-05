Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports CButtonLib
Imports FireSharp
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000118 RID: 280
	<DesignerGenerated()>
	Public Partial Class frmGodownConfig
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002FE9 RID: 12265 RVA: 0x0001E06B File Offset: 0x0001C26B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGodownConfig_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGodownConfig_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170012AA RID: 4778
		' (get) Token: 0x06002FEC RID: 12268 RVA: 0x0001E09D File Offset: 0x0001C29D
		' (set) Token: 0x06002FED RID: 12269 RVA: 0x0001E0A7 File Offset: 0x0001C2A7
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170012AB RID: 4779
		' (get) Token: 0x06002FEE RID: 12270 RVA: 0x0001E0B0 File Offset: 0x0001C2B0
		' (set) Token: 0x06002FEF RID: 12271 RVA: 0x0001E0BA File Offset: 0x0001C2BA
		Friend Overridable Property Label1 As Label

		' Token: 0x170012AC RID: 4780
		' (get) Token: 0x06002FF0 RID: 12272 RVA: 0x0001E0C3 File Offset: 0x0001C2C3
		' (set) Token: 0x06002FF1 RID: 12273 RVA: 0x001D8664 File Offset: 0x001D6864
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012AD RID: 4781
		' (get) Token: 0x06002FF2 RID: 12274 RVA: 0x0001E0CD File Offset: 0x0001C2CD
		' (set) Token: 0x06002FF3 RID: 12275 RVA: 0x001D86A8 File Offset: 0x001D68A8
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

		' Token: 0x170012AE RID: 4782
		' (get) Token: 0x06002FF4 RID: 12276 RVA: 0x0001E0D7 File Offset: 0x0001C2D7
		' (set) Token: 0x06002FF5 RID: 12277 RVA: 0x0001E0E1 File Offset: 0x0001C2E1
		Friend Overridable Property Label3 As Label

		' Token: 0x170012AF RID: 4783
		' (get) Token: 0x06002FF6 RID: 12278 RVA: 0x0001E0EA File Offset: 0x0001C2EA
		' (set) Token: 0x06002FF7 RID: 12279 RVA: 0x0001E0F4 File Offset: 0x0001C2F4
		Friend Overridable Property Label2 As Label

		' Token: 0x170012B0 RID: 4784
		' (get) Token: 0x06002FF8 RID: 12280 RVA: 0x0001E0FD File Offset: 0x0001C2FD
		' (set) Token: 0x06002FF9 RID: 12281 RVA: 0x001D86EC File Offset: 0x001D68EC
		Private _Button3 As CButton
		Friend Overridable Property Button3 As CButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.Button3_ClickButtonArea
				Dim cbutton As CButton = Me._Button3
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._Button3 = value
				cbutton = Me._Button3
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012B1 RID: 4785
		' (get) Token: 0x06002FFA RID: 12282 RVA: 0x0001E107 File Offset: 0x0001C307
		' (set) Token: 0x06002FFB RID: 12283 RVA: 0x001D8730 File Offset: 0x001D6930
		Private _btnDelete As CButton
		Friend Overridable Property btnDelete As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnDelete_ClickButtonArea
				Dim cbutton As CButton = Me._btnDelete
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnDelete = value
				cbutton = Me._btnDelete
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012B2 RID: 4786
		' (get) Token: 0x06002FFC RID: 12284 RVA: 0x0001E111 File Offset: 0x0001C311
		' (set) Token: 0x06002FFD RID: 12285 RVA: 0x0001E11B File Offset: 0x0001C31B
		Friend Overridable Property lblUserType As Label

		' Token: 0x170012B3 RID: 4787
		' (get) Token: 0x06002FFE RID: 12286 RVA: 0x0001E124 File Offset: 0x0001C324
		' (set) Token: 0x06002FFF RID: 12287 RVA: 0x0001E12E File Offset: 0x0001C32E
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x06003000 RID: 12288 RVA: 0x001D8774 File Offset: 0x001D6974
		Private Sub Button3_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT COUNT(*) FROM Activation"
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
				Dim flag As Boolean = num > 0
				If flag Then
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "Update Activation set HardwareID=@d1, ActivationID=@d2 where ID=@d3"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.TrimEnd(New Char(-1) {}))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox2.Text.TrimEnd(New Char(-1) {}))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 1)
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "Insert into Activation(HardwareID, ActivationID) VALUES (@d1, @d2)"
					ModCommonClasses.cmd = New SqlCommand(text3)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.TrimEnd(New Char(-1) {}))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox2.Text.TrimEnd(New Char(-1) {}))
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003001 RID: 12289 RVA: 0x001D89E0 File Offset: 0x001D6BE0
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(If(("SELECT RTRIM(ID), RTRIM(HardwareID), RTRIM(ActivationID) from Activation where ID=" + Conversions.ToString(1)), ""), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.TextBox1.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.TextBox2.Text = ModCommonClasses.rdr.GetValue(2).ToString()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003002 RID: 12290 RVA: 0x0001E137 File Offset: 0x0001C337
		Private Sub frmGodownConfig_Load(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06003003 RID: 12291 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGodownConfig_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06003004 RID: 12292 RVA: 0x001D8AD0 File Offset: 0x001D6CD0
		Private Sub btnDelete_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0
			If flag Then
				Try
					Me.RealtimeDatabasePath = Me.TextBox1.Text.ToString()
					Me.DatabaseSecretKey = Me.TextBox2.Text.ToString()
					Dim firebaseConfig As FirebaseConfig = New FirebaseConfig() With { .AuthSecret = Me.DatabaseSecretKey, .BasePath = Me.RealtimeDatabasePath }
					Try
						Me.client = New FirebaseClient(firebaseConfig)
					Catch ex As Exception
						MessageBox.Show(ex.Message)
					End Try
					Dim firebaseResponse As FirebaseResponse = Me.client.Delete("/")
					MessageBox.Show("All Data Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				MessageBox.Show("You are not allowed to delete !", "Ooops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		End Sub

		' Token: 0x06003005 RID: 12293 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06003006 RID: 12294 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x04001487 RID: 5255
		Private client As IFirebaseClient

		' Token: 0x04001488 RID: 5256
		Private RealtimeDatabasePath As String

		' Token: 0x04001489 RID: 5257
		Private DatabaseSecretKey As String
	End Class
End Namespace
