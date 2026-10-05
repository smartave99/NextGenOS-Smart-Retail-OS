Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200012C RID: 300
	<DesignerGenerated()>
	Public Partial Class frmMenu_update
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060033FF RID: 13311 RVA: 0x0002015F File Offset: 0x0001E35F
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMenu_update_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700142A RID: 5162
		' (get) Token: 0x06003402 RID: 13314 RVA: 0x0002017F File Offset: 0x0001E37F
		' (set) Token: 0x06003403 RID: 13315 RVA: 0x00020189 File Offset: 0x0001E389
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700142B RID: 5163
		' (get) Token: 0x06003404 RID: 13316 RVA: 0x00020192 File Offset: 0x0001E392
		' (set) Token: 0x06003405 RID: 13317 RVA: 0x00202ACC File Offset: 0x00200CCC
		Private _cboxCategory As ComboBox
		Friend Overridable Property cboxCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cboxCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cboxCategory_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cboxCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cboxCategory = value
				comboBox = Me._cboxCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700142C RID: 5164
		' (get) Token: 0x06003406 RID: 13318 RVA: 0x0002019C File Offset: 0x0001E39C
		' (set) Token: 0x06003407 RID: 13319 RVA: 0x000201A6 File Offset: 0x0001E3A6
		Friend Overridable Property Label2 As Label

		' Token: 0x1700142D RID: 5165
		' (get) Token: 0x06003408 RID: 13320 RVA: 0x000201AF File Offset: 0x0001E3AF
		' (set) Token: 0x06003409 RID: 13321 RVA: 0x000201B9 File Offset: 0x0001E3B9
		Friend Overridable Property lblSubcategory As Label

		' Token: 0x1700142E RID: 5166
		' (get) Token: 0x0600340A RID: 13322 RVA: 0x000201C2 File Offset: 0x0001E3C2
		' (set) Token: 0x0600340B RID: 13323 RVA: 0x000201CC File Offset: 0x0001E3CC
		Friend Overridable Property lblId As Label

		' Token: 0x1700142F RID: 5167
		' (get) Token: 0x0600340C RID: 13324 RVA: 0x000201D5 File Offset: 0x0001E3D5
		' (set) Token: 0x0600340D RID: 13325 RVA: 0x00202B10 File Offset: 0x00200D10
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

		' Token: 0x17001430 RID: 5168
		' (get) Token: 0x0600340E RID: 13326 RVA: 0x000201DF File Offset: 0x0001E3DF
		' (set) Token: 0x0600340F RID: 13327 RVA: 0x000201E9 File Offset: 0x0001E3E9
		Public Overridable Property Picture As PictureBox

		' Token: 0x17001431 RID: 5169
		' (get) Token: 0x06003410 RID: 13328 RVA: 0x000201F2 File Offset: 0x0001E3F2
		' (set) Token: 0x06003411 RID: 13329 RVA: 0x00202B54 File Offset: 0x00200D54
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

		' Token: 0x17001432 RID: 5170
		' (get) Token: 0x06003412 RID: 13330 RVA: 0x000201FC File Offset: 0x0001E3FC
		' (set) Token: 0x06003413 RID: 13331 RVA: 0x00202B98 File Offset: 0x00200D98
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

		' Token: 0x17001433 RID: 5171
		' (get) Token: 0x06003414 RID: 13332 RVA: 0x00020206 File Offset: 0x0001E406
		' (set) Token: 0x06003415 RID: 13333 RVA: 0x00020210 File Offset: 0x0001E410
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17001434 RID: 5172
		' (get) Token: 0x06003416 RID: 13334 RVA: 0x00020219 File Offset: 0x0001E419
		' (set) Token: 0x06003417 RID: 13335 RVA: 0x00020223 File Offset: 0x0001E423
		Friend Overridable Property chkAuto As CheckBox

		' Token: 0x17001435 RID: 5173
		' (get) Token: 0x06003418 RID: 13336 RVA: 0x0002022C File Offset: 0x0001E42C
		' (set) Token: 0x06003419 RID: 13337 RVA: 0x00020236 File Offset: 0x0001E436
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17001436 RID: 5174
		' (get) Token: 0x0600341A RID: 13338 RVA: 0x0002023F File Offset: 0x0001E43F
		' (set) Token: 0x0600341B RID: 13339 RVA: 0x00202BDC File Offset: 0x00200DDC
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

		' Token: 0x17001437 RID: 5175
		' (get) Token: 0x0600341C RID: 13340 RVA: 0x00020249 File Offset: 0x0001E449
		' (set) Token: 0x0600341D RID: 13341 RVA: 0x00202C20 File Offset: 0x00200E20
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

		' Token: 0x17001438 RID: 5176
		' (get) Token: 0x0600341E RID: 13342 RVA: 0x00020253 File Offset: 0x0001E453
		' (set) Token: 0x0600341F RID: 13343 RVA: 0x00202C64 File Offset: 0x00200E64
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

		' Token: 0x17001439 RID: 5177
		' (get) Token: 0x06003420 RID: 13344 RVA: 0x0002025D File Offset: 0x0001E45D
		' (set) Token: 0x06003421 RID: 13345 RVA: 0x00202CA8 File Offset: 0x00200EA8
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

		' Token: 0x1700143A RID: 5178
		' (get) Token: 0x06003422 RID: 13346 RVA: 0x00020267 File Offset: 0x0001E467
		' (set) Token: 0x06003423 RID: 13347 RVA: 0x00020271 File Offset: 0x0001E471
		Friend Overridable Property Label1 As Label

		' Token: 0x1700143B RID: 5179
		' (get) Token: 0x06003424 RID: 13348 RVA: 0x0002027A File Offset: 0x0001E47A
		' (set) Token: 0x06003425 RID: 13349 RVA: 0x00020284 File Offset: 0x0001E484
		Friend Overridable Property txtSubcategory As TextBox

		' Token: 0x1700143C RID: 5180
		' (get) Token: 0x06003426 RID: 13350 RVA: 0x0002028D File Offset: 0x0001E48D
		' (set) Token: 0x06003427 RID: 13351 RVA: 0x00020297 File Offset: 0x0001E497
		Friend Overridable Property Label3 As Label

		' Token: 0x1700143D RID: 5181
		' (get) Token: 0x06003428 RID: 13352 RVA: 0x000202A0 File Offset: 0x0001E4A0
		' (set) Token: 0x06003429 RID: 13353 RVA: 0x000202AA File Offset: 0x0001E4AA
		Friend Overridable Property txtFormname As TextBox

		' Token: 0x1700143E RID: 5182
		' (get) Token: 0x0600342A RID: 13354 RVA: 0x000202B3 File Offset: 0x0001E4B3
		' (set) Token: 0x0600342B RID: 13355 RVA: 0x000202BD File Offset: 0x0001E4BD
		Friend Overridable Property lblStatus As Label

		' Token: 0x1700143F RID: 5183
		' (get) Token: 0x0600342C RID: 13356 RVA: 0x000202C6 File Offset: 0x0001E4C6
		' (set) Token: 0x0600342D RID: 13357 RVA: 0x000202D0 File Offset: 0x0001E4D0
		Friend Overridable Property Label4 As Label

		' Token: 0x17001440 RID: 5184
		' (get) Token: 0x0600342E RID: 13358 RVA: 0x000202D9 File Offset: 0x0001E4D9
		' (set) Token: 0x0600342F RID: 13359 RVA: 0x000202E3 File Offset: 0x0001E4E3
		Friend Overridable Property cboxActive As ComboBox

		' Token: 0x17001441 RID: 5185
		' (get) Token: 0x06003430 RID: 13360 RVA: 0x000202EC File Offset: 0x0001E4EC
		' (set) Token: 0x06003431 RID: 13361 RVA: 0x000202F6 File Offset: 0x0001E4F6
		Friend Overridable Property Label5 As Label

		' Token: 0x17001442 RID: 5186
		' (get) Token: 0x06003432 RID: 13362 RVA: 0x000202FF File Offset: 0x0001E4FF
		' (set) Token: 0x06003433 RID: 13363 RVA: 0x00020309 File Offset: 0x0001E509
		Friend Overridable Property txtstatusvisible As TextBox

		' Token: 0x17001443 RID: 5187
		' (get) Token: 0x06003434 RID: 13364 RVA: 0x00020312 File Offset: 0x0001E512
		' (set) Token: 0x06003435 RID: 13365 RVA: 0x0002031C File Offset: 0x0001E51C
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17001444 RID: 5188
		' (get) Token: 0x06003436 RID: 13366 RVA: 0x00020325 File Offset: 0x0001E525
		' (set) Token: 0x06003437 RID: 13367 RVA: 0x0002032F File Offset: 0x0001E52F
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17001445 RID: 5189
		' (get) Token: 0x06003438 RID: 13368 RVA: 0x00020338 File Offset: 0x0001E538
		' (set) Token: 0x06003439 RID: 13369 RVA: 0x00020342 File Offset: 0x0001E542
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17001446 RID: 5190
		' (get) Token: 0x0600343A RID: 13370 RVA: 0x0002034B File Offset: 0x0001E54B
		' (set) Token: 0x0600343B RID: 13371 RVA: 0x00020355 File Offset: 0x0001E555
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17001447 RID: 5191
		' (get) Token: 0x0600343C RID: 13372 RVA: 0x0002035E File Offset: 0x0001E55E
		' (set) Token: 0x0600343D RID: 13373 RVA: 0x00020368 File Offset: 0x0001E568
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17001448 RID: 5192
		' (get) Token: 0x0600343E RID: 13374 RVA: 0x00020371 File Offset: 0x0001E571
		' (set) Token: 0x0600343F RID: 13375 RVA: 0x0002037B File Offset: 0x0001E57B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17001449 RID: 5193
		' (get) Token: 0x06003440 RID: 13376 RVA: 0x00020384 File Offset: 0x0001E584
		' (set) Token: 0x06003441 RID: 13377 RVA: 0x0002038E File Offset: 0x0001E58E
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x06003442 RID: 13378 RVA: 0x00020397 File Offset: 0x0001E597
		Private Sub frmMenu_update_Load(sender As Object, e As EventArgs)
			Me.BindMenuCatgory()
		End Sub

		' Token: 0x06003443 RID: 13379 RVA: 0x00202CEC File Offset: 0x00200EEC
		Public Sub BindMenuCatgory()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "SELECT id, category_name FROM tbl_master_menu_header ORDER BY orderby"
			Dim sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
			Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
			Me.cboxCategory.Items.Clear()
			While sqlDataReader.Read()
				Me.cboxCategory.Items.Add(New KeyValuePair(Of Integer, String)(Conversions.ToInteger(sqlDataReader("id")), sqlDataReader("category_name").ToString()))
			End While
			sqlDataReader.Close()
			sqlConnection.Close()
			Me.cboxCategory.DisplayMember = "Value"
			Me.cboxCategory.ValueMember = "Key"
		End Sub

		' Token: 0x06003444 RID: 13380 RVA: 0x00202DAC File Offset: 0x00200FAC
		Private Sub cboxCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.cboxCategory.SelectedItem Is Nothing
				If Not flag Then
					Dim selectedItem As Object = Me.cboxCategory.SelectedItem
					Dim value As String = If((selectedItem IsNot Nothing), CType(selectedItem, KeyValuePair(Of Integer, String)), Nothing).Value
					Me.Bindgrid(value)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003445 RID: 13381 RVA: 0x00202E44 File Offset: 0x00201044
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

		' Token: 0x06003446 RID: 13382 RVA: 0x000203A1 File Offset: 0x0001E5A1
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources._12
		End Sub

		' Token: 0x06003447 RID: 13383 RVA: 0x00202EE4 File Offset: 0x002010E4
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
							Dim text As String = "UPDATE tbl_master_menu SET sub_category_name=@d1, icon_img=@imageData, form_name=@d2, is_deleted=@d3, visual_status=@d4 WHERE id=@id"
							Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@d1", Me.txtSubcategory.Text)
								sqlCommand.Parameters.AddWithValue("@imageData", array)
								sqlCommand.Parameters.AddWithValue("@id", Me.lblId.Text)
								sqlCommand.Parameters.AddWithValue("@d2", Me.txtFormname.Text)
								sqlCommand.Parameters.AddWithValue("@d3", Me.cboxActive.Text)
								sqlCommand.Parameters.AddWithValue("@d4", Me.txtstatusvisible.Text)
								Dim num As Integer = sqlCommand.ExecuteNonQuery()
								Dim flag3 As Boolean = num > 0
								If flag3 Then
									Dim flag4 As Boolean = Me.cboxCategory.SelectedItem Is Nothing
									If Not flag4 Then
										Dim selectedItem As Object = Me.cboxCategory.SelectedItem
										Dim value As String = If((selectedItem IsNot Nothing), CType(selectedItem, KeyValuePair(Of Integer, String)), Nothing).Value
										Me.Bindgrid(value)
										MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									End If
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

		' Token: 0x06003448 RID: 13384 RVA: 0x00203168 File Offset: 0x00201368
		Public Sub InsertData()
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSubcategory.Text)
				If flag Then
					MessageBox.Show("Subcategory name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag2 As Boolean = Me.cboxCategory.SelectedItem Is Nothing
					If flag2 Then
						MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Dim flag3 As Boolean = Me.Picture.Image Is Nothing
						If flag3 Then
							MessageBox.Show("No image selected in the PictureBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Else
							Dim memoryStream As MemoryStream = New MemoryStream()
							Me.Picture.Image.Save(memoryStream, ImageFormat.Jpeg)
							Dim array As Byte() = memoryStream.ToArray()
							Dim selectedItem As Object = Me.cboxCategory.SelectedItem
							Dim value As String = If((selectedItem IsNot Nothing), CType(selectedItem, KeyValuePair(Of Integer, String)), Nothing).Value
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection.Open()
								Dim text As String = "INSERT INTO tbl_master_menu (category_name, sub_category_name, icon_img, form_name,visual_status) VALUES (@category_name, @d1, @imageData, @d2, @d3)"
								Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
									sqlCommand.Parameters.AddWithValue("@category_name", value)
									sqlCommand.Parameters.AddWithValue("@d1", Me.txtSubcategory.Text)
									sqlCommand.Parameters.AddWithValue("@imageData", array)
									sqlCommand.Parameters.AddWithValue("@d2", Me.txtFormname.Text)
									sqlCommand.Parameters.AddWithValue("@d3", Me.txtstatusvisible.Text)
									Dim num As Integer = sqlCommand.ExecuteNonQuery()
									Dim flag4 As Boolean = num > 0
									If flag4 Then
										Me.Bindgrid(value.ToString())
										MessageBox.Show("Record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.btnSave.Enabled = False
										Me.Reset()
									Else
										MessageBox.Show("Insertion failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End If
								End Using
							End Using
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003449 RID: 13385 RVA: 0x002033F0 File Offset: 0x002015F0
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = e.RowIndex >= 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
					Me.lblId.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cboxCategory.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtSubcategory.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtFormname.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.cboxActive.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtstatusvisible.Text = dataGridViewRow.Cells(6).Value.ToString()
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)) AndAlso Not Information.IsNothing(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
					If flag2 Then
						Dim array As Byte() = CType(dataGridViewRow.Cells(3).Value, Byte())
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

		' Token: 0x0600344A RID: 13386 RVA: 0x000203B5 File Offset: 0x0001E5B5
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Me.UpdateData()
		End Sub

		' Token: 0x0600344B RID: 13387 RVA: 0x002036B0 File Offset: 0x002018B0
		Public Sub Bindgrid(selectedCategoryName As String)
			Me.DataGridView1.Rows.Clear()
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = "SELECT id, category_name, sub_category_name, icon_img, form_name, is_deleted, visual_status FROM tbl_master_menu WHERE category_name = @categoryID ORDER BY id"
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@categoryID", selectedCategoryName)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Me.DataGridView1.Rows.Add(New Object() { sqlDataReader("id"), sqlDataReader("category_name"), sqlDataReader("sub_category_name"), sqlDataReader("icon_img"), sqlDataReader("form_name"), sqlDataReader("is_deleted"), sqlDataReader("visual_status") })
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x0600344C RID: 13388 RVA: 0x000203BF File Offset: 0x0001E5BF
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600344D RID: 13389 RVA: 0x002037E8 File Offset: 0x002019E8
		Public Sub Reset()
			Me.lblId.Text = ""
			Me.txtSubcategory.Text = ""
			Me.txtFormname.Text = ""
			Me.cboxCategory.Text = ""
			Me.cboxActive.Text = "False"
			Me.txtstatusvisible.Text = ""
			Me.DataGridView1.Rows.Clear()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
		End Sub

		' Token: 0x0600344E RID: 13390 RVA: 0x000203C9 File Offset: 0x0001E5C9
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.InsertData()
		End Sub

		' Token: 0x0600344F RID: 13391 RVA: 0x000203D3 File Offset: 0x0001E5D3
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Me.DeleteData()
		End Sub

		' Token: 0x06003450 RID: 13392 RVA: 0x00203894 File Offset: 0x00201A94
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
							Dim text As String = "DELETE FROM tbl_master_menu WHERE id=@id"
							Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
								sqlCommand.Parameters.AddWithValue("@id", Me.lblId.Text)
								Dim num As Integer = sqlCommand.ExecuteNonQuery()
								Dim flag3 As Boolean = num > 0
								If flag3 Then
									Dim flag4 As Boolean = Me.cboxCategory.SelectedItem Is Nothing
									If Not flag4 Then
										Dim selectedItem As Object = Me.cboxCategory.SelectedItem
										Dim value As String = If((selectedItem IsNot Nothing), CType(selectedItem, KeyValuePair(Of Integer, String)), Nothing).Value
										Me.Bindgrid(value.ToString())
										MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.lblId.Text = ""
										Me.txtSubcategory.Text = ""
										Me.txtFormname.Text = ""
										Me.btnDelete.Enabled = False
										Me.btnSave.Enabled = False
										Me.btnUpdate.Enabled = False
									End If
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
	End Class
End Namespace
