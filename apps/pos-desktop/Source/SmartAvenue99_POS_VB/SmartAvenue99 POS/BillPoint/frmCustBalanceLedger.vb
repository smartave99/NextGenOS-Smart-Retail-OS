Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200033B RID: 827
	<DesignerGenerated()>
	Public Partial Class frmCustBalanceLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C10B RID: 49419 RVA: 0x007ACD70 File Offset: 0x007AAF70
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustBalanceLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustBalanceLedger_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmCustBalanceLedger_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CBE RID: 19646
		' (get) Token: 0x0600C10E RID: 49422 RVA: 0x0005644C File Offset: 0x0005464C
		' (set) Token: 0x0600C10F RID: 49423 RVA: 0x007AD97C File Offset: 0x007ABB7C
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CBF RID: 19647
		' (get) Token: 0x0600C110 RID: 49424 RVA: 0x00056456 File Offset: 0x00054656
		' (set) Token: 0x0600C111 RID: 49425 RVA: 0x00056460 File Offset: 0x00054660
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17004CC0 RID: 19648
		' (get) Token: 0x0600C112 RID: 49426 RVA: 0x00056469 File Offset: 0x00054669
		' (set) Token: 0x0600C113 RID: 49427 RVA: 0x00056473 File Offset: 0x00054673
		Friend Overridable Property Label1 As Label

		' Token: 0x17004CC1 RID: 19649
		' (get) Token: 0x0600C114 RID: 49428 RVA: 0x0005647C File Offset: 0x0005467C
		' (set) Token: 0x0600C115 RID: 49429 RVA: 0x007AD9C0 File Offset: 0x007ABBC0
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CC2 RID: 19650
		' (get) Token: 0x0600C116 RID: 49430 RVA: 0x00056486 File Offset: 0x00054686
		' (set) Token: 0x0600C117 RID: 49431 RVA: 0x00056490 File Offset: 0x00054690
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004CC3 RID: 19651
		' (get) Token: 0x0600C118 RID: 49432 RVA: 0x00056499 File Offset: 0x00054699
		' (set) Token: 0x0600C119 RID: 49433 RVA: 0x000564A3 File Offset: 0x000546A3
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004CC4 RID: 19652
		' (get) Token: 0x0600C11A RID: 49434 RVA: 0x000564AC File Offset: 0x000546AC
		' (set) Token: 0x0600C11B RID: 49435 RVA: 0x000564B6 File Offset: 0x000546B6
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004CC5 RID: 19653
		' (get) Token: 0x0600C11C RID: 49436 RVA: 0x000564BF File Offset: 0x000546BF
		' (set) Token: 0x0600C11D RID: 49437 RVA: 0x000564C9 File Offset: 0x000546C9
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004CC6 RID: 19654
		' (get) Token: 0x0600C11E RID: 49438 RVA: 0x000564D2 File Offset: 0x000546D2
		' (set) Token: 0x0600C11F RID: 49439 RVA: 0x000564DC File Offset: 0x000546DC
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004CC7 RID: 19655
		' (get) Token: 0x0600C120 RID: 49440 RVA: 0x000564E5 File Offset: 0x000546E5
		' (set) Token: 0x0600C121 RID: 49441 RVA: 0x000564EF File Offset: 0x000546EF
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004CC8 RID: 19656
		' (get) Token: 0x0600C122 RID: 49442 RVA: 0x000564F8 File Offset: 0x000546F8
		' (set) Token: 0x0600C123 RID: 49443 RVA: 0x00056502 File Offset: 0x00054702
		Friend Overridable Property Label5 As Label

		' Token: 0x17004CC9 RID: 19657
		' (get) Token: 0x0600C124 RID: 49444 RVA: 0x0005650B File Offset: 0x0005470B
		' (set) Token: 0x0600C125 RID: 49445 RVA: 0x00056515 File Offset: 0x00054715
		Friend Overridable Property Label4 As Label

		' Token: 0x17004CCA RID: 19658
		' (get) Token: 0x0600C126 RID: 49446 RVA: 0x0005651E File Offset: 0x0005471E
		' (set) Token: 0x0600C127 RID: 49447 RVA: 0x007ADA04 File Offset: 0x007ABC04
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox3_TextChanged
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CCB RID: 19659
		' (get) Token: 0x0600C128 RID: 49448 RVA: 0x00056528 File Offset: 0x00054728
		' (set) Token: 0x0600C129 RID: 49449 RVA: 0x00056532 File Offset: 0x00054732
		Friend Overridable Property Label2 As Label

		' Token: 0x0600C12A RID: 49450 RVA: 0x007ADA48 File Offset: 0x007ABC48
		Private Sub frmCustBalanceLedger_Load(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label2.Text, "POS", False) = 0
			If flag Then
				Me.txtCustomerID.Text = MyProject.Forms.frmPOS.txtCustomerID.Text
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.Label2.Text, "POSTouch", False) = 0
				If flag2 Then
					Me.txtCustomerID.Text = MyProject.Forms.frmPOSTouch.txtCustomerID.Text
				End If
			End If
			Me.getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600C12B RID: 49451 RVA: 0x007ADB48 File Offset: 0x007ABD48
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP " + Me.TextBox3.Text + " Date, RTRIM(Name), RTRIM(LedgerNo), RTRIM(Label), Debit, Credit from CustomerLedgerBook where PartyID=@d1 order by Date DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C12C RID: 49452 RVA: 0x007ADCAC File Offset: 0x007ABEAC
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600C12D RID: 49453 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600C12E RID: 49454 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustBalanceLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C12F RID: 49455 RVA: 0x0005653B File Offset: 0x0005473B
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.getdata()
		End Sub

		' Token: 0x0600C130 RID: 49456 RVA: 0x00056545 File Offset: 0x00054745
		Private Sub frmCustBalanceLedger_Closing(sender As Object, e As CancelEventArgs)
			Me.TextBox3.Text = "10"
		End Sub
	End Class
End Namespace
