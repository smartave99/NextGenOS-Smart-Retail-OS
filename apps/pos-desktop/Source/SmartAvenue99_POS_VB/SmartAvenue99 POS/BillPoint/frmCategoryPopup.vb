Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000080 RID: 128
	<DesignerGenerated()>
	Public Partial Class frmCategoryPopup
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001536 RID: 5430 RVA: 0x00011516 File Offset: 0x0000F716
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmState_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000889 RID: 2185
		' (get) Token: 0x06001539 RID: 5433 RVA: 0x00011536 File Offset: 0x0000F736
		' (set) Token: 0x0600153A RID: 5434 RVA: 0x000E4214 File Offset: 0x000E2414
		Private _grdState As DataGridView
		Friend Overridable Property grdState As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._grdState
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.grdState_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.grdState_KeyDown
				Dim dataGridView As DataGridView = Me._grdState
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyUp, keyEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler2
				End If
				Me._grdState = value
				dataGridView = Me._grdState
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyUp, keyEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700088A RID: 2186
		' (get) Token: 0x0600153B RID: 5435 RVA: 0x00011540 File Offset: 0x0000F740
		' (set) Token: 0x0600153C RID: 5436 RVA: 0x000E4274 File Offset: 0x000E2474
		Private _txtCategoryName As TextBox
		Friend Overridable Property txtCategoryName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCategoryName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtStateName_KeyDown
				Dim textBox As TextBox = Me._txtCategoryName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCategoryName = value
				textBox = Me._txtCategoryName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700088B RID: 2187
		' (get) Token: 0x0600153D RID: 5437 RVA: 0x0001154A File Offset: 0x0000F74A
		' (set) Token: 0x0600153E RID: 5438 RVA: 0x00011554 File Offset: 0x0000F754
		Friend Overridable Property Label1 As Label

		' Token: 0x1700088C RID: 2188
		' (get) Token: 0x0600153F RID: 5439 RVA: 0x0001155D File Offset: 0x0000F75D
		' (set) Token: 0x06001540 RID: 5440 RVA: 0x00011567 File Offset: 0x0000F767
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x06001541 RID: 5441 RVA: 0x00011570 File Offset: 0x0000F770
		Private Sub frmState_Load(sender As Object, e As EventArgs)
			Me.LoadCategory()
		End Sub

		' Token: 0x06001542 RID: 5442 RVA: 0x000E42D4 File Offset: 0x000E24D4
		Private Sub LoadCategory()
			Try
				Me.stateDt = New DataTable()
				Me.txtCategoryName.Text = ""
				Me.txtCategoryName.Focus()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT CategoryName FROM Category ORDER BY CategoryName"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							sqlDataAdapter.Fill(Me.stateDt)
							Me.grdState.DataSource = Me.stateDt
						End Using
					End Using
				End Using
				Me.grdState.Focus()
				Dim flag As Boolean = Me.grdState.RowCount > 0
				If flag Then
					Me.grdState.CurrentCell = Me.grdState.Rows(0).Cells(0)
				End If
				Me.grdState.BeginEdit(False)
				Me.grdState.EndEdit()
				Application.DoEvents()
				Me.grdState.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
				Me.grdState.SelectionMode = DataGridViewSelectionMode.FullRowSelect
				Me.grdState.[ReadOnly] = True
			Catch ex As Exception
				MessageBox.Show("Error loading states: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06001543 RID: 5443 RVA: 0x000E44A0 File Offset: 0x000E26A0
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.txtCategoryName.Text.Trim().Length > 0
			If flag Then
				Dim dataView As DataView = New DataView(Me.stateDt)
				dataView.RowFilter = String.Format("CategoryName LIKE '{0}%'", Me.txtCategoryName.Text.Replace("'", "''"))
				Me.grdState.DataSource = dataView
			Else
				Me.grdState.DataSource = Me.stateDt
			End If
		End Sub

		' Token: 0x06001544 RID: 5444 RVA: 0x000E4528 File Offset: 0x000E2728
		Private Sub grdState_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.grdState.Visible = False
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
					Me.txtCategoryName.Focus()
					Me.txtCategoryName.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.txtCategoryName.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.txtCategoryName.Text = Me.txtCategoryName.Text.Remove(Me.txtCategoryName.Text.Length - 1, 1)
						Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
						Me.txtCategoryName.Focus()
						Me.txtCategoryName.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "a"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "b"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "c"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "d"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "e"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "f"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "g"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "h"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "i"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "j"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "k"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "l"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "m"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "n"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "o"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "p"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "q"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "r"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "s"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "t"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "u"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "v"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "w"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "x"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "y"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "z"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "0"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "1"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "2"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "3"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "4"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "5"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "6"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "7"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "8"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "9"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "+"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "-"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + "\"
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
				Me.txtCategoryName.Text = Me.txtCategoryName.Text + ","
				Me.txtCategoryName.[Select](Me.txtCategoryName.Text.Length, 0)
				Me.txtCategoryName.Focus()
				Me.txtCategoryName.ScrollToCaret()
			End If
		End Sub

		' Token: 0x06001545 RID: 5445 RVA: 0x000E5F70 File Offset: 0x000E4170
		Private Sub txtStateName_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return] AndAlso Me.grdState.Rows.Count = 1
				If flag Then
					Me.grdState.CurrentCell = Me.grdState.Rows(0).Cells(0)
					Me.grdState.Focus()
					SendKeys.Send("{ENTER}")
					e.Handled = True
				Else
					Dim flag2 As Boolean = e.KeyCode = Keys.Down AndAlso Me.grdState.Rows.Count > 0
					If flag2 Then
						Me.grdState.Focus()
						Me.grdState.CurrentCell = Me.grdState.Rows(0).Cells(0)
						e.Handled = True
					End If
					Dim flag3 As Boolean = e.KeyCode = Keys.[Return] AndAlso Me.grdState.Rows.Count > 1
					If flag3 Then
						Me.grdState.Focus()
						Me.grdState.CurrentCell = Me.grdState.Rows(0).Cells(0)
						SendKeys.Send("{ENTER}")
						e.Handled = True
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in txtStateName_KeyDown: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06001546 RID: 5446 RVA: 0x000E6104 File Offset: 0x000E4304
		Private Sub grdState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = Me.grdState.CurrentRow IsNot Nothing
				If flag2 Then
					Dim text As String = Me.grdState.CurrentRow.Cells(0).Value.ToString().Trim()
					Dim flag3 As Boolean = TypeOf MyBase.Owner Is frmSubCategoryNew
					If flag3 Then
						Dim frmSubCategoryNew As frmSubCategoryNew = CType(MyBase.Owner, frmSubCategoryNew)
						frmSubCategoryNew.UpdateCategoryName(Me.currentRow, Me.currentColumn, text)
					End If
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0400074B RID: 1867
		Private stateDt As DataTable

		' Token: 0x0400074C RID: 1868
		Public currentRow As Integer

		' Token: 0x0400074D RID: 1869
		Public currentColumn As Integer
	End Class
End Namespace
