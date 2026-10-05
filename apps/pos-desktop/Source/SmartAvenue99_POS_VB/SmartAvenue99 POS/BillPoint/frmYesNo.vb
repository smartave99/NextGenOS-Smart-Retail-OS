Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000AA RID: 170
	<DesignerGenerated()>
	Public Partial Class frmYesNo
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001922 RID: 6434 RVA: 0x000132B1 File Offset: 0x000114B1
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCreditDebit_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170009E6 RID: 2534
		' (get) Token: 0x06001925 RID: 6437 RVA: 0x000132D1 File Offset: 0x000114D1
		' (set) Token: 0x06001926 RID: 6438 RVA: 0x00111670 File Offset: 0x0010F870
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

		' Token: 0x170009E7 RID: 2535
		' (get) Token: 0x06001927 RID: 6439 RVA: 0x000132DB File Offset: 0x000114DB
		' (set) Token: 0x06001928 RID: 6440 RVA: 0x000132E5 File Offset: 0x000114E5
		Friend Overridable Property Label1 As Label

		' Token: 0x170009E8 RID: 2536
		' (get) Token: 0x06001929 RID: 6441 RVA: 0x000132EE File Offset: 0x000114EE
		' (set) Token: 0x0600192A RID: 6442 RVA: 0x000132F8 File Offset: 0x000114F8
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x0600192B RID: 6443 RVA: 0x00013301 File Offset: 0x00011501
		Private Sub frmCreditDebit_Load(sender As Object, e As EventArgs)
			Me.YesNo()
			MyBase.StartPosition = FormStartPosition.CenterParent
		End Sub

		' Token: 0x0600192C RID: 6444 RVA: 0x001116B4 File Offset: 0x0010F8B4
		Private Sub YesNo()
			Try
				Me.grdCreditDebit.Rows.Clear()
				Me.grdCreditDebit.Rows.Add(New Object() { "Yes" })
				Me.grdCreditDebit.Rows(0).Cells(0).Tag = "Yes"
				Me.grdCreditDebit.Rows.Add(New Object() { "No" })
				Me.grdCreditDebit.Rows(1).Cells(0).Tag = "No"
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

		' Token: 0x0600192D RID: 6445 RVA: 0x00111820 File Offset: 0x0010FA20
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
						Dim flag6 As Boolean = TypeOf MyBase.Owner Is frmCustomersNew
						If flag6 Then
							Dim frmCustomersNew As frmCustomersNew = CType(MyBase.Owner, frmCustomersNew)
							frmCustomersNew.Focus()
							frmCustomersNew.dgw.Focus()
							frmCustomersNew.UpdateYesNo(Me.currentRow, Me.currentColumn, text)
						Else
							Dim flag7 As Boolean = TypeOf MyBase.Owner Is frmSubCategoryNew
							If flag7 Then
								Dim frmSubCategoryNew As frmSubCategoryNew = CType(MyBase.Owner, frmSubCategoryNew)
								frmSubCategoryNew.Focus()
								frmSubCategoryNew.dgw.Focus()
								frmSubCategoryNew.UpdateYesNo(Me.currentRow, Me.currentColumn, text)
							Else
								Dim flag8 As Boolean = TypeOf MyBase.Owner Is frmUnitMasterNew
								If flag8 Then
									Dim frmUnitMasterNew As frmUnitMasterNew = CType(MyBase.Owner, frmUnitMasterNew)
									MyProject.Forms.frmUnitMasterNew.Focus()
									MyProject.Forms.frmUnitMasterNew.dgw.Focus()
									MyProject.Forms.frmUnitMasterNew.UpdateYesNo(Me.currentRow, Me.currentColumn, text)
								Else
									Dim flag9 As Boolean = TypeOf MyBase.Owner Is frmTaxCategoryNew
									If flag9 Then
										Dim frmTaxCategoryNew As frmTaxCategoryNew = CType(MyBase.Owner, frmTaxCategoryNew)
										MyProject.Forms.frmTaxCategoryNew.Focus()
										MyProject.Forms.frmTaxCategoryNew.dgw.Focus()
										MyProject.Forms.frmTaxCategoryNew.UpdateYesNo(Me.currentRow, Me.currentColumn, text)
									Else
										Dim flag10 As Boolean = TypeOf MyBase.Owner Is frmProductSmart
										If flag10 Then
											Dim frmProductSmart As frmProductSmart = CType(MyBase.Owner, frmProductSmart)
											frmProductSmart.Focus()
											frmProductSmart.DataGridView1.Focus()
											frmProductSmart.UpdateYesNo(Me.currentRow, Me.currentColumn, text)
										End If
									End If
								End If
							End If
						End If
						MyBase.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in grdCreditDebit_KeyDown: " + ex.Message)
			End Try
		End Sub

		' Token: 0x040009BF RID: 2495
		Private stateDt As DataTable

		' Token: 0x040009C0 RID: 2496
		Public currentRow As Integer

		' Token: 0x040009C1 RID: 2497
		Public currentColumn As Integer
	End Class
End Namespace
