Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevNet
Imports DevNet.Models
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000332 RID: 818
	<DesignerGenerated()>
	Public Partial Class frmBulkWapp2CrCustomer
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C073 RID: 49267 RVA: 0x007A7F44 File Offset: 0x007A6144
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkWapp2CrCustomer_Load
			AddHandler MyBase.Closing, AddressOf Me.frmBulkWapp2CrCustomer_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmBulkWapp2CrCustomer_KeyDown
			Me.sts = ""
			Me.sts1 = ""
			Me.cmpnm = ""
			Me.whatsApp1 = frmMainMenu.whatsApp1
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004C92 RID: 19602
		' (get) Token: 0x0600C076 RID: 49270 RVA: 0x0005600F File Offset: 0x0005420F
		' (set) Token: 0x0600C077 RID: 49271 RVA: 0x007A98E4 File Offset: 0x007A7AE4
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

		' Token: 0x17004C93 RID: 19603
		' (get) Token: 0x0600C078 RID: 49272 RVA: 0x00056019 File Offset: 0x00054219
		' (set) Token: 0x0600C079 RID: 49273 RVA: 0x007A9928 File Offset: 0x007A7B28
		Private _Timer2 As Timer
		Friend Overridable Property Timer2 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer2_Tick
				Dim timer As Timer = Me._Timer2
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer2 = value
				timer = Me._Timer2
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C94 RID: 19604
		' (get) Token: 0x0600C07A RID: 49274 RVA: 0x00056023 File Offset: 0x00054223
		' (set) Token: 0x0600C07B RID: 49275 RVA: 0x0005602D File Offset: 0x0005422D
		Friend Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17004C95 RID: 19605
		' (get) Token: 0x0600C07C RID: 49276 RVA: 0x00056036 File Offset: 0x00054236
		' (set) Token: 0x0600C07D RID: 49277 RVA: 0x00056040 File Offset: 0x00054240
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17004C96 RID: 19606
		' (get) Token: 0x0600C07E RID: 49278 RVA: 0x00056049 File Offset: 0x00054249
		' (set) Token: 0x0600C07F RID: 49279 RVA: 0x00056053 File Offset: 0x00054253
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17004C97 RID: 19607
		' (get) Token: 0x0600C080 RID: 49280 RVA: 0x0005605C File Offset: 0x0005425C
		' (set) Token: 0x0600C081 RID: 49281 RVA: 0x00056066 File Offset: 0x00054266
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17004C98 RID: 19608
		' (get) Token: 0x0600C082 RID: 49282 RVA: 0x0005606F File Offset: 0x0005426F
		' (set) Token: 0x0600C083 RID: 49283 RVA: 0x00056079 File Offset: 0x00054279
		Friend Overridable Property cmbCustomerName As ComboBox

		' Token: 0x17004C99 RID: 19609
		' (get) Token: 0x0600C084 RID: 49284 RVA: 0x00056082 File Offset: 0x00054282
		' (set) Token: 0x0600C085 RID: 49285 RVA: 0x0005608C File Offset: 0x0005428C
		Friend Overridable Property Label4 As Label

		' Token: 0x17004C9A RID: 19610
		' (get) Token: 0x0600C086 RID: 49286 RVA: 0x00056095 File Offset: 0x00054295
		' (set) Token: 0x0600C087 RID: 49287 RVA: 0x0005609F File Offset: 0x0005429F
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004C9B RID: 19611
		' (get) Token: 0x0600C088 RID: 49288 RVA: 0x000560A8 File Offset: 0x000542A8
		' (set) Token: 0x0600C089 RID: 49289 RVA: 0x000560B2 File Offset: 0x000542B2
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004C9C RID: 19612
		' (get) Token: 0x0600C08A RID: 49290 RVA: 0x000560BB File Offset: 0x000542BB
		' (set) Token: 0x0600C08B RID: 49291 RVA: 0x000560C5 File Offset: 0x000542C5
		Friend Overridable Property Label5 As Label

		' Token: 0x17004C9D RID: 19613
		' (get) Token: 0x0600C08C RID: 49292 RVA: 0x000560CE File Offset: 0x000542CE
		' (set) Token: 0x0600C08D RID: 49293 RVA: 0x000560D8 File Offset: 0x000542D8
		Friend Overridable Property ListView1 As ListView

		' Token: 0x17004C9E RID: 19614
		' (get) Token: 0x0600C08E RID: 49294 RVA: 0x000560E1 File Offset: 0x000542E1
		' (set) Token: 0x0600C08F RID: 49295 RVA: 0x000560EB File Offset: 0x000542EB
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17004C9F RID: 19615
		' (get) Token: 0x0600C090 RID: 49296 RVA: 0x000560F4 File Offset: 0x000542F4
		' (set) Token: 0x0600C091 RID: 49297 RVA: 0x000560FE File Offset: 0x000542FE
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x17004CA0 RID: 19616
		' (get) Token: 0x0600C092 RID: 49298 RVA: 0x00056107 File Offset: 0x00054307
		' (set) Token: 0x0600C093 RID: 49299 RVA: 0x00056111 File Offset: 0x00054311
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17004CA1 RID: 19617
		' (get) Token: 0x0600C094 RID: 49300 RVA: 0x0005611A File Offset: 0x0005431A
		' (set) Token: 0x0600C095 RID: 49301 RVA: 0x00056124 File Offset: 0x00054324
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17004CA2 RID: 19618
		' (get) Token: 0x0600C096 RID: 49302 RVA: 0x0005612D File Offset: 0x0005432D
		' (set) Token: 0x0600C097 RID: 49303 RVA: 0x00056137 File Offset: 0x00054337
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004CA3 RID: 19619
		' (get) Token: 0x0600C098 RID: 49304 RVA: 0x00056140 File Offset: 0x00054340
		' (set) Token: 0x0600C099 RID: 49305 RVA: 0x0005614A File Offset: 0x0005434A
		Friend Overridable Property Label7 As Label

		' Token: 0x17004CA4 RID: 19620
		' (get) Token: 0x0600C09A RID: 49306 RVA: 0x00056153 File Offset: 0x00054353
		' (set) Token: 0x0600C09B RID: 49307 RVA: 0x007A996C File Offset: 0x007A7B6C
		Private _TextBox6 As TextBox
		Friend Overridable Property TextBox6 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox6_KeyDown
				Dim textBox As TextBox = Me._TextBox6
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox6 = value
				textBox = Me._TextBox6
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CA5 RID: 19621
		' (get) Token: 0x0600C09C RID: 49308 RVA: 0x0005615D File Offset: 0x0005435D
		' (set) Token: 0x0600C09D RID: 49309 RVA: 0x00056167 File Offset: 0x00054367
		Friend Overridable Property Label6 As Label

		' Token: 0x17004CA6 RID: 19622
		' (get) Token: 0x0600C09E RID: 49310 RVA: 0x00056170 File Offset: 0x00054370
		' (set) Token: 0x0600C09F RID: 49311 RVA: 0x0005617A File Offset: 0x0005437A
		Friend Overridable Property Label3 As Label

		' Token: 0x17004CA7 RID: 19623
		' (get) Token: 0x0600C0A0 RID: 49312 RVA: 0x00056183 File Offset: 0x00054383
		' (set) Token: 0x0600C0A1 RID: 49313 RVA: 0x007A99B0 File Offset: 0x007A7BB0
		Private _TextBox5 As TextBox
		Friend Overridable Property TextBox5 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox5_KeyDown
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CA8 RID: 19624
		' (get) Token: 0x0600C0A2 RID: 49314 RVA: 0x0005618D File Offset: 0x0005438D
		' (set) Token: 0x0600C0A3 RID: 49315 RVA: 0x00056197 File Offset: 0x00054397
		Friend Overridable Property Label2 As Label

		' Token: 0x17004CA9 RID: 19625
		' (get) Token: 0x0600C0A4 RID: 49316 RVA: 0x000561A0 File Offset: 0x000543A0
		' (set) Token: 0x0600C0A5 RID: 49317 RVA: 0x000561AA File Offset: 0x000543AA
		Friend Overridable Property Label1 As Label

		' Token: 0x17004CAA RID: 19626
		' (get) Token: 0x0600C0A6 RID: 49318 RVA: 0x000561B3 File Offset: 0x000543B3
		' (set) Token: 0x0600C0A7 RID: 49319 RVA: 0x007A99F4 File Offset: 0x007A7BF4
		Private _TextBox4 As TextBox
		Friend Overridable Property TextBox4 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox4_KeyDown
				Dim textBox As TextBox = Me._TextBox4
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox4 = value
				textBox = Me._TextBox4
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CAB RID: 19627
		' (get) Token: 0x0600C0A8 RID: 49320 RVA: 0x000561BD File Offset: 0x000543BD
		' (set) Token: 0x0600C0A9 RID: 49321 RVA: 0x007A9A38 File Offset: 0x007A7C38
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox3_KeyDown
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CAC RID: 19628
		' (get) Token: 0x0600C0AA RID: 49322 RVA: 0x000561C7 File Offset: 0x000543C7
		' (set) Token: 0x0600C0AB RID: 49323 RVA: 0x007A9A7C File Offset: 0x007A7C7C
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CAD RID: 19629
		' (get) Token: 0x0600C0AC RID: 49324 RVA: 0x000561D1 File Offset: 0x000543D1
		' (set) Token: 0x0600C0AD RID: 49325 RVA: 0x000561DB File Offset: 0x000543DB
		Friend Overridable Property Label8 As Label

		' Token: 0x17004CAE RID: 19630
		' (get) Token: 0x0600C0AE RID: 49326 RVA: 0x000561E4 File Offset: 0x000543E4
		' (set) Token: 0x0600C0AF RID: 49327 RVA: 0x007A9AC0 File Offset: 0x007A7CC0
		Private _TextBox7 As TextBox
		Friend Overridable Property TextBox7 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox7_KeyDown
				Dim textBox As TextBox = Me._TextBox7
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox7 = value
				textBox = Me._TextBox7
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CAF RID: 19631
		' (get) Token: 0x0600C0B0 RID: 49328 RVA: 0x000561EE File Offset: 0x000543EE
		' (set) Token: 0x0600C0B1 RID: 49329 RVA: 0x000561F8 File Offset: 0x000543F8
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x17004CB0 RID: 19632
		' (get) Token: 0x0600C0B2 RID: 49330 RVA: 0x00056201 File Offset: 0x00054401
		' (set) Token: 0x0600C0B3 RID: 49331 RVA: 0x0005620B File Offset: 0x0005440B
		Friend Overridable Property ListBox1 As ListBox

		' Token: 0x17004CB1 RID: 19633
		' (get) Token: 0x0600C0B4 RID: 49332 RVA: 0x00056214 File Offset: 0x00054414
		' (set) Token: 0x0600C0B5 RID: 49333 RVA: 0x0005621E File Offset: 0x0005441E
		Friend Overridable Property ListBox2 As ListBox

		' Token: 0x17004CB2 RID: 19634
		' (get) Token: 0x0600C0B6 RID: 49334 RVA: 0x00056227 File Offset: 0x00054427
		' (set) Token: 0x0600C0B7 RID: 49335 RVA: 0x007A9B04 File Offset: 0x007A7D04
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

		' Token: 0x17004CB3 RID: 19635
		' (get) Token: 0x0600C0B8 RID: 49336 RVA: 0x00056231 File Offset: 0x00054431
		' (set) Token: 0x0600C0B9 RID: 49337 RVA: 0x0005623B File Offset: 0x0005443B
		Friend Overridable Property ListBox3 As ListBox

		' Token: 0x17004CB4 RID: 19636
		' (get) Token: 0x0600C0BA RID: 49338 RVA: 0x00056244 File Offset: 0x00054444
		' (set) Token: 0x0600C0BB RID: 49339 RVA: 0x0005624E File Offset: 0x0005444E
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17004CB5 RID: 19637
		' (get) Token: 0x0600C0BC RID: 49340 RVA: 0x00056257 File Offset: 0x00054457
		' (set) Token: 0x0600C0BD RID: 49341 RVA: 0x007A9B48 File Offset: 0x007A7D48
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

		' Token: 0x17004CB6 RID: 19638
		' (get) Token: 0x0600C0BE RID: 49342 RVA: 0x00056261 File Offset: 0x00054461
		' (set) Token: 0x0600C0BF RID: 49343 RVA: 0x007A9B8C File Offset: 0x007A7D8C
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

		' Token: 0x17004CB7 RID: 19639
		' (get) Token: 0x0600C0C0 RID: 49344 RVA: 0x0005626B File Offset: 0x0005446B
		' (set) Token: 0x0600C0C1 RID: 49345 RVA: 0x007A9BD0 File Offset: 0x007A7DD0
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

		' Token: 0x17004CB8 RID: 19640
		' (get) Token: 0x0600C0C2 RID: 49346 RVA: 0x00056275 File Offset: 0x00054475
		' (set) Token: 0x0600C0C3 RID: 49347 RVA: 0x007A9C14 File Offset: 0x007A7E14
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

		' Token: 0x0600C0C4 RID: 49348 RVA: 0x007A9C58 File Offset: 0x007A7E58
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
					Me.sts1 = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.sts = "91"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C0C5 RID: 49349 RVA: 0x007A9D4C File Offset: 0x007A7F4C
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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
			End Try
		End Sub

		' Token: 0x0600C0C6 RID: 49350 RVA: 0x0005627F File Offset: 0x0005447F
		Private Sub frmBulkWapp2CrCustomer_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.FillCustomer()
			Me.GetCompanyState()
			Me.statusdisplay()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C0C7 RID: 49351 RVA: 0x007A9E28 File Offset: 0x007A8028
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

		' Token: 0x0600C0C8 RID: 49352 RVA: 0x007A9FA0 File Offset: 0x007A81A0
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

		' Token: 0x0600C0C9 RID: 49353 RVA: 0x007AA05C File Offset: 0x007A825C
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

		' Token: 0x0600C0CA RID: 49354 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C0CB RID: 49355 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C0CC RID: 49356 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C0CD RID: 49357 RVA: 0x007AA128 File Offset: 0x007A8328
		Public Sub FillCustomer()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT CustomerID, RTRIM(Name) AS Name FROM Customer ORDER BY Name", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.con.Close()
				Me.cmbCustomerName.DisplayMember = "Name"
				Me.cmbCustomerName.ValueMember = "CustomerID"
				Me.cmbCustomerName.DataSource = ModCommonClasses.ds.Tables(0)
				Me.cmbCustomerName.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C0CE RID: 49358 RVA: 0x000562A5 File Offset: 0x000544A5
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer2.Enabled = False
		End Sub

		' Token: 0x0600C0CF RID: 49359 RVA: 0x007AA21C File Offset: 0x007A841C
		Private Sub Reset()
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox5.Text = ""
			Me.TextBox6.Text = ""
			Me.TextBox7.Text = ""
			Me.TextBox8.Text = "Please pay as soon as possible"
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.ListView1.Items.Clear()
			Me.cmbCustomerName.SelectedIndex = -1
			Me.dtpDateFrom.Focus()
			Me.ListBox1.Items.Clear()
			Me.ListBox2.Items.Clear()
			Me.ListBox3.Items.Clear()
			Me.chkSelectAll.Checked = True
		End Sub

		' Token: 0x0600C0D0 RID: 49360 RVA: 0x007AA324 File Offset: 0x007A8524
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

		' Token: 0x0600C0D1 RID: 49361 RVA: 0x007AA41C File Offset: 0x007A861C
		Private Async Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts1, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Internet Connection not found", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
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
											Dim customerName As String = item.SubItems(0).Text
											Dim oBalance As String = item.SubItems(2).Text
											Dim phone As String = Me.sts + item.SubItems(1).Text
											Dim attach As String = ""
											Dim message As String = String.Format("Dear {0}, Your arrear balance is : Rs.{1}, {2}, _Best wishes from : *{3}*_", New Object() { customerName, oBalance, Me.TextBox8.Text, Me.cmpnm })
											Dim flag5 As Boolean = phone IsNot Nothing AndAlso (message IsNot Nothing OrElse attach <> Nothing)
											If flag5 Then
												Dim messageRequest As MessageRequest = New MessageRequest() With { .Phone = phone, .Message = message, .AttachmentPath = attach }
												Dim response As MessageResponse = Await Me.whatsApp1.Send(messageRequest)
												item.SubItems(7).Text = response.Status.Description()
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

		' Token: 0x0600C0D2 RID: 49362 RVA: 0x007AA464 File Offset: 0x007A8664
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo,(Sum(CustomerLedgerBook.Debit)-Sum(CustomerLedgerBook.Credit)),Customer.Address,Customer.State,Customer.City,Customer.ZipCode FROM CustomerLedgerBook INNER JOIN Customer ON CustomerLedgerBook.PartyID = Customer.CustomerID where CustomerLedgerBook.Date between @d1 and @d2 AND CustomerLedgerBook.PartyID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "CustomerLedgerBook.PartyID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " AND Customer.Name like N'%" + Me.TextBox2.Text + "%' GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN,Customer.Address,Customer.City,Customer.ZipCode having (Sum(CustomerLedgerBook.Credit)-Sum(CustomerLedgerBook.Debit))<0 ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(Math.Abs(2)).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add("")
					Me.ListView1.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C0D3 RID: 49363 RVA: 0x007AA720 File Offset: 0x007A8920
		Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo,(Sum(CustomerLedgerBook.Debit)-Sum(CustomerLedgerBook.Credit)),Customer.Address,Customer.State,Customer.City,Customer.ZipCode FROM CustomerLedgerBook INNER JOIN Customer ON CustomerLedgerBook.PartyID = Customer.CustomerID where CustomerLedgerBook.Date between @d1 and @d2 AND CustomerLedgerBook.PartyID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "CustomerLedgerBook.PartyID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " AND Customer.ContactNo like N'%" + Me.TextBox3.Text + "%' GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN,Customer.Address,Customer.City,Customer.ZipCode having (Sum(CustomerLedgerBook.Credit)-Sum(CustomerLedgerBook.Debit))<0 ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(Math.Abs(2)).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add("")
					Me.ListView1.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C0D4 RID: 49364 RVA: 0x007AA9DC File Offset: 0x007A8BDC
		Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo,(Sum(CustomerLedgerBook.Debit)-Sum(CustomerLedgerBook.Credit)),Customer.Address,Customer.State,Customer.City,Customer.ZipCode FROM CustomerLedgerBook INNER JOIN Customer ON CustomerLedgerBook.PartyID = Customer.CustomerID where CustomerLedgerBook.Date between @d1 and @d2 AND CustomerLedgerBook.PartyID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "CustomerLedgerBook.PartyID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " AND Customer.Address like N'%" + Me.TextBox4.Text + "%' GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN,Customer.Address,Customer.City,Customer.ZipCode having (Sum(CustomerLedgerBook.Credit)-Sum(CustomerLedgerBook.Debit))<0 ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(Math.Abs(2)).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add("")
					Me.ListView1.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C0D5 RID: 49365 RVA: 0x007AAC98 File Offset: 0x007A8E98
		Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo,(Sum(CustomerLedgerBook.Debit)-Sum(CustomerLedgerBook.Credit)),Customer.Address,Customer.State,Customer.City,Customer.ZipCode FROM CustomerLedgerBook INNER JOIN Customer ON CustomerLedgerBook.PartyID = Customer.CustomerID where CustomerLedgerBook.Date between @d1 and @d2 AND CustomerLedgerBook.PartyID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "CustomerLedgerBook.PartyID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " AND Customer.State like N'%" + Me.TextBox5.Text + "%' GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN,Customer.Address,Customer.City,Customer.ZipCode having (Sum(CustomerLedgerBook.Credit)-Sum(CustomerLedgerBook.Debit))<0 ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(Math.Abs(2)).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add("")
					Me.ListView1.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C0D6 RID: 49366 RVA: 0x007AAF54 File Offset: 0x007A9154
		Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo,(Sum(CustomerLedgerBook.Debit)-Sum(CustomerLedgerBook.Credit)),Customer.Address,Customer.State,Customer.City,Customer.ZipCode FROM CustomerLedgerBook INNER JOIN Customer ON CustomerLedgerBook.PartyID = Customer.CustomerID where CustomerLedgerBook.Date between @d1 and @d2 AND CustomerLedgerBook.PartyID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "CustomerLedgerBook.PartyID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " AND Customer.City like N'%" + Me.TextBox6.Text + "%' GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN,Customer.Address,Customer.City,Customer.ZipCode having (Sum(CustomerLedgerBook.Credit)-Sum(CustomerLedgerBook.Debit))<0 ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(Math.Abs(2)).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add("")
					Me.ListView1.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C0D7 RID: 49367 RVA: 0x007AB210 File Offset: 0x007A9410
		Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo,(Sum(CustomerLedgerBook.Debit)-Sum(CustomerLedgerBook.Credit)),Customer.Address,Customer.State,Customer.City,Customer.ZipCode FROM CustomerLedgerBook INNER JOIN Customer ON CustomerLedgerBook.PartyID = Customer.CustomerID where CustomerLedgerBook.Date between @d1 and @d2 AND CustomerLedgerBook.PartyID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "CustomerLedgerBook.PartyID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " AND Customer.ZipCode like N'%" + Me.TextBox7.Text + "%' GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN,Customer.Address,Customer.City,Customer.ZipCode having (Sum(CustomerLedgerBook.Credit)-Sum(CustomerLedgerBook.Debit))<0 ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(Math.Abs(2)).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add("")
					Me.ListView1.Items.Add(listViewItem)
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C0D8 RID: 49368 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmBulkWapp2CrCustomer_Closing(sender As Object, e As CancelEventArgs)
		End Sub

		' Token: 0x0600C0D9 RID: 49369 RVA: 0x007AB4CC File Offset: 0x007A96CC
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

		' Token: 0x0600C0DA RID: 49370 RVA: 0x000562C1 File Offset: 0x000544C1
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600C0DB RID: 49371 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBulkWapp2CrCustomer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C0DC RID: 49372 RVA: 0x000562DD File Offset: 0x000544DD
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600C0DD RID: 49373 RVA: 0x007AB5B8 File Offset: 0x007A97B8
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo,(Sum(CustomerLedgerBook.Debit)-Sum(CustomerLedgerBook.Credit)),Customer.Address,Customer.State,Customer.City,Customer.ZipCode FROM CustomerLedgerBook INNER JOIN Customer ON CustomerLedgerBook.PartyID = Customer.CustomerID where CustomerLedgerBook.Date between @d1 and @d2 AND CustomerLedgerBook.PartyID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "CustomerLedgerBook.PartyID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN,Customer.Address,Customer.City,Customer.ZipCode having (Sum(CustomerLedgerBook.Credit)-Sum(CustomerLedgerBook.Debit))<0 ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(Math.Abs(2)).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add("")
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

		' Token: 0x0600C0DE RID: 49374 RVA: 0x007AB89C File Offset: 0x007A9A9C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts1, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Internet Connection not found", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Me.ListView1.Items.Count = 0
					If flag3 Then
						MessageBox.Show("Please retrieve customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = Me.ListView1.CheckedItems.Count = 0
						If flag4 Then
							MessageBox.Show("Please select customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x04004D43 RID: 19779
		Private sts As String

		' Token: 0x04004D44 RID: 19780
		Private sts1 As String

		' Token: 0x04004D45 RID: 19781
		Private st1 As String

		' Token: 0x04004D46 RID: 19782
		Private st2 As String

		' Token: 0x04004D47 RID: 19783
		Private st3 As String

		' Token: 0x04004D48 RID: 19784
		Private cmpnm As String

		' Token: 0x04004D49 RID: 19785
		Private whatsApp1 As WhatsApp
	End Class
End Namespace
