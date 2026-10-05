Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200036E RID: 878
	<DesignerGenerated()>
	Public Partial Class frmScrDsply
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CFAD RID: 53165 RVA: 0x0005C53C File Offset: 0x0005A73C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmScrDsply_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005179 RID: 20857
		' (get) Token: 0x0600CFB0 RID: 53168 RVA: 0x0005C55C File Offset: 0x0005A75C
		' (set) Token: 0x0600CFB1 RID: 53169 RVA: 0x0005C566 File Offset: 0x0005A766
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x0600CFB2 RID: 53170 RVA: 0x008182DC File Offset: 0x008164DC
		Private Sub DSI()
			Dim sqlCommand As SqlCommand = New SqlCommand("Select c3 from Gallery where c4=@d1", ModCommonClasses.con)
			sqlCommand.Parameters.AddWithValue("@d1", "Yes")
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
			Dim dataTable As DataTable = New DataTable()
			Try
				sqlDataAdapter.Fill(dataTable)
				Dim flag As Boolean = dataTable.Rows.Count = 1
				If flag Then
					Dim array As Byte() = CType(dataTable.AsEnumerable().ElementAtOrDefault(0)(0), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.PictureBox1.Image = Image.FromStream(memoryStream)
				Else
					Me.PictureBox1.Image = Nothing
				End If
			Catch ex As Exception
				Me.PictureBox1.Image = Nothing
			End Try
		End Sub

		' Token: 0x0600CFB3 RID: 53171 RVA: 0x0005C56F File Offset: 0x0005A76F
		Private Sub frmScrDsply_Load(sender As Object, e As EventArgs)
			Me.DSI()
		End Sub
	End Class
End Namespace
