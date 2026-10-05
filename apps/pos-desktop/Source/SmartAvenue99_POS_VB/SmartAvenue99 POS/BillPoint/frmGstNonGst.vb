Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000A7 RID: 167
	<DesignerGenerated()>
	Public Partial Class frmGstNonGst
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060018FD RID: 6397 RVA: 0x0001318B File Offset: 0x0001138B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCreditDebit_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170009DD RID: 2525
		' (get) Token: 0x06001900 RID: 6400 RVA: 0x000131AB File Offset: 0x000113AB
		' (set) Token: 0x06001901 RID: 6401 RVA: 0x0010FE9C File Offset: 0x0010E09C
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

		' Token: 0x170009DE RID: 2526
		' (get) Token: 0x06001902 RID: 6402 RVA: 0x000131B5 File Offset: 0x000113B5
		' (set) Token: 0x06001903 RID: 6403 RVA: 0x000131BF File Offset: 0x000113BF
		Friend Overridable Property Label1 As Label

		' Token: 0x170009DF RID: 2527
		' (get) Token: 0x06001904 RID: 6404 RVA: 0x000131C8 File Offset: 0x000113C8
		' (set) Token: 0x06001905 RID: 6405 RVA: 0x000131D2 File Offset: 0x000113D2
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x06001906 RID: 6406 RVA: 0x000131DB File Offset: 0x000113DB
		Private Sub frmCreditDebit_Load(sender As Object, e As EventArgs)
			Me.YesNo()
			MyBase.StartPosition = FormStartPosition.CenterParent
		End Sub

		' Token: 0x06001907 RID: 6407 RVA: 0x0010FEE0 File Offset: 0x0010E0E0
		Private Sub YesNo()
			Try
				Me.grdCreditDebit.Rows.Clear()
				Me.grdCreditDebit.Rows.Add(New Object() { "GST" })
				Me.grdCreditDebit.Rows(0).Cells(0).Tag = "GST"
				Me.grdCreditDebit.Rows.Add(New Object() { "NON GST" })
				Me.grdCreditDebit.Rows(1).Cells(0).Tag = "NON GST"
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

		' Token: 0x06001908 RID: 6408 RVA: 0x0011004C File Offset: 0x0010E24C
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
						Dim flag6 As Boolean = TypeOf MyBase.Owner Is frmTaxSettingsNew
						If flag6 Then
							Dim frmTaxSettingsNew As frmTaxSettingsNew = CType(MyBase.Owner, frmTaxSettingsNew)
							frmTaxSettingsNew.Focus()
							frmTaxSettingsNew.dgw.Focus()
							frmTaxSettingsNew.UpdateYesNo(Me.currentRow, Me.currentColumn, text)
						End If
						MyBase.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in grdCreditDebit_KeyDown: " + ex.Message)
			End Try
		End Sub

		' Token: 0x040009AA RID: 2474
		Private stateDt As DataTable

		' Token: 0x040009AB RID: 2475
		Public currentRow As Integer

		' Token: 0x040009AC RID: 2476
		Public currentColumn As Integer
	End Class
End Namespace
