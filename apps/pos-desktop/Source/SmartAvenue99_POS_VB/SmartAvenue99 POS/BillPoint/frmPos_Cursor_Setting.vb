Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001D0 RID: 464
	<DesignerGenerated()>
	Public Partial Class frmPos_Cursor_Setting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007953 RID: 31059 RVA: 0x0003C139 File Offset: 0x0003A339
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPos_Cursor_Setting_Load
			Me.isFormLoading = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002C8D RID: 11405
		' (get) Token: 0x06007956 RID: 31062 RVA: 0x0003C163 File Offset: 0x0003A363
		' (set) Token: 0x06007957 RID: 31063 RVA: 0x0003C16D File Offset: 0x0003A36D
		Friend Overridable Property cmbComboPack As ComboBox

		' Token: 0x17002C8E RID: 11406
		' (get) Token: 0x06007958 RID: 31064 RVA: 0x0003C176 File Offset: 0x0003A376
		' (set) Token: 0x06007959 RID: 31065 RVA: 0x0003C180 File Offset: 0x0003A380
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17002C8F RID: 11407
		' (get) Token: 0x0600795A RID: 31066 RVA: 0x0003C189 File Offset: 0x0003A389
		' (set) Token: 0x0600795B RID: 31067 RVA: 0x005AA790 File Offset: 0x005A8990
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

		' Token: 0x0600795C RID: 31068 RVA: 0x005AA7D4 File Offset: 0x005A89D4
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.isFormLoading
			If Not flag Then
				Dim flag2 As Boolean = Me.cmbComboPack.SelectedIndex <> -1
				If flag2 Then
					Me.UpdateComboDefault(Me.cmbComboPack.SelectedItem.ToString())
				End If
			End If
		End Sub

		' Token: 0x0600795D RID: 31069 RVA: 0x0003C193 File Offset: 0x0003A393
		Private Sub frmPos_Cursor_Setting_Load(sender As Object, e As EventArgs)
			Me.isFormLoading = True
			Me.combo_control_default()
			Me.isFormLoading = False
		End Sub

		' Token: 0x0600795E RID: 31070 RVA: 0x005AA81C File Offset: 0x005A8A1C
		Private Sub UpdateComboDefault(selectedItem As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("UPDATE tbl_form_cursor SET is_default = 0", ModCommonClasses.con)
				sqlCommand.ExecuteNonQuery()
				Dim sqlCommand2 As SqlCommand = New SqlCommand("UPDATE tbl_form_cursor SET is_default = 1 WHERE form_itemname = @name", ModCommonClasses.con)
				sqlCommand2.Parameters.AddWithValue("@name", selectedItem)
				sqlCommand2.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				MessageBox.Show("Default Set :" + selectedItem)
			Catch ex As Exception
				MessageBox.Show("Error updating default combo item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600795F RID: 31071 RVA: 0x005AA8E4 File Offset: 0x005A8AE4
		Public Sub combo_control_default()
			Try
				Me.cmbComboPack.Items.Clear()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT form_itemname, is_default FROM tbl_form_cursor ORDER BY id", ModCommonClasses.con)
				Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
				Dim text As String = Nothing
				While sqlDataReader.Read()
					Dim text2 As String = sqlDataReader("form_itemname").ToString()
					Me.cmbComboPack.Items.Add(text2)
					Dim flag As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlDataReader("is_default"))) = 1
					If flag Then
						text = text2
					End If
				End While
				Dim flag2 As Boolean = text <> Nothing
				If flag2 Then
					Me.cmbComboPack.SelectedItem = text
				Else
					Dim flag3 As Boolean = Me.cmbComboPack.Items.Count > 0
					If flag3 Then
						Me.cmbComboPack.SelectedIndex = 0
					End If
				End If
				sqlDataReader.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show("Error loading combo items: " + ex.Message)
			End Try
		End Sub

		' Token: 0x040035B0 RID: 13744
		Private isFormLoading As Boolean
	End Class
End Namespace
