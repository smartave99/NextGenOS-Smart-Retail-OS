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
	' Token: 0x02000091 RID: 145
	<DesignerGenerated()>
	Public Partial Class frmTaxCategoryNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600174E RID: 5966 RVA: 0x00012594 File Offset: 0x00010794
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			Me.prevCell = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700094F RID: 2383
		' (get) Token: 0x06001751 RID: 5969 RVA: 0x000125BE File Offset: 0x000107BE
		' (set) Token: 0x06001752 RID: 5970 RVA: 0x000FF304 File Offset: 0x000FD504
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdState_KeyUp
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CurrentCellChanged, eventHandler
					RemoveHandler dataGridView.KeyUp, keyEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CurrentCellChanged, eventHandler
					AddHandler dataGridView.KeyUp, keyEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000950 RID: 2384
		' (get) Token: 0x06001753 RID: 5971 RVA: 0x000125C8 File Offset: 0x000107C8
		' (set) Token: 0x06001754 RID: 5972 RVA: 0x000125D2 File Offset: 0x000107D2
		Public Overridable Property Photo As PictureBox

		' Token: 0x17000951 RID: 2385
		' (get) Token: 0x06001755 RID: 5973 RVA: 0x000125DB File Offset: 0x000107DB
		' (set) Token: 0x06001756 RID: 5974 RVA: 0x000125E5 File Offset: 0x000107E5
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000952 RID: 2386
		' (get) Token: 0x06001757 RID: 5975 RVA: 0x000125EE File Offset: 0x000107EE
		' (set) Token: 0x06001758 RID: 5976 RVA: 0x000FF380 File Offset: 0x000FD580
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

		' Token: 0x17000953 RID: 2387
		' (get) Token: 0x06001759 RID: 5977 RVA: 0x000125F8 File Offset: 0x000107F8
		' (set) Token: 0x0600175A RID: 5978 RVA: 0x00012602 File Offset: 0x00010802
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000954 RID: 2388
		' (get) Token: 0x0600175B RID: 5979 RVA: 0x0001260B File Offset: 0x0001080B
		' (set) Token: 0x0600175C RID: 5980 RVA: 0x00012615 File Offset: 0x00010815
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17000955 RID: 2389
		' (get) Token: 0x0600175D RID: 5981 RVA: 0x0001261E File Offset: 0x0001081E
		' (set) Token: 0x0600175E RID: 5982 RVA: 0x00012628 File Offset: 0x00010828
		Friend Overridable Property Label17 As Label

		' Token: 0x17000956 RID: 2390
		' (get) Token: 0x0600175F RID: 5983 RVA: 0x00012631 File Offset: 0x00010831
		' (set) Token: 0x06001760 RID: 5984 RVA: 0x0001263B File Offset: 0x0001083B
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17000957 RID: 2391
		' (get) Token: 0x06001761 RID: 5985 RVA: 0x00012644 File Offset: 0x00010844
		' (set) Token: 0x06001762 RID: 5986 RVA: 0x0001264E File Offset: 0x0001084E
		Friend Overridable Property Label19 As Label

		' Token: 0x17000958 RID: 2392
		' (get) Token: 0x06001763 RID: 5987 RVA: 0x00012657 File Offset: 0x00010857
		' (set) Token: 0x06001764 RID: 5988 RVA: 0x000FF3C4 File Offset: 0x000FD5C4
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

		' Token: 0x17000959 RID: 2393
		' (get) Token: 0x06001765 RID: 5989 RVA: 0x00012661 File Offset: 0x00010861
		' (set) Token: 0x06001766 RID: 5990 RVA: 0x0001266B File Offset: 0x0001086B
		Friend Overridable Property Label18 As Label

		' Token: 0x1700095A RID: 2394
		' (get) Token: 0x06001767 RID: 5991 RVA: 0x00012674 File Offset: 0x00010874
		' (set) Token: 0x06001768 RID: 5992 RVA: 0x0001267E File Offset: 0x0001087E
		Friend Overridable Property Label21 As Label

		' Token: 0x1700095B RID: 2395
		' (get) Token: 0x06001769 RID: 5993 RVA: 0x00012687 File Offset: 0x00010887
		' (set) Token: 0x0600176A RID: 5994 RVA: 0x000FF408 File Offset: 0x000FD608
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

		' Token: 0x1700095C RID: 2396
		' (get) Token: 0x0600176B RID: 5995 RVA: 0x00012691 File Offset: 0x00010891
		' (set) Token: 0x0600176C RID: 5996 RVA: 0x000FF44C File Offset: 0x000FD64C
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

		' Token: 0x1700095D RID: 2397
		' (get) Token: 0x0600176D RID: 5997 RVA: 0x0001269B File Offset: 0x0001089B
		' (set) Token: 0x0600176E RID: 5998 RVA: 0x000FF490 File Offset: 0x000FD690
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

		' Token: 0x1700095E RID: 2398
		' (get) Token: 0x0600176F RID: 5999 RVA: 0x000126A5 File Offset: 0x000108A5
		' (set) Token: 0x06001770 RID: 6000 RVA: 0x000126AF File Offset: 0x000108AF
		Friend Overridable Property Label1 As Label

		' Token: 0x1700095F RID: 2399
		' (get) Token: 0x06001771 RID: 6001 RVA: 0x000126B8 File Offset: 0x000108B8
		' (set) Token: 0x06001772 RID: 6002 RVA: 0x000126C2 File Offset: 0x000108C2
		Friend Overridable Property Button2 As Button

		' Token: 0x17000960 RID: 2400
		' (get) Token: 0x06001773 RID: 6003 RVA: 0x000126CB File Offset: 0x000108CB
		' (set) Token: 0x06001774 RID: 6004 RVA: 0x000126D5 File Offset: 0x000108D5
		Friend Overridable Property Label2 As Label

		' Token: 0x17000961 RID: 2401
		' (get) Token: 0x06001775 RID: 6005 RVA: 0x000126DE File Offset: 0x000108DE
		' (set) Token: 0x06001776 RID: 6006 RVA: 0x000126E8 File Offset: 0x000108E8
		Friend Overridable Property lblId As Label

		' Token: 0x17000962 RID: 2402
		' (get) Token: 0x06001777 RID: 6007 RVA: 0x000126F1 File Offset: 0x000108F1
		' (set) Token: 0x06001778 RID: 6008 RVA: 0x000126FB File Offset: 0x000108FB
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000963 RID: 2403
		' (get) Token: 0x06001779 RID: 6009 RVA: 0x00012704 File Offset: 0x00010904
		' (set) Token: 0x0600177A RID: 6010 RVA: 0x0001270E File Offset: 0x0001090E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000964 RID: 2404
		' (get) Token: 0x0600177B RID: 6011 RVA: 0x00012717 File Offset: 0x00010917
		' (set) Token: 0x0600177C RID: 6012 RVA: 0x00012721 File Offset: 0x00010921
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000965 RID: 2405
		' (get) Token: 0x0600177D RID: 6013 RVA: 0x0001272A File Offset: 0x0001092A
		' (set) Token: 0x0600177E RID: 6014 RVA: 0x00012734 File Offset: 0x00010934
		Friend Overridable Property Column22 As DataGridViewButtonColumn

		' Token: 0x17000966 RID: 2406
		' (get) Token: 0x0600177F RID: 6015 RVA: 0x0001273D File Offset: 0x0001093D
		' (set) Token: 0x06001780 RID: 6016 RVA: 0x00012747 File Offset: 0x00010947
		Friend Overridable Property Column2 As DataGridViewButtonColumn

		' Token: 0x06001781 RID: 6017 RVA: 0x00012750 File Offset: 0x00010950
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06001782 RID: 6018 RVA: 0x000FF4D4 File Offset: 0x000FD6D4
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.hideControl
				Dim text As String
				If flag Then
					text = "SELECT RTRIM(ID), RTRIM(Rate), RTRIM(IsDefault) from TaxCat "
				Else
					text = "SELECT TOP " + Me.txtTopResult.Text + " RTRIM(ID), RTRIM(Rate), RTRIM(IsDefault) from TaxCat "
				End If
				Dim flag2 As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag2 Then
					text += " WHERE RTrim(Rate) LIKE @search"
				End If
				text += " ORDER BY id DESC"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				Dim flag3 As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag3 Then
					ModCommonClasses.cmd.Parameters.AddWithValue("@search", "%" + Me.txtSearchProduct.Text.Trim() + "%")
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text2 As String = "Yes"
					Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "0", False)
					If flag4 Then
						text2 = "No"
					End If
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), text2 })
					Me.dgw.Rows(num).Cells(3).Value = "Update"
					Me.dgw.Rows(num).Cells(4).Value = "Delete"
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim flag5 As Boolean = Me.hideControl AndAlso Me.dgw.RowCount = 1
				If flag5 Then
					Me.dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect
					Me.dgw.MultiSelect = False
				End If
				Dim flag6 As Boolean = Me.dgw.RowCount > 0
				If flag6 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001783 RID: 6019 RVA: 0x000FF7C4 File Offset: 0x000FD9C4
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

		' Token: 0x06001784 RID: 6020 RVA: 0x000FF838 File Offset: 0x000FDA38
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

		' Token: 0x06001785 RID: 6021 RVA: 0x000FF8A0 File Offset: 0x000FDAA0
		Private Sub grdState_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.txtSearchProduct.[Select](Me.txtSearchProduct.Text.Length, 0)
				Me.txtSearchProduct.Focus()
				Me.txtSearchProduct.ScrollToCaret()
				Me.txtSearchProduct.Text = ""
			Else
				Me.txtSearchProduct.[Select](Me.txtSearchProduct.Text.Length, 0)
				Me.txtSearchProduct.Focus()
				Me.txtSearchProduct.ScrollToCaret()
			End If
		End Sub

		' Token: 0x06001786 RID: 6022 RVA: 0x000FF93C File Offset: 0x000FDB3C
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Dim focused As Boolean = Me.txtSearchProduct.Focused
			If focused Then
				Dim flag As Boolean = keyData = Keys.Down
				If flag Then
					Dim flag2 As Boolean = Me.dgw.Rows.Count = 0
					If flag2 Then
						Return True
					End If
					Me.dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect
					Me.dgw.MultiSelect = False
					Me.dgw.ClearSelection()
					Dim flag3 As Boolean = Me.dgw.CurrentCell Is Nothing
					If flag3 Then
						Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
					Else
						Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
						Dim flag4 As Boolean = rowIndex = Me.dgw.Rows.Count - 1
						If flag4 Then
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
						Else
							Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(1)
						End If
					End If
					Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex).Selected = True
					Me.dgw.Focus()
					Return True
				Else
					Dim flag5 As Boolean = keyData = Keys.Up
					If flag5 Then
						Dim flag6 As Boolean = Me.dgw.Rows.Count = 0
						If flag6 Then
							Return True
						End If
						Me.dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect
						Me.dgw.MultiSelect = False
						Me.dgw.ClearSelection()
						Dim flag7 As Boolean = Me.dgw.CurrentCell Is Nothing
						If flag7 Then
							Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.Rows.Count - 1).Cells(1)
						Else
							Dim rowIndex2 As Integer = Me.dgw.CurrentCell.RowIndex
							Dim flag8 As Boolean = rowIndex2 = 0
							If flag8 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.Rows.Count - 1).Cells(1)
							Else
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex2 - 1).Cells(1)
							End If
						End If
						Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex).Selected = True
						Me.dgw.Focus()
						Return True
					Else
						Dim flag9 As Boolean = keyData = Keys.Escape
						If flag9 Then
							Me.txtSearchProduct.Text = ""
							Me.txtSearchProduct.Focus()
							Me.txtSearchProduct.SelectionStart = 0
							Return True
						End If
						Dim flag10 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell IsNot Nothing
						If Not flag10 Then
							Return MyBase.ProcessCmdKey(msg, keyData)
						End If
					End If
				End If
			End If
			Dim flag11 As Boolean = Me.dgw.CurrentCell Is Nothing
			Dim flag12 As Boolean
			If flag11 Then
				flag12 = True
			Else
				Dim flag13 As Boolean = Me.hideControl
				If flag13 Then
					Dim flag14 As Boolean = keyData = Keys.Down
					If flag14 Then
						Dim flag15 As Boolean = Me.dgw.CurrentCell.RowIndex < Me.dgw.RowCount - 1
						If flag15 Then
							Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex + 1).Cells(1)
						Else
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
						End If
					Else
						Dim flag16 As Boolean = keyData = Keys.Up
						If flag16 Then
							Dim flag17 As Boolean = Me.dgw.CurrentCell.RowIndex > 0
							If flag17 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex - 1).Cells(1)
							Else
								Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.RowCount - 1).Cells(1)
							End If
						Else
							Dim flag18 As Boolean = keyData = Keys.[Return]
							If flag18 Then
								Dim flag19 As Boolean = TypeOf MyBase.Owner Is frmProductSmart
								If flag19 Then
									Dim frmProductSmart As frmProductSmart = CType(MyBase.Owner, frmProductSmart)
									Dim text As String = Me.dgw.CurrentRow.Cells(0).Value.ToString().Trim()
									Dim text2 As String = Me.dgw.CurrentRow.Cells(1).Value.ToString().Trim()
									frmProductSmart.UpdateGstRate(Me.currentRow, Me.currentColumn, Conversions.ToInteger(text), Conversions.ToDecimal(text2))
									MyBase.Dispose()
								End If
							End If
						End If
					End If
					flag12 = True
				Else
					Me.dgw.Focus()
					Dim flag20 As Boolean = Not Me.txtSearchProduct.Focused And Not Me.txtTopResult.Focused
					If flag20 Then
						Dim flag21 As Boolean = keyData = Keys.[Return]
						If flag21 Then
							Me.dgw.ClearSelection()
							Dim num As Integer = 1
							Dim num2 As Integer = 1
							Dim flag22 As Boolean = Me.dgw.CurrentCell IsNot Nothing
							If flag22 Then
								Dim rowIndex3 As Integer = Me.dgw.CurrentCell.RowIndex
								Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
								Dim flag23 As Boolean = keyData = Keys.[Return] AndAlso columnIndex = 4
								If flag23 Then
									Me.DeleteCategory(rowIndex3, columnIndex)
									Return True
								End If
								Dim flag24 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex > 0 AndAlso Me.dgw.CurrentCell.ColumnIndex < 3
								If flag24 Then
									Dim flag25 As Boolean = columnIndex = 2 AndAlso msg.Msg > 0
									If flag25 Then
										Me.dgw.EndEdit()
										Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
										Me.dgw.Refresh()
										Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(rowIndex3)
										MyProject.Forms.frmYesNo.currentRow = rowIndex3
										MyProject.Forms.frmYesNo.currentColumn = columnIndex
										MyProject.Forms.frmYesNo.Owner = Me
										MyProject.Forms.frmYesNo.ShowDialog()
										Return True
									End If
									Dim flag26 As Boolean = columnIndex < Me.dgw.Columns.Count
									If flag26 Then
										Me.dgw.Focus()
										Me.dgw.[Select]()
										Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex + num)
									End If
									Return Me.MoveToNextAndClear()
								Else
									Dim flag27 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 3
									If flag27 Then
										Dim flag28 As Boolean = Operators.ConditionalCompareObjectGreaterEqual(Me.dgw.Rows(rowIndex3).Cells(0).Value, 0, False)
										If Not flag28 Then
											Return True
										End If
										Dim flag29 As Boolean = False
										Me.InsertNewSubCategory(rowIndex3, columnIndex, flag29)
										Dim flag30 As Boolean = flag29
										If flag30 Then
											Dim flag31 As Boolean = rowIndex3 < Me.dgw.Rows.Count - 1
											If flag31 Then
												Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(1)
											Else
												Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
											End If
											Return Me.MoveToNextAndClear()
										End If
										Return True
									Else
										Select Case keyData
											Case Keys.Left
												Dim flag32 As Boolean = columnIndex > 4
												If flag32 Then
													Dim flag33 As Boolean = Not Me.dgw.Rows(rowIndex3).Cells(columnIndex - num2).Visible
													If flag33 Then
														num2 += 1
													End If
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex - num2)
												Else
													Dim flag34 As Boolean = columnIndex = 4
													If flag34 Then
														Dim flag35 As Boolean = rowIndex3 > 0
														If flag35 Then
															Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 - 1).Cells(15)
														Else
															Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(1)
														End If
													End If
												End If
												Return Me.MoveToNextAndClear()
											Case Keys.Up
												Dim flag36 As Boolean = rowIndex3 > 0
												If flag36 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 - 1).Cells(columnIndex)
													Return Me.MoveToNextAndClear()
												End If
											Case Keys.Right
												Dim flag37 As Boolean = columnIndex < 4
												If flag37 Then
													Dim flag38 As Boolean = Not Me.dgw.Rows(rowIndex3).Cells(columnIndex + num).Visible
													If flag38 Then
														num += 1
													End If
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex + num)
												Else
													Dim flag39 As Boolean = columnIndex = 4
													If flag39 Then
														Dim flag40 As Boolean = rowIndex3 >= Me.dgw.Rows.Count - 1
														If flag40 Then
															Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
														Else
															Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(1)
														End If
													End If
												End If
												Return Me.MoveToNextAndClear()
											Case Keys.Down
												Dim flag41 As Boolean = rowIndex3 < Me.dgw.Rows.Count - 1
												If flag41 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(columnIndex)
													Return Me.MoveToNextAndClear()
												End If
										End Select
										Dim flag42 As Boolean = Not Me.txtSearchProduct.Focused
										If flag42 Then
											Me.dgw.BeginEdit(True)
											Me.dgw.ClearSelection()
										End If
									End If
								End If
							End If
						End If
					Else
						Dim flag43 As Boolean = keyData = Keys.[Return]
						If flag43 Then
							Dim flag44 As Boolean = Me.dgw.RowCount > 0
							If flag44 Then
								Dim focused2 As Boolean = Me.txtSearchProduct.Focused
								If focused2 Then
									Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
								End If
								Me.dgw.BeginEdit(True)
								Me.dgw.ClearSelection()
							End If
						End If
					End If
					flag12 = MyBase.ProcessCmdKey(msg, keyData)
				End If
			End If
			Return flag12
		End Function

		' Token: 0x06001787 RID: 6023 RVA: 0x00100518 File Offset: 0x000FE718
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

		' Token: 0x06001788 RID: 6024 RVA: 0x001006FC File Offset: 0x000FE8FC
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim rowIndex As Integer = e.RowIndex
			Dim columnIndex As Integer = e.ColumnIndex
			Dim flag As Boolean = False
			Me.InsertNewSubCategory(rowIndex, columnIndex, flag)
			Me.DeleteCategory(e.RowIndex, e.ColumnIndex)
		End Sub

		' Token: 0x06001789 RID: 6025 RVA: 0x00100734 File Offset: 0x000FE934
		Public Sub SetFocustoCurrentCell(rowindex As Integer, colindex As Integer)
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(rowindex).Cells(colindex)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x0600178A RID: 6026 RVA: 0x00100770 File Offset: 0x000FE970
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
						MessageBox.Show("Please enter sub GST Rate", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						NewLateBinding.LateCall(NewLateBinding.LateGet(dataGridViewRow.Cells(1).Value, Nothing, "Text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing, True)
					Else
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select Rate from TaxCat where Rate=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(1).Value.ToString().Trim())
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
						If flag5 Then
							MessageBox.Show("GST Rate Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag6 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							Dim flag7 As Boolean = Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString().Trim(), "Yes", False) = 0
							If flag7 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "select IsDefault from TaxCat where IsDefault='Yes'"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
								If flag8 Then
									MessageBox.Show("GST Rate is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag9 Then
										ModCommonClasses.rdr.Close()
									End If
									Return
								End If
							End If
							Dim value As Object = dataGridViewRow.Cells(3).Value
							Dim text4 As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(If((Operators.CompareString(text4, "Save", False) <> 0), Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)), Me.lblId.Text))
							Dim text5 As String = (If(dataGridViewRow.Cells(1).Value, "")).ToString().Trim()
							Dim text6 As String = (If(dataGridViewRow.Cells(2).Value, "")).ToString().Trim()
							Dim text7 As String = "insert into TaxCat (Rate,IsDefault) VALUES (@d1,@d2)"
							Dim text8 As String = "Update TaxCat set Rate=@d1, IsDefault=@d2 where ID=@ID"
							Dim text9 As String = If((Operators.CompareString(text4, "Save", False) = 0), text7, text8)
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
								Using sqlCommand As SqlCommand = New SqlCommand(text9, sqlConnection)
									sqlCommand.Parameters.AddWithValue("@d1", text5)
									sqlCommand.Parameters.AddWithValue("@d2", text6)
									sqlCommand.Parameters.AddWithValue("@ID", RuntimeHelpers.GetObjectValue(objectValue))
									sqlConnection.Open()
									sqlCommand.ExecuteNonQuery()
								End Using
							End Using
							MessageBox.Show("Record " + If((Operators.CompareString(text4, "Save", False) = 0), "inserted", "updated") + " successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Dim flag10 As Boolean = Operators.CompareString(text4, "Save", False) = 0
							If flag10 Then
								Me.AddNewRow()
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600178B RID: 6027 RVA: 0x00100C34 File Offset: 0x000FEE34
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
								Using sqlCommand As SqlCommand = New SqlCommand("DELETE FROM TaxCat WHERE ID=@ID", sqlConnection)
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

		' Token: 0x0600178C RID: 6028 RVA: 0x00012762 File Offset: 0x00010962
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x0600178D RID: 6029 RVA: 0x00100E28 File Offset: 0x000FF028
		Private Sub txtTopResult_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Dim flag As Boolean = Not String.IsNullOrEmpty(Me.txtTopResult.Text.Trim())
			If flag Then
				Me.Getdata()
			End If
		End Sub

		' Token: 0x0600178E RID: 6030 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub Reset()
		End Sub

		' Token: 0x0600178F RID: 6031 RVA: 0x00100E5C File Offset: 0x000FF05C
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkSelectAll.Checked
			If checked Then
				Me.dgw.SelectAll()
			Else
				Me.dgw.ClearSelection()
			End If
		End Sub

		' Token: 0x06001790 RID: 6032 RVA: 0x0001276C File Offset: 0x0001096C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06001791 RID: 6033 RVA: 0x0001276C File Offset: 0x0001096C
		Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Me.Getdata()
		End Sub

		' Token: 0x06001792 RID: 6034 RVA: 0x00100E98 File Offset: 0x000FF098
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

		' Token: 0x06001793 RID: 6035 RVA: 0x00100EE8 File Offset: 0x000FF0E8
		Public Sub HideControls(isHide As Boolean, Rate As String)
			Me.hideControl = isHide
			If isHide Then
				Dim flag As Boolean = Not String.IsNullOrEmpty(Rate)
				If flag Then
					Me.txtSearchProduct.Text = Rate
					Me.txtSearchProduct.Focus()
					Me.txtSearchProduct.[Select]()
					Me.txtSearchProduct.SelectAll()
				End If
				Me.Label19.Visible = False
				Me.chkSelectAll.Visible = False
				Me.Label21.Visible = False
				Me.txtTopResult.Visible = False
				Me.Label18.Visible = False
				Me.btnNewSupplier.Visible = False
				Me.Button2.Visible = False
				Me.Button1.Visible = False
				Me.dgw.Columns(3).Visible = False
				Me.dgw.Columns(4).Visible = False
				Me.dgw.Columns(2).Visible = False
			End If
		End Sub

		' Token: 0x040008E0 RID: 2272
		Public currentRow As Integer

		' Token: 0x040008E1 RID: 2273
		Public currentColumn As Integer

		' Token: 0x040008E2 RID: 2274
		Public hideControl As Boolean

		' Token: 0x040008E3 RID: 2275
		Public eventSender As Object

		' Token: 0x040008E4 RID: 2276
		Private prevCell As DataGridViewCell
	End Class
End Namespace
