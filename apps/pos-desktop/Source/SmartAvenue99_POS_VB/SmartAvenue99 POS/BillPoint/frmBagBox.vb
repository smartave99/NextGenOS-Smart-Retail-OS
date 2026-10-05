Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000A9 RID: 169
	<DesignerGenerated()>
	Public Partial Class frmBagBox
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001915 RID: 6421 RVA: 0x0001324F File Offset: 0x0001144F
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCreditDebit_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170009E3 RID: 2531
		' (get) Token: 0x06001918 RID: 6424 RVA: 0x0001326F File Offset: 0x0001146F
		' (set) Token: 0x06001919 RID: 6425 RVA: 0x00110E6C File Offset: 0x0010F06C
		Private _grdCreditDebit As DataGridView
		Friend Overridable Property grdCreditDebit As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._grdCreditDebit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdCreditDebit_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.grdCreditDebit_CellContentClick
				Dim dataGridView As DataGridView = Me._grdCreditDebit
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._grdCreditDebit = value
				dataGridView = Me._grdCreditDebit
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170009E4 RID: 2532
		' (get) Token: 0x0600191A RID: 6426 RVA: 0x00013279 File Offset: 0x00011479
		' (set) Token: 0x0600191B RID: 6427 RVA: 0x00013283 File Offset: 0x00011483
		Friend Overridable Property Label1 As Label

		' Token: 0x170009E5 RID: 2533
		' (get) Token: 0x0600191C RID: 6428 RVA: 0x0001328C File Offset: 0x0001148C
		' (set) Token: 0x0600191D RID: 6429 RVA: 0x00013296 File Offset: 0x00011496
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x0600191E RID: 6430 RVA: 0x0001329F File Offset: 0x0001149F
		Private Sub frmCreditDebit_Load(sender As Object, e As EventArgs)
			Me.YesNo()
			MyBase.StartPosition = FormStartPosition.CenterParent
		End Sub

		' Token: 0x0600191F RID: 6431 RVA: 0x00110ECC File Offset: 0x0010F0CC
		Private Sub YesNo()
			Try
				Me.grdCreditDebit.Rows.Clear()
				Me.grdCreditDebit.Rows.Add(New Object() { "BOX" })
				Me.grdCreditDebit.Rows(0).Cells(0).Tag = "BOX"
				Me.grdCreditDebit.Rows.Add(New Object() { "PCS" })
				Me.grdCreditDebit.Rows(1).Cells(0).Tag = "PCS"
				Me.grdCreditDebit.CurrentCell = Me.grdCreditDebit.Rows(0).Cells(0)
				Me.grdCreditDebit.Focus()
				Me.grdCreditDebit.BeginEdit(False)
				Me.grdCreditDebit.EndEdit()
				Application.DoEvents()
				Me.grdCreditDebit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
				Me.grdCreditDebit.SelectionMode = DataGridViewSelectionMode.FullRowSelect
				Me.grdCreditDebit.[ReadOnly] = True
			Catch ex As Exception
				MessageBox.Show("Error loading states: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06001920 RID: 6432 RVA: 0x00111038 File Offset: 0x0010F238
		Private Sub grdCreditDebit_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim keyCode As Keys = e.KeyCode
				If keyCode <> Keys.[Return] Then
					If keyCode <> Keys.Up Then
						If keyCode = Keys.Down Then
							e.Handled = True
							Dim flag As Boolean = Me.grdCreditDebit.CurrentRow IsNot Nothing
							If flag Then
								Dim num As Integer = Me.grdCreditDebit.CurrentRow.Index + 1
								Dim flag2 As Boolean = num < Me.grdCreditDebit.Rows.Count
								If flag2 Then
									Me.grdCreditDebit.CurrentCell = Me.grdCreditDebit.Rows(num).Cells(0)
								End If
							End If
						End If
					Else
						e.Handled = True
						Dim flag3 As Boolean = Me.grdCreditDebit.CurrentRow IsNot Nothing
						If flag3 Then
							Dim num2 As Integer = Me.grdCreditDebit.CurrentRow.Index - 1
							Dim flag4 As Boolean = num2 >= 0
							If flag4 Then
								Me.grdCreditDebit.CurrentCell = Me.grdCreditDebit.Rows(num2).Cells(0)
							End If
						End If
					End If
				Else
					Dim flag5 As Boolean = Me.grdCreditDebit.CurrentRow IsNot Nothing
					If flag5 Then
						Dim text As String = Me.grdCreditDebit.CurrentRow.Cells(0).Tag.ToString().Trim()
						Dim flag6 As Boolean = TypeOf MyBase.Owner Is frmProductSmart
						If flag6 Then
							Dim frmProductSmart As frmProductSmart = CType(MyBase.Owner, frmProductSmart)
							frmProductSmart.Focus()
							frmProductSmart.DataGridView1.Focus()
							frmProductSmart.UpdateBoxBag(Me.currentRow, Me.currentColumn, text)
						End If
						MyBase.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in grdCreditDebit_KeyDown: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06001921 RID: 6433 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub grdCreditDebit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
		End Sub

		' Token: 0x040009B8 RID: 2488
		Private stateDt As DataTable

		' Token: 0x040009B9 RID: 2489
		Public currentRow As Integer

		' Token: 0x040009BA RID: 2490
		Public currentColumn As Integer
	End Class
End Namespace
