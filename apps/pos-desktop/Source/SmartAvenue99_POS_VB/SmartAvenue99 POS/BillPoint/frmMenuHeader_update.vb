Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200012B RID: 299
	<DesignerGenerated()>
	Public Partial Class frmMenuHeader_update
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060033BA RID: 13242 RVA: 0x0001FF40 File Offset: 0x0001E140
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMenu_update_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001410 RID: 5136
		' (get) Token: 0x060033BD RID: 13245 RVA: 0x0001FF60 File Offset: 0x0001E160
		' (set) Token: 0x060033BE RID: 13246 RVA: 0x0001FF6A File Offset: 0x0001E16A
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17001411 RID: 5137
		' (get) Token: 0x060033BF RID: 13247 RVA: 0x0001FF73 File Offset: 0x0001E173
		' (set) Token: 0x060033C0 RID: 13248 RVA: 0x0001FF7D File Offset: 0x0001E17D
		Friend Overridable Property lblSubcategory As Label

		' Token: 0x17001412 RID: 5138
		' (get) Token: 0x060033C1 RID: 13249 RVA: 0x0001FF86 File Offset: 0x0001E186
		' (set) Token: 0x060033C2 RID: 13250 RVA: 0x0001FF90 File Offset: 0x0001E190
		Friend Overridable Property lblId As Label

		' Token: 0x17001413 RID: 5139
		' (get) Token: 0x060033C3 RID: 13251 RVA: 0x0001FF99 File Offset: 0x0001E199
		' (set) Token: 0x060033C4 RID: 13252 RVA: 0x002004F0 File Offset: 0x001FE6F0
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001414 RID: 5140
		' (get) Token: 0x060033C5 RID: 13253 RVA: 0x0001FFA3 File Offset: 0x0001E1A3
		' (set) Token: 0x060033C6 RID: 13254 RVA: 0x0001FFAD File Offset: 0x0001E1AD
		Public Overridable Property Picture As PictureBox

		' Token: 0x17001415 RID: 5141
		' (get) Token: 0x060033C7 RID: 13255 RVA: 0x0001FFB6 File Offset: 0x0001E1B6
		' (set) Token: 0x060033C8 RID: 13256 RVA: 0x00200534 File Offset: 0x001FE734
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

		' Token: 0x17001416 RID: 5142
		' (get) Token: 0x060033C9 RID: 13257 RVA: 0x0001FFC0 File Offset: 0x0001E1C0
		' (set) Token: 0x060033CA RID: 13258 RVA: 0x00200578 File Offset: 0x001FE778
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

		' Token: 0x17001417 RID: 5143
		' (get) Token: 0x060033CB RID: 13259 RVA: 0x0001FFCA File Offset: 0x0001E1CA
		' (set) Token: 0x060033CC RID: 13260 RVA: 0x0001FFD4 File Offset: 0x0001E1D4
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17001418 RID: 5144
		' (get) Token: 0x060033CD RID: 13261 RVA: 0x0001FFDD File Offset: 0x0001E1DD
		' (set) Token: 0x060033CE RID: 13262 RVA: 0x0001FFE7 File Offset: 0x0001E1E7
		Friend Overridable Property chkAuto As CheckBox

		' Token: 0x17001419 RID: 5145
		' (get) Token: 0x060033CF RID: 13263 RVA: 0x0001FFF0 File Offset: 0x0001E1F0
		' (set) Token: 0x060033D0 RID: 13264 RVA: 0x0001FFFA File Offset: 0x0001E1FA
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700141A RID: 5146
		' (get) Token: 0x060033D1 RID: 13265 RVA: 0x00020003 File Offset: 0x0001E203
		' (set) Token: 0x060033D2 RID: 13266 RVA: 0x002005BC File Offset: 0x001FE7BC
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700141B RID: 5147
		' (get) Token: 0x060033D3 RID: 13267 RVA: 0x0002000D File Offset: 0x0001E20D
		' (set) Token: 0x060033D4 RID: 13268 RVA: 0x00200600 File Offset: 0x001FE800
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700141C RID: 5148
		' (get) Token: 0x060033D5 RID: 13269 RVA: 0x00020017 File Offset: 0x0001E217
		' (set) Token: 0x060033D6 RID: 13270 RVA: 0x00200644 File Offset: 0x001FE844
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

		' Token: 0x1700141D RID: 5149
		' (get) Token: 0x060033D7 RID: 13271 RVA: 0x00020021 File Offset: 0x0001E221
		' (set) Token: 0x060033D8 RID: 13272 RVA: 0x00200688 File Offset: 0x001FE888
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

		' Token: 0x1700141E RID: 5150
		' (get) Token: 0x060033D9 RID: 13273 RVA: 0x0002002B File Offset: 0x0001E22B
		' (set) Token: 0x060033DA RID: 13274 RVA: 0x00020035 File Offset: 0x0001E235
		Friend Overridable Property Label1 As Label

		' Token: 0x1700141F RID: 5151
		' (get) Token: 0x060033DB RID: 13275 RVA: 0x0002003E File Offset: 0x0001E23E
		' (set) Token: 0x060033DC RID: 13276 RVA: 0x00020048 File Offset: 0x0001E248
		Friend Overridable Property txtSubcategory As TextBox

		' Token: 0x17001420 RID: 5152
		' (get) Token: 0x060033DD RID: 13277 RVA: 0x00020051 File Offset: 0x0001E251
		' (set) Token: 0x060033DE RID: 13278 RVA: 0x0002005B File Offset: 0x0001E25B
		Friend Overridable Property Label3 As Label

		' Token: 0x17001421 RID: 5153
		' (get) Token: 0x060033DF RID: 13279 RVA: 0x00020064 File Offset: 0x0001E264
		' (set) Token: 0x060033E0 RID: 13280 RVA: 0x0002006E File Offset: 0x0001E26E
		Friend Overridable Property txtFormname As TextBox

		' Token: 0x17001422 RID: 5154
		' (get) Token: 0x060033E1 RID: 13281 RVA: 0x00020077 File Offset: 0x0001E277
		' (set) Token: 0x060033E2 RID: 13282 RVA: 0x00020081 File Offset: 0x0001E281
		Friend Overridable Property Label4 As Label

		' Token: 0x17001423 RID: 5155
		' (get) Token: 0x060033E3 RID: 13283 RVA: 0x0002008A File Offset: 0x0001E28A
		' (set) Token: 0x060033E4 RID: 13284 RVA: 0x00020094 File Offset: 0x0001E294
		Friend Overridable Property cboxActive As ComboBox

		' Token: 0x17001424 RID: 5156
		' (get) Token: 0x060033E5 RID: 13285 RVA: 0x0002009D File Offset: 0x0001E29D
		' (set) Token: 0x060033E6 RID: 13286 RVA: 0x000200A7 File Offset: 0x0001E2A7
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17001425 RID: 5157
		' (get) Token: 0x060033E7 RID: 13287 RVA: 0x000200B0 File Offset: 0x0001E2B0
		' (set) Token: 0x060033E8 RID: 13288 RVA: 0x000200BA File Offset: 0x0001E2BA
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17001426 RID: 5158
		' (get) Token: 0x060033E9 RID: 13289 RVA: 0x000200C3 File Offset: 0x0001E2C3
		' (set) Token: 0x060033EA RID: 13290 RVA: 0x000200CD File Offset: 0x0001E2CD
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17001427 RID: 5159
		' (get) Token: 0x060033EB RID: 13291 RVA: 0x000200D6 File Offset: 0x0001E2D6
		' (set) Token: 0x060033EC RID: 13292 RVA: 0x000200E0 File Offset: 0x0001E2E0
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17001428 RID: 5160
		' (get) Token: 0x060033ED RID: 13293 RVA: 0x000200E9 File Offset: 0x0001E2E9
		' (set) Token: 0x060033EE RID: 13294 RVA: 0x000200F3 File Offset: 0x0001E2F3
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17001429 RID: 5161
		' (get) Token: 0x060033EF RID: 13295 RVA: 0x000200FC File Offset: 0x0001E2FC
		' (set) Token: 0x060033F0 RID: 13296 RVA: 0x002006CC File Offset: 0x001FE8CC
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

		' Token: 0x060033F1 RID: 13297 RVA: 0x00020106 File Offset: 0x0001E306
		Private Sub frmMenu_update_Load(sender As Object, e As EventArgs)
			Me.Bindgrid()
		End Sub

		' Token: 0x060033F2 RID: 13298 RVA: 0x00200710 File Offset: 0x001FE910
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

		' Token: 0x060033F3 RID: 13299 RVA: 0x00020110 File Offset: 0x0001E310
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources._12
		End Sub

		' Token: 0x060033F4 RID: 13300 RVA: 0x002007B0 File Offset: 0x001FE9B0
		Public Sub UpdateData()
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.lblId.Text)
				If flag Then
					MessageBox.Show("No ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag2 As Boolean = Me.Picture.Image Is Nothing
					If flag2 Then
						MessageBox.Show("No image selected in the PictureBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Dim memoryStream As MemoryStream = New MemoryStream()
						Me.Picture.Image.Save(memoryStream, ImageFormat.Jpeg)
						Dim array As Byte() = memoryStream.ToArray()
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim text As String = "UPDATE tbl_master_menu_header SET category_name=@d1, icon_img=@imageData, orderby=@d2, is_deleted=@d3 WHERE id=@id"
							Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@d1", Me.txtSubcategory.Text)
								sqlCommand.Parameters.AddWithValue("@imageData", array)
								sqlCommand.Parameters.AddWithValue("@id", Me.lblId.Text)
								sqlCommand.Parameters.AddWithValue("@d2", Me.txtFormname.Text)
								sqlCommand.Parameters.AddWithValue("@d3", Me.cboxActive.Text)
								Dim num As Integer = sqlCommand.ExecuteNonQuery()
								Dim flag3 As Boolean = num > 0
								If flag3 Then
									Me.Bindgrid()
									MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Else
									MessageBox.Show("No record updated. Check the ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								End If
							End Using
						End Using
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060033F5 RID: 13301 RVA: 0x002009D0 File Offset: 0x001FEBD0
		Public Sub InsertData()
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSubcategory.Text)
				If flag Then
					MessageBox.Show("Menu name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag2 As Boolean = Me.Picture.Image Is Nothing
					If flag2 Then
						MessageBox.Show("No image selected in the PictureBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Dim memoryStream As MemoryStream = New MemoryStream()
						Me.Picture.Image.Save(memoryStream, ImageFormat.Jpeg)
						Dim array As Byte() = memoryStream.ToArray()
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim text As String = "INSERT INTO tbl_master_menu_header (category_name, icon_img, orderby) VALUES (@d1, @imageData, @d2)"
							Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@d1", Me.txtSubcategory.Text)
								sqlCommand.Parameters.AddWithValue("@imageData", array)
								sqlCommand.Parameters.AddWithValue("@d2", Me.txtFormname.Text)
								Dim num As Integer = sqlCommand.ExecuteNonQuery()
								Dim flag3 As Boolean = num > 0
								If flag3 Then
									Me.Bindgrid()
									MessageBox.Show("Record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnSave.Enabled = False
								Else
									MessageBox.Show("Insertion failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End If
							End Using
						End Using
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060033F6 RID: 13302 RVA: 0x00200BC4 File Offset: 0x001FEDC4
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = e.RowIndex >= 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
					Me.lblId.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtSubcategory.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtFormname.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.cboxActive.Text = dataGridViewRow.Cells(4).Value.ToString()
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value)) AndAlso Not Information.IsNothing(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
					If flag2 Then
						Dim array As Byte() = CType(dataGridViewRow.Cells(2).Value, Byte())
						Dim memoryStream As MemoryStream = New MemoryStream(array)
						Me.Picture.Image = Image.FromStream(memoryStream)
					Else
						Me.Picture.Image = Resources._12
						Try
							Dim checked As Boolean = Me.chkAuto.Checked
							If checked Then
								Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
								openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
								openFileDialog.FilterIndex = 4
								Me.OpenFileDialog1.FileName = ""
								Dim flag3 As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
								If flag3 Then
									Me.Picture.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
								End If
							End If
						Catch ex As Exception
							Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
						End Try
					End If
				End If
				Me.btnSave.Enabled = False
				Me.btnUpdate.Enabled = True
				Me.btnDelete.Enabled = True
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message, "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060033F7 RID: 13303 RVA: 0x00020124 File Offset: 0x0001E324
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Me.UpdateData()
		End Sub

		' Token: 0x060033F8 RID: 13304 RVA: 0x00200E40 File Offset: 0x001FF040
		Public Sub Bindgrid()
			Me.DataGridView1.Rows.Clear()
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = "SELECT id, category_name, icon_img, orderby, is_deleted FROM tbl_master_menu_header ORDER BY orderby "
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Me.DataGridView1.Rows.Add(New Object() { sqlDataReader("id"), sqlDataReader("category_name"), sqlDataReader("icon_img"), sqlDataReader("orderby"), sqlDataReader("is_deleted") })
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x060033F9 RID: 13305 RVA: 0x0002012E File Offset: 0x0001E32E
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060033FA RID: 13306 RVA: 0x00200F48 File Offset: 0x001FF148
		Public Sub Reset()
			Me.lblId.Text = ""
			Me.txtSubcategory.Text = ""
			Me.txtFormname.Text = ""
			Me.cboxActive.Text = "False"
			Me.DataGridView1.Rows.Clear()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
		End Sub

		' Token: 0x060033FB RID: 13307 RVA: 0x00020138 File Offset: 0x0001E338
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.InsertData()
		End Sub

		' Token: 0x060033FC RID: 13308 RVA: 0x00020142 File Offset: 0x0001E342
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Me.DeleteData()
		End Sub

		' Token: 0x060033FD RID: 13309 RVA: 0x00200FD4 File Offset: 0x001FF1D4
		Public Sub DeleteData()
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.lblId.Text)
				If flag Then
					MessageBox.Show("No ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					Dim flag2 As Boolean = dialogResult <> DialogResult.Yes
					If Not flag2 Then
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim text As String = "DELETE FROM tbl_master_menu_header WHERE id=@id"
							Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@id", Me.lblId.Text)
								Dim num As Integer = sqlCommand.ExecuteNonQuery()
								Dim flag3 As Boolean = num > 0
								If flag3 Then
									Me.Bindgrid()
									MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.lblId.Text = ""
									Me.txtSubcategory.Text = ""
									Me.txtFormname.Text = ""
									Me.btnDelete.Enabled = False
									Me.btnSave.Enabled = False
									Me.btnUpdate.Enabled = False
								Else
									MessageBox.Show("No record deleted. Check the ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								End If
							End Using
						End Using
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060033FE RID: 13310 RVA: 0x0002014C File Offset: 0x0001E34C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmUserMenu_Control.ShowDialog()
		End Sub
	End Class
End Namespace
