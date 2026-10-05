Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports Bunifu.Framework.UI
Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000475 RID: 1141
		Public Partial Class QRGenerator
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600E820 RID: 59424 RVA: 0x000661CE File Offset: 0x000643CE
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.QRGenerator_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700590A RID: 22794
		' (get) Token: 0x0600E823 RID: 59427 RVA: 0x000661EE File Offset: 0x000643EE
		' (set) Token: 0x0600E824 RID: 59428 RVA: 0x000661F8 File Offset: 0x000643F8
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x1700590B RID: 22795
		' (get) Token: 0x0600E825 RID: 59429 RVA: 0x00066201 File Offset: 0x00064401
		' (set) Token: 0x0600E826 RID: 59430 RVA: 0x0006620B File Offset: 0x0006440B
		Friend Overridable Property txtCode As TextBox

		' Token: 0x1700590C RID: 22796
		' (get) Token: 0x0600E827 RID: 59431 RVA: 0x00066214 File Offset: 0x00064414
		' (set) Token: 0x0600E828 RID: 59432 RVA: 0x008CEBEC File Offset: 0x008CCDEC
		Private _btnGenerate As Button
		Friend Overridable Property btnGenerate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGenerate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGenerate_Click
				Dim button As Button = Me._btnGenerate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGenerate = value
				button = Me._btnGenerate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700590D RID: 22797
		' (get) Token: 0x0600E829 RID: 59433 RVA: 0x0006621E File Offset: 0x0006441E
		' (set) Token: 0x0600E82A RID: 59434 RVA: 0x008CEC30 File Offset: 0x008CCE30
		Private _btnExport As Button
		Friend Overridable Property btnExport As Button
			<CompilerGenerated()>
			Get
				Return Me._btnExport
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExport_Click
				Dim button As Button = Me._btnExport
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnExport = value
				button = Me._btnExport
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700590E RID: 22798
		' (get) Token: 0x0600E82B RID: 59435 RVA: 0x00066228 File Offset: 0x00064428
		' (set) Token: 0x0600E82C RID: 59436 RVA: 0x00066232 File Offset: 0x00064432
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x1700590F RID: 22799
		' (get) Token: 0x0600E82D RID: 59437 RVA: 0x0006623B File Offset: 0x0006443B
		' (set) Token: 0x0600E82E RID: 59438 RVA: 0x00066245 File Offset: 0x00064445
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17005910 RID: 22800
		' (get) Token: 0x0600E82F RID: 59439 RVA: 0x0006624E File Offset: 0x0006444E
		' (set) Token: 0x0600E830 RID: 59440 RVA: 0x00066258 File Offset: 0x00064458
		Friend Overridable Property BunifuCards1 As BunifuCards

		' Token: 0x17005911 RID: 22801
		' (get) Token: 0x0600E831 RID: 59441 RVA: 0x00066261 File Offset: 0x00064461
		' (set) Token: 0x0600E832 RID: 59442 RVA: 0x0006626B File Offset: 0x0006446B
		Friend Overridable Property Label2 As Label

		' Token: 0x17005912 RID: 22802
		' (get) Token: 0x0600E833 RID: 59443 RVA: 0x00066274 File Offset: 0x00064474
		' (set) Token: 0x0600E834 RID: 59444 RVA: 0x008CEC74 File Offset: 0x008CCE74
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

		' Token: 0x17005913 RID: 22803
		' (get) Token: 0x0600E835 RID: 59445 RVA: 0x0006627E File Offset: 0x0006447E
		' (set) Token: 0x0600E836 RID: 59446 RVA: 0x008CECB8 File Offset: 0x008CCEB8
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

		' Token: 0x0600E837 RID: 59447 RVA: 0x008CECFC File Offset: 0x008CCEFC
		Private Sub btnGenerate_Click(sender As Object, e As EventArgs)
			Try
				Me.qrcodeGen()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			End Try
		End Sub

		' Token: 0x0600E838 RID: 59448 RVA: 0x008CED48 File Offset: 0x008CCF48
		Private Sub qrcodeGen()
			Try
				Dim qrcodeEncoder As QRCodeEncoder = New QRCodeEncoder()
				qrcodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
				qrcodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
				Me.PictureBox1.Image = qrcodeEncoder.Encode(Me.txtCode.Text, Encoding.UTF8)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			End Try
		End Sub

		' Token: 0x0600E839 RID: 59449 RVA: 0x008CEDC8 File Offset: 0x008CCFC8
		Private Sub btnExport_Click(sender As Object, e As EventArgs)
			Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
			saveFileDialog.Filter = "JPEG File|*.jpeg"
			Dim flag As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Try
					Dim flag2 As Boolean = Me.PictureBox1.Image IsNot Nothing
					If flag2 Then
						Me.PictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg)
						MessageBox.Show("QR Code Image is Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End Try
			End If
		End Sub

		' Token: 0x0600E83A RID: 59450 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600E83B RID: 59451 RVA: 0x00066288 File Offset: 0x00064488
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.txtCode.Text = ""
			Me.PictureBox1.Image = Nothing
		End Sub

		' Token: 0x0600E83C RID: 59452 RVA: 0x000662A9 File Offset: 0x000644A9
		Private Sub QRGenerator_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x0600E83D RID: 59453 RVA: 0x008CEE74 File Offset: 0x008CD074
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						GlobalVariables.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not GlobalVariables.translations.ContainsKey(text2)
								If flag Then
									GlobalVariables.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Me.UpdateAllHeaders(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600E83E RID: 59454 RVA: 0x008CEFEC File Offset: 0x008CD1EC
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
				End If
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.UpdateAllControls(control, translations)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600E83F RID: 59455 RVA: 0x008CF0A8 File Offset: 0x008CD2A8
		Private Sub UpdateAllHeaders(container As Control)
			Try
				For Each obj As Object In container.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						Else
							Dim flag3 As Boolean = TypeOf control Is TabControl
							If flag3 Then
								Me.UpdateTabControlHeaders(CType(control, TabControl))
							End If
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateAllHeaders(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600E840 RID: 59456 RVA: 0x00086F78 File Offset: 0x00085178
		Private Sub UpdateListViewHeaders(listView As ListView)
			Try
				For Each obj As Object In listView.Columns
					Dim columnHeader As ColumnHeader = CType(obj, ColumnHeader)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(columnHeader.Text)
					If flag Then
						columnHeader.Text = GlobalVariables.translations(columnHeader.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600E841 RID: 59457 RVA: 0x00087000 File Offset: 0x00085200
		Private Sub UpdateTabControlHeaders(tabControl As TabControl)
			Try
				For Each obj As Object In tabControl.TabPages
					Dim tabPage As TabPage = CType(obj, TabPage)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(tabPage.Text)
					If flag Then
						tabPage.Text = GlobalVariables.translations(tabPage.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600E842 RID: 59458 RVA: 0x00087088 File Offset: 0x00085288
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub
	End Class
End Namespace
