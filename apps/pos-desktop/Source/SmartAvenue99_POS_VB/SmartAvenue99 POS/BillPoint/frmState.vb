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
	' Token: 0x020001F8 RID: 504
	<DesignerGenerated()>
	Public Partial Class frmState
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600901E RID: 36894 RVA: 0x00046711 File Offset: 0x00044911
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmState_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700354B RID: 13643
		' (get) Token: 0x06009021 RID: 36897 RVA: 0x00046731 File Offset: 0x00044931
		' (set) Token: 0x06009022 RID: 36898 RVA: 0x0068E83C File Offset: 0x0068CA3C
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

		' Token: 0x1700354C RID: 13644
		' (get) Token: 0x06009023 RID: 36899 RVA: 0x0004673B File Offset: 0x0004493B
		' (set) Token: 0x06009024 RID: 36900 RVA: 0x0068E89C File Offset: 0x0068CA9C
		Private _txtStateName As TextBox
		Friend Overridable Property txtStateName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtStateName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtStateName_KeyDown
				Dim textBox As TextBox = Me._txtStateName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtStateName = value
				textBox = Me._txtStateName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700354D RID: 13645
		' (get) Token: 0x06009025 RID: 36901 RVA: 0x00046745 File Offset: 0x00044945
		' (set) Token: 0x06009026 RID: 36902 RVA: 0x0004674F File Offset: 0x0004494F
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x1700354E RID: 13646
		' (get) Token: 0x06009027 RID: 36903 RVA: 0x00046758 File Offset: 0x00044958
		' (set) Token: 0x06009028 RID: 36904 RVA: 0x00046762 File Offset: 0x00044962
		Friend Overridable Property Label1 As Label

		' Token: 0x06009029 RID: 36905 RVA: 0x0004676B File Offset: 0x0004496B
		Private Sub frmState_Load(sender As Object, e As EventArgs)
			Me.LoadStates()
		End Sub

		' Token: 0x0600902A RID: 36906 RVA: 0x0068E8FC File Offset: 0x0068CAFC
		Private Sub LoadStates()
			Try
				Me.stateDt = New DataTable()
				Me.txtStateName.Text = ""
				Me.txtStateName.Focus()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT name as StateName FROM tbl_state ORDER BY name"
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

		' Token: 0x0600902B RID: 36907 RVA: 0x0068EAC8 File Offset: 0x0068CCC8
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.txtStateName.Text.Trim().Length > 0
			If flag Then
				Dim dataView As DataView = New DataView(Me.stateDt)
				dataView.RowFilter = String.Format("StateName LIKE '{0}%'", Me.txtStateName.Text.Replace("'", "''"))
				Me.grdState.DataSource = dataView
			Else
				Me.grdState.DataSource = Me.stateDt
			End If
		End Sub

		' Token: 0x0600902C RID: 36908 RVA: 0x0068EB50 File Offset: 0x0068CD50
		Private Sub grdState_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.grdState.Visible = False
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
					Me.txtStateName.Focus()
					Me.txtStateName.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.txtStateName.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.txtStateName.Text = Me.txtStateName.Text.Remove(Me.txtStateName.Text.Length - 1, 1)
						Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
						Me.txtStateName.Focus()
						Me.txtStateName.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "a"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "b"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "c"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "d"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "e"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "f"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "g"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "h"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "i"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "j"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "k"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "l"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "m"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "n"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "o"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "p"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "q"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "r"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "s"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "t"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "u"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "v"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "w"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "x"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "y"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "z"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "0"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "1"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "2"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "3"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "4"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "5"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "6"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "7"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "8"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "9"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "+"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "-"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + "\"
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
				Me.txtStateName.Text = Me.txtStateName.Text + ","
				Me.txtStateName.[Select](Me.txtStateName.Text.Length, 0)
				Me.txtStateName.Focus()
				Me.txtStateName.ScrollToCaret()
			End If
		End Sub

		' Token: 0x0600902D RID: 36909 RVA: 0x00690598 File Offset: 0x0068E798
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

		' Token: 0x0600902E RID: 36910 RVA: 0x0069072C File Offset: 0x0068E92C
		Private Sub grdState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = Me.grdState.CurrentRow IsNot Nothing
				If flag2 Then
					Dim text As String = Me.grdState.CurrentRow.Cells(0).Value.ToString().Trim()
					Dim flag3 As Boolean = TypeOf MyBase.Owner Is frmPOSTouch
					If flag3 Then
						Dim frmPOSTouch As frmPOSTouch = CType(MyBase.Owner, frmPOSTouch)
						frmPOSTouch.UpdateState(Me.currentRow, Me.currentColumn, text)
					Else
						Dim flag4 As Boolean = TypeOf MyBase.Owner Is frmSuppliers
						If flag4 Then
							Dim frmSuppliers As frmSuppliers = CType(MyBase.Owner, frmSuppliers)
							frmSuppliers.UpdateState(Me.currentRow, Me.currentColumn, text)
						Else
							Dim flag5 As Boolean = TypeOf MyBase.Owner Is frmCustomersNew
							If flag5 Then
								Dim frmCustomersNew As frmCustomersNew = CType(MyBase.Owner, frmCustomersNew)
								frmCustomersNew.UpdateState(Me.currentRow, Me.currentColumn, text)
							End If
						End If
					End If
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04003FCF RID: 16335
		Private stateDt As DataTable

		' Token: 0x04003FD0 RID: 16336
		Public currentRow As Integer

		' Token: 0x04003FD1 RID: 16337
		Public currentColumn As Integer
	End Class
End Namespace
