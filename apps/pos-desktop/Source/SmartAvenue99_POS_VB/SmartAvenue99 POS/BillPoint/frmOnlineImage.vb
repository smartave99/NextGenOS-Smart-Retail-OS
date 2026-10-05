Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports DevNet
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020002A4 RID: 676
	<DesignerGenerated()>
	Public Partial Class frmOnlineImage
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600AD2D RID: 44333 RVA: 0x0073ADB8 File Offset: 0x00738FB8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmOnlineImage_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmOnlineImage_FormClosing
			AddHandler MyBase.KeyDown, AddressOf Me.frmOnlineImage_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170042F4 RID: 17140
		' (get) Token: 0x0600AD30 RID: 44336 RVA: 0x0005099A File Offset: 0x0004EB9A
		' (set) Token: 0x0600AD31 RID: 44337 RVA: 0x0073B154 File Offset: 0x00739354
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellContentDoubleClick
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentDoubleClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentDoubleClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170042F5 RID: 17141
		' (get) Token: 0x0600AD32 RID: 44338 RVA: 0x000509A4 File Offset: 0x0004EBA4
		' (set) Token: 0x0600AD33 RID: 44339 RVA: 0x000509AE File Offset: 0x0004EBAE
		Friend Overridable Property Label1 As Label

		' Token: 0x170042F6 RID: 17142
		' (get) Token: 0x0600AD34 RID: 44340 RVA: 0x000509B7 File Offset: 0x0004EBB7
		' (set) Token: 0x0600AD35 RID: 44341 RVA: 0x000509C1 File Offset: 0x0004EBC1
		Friend Overridable Property Label2 As Label

		' Token: 0x0600AD36 RID: 44342 RVA: 0x000509CA File Offset: 0x0004EBCA
		Private Sub frmOnlineImage_Load(sender As Object, e As EventArgs)
			Me.dt()
		End Sub

		' Token: 0x0600AD37 RID: 44343 RVA: 0x0073B198 File Offset: 0x00739398
		Public Async Sub dt()
			' The following expression was wrapped in a checked-expression
			Dim result As List(Of WebImage) = Await QImage.Query(Me.Label1.Text, CInt(Math.Round(Conversion.Val(Me.Label2.Text))))
			Me.DataGridView2.DataSource = result
		End Sub

		' Token: 0x0600AD38 RID: 44344 RVA: 0x0073B1D4 File Offset: 0x007393D4
		Private Sub DataGridView2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = Me.DataGridView2.CurrentCell.ColumnIndex.Equals(0) AndAlso e.RowIndex <> -1
			If flag Then
				Dim flag2 As Boolean = Me.DataGridView2.CurrentCell IsNot Nothing AndAlso Me.DataGridView2.CurrentCell.Value IsNot Nothing
				If flag2 Then
					Dim image As Image = CType(Me.DataGridView2.CurrentCell.Value, Image)
					MyProject.Forms.frmProduct.Picture.Image = image
					Try
						For Each obj As Object In CType(MyProject.Forms.frmProduct.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							MyProject.Forms.frmProduct.dgw.Rows.Remove(dataGridViewRow)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(MyProject.Forms.frmProduct.dgw.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							MyProject.Forms.frmProduct.dgw.Rows.Remove(dataGridViewRow2)
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					MyProject.Forms.frmProduct.dgw.Rows.Add(New Object() { MyProject.Forms.frmProduct.Picture.Image })
				End If
			End If
		End Sub

		' Token: 0x0600AD39 RID: 44345 RVA: 0x000509D4 File Offset: 0x0004EBD4
		Private Sub frmOnlineImage_FormClosing(sender As Object, e As FormClosingEventArgs)
			Me.Label1.Text = ""
			Me.Label2.Text = ""
			Me.DataGridView2.DataSource = Nothing
		End Sub

		' Token: 0x0600AD3A RID: 44346 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmOnlineImage_KeyDown(sender As Object, e As KeyEventArgs)
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
