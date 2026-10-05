Imports System
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
	' Token: 0x0200007B RID: 123
	<DesignerGenerated()>
	Public Partial Class frmBillStyle
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001488 RID: 5256 RVA: 0x00010FE4 File Offset: 0x0000F1E4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBillStyle_Load
			Me.testval = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700084A RID: 2122
		' (get) Token: 0x0600148B RID: 5259 RVA: 0x00011012 File Offset: 0x0000F212
		' (set) Token: 0x0600148C RID: 5260 RVA: 0x000DE9B8 File Offset: 0x000DCBB8
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700084B RID: 2123
		' (get) Token: 0x0600148D RID: 5261 RVA: 0x0001101C File Offset: 0x0000F21C
		' (set) Token: 0x0600148E RID: 5262 RVA: 0x000DE9FC File Offset: 0x000DCBFC
		Private _RA4 As RadioButton
		Friend Overridable Property RA4 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RA4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RA4_CheckedChanged
				Dim radioButton As RadioButton = Me._RA4
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RA4 = value
				radioButton = Me._RA4
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700084C RID: 2124
		' (get) Token: 0x0600148F RID: 5263 RVA: 0x00011026 File Offset: 0x0000F226
		' (set) Token: 0x06001490 RID: 5264 RVA: 0x000DEA40 File Offset: 0x000DCC40
		Private _RA5 As RadioButton
		Friend Overridable Property RA5 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RA5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RA5_CheckedChanged
				Dim radioButton As RadioButton = Me._RA5
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RA5 = value
				radioButton = Me._RA5
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700084D RID: 2125
		' (get) Token: 0x06001491 RID: 5265 RVA: 0x00011030 File Offset: 0x0000F230
		' (set) Token: 0x06001492 RID: 5266 RVA: 0x000DEA84 File Offset: 0x000DCC84
		Private _R3Inch As RadioButton
		Friend Overridable Property R3Inch As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._R3Inch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.R3Inch_CheckedChanged
				Dim radioButton As RadioButton = Me._R3Inch
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._R3Inch = value
				radioButton = Me._R3Inch
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700084E RID: 2126
		' (get) Token: 0x06001493 RID: 5267 RVA: 0x0001103A File Offset: 0x0000F23A
		' (set) Token: 0x06001494 RID: 5268 RVA: 0x000DEAC8 File Offset: 0x000DCCC8
		Private _RAll As RadioButton
		Friend Overridable Property RAll As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RAll_CheckedChanged
				Dim radioButton As RadioButton = Me._RAll
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RAll = value
				radioButton = Me._RAll
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700084F RID: 2127
		' (get) Token: 0x06001495 RID: 5269 RVA: 0x00011044 File Offset: 0x0000F244
		' (set) Token: 0x06001496 RID: 5270 RVA: 0x0001104E File Offset: 0x0000F24E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000850 RID: 2128
		' (get) Token: 0x06001497 RID: 5271 RVA: 0x00011057 File Offset: 0x0000F257
		' (set) Token: 0x06001498 RID: 5272 RVA: 0x00011061 File Offset: 0x0000F261
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000851 RID: 2129
		' (get) Token: 0x06001499 RID: 5273 RVA: 0x0001106A File Offset: 0x0000F26A
		' (set) Token: 0x0600149A RID: 5274 RVA: 0x00011074 File Offset: 0x0000F274
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000852 RID: 2130
		' (get) Token: 0x0600149B RID: 5275 RVA: 0x0001107D File Offset: 0x0000F27D
		' (set) Token: 0x0600149C RID: 5276 RVA: 0x00011087 File Offset: 0x0000F287
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000853 RID: 2131
		' (get) Token: 0x0600149D RID: 5277 RVA: 0x00011090 File Offset: 0x0000F290
		' (set) Token: 0x0600149E RID: 5278 RVA: 0x000DEB0C File Offset: 0x000DCD0C
		Private _btnCash As GelButton
		Friend Overridable Property btnCash As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnCash
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnCash_Click
				Dim gelButton As GelButton = Me._btnCash
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnCash = value
				gelButton = Me._btnCash
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000854 RID: 2132
		' (get) Token: 0x0600149F RID: 5279 RVA: 0x0001109A File Offset: 0x0000F29A
		' (set) Token: 0x060014A0 RID: 5280 RVA: 0x000110A4 File Offset: 0x0000F2A4
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17000855 RID: 2133
		' (get) Token: 0x060014A1 RID: 5281 RVA: 0x000110AD File Offset: 0x0000F2AD
		' (set) Token: 0x060014A2 RID: 5282 RVA: 0x000DEB50 File Offset: 0x000DCD50
		Private _btnTwo As GelButton
		Friend Overridable Property btnTwo As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnTwo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnTwo_Click
				Dim gelButton As GelButton = Me._btnTwo
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnTwo = value
				gelButton = Me._btnTwo
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060014A3 RID: 5283 RVA: 0x000DEB94 File Offset: 0x000DCD94
		Public Sub Getdata()
			Try
				Dim text As String = ""
				Dim checked As Boolean = Me.RA4.Checked
				If checked Then
					text = "A4"
				Else
					Dim checked2 As Boolean = Me.RA5.Checked
					If checked2 Then
						text = "A5"
					Else
						Dim checked3 As Boolean = Me.R3Inch.Checked
						If checked3 Then
							text = "3Inch"
						End If
					End If
				End If
				Dim text2 As String = "Select BillStyleId,BillStyleName,PrintPreviewType,BillStyleImage from BillPreview where 1=1"
				Dim flag As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag Then
					text2 = text2 + " and PrintPreviewType='" + text + "'"
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060014A4 RID: 5284 RVA: 0x000110B7 File Offset: 0x0000F2B7
		Private Sub frmBillStyle_Load(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060014A5 RID: 5285 RVA: 0x000110B7 File Offset: 0x0000F2B7
		Private Sub RA4_CheckedChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060014A6 RID: 5286 RVA: 0x000110B7 File Offset: 0x0000F2B7
		Private Sub RA5_CheckedChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060014A7 RID: 5287 RVA: 0x000110B7 File Offset: 0x0000F2B7
		Private Sub R3Inch_CheckedChanged(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x060014A8 RID: 5288 RVA: 0x000110C1 File Offset: 0x0000F2C1
		Private Sub RAll_CheckedChanged(sender As Object, e As EventArgs)
			Me.RA4.Checked = False
			Me.RA5.Checked = False
			Me.R3Inch.Checked = False
			Me.Getdata()
		End Sub

		' Token: 0x060014A9 RID: 5289 RVA: 0x000DED38 File Offset: 0x000DCF38
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
			Me.PictureBox1.Image = Image.FromFile(Application.StartupPath + "\BillImg\" + dataGridViewRow.Cells(3).Value.ToString())
			Me.testval = dataGridViewRow.Cells(1).Value.ToString()
		End Sub

		' Token: 0x060014AA RID: 5290 RVA: 0x000DEDAC File Offset: 0x000DCFAC
		Private Sub btnCash_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Dim num As Integer = MyProject.Forms.frmPOSTouch.ComboBox1.Items.Count - 1
			For i As Integer = 0 To num
				Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(MyProject.Forms.frmPOSTouch.ComboBox1.Items(i).ToString(), Me.testval, False)
				If flag Then
					MyProject.Forms.frmPOSTouch.ComboBox1.SelectedIndex = i
				End If
			Next
			MyBase.Hide()
		End Sub

		' Token: 0x060014AB RID: 5291 RVA: 0x000110F2 File Offset: 0x0000F2F2
		Private Sub btnTwo_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTerminalSetting.Reset()
			MyProject.Forms.frmTerminalSetting.ShowDialog()
		End Sub

		' Token: 0x04000708 RID: 1800
		Private testval As Object
	End Class
End Namespace
