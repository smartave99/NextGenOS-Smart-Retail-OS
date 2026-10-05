Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200012A RID: 298
	<DesignerGenerated()>
	Public Partial Class frmLSetDefault
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060033A7 RID: 13223 RVA: 0x0001FE9B File Offset: 0x0001E09B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLSetDefault_Load
			AddHandler MyBase.FormClosed, AddressOf Me.frmLSetDefault_FormClosed
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700140A RID: 5130
		' (get) Token: 0x060033AA RID: 13226 RVA: 0x0001FECD File Offset: 0x0001E0CD
		' (set) Token: 0x060033AB RID: 13227 RVA: 0x0001FED7 File Offset: 0x0001E0D7
		Friend Overridable Property Label2 As Label

		' Token: 0x1700140B RID: 5131
		' (get) Token: 0x060033AC RID: 13228 RVA: 0x0001FEE0 File Offset: 0x0001E0E0
		' (set) Token: 0x060033AD RID: 13229 RVA: 0x0001FEEA File Offset: 0x0001E0EA
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700140C RID: 5132
		' (get) Token: 0x060033AE RID: 13230 RVA: 0x0001FEF3 File Offset: 0x0001E0F3
		' (set) Token: 0x060033AF RID: 13231 RVA: 0x001FEB7C File Offset: 0x001FCD7C
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

		' Token: 0x1700140D RID: 5133
		' (get) Token: 0x060033B0 RID: 13232 RVA: 0x0001FEFD File Offset: 0x0001E0FD
		' (set) Token: 0x060033B1 RID: 13233 RVA: 0x0001FF07 File Offset: 0x0001E107
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x1700140E RID: 5134
		' (get) Token: 0x060033B2 RID: 13234 RVA: 0x0001FF10 File Offset: 0x0001E110
		' (set) Token: 0x060033B3 RID: 13235 RVA: 0x0001FF1A File Offset: 0x0001E11A
		Friend Overridable Property Label1 As Label

		' Token: 0x1700140F RID: 5135
		' (get) Token: 0x060033B4 RID: 13236 RVA: 0x0001FF23 File Offset: 0x0001E123
		' (set) Token: 0x060033B5 RID: 13237 RVA: 0x0001FF2D File Offset: 0x0001E12D
		Friend Overridable Property lbltype As Label

		' Token: 0x060033B6 RID: 13238 RVA: 0x001FEBC0 File Offset: 0x001FCDC0
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update tbl_loyalty_setting Set mode=@d1, points=@d2 where id=1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Convert.ToDecimal(Me.TextBox1.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				MessageBox.Show("Updated Succefully!")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060033B7 RID: 13239 RVA: 0x0001FF36 File Offset: 0x0001E136
		Private Sub frmLSetDefault_Load(sender As Object, e As EventArgs)
			Me.DefaultLoyality()
		End Sub

		' Token: 0x060033B8 RID: 13240 RVA: 0x001FEC98 File Offset: 0x001FCE98
		Public Sub DefaultLoyality()
			Try
				Dim text As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlConnection.Open()
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								Me.ComboBox1.Text = sqlDataReader("mode").ToString()
								Me.TextBox1.Text = sqlDataReader("points").ToString()
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060033B9 RID: 13241 RVA: 0x001FED9C File Offset: 0x001FCF9C
		Private Sub frmLSetDefault_FormClosed(sender As Object, e As FormClosedEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lbltype.Text, "bulk", False) = 0
			If flag Then
				MyBase.Dispose()
				MyProject.Forms.frmProductBulkUpdate.ShowDialog()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.lbltype.Text, "import", False) = 0
				If flag2 Then
					MyBase.Dispose()
					MyProject.Forms.frmExportImportExcel_ProductsRecord.ShowDialog()
				End If
			End If
		End Sub
	End Class
End Namespace
