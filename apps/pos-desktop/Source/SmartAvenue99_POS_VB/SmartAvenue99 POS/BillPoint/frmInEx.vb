Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000A8 RID: 168
	<DesignerGenerated()>
	Public Partial Class frmInEx
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001909 RID: 6409 RVA: 0x000131ED File Offset: 0x000113ED
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCreditDebit_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170009E0 RID: 2528
		' (get) Token: 0x0600190C RID: 6412 RVA: 0x0001320D File Offset: 0x0001140D
		' (set) Token: 0x0600190D RID: 6413 RVA: 0x00110684 File Offset: 0x0010E884
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

		' Token: 0x170009E1 RID: 2529
		' (get) Token: 0x0600190E RID: 6414 RVA: 0x00013217 File Offset: 0x00011417
		' (set) Token: 0x0600190F RID: 6415 RVA: 0x00013221 File Offset: 0x00011421
		Friend Overridable Property Label1 As Label

		' Token: 0x170009E2 RID: 2530
		' (get) Token: 0x06001910 RID: 6416 RVA: 0x0001322A File Offset: 0x0001142A
		' (set) Token: 0x06001911 RID: 6417 RVA: 0x00013234 File Offset: 0x00011434
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x06001912 RID: 6418 RVA: 0x0001323D File Offset: 0x0001143D
		Private Sub frmCreditDebit_Load(sender As Object, e As EventArgs)
			Me.YesNo()
			MyBase.StartPosition = FormStartPosition.CenterParent
		End Sub

		' Token: 0x06001913 RID: 6419 RVA: 0x001106C8 File Offset: 0x0010E8C8
		Private Sub YesNo()
			Try
				Me.grdCreditDebit.Rows.Clear()
				Me.grdCreditDebit.Rows.Add(New Object() { "Inclusive" })
				Me.grdCreditDebit.Rows(0).Cells(0).Tag = "Inclusive"
				Me.grdCreditDebit.Rows.Add(New Object() { "Exclusive" })
				Me.grdCreditDebit.Rows(1).Cells(0).Tag = "Exclusive"
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

		' Token: 0x06001914 RID: 6420 RVA: 0x00110834 File Offset: 0x0010EA34
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
							frmProductSmart.UpdateTaxType(Me.currentRow, Me.currentColumn, text)
						End If
						MyBase.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in grdCreditDebit_KeyDown: " + ex.Message)
			End Try
		End Sub

		' Token: 0x040009B1 RID: 2481
		Private stateDt As DataTable

		' Token: 0x040009B2 RID: 2482
		Public currentRow As Integer

		' Token: 0x040009B3 RID: 2483
		Public currentColumn As Integer
	End Class
End Namespace
