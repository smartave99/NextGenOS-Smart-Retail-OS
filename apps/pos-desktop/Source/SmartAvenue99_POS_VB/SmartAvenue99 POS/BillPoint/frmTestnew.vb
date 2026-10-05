Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200020C RID: 524
	<DesignerGenerated()>
	Public Partial Class frmTestnew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06009898 RID: 39064 RVA: 0x0004A935 File Offset: 0x00048B35
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170038B3 RID: 14515
		' (get) Token: 0x0600989B RID: 39067 RVA: 0x0004A943 File Offset: 0x00048B43
		' (set) Token: 0x0600989C RID: 39068 RVA: 0x0004A94D File Offset: 0x00048B4D
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170038B4 RID: 14516
		' (get) Token: 0x0600989D RID: 39069 RVA: 0x0004A956 File Offset: 0x00048B56
		' (set) Token: 0x0600989E RID: 39070 RVA: 0x006D98B0 File Offset: 0x006D7AB0
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170038B5 RID: 14517
		' (get) Token: 0x0600989F RID: 39071 RVA: 0x0004A960 File Offset: 0x00048B60
		' (set) Token: 0x060098A0 RID: 39072 RVA: 0x006D98F4 File Offset: 0x006D7AF4
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170038B6 RID: 14518
		' (get) Token: 0x060098A1 RID: 39073 RVA: 0x0004A96A File Offset: 0x00048B6A
		' (set) Token: 0x060098A2 RID: 39074 RVA: 0x0004A974 File Offset: 0x00048B74
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x170038B7 RID: 14519
		' (get) Token: 0x060098A3 RID: 39075 RVA: 0x0004A97D File Offset: 0x00048B7D
		' (set) Token: 0x060098A4 RID: 39076 RVA: 0x0004A987 File Offset: 0x00048B87
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170038B8 RID: 14520
		' (get) Token: 0x060098A5 RID: 39077 RVA: 0x0004A990 File Offset: 0x00048B90
		' (set) Token: 0x060098A6 RID: 39078 RVA: 0x0004A99A File Offset: 0x00048B9A
		Friend Overridable Property Column29 As DataGridViewImageColumn

		' Token: 0x170038B9 RID: 14521
		' (get) Token: 0x060098A7 RID: 39079 RVA: 0x0004A9A3 File Offset: 0x00048BA3
		' (set) Token: 0x060098A8 RID: 39080 RVA: 0x0004A9AD File Offset: 0x00048BAD
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x170038BA RID: 14522
		' (get) Token: 0x060098A9 RID: 39081 RVA: 0x0004A9B6 File Offset: 0x00048BB6
		' (set) Token: 0x060098AA RID: 39082 RVA: 0x006D9938 File Offset: 0x006D7B38
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

		' Token: 0x170038BB RID: 14523
		' (get) Token: 0x060098AB RID: 39083 RVA: 0x0004A9C0 File Offset: 0x00048BC0
		' (set) Token: 0x060098AC RID: 39084 RVA: 0x0004A9CA File Offset: 0x00048BCA
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x060098AD RID: 39085 RVA: 0x006D997C File Offset: 0x006D7B7C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Images|*.jpg;jpeg;png"
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Me.PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
			End If
		End Sub

		' Token: 0x060098AE RID: 39086 RVA: 0x006D99C4 File Offset: 0x006D7BC4
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
			Console.WriteLine("Number of columns in DataTable4: " + Conversions.ToString(barcodeDataSet.DataTable4.Columns.Count))
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim text As String = dataGridViewRow.Cells(0).Value.ToString()
					Dim image As Image = CType(dataGridViewRow.Cells(1).Value, Image)
					Dim memoryStream As MemoryStream = New MemoryStream()
					image.Save(memoryStream, image.RawFormat)
					Dim array As Byte() = memoryStream.ToArray()
					barcodeDataSet.DataTable4.Rows.Add(New Object() { text, array })
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim crystalReport As CrystalReport1 = New CrystalReport1()
			crystalReport.SetDataSource(barcodeDataSet.Tables("DataTable4"))
			Dim rptForm As New frmReport()
			rptForm.CrystalReportViewer1.ReportSource = crystalReport
			rptForm.ShowDialog()
		End Sub

		' Token: 0x060098AF RID: 39087 RVA: 0x006D9B04 File Offset: 0x006D7D04
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.DataGridView1.Rows.Add(New Object() { Me.TextBox1.Text, Me.GetProductImage(CInt(Convert.ToInt16(Me.txtProductID.Text))) })
		End Sub

		' Token: 0x060098B0 RID: 39088 RVA: 0x006D9B50 File Offset: 0x006D7D50
		Public Function GetProductImage(pid As Integer) As Image
			Dim image2 As Image
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT top 1 photo from Product_Join where ProductID=" + Conversions.ToString(pid) + " order by ProductID desc", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim image As Image
				While ModCommonClasses.rdr.Read()
					Dim array As Byte() = CType(ModCommonClasses.rdr(0), Byte())
					Using memoryStream As MemoryStream = New MemoryStream(array)
						image = Image.FromStream(memoryStream)
					End Using
				End While
				ModCommonClasses.con.Close()
				image2 = image
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return image2
		End Function
	End Class
End Namespace
