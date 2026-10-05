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
	' Token: 0x020001DF RID: 479
	<DesignerGenerated()>
	Public Partial Class frmProductRec_serial
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008032 RID: 32818 RVA: 0x005EFF24 File Offset: 0x005EE124
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductRec_variant_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductRec_variant_KeyDown
			Me.dt = New DataTable()
			Me.currentRowIndex = 0
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002F12 RID: 12050
		' (get) Token: 0x06008035 RID: 32821 RVA: 0x0003EF92 File Offset: 0x0003D192
		' (set) Token: 0x06008036 RID: 32822 RVA: 0x0003EF9C File Offset: 0x0003D19C
		Friend Overridable Property txtBar As TextBox

		' Token: 0x17002F13 RID: 12051
		' (get) Token: 0x06008037 RID: 32823 RVA: 0x0003EFA5 File Offset: 0x0003D1A5
		' (set) Token: 0x06008038 RID: 32824 RVA: 0x0003EFAF File Offset: 0x0003D1AF
		Friend Overridable Property txtBarcodeTempStock As TextBox

		' Token: 0x17002F14 RID: 12052
		' (get) Token: 0x06008039 RID: 32825 RVA: 0x0003EFB8 File Offset: 0x0003D1B8
		' (set) Token: 0x0600803A RID: 32826 RVA: 0x0003EFC2 File Offset: 0x0003D1C2
		Friend Overridable Property txtID As TextBox

		' Token: 0x17002F15 RID: 12053
		' (get) Token: 0x0600803B RID: 32827 RVA: 0x0003EFCB File Offset: 0x0003D1CB
		' (set) Token: 0x0600803C RID: 32828 RVA: 0x0003EFD5 File Offset: 0x0003D1D5
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17002F16 RID: 12054
		' (get) Token: 0x0600803D RID: 32829 RVA: 0x0003EFDE File Offset: 0x0003D1DE
		' (set) Token: 0x0600803E RID: 32830 RVA: 0x0003EFE8 File Offset: 0x0003D1E8
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x17002F17 RID: 12055
		' (get) Token: 0x0600803F RID: 32831 RVA: 0x0003EFF1 File Offset: 0x0003D1F1
		' (set) Token: 0x06008040 RID: 32832 RVA: 0x0003EFFB File Offset: 0x0003D1FB
		Friend Overridable Property txtNP As TextBox

		' Token: 0x17002F18 RID: 12056
		' (get) Token: 0x06008041 RID: 32833 RVA: 0x0003F004 File Offset: 0x0003D204
		' (set) Token: 0x06008042 RID: 32834 RVA: 0x0003F00E File Offset: 0x0003D20E
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17002F19 RID: 12057
		' (get) Token: 0x06008043 RID: 32835 RVA: 0x0003F017 File Offset: 0x0003D217
		' (set) Token: 0x06008044 RID: 32836 RVA: 0x0003F021 File Offset: 0x0003D221
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17002F1A RID: 12058
		' (get) Token: 0x06008045 RID: 32837 RVA: 0x0003F02A File Offset: 0x0003D22A
		' (set) Token: 0x06008046 RID: 32838 RVA: 0x005F15B4 File Offset: 0x005EF7B4
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

		' Token: 0x17002F1B RID: 12059
		' (get) Token: 0x06008047 RID: 32839 RVA: 0x0003F034 File Offset: 0x0003D234
		' (set) Token: 0x06008048 RID: 32840 RVA: 0x005F15F8 File Offset: 0x005EF7F8
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

		' Token: 0x17002F1C RID: 12060
		' (get) Token: 0x06008049 RID: 32841 RVA: 0x0003F03E File Offset: 0x0003D23E
		' (set) Token: 0x0600804A RID: 32842 RVA: 0x005F163C File Offset: 0x005EF83C
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

		' Token: 0x17002F1D RID: 12061
		' (get) Token: 0x0600804B RID: 32843 RVA: 0x0003F048 File Offset: 0x0003D248
		' (set) Token: 0x0600804C RID: 32844 RVA: 0x0003F052 File Offset: 0x0003D252
		Friend Overridable Property Label14 As Label

		' Token: 0x17002F1E RID: 12062
		' (get) Token: 0x0600804D RID: 32845 RVA: 0x0003F05B File Offset: 0x0003D25B
		' (set) Token: 0x0600804E RID: 32846 RVA: 0x0003F065 File Offset: 0x0003D265
		Friend Overridable Property Label13 As Label

		' Token: 0x17002F1F RID: 12063
		' (get) Token: 0x0600804F RID: 32847 RVA: 0x0003F06E File Offset: 0x0003D26E
		' (set) Token: 0x06008050 RID: 32848 RVA: 0x0003F078 File Offset: 0x0003D278
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x17002F20 RID: 12064
		' (get) Token: 0x06008051 RID: 32849 RVA: 0x0003F081 File Offset: 0x0003D281
		' (set) Token: 0x06008052 RID: 32850 RVA: 0x0003F08B File Offset: 0x0003D28B
		Friend Overridable Property Label2 As Label

		' Token: 0x17002F21 RID: 12065
		' (get) Token: 0x06008053 RID: 32851 RVA: 0x0003F094 File Offset: 0x0003D294
		' (set) Token: 0x06008054 RID: 32852 RVA: 0x0003F09E File Offset: 0x0003D29E
		Friend Overridable Property Label1 As Label

		' Token: 0x17002F22 RID: 12066
		' (get) Token: 0x06008055 RID: 32853 RVA: 0x0003F0A7 File Offset: 0x0003D2A7
		' (set) Token: 0x06008056 RID: 32854 RVA: 0x005F16DC File Offset: 0x005EF8DC
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

		' Token: 0x17002F23 RID: 12067
		' (get) Token: 0x06008057 RID: 32855 RVA: 0x0003F0B1 File Offset: 0x0003D2B1
		' (set) Token: 0x06008058 RID: 32856 RVA: 0x005F1720 File Offset: 0x005EF920
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

		' Token: 0x17002F24 RID: 12068
		' (get) Token: 0x06008059 RID: 32857 RVA: 0x0003F0BB File Offset: 0x0003D2BB
		' (set) Token: 0x0600805A RID: 32858 RVA: 0x005F1764 File Offset: 0x005EF964
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

		' Token: 0x17002F25 RID: 12069
		' (get) Token: 0x0600805B RID: 32859 RVA: 0x0003F0C5 File Offset: 0x0003D2C5
		' (set) Token: 0x0600805C RID: 32860 RVA: 0x0003F0CF File Offset: 0x0003D2CF
		Friend Overridable Property chkScanner As CheckBox

		' Token: 0x17002F26 RID: 12070
		' (get) Token: 0x0600805D RID: 32861 RVA: 0x0003F0D8 File Offset: 0x0003D2D8
		' (set) Token: 0x0600805E RID: 32862 RVA: 0x0003F0E2 File Offset: 0x0003D2E2
		Friend Overridable Property lblUser As Label

		' Token: 0x17002F27 RID: 12071
		' (get) Token: 0x0600805F RID: 32863 RVA: 0x0003F0EB File Offset: 0x0003D2EB
		' (set) Token: 0x06008060 RID: 32864 RVA: 0x0003F0F5 File Offset: 0x0003D2F5
		Friend Overridable Property lblInvoiceno As Label

		' Token: 0x17002F28 RID: 12072
		' (get) Token: 0x06008061 RID: 32865 RVA: 0x0003F0FE File Offset: 0x0003D2FE
		' (set) Token: 0x06008062 RID: 32866 RVA: 0x005F17C4 File Offset: 0x005EF9C4
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

		' Token: 0x17002F29 RID: 12073
		' (get) Token: 0x06008063 RID: 32867 RVA: 0x0003F108 File Offset: 0x0003D308
		' (set) Token: 0x06008064 RID: 32868 RVA: 0x0003F112 File Offset: 0x0003D312
		Friend Overridable Property lblstatus As Label

		' Token: 0x17002F2A RID: 12074
		' (get) Token: 0x06008065 RID: 32869 RVA: 0x0003F11B File Offset: 0x0003D31B
		' (set) Token: 0x06008066 RID: 32870 RVA: 0x0003F125 File Offset: 0x0003D325
		Friend Overridable Property PID As DataGridViewTextBoxColumn

		' Token: 0x17002F2B RID: 12075
		' (get) Token: 0x06008067 RID: 32871 RVA: 0x0003F12E File Offset: 0x0003D32E
		' (set) Token: 0x06008068 RID: 32872 RVA: 0x0003F138 File Offset: 0x0003D338
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17002F2C RID: 12076
		' (get) Token: 0x06008069 RID: 32873 RVA: 0x0003F141 File Offset: 0x0003D341
		' (set) Token: 0x0600806A RID: 32874 RVA: 0x0003F14B File Offset: 0x0003D34B
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17002F2D RID: 12077
		' (get) Token: 0x0600806B RID: 32875 RVA: 0x0003F154 File Offset: 0x0003D354
		' (set) Token: 0x0600806C RID: 32876 RVA: 0x0003F15E File Offset: 0x0003D35E
		Friend Overridable Property TempBarcode As DataGridViewTextBoxColumn

		' Token: 0x17002F2E RID: 12078
		' (get) Token: 0x0600806D RID: 32877 RVA: 0x0003F167 File Offset: 0x0003D367
		' (set) Token: 0x0600806E RID: 32878 RVA: 0x0003F171 File Offset: 0x0003D371
		Friend Overridable Property Serial_no As DataGridViewTextBoxColumn

		' Token: 0x17002F2F RID: 12079
		' (get) Token: 0x0600806F RID: 32879 RVA: 0x0003F17A File Offset: 0x0003D37A
		' (set) Token: 0x06008070 RID: 32880 RVA: 0x0003F184 File Offset: 0x0003D384
		Friend Overridable Property Serial_no2 As DataGridViewTextBoxColumn

		' Token: 0x1400002E RID: 46
		' (add) Token: 0x06008071 RID: 32881 RVA: 0x005F1808 File Offset: 0x005EFA08
		' (remove) Token: 0x06008072 RID: 32882 RVA: 0x005F1840 File Offset: 0x005EFA40
		Public Event frmProductRec_variantClosed As frmProductRec_serial.frmProductRec_variantClosedEventHandler

		' Token: 0x06008073 RID: 32883 RVA: 0x005F1878 File Offset: 0x005EFA78
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

		' Token: 0x06008074 RID: 32884 RVA: 0x005ED5FC File Offset: 0x005EB7FC
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

		' Token: 0x06008075 RID: 32885 RVA: 0x005ED880 File Offset: 0x005EBA80
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

		' Token: 0x06008076 RID: 32886 RVA: 0x005C56AC File Offset: 0x005C38AC
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

		' Token: 0x06008077 RID: 32887 RVA: 0x005F1914 File Offset: 0x005EFB14
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

		' Token: 0x06008078 RID: 32888 RVA: 0x0020DD08 File Offset: 0x0020BF08
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

		' Token: 0x06008079 RID: 32889 RVA: 0x005F1A00 File Offset: 0x005EFC00
		Public Sub GenerateBarcode()
			Try
				Me.BCodeDisplay()
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600807A RID: 32890 RVA: 0x005F1A84 File Offset: 0x005EFC84
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

		' Token: 0x0600807B RID: 32891 RVA: 0x005EDB9C File Offset: 0x005EBD9C
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

		' Token: 0x0600807C RID: 32892 RVA: 0x005F1B6C File Offset: 0x005EFD6C
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

		' Token: 0x0600807D RID: 32893 RVA: 0x005F1CA0 File Offset: 0x005EFEA0
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600807E RID: 32894 RVA: 0x005F1D24 File Offset: 0x005EFF24
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600807F RID: 32895 RVA: 0x0011427C File Offset: 0x0011247C
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

		' Token: 0x06008080 RID: 32896 RVA: 0x005F1D98 File Offset: 0x005EFF98
		Public Sub gridCOlumDefine()
			Me.DataGridView2.Columns.Add("PID", "PID")
			Me.DataGridView2.Columns.Add("ProductCode", "ProductCode")
			Me.DataGridView2.Columns.Add("Productname", "Productname")
			Me.DataGridView2.Columns.Add("TempBarcode", "TempBarcode")
			Me.DataGridView2.Columns.Add("Serial_no", "Serial_no")
			Me.DataGridView2.Columns.Add("Serial_no2", "Serial_no2")
		End Sub

		' Token: 0x06008081 RID: 32897 RVA: 0x005F1E48 File Offset: 0x005F0048
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

		' Token: 0x06008082 RID: 32898 RVA: 0x005F1FD8 File Offset: 0x005F01D8
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

		' Token: 0x06008083 RID: 32899 RVA: 0x005F2168 File Offset: 0x005F0368
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

		' Token: 0x06008084 RID: 32900 RVA: 0x005F2428 File Offset: 0x005F0628
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

		' Token: 0x06008085 RID: 32901 RVA: 0x005F2568 File Offset: 0x005F0768
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

		' Token: 0x06008086 RID: 32902 RVA: 0x005EE6FC File Offset: 0x005EC8FC
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

		' Token: 0x06008087 RID: 32903 RVA: 0x005F25E4 File Offset: 0x005F07E4
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

		' Token: 0x06008088 RID: 32904 RVA: 0x005F268C File Offset: 0x005F088C
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

		' Token: 0x06008089 RID: 32905 RVA: 0x005F28C4 File Offset: 0x005F0AC4
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

		' Token: 0x0600808A RID: 32906 RVA: 0x005F2960 File Offset: 0x005F0B60
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

		' Token: 0x0600808B RID: 32907 RVA: 0x005F2A60 File Offset: 0x005F0C60
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

		' Token: 0x0600808C RID: 32908 RVA: 0x005EF02C File Offset: 0x005ED22C
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

		' Token: 0x0600808D RID: 32909 RVA: 0x005F2D8C File Offset: 0x005F0F8C
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

		' Token: 0x0600808E RID: 32910 RVA: 0x005F3208 File Offset: 0x005F1408
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

		' Token: 0x0600808F RID: 32911 RVA: 0x005F338C File Offset: 0x005F158C
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

		' Token: 0x06008090 RID: 32912 RVA: 0x005F34C4 File Offset: 0x005F16C4
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

		' Token: 0x06008091 RID: 32913 RVA: 0x005F3640 File Offset: 0x005F1840
		Private Sub txtSerialno2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.btnUpdate.Focus()
			End If
		End Sub

		' Token: 0x06008092 RID: 32914 RVA: 0x005F366C File Offset: 0x005F186C
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

		' Token: 0x06008093 RID: 32915 RVA: 0x005F3AB8 File Offset: 0x005F1CB8
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

		' Token: 0x06008094 RID: 32916 RVA: 0x005F3BF4 File Offset: 0x005F1DF4
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

		' Token: 0x06008095 RID: 32917 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtSerialno1_Leave(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06008096 RID: 32918 RVA: 0x005F3D30 File Offset: 0x005F1F30
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

		' Token: 0x06008097 RID: 32919 RVA: 0x0003F18D File Offset: 0x0003D38D
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseEntry.ReceivedValue3 = Me.Label14.Text.ToString()
			MyProject.Forms.frmPurchaseEntry.strStatus = "variant"
			MyBase.Dispose()
		End Sub

		' Token: 0x040038BA RID: 14522
		Private strBarcode As String

		' Token: 0x040038BB RID: 14523
		Private dt As DataTable

		' Token: 0x040038BC RID: 14524
		Private initialQty As Decimal

		' Token: 0x040038BD RID: 14525
		Public Shared strSerialno As String

		' Token: 0x040038BE RID: 14526
		Public Shared strSerialno2 As String

		' Token: 0x040038BF RID: 14527
		Private currentRowIndex As Integer

		' Token: 0x040038C0 RID: 14528
		Private strStatus As String

		' Token: 0x040038C1 RID: 14529
		Private Dad As SqlDataAdapter

		' Token: 0x040038C2 RID: 14530
		Private Dst As DataSet

		' Token: 0x040038C3 RID: 14531
		Private CurrentRow As Object

		' Token: 0x040038C4 RID: 14532
		Private isd As String

		' Token: 0x020001E0 RID: 480
		' (Invoke) Token: 0x0600809B RID: 32923
		Public Delegate Sub frmProductRec_variantClosedEventHandler(value As String)
	End Class
End Namespace
