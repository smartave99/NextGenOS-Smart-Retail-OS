Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000B1 RID: 177
	<DesignerGenerated()>
	Public Partial Class frmCreditDebit
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060019D1 RID: 6609 RVA: 0x000137A3 File Offset: 0x000119A3
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCreditDebit_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000A18 RID: 2584
		' (get) Token: 0x060019D4 RID: 6612 RVA: 0x000137C3 File Offset: 0x000119C3
		' (set) Token: 0x060019D5 RID: 6613 RVA: 0x0011C544 File Offset: 0x0011A744
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
				Dim dataGridView As DataGridView = Me._grdCreditDebit
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._grdCreditDebit = value
				dataGridView = Me._grdCreditDebit
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A19 RID: 2585
		' (get) Token: 0x060019D6 RID: 6614 RVA: 0x000137CD File Offset: 0x000119CD
		' (set) Token: 0x060019D7 RID: 6615 RVA: 0x000137D7 File Offset: 0x000119D7
		Friend Overridable Property Label1 As Label

		' Token: 0x17000A1A RID: 2586
		' (get) Token: 0x060019D8 RID: 6616 RVA: 0x000137E0 File Offset: 0x000119E0
		' (set) Token: 0x060019D9 RID: 6617 RVA: 0x000137EA File Offset: 0x000119EA
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x060019DA RID: 6618 RVA: 0x000137F3 File Offset: 0x000119F3
		Private Sub frmCreditDebit_Load(sender As Object, e As EventArgs)
			Me.CreditDebit()
			MyBase.StartPosition = FormStartPosition.CenterParent
		End Sub

		' Token: 0x060019DB RID: 6619 RVA: 0x0011C588 File Offset: 0x0011A788
		Private Sub CreditDebit()
			Try
				Me.grdCreditDebit.Rows.Clear()
				Me.grdCreditDebit.Rows.Add(New Object() { "Credit" })
				Me.grdCreditDebit.Rows(0).Cells(0).Tag = "Cr"
				Me.grdCreditDebit.Rows.Add(New Object() { "Debit" })
				Me.grdCreditDebit.Rows(1).Cells(0).Tag = "Dr"
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

		' Token: 0x060019DC RID: 6620 RVA: 0x0011C6F4 File Offset: 0x0011A8F4
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
						Dim flag6 As Boolean = TypeOf MyBase.Owner Is frmSuppliers
						If flag6 Then
							Dim frmSuppliers As frmSuppliers = CType(MyBase.Owner, frmSuppliers)
							frmSuppliers.Focus()
							frmSuppliers.dgw.Focus()
							frmSuppliers.UpdateAccountType(Me.currentRow, Me.currentColumn, text)
						Else
							Dim flag7 As Boolean = TypeOf MyBase.Owner Is frmCustomersNew
							If flag7 Then
								Dim frmCustomersNew As frmCustomersNew = CType(MyBase.Owner, frmCustomersNew)
								frmCustomersNew.Focus()
								frmCustomersNew.dgw.Focus()
								frmCustomersNew.UpdateAccountType(Me.currentRow, Me.currentColumn, text)
							End If
						End If
						MyBase.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in grdCreditDebit_KeyDown: " + ex.Message)
			End Try
		End Sub

		' Token: 0x04000A08 RID: 2568
		Private stateDt As DataTable

		' Token: 0x04000A09 RID: 2569
		Public currentRow As Integer

		' Token: 0x04000A0A RID: 2570
		Public currentColumn As Integer
	End Class
End Namespace
