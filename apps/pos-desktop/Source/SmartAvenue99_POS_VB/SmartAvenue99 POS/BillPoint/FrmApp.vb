Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports CrystalDecisions.CrystalReports.Engine
Imports DevNet
Imports DevNet.Models
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200006A RID: 106
	<DesignerGenerated()>
	Public Partial Class FrmApp
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600136B RID: 4971 RVA: 0x00010828 File Offset: 0x0000EA28
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Form1_Load
			AddHandler MyBase.FormClosing, AddressOf Me.FrmApp_FormClosing
			Me.InitializeComponent()
		End Sub

		' Token: 0x170007EE RID: 2030
		' (get) Token: 0x0600136E RID: 4974 RVA: 0x0001085A File Offset: 0x0000EA5A
		' (set) Token: 0x0600136F RID: 4975 RVA: 0x00010864 File Offset: 0x0000EA64
		Friend Overridable Property Status As DataGridViewTextBoxColumn

		' Token: 0x170007EF RID: 2031
		' (get) Token: 0x06001370 RID: 4976 RVA: 0x0001086D File Offset: 0x0000EA6D
		' (set) Token: 0x06001371 RID: 4977 RVA: 0x00010877 File Offset: 0x0000EA77
		Friend Overridable Property Attach As DataGridViewTextBoxColumn

		' Token: 0x170007F0 RID: 2032
		' (get) Token: 0x06001372 RID: 4978 RVA: 0x00010880 File Offset: 0x0000EA80
		' (set) Token: 0x06001373 RID: 4979 RVA: 0x0001088A File Offset: 0x0000EA8A
		Friend Overridable Property Message As DataGridViewTextBoxColumn

		' Token: 0x170007F1 RID: 2033
		' (get) Token: 0x06001374 RID: 4980 RVA: 0x00010893 File Offset: 0x0000EA93
		' (set) Token: 0x06001375 RID: 4981 RVA: 0x0001089D File Offset: 0x0000EA9D
		Friend Overridable Property Phone As DataGridViewTextBoxColumn

		' Token: 0x170007F2 RID: 2034
		' (get) Token: 0x06001376 RID: 4982 RVA: 0x000108A6 File Offset: 0x0000EAA6
		' (set) Token: 0x06001377 RID: 4983 RVA: 0x000108B0 File Offset: 0x0000EAB0
		Friend Overridable Property columnSelection As DataGridViewCheckBoxColumn

		' Token: 0x170007F3 RID: 2035
		' (get) Token: 0x06001378 RID: 4984 RVA: 0x000108B9 File Offset: 0x0000EAB9
		' (set) Token: 0x06001379 RID: 4985 RVA: 0x000108C3 File Offset: 0x0000EAC3
		Friend Overridable Property dgv As DataGridView

		' Token: 0x170007F4 RID: 2036
		' (get) Token: 0x0600137A RID: 4986 RVA: 0x000108CC File Offset: 0x0000EACC
		' (set) Token: 0x0600137B RID: 4987 RVA: 0x000108D6 File Offset: 0x0000EAD6
		Friend Overridable Property columnBrowse As DataGridViewButtonColumn

		' Token: 0x170007F5 RID: 2037
		' (get) Token: 0x0600137C RID: 4988 RVA: 0x000108DF File Offset: 0x0000EADF
		' (set) Token: 0x0600137D RID: 4989 RVA: 0x000108E9 File Offset: 0x0000EAE9
		Friend Overridable Property btnSendBulk As Button

		' Token: 0x170007F6 RID: 2038
		' (get) Token: 0x0600137E RID: 4990 RVA: 0x000108F2 File Offset: 0x0000EAF2
		' (set) Token: 0x0600137F RID: 4991 RVA: 0x000108FC File Offset: 0x0000EAFC
		Friend Overridable Property lblDelay As Label

		' Token: 0x170007F7 RID: 2039
		' (get) Token: 0x06001380 RID: 4992 RVA: 0x00010905 File Offset: 0x0000EB05
		' (set) Token: 0x06001381 RID: 4993 RVA: 0x0001090F File Offset: 0x0000EB0F
		Friend Overridable Property numDelay As NumericUpDown

		' Token: 0x170007F8 RID: 2040
		' (get) Token: 0x06001382 RID: 4994 RVA: 0x00010918 File Offset: 0x0000EB18
		' (set) Token: 0x06001383 RID: 4995 RVA: 0x00010922 File Offset: 0x0000EB22
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x170007F9 RID: 2041
		' (get) Token: 0x06001384 RID: 4996 RVA: 0x0001092B File Offset: 0x0000EB2B
		' (set) Token: 0x06001385 RID: 4997 RVA: 0x00010935 File Offset: 0x0000EB35
		Friend Overridable Property panel2 As Panel

		' Token: 0x170007FA RID: 2042
		' (get) Token: 0x06001386 RID: 4998 RVA: 0x0001093E File Offset: 0x0000EB3E
		' (set) Token: 0x06001387 RID: 4999 RVA: 0x00010948 File Offset: 0x0000EB48
		Friend Overridable Property tabBulk As TabPage

		' Token: 0x170007FB RID: 2043
		' (get) Token: 0x06001388 RID: 5000 RVA: 0x00010951 File Offset: 0x0000EB51
		' (set) Token: 0x06001389 RID: 5001 RVA: 0x0001095B File Offset: 0x0000EB5B
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170007FC RID: 2044
		' (get) Token: 0x0600138A RID: 5002 RVA: 0x00010964 File Offset: 0x0000EB64
		' (set) Token: 0x0600138B RID: 5003 RVA: 0x0001096E File Offset: 0x0000EB6E
		Friend Overridable Property Button1 As Button

		' Token: 0x170007FD RID: 2045
		' (get) Token: 0x0600138C RID: 5004 RVA: 0x00010977 File Offset: 0x0000EB77
		' (set) Token: 0x0600138D RID: 5005 RVA: 0x00010981 File Offset: 0x0000EB81
		Friend Overridable Property panelSend As Panel

		' Token: 0x170007FE RID: 2046
		' (get) Token: 0x0600138E RID: 5006 RVA: 0x0001098A File Offset: 0x0000EB8A
		' (set) Token: 0x0600138F RID: 5007 RVA: 0x00010994 File Offset: 0x0000EB94
		Friend Overridable Property btnSend As Button

		' Token: 0x170007FF RID: 2047
		' (get) Token: 0x06001390 RID: 5008 RVA: 0x0001099D File Offset: 0x0000EB9D
		' (set) Token: 0x06001391 RID: 5009 RVA: 0x000109A7 File Offset: 0x0000EBA7
		Friend Overridable Property btnAttachBrowse As Button

		' Token: 0x17000800 RID: 2048
		' (get) Token: 0x06001392 RID: 5010 RVA: 0x000109B0 File Offset: 0x0000EBB0
		' (set) Token: 0x06001393 RID: 5011 RVA: 0x000109BA File Offset: 0x0000EBBA
		Friend Overridable Property tBoxAttach As TextBox

		' Token: 0x17000801 RID: 2049
		' (get) Token: 0x06001394 RID: 5012 RVA: 0x000109C3 File Offset: 0x0000EBC3
		' (set) Token: 0x06001395 RID: 5013 RVA: 0x000109CD File Offset: 0x0000EBCD
		Friend Overridable Property label3 As Label

		' Token: 0x17000802 RID: 2050
		' (get) Token: 0x06001396 RID: 5014 RVA: 0x000109D6 File Offset: 0x0000EBD6
		' (set) Token: 0x06001397 RID: 5015 RVA: 0x000109E0 File Offset: 0x0000EBE0
		Friend Overridable Property tBoxMessage As TextBox

		' Token: 0x17000803 RID: 2051
		' (get) Token: 0x06001398 RID: 5016 RVA: 0x000109E9 File Offset: 0x0000EBE9
		' (set) Token: 0x06001399 RID: 5017 RVA: 0x000109F3 File Offset: 0x0000EBF3
		Friend Overridable Property label2 As Label

		' Token: 0x17000804 RID: 2052
		' (get) Token: 0x0600139A RID: 5018 RVA: 0x000109FC File Offset: 0x0000EBFC
		' (set) Token: 0x0600139B RID: 5019 RVA: 0x00010A06 File Offset: 0x0000EC06
		Friend Overridable Property tBoxPhone As TextBox

		' Token: 0x17000805 RID: 2053
		' (get) Token: 0x0600139C RID: 5020 RVA: 0x00010A0F File Offset: 0x0000EC0F
		' (set) Token: 0x0600139D RID: 5021 RVA: 0x00010A19 File Offset: 0x0000EC19
		Friend Overridable Property label1 As Label

		' Token: 0x17000806 RID: 2054
		' (get) Token: 0x0600139E RID: 5022 RVA: 0x00010A22 File Offset: 0x0000EC22
		' (set) Token: 0x0600139F RID: 5023 RVA: 0x00010A2C File Offset: 0x0000EC2C
		Friend Overridable Property label4 As Label

		' Token: 0x17000807 RID: 2055
		' (get) Token: 0x060013A0 RID: 5024 RVA: 0x00010A35 File Offset: 0x0000EC35
		' (set) Token: 0x060013A1 RID: 5025 RVA: 0x00010A3F File Offset: 0x0000EC3F
		Friend Overridable Property timer1 As Timer

		' Token: 0x17000808 RID: 2056
		' (get) Token: 0x060013A2 RID: 5026 RVA: 0x00010A48 File Offset: 0x0000EC48
		' (set) Token: 0x060013A3 RID: 5027 RVA: 0x00010A52 File Offset: 0x0000EC52
		Friend Overridable Property openAttach As OpenFileDialog

		' Token: 0x17000809 RID: 2057
		' (get) Token: 0x060013A4 RID: 5028 RVA: 0x00010A5B File Offset: 0x0000EC5B
		' (set) Token: 0x060013A5 RID: 5029 RVA: 0x00010A65 File Offset: 0x0000EC65
		Friend Overridable Property btnLogout As Button

		' Token: 0x1700080A RID: 2058
		' (get) Token: 0x060013A6 RID: 5030 RVA: 0x00010A6E File Offset: 0x0000EC6E
		' (set) Token: 0x060013A7 RID: 5031 RVA: 0x00010A78 File Offset: 0x0000EC78
		Friend Overridable Property flowLayoutPanel1 As FlowLayoutPanel

		' Token: 0x1700080B RID: 2059
		' (get) Token: 0x060013A8 RID: 5032 RVA: 0x00010A81 File Offset: 0x0000EC81
		' (set) Token: 0x060013A9 RID: 5033 RVA: 0x00010A8B File Offset: 0x0000EC8B
		Friend Overridable Property LblSenderId As Label

		' Token: 0x1700080C RID: 2060
		' (get) Token: 0x060013AA RID: 5034 RVA: 0x00010A94 File Offset: 0x0000EC94
		' (set) Token: 0x060013AB RID: 5035 RVA: 0x00010A9E File Offset: 0x0000EC9E
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700080D RID: 2061
		' (get) Token: 0x060013AC RID: 5036 RVA: 0x00010AA7 File Offset: 0x0000ECA7
		' (set) Token: 0x060013AD RID: 5037 RVA: 0x00010AB1 File Offset: 0x0000ECB1
		Friend Overridable Property chkBoxHeadLess As CheckBox

		' Token: 0x1700080E RID: 2062
		' (get) Token: 0x060013AE RID: 5038 RVA: 0x00010ABA File Offset: 0x0000ECBA
		' (set) Token: 0x060013AF RID: 5039 RVA: 0x00010AC4 File Offset: 0x0000ECC4
		Friend Overridable Property panel6 As Panel

		' Token: 0x1700080F RID: 2063
		' (get) Token: 0x060013B0 RID: 5040 RVA: 0x00010ACD File Offset: 0x0000ECCD
		' (set) Token: 0x060013B1 RID: 5041 RVA: 0x00010AD7 File Offset: 0x0000ECD7
		Friend Overridable Property lblWhatsAppState As Label

		' Token: 0x17000810 RID: 2064
		' (get) Token: 0x060013B2 RID: 5042 RVA: 0x00010AE0 File Offset: 0x0000ECE0
		' (set) Token: 0x060013B3 RID: 5043 RVA: 0x00010AEA File Offset: 0x0000ECEA
		Friend Overridable Property btnTerminate As Button

		' Token: 0x17000811 RID: 2065
		' (get) Token: 0x060013B4 RID: 5044 RVA: 0x00010AF3 File Offset: 0x0000ECF3
		' (set) Token: 0x060013B5 RID: 5045 RVA: 0x00010AFD File Offset: 0x0000ECFD
		Friend Overridable Property btnInitialize As Button

		' Token: 0x17000812 RID: 2066
		' (get) Token: 0x060013B6 RID: 5046 RVA: 0x00010B06 File Offset: 0x0000ED06
		' (set) Token: 0x060013B7 RID: 5047 RVA: 0x00010B10 File Offset: 0x0000ED10
		Friend Overridable Property tabIndividual As TabPage

		' Token: 0x17000813 RID: 2067
		' (get) Token: 0x060013B8 RID: 5048 RVA: 0x00010B19 File Offset: 0x0000ED19
		' (set) Token: 0x060013B9 RID: 5049 RVA: 0x00010B23 File Offset: 0x0000ED23
		Friend Overridable Property panelAuth As Panel

		' Token: 0x17000814 RID: 2068
		' (get) Token: 0x060013BA RID: 5050 RVA: 0x00010B2C File Offset: 0x0000ED2C
		' (set) Token: 0x060013BB RID: 5051 RVA: 0x00010B36 File Offset: 0x0000ED36
		Friend Overridable Property pBoxAuthQR As PictureBox

		' Token: 0x17000815 RID: 2069
		' (get) Token: 0x060013BC RID: 5052 RVA: 0x00010B3F File Offset: 0x0000ED3F
		' (set) Token: 0x060013BD RID: 5053 RVA: 0x00010B49 File Offset: 0x0000ED49
		Friend Overridable Property statusRetriever As Timer

		' Token: 0x17000816 RID: 2070
		' (get) Token: 0x060013BE RID: 5054 RVA: 0x00010B52 File Offset: 0x0000ED52
		' (set) Token: 0x060013BF RID: 5055 RVA: 0x00010B5C File Offset: 0x0000ED5C
		Friend Overridable Property tabControlSender As TabControl

		' Token: 0x060013C0 RID: 5056 RVA: 0x00010B65 File Offset: 0x0000ED65
		Private Sub Form1_Load(sender As Object, e As EventArgs)
			FrmApp.whatsApp = New WhatsApp()
			Me.Initialization()
		End Sub

		' Token: 0x060013C1 RID: 5057 RVA: 0x00010B79 File Offset: 0x0000ED79
		Private Sub btnInitialize_Click(sender As Object, e As EventArgs)
			Me.Initialization()
		End Sub

		' Token: 0x060013C2 RID: 5058 RVA: 0x000D5564 File Offset: 0x000D3764
		Public Sub Initialization()
			Try
				FrmApp.whatsApp.Initialize(New Config() With { .HideCommandPromptWindow = True, .Headless = Me.chkBoxHeadLess.Checked })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060013C3 RID: 5059 RVA: 0x000D55D4 File Offset: 0x000D37D4
		Private Async Sub btnTerminate_Click(sender As Object, e As EventArgs)
			Await FrmApp.whatsApp.Destroy()
		End Sub

		' Token: 0x060013C4 RID: 5060 RVA: 0x000D561C File Offset: 0x000D381C
		Private Async Sub btnLogout_Click(sender As Object, e As EventArgs)
			Await FrmApp.whatsApp.Logout()
		End Sub

		' Token: 0x060013C5 RID: 5061 RVA: 0x000D5664 File Offset: 0x000D3864
		Private Sub btnAttachBrowse_Click(sender As Object, e As EventArgs)
			Dim dialogResult As DialogResult = Me.openAttach.ShowDialog()
			Dim flag As Boolean = dialogResult = DialogResult.OK
			If flag Then
				Dim flag2 As Boolean = File.Exists(Me.openAttach.FileName)
				If flag2 Then
					Me.tBoxAttach.Text = Me.openAttach.FileName
				Else
					MessageBox.Show("File does not exists")
				End If
			End If
		End Sub

		' Token: 0x060013C6 RID: 5062 RVA: 0x000D56C4 File Offset: 0x000D38C4
		Private Async Sub btnSend_Click(sender As Object, e As EventArgs)
			Dim messageRequest As MessageRequest = New MessageRequest() With { .Phone = Me.tBoxPhone.Text, .Message = Me.tBoxMessage.Text, .AttachmentPath = Me.tBoxAttach.Text }
			Dim response As MessageResponse = Await FrmApp.whatsApp.Send(messageRequest)
			MessageBox.Show(response.Status.Description())
		End Sub

		' Token: 0x060013C7 RID: 5063 RVA: 0x000D570C File Offset: 0x000D390C
		Private Async Sub timer1_Tick(sender As Object, e As EventArgs)
			Dim flag As Boolean = FrmApp.whatsApp Is Nothing
			If flag Then
				Await Task.Delay(500)
			Else
				Me.pBoxAuthQR.Image = FrmApp.whatsApp.AuthQR
				Me.LblSenderId.Text = String.Format("Sender Id: {0}", If(FrmApp.whatsApp.SenderID, "Unavailable"))
				If FrmApp.whatsApp.CurrentState = State.READY Then
					Me.btnLogout.Enabled = True
					Me.tabControlSender.Enabled = True
				Else
					Me.btnLogout.Enabled = False
					Me.tabControlSender.Enabled = False
				End If
				If FrmApp.whatsApp.CurrentState = State.STOPPED Then
					Me.btnInitialize.Enabled = True
					Me.btnTerminate.Enabled = False
					Me.chkBoxHeadLess.Enabled = True
				Else
					Me.btnInitialize.Enabled = False
					Me.btnTerminate.Enabled = True
					Me.chkBoxHeadLess.Enabled = False
				End If
				If FrmApp.whatsApp.CurrentState = State.AUTH_REQUIRED Then
					Me.panelAuth.Enabled = True
					If Me._AUTH_QR IsNot FrmApp.whatsApp.AuthQR Then
						Me._AUTH_QR = FrmApp.whatsApp.AuthQR
					End If
				Else
					Me.panelAuth.Enabled = False
				End If
				If Me._ENGINE_STATE <> FrmApp.whatsApp.CurrentState Then
					Me.lblWhatsAppState.Text = String.Format("Engine: {0}", FrmApp.whatsApp.CurrentState.GetString())
					Me._ENGINE_STATE = FrmApp.whatsApp.CurrentState
				End If
			End If
		End Sub

		' Token: 0x060013C8 RID: 5064 RVA: 0x000D5754 File Offset: 0x000D3954
		Private Async Sub btnSendBulk_Click(sender As Object, e As EventArgs)
			Try
				For Each obj As Object In CType(Me.dgv.Rows, IEnumerable)
					Dim row As DataGridViewRow = CType(obj, DataGridViewRow)
					Try
						Dim flag As Boolean = Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(row.Cells(0).Value))
						If flag Then
							Dim phone As String = If((row.Cells(1).Value IsNot Nothing), row.Cells(1).Value.ToString(), Nothing)
							Dim message As String = If((row.Cells(2).Value IsNot Nothing), row.Cells(2).Value.ToString(), Nothing)
							Dim attach As String = If((row.Cells(3).Value IsNot Nothing), row.Cells(3).Value.ToString(), Nothing)
							Dim flag2 As Boolean = phone IsNot Nothing AndAlso (message IsNot Nothing OrElse attach <> Nothing)
							If flag2 Then
								Dim messageRequest As MessageRequest = New MessageRequest() With { .Phone = phone, .Message = message, .AttachmentPath = attach }
								Dim response As MessageResponse = Await FrmApp.whatsApp.Send(messageRequest)
								row.Cells(5).Value = response.Status.Description()
							End If
						End If
					Catch ex As Exception
					End Try
					If Convert.ToInt32(Me.numDelay.Value) > 0 Then
						Await Task.Run(Async Sub()
							' The following expression was wrapped in a checked-expression
							Await Task.Delay(Convert.ToInt32(Me.numDelay.Value) * 1000)
						End Sub)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060013C9 RID: 5065 RVA: 0x000D579C File Offset: 0x000D399C
		Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.dgv.Columns(e.ColumnIndex).Name, "columnBrowse", False) = 0
			If flag Then
				Dim dialogResult As DialogResult = Me.openAttach.ShowDialog()
				Dim flag2 As Boolean = dialogResult = DialogResult.OK
				If flag2 Then
					Dim flag3 As Boolean = File.Exists(Me.openAttach.FileName)
					If flag3 Then
						Me.dgv.Rows(e.RowIndex).Cells(3).Value = Me.openAttach.FileName
					Else
						MessageBox.Show("File does not exists")
					End If
				End If
			End If
		End Sub

		' Token: 0x060013CA RID: 5066 RVA: 0x000D5848 File Offset: 0x000D3A48
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.tBoxMessage.Text, "", False) = 0
			If flag Then
				Interaction.MsgBox("Please fill Text Message", MsgBoxStyle.OkOnly, Nothing)
			Else
				MyProject.Forms.frmReport.TextBox1.Text = Me.tBoxPhone.Text
				Dim reportDocument As ReportDocument = New CrystalReport1()
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				Dim textObject As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text1"), TextObject)
				textObject.Text = Me.tBoxMessage.Text
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub

		' Token: 0x060013CB RID: 5067 RVA: 0x000D5920 File Offset: 0x000D3B20
		Public Function CheckForInternetConnection() As Boolean
			Dim flag As Boolean
			Try
				Using webClient As WebClient = New WebClient()
					Using webClient.OpenRead("http://www.google.com")
						flag = True
					End Using
				End Using
			Catch ex As Exception
				flag = False
			End Try
			Return flag
		End Function

		' Token: 0x060013CC RID: 5068 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub tBoxPhone_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x060013CD RID: 5069 RVA: 0x000D59D8 File Offset: 0x000D3BD8
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Try
					For Each obj As Object In CType(Me.dgv.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Cells(0).Value = True
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					Try
						For Each obj2 As Object In CType(Me.dgv.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataGridViewRow2.Cells(0).Value = False
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
				End If
			End If
		End Sub

		' Token: 0x060013CE RID: 5070 RVA: 0x000D5AE4 File Offset: 0x000D3CE4
		Private Async Sub FrmApp_FormClosing(sender As Object, e As FormClosingEventArgs)
			Await FrmApp.whatsApp.Destroy()
		End Sub

		' Token: 0x0400066E RID: 1646
		Public Shared whatsApp As WhatsApp

		' Token: 0x0400066F RID: 1647
		Private _ENGINE_STATE As State

		' Token: 0x04000670 RID: 1648
		Private _AUTH_QR As Image
	End Class
End Namespace
