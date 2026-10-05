Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000366 RID: 870
	<DesignerGenerated()>
	Public Partial Class frmReminderShow
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CE91 RID: 52881 RVA: 0x0005BDBB File Offset: 0x00059FBB
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmReminderShow_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmReminderShow_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005121 RID: 20769
		' (get) Token: 0x0600CE94 RID: 52884 RVA: 0x0005BDED File Offset: 0x00059FED
		' (set) Token: 0x0600CE95 RID: 52885 RVA: 0x0005BDF7 File Offset: 0x00059FF7
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005122 RID: 20770
		' (get) Token: 0x0600CE96 RID: 52886 RVA: 0x0005BE00 File Offset: 0x0005A000
		' (set) Token: 0x0600CE97 RID: 52887 RVA: 0x0080F764 File Offset: 0x0080D964
		Private _btnClose As Button
		Friend Overridable Property btnClose As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClose_Click
				Dim button As Button = Me._btnClose
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClose = value
				button = Me._btnClose
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005123 RID: 20771
		' (get) Token: 0x0600CE98 RID: 52888 RVA: 0x0005BE0A File Offset: 0x0005A00A
		' (set) Token: 0x0600CE99 RID: 52889 RVA: 0x0080F7A8 File Offset: 0x0080D9A8
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

		' Token: 0x17005124 RID: 20772
		' (get) Token: 0x0600CE9A RID: 52890 RVA: 0x0005BE14 File Offset: 0x0005A014
		' (set) Token: 0x0600CE9B RID: 52891 RVA: 0x0005BE1E File Offset: 0x0005A01E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x0600CE9C RID: 52892 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600CE9D RID: 52893 RVA: 0x0005BE27 File Offset: 0x0005A027
		Private Sub frmReminderShow_Load(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600CE9E RID: 52894 RVA: 0x0080F7EC File Offset: 0x0080D9EC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT msg from Reminder where mdate=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateAndTime.Today
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CE9F RID: 52895 RVA: 0x0080F8FC File Offset: 0x0080DAFC
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim controlText As Brush = SystemBrushes.ControlText
			e.Graphics.DrawString(text, Me.Font, controlText, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600CEA0 RID: 52896 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmReminderShow_KeyDown(sender As Object, e As KeyEventArgs)
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
