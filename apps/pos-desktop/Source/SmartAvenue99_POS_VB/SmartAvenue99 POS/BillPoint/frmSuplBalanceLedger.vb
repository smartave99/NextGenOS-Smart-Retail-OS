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
	' Token: 0x020004DC RID: 1244
	<DesignerGenerated()>
	Public Partial Class frmSuplBalanceLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FD67 RID: 64871 RVA: 0x0006F09B File Offset: 0x0006D29B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSuplBalanceLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSuplBalanceLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170060DB RID: 24795
		' (get) Token: 0x0600FD6A RID: 64874 RVA: 0x0006F0CD File Offset: 0x0006D2CD
		' (set) Token: 0x0600FD6B RID: 64875 RVA: 0x0006F0D7 File Offset: 0x0006D2D7
		Friend Overridable Property Label1 As Label

		' Token: 0x170060DC RID: 24796
		' (get) Token: 0x0600FD6C RID: 64876 RVA: 0x0006F0E0 File Offset: 0x0006D2E0
		' (set) Token: 0x0600FD6D RID: 64877 RVA: 0x0006F0EA File Offset: 0x0006D2EA
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170060DD RID: 24797
		' (get) Token: 0x0600FD6E RID: 64878 RVA: 0x0006F0F3 File Offset: 0x0006D2F3
		' (set) Token: 0x0600FD6F RID: 64879 RVA: 0x00979844 File Offset: 0x00977A44
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

		' Token: 0x170060DE RID: 24798
		' (get) Token: 0x0600FD70 RID: 64880 RVA: 0x0006F0FD File Offset: 0x0006D2FD
		' (set) Token: 0x0600FD71 RID: 64881 RVA: 0x0006F107 File Offset: 0x0006D307
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170060DF RID: 24799
		' (get) Token: 0x0600FD72 RID: 64882 RVA: 0x0006F110 File Offset: 0x0006D310
		' (set) Token: 0x0600FD73 RID: 64883 RVA: 0x0006F11A File Offset: 0x0006D31A
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170060E0 RID: 24800
		' (get) Token: 0x0600FD74 RID: 64884 RVA: 0x0006F123 File Offset: 0x0006D323
		' (set) Token: 0x0600FD75 RID: 64885 RVA: 0x0006F12D File Offset: 0x0006D32D
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170060E1 RID: 24801
		' (get) Token: 0x0600FD76 RID: 64886 RVA: 0x0006F136 File Offset: 0x0006D336
		' (set) Token: 0x0600FD77 RID: 64887 RVA: 0x0006F140 File Offset: 0x0006D340
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170060E2 RID: 24802
		' (get) Token: 0x0600FD78 RID: 64888 RVA: 0x0006F149 File Offset: 0x0006D349
		' (set) Token: 0x0600FD79 RID: 64889 RVA: 0x0006F153 File Offset: 0x0006D353
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170060E3 RID: 24803
		' (get) Token: 0x0600FD7A RID: 64890 RVA: 0x0006F15C File Offset: 0x0006D35C
		' (set) Token: 0x0600FD7B RID: 64891 RVA: 0x0006F166 File Offset: 0x0006D366
		Friend Overridable Property txtSupplierID As TextBox

		' Token: 0x170060E4 RID: 24804
		' (get) Token: 0x0600FD7C RID: 64892 RVA: 0x0006F16F File Offset: 0x0006D36F
		' (set) Token: 0x0600FD7D RID: 64893 RVA: 0x00979888 File Offset: 0x00977A88
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

		' Token: 0x0600FD7E RID: 64894 RVA: 0x009798CC File Offset: 0x00977ACC
		Private Sub frmSuplBalanceLedger_Load(sender As Object, e As EventArgs)
			Me.txtSupplierID.Text = MyProject.Forms.frmPurchaseEntry.txtSupplierID.Text
			Me.getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600FD7F RID: 64895 RVA: 0x00979970 File Offset: 0x00977B70
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Date, RTRIM(Name), RTRIM(LedgerNo), RTRIM(Label), Debit, Credit from SupplierLedgerBook where PartyID=@d1 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
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

		' Token: 0x0600FD80 RID: 64896 RVA: 0x00979ABC File Offset: 0x00977CBC
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

		' Token: 0x0600FD81 RID: 64897 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600FD82 RID: 64898 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSuplBalanceLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
