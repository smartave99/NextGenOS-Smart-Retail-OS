Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200008C RID: 140
	<DesignerGenerated()>
	Public Partial Class frmTaxSettingsNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060016FF RID: 5887 RVA: 0x00012371 File Offset: 0x00010571
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			Me.prevCell = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000936 RID: 2358
		' (get) Token: 0x06001702 RID: 5890 RVA: 0x0001239B File Offset: 0x0001059B
		' (set) Token: 0x06001703 RID: 5891 RVA: 0x000FC7A0 File Offset: 0x000FA9A0
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim eventHandler As EventHandler = AddressOf Me.dgw_CurrentCellChanged
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CurrentCellChanged, eventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CurrentCellChanged, eventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000937 RID: 2359
		' (get) Token: 0x06001704 RID: 5892 RVA: 0x000123A5 File Offset: 0x000105A5
		' (set) Token: 0x06001705 RID: 5893 RVA: 0x000123AF File Offset: 0x000105AF
		Public Overridable Property Photo As PictureBox

		' Token: 0x17000938 RID: 2360
		' (get) Token: 0x06001706 RID: 5894 RVA: 0x000123B8 File Offset: 0x000105B8
		' (set) Token: 0x06001707 RID: 5895 RVA: 0x000123C2 File Offset: 0x000105C2
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000939 RID: 2361
		' (get) Token: 0x06001708 RID: 5896 RVA: 0x000123CB File Offset: 0x000105CB
		' (set) Token: 0x06001709 RID: 5897 RVA: 0x000FC800 File Offset: 0x000FAA00
		Private _btnNewSupplier As Button
		Friend Overridable Property btnNewSupplier As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNewSupplier
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._btnNewSupplier
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNewSupplier = value
				button = Me._btnNewSupplier
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700093A RID: 2362
		' (get) Token: 0x0600170A RID: 5898 RVA: 0x000123D5 File Offset: 0x000105D5
		' (set) Token: 0x0600170B RID: 5899 RVA: 0x000123DF File Offset: 0x000105DF
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700093B RID: 2363
		' (get) Token: 0x0600170C RID: 5900 RVA: 0x000123E8 File Offset: 0x000105E8
		' (set) Token: 0x0600170D RID: 5901 RVA: 0x000123F2 File Offset: 0x000105F2
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x1700093C RID: 2364
		' (get) Token: 0x0600170E RID: 5902 RVA: 0x000123FB File Offset: 0x000105FB
		' (set) Token: 0x0600170F RID: 5903 RVA: 0x00012405 File Offset: 0x00010605
		Friend Overridable Property Label17 As Label

		' Token: 0x1700093D RID: 2365
		' (get) Token: 0x06001710 RID: 5904 RVA: 0x0001240E File Offset: 0x0001060E
		' (set) Token: 0x06001711 RID: 5905 RVA: 0x00012418 File Offset: 0x00010618
		Friend Overridable Property Panel7 As Panel

		' Token: 0x1700093E RID: 2366
		' (get) Token: 0x06001712 RID: 5906 RVA: 0x00012421 File Offset: 0x00010621
		' (set) Token: 0x06001713 RID: 5907 RVA: 0x0001242B File Offset: 0x0001062B
		Friend Overridable Property Label19 As Label

		' Token: 0x1700093F RID: 2367
		' (get) Token: 0x06001714 RID: 5908 RVA: 0x00012434 File Offset: 0x00010634
		' (set) Token: 0x06001715 RID: 5909 RVA: 0x000FC844 File Offset: 0x000FAA44
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000940 RID: 2368
		' (get) Token: 0x06001716 RID: 5910 RVA: 0x0001243E File Offset: 0x0001063E
		' (set) Token: 0x06001717 RID: 5911 RVA: 0x00012448 File Offset: 0x00010648
		Friend Overridable Property Label18 As Label

		' Token: 0x17000941 RID: 2369
		' (get) Token: 0x06001718 RID: 5912 RVA: 0x00012451 File Offset: 0x00010651
		' (set) Token: 0x06001719 RID: 5913 RVA: 0x0001245B File Offset: 0x0001065B
		Friend Overridable Property Label21 As Label

		' Token: 0x17000942 RID: 2370
		' (get) Token: 0x0600171A RID: 5914 RVA: 0x00012464 File Offset: 0x00010664
		' (set) Token: 0x0600171B RID: 5915 RVA: 0x000FC888 File Offset: 0x000FAA88
		Private _txtTopResult As TextBox
		Friend Overridable Property txtTopResult As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTopResult
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtTopResult_TextChanged
				Dim textBox As TextBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtTopResult = value
				textBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000943 RID: 2371
		' (get) Token: 0x0600171C RID: 5916 RVA: 0x0001246E File Offset: 0x0001066E
		' (set) Token: 0x0600171D RID: 5917 RVA: 0x000FC8CC File Offset: 0x000FAACC
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

		' Token: 0x17000944 RID: 2372
		' (get) Token: 0x0600171E RID: 5918 RVA: 0x00012478 File Offset: 0x00010678
		' (set) Token: 0x0600171F RID: 5919 RVA: 0x000FC910 File Offset: 0x000FAB10
		Private _txtSearchProduct As TextBox
		Friend Overridable Property txtSearchProduct As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchProduct_TextChanged
				Dim textBox As TextBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchProduct = value
				textBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000945 RID: 2373
		' (get) Token: 0x06001720 RID: 5920 RVA: 0x00012482 File Offset: 0x00010682
		' (set) Token: 0x06001721 RID: 5921 RVA: 0x0001248C File Offset: 0x0001068C
		Friend Overridable Property Label1 As Label

		' Token: 0x17000946 RID: 2374
		' (get) Token: 0x06001722 RID: 5922 RVA: 0x00012495 File Offset: 0x00010695
		' (set) Token: 0x06001723 RID: 5923 RVA: 0x0001249F File Offset: 0x0001069F
		Friend Overridable Property Button2 As Button

		' Token: 0x17000947 RID: 2375
		' (get) Token: 0x06001724 RID: 5924 RVA: 0x000124A8 File Offset: 0x000106A8
		' (set) Token: 0x06001725 RID: 5925 RVA: 0x000124B2 File Offset: 0x000106B2
		Friend Overridable Property Label2 As Label

		' Token: 0x17000948 RID: 2376
		' (get) Token: 0x06001726 RID: 5926 RVA: 0x000124BB File Offset: 0x000106BB
		' (set) Token: 0x06001727 RID: 5927 RVA: 0x000124C5 File Offset: 0x000106C5
		Friend Overridable Property lblId As Label

		' Token: 0x17000949 RID: 2377
		' (get) Token: 0x06001728 RID: 5928 RVA: 0x000124CE File Offset: 0x000106CE
		' (set) Token: 0x06001729 RID: 5929 RVA: 0x000124D8 File Offset: 0x000106D8
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700094A RID: 2378
		' (get) Token: 0x0600172A RID: 5930 RVA: 0x000124E1 File Offset: 0x000106E1
		' (set) Token: 0x0600172B RID: 5931 RVA: 0x000124EB File Offset: 0x000106EB
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700094B RID: 2379
		' (get) Token: 0x0600172C RID: 5932 RVA: 0x000124F4 File Offset: 0x000106F4
		' (set) Token: 0x0600172D RID: 5933 RVA: 0x000124FE File Offset: 0x000106FE
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700094C RID: 2380
		' (get) Token: 0x0600172E RID: 5934 RVA: 0x00012507 File Offset: 0x00010707
		' (set) Token: 0x0600172F RID: 5935 RVA: 0x00012511 File Offset: 0x00010711
		Friend Overridable Property Column22 As DataGridViewButtonColumn

		' Token: 0x1700094D RID: 2381
		' (get) Token: 0x06001730 RID: 5936 RVA: 0x0001251A File Offset: 0x0001071A
		' (set) Token: 0x06001731 RID: 5937 RVA: 0x00012524 File Offset: 0x00010724
		Friend Overridable Property Column2 As DataGridViewButtonColumn

		' Token: 0x1700094E RID: 2382
		' (get) Token: 0x06001732 RID: 5938 RVA: 0x0001252D File Offset: 0x0001072D
		' (set) Token: 0x06001733 RID: 5939 RVA: 0x00012537 File Offset: 0x00010737
		Friend Overridable Property cmbSearchCat As ComboBox

		' Token: 0x06001734 RID: 5940 RVA: 0x00012540 File Offset: 0x00010740
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06001735 RID: 5941 RVA: 0x000FC954 File Offset: 0x000FAB54
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " id,RTRIM(PurchaseTax),RTRIM(SalesTax) from Setting "
				Dim flag As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag Then
					text += " WHERE RTrim(PurchaseTax) LIKE @search"
				End If
				text += " ORDER BY id DESC"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				Dim flag2 As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag2 Then
					ModCommonClasses.cmd.Parameters.AddWithValue("@search", "%" + Me.txtSearchProduct.Text.Trim() + "%")
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
					Me.dgw.Rows(num).Cells(3).Value = "Update"
					Me.dgw.Rows(num).Cells(4).Value = "Delete"
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim flag3 As Boolean = Me.dgw.RowCount > 0
				If flag3 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001736 RID: 5942 RVA: 0x000FCBC8 File Offset: 0x000FADC8
		Private Sub dgw_CurrentCellChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.prevCell IsNot Nothing
			If flag Then
				Me.prevCell.Style.BackColor = Color.White
			End If
			Dim flag2 As Boolean = Me.dgw.CurrentCell IsNot Nothing
			If flag2 Then
				Me.dgw.CurrentCell.Style.BackColor = Color.Yellow
				Me.prevCell = Me.dgw.CurrentCell
			End If
		End Sub

		' Token: 0x06001737 RID: 5943 RVA: 0x000FCC3C File Offset: 0x000FAE3C
		Public Function MoveToNextAndClear() As Boolean
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim textBox As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			Dim flag As Boolean = textBox IsNot Nothing
			If flag Then
				textBox.SelectionStart = 0
				textBox.SelectionLength = textBox.Text.Length
				Application.DoEvents()
			End If
			Return True
		End Function

		' Token: 0x06001738 RID: 5944 RVA: 0x000FCCA4 File Offset: 0x000FAEA4
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Dim flag As Boolean = Not Me.txtSearchProduct.Focused And Not Me.txtTopResult.Focused
			If flag Then
				Dim flag2 As Boolean = keyData = Keys.[Return]
				If flag2 Then
					Me.dgw.ClearSelection()
					Dim num As Integer = 1
					Dim num2 As Integer = 1
					Dim flag3 As Boolean = Me.dgw.CurrentCell IsNot Nothing
					If flag3 Then
						Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
						Dim flag4 As Boolean = keyData = Keys.[Return] AndAlso columnIndex = 4
						If flag4 Then
							Me.DeleteCategory(rowIndex, columnIndex)
							Return True
						End If
						Dim flag5 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex > 0 AndAlso Me.dgw.CurrentCell.ColumnIndex < 3
						If flag5 Then
							Dim flag6 As Boolean = columnIndex = 1 AndAlso msg.Msg > 0
							If flag6 Then
								Me.dgw.EndEdit()
								Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
								Me.dgw.Refresh()
								Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(rowIndex)
								MyProject.Forms.frmGstNonGst.currentRow = rowIndex
								MyProject.Forms.frmGstNonGst.currentColumn = columnIndex
								MyProject.Forms.frmGstNonGst.Owner = Me
								MyProject.Forms.frmGstNonGst.ShowDialog()
								Return True
							End If
							Dim flag7 As Boolean = columnIndex = 2 AndAlso msg.Msg > 0
							If flag7 Then
								Me.dgw.EndEdit()
								Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
								Me.dgw.Refresh()
								Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.Rows(rowIndex)
								MyProject.Forms.frmGstNonGst.currentRow = rowIndex
								MyProject.Forms.frmGstNonGst.currentColumn = columnIndex
								MyProject.Forms.frmGstNonGst.Owner = Me
								MyProject.Forms.frmGstNonGst.ShowDialog()
								Return True
							End If
							Dim flag8 As Boolean = columnIndex < Me.dgw.Columns.Count
							If flag8 Then
								Me.dgw.Focus()
								Me.dgw.[Select]()
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
							End If
							Return Me.MoveToNextAndClear()
						Else
							Dim flag9 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 3
							If flag9 Then
								Dim flag10 As Boolean = Operators.ConditionalCompareObjectGreaterEqual(Me.dgw.Rows(rowIndex).Cells(0).Value, 0, False)
								If Not flag10 Then
									Return True
								End If
								Dim flag11 As Boolean = False
								Me.InsertNewSubCategory(rowIndex, columnIndex, flag11)
								Dim flag12 As Boolean = flag11
								If flag12 Then
									Dim flag13 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
									If flag13 Then
										Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(1)
									Else
										Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
									End If
									Return Me.MoveToNextAndClear()
								End If
								Return True
							Else
								Select Case keyData
									Case Keys.Left
										Dim flag14 As Boolean = columnIndex > 4
										If flag14 Then
											Dim flag15 As Boolean = Not Me.dgw.Rows(rowIndex).Cells(columnIndex - num2).Visible
											If flag15 Then
												num2 += 1
											End If
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex - num2)
										Else
											Dim flag16 As Boolean = columnIndex = 4
											If flag16 Then
												Dim flag17 As Boolean = rowIndex > 0
												If flag17 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex - 1).Cells(15)
												Else
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(1)
												End If
											End If
										End If
										Return Me.MoveToNextAndClear()
									Case Keys.Up
										Dim flag18 As Boolean = rowIndex > 0
										If flag18 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex - 1).Cells(columnIndex)
											Return Me.MoveToNextAndClear()
										End If
									Case Keys.Right
										Dim flag19 As Boolean = columnIndex < 4
										If flag19 Then
											Dim flag20 As Boolean = Not Me.dgw.Rows(rowIndex).Cells(columnIndex + num).Visible
											If flag20 Then
												num += 1
											End If
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
										Else
											Dim flag21 As Boolean = columnIndex = 4
											If flag21 Then
												Dim flag22 As Boolean = rowIndex >= Me.dgw.Rows.Count - 1
												If flag22 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
												Else
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(1)
												End If
											End If
										End If
										Return Me.MoveToNextAndClear()
									Case Keys.Down
										Dim flag23 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
										If flag23 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(columnIndex)
											Return Me.MoveToNextAndClear()
										End If
								End Select
								Dim flag24 As Boolean = Not Me.txtSearchProduct.Focused
								If flag24 Then
									Me.dgw.BeginEdit(True)
									Me.dgw.ClearSelection()
								End If
							End If
						End If
					End If
				End If
			Else
				Dim flag25 As Boolean = keyData = Keys.[Return]
				If flag25 Then
					Dim flag26 As Boolean = Me.dgw.RowCount > 0
					If flag26 Then
						Dim focused As Boolean = Me.txtSearchProduct.Focused
						If focused Then
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
						End If
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End If
				End If
			End If
			Return MyBase.ProcessCmdKey(msg, keyData)
		End Function

		' Token: 0x06001739 RID: 5945 RVA: 0x000FD3B0 File Offset: 0x000FB5B0
		Private Sub AddNewRow()
			For Each row As DataGridViewRow In Me.dgw.Rows
				If row.Cells(0).Tag IsNot Nothing AndAlso Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(0).Tag)) >= 0.0 Then
					MessageBox.Show("A new row already exists. Please save it before adding another.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.dgw.ClearSelection()
					MyBase.BeginInvoke(New MethodInvoker(Sub()
						Me.dgw.Focus()
						Me.dgw.CurrentCell = row.Cells(1)
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End Sub))
					Return
				End If
			Next
			Me.dgw.ClearSelection()
			Dim num As Integer = Me.dgw.Rows.Add()
			Dim newRow As DataGridViewRow = Me.dgw.Rows(num)
			newRow.Cells(0).Value = 0
			newRow.Cells(1).Value = ""
			newRow.Cells(2).Value = ""
			newRow.Cells(3).Value = "Save"
			Me.lblId.Text = "0"
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New MethodInvoker(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = newRow.Cells(1)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x0600173A RID: 5946 RVA: 0x000FD594 File Offset: 0x000FB794
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim rowIndex As Integer = e.RowIndex
			Dim columnIndex As Integer = e.ColumnIndex
			Dim flag As Boolean = False
			Me.InsertNewSubCategory(rowIndex, columnIndex, flag)
			Me.DeleteCategory(e.RowIndex, e.ColumnIndex)
		End Sub

		' Token: 0x0600173B RID: 5947 RVA: 0x000FD5CC File Offset: 0x000FB7CC
		Public Sub SetFocustoCurrentCell(rowindex As Integer, colindex As Integer)
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(rowindex).Cells(colindex)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x0600173C RID: 5948 RVA: 0x000FD608 File Offset: 0x000FB808
		Public Sub InsertNewSubCategory(RowIndex As Integer, ColumnIndex As Integer, ByRef isUpdate As Boolean)
			Dim flag As Boolean = ColumnIndex = Me.dgw.Columns(3).Index AndAlso RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					ModCommonClasses.con.Close()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells(1).Value.ToString())) = 0
					If flag4 Then
						MessageBox.Show("Please select purchase tax", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						NewLateBinding.LateCall(NewLateBinding.LateGet(dataGridViewRow.Cells(1).Value, Nothing, "Text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing, True)
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells(2).Value.ToString())) = 0
						If flag5 Then
							MessageBox.Show("Please select sales tax", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							NewLateBinding.LateCall(NewLateBinding.LateGet(dataGridViewRow.Cells(1).Value, Nothing, "Text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing, True)
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select count(*) from Setting Having count(*) >= 1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(1).Value.ToString().Trim())
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
							If flag6 Then
								MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag7 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								Dim value As Object = dataGridViewRow.Cells(3).Value
								Dim text3 As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
								Dim objectValue As Object = RuntimeHelpers.GetObjectValue(If((Operators.CompareString(text3, "Save", False) <> 0), Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)), Me.lblId.Text))
								Dim text4 As String = (If(dataGridViewRow.Cells(1).Value, "")).ToString().Trim()
								Dim text5 As String = (If(dataGridViewRow.Cells(2).Value, "")).ToString().Trim()
								Dim text6 As String = "insert into Setting(PurchaseTax,SalesTax) VALUES (@d1,@d2)"
								Dim text7 As String = "Update Setting set PurchaseTax=@d1,SalesTax=@d2 where ID=@ID"
								Dim text8 As String = If((Operators.CompareString(text3, "Save", False) = 0), text6, text7)
								Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
									Using sqlCommand As SqlCommand = New SqlCommand(text8, sqlConnection)
										sqlCommand.Parameters.AddWithValue("@d1", text4)
										sqlCommand.Parameters.AddWithValue("@d2", text5)
										sqlCommand.Parameters.AddWithValue("@ID", RuntimeHelpers.GetObjectValue(objectValue))
										sqlConnection.Open()
										sqlCommand.ExecuteNonQuery()
									End Using
								End Using
								MessageBox.Show("Record " + If((Operators.CompareString(text3, "Save", False) = 0), "inserted", "updated") + " successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Dim flag8 As Boolean = Operators.CompareString(text3, "Save", False) = 0
								If flag8 Then
									Me.AddNewRow()
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600173D RID: 5949 RVA: 0x000FDA84 File Offset: 0x000FBC84
		Public Sub DeleteCategory(RowIndex As Integer, ColumnIndex As Integer)
			Dim flag As Boolean = ColumnIndex <> Me.dgw.Columns(4).Index OrElse RowIndex < 0
			If Not flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
				Dim num As Integer = CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))))
				Dim value As Object = dataGridViewRow.Cells(4).Value
				Dim text As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
				Dim flag2 As Boolean = Operators.CompareString(text, "Delete", False) <> 0
				If Not flag2 Then
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete this Record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
					Dim flag3 As Boolean = dialogResult = DialogResult.No
					If Not flag3 Then
						dataGridViewRow.Cells(3).Value = "Save"
						Try
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								Using sqlCommand As SqlCommand = New SqlCommand("delete from Setting where ID=@ID", sqlConnection)
									sqlCommand.Parameters.AddWithValue("@ID", num)
									sqlConnection.Open()
									Dim num2 As Integer = sqlCommand.ExecuteNonQuery()
									Dim flag4 As Boolean = num2 > 0
									If flag4 Then
										MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.Getdata()
										Me.Reset()
									Else
										MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.Reset()
									End If
								End Using
							End Using
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600173E RID: 5950 RVA: 0x00012552 File Offset: 0x00010752
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x0600173F RID: 5951 RVA: 0x000FDC78 File Offset: 0x000FBE78
		Private Sub txtTopResult_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Dim flag As Boolean = Not String.IsNullOrEmpty(Me.txtTopResult.Text.Trim())
			If flag Then
				Me.Getdata()
			End If
		End Sub

		' Token: 0x06001740 RID: 5952 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub Reset()
		End Sub

		' Token: 0x06001741 RID: 5953 RVA: 0x000FDCAC File Offset: 0x000FBEAC
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkSelectAll.Checked
			If checked Then
				Me.dgw.SelectAll()
			Else
				Me.dgw.ClearSelection()
			End If
		End Sub

		' Token: 0x06001742 RID: 5954 RVA: 0x0001255C File Offset: 0x0001075C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06001743 RID: 5955 RVA: 0x0001255C File Offset: 0x0001075C
		Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Me.Getdata()
		End Sub

		' Token: 0x06001744 RID: 5956 RVA: 0x000FDCE8 File Offset: 0x000FBEE8
		Friend Async Sub UpdateYesNo(currentRow As Integer, currentColumn As Integer, selectedType As String)
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = selectedType
			Dim nextCol As Integer = currentColumn + 1
			Dim flag As Boolean = nextCol < Me.dgw.Columns.Count
			If flag Then
				Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(nextCol)
			End If
			Me.dgw.Focus()
			Application.DoEvents()
			Await Task.Delay(50)
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim editingControl As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			If editingControl IsNot Nothing Then
				editingControl.SelectionStart = 0
				editingControl.SelectionLength = editingControl.Text.Length
			End If
		End Sub

		' Token: 0x040008B5 RID: 2229
		Public eventSender As Object

		' Token: 0x040008B6 RID: 2230
		Private prevCell As DataGridViewCell
	End Class
End Namespace
