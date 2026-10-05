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
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports DevNet
Imports DevNet.Models
Imports DevNetWP.Classes
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x02000373 RID: 883
	<DesignerGenerated()>
	Public Partial Class frmWAppAPIServer
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600D07E RID: 53374 RVA: 0x0081EF84 File Offset: 0x0081D184
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAutobackup_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmWAppAPIServer_KeyDown
			Me.sts2 = ""
			Me._ApiRequestor = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x170051B8 RID: 20920
		' (get) Token: 0x0600D081 RID: 53377 RVA: 0x0005CB77 File Offset: 0x0005AD77
		' (set) Token: 0x0600D082 RID: 53378 RVA: 0x0005CB81 File Offset: 0x0005AD81
		Friend Overridable Property Timer1 As Timer

		' Token: 0x170051B9 RID: 20921
		' (get) Token: 0x0600D083 RID: 53379 RVA: 0x0005CB8A File Offset: 0x0005AD8A
		' (set) Token: 0x0600D084 RID: 53380 RVA: 0x0005CB94 File Offset: 0x0005AD94
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170051BA RID: 20922
		' (get) Token: 0x0600D085 RID: 53381 RVA: 0x0005CB9D File Offset: 0x0005AD9D
		' (set) Token: 0x0600D086 RID: 53382 RVA: 0x0005CBA7 File Offset: 0x0005ADA7
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170051BB RID: 20923
		' (get) Token: 0x0600D087 RID: 53383 RVA: 0x0005CBB0 File Offset: 0x0005ADB0
		' (set) Token: 0x0600D088 RID: 53384 RVA: 0x0005CBBA File Offset: 0x0005ADBA
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170051BC RID: 20924
		' (get) Token: 0x0600D089 RID: 53385 RVA: 0x0005CBC3 File Offset: 0x0005ADC3
		' (set) Token: 0x0600D08A RID: 53386 RVA: 0x0005CBCD File Offset: 0x0005ADCD
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170051BD RID: 20925
		' (get) Token: 0x0600D08B RID: 53387 RVA: 0x0005CBD6 File Offset: 0x0005ADD6
		' (set) Token: 0x0600D08C RID: 53388 RVA: 0x0005CBE0 File Offset: 0x0005ADE0
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170051BE RID: 20926
		' (get) Token: 0x0600D08D RID: 53389 RVA: 0x0005CBE9 File Offset: 0x0005ADE9
		' (set) Token: 0x0600D08E RID: 53390 RVA: 0x0005CBF3 File Offset: 0x0005ADF3
		Friend Overridable Property txtMsgApi As TextBox

		' Token: 0x170051BF RID: 20927
		' (get) Token: 0x0600D08F RID: 53391 RVA: 0x0005CBFC File Offset: 0x0005ADFC
		' (set) Token: 0x0600D090 RID: 53392 RVA: 0x0005CC06 File Offset: 0x0005AE06
		Friend Overridable Property Label9 As Label

		' Token: 0x170051C0 RID: 20928
		' (get) Token: 0x0600D091 RID: 53393 RVA: 0x0005CC0F File Offset: 0x0005AE0F
		' (set) Token: 0x0600D092 RID: 53394 RVA: 0x0005CC19 File Offset: 0x0005AE19
		Friend Overridable Property txtFileUrl As TextBox

		' Token: 0x170051C1 RID: 20929
		' (get) Token: 0x0600D093 RID: 53395 RVA: 0x0005CC22 File Offset: 0x0005AE22
		' (set) Token: 0x0600D094 RID: 53396 RVA: 0x0005CC2C File Offset: 0x0005AE2C
		Friend Overridable Property Label8 As Label

		' Token: 0x170051C2 RID: 20930
		' (get) Token: 0x0600D095 RID: 53397 RVA: 0x0005CC35 File Offset: 0x0005AE35
		' (set) Token: 0x0600D096 RID: 53398 RVA: 0x0005CC3F File Offset: 0x0005AE3F
		Friend Overridable Property txtPassword As TextBox

		' Token: 0x170051C3 RID: 20931
		' (get) Token: 0x0600D097 RID: 53399 RVA: 0x0005CC48 File Offset: 0x0005AE48
		' (set) Token: 0x0600D098 RID: 53400 RVA: 0x0005CC52 File Offset: 0x0005AE52
		Friend Overridable Property Label7 As Label

		' Token: 0x170051C4 RID: 20932
		' (get) Token: 0x0600D099 RID: 53401 RVA: 0x0005CC5B File Offset: 0x0005AE5B
		' (set) Token: 0x0600D09A RID: 53402 RVA: 0x0005CC65 File Offset: 0x0005AE65
		Friend Overridable Property txtUserId As TextBox

		' Token: 0x170051C5 RID: 20933
		' (get) Token: 0x0600D09B RID: 53403 RVA: 0x0005CC6E File Offset: 0x0005AE6E
		' (set) Token: 0x0600D09C RID: 53404 RVA: 0x0005CC78 File Offset: 0x0005AE78
		Friend Overridable Property Label6 As Label

		' Token: 0x170051C6 RID: 20934
		' (get) Token: 0x0600D09D RID: 53405 RVA: 0x0005CC81 File Offset: 0x0005AE81
		' (set) Token: 0x0600D09E RID: 53406 RVA: 0x0005CC8B File Offset: 0x0005AE8B
		Friend Overridable Property txtFtpUrl As TextBox

		' Token: 0x170051C7 RID: 20935
		' (get) Token: 0x0600D09F RID: 53407 RVA: 0x0005CC94 File Offset: 0x0005AE94
		' (set) Token: 0x0600D0A0 RID: 53408 RVA: 0x0005CC9E File Offset: 0x0005AE9E
		Friend Overridable Property Label5 As Label

		' Token: 0x170051C8 RID: 20936
		' (get) Token: 0x0600D0A1 RID: 53409 RVA: 0x0005CCA7 File Offset: 0x0005AEA7
		' (set) Token: 0x0600D0A2 RID: 53410 RVA: 0x0005CCB1 File Offset: 0x0005AEB1
		Friend Overridable Property txtWApi As TextBox

		' Token: 0x170051C9 RID: 20937
		' (get) Token: 0x0600D0A3 RID: 53411 RVA: 0x0005CCBA File Offset: 0x0005AEBA
		' (set) Token: 0x0600D0A4 RID: 53412 RVA: 0x0005CCC4 File Offset: 0x0005AEC4
		Friend Overridable Property Label4 As Label

		' Token: 0x170051CA RID: 20938
		' (get) Token: 0x0600D0A5 RID: 53413 RVA: 0x0005CCCD File Offset: 0x0005AECD
		' (set) Token: 0x0600D0A6 RID: 53414 RVA: 0x00821E34 File Offset: 0x00820034
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown_1
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress_1
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x170051CB RID: 20939
		' (get) Token: 0x0600D0A7 RID: 53415 RVA: 0x0005CCD7 File Offset: 0x0005AED7
		' (set) Token: 0x0600D0A8 RID: 53416 RVA: 0x00821E94 File Offset: 0x00820094
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox1_KeyDown_1
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170051CC RID: 20940
		' (get) Token: 0x0600D0A9 RID: 53417 RVA: 0x0005CCE1 File Offset: 0x0005AEE1
		' (set) Token: 0x0600D0AA RID: 53418 RVA: 0x0005CCEB File Offset: 0x0005AEEB
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x170051CD RID: 20941
		' (get) Token: 0x0600D0AB RID: 53419 RVA: 0x0005CCF4 File Offset: 0x0005AEF4
		' (set) Token: 0x0600D0AC RID: 53420 RVA: 0x0005CCFE File Offset: 0x0005AEFE
		Friend Overridable Property Label2 As Label

		' Token: 0x170051CE RID: 20942
		' (get) Token: 0x0600D0AD RID: 53421 RVA: 0x0005CD07 File Offset: 0x0005AF07
		' (set) Token: 0x0600D0AE RID: 53422 RVA: 0x0005CD11 File Offset: 0x0005AF11
		Friend Overridable Property Label3 As Label

		' Token: 0x170051CF RID: 20943
		' (get) Token: 0x0600D0AF RID: 53423 RVA: 0x0005CD1A File Offset: 0x0005AF1A
		' (set) Token: 0x0600D0B0 RID: 53424 RVA: 0x0005CD24 File Offset: 0x0005AF24
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170051D0 RID: 20944
		' (get) Token: 0x0600D0B1 RID: 53425 RVA: 0x0005CD2D File Offset: 0x0005AF2D
		' (set) Token: 0x0600D0B2 RID: 53426 RVA: 0x0005CD37 File Offset: 0x0005AF37
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170051D1 RID: 20945
		' (get) Token: 0x0600D0B3 RID: 53427 RVA: 0x0005CD40 File Offset: 0x0005AF40
		' (set) Token: 0x0600D0B4 RID: 53428 RVA: 0x0005CD4A File Offset: 0x0005AF4A
		Friend Overridable Property Label1 As Label

		' Token: 0x170051D2 RID: 20946
		' (get) Token: 0x0600D0B5 RID: 53429 RVA: 0x0005CD53 File Offset: 0x0005AF53
		' (set) Token: 0x0600D0B6 RID: 53430 RVA: 0x0005CD5D File Offset: 0x0005AF5D
		Friend Overridable Property btnInitialize As Button

		' Token: 0x170051D3 RID: 20947
		' (get) Token: 0x0600D0B7 RID: 53431 RVA: 0x0005CD66 File Offset: 0x0005AF66
		' (set) Token: 0x0600D0B8 RID: 53432 RVA: 0x0005CD70 File Offset: 0x0005AF70
		Friend Overridable Property btnLogout As Button

		' Token: 0x170051D4 RID: 20948
		' (get) Token: 0x0600D0B9 RID: 53433 RVA: 0x0005CD79 File Offset: 0x0005AF79
		' (set) Token: 0x0600D0BA RID: 53434 RVA: 0x0005CD83 File Offset: 0x0005AF83
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170051D5 RID: 20949
		' (get) Token: 0x0600D0BB RID: 53435 RVA: 0x0005CD8C File Offset: 0x0005AF8C
		' (set) Token: 0x0600D0BC RID: 53436 RVA: 0x0005CD96 File Offset: 0x0005AF96
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170051D6 RID: 20950
		' (get) Token: 0x0600D0BD RID: 53437 RVA: 0x0005CD9F File Offset: 0x0005AF9F
		' (set) Token: 0x0600D0BE RID: 53438 RVA: 0x00821ED8 File Offset: 0x008200D8
		Private _btnReconnect As GelButton
		Friend Overridable Property btnReconnect As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReconnect
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReconnect_Click
				Dim gelButton As GelButton = Me._btnReconnect
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReconnect = value
				gelButton = Me._btnReconnect
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170051D7 RID: 20951
		' (get) Token: 0x0600D0BF RID: 53439 RVA: 0x0005CDA9 File Offset: 0x0005AFA9
		' (set) Token: 0x0600D0C0 RID: 53440 RVA: 0x00821F1C File Offset: 0x0082011C
		Private _btnResetInstance As GelButton
		Friend Overridable Property btnResetInstance As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnResetInstance
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnResetInstance_Click
				Dim gelButton As GelButton = Me._btnResetInstance
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnResetInstance = value
				gelButton = Me._btnResetInstance
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170051D8 RID: 20952
		' (get) Token: 0x0600D0C1 RID: 53441 RVA: 0x0005CDB3 File Offset: 0x0005AFB3
		' (set) Token: 0x0600D0C2 RID: 53442 RVA: 0x00821F60 File Offset: 0x00820160
		Private _btnRebootInstance As GelButton
		Friend Overridable Property btnRebootInstance As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnRebootInstance
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnRebootInstance_Click
				Dim gelButton As GelButton = Me._btnRebootInstance
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnRebootInstance = value
				gelButton = Me._btnRebootInstance
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170051D9 RID: 20953
		' (get) Token: 0x0600D0C3 RID: 53443 RVA: 0x0005CDBD File Offset: 0x0005AFBD
		' (set) Token: 0x0600D0C4 RID: 53444 RVA: 0x0005CDC7 File Offset: 0x0005AFC7
		Friend Overridable Property Panel9 As Panel

		' Token: 0x170051DA RID: 20954
		' (get) Token: 0x0600D0C5 RID: 53445 RVA: 0x0005CDD0 File Offset: 0x0005AFD0
		' (set) Token: 0x0600D0C6 RID: 53446 RVA: 0x0005CDDA File Offset: 0x0005AFDA
		Friend Overridable Property imgBarcode As PictureBox

		' Token: 0x170051DB RID: 20955
		' (get) Token: 0x0600D0C7 RID: 53447 RVA: 0x0005CDE3 File Offset: 0x0005AFE3
		' (set) Token: 0x0600D0C8 RID: 53448 RVA: 0x0005CDED File Offset: 0x0005AFED
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170051DC RID: 20956
		' (get) Token: 0x0600D0C9 RID: 53449 RVA: 0x0005CDF6 File Offset: 0x0005AFF6
		' (set) Token: 0x0600D0CA RID: 53450 RVA: 0x0005CE00 File Offset: 0x0005B000
		Friend Overridable Property chkBoxHeadLess As CheckBox

		' Token: 0x170051DD RID: 20957
		' (get) Token: 0x0600D0CB RID: 53451 RVA: 0x0005CE09 File Offset: 0x0005B009
		' (set) Token: 0x0600D0CC RID: 53452 RVA: 0x0005CE13 File Offset: 0x0005B013
		Friend Overridable Property Button1 As Button

		' Token: 0x170051DE RID: 20958
		' (get) Token: 0x0600D0CD RID: 53453 RVA: 0x0005CE1C File Offset: 0x0005B01C
		' (set) Token: 0x0600D0CE RID: 53454 RVA: 0x0005CE26 File Offset: 0x0005B026
		Friend Overridable Property Panel8 As Panel

		' Token: 0x170051DF RID: 20959
		' (get) Token: 0x0600D0CF RID: 53455 RVA: 0x0005CE2F File Offset: 0x0005B02F
		' (set) Token: 0x0600D0D0 RID: 53456 RVA: 0x0005CE39 File Offset: 0x0005B039
		Friend Overridable Property LblSenderId As Label

		' Token: 0x170051E0 RID: 20960
		' (get) Token: 0x0600D0D1 RID: 53457 RVA: 0x0005CE42 File Offset: 0x0005B042
		' (set) Token: 0x0600D0D2 RID: 53458 RVA: 0x0005CE4C File Offset: 0x0005B04C
		Friend Overridable Property lblWhatsAppState As Label

		' Token: 0x170051E1 RID: 20961
		' (get) Token: 0x0600D0D3 RID: 53459 RVA: 0x0005CE55 File Offset: 0x0005B055
		' (set) Token: 0x0600D0D4 RID: 53460 RVA: 0x00821FA4 File Offset: 0x008201A4
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

		' Token: 0x170051E2 RID: 20962
		' (get) Token: 0x0600D0D5 RID: 53461 RVA: 0x0005CE5F File Offset: 0x0005B05F
		' (set) Token: 0x0600D0D6 RID: 53462 RVA: 0x0005CE69 File Offset: 0x0005B069
		Friend Overridable Property Panel7 As Panel

		' Token: 0x170051E3 RID: 20963
		' (get) Token: 0x0600D0D7 RID: 53463 RVA: 0x0005CE72 File Offset: 0x0005B072
		' (set) Token: 0x0600D0D8 RID: 53464 RVA: 0x0005CE7C File Offset: 0x0005B07C
		Friend Overridable Property pBoxAuthQR As PictureBox

		' Token: 0x170051E4 RID: 20964
		' (get) Token: 0x0600D0D9 RID: 53465 RVA: 0x0005CE85 File Offset: 0x0005B085
		' (set) Token: 0x0600D0DA RID: 53466 RVA: 0x0005CE8F File Offset: 0x0005B08F
		Friend Overridable Property btnTerminate As Button

		' Token: 0x170051E5 RID: 20965
		' (get) Token: 0x0600D0DB RID: 53467 RVA: 0x0005CE98 File Offset: 0x0005B098
		' (set) Token: 0x0600D0DC RID: 53468 RVA: 0x0005CEA2 File Offset: 0x0005B0A2
		Friend Overridable Property Panel6 As Panel

		' Token: 0x170051E6 RID: 20966
		' (get) Token: 0x0600D0DD RID: 53469 RVA: 0x0005CEAB File Offset: 0x0005B0AB
		' (set) Token: 0x0600D0DE RID: 53470 RVA: 0x0005CEB5 File Offset: 0x0005B0B5
		Friend Overridable Property LinkLabel1 As LinkLabel

		' Token: 0x170051E7 RID: 20967
		' (get) Token: 0x0600D0DF RID: 53471 RVA: 0x0005CEBE File Offset: 0x0005B0BE
		' (set) Token: 0x0600D0E0 RID: 53472 RVA: 0x0005CEC8 File Offset: 0x0005B0C8
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170051E8 RID: 20968
		' (get) Token: 0x0600D0E1 RID: 53473 RVA: 0x0005CED1 File Offset: 0x0005B0D1
		' (set) Token: 0x0600D0E2 RID: 53474 RVA: 0x0005CEDB File Offset: 0x0005B0DB
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170051E9 RID: 20969
		' (get) Token: 0x0600D0E3 RID: 53475 RVA: 0x0005CEE4 File Offset: 0x0005B0E4
		' (set) Token: 0x0600D0E4 RID: 53476 RVA: 0x00821FE8 File Offset: 0x008201E8
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click_1
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

		' Token: 0x170051EA RID: 20970
		' (get) Token: 0x0600D0E5 RID: 53477 RVA: 0x0005CEEE File Offset: 0x0005B0EE
		' (set) Token: 0x0600D0E6 RID: 53478 RVA: 0x0082202C File Offset: 0x0082022C
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click_1
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

		' Token: 0x170051EB RID: 20971
		' (get) Token: 0x0600D0E7 RID: 53479 RVA: 0x0005CEF8 File Offset: 0x0005B0F8
		' (set) Token: 0x0600D0E8 RID: 53480 RVA: 0x00822070 File Offset: 0x00820270
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click_1
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

		' Token: 0x170051EC RID: 20972
		' (get) Token: 0x0600D0E9 RID: 53481 RVA: 0x0005CF02 File Offset: 0x0005B102
		' (set) Token: 0x0600D0EA RID: 53482 RVA: 0x008220B4 File Offset: 0x008202B4
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

		' Token: 0x170051ED RID: 20973
		' (get) Token: 0x0600D0EB RID: 53483 RVA: 0x0005CF0C File Offset: 0x0005B10C
		' (set) Token: 0x0600D0EC RID: 53484 RVA: 0x008220F8 File Offset: 0x008202F8
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick_1
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint_1
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170051EE RID: 20974
		' (get) Token: 0x0600D0ED RID: 53485 RVA: 0x0005CF16 File Offset: 0x0005B116
		' (set) Token: 0x0600D0EE RID: 53486 RVA: 0x0005CF20 File Offset: 0x0005B120
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170051EF RID: 20975
		' (get) Token: 0x0600D0EF RID: 53487 RVA: 0x0005CF29 File Offset: 0x0005B129
		' (set) Token: 0x0600D0F0 RID: 53488 RVA: 0x0005CF33 File Offset: 0x0005B133
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170051F0 RID: 20976
		' (get) Token: 0x0600D0F1 RID: 53489 RVA: 0x0005CF3C File Offset: 0x0005B13C
		' (set) Token: 0x0600D0F2 RID: 53490 RVA: 0x0005CF46 File Offset: 0x0005B146
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170051F1 RID: 20977
		' (get) Token: 0x0600D0F3 RID: 53491 RVA: 0x0005CF4F File Offset: 0x0005B14F
		' (set) Token: 0x0600D0F4 RID: 53492 RVA: 0x0005CF59 File Offset: 0x0005B159
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170051F2 RID: 20978
		' (get) Token: 0x0600D0F5 RID: 53493 RVA: 0x0005CF62 File Offset: 0x0005B162
		' (set) Token: 0x0600D0F6 RID: 53494 RVA: 0x0005CF6C File Offset: 0x0005B16C
		Friend Overridable Property ImageList1 As ImageList

		' Token: 0x0600D0F7 RID: 53495 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x0600D0F8 RID: 53496 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
		End Sub

		' Token: 0x0600D0F9 RID: 53497 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TV(sender As Object, e As CancelEventArgs)
		End Sub

		' Token: 0x0600D0FA RID: 53498 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x0600D0FB RID: 53499 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnInitialize_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600D0FC RID: 53500 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnLogout_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600D0FD RID: 53501 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnTerminate_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600D0FE RID: 53502 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
		End Sub

		' Token: 0x0600D0FF RID: 53503 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button2_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600D100 RID: 53504 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button3_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600D101 RID: 53505 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button4_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600D102 RID: 53506 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button5_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600D103 RID: 53507 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
		End Sub

		' Token: 0x0600D104 RID: 53508 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
		End Sub

		' Token: 0x0600D105 RID: 53509 RVA: 0x00822158 File Offset: 0x00820358
		Private Function Result_new(success As Boolean, result As String, message As String, instance_id As String) As Dictionary(Of String, Object)
			Dim dictionary As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
			dictionary("success") = success
			dictionary("result") = result
			dictionary("message") = message
			dictionary("instance_id") = instance_id
			Return dictionary
		End Function

		' Token: 0x0600D106 RID: 53510 RVA: 0x008221AC File Offset: 0x008203AC
		Private Sub Clear()
			Me.TextBox1.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.txtWApi.Text = ""
			Me.txtFtpUrl.Text = ""
			Me.txtUserId.Text = ""
			Me.txtPassword.Text = ""
			Me.txtFileUrl.Text = ""
			Me.txtMsgApi.Text = ""
			Me.GetData()
			Me.TextBox1.Focus()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600D107 RID: 53511 RVA: 0x00822278 File Offset: 0x00820478
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT ID,RTRIM(c1),RTRIM(c2),WApi,FtpUrl,FtpUser,FtpPassword,FileUrl,ApiMsg from WappApi ORDER BY ID", ModCommonClasses.con)
				ModCommonClasses.rdr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D108 RID: 53512 RVA: 0x0005CF75 File Offset: 0x0005B175
		Private Sub frmAutobackup_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600D109 RID: 53513 RVA: 0x008223D8 File Offset: 0x008205D8
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

		' Token: 0x0600D10A RID: 53514 RVA: 0x00822550 File Offset: 0x00820750
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

		' Token: 0x0600D10B RID: 53515 RVA: 0x0082260C File Offset: 0x0082080C
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

		' Token: 0x0600D10C RID: 53516 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600D10D RID: 53517 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600D10E RID: 53518 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600D10F RID: 53519 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmWAppAPIServer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600D110 RID: 53520 RVA: 0x008226D8 File Offset: 0x008208D8
		Public Sub Initialization()
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Try
					frmWAppAPIServer.whatsApp.Initialize(New Config() With { .HideCommandPromptWindow = True, .Headless = Me.chkBoxHeadLess.Checked })
				Catch ex As Exception
				End Try
			Else
				MessageBox.Show("Internet Connection Failed", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600D111 RID: 53521 RVA: 0x0005CF86 File Offset: 0x0005B186
		Public Sub LoadProfile()
			frmWAppAPIServer.whatsApp = New WhatsApp()
		End Sub

		' Token: 0x0600D112 RID: 53522 RVA: 0x00822754 File Offset: 0x00820954
		Public Sub wappnodisplay()
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
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D113 RID: 53523 RVA: 0x00822824 File Offset: 0x00820A24
		Private Function GetQRCode(endpoint As String, instanceID As String) As Dictionary(Of String, Object)
			Dim dictionary As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
			Try
				dictionary = Me._ApiRequestor.GetMEthods(endpoint)
				Dim flag As Boolean = Conversions.ToBoolean(dictionary("success"))
				If Not flag Then
					Throw New Exception(Conversions.ToString(dictionary("message")))
				End If
				Dim modelqrcode As frmWAppAPIServer.modelqrcode = JsonConvert.DeserializeObject(Of frmWAppAPIServer.modelqrcode)(Conversions.ToString(dictionary("result")))
				Dim flag2 As Boolean = Not modelqrcode.Status.Equals("success")
				If flag2 Then
					Throw New Exception(Conversions.ToString(dictionary("message")))
				End If
				Dim text As String = "set_webhook?webhook_url=https://webhook.site/6474866802b9e&enable=true&instance_id=" + instanceID + "&access_token=6474866802b9e"
				Dim dictionary2 As Dictionary(Of String, Object) = Me.SetWebhook(text)
				Dim flag3 As Boolean = Not Conversions.ToBoolean(dictionary2("success"))
				If flag3 Then
					Throw New Exception(Conversions.ToString(dictionary2("message")))
				End If
				dictionary = Me.Result_new(True, modelqrcode.base64, modelqrcode.Message, "")
			Catch ex As Exception
				dictionary = Me.Result_new(False, "", "Exeception Occured [GetQRCode] " + ex.Message, "")
			End Try
			Return dictionary
		End Function

		' Token: 0x0600D114 RID: 53524 RVA: 0x00822970 File Offset: 0x00820B70
		Private Function SetWebhook(endpoint As String) As Dictionary(Of String, Object)
			Dim dictionary As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
			Try
				dictionary = Me._ApiRequestor.GetMEthods(endpoint)
				Dim flag As Boolean = Conversions.ToBoolean(dictionary("success"))
				If Not flag Then
					Throw New Exception(Conversions.ToString(dictionary("message")))
				End If
				Dim modelwebhook As frmWAppAPIServer.modelwebhook = JsonConvert.DeserializeObject(Of frmWAppAPIServer.modelwebhook)(Conversions.ToString(dictionary("result")))
				Dim flag2 As Boolean = Not modelwebhook.Status.Equals("success")
				If flag2 Then
					Throw New Exception(Conversions.ToString(dictionary("message")))
				End If
				dictionary = Me.Result_new(True, modelwebhook.Message, "", "")
			Catch ex As Exception
				dictionary = Me.Result_new(False, "", "Exeception Occured [SetWebhook] " + ex.Message, "")
			End Try
			Return dictionary
		End Function

		' Token: 0x0600D115 RID: 53525 RVA: 0x00822A6C File Offset: 0x00820C6C
		Public Function CreateInstanceID(endpoint As String) As Dictionary(Of String, Object)
			Dim text As String = endpoint.Replace("createinstance.php", "create_instance")
			text = text.Split(New Char() { "="c }).First()
			text += "=6474866802b9e"
			Me._ApiRequestor = New ApiRequestor()
			Dim dictionary As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
			Try
				dictionary = Me._ApiRequestor.GetMEthods(text)
				Dim flag As Boolean = Conversions.ToBoolean(dictionary("success"))
				If Not flag Then
					Throw New Exception(Conversions.ToString(dictionary("message")))
				End If
				Dim modelinstance As frmWAppAPIServer.modelinstance = JsonConvert.DeserializeObject(Of frmWAppAPIServer.modelinstance)(Conversions.ToString(dictionary("result")))
				Dim flag2 As Boolean = Not modelinstance.Status.Equals("success")
				If flag2 Then
					Throw New Exception(Conversions.ToString(dictionary("message")))
				End If
				Dim text2 As String = "get_qrcode?instance_id=" + modelinstance.instance_id + "&access_token=6474866802b9e"
				Dim qrcode As Dictionary(Of String, Object) = Me.GetQRCode(text2, modelinstance.instance_id)
				Dim flag3 As Boolean = Not Conversions.ToBoolean(qrcode("success"))
				If flag3 Then
					Throw New Exception(Conversions.ToString(qrcode("message")))
				End If
				qrcode("instance_id") = modelinstance.instance_id
				dictionary = Me.Result_new(True, Conversions.ToString(qrcode("result")), Conversions.ToString(qrcode("message")), Conversions.ToString(qrcode("instance_id")))
			Catch ex As Exception
			End Try
			Return dictionary
		End Function

		' Token: 0x0600D116 RID: 53526 RVA: 0x00822C28 File Offset: 0x00820E28
		Private Function ConfigureWhatsapp() As Object
			Try
				Dim text As String = "createinstance.php?access_token=7fdbba772f1a8911e42d4d4c321132c1"
				Dim clsWhatsapp As DevNetWP.Classes.clsWhatsapp = New DevNetWP.Classes.clsWhatsapp()
				Dim dictionary As Dictionary(Of String, Object) = clsWhatsapp.CreateInstanceID(text)
				Me.CreateInstanceFile(dictionary("instance_id").ToString())
				frmLogin.InstanceID = dictionary("instance_id").ToString()
				Dim text2 As String = dictionary("result").ToString()
				Dim image As Image = Me.Base64ToImage(text2.Trim())
				Me.imgBarcode.Image = image
			Catch ex As Exception
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600D117 RID: 53527 RVA: 0x00822CCC File Offset: 0x00820ECC
		Private Sub CreateInstanceFile(x As String)
			Dim text As String = Application.StartupPath + "\instanceID.txt"
			Dim flag As Boolean = Not File.Exists(text)
			If flag Then
				File.Create(text).Dispose()
			Else
				File.Delete(text)
				File.Create(text).Dispose()
			End If
			Dim streamWriter As StreamWriter = New StreamWriter(text, True)
			streamWriter.WriteLine(x)
			streamWriter.Close()
		End Sub

		' Token: 0x0600D118 RID: 53528 RVA: 0x0005CF93 File Offset: 0x0005B193
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Me.ConfigureWhatsapp()
		End Sub

		' Token: 0x0600D119 RID: 53529 RVA: 0x00822D34 File Offset: 0x00820F34
		Private Function CreateInstanceID() As String
			Dim text As String = ""
			Dim text2 As String = "https://web.raintechherbals.com/api/createinstance.php?access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Try
				Dim text3 As String = ApiRequestor.RequestGetMethods(text2)
				Dim flag As Boolean = text3.Equals("-1")
				If flag Then
					text = "Exeception Occured [CreateInstanceID]: RequestGetMethods"
				Else
					Dim instaceIDModel As instaceIDModel = JsonConvert.DeserializeObject(Of instaceIDModel)(text3)
					Dim flag2 As Boolean = instaceIDModel.Status.Equals("success")
					If flag2 Then
						Me.CreateInstanceFile(instaceIDModel.InstanceId)
						text = Me.GetQRCode(instaceIDModel.InstanceId)
						frmLogin.InstanceID = instaceIDModel.InstanceId
					Else
						text = instaceIDModel.Message
					End If
				End If
			Catch ex As Exception
				text = "Exeception Occured [CreateInstanceID]: " + ex.Message
			End Try
			Return text
		End Function

		' Token: 0x0600D11A RID: 53530 RVA: 0x00822E00 File Offset: 0x00821000
		Private Function GetQRCode(id As String) As String
			Dim text As String = ""
			Dim text2 As String = "https://web.raintechherbals.com/api/getqrcode.php?instance_id=" + id + "&access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Try
				Dim text3 As String = ApiRequestor.RequestGetMethods(text2)
				Dim flag As Boolean = text3.Equals("-1")
				If flag Then
					text = "Exeception Occured [GetQRCode]: RequestGetMethods"
				Else
					Dim qrcodeModel As QRCodeModel = JsonConvert.DeserializeObject(Of QRCodeModel)(text3)
				End If
			Catch ex As Exception
				text = "Exeception Occured [GetQRCode]: " + ex.Message
			End Try
			Return text
		End Function

		' Token: 0x0600D11B RID: 53531 RVA: 0x00822E8C File Offset: 0x0082108C
		Public Function Base64ToImage(base64string As String) As Image
			Dim image As Image
			Try
				Dim memoryStream As MemoryStream = New MemoryStream()
				Dim text As String = base64string.Replace(" ", "+").Split(New Char() { ","c }).Last()
				Dim array As Byte() = Convert.FromBase64String(text)
				memoryStream = New MemoryStream(array)
				image = Image.FromStream(memoryStream)
			Catch ex As Exception
			End Try
			Return image
		End Function

		' Token: 0x0600D11C RID: 53532 RVA: 0x00822F08 File Offset: 0x00821108
		Private Function RebootInstance(id As String) As String
			Dim text As String = ""
			Dim text2 As String = "https://web.raintechherbals.com/api/reboot.php?instance_id=" + id + "&access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Try
				Dim text3 As String = ApiRequestor.RequestGetMethods(text2)
				Dim flag As Boolean = text3.Equals("-1")
				If flag Then
					text = "Exeception Occured [RebootInstance]: RequestGetMethods"
				Else
					Dim instaceIDModel As instaceIDModel = JsonConvert.DeserializeObject(Of instaceIDModel)(text3)
					Dim flag2 As Boolean = Operators.CompareString(instaceIDModel.Status, "success", False) = 0
					If flag2 Then
						Throw New Exception(instaceIDModel.Message)
					End If
					text = instaceIDModel.Message
				End If
			Catch ex As Exception
				text = "Exeception Occured [RebootInstance]: " + ex.Message
			End Try
			Return text
		End Function

		' Token: 0x0600D11D RID: 53533 RVA: 0x00822FC8 File Offset: 0x008211C8
		Private Function ResetInstance(id As String) As String
			Dim text As String = ""
			Dim text2 As String = "https://web.raintechherbals.com/api/resetinstance.php?instance_id=" + id + "&access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Try
				Dim text3 As String = ApiRequestor.RequestGetMethods(text2)
				Dim flag As Boolean = text3.Equals("-1")
				If flag Then
					text = "Exeception Occured [ResetInstance]: RequestGetMethods"
				Else
					Dim instaceIDModel As instaceIDModel = JsonConvert.DeserializeObject(Of instaceIDModel)(text3)
					Dim flag2 As Boolean = instaceIDModel.Status.Equals("success")
					If Not flag2 Then
						text = instaceIDModel.Message
					End If
				End If
			Catch ex As Exception
				text = "Exeception Occured [RebootInstance]: " + ex.Message
			End Try
			Return text
		End Function

		' Token: 0x0600D11E RID: 53534 RVA: 0x00823078 File Offset: 0x00821278
		Private Function Reconnect(id As String) As String
			Dim text As String = ""
			Dim text2 As String = "https://web.raintechherbals.com/api/reconnect.php?instance_id=" + id + "&access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Try
				Dim text3 As String = ApiRequestor.RequestGetMethods(text2)
				Dim flag As Boolean = text3.Equals("-1")
				If flag Then
					text = "Exeception Occured [Reconnect]: RequestGetMethods"
				Else
					Dim instaceIDModel As instaceIDModel = JsonConvert.DeserializeObject(Of instaceIDModel)(text3)
					Dim flag2 As Boolean = instaceIDModel.Status.Equals("success")
					If Not flag2 Then
						text = instaceIDModel.Message
					End If
				End If
			Catch ex As Exception
				text = "Exeception Occured [RebootInstance]: " + ex.Message
			End Try
			Return text
		End Function

		' Token: 0x0600D11F RID: 53535 RVA: 0x00823078 File Offset: 0x00821278
		Private Function SendMessage(id As String) As String
			Dim text As String = ""
			Dim text2 As String = "https://web.raintechherbals.com/api/reconnect.php?instance_id=" + id + "&access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Try
				Dim text3 As String = ApiRequestor.RequestGetMethods(text2)
				Dim flag As Boolean = text3.Equals("-1")
				If flag Then
					text = "Exeception Occured [Reconnect]: RequestGetMethods"
				Else
					Dim instaceIDModel As instaceIDModel = JsonConvert.DeserializeObject(Of instaceIDModel)(text3)
					Dim flag2 As Boolean = instaceIDModel.Status.Equals("success")
					If Not flag2 Then
						text = instaceIDModel.Message
					End If
				End If
			Catch ex As Exception
				text = "Exeception Occured [RebootInstance]: " + ex.Message
			End Try
			Return text
		End Function

		' Token: 0x0600D120 RID: 53536 RVA: 0x00823128 File Offset: 0x00821328
		Private Sub btnRebootInstance_Click(sender As Object, e As EventArgs)
			Dim text As String = "reboot.php?instance_id=" + frmLogin.InstanceID + "&access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Dim clsWhatsapp As DevNetWP.Classes.clsWhatsapp = New DevNetWP.Classes.clsWhatsapp()
			Dim dictionary As Dictionary(Of String, Object) = clsWhatsapp.RebootInstance(text)
			Dim flag As Boolean = Conversions.ToBoolean(dictionary("success"))
			Dim text2 As String
			If flag Then
				text2 = dictionary("result").ToString()
			Else
				text2 = dictionary("message").ToString()
			End If
			MessageBox.Show(text2)
		End Sub

		' Token: 0x0600D121 RID: 53537 RVA: 0x008231A4 File Offset: 0x008213A4
		Private Sub btnResetInstance_Click(sender As Object, e As EventArgs)
			Dim text As String = "resetinstance.php?instance_id=" + frmLogin.InstanceID + "&access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Dim clsWhatsapp As DevNetWP.Classes.clsWhatsapp = New DevNetWP.Classes.clsWhatsapp()
			Dim dictionary As Dictionary(Of String, Object) = clsWhatsapp.ResetInstance(text)
			Dim flag As Boolean = Conversions.ToBoolean(dictionary("success"))
			Dim text2 As String
			If flag Then
				text2 = dictionary("result").ToString()
			Else
				text2 = dictionary("message").ToString()
			End If
			MessageBox.Show(text2)
		End Sub

		' Token: 0x0600D122 RID: 53538 RVA: 0x00823220 File Offset: 0x00821420
		Private Sub btnReconnect_Click(sender As Object, e As EventArgs)
			Dim text As String = "reconnect.php?instance_id=" + frmLogin.InstanceID + "&access_token=7fdbba772f1a8911e42d4d4c321132c1"
			Dim clsWhatsapp As DevNetWP.Classes.clsWhatsapp = New DevNetWP.Classes.clsWhatsapp()
			Dim dictionary As Dictionary(Of String, Object) = clsWhatsapp.Reconnect(text)
			Dim flag As Boolean = Conversions.ToBoolean(dictionary("success"))
			Dim text2 As String
			If flag Then
				text2 = dictionary("result").ToString()
			Else
				text2 = dictionary("message").ToString()
			End If
			MessageBox.Show(text2)
		End Sub

		' Token: 0x0600D123 RID: 53539 RVA: 0x0082329C File Offset: 0x0082149C
		Private Sub Button3_Click_1(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					MessageBox.Show("Add Company Information first in master entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					flag = ModCommonClasses.rdr IsNot Nothing
					Dim flag3 As Boolean = flag
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Me.Clear()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please fill Country Code of WhatsApp No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox1.Focus()
					Else
						Dim flag5 As Boolean = (Operators.CompareString(Me.ComboBox1.Text, "", False) = 0) Or (Me.ComboBox1.SelectedIndex = -1)
						If flag5 Then
							MessageBox.Show("Please fill WhatsApp API Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.ComboBox1.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.txtWApi.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please enter WhatsApp Api", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtWApi.Focus()
							Else
								Dim flag7 As Boolean = Operators.CompareString(Me.txtFtpUrl.Text, "", False) = 0
								If flag7 Then
									MessageBox.Show("Please enter FTP url", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtFtpUrl.Focus()
								Else
									Dim flag8 As Boolean = Operators.CompareString(Me.txtUserId.Text, "", False) = 0
									If flag8 Then
										MessageBox.Show("Please enter FTP user name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtUserId.Focus()
									Else
										Dim flag9 As Boolean = Operators.CompareString(Me.txtPassword.Text, "", False) = 0
										If flag9 Then
											MessageBox.Show("Please enter FTP password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtPassword.Focus()
										Else
											Dim flag10 As Boolean = Operators.CompareString(Me.txtFileUrl.Text, "", False) = 0
											If flag10 Then
												MessageBox.Show("Please enter file url", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtFileUrl.Focus()
											Else
												Dim flag11 As Boolean = Operators.CompareString(Me.txtMsgApi.Text, "", False) = 0
												If flag11 Then
													MessageBox.Show("Please enter Api url", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtMsgApi.Focus()
												Else
													Try
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text2 As String = If(("Update WappApi set c1=@d1, c2=@d2,WApi=@d3,FtpUrl=@d4,FtpUser=@d5,FtpPassword=@d6,FileUrl=@d7,ApiMsg=@d8 where ID=" + Me.TextBox2.Text), "")
														ModCommonClasses.cmd = New SqlCommand(text2)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.TrimEnd(New Char(-1) {}))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtWApi.Text.TrimEnd(New Char(-1) {}))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtFtpUrl.Text.TrimEnd(New Char(-1) {}))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtUserId.Text.TrimEnd(New Char(-1) {}))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtPassword.Text.TrimEnd(New Char(-1) {}))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtFileUrl.Text.TrimEnd(New Char(-1) {}))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtMsgApi.Text.TrimEnd(New Char(-1) {}))
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
														Me.GetData()
														Me.Clear()
														Me.Button4.Enabled = True
														Me.Button3.Enabled = False
														Me.Button2.Enabled = False
													Catch ex As Exception
														MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													End Try
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x0600D124 RID: 53540 RVA: 0x008237DC File Offset: 0x008219DC
		Private Sub Button2_Click_1(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM WappApi WHERE ID = " + Me.TextBox2.Text
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK
				If flag Then
					Dim flag2 As Boolean = sqlCommand.ExecuteNonQuery() > 0
					If flag2 Then
						MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Clear()
					End If
				End If
				Me.GetData()
				Me.Clear()
				ModCommonClasses.con.Close()
				Me.Button4.Enabled = True
				Me.Button3.Enabled = False
				Me.Button3.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D125 RID: 53541 RVA: 0x0005CF9D File Offset: 0x0005B19D
		Private Sub Button5_Click_1(sender As Object, e As EventArgs)
			Me.Clear()
			Me.Button4.Enabled = True
			Me.Button3.Enabled = False
			Me.Button2.Enabled = False
		End Sub

		' Token: 0x0600D126 RID: 53542 RVA: 0x008238E0 File Offset: 0x00821AE0
		Private Sub Button4_Click_1(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					ModCommonClasses.con.Close()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please fill Country Code of WhatsApp No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.TextBox1.Focus()
					Else
						Dim flag4 As Boolean = (Operators.CompareString(Me.ComboBox1.Text, "", False) = 0) Or (Me.ComboBox1.SelectedIndex = -1)
						If flag4 Then
							MessageBox.Show("Please fill WhatsApp API Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.ComboBox1.Focus()
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtWApi.Text, "", False) = 0
							If flag5 Then
								MessageBox.Show("Please enter WhatsApp Api", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtWApi.Focus()
							Else
								Dim flag6 As Boolean = Operators.CompareString(Me.txtFtpUrl.Text, "", False) = 0
								If flag6 Then
									MessageBox.Show("Please enter FTP url", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtFtpUrl.Focus()
								Else
									Dim flag7 As Boolean = Operators.CompareString(Me.txtUserId.Text, "", False) = 0
									If flag7 Then
										MessageBox.Show("Please enter FTP user name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtUserId.Focus()
									Else
										Dim flag8 As Boolean = Operators.CompareString(Me.txtPassword.Text, "", False) = 0
										If flag8 Then
											MessageBox.Show("Please enter FTP password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtPassword.Focus()
										Else
											Dim flag9 As Boolean = Operators.CompareString(Me.txtFileUrl.Text, "", False) = 0
											If flag9 Then
												MessageBox.Show("Please enter file url", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtFileUrl.Focus()
											Else
												Dim flag10 As Boolean = Operators.CompareString(Me.txtMsgApi.Text, "", False) = 0
												If flag10 Then
													MessageBox.Show("Please enter Api url", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtMsgApi.Focus()
												Else
													Try
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text2 As String = "Select count(*) from WappApi Having count(*) >= 1"
														ModCommonClasses.cmd = New SqlCommand(text2)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
														If flag11 Then
															MessageBox.Show("Record Already Exists" & vbCrLf & "Please update the information only", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
															Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
															If flag12 Then
																ModCommonClasses.rdr.Close()
															End If
														Else
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text3 As String = "insert into WappApi(c1,c2,WApi,FtpUrl,FtpUser,FtpPassword,FileUrl,ApiMsg) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
															ModCommonClasses.cmd = New SqlCommand(text3)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text.TrimEnd(New Char(-1) {}))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtWApi.Text.TrimEnd(New Char(-1) {}))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtFtpUrl.Text.TrimEnd(New Char(-1) {}))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtUserId.Text.TrimEnd(New Char(-1) {}))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtPassword.Text.TrimEnd(New Char(-1) {}))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtFileUrl.Text.TrimEnd(New Char(-1) {}))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtMsgApi.Text.TrimEnd(New Char(-1) {}))
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.ExecuteReader()
															ModCommonClasses.con.Close()
															MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
															Me.Button4.Enabled = True
															Me.Button3.Enabled = False
															Me.Button2.Enabled = False
															Me.GetData()
															Me.Clear()
														End If
													Catch ex As Exception
														MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													End Try
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Finally
			End Try
		End Sub

		' Token: 0x0600D127 RID: 53543 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown_1(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600D128 RID: 53544 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown_1(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600D129 RID: 53545 RVA: 0x00823E94 File Offset: 0x00822094
		Private Sub dgw_MouseClick_1(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
					Me.Button4.Enabled = False
					Me.Button3.Enabled = True
					Me.Button2.Enabled = True
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.TextBox2.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.TextBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.ComboBox1.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.txtWApi.Text = dataGridViewRow.Cells(3).Value.ToString()
				Me.txtFtpUrl.Text = dataGridViewRow.Cells(4).Value.ToString()
				Me.txtUserId.Text = dataGridViewRow.Cells(5).Value.ToString()
				Me.txtPassword.Text = dataGridViewRow.Cells(6).Value.ToString()
				Me.txtFileUrl.Text = dataGridViewRow.Cells(7).Value.ToString()
				Me.txtMsgApi.Text = dataGridViewRow.Cells(8).Value.ToString()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600D12A RID: 53546 RVA: 0x00824058 File Offset: 0x00822258
		Private Sub dgw_RowPostPaint_1(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600D12B RID: 53547 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub TextBox1_KeyPress_1(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x040053DB RID: 21467
		Public Shared whatsApp As WhatsApp

		' Token: 0x040053DC RID: 21468
		Private _ENGINE_STATE As State

		' Token: 0x040053DD RID: 21469
		Private _AUTH_QR As Image

		' Token: 0x040053DE RID: 21470
		Private sts2 As String

		' Token: 0x040053DF RID: 21471
		Private _ApiRequestor As ApiRequestor

		' Token: 0x02000374 RID: 884
		Friend Class modelwebhook
			' Token: 0x170051F3 RID: 20979
			' (get) Token: 0x0600D12D RID: 53549 RVA: 0x0005CFCE File Offset: 0x0005B1CE
			' (set) Token: 0x0600D12E RID: 53550 RVA: 0x0005CFD8 File Offset: 0x0005B1D8
			Public Property Status As String

			' Token: 0x170051F4 RID: 20980
			' (get) Token: 0x0600D12F RID: 53551 RVA: 0x0005CFE1 File Offset: 0x0005B1E1
			' (set) Token: 0x0600D130 RID: 53552 RVA: 0x0005CFEB File Offset: 0x0005B1EB
			Public Property Message As String
		End Class

		' Token: 0x02000375 RID: 885
		Friend Class modelinstance
			' Token: 0x170051F5 RID: 20981
			' (get) Token: 0x0600D132 RID: 53554 RVA: 0x0005CFF4 File Offset: 0x0005B1F4
			' (set) Token: 0x0600D133 RID: 53555 RVA: 0x0005CFFE File Offset: 0x0005B1FE
			Public Property Status As String

			' Token: 0x170051F6 RID: 20982
			' (get) Token: 0x0600D134 RID: 53556 RVA: 0x0005D007 File Offset: 0x0005B207
			' (set) Token: 0x0600D135 RID: 53557 RVA: 0x0005D011 File Offset: 0x0005B211
			Public Property Message As String

			' Token: 0x170051F7 RID: 20983
			' (get) Token: 0x0600D136 RID: 53558 RVA: 0x0005D01A File Offset: 0x0005B21A
			' (set) Token: 0x0600D137 RID: 53559 RVA: 0x0005D024 File Offset: 0x0005B224
			Public Property instance_id As String
		End Class

		' Token: 0x02000376 RID: 886
		Friend Class modelqrcode
			' Token: 0x170051F8 RID: 20984
			' (get) Token: 0x0600D139 RID: 53561 RVA: 0x0005D02D File Offset: 0x0005B22D
			' (set) Token: 0x0600D13A RID: 53562 RVA: 0x0005D037 File Offset: 0x0005B237
			Public Property Status As String

			' Token: 0x170051F9 RID: 20985
			' (get) Token: 0x0600D13B RID: 53563 RVA: 0x0005D040 File Offset: 0x0005B240
			' (set) Token: 0x0600D13C RID: 53564 RVA: 0x0005D04A File Offset: 0x0005B24A
			Public Property Message As String

			' Token: 0x170051FA RID: 20986
			' (get) Token: 0x0600D13D RID: 53565 RVA: 0x0005D053 File Offset: 0x0005B253
			' (set) Token: 0x0600D13E RID: 53566 RVA: 0x0005D05D File Offset: 0x0005B25D
			Public Property base64 As String
		End Class
	End Class
End Namespace
