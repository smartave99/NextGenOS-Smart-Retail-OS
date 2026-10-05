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
	' Token: 0x020000BC RID: 188
	<DesignerGenerated()>
	Public Partial Class frmProductNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001AC9 RID: 6857 RVA: 0x00124F00 File Offset: 0x00123100
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			AddHandler MyBase.Closing, AddressOf Me.frmBulkPriceChange_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmBulkPriceChange_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000A6C RID: 2668
		' (get) Token: 0x06001ACC RID: 6860 RVA: 0x00013E93 File Offset: 0x00012093
		' (set) Token: 0x06001ACD RID: 6861 RVA: 0x00125FA4 File Offset: 0x001241A4
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A6D RID: 2669
		' (get) Token: 0x06001ACE RID: 6862 RVA: 0x00013E9D File Offset: 0x0001209D
		' (set) Token: 0x06001ACF RID: 6863 RVA: 0x00125FE8 File Offset: 0x001241E8
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

		' Token: 0x17000A6E RID: 2670
		' (get) Token: 0x06001AD0 RID: 6864 RVA: 0x00013EA7 File Offset: 0x000120A7
		' (set) Token: 0x06001AD1 RID: 6865 RVA: 0x00013EB1 File Offset: 0x000120B1
		Friend Overridable Property lblCategoryId As Label

		' Token: 0x17000A6F RID: 2671
		' (get) Token: 0x06001AD2 RID: 6866 RVA: 0x00013EBA File Offset: 0x000120BA
		' (set) Token: 0x06001AD3 RID: 6867 RVA: 0x0012602C File Offset: 0x0012422C
		Private _btnNewItem As Button
		Friend Overridable Property btnNewItem As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNewItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNewItem_Click
				Dim button As Button = Me._btnNewItem
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNewItem = value
				button = Me._btnNewItem
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A70 RID: 2672
		' (get) Token: 0x06001AD4 RID: 6868 RVA: 0x00013EC4 File Offset: 0x000120C4
		' (set) Token: 0x06001AD5 RID: 6869 RVA: 0x00013ECE File Offset: 0x000120CE
		Friend Overridable Property txtBar As TextBox

		' Token: 0x17000A71 RID: 2673
		' (get) Token: 0x06001AD6 RID: 6870 RVA: 0x00013ED7 File Offset: 0x000120D7
		' (set) Token: 0x06001AD7 RID: 6871 RVA: 0x00013EE1 File Offset: 0x000120E1
		Friend Overridable Property txtID_temp As TextBox

		' Token: 0x17000A72 RID: 2674
		' (get) Token: 0x06001AD8 RID: 6872 RVA: 0x00013EEA File Offset: 0x000120EA
		' (set) Token: 0x06001AD9 RID: 6873 RVA: 0x00013EF4 File Offset: 0x000120F4
		Friend Overridable Property strStax As TextBox

		' Token: 0x17000A73 RID: 2675
		' (get) Token: 0x06001ADA RID: 6874 RVA: 0x00013EFD File Offset: 0x000120FD
		' (set) Token: 0x06001ADB RID: 6875 RVA: 0x00013F07 File Offset: 0x00012107
		Friend Overridable Property strPtax As TextBox

		' Token: 0x17000A74 RID: 2676
		' (get) Token: 0x06001ADC RID: 6876 RVA: 0x00013F10 File Offset: 0x00012110
		' (set) Token: 0x06001ADD RID: 6877 RVA: 0x00013F1A File Offset: 0x0001211A
		Public Overridable Property Photo As PictureBox

		' Token: 0x17000A75 RID: 2677
		' (get) Token: 0x06001ADE RID: 6878 RVA: 0x00013F23 File Offset: 0x00012123
		' (set) Token: 0x06001ADF RID: 6879 RVA: 0x00013F2D File Offset: 0x0001212D
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000A76 RID: 2678
		' (get) Token: 0x06001AE0 RID: 6880 RVA: 0x00013F36 File Offset: 0x00012136
		' (set) Token: 0x06001AE1 RID: 6881 RVA: 0x00126070 File Offset: 0x00124270
		Private _settingdefault As Button
		Friend Overridable Property settingdefault As Button
			<CompilerGenerated()>
			Get
				Return Me._settingdefault
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.settingdefault_Click
				Dim button As Button = Me._settingdefault
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._settingdefault = value
				button = Me._settingdefault
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A77 RID: 2679
		' (get) Token: 0x06001AE2 RID: 6882 RVA: 0x00013F40 File Offset: 0x00012140
		' (set) Token: 0x06001AE3 RID: 6883 RVA: 0x00013F4A File Offset: 0x0001214A
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x17000A78 RID: 2680
		' (get) Token: 0x06001AE4 RID: 6884 RVA: 0x00013F53 File Offset: 0x00012153
		' (set) Token: 0x06001AE5 RID: 6885 RVA: 0x00013F5D File Offset: 0x0001215D
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000A79 RID: 2681
		' (get) Token: 0x06001AE6 RID: 6886 RVA: 0x00013F66 File Offset: 0x00012166
		' (set) Token: 0x06001AE7 RID: 6887 RVA: 0x00013F70 File Offset: 0x00012170
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17000A7A RID: 2682
		' (get) Token: 0x06001AE8 RID: 6888 RVA: 0x00013F79 File Offset: 0x00012179
		' (set) Token: 0x06001AE9 RID: 6889 RVA: 0x00013F83 File Offset: 0x00012183
		Friend Overridable Property DataGridViewComboBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17000A7B RID: 2683
		' (get) Token: 0x06001AEA RID: 6890 RVA: 0x00013F8C File Offset: 0x0001218C
		' (set) Token: 0x06001AEB RID: 6891 RVA: 0x00013F96 File Offset: 0x00012196
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000A7C RID: 2684
		' (get) Token: 0x06001AEC RID: 6892 RVA: 0x00013F9F File Offset: 0x0001219F
		' (set) Token: 0x06001AED RID: 6893 RVA: 0x00013FA9 File Offset: 0x000121A9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000A7D RID: 2685
		' (get) Token: 0x06001AEE RID: 6894 RVA: 0x00013FB2 File Offset: 0x000121B2
		' (set) Token: 0x06001AEF RID: 6895 RVA: 0x00013FBC File Offset: 0x000121BC
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000A7E RID: 2686
		' (get) Token: 0x06001AF0 RID: 6896 RVA: 0x00013FC5 File Offset: 0x000121C5
		' (set) Token: 0x06001AF1 RID: 6897 RVA: 0x00013FCF File Offset: 0x000121CF
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000A7F RID: 2687
		' (get) Token: 0x06001AF2 RID: 6898 RVA: 0x00013FD8 File Offset: 0x000121D8
		' (set) Token: 0x06001AF3 RID: 6899 RVA: 0x00013FE2 File Offset: 0x000121E2
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000A80 RID: 2688
		' (get) Token: 0x06001AF4 RID: 6900 RVA: 0x00013FEB File Offset: 0x000121EB
		' (set) Token: 0x06001AF5 RID: 6901 RVA: 0x00013FF5 File Offset: 0x000121F5
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000A81 RID: 2689
		' (get) Token: 0x06001AF6 RID: 6902 RVA: 0x00013FFE File Offset: 0x000121FE
		' (set) Token: 0x06001AF7 RID: 6903 RVA: 0x00014008 File Offset: 0x00012208
		Friend Overridable Property lblUser As Label

		' Token: 0x17000A82 RID: 2690
		' (get) Token: 0x06001AF8 RID: 6904 RVA: 0x00014011 File Offset: 0x00012211
		' (set) Token: 0x06001AF9 RID: 6905 RVA: 0x0001401B File Offset: 0x0001221B
		Friend Overridable Property lblUserType As Label

		' Token: 0x17000A83 RID: 2691
		' (get) Token: 0x06001AFA RID: 6906 RVA: 0x00014024 File Offset: 0x00012224
		' (set) Token: 0x06001AFB RID: 6907 RVA: 0x001260B4 File Offset: 0x001242B4
		Private _GelButton3 As Button
		Friend Overridable Property GelButton3 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim button As Button = Me._GelButton3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton3 = value
				button = Me._GelButton3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A84 RID: 2692
		' (get) Token: 0x06001AFC RID: 6908 RVA: 0x0001402E File Offset: 0x0001222E
		' (set) Token: 0x06001AFD RID: 6909 RVA: 0x001260F8 File Offset: 0x001242F8
		Private _GelButtonNewRecord As Button
		Friend Overridable Property GelButtonNewRecord As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButtonNewRecord
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButtonNewRecord = value
				button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A85 RID: 2693
		' (get) Token: 0x06001AFE RID: 6910 RVA: 0x00014038 File Offset: 0x00012238
		' (set) Token: 0x06001AFF RID: 6911 RVA: 0x0012613C File Offset: 0x0012433C
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

		' Token: 0x06001B00 RID: 6912 RVA: 0x00014042 File Offset: 0x00012242
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06001B01 RID: 6913 RVA: 0x00126180 File Offset: 0x00124380
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode), RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice)," & vbCrLf & "(Temp_Stock.SPrice), Temp_Stock.Qty from Temp_Stock,Product,SubCategory " & vbCrLf & "where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' " & vbCrLf & "and Product.SubCategoryID = " + Me.lblCategoryId.Text + " and Temp_Stock.Qty > 0 order by ProductName", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim flag As Boolean = Me.dgw.RowCount > 0
				If flag Then
					MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
						Me.dgw.Focus()
						Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
						Me.dgw.BeginEdit(True)
						Dim textBox As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
						Dim flag2 As Boolean = textBox IsNot Nothing
						If flag2 Then
							textBox.Focus()
							RemoveHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
							AddHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
						End If
					End Sub))
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001B02 RID: 6914 RVA: 0x00126364 File Offset: 0x00124564
		Private Sub btnUpdatePrice_Click(sender As Object, e As EventArgs)
			Try

				Dim dataGridViewRow As DataGridViewRow = Nothing

				For Each r As DataGridViewRow In Me.dgw.Rows

					If Not r.IsNewRow Then

						Dim num5 As Integer = CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(r.Cells(0).Value))))

						Dim text6 As String = Conversions.ToString(r.Cells(2).Value)

						Dim text7 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(r.Cells(3).Value))

						Dim num6 As Decimal = New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(r.Cells(4).Value)))

						Dim num7 As Decimal = New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(r.Cells(5).Value)))

						Dim flag14 As Boolean = String.IsNullOrEmpty(text6.Trim())

						If flag14 Then

							Me.dgw.Rows.Remove(r)

						ElseIf (num5 <> 0 AndAlso String.IsNullOrEmpty(text7)) OrElse Decimal.Compare(num6, 0D) <= 0 OrElse Decimal.Compare(num7, 0D) <= 0 Then

							dataGridViewRow = r

							Exit For

						End If

					End If

				Next

				Dim flag As Boolean = dataGridViewRow IsNot Nothing
				If flag Then
					MessageBox.Show("Invalid value found at row " + Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)) + ", can't update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag2 As Boolean = Not Me.GetDefaultValues()
					If Not flag2 Then
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim flag3 As Boolean = True
							Using sqlTransaction As SqlTransaction = sqlConnection.BeginTransaction()
								Try
									Dim array As ValueTuple(Of String, String, String, String, String, String)() = New ValueTuple(Of String, String, String, String, String, String)() { New ValueTuple(Of String, String, String, String, String, String)("Product", "PID", "Barcode", "CostPrice", "SellingPrice", "DefQty"), New ValueTuple(Of String, String, String, String, String, String)("Temp_Stock", "ProductID", "Barcode", "PPrice", "SalePrice", "Qty"), New ValueTuple(Of String, String, String, String, String, String)("Product_OpeningStock", "ProductID", "Barcode", "PPrice", "SalePrice", "Qty"), New ValueTuple(Of String, String, String, String, String, String)("Invoice_Product", "ProductID", "Barcode", "PurchaseRate", "SalesRate", "Qty"), New ValueTuple(Of String, String, String, String, String, String)("SalesReturn_Join", "ProductID", "Barcode", "PurchaseRate", "SalesRate", "Qty") }
									Dim array2 As ValueTuple(Of String, String, String)() = New ValueTuple(Of String, String, String)() { New ValueTuple(Of String, String, String)("Stock_Product", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("Quotation_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("Estimate_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("PurchaseOrder_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("PurchaseReturn_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("Stock_Store_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("StockAdjustment_Store", "ProductID", "Barcode") }
									Try
										For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
											Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
											Dim isNewRow As Boolean = dataGridViewRow2.IsNewRow
											If Not isNewRow Then
												Dim flag4 As Boolean = String.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(dataGridViewRow2.Cells(2).Value, Nothing, "trim", New Object(-1) {}, Nothing, Nothing, Nothing)))
												If Not flag4 Then
													Dim flag5 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow2.Cells(0).Value, 0, False)
													If flag5 Then
														Dim num As Integer = Conversions.ToInteger(dataGridViewRow2.Cells(0).Value)
														Dim text As String = Conversions.ToString(dataGridViewRow2.Cells(3).Value)
														Dim num2 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(4).Value))
														Dim num3 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(5).Value))
														Dim text2 As String = Conversions.ToString(dataGridViewRow2.Cells(6).Value)
														Dim num4 As Decimal = New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(9).Value)))
														Dim list As New List(Of ValueTuple(Of String, String))()

														For Each t As ValueTuple(Of String, String, String, String, String, String) In array

															list.Add(New ValueTuple(Of String, String)(t.Item1, t.Item2))

														Next

														For Each t As ValueTuple(Of String, String, String) In array2

															list.Add(New ValueTuple(Of String, String)(t.Item1, t.Item2))

														Next

														Try
															For Each valueTuple As ValueTuple(Of String, String) In list
																Dim flag6 As Boolean = Operators.CompareString(valueTuple.Item1, "Product", False) = 0
																If Not flag6 Then
																	Dim text3 As String = String.Format("SELECT 1 FROM {0} WHERE {1} <> @id AND Barcode = @bc", valueTuple.Item1, valueTuple.Item2)
																	Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection, sqlTransaction)
																		sqlCommand.Parameters.AddWithValue("@id", num)
																		sqlCommand.Parameters.AddWithValue("@bc", text)
																		Dim flag7 As Boolean = sqlCommand.ExecuteScalar() IsNot Nothing
																		If flag7 Then
																			MessageBox.Show(String.Format("Barcode {0} already exists in {1}.", text, valueTuple), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																			Return
																		End If
																	End Using
																End If
															Next
														Finally
															Dim enumerator2 As List(Of ValueTuple(Of String, String)).Enumerator
															CType(enumerator2, IDisposable).Dispose()
														End Try
														For Each valueTuple2 As ValueTuple(Of String, String, String, String, String, String) In array
															Dim text4 As String = String.Format("UPDATE {0} SET {1}=@bc", valueTuple2.Item1, valueTuple2.Item3)
															Dim flag8 As Boolean = num2 > 0.0
															If flag8 Then
																text4 += String.Format(", {0}=@c", valueTuple2.Item4)
															End If
															Dim flag9 As Boolean = num3 > 0.0
															If flag9 Then
																text4 += String.Format(", {0}=@s", valueTuple2.Item5)
															End If
															Dim flag10 As Boolean = Decimal.Compare(num4, 0D) > 0
															If flag10 Then
																text4 += String.Format(", {0}=@q", valueTuple2.Item6)
															End If
															text4 += String.Format(" WHERE {0}=@id AND {1}=@old", valueTuple2.Item2, valueTuple2.Item3)
															Using sqlCommand2 As SqlCommand = New SqlCommand(text4, sqlConnection, sqlTransaction)
																sqlCommand2.Parameters.AddWithValue("@bc", text)
																sqlCommand2.Parameters.AddWithValue("@c", num2)
																sqlCommand2.Parameters.AddWithValue("@s", num3)
																sqlCommand2.Parameters.AddWithValue("@q", num4)
																sqlCommand2.Parameters.AddWithValue("@id", num)
																sqlCommand2.Parameters.AddWithValue("@old", text2)
																sqlCommand2.ExecuteNonQuery()
															End Using
														Next
														For Each valueTuple3 As ValueTuple(Of String, String, String) In array2
															Dim text5 As String = String.Format("UPDATE {0} SET {1}=@bc WHERE {2}=@id AND {3}=@old", New Object() { valueTuple3.Item1, valueTuple3.Item3, valueTuple3.Item2, valueTuple3.Item3 })
															Using sqlCommand3 As SqlCommand = New SqlCommand(text5, sqlConnection, sqlTransaction)
																sqlCommand3.Parameters.AddWithValue("@bc", text)
																sqlCommand3.Parameters.AddWithValue("@id", num)
																sqlCommand3.Parameters.AddWithValue("@old", text2)
																sqlCommand3.ExecuteNonQuery()
															End Using
														Next
														ModFunc.LogFunc(Me.lblUser.Text, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("updated the Product '", dataGridViewRow2.Cells(2).Value), "' having Product code '"), dataGridViewRow2.Cells(1).Value), "'")))
													Else
														Dim flag11 As Boolean = Me.InsertD_SaleProduct(dataGridViewRow2)
														If flag11 Then
															flag3 = True
															ModFunc.LogFunc(Me.lblUser.Text, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("added the new Product '", dataGridViewRow2.Cells(2).Value), "' having Product code '"), dataGridViewRow2.Cells(1).Value), "'")))
														Else
															flag3 = False
														End If
													End If
												End If
											End If
										Next
									Finally
										Dim enumerator As IEnumerator
										If TypeOf enumerator Is IDisposable Then
											TryCast(enumerator, IDisposable).Dispose()
										End If
									End Try
									Dim flag12 As Boolean = flag3
									If flag12 Then
										sqlTransaction.Commit()
									Else
										Dim flag13 As Boolean = MessageBox.Show("New product insert failed, Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
										If flag13 Then
											sqlTransaction.Commit()
										Else
											sqlTransaction.Rollback()
										End If
									End If
									MessageBox.Show("All products updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Catch ex As Exception
									sqlTransaction.Rollback()
									Throw
								End Try
							End Using
						End Using
						MyBase.Dispose()
					End If
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001B03 RID: 6915 RVA: 0x00014054 File Offset: 0x00012254
		Private Sub frmBulkPriceChange_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmPOSNewTuch.btnCategory_Click(RuntimeHelpers.GetObjectValue(Me.eventSender), e)
		End Sub

		' Token: 0x06001B04 RID: 6916 RVA: 0x00126D8C File Offset: 0x00124F8C
		Private Sub dgw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Dim flag As Boolean = Me.dgw.CurrentCell.ColumnIndex > 3
			If flag Then
				Dim textBox As TextBox = TryCast(e.Control, TextBox)
				Dim flag2 As Boolean = textBox IsNot Nothing
				If flag2 Then
					RemoveHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
					AddHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
				End If
			End If
		End Sub

		' Token: 0x06001B05 RID: 6917 RVA: 0x00126DF0 File Offset: 0x00124FF0
		Private Sub NumericDecimal_KeyPress(sender As Object, e As KeyPressEventArgs)
			e.KeyChar = Char.ToUpper(e.KeyChar)
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
					Dim flag4 As Boolean = (Me.dgw.CurrentCell.ColumnIndex = 3) And Not Char.IsDigit(e.KeyChar)
					If Not flag4 Then
						Dim flag5 As Boolean = Me.dgw.CurrentCell.ColumnIndex = 2
						If Not flag5 Then
							Dim flag6 As Boolean = Not Char.IsDigit(e.KeyChar)
							If flag6 Then
								e.Handled = True
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06001B06 RID: 6918 RVA: 0x00126EC0 File Offset: 0x001250C0
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Me.dgw.ClearSelection()
			Dim num As Integer = 1
			Dim num2 As Integer = 1
			Dim flag As Boolean = Me.dgw.CurrentCell.ColumnIndex = 5
			If flag Then
				num = 4
			End If
			Dim flag2 As Boolean = Me.dgw.CurrentCell.ColumnIndex = 9
			If flag2 Then
				num2 = 4
			End If
			Dim flag3 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex > 1 AndAlso Me.dgw.CurrentCell.ColumnIndex < 9
			Dim flag5 As Boolean
			If flag3 Then
				Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
				Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
				Dim flag4 As Boolean = columnIndex < Me.dgw.Columns.Count
				If flag4 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
				End If
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
				flag5 = True
			Else
				Dim flag6 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 9
				If flag6 Then
					Dim rowIndex2 As Integer = Me.dgw.CurrentCell.RowIndex
					Dim columnIndex2 As Integer = Me.dgw.CurrentCell.ColumnIndex
					Dim flag7 As Boolean = Operators.ConditionalCompareObjectEqual(Me.dgw.Rows(rowIndex2).Cells(0).Value, 0, False)
					If flag7 Then
						Me.AddNewRow()
					Else
						Dim flag8 As Boolean = rowIndex2 < Me.dgw.Rows.Count - 1
						If flag8 Then
							Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex2 + 1).Cells(3)
						Else
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
						End If
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End If
					flag5 = True
				Else
					Dim rowIndex3 As Integer = Me.dgw.CurrentCell.RowIndex
					Dim columnIndex3 As Integer = Me.dgw.CurrentCell.ColumnIndex
					Select Case keyData
						Case Keys.Left
							Dim flag9 As Boolean = columnIndex3 > 3
							If flag9 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex3 - num2)
								Me.dgw.BeginEdit(True)
								Return True
							End If
							Dim flag10 As Boolean = columnIndex3 = 3
							If flag10 Then
								Dim flag11 As Boolean = rowIndex3 > 0
								If flag11 Then
									Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 - 1).Cells(9)
									Me.dgw.BeginEdit(True)
									Return True
								End If
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(3)
								Me.dgw.BeginEdit(True)
								Return True
							End If
						Case Keys.Up
							Dim flag12 As Boolean = rowIndex3 > 0
							If flag12 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 - 1).Cells(columnIndex3)
								Me.dgw.BeginEdit(True)
								Return True
							End If
						Case Keys.Right
							Dim flag13 As Boolean = columnIndex3 < 9
							If flag13 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex3 + num)
								Me.dgw.BeginEdit(True)
								Me.dgw.ClearSelection()
								Return True
							End If
							Dim flag14 As Boolean = columnIndex3 >= 9
							If flag14 Then
								Dim flag15 As Boolean = rowIndex3 >= Me.dgw.Rows.Count - 1
								If flag15 Then
									Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
									Me.dgw.BeginEdit(True)
									Me.dgw.ClearSelection()
									Return True
								End If
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(3)
								Me.dgw.BeginEdit(True)
								Me.dgw.ClearSelection()
								Return True
							End If
						Case Keys.Down
							Dim flag16 As Boolean = rowIndex3 < Me.dgw.Rows.Count - 1
							If flag16 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(columnIndex3)
								Me.dgw.BeginEdit(True)
								Return True
							End If
					End Select
					flag5 = MyBase.ProcessCmdKey(msg, keyData)
				End If
			End If
			Return flag5
		End Function

		' Token: 0x06001B07 RID: 6919 RVA: 0x001273FC File Offset: 0x001255FC
		Private Sub frmBulkPriceChange_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.Control AndAlso e.KeyCode = Keys.U
			If flag Then
				Me.btnUpdatePrice.Focus()
				Me.btnUpdatePrice_Click(RuntimeHelpers.GetObjectValue(sender), e)
			End If
		End Sub

		' Token: 0x06001B08 RID: 6920 RVA: 0x00014073 File Offset: 0x00012273
		Private Sub btnNewItem_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x06001B09 RID: 6921 RVA: 0x00127440 File Offset: 0x00125640
		Private Sub AddNewRow()
			Me.dgw.ClearSelection()
			Dim num As Integer = Me.dgw.Rows.Add()
			Dim newRow As DataGridViewRow = Me.dgw.Rows(num)
			newRow.Cells(0).Value = 0
			newRow.Cells(1).Value = ""
			newRow.Cells(2).Value = ""
			newRow.Cells(2).[ReadOnly] = False
			newRow.Cells(3).[ReadOnly] = True
			newRow.Cells(3).Value = ""
			newRow.Cells(4).Value = 0
			newRow.Cells(5).Value = 0
			newRow.Cells(6).Value = ""
			newRow.Cells(7).Value = 0
			newRow.Cells(8).Value = 0
			newRow.Cells(9).Value = 0
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = newRow.Cells(2)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x06001B0A RID: 6922 RVA: 0x00127600 File Offset: 0x00125800
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

		' Token: 0x06001B0B RID: 6923 RVA: 0x001276E8 File Offset: 0x001258E8
		Public Function GenerateIDProd() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product WITH (NOLOCK) ORDER BY PID DESC", ModCommonClasses.con)
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

		' Token: 0x06001B0C RID: 6924 RVA: 0x00127854 File Offset: 0x00125A54
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06001B0D RID: 6925 RVA: 0x001278D8 File Offset: 0x00125AD8
		Public Function GenerateIDx() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ISNULL(MAX(ID), 0) ID FROM Product_OpeningStock WITH (NOLOCK)", ModCommonClasses.con)
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

		' Token: 0x06001B0E RID: 6926 RVA: 0x00127A44 File Offset: 0x00125C44
		Public Function InsertD_SaleProduct(row As DataGridViewRow) As Boolean
			Try
				Dim text As String = ""
				Dim num As Double = 0.0
				Dim text2 As String = ""
				Dim text3 As String = ""
				Dim num2 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(9).Value))
				Me.txtID_temp.Text = Me.GenerateIDProd()
				Dim text4 As String = "P-" + Me.GenerateIDProd()
				Me.BCodeDisplay()
				Dim text5 As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateIDx()))
				Dim flag As Boolean = Operators.CompareString(text5, "1000", False) = 0
				If flag Then
					MessageBox.Show(String.Format("Couldn't generate the barcode for product '{0}'", RuntimeHelpers.GetObjectValue(row.Cells("DataGridViewTextBoxColumn57").Value)))
					Return False
				End If
				Dim text6 As String = Me.txtBar.Text + text5
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text7 As String = "select unit from UnitMaster WHERE ISDEFAULT = 'Yes'"
				ModCommonClasses.cmd = New SqlCommand(text7)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					text = ModCommonClasses.rdr(0).ToString()
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text8 As String = "select Rate from TaxCat WHERE ISDEFAULT = 'Yes'"
				ModCommonClasses.cmd = New SqlCommand(text8)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
				If flag4 Then
					num = Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0)))
					Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag5 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text9 As String = "select stax_type from Defaulttaxtype WHERE id = '1'"
				ModCommonClasses.cmd = New SqlCommand(text9)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
				If flag6 Then
					text2 = ModCommonClasses.rdr(0).ToString()
					Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag7 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text10 As String = "select Ptax_type from Defaulttaxtype WHERE id = '1'"
				ModCommonClasses.cmd = New SqlCommand(text10)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
				If flag8 Then
					text3 = ModCommonClasses.rdr(0).ToString()
					Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag9 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text11 As String = "select Rate as DRate from tbl_DiscountDefault WHERE id = '1'"
				ModCommonClasses.cmd = New SqlCommand(text11)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag10 As Boolean = ModCommonClasses.rdr.Read()
				If flag10 Then
					Dim num3 As Double = Conversions.ToDouble(ModCommonClasses.rdr(0).ToString())
					Dim flag11 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag11 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text12 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
				ModCommonClasses.cmd = New SqlCommand(text12)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag12 As Boolean = ModCommonClasses.rdr.Read()
				If flag12 Then
					Dim text13 As String = ModCommonClasses.rdr(1).ToString()
					Dim num4 As Double = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
					Dim flag13 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag13 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text14 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "        Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen,loyality_mode,loyality_value) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d34,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d35)"
				ModCommonClasses.cmd = New SqlCommand(text14)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID_temp.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", text4)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(row.Cells("DataGridViewTextBoxColumn57").Value))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.lblCategoryId.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(row.Cells("DataGridViewTextBoxColumn57").Value))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(4).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d7", 0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d8", num / 2.0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d11", 0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d12", text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d13", text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d14", num / 2.0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d15", 0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d16", 0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d17", 0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d18", text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d19", 1)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d20", 1)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d34", "Yes")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d22", text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d23", text3)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.strPtax.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d25", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d28", 0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d29", 0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d30", DateTime.Today)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d31", 1)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d32", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d33", "per")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d35", "0.00")
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text15 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID_temp.Text + ",@d2)"
				ModCommonClasses.cmd = New SqlCommand(text15)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Prepare()
				Dim memoryStream As MemoryStream = New MemoryStream()
				Dim image As Image = Me.Photo.Image
				Dim bitmap As Bitmap = New Bitmap(image)
				bitmap.Save(memoryStream, ImageFormat.Jpeg)
				Dim buffer As Byte() = memoryStream.GetBuffer()
				Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
				sqlParameter.Value = buffer
				ModCommonClasses.cmd.Parameters.Add(sqlParameter)
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.cmd.Parameters.Clear()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text16 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
				ModCommonClasses.cmd = New SqlCommand(text16)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Prepare()
				ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID_temp.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", num2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d7", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d9", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d10", text6)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
				Dim flag14 As Boolean = Operators.CompareString(Me.strPtax.Text, "Inclusive", False) = 0
				Dim num5 As Double
				If flag14 Then
					num5 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(4).Value)), 2)), "0.00"))
				Else
					num5 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(4).Value)), 2)), "0.00"))
				End If
				ModCommonClasses.cmd.Parameters.AddWithValue("@d14", num5)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num5 * num2, 3)), "0.00"))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d17", "")
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.cmd.Parameters.Clear()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text17 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "        Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur, Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
				ModCommonClasses.cmd = New SqlCommand(text17)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Prepare()
				ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID_temp.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", num2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", text6)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d5", 0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d7", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d9", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d10", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d11", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(5).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "")
				ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(4).Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(Me.txtID_temp.Text))
				Me.Generate_GiftQR(text6)
				Dim memoryStream2 As MemoryStream = New MemoryStream()
				Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
				bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
				Dim buffer2 As Byte() = memoryStream2.GetBuffer()
				Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
				sqlParameter2.Value = buffer2
				ModCommonClasses.cmd.Parameters.AddWithValue("@d20", 0.0)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtID_temp.Text))
				ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.cmd.Parameters.Clear()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text18 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
				ModCommonClasses.cmd = New SqlCommand(text18)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_temp.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text19 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
				ModCommonClasses.cmd = New SqlCommand(text19)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_temp.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				ModCommonClasses.con.Close()
				Return False
			Finally
				ModCommonClasses.con.Close()
			End Try
			Return True
		End Function

		' Token: 0x06001B0F RID: 6927 RVA: 0x0001407D File Offset: 0x0001227D
		Private Sub settingdefault_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmProductDefault.lblform.Text = "frmProductRec1"
			MyProject.Forms.frmProductDefault.ShowDialog()
		End Sub

		' Token: 0x06001B10 RID: 6928 RVA: 0x00128C88 File Offset: 0x00126E88
		Public Function GetDefaultValues() As Boolean
			Dim text As String = ""
			Dim num As Double = 0.0
			Dim text2 As String = ""
			Dim text3 As String = ""
			Dim num2 As Double = 0.0
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text4 As String = "select unit from UnitMaster WHERE ISDEFAULT = 'Yes'"
			ModCommonClasses.cmd = New SqlCommand(text4)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				text = ModCommonClasses.rdr(0).ToString()
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			Dim text5 As String = "Following are the default values for " & vbCrLf + String.Format("UnitMaster = {0}", text) + vbCrLf
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text6 As String = "select Rate from TaxCat WHERE ISDEFAULT = 'Yes'"
			ModCommonClasses.cmd = New SqlCommand(text6)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
			If flag3 Then
				num = Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0)))
				Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag4 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			text5 = text5 + String.Format("TaxCat = {0}", num) + vbCrLf
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text7 As String = "select stax_type from Defaulttaxtype WHERE id = '1'"
			ModCommonClasses.cmd = New SqlCommand(text7)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
			If flag5 Then
				text2 = ModCommonClasses.rdr(0).ToString()
				Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag6 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			text5 = text5 + String.Format("Defaulttaxtype stax_type = {0}", text2) + vbCrLf
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text8 As String = "select Ptax_type from Defaulttaxtype WHERE id = '1'"
			ModCommonClasses.cmd = New SqlCommand(text8)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
			If flag7 Then
				text3 = ModCommonClasses.rdr(0).ToString()
				Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag8 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			text5 = text5 + String.Format("Defaulttaxtype Ptax_type = {0}", text3) + vbCrLf
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text9 As String = "select Rate as DRate from tbl_DiscountDefault WHERE id = '1'"
			ModCommonClasses.cmd = New SqlCommand(text9)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
			If flag9 Then
				num2 = Conversions.ToDouble(ModCommonClasses.rdr(0).ToString())
				Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag10 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			text5 = text5 + String.Format("DiscountDefaul = {0}", num2) + vbCrLf
			Dim text10 As String = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text11 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
			ModCommonClasses.cmd = New SqlCommand(text11)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
			If flag11 Then
				text10 = ModCommonClasses.rdr(1).ToString()
				Dim num3 As Double = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
				Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag12 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			text5 = text5 + String.Format("loyalty = {0}", text10) + vbCrLf
			Dim flag13 As Boolean = MessageBox.Show(text5 + "Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No
			Return Not flag13
		End Function

		' Token: 0x06001B11 RID: 6929 RVA: 0x00014073 File Offset: 0x00012273
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x06001B12 RID: 6930 RVA: 0x0001407D File Offset: 0x0001227D
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmProductDefault.lblform.Text = "frmProductRec1"
			MyProject.Forms.frmProductDefault.ShowDialog()
		End Sub

		' Token: 0x06001B13 RID: 6931 RVA: 0x00129100 File Offset: 0x00127300
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim text As String = ""
				Dim dataGridViewRow As DataGridViewRow = Nothing
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim isNewRow As Boolean = dataGridViewRow2.IsNewRow
						If Not isNewRow Then
							Dim num As Integer = CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value))))
							Dim text2 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(2).Value)).Trim()
							Dim text3 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value))
							Dim num2 As Decimal = New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(4).Value)))
							Dim num3 As Decimal = New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(5).Value)))
							Dim flag As Boolean = String.IsNullOrEmpty(text2)
							If flag Then
								Me.dgw.Rows.Remove(dataGridViewRow2)
								Exit For
							End If
							Dim flag2 As Boolean = num <> 0 AndAlso String.IsNullOrEmpty(text3)
							If flag2 Then
								text = "Barcode is required for existing product."
							Else
								Dim flag3 As Boolean = Decimal.Compare(num2, 0D) <= 0
								If flag3 Then
									text = "Purchase price must be greater than 0."
								Else
									Dim flag4 As Boolean = Decimal.Compare(num3, 0D) <= 0
									If flag4 Then
										text = "Sale price must be greater than 0."
									Else
										Dim flag5 As Boolean = Decimal.Compare(num3, num2) < 0
										If flag5 Then
											text = String.Format("Sale price ({0}) cannot be less than purchase price ({1}).", num3, num2)
										End If
									End If
								End If
							End If
							Dim flag6 As Boolean = Operators.CompareString(text, "", False) <> 0
							If flag6 Then
								dataGridViewRow = dataGridViewRow2
								Exit For
							End If
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag7 As Boolean = dataGridViewRow IsNot Nothing
				If flag7 Then
					MessageBox.Show(String.Concat(New String() { "Error at Row No: ", Conversions.ToString(dataGridViewRow.Index + 1), vbCrLf & "Product : ", Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)), " - ", Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value)), vbCrLf, text }), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag8 As Boolean = Not Me.GetDefaultValues()
					If Not flag8 Then
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Dim flag9 As Boolean = True
							Using sqlTransaction As SqlTransaction = sqlConnection.BeginTransaction()
								Try
									Dim array As ValueTuple(Of String, String, String, String, String, String)() = New ValueTuple(Of String, String, String, String, String, String)() { New ValueTuple(Of String, String, String, String, String, String)("Product", "PID", "Barcode", "CostPrice", "SellingPrice", "DefQty"), New ValueTuple(Of String, String, String, String, String, String)("Temp_Stock", "ProductID", "Barcode", "PPrice", "SalePrice", "Qty"), New ValueTuple(Of String, String, String, String, String, String)("Product_OpeningStock", "ProductID", "Barcode", "PPrice", "SalePrice", "Qty") }
									Dim array2 As ValueTuple(Of String, String, String)() = New ValueTuple(Of String, String, String)() { New ValueTuple(Of String, String, String)("Stock_Product", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("Quotation_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("Estimate_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("PurchaseOrder_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("PurchaseReturn_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("Stock_Store_Join", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("StockAdjustment_Store", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("Invoice_Product", "ProductID", "Barcode"), New ValueTuple(Of String, String, String)("SalesReturn_Join", "ProductID", "Barcode") }
									Try
										For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
											Dim dataGridViewRow3 As DataGridViewRow = CType(obj2, DataGridViewRow)
											Dim isNewRow2 As Boolean = dataGridViewRow3.IsNewRow
											If Not isNewRow2 Then
												Dim flag10 As Boolean = String.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(dataGridViewRow3.Cells(2).Value, Nothing, "trim", New Object(-1) {}, Nothing, Nothing, Nothing)))
												If Not flag10 Then
													Dim flag11 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow3.Cells(0).Value, 0, False)
													If flag11 Then
														Dim num4 As Integer = Conversions.ToInteger(dataGridViewRow3.Cells(0).Value)
														Dim text4 As String = Conversions.ToString(dataGridViewRow3.Cells(3).Value)
														Dim num5 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value))
														Dim num6 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(5).Value))
														Dim text5 As String = Conversions.ToString(dataGridViewRow3.Cells(6).Value)
														Dim num7 As Decimal = New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(9).Value)))
														Dim list As New List(Of ValueTuple(Of String, String))()

														For Each t As ValueTuple(Of String, String, String, String, String, String) In array

															list.Add(New ValueTuple(Of String, String)(t.Item1, t.Item2))

														Next

														For Each t As ValueTuple(Of String, String, String) In array2

															list.Add(New ValueTuple(Of String, String)(t.Item1, t.Item2))

														Next

														Try
															For Each valueTuple As ValueTuple(Of String, String) In list
																Dim flag12 As Boolean = Operators.CompareString(valueTuple.Item1, "Product", False) = 0
																If Not flag12 Then
																	Dim text6 As String = String.Format("SELECT 1 FROM {0} WHERE {1} <> @id AND Barcode = @bc", valueTuple.Item1, valueTuple.Item2)
																	Using sqlCommand As SqlCommand = New SqlCommand(text6, sqlConnection, sqlTransaction)
																		sqlCommand.Parameters.AddWithValue("@id", num4)
																		sqlCommand.Parameters.AddWithValue("@bc", text4)
																		Dim flag13 As Boolean = sqlCommand.ExecuteScalar() IsNot Nothing
																		If flag13 Then
																			MessageBox.Show(String.Format("Barcode {0} already exists in {1} {2}.", text4, valueTuple, Conversions.ToString(dataGridViewRow3.Cells(2).Value)), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																			Return
																		End If
																	End Using
																End If
															Next
														Finally
															Dim enumerator3 As List(Of ValueTuple(Of String, String)).Enumerator
															CType(enumerator3, IDisposable).Dispose()
														End Try
														For Each valueTuple2 As ValueTuple(Of String, String, String, String, String, String) In array
															Dim text7 As String = String.Format("UPDATE {0} SET {1}=@bc", valueTuple2.Item1, valueTuple2.Item3)
															Dim flag14 As Boolean = num5 > 0.0
															If flag14 Then
																text7 += String.Format(", {0}=@c", valueTuple2.Item4)
															End If
															Dim flag15 As Boolean = num6 > 0.0
															If flag15 Then
																text7 += String.Format(", {0}=@s", valueTuple2.Item5)
																Dim flag16 As Boolean = Operators.CompareString(valueTuple2.Item1, "Temp_Stock", False) = 0
																If flag16 Then
																	text7 += ", SPrice=@s"
																End If
															End If
															Dim flag17 As Boolean = Decimal.Compare(num7, 0D) > 0
															If flag17 Then
																text7 += String.Format(", {0}=@q", valueTuple2.Item6)
															End If
															text7 += String.Format(" WHERE {0}=@id", valueTuple2.Item2)
															Dim flag18 As Boolean = Operators.CompareString(valueTuple2.Item1, "Product", False) <> 0
															If flag18 Then
																text7 += String.Format(" And {0}=@old", valueTuple2.Item3)
															End If
															Using sqlCommand2 As SqlCommand = New SqlCommand(text7, sqlConnection, sqlTransaction)
																sqlCommand2.Parameters.AddWithValue("@bc", text4)
																sqlCommand2.Parameters.AddWithValue("@c", num5)
																sqlCommand2.Parameters.AddWithValue("@s", num6)
																sqlCommand2.Parameters.AddWithValue("@q", num7)
																sqlCommand2.Parameters.AddWithValue("@id", num4)
																Dim flag19 As Boolean = Operators.CompareString(valueTuple2.Item1, "Product", False) <> 0
																If flag19 Then
																	sqlCommand2.Parameters.AddWithValue("@old", text5)
																End If
																Dim num8 As Integer = sqlCommand2.ExecuteNonQuery()
															End Using
														Next
														For Each valueTuple3 As ValueTuple(Of String, String, String) In array2
															Dim text8 As String = String.Format("UPDATE {0} SET {1}=@bc WHERE {2}=@id And {3}=@old", New Object() { valueTuple3.Item1, valueTuple3.Item3, valueTuple3.Item2, valueTuple3.Item3 })
															Using sqlCommand3 As SqlCommand = New SqlCommand(text8, sqlConnection, sqlTransaction)
																sqlCommand3.Parameters.AddWithValue("@bc", text4)
																sqlCommand3.Parameters.AddWithValue("@id", num4)
																sqlCommand3.Parameters.AddWithValue("@old", text5)
																sqlCommand3.ExecuteNonQuery()
															End Using
														Next
														ModFunc.LogFunc(Me.lblUser.Text, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("updated the Product '", dataGridViewRow3.Cells(2).Value), "' having Product code '"), dataGridViewRow3.Cells(1).Value), "'")))
													Else
														Dim flag20 As Boolean = Me.InsertD_SaleProduct(dataGridViewRow3)
														If flag20 Then
															flag9 = True
															ModFunc.LogFunc(Me.lblUser.Text, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("added the new Product '", dataGridViewRow3.Cells(2).Value), "' having Product code '"), dataGridViewRow3.Cells(1).Value), "'")))
														Else
															flag9 = False
														End If
													End If
												End If
											End If
										Next
									Finally
										Dim enumerator2 As IEnumerator
										If TypeOf enumerator2 Is IDisposable Then
											TryCast(enumerator2, IDisposable).Dispose()
										End If
									End Try
									Dim flag21 As Boolean = flag9
									If flag21 Then
										sqlTransaction.Commit()
									Else
										Dim flag22 As Boolean = MessageBox.Show("New product insert failed, Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
										If flag22 Then
											sqlTransaction.Commit()
										Else
											sqlTransaction.Rollback()
										End If
									End If
									MessageBox.Show("All products updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Catch ex As Exception
									sqlTransaction.Rollback()
									Throw
								End Try
							End Using
						End Using
						MyBase.Dispose()
					End If
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04000AA8 RID: 2728
		Public eventSender As Object
	End Class
End Namespace
