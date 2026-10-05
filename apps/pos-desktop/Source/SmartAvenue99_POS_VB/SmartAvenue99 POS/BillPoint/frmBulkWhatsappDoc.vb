Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports DevNet
Imports DevNet.Models
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000293 RID: 659
	<DesignerGenerated()>
	Public Partial Class frmBulkWhatsappDoc
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600A772 RID: 42866 RVA: 0x00702D20 File Offset: 0x00700F20
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkWhatsappDoc_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBulkWhatsappDoc_KeyDown
			Me.sts = ""
			Me.sts2 = ""
			Me.cmpnm = ""
			Me.AttachFlag1 = ""
			Me.whatsApp1 = frmMainMenu.whatsApp1
			Me.InitializeComponent()
		End Sub

		' Token: 0x170040EB RID: 16619
		' (get) Token: 0x0600A775 RID: 42869 RVA: 0x0004E270 File Offset: 0x0004C470
		' (set) Token: 0x0600A776 RID: 42870 RVA: 0x0004E27A File Offset: 0x0004C47A
		Friend Overridable Property ListView1 As ListView

		' Token: 0x170040EC RID: 16620
		' (get) Token: 0x0600A777 RID: 42871 RVA: 0x0004E283 File Offset: 0x0004C483
		' (set) Token: 0x0600A778 RID: 42872 RVA: 0x0004E28D File Offset: 0x0004C48D
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x170040ED RID: 16621
		' (get) Token: 0x0600A779 RID: 42873 RVA: 0x0004E296 File Offset: 0x0004C496
		' (set) Token: 0x0600A77A RID: 42874 RVA: 0x0004E2A0 File Offset: 0x0004C4A0
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x170040EE RID: 16622
		' (get) Token: 0x0600A77B RID: 42875 RVA: 0x0004E2A9 File Offset: 0x0004C4A9
		' (set) Token: 0x0600A77C RID: 42876 RVA: 0x0004E2B3 File Offset: 0x0004C4B3
		Friend Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x170040EF RID: 16623
		' (get) Token: 0x0600A77D RID: 42877 RVA: 0x0004E2BC File Offset: 0x0004C4BC
		' (set) Token: 0x0600A77E RID: 42878 RVA: 0x0004E2C6 File Offset: 0x0004C4C6
		Friend Overridable Property RichTextBox1 As RichTextBox

		' Token: 0x170040F0 RID: 16624
		' (get) Token: 0x0600A77F RID: 42879 RVA: 0x0004E2CF File Offset: 0x0004C4CF
		' (set) Token: 0x0600A780 RID: 42880 RVA: 0x0004E2D9 File Offset: 0x0004C4D9
		Friend Overridable Property Label2 As Label

		' Token: 0x170040F1 RID: 16625
		' (get) Token: 0x0600A781 RID: 42881 RVA: 0x0004E2E2 File Offset: 0x0004C4E2
		' (set) Token: 0x0600A782 RID: 42882 RVA: 0x007046AC File Offset: 0x007028AC
		Private _Start As Button
		Friend Overridable Property Start As Button
			<CompilerGenerated()>
			Get
				Return Me._Start
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Start_Click
				Dim button As Button = Me._Start
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Start = value
				button = Me._Start
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170040F2 RID: 16626
		' (get) Token: 0x0600A783 RID: 42883 RVA: 0x0004E2EC File Offset: 0x0004C4EC
		' (set) Token: 0x0600A784 RID: 42884 RVA: 0x0004E2F6 File Offset: 0x0004C4F6
		Friend Overridable Property Label6 As Label

		' Token: 0x170040F3 RID: 16627
		' (get) Token: 0x0600A785 RID: 42885 RVA: 0x0004E2FF File Offset: 0x0004C4FF
		' (set) Token: 0x0600A786 RID: 42886 RVA: 0x007046F0 File Offset: 0x007028F0
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170040F4 RID: 16628
		' (get) Token: 0x0600A787 RID: 42887 RVA: 0x0004E309 File Offset: 0x0004C509
		' (set) Token: 0x0600A788 RID: 42888 RVA: 0x0004E313 File Offset: 0x0004C513
		Friend Overridable Property openAttach As OpenFileDialog

		' Token: 0x170040F5 RID: 16629
		' (get) Token: 0x0600A789 RID: 42889 RVA: 0x0004E31C File Offset: 0x0004C51C
		' (set) Token: 0x0600A78A RID: 42890 RVA: 0x00704734 File Offset: 0x00702934
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170040F6 RID: 16630
		' (get) Token: 0x0600A78B RID: 42891 RVA: 0x0004E326 File Offset: 0x0004C526
		' (set) Token: 0x0600A78C RID: 42892 RVA: 0x0004E330 File Offset: 0x0004C530
		Friend Overridable Property Label7 As Label

		' Token: 0x170040F7 RID: 16631
		' (get) Token: 0x0600A78D RID: 42893 RVA: 0x0004E339 File Offset: 0x0004C539
		' (set) Token: 0x0600A78E RID: 42894 RVA: 0x0004E343 File Offset: 0x0004C543
		Friend Overridable Property tBoxAttach As TextBox

		' Token: 0x170040F8 RID: 16632
		' (get) Token: 0x0600A78F RID: 42895 RVA: 0x0004E34C File Offset: 0x0004C54C
		' (set) Token: 0x0600A790 RID: 42896 RVA: 0x0004E356 File Offset: 0x0004C556
		Friend Overridable Property label3 As Label

		' Token: 0x170040F9 RID: 16633
		' (get) Token: 0x0600A791 RID: 42897 RVA: 0x0004E35F File Offset: 0x0004C55F
		' (set) Token: 0x0600A792 RID: 42898 RVA: 0x00704778 File Offset: 0x00702978
		Private _btnAttachBrowse As Button
		Friend Overridable Property btnAttachBrowse As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAttachBrowse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAttachBrowse_Click
				Dim button As Button = Me._btnAttachBrowse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAttachBrowse = value
				button = Me._btnAttachBrowse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170040FA RID: 16634
		' (get) Token: 0x0600A793 RID: 42899 RVA: 0x0004E369 File Offset: 0x0004C569
		' (set) Token: 0x0600A794 RID: 42900 RVA: 0x0004E373 File Offset: 0x0004C573
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x170040FB RID: 16635
		' (get) Token: 0x0600A795 RID: 42901 RVA: 0x0004E37C File Offset: 0x0004C57C
		' (set) Token: 0x0600A796 RID: 42902 RVA: 0x007047BC File Offset: 0x007029BC
		Private _Timer1 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer1 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer1
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

		' Token: 0x170040FC RID: 16636
		' (get) Token: 0x0600A797 RID: 42903 RVA: 0x0004E386 File Offset: 0x0004C586
		' (set) Token: 0x0600A798 RID: 42904 RVA: 0x0004E390 File Offset: 0x0004C590
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x170040FD RID: 16637
		' (get) Token: 0x0600A799 RID: 42905 RVA: 0x0004E399 File Offset: 0x0004C599
		' (set) Token: 0x0600A79A RID: 42906 RVA: 0x0004E3A3 File Offset: 0x0004C5A3
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x170040FE RID: 16638
		' (get) Token: 0x0600A79B RID: 42907 RVA: 0x0004E3AC File Offset: 0x0004C5AC
		' (set) Token: 0x0600A79C RID: 42908 RVA: 0x0004E3B6 File Offset: 0x0004C5B6
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x170040FF RID: 16639
		' (get) Token: 0x0600A79D RID: 42909 RVA: 0x0004E3BF File Offset: 0x0004C5BF
		' (set) Token: 0x0600A79E RID: 42910 RVA: 0x0004E3C9 File Offset: 0x0004C5C9
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17004100 RID: 16640
		' (get) Token: 0x0600A79F RID: 42911 RVA: 0x0004E3D2 File Offset: 0x0004C5D2
		' (set) Token: 0x0600A7A0 RID: 42912 RVA: 0x0004E3DC File Offset: 0x0004C5DC
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17004101 RID: 16641
		' (get) Token: 0x0600A7A1 RID: 42913 RVA: 0x0004E3E5 File Offset: 0x0004C5E5
		' (set) Token: 0x0600A7A2 RID: 42914 RVA: 0x0004E3EF File Offset: 0x0004C5EF
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17004102 RID: 16642
		' (get) Token: 0x0600A7A3 RID: 42915 RVA: 0x0004E3F8 File Offset: 0x0004C5F8
		' (set) Token: 0x0600A7A4 RID: 42916 RVA: 0x0004E402 File Offset: 0x0004C602
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x17004103 RID: 16643
		' (get) Token: 0x0600A7A5 RID: 42917 RVA: 0x0004E40B File Offset: 0x0004C60B
		' (set) Token: 0x0600A7A6 RID: 42918 RVA: 0x00704800 File Offset: 0x00702A00
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004104 RID: 16644
		' (get) Token: 0x0600A7A7 RID: 42919 RVA: 0x0004E415 File Offset: 0x0004C615
		' (set) Token: 0x0600A7A8 RID: 42920 RVA: 0x0004E41F File Offset: 0x0004C61F
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004105 RID: 16645
		' (get) Token: 0x0600A7A9 RID: 42921 RVA: 0x0004E428 File Offset: 0x0004C628
		' (set) Token: 0x0600A7AA RID: 42922 RVA: 0x0004E432 File Offset: 0x0004C632
		Friend Overridable Property GroupBox7 As GroupBox

		' Token: 0x17004106 RID: 16646
		' (get) Token: 0x0600A7AB RID: 42923 RVA: 0x0004E43B File Offset: 0x0004C63B
		' (set) Token: 0x0600A7AC RID: 42924 RVA: 0x0004E445 File Offset: 0x0004C645
		Friend Overridable Property Label1 As Label

		' Token: 0x17004107 RID: 16647
		' (get) Token: 0x0600A7AD RID: 42925 RVA: 0x0004E44E File Offset: 0x0004C64E
		' (set) Token: 0x0600A7AE RID: 42926 RVA: 0x0004E458 File Offset: 0x0004C658
		Friend Overridable Property Label4 As Label

		' Token: 0x17004108 RID: 16648
		' (get) Token: 0x0600A7AF RID: 42927 RVA: 0x0004E461 File Offset: 0x0004C661
		' (set) Token: 0x0600A7B0 RID: 42928 RVA: 0x00704844 File Offset: 0x00702A44
		Private _txtSlNo2 As TextBox
		Friend Overridable Property txtSlNo2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSlNo2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSlNo2_KeyPress
				Dim textBox As TextBox = Me._txtSlNo2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtSlNo2 = value
				textBox = Me._txtSlNo2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004109 RID: 16649
		' (get) Token: 0x0600A7B1 RID: 42929 RVA: 0x0004E46B File Offset: 0x0004C66B
		' (set) Token: 0x0600A7B2 RID: 42930 RVA: 0x00704888 File Offset: 0x00702A88
		Private _txtSlNo1 As TextBox
		Friend Overridable Property txtSlNo1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSlNo1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSlNo1_KeyPress
				Dim textBox As TextBox = Me._txtSlNo1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtSlNo1 = value
				textBox = Me._txtSlNo1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700410A RID: 16650
		' (get) Token: 0x0600A7B3 RID: 42931 RVA: 0x0004E475 File Offset: 0x0004C675
		' (set) Token: 0x0600A7B4 RID: 42932 RVA: 0x0004E47F File Offset: 0x0004C67F
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x1700410B RID: 16651
		' (get) Token: 0x0600A7B5 RID: 42933 RVA: 0x0004E488 File Offset: 0x0004C688
		' (set) Token: 0x0600A7B6 RID: 42934 RVA: 0x007048CC File Offset: 0x00702ACC
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

		' Token: 0x1700410C RID: 16652
		' (get) Token: 0x0600A7B7 RID: 42935 RVA: 0x0004E492 File Offset: 0x0004C692
		' (set) Token: 0x0600A7B8 RID: 42936 RVA: 0x00704910 File Offset: 0x00702B10
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700410D RID: 16653
		' (get) Token: 0x0600A7B9 RID: 42937 RVA: 0x0004E49C File Offset: 0x0004C69C
		' (set) Token: 0x0600A7BA RID: 42938 RVA: 0x00704954 File Offset: 0x00702B54
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700410E RID: 16654
		' (get) Token: 0x0600A7BB RID: 42939 RVA: 0x0004E4A6 File Offset: 0x0004C6A6
		' (set) Token: 0x0600A7BC RID: 42940 RVA: 0x0004E4B0 File Offset: 0x0004C6B0
		Friend Overridable Property lblAttach As Label

		' Token: 0x1700410F RID: 16655
		' (get) Token: 0x0600A7BD RID: 42941 RVA: 0x0004E4B9 File Offset: 0x0004C6B9
		' (set) Token: 0x0600A7BE RID: 42942 RVA: 0x00704998 File Offset: 0x00702B98
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

		' Token: 0x0600A7BF RID: 42943 RVA: 0x007049DC File Offset: 0x00702BDC
		Public Function CheckForInternetConnection() As Boolean
			Thread.Sleep(1000)
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

		' Token: 0x0600A7C0 RID: 42944 RVA: 0x0004E4C3 File Offset: 0x0004C6C3
		Private Sub frmBulkWhatsappDoc_Load(sender As Object, e As EventArgs)
			Me.statusdisplay()
			Me.GetCompanyState()
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600A7C1 RID: 42945 RVA: 0x00704A60 File Offset: 0x00702C60
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

		' Token: 0x0600A7C2 RID: 42946 RVA: 0x00704BD8 File Offset: 0x00702DD8
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

		' Token: 0x0600A7C3 RID: 42947 RVA: 0x00704C94 File Offset: 0x00702E94
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

		' Token: 0x0600A7C4 RID: 42948 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600A7C5 RID: 42949 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600A7C6 RID: 42950 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600A7C7 RID: 42951 RVA: 0x00704D60 File Offset: 0x00702F60
		Private Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer where not Customer.Name='Cash' order by Customer.Name ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add("")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A7C8 RID: 42952 RVA: 0x00704FD4 File Offset: 0x007031D4
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.ListView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.ListView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.ListView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.ListView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x0600A7C9 RID: 42953 RVA: 0x007050C0 File Offset: 0x007032C0
		Private Async Sub Start_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not Me.CheckForInternetConnection()
				If flag2 Then
					Interaction.MsgBox("Internet Connection not avaliable !", MsgBoxStyle.Information, "Info")
				Else
					Dim flag3 As Boolean = Me.ListView1.Items.Count = 0
					If flag3 Then
						MessageBox.Show("Please retrieve customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = Me.ListView1.CheckedItems.Count = 0
						If flag4 Then
							MessageBox.Show("Please select customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Try
								Me.Cursor = Cursors.WaitCursor
								Me.Timer1.Enabled = True
								Dim path As String = ""
								Dim instantid As String = ""
								Dim checkCounter As Integer = 0
								Dim tmpCounter As Integer = 0
								Try
									For Each obj As Object In Me.ListView1.Items
										Dim item As ListViewItem = CType(obj, ListViewItem)
										Dim checked As Boolean = item.Checked
										If checked Then
											checkCounter = 1
										End If
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								Try
									For Each obj2 As Object In Me.ListView1.Items
										Dim item2 As ListViewItem = CType(obj2, ListViewItem)
										Try
											Dim checked2 As Boolean = item2.Checked
											If checked2 Then
												tmpCounter = 1
												Dim customerName As String = item2.SubItems(1).Text
												Dim textsms As String = Me.RichTextBox1.Text
												Dim phone As String = item2.SubItems(2).Text
												Dim attach As String = Me.tBoxAttach.Text
												Dim name As String = ""
												Dim message As String = String.Format("Dear {0}, {1}, {2}, _Best wishes from : *{3}*_", New Object() { customerName, textsms, "", Me.cmpnm })
												Dim dt As DataTable = New DataTable()
												dt = clsfun.ExecDataTable("Select c1,WApi,FtpUrl,FtpUser,FtpPassword,FileUrl from WappApi where c2='Enabled'")
												Dim client As WebClient = New WebClient()
												Dim countryCode As String = dt.Rows(0)("c1").ToString()
												client.Credentials = New NetworkCredential(dt.Rows(0)("FtpUser").ToString(), dt.Rows(0)("FtpPassword").ToString())
												Dim filename As String = attach.Split(New Char() { "/"c }).Last()
												Dim flag5 As Boolean = filename.Contains(".pdf")
												If flag5 Then
													name = "Report.pdf"
												Else
													Dim flag6 As Boolean = filename.Contains(".png")
													If flag6 Then
														name = "Report.png"
													Else
														Dim flag7 As Boolean = filename.Contains(".mp4")
														If flag7 Then
															name = "Report.mp4"
														Else
															name = "Report.jpg"
														End If
													End If
												End If
												instantid = clswhatsApp.GETInstantID()
												Dim tmpDir As String = MyProject.Application.Info.DirectoryPath + "\PDF Reports\" + frmLogin.InstanceID
												Me.Timer1.Enabled = True
												Dim flag8 As Boolean = checkCounter = 1
												If flag8 Then
													Dim flag9 As Boolean = clswhatsApp.CreateFtpFolder(tmpDir, instantid, dt, name, path, attach, client, countryCode + phone, message, "FI")
													If flag9 Then
														item2.SubItems(3).Text = "Success"
													End If
												Else
													Dim flag10 As Boolean = tmpCounter = checkCounter
													If flag10 Then
														Dim flag11 As Boolean = clswhatsApp.CreateFtpFolder(tmpDir, instantid, dt, name, path, attach, client, countryCode + phone, message, "L")
														If flag11 Then
															item2.SubItems(3).Text = "Success"
														End If
													Else
														Dim flag12 As Boolean = clswhatsApp.CreateFtpFolder(tmpDir, instantid, dt, name, path, attach, client, countryCode + phone, message, "F")
														If flag12 Then
															item2.SubItems(3).Text = "Success"
														End If
													End If
												End If
											End If
											Await Task.Delay(7000)
										Catch ex As Exception
											MessageBox.Show("Exeception: " + ex.Message)
										End Try
									Next
								Finally
									Dim enumerator2 As IEnumerator
									If TypeOf enumerator2 Is IDisposable Then
										TryCast(enumerator2, IDisposable).Dispose()
									End If
								End Try
								MessageBox.Show("Function Successfully Completed")
							Catch ex2 As Exception
								MessageBox.Show("Engine is not active" + ex2.Message)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600A7CA RID: 42954 RVA: 0x00705108 File Offset: 0x00703308
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

		' Token: 0x0600A7CB RID: 42955 RVA: 0x00705218 File Offset: 0x00703418
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

		' Token: 0x0600A7CC RID: 42956 RVA: 0x00705278 File Offset: 0x00703478
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please select saerch category", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.ComboBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						Dim text As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.Name like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							Dim text2 As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.ContactNo like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
							ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								Dim text3 As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.Address like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
								ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									Dim text4 As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.City like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
									ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										Dim text5 As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.State like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
										ModCommonClasses.cmd = New SqlCommand(text5, ModCommonClasses.con)
									Else
										Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 5
										If flag7 Then
											Dim text6 As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.ZipCode like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
											ModCommonClasses.cmd = New SqlCommand(text6, ModCommonClasses.con)
										Else
											Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 6
											If flag8 Then
												Dim text7 As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.CardNo like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
												ModCommonClasses.cmd = New SqlCommand(text7, ModCommonClasses.con)
											Else
												Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 7
												If flag9 Then
													Dim text8 As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.Route like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
													ModCommonClasses.cmd = New SqlCommand(text8, ModCommonClasses.con)
												Else
													Dim flag10 As Boolean = Me.ComboBox1.SelectedIndex = 8
													If flag10 Then
														Dim text9 As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.Remarks like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
														ModCommonClasses.cmd = New SqlCommand(text9, ModCommonClasses.con)
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.ListView1.Items.Clear()
					While ModCommonClasses.rdr.Read()
						Dim listViewItem As ListViewItem = New ListViewItem()
						listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
						listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
						listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
						listViewItem.SubItems.Add("")
						listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
						listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
						listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
						listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
						listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
						listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
						listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
						Me.ListView1.Items.Add(listViewItem)
					End While
					Dim num As Integer = Me.ListView1.Items.Count - 1
					For i As Integer = 0 To num
						Me.ListView1.Items(i).Checked = True
					Next
					ModCommonClasses.con.Close()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600A7CD RID: 42957 RVA: 0x00705790 File Offset: 0x00703990
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
					Me.sts = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.sts = "91"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A7CE RID: 42958 RVA: 0x00705884 File Offset: 0x00703A84
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmpnm = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.cmpnm = ""
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

		' Token: 0x0600A7CF RID: 42959 RVA: 0x0004E4E2 File Offset: 0x0004C6E2
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600A7D0 RID: 42960 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBulkWhatsappDoc_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600A7D1 RID: 42961 RVA: 0x0004E4FE File Offset: 0x0004C6FE
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
		End Sub

		' Token: 0x0600A7D2 RID: 42962 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub txtSlNo1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600A7D3 RID: 42963 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub txtSlNo2_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600A7D4 RID: 42964 RVA: 0x0070597C File Offset: 0x00703B7C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Customer.CustomerID, Customer.Name, Customer.ContactNo, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.CardNo, Customer.Route, Customer.Remarks FROM Customer WHERE not Customer.Name='Cash' and Customer.ID between @d1 and @d2 order by Customer.Name ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSlNo1.Text.Trim())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSlNo2.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add("")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A7D5 RID: 42965 RVA: 0x00705C44 File Offset: 0x00703E44
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.RichTextBox1.Clear()
			Me.RichTextBox1.Focus()
			Me.tBoxAttach.Text = ""
			Me.TextBox1.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.txtSlNo1.Text = ""
			Me.txtSlNo2.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600A7D6 RID: 42966 RVA: 0x0004E50D File Offset: 0x0004C70D
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.AttachFlag1 = "F"
		End Sub

		' Token: 0x0600A7D7 RID: 42967 RVA: 0x00705CC4 File Offset: 0x00703EC4
		Private Async Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not Me.CheckForInternetConnection()
				If flag2 Then
					Interaction.MsgBox("Internet Connection not avaliable !", MsgBoxStyle.Information, "Info")
				Else
					Dim flag3 As Boolean = Me.ListView1.Items.Count = 0
					If flag3 Then
						MessageBox.Show("Please retrieve customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = Me.ListView1.CheckedItems.Count = 0
						If flag4 Then
							MessageBox.Show("Please select customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Try
								Me.Cursor = Cursors.WaitCursor
								Me.Timer1.Enabled = True
								Try
									For Each obj As Object In Me.ListView1.Items
										Dim item As ListViewItem = CType(obj, ListViewItem)
										Dim checked As Boolean = item.Checked
										If checked Then
											Dim customerName As String = item.SubItems(1).Text
											Dim textsms As String = Me.RichTextBox1.Text
											Dim phone As String = Me.sts + item.SubItems(2).Text
											Dim attach As String = Me.tBoxAttach.Text
											Dim message As String = ""
											Dim checked2 As Boolean = Me.chkSelectAll.Checked
											If checked2 Then
												message = String.Format("Dear {0}, {1}, _Best wishes from : *{2}*_", customerName, textsms, Me.cmpnm)
											Else
												message = String.Format("{0}, _Best wishes from : *{1}*_", textsms, Me.cmpnm)
											End If
											Dim flag5 As Boolean = phone IsNot Nothing AndAlso (message IsNot Nothing OrElse attach <> Nothing)
											If flag5 Then
												Dim messageRequest As MessageRequest = New MessageRequest() With { .Phone = phone, .Message = message, .AttachmentPath = attach }
												Dim response As MessageResponse = Await Me.whatsApp1.Send(messageRequest)
												item.SubItems(3).Text = response.Status.Description()
											End If
										End If
										Await Task.Delay(7000)
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								MessageBox.Show("WhatsApp function completed", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Catch ex As Exception
								MessageBox.Show("Engine is not active")
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x040045F5 RID: 17909
		Private sts As String

		' Token: 0x040045F6 RID: 17910
		Private sts2 As String

		' Token: 0x040045F7 RID: 17911
		Private cmpnm As String

		' Token: 0x040045F8 RID: 17912
		Private AttachFlag1 As String

		' Token: 0x040045F9 RID: 17913
		Private whatsApp1 As WhatsApp
	End Class
End Namespace
