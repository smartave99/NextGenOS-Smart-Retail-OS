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
	' Token: 0x02000096 RID: 150
	<DesignerGenerated()>
	Public Partial Class frmUnitMasterNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600179D RID: 6045 RVA: 0x000127A4 File Offset: 0x000109A4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			Me.prevCell = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000967 RID: 2407
		' (get) Token: 0x060017A0 RID: 6048 RVA: 0x000127CE File Offset: 0x000109CE
		' (set) Token: 0x060017A1 RID: 6049 RVA: 0x00102594 File Offset: 0x00100794
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

		' Token: 0x17000968 RID: 2408
		' (get) Token: 0x060017A2 RID: 6050 RVA: 0x000127D8 File Offset: 0x000109D8
		' (set) Token: 0x060017A3 RID: 6051 RVA: 0x000127E2 File Offset: 0x000109E2
		Public Overridable Property Photo As PictureBox

		' Token: 0x17000969 RID: 2409
		' (get) Token: 0x060017A4 RID: 6052 RVA: 0x000127EB File Offset: 0x000109EB
		' (set) Token: 0x060017A5 RID: 6053 RVA: 0x000127F5 File Offset: 0x000109F5
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x1700096A RID: 2410
		' (get) Token: 0x060017A6 RID: 6054 RVA: 0x000127FE File Offset: 0x000109FE
		' (set) Token: 0x060017A7 RID: 6055 RVA: 0x00102610 File Offset: 0x00100810
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

		' Token: 0x1700096B RID: 2411
		' (get) Token: 0x060017A8 RID: 6056 RVA: 0x00012808 File Offset: 0x00010A08
		' (set) Token: 0x060017A9 RID: 6057 RVA: 0x00012812 File Offset: 0x00010A12
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700096C RID: 2412
		' (get) Token: 0x060017AA RID: 6058 RVA: 0x0001281B File Offset: 0x00010A1B
		' (set) Token: 0x060017AB RID: 6059 RVA: 0x00012825 File Offset: 0x00010A25
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x1700096D RID: 2413
		' (get) Token: 0x060017AC RID: 6060 RVA: 0x0001282E File Offset: 0x00010A2E
		' (set) Token: 0x060017AD RID: 6061 RVA: 0x00012838 File Offset: 0x00010A38
		Friend Overridable Property Label17 As Label

		' Token: 0x1700096E RID: 2414
		' (get) Token: 0x060017AE RID: 6062 RVA: 0x00012841 File Offset: 0x00010A41
		' (set) Token: 0x060017AF RID: 6063 RVA: 0x0001284B File Offset: 0x00010A4B
		Friend Overridable Property Panel7 As Panel

		' Token: 0x1700096F RID: 2415
		' (get) Token: 0x060017B0 RID: 6064 RVA: 0x00012854 File Offset: 0x00010A54
		' (set) Token: 0x060017B1 RID: 6065 RVA: 0x0001285E File Offset: 0x00010A5E
		Friend Overridable Property Label19 As Label

		' Token: 0x17000970 RID: 2416
		' (get) Token: 0x060017B2 RID: 6066 RVA: 0x00012867 File Offset: 0x00010A67
		' (set) Token: 0x060017B3 RID: 6067 RVA: 0x00102654 File Offset: 0x00100854
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

		' Token: 0x17000971 RID: 2417
		' (get) Token: 0x060017B4 RID: 6068 RVA: 0x00012871 File Offset: 0x00010A71
		' (set) Token: 0x060017B5 RID: 6069 RVA: 0x0001287B File Offset: 0x00010A7B
		Friend Overridable Property Label18 As Label

		' Token: 0x17000972 RID: 2418
		' (get) Token: 0x060017B6 RID: 6070 RVA: 0x00012884 File Offset: 0x00010A84
		' (set) Token: 0x060017B7 RID: 6071 RVA: 0x0001288E File Offset: 0x00010A8E
		Friend Overridable Property Label21 As Label

		' Token: 0x17000973 RID: 2419
		' (get) Token: 0x060017B8 RID: 6072 RVA: 0x00012897 File Offset: 0x00010A97
		' (set) Token: 0x060017B9 RID: 6073 RVA: 0x00102698 File Offset: 0x00100898
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

		' Token: 0x17000974 RID: 2420
		' (get) Token: 0x060017BA RID: 6074 RVA: 0x000128A1 File Offset: 0x00010AA1
		' (set) Token: 0x060017BB RID: 6075 RVA: 0x001026DC File Offset: 0x001008DC
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

		' Token: 0x17000975 RID: 2421
		' (get) Token: 0x060017BC RID: 6076 RVA: 0x000128AB File Offset: 0x00010AAB
		' (set) Token: 0x060017BD RID: 6077 RVA: 0x00102720 File Offset: 0x00100920
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

		' Token: 0x17000976 RID: 2422
		' (get) Token: 0x060017BE RID: 6078 RVA: 0x000128B5 File Offset: 0x00010AB5
		' (set) Token: 0x060017BF RID: 6079 RVA: 0x000128BF File Offset: 0x00010ABF
		Friend Overridable Property Label1 As Label

		' Token: 0x17000977 RID: 2423
		' (get) Token: 0x060017C0 RID: 6080 RVA: 0x000128C8 File Offset: 0x00010AC8
		' (set) Token: 0x060017C1 RID: 6081 RVA: 0x000128D2 File Offset: 0x00010AD2
		Friend Overridable Property Button2 As Button

		' Token: 0x17000978 RID: 2424
		' (get) Token: 0x060017C2 RID: 6082 RVA: 0x000128DB File Offset: 0x00010ADB
		' (set) Token: 0x060017C3 RID: 6083 RVA: 0x000128E5 File Offset: 0x00010AE5
		Friend Overridable Property Label2 As Label

		' Token: 0x17000979 RID: 2425
		' (get) Token: 0x060017C4 RID: 6084 RVA: 0x000128EE File Offset: 0x00010AEE
		' (set) Token: 0x060017C5 RID: 6085 RVA: 0x000128F8 File Offset: 0x00010AF8
		Friend Overridable Property lblId As Label

		' Token: 0x1700097A RID: 2426
		' (get) Token: 0x060017C6 RID: 6086 RVA: 0x00012901 File Offset: 0x00010B01
		' (set) Token: 0x060017C7 RID: 6087 RVA: 0x0001290B File Offset: 0x00010B0B
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700097B RID: 2427
		' (get) Token: 0x060017C8 RID: 6088 RVA: 0x00012914 File Offset: 0x00010B14
		' (set) Token: 0x060017C9 RID: 6089 RVA: 0x0001291E File Offset: 0x00010B1E
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700097C RID: 2428
		' (get) Token: 0x060017CA RID: 6090 RVA: 0x00012927 File Offset: 0x00010B27
		' (set) Token: 0x060017CB RID: 6091 RVA: 0x00012931 File Offset: 0x00010B31
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700097D RID: 2429
		' (get) Token: 0x060017CC RID: 6092 RVA: 0x0001293A File Offset: 0x00010B3A
		' (set) Token: 0x060017CD RID: 6093 RVA: 0x00012944 File Offset: 0x00010B44
		Friend Overridable Property Column22 As DataGridViewButtonColumn

		' Token: 0x1700097E RID: 2430
		' (get) Token: 0x060017CE RID: 6094 RVA: 0x0001294D File Offset: 0x00010B4D
		' (set) Token: 0x060017CF RID: 6095 RVA: 0x00012957 File Offset: 0x00010B57
		Friend Overridable Property Column2 As DataGridViewButtonColumn

		' Token: 0x060017D0 RID: 6096 RVA: 0x00012960 File Offset: 0x00010B60
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x060017D1 RID: 6097 RVA: 0x00102764 File Offset: 0x00100964
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.hideControl
				Dim text As String
				If flag Then
					text = "Select RTRIM(Unit),RTRIM(Description), IsDefault from UnitMaster  "
				Else
					text = "Select Top " + Me.txtTopResult.Text + " RTRIM(Unit),RTRIM(Description), IsDefault from UnitMaster  "
				End If
				Dim flag2 As Boolean = Me.txtSearchProduct.Text.Trim().Length > 0
				If flag2 Then
					text += " WHERE RTrim(Unit) LIKE @search"
				End If
				text += " ORDER BY IsDefault DESC"
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
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(0)
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060017D2 RID: 6098 RVA: 0x00102A54 File Offset: 0x00100C54
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

		' Token: 0x060017D3 RID: 6099 RVA: 0x00102AC8 File Offset: 0x00100CC8
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

		' Token: 0x060017D4 RID: 6100 RVA: 0x00102B30 File Offset: 0x00100D30
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

		' Token: 0x060017D5 RID: 6101 RVA: 0x00102BCC File Offset: 0x00100DCC
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
							Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex + 1).Cells(0)
						Else
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(1)
						End If
					Else
						Dim flag16 As Boolean = keyData = Keys.Up
						If flag16 Then
							Dim flag17 As Boolean = Me.dgw.CurrentCell.RowIndex > 0
							If flag17 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.CurrentCell.RowIndex - 1).Cells(0)
							Else
								Me.dgw.CurrentCell = Me.dgw.Rows(Me.dgw.RowCount - 1).Cells(0)
							End If
						Else
							Dim flag18 As Boolean = keyData = Keys.[Return]
							If flag18 Then
								Dim flag19 As Boolean = TypeOf MyBase.Owner Is frmProductSmart
								If flag19 Then
									Dim frmProductSmart As frmProductSmart = CType(MyBase.Owner, frmProductSmart)
									Dim text As String = Me.dgw.CurrentRow.Cells(0).Value.ToString().Trim()
									frmProductSmart.UpdateUnit(Me.currentRow, Me.currentColumn, text)
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
								Dim flag24 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex >= 0 AndAlso Me.dgw.CurrentCell.ColumnIndex < 4
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
									Dim flag26 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 3
									If Not flag26 Then
										Select Case keyData
											Case Keys.Left
												Dim flag27 As Boolean = columnIndex > 4
												If flag27 Then
													Dim flag28 As Boolean = Not Me.dgw.Rows(rowIndex3).Cells(columnIndex - num2).Visible
													If flag28 Then
														num2 += 1
													End If
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex - num2)
												Else
													Dim flag29 As Boolean = columnIndex = 3
													If flag29 Then
														Dim flag30 As Boolean = rowIndex3 > 0
														If flag30 Then
															Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 - 1).Cells(15)
														Else
															Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(0)
														End If
													End If
												End If
												Return Me.MoveToNextAndClear()
											Case Keys.Up
												Dim flag31 As Boolean = rowIndex3 > 0
												If flag31 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 - 1).Cells(columnIndex)
													Return Me.MoveToNextAndClear()
												End If
											Case Keys.Right
												Dim flag32 As Boolean = columnIndex < 4
												If flag32 Then
													Dim flag33 As Boolean = Not Me.dgw.Rows(rowIndex3).Cells(columnIndex + num).Visible
													If flag33 Then
														num += 1
													End If
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex + num)
												Else
													Dim flag34 As Boolean = columnIndex = 3
													If flag34 Then
														Dim flag35 As Boolean = rowIndex3 >= Me.dgw.Rows.Count - 1
														If flag35 Then
															Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(0)
														Else
															Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(0)
														End If
													End If
												End If
												Return Me.MoveToNextAndClear()
											Case Keys.Down
												Dim flag36 As Boolean = rowIndex3 < Me.dgw.Rows.Count - 1
												If flag36 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(columnIndex)
													Return Me.MoveToNextAndClear()
												End If
										End Select
										Dim flag37 As Boolean = columnIndex < Me.dgw.Columns.Count
										If flag37 Then
											Me.dgw.Focus()
											Me.dgw.[Select]()
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3).Cells(columnIndex + num)
										End If
										Return Me.MoveToNextAndClear()
									End If
									Dim flag38 As Boolean = Operators.ConditionalCompareObjectGreaterEqual(Me.dgw.Rows(rowIndex3).Cells(0).Tag, 0, False)
									If Not flag38 Then
										Return True
									End If
									Me.dgw.Rows(rowIndex3).Cells(0).Tag = 1
									Dim flag39 As Boolean = False
									Me.InsertNewSubCategory(rowIndex3, columnIndex, flag39)
									Dim flag40 As Boolean = flag39
									If flag40 Then
										Dim flag41 As Boolean = rowIndex3 < Me.dgw.Rows.Count - 1
										If flag41 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex3 + 1).Cells(0)
										Else
											Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(0)
										End If
										Return Me.MoveToNextAndClear()
									End If
									Return True
								End If
							End If
						Else
							Dim flag42 As Boolean = keyData = Keys.[Return]
							If flag42 Then
								Dim flag43 As Boolean = Me.dgw.RowCount > 0
								If flag43 Then
									Dim focused2 As Boolean = Me.txtSearchProduct.Focused
									If focused2 Then
										Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(0)
									End If
									Me.dgw.BeginEdit(True)
									Me.dgw.ClearSelection()
								End If
							End If
						End If
						flag12 = MyBase.ProcessCmdKey(msg, keyData)
					Else
						Dim flag44 As Boolean = keyData = Keys.[Return]
						If flag44 Then
							Dim flag45 As Boolean = Me.dgw.RowCount > 0
							If flag45 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(0)
								Me.dgw.BeginEdit(True)
								Me.dgw.ClearSelection()
							End If
						End If
						flag12 = MyBase.ProcessCmdKey(msg, keyData)
					End If
				End If
			End If
			Return flag12
		End Function

		' Token: 0x060017D6 RID: 6102 RVA: 0x001037D4 File Offset: 0x001019D4
		Private Sub AddNewRow()
			For Each row As DataGridViewRow In Me.dgw.Rows
				If row.Cells(0).Tag IsNot Nothing AndAlso Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(0).Tag)) = 0.0 Then
					MessageBox.Show("A new row already exists. Please save it before adding another.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.dgw.ClearSelection()
					MyBase.BeginInvoke(New MethodInvoker(Sub()
						Me.dgw.Focus()
						Me.dgw.CurrentCell = row.Cells(0)
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End Sub))
					Return
				End If
			Next
			Me.dgw.ClearSelection()
			Dim num As Integer = Me.dgw.Rows.Add()
			Dim newRow As DataGridViewRow = Me.dgw.Rows(num)
			newRow.Cells(0).Tag = 0
			newRow.Cells(0).Value = ""
			newRow.Cells(1).Value = ""
			newRow.Cells(2).Value = ""
			newRow.Cells(3).Value = "Save"
			Me.lblId.Text = "0"
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New MethodInvoker(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = newRow.Cells(0)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x060017D7 RID: 6103 RVA: 0x001039D4 File Offset: 0x00101BD4
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim rowIndex As Integer = e.RowIndex
			Dim columnIndex As Integer = e.ColumnIndex
			Dim flag As Boolean = False
			Me.InsertNewSubCategory(rowIndex, columnIndex, flag)
			Me.DeleteCategory(e.RowIndex, e.ColumnIndex)
		End Sub

		' Token: 0x060017D8 RID: 6104 RVA: 0x00103A0C File Offset: 0x00101C0C
		Public Sub SetFocustoCurrentCell(rowindex As Integer, colindex As Integer)
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(rowindex).Cells(colindex)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x060017D9 RID: 6105 RVA: 0x00103A48 File Offset: 0x00101C48
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM SubCategory"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.lblId.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.lblId.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060017DA RID: 6106 RVA: 0x00103B4C File Offset: 0x00101D4C
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
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells(0).Value.ToString())) = 0
					If flag4 Then
						MessageBox.Show("Please enter Unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.dgw.CurrentCell = CType(NewLateBinding.LateGet(NewLateBinding.LateGet(dataGridViewRow.Cells(1).Value, Nothing, "Text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing), DataGridViewCell)
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells(1).Value.ToString())) = 0
						If flag5 Then
							MessageBox.Show("Please select Description", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.dgw.CurrentCell = dataGridViewRow.Cells(2)
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select Unit from UnitMaster where Unit=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(0).Value.ToString().Trim())
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
							If flag6 Then
								MessageBox.Show("Unit Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag7 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								Dim flag8 As Boolean = Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString().Trim(), "Yes", False) = 0
								If flag8 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "select IsDefault from UnitMaster where IsDefault='Yes'"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
									If flag9 Then
										MessageBox.Show("Unit is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag10 Then
											ModCommonClasses.rdr.Close()
										End If
										Return
									End If
								End If
								Dim value As Object = dataGridViewRow.Cells(3).Value
								Dim text4 As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
								Dim objectValue As Object = RuntimeHelpers.GetObjectValue(If((Operators.CompareString(text4, "Save", False) <> 0), Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)), Me.lblId.Text))
								Dim text5 As String = (If(dataGridViewRow.Cells(0).Value, "")).ToString().Trim()
								Dim text6 As String = (If(dataGridViewRow.Cells(1).Value, "")).ToString().Trim()
								Dim flag11 As Boolean = False
								Dim flag12 As Boolean = Operators.CompareString(New ValueTuple(Of Object, String)(dataGridViewRow.Cells(2).Value, "").ToString().Trim(), "Yes", False) = 0
								If flag12 Then
									flag11 = True
								End If
								Dim text7 As String = "insert into UnitMaster(Unit,Description,IsDefault) VALUES (@d1,@d2,@d3)"
								Dim text8 As String = "Update UnitMaster set Unit=@d1,Description=@d3, IsDefault=@d3 where Unit=@d1"
								Dim text9 As String = If((Operators.CompareString(text4, "Save", False) = 0), text7, text8)
								Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
									Using sqlCommand As SqlCommand = New SqlCommand(text9, sqlConnection)
										sqlCommand.Parameters.AddWithValue("@d1", text5)
										sqlCommand.Parameters.AddWithValue("@d2", text6)
										sqlCommand.Parameters.AddWithValue("@d3", flag11)
										sqlCommand.Parameters.AddWithValue("@ID", RuntimeHelpers.GetObjectValue(objectValue))
										sqlConnection.Open()
										sqlCommand.ExecuteNonQuery()
									End Using
								End Using
								MessageBox.Show("Record " + If((Operators.CompareString(text4, "Save", False) = 0), "inserted", "updated") + " successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Dim flag13 As Boolean = Operators.CompareString(text4, "Save", False) = 0
								If flag13 Then
									Me.AddNewRow()
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060017DB RID: 6107 RVA: 0x001040DC File Offset: 0x001022DC
		Public Sub DeleteCategory(RowIndex As Integer, ColumnIndex As Integer)
			Dim flag As Boolean = ColumnIndex <> Me.dgw.Columns(4).Index OrElse RowIndex < 0
			If Not flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
				Dim value As Object = dataGridViewRow.Cells(4).Value
				Dim text As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
				Dim flag2 As Boolean = Operators.CompareString(text, "Delete", False) <> 0
				If Not flag2 Then
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete this Unit?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
					Dim flag3 As Boolean = dialogResult = DialogResult.No
					If Not flag3 Then
						dataGridViewRow.Cells(4).Value = "Save"
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select Unit from UnitMaster,Product where UnitMaster.Unit=Product.PurchaseUnit and Unit=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								MessageBox.Show("Unable to delete..Already in use in Product Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
								If flag6 Then
									MessageBox.Show("Unable to delete..Already in use in Product Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag7 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
										Using sqlCommand As SqlCommand = New SqlCommand("DELETE FROM UnitMaster WHERE Unit=@d1", sqlConnection)
											sqlCommand.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
											sqlConnection.Open()
											Dim num As Integer = sqlCommand.ExecuteNonQuery()
											Dim flag8 As Boolean = num > 0
											If flag8 Then
												MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Me.Getdata()
												Me.Reset()
											Else
												MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Me.Reset()
											End If
										End Using
									End Using
								End If
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060017DC RID: 6108 RVA: 0x00012972 File Offset: 0x00010B72
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x060017DD RID: 6109 RVA: 0x00104454 File Offset: 0x00102654
		Private Sub txtTopResult_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Dim flag As Boolean = Not String.IsNullOrEmpty(Me.txtTopResult.Text.Trim())
			If flag Then
				Me.Getdata()
			End If
		End Sub

		' Token: 0x060017DE RID: 6110 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub Reset()
		End Sub

		' Token: 0x060017DF RID: 6111 RVA: 0x00104488 File Offset: 0x00102688
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkSelectAll.Checked
			If checked Then
				Me.dgw.SelectAll()
			Else
				Me.dgw.ClearSelection()
			End If
		End Sub

		' Token: 0x060017E0 RID: 6112 RVA: 0x0001297C File Offset: 0x00010B7C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060017E1 RID: 6113 RVA: 0x0001297C File Offset: 0x00010B7C
		Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Me.Getdata()
		End Sub

		' Token: 0x060017E2 RID: 6114 RVA: 0x001044C4 File Offset: 0x001026C4
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

		' Token: 0x060017E3 RID: 6115 RVA: 0x00104514 File Offset: 0x00102714
		Public Sub UpdateCategoryName(currentRow As Integer, currentColumn As Integer, selectedState As String)
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = ""
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = selectedState
			Me.dgw.EndEdit()
			Me.dgw.RefreshEdit()
			Me.dgw.Invalidate()
			Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(currentColumn + 1)
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(3)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x060017E4 RID: 6116 RVA: 0x001045FC File Offset: 0x001027FC
		Public Sub HideControls(isHide As Boolean, unit As String)
			Me.hideControl = isHide
			If isHide Then
				Dim flag As Boolean = Not String.IsNullOrEmpty(unit)
				If flag Then
					Me.txtSearchProduct.Text = unit
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

		' Token: 0x0400090E RID: 2318
		Public currentRow As Integer

		' Token: 0x0400090F RID: 2319
		Public currentColumn As Integer

		' Token: 0x04000910 RID: 2320
		Public hideControl As Boolean

		' Token: 0x04000911 RID: 2321
		Public eventSender As Object

		' Token: 0x04000912 RID: 2322
		Private prevCell As DataGridViewCell
	End Class
End Namespace
