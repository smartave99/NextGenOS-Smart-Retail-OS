Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200056E RID: 1390
	<DesignerGenerated()>
	Public Partial Class frmSalesInvoiceRecord_GSTR
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010ED4 RID: 69332 RVA: 0x0007498D File Offset: 0x00072B8D
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170068F6 RID: 26870
		' (get) Token: 0x06010ED7 RID: 69335 RVA: 0x000749BF File Offset: 0x00072BBF
		' (set) Token: 0x06010ED8 RID: 69336 RVA: 0x000749C9 File Offset: 0x00072BC9
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170068F7 RID: 26871
		' (get) Token: 0x06010ED9 RID: 69337 RVA: 0x000749D2 File Offset: 0x00072BD2
		' (set) Token: 0x06010EDA RID: 69338 RVA: 0x009D9840 File Offset: 0x009D7A40
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170068F8 RID: 26872
		' (get) Token: 0x06010EDB RID: 69339 RVA: 0x000749DC File Offset: 0x00072BDC
		' (set) Token: 0x06010EDC RID: 69340 RVA: 0x000749E6 File Offset: 0x00072BE6
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170068F9 RID: 26873
		' (get) Token: 0x06010EDD RID: 69341 RVA: 0x000749EF File Offset: 0x00072BEF
		' (set) Token: 0x06010EDE RID: 69342 RVA: 0x000749F9 File Offset: 0x00072BF9
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170068FA RID: 26874
		' (get) Token: 0x06010EDF RID: 69343 RVA: 0x00074A02 File Offset: 0x00072C02
		' (set) Token: 0x06010EE0 RID: 69344 RVA: 0x00074A0C File Offset: 0x00072C0C
		Friend Overridable Property Label2 As Label

		' Token: 0x170068FB RID: 26875
		' (get) Token: 0x06010EE1 RID: 69345 RVA: 0x00074A15 File Offset: 0x00072C15
		' (set) Token: 0x06010EE2 RID: 69346 RVA: 0x00074A1F File Offset: 0x00072C1F
		Friend Overridable Property Label4 As Label

		' Token: 0x170068FC RID: 26876
		' (get) Token: 0x06010EE3 RID: 69347 RVA: 0x00074A28 File Offset: 0x00072C28
		' (set) Token: 0x06010EE4 RID: 69348 RVA: 0x00074A32 File Offset: 0x00072C32
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170068FD RID: 26877
		' (get) Token: 0x06010EE5 RID: 69349 RVA: 0x00074A3B File Offset: 0x00072C3B
		' (set) Token: 0x06010EE6 RID: 69350 RVA: 0x00074A45 File Offset: 0x00072C45
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170068FE RID: 26878
		' (get) Token: 0x06010EE7 RID: 69351 RVA: 0x00074A4E File Offset: 0x00072C4E
		' (set) Token: 0x06010EE8 RID: 69352 RVA: 0x00074A58 File Offset: 0x00072C58
		Friend Overridable Property Label1 As Label

		' Token: 0x170068FF RID: 26879
		' (get) Token: 0x06010EE9 RID: 69353 RVA: 0x00074A61 File Offset: 0x00072C61
		' (set) Token: 0x06010EEA RID: 69354 RVA: 0x00074A6B File Offset: 0x00072C6B
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006900 RID: 26880
		' (get) Token: 0x06010EEB RID: 69355 RVA: 0x00074A74 File Offset: 0x00072C74
		' (set) Token: 0x06010EEC RID: 69356 RVA: 0x00074A7E File Offset: 0x00072C7E
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006901 RID: 26881
		' (get) Token: 0x06010EED RID: 69357 RVA: 0x00074A87 File Offset: 0x00072C87
		' (set) Token: 0x06010EEE RID: 69358 RVA: 0x00074A91 File Offset: 0x00072C91
		Friend Overridable Property Label3 As Label

		' Token: 0x17006902 RID: 26882
		' (get) Token: 0x06010EEF RID: 69359 RVA: 0x00074A9A File Offset: 0x00072C9A
		' (set) Token: 0x06010EF0 RID: 69360 RVA: 0x009D98A0 File Offset: 0x009D7AA0
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

		' Token: 0x17006903 RID: 26883
		' (get) Token: 0x06010EF1 RID: 69361 RVA: 0x00074AA4 File Offset: 0x00072CA4
		' (set) Token: 0x06010EF2 RID: 69362 RVA: 0x009D98E4 File Offset: 0x009D7AE4
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

		' Token: 0x17006904 RID: 26884
		' (get) Token: 0x06010EF3 RID: 69363 RVA: 0x00074AAE File Offset: 0x00072CAE
		' (set) Token: 0x06010EF4 RID: 69364 RVA: 0x009D9928 File Offset: 0x009D7B28
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

		' Token: 0x17006905 RID: 26885
		' (get) Token: 0x06010EF5 RID: 69365 RVA: 0x00074AB8 File Offset: 0x00072CB8
		' (set) Token: 0x06010EF6 RID: 69366 RVA: 0x00074AC2 File Offset: 0x00072CC2
		Friend Overridable Property Label6 As Label

		' Token: 0x17006906 RID: 26886
		' (get) Token: 0x06010EF7 RID: 69367 RVA: 0x00074ACB File Offset: 0x00072CCB
		' (set) Token: 0x06010EF8 RID: 69368 RVA: 0x00074AD5 File Offset: 0x00072CD5
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17006907 RID: 26887
		' (get) Token: 0x06010EF9 RID: 69369 RVA: 0x00074ADE File Offset: 0x00072CDE
		' (set) Token: 0x06010EFA RID: 69370 RVA: 0x00074AE8 File Offset: 0x00072CE8
		Friend Overridable Property Label8 As Label

		' Token: 0x17006908 RID: 26888
		' (get) Token: 0x06010EFB RID: 69371 RVA: 0x00074AF1 File Offset: 0x00072CF1
		' (set) Token: 0x06010EFC RID: 69372 RVA: 0x009D996C File Offset: 0x009D7B6C
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006909 RID: 26889
		' (get) Token: 0x06010EFD RID: 69373 RVA: 0x00074AFB File Offset: 0x00072CFB
		' (set) Token: 0x06010EFE RID: 69374 RVA: 0x00074B05 File Offset: 0x00072D05
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700690A RID: 26890
		' (get) Token: 0x06010EFF RID: 69375 RVA: 0x00074B0E File Offset: 0x00072D0E
		' (set) Token: 0x06010F00 RID: 69376 RVA: 0x00074B18 File Offset: 0x00072D18
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700690B RID: 26891
		' (get) Token: 0x06010F01 RID: 69377 RVA: 0x00074B21 File Offset: 0x00072D21
		' (set) Token: 0x06010F02 RID: 69378 RVA: 0x00074B2B File Offset: 0x00072D2B
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700690C RID: 26892
		' (get) Token: 0x06010F03 RID: 69379 RVA: 0x00074B34 File Offset: 0x00072D34
		' (set) Token: 0x06010F04 RID: 69380 RVA: 0x00074B3E File Offset: 0x00072D3E
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700690D RID: 26893
		' (get) Token: 0x06010F05 RID: 69381 RVA: 0x00074B47 File Offset: 0x00072D47
		' (set) Token: 0x06010F06 RID: 69382 RVA: 0x00074B51 File Offset: 0x00072D51
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700690E RID: 26894
		' (get) Token: 0x06010F07 RID: 69383 RVA: 0x00074B5A File Offset: 0x00072D5A
		' (set) Token: 0x06010F08 RID: 69384 RVA: 0x00074B64 File Offset: 0x00072D64
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700690F RID: 26895
		' (get) Token: 0x06010F09 RID: 69385 RVA: 0x00074B6D File Offset: 0x00072D6D
		' (set) Token: 0x06010F0A RID: 69386 RVA: 0x00074B77 File Offset: 0x00072D77
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17006910 RID: 26896
		' (get) Token: 0x06010F0B RID: 69387 RVA: 0x00074B80 File Offset: 0x00072D80
		' (set) Token: 0x06010F0C RID: 69388 RVA: 0x00074B8A File Offset: 0x00072D8A
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17006911 RID: 26897
		' (get) Token: 0x06010F0D RID: 69389 RVA: 0x00074B93 File Offset: 0x00072D93
		' (set) Token: 0x06010F0E RID: 69390 RVA: 0x00074B9D File Offset: 0x00072D9D
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17006912 RID: 26898
		' (get) Token: 0x06010F0F RID: 69391 RVA: 0x00074BA6 File Offset: 0x00072DA6
		' (set) Token: 0x06010F10 RID: 69392 RVA: 0x00074BB0 File Offset: 0x00072DB0
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006913 RID: 26899
		' (get) Token: 0x06010F11 RID: 69393 RVA: 0x00074BB9 File Offset: 0x00072DB9
		' (set) Token: 0x06010F12 RID: 69394 RVA: 0x00074BC3 File Offset: 0x00072DC3
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006914 RID: 26900
		' (get) Token: 0x06010F13 RID: 69395 RVA: 0x00074BCC File Offset: 0x00072DCC
		' (set) Token: 0x06010F14 RID: 69396 RVA: 0x00074BD6 File Offset: 0x00072DD6
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006915 RID: 26901
		' (get) Token: 0x06010F15 RID: 69397 RVA: 0x00074BDF File Offset: 0x00072DDF
		' (set) Token: 0x06010F16 RID: 69398 RVA: 0x00074BE9 File Offset: 0x00072DE9
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006916 RID: 26902
		' (get) Token: 0x06010F17 RID: 69399 RVA: 0x00074BF2 File Offset: 0x00072DF2
		' (set) Token: 0x06010F18 RID: 69400 RVA: 0x00074BFC File Offset: 0x00072DFC
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006917 RID: 26903
		' (get) Token: 0x06010F19 RID: 69401 RVA: 0x00074C05 File Offset: 0x00072E05
		' (set) Token: 0x06010F1A RID: 69402 RVA: 0x00074C0F File Offset: 0x00072E0F
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17006918 RID: 26904
		' (get) Token: 0x06010F1B RID: 69403 RVA: 0x00074C18 File Offset: 0x00072E18
		' (set) Token: 0x06010F1C RID: 69404 RVA: 0x00074C22 File Offset: 0x00072E22
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006919 RID: 26905
		' (get) Token: 0x06010F1D RID: 69405 RVA: 0x00074C2B File Offset: 0x00072E2B
		' (set) Token: 0x06010F1E RID: 69406 RVA: 0x00074C35 File Offset: 0x00072E35
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x1700691A RID: 26906
		' (get) Token: 0x06010F1F RID: 69407 RVA: 0x00074C3E File Offset: 0x00072E3E
		' (set) Token: 0x06010F20 RID: 69408 RVA: 0x00074C48 File Offset: 0x00072E48
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700691B RID: 26907
		' (get) Token: 0x06010F21 RID: 69409 RVA: 0x00074C51 File Offset: 0x00072E51
		' (set) Token: 0x06010F22 RID: 69410 RVA: 0x00074C5B File Offset: 0x00072E5B
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700691C RID: 26908
		' (get) Token: 0x06010F23 RID: 69411 RVA: 0x00074C64 File Offset: 0x00072E64
		' (set) Token: 0x06010F24 RID: 69412 RVA: 0x00074C6E File Offset: 0x00072E6E
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x1700691D RID: 26909
		' (get) Token: 0x06010F25 RID: 69413 RVA: 0x00074C77 File Offset: 0x00072E77
		' (set) Token: 0x06010F26 RID: 69414 RVA: 0x00074C81 File Offset: 0x00072E81
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700691E RID: 26910
		' (get) Token: 0x06010F27 RID: 69415 RVA: 0x00074C8A File Offset: 0x00072E8A
		' (set) Token: 0x06010F28 RID: 69416 RVA: 0x00074C94 File Offset: 0x00072E94
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700691F RID: 26911
		' (get) Token: 0x06010F29 RID: 69417 RVA: 0x00074C9D File Offset: 0x00072E9D
		' (set) Token: 0x06010F2A RID: 69418 RVA: 0x00074CA7 File Offset: 0x00072EA7
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006920 RID: 26912
		' (get) Token: 0x06010F2B RID: 69419 RVA: 0x00074CB0 File Offset: 0x00072EB0
		' (set) Token: 0x06010F2C RID: 69420 RVA: 0x00074CBA File Offset: 0x00072EBA
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17006921 RID: 26913
		' (get) Token: 0x06010F2D RID: 69421 RVA: 0x00074CC3 File Offset: 0x00072EC3
		' (set) Token: 0x06010F2E RID: 69422 RVA: 0x00074CCD File Offset: 0x00072ECD
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17006922 RID: 26914
		' (get) Token: 0x06010F2F RID: 69423 RVA: 0x00074CD6 File Offset: 0x00072ED6
		' (set) Token: 0x06010F30 RID: 69424 RVA: 0x00074CE0 File Offset: 0x00072EE0
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17006923 RID: 26915
		' (get) Token: 0x06010F31 RID: 69425 RVA: 0x00074CE9 File Offset: 0x00072EE9
		' (set) Token: 0x06010F32 RID: 69426 RVA: 0x00074CF3 File Offset: 0x00072EF3
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17006924 RID: 26916
		' (get) Token: 0x06010F33 RID: 69427 RVA: 0x00074CFC File Offset: 0x00072EFC
		' (set) Token: 0x06010F34 RID: 69428 RVA: 0x00074D06 File Offset: 0x00072F06
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17006925 RID: 26917
		' (get) Token: 0x06010F35 RID: 69429 RVA: 0x00074D0F File Offset: 0x00072F0F
		' (set) Token: 0x06010F36 RID: 69430 RVA: 0x00074D19 File Offset: 0x00072F19
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17006926 RID: 26918
		' (get) Token: 0x06010F37 RID: 69431 RVA: 0x00074D22 File Offset: 0x00072F22
		' (set) Token: 0x06010F38 RID: 69432 RVA: 0x00074D2C File Offset: 0x00072F2C
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17006927 RID: 26919
		' (get) Token: 0x06010F39 RID: 69433 RVA: 0x00074D35 File Offset: 0x00072F35
		' (set) Token: 0x06010F3A RID: 69434 RVA: 0x00074D3F File Offset: 0x00072F3F
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17006928 RID: 26920
		' (get) Token: 0x06010F3B RID: 69435 RVA: 0x00074D48 File Offset: 0x00072F48
		' (set) Token: 0x06010F3C RID: 69436 RVA: 0x00074D52 File Offset: 0x00072F52
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17006929 RID: 26921
		' (get) Token: 0x06010F3D RID: 69437 RVA: 0x00074D5B File Offset: 0x00072F5B
		' (set) Token: 0x06010F3E RID: 69438 RVA: 0x009D99B0 File Offset: 0x009D7BB0
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

		' Token: 0x1700692A RID: 26922
		' (get) Token: 0x06010F3F RID: 69439 RVA: 0x00074D65 File Offset: 0x00072F65
		' (set) Token: 0x06010F40 RID: 69440 RVA: 0x009D99F4 File Offset: 0x009D7BF4
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700692B RID: 26923
		' (get) Token: 0x06010F41 RID: 69441 RVA: 0x00074D6F File Offset: 0x00072F6F
		' (set) Token: 0x06010F42 RID: 69442 RVA: 0x009D9A38 File Offset: 0x009D7C38
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06010F43 RID: 69443 RVA: 0x009D9A7C File Offset: 0x009D7C7C
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
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

		' Token: 0x06010F44 RID: 69444 RVA: 0x009D9B50 File Offset: 0x009D7D50
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where Invoiceinfo.InvoiceDate between @d1 and @d2 order by Invoiceinfo.InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010F45 RID: 69445 RVA: 0x009D9EA8 File Offset: 0x009D80A8
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010F46 RID: 69446 RVA: 0x009D9F40 File Offset: 0x009D8140
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

		' Token: 0x06010F47 RID: 69447 RVA: 0x009DA0B8 File Offset: 0x009D82B8
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x06010F48 RID: 69448 RVA: 0x009DA184 File Offset: 0x009D8384
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

		' Token: 0x06010F49 RID: 69449 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010F4A RID: 69450 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010F4B RID: 69451 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010F4C RID: 69452 RVA: 0x009DA250 File Offset: 0x009D8450
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
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

		' Token: 0x06010F4D RID: 69453 RVA: 0x00074D79 File Offset: 0x00072F79
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x06010F4E RID: 69454 RVA: 0x009DA338 File Offset: 0x009D8538
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Select the search category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and InvoiceInfo.InvoiceNo=N'" + Me.TextBox1.Text + "' order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Customer.Name=N'" + Me.TextBox1.Text + "' order by InvoiceDate", ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Product.ProductName=N'" + Me.TextBox1.Text + "' order by InvoiceDate", ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Product.ProductCode=N'" + Me.TextBox1.Text + "' order by InvoiceDate", ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
									ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Invoice_Product.Barcode=N'" + Me.TextBox1.Text + "' order by InvoiceDate", ModCommonClasses.con)
										ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
										ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
									Else
										Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 5
										If flag7 Then
											ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Invoice_Product.IM1=N'" + Me.TextBox1.Text + "' order by InvoiceDate", ModCommonClasses.con)
											ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
											ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
										Else
											Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 6
											If flag8 Then
												ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Invoice_Product.IM2=N'" + Me.TextBox1.Text + "' order by InvoiceDate", ModCommonClasses.con)
												ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
												ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
											Else
												Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 7
												If flag9 Then
													ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Invoice_Product.Descr like N'" + Me.TextBox1.Text + "%' order by InvoiceDate", ModCommonClasses.con)
													ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
													ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
												Else
													Dim flag10 As Boolean = Me.ComboBox1.SelectedIndex = 8
													If flag10 Then
														ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Invoice_Product.Batch like N'" + Me.TextBox1.Text + "%' order by InvoiceDate", ModCommonClasses.con)
														ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
														ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
													Else
														Dim flag11 As Boolean = Me.ComboBox1.SelectedIndex = 9
														If flag11 Then
															ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Invoice_Product.Size like N'" + Me.TextBox1.Text + "%' order by InvoiceDate", ModCommonClasses.con)
															ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
															ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
														Else
															Dim flag12 As Boolean = Me.ComboBox1.SelectedIndex = 10
															If flag12 Then
																ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Invoice_Product.Colour like N'" + Me.TextBox1.Text + "%' order by InvoiceDate", ModCommonClasses.con)
																ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
																ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
															End If
														End If
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
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x06010F4F RID: 69455 RVA: 0x00074D9B File Offset: 0x00072F9B
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06010F50 RID: 69456 RVA: 0x00074DD0 File Offset: 0x00072FD0
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.TextBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06010F51 RID: 69457 RVA: 0x009DAE34 File Offset: 0x009D9034
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.cpy = dataGridViewRow.Cells(0).Value.ToString()
				Clipboard.SetDataObject(Me.cpy)
				MessageBox.Show("Invoice Number is Copied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06010F52 RID: 69458 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesInvoiceRecord_GSTR_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010F53 RID: 69459 RVA: 0x009DAEB4 File Offset: 0x009D90B4
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x06010F54 RID: 69460 RVA: 0x009DAFCC File Offset: 0x009D91CC
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.ComboBox1.SelectedIndex = -1
				Me.TextBox1.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox2.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and NOT InvoiceInfo.TaxType=@d3 order by InvoiceDate", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
				Else
					Dim flag2 As Boolean = Me.ComboBox2.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and InvoiceInfo.TaxType=@d3 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06010F55 RID: 69461 RVA: 0x009DB414 File Offset: 0x009D9614
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06010F56 RID: 69462 RVA: 0x009DB464 File Offset: 0x009D9664
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010F57 RID: 69463 RVA: 0x009DB710 File Offset: 0x009D9910
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Me.ComboBox1.SelectedIndex = -1
				Me.TextBox1.Text = ""
				Me.ComboBox2.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0400660D RID: 26125
		Private cpy As String
	End Class
End Namespace
