Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports DevNet
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200035E RID: 862
	<DesignerGenerated()>
	Public Partial Class frmProductImageUpdator
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CC23 RID: 52259 RVA: 0x007FB15C File Offset: 0x007F935C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductImageUpdator_Load
			AddHandler MyBase.Closing, AddressOf Me.frmProductImageUpdator_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductImageUpdator_KeyDown
			AddHandler MyBase.FormClosing, AddressOf Me.frmProductImageUpdator_FormClosing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005035 RID: 20533
		' (get) Token: 0x0600CC26 RID: 52262 RVA: 0x0005ABFB File Offset: 0x00058DFB
		' (set) Token: 0x0600CC27 RID: 52263 RVA: 0x007FC49C File Offset: 0x007FA69C
		Private _btnRemove As Button
		Public Overridable Property btnRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemove_Click
				Dim button As Button = Me._btnRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRemove = value
				button = Me._btnRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005036 RID: 20534
		' (get) Token: 0x0600CC28 RID: 52264 RVA: 0x0005AC05 File Offset: 0x00058E05
		' (set) Token: 0x0600CC29 RID: 52265 RVA: 0x007FC4E0 File Offset: 0x007FA6E0
		Private _btnAdd As Button
		Public Overridable Property btnAdd As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAdd_Click
				Dim button As Button = Me._btnAdd
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAdd = value
				button = Me._btnAdd
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005037 RID: 20535
		' (get) Token: 0x0600CC2A RID: 52266 RVA: 0x0005AC0F File Offset: 0x00058E0F
		' (set) Token: 0x0600CC2B RID: 52267 RVA: 0x007FC524 File Offset: 0x007FA724
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005038 RID: 20536
		' (get) Token: 0x0600CC2C RID: 52268 RVA: 0x0005AC19 File Offset: 0x00058E19
		' (set) Token: 0x0600CC2D RID: 52269 RVA: 0x0005AC23 File Offset: 0x00058E23
		Friend Overridable Property Column1 As DataGridViewImageColumn

		' Token: 0x17005039 RID: 20537
		' (get) Token: 0x0600CC2E RID: 52270 RVA: 0x0005AC2C File Offset: 0x00058E2C
		' (set) Token: 0x0600CC2F RID: 52271 RVA: 0x0005AC36 File Offset: 0x00058E36
		Public Overridable Property Picture As PictureBox

		' Token: 0x1700503A RID: 20538
		' (get) Token: 0x0600CC30 RID: 52272 RVA: 0x0005AC3F File Offset: 0x00058E3F
		' (set) Token: 0x0600CC31 RID: 52273 RVA: 0x007FC568 File Offset: 0x007FA768
		Private _BRemove As Button
		Friend Overridable Property BRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._BRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BRemove_Click
				Dim button As Button = Me._BRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BRemove = value
				button = Me._BRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700503B RID: 20539
		' (get) Token: 0x0600CC32 RID: 52274 RVA: 0x0005AC49 File Offset: 0x00058E49
		' (set) Token: 0x0600CC33 RID: 52275 RVA: 0x007FC5AC File Offset: 0x007FA7AC
		Private _Browse As Button
		Friend Overridable Property Browse As Button
			<CompilerGenerated()>
			Get
				Return Me._Browse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Browse_Click
				Dim button As Button = Me._Browse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Browse = value
				button = Me._Browse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700503C RID: 20540
		' (get) Token: 0x0600CC34 RID: 52276 RVA: 0x0005AC53 File Offset: 0x00058E53
		' (set) Token: 0x0600CC35 RID: 52277 RVA: 0x0005AC5D File Offset: 0x00058E5D
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x1700503D RID: 20541
		' (get) Token: 0x0600CC36 RID: 52278 RVA: 0x0005AC66 File Offset: 0x00058E66
		' (set) Token: 0x0600CC37 RID: 52279 RVA: 0x007FC5F0 File Offset: 0x007FA7F0
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

		' Token: 0x1700503E RID: 20542
		' (get) Token: 0x0600CC38 RID: 52280 RVA: 0x0005AC70 File Offset: 0x00058E70
		' (set) Token: 0x0600CC39 RID: 52281 RVA: 0x0005AC7A File Offset: 0x00058E7A
		Friend Overridable Property txtID As TextBox

		' Token: 0x1700503F RID: 20543
		' (get) Token: 0x0600CC3A RID: 52282 RVA: 0x0005AC83 File Offset: 0x00058E83
		' (set) Token: 0x0600CC3B RID: 52283 RVA: 0x0005AC8D File Offset: 0x00058E8D
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005040 RID: 20544
		' (get) Token: 0x0600CC3C RID: 52284 RVA: 0x0005AC96 File Offset: 0x00058E96
		' (set) Token: 0x0600CC3D RID: 52285 RVA: 0x007FC634 File Offset: 0x007FA834
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellContentClick
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005041 RID: 20545
		' (get) Token: 0x0600CC3E RID: 52286 RVA: 0x0005ACA0 File Offset: 0x00058EA0
		' (set) Token: 0x0600CC3F RID: 52287 RVA: 0x007FC678 File Offset: 0x007FA878
		Private _Button2 As Button
		Public Overridable Property Button2 As Button
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

		' Token: 0x17005042 RID: 20546
		' (get) Token: 0x0600CC40 RID: 52288 RVA: 0x0005ACAA File Offset: 0x00058EAA
		' (set) Token: 0x0600CC41 RID: 52289 RVA: 0x0005ACB4 File Offset: 0x00058EB4
		Friend Overridable Property Label34 As Label

		' Token: 0x17005043 RID: 20547
		' (get) Token: 0x0600CC42 RID: 52290 RVA: 0x0005ACBD File Offset: 0x00058EBD
		' (set) Token: 0x0600CC43 RID: 52291 RVA: 0x0005ACC7 File Offset: 0x00058EC7
		Friend Overridable Property numericUpDown1 As NumericUpDown

		' Token: 0x17005044 RID: 20548
		' (get) Token: 0x0600CC44 RID: 52292 RVA: 0x0005ACD0 File Offset: 0x00058ED0
		' (set) Token: 0x0600CC45 RID: 52293 RVA: 0x0005ACDA File Offset: 0x00058EDA
		Friend Overridable Property Label1 As Label

		' Token: 0x17005045 RID: 20549
		' (get) Token: 0x0600CC46 RID: 52294 RVA: 0x0005ACE3 File Offset: 0x00058EE3
		' (set) Token: 0x0600CC47 RID: 52295 RVA: 0x0005ACED File Offset: 0x00058EED
		Friend Overridable Property Label2 As Label

		' Token: 0x17005046 RID: 20550
		' (get) Token: 0x0600CC48 RID: 52296 RVA: 0x0005ACF6 File Offset: 0x00058EF6
		' (set) Token: 0x0600CC49 RID: 52297 RVA: 0x007FC6BC File Offset: 0x007FA8BC
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600CC4A RID: 52298 RVA: 0x0005AD00 File Offset: 0x00058F00
		Private Sub frmProductImageUpdator_Load(sender As Object, e As EventArgs)
			Me.btnRemove.Enabled = False
		End Sub

		' Token: 0x0600CC4B RID: 52299 RVA: 0x007FC700 File Offset: 0x007FA900
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Me.dgw.Rows.Remove(dataGridViewRow)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Try
				For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
					Me.dgw.Rows.Remove(dataGridViewRow2)
				Next
			Finally
				Dim enumerator2 As IEnumerator
				If TypeOf enumerator2 Is IDisposable Then
					TryCast(enumerator2, IDisposable).Dispose()
				End If
			End Try
			Me.dgw.Rows.Add(New Object() { Me.Picture.Image })
		End Sub

		' Token: 0x0600CC4C RID: 52300 RVA: 0x007FC7FC File Offset: 0x007FA9FC
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Try
				Try
					For Each obj As Object In Me.dgw.SelectedRows
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.dgw.Rows.Remove(dataGridViewRow)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.btnRemove.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CC4D RID: 52301 RVA: 0x007FC8B0 File Offset: 0x007FAAB0
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Me.dgw.Rows.Count > 0
			If flag Then
				Me.btnRemove.Enabled = True
			End If
		End Sub

		' Token: 0x0600CC4E RID: 52302 RVA: 0x007FC8E4 File Offset: 0x007FAAE4
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Picture.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600CC4F RID: 52303 RVA: 0x0005AD10 File Offset: 0x00058F10
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources._12
		End Sub

		' Token: 0x0600CC50 RID: 52304 RVA: 0x007FC984 File Offset: 0x007FAB84
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dgw.Rows.Count = 0
			If flag Then
				Me.dgw.Rows.Add(New Object() { Me.Picture.Image })
			End If
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Product_Join where ProductID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Me.txtID.Text + ",@d2)"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Prepare()
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
						If flag2 Then
							Dim memoryStream As MemoryStream = New MemoryStream()
							Dim image As Image = CType(dataGridViewRow.Cells(0).Value, Image)
							Dim bitmap As Bitmap = New Bitmap(image)
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim buffer As Byte() = memoryStream.GetBuffer()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
							sqlParameter.Value = buffer
							ModCommonClasses.cmd.Parameters.Add(sqlParameter)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.cmd.Parameters.Clear()
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
				MessageBox.Show("Successfully Image Updated", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
			End Try
			Me.dgw.ClearSelection()
			Me.dgw.Rows.Clear()
			Me.dgw.DataSource = Nothing
			Me.Picture.Image = Resources._12
			Me.txtID.Text = ""
		End Sub

		' Token: 0x0600CC51 RID: 52305 RVA: 0x0005AD24 File Offset: 0x00058F24
		Private Sub frmProductImageUpdator_Closing(sender As Object, e As CancelEventArgs)
			Me.txtID.Text = ""
			Me.dgw.DataSource = Nothing
			MyProject.Forms.frmProductImageMaker.Getdata1()
		End Sub

		' Token: 0x0600CC52 RID: 52306 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmProductImageUpdator_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CC53 RID: 52307 RVA: 0x007FCC48 File Offset: 0x007FAE48
		Private Async Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill Item name!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.TextBox1.Focus()
				Else
					Dim result As List(Of WebImage) = Await QImage.Query(Me.TextBox1.Text, Convert.ToInt32(Me.numericUpDown1.Value))
					Me.DataGridView2.DataSource = result
				End If
			Else
				MessageBox.Show("Internet Connction not found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		End Sub

		' Token: 0x0600CC54 RID: 52308 RVA: 0x007FCC90 File Offset: 0x007FAE90
		Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = Me.DataGridView2.CurrentCell.ColumnIndex.Equals(0) AndAlso e.RowIndex <> -1
			If flag Then
				Dim flag2 As Boolean = Me.DataGridView2.CurrentCell IsNot Nothing AndAlso Me.DataGridView2.CurrentCell.Value IsNot Nothing
				If flag2 Then
					Dim image As Image = CType(Me.DataGridView2.CurrentCell.Value, Image)
					Me.Picture.Image = image
				End If
			End If
		End Sub

		' Token: 0x0600CC55 RID: 52309 RVA: 0x0005AD55 File Offset: 0x00058F55
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.DataGridView2.DataSource = Nothing
		End Sub

		' Token: 0x0600CC56 RID: 52310 RVA: 0x0005AD55 File Offset: 0x00058F55
		Private Sub frmProductImageUpdator_FormClosing(sender As Object, e As FormClosingEventArgs)
			Me.TextBox1.Text = ""
			Me.DataGridView2.DataSource = Nothing
		End Sub
	End Class
End Namespace
