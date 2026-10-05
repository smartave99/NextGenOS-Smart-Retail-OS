Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020001DD RID: 477
	<DesignerGenerated()>
	Public Partial Class frmProductRec_serial_sale
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007FCA RID: 32714 RVA: 0x005EBCB4 File Offset: 0x005E9EB4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductRec_variant_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductRec_variant_KeyDown
			Me.dt = New DataTable()
			Me.currentRowIndex = 0
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002EF5 RID: 12021
		' (get) Token: 0x06007FCD RID: 32717 RVA: 0x0003ED6B File Offset: 0x0003CF6B
		' (set) Token: 0x06007FCE RID: 32718 RVA: 0x0003ED75 File Offset: 0x0003CF75
		Friend Overridable Property txtBar As TextBox

		' Token: 0x17002EF6 RID: 12022
		' (get) Token: 0x06007FCF RID: 32719 RVA: 0x0003ED7E File Offset: 0x0003CF7E
		' (set) Token: 0x06007FD0 RID: 32720 RVA: 0x0003ED88 File Offset: 0x0003CF88
		Friend Overridable Property txtBarcodeTempStock As TextBox

		' Token: 0x17002EF7 RID: 12023
		' (get) Token: 0x06007FD1 RID: 32721 RVA: 0x0003ED91 File Offset: 0x0003CF91
		' (set) Token: 0x06007FD2 RID: 32722 RVA: 0x0003ED9B File Offset: 0x0003CF9B
		Friend Overridable Property txtID As TextBox

		' Token: 0x17002EF8 RID: 12024
		' (get) Token: 0x06007FD3 RID: 32723 RVA: 0x0003EDA4 File Offset: 0x0003CFA4
		' (set) Token: 0x06007FD4 RID: 32724 RVA: 0x0003EDAE File Offset: 0x0003CFAE
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17002EF9 RID: 12025
		' (get) Token: 0x06007FD5 RID: 32725 RVA: 0x0003EDB7 File Offset: 0x0003CFB7
		' (set) Token: 0x06007FD6 RID: 32726 RVA: 0x0003EDC1 File Offset: 0x0003CFC1
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x17002EFA RID: 12026
		' (get) Token: 0x06007FD7 RID: 32727 RVA: 0x0003EDCA File Offset: 0x0003CFCA
		' (set) Token: 0x06007FD8 RID: 32728 RVA: 0x0003EDD4 File Offset: 0x0003CFD4
		Friend Overridable Property txtNP As TextBox

		' Token: 0x17002EFB RID: 12027
		' (get) Token: 0x06007FD9 RID: 32729 RVA: 0x0003EDDD File Offset: 0x0003CFDD
		' (set) Token: 0x06007FDA RID: 32730 RVA: 0x0003EDE7 File Offset: 0x0003CFE7
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17002EFC RID: 12028
		' (get) Token: 0x06007FDB RID: 32731 RVA: 0x0003EDF0 File Offset: 0x0003CFF0
		' (set) Token: 0x06007FDC RID: 32732 RVA: 0x0003EDFA File Offset: 0x0003CFFA
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17002EFD RID: 12029
		' (get) Token: 0x06007FDD RID: 32733 RVA: 0x0003EE03 File Offset: 0x0003D003
		' (set) Token: 0x06007FDE RID: 32734 RVA: 0x005ED29C File Offset: 0x005EB49C
		Private _GelButtonNewRecord As GelButton
		Friend Overridable Property GelButtonNewRecord As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButtonNewRecord
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim gelButton As GelButton = Me._GelButtonNewRecord
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButtonNewRecord = value
				gelButton = Me._GelButtonNewRecord
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002EFE RID: 12030
		' (get) Token: 0x06007FDF RID: 32735 RVA: 0x0003EE0D File Offset: 0x0003D00D
		' (set) Token: 0x06007FE0 RID: 32736 RVA: 0x005ED2E0 File Offset: 0x005EB4E0
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

		' Token: 0x17002EFF RID: 12031
		' (get) Token: 0x06007FE1 RID: 32737 RVA: 0x0003EE17 File Offset: 0x0003D017
		' (set) Token: 0x06007FE2 RID: 32738 RVA: 0x005ED324 File Offset: 0x005EB524
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.DataGridView2_EditingControlShowing
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellContentClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView2_KeyDown
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellEndEdit
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellEndEdit, dataGridViewCellEventHandler2
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellEndEdit, dataGridViewCellEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002F00 RID: 12032
		' (get) Token: 0x06007FE3 RID: 32739 RVA: 0x0003EE21 File Offset: 0x0003D021
		' (set) Token: 0x06007FE4 RID: 32740 RVA: 0x0003EE2B File Offset: 0x0003D02B
		Friend Overridable Property Label14 As Label

		' Token: 0x17002F01 RID: 12033
		' (get) Token: 0x06007FE5 RID: 32741 RVA: 0x0003EE34 File Offset: 0x0003D034
		' (set) Token: 0x06007FE6 RID: 32742 RVA: 0x0003EE3E File Offset: 0x0003D03E
		Friend Overridable Property Label13 As Label

		' Token: 0x17002F02 RID: 12034
		' (get) Token: 0x06007FE7 RID: 32743 RVA: 0x0003EE47 File Offset: 0x0003D047
		' (set) Token: 0x06007FE8 RID: 32744 RVA: 0x0003EE51 File Offset: 0x0003D051
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x17002F03 RID: 12035
		' (get) Token: 0x06007FE9 RID: 32745 RVA: 0x0003EE5A File Offset: 0x0003D05A
		' (set) Token: 0x06007FEA RID: 32746 RVA: 0x0003EE64 File Offset: 0x0003D064
		Friend Overridable Property Label2 As Label

		' Token: 0x17002F04 RID: 12036
		' (get) Token: 0x06007FEB RID: 32747 RVA: 0x0003EE6D File Offset: 0x0003D06D
		' (set) Token: 0x06007FEC RID: 32748 RVA: 0x0003EE77 File Offset: 0x0003D077
		Friend Overridable Property Label1 As Label

		' Token: 0x17002F05 RID: 12037
		' (get) Token: 0x06007FED RID: 32749 RVA: 0x0003EE80 File Offset: 0x0003D080
		' (set) Token: 0x06007FEE RID: 32750 RVA: 0x005ED3C4 File Offset: 0x005EB5C4
		Private _txtSerialno2 As TextBox
		Friend Overridable Property txtSerialno2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSerialno2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSerialno2_KeyDown
				Dim textBox As TextBox = Me._txtSerialno2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSerialno2 = value
				textBox = Me._txtSerialno2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002F06 RID: 12038
		' (get) Token: 0x06007FEF RID: 32751 RVA: 0x0003EE8A File Offset: 0x0003D08A
		' (set) Token: 0x06007FF0 RID: 32752 RVA: 0x005ED408 File Offset: 0x005EB608
		Private _btnUpdate As Button
		Friend Overridable Property btnUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim button As Button = Me._btnUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUpdate = value
				button = Me._btnUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002F07 RID: 12039
		' (get) Token: 0x06007FF1 RID: 32753 RVA: 0x0003EE94 File Offset: 0x0003D094
		' (set) Token: 0x06007FF2 RID: 32754 RVA: 0x005ED44C File Offset: 0x005EB64C
		Private _txtSerialno1 As TextBox
		Friend Overridable Property txtSerialno1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSerialno1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSerialno1_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtSerialno1_Leave
				Dim textBox As TextBox = Me._txtSerialno1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Leave, eventHandler
				End If
				Me._txtSerialno1 = value
				textBox = Me._txtSerialno1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Leave, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002F08 RID: 12040
		' (get) Token: 0x06007FF3 RID: 32755 RVA: 0x0003EE9E File Offset: 0x0003D09E
		' (set) Token: 0x06007FF4 RID: 32756 RVA: 0x0003EEA8 File Offset: 0x0003D0A8
		Friend Overridable Property chkScanner As CheckBox

		' Token: 0x17002F09 RID: 12041
		' (get) Token: 0x06007FF5 RID: 32757 RVA: 0x0003EEB1 File Offset: 0x0003D0B1
		' (set) Token: 0x06007FF6 RID: 32758 RVA: 0x0003EEBB File Offset: 0x0003D0BB
		Friend Overridable Property lblUser As Label

		' Token: 0x17002F0A RID: 12042
		' (get) Token: 0x06007FF7 RID: 32759 RVA: 0x0003EEC4 File Offset: 0x0003D0C4
		' (set) Token: 0x06007FF8 RID: 32760 RVA: 0x0003EECE File Offset: 0x0003D0CE
		Friend Overridable Property lblInvoiceno As Label

		' Token: 0x17002F0B RID: 12043
		' (get) Token: 0x06007FF9 RID: 32761 RVA: 0x0003EED7 File Offset: 0x0003D0D7
		' (set) Token: 0x06007FFA RID: 32762 RVA: 0x005ED4AC File Offset: 0x005EB6AC
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

		' Token: 0x17002F0C RID: 12044
		' (get) Token: 0x06007FFB RID: 32763 RVA: 0x0003EEE1 File Offset: 0x0003D0E1
		' (set) Token: 0x06007FFC RID: 32764 RVA: 0x0003EEEB File Offset: 0x0003D0EB
		Friend Overridable Property lblstatus As Label

		' Token: 0x17002F0D RID: 12045
		' (get) Token: 0x06007FFD RID: 32765 RVA: 0x0003EEF4 File Offset: 0x0003D0F4
		' (set) Token: 0x06007FFE RID: 32766 RVA: 0x0003EEFE File Offset: 0x0003D0FE
		Friend Overridable Property PID As DataGridViewTextBoxColumn

		' Token: 0x17002F0E RID: 12046
		' (get) Token: 0x06007FFF RID: 32767 RVA: 0x0003EF07 File Offset: 0x0003D107
		' (set) Token: 0x06008000 RID: 32768 RVA: 0x0003EF11 File Offset: 0x0003D111
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17002F0F RID: 12047
		' (get) Token: 0x06008001 RID: 32769 RVA: 0x0003EF1A File Offset: 0x0003D11A
		' (set) Token: 0x06008002 RID: 32770 RVA: 0x0003EF24 File Offset: 0x0003D124
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17002F10 RID: 12048
		' (get) Token: 0x06008003 RID: 32771 RVA: 0x0003EF2D File Offset: 0x0003D12D
		' (set) Token: 0x06008004 RID: 32772 RVA: 0x0003EF37 File Offset: 0x0003D137
		Friend Overridable Property TempBarcode As DataGridViewTextBoxColumn

		' Token: 0x17002F11 RID: 12049
		' (get) Token: 0x06008005 RID: 32773 RVA: 0x0003EF40 File Offset: 0x0003D140
		' (set) Token: 0x06008006 RID: 32774 RVA: 0x0003EF4A File Offset: 0x0003D14A
		Friend Overridable Property Serial_no As DataGridViewTextBoxColumn

		' Token: 0x1400002D RID: 45
		' (add) Token: 0x06008007 RID: 32775 RVA: 0x005ED4F0 File Offset: 0x005EB6F0
		' (remove) Token: 0x06008008 RID: 32776 RVA: 0x005ED528 File Offset: 0x005EB728
		Public Event frmProductRec_variantClosed As frmProductRec_serial_sale.frmProductRec_variantClosedEventHandler

		' Token: 0x06008009 RID: 32777 RVA: 0x005ED560 File Offset: 0x005EB760
		Private Sub frmProductRec_variant_Load(sender As Object, e As EventArgs)
			Me.GenerateBarcode()
			Dim flag As Boolean = Operators.CompareString(Me.lblstatus.Text, "edit", False) = 0
			If flag Then
				Me.GetProduct_Serial(Me.Label14.Text, Me.lblInvoiceno.Text)
			Else
				Me.GetProduct_Serial(Me.Label14.Text, Me.lblInvoiceno.Text)
			End If
			Me.currentRowIndex = 0
			Me.strStatus = "new"
			Me.chkScanner.Checked = True
			Me.txtSerialno1.Focus()
		End Sub

		' Token: 0x0600800A RID: 32778 RVA: 0x005ED5FC File Offset: 0x005EB7FC
		Public Sub copy_data_to_product_serial(InvoiceNo As String, SysUser As String)
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			Dim dataTable As DataTable = New DataTable()
			Try
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM tbl_product_serial_final " & vbCrLf & "                                     where invoice_no = @d2 " & vbCrLf & "                                     AND sys_user = @sysUser", sqlConnection)
				sqlCommand.Parameters.Add("@d2", SqlDbType.VarChar).Value = InvoiceNo
				sqlCommand.Parameters.Add("@sysUser", SqlDbType.VarChar).Value = SysUser
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
				sqlDataAdapter.Fill(dataTable)
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Try
						For Each obj As Object In dataTable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Dim sqlCommand2 As SqlCommand = New SqlCommand("INSERT INTO tbl_product_serial (productid, barcode, serialno1, serialno2, status, sys_user, invoice_no)" & vbCrLf & "                                             VALUES (@productid, @barcode, @serialno1, @serialno2, @status, @sysUser, @invoice_no)", sqlConnection)
							sqlCommand2.Parameters.Add("@productid", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("productid"))
							sqlCommand2.Parameters.Add("@barcode", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("barcode"))
							sqlCommand2.Parameters.Add("@serialno1", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("serialno1"))
							sqlCommand2.Parameters.Add("@serialno2", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("serialno2"))
							sqlCommand2.Parameters.Add("@status", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("status"))
							sqlCommand2.Parameters.Add("@sysUser", SqlDbType.VarChar).Value = SysUser
							sqlCommand2.Parameters.Add("@invoice_no", SqlDbType.VarChar).Value = InvoiceNo
							sqlCommand2.ExecuteNonQuery()
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			Finally
				Dim flag2 As Boolean = sqlConnection.State = ConnectionState.Open
				If flag2 Then
					sqlConnection.Close()
				End If
			End Try
		End Sub

		' Token: 0x0600800B RID: 32779 RVA: 0x005ED880 File Offset: 0x005EBA80
		Public Sub Clear_SerialData()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			Dim sqlCommand As SqlCommand = Nothing
			Try
				sqlConnection.Open()
				Dim text As String = "DELETE FROM tbl_product_serial"
				sqlCommand = New SqlCommand(text, sqlConnection)
				Dim num As Integer = sqlCommand.ExecuteNonQuery()
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag As Boolean = sqlCommand IsNot Nothing
				If flag Then
					sqlCommand.Dispose()
				End If
				Dim flag2 As Boolean = sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open
				If flag2 Then
					sqlConnection.Close()
					sqlConnection.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600800C RID: 32780 RVA: 0x005C56AC File Offset: 0x005C38AC
		Private Sub BarcodeRemoveAll()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from GenerateBarcode"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600800D RID: 32781 RVA: 0x005ED944 File Offset: 0x005EBB44
		Private Sub DataforNP()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Product", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Product")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Product").Rows(Conversions.ToInteger(Me.CurrentRow))("PID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600800E RID: 32782 RVA: 0x0020DD08 File Offset: 0x0020BF08
		Private Function GenerateID1() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Product_OpeningStock ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600800F RID: 32783 RVA: 0x005EDA30 File Offset: 0x005EBC30
		Public Sub GenerateBarcode()
			Try
				Me.BCodeDisplay()
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008010 RID: 32784 RVA: 0x005EDAB4 File Offset: 0x005EBCB4
		Public Sub BCodeDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(BCode) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtBar.Text = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.txtBar.Text = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008011 RID: 32785 RVA: 0x005EDB9C File Offset: 0x005EBD9C
		Private Function printCustomBarcode(barcode As String) As DataSet
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlCommand As SqlCommand = New SqlCommand()
			Dim sqlCommand2 As SqlCommand = New SqlCommand()
			Dim dataSet As DataSet = New DataSet()
			Dim dataSet2 As DataSet = New DataSet()
			Try
				Dim text As String = "Select ProductCode,ProductName,(Category),Temp_Stock.Barcode,Temp_Stock.Qty,(PartNo),(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),(Product.CGST),(Product.SGST),QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes'  and Temp_Stock.barcode in(" + barcode + ")"
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = ModCommonClasses.con
				sqlCommand.CommandText = text
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				ModCommonClasses.con.Open()
				sqlDataAdapter.Fill(dataSet, "DataTable2")
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return dataSet
		End Function

		' Token: 0x06008012 RID: 32786 RVA: 0x005EDC84 File Offset: 0x005EBE84
		Public Sub fillProductID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(PID) FROM Product order by PID ASC", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06008013 RID: 32787 RVA: 0x005EDDB8 File Offset: 0x005EBFB8
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06008014 RID: 32788 RVA: 0x005EDE3C File Offset: 0x005EC03C
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008015 RID: 32789 RVA: 0x0011427C File Offset: 0x0011247C
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06008016 RID: 32790 RVA: 0x005EDEB0 File Offset: 0x005EC0B0
		Public Sub gridCOlumDefine()
			Me.DataGridView2.Columns.Add("PID", "PID")
			Me.DataGridView2.Columns.Add("ProductCode", "ProductCode")
			Me.DataGridView2.Columns.Add("Productname", "Productname")
			Me.DataGridView2.Columns.Add("TempBarcode", "TempBarcode")
			Me.DataGridView2.Columns.Add("Serial_no", "Serial_no")
			Me.DataGridView2.Columns.Add("Serial_no2", "Serial_no2")
		End Sub

		' Token: 0x06008017 RID: 32791 RVA: 0x005EDF60 File Offset: 0x005EC160
		Public Sub GetProduct_Serial_final(ProductId As String, InvoiceNo As String)
			Try
				Me.Cursor = Cursors.WaitCursor
				Dim dataTable As DataTable = New DataTable()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT a.productid AS PID, RTRIM(b.ProductCode) AS ProductCode, RTRIM(b.ProductName) AS ProductName, " & vbCrLf & "                                     a.barcode AS TempBarcode, a.serialno1 AS Serial_no, a.serialno2 AS Serial_no2" & vbCrLf & "                              FROM tbl_product_serial_final a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid  " & vbCrLf & "                              WHERE a.productid = @d1 AND a.invoice_no = @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.VarChar).Value = ProductId
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.VarChar).Value = InvoiceNo
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				sqlDataAdapter.Fill(dataTable)
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Me.DataGridView2.DataSource = Nothing
					Me.DataGridView2.Rows.Clear()
					Me.DataGridView2.DataSource = dataTable
				Else
					Me.Getdata_variant(Conversions.ToShort(Me.Label14.Text), Me.strBarcode)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = ModCommonClasses.con IsNot Nothing AndAlso ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
				Me.Cursor = Cursors.[Default]
			End Try
		End Sub

		' Token: 0x06008018 RID: 32792 RVA: 0x005EE0F0 File Offset: 0x005EC2F0
		Public Sub GetProduct_Serial(ProductId As String, InvoiceNo As String)
			Try
				Me.Cursor = Cursors.WaitCursor
				Dim dataTable As DataTable = New DataTable()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT a.productid AS PID, RTRIM(b.ProductCode) AS ProductCode, RTRIM(b.ProductName) AS ProductName, " & vbCrLf & "                                     a.barcode AS TempBarcode, a.serialno1 AS Serial_no, a.serialno2 AS Serial_no2" & vbCrLf & "                              FROM tbl_product_serial a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid  " & vbCrLf & "                              WHERE a.productid = @d1 AND a.invoice_no = @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.VarChar).Value = ProductId
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.VarChar).Value = InvoiceNo
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				sqlDataAdapter.Fill(dataTable)
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Me.DataGridView2.DataSource = Nothing
					Me.DataGridView2.Rows.Clear()
					Me.DataGridView2.DataSource = dataTable
				Else
					Me.Getdata_variant(Conversions.ToShort(Me.Label14.Text), Me.strBarcode)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = ModCommonClasses.con IsNot Nothing AndAlso ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
				Me.Cursor = Cursors.[Default]
			End Try
		End Sub

		' Token: 0x06008019 RID: 32793 RVA: 0x005EE280 File Offset: 0x005EC480
		Public Sub Getdata_variant(Id As Short, strBarcode As String)
			' The following expression was wrapped in a checked-statement
			Try
				Me.Label14.Text = Id.ToString()
				Me.Cursor = Cursors.WaitCursor
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "                SELECT PID, " & vbCrLf & "                       RTRIM(ProductCode) AS ProductCode, " & vbCrLf & "                       RTRIM(Productname) AS Productname, " & vbCrLf & "                       RTRIM(Temp_Stock.Barcode) AS TempBarcode, " & vbCrLf & "                       ISNULL(Temp_Stock.Serial_no, '') AS Serial_no, " & vbCrLf & "                       '' AS Serial_no2" & vbCrLf & "                FROM Category" & vbCrLf & "                INNER JOIN SubCategory ON Category.CategoryName = SubCategory.Category" & vbCrLf & "                INNER JOIN Product ON Product.SubCategoryID = SubCategory.ID" & vbCrLf & "                INNER JOIN Temp_Stock ON Temp_Stock.ProductID = Product.PID" & vbCrLf & "                INNER JOIN Product_Join ON Product.PID = Product_Join.ProductID" & vbCrLf & "                WHERE Temp_Stock.ProductID = @Id" & vbCrLf & "                ORDER BY PID ASC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@Id", Id)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Me.dt.Rows.Clear()
							sqlDataAdapter.Fill(Me.dt)
						End Using
					End Using
				End Using
				Me.DataGridView2.DataSource = Nothing
				Me.DataGridView2.Rows.Clear()
				Dim num As Integer = If(Integer.TryParse(Me.Label13.Text.Split(New Char() { "."c })(0), num), num, 0)
				Dim flag As Boolean = Me.dt.Rows.Count > 0 AndAlso num > 1
				If flag Then
					Dim list As List(Of DataRow) = Me.dt.Rows.Cast(Of DataRow)().ToList()
					Try
						For Each dataRow As DataRow In list
							Dim num2 As Integer = num - 1
							For i As Integer = 1 To num2
								Dim dataRow2 As DataRow = Me.dt.NewRow()
								dataRow2.ItemArray = CType(dataRow.ItemArray.Clone(), Object())
								Me.dt.Rows.Add(dataRow2)
							Next
						Next
					Finally
						Dim enumerator As List(Of DataRow).Enumerator
						CType(enumerator, IDisposable).Dispose()
					End Try
				End If
				Me.DataGridView2.DataSource = Nothing
				Me.DataGridView2.Rows.Clear()
				Me.DataGridView2.DataSource = Me.dt
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.Cursor = Cursors.[Default]
			End Try
		End Sub

		' Token: 0x0600801A RID: 32794 RVA: 0x005EE540 File Offset: 0x005EC740
		Private Sub gridtodatatable()
			Dim dataTable As DataTable = New DataTable()
			Try
				For Each obj As Object In Me.DataGridView2.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim type As Type = If(dataGridViewColumn.ValueType, GetType(String))
					dataTable.Columns.Add(dataGridViewColumn.HeaderText, type)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim num As Integer = Me.DataGridView2.Rows.Count - 1
			For i As Integer = 1 To num
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
				Dim flag As Boolean = Not dataGridViewRow.IsNewRow
				If flag Then
					Dim dataRow As DataRow = dataTable.NewRow()
					Dim num2 As Integer = Me.DataGridView2.Columns.Count - 1
					For j As Integer = 0 To num2
						dataRow(j) = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(j).Value)
					Next
					dataTable.Rows.Add(dataRow)
				End If
			Next
		End Sub

		' Token: 0x0600801B RID: 32795 RVA: 0x005EE680 File Offset: 0x005EC880
		Private Sub DataGridView2_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Try
				Dim flag As Boolean = TypeOf Me.DataGridView2.CurrentCell Is DataGridViewTextBoxCell
				If flag Then
					Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
					RemoveHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
					AddHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600801C RID: 32796 RVA: 0x005EE6FC File Offset: 0x005EC8FC
		Private Sub PreTranslateDGV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewTextBoxEditingControl.EditingControlDataGridView
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = editingControlDataGridView.ColumnCount - 1
				Dim num As Integer
				Dim num2 As Integer
				If flag2 Then
					num = editingControlDataGridView.CurrentCell.RowIndex + 1
					num2 = 0
					Dim flag3 As Boolean = num = editingControlDataGridView.RowCount
					If flag3 Then
						editingControlDataGridView.Rows.Add(1)
					End If
				Else
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 1
					While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
						num2 += 1
					End While
				End If
				Dim flag4 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 19
				If flag4 Then
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 4
				End If
				While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
					num2 += 1
				End While
				Dim flag5 As Boolean = num2 < editingControlDataGridView.ColumnCount
				If flag5 Then
					editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(num).Cells(num2)
					Dim flag6 As Boolean = New Integer() { 3, 5, 8, 14, 23, 32, 33, 45, 46 }.Contains(num2)
					If flag6 Then
						editingControlDataGridView.BeginEdit(True)
					End If
				End If
			End If
		End Sub

		' Token: 0x0600801D RID: 32797 RVA: 0x005EE884 File Offset: 0x005ECA84
		Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.RowIndex >= 0
			If flag Then
				Me.strStatus = "edit"
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
				Dim text As String = (If(dataGridViewRow.Cells("Serial_no").Value, "")).ToString()
				Dim text2 As String = (If(dataGridViewRow.Cells("Serial_no2").Value, "")).ToString()
				Me.txtSerialno1.Text = text
				Me.txtSerialno2.Text = text2
			End If
		End Sub

		' Token: 0x0600801E RID: 32798 RVA: 0x005EE92C File Offset: 0x005ECB2C
		Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Dim dataGridView As DataGridView = CType(sender, DataGridView)
					e.Handled = True
					Dim flag2 As Boolean = dataGridView.CurrentCell.ColumnIndex < dataGridView.ColumnCount - 1
					If flag2 Then
						Dim flag3 As Boolean = dataGridView.CurrentCell.ColumnIndex = 11
						If flag3 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 24, dataGridView.CurrentCell.RowIndex)
						Else
							Dim flag4 As Boolean = dataGridView.CurrentCell.ColumnIndex = 35
							If flag4 Then
								dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 8, dataGridView.CurrentCell.RowIndex)
							Else
								Dim visible As Boolean = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex).Visible
								If visible Then
									dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex)
								Else
									dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex)
								End If
							End If
						End If
					Else
						Dim flag5 As Boolean = dataGridView.CurrentCell.RowIndex < dataGridView.RowCount - 1
						If flag5 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex + 1)
						End If
					End If
					Dim rowIndex As Integer = Me.DataGridView2.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.DataGridView2.CurrentCell.ColumnIndex
					Dim flag6 As Boolean = TypeOf dataGridView.CurrentCell Is DataGridViewButtonCell
					If flag6 Then
						Dim name As String = dataGridView.CurrentCell.OwningColumn.Name
						If Operators.CompareString(name, "btnAddNew", False) = 0 Then
							Me.DataGridView2_CellContentClick(Me.DataGridView2, New DataGridViewCellEventArgs(columnIndex, rowIndex))
						End If
					Else
						dataGridView.BeginEdit(True)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600801F RID: 32799 RVA: 0x005EEB64 File Offset: 0x005ECD64
		Private Sub DataGridView2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView2 IsNot Nothing AndAlso Me.DataGridView2.Columns.Contains("txtOpeningStock2")
				If flag Then
					Dim flag2 As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("txtOpeningStock2").Index
					If flag2 Then
						Me.CalculateColumnSum()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in CellEndEdit: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06008020 RID: 32800 RVA: 0x005EEC00 File Offset: 0x005ECE00
		Private Sub CalculateColumnSum()
			Dim flag As Boolean = Me.dt.Rows.Count = 1
			If flag Then
				Dim num As Decimal = 0D
				Dim text As String = "txtOpeningStock2"
				Dim num2 As Integer = Me.DataGridView2.Rows.Count - 1
				For i As Integer = 1 To num2
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
					Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
					If flag2 Then
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(text).Value)
						Dim num3 As Decimal = 0D
						Dim flag3 As Boolean = Decimal.TryParse(objectValue.ToString(), num3)
						If flag3 Then
							num = Decimal.Add(num, num3)
							Dim num4 As Decimal = Decimal.Subtract(Me.initialQty, num)
							Me.DataGridView2.Rows(0).Cells(text).Value = num4
						End If
					End If
				Next
			End If
		End Sub

		' Token: 0x06008021 RID: 32801 RVA: 0x005EED00 File Offset: 0x005ECF00
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dt.Rows.Count > 0
			If flag Then
				Try
					Dim num As Integer = Me.DataGridView2.Rows.Count - 1
					For i As Integer = 0 To num
						Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
						Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
						If Not isNewRow Then
							Me.txtID.Text = Me.GenerateID()
							Me.txtProductCode.Text = "P-" + Me.GenerateID()
							Me.BCodeDisplay()
							Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
							Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text
							Dim flag2 As Boolean = dataGridViewRow.Cells("Serial_no").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow.Cells("Serial_no").Value.ToString(), "", False) <> 0
							If flag2 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "insert into tbl_product_serial(productid, barcode, serialno1, serialno2, status, sys_user, invoice_no) VALUES (@d0,@d1,@d2,@d3,@d4, @d5, @d6)"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.dt.Rows(0)("PID").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dt.Rows(0)("TempBarcode").ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Serial_no").Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Serial_no2").Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "PURCHASE")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.lblUser.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.lblInvoiceno.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Catch ex As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
				MessageBox.Show("Successfully Product Serial Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				MyBase.Dispose()
			End If
		End Sub

		' Token: 0x06008022 RID: 32802 RVA: 0x005EF02C File Offset: 0x005ED22C
		Private Sub frmProductRec_variant_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim msgBoxResult As MsgBoxResult = Interaction.MsgBox("Are you sure you want to Exit ?", MsgBoxStyle.YesNo, Nothing)
				Dim flag2 As Boolean = msgBoxResult = MsgBoxResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06008023 RID: 32803 RVA: 0x005EF070 File Offset: 0x005ED270
		Private Sub UpdateSerialNumbers()
			Dim flag As Boolean = Me.currentRowIndex < Me.DataGridView2.Rows.Count AndAlso Not Me.DataGridView2.Rows(Me.currentRowIndex).IsNewRow
			If flag Then
				Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtSerialno1.Text)
				If flag2 Then
					MessageBox.Show("Serial No. 1 is mandatory. Please enter a value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSerialno1.Focus()
				Else
					Dim text As String = Me.txtSerialno1.Text
					Dim text2 As String = Me.txtSerialno2.Text
					Try
						For Each obj As Object In CType(Me.DataGridView2.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag3 As Boolean = Not dataGridViewRow.IsNewRow AndAlso dataGridViewRow.Index <> Me.currentRowIndex
							If flag3 Then
								Dim value As Object = dataGridViewRow.Cells("Serial_no").Value
								Dim flag4 As Boolean = Operators.CompareString(If((value IsNot Nothing), value.ToString(), Nothing), text, False) = 0
								If flag4 Then
									MessageBox.Show(String.Format("Duplicate Serial No. 1 detected in row {0}. Please enter a unique value.", dataGridViewRow.Index + 1), "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtSerialno1.Focus()
									Return
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "SELECT TOP 1 serialno1 FROM tbl_product_serial WHERE serialno1 = @SerialNo UNION ALL SELECT TOP 1 serialno1 FROM tbl_product_serial_final WHERE serialno1 = @SerialNo"
								ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
								ModCommonClasses.cmd.CommandTimeout = 0
								ModCommonClasses.cmd.Parameters.AddWithValue("@SerialNo", text)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
								If hasRows Then
									MessageBox.Show("Serial no. 1 already exists." & vbCrLf & "Thank You!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtSerialno1.Focus()
									Return
								End If
								ModCommonClasses.con.Close()
								Dim flag5 As Boolean
								If Not String.IsNullOrEmpty(text2) Then
									Dim value2 As Object = dataGridViewRow.Cells("Serial_no2").Value
									flag5 = Operators.CompareString(If((value2 IsNot Nothing), value2.ToString(), Nothing), text2, False) = 0
								Else
									flag5 = False
								End If
								Dim flag6 As Boolean = flag5
								If flag6 Then
									MessageBox.Show(String.Format("Duplicate Serial No. 2 detected in row {0}. Please enter a unique value.", dataGridViewRow.Index + 1), "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtSerialno2.Focus()
									Return
								End If
								Dim flag7 As Boolean = Not String.IsNullOrEmpty(text2)
								If flag7 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "SELECT serialno2 FROM tbl_product_serial WHERE serialno2 = @SerialNo UNION ALL SELECT TOP 1 serialno2 FROM tbl_product_serial_final WHERE serialno2 = @SerialNo"
									ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
									ModCommonClasses.cmd.CommandTimeout = 0
									ModCommonClasses.cmd.Parameters.AddWithValue("@SerialNo", text2)
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim hasRows2 As Boolean = ModCommonClasses.rdr.HasRows
									If hasRows2 Then
										MessageBox.Show("Serial no. 2 already exists." & vbCrLf & "Thank You!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtSerialno2.Focus()
										Return
									End If
									ModCommonClasses.con.Close()
								End If
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView2.Rows(Me.currentRowIndex)
					dataGridViewRow2.Cells("Serial_no").Value = text
					dataGridViewRow2.Cells("Serial_no2").Value = text2
					MessageBox.Show("Row " + (Me.currentRowIndex + 1).ToString() + " updated successfully.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.txtSerialno1.Clear()
					Me.txtSerialno2.Clear()
					Me.txtSerialno1.Focus()
					Me.currentRowIndex = Me.currentRowIndex + 1
					Dim flag8 As Boolean = CDbl(Me.currentRowIndex) = Conversion.Val(Me.Label13.Text)
					If flag8 Then
						Me.GelButton1.Enabled = True
					Else
						Me.GelButton1.Enabled = False
					End If
				End If
			Else
				MessageBox.Show("All rows have been updated or there are no more rows to update.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.currentRowIndex -= 1
			End If
		End Sub

		' Token: 0x06008024 RID: 32804 RVA: 0x005EF4EC File Offset: 0x005ED6EC
		Private Sub UpdateSerialNumbers1()
			' The following expression was wrapped in a checked-statement
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView2.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag As Boolean = Not dataGridViewRow.IsNewRow
						If flag Then
							Dim text As String
							Do
								text = Interaction.InputBox("Enter a mandatory value for Serial No. 1 for Row " + Conversions.ToString(dataGridViewRow.Index + 1), "Serial No. 1 Input", "", -1, -1)
								Dim flag2 As Boolean = String.IsNullOrEmpty(text)
								If flag2 Then
									MessageBox.Show("Serial No. 1 is mandatory. Please enter a value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								End If
							Loop While String.IsNullOrEmpty(text)
							Dim text2 As String = Interaction.InputBox("Enter a value for Serial No. 2 for Row " + Conversions.ToString(dataGridViewRow.Index + 1), "Serial No. 2 Input", "", -1, -1)
							dataGridViewRow.Cells("Serial_no").Value = text
							dataGridViewRow.Cells("Serial_no2").Value = text2
						End If
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

		' Token: 0x06008025 RID: 32805 RVA: 0x005EF670 File Offset: 0x005ED870
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.strStatus, "new", False) = 0
			If flag Then
				Me.UpdateSerialNumbers()
			Else
				Dim flag2 As Boolean = Me.DataGridView2.CurrentRow IsNot Nothing AndAlso Not Me.DataGridView2.CurrentRow.IsNewRow
				If flag2 Then
					Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtSerialno1.Text)
					If flag3 Then
						MessageBox.Show("Serial No. 1 cannot be empty. Please enter a value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtSerialno1.Focus()
					Else
						Dim currentRow As DataGridViewRow = Me.DataGridView2.CurrentRow
						currentRow.Cells("Serial_no").Value = Me.txtSerialno1.Text
						currentRow.Cells("Serial_no2").Value = Me.txtSerialno2.Text
						MessageBox.Show("Row updated successfully.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.txtSerialno1.Clear()
						Me.txtSerialno2.Clear()
						Me.txtSerialno1.Focus()
					End If
				Else
					MessageBox.Show("No row selected or invalid row. Please select a valid row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			End If
		End Sub

		' Token: 0x06008026 RID: 32806 RVA: 0x005EF7A8 File Offset: 0x005ED9A8
		Private Sub txtSerialno1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim checked As Boolean = Me.chkScanner.Checked
				If checked Then
					Dim flag2 As Boolean = Operators.CompareString(Me.strStatus, "new", False) = 0
					If flag2 Then
						Me.UpdateSerialNumbers_scanner()
					Else
						Me.txtSerialno2.Focus()
						Dim flag3 As Boolean = Me.DataGridView2.CurrentRow IsNot Nothing AndAlso Not Me.DataGridView2.CurrentRow.IsNewRow
						If flag3 Then
							Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtSerialno1.Text)
							If flag4 Then
								MessageBox.Show("Serial No. 1 cannot be empty. Please enter a value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtSerialno1.Focus()
								Return
							End If
							Dim currentRow As DataGridViewRow = Me.DataGridView2.CurrentRow
							currentRow.Cells("Serial_no").Value = Me.txtSerialno1.Text
							currentRow.Cells("Serial_no2").Value = Me.txtSerialno2.Text
							MessageBox.Show("Row updated successfully.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.txtSerialno1.Clear()
							Me.txtSerialno2.Clear()
							Me.txtSerialno1.Focus()
						Else
							MessageBox.Show("No row selected or invalid row. Please select a valid row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						End If
					End If
				End If
				Dim flag5 As Boolean = Not Me.chkScanner.Checked
				If flag5 Then
					Me.txtSerialno2.Focus()
				End If
			End If
		End Sub

		' Token: 0x06008027 RID: 32807 RVA: 0x005EF938 File Offset: 0x005EDB38
		Private Sub txtSerialno2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.btnUpdate.Focus()
			End If
		End Sub

		' Token: 0x06008028 RID: 32808 RVA: 0x005EF070 File Offset: 0x005ED270
		Public Sub UpdateSerialNumbers_scanner()
			Dim flag As Boolean = Me.currentRowIndex < Me.DataGridView2.Rows.Count AndAlso Not Me.DataGridView2.Rows(Me.currentRowIndex).IsNewRow
			If flag Then
				Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtSerialno1.Text)
				If flag2 Then
					MessageBox.Show("Serial No. 1 is mandatory. Please enter a value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSerialno1.Focus()
				Else
					Dim text As String = Me.txtSerialno1.Text
					Dim text2 As String = Me.txtSerialno2.Text
					Try
						For Each obj As Object In CType(Me.DataGridView2.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag3 As Boolean = Not dataGridViewRow.IsNewRow AndAlso dataGridViewRow.Index <> Me.currentRowIndex
							If flag3 Then
								Dim value As Object = dataGridViewRow.Cells("Serial_no").Value
								Dim flag4 As Boolean = Operators.CompareString(If((value IsNot Nothing), value.ToString(), Nothing), text, False) = 0
								If flag4 Then
									MessageBox.Show(String.Format("Duplicate Serial No. 1 detected in row {0}. Please enter a unique value.", dataGridViewRow.Index + 1), "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtSerialno1.Focus()
									Return
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "SELECT TOP 1 serialno1 FROM tbl_product_serial WHERE serialno1 = @SerialNo UNION ALL SELECT TOP 1 serialno1 FROM tbl_product_serial_final WHERE serialno1 = @SerialNo"
								ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
								ModCommonClasses.cmd.CommandTimeout = 0
								ModCommonClasses.cmd.Parameters.AddWithValue("@SerialNo", text)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
								If hasRows Then
									MessageBox.Show("Serial no. 1 already exists." & vbCrLf & "Thank You!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtSerialno1.Focus()
									Return
								End If
								ModCommonClasses.con.Close()
								Dim flag5 As Boolean
								If Not String.IsNullOrEmpty(text2) Then
									Dim value2 As Object = dataGridViewRow.Cells("Serial_no2").Value
									flag5 = Operators.CompareString(If((value2 IsNot Nothing), value2.ToString(), Nothing), text2, False) = 0
								Else
									flag5 = False
								End If
								Dim flag6 As Boolean = flag5
								If flag6 Then
									MessageBox.Show(String.Format("Duplicate Serial No. 2 detected in row {0}. Please enter a unique value.", dataGridViewRow.Index + 1), "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtSerialno2.Focus()
									Return
								End If
								Dim flag7 As Boolean = Not String.IsNullOrEmpty(text2)
								If flag7 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "SELECT serialno2 FROM tbl_product_serial WHERE serialno2 = @SerialNo UNION ALL SELECT TOP 1 serialno2 FROM tbl_product_serial_final WHERE serialno2 = @SerialNo"
									ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
									ModCommonClasses.cmd.CommandTimeout = 0
									ModCommonClasses.cmd.Parameters.AddWithValue("@SerialNo", text2)
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim hasRows2 As Boolean = ModCommonClasses.rdr.HasRows
									If hasRows2 Then
										MessageBox.Show("Serial no. 2 already exists." & vbCrLf & "Thank You!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtSerialno2.Focus()
										Return
									End If
									ModCommonClasses.con.Close()
								End If
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView2.Rows(Me.currentRowIndex)
					dataGridViewRow2.Cells("Serial_no").Value = text
					dataGridViewRow2.Cells("Serial_no2").Value = text2
					MessageBox.Show("Row " + (Me.currentRowIndex + 1).ToString() + " updated successfully.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.txtSerialno1.Clear()
					Me.txtSerialno2.Clear()
					Me.txtSerialno1.Focus()
					Me.currentRowIndex = Me.currentRowIndex + 1
					Dim flag8 As Boolean = CDbl(Me.currentRowIndex) = Conversion.Val(Me.Label13.Text)
					If flag8 Then
						Me.GelButton1.Enabled = True
					Else
						Me.GelButton1.Enabled = False
					End If
				End If
			Else
				MessageBox.Show("All rows have been updated or there are no more rows to update.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.currentRowIndex -= 1
			End If
		End Sub

		' Token: 0x06008029 RID: 32809 RVA: 0x005EF964 File Offset: 0x005EDB64
		Public Sub Check_serialno1(serialNumber As String)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Try
					sqlConnection.Open()
					Dim text As String = "SELECT * FROM tbl_product_serial_final WHERE serialno1 = @SerialNo"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.CommandTimeout = 0
						sqlCommand.Parameters.AddWithValue("@SerialNo", serialNumber)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim hasRows As Boolean = sqlDataReader.HasRows
							If hasRows Then
								MessageBox.Show("Serial no. already exists." & vbCrLf & "Thank You!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtSerialno1.Focus()
							End If
						End Using
					End Using
				Catch ex As Exception
					MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Finally
					Dim flag As Boolean = sqlConnection.State = ConnectionState.Open
					If flag Then
						sqlConnection.Close()
					End If
				End Try
			End Using
		End Sub

		' Token: 0x0600802A RID: 32810 RVA: 0x005EFAA0 File Offset: 0x005EDCA0
		Public Sub Check_serialno2(serialNumber As String)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				Try
					sqlConnection.Open()
					Dim text As String = "SELECT * FROM tbl_product_serial_final WHERE serialno2 = @SerialNo"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.CommandTimeout = 0
						sqlCommand.Parameters.AddWithValue("@SerialNo", serialNumber)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim hasRows As Boolean = sqlDataReader.HasRows
							If hasRows Then
								MessageBox.Show("Serial no. already exists." & vbCrLf & "Thank You!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtSerialno2.Focus()
							End If
						End Using
					End Using
				Catch ex As Exception
					MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Finally
					Dim flag As Boolean = sqlConnection.State = ConnectionState.Open
					If flag Then
						sqlConnection.Close()
					End If
				End Try
			End Using
		End Sub

		' Token: 0x0600802B RID: 32811 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtSerialno1_Leave(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600802C RID: 32812 RVA: 0x005EFBDC File Offset: 0x005EDDDC
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim text As String = ""
				Dim flag As Boolean = Me.DataGridView2.Rows.Count > 0
				If flag Then
					text = Me.DataGridView2.Rows(0).Cells("PID").Value.ToString()
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text2 As String = "DELETE FROM tbl_product_serial WHERE productid = @d0 AND invoice_no = @d6"
						Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@d0", text)
							sqlCommand.Parameters.AddWithValue("@d6", Me.lblInvoiceno.Text)
							sqlCommand.ExecuteNonQuery()
						End Using
						Dim num As Integer = Me.DataGridView2.Rows.Count - 1
						For i As Integer = 0 To num
							Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
							Dim flag2 As Boolean = dataGridViewRow.Cells("Serial_no").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow.Cells("Serial_no").Value.ToString(), "", False) <> 0
							If flag2 Then
								ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
								ModCommonClasses.con1.Open()
								Dim text3 As String = "insert into tbl_product_serial(productid, barcode, serialno1, serialno2, status, sys_user, invoice_no) VALUES (@d0,@d1,@d2,@d3,@d4, @d5, @d6)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d0", text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("TempBarcode").Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Serial_no").Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Serial_no2").Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "PURCHASE")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.lblUser.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.lblInvoiceno.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con1
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con1.Close()
							End If
						Next
						MessageBox.Show("Data Updated!!")
					End Using
				Else
					MessageBox.Show("Data Not Updating!!")
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600802D RID: 32813 RVA: 0x0003EF53 File Offset: 0x0003D153
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseEntry.ReceivedValue3 = Me.Label14.Text.ToString()
			MyProject.Forms.frmPurchaseEntry.strStatus = "variant"
			MyBase.Dispose()
		End Sub

		' Token: 0x0400388F RID: 14479
		Private strBarcode As String

		' Token: 0x04003890 RID: 14480
		Private dt As DataTable

		' Token: 0x04003891 RID: 14481
		Private initialQty As Decimal

		' Token: 0x04003892 RID: 14482
		Public Shared strSerialno As String

		' Token: 0x04003893 RID: 14483
		Public Shared strSerialno2 As String

		' Token: 0x04003894 RID: 14484
		Private currentRowIndex As Integer

		' Token: 0x04003895 RID: 14485
		Private strStatus As String

		' Token: 0x04003896 RID: 14486
		Private Dad As SqlDataAdapter

		' Token: 0x04003897 RID: 14487
		Private Dst As DataSet

		' Token: 0x04003898 RID: 14488
		Private CurrentRow As Object

		' Token: 0x04003899 RID: 14489
		Private isd As String

		' Token: 0x020001DE RID: 478
		' (Invoke) Token: 0x06008031 RID: 32817
		Public Delegate Sub frmProductRec_variantClosedEventHandler(value As String)
	End Class
End Namespace
