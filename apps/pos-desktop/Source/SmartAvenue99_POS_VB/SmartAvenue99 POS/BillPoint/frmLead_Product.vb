Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports OpenQA.Selenium

Namespace BillPoint
	' Token: 0x020000CA RID: 202
	<DesignerGenerated()>
	Public Partial Class frmLead_Product
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060022FC RID: 8956 RVA: 0x00163CE4 File Offset: 0x00161EE4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmcategory_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCategory_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmCategory_Closing
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.password = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000DEF RID: 3567
		' (get) Token: 0x060022FF RID: 8959 RVA: 0x000181F8 File Offset: 0x000163F8
		' (set) Token: 0x06002300 RID: 8960 RVA: 0x00018202 File Offset: 0x00016402
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000DF0 RID: 3568
		' (get) Token: 0x06002301 RID: 8961 RVA: 0x0001820B File Offset: 0x0001640B
		' (set) Token: 0x06002302 RID: 8962 RVA: 0x00165590 File Offset: 0x00163790
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
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DF1 RID: 3569
		' (get) Token: 0x06002303 RID: 8963 RVA: 0x00018215 File Offset: 0x00016415
		' (set) Token: 0x06002304 RID: 8964 RVA: 0x0001821F File Offset: 0x0001641F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000DF2 RID: 3570
		' (get) Token: 0x06002305 RID: 8965 RVA: 0x00018228 File Offset: 0x00016428
		' (set) Token: 0x06002306 RID: 8966 RVA: 0x00018232 File Offset: 0x00016432
		Friend Overridable Property Label1 As Label

		' Token: 0x17000DF3 RID: 3571
		' (get) Token: 0x06002307 RID: 8967 RVA: 0x0001823B File Offset: 0x0001643B
		' (set) Token: 0x06002308 RID: 8968 RVA: 0x00018245 File Offset: 0x00016445
		Friend Overridable Property txtCategoryName As TextBox

		' Token: 0x17000DF4 RID: 3572
		' (get) Token: 0x06002309 RID: 8969 RVA: 0x0001824E File Offset: 0x0001644E
		' (set) Token: 0x0600230A RID: 8970 RVA: 0x00018258 File Offset: 0x00016458
		Friend Overridable Property lblUser As Label

		' Token: 0x17000DF5 RID: 3573
		' (get) Token: 0x0600230B RID: 8971 RVA: 0x00018261 File Offset: 0x00016461
		' (set) Token: 0x0600230C RID: 8972 RVA: 0x001655F0 File Offset: 0x001637F0
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCategory_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DF6 RID: 3574
		' (get) Token: 0x0600230D RID: 8973 RVA: 0x0001826B File Offset: 0x0001646B
		' (set) Token: 0x0600230E RID: 8974 RVA: 0x00165650 File Offset: 0x00163850
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DF7 RID: 3575
		' (get) Token: 0x0600230F RID: 8975 RVA: 0x00018275 File Offset: 0x00016475
		' (set) Token: 0x06002310 RID: 8976 RVA: 0x0001827F File Offset: 0x0001647F
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17000DF8 RID: 3576
		' (get) Token: 0x06002311 RID: 8977 RVA: 0x00018288 File Offset: 0x00016488
		' (set) Token: 0x06002312 RID: 8978 RVA: 0x00018292 File Offset: 0x00016492
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17000DF9 RID: 3577
		' (get) Token: 0x06002313 RID: 8979 RVA: 0x0001829B File Offset: 0x0001649B
		' (set) Token: 0x06002314 RID: 8980 RVA: 0x000182A5 File Offset: 0x000164A5
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000DFA RID: 3578
		' (get) Token: 0x06002315 RID: 8981 RVA: 0x000182AE File Offset: 0x000164AE
		' (set) Token: 0x06002316 RID: 8982 RVA: 0x000182B8 File Offset: 0x000164B8
		Friend Overridable Property BackgroundWorker1 As BackgroundWorker

		' Token: 0x17000DFB RID: 3579
		' (get) Token: 0x06002317 RID: 8983 RVA: 0x000182C1 File Offset: 0x000164C1
		' (set) Token: 0x06002318 RID: 8984 RVA: 0x000182CB File Offset: 0x000164CB
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000DFC RID: 3580
		' (get) Token: 0x06002319 RID: 8985 RVA: 0x000182D4 File Offset: 0x000164D4
		' (set) Token: 0x0600231A RID: 8986 RVA: 0x00165694 File Offset: 0x00163894
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

		' Token: 0x17000DFD RID: 3581
		' (get) Token: 0x0600231B RID: 8987 RVA: 0x000182DE File Offset: 0x000164DE
		' (set) Token: 0x0600231C RID: 8988 RVA: 0x001656D8 File Offset: 0x001638D8
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

		' Token: 0x17000DFE RID: 3582
		' (get) Token: 0x0600231D RID: 8989 RVA: 0x000182E8 File Offset: 0x000164E8
		' (set) Token: 0x0600231E RID: 8990 RVA: 0x0016571C File Offset: 0x0016391C
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

		' Token: 0x17000DFF RID: 3583
		' (get) Token: 0x0600231F RID: 8991 RVA: 0x000182F2 File Offset: 0x000164F2
		' (set) Token: 0x06002320 RID: 8992 RVA: 0x00165760 File Offset: 0x00163960
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

		' Token: 0x17000E00 RID: 3584
		' (get) Token: 0x06002321 RID: 8993 RVA: 0x000182FC File Offset: 0x000164FC
		' (set) Token: 0x06002322 RID: 8994 RVA: 0x00018306 File Offset: 0x00016506
		Public Overridable Property Picture As PictureBox

		' Token: 0x17000E01 RID: 3585
		' (get) Token: 0x06002323 RID: 8995 RVA: 0x0001830F File Offset: 0x0001650F
		' (set) Token: 0x06002324 RID: 8996 RVA: 0x001657A4 File Offset: 0x001639A4
		Private _BStartCapture As Button
		Friend Overridable Property BStartCapture As Button
			<CompilerGenerated()>
			Get
				Return Me._BStartCapture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BStartCapture_Click
				Dim button As Button = Me._BStartCapture
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BStartCapture = value
				button = Me._BStartCapture
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E02 RID: 3586
		' (get) Token: 0x06002325 RID: 8997 RVA: 0x00018319 File Offset: 0x00016519
		' (set) Token: 0x06002326 RID: 8998 RVA: 0x001657E8 File Offset: 0x001639E8
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

		' Token: 0x17000E03 RID: 3587
		' (get) Token: 0x06002327 RID: 8999 RVA: 0x00018323 File Offset: 0x00016523
		' (set) Token: 0x06002328 RID: 9000 RVA: 0x0016582C File Offset: 0x00163A2C
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

		' Token: 0x17000E04 RID: 3588
		' (get) Token: 0x06002329 RID: 9001 RVA: 0x0001832D File Offset: 0x0001652D
		' (set) Token: 0x0600232A RID: 9002 RVA: 0x00018337 File Offset: 0x00016537
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17000E05 RID: 3589
		' (get) Token: 0x0600232B RID: 9003 RVA: 0x00018340 File Offset: 0x00016540
		' (set) Token: 0x0600232C RID: 9004 RVA: 0x00165870 File Offset: 0x00163A70
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E06 RID: 3590
		' (get) Token: 0x0600232D RID: 9005 RVA: 0x0001834A File Offset: 0x0001654A
		' (set) Token: 0x0600232E RID: 9006 RVA: 0x00018354 File Offset: 0x00016554
		Friend Overridable Property lblSource As Label

		' Token: 0x17000E07 RID: 3591
		' (get) Token: 0x0600232F RID: 9007 RVA: 0x0001835D File Offset: 0x0001655D
		' (set) Token: 0x06002330 RID: 9008 RVA: 0x00018367 File Offset: 0x00016567
		Friend Overridable Property Label2 As Label

		' Token: 0x17000E08 RID: 3592
		' (get) Token: 0x06002331 RID: 9009 RVA: 0x00018370 File Offset: 0x00016570
		' (set) Token: 0x06002332 RID: 9010 RVA: 0x0001837A File Offset: 0x0001657A
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x17000E09 RID: 3593
		' (get) Token: 0x06002333 RID: 9011 RVA: 0x00018383 File Offset: 0x00016583
		' (set) Token: 0x06002334 RID: 9012 RVA: 0x0001838D File Offset: 0x0001658D
		Friend Overridable Property Column1 As DataGridViewImageColumn

		' Token: 0x17000E0A RID: 3594
		' (get) Token: 0x06002335 RID: 9013 RVA: 0x00018396 File Offset: 0x00016596
		' (set) Token: 0x06002336 RID: 9014 RVA: 0x000183A0 File Offset: 0x000165A0
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x06002337 RID: 9015 RVA: 0x001658B4 File Offset: 0x00163AB4
		Public Sub Reset()
			Me.cmbCategory.Text = ""
			Me.cmbCategory.SelectedIndex = -1
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.Getdata()
			Me.fillGategoryName()
			Me.cmbCategory.Focus()
		End Sub

		' Token: 0x06002338 RID: 9016 RVA: 0x00165924 File Offset: 0x00163B24
		Public Sub fillGategoryName()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(product_name) FROM tbl_lead_product", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCategory.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002339 RID: 9017 RVA: 0x00165A60 File Offset: 0x00163C60
		Private Sub DeleteRecord()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = "select a.product_name from tbl_lead_product a inner join tbl_lead_master b on a.product_name = b.productname where a.product_name=@d1"
				Me.cmd = New SqlCommand(text)
				Me.cmd.Connection = Me.con
				Me.cmd.Parameters.AddWithValue("@d1", Me.txtCategoryName.Text.TrimEnd(New Char(-1) {}))
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Lead Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
				Else
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text2 As String = "delete from tbl_lead_product where product_name=@d1"
					Me.cmd = New SqlCommand(text2)
					Me.cmd.Parameters.AddWithValue("@d1", Me.txtCategoryName.Text)
					Me.cmd.Connection = Me.con
					Dim num As Integer = Me.cmd.ExecuteNonQuery()
					Dim flag3 As Boolean = num > 0
					If flag3 Then
						Me.LogFunc(Me.lblUser.Text, "deleted the product_name '" + Me.cmbCategory.Text.TrimEnd(New Char(-1) {}) + "'")
						MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
					If flag4 Then
						Me.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600233A RID: 9018 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub LogFunc(text As String, v As String)
		End Sub

		' Token: 0x0600233B RID: 9019 RVA: 0x00165C88 File Offset: 0x00163E88
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtCategoryName.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbCategory.Text = dataGridViewRow.Cells(0).Value.ToString()
					Dim array As Byte() = CType(dataGridViewRow.Cells(1).Value, Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600233C RID: 9020 RVA: 0x00165D84 File Offset: 0x00163F84
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600233D RID: 9021 RVA: 0x00165E6C File Offset: 0x0016406C
		Public Sub Getdata()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT RTRIM(product_name), CPhoto,id from tbl_lead_product order by product_name", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While Me.rdr.Read()
					Me.dgw.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2) })
				End While
				Me.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600233E RID: 9022 RVA: 0x00165F78 File Offset: 0x00164178
		Private Sub frmcategory_Load(sender As Object, e As EventArgs)
			Me.LinkLabel1.TabStop = False
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600233F RID: 9023 RVA: 0x00166010 File Offset: 0x00164210
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						GlobalVariables.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not GlobalVariables.translations.ContainsKey(text2)
								If flag Then
									GlobalVariables.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
										End If
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06002340 RID: 9024 RVA: 0x001662B0 File Offset: 0x001644B0
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
				End If
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.UpdateAllControls(control, translations)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06002341 RID: 9025 RVA: 0x00087088 File Offset: 0x00085288
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06002342 RID: 9026 RVA: 0x00166364 File Offset: 0x00164564
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = CDbl(e.KeyCode) = Conversions.ToDouble(OpenQA.Selenium.Keys.Enter)
				If flag Then
					SendKeys.Send("{TAB}")
					e.SuppressKeyPress = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002343 RID: 9027 RVA: 0x001663C4 File Offset: 0x001645C4
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									Dim flag2 As Boolean = dataGridViewCell.ColumnIndex = 1
									If Not flag2 Then
										' The following expression was wrapped in a checked-expression
										dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
									End If
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag3 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag3 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002344 RID: 9028 RVA: 0x00166684 File Offset: 0x00164884
		Public Function DeriveKeyFromPassword(password As String, salt As Byte(), keySizeInBytes As Integer, iterations As Integer) As Byte()
			Dim bytes As Byte()
			Using rfc2898DeriveBytes As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(password, salt, iterations)
				bytes = rfc2898DeriveBytes.GetBytes(keySizeInBytes)
			End Using
			Return bytes
		End Function

		' Token: 0x06002345 RID: 9029 RVA: 0x001666C4 File Offset: 0x001648C4
		Public Function GenerateRandomSalt() As Byte()
			Dim num As Integer = 16
			Dim array As Byte() = New Byte(num - 1 + 1 - 1) {}
			Using rngcryptoServiceProvider As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
				rngcryptoServiceProvider.GetBytes(array)
			End Using
			Return array
		End Function

		' Token: 0x06002346 RID: 9030 RVA: 0x00166714 File Offset: 0x00164914
		Public Function Compress(data As Byte()) As Byte()
			Dim array As Byte()
			Using memoryStream As MemoryStream = New MemoryStream()
				Using gzipStream As GZipStream = New GZipStream(memoryStream, CompressionMode.Compress)
					gzipStream.Write(data, 0, data.Length)
				End Using
				array = memoryStream.ToArray()
			End Using
			Return array
		End Function

		' Token: 0x06002347 RID: 9031 RVA: 0x00166780 File Offset: 0x00164980
		Public Function EncryptByteArrayUsingPassword(password As String, data As Byte()) As String
			Dim array As Byte() = Me.GenerateRandomSalt()
			Dim num As Integer = 10000
			Dim num2 As Integer = 32
			Dim array2 As Byte() = Me.DeriveKeyFromPassword(password, array, num2, num)
			Dim text As String
			Using aesCryptoServiceProvider As AesCryptoServiceProvider = New AesCryptoServiceProvider()
				aesCryptoServiceProvider.Key = array2
				aesCryptoServiceProvider.GenerateIV()
				Using cryptoTransform As ICryptoTransform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV)
					Using memoryStream As MemoryStream = New MemoryStream()
						Using cryptoStream As CryptoStream = New CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write)
							cryptoStream.Write(data, 0, data.Length)
							cryptoStream.FlushFinalBlock()
						End Using
						Dim array3 As Byte() = array.Concat(aesCryptoServiceProvider.IV).Concat(memoryStream.ToArray()).ToArray()
						Dim array4 As Byte() = Me.Compress(array3)
						text = Convert.ToBase64String(array4)
					End Using
				End Using
			End Using
			Return text
		End Function

		' Token: 0x06002348 RID: 9032 RVA: 0x001668AC File Offset: 0x00164AAC
		Public Function DecryptStringToByteArrayUsingPassword(password As String, encryptedText As String) As Byte()
			Dim array As Byte() = Convert.FromBase64String(encryptedText)
			Dim num As Integer = 16
			Dim num2 As Integer = 16
			Dim num3 As Integer = 32
			Dim array2 As Byte() = array.Take(num).ToArray()
			Dim array3 As Byte() = array.Skip(num).Take(num2).ToArray()
			Dim array4 As Byte() = array.Skip(num + num2).ToArray()
			Dim array5 As Byte() = Me.DeriveKeyFromPassword(password, array2, num3, 10000)
			Dim array6 As Byte()
			Using aesCryptoServiceProvider As AesCryptoServiceProvider = New AesCryptoServiceProvider()
				aesCryptoServiceProvider.Key = array5
				aesCryptoServiceProvider.IV = array3
				Using cryptoTransform As ICryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV)
					Using memoryStream As MemoryStream = New MemoryStream(array4)
						Using cryptoStream As CryptoStream = New CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read)
							Using memoryStream2 As MemoryStream = New MemoryStream()
								cryptoStream.CopyTo(memoryStream2)
								array6 = memoryStream2.ToArray()
							End Using
						End Using
					End Using
				End Using
			End Using
			Return array6
		End Function

		' Token: 0x06002349 RID: 9033 RVA: 0x00166A00 File Offset: 0x00164C00
		Private Sub frmCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = CDbl(e.KeyCode) = Conversions.ToDouble(OpenQA.Selenium.Keys.Escape)
				If flag Then
					e.Handled = True
					Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
					If flag2 Then
						MyBase.Close()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600234A RID: 9034 RVA: 0x00166A78 File Offset: 0x00164C78
		Private Sub frmCategory_Closing(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label2.Text, "lead_product", False) = 0
			If flag Then
				MyBase.Dispose()
				MyProject.Forms.frmLead2.ShowDialog()
			End If
		End Sub

		' Token: 0x0600234B RID: 9035 RVA: 0x00166ABC File Offset: 0x00164CBC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbCategory.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCategory, String.Empty)
			End If
		End Sub

		' Token: 0x0600234C RID: 9036 RVA: 0x000183A9 File Offset: 0x000165A9
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600234D RID: 9037 RVA: 0x00166B18 File Offset: 0x00164D18
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text As String = "select * from Company"
			Me.cmd = New SqlCommand(text)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag As Boolean = Not Me.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Me.con.Close()
			Else
				Dim flag3 As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter product", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCategory.Focus()
				Else
					Try
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text2 As String = "select product_name from tbl_lead_product where product_name=@d1"
						Me.cmd = New SqlCommand(text2)
						Me.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
						Me.cmd.Connection = Me.con
						Me.rdr = Me.cmd.ExecuteReader()
						Dim flag4 As Boolean = Me.rdr.Read()
						If flag4 Then
							MessageBox.Show("Product Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.cmbCategory.Text = ""
							Me.cmbCategory.Focus()
							Dim flag5 As Boolean = Me.rdr IsNot Nothing
							If flag5 Then
								Me.rdr.Close()
							End If
							Return
						End If
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text3 As String = "insert into tbl_lead_product(product_name,CPhoto) VALUES (@d1,@d2)"
						Me.cmd = New SqlCommand(text3)
						Me.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
						Me.cmd.Connection = Me.con
						Dim memoryStream As MemoryStream = New MemoryStream()
						Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
						bitmap.Save(memoryStream, ImageFormat.Jpeg)
						Dim buffer As Byte() = memoryStream.GetBuffer()
						Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
						sqlParameter.Value = buffer
						Me.cmd.Parameters.Add(sqlParameter)
						Me.cmd.ExecuteNonQuery()
						Me.con.Close()
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnSave.Enabled = False
						Me.Getdata()
						Me.fillGategoryName()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
					MyProject.Forms.frmLead2.Label15.Text = Me.cmbCategory.Text
					Dim flag6 As Boolean = Operators.CompareString(Me.Label2.Text, "lead_product", False) = 0
					If flag6 Then
						MyBase.Dispose()
						MyProject.Forms.frmLead2.ShowDialog()
					End If
				End If
			End If
		End Sub

		' Token: 0x0600234E RID: 9038 RVA: 0x00166E9C File Offset: 0x0016509C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter product", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbCategory.Focus()
			Else
				Try
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text As String = "Update tbl_lead_product set product_name=@d1,CPhoto=@d3 where product_name=@d2"
					Me.cmd = New SqlCommand(text)
					Me.cmd.Connection = Me.con
					Me.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
					Me.cmd.Parameters.AddWithValue("@d2", Me.txtCategoryName.Text)
					Me.cmd.Connection = Me.con
					Dim memoryStream As MemoryStream = New MemoryStream()
					Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
					bitmap.Save(memoryStream, ImageFormat.Jpeg)
					Dim buffer As Byte() = memoryStream.GetBuffer()
					Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.Image)
					sqlParameter.Value = buffer
					Me.cmd.Parameters.Add(sqlParameter)
					Me.cmd.ExecuteReader()
					Me.LogFunc(Me.lblUser.Text, "updated the product '" + Me.cmbCategory.Text + "'")
					MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					Me.Getdata()
					Me.fillGategoryName()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600234F RID: 9039 RVA: 0x0016708C File Offset: 0x0016528C
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002350 RID: 9040 RVA: 0x001670F4 File Offset: 0x001652F4
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

		' Token: 0x06002351 RID: 9041 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06002352 RID: 9042 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub BStartCapture_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06002353 RID: 9043 RVA: 0x00167194 File Offset: 0x00165394
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Export File$]", oleDbConnection)
					oleDbConnection.Open()
					Me.dtable = New DataTable()
					oleDbDataAdapter.Fill(Me.dtable)
					Try
						For Each obj As Object In Me.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							SqlConnection.ClearAllPools()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text As String = "SET IDENTITY_INSERT tbl_lead_product ON; INSERT INTO tbl_lead_product(ID, product_name, CPhoto) VALUES (@d1, @d2, @d3); SET IDENTITY_INSERT tbl_lead_product OFF;"
							Me.cmd = New SqlCommand(text)
							Me.cmd.Parameters.AddWithValue("@d1", dataRow("ID").ToString().TrimEnd(New Char(-1) {}))
							Me.cmd.Parameters.AddWithValue("@d2", dataRow("product_name").ToString().TrimEnd(New Char(-1) {}))
							Me.cmd.Connection = Me.con
							Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
							Dim memoryStream As MemoryStream = New MemoryStream()
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim array As Byte() = memoryStream.ToArray()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.Image)
							sqlParameter.Value = array
							Me.cmd.Parameters.Add(sqlParameter)
							Me.cmd.ExecuteReader()
							Me.con.Close()
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Successfully imported")
					Me.Getdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message + "ONCLICK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002354 RID: 9044 RVA: 0x00167420 File Offset: 0x00165620
		Private Function BitmapToByteArray(bitmap As Bitmap) As Byte()
			Dim rectangle As Rectangle = New Rectangle(0, 0, bitmap.Width, bitmap.Height)
			Dim bitmapData As BitmapData = bitmap.LockBits(rectangle, ImageLockMode.[ReadOnly], bitmap.PixelFormat)
			Dim num As Integer = bitmapData.Stride * bitmap.Height
			Dim array As Byte() = New Byte(num - 1 + 1 - 1) {}
			Marshal.Copy(bitmapData.Scan0, array, 0, num)
			bitmap.UnlockBits(bitmapData)
			Return array
		End Function

		' Token: 0x04000E66 RID: 3686
		Private s As String

		' Token: 0x04000E67 RID: 3687
		Private Photoname As String

		' Token: 0x04000E68 RID: 3688
		Private IsImageChanged As Boolean

		' Token: 0x04000E69 RID: 3689
		Private con As SqlConnection

		' Token: 0x04000E6A RID: 3690
		Private cmd As SqlCommand

		' Token: 0x04000E6B RID: 3691
		Private rdr As SqlDataReader

		' Token: 0x04000E6C RID: 3692
		Private adp As SqlDataAdapter

		' Token: 0x04000E6D RID: 3693
		Private ds As DataSet

		' Token: 0x04000E6E RID: 3694
		Private dtable As DataTable

		' Token: 0x04000E6F RID: 3695
		Private password As String
	End Class
End Namespace
