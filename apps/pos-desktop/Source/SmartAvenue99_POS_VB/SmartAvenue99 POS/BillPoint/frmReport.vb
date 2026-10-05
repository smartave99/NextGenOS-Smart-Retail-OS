Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Windows.Forms
Imports DevNet
Imports DevNet.Models
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000367 RID: 871
	<DesignerGenerated()>
	Public Partial Class frmReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CEA1 RID: 52897 RVA: 0x0080F9E4 File Offset: 0x0080DBE4
		Public Sub New()
			AddHandler MyBase.FormClosed, AddressOf Me.frmReport_FormClosed
			AddHandler MyBase.Load, AddressOf Me.frmReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmReport_KeyDown
			AddHandler MyBase.FormClosing, AddressOf Me.frmReport_FormClosing
			Me.sts = ""
			Me.instanceId = ""
			Me.token = ""
			Me.isProcessing = False
			Me.whatsApp1 = frmMainMenu.whatsApp1
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005125 RID: 20773
		' (get) Token: 0x0600CEA4 RID: 52900 RVA: 0x0005BE31 File Offset: 0x0005A031
		' (set) Token: 0x0600CEA5 RID: 52901 RVA: 0x0005BE3B File Offset: 0x0005A03B
		Friend Overridable Property CrystalReportViewer1 As CrystalReportViewer

		' Token: 0x17005126 RID: 20774
		' (get) Token: 0x0600CEA6 RID: 52902 RVA: 0x0005BE44 File Offset: 0x0005A044
		' (set) Token: 0x0600CEA7 RID: 52903 RVA: 0x00811450 File Offset: 0x0080F650
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

		' Token: 0x17005127 RID: 20775
		' (get) Token: 0x0600CEA8 RID: 52904 RVA: 0x0005BE4E File Offset: 0x0005A04E
		' (set) Token: 0x0600CEA9 RID: 52905 RVA: 0x0005BE58 File Offset: 0x0005A058
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005128 RID: 20776
		' (get) Token: 0x0600CEAA RID: 52906 RVA: 0x0005BE61 File Offset: 0x0005A061
		' (set) Token: 0x0600CEAB RID: 52907 RVA: 0x00811494 File Offset: 0x0080F694
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

		' Token: 0x17005129 RID: 20777
		' (get) Token: 0x0600CEAC RID: 52908 RVA: 0x0005BE6B File Offset: 0x0005A06B
		' (set) Token: 0x0600CEAD RID: 52909 RVA: 0x0005BE75 File Offset: 0x0005A075
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700512A RID: 20778
		' (get) Token: 0x0600CEAE RID: 52910 RVA: 0x0005BE7E File Offset: 0x0005A07E
		' (set) Token: 0x0600CEAF RID: 52911 RVA: 0x0005BE88 File Offset: 0x0005A088
		Friend Overridable Property PrintDialog1 As PrintDialog

		' Token: 0x1700512B RID: 20779
		' (get) Token: 0x0600CEB0 RID: 52912 RVA: 0x0005BE91 File Offset: 0x0005A091
		' (set) Token: 0x0600CEB1 RID: 52913 RVA: 0x0005BE9B File Offset: 0x0005A09B
		Friend Overridable Property PrintDocument1 As PrintDocument

		' Token: 0x1700512C RID: 20780
		' (get) Token: 0x0600CEB2 RID: 52914 RVA: 0x0005BEA4 File Offset: 0x0005A0A4
		' (set) Token: 0x0600CEB3 RID: 52915 RVA: 0x008114D8 File Offset: 0x0080F6D8
		Private _txtEmailID As TextBox
		Friend Overridable Property txtEmailID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmailID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtEmailID_KeyDown
				Dim textBox As TextBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtEmailID = value
				textBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700512D RID: 20781
		' (get) Token: 0x0600CEB4 RID: 52916 RVA: 0x0005BEAE File Offset: 0x0005A0AE
		' (set) Token: 0x0600CEB5 RID: 52917 RVA: 0x0081151C File Offset: 0x0080F71C
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700512E RID: 20782
		' (get) Token: 0x0600CEB6 RID: 52918 RVA: 0x0005BEB8 File Offset: 0x0005A0B8
		' (set) Token: 0x0600CEB7 RID: 52919 RVA: 0x0005BEC2 File Offset: 0x0005A0C2
		Friend Overridable Property txtcompname As TextBox

		' Token: 0x1700512F RID: 20783
		' (get) Token: 0x0600CEB8 RID: 52920 RVA: 0x0005BECB File Offset: 0x0005A0CB
		' (set) Token: 0x0600CEB9 RID: 52921 RVA: 0x00811560 File Offset: 0x0080F760
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

		' Token: 0x17005130 RID: 20784
		' (get) Token: 0x0600CEBA RID: 52922 RVA: 0x0005BED5 File Offset: 0x0005A0D5
		' (set) Token: 0x0600CEBB RID: 52923 RVA: 0x0005BEDF File Offset: 0x0005A0DF
		Friend Overridable Property Label1 As Label

		' Token: 0x17005131 RID: 20785
		' (get) Token: 0x0600CEBC RID: 52924 RVA: 0x0005BEE8 File Offset: 0x0005A0E8
		' (set) Token: 0x0600CEBD RID: 52925 RVA: 0x0005BEF2 File Offset: 0x0005A0F2
		Friend Overridable Property Label2 As Label

		' Token: 0x17005132 RID: 20786
		' (get) Token: 0x0600CEBE RID: 52926 RVA: 0x0005BEFB File Offset: 0x0005A0FB
		' (set) Token: 0x0600CEBF RID: 52927 RVA: 0x0005BF05 File Offset: 0x0005A105
		Friend Overridable Property Num1 As NumericUpDown

		' Token: 0x17005133 RID: 20787
		' (get) Token: 0x0600CEC0 RID: 52928 RVA: 0x0005BF0E File Offset: 0x0005A10E
		' (set) Token: 0x0600CEC1 RID: 52929 RVA: 0x0005BF18 File Offset: 0x0005A118
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005134 RID: 20788
		' (get) Token: 0x0600CEC2 RID: 52930 RVA: 0x0005BF21 File Offset: 0x0005A121
		' (set) Token: 0x0600CEC3 RID: 52931 RVA: 0x008115A4 File Offset: 0x0080F7A4
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005135 RID: 20789
		' (get) Token: 0x0600CEC4 RID: 52932 RVA: 0x0005BF2B File Offset: 0x0005A12B
		' (set) Token: 0x0600CEC5 RID: 52933 RVA: 0x008115E8 File Offset: 0x0080F7E8
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox2_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005136 RID: 20790
		' (get) Token: 0x0600CEC6 RID: 52934 RVA: 0x0005BF35 File Offset: 0x0005A135
		' (set) Token: 0x0600CEC7 RID: 52935 RVA: 0x0005BF3F File Offset: 0x0005A13F
		Friend Overridable Property Label3 As Label

		' Token: 0x17005137 RID: 20791
		' (get) Token: 0x0600CEC8 RID: 52936 RVA: 0x0005BF48 File Offset: 0x0005A148
		' (set) Token: 0x0600CEC9 RID: 52937 RVA: 0x0005BF52 File Offset: 0x0005A152
		Friend Overridable Property txtserverlink As Label

		' Token: 0x17005138 RID: 20792
		' (get) Token: 0x0600CECA RID: 52938 RVA: 0x0005BF5B File Offset: 0x0005A15B
		' (set) Token: 0x0600CECB RID: 52939 RVA: 0x0005BF65 File Offset: 0x0005A165
		Friend Overridable Property Label4 As Label

		' Token: 0x17005139 RID: 20793
		' (get) Token: 0x0600CECC RID: 52940 RVA: 0x0005BF6E File Offset: 0x0005A16E
		' (set) Token: 0x0600CECD RID: 52941 RVA: 0x0005BF78 File Offset: 0x0005A178
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x1700513A RID: 20794
		' (get) Token: 0x0600CECE RID: 52942 RVA: 0x0005BF81 File Offset: 0x0005A181
		' (set) Token: 0x0600CECF RID: 52943 RVA: 0x0005BF8B File Offset: 0x0005A18B
		Friend Overridable Property Label5 As Label

		' Token: 0x1700513B RID: 20795
		' (get) Token: 0x0600CED0 RID: 52944 RVA: 0x0005BF94 File Offset: 0x0005A194
		' (set) Token: 0x0600CED1 RID: 52945 RVA: 0x0005BF9E File Offset: 0x0005A19E
		Friend Overridable Property StatusRetriever As Timer

		' Token: 0x1700513C RID: 20796
		' (get) Token: 0x0600CED2 RID: 52946 RVA: 0x0005BFA7 File Offset: 0x0005A1A7
		' (set) Token: 0x0600CED3 RID: 52947 RVA: 0x00811648 File Offset: 0x0080F848
		Private _Button10 As GelButton
		Friend Overridable Property Button10 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button10_Click
				Dim gelButton As GelButton = Me._Button10
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button10 = value
				gelButton = Me._Button10
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700513D RID: 20797
		' (get) Token: 0x0600CED4 RID: 52948 RVA: 0x0005BFB1 File Offset: 0x0005A1B1
		' (set) Token: 0x0600CED5 RID: 52949 RVA: 0x0081168C File Offset: 0x0080F88C
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton1 = value
				gelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700513E RID: 20798
		' (get) Token: 0x0600CED6 RID: 52950 RVA: 0x0005BFBB File Offset: 0x0005A1BB
		' (set) Token: 0x0600CED7 RID: 52951 RVA: 0x008116D0 File Offset: 0x0080F8D0
		Private _Button6 As Button
		Friend Overridable Property Button6 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim button As Button = Me._Button6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button6 = value
				button = Me._Button6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700513F RID: 20799
		' (get) Token: 0x0600CED8 RID: 52952 RVA: 0x0005BFC5 File Offset: 0x0005A1C5
		' (set) Token: 0x0600CED9 RID: 52953 RVA: 0x00811714 File Offset: 0x0080F914
		Private _Button5 As Button
		Friend Overridable Property Button5 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button5_Click_1
				Dim button As Button = Me._Button5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button5 = value
				button = Me._Button5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005140 RID: 20800
		' (get) Token: 0x0600CEDA RID: 52954 RVA: 0x0005BFCF File Offset: 0x0005A1CF
		' (set) Token: 0x0600CEDB RID: 52955 RVA: 0x0005BFD9 File Offset: 0x0005A1D9
		Friend Overridable Property Label7 As Label

		' Token: 0x17005141 RID: 20801
		' (get) Token: 0x0600CEDC RID: 52956 RVA: 0x0005BFE2 File Offset: 0x0005A1E2
		' (set) Token: 0x0600CEDD RID: 52957 RVA: 0x0005BFEC File Offset: 0x0005A1EC
		Friend Overridable Property Label6 As Label

		' Token: 0x17005142 RID: 20802
		' (get) Token: 0x0600CEDE RID: 52958 RVA: 0x0005BFF5 File Offset: 0x0005A1F5
		' (set) Token: 0x0600CEDF RID: 52959 RVA: 0x0005BFFF File Offset: 0x0005A1FF
		Friend Overridable Property Label9 As Label

		' Token: 0x17005143 RID: 20803
		' (get) Token: 0x0600CEE0 RID: 52960 RVA: 0x0005C008 File Offset: 0x0005A208
		' (set) Token: 0x0600CEE1 RID: 52961 RVA: 0x0005C012 File Offset: 0x0005A212
		Friend Overridable Property Label8 As Label

		' Token: 0x17005144 RID: 20804
		' (get) Token: 0x0600CEE2 RID: 52962 RVA: 0x0005C01B File Offset: 0x0005A21B
		' (set) Token: 0x0600CEE3 RID: 52963 RVA: 0x0005C025 File Offset: 0x0005A225
		Friend Overridable Property lblwWork As Label

		' Token: 0x0600CEE4 RID: 52964 RVA: 0x00811758 File Offset: 0x0080F958
		Public Sub statusdisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT c1, c2 FROM WappApi"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtserverlink.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.sts = NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(1), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString()
				Else
					Me.txtserverlink.Text = "91"
					Me.sts = "Disabled"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CEE5 RID: 52965 RVA: 0x00811874 File Offset: 0x0080FA74
		Private Sub autoexportinpdf()
			Try
				Dim diskFileDestinationOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions()
				Dim pdfRtfWordFormatOptions As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
				diskFileDestinationOptions.DiskFileName = MyProject.Application.Info.DirectoryPath + "\Email Reports\Report.Pdf"
				Dim exportOptions As ExportOptions = CType(NewLateBinding.LateGet(Me.CrystalReportViewer1.ReportSource, Nothing, "ExportOptions", New Object(-1) {}, Nothing, Nothing, Nothing), ExportOptions)
				Dim exportOptions2 As ExportOptions = exportOptions
				exportOptions2.ExportDestinationType = ExportDestinationType.DiskFile
				exportOptions2.ExportFormatType = ExportFormatType.PortableDocFormat
				exportOptions2.ExportDestinationOptions = diskFileDestinationOptions
				exportOptions2.ExportFormatOptions = pdfRtfWordFormatOptions
				NewLateBinding.LateCall(Me.CrystalReportViewer1.ReportSource, Nothing, "Export", New Object(-1) {}, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600CEE6 RID: 52966 RVA: 0x00811940 File Offset: 0x0080FB40
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim diskFileDestinationOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions()
				Dim pdfRtfWordFormatOptions As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
				Me.SaveFileDialog1.Filter = "Pdf Files|*.pdf"
				Dim flag As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					diskFileDestinationOptions.DiskFileName = Me.SaveFileDialog1.FileName
				End If
				Dim exportOptions As ExportOptions = CType(NewLateBinding.LateGet(Me.CrystalReportViewer1.ReportSource, Nothing, "ExportOptions", New Object(-1) {}, Nothing, Nothing, Nothing), ExportOptions)
				Dim exportOptions2 As ExportOptions = exportOptions
				exportOptions2.ExportDestinationType = ExportDestinationType.DiskFile
				exportOptions2.ExportFormatType = ExportFormatType.PortableDocFormat
				exportOptions2.ExportDestinationOptions = diskFileDestinationOptions
				exportOptions2.ExportFormatOptions = pdfRtfWordFormatOptions
				NewLateBinding.LateCall(Me.CrystalReportViewer1.ReportSource, Nothing, "Export", New Object(-1) {}, Nothing, Nothing, Nothing, True)
				MessageBox.Show("Successfully Exported", "Export", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CEE7 RID: 52967 RVA: 0x00811A68 File Offset: 0x0080FC68
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtEmailID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please enter Email ID", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtEmailID.Focus()
				Else
					Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
					If flag2 Then
						MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
						ModCommonClasses.con1.Open()
						Dim text As String = "SELECT COUNT(*) FROM EmailSetting HAVING COUNT(*) <= 0"
						ModCommonClasses.cmd1 = New SqlCommand(text, ModCommonClasses.con1)
						ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr1.Read()
						If flag3 Then
							ModCommonClasses.rdr1.Close()
							ModCommonClasses.con1.Close()
						Else
							ModCommonClasses.rdr1.Close()
							ModCommonClasses.con1.Close()
							Dim flag4 As Boolean = ModFunc.CheckForInternetConnection()
							If flag4 Then
								Me.Cursor = Cursors.WaitCursor
								Me.Timer1.Enabled = True
								ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
								ModCommonClasses.con1.Open()
								Dim text2 As String = "SELECT RTRIM(Username), RTRIM(Password), RTRIM(SMTPAddress), Port FROM EmailSetting WHERE IsDefault='Yes' AND IsActive='Yes'"
								ModCommonClasses.cmd1 = New SqlCommand(text2, ModCommonClasses.con1)
								Dim sqlDataReader As SqlDataReader = ModCommonClasses.cmd1.ExecuteReader()
								Dim flag5 As Boolean = sqlDataReader.Read()
								If flag5 Then
									Dim text3 As String = MyProject.Application.Info.DirectoryPath + "\Email Reports"
									Dim flag6 As Boolean = Not Directory.Exists(text3)
									If flag6 Then
										Directory.CreateDirectory(text3)
									End If
									Me.autoexportinpdf()
									Dim text4 As String = text3 + "\Report.Pdf"
									Dim [string] As String = sqlDataReader.GetString(0)
									Dim text5 As String = ModFunc.Decrypt(sqlDataReader.GetString(1))
									Dim string2 As String = sqlDataReader.GetString(2)
									Dim int As Integer = sqlDataReader.GetInt32(3)
									Dim mailMessage As MailMessage = New MailMessage()
									mailMessage.From = New MailAddress([string])
									mailMessage.[To].Add(Me.txtEmailID.Text)
									mailMessage.Subject = "POS Report : " + Me.txtcompname.Text
									mailMessage.Body = "Please find the attachment below"
									mailMessage.IsBodyHtml = False
									Dim flag7 As Boolean = File.Exists(text4)
									If flag7 Then
										mailMessage.Attachments.Add(New Attachment(text4))
									End If
									Dim smtpClient As New SmtpClient(string2) With { .Port = int, .Credentials = New NetworkCredential([string], text5), .EnableSsl = True }
										smtpClient.Send(mailMessage)
									MessageBox.Show("Successfully Sent", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Else
									MessageBox.Show("No email configuration found", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End If
								Dim flag8 As Boolean = sqlDataReader IsNot Nothing
								If flag8 Then
									sqlDataReader.Close()
								End If
								ModCommonClasses.con1.Close()
								Me.Cursor = Cursors.[Default]
							End If
						End If
					End If
				End If
			Catch ex As Exception
				Me.Cursor = Cursors.[Default]
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CEE8 RID: 52968 RVA: 0x00811DB8 File Offset: 0x0080FFB8
		Private Sub frmReport_FormClosed(sender As Object, e As FormClosedEventArgs)
			Dim text As String = MyProject.Application.Info.DirectoryPath + "\PDF Reports\Report.Pdf"
			Dim text2 As String = MyProject.Application.Info.DirectoryPath + "\Email Reports\Report.Pdf"
			Try
				Dim flag As Boolean = File.Exists(text)
				If flag Then
					File.Delete(text)
				End If
				Dim flag2 As Boolean = File.Exists(text2)
				If flag2 Then
					File.Delete(text2)
				End If
			Catch ex As Exception
			End Try
			Me.txtEmailID.Text = ""
			Me.Num1.Minimum = 1D
		End Sub

		' Token: 0x0600CEE9 RID: 52969 RVA: 0x00811E68 File Offset: 0x00810068
		Public Sub DefaultPrinter()
			ModCommonClasses.con.Close()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select PrinterName from PosPrinterSetting where TillID=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Dns.GetHostName().ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Me.TextBox1.Text = Conversions.ToString(NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(0), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing))
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600CEEA RID: 52970 RVA: 0x00811F38 File Offset: 0x00810138
		Private Sub frmReport_Load(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not Directory.Exists("D:\SBPE_DATA")
			If flag Then
				Directory.CreateDirectory("D:\SBPE_DATA\")
			End If
			Dim flag2 As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\PDF Reports")
			If flag2 Then
				Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\PDF Reports\")
			End If
			Me.statusdisplay()
			Me.Num1.Minimum = 1D
			Dim printerSettings As PrinterSettings = New PrinterSettings()
			Dim printerName As String = printerSettings.PrinterName
			Me.TextBox1.Text = printerName
			Me.GetCompanyname()
			Me.Num1.Text = "1"
		End Sub

		' Token: 0x0600CEEB RID: 52971 RVA: 0x00811FF4 File Offset: 0x008101F4
		Public Sub GetCompanyname()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtcompname.Text = ModCommonClasses.rdr.GetValue(0).ToString()
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CEEC RID: 52972 RVA: 0x0005C02E File Offset: 0x0005A22E
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600CEED RID: 52973 RVA: 0x008120E4 File Offset: 0x008102E4
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.CrystalReportViewer1.ReportSource, Nothing, "PrintOptions", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "PrinterName", New Object() { Me.TextBox1.Text }, Nothing, Nothing, False, True)
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Me.CrystalReportViewer1.ReportSource, Nothing, "PrintOptions", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "DissociatePageSizeAndPrinterPaperSize", New Object() { True }, Nothing, Nothing, False, True)
			NewLateBinding.LateCall(Me.CrystalReportViewer1.ReportSource, Nothing, "PrintToPrinter", New Object() { Conversion.Val(Me.Num1.Text), False, 0, 0 }, Nothing, Nothing, Nothing, True)
		End Sub

		' Token: 0x0600CEEE RID: 52974 RVA: 0x008121C8 File Offset: 0x008103C8
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Dim text As String = ""
			Dim flag As Boolean = Operators.CompareString(Me.sts, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
				If flag2 Then
					Me.TextBox2.Focus()
					MessageBox.Show("Please fill correct WhatsApp number", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = ModFunc.CheckForInternetConnection()
					If flag3 Then
						Try
							Me.Cursor = Cursors.WaitCursor
							Me.Timer1.Enabled = True
							Dim flag4 As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\PDF Reports")
							If flag4 Then
								Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\PDF Reports\")
							End If
							Dim instantID As String = clswhatsApp.GETInstantID()
							Dim diskFileDestinationOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions()
							Dim pdfRtfWordFormatOptions As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
							diskFileDestinationOptions.DiskFileName = MyProject.Application.Info.DirectoryPath + "\PDF Reports\Report.pdf"
							Dim exportOptions As ExportOptions = CType(NewLateBinding.LateGet(Me.CrystalReportViewer1.ReportSource, Nothing, "ExportOptions", New Object(-1) {}, Nothing, Nothing, Nothing), ExportOptions)
							Dim exportOptions2 As ExportOptions = exportOptions
							exportOptions2.ExportDestinationType = ExportDestinationType.DiskFile
							exportOptions2.ExportFormatType = ExportFormatType.PortableDocFormat
							exportOptions2.ExportDestinationOptions = diskFileDestinationOptions
							exportOptions2.ExportFormatOptions = pdfRtfWordFormatOptions
							NewLateBinding.LateCall(Me.CrystalReportViewer1.ReportSource, Nothing, "Export", New Object(-1) {}, Nothing, Nothing, Nothing, True)
							Dim text2 As String = MyProject.Application.Info.DirectoryPath + "\PDF Reports\Report.Pdf"
							Dim dataTable As DataTable = New DataTable()
							dataTable = clsfun.ExecDataTable("Select c1,WApi,FtpUrl,FtpUser,FtpPassword,FileUrl from WappApi where c2='Enabled'")
							Dim webClient As WebClient = New WebClient()
							Dim text3 As String = dataTable.Rows(0)("c1").ToString()
							webClient.Credentials = New NetworkCredential(dataTable.Rows(0)("FtpUser").ToString(), dataTable.Rows(0)("FtpPassword").ToString())
							Dim text4 As String = text2.Split(New Char() { "/"c }).Last()
							Dim flag5 As Boolean = text4.ToUpper().Contains(".PDF")
							If flag5 Then
								MyBase.Name = "Report.pdf"
							Else
								Dim flag6 As Boolean = text4.ToUpper().Contains(".PNG")
								If flag6 Then
									MyBase.Name = "Report.png"
								Else
									MyBase.Name = "Report.jpg"
								End If
							End If
							Dim text5 As String = MyProject.Application.Info.DirectoryPath + "\PDF Reports\" + frmLogin.InstanceID
							Me.Timer1.Enabled = True
							Dim flag7 As Boolean = clswhatsApp.CreateFtpFolder(text5, frmLogin.InstanceID, dataTable, MyBase.Name, text, text2, webClient, text3 + Me.TextBox2.Text, Me.TextBox3.Text, "")
							If flag7 Then
								MessageBox.Show("Report Send")
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600CEEF RID: 52975 RVA: 0x0081253C File Offset: 0x0081073C
		Private Function WhatsAppSender(contactNo As String, msg As String, FileUrl As String) As Object
			Dim dataTable As DataTable = New DataTable()
			dataTable = clsfun.ExecDataTable("Select c1,WApi from WappApi where c2='Enabled'")
			Me.Cursor = Cursors.WaitCursor
			Me.Timer1.Enabled = True
			Try
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Dim text As String = dataTable.Rows(0)("Wapi").ToString()
					text = text.Replace("{No}", dataTable.Rows(0)("c1").ToString() + contactNo).Replace("{Msg}", msg).Replace("{url}", FileUrl)
					Dim uri As Uri = New Uri(text)
					Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(uri), HttpWebRequest)
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600CEF0 RID: 52976 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600CEF1 RID: 52977 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmailID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600CEF2 RID: 52978 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600CEF3 RID: 52979 RVA: 0x0081264C File Offset: 0x0081084C
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600CEF4 RID: 52980 RVA: 0x008126AC File Offset: 0x008108AC
		Private Async Sub WhatsAppSender()
			Me.Cursor = Cursors.WaitCursor
			Me.Timer1.Enabled = True
			Try
				Dim messageRequest As MessageRequest = New MessageRequest()
				messageRequest.Phone = Me.txtserverlink.Text + Me.TextBox2.Text
				messageRequest.Message = Me.TextBox3.Text
				messageRequest.AttachmentPath = MyProject.Application.Info.DirectoryPath + "\PDF Reports\Report.pdf"
			Catch ex As Exception
				Dim exception As Exception = ex
				MessageBox.Show(exception.Message)
			End Try
		End Sub

		' Token: 0x0600CEF5 RID: 52981 RVA: 0x008126E8 File Offset: 0x008108E8
		Private Sub frmReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F6
			If flag3 Then
				e.Handled = True
				Me.Button3.PerformClick()
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.F7
			If flag4 Then
				e.Handled = True
				Me.Button1.PerformClick()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.F8
			If flag5 Then
				e.Handled = True
				Me.Button2.PerformClick()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.F9
			If flag6 Then
				e.Handled = True
				Me.Button4.PerformClick()
			End If
		End Sub

		' Token: 0x0600CEF6 RID: 52982 RVA: 0x008127C8 File Offset: 0x008109C8
		Public Sub Whatsappsend()
			Dim text As String = ""
			Dim flag As Boolean = Operators.CompareString(Me.sts, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
				If flag2 Then
					Me.TextBox2.Focus()
					MessageBox.Show("Please fill correct WhatsApp number", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = ModFunc.CheckForInternetConnection()
					If flag3 Then
						Try
							Me.Cursor = Cursors.WaitCursor
							Me.Timer1.Enabled = True
							Dim flag4 As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\PDF Reports")
							If flag4 Then
								Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\PDF Reports\")
							End If
							Dim instantID As String = clswhatsApp.GETInstantID()
							Dim diskFileDestinationOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions()
							Dim pdfRtfWordFormatOptions As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
							diskFileDestinationOptions.DiskFileName = MyProject.Application.Info.DirectoryPath + "\PDF Reports\Report.pdf"
							Dim exportOptions As ExportOptions = CType(NewLateBinding.LateGet(Me.CrystalReportViewer1.ReportSource, Nothing, "ExportOptions", New Object(-1) {}, Nothing, Nothing, Nothing), ExportOptions)
							Dim exportOptions2 As ExportOptions = exportOptions
							exportOptions2.ExportDestinationType = ExportDestinationType.DiskFile
							exportOptions2.ExportFormatType = ExportFormatType.PortableDocFormat
							exportOptions2.ExportDestinationOptions = diskFileDestinationOptions
							exportOptions2.ExportFormatOptions = pdfRtfWordFormatOptions
							NewLateBinding.LateCall(Me.CrystalReportViewer1.ReportSource, Nothing, "Export", New Object(-1) {}, Nothing, Nothing, Nothing, True)
							Dim text2 As String = MyProject.Application.Info.DirectoryPath + "\PDF Reports\Report.Pdf"
							Dim dataTable As DataTable = New DataTable()
							dataTable = clsfun.ExecDataTable("Select c1,WApi,FtpUrl,FtpUser,FtpPassword,FileUrl from WappApi where c2='Enabled'")
							Dim webClient As WebClient = New WebClient()
							Dim text3 As String = dataTable.Rows(0)("c1").ToString()
							webClient.Credentials = New NetworkCredential(dataTable.Rows(0)("FtpUser").ToString(), dataTable.Rows(0)("FtpPassword").ToString())
							Dim text4 As String = text2.Split(New Char() { "/"c }).Last()
							Dim text5 As String = Application.StartupPath + "\2ndW.txt"
							Dim flag5 As Boolean = File.Exists(text5)
							If flag5 Then
								Dim list As List(Of String) = File.ReadAllLines(text5).ToList()
								Dim flag6 As Boolean = list.Count > 0
								If flag6 Then
									Me.instanceId = list(0)
									Me.token = list(1)
								End If
							Else
								MessageBox.Show("File not found!")
							End If
							Dim flag7 As Boolean = text4.ToUpper().Contains(".PDF")
							If flag7 Then
								MyBase.Name = "Report" + Guid.NewGuid().ToString() + ".pdf"
							Else
								Dim flag8 As Boolean = text4.ToUpper().Contains(".PNG")
								If flag8 Then
									MyBase.Name = "Report.png"
								Else
									MyBase.Name = "Report.jpg"
								End If
							End If
							Dim text6 As String = MyProject.Application.Info.DirectoryPath + "\PDF Reports\" + Me.token
							Dim flag9 As Boolean = clswhatsApp.CreateFtpFolder2(text6, Me.token, dataTable, MyBase.Name, text, text2, webClient, text3 + Me.TextBox2.Text, Me.TextBox3.Text, "")
							If flag9 Then
								MessageBox.Show("Report Send")
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600CEF7 RID: 52983 RVA: 0x00812BBC File Offset: 0x00810DBC
		Private Sub DeleteAllFilesInFolder(folderUrl As String, ftpUser As String, ftpPassword As String)
			Try
				Dim ftpWebRequest As FtpWebRequest = CType(WebRequest.Create(folderUrl), FtpWebRequest)
				ftpWebRequest.Method = "NLST"
				ftpWebRequest.Credentials = New NetworkCredential(ftpUser, ftpPassword)
				ftpWebRequest.UsePassive = True
				Dim list As List(Of String) = New List(Of String)()
				Using ftpWebResponse As FtpWebResponse = CType(ftpWebRequest.GetResponse(), FtpWebResponse)
					Using streamReader As StreamReader = New StreamReader(ftpWebResponse.GetResponseStream())
						While Not streamReader.EndOfStream
							list.Add(streamReader.ReadLine())
						End While
					End Using
				End Using
				Try
					For Each text As String In list
						Try
							Dim ftpWebRequest2 As FtpWebRequest = CType(WebRequest.Create(folderUrl + "/" + text), FtpWebRequest)
							ftpWebRequest2.Method = "DELE"
							ftpWebRequest2.Credentials = New NetworkCredential(ftpUser, ftpPassword)
							ftpWebRequest2.UsePassive = True
							Using CType(ftpWebRequest2.GetResponse(), FtpWebResponse)
								Console.WriteLine("Deleted file: " + text)
							End Using
						Catch ex As Exception
							MessageBox.Show("Error deleting file: " + text + " - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					Next
				Finally
					Dim enumerator As List(Of String).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
				MessageBox.Show("All files in the folder were deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex2 As Exception
				MessageBox.Show("An error occurred: " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CEF8 RID: 52984 RVA: 0x0005C04A File Offset: 0x0005A24A
		Private Sub Button10_Click(sender As Object, e As EventArgs)
			Me.Whatsappsend()
		End Sub

		' Token: 0x0600CEF9 RID: 52985 RVA: 0x00812E10 File Offset: 0x00811010
		Private Async Sub WhatsAppSender1()
			Me.Cursor = Cursors.WaitCursor
			Me.Timer1.Enabled = True
			Try
				Dim messageRequest As MessageRequest = New MessageRequest() With { .Phone = Me.txtserverlink.Text + Me.TextBox2.Text, .Message = Me.TextBox3.Text, .AttachmentPath = MyProject.Application.Info.DirectoryPath + "\PDF Reports\Report.pdf" }
				Dim response As MessageResponse = Await Me.whatsApp1.Send(messageRequest)
				MessageBox.Show(response.Status.Description())
			Catch exception As Exception
				MessageBox.Show(exception.Message)
			End Try
		End Sub

		' Token: 0x0600CEFA RID: 52986 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CEFB RID: 52987 RVA: 0x00812E4C File Offset: 0x0081104C
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox2.Text, "", False) = 0
				If flag2 Then
					Me.TextBox2.Focus()
					MessageBox.Show("Please fill correct WhatsApp number", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = ModFunc.CheckForInternetConnection()
					If flag3 Then
						Try
							Me.Cursor = Cursors.WaitCursor
							Me.Timer1.Enabled = True
							Dim flag4 As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\PDF Reports")
							If flag4 Then
								Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\PDF Reports\")
							End If
							Dim diskFileDestinationOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions()
							Dim pdfRtfWordFormatOptions As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
							diskFileDestinationOptions.DiskFileName = MyProject.Application.Info.DirectoryPath + "\PDF Reports\Report.pdf"
							Dim exportOptions As ExportOptions = CType(NewLateBinding.LateGet(Me.CrystalReportViewer1.ReportSource, Nothing, "ExportOptions", New Object(-1) {}, Nothing, Nothing, Nothing), ExportOptions)
							Dim exportOptions2 As ExportOptions = exportOptions
							exportOptions2.ExportDestinationType = ExportDestinationType.DiskFile
							exportOptions2.ExportFormatType = ExportFormatType.PortableDocFormat
							exportOptions2.ExportDestinationOptions = diskFileDestinationOptions
							exportOptions2.ExportFormatOptions = pdfRtfWordFormatOptions
							NewLateBinding.LateCall(Me.CrystalReportViewer1.ReportSource, Nothing, "Export", New Object(-1) {}, Nothing, Nothing, Nothing, True)
							Me.WhatsAppSender1()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					Else
						MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End If
				End If
			End If
		End Sub

		' Token: 0x0600CEFC RID: 52988 RVA: 0x0005C04A File Offset: 0x0005A24A
		Private Sub Button5_Click_1(sender As Object, e As EventArgs)
			Me.Whatsappsend()
		End Sub

		' Token: 0x0600CEFD RID: 52989 RVA: 0x00813044 File Offset: 0x00811244
		Private Sub SafeInvoke(action As Action)
			Dim invokeRequired As Boolean = MyBase.InvokeRequired
			If invokeRequired Then
				MyBase.Invoke(action)
			Else
				action()
			End If
		End Sub

		' Token: 0x0600CEFE RID: 52990 RVA: 0x00813070 File Offset: 0x00811270
		Private Sub SafeMsgBox(msg As String, Optional title As String = "Info", Optional icon As MessageBoxIcon = MessageBoxIcon.Asterisk)
			Me.SafeInvoke(Sub()
				MessageBox.Show(msg, title, MessageBoxButtons.OK, icon)
			End Sub)
		End Sub

		' Token: 0x0600CEFF RID: 52991 RVA: 0x008130AC File Offset: 0x008112AC
		Private Sub frmReport_FormClosing(sender As Object, e As FormClosingEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label5.Text, "POS_Save_Print", False) = 0
			If flag Then
				Me.Label5.Text = ""
				MyProject.Forms.frmPOS.Reset()
			End If
		End Sub

		' Token: 0x04005304 RID: 21252
		Private sts As String

		' Token: 0x04005305 RID: 21253
		Private instanceId As String

		' Token: 0x04005306 RID: 21254
		Private token As String

		' Token: 0x04005307 RID: 21255
		Private isProcessing As Boolean

		' Token: 0x04005308 RID: 21256
		Private whatsApp1 As WhatsApp
	End Class
End Namespace
