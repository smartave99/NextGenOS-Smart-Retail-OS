Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000BF RID: 191
	<DesignerGenerated()>
	Public Partial Class frmBulkPriceChange
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001B1F RID: 6943 RVA: 0x00129FEC File Offset: 0x001281EC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			AddHandler MyBase.Closing, AddressOf Me.frmBulkPriceChange_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmBulkPriceChange_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000A86 RID: 2694
		' (get) Token: 0x06001B22 RID: 6946 RVA: 0x000140BD File Offset: 0x000122BD
		' (set) Token: 0x06001B23 RID: 6947 RVA: 0x0012A6E8 File Offset: 0x001288E8
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.dgw_EditingControlShowing
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A87 RID: 2695
		' (get) Token: 0x06001B24 RID: 6948 RVA: 0x000140C7 File Offset: 0x000122C7
		' (set) Token: 0x06001B25 RID: 6949 RVA: 0x0012A748 File Offset: 0x00128948
		Private _btnUpdatePrice As Button
		Friend Overridable Property btnUpdatePrice As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUpdatePrice
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdatePrice_Click
				Dim button As Button = Me._btnUpdatePrice
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUpdatePrice = value
				button = Me._btnUpdatePrice
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A88 RID: 2696
		' (get) Token: 0x06001B26 RID: 6950 RVA: 0x000140D1 File Offset: 0x000122D1
		' (set) Token: 0x06001B27 RID: 6951 RVA: 0x000140DB File Offset: 0x000122DB
		Friend Overridable Property lblCategoryId As Label

		' Token: 0x17000A89 RID: 2697
		' (get) Token: 0x06001B28 RID: 6952 RVA: 0x000140E4 File Offset: 0x000122E4
		' (set) Token: 0x06001B29 RID: 6953 RVA: 0x000140EE File Offset: 0x000122EE
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x17000A8A RID: 2698
		' (get) Token: 0x06001B2A RID: 6954 RVA: 0x000140F7 File Offset: 0x000122F7
		' (set) Token: 0x06001B2B RID: 6955 RVA: 0x00014101 File Offset: 0x00012301
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000A8B RID: 2699
		' (get) Token: 0x06001B2C RID: 6956 RVA: 0x0001410A File Offset: 0x0001230A
		' (set) Token: 0x06001B2D RID: 6957 RVA: 0x00014114 File Offset: 0x00012314
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17000A8C RID: 2700
		' (get) Token: 0x06001B2E RID: 6958 RVA: 0x0001411D File Offset: 0x0001231D
		' (set) Token: 0x06001B2F RID: 6959 RVA: 0x00014127 File Offset: 0x00012327
		Friend Overridable Property DataGridViewComboBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17000A8D RID: 2701
		' (get) Token: 0x06001B30 RID: 6960 RVA: 0x00014130 File Offset: 0x00012330
		' (set) Token: 0x06001B31 RID: 6961 RVA: 0x0001413A File Offset: 0x0001233A
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000A8E RID: 2702
		' (get) Token: 0x06001B32 RID: 6962 RVA: 0x00014143 File Offset: 0x00012343
		' (set) Token: 0x06001B33 RID: 6963 RVA: 0x0001414D File Offset: 0x0001234D
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000A8F RID: 2703
		' (get) Token: 0x06001B34 RID: 6964 RVA: 0x00014156 File Offset: 0x00012356
		' (set) Token: 0x06001B35 RID: 6965 RVA: 0x00014160 File Offset: 0x00012360
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x06001B36 RID: 6966 RVA: 0x00014169 File Offset: 0x00012369
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06001B37 RID: 6967 RVA: 0x0012A78C File Offset: 0x0012898C
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode), RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Product.SubCategoryID = " + Me.lblCategoryId.Text + " and Temp_Stock.Qty > 0 order by ProductName", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim flag As Boolean = Me.dgw.RowCount > 0
				If flag Then
					MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
						Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(6)
						Me.dgw.BeginEdit(True)
					End Sub))
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001B38 RID: 6968 RVA: 0x0012A930 File Offset: 0x00128B30
		Private Sub btnUpdatePrice_Click(sender As Object, e As EventArgs)
			Dim text As String = ""
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Conversions.ToBoolean(Operators.AndObject(dataGridViewRow.Cells(6) IsNot Nothing, Operators.CompareObjectGreater(dataGridViewRow.Cells(6).Value, 0, False)))
					If flag Then
						Dim text2 As String = String.Concat(New String() { "UPDATE Product SET SellingPrice = ", Conversions.ToString(dataGridViewRow.Cells(6).Value), " WHERE PID = ", Conversions.ToString(dataGridViewRow.Cells(0).Value), " and ProductCode = N'", dataGridViewRow.Cells(1).Value.ToString().Trim(), "';" })
						Dim text3 As String = String.Concat(New String() { "Update Temp_Stock set SPrice = ", Conversions.ToString(dataGridViewRow.Cells(6).Value), " WHERE ProductID = ", Conversions.ToString(dataGridViewRow.Cells(0).Value), " and Barcode = N'", dataGridViewRow.Cells(3).Value.ToString().Trim(), "';" })
						Dim text4 As String = String.Concat(New String() { "Update Product_OpeningStock set SalePrice = ", Conversions.ToString(dataGridViewRow.Cells(6).Value), " WHERE ProductID = ", Conversions.ToString(dataGridViewRow.Cells(0).Value), " and Barcode = N'", dataGridViewRow.Cells(3).Value.ToString().Trim(), "';" })
						text = String.Concat(New String() { text, text2, vbCrLf, text3, vbCrLf, text4, vbCrLf })
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Try
				Dim flag2 As Boolean = text.Length > 0
				If flag2 Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.rdr = New SqlCommand(text) With { .Connection = ModCommonClasses.con }.ExecuteReader()
					ModCommonClasses.con.Close()
					MessageBox.Show("New Sale Price Successfully Updated", " Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					MyBase.Dispose()
				Else
					Dim flag3 As Boolean = Me.dgw.RowCount > 0
					If flag3 Then
						Me.dgw.Focus()
						Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(6)
						Me.dgw.BeginEdit(True)
						Dim textBox As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
						Dim flag4 As Boolean = textBox IsNot Nothing
						If flag4 Then
							textBox.Focus()
							textBox.SelectionStart = textBox.TextLength
						End If
					End If
					MessageBox.Show("Enter sell price to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001B39 RID: 6969 RVA: 0x0001417B File Offset: 0x0001237B
		Private Sub frmBulkPriceChange_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmPOSNewTuch.btnCategory_Click(RuntimeHelpers.GetObjectValue(Me.eventSender), e)
		End Sub

		' Token: 0x06001B3A RID: 6970 RVA: 0x0012ACF4 File Offset: 0x00128EF4
		Private Sub dgw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Dim flag As Boolean = Me.dgw.CurrentCell.ColumnIndex = 6
			If flag Then
				Dim textBox As TextBox = TryCast(e.Control, TextBox)
				Dim flag2 As Boolean = textBox IsNot Nothing
				If flag2 Then
					RemoveHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
					AddHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
				End If
			End If
		End Sub

		' Token: 0x06001B3B RID: 6971 RVA: 0x0011AF1C File Offset: 0x0011911C
		Private Sub NumericDecimal_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim textBox As TextBox = CType(sender, TextBox)
			Dim flag As Boolean = Char.IsControl(e.KeyChar)
			If Not flag Then
				Dim flag2 As Boolean = e.KeyChar = "."c
				If flag2 Then
					Dim flag3 As Boolean = textBox.Text.Contains(".")
					If flag3 Then
						e.Handled = True
					End If
				Else
					Dim flag4 As Boolean = Not Char.IsDigit(e.KeyChar)
					If flag4 Then
						e.Handled = True
					End If
				End If
			End If
		End Sub

		' Token: 0x06001B3C RID: 6972 RVA: 0x0012AD58 File Offset: 0x00128F58
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 6
			If flag Then
				e.SuppressKeyPress = True
				Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
				Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
				Dim flag2 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
				If flag2 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(columnIndex)
				Else
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(columnIndex)
				End If
				Me.dgw.BeginEdit(True)
			End If
		End Sub

		' Token: 0x06001B3D RID: 6973 RVA: 0x0012AE38 File Offset: 0x00129038
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Dim flag As Boolean = keyData = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Me.dgw.Focused OrElse (Me.dgw.IsCurrentCellInEditMode AndAlso Me.dgw.CurrentCell.ColumnIndex = 6)
				If flag2 Then
					Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
					Dim flag3 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
					If flag3 Then
						Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(columnIndex)
					Else
						Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(columnIndex)
					End If
					Me.dgw.BeginEdit(True)
					Return True
				End If
			End If
			Return MyBase.ProcessCmdKey(msg, keyData)
		End Function

		' Token: 0x06001B3E RID: 6974 RVA: 0x0012AF44 File Offset: 0x00129144
		Private Sub frmBulkPriceChange_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.Control AndAlso e.KeyCode = Keys.U
			If flag Then
				Me.btnUpdatePrice.Focus()
				Me.btnUpdatePrice_Click(RuntimeHelpers.GetObjectValue(sender), e)
			End If
		End Sub

		' Token: 0x04000ABC RID: 2748
		Public eventSender As Object
	End Class
End Namespace
