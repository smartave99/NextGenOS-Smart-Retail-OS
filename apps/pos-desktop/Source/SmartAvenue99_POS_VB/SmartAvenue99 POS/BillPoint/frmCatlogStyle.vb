Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000CB RID: 203
	<DesignerGenerated()>
	Public Partial Class frmCatlogStyle
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002355 RID: 9045 RVA: 0x000183B3 File Offset: 0x000165B3
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCatlogStyle_Load
			Me.StyleName = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000E0B RID: 3595
		' (get) Token: 0x06002358 RID: 9048 RVA: 0x000183E1 File Offset: 0x000165E1
		' (set) Token: 0x06002359 RID: 9049 RVA: 0x00167B5C File Offset: 0x00165D5C
		Private _dgwBill As DataGridView
		Friend Overridable Property dgwBill As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgwBill
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgwBill_MouseClick
				Dim dataGridView As DataGridView = Me._dgwBill
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgwBill = value
				dataGridView = Me._dgwBill
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E0C RID: 3596
		' (get) Token: 0x0600235A RID: 9050 RVA: 0x000183EB File Offset: 0x000165EB
		' (set) Token: 0x0600235B RID: 9051 RVA: 0x000183F5 File Offset: 0x000165F5
		Friend Overridable Property PictureBox5 As PictureBox

		' Token: 0x17000E0D RID: 3597
		' (get) Token: 0x0600235C RID: 9052 RVA: 0x000183FE File Offset: 0x000165FE
		' (set) Token: 0x0600235D RID: 9053 RVA: 0x00167BA0 File Offset: 0x00165DA0
		Private _GelButton11 As GelButton
		Friend Overridable Property GelButton11 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton11_Click
				Dim gelButton As GelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton11 = value
				gelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000E0E RID: 3598
		' (get) Token: 0x0600235E RID: 9054 RVA: 0x00018408 File Offset: 0x00016608
		' (set) Token: 0x0600235F RID: 9055 RVA: 0x00018412 File Offset: 0x00016612
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x17000E0F RID: 3599
		' (get) Token: 0x06002360 RID: 9056 RVA: 0x0001841B File Offset: 0x0001661B
		' (set) Token: 0x06002361 RID: 9057 RVA: 0x00018425 File Offset: 0x00016625
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17000E10 RID: 3600
		' (get) Token: 0x06002362 RID: 9058 RVA: 0x0001842E File Offset: 0x0001662E
		' (set) Token: 0x06002363 RID: 9059 RVA: 0x00018438 File Offset: 0x00016638
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x06002364 RID: 9060 RVA: 0x00018441 File Offset: 0x00016641
		Private Sub frmCatlogStyle_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.FillStyleGrid()
		End Sub

		' Token: 0x06002365 RID: 9061 RVA: 0x00167BE4 File Offset: 0x00165DE4
		Public Sub Getdata()
			Try
				Dim text As String = "Select BillStyleId,BillStyleName,BillStyleImage from CatalogStyle order by BillStyleId"
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwBill.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwBill.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwBill.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002366 RID: 9062 RVA: 0x00167CF8 File Offset: 0x00165EF8
		Private Sub dgwBill_MouseClick(sender As Object, e As MouseEventArgs)
			Dim dataGridViewRow As DataGridViewRow = Me.dgwBill.SelectedRows(0)
			Me.PictureBox5.Image = Image.FromFile(Application.StartupPath + "\BillImg\" + dataGridViewRow.Cells(2).Value.ToString())
			Me.StyleName = dataGridViewRow.Cells(1).Value.ToString()
			Me.StyleId = dataGridViewRow.Cells(0).Value.ToString()
		End Sub

		' Token: 0x06002367 RID: 9063 RVA: 0x00167D88 File Offset: 0x00165F88
		Private Sub GelButton11_Click(sender As Object, e As EventArgs)
			Dim text As String = "Update CatalogStyle set isdisplay=0;Update CatalogStyle set isdisplay=1 where BillStyleId=" + Me.StyleId
			clsfun.ExecNonQuery(text, False)
			MyBase.Close()
			MyProject.Forms.frmProductImageMaker.GetStyleDetails()
		End Sub

		' Token: 0x06002368 RID: 9064 RVA: 0x00167DC8 File Offset: 0x00165FC8
		Public Sub FillStyleGrid()
			Dim text As String = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
			ModCommonClasses.cmd.CommandText = "Select BillStyleId from CatalogStyle where isdisplay=1"
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				text = ModCommonClasses.rdr.GetValue(0).ToString()
			End If
			Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
			If flag2 Then
				ModCommonClasses.rdr.Close()
			End If
			Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
			If flag3 Then
				ModCommonClasses.con.Close()
			End If
			Try
				For Each obj As Object In CType(Me.dgwBill.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag4 As Boolean = dataGridViewRow.Cells(0).Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow.Cells(0).Value.ToString().Trim(), text, False) = 0
					If flag4 Then
						Me.PictureBox5.Image = Image.FromFile(Application.StartupPath + "\BillImg\" + dataGridViewRow.Cells(2).Value.ToString())
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x04000E77 RID: 3703
		Private StyleId As String

		' Token: 0x04000E78 RID: 3704
		Private StyleName As String
	End Class
End Namespace
