Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports DevNet
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json.Linq
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020001E5 RID: 485
	<DesignerGenerated()>
	Public Partial Class frmProductRec
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600820E RID: 33294 RVA: 0x00605608 File Offset: 0x00603808
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductRecord_KeyDown
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductRec_KeyDown
			Me.shouldHandleSelectedIndexChanged = False
			Me.dt = New DataTable()
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.apiKey = ""
			Me.url = ""
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002FB2 RID: 12210
		' (get) Token: 0x06008211 RID: 33297 RVA: 0x0003FC15 File Offset: 0x0003DE15
		' (set) Token: 0x06008212 RID: 33298 RVA: 0x0003FC1F File Offset: 0x0003DE1F
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17002FB3 RID: 12211
		' (get) Token: 0x06008213 RID: 33299 RVA: 0x0003FC28 File Offset: 0x0003DE28
		' (set) Token: 0x06008214 RID: 33300 RVA: 0x0003FC32 File Offset: 0x0003DE32
		Friend Overridable Property lblSet As Label

		' Token: 0x17002FB4 RID: 12212
		' (get) Token: 0x06008215 RID: 33301 RVA: 0x0003FC3B File Offset: 0x0003DE3B
		' (set) Token: 0x06008216 RID: 33302 RVA: 0x0060C020 File Offset: 0x0060A220
		Private _txtCategory As TextBox
		Friend Overridable Property txtCategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCategory_KeyDown
				Dim textBox As TextBox = Me._txtCategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCategory = value
				textBox = Me._txtCategory
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002FB5 RID: 12213
		' (get) Token: 0x06008217 RID: 33303 RVA: 0x0003FC45 File Offset: 0x0003DE45
		' (set) Token: 0x06008218 RID: 33304 RVA: 0x0003FC4F File Offset: 0x0003DE4F
		Friend Overridable Property Label2 As Label

		' Token: 0x17002FB6 RID: 12214
		' (get) Token: 0x06008219 RID: 33305 RVA: 0x0003FC58 File Offset: 0x0003DE58
		' (set) Token: 0x0600821A RID: 33306 RVA: 0x0003FC62 File Offset: 0x0003DE62
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17002FB7 RID: 12215
		' (get) Token: 0x0600821B RID: 33307 RVA: 0x0003FC6B File Offset: 0x0003DE6B
		' (set) Token: 0x0600821C RID: 33308 RVA: 0x0003FC75 File Offset: 0x0003DE75
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17002FB8 RID: 12216
		' (get) Token: 0x0600821D RID: 33309 RVA: 0x0003FC7E File Offset: 0x0003DE7E
		' (set) Token: 0x0600821E RID: 33310 RVA: 0x0060C064 File Offset: 0x0060A264
		Private _txtProductName As TextBox
		Friend Overridable Property txtProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtProductName_KeyDown
				Dim textBox As TextBox = Me._txtProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtProductName = value
				textBox = Me._txtProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002FB9 RID: 12217
		' (get) Token: 0x0600821F RID: 33311 RVA: 0x0003FC88 File Offset: 0x0003DE88
		' (set) Token: 0x06008220 RID: 33312 RVA: 0x0003FC92 File Offset: 0x0003DE92
		Friend Overridable Property Label3 As Label

		' Token: 0x17002FBA RID: 12218
		' (get) Token: 0x06008221 RID: 33313 RVA: 0x0003FC9B File Offset: 0x0003DE9B
		' (set) Token: 0x06008222 RID: 33314 RVA: 0x0003FCA5 File Offset: 0x0003DEA5
		Friend Overridable Property Label4 As Label

		' Token: 0x17002FBB RID: 12219
		' (get) Token: 0x06008223 RID: 33315 RVA: 0x0003FCAE File Offset: 0x0003DEAE
		' (set) Token: 0x06008224 RID: 33316 RVA: 0x0060C0A8 File Offset: 0x0060A2A8
		Private _txtBarcode As TextBox
		Friend Overridable Property txtBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBarcode_KeyDown
				Dim textBox As TextBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBarcode = value
				textBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002FBC RID: 12220
		' (get) Token: 0x06008225 RID: 33317 RVA: 0x0003FCB8 File Offset: 0x0003DEB8
		' (set) Token: 0x06008226 RID: 33318 RVA: 0x0003FCC2 File Offset: 0x0003DEC2
		Friend Overridable Property Label5 As Label

		' Token: 0x17002FBD RID: 12221
		' (get) Token: 0x06008227 RID: 33319 RVA: 0x0003FCCB File Offset: 0x0003DECB
		' (set) Token: 0x06008228 RID: 33320 RVA: 0x0060C0EC File Offset: 0x0060A2EC
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002FBE RID: 12222
		' (get) Token: 0x06008229 RID: 33321 RVA: 0x0003FCD5 File Offset: 0x0003DED5
		' (set) Token: 0x0600822A RID: 33322 RVA: 0x0003FCDF File Offset: 0x0003DEDF
		Friend Overridable Property Label6 As Label

		' Token: 0x17002FBF RID: 12223
		' (get) Token: 0x0600822B RID: 33323 RVA: 0x0003FCE8 File Offset: 0x0003DEE8
		' (set) Token: 0x0600822C RID: 33324 RVA: 0x0003FCF2 File Offset: 0x0003DEF2
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17002FC0 RID: 12224
		' (get) Token: 0x0600822D RID: 33325 RVA: 0x0003FCFB File Offset: 0x0003DEFB
		' (set) Token: 0x0600822E RID: 33326 RVA: 0x0003FD05 File Offset: 0x0003DF05
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17002FC1 RID: 12225
		' (get) Token: 0x0600822F RID: 33327 RVA: 0x0003FD0E File Offset: 0x0003DF0E
		' (set) Token: 0x06008230 RID: 33328 RVA: 0x0003FD18 File Offset: 0x0003DF18
		Friend Overridable Property Label7 As Label

		' Token: 0x17002FC2 RID: 12226
		' (get) Token: 0x06008231 RID: 33329 RVA: 0x0003FD21 File Offset: 0x0003DF21
		' (set) Token: 0x06008232 RID: 33330 RVA: 0x0003FD2B File Offset: 0x0003DF2B
		Friend Overridable Property Label9 As Label

		' Token: 0x17002FC3 RID: 12227
		' (get) Token: 0x06008233 RID: 33331 RVA: 0x0003FD34 File Offset: 0x0003DF34
		' (set) Token: 0x06008234 RID: 33332 RVA: 0x0003FD3E File Offset: 0x0003DF3E
		Friend Overridable Property cmbRack As ComboBox

		' Token: 0x17002FC4 RID: 12228
		' (get) Token: 0x06008235 RID: 33333 RVA: 0x0003FD47 File Offset: 0x0003DF47
		' (set) Token: 0x06008236 RID: 33334 RVA: 0x0003FD51 File Offset: 0x0003DF51
		Friend Overridable Property Label8 As Label

		' Token: 0x17002FC5 RID: 12229
		' (get) Token: 0x06008237 RID: 33335 RVA: 0x0003FD5A File Offset: 0x0003DF5A
		' (set) Token: 0x06008238 RID: 33336 RVA: 0x0003FD64 File Offset: 0x0003DF64
		Friend Overridable Property cmbGDown As ComboBox

		' Token: 0x17002FC6 RID: 12230
		' (get) Token: 0x06008239 RID: 33337 RVA: 0x0003FD6D File Offset: 0x0003DF6D
		' (set) Token: 0x0600823A RID: 33338 RVA: 0x0060C130 File Offset: 0x0060A330
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

		' Token: 0x17002FC7 RID: 12231
		' (get) Token: 0x0600823B RID: 33339 RVA: 0x0003FD77 File Offset: 0x0003DF77
		' (set) Token: 0x0600823C RID: 33340 RVA: 0x0003FD81 File Offset: 0x0003DF81
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17002FC8 RID: 12232
		' (get) Token: 0x0600823D RID: 33341 RVA: 0x0003FD8A File Offset: 0x0003DF8A
		' (set) Token: 0x0600823E RID: 33342 RVA: 0x0060C174 File Offset: 0x0060A374
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView1_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.DataGridView1_EditingControlShowing
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellDoubleClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler2
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002FC9 RID: 12233
		' (get) Token: 0x0600823F RID: 33343 RVA: 0x0003FD94 File Offset: 0x0003DF94
		' (set) Token: 0x06008240 RID: 33344 RVA: 0x0003FD9E File Offset: 0x0003DF9E
		Friend Overridable Property txtID As TextBox

		' Token: 0x17002FCA RID: 12234
		' (get) Token: 0x06008241 RID: 33345 RVA: 0x0003FDA7 File Offset: 0x0003DFA7
		' (set) Token: 0x06008242 RID: 33346 RVA: 0x0003FDB1 File Offset: 0x0003DFB1
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x17002FCB RID: 12235
		' (get) Token: 0x06008243 RID: 33347 RVA: 0x0003FDBA File Offset: 0x0003DFBA
		' (set) Token: 0x06008244 RID: 33348 RVA: 0x0003FDC4 File Offset: 0x0003DFC4
		Friend Overridable Property txtBarcodeTempStock As TextBox

		' Token: 0x17002FCC RID: 12236
		' (get) Token: 0x06008245 RID: 33349 RVA: 0x0003FDCD File Offset: 0x0003DFCD
		' (set) Token: 0x06008246 RID: 33350 RVA: 0x0003FDD7 File Offset: 0x0003DFD7
		Friend Overridable Property txtBar As TextBox

		' Token: 0x17002FCD RID: 12237
		' (get) Token: 0x06008247 RID: 33351 RVA: 0x0003FDE0 File Offset: 0x0003DFE0
		' (set) Token: 0x06008248 RID: 33352 RVA: 0x0003FDEA File Offset: 0x0003DFEA
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17002FCE RID: 12238
		' (get) Token: 0x06008249 RID: 33353 RVA: 0x0003FDF3 File Offset: 0x0003DFF3
		' (set) Token: 0x0600824A RID: 33354 RVA: 0x0003FDFD File Offset: 0x0003DFFD
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17002FCF RID: 12239
		' (get) Token: 0x0600824B RID: 33355 RVA: 0x0003FE06 File Offset: 0x0003E006
		' (set) Token: 0x0600824C RID: 33356 RVA: 0x0003FE10 File Offset: 0x0003E010
		Friend Overridable Property txtNP As TextBox

		' Token: 0x17002FD0 RID: 12240
		' (get) Token: 0x0600824D RID: 33357 RVA: 0x0003FE19 File Offset: 0x0003E019
		' (set) Token: 0x0600824E RID: 33358 RVA: 0x0003FE23 File Offset: 0x0003E023
		Friend Overridable Property txtID_Update As TextBox

		' Token: 0x17002FD1 RID: 12241
		' (get) Token: 0x0600824F RID: 33359 RVA: 0x0003FE2C File Offset: 0x0003E02C
		' (set) Token: 0x06008250 RID: 33360 RVA: 0x0003FE36 File Offset: 0x0003E036
		Friend Overridable Property txtbarcodeNocopy As TextBox

		' Token: 0x17002FD2 RID: 12242
		' (get) Token: 0x06008251 RID: 33361 RVA: 0x0003FE3F File Offset: 0x0003E03F
		' (set) Token: 0x06008252 RID: 33362 RVA: 0x0003FE49 File Offset: 0x0003E049
		Friend Overridable Property Label12 As Label

		' Token: 0x17002FD3 RID: 12243
		' (get) Token: 0x06008253 RID: 33363 RVA: 0x0003FE52 File Offset: 0x0003E052
		' (set) Token: 0x06008254 RID: 33364 RVA: 0x0003FE5C File Offset: 0x0003E05C
		Public Overridable Property Picture As PictureBox

		' Token: 0x17002FD4 RID: 12244
		' (get) Token: 0x06008255 RID: 33365 RVA: 0x0003FE65 File Offset: 0x0003E065
		' (set) Token: 0x06008256 RID: 33366 RVA: 0x0060C214 File Offset: 0x0060A414
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSubCategory_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002FD5 RID: 12245
		' (get) Token: 0x06008257 RID: 33367 RVA: 0x0003FE6F File Offset: 0x0003E06F
		' (set) Token: 0x06008258 RID: 33368 RVA: 0x0060C258 File Offset: 0x0060A458
		Private _CheckBox1 As CheckBox
		Friend Overridable Property CheckBox1 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox1_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox1 = value
				checkBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002FD6 RID: 12246
		' (get) Token: 0x06008259 RID: 33369 RVA: 0x0003FE79 File Offset: 0x0003E079
		' (set) Token: 0x0600825A RID: 33370 RVA: 0x0003FE83 File Offset: 0x0003E083
		Friend Overridable Property txtCompany As TextBox

		' Token: 0x17002FD7 RID: 12247
		' (get) Token: 0x0600825B RID: 33371 RVA: 0x0003FE8C File Offset: 0x0003E08C
		' (set) Token: 0x0600825C RID: 33372 RVA: 0x0003FE96 File Offset: 0x0003E096
		Friend Overridable Property pnlVariant As Panel

		' Token: 0x17002FD8 RID: 12248
		' (get) Token: 0x0600825D RID: 33373 RVA: 0x0003FE9F File Offset: 0x0003E09F
		' (set) Token: 0x0600825E RID: 33374 RVA: 0x0060C29C File Offset: 0x0060A49C
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.DataGridView2_EditingControlShowing
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellContentClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView2_KeyDown
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellEndEdit
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellEndEdit, dataGridViewCellEventHandler2
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellEndEdit, dataGridViewCellEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17002FD9 RID: 12249
		' (get) Token: 0x0600825F RID: 33375 RVA: 0x0003FEA9 File Offset: 0x0003E0A9
		' (set) Token: 0x06008260 RID: 33376 RVA: 0x0003FEB3 File Offset: 0x0003E0B3
		Friend Overridable Property Label13 As Label

		' Token: 0x17002FDA RID: 12250
		' (get) Token: 0x06008261 RID: 33377 RVA: 0x0003FEBC File Offset: 0x0003E0BC
		' (set) Token: 0x06008262 RID: 33378 RVA: 0x0003FEC6 File Offset: 0x0003E0C6
		Friend Overridable Property Label14 As Label

		' Token: 0x17002FDB RID: 12251
		' (get) Token: 0x06008263 RID: 33379 RVA: 0x0003FECF File Offset: 0x0003E0CF
		' (set) Token: 0x06008264 RID: 33380 RVA: 0x0003FED9 File Offset: 0x0003E0D9
		Friend Overridable Property DataGridViewImageColumn2 As DataGridViewImageColumn

		' Token: 0x17002FDC RID: 12252
		' (get) Token: 0x06008265 RID: 33381 RVA: 0x0003FEE2 File Offset: 0x0003E0E2
		' (set) Token: 0x06008266 RID: 33382 RVA: 0x0003FEEC File Offset: 0x0003E0EC
		Friend Overridable Property PID2 As DataGridViewTextBoxColumn

		' Token: 0x17002FDD RID: 12253
		' (get) Token: 0x06008267 RID: 33383 RVA: 0x0003FEF5 File Offset: 0x0003E0F5
		' (set) Token: 0x06008268 RID: 33384 RVA: 0x0003FEFF File Offset: 0x0003E0FF
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17002FDE RID: 12254
		' (get) Token: 0x06008269 RID: 33385 RVA: 0x0003FF08 File Offset: 0x0003E108
		' (set) Token: 0x0600826A RID: 33386 RVA: 0x0003FF12 File Offset: 0x0003E112
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17002FDF RID: 12255
		' (get) Token: 0x0600826B RID: 33387 RVA: 0x0003FF1B File Offset: 0x0003E11B
		' (set) Token: 0x0600826C RID: 33388 RVA: 0x0003FF25 File Offset: 0x0003E125
		Friend Overridable Property CategoryName As DataGridViewTextBoxColumn

		' Token: 0x17002FE0 RID: 12256
		' (get) Token: 0x0600826D RID: 33389 RVA: 0x0003FF2E File Offset: 0x0003E12E
		' (set) Token: 0x0600826E RID: 33390 RVA: 0x0003FF38 File Offset: 0x0003E138
		Friend Overridable Property DataGridViewButtonColumn1 As DataGridViewButtonColumn

		' Token: 0x17002FE1 RID: 12257
		' (get) Token: 0x0600826F RID: 33391 RVA: 0x0003FF41 File Offset: 0x0003E141
		' (set) Token: 0x06008270 RID: 33392 RVA: 0x0003FF4B File Offset: 0x0003E14B
		Friend Overridable Property SubCategoryName As DataGridViewTextBoxColumn

		' Token: 0x17002FE2 RID: 12258
		' (get) Token: 0x06008271 RID: 33393 RVA: 0x0003FF54 File Offset: 0x0003E154
		' (set) Token: 0x06008272 RID: 33394 RVA: 0x0003FF5E File Offset: 0x0003E15E
		Friend Overridable Property DataGridViewButtonColumn2 As DataGridViewButtonColumn

		' Token: 0x17002FE3 RID: 12259
		' (get) Token: 0x06008273 RID: 33395 RVA: 0x0003FF67 File Offset: 0x0003E167
		' (set) Token: 0x06008274 RID: 33396 RVA: 0x0003FF71 File Offset: 0x0003E171
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17002FE4 RID: 12260
		' (get) Token: 0x06008275 RID: 33397 RVA: 0x0003FF7A File Offset: 0x0003E17A
		' (set) Token: 0x06008276 RID: 33398 RVA: 0x0003FF84 File Offset: 0x0003E184
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17002FE5 RID: 12261
		' (get) Token: 0x06008277 RID: 33399 RVA: 0x0003FF8D File Offset: 0x0003E18D
		' (set) Token: 0x06008278 RID: 33400 RVA: 0x0003FF97 File Offset: 0x0003E197
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17002FE6 RID: 12262
		' (get) Token: 0x06008279 RID: 33401 RVA: 0x0003FFA0 File Offset: 0x0003E1A0
		' (set) Token: 0x0600827A RID: 33402 RVA: 0x0003FFAA File Offset: 0x0003E1AA
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17002FE7 RID: 12263
		' (get) Token: 0x0600827B RID: 33403 RVA: 0x0003FFB3 File Offset: 0x0003E1B3
		' (set) Token: 0x0600827C RID: 33404 RVA: 0x0003FFBD File Offset: 0x0003E1BD
		Friend Overridable Property CostPrice As DataGridViewTextBoxColumn

		' Token: 0x17002FE8 RID: 12264
		' (get) Token: 0x0600827D RID: 33405 RVA: 0x0003FFC6 File Offset: 0x0003E1C6
		' (set) Token: 0x0600827E RID: 33406 RVA: 0x0003FFD0 File Offset: 0x0003E1D0
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x17002FE9 RID: 12265
		' (get) Token: 0x0600827F RID: 33407 RVA: 0x0003FFD9 File Offset: 0x0003E1D9
		' (set) Token: 0x06008280 RID: 33408 RVA: 0x0003FFE3 File Offset: 0x0003E1E3
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x17002FEA RID: 12266
		' (get) Token: 0x06008281 RID: 33409 RVA: 0x0003FFEC File Offset: 0x0003E1EC
		' (set) Token: 0x06008282 RID: 33410 RVA: 0x0003FFF6 File Offset: 0x0003E1F6
		Friend Overridable Property cmbGST1 As DataGridViewTextBoxColumn

		' Token: 0x17002FEB RID: 12267
		' (get) Token: 0x06008283 RID: 33411 RVA: 0x0003FFFF File Offset: 0x0003E1FF
		' (set) Token: 0x06008284 RID: 33412 RVA: 0x00040009 File Offset: 0x0003E209
		Friend Overridable Property DataGridViewButtonColumn3 As DataGridViewButtonColumn

		' Token: 0x17002FEC RID: 12268
		' (get) Token: 0x06008285 RID: 33413 RVA: 0x00040012 File Offset: 0x0003E212
		' (set) Token: 0x06008286 RID: 33414 RVA: 0x0004001C File Offset: 0x0003E21C
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x17002FED RID: 12269
		' (get) Token: 0x06008287 RID: 33415 RVA: 0x00040025 File Offset: 0x0003E225
		' (set) Token: 0x06008288 RID: 33416 RVA: 0x0004002F File Offset: 0x0003E22F
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x17002FEE RID: 12270
		' (get) Token: 0x06008289 RID: 33417 RVA: 0x00040038 File Offset: 0x0003E238
		' (set) Token: 0x0600828A RID: 33418 RVA: 0x00040042 File Offset: 0x0003E242
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17002FEF RID: 12271
		' (get) Token: 0x0600828B RID: 33419 RVA: 0x0004004B File Offset: 0x0003E24B
		' (set) Token: 0x0600828C RID: 33420 RVA: 0x00040055 File Offset: 0x0003E255
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17002FF0 RID: 12272
		' (get) Token: 0x0600828D RID: 33421 RVA: 0x0004005E File Offset: 0x0003E25E
		' (set) Token: 0x0600828E RID: 33422 RVA: 0x00040068 File Offset: 0x0003E268
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17002FF1 RID: 12273
		' (get) Token: 0x0600828F RID: 33423 RVA: 0x00040071 File Offset: 0x0003E271
		' (set) Token: 0x06008290 RID: 33424 RVA: 0x0004007B File Offset: 0x0003E27B
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17002FF2 RID: 12274
		' (get) Token: 0x06008291 RID: 33425 RVA: 0x00040084 File Offset: 0x0003E284
		' (set) Token: 0x06008292 RID: 33426 RVA: 0x0004008E File Offset: 0x0003E28E
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17002FF3 RID: 12275
		' (get) Token: 0x06008293 RID: 33427 RVA: 0x00040097 File Offset: 0x0003E297
		' (set) Token: 0x06008294 RID: 33428 RVA: 0x000400A1 File Offset: 0x0003E2A1
		Friend Overridable Property cmbPurchaseUnit2 As DataGridViewTextBoxColumn

		' Token: 0x17002FF4 RID: 12276
		' (get) Token: 0x06008295 RID: 33429 RVA: 0x000400AA File Offset: 0x0003E2AA
		' (set) Token: 0x06008296 RID: 33430 RVA: 0x000400B4 File Offset: 0x0003E2B4
		Friend Overridable Property cmbSalesUnit2 As DataGridViewTextBoxColumn

		' Token: 0x17002FF5 RID: 12277
		' (get) Token: 0x06008297 RID: 33431 RVA: 0x000400BD File Offset: 0x0003E2BD
		' (set) Token: 0x06008298 RID: 33432 RVA: 0x000400C7 File Offset: 0x0003E2C7
		Friend Overridable Property cmbAltunit2 As DataGridViewTextBoxColumn

		' Token: 0x17002FF6 RID: 12278
		' (get) Token: 0x06008299 RID: 33433 RVA: 0x000400D0 File Offset: 0x0003E2D0
		' (set) Token: 0x0600829A RID: 33434 RVA: 0x000400DA File Offset: 0x0003E2DA
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17002FF7 RID: 12279
		' (get) Token: 0x0600829B RID: 33435 RVA: 0x000400E3 File Offset: 0x0003E2E3
		' (set) Token: 0x0600829C RID: 33436 RVA: 0x000400ED File Offset: 0x0003E2ED
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17002FF8 RID: 12280
		' (get) Token: 0x0600829D RID: 33437 RVA: 0x000400F6 File Offset: 0x0003E2F6
		' (set) Token: 0x0600829E RID: 33438 RVA: 0x00040100 File Offset: 0x0003E300
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x17002FF9 RID: 12281
		' (get) Token: 0x0600829F RID: 33439 RVA: 0x00040109 File Offset: 0x0003E309
		' (set) Token: 0x060082A0 RID: 33440 RVA: 0x00040113 File Offset: 0x0003E313
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x17002FFA RID: 12282
		' (get) Token: 0x060082A1 RID: 33441 RVA: 0x0004011C File Offset: 0x0003E31C
		' (set) Token: 0x060082A2 RID: 33442 RVA: 0x00040126 File Offset: 0x0003E326
		Friend Overridable Property cmbSalesTaxType2 As DataGridViewTextBoxColumn

		' Token: 0x17002FFB RID: 12283
		' (get) Token: 0x060082A3 RID: 33443 RVA: 0x0004012F File Offset: 0x0003E32F
		' (set) Token: 0x060082A4 RID: 33444 RVA: 0x00040139 File Offset: 0x0003E339
		Friend Overridable Property cmbPurchaseTaxType2 As DataGridViewTextBoxColumn

		' Token: 0x17002FFC RID: 12284
		' (get) Token: 0x060082A5 RID: 33445 RVA: 0x00040142 File Offset: 0x0003E342
		' (set) Token: 0x060082A6 RID: 33446 RVA: 0x0004014C File Offset: 0x0003E34C
		Friend Overridable Property ddlGdown2 As DataGridViewTextBoxColumn

		' Token: 0x17002FFD RID: 12285
		' (get) Token: 0x060082A7 RID: 33447 RVA: 0x00040155 File Offset: 0x0003E355
		' (set) Token: 0x060082A8 RID: 33448 RVA: 0x0004015F File Offset: 0x0003E35F
		Friend Overridable Property ddlRack2 As DataGridViewTextBoxColumn

		' Token: 0x17002FFE RID: 12286
		' (get) Token: 0x060082A9 RID: 33449 RVA: 0x00040168 File Offset: 0x0003E368
		' (set) Token: 0x060082AA RID: 33450 RVA: 0x00040172 File Offset: 0x0003E372
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x17002FFF RID: 12287
		' (get) Token: 0x060082AB RID: 33451 RVA: 0x0004017B File Offset: 0x0003E37B
		' (set) Token: 0x060082AC RID: 33452 RVA: 0x00040185 File Offset: 0x0003E385
		Friend Overridable Property txtOpeningStock2 As DataGridViewTextBoxColumn

		' Token: 0x17003000 RID: 12288
		' (get) Token: 0x060082AD RID: 33453 RVA: 0x0004018E File Offset: 0x0003E38E
		' (set) Token: 0x060082AE RID: 33454 RVA: 0x00040198 File Offset: 0x0003E398
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17003001 RID: 12289
		' (get) Token: 0x060082AF RID: 33455 RVA: 0x000401A1 File Offset: 0x0003E3A1
		' (set) Token: 0x060082B0 RID: 33456 RVA: 0x000401AB File Offset: 0x0003E3AB
		Friend Overridable Property txtMRP As DataGridViewTextBoxColumn

		' Token: 0x17003002 RID: 12290
		' (get) Token: 0x060082B1 RID: 33457 RVA: 0x000401B4 File Offset: 0x0003E3B4
		' (set) Token: 0x060082B2 RID: 33458 RVA: 0x000401BE File Offset: 0x0003E3BE
		Friend Overridable Property txtRSP1 As DataGridViewTextBoxColumn

		' Token: 0x17003003 RID: 12291
		' (get) Token: 0x060082B3 RID: 33459 RVA: 0x000401C7 File Offset: 0x0003E3C7
		' (set) Token: 0x060082B4 RID: 33460 RVA: 0x000401D1 File Offset: 0x0003E3D1
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17003004 RID: 12292
		' (get) Token: 0x060082B5 RID: 33461 RVA: 0x000401DA File Offset: 0x0003E3DA
		' (set) Token: 0x060082B6 RID: 33462 RVA: 0x000401E4 File Offset: 0x0003E3E4
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17003005 RID: 12293
		' (get) Token: 0x060082B7 RID: 33463 RVA: 0x000401ED File Offset: 0x0003E3ED
		' (set) Token: 0x060082B8 RID: 33464 RVA: 0x000401F7 File Offset: 0x0003E3F7
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17003006 RID: 12294
		' (get) Token: 0x060082B9 RID: 33465 RVA: 0x00040200 File Offset: 0x0003E400
		' (set) Token: 0x060082BA RID: 33466 RVA: 0x0004020A File Offset: 0x0003E40A
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17003007 RID: 12295
		' (get) Token: 0x060082BB RID: 33467 RVA: 0x00040213 File Offset: 0x0003E413
		' (set) Token: 0x060082BC RID: 33468 RVA: 0x0004021D File Offset: 0x0003E41D
		Friend Overridable Property cmbSize2 As DataGridViewTextBoxColumn

		' Token: 0x17003008 RID: 12296
		' (get) Token: 0x060082BD RID: 33469 RVA: 0x00040226 File Offset: 0x0003E426
		' (set) Token: 0x060082BE RID: 33470 RVA: 0x00040230 File Offset: 0x0003E430
		Friend Overridable Property cmbColour2 As DataGridViewTextBoxColumn

		' Token: 0x17003009 RID: 12297
		' (get) Token: 0x060082BF RID: 33471 RVA: 0x00040239 File Offset: 0x0003E439
		' (set) Token: 0x060082C0 RID: 33472 RVA: 0x00040243 File Offset: 0x0003E443
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x1700300A RID: 12298
		' (get) Token: 0x060082C1 RID: 33473 RVA: 0x0004024C File Offset: 0x0003E44C
		' (set) Token: 0x060082C2 RID: 33474 RVA: 0x00040256 File Offset: 0x0003E456
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x1700300B RID: 12299
		' (get) Token: 0x060082C3 RID: 33475 RVA: 0x0004025F File Offset: 0x0003E45F
		' (set) Token: 0x060082C4 RID: 33476 RVA: 0x00040269 File Offset: 0x0003E469
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x1700300C RID: 12300
		' (get) Token: 0x060082C5 RID: 33477 RVA: 0x00040272 File Offset: 0x0003E472
		' (set) Token: 0x060082C6 RID: 33478 RVA: 0x0004027C File Offset: 0x0003E47C
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x1700300D RID: 12301
		' (get) Token: 0x060082C7 RID: 33479 RVA: 0x00040285 File Offset: 0x0003E485
		' (set) Token: 0x060082C8 RID: 33480 RVA: 0x0004028F File Offset: 0x0003E48F
		Friend Overridable Property btnAddNew As DataGridViewButtonColumn

		' Token: 0x1700300E RID: 12302
		' (get) Token: 0x060082C9 RID: 33481 RVA: 0x00040298 File Offset: 0x0003E498
		' (set) Token: 0x060082CA RID: 33482 RVA: 0x000402A2 File Offset: 0x0003E4A2
		Friend Overridable Property PID As DataGridViewTextBoxColumn

		' Token: 0x1700300F RID: 12303
		' (get) Token: 0x060082CB RID: 33483 RVA: 0x000402AB File Offset: 0x0003E4AB
		' (set) Token: 0x060082CC RID: 33484 RVA: 0x000402B5 File Offset: 0x0003E4B5
		Friend Overridable Property ProductCode As DataGridViewTextBoxColumn

		' Token: 0x17003010 RID: 12304
		' (get) Token: 0x060082CD RID: 33485 RVA: 0x000402BE File Offset: 0x0003E4BE
		' (set) Token: 0x060082CE RID: 33486 RVA: 0x000402C8 File Offset: 0x0003E4C8
		Friend Overridable Property ProductName As DataGridViewTextBoxColumn

		' Token: 0x17003011 RID: 12305
		' (get) Token: 0x060082CF RID: 33487 RVA: 0x000402D1 File Offset: 0x0003E4D1
		' (set) Token: 0x060082D0 RID: 33488 RVA: 0x000402DB File Offset: 0x0003E4DB
		Friend Overridable Property cmbCategory As DataGridViewComboBoxColumn

		' Token: 0x17003012 RID: 12306
		' (get) Token: 0x060082D1 RID: 33489 RVA: 0x000402E4 File Offset: 0x0003E4E4
		' (set) Token: 0x060082D2 RID: 33490 RVA: 0x000402EE File Offset: 0x0003E4EE
		Friend Overridable Property btnAddCategory As DataGridViewButtonColumn

		' Token: 0x17003013 RID: 12307
		' (get) Token: 0x060082D3 RID: 33491 RVA: 0x000402F7 File Offset: 0x0003E4F7
		' (set) Token: 0x060082D4 RID: 33492 RVA: 0x00040301 File Offset: 0x0003E501
		Friend Overridable Property cmbSubCategory As DataGridViewComboBoxColumn

		' Token: 0x17003014 RID: 12308
		' (get) Token: 0x060082D5 RID: 33493 RVA: 0x0004030A File Offset: 0x0003E50A
		' (set) Token: 0x060082D6 RID: 33494 RVA: 0x00040314 File Offset: 0x0003E514
		Friend Overridable Property btnAddSubCategory As DataGridViewButtonColumn

		' Token: 0x17003015 RID: 12309
		' (get) Token: 0x060082D7 RID: 33495 RVA: 0x0004031D File Offset: 0x0003E51D
		' (set) Token: 0x060082D8 RID: 33496 RVA: 0x00040327 File Offset: 0x0003E527
		Friend Overridable Property txtSubCategoryID As DataGridViewTextBoxColumn

		' Token: 0x17003016 RID: 12310
		' (get) Token: 0x060082D9 RID: 33497 RVA: 0x00040330 File Offset: 0x0003E530
		' (set) Token: 0x060082DA RID: 33498 RVA: 0x0004033A File Offset: 0x0003E53A
		Friend Overridable Property txtHSNCode As DataGridViewTextBoxColumn

		' Token: 0x17003017 RID: 12311
		' (get) Token: 0x060082DB RID: 33499 RVA: 0x00040343 File Offset: 0x0003E543
		' (set) Token: 0x060082DC RID: 33500 RVA: 0x0004034D File Offset: 0x0003E54D
		Friend Overridable Property txtPartNo As DataGridViewTextBoxColumn

		' Token: 0x17003018 RID: 12312
		' (get) Token: 0x060082DD RID: 33501 RVA: 0x00040356 File Offset: 0x0003E556
		' (set) Token: 0x060082DE RID: 33502 RVA: 0x00040360 File Offset: 0x0003E560
		Friend Overridable Property txtFeatures As DataGridViewTextBoxColumn

		' Token: 0x17003019 RID: 12313
		' (get) Token: 0x060082DF RID: 33503 RVA: 0x00040369 File Offset: 0x0003E569
		' (set) Token: 0x060082E0 RID: 33504 RVA: 0x00040373 File Offset: 0x0003E573
		Friend Overridable Property txtCostPrice As DataGridViewTextBoxColumn

		' Token: 0x1700301A RID: 12314
		' (get) Token: 0x060082E1 RID: 33505 RVA: 0x0004037C File Offset: 0x0003E57C
		' (set) Token: 0x060082E2 RID: 33506 RVA: 0x00040386 File Offset: 0x0003E586
		Friend Overridable Property RSPrice As DataGridViewTextBoxColumn

		' Token: 0x1700301B RID: 12315
		' (get) Token: 0x060082E3 RID: 33507 RVA: 0x0004038F File Offset: 0x0003E58F
		' (set) Token: 0x060082E4 RID: 33508 RVA: 0x00040399 File Offset: 0x0003E599
		Friend Overridable Property txtDiscount As DataGridViewTextBoxColumn

		' Token: 0x1700301C RID: 12316
		' (get) Token: 0x060082E5 RID: 33509 RVA: 0x000403A2 File Offset: 0x0003E5A2
		' (set) Token: 0x060082E6 RID: 33510 RVA: 0x000403AC File Offset: 0x0003E5AC
		Friend Overridable Property cmbGST As DataGridViewComboBoxColumn

		' Token: 0x1700301D RID: 12317
		' (get) Token: 0x060082E7 RID: 33511 RVA: 0x000403B5 File Offset: 0x0003E5B5
		' (set) Token: 0x060082E8 RID: 33512 RVA: 0x000403BF File Offset: 0x0003E5BF
		Friend Overridable Property btnAddGSTPer As DataGridViewButtonColumn

		' Token: 0x1700301E RID: 12318
		' (get) Token: 0x060082E9 RID: 33513 RVA: 0x000403C8 File Offset: 0x0003E5C8
		' (set) Token: 0x060082EA RID: 33514 RVA: 0x000403D2 File Offset: 0x0003E5D2
		Friend Overridable Property txtCGST As DataGridViewTextBoxColumn

		' Token: 0x1700301F RID: 12319
		' (get) Token: 0x060082EB RID: 33515 RVA: 0x000403DB File Offset: 0x0003E5DB
		' (set) Token: 0x060082EC RID: 33516 RVA: 0x000403E5 File Offset: 0x0003E5E5
		Friend Overridable Property txtSGST As DataGridViewTextBoxColumn

		' Token: 0x17003020 RID: 12320
		' (get) Token: 0x060082ED RID: 33517 RVA: 0x000403EE File Offset: 0x0003E5EE
		' (set) Token: 0x060082EE RID: 33518 RVA: 0x000403F8 File Offset: 0x0003E5F8
		Friend Overridable Property txtIGST As DataGridViewTextBoxColumn

		' Token: 0x17003021 RID: 12321
		' (get) Token: 0x060082EF RID: 33519 RVA: 0x00040401 File Offset: 0x0003E601
		' (set) Token: 0x060082F0 RID: 33520 RVA: 0x0004040B File Offset: 0x0003E60B
		Friend Overridable Property txtCESS As DataGridViewTextBoxColumn

		' Token: 0x17003022 RID: 12322
		' (get) Token: 0x060082F1 RID: 33521 RVA: 0x00040414 File Offset: 0x0003E614
		' (set) Token: 0x060082F2 RID: 33522 RVA: 0x0004041E File Offset: 0x0003E61E
		Friend Overridable Property WSPrice As DataGridViewTextBoxColumn

		' Token: 0x17003023 RID: 12323
		' (get) Token: 0x060082F3 RID: 33523 RVA: 0x00040427 File Offset: 0x0003E627
		' (set) Token: 0x060082F4 RID: 33524 RVA: 0x00040431 File Offset: 0x0003E631
		Friend Overridable Property Barcode As DataGridViewTextBoxColumn

		' Token: 0x17003024 RID: 12324
		' (get) Token: 0x060082F5 RID: 33525 RVA: 0x0004043A File Offset: 0x0003E63A
		' (set) Token: 0x060082F6 RID: 33526 RVA: 0x00040444 File Offset: 0x0003E644
		Friend Overridable Property OpeningStock As DataGridViewTextBoxColumn

		' Token: 0x17003025 RID: 12325
		' (get) Token: 0x060082F7 RID: 33527 RVA: 0x0004044D File Offset: 0x0003E64D
		' (set) Token: 0x060082F8 RID: 33528 RVA: 0x00040457 File Offset: 0x0003E657
		Friend Overridable Property cmbPurchaseUnit As DataGridViewComboBoxColumn

		' Token: 0x17003026 RID: 12326
		' (get) Token: 0x060082F9 RID: 33529 RVA: 0x00040460 File Offset: 0x0003E660
		' (set) Token: 0x060082FA RID: 33530 RVA: 0x0004046A File Offset: 0x0003E66A
		Friend Overridable Property cmbSalesUnit As DataGridViewComboBoxColumn

		' Token: 0x17003027 RID: 12327
		' (get) Token: 0x060082FB RID: 33531 RVA: 0x00040473 File Offset: 0x0003E673
		' (set) Token: 0x060082FC RID: 33532 RVA: 0x0004047D File Offset: 0x0003E67D
		Friend Overridable Property cmbAltunit As DataGridViewComboBoxColumn

		' Token: 0x17003028 RID: 12328
		' (get) Token: 0x060082FD RID: 33533 RVA: 0x00040486 File Offset: 0x0003E686
		' (set) Token: 0x060082FE RID: 33534 RVA: 0x00040490 File Offset: 0x0003E690
		Friend Overridable Property Conv As DataGridViewTextBoxColumn

		' Token: 0x17003029 RID: 12329
		' (get) Token: 0x060082FF RID: 33535 RVA: 0x00040499 File Offset: 0x0003E699
		' (set) Token: 0x06008300 RID: 33536 RVA: 0x000404A3 File Offset: 0x0003E6A3
		Friend Overridable Property txtMinStock As DataGridViewTextBoxColumn

		' Token: 0x1700302A RID: 12330
		' (get) Token: 0x06008301 RID: 33537 RVA: 0x000404AC File Offset: 0x0003E6AC
		' (set) Token: 0x06008302 RID: 33538 RVA: 0x000404B6 File Offset: 0x0003E6B6
		Friend Overridable Property DefMRP As DataGridViewTextBoxColumn

		' Token: 0x1700302B RID: 12331
		' (get) Token: 0x06008303 RID: 33539 RVA: 0x000404BF File Offset: 0x0003E6BF
		' (set) Token: 0x06008304 RID: 33540 RVA: 0x000404C9 File Offset: 0x0003E6C9
		Friend Overridable Property Active As DataGridViewTextBoxColumn

		' Token: 0x1700302C RID: 12332
		' (get) Token: 0x06008305 RID: 33541 RVA: 0x000404D2 File Offset: 0x0003E6D2
		' (set) Token: 0x06008306 RID: 33542 RVA: 0x000404DC File Offset: 0x0003E6DC
		Friend Overridable Property cmbSalesTaxType As DataGridViewComboBoxColumn

		' Token: 0x1700302D RID: 12333
		' (get) Token: 0x06008307 RID: 33543 RVA: 0x000404E5 File Offset: 0x0003E6E5
		' (set) Token: 0x06008308 RID: 33544 RVA: 0x000404EF File Offset: 0x0003E6EF
		Friend Overridable Property cmbPurchaseTaxType As DataGridViewComboBoxColumn

		' Token: 0x1700302E RID: 12334
		' (get) Token: 0x06008309 RID: 33545 RVA: 0x000404F8 File Offset: 0x0003E6F8
		' (set) Token: 0x0600830A RID: 33546 RVA: 0x00040502 File Offset: 0x0003E702
		Friend Overridable Property ddlGdown As DataGridViewComboBoxColumn

		' Token: 0x1700302F RID: 12335
		' (get) Token: 0x0600830B RID: 33547 RVA: 0x0004050B File Offset: 0x0003E70B
		' (set) Token: 0x0600830C RID: 33548 RVA: 0x00040515 File Offset: 0x0003E715
		Friend Overridable Property ddlRack As DataGridViewComboBoxColumn

		' Token: 0x17003030 RID: 12336
		' (get) Token: 0x0600830D RID: 33549 RVA: 0x0004051E File Offset: 0x0003E71E
		' (set) Token: 0x0600830E RID: 33550 RVA: 0x00040528 File Offset: 0x0003E728
		Friend Overridable Property txtSaleQty As DataGridViewTextBoxColumn

		' Token: 0x17003031 RID: 12337
		' (get) Token: 0x0600830F RID: 33551 RVA: 0x00040531 File Offset: 0x0003E731
		' (set) Token: 0x06008310 RID: 33552 RVA: 0x0004053B File Offset: 0x0003E73B
		Friend Overridable Property txtOpeningStock As DataGridViewTextBoxColumn

		' Token: 0x17003032 RID: 12338
		' (get) Token: 0x06008311 RID: 33553 RVA: 0x00040544 File Offset: 0x0003E744
		' (set) Token: 0x06008312 RID: 33554 RVA: 0x0004054E File Offset: 0x0003E74E
		Friend Overridable Property txtBarcode_TempStock As DataGridViewTextBoxColumn

		' Token: 0x17003033 RID: 12339
		' (get) Token: 0x06008313 RID: 33555 RVA: 0x00040557 File Offset: 0x0003E757
		' (set) Token: 0x06008314 RID: 33556 RVA: 0x00040561 File Offset: 0x0003E761
		Friend Overridable Property txtDefMRP As DataGridViewTextBoxColumn

		' Token: 0x17003034 RID: 12340
		' (get) Token: 0x06008315 RID: 33557 RVA: 0x0004056A File Offset: 0x0003E76A
		' (set) Token: 0x06008316 RID: 33558 RVA: 0x00040574 File Offset: 0x0003E774
		Friend Overridable Property txtRSP As DataGridViewTextBoxColumn

		' Token: 0x17003035 RID: 12341
		' (get) Token: 0x06008317 RID: 33559 RVA: 0x0004057D File Offset: 0x0003E77D
		' (set) Token: 0x06008318 RID: 33560 RVA: 0x00040587 File Offset: 0x0003E787
		Friend Overridable Property txtWSP As DataGridViewTextBoxColumn

		' Token: 0x17003036 RID: 12342
		' (get) Token: 0x06008319 RID: 33561 RVA: 0x00040590 File Offset: 0x0003E790
		' (set) Token: 0x0600831A RID: 33562 RVA: 0x0004059A File Offset: 0x0003E79A
		Friend Overridable Property txtBatch As DataGridViewTextBoxColumn

		' Token: 0x17003037 RID: 12343
		' (get) Token: 0x0600831B RID: 33563 RVA: 0x000405A3 File Offset: 0x0003E7A3
		' (set) Token: 0x0600831C RID: 33564 RVA: 0x000405AD File Offset: 0x0003E7AD
		Friend Overridable Property MfgDate As DataGridViewTextBoxColumn

		' Token: 0x17003038 RID: 12344
		' (get) Token: 0x0600831D RID: 33565 RVA: 0x000405B6 File Offset: 0x0003E7B6
		' (set) Token: 0x0600831E RID: 33566 RVA: 0x000405C0 File Offset: 0x0003E7C0
		Friend Overridable Property ExpDate As DataGridViewTextBoxColumn

		' Token: 0x17003039 RID: 12345
		' (get) Token: 0x0600831F RID: 33567 RVA: 0x000405C9 File Offset: 0x0003E7C9
		' (set) Token: 0x06008320 RID: 33568 RVA: 0x000405D3 File Offset: 0x0003E7D3
		Friend Overridable Property cmbSize As DataGridViewTextBoxColumn

		' Token: 0x1700303A RID: 12346
		' (get) Token: 0x06008321 RID: 33569 RVA: 0x000405DC File Offset: 0x0003E7DC
		' (set) Token: 0x06008322 RID: 33570 RVA: 0x000405E6 File Offset: 0x0003E7E6
		Friend Overridable Property cmbColour As DataGridViewTextBoxColumn

		' Token: 0x1700303B RID: 12347
		' (get) Token: 0x06008323 RID: 33571 RVA: 0x000405EF File Offset: 0x0003E7EF
		' (set) Token: 0x06008324 RID: 33572 RVA: 0x000405F9 File Offset: 0x0003E7F9
		Friend Overridable Property txtIMEI1 As DataGridViewTextBoxColumn

		' Token: 0x1700303C RID: 12348
		' (get) Token: 0x06008325 RID: 33573 RVA: 0x00040602 File Offset: 0x0003E802
		' (set) Token: 0x06008326 RID: 33574 RVA: 0x0004060C File Offset: 0x0003E80C
		Friend Overridable Property txtIMEI2 As DataGridViewTextBoxColumn

		' Token: 0x1700303D RID: 12349
		' (get) Token: 0x06008327 RID: 33575 RVA: 0x00040615 File Offset: 0x0003E815
		' (set) Token: 0x06008328 RID: 33576 RVA: 0x0004061F File Offset: 0x0003E81F
		Friend Overridable Property Kitchen As DataGridViewTextBoxColumn

		' Token: 0x1700303E RID: 12350
		' (get) Token: 0x06008329 RID: 33577 RVA: 0x00040628 File Offset: 0x0003E828
		' (set) Token: 0x0600832A RID: 33578 RVA: 0x00040632 File Offset: 0x0003E832
		Friend Overridable Property Photo As DataGridViewImageColumn

		' Token: 0x1700303F RID: 12351
		' (get) Token: 0x0600832B RID: 33579 RVA: 0x0004063B File Offset: 0x0003E83B
		' (set) Token: 0x0600832C RID: 33580 RVA: 0x00040645 File Offset: 0x0003E845
		Friend Overridable Property variant_id As DataGridViewTextBoxColumn

		' Token: 0x17003040 RID: 12352
		' (get) Token: 0x0600832D RID: 33581 RVA: 0x0004064E File Offset: 0x0003E84E
		' (set) Token: 0x0600832E RID: 33582 RVA: 0x00040658 File Offset: 0x0003E858
		Friend Overridable Property InsertButtonColumn As DataGridViewButtonColumn

		' Token: 0x17003041 RID: 12353
		' (get) Token: 0x0600832F RID: 33583 RVA: 0x00040661 File Offset: 0x0003E861
		' (set) Token: 0x06008330 RID: 33584 RVA: 0x0004066B File Offset: 0x0003E86B
		Friend Overridable Property UpdateButtonColumn As DataGridViewButtonColumn

		' Token: 0x17003042 RID: 12354
		' (get) Token: 0x06008331 RID: 33585 RVA: 0x00040674 File Offset: 0x0003E874
		' (set) Token: 0x06008332 RID: 33586 RVA: 0x0004067E File Offset: 0x0003E87E
		Friend Overridable Property DeleteButtonColumn As DataGridViewButtonColumn

		' Token: 0x17003043 RID: 12355
		' (get) Token: 0x06008333 RID: 33587 RVA: 0x00040687 File Offset: 0x0003E887
		' (set) Token: 0x06008334 RID: 33588 RVA: 0x00040691 File Offset: 0x0003E891
		Friend Overridable Property PrintBarcodeButton As DataGridViewButtonColumn

		' Token: 0x17003044 RID: 12356
		' (get) Token: 0x06008335 RID: 33589 RVA: 0x0004069A File Offset: 0x0003E89A
		' (set) Token: 0x06008336 RID: 33590 RVA: 0x000406A4 File Offset: 0x0003E8A4
		Friend Overridable Property Mark As DataGridViewCheckBoxColumn

		' Token: 0x17003045 RID: 12357
		' (get) Token: 0x06008337 RID: 33591 RVA: 0x000406AD File Offset: 0x0003E8AD
		' (set) Token: 0x06008338 RID: 33592 RVA: 0x000406B7 File Offset: 0x0003E8B7
		Friend Overridable Property variantName As DataGridViewButtonColumn

		' Token: 0x17003046 RID: 12358
		' (get) Token: 0x06008339 RID: 33593 RVA: 0x000406C0 File Offset: 0x0003E8C0
		' (set) Token: 0x0600833A RID: 33594 RVA: 0x000406CA File Offset: 0x0003E8CA
		Friend Overridable Property lblUser As Label

		' Token: 0x17003047 RID: 12359
		' (get) Token: 0x0600833B RID: 33595 RVA: 0x000406D3 File Offset: 0x0003E8D3
		' (set) Token: 0x0600833C RID: 33596 RVA: 0x000406DD File Offset: 0x0003E8DD
		Friend Overridable Property Label16 As Label

		' Token: 0x17003048 RID: 12360
		' (get) Token: 0x0600833D RID: 33597 RVA: 0x000406E6 File Offset: 0x0003E8E6
		' (set) Token: 0x0600833E RID: 33598 RVA: 0x000406F0 File Offset: 0x0003E8F0
		Friend Overridable Property Label15 As Label

		' Token: 0x17003049 RID: 12361
		' (get) Token: 0x0600833F RID: 33599 RVA: 0x000406F9 File Offset: 0x0003E8F9
		' (set) Token: 0x06008340 RID: 33600 RVA: 0x00040703 File Offset: 0x0003E903
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700304A RID: 12362
		' (get) Token: 0x06008341 RID: 33601 RVA: 0x0004070C File Offset: 0x0003E90C
		' (set) Token: 0x06008342 RID: 33602 RVA: 0x0060C33C File Offset: 0x0060A53C
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click_1
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700304B RID: 12363
		' (get) Token: 0x06008343 RID: 33603 RVA: 0x00040716 File Offset: 0x0003E916
		' (set) Token: 0x06008344 RID: 33604 RVA: 0x0060C380 File Offset: 0x0060A580
		Private _Button16 As Button
		Friend Overridable Property Button16 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button16_Click
				Dim button As Button = Me._Button16
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button16 = value
				button = Me._Button16
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700304C RID: 12364
		' (get) Token: 0x06008345 RID: 33605 RVA: 0x00040720 File Offset: 0x0003E920
		' (set) Token: 0x06008346 RID: 33606 RVA: 0x0060C3C4 File Offset: 0x0060A5C4
		Private _btnExportExcel As Button
		Friend Overridable Property btnExportExcel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click_1
				Dim button As Button = Me._btnExportExcel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnExportExcel = value
				button = Me._btnExportExcel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700304D RID: 12365
		' (get) Token: 0x06008347 RID: 33607 RVA: 0x0004072A File Offset: 0x0003E92A
		' (set) Token: 0x06008348 RID: 33608 RVA: 0x0060C408 File Offset: 0x0060A608
		Private _btnProductSeting As Button
		Friend Overridable Property btnProductSeting As Button
			<CompilerGenerated()>
			Get
				Return Me._btnProductSeting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnProductSeting_Click
				Dim button As Button = Me._btnProductSeting
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnProductSeting = value
				button = Me._btnProductSeting
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700304E RID: 12366
		' (get) Token: 0x06008349 RID: 33609 RVA: 0x00040734 File Offset: 0x0003E934
		' (set) Token: 0x0600834A RID: 33610 RVA: 0x0004073E File Offset: 0x0003E93E
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700304F RID: 12367
		' (get) Token: 0x0600834B RID: 33611 RVA: 0x00040747 File Offset: 0x0003E947
		' (set) Token: 0x0600834C RID: 33612 RVA: 0x00040751 File Offset: 0x0003E951
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17003050 RID: 12368
		' (get) Token: 0x0600834D RID: 33613 RVA: 0x0004075A File Offset: 0x0003E95A
		' (set) Token: 0x0600834E RID: 33614 RVA: 0x00040764 File Offset: 0x0003E964
		Friend Overridable Property Label17 As Label

		' Token: 0x17003051 RID: 12369
		' (get) Token: 0x0600834F RID: 33615 RVA: 0x0004076D File Offset: 0x0003E96D
		' (set) Token: 0x06008350 RID: 33616 RVA: 0x0060C44C File Offset: 0x0060A64C
		Private _GelButton3 As Button
		Friend Overridable Property GelButton3 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim button As Button = Me._GelButton3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton3 = value
				button = Me._GelButton3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003052 RID: 12370
		' (get) Token: 0x06008351 RID: 33617 RVA: 0x00040777 File Offset: 0x0003E977
		' (set) Token: 0x06008352 RID: 33618 RVA: 0x0060C490 File Offset: 0x0060A690
		Private _btnBulkImageUpdate As Button
		Friend Overridable Property btnBulkImageUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBulkImageUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBulkImageUpdate_Click
				Dim button As Button = Me._btnBulkImageUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBulkImageUpdate = value
				button = Me._btnBulkImageUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003053 RID: 12371
		' (get) Token: 0x06008353 RID: 33619 RVA: 0x00040781 File Offset: 0x0003E981
		' (set) Token: 0x06008354 RID: 33620 RVA: 0x0060C4D4 File Offset: 0x0060A6D4
		Private _btnShowAll As Button
		Friend Overridable Property btnShowAll As Button
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click_1
				Dim button As Button = Me._btnShowAll
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnShowAll = value
				button = Me._btnShowAll
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003054 RID: 12372
		' (get) Token: 0x06008355 RID: 33621 RVA: 0x0004078B File Offset: 0x0003E98B
		' (set) Token: 0x06008356 RID: 33622 RVA: 0x0060C518 File Offset: 0x0060A718
		Private _GelButton5 As Button
		Friend Overridable Property GelButton5 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim button As Button = Me._GelButton5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton5 = value
				button = Me._GelButton5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003055 RID: 12373
		' (get) Token: 0x06008357 RID: 33623 RVA: 0x00040795 File Offset: 0x0003E995
		' (set) Token: 0x06008358 RID: 33624 RVA: 0x0060C55C File Offset: 0x0060A75C
		Private _GelButton6 As Button
		Friend Overridable Property GelButton6 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim button As Button = Me._GelButton6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton6 = value
				button = Me._GelButton6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003056 RID: 12374
		' (get) Token: 0x06008359 RID: 33625 RVA: 0x0004079F File Offset: 0x0003E99F
		' (set) Token: 0x0600835A RID: 33626 RVA: 0x0060C5A0 File Offset: 0x0060A7A0
		Private _GelButtonNewRecord As Button
		Friend Overridable Property GelButtonNewRecord As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButtonNewRecord
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButtonNewRecord = value
				button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003057 RID: 12375
		' (get) Token: 0x0600835B RID: 33627 RVA: 0x000407A9 File Offset: 0x0003E9A9
		' (set) Token: 0x0600835C RID: 33628 RVA: 0x000407B3 File Offset: 0x0003E9B3
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17003058 RID: 12376
		' (get) Token: 0x0600835D RID: 33629 RVA: 0x000407BC File Offset: 0x0003E9BC
		' (set) Token: 0x0600835E RID: 33630 RVA: 0x000407C6 File Offset: 0x0003E9C6
		Friend Overridable Property Label20 As Label

		' Token: 0x17003059 RID: 12377
		' (get) Token: 0x0600835F RID: 33631 RVA: 0x000407CF File Offset: 0x0003E9CF
		' (set) Token: 0x06008360 RID: 33632 RVA: 0x000407D9 File Offset: 0x0003E9D9
		Friend Overridable Property Label19 As Label

		' Token: 0x1700305A RID: 12378
		' (get) Token: 0x06008361 RID: 33633 RVA: 0x000407E2 File Offset: 0x0003E9E2
		' (set) Token: 0x06008362 RID: 33634 RVA: 0x000407EC File Offset: 0x0003E9EC
		Friend Overridable Property Label18 As Label

		' Token: 0x1700305B RID: 12379
		' (get) Token: 0x06008363 RID: 33635 RVA: 0x000407F5 File Offset: 0x0003E9F5
		' (set) Token: 0x06008364 RID: 33636 RVA: 0x000407FF File Offset: 0x0003E9FF
		Friend Overridable Property Label21 As Label

		' Token: 0x1700305C RID: 12380
		' (get) Token: 0x06008365 RID: 33637 RVA: 0x00040808 File Offset: 0x0003EA08
		' (set) Token: 0x06008366 RID: 33638 RVA: 0x0060C5E4 File Offset: 0x0060A7E4
		Private _txtSearchProduct As TextBox
		Friend Overridable Property txtSearchProduct As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSearchProduct_KeyDown
				Dim textBox As TextBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSearchProduct = value
				textBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700305D RID: 12381
		' (get) Token: 0x06008367 RID: 33639 RVA: 0x00040812 File Offset: 0x0003EA12
		' (set) Token: 0x06008368 RID: 33640 RVA: 0x0004081C File Offset: 0x0003EA1C
		Friend Overridable Property cmbSearchCat As ComboBox

		' Token: 0x1700305E RID: 12382
		' (get) Token: 0x06008369 RID: 33641 RVA: 0x00040825 File Offset: 0x0003EA25
		' (set) Token: 0x0600836A RID: 33642 RVA: 0x0060C628 File Offset: 0x0060A828
		Private _GelButton2 As Button
		Friend Overridable Property GelButton2 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click_1
				Dim button As Button = Me._GelButton2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton2 = value
				button = Me._GelButton2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700305F RID: 12383
		' (get) Token: 0x0600836B RID: 33643 RVA: 0x0004082F File Offset: 0x0003EA2F
		' (set) Token: 0x0600836C RID: 33644 RVA: 0x0060C66C File Offset: 0x0060A86C
		Private _GelButton1 As Button
		Friend Overridable Property GelButton1 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim button As Button = Me._GelButton1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton1 = value
				button = Me._GelButton1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003060 RID: 12384
		' (get) Token: 0x0600836D RID: 33645 RVA: 0x00040839 File Offset: 0x0003EA39
		' (set) Token: 0x0600836E RID: 33646 RVA: 0x0060C6B0 File Offset: 0x0060A8B0
		Private _btnWebcam As Button
		Friend Overridable Property btnWebcam As Button
			<CompilerGenerated()>
			Get
				Return Me._btnWebcam
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnWebcam_Click
				Dim button As Button = Me._btnWebcam
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnWebcam = value
				button = Me._btnWebcam
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003061 RID: 12385
		' (get) Token: 0x0600836F RID: 33647 RVA: 0x00040843 File Offset: 0x0003EA43
		' (set) Token: 0x06008370 RID: 33648 RVA: 0x0004084D File Offset: 0x0003EA4D
		Public Property POSForm As frmPOSNewTuch

		' Token: 0x06008371 RID: 33649 RVA: 0x0060C6F4 File Offset: 0x0060A8F4
		Public Sub fillCategory()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Me.cmbCategory.Items.Add("Select")
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCategory.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter("SELECT distinct RTRIM(SubCategoryName) As SubCategoryName,CategoryName,SubCategory.ID FROM SubCategory,Category where SubCategory.Category=Category.CategoryName order by 1", ModCS.cs)
				Me.subcategories = New DataTable()
				sqlDataAdapter.Fill(Me.subcategories)
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008372 RID: 33650 RVA: 0x0060C894 File Offset: 0x0060AA94
		Public Sub fillUnit()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Unit) FROM UnitMaster order by 1", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbSalesUnit.Items.Clear()
				Me.cmbPurchaseUnit.Items.Clear()
				Me.cmbAltunit.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSalesUnit.Items.Add(dataRow(0).ToString())
						Me.cmbPurchaseUnit.Items.Add(dataRow(0).ToString())
						Me.cmbAltunit.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008373 RID: 33651 RVA: 0x0060CA50 File Offset: 0x0060AC50
		Public Sub default_fillUnit_Default()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT RTRIM(Unit) as Unit, IsDefault FROM UnitMaster where isDefault=@d1"
				Me.cmd.Parameters.AddWithValue("@d1", "Yes")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Dim text As String = Me.rdr.GetValue(0).ToString()
					Dim num As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns("cmbPurchaseUnit").Index
					Me.DataGridView1.Rows(num).Cells(index).Value = text
					Dim index2 As Integer = Me.DataGridView1.Columns("cmbSalesUnit").Index
					Me.DataGridView1.Rows(num).Cells(index2).Value = text
					Dim index3 As Integer = Me.DataGridView1.Columns("cmbAltunit").Index
					Me.DataGridView1.Rows(num).Cells(index3).Value = text
				End If
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
				If flag3 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008374 RID: 33652 RVA: 0x0060CC44 File Offset: 0x0060AE44
		Public Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Me.CustomizeRowHeaders()
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("Select Top " + Me.txtTopResult.Text + " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'',(CGST+SGST) as GST,CGST,SGST,(CGST+SGST) as IGST,CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory," & vbCrLf & "Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.PID=Product_Join.ProductID order by PID desc", Me.con)
				Me.cmd.CommandTimeout = 0
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While Me.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41), Me.rdr(42), Me.rdr(43), Me.rdr(44), Me.rdr(45), Me.rdr(46), Me.rdr(47), Me.rdr(48), Me.rdr(49) })
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1)
					dataGridViewRow.Cells("cmbGST").Value = Convert.ToInt32(RuntimeHelpers.GetObjectValue(Me.rdr(15)))
				End While
				Dim flag As Boolean = Me.rdr IsNot Nothing
				If flag Then
					Me.rdr.Close()
				End If
				Me.con.Close()
				Me.DataGridView1.ClearSelection()
				RemoveHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
				AddHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
				Me.DataGridView1.Columns(1).Frozen = True
				Me.DataGridView1.Columns(2).Frozen = True
				Me.DataGridView1.Columns(3).Frozen = True
				Me.DataGridView1.Columns(4).Frozen = True
				Me.DataGridView1.Columns(5).Frozen = True
				Me.DataGridView1.Columns(49).Frozen = True
				Dim num As Integer = 7
				Do
					Me.DataGridView1.Columns(num).Frozen = False
					num += 1
				Loop While num <= 48
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008375 RID: 33653 RVA: 0x0060D20C File Offset: 0x0060B40C
		Public Sub Getdata_variant(Id As Short, strBarcode As String)
			Try
				Me.Label14.Text = Conversions.ToString(CInt(Id))
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Me.CustomizeRowHeaders()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand(vbCrLf & "Select PID, RTRIM(ProductCode) as ProductCode, RTRIM(Productname) as Productname, " & vbCrLf & "                RTRIM(CategoryName) as CategoryName, '' as Col4, RTRIM(SubCategoryName) as SubCategoryName, '' as Col6," & vbCrLf & "                SubCategoryID, RTRIM(HSNCode) as HSNCode, RTRIM(PartNo) as PartNo, RTRIM(Description) As Description," & vbCrLf & "                CostPrice, SellingPrice, Discount, '' as Col14, (CGST+SGST) as GST, CGST, SGST, (CGST+SGST) as IGST," & vbCrLf & "                CESS, ReorderPoint, RTRIM(Product.Barcode) as Barcode, OpeningStock, RTRIM(PurchaseUnit) as PurchaseUnit," & vbCrLf & "                RTRIM(Salesunit) as SalesUnit, RTRIM(SalesAltUnit) as SalesAltUnit, RTRIM(Conv) as Conv, RTRIM(MinStock) as MinStock," & vbCrLf & "                Product.MRP, RTRIM(Product.Status) as Status, Product.STax, Product.PTax, RTRIM(Product.GDown) as GDown," & vbCrLf & "                RTRIM(Product.Rack) as Rack, Product.DefQty, Temp_Stock.Qty as txtOpeningStock2, RTRIM(Temp_Stock.Barcode) as TempBarcode," & vbCrLf & "                Temp_Stock.MRP, Temp_Stock.SPrice, Temp_Stock.WPrice, RTRIM(Temp_Stock.Batch) as Batch, Temp_Stock.Mfgdate," & vbCrLf & "                Temp_Stock.Expdate, RTRIM(Temp_Stock.Size) as Size, RTRIM(Temp_Stock.Colour) as Colour, RTRIM(Product.Kitchen) as Kitchen," & vbCrLf & "                temp_Stock.IMEI1, temp_Stock.IMEI2, Photo, Temp_Stock.StLimit, Temp_Stock.SalePrice, Temp_Stock.WSalePrice, Temp_Stock.PPrice, Temp_Stock.EPPrice, Temp_Stock.QrBarcode, Temp_Stock.SalesManPur" & vbCrLf & "                from Category, SubCategory, Product, Temp_Stock, Product_Join " & vbCrLf & "                where Category.CategoryName = SubCategory.Category and Product.SubCategoryID = SubCategory.ID " & vbCrLf & "                and Temp_Stock.ProductID = Product.PID and Product.PID = Product_Join.ProductID " & vbCrLf & "                and Temp_Stock.Variant_id = @Id order by PID ASC", sqlConnection)
					sqlCommand.Parameters.AddWithValue("@Id", Id)
					sqlCommand.CommandTimeout = 0
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
					sqlDataAdapter.Fill(Me.dt)
					Me.DataGridView2.DataSource = Nothing
					Me.DataGridView2.Rows.Clear()
					Dim flag As Boolean = Me.dt.Rows.Count > 0
					If flag Then
						Try
							For Each obj As Object In Me.dt.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Me.DataGridView2.Rows.Add(dataRow.ItemArray)
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End If
					Me.DataGridView2.ClearSelection()
					RemoveHandler Me.DataGridView2.KeyDown, AddressOf Me.DataGridView2_KeyDown
					AddHandler Me.DataGridView2.KeyDown, AddressOf Me.DataGridView2_KeyDown
					Me.DataGridView2.Rows(1).Cells("CostPrice").Value = Me.DataGridView2.Rows(0).Cells("CostPrice").Value.ToString()
					Dim index As Integer = Me.DataGridView2.Columns("txtOpeningStock2").Index
					Me.initialQty = Decimal.Parse(Me.DataGridView2.Rows(0).Cells("txtOpeningStock2").Value.ToString())
					Dim flag2 As Boolean = Me.DataGridView2.CurrentRow IsNot Nothing
					If flag2 Then
						' The following expression was wrapped in a checked-expression
						Dim num As Integer = Me.DataGridView2.CurrentRow.Index + 1
						Dim flag3 As Boolean = num < Me.DataGridView2.Rows.Count
						If flag3 Then
							Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(num).Cells(index)
							Me.DataGridView2.BeginEdit(True)
						End If
					End If
				End Using
				Dim flag4 As Boolean = Me.dt.Rows.Count = 1
				If flag4 Then
					Me.GelButton1.Enabled = True
				Else
					Me.GelButton1.Enabled = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Me.Cursor = Cursors.[Default]
				Me.Timer1.Enabled = False
			End Try
		End Sub

		' Token: 0x06008376 RID: 33654 RVA: 0x0060D580 File Offset: 0x0060B780
		Private Sub CustomizeRowHeaders()
			Me.DataGridView1.Columns("ProductName").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("ProductName").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("ProductName").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("cmbCategory").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("cmbCategory").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("cmbCategory").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("cmbSubCategory").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("cmbSubCategory").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("cmbSubCategory").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtPartNo").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtPartNo").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtPartNo").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtCostPrice").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtCostPrice").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtCostPrice").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("cmbGST").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("cmbGST").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("cmbGST").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtMinStock").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtMinStock").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtMinStock").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("cmbPurchaseUnit").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("cmbPurchaseUnit").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("cmbPurchaseUnit").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtSaleQty").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtSaleQty").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtSaleQty").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtBarcode_TempStock").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtBarcode_TempStock").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtBarcode_TempStock").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
		End Sub

		' Token: 0x06008377 RID: 33655 RVA: 0x0060DAE8 File Offset: 0x0060BCE8
		Private Sub ComboBox1_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 3
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 2
			Else
				Dim flag2 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 5
				If flag2 Then
					Dim flag3 As Boolean = Operators.CompareString(Me.DataGridView1.Columns(editingControlDataGridView.CurrentCell.ColumnIndex).Name, "cmbSubCategory", False) = 0
					If flag3 Then
						num = editingControlDataGridView.CurrentCell.ColumnIndex
					End If
				End If
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.BeginEdit(True)
			comboBox.Focus()
		End Sub

		' Token: 0x06008378 RID: 33656 RVA: 0x0060DBC4 File Offset: 0x0060BDC4
		Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Dim dataGridView As DataGridView = CType(sender, DataGridView)
					e.Handled = True
					Dim flag2 As Boolean = dataGridView.CurrentCell.ColumnIndex < dataGridView.ColumnCount - 1
					If flag2 Then
						Dim flag3 As Boolean = dataGridView.CurrentCell.ColumnIndex = 3
						If flag3 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 2, dataGridView.CurrentCell.RowIndex)
						Else
							Dim flag4 As Boolean = dataGridView.CurrentCell.ColumnIndex = 5
							If flag4 Then
								dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 6, dataGridView.CurrentCell.RowIndex)
							Else
								Dim flag5 As Boolean = dataGridView.CurrentCell.ColumnIndex = 29
								If flag5 Then
									dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 6, dataGridView.CurrentCell.RowIndex)
								Else
									Dim rowIndex As Integer = dataGridView.CurrentCell.RowIndex
									Dim num As Integer = dataGridView.CurrentCell.ColumnIndex
									While num < dataGridView.ColumnCount AndAlso Not dataGridView.Columns(num).Visible
										num += 1
									End While
									dataGridView.CurrentCell = dataGridView(num, rowIndex)
									dataGridView.BeginEdit(True)
								End If
							End If
						End If
					Else
						Dim flag6 As Boolean = dataGridView.CurrentCell.RowIndex < dataGridView.RowCount - 1
						If flag6 Then
							dataGridView.CurrentCell = dataGridView(0, dataGridView.CurrentCell.RowIndex + 1)
						End If
					End If
					Dim rowIndex2 As Integer = Me.DataGridView1.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
					Dim flag7 As Boolean = TypeOf dataGridView.CurrentCell Is DataGridViewButtonCell
					If flag7 Then
						Dim name As String = dataGridView.CurrentCell.OwningColumn.Name
						If Operators.CompareString(name, "InsertButtonColumn", False) = 0 Then
							Me.DataGridView1_CellContentClick(Me.DataGridView1, New DataGridViewCellEventArgs(columnIndex, rowIndex2))
						End If
					Else
						dataGridView.BeginEdit(True)
					End If
				End If
				Dim flag8 As Boolean = e.KeyCode = Keys.Left
				If flag8 Then
					Dim flag9 As Boolean = Not(TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell)
					If flag9 Then
						e.Handled = True
						Dim flag10 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex > 0
						If flag10 Then
							Me.DataGridView1.CurrentCell = Me.DataGridView1(Me.DataGridView1.CurrentCell.ColumnIndex - 1, Me.DataGridView1.CurrentCell.RowIndex)
						End If
						Me.DataGridView1.BeginEdit(True)
						e.SuppressKeyPress = True
					End If
				Else
					Dim flag11 As Boolean = e.KeyCode = Keys.Right
					If flag11 Then
						Dim flag12 As Boolean = Not(TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell)
						If flag12 Then
							e.Handled = True
							Dim flag13 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex < Me.DataGridView1.ColumnCount - 1
							If flag13 Then
								Me.DataGridView1.CurrentCell = Me.DataGridView1(Me.DataGridView1.CurrentCell.ColumnIndex + 1, Me.DataGridView1.CurrentCell.RowIndex)
							End If
							Me.DataGridView1.BeginEdit(True)
							e.SuppressKeyPress = True
						End If
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008379 RID: 33657 RVA: 0x0060DF74 File Offset: 0x0060C174
		Private Sub ComboBox_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim comboBox As ComboBox = CType(sender, ComboBox)
				Dim text As String = comboBox.Text.Trim()
				Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(Me.DataGridView1.EditingControl, DataGridViewComboBoxEditingControl)
				Dim flag2 As Boolean = Not dataGridViewComboBoxEditingControl.Items.Contains(text)
				If flag2 Then
					dataGridViewComboBoxEditingControl.Items.Add(text)
				End If
				Me.DataGridView1.CurrentCell.Value = text
				Me.DataGridView1.EndEdit()
				Dim flag3 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex < Me.DataGridView1.Columns.Count - 1
				If flag3 Then
					Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells(Me.DataGridView1.CurrentCell.ColumnIndex + 1)
				End If
			End If
		End Sub

		' Token: 0x0600837A RID: 33658 RVA: 0x0060E070 File Offset: 0x0060C270
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x0600837B RID: 33659 RVA: 0x00040856 File Offset: 0x0003EA56
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x0600837C RID: 33660 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub RetrieveData()
		End Sub

		' Token: 0x0600837D RID: 33661 RVA: 0x0060E098 File Offset: 0x0060C298
		Public Sub Reset()
			Me.txtProductName.Text = ""
			Me.txtCategory.Text = ""
			Me.ComboBox2.Text = ""
			Me.txtBarcode.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.cmbGDown.SelectedIndex = -1
			Me.cmbRack.SelectedIndex = -1
			Me.txtTopResult.Text = "10"
			Me.DataGridView1.Rows.Clear()
			Me.DataGridView1.ClearSelection()
			Me.btnShowAll.Focus()
		End Sub

		' Token: 0x0600837E RID: 33662 RVA: 0x00040860 File Offset: 0x0003EA60
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600837F RID: 33663 RVA: 0x0060E14C File Offset: 0x0060C34C
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView1.Columns
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
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
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

		' Token: 0x06008380 RID: 33664 RVA: 0x0060E3F8 File Offset: 0x0060C5F8
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " " & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & "Temp_Stock.Barcode like N'", Me.txtBarcode.Text, "%' order by PID desc" }), Me.con)
					Me.cmd.CommandTimeout = 0
					Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While Me.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41), Me.rdr(42), Me.rdr(43), Me.rdr(44), Me.rdr(45), Me.rdr(46), Me.rdr(47), Me.rdr(48), Me.rdr(49) })
					End While
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008381 RID: 33665 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06008382 RID: 33666 RVA: 0x0060E890 File Offset: 0x0060CA90
		Private Sub txtProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & " ProductName like N'", Me.txtProductName.Text, "%' order by PID desc" }), Me.con)
					Me.cmd.CommandTimeout = 0
					Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While Me.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41), Me.rdr(42), Me.rdr(43), Me.rdr(44), Me.rdr(45), Me.rdr(46), Me.rdr(47), Me.rdr(48), Me.rdr(49) })
					End While
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008383 RID: 33667 RVA: 0x0060ED28 File Offset: 0x0060CF28
		Private Sub txtCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " " & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & " SubCategory.Category like N'", Me.txtCategory.Text, "%' order by PID desc" }), Me.con)
					Me.cmd.CommandTimeout = 0
					Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While Me.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41), Me.rdr(42), Me.rdr(43), Me.rdr(44), Me.rdr(45), Me.rdr(46), Me.rdr(47), Me.rdr(48), Me.rdr(49) })
					End While
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008384 RID: 33668 RVA: 0x0060F1C0 File Offset: 0x0060D3C0
		Private Sub txtSubCategory_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " " & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & " SubCategory.SubCategoryName like N'", Me.ComboBox2.Text, "%' order by PID desc" }), Me.con)
					Me.cmd.CommandTimeout = 0
					Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While Me.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41), Me.rdr(42), Me.rdr(43), Me.rdr(44), Me.rdr(45), Me.rdr(46), Me.rdr(47), Me.rdr(48), Me.rdr(49) })
					End While
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
					Me.con.Close()
				End If
				Me.DataGridView1.ClearSelection()
				RemoveHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
				AddHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
				Me.DataGridView1.Columns(1).Frozen = True
				Me.DataGridView1.Columns(2).Frozen = True
				Me.DataGridView1.Columns(3).Frozen = True
				Me.DataGridView1.Columns(4).Frozen = True
				Me.DataGridView1.Columns(5).Frozen = True
				Me.DataGridView1.Columns(6).Frozen = True
				Dim num As Integer = 7
				Do
					Me.DataGridView1.Columns(num).Frozen = False
					num += 1
				Loop While num <= 48
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008385 RID: 33669 RVA: 0x0060F74C File Offset: 0x0060D94C
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTrim(ProductCode), RTrim(ProductName)," & vbCrLf & "RTrim(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint, RTrim(Product.Barcode), OpeningStock, RTrim(PurchaseUnit), RTrim(Salesunit), RTrim(SalesAltUnit), RTrim(Conv), RTrim(MinStock), (Product.MRP), RTrim(Product.Status)," & vbCrLf & "(Product.STax), (Product.PTax), RTrim(Product.GDown), RTrim(Product.Rack), (Product.DefQty), Temp_Stock.Qty, RTrim(Temp_Stock.Barcode), (Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice), (Temp_Stock.WPrice), RTrim(Temp_Stock.Batch), (Temp_Stock.Mfgdate), (Temp_Stock.Expdate), RTrim(Temp_Stock.Size)," & vbCrLf & "RTrim(Temp_Stock.Colour), RTrim(Product.Kitchen), temp_Stock.IMEI1, temp_Stock.IMEI2, Photo from Category, SubCategory, Product, Temp_Stock, Product_Join where Category.CategoryName=SubCategory.Category And" & vbCrLf & " Product.SubCategoryID = SubCategory.ID And" & vbCrLf & vbCrLf & " Temp_Stock.ProductID = Product.PID And" & vbCrLf & " Product.PID = Product_Join.ProductID And" & vbCrLf & "PartNo Like N'", Me.TextBox1.Text, "%' order by PID desc" }), Me.con)
					Me.cmd.CommandTimeout = 0
					Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While Me.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41), Me.rdr(42), Me.rdr(43), Me.rdr(44), Me.rdr(45), Me.rdr(46), Me.rdr(47), Me.rdr(48), Me.rdr(49) })
					End While
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
					Me.con.Close()
				End If
				Me.DataGridView1.ClearSelection()
				RemoveHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
				AddHandler Me.DataGridView1.KeyDown, AddressOf Me.DataGridView1_KeyDown
				Me.DataGridView1.Columns(1).Frozen = True
				Me.DataGridView1.Columns(2).Frozen = True
				Me.DataGridView1.Columns(3).Frozen = True
				Me.DataGridView1.Columns(4).Frozen = True
				Me.DataGridView1.Columns(5).Frozen = True
				Me.DataGridView1.Columns(6).Frozen = True
				Dim num As Integer = 7
				Do
					Me.DataGridView1.Columns(num).Frozen = False
					num += 1
				Loop While num <= 48
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008386 RID: 33670 RVA: 0x0060FCD8 File Offset: 0x0060DED8
		Public Sub FillCompany()
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text As String = "Select RTRIM(CompanyName) from Company"
			Me.cmd = New SqlCommand(text, Me.con)
			Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr.Read()
			If flag Then
				Me.txtCompany.Text = Me.rdr.GetString(0)
			End If
			Dim flag2 As Boolean = Me.rdr IsNot Nothing
			If flag2 Then
				Me.rdr.Close()
			End If
			Me.con.Close()
		End Sub

		' Token: 0x06008387 RID: 33671 RVA: 0x0060FD80 File Offset: 0x0060DF80
		Private Sub txtSearchProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.getgriditemdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008388 RID: 33672 RVA: 0x0060FDDC File Offset: 0x0060DFDC
		Private Sub getgriditemdata()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim flag As Boolean = Me.cmbSearchCat.SelectedIndex = 0
				If flag Then
					Me.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & " ProductName like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
				Else
					Dim flag2 As Boolean = Me.cmbSearchCat.SelectedIndex = 1
					If flag2 Then
						Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " " & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & " SubCategory.SubCategoryName like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
					Else
						Dim flag3 As Boolean = Me.cmbSearchCat.SelectedIndex = 2
						If flag3 Then
							Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " " & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & " SubCategory.Category like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
						Else
							Dim flag4 As Boolean = Me.cmbSearchCat.SelectedIndex = 3
							If flag4 Then
								Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " " & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & "Temp_Stock.Barcode like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
							Else
								Dim flag5 As Boolean = Me.cmbSearchCat.SelectedIndex = 4
								If flag5 Then
									Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTrim(ProductCode), RTrim(ProductName)," & vbCrLf & "RTrim(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint, RTrim(Product.Barcode), OpeningStock, RTrim(PurchaseUnit), RTrim(Salesunit), RTrim(SalesAltUnit), RTrim(Conv), RTrim(MinStock), (Product.MRP), RTrim(Product.Status)," & vbCrLf & "(Product.STax), (Product.PTax), RTrim(Product.GDown), RTrim(Product.Rack), (Product.DefQty), Temp_Stock.Qty, RTrim(Temp_Stock.Barcode), (Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice), (Temp_Stock.WPrice), RTrim(Temp_Stock.Batch), (Temp_Stock.Mfgdate), (Temp_Stock.Expdate), RTrim(Temp_Stock.Size)," & vbCrLf & "RTrim(Temp_Stock.Colour), RTrim(Product.Kitchen), temp_Stock.IMEI1, temp_Stock.IMEI2, Photo from Category, SubCategory, Product, Temp_Stock, Product_Join where Category.CategoryName=SubCategory.Category And" & vbCrLf & " Product.SubCategoryID = SubCategory.ID And" & vbCrLf & vbCrLf & " Temp_Stock.ProductID = Product.PID And" & vbCrLf & " Product.PID = Product_Join.ProductID And" & vbCrLf & "PartNo Like N'", Me.TextBox1.Text, "%' order by PID desc" }), Me.con)
								Else
									Me.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                    RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "(Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "(Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & " Product.SubCategoryID=SubCategory.ID and" & vbCrLf & " Temp_Stock.ProductID=Product.PID and " & vbCrLf & " Product.PID=Product_Join.ProductID and" & vbCrLf & " ProductName like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
								End If
							End If
						End If
					End If
				End If
				Dim sqlDataReader As SqlDataReader = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While sqlDataReader.Read()
					Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16), sqlDataReader(17), sqlDataReader(18), sqlDataReader(19), sqlDataReader(20), sqlDataReader(21), sqlDataReader(22), sqlDataReader(23), sqlDataReader(24), sqlDataReader(25), sqlDataReader(26), sqlDataReader(27), sqlDataReader(28), sqlDataReader(29), sqlDataReader(30), sqlDataReader(31), sqlDataReader(32), sqlDataReader(33), sqlDataReader(34), sqlDataReader(35), sqlDataReader(36), sqlDataReader(37), sqlDataReader(38), sqlDataReader(39), sqlDataReader(40), sqlDataReader(41), sqlDataReader(42), sqlDataReader(43), sqlDataReader(44), sqlDataReader(45), sqlDataReader(46), sqlDataReader(47), sqlDataReader(48), sqlDataReader(49) })
				End While
				Dim flag6 As Boolean = sqlDataReader IsNot Nothing
				If flag6 Then
					sqlDataReader.Close()
				End If
				Me.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008389 RID: 33673 RVA: 0x000EE848 File Offset: 0x000ECA48
		Public Sub CheckAllResourceImages()
			Dim list As List(Of String) = New List(Of String)()
			Dim resourceSet As ResourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, True, True)
			For Each obj As Object In resourceSet
				Dim dictionaryEntry As DictionaryEntry = If((obj IsNot Nothing), CType(obj, DictionaryEntry), Nothing)
				Dim text As String = dictionaryEntry.Key.ToString()
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dictionaryEntry.Value)
				Dim flag As Boolean = TypeOf objectValue Is Bitmap OrElse TypeOf objectValue Is Image
				If flag Then
					Try
						Using CType(objectValue, Image)
						End Using
					Catch ex As Exception
						list.Add(text)
					End Try
				End If
			Next
			Dim flag2 As Boolean = list.Count > 0
			If flag2 Then
				MessageBox.Show("Corrupt Images Found: " + String.Join(", ", list))
			Else
				MessageBox.Show("All images are valid.")
			End If
		End Sub

		' Token: 0x0600838A RID: 33674 RVA: 0x00610344 File Offset: 0x0060E544
		Private Sub frmProductRecord_Load(sender As Object, e As EventArgs)
			MyBase.KeyPreview = True
			Me.GetApiDtl()
			Me.btnShowAll.Focus()
			Me.txtProductName.Text = ""
			Me.txtCategory.Text = ""
			Me.ComboBox2.Text = ""
			Me.txtBarcode.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.DataGridView1.Rows.Clear()
			Me.FillCompany()
			Me.fillGdown()
			Me.fillRack()
			AddHandler Me.DataGridView1.DataError, AddressOf Me.DataGridView1_DataError
			Me.DataGridView1.AutoGenerateColumns = False
			Me.auto()
			Me.GenerateBarcode()
			AddHandler Me.DataGridView1.CellBeginEdit, AddressOf Me.DataGridView1_CellBeginEdit
			Me.DataforNP()
			Me.fillCategory()
			Me.FillSubCat()
			Me.fillUnit()
			Me.fillTaxRate()
			Me.fillProductID()
			Me.fillGdown()
			Me.fillRack()
			Me.BarcodeRemoveAll()
			Me.SetupDataGridViewColumns()
			Me.Getdata()
			Me.default_fill_tax()
			Me.default_fill_Category_data()
			Me.default_fillUnit_Default()
			Me.Convert_Language()
			Dim flag As Boolean = Operators.CompareString(frmProductRec.strForm, "POSNewTuch", False) = 0
			If flag Then
				Me.GelButtonNewRecord.PerformClick()
			End If
		End Sub

		' Token: 0x0600838B RID: 33675 RVA: 0x006104C0 File Offset: 0x0060E6C0
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

		' Token: 0x0600838C RID: 33676 RVA: 0x00610638 File Offset: 0x0060E838
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

		' Token: 0x0600838D RID: 33677 RVA: 0x00610704 File Offset: 0x0060E904
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

		' Token: 0x0600838E RID: 33678 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600838F RID: 33679 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06008390 RID: 33680 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06008391 RID: 33681 RVA: 0x006107D0 File Offset: 0x0060E9D0
		Private Sub BarcodeRemoveAll()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = "delete from GenerateBarcode"
				Me.cmd = New SqlCommand(text)
				Me.cmd.Connection = Me.con
				Me.cmd.ExecuteNonQuery()
				Me.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008392 RID: 33682 RVA: 0x0061085C File Offset: 0x0060EA5C
		Private Sub DataforNP()
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Close()
			Me.CurrentRow = 0
			Me.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Product", Me.con)
			Me.Dad.Fill(Me.Dst, "Product")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Product").Rows(Conversions.ToInteger(Me.CurrentRow))("PID"))
				Me.con.Close()
			Catch ex As Exception
			End Try
			Me.con.Close()
		End Sub

		' Token: 0x06008393 RID: 33683 RVA: 0x0061094C File Offset: 0x0060EB4C
		Public Sub fillTaxRate()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Rate) FROM TaxCat order by Rate ASC", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbGST.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbGST.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008394 RID: 33684 RVA: 0x00610A94 File Offset: 0x0060EC94
		Public Sub default_Tax_type()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT * FROM Defaulttaxtype WHERE id = @d1"
				Me.cmd.Parameters.AddWithValue("@d1", "1")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Me.strStax = Me.rdr.GetValue(1).ToString()
					Me.strPtax = Me.rdr.GetValue(2).ToString()
					Dim num As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns("cmbSalesTaxType").Index
					Me.DataGridView1.Rows(num).Cells(index).Value = Me.strStax
					Dim index2 As Integer = Me.DataGridView1.Columns("cmbPurchaseTaxType").Index
					Me.DataGridView1.Rows(num).Cells(index2).Value = Me.strPtax
				End If
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
				If flag3 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008395 RID: 33685 RVA: 0x00610C6C File Offset: 0x0060EE6C
		Public Sub default_fill_tax()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT RTRIM(Rate),RTRIM(IsDefault) from TaxCat where IsDefault=@d1"
				Me.cmd.Parameters.AddWithValue("@d1", "Yes")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Dim text As String = Me.rdr.GetValue(0).ToString()
					Dim num As Decimal
					Dim flag2 As Boolean = Not Decimal.TryParse(text, num)
					If flag2 Then
						MessageBox.Show("Invalid rate value! '" + text + "'", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
					Dim text2 As String = Me.rdr.GetValue(1).ToString()
					Dim dataRow As DataRow = Me.dtable.NewRow()
					dataRow("Column1") = text
					Dim num2 As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns("cmbGST").Index
					Me.DataGridView1.Rows(num2).Cells(index).Value = text
					Dim index2 As Integer = Me.DataGridView1.Columns("txtCGST").Index
					Me.DataGridView1.Rows(num2).Cells(index2).Value = Conversions.ToDouble(text) / 2.0
					Dim index3 As Integer = Me.DataGridView1.Columns("txtSGST").Index
					Me.DataGridView1.Rows(num2).Cells(index3).Value = Conversions.ToDouble(text) / 2.0
					Dim index4 As Integer = Me.DataGridView1.Columns("txtIGST").Index
					Me.DataGridView1.Rows(num2).Cells(index4).Value = text
				End If
				Dim flag3 As Boolean = Me.rdr IsNot Nothing
				If flag3 Then
					Me.rdr.Close()
				End If
				Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
				If flag4 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008396 RID: 33686 RVA: 0x00610F30 File Offset: 0x0060F130
		Public Sub default_fill_Category_data()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT ID, RTRIM(SubCategoryName) As SubCategoryName, RTRIM(Category) as CategoryName from SubCategory where isDefault=@d1"
				Me.cmd.Parameters.AddWithValue("@d1", "Yes")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Dim text As String = Me.rdr.GetValue(0).ToString()
					Dim text2 As String = Me.rdr.GetValue(1).ToString()
					Dim text3 As String = Me.rdr.GetValue(2).ToString()
					Dim num As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns("txtSubCategoryID").Index
					Me.DataGridView1.Rows(num).Cells(index).Value = text
					Dim index2 As Integer = Me.DataGridView1.Columns("cmbCategory").Index
					Me.DataGridView1.Rows(num).Cells(index2).Value = text3
					Dim index3 As Integer = Me.DataGridView1.Columns("cmbSubCategory").Index
					Me.DataGridView1.Rows(num).Cells(index3).Value = text2
				End If
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
				If flag3 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008397 RID: 33687 RVA: 0x00611150 File Offset: 0x0060F350
		Public Sub fillDefaultTaxRate()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT RTRIM(Rate),RTRIM(IsDefault) from TaxCat where IsDefault=@d1"
				Me.cmd.Parameters.AddWithValue("@d1", "Yes")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Dim text As String = Me.rdr.GetValue(0).ToString()
					Dim text2 As String = Me.rdr.GetValue(1).ToString()
					Dim num As Integer = 0
					Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(num).Cells("cmbGST"), DataGridViewComboBoxCell)
					Dim num2 As Integer = dataGridViewComboBoxCell.Items.IndexOf(text)
					Dim flag2 As Boolean = num2 >= 0
					If flag2 Then
						dataGridViewComboBoxCell.Value = RuntimeHelpers.GetObjectValue(dataGridViewComboBoxCell.Items(num2))
					End If
				End If
				Dim flag3 As Boolean = Me.rdr IsNot Nothing
				If flag3 Then
					Me.rdr.Close()
				End If
				Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
				If flag4 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008398 RID: 33688 RVA: 0x006112E8 File Offset: 0x0060F4E8
		Private Function GenerateID1() As String
			Me.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT TOP 1 ID FROM Product_OpeningStock ORDER BY ID DESC", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = Me.rdr.HasRows
				If hasRows Then
					Me.rdr.Read()
					text = Conversions.ToString(Me.rdr("ID"))
				End If
				Me.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
				Dim flag4 As Boolean = Me.rdr IsNot Nothing
				If flag4 Then
					Me.rdr.Close()
				End If
				Me.con.Close()
			Catch ex As Exception
				Dim flag5 As Boolean = Me.con.State = ConnectionState.Open
				If flag5 Then
					Me.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06008399 RID: 33689 RVA: 0x00611494 File Offset: 0x0060F694
		Public Sub GenerateBarcode()
			Try
				Me.BCodeDisplay()
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600839A RID: 33690 RVA: 0x00611518 File Offset: 0x0060F718
		Public Sub BCodeDisplay()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim sqlCommand As SqlCommand = Me.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(BCode) FROM Company"
				sqlCommand.Parameters.Clear()
				Me.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtBar.Text = Me.rdr.GetValue(0).ToString()
				Else
					Me.txtBar.Text = ""
				End If
				Dim flag3 As Boolean = Me.rdr IsNot Nothing
				If flag3 Then
					Me.rdr.Close()
				End If
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600839B RID: 33691 RVA: 0x00611618 File Offset: 0x0060F818
		Public Sub ScrollToSelectedCell(rowIndex As Short, colIndex As Short)
			Me.DataGridView1.FirstDisplayedScrollingRowIndex = CInt(rowIndex)
			Me.DataGridView1.FirstDisplayedScrollingColumnIndex = CInt(colIndex)
			Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(CInt(rowIndex)).Cells(CInt(colIndex))
		End Sub

		' Token: 0x0600839C RID: 33692 RVA: 0x00611668 File Offset: 0x0060F868
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("variantName").Index AndAlso e.RowIndex >= 0
			If flag Then
				Me.dt.Clear()
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Me.id = Conversions.ToShort(dataGridViewRow.Cells("variant_id").Value)
				Me.strBarcode = dataGridViewRow.Cells("txtBarcode_TempStock").Value.ToString()
				Me.Label13.Text = dataGridViewRow.Cells("txtOpeningStock").Value.ToString()
				Dim flag2 As Boolean = (Me.id > 0S) And (Operators.CompareString(Me.strBarcode, "", False) <> 0)
				If flag2 Then
					Me.pnlVariant.Visible = True
					Me.DataGridView2.Visible = True
					Me.Getdata_variant(Me.id, Me.strBarcode)
				Else
					Me.pnlVariant.Visible = False
					Me.DataGridView2.Visible = False
					MessageBox.Show("Datat not found!")
				End If
			End If
			Dim flag3 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnAddCategory").Index AndAlso e.RowIndex >= 0
			If flag3 Then
				MyProject.Forms.frmCategory.lblSource.Text = "ProductRec"
				MyProject.Forms.frmCategory.Reset()
				MyProject.Forms.frmCategory.ShowDialog()
				MyProject.Forms.frmCategory.Dispose()
			End If
			Dim flag4 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnAddSubCategory").Index AndAlso e.RowIndex >= 0
			If flag4 Then
				MyProject.Forms.frmSubCategory.lblSource.Text = "ProductRec"
				MyProject.Forms.frmSubCategory.lblCurrentCellIndex.Text = Conversions.ToString(e.RowIndex)
				MyProject.Forms.frmSubCategory.Reset()
				MyProject.Forms.frmSubCategory.ShowDialog()
				MyProject.Forms.frmSubCategory.Dispose()
			End If
			Dim flag5 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnAddGSTPer").Index AndAlso e.RowIndex >= 0
			If flag5 Then
				MyProject.Forms.frmTaxCategory.lblSource.Text = "ProductRec"
				MyProject.Forms.frmTaxCategory.Reset()
				MyProject.Forms.frmTaxCategory.ShowDialog()
				MyProject.Forms.frmTaxCategory.Dispose()
			End If
			Dim flag6 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("UpdateButtonColumn").Index AndAlso e.RowIndex >= 0
			If flag6 Then
				Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Me.txtID_Update.Text = dataGridViewRow2.Cells(1).Value.ToString().Substring(dataGridViewRow2.Cells(1).Value.ToString().LastIndexOf("-") + 1)
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = If(("Update Product Set Productname=@d2, SubCategoryID=@d3, Description=@d4, CostPrice=@d5, Discount=@d7, CGST=@d8, Barcode=@d10, ProductCode=@d1, PurchaseUnit=@d12,SalesUnit=@d13,SGST=@d14,HSNCode=@d15,PartNo=@d16,Cess=@d17,SalesAltUnit=@d18,Conv=@d19,MinStock=@d20,Status=@d22,STax=@d23,PTax=@d24,GDown=@d25,Rack=@d26,MRP=@d27,SellingPrice=@d28,ReorderPoint=@d29,DefQty=@d30,Kitchen=@d31 where PID=" + Conversions.ToString(Conversion.Val(Me.txtID_Update.Text))), "")
				Me.cmd = New SqlCommand(text)
				Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells("ProductName").Value.ToString())
				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow2.Cells("txtSubCategoryID").Value.ToString()))
				Dim flag7 As Boolean = dataGridViewRow2.Cells("txtFeatures").Value IsNot Nothing
				If flag7 Then
					Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtFeatures").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d4", dataGridViewRow2.Cells("ProductName").Value.ToString())
				End If
				Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow2.Cells("txtCostPrice").Value.ToString()))
				Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow2.Cells("txtDiscount").Value.ToString()))
				Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow2.Cells("txtCGST").Value.ToString()))
				Me.cmd.Parameters.AddWithValue("@d10", "0")
				Me.cmd.Parameters.AddWithValue("@d1", dataGridViewRow2.Cells("ProductCode").Value.ToString())
				Me.cmd.Parameters.AddWithValue("@d12", dataGridViewRow2.Cells("cmbPurchaseUnit").Value.ToString())
				Me.cmd.Parameters.AddWithValue("@d13", dataGridViewRow2.Cells("cmbSalesUnit").Value.ToString())
				Me.cmd.Parameters.AddWithValue("@d14", Conversion.Val(dataGridViewRow2.Cells("txtSGST").Value.ToString()))
				Me.cmd.Parameters.AddWithValue("@d15", dataGridViewRow2.Cells("txtHSNCode").Value.ToString())
				Me.cmd.Parameters.AddWithValue("@d16", dataGridViewRow2.Cells("txtPartNo").Value.ToString())
				Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(dataGridViewRow2.Cells("txtCESS").Value.ToString()))
				Me.cmd.Parameters.AddWithValue("@d18", dataGridViewRow2.Cells("cmbAltunit").Value.ToString())
				Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow2.Cells("Conv").Value.ToString()))
				Me.cmd.Parameters.AddWithValue("@d20", Conversion.Val(dataGridViewRow2.Cells("txtMinStock").Value.ToString()))
				Me.cmd.Parameters.AddWithValue("@d22", "Yes")
				Me.cmd.Parameters.AddWithValue("@d23", dataGridViewRow2.Cells("cmbSalesTaxType").Value.ToString())
				Me.cmd.Parameters.AddWithValue("@d24", dataGridViewRow2.Cells("cmbPurchaseTaxType").Value.ToString())
				Dim flag8 As Boolean = dataGridViewRow2.Cells("ddlGDown").Value IsNot Nothing
				If flag8 Then
					Me.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("ddlGDown").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d25", "")
				End If
				Dim flag9 As Boolean = dataGridViewRow2.Cells("ddlGDown").Value IsNot Nothing
				If flag9 Then
					Me.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("ddlRack").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d26", "")
				End If
				Me.cmd.Parameters.AddWithValue("@d27", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtDefMRP").Value)))
				Me.cmd.Parameters.AddWithValue("@d28", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtRSP").Value)))
				Me.cmd.Parameters.AddWithValue("@d29", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtWSP").Value)))
				Dim flag10 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells("txtSaleQty").Value, "", False), Operators.CompareObjectEqual(dataGridViewRow2.Cells("txtSaleQty").Value, "0", False)))
				If flag10 Then
					Me.cmd.Parameters.AddWithValue("@d30", "1")
				Else
					Me.cmd.Parameters.AddWithValue("@d30", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtSaleQty").Value))
				End If
				Me.cmd.Parameters.AddWithValue("@d31", "")
				Me.cmd.Connection = Me.con
				Me.cmd.ExecuteNonQuery()
				Me.con.Close()
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text2 As String = "Update Temp_Stock Set SalePrice=@d2, WSalePrice=@d3, StLimit=@d4, MRP=@d5, SPrice=@d6, PPrice=@d7, EPPrice=@d8,Batch=@d9,Mfgdate=@d10,Expdate=@d11,Size=@d12,Colour=@d13,IMEI1=@d14,IMEI2=@d15,WPrice=@d16 where ProductID=@d1"
				Me.cmd = New SqlCommand(text2)
				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
				Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtRSP").Value)))
				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtWSP").Value)))
				Me.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtMinStock").Value)))
				Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtDefMRP").Value)))
				Me.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtRSP").Value)))
				Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow2.Cells("txtCostPrice").Value.ToString()))
				Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow2.Cells("txtCostPrice").Value.ToString()))
				Dim flag11 As Boolean = dataGridViewRow2.Cells("txtBatch").Value IsNot Nothing
				If flag11 Then
					Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtBatch").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d9", "")
				End If
				Dim flag12 As Boolean = dataGridViewRow2.Cells("MfgDate").Value IsNot Nothing
				If flag12 Then
					Me.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("MfgDate").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d10", "")
				End If
				Dim flag13 As Boolean = dataGridViewRow2.Cells("ExpDate").Value IsNot Nothing
				If flag13 Then
					Me.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("ExpDate").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d11", "")
				End If
				Dim flag14 As Boolean = dataGridViewRow2.Cells("cmbSize").Value IsNot Nothing
				If flag14 Then
					Me.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbSize").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d12", "")
				End If
				Dim flag15 As Boolean = dataGridViewRow2.Cells("cmbColour").Value IsNot Nothing
				If flag15 Then
					Me.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbColour").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d13", "")
				End If
				Dim flag16 As Boolean = dataGridViewRow2.Cells("txtIMEI1").Value IsNot Nothing
				If flag16 Then
					Me.cmd.Parameters.AddWithValue("@d14", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtIMEI1").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d14", "")
				End If
				Dim flag17 As Boolean = dataGridViewRow2.Cells("txtIMEI2").Value IsNot Nothing
				If flag17 Then
					Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtIMEI2").Value))
				Else
					Me.cmd.Parameters.AddWithValue("@d15", "")
				End If
				Me.cmd.Parameters.AddWithValue("@d16", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtWSP").Value)))
				Me.cmd.Connection = Me.con
				Me.cmd.ExecuteNonQuery()
				Me.con.Close()
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text3 As String = "delete from ExtDB1 where a1=@d1"
				Me.cmd = New SqlCommand(text3)
				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
				Me.cmd.Connection = Me.con
				Me.cmd.ExecuteReader()
				Me.con.Close()
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text4 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
				Me.cmd = New SqlCommand(text4)
				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbSalesUnit").Value))
				Me.cmd.Connection = Me.con
				Me.cmd.ExecuteReader()
				Me.con.Close()
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text5 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
				Me.cmd = New SqlCommand(text5)
				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbAltunit").Value))
				Me.cmd.Connection = Me.con
				Me.cmd.ExecuteReader()
				Me.con.Close()
				MessageBox.Show("Successfully Updated", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.Getdata()
				Me.con.Close()
			End If
			Dim flag18 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("DeleteButtonColumn").Index AndAlso e.RowIndex >= 0
			If flag18 Then
				Try
					Dim flag19 As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag19 Then
						Try
							Dim dataGridViewRow3 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
							Me.txtID_Update.Text = dataGridViewRow3.Cells(1).Value.ToString().Substring(dataGridViewRow3.Cells(1).Value.ToString().LastIndexOf("-") + 1)
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text6 As String = "SELECT PID FROM Product INNER JOIN StockAdjustment_Store ON Product.PID = StockAdjustment_Store.ProductID where PID=@d1"
							Me.cmd = New SqlCommand(text6)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag20 As Boolean = Me.rdr.Read()
							If flag20 Then
								MessageBox.Show("Unable to delete..Already in use in Stock Adjustment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag21 As Boolean = Me.rdr IsNot Nothing
								If flag21 Then
									Me.rdr.Close()
								End If
								Return
							End If
							Dim flag22 As Boolean = Me.rdr IsNot Nothing
							If flag22 Then
								Me.rdr.Close()
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text7 As String = "SELECT PID FROM Product INNER JOIN Stock_Store_Join ON Product.PID = Stock_Store_Join.ProductID where PID=@d1"
							Me.cmd = New SqlCommand(text7)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag23 As Boolean = Me.rdr.Read()
							If flag23 Then
								MessageBox.Show("Unable to delete..Already in use in Stock Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag24 As Boolean = Me.rdr IsNot Nothing
								If flag24 Then
									Me.rdr.Close()
								End If
								Return
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text8 As String = "SELECT PID FROM Product INNER JOIN PurchaseOrder_Join ON Product.PID = PurchaseOrder_Join.ProductID where PID=@d1"
							Me.cmd = New SqlCommand(text8)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag25 As Boolean = Me.rdr.Read()
							If flag25 Then
								MessageBox.Show("Unable to delete..Already in use in Purchase Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag26 As Boolean = Me.rdr IsNot Nothing
								If flag26 Then
									Me.rdr.Close()
								End If
								Return
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text9 As String = "SELECT PID FROM Product INNER JOIN Stock_Product ON Product.PID = Stock_Product.ProductID where PID=@d1"
							Me.cmd = New SqlCommand(text9)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag27 As Boolean = Me.rdr.Read()
							If flag27 Then
								MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag28 As Boolean = Me.rdr IsNot Nothing
								If flag28 Then
									Me.rdr.Close()
								End If
								Return
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text10 As String = "SELECT PID FROM Product INNER JOIN Invoice_Product ON Product.PID = Invoice_Product.ProductID where PID=@d1"
							Me.cmd = New SqlCommand(text10)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag29 As Boolean = Me.rdr.Read()
							If flag29 Then
								MessageBox.Show("Unable to delete..Already in use in Sale Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag30 As Boolean = Me.rdr IsNot Nothing
								If flag30 Then
									Me.rdr.Close()
								End If
								Return
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text11 As String = "SELECT PID FROM Product INNER JOIN Quotation_Join ON Product.PID = Quotation_Join.ProductID where PID=@d1"
							Me.cmd = New SqlCommand(text11)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag31 As Boolean = Me.rdr.Read()
							If flag31 Then
								MessageBox.Show("Unable to delete..Already in use in Quotation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag32 As Boolean = Me.rdr IsNot Nothing
								If flag32 Then
									Me.rdr.Close()
								End If
								Return
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text12 As String = "SELECT PID FROM Product INNER JOIN Estimate_Join ON Product.PID = Estimate_Join.ProductID where PID=@d1"
							Me.cmd = New SqlCommand(text12)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag33 As Boolean = Me.rdr.Read()
							If flag33 Then
								MessageBox.Show("Unable to delete..Already in use in Estimate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag34 As Boolean = Me.rdr IsNot Nothing
								If flag34 Then
									Me.rdr.Close()
								End If
								Return
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text13 As String = "select ProductID from StockMovement where ProductID=@d1"
							Me.cmd = New SqlCommand(text13)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag35 As Boolean = Me.rdr.Read()
							If flag35 Then
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text14 As String = "delete from StockMovement where ProductID=@d1"
								Me.cmd = New SqlCommand(text14)
								Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteNonQuery()
								Me.con.Close()
							End If
							Dim flag36 As Boolean = Me.rdr IsNot Nothing
							If flag36 Then
								Me.rdr.Close()
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text15 As String = "delete from Product_OpeningStock where ProductID=@d1"
							Me.cmd = New SqlCommand(text15)
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.cmd.Connection = Me.con
							Dim num As Integer = Me.cmd.ExecuteNonQuery()
							Dim flag37 As Boolean = num > 0
							If flag37 Then
								Me.con.Close()
							End If
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text16 As String = "delete from ExtDB1 where a1=@d1"
							Me.cmd = New SqlCommand(text16)
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.cmd.Connection = Me.con
							Me.cmd.ExecuteReader()
							Me.con.Close()
							Me.con.Close()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text17 As String = "delete from Product where PID=@d1"
							Me.cmd = New SqlCommand(text17)
							Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_Update.Text))
							Me.cmd.Connection = Me.con
							num = Me.cmd.ExecuteNonQuery()
							Dim flag38 As Boolean = num > 0
							If flag38 Then
								MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.Getdata()
								Me.fillProductID()
								Me.auto()
								Me.GenerateBarcode()
							Else
								MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.fillProductID()
								Me.auto()
								Me.GenerateBarcode()
								Dim flag39 As Boolean = Me.con.State = ConnectionState.Open
								If flag39 Then
									Me.con.Close()
								End If
								Me.con.Close()
							End If
							Me.DataforNP()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
			Dim flag40 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("PrintBarcodeButton").Index AndAlso e.RowIndex >= 0
			If flag40 Then
				Dim dataGridViewRow4 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Dim dataSet As DataSet = New DataSet()
				Dim dataTable As DataTable = New DataTable()
				Dim flag41 As Boolean = Me.DataGridView1.Rows.Count = 0
				If flag41 Then
					MessageBox.Show("Barcode list not found", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If
				Try
					Dim dataTable2 As DataTable = New DataTable()
					Dim dataTable3 As DataTable = dataTable2
					dataTable3.Columns.Add("PCode")
					dataTable3.Columns.Add("ProductName")
					dataTable3.Columns.Add("Category")
					dataTable3.Columns.Add("Barcode")
					dataTable3.Columns.Add("AvlQty")
					dataTable3.Columns.Add("NoCopy")
					dataTable3.Columns.Add("PartNo")
					dataTable3.Columns.Add("HSNC")
					dataTable3.Columns.Add("MRP")
					dataTable3.Columns.Add("SalePrice")
					dataTable3.Columns.Add("WholesalePrice")
					dataTable3.Columns.Add("Batch")
					dataTable3.Columns.Add("Mfg")
					dataTable3.Columns.Add("Exp")
					dataTable3.Columns.Add("Size")
					dataTable3.Columns.Add("Colour")
					dataTable3.Columns.Add("GST")
					dataTable3.Columns.Add("PurInv")
					dataTable3.Columns.Add("QrBarcode")
					Dim dictionary As Dictionary(Of String, List(Of DataTable)) = New Dictionary(Of String, List(Of DataTable))()
					Dim list As List(Of Integer) = New List(Of Integer)()
					Dim list2 As List(Of DataTable) = New List(Of DataTable)()
					dataSet = Me.printCustomBarcode(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("'", dataGridViewRow4.Cells("txtBarcode_TempStock").Value), "'")))
					dataTable = dataSet.Tables(0).Clone()
					Dim num2 As Integer = Integer.Parse("1")
					Dim text18 As String = "A"
					Dim num3 As Integer = num2 - 1
					For i As Integer = 0 To num3
						Dim text19 As String = Conversions.ToString(dataGridViewRow4.Cells("ProductCode").Value)
						Dim text20 As String = Conversions.ToString(dataGridViewRow4.Cells("ProductName").Value)
						Dim text21 As String = Conversions.ToString(dataGridViewRow4.Cells("cmbCategory").Value)
						Dim text22 As String = Conversions.ToString(dataGridViewRow4.Cells("txtBarcode_TempStock").Value)
						Dim text23 As String = Conversions.ToString(dataGridViewRow4.Cells("txtSaleQty").Value)
						Dim text24 As String = Me.txtbarcodeNocopy.Text
						Dim text25 As String = Conversions.ToString(dataGridViewRow4.Cells("txtPartNo").Value)
						Dim text26 As String = Conversions.ToString(dataGridViewRow4.Cells("txtHSNCode").Value)
						Dim text27 As String = Conversions.ToString(dataGridViewRow4.Cells("txtDefMRP").Value)
						Dim text28 As String = Conversions.ToString(dataGridViewRow4.Cells("txtRSP").Value)
						Dim text29 As String = Conversions.ToString(dataGridViewRow4.Cells("txtWSP").Value)
						Dim text30 As String = Conversions.ToString(dataGridViewRow4.Cells("txtBatch").Value)
						Dim text31 As String = Conversions.ToString(dataGridViewRow4.Cells("MfgDate").Value)
						Dim text32 As String = Conversions.ToString(dataGridViewRow4.Cells("ExpDate").Value)
						Dim text33 As String = Conversions.ToString(dataGridViewRow4.Cells("cmbSize").Value)
						Dim text34 As String = Conversions.ToString(dataGridViewRow4.Cells("cmbColour").Value)
						Dim text35 As String = Conversions.ToString(dataGridViewRow4.Cells("cmbGST").Value)
						Dim text36 As String = ""
						dataTable2.Rows.Add(New Object() { text19, text20, text21, text22, text23, text24, text25, text26, text27, text28, text29, text30, text31, text32, text33, text34, text35, text36 })
					Next
					list.Add(num2 - 1)
					list2.Add(dataSet.Tables(0))
					num2 = Integer.Parse(Me.txtbarcodeNocopy.Text)
					Dim flag42 As Boolean = Operators.CompareString(text18, "A", False) = 0
					If flag42 Then
						Dim num4 As Integer = num2 - 1
						For j As Integer = 0 To num4
							Try
								For Each dataTable4 As DataTable In list2
									Try
										For Each obj As Object In dataTable4.Rows
											Dim dataRow As DataRow = CType(obj, DataRow)
											dataTable.ImportRow(dataRow)
										Next
									Finally
										Dim enumerator2 As IEnumerator
										If TypeOf enumerator2 Is IDisposable Then
											TryCast(enumerator2, IDisposable).Dispose()
										End If
									End Try
								Next
							Finally
								Dim enumerator As List(Of DataTable).Enumerator
								CType(enumerator, IDisposable).Dispose()
							End Try
						Next
					Else
						Dim flag43 As Boolean = Operators.CompareString(text18, "I", False) = 0
						If flag43 Then
							Dim count As Integer = list2.Count
							Dim num5 As Integer = 0
							Try
								For Each num6 As Integer In list
									Dim flag44 As Boolean = num6 = 0
									If flag44 Then
										Dim dataTable5 As DataTable = list2(num5)
										Dim flag45 As Boolean = dataTable5.Rows.Count > 0
										If flag45 Then
											Try
												For Each obj2 As Object In dataTable5.Rows
													Dim dataRow2 As DataRow = CType(obj2, DataRow)
													dataTable.ImportRow(dataRow2)
												Next
											Finally
												Dim enumerator4 As IEnumerator
												If TypeOf enumerator4 Is IDisposable Then
													TryCast(enumerator4, IDisposable).Dispose()
												End If
											End Try
										End If
									Else
										Dim num7 As Integer = num6
										For k As Integer = 0 To num7
											Dim dataTable6 As DataTable = list2(num5)
											Try
												For Each obj3 As Object In dataTable6.Rows
													Dim dataRow3 As DataRow = CType(obj3, DataRow)
													dataTable.ImportRow(dataRow3)
												Next
											Finally
												Dim enumerator5 As IEnumerator
												If TypeOf enumerator5 Is IDisposable Then
													TryCast(enumerator5, IDisposable).Dispose()
												End If
											End Try
										Next
									End If
									num5 += 1
								Next
							Finally
								Dim enumerator3 As List(Of Integer).Enumerator
								CType(enumerator3, IDisposable).Dispose()
							End Try
						End If
					End If
					dataTable.DefaultView.Sort = "Barcode ASC"
					dataTable = dataTable.DefaultView.ToTable()
					Dim text37 As String = ""
					Dim text38 As String = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview where is_active=1"
					Dim flag46 As Boolean = Operators.CompareString(text37, "", False) <> 0
					If flag46 Then
						text38 = text38 + " and PrintPreviewType='" + text37 + "'"
					End If
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Me.cmd = New SqlCommand(text38, Me.con)
					Me.cmd.CommandTimeout = 0
					Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag47 As Boolean = Me.rdr.Read()
					If flag47 Then
						Me.StyleId = Me.rdr(0).ToString()
					End If
					Dim flag48 As Boolean = Me.rdr IsNot Nothing
					If flag48 Then
						Me.rdr.Close()
					End If
					Dim reportDocument As ReportDocument = New ReportDocument()
					Dim flag49 As Boolean = Conversions.ToDouble(Me.StyleId) = 1.0
					If flag49 Then
						Dim reportDocument2 As ReportDocument = New ReportDocument()
						reportDocument2.Load(Application.StartupPath + "\CryReport\BarcodeT1.rpt")
						reportDocument2.SetDataSource(dataTable)
						reportDocument2.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument2
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag50 As Boolean = Conversions.ToDouble(Me.StyleId) = 2.0
					If flag50 Then
						Dim reportDocument3 As ReportDocument = New ReportDocument()
						reportDocument3.Load(Application.StartupPath + "\CryReport\BarcodeT2.rpt")
						reportDocument3.SetDataSource(dataTable)
						reportDocument3.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument3
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag51 As Boolean = Conversions.ToDouble(Me.StyleId) = 3.0
					If flag51 Then
						reportDocument = New BarcodeT3()
					End If
					Dim flag52 As Boolean = Conversions.ToDouble(Me.StyleId) = 4.0
					If flag52 Then
						reportDocument = New BarcodeT4()
					End If
					Dim flag53 As Boolean = Conversions.ToDouble(Me.StyleId) = 5.0
					If flag53 Then
						reportDocument = New BarcodeT5()
					End If
					Dim flag54 As Boolean = Conversions.ToDouble(Me.StyleId) = 6.0
					If flag54 Then
						Dim reportDocument4 As ReportDocument = New ReportDocument()
						reportDocument4.Load(Application.StartupPath + "\CryReport\BarcodeT6.rpt")
						reportDocument4.SetDataSource(dataTable)
						reportDocument4.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument4
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag55 As Boolean = Conversions.ToDouble(Me.StyleId) = 7.0
					If flag55 Then
						Dim reportDocument5 As ReportDocument = New ReportDocument()
						reportDocument5.Load(Application.StartupPath + "\CryReport\BarcodeT7.rpt")
						reportDocument5.SetDataSource(dataTable)
						reportDocument5.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument5
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag56 As Boolean = Conversions.ToDouble(Me.StyleId) = 8.0
					If flag56 Then
						Dim reportDocument6 As ReportDocument = New ReportDocument()
						reportDocument6.Load(Application.StartupPath + "\CryReport\BarcodeT8.rpt")
						reportDocument6.SetDataSource(dataTable)
						reportDocument6.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument6
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag57 As Boolean = Conversions.ToDouble(Me.StyleId) = 9.0
					If flag57 Then
						Dim reportDocument7 As ReportDocument = New ReportDocument()
						reportDocument7.Load(Application.StartupPath + "\CryReport\BarcodeT9.rpt")
						reportDocument7.SetDataSource(dataTable)
						reportDocument7.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument7
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag58 As Boolean = Conversions.ToDouble(Me.StyleId) = 10.0
					If flag58 Then
						Dim reportDocument8 As ReportDocument = New ReportDocument()
						reportDocument8.Load(Application.StartupPath + "\CryReport\BarcodeT10.rpt")
						reportDocument8.SetDataSource(dataTable)
						reportDocument8.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument8
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag59 As Boolean = Conversions.ToDouble(Me.StyleId) = 11.0
					If flag59 Then
						Dim reportDocument9 As ReportDocument = New ReportDocument()
						reportDocument9.Load(Application.StartupPath + "\CryReport\BarcodeT11.rpt")
						reportDocument9.SetDataSource(dataTable)
						reportDocument9.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument9
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag60 As Boolean = Conversions.ToDouble(Me.StyleId) = 12.0
					If flag60 Then
						Dim reportDocument10 As ReportDocument = New ReportDocument()
						reportDocument10.Load(Application.StartupPath + "\CryReport\BarcodeT12.rpt")
						reportDocument10.SetDataSource(dataTable)
						reportDocument10.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument10
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag61 As Boolean = Conversions.ToDouble(Me.StyleId) = 13.0
					If flag61 Then
						Dim reportDocument11 As ReportDocument = New ReportDocument()
						reportDocument11.Load(Application.StartupPath + "\CryReport\BarcodeCustomise1.rpt")
						reportDocument11.SetDataSource(dataTable)
						reportDocument11.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument11
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag62 As Boolean = Conversions.ToDouble(Me.StyleId) = 14.0
					If flag62 Then
						Dim reportDocument12 As ReportDocument = New ReportDocument()
						reportDocument12.Load(Application.StartupPath + "\CryReport\BarcodeCustomise2.rpt")
						reportDocument12.SetDataSource(dataTable)
						reportDocument12.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument12
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag63 As Boolean = Conversions.ToDouble(Me.StyleId) = 15.0
					If flag63 Then
						Dim reportDocument13 As ReportDocument = New ReportDocument()
						reportDocument13.Load(Application.StartupPath + "\CryReport\BarcodeT13.rpt")
						reportDocument13.SetDataSource(dataTable)
						reportDocument13.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument13
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag64 As Boolean = Conversions.ToDouble(Me.StyleId) = 16.0
					If flag64 Then
						Dim reportDocument14 As ReportDocument = New ReportDocument()
						reportDocument14.Load(Application.StartupPath + "\CryReport\BarcodeT14.rpt")
						reportDocument14.SetDataSource(dataTable)
						reportDocument14.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument14
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag65 As Boolean = Conversions.ToDouble(Me.StyleId) = 17.0
					If flag65 Then
						Dim reportDocument15 As ReportDocument = New ReportDocument()
						reportDocument15.Load(Application.StartupPath + "\CryReport\BarcodeT15.rpt")
						reportDocument15.SetDataSource(dataTable)
						reportDocument15.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument15
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag66 As Boolean = Conversions.ToDouble(Me.StyleId) = 18.0
					If flag66 Then
						Dim reportDocument16 As ReportDocument = New ReportDocument()
						reportDocument16.Load(Application.StartupPath + "\CryReport\BarcodeT16.rpt")
						reportDocument16.SetDataSource(dataTable)
						reportDocument16.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument16
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag67 As Boolean = Conversions.ToDouble(Me.StyleId) = 19.0
					If flag67 Then
						Dim reportDocument17 As ReportDocument = New ReportDocument()
						reportDocument17.Load(Application.StartupPath + "\CryReport\BarcodeT17.rpt")
						reportDocument17.SetDataSource(dataTable)
						reportDocument17.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument17
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					Dim flag68 As Boolean = Conversions.ToDouble(Me.StyleId) = 20.0
					If flag68 Then
						Dim reportDocument18 As ReportDocument = New ReportDocument()
						reportDocument18.Load(Application.StartupPath + "\CryReport\BarcodeT18.rpt")
						reportDocument18.SetDataSource(dataTable)
						reportDocument18.SetParameterValue("P1", Me.txtCompany.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument18
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
						Return
					End If
					reportDocument.SetDataSource(dataTable2)
					reportDocument.SetParameterValue("P1", Me.txtCompany.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
					MyProject.Forms.frmReport.ShowDialog()
					MyProject.Forms.frmReport.Dispose()
				Catch ex3 As Exception
					MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
			Dim flag69 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("InsertButtonColumn").Index AndAlso e.RowIndex >= 0
			If flag69 Then
				Dim dataGridViewRow5 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Dim flag70 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow5.Cells("ProductName").Value))) = 0
				If flag70 Then
					MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.ScrollToSelectedCell(CShort(e.RowIndex), 1S)
				Else
					Dim flag71 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow5.Cells("cmbCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow5.Cells("cmbCategory").Value))) = 0)
					If flag71 Then
						MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ScrollToSelectedCell(CShort(e.RowIndex), 3S)
					Else
						Dim flag72 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow5.Cells("cmbSubCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow5.Cells("cmbSubCategory").Value))) = 0)
						If flag72 Then
							MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.ScrollToSelectedCell(CShort(e.RowIndex), 5S)
						Else
							Dim flag73 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtCostPrice").Value))))) = 0) Or (dataGridViewRow5.Cells("txtCostPrice").Value Is Nothing)
							If flag73 Then
								MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.ScrollToSelectedCell(CShort(e.RowIndex), 11S)
							Else
								Dim flag74 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow5.Cells("cmbGST").Value))) = 0
								If flag74 Then
									MessageBox.Show("Please select your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.ScrollToSelectedCell(CShort(e.RowIndex), 14S)
								Else
									Dim flag75 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow5.Cells("cmbPurchaseUnit").Value))) = 0) Or (dataGridViewRow5.Cells("cmbPurchaseUnit").Value Is Nothing)
									If flag75 Then
										MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.ScrollToSelectedCell(CShort(e.RowIndex), 23S)
									Else
										Dim flag76 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow5.Cells("cmbSalesUnit").Value.ToString())) = 0
										If flag76 Then
											MessageBox.Show("Please select sales main unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.ScrollToSelectedCell(CShort(e.RowIndex), 24S)
										Else
											Dim flag77 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow5.Cells("cmbAltunit").Value.ToString())) = 0
											If flag77 Then
												MessageBox.Show("Please select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.ScrollToSelectedCell(CShort(e.RowIndex), 25S)
											Else
												Dim flag78 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("Conv").Value))))) = 0) Or (dataGridViewRow5.Cells("Conv").Value Is Nothing)
												If flag78 Then
													MessageBox.Show("Please enter conversion value", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.ScrollToSelectedCell(CShort(e.RowIndex), 26S)
												Else
													Dim flag79 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow5.Cells("txtSaleQty").Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow5.Cells("txtSaleQty").Value, 0, False)))
													If flag79 Then
														MessageBox.Show("Please enter default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.ScrollToSelectedCell(CShort(e.RowIndex), 34S)
													Else
														Dim flag80 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtDefMRP").Value)) <= 0.0
														If flag80 Then
															MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
															Me.ScrollToSelectedCell(CShort(e.RowIndex), 37S)
														Else
															Dim flag81 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow5.Cells("txtBarcode_TempStock").Value, "", False)
															If flag81 Then
																MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																Me.txtBarcode.Focus()
																Me.ScrollToSelectedCell(CShort(e.RowIndex), 36S)
															Else
																Dim flag82 As Boolean = Me.DataGridView1.Rows.Count > 0
																If flag82 Then
																	Try
																		For Each obj4 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																			Dim dataGridViewRow6 As DataGridViewRow = CType(obj4, DataGridViewRow)
																			Me.con = New SqlConnection(ModCS.cs)
																			Me.con.Open()
																			Dim text39 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																			Me.cmd = New SqlCommand(text39)
																			Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtBarcode_TempStock").Value))
																			Me.cmd.Connection = Me.con
																			Me.rdr = Me.cmd.ExecuteReader()
																			Dim flag83 As Boolean = Me.rdr.Read()
																			If flag83 Then
																				MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																				Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow6.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																				Dim flag84 As Boolean = Me.rdr IsNot Nothing
																				If flag84 Then
																					Me.rdr.Close()
																				End If
																				Return
																			End If
																			Me.con = New SqlConnection(ModCS.cs)
																			Me.con.Open()
																			Dim text40 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																			Me.cmd = New SqlCommand(text40)
																			Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtBarcode_TempStock").Value))
																			Me.cmd.Connection = Me.con
																			Me.rdr = Me.cmd.ExecuteReader()
																			Dim flag85 As Boolean = Me.rdr.Read()
																			If flag85 Then
																				MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																				Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow6.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																				Dim flag86 As Boolean = Me.rdr IsNot Nothing
																				If flag86 Then
																					Me.rdr.Close()
																				End If
																				Return
																			End If
																		Next
																	Finally
																		Dim enumerator6 As IEnumerator
																		If TypeOf enumerator6 Is IDisposable Then
																			TryCast(enumerator6, IDisposable).Dispose()
																		End If
																	End Try
																Else
																	Dim flag87 As Boolean = Me.DataGridView1.Rows.Count <= 0
																	If flag87 Then
																		Me.con = New SqlConnection(ModCS.cs)
																		Me.con.Open()
																		Dim text41 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																		Me.cmd = New SqlCommand(text41)
																		Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtBarcode_TempStock").Value))
																		Me.cmd.Connection = Me.con
																		Me.rdr = Me.cmd.ExecuteReader()
																		Dim flag88 As Boolean = Me.rdr.Read()
																		If flag88 Then
																			MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																			Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow5.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																			Dim flag89 As Boolean = Me.rdr IsNot Nothing
																			If flag89 Then
																				Me.rdr.Close()
																			End If
																			Return
																		End If
																		Me.con = New SqlConnection(ModCS.cs)
																		Me.con.Open()
																		Dim text42 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																		Me.cmd = New SqlCommand(text42)
																		Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtBarcode_TempStock").Value))
																		Me.cmd.Connection = Me.con
																		Me.rdr = Me.cmd.ExecuteReader()
																		Dim flag90 As Boolean = Me.rdr.Read()
																		If flag90 Then
																			MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																			Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow5.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																			Dim flag91 As Boolean = Me.rdr IsNot Nothing
																			If flag91 Then
																				Me.rdr.Close()
																			End If
																			Return
																		End If
																	End If
																End If
																Me.con = New SqlConnection(ModCS.cs)
																Me.con.Open()
																Dim text43 As String = "SELECT * FROM Defaulttaxtype WHERE id = 1"
																Me.cmd = New SqlCommand(text43)
																Me.cmd.Connection = Me.con
																Me.rdr = Me.cmd.ExecuteReader()
																Dim flag92 As Boolean = Me.rdr.Read()
																If flag92 Then
																	Me.strStax = Me.rdr(1).ToString()
																	Me.strPtax = Me.rdr(2).ToString()
																	Dim flag93 As Boolean = Me.rdr IsNot Nothing
																	If flag93 Then
																		Me.rdr.Close()
																	End If
																End If
																Me.con = New SqlConnection(ModCS.cs)
																Me.con.Open()
																Dim text44 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
																Me.cmd = New SqlCommand(text44)
																Me.cmd.Connection = Me.con
																Me.rdr = Me.cmd.ExecuteReader()
																Dim flag94 As Boolean = Me.rdr.Read()
																Dim text45 As String
																Dim num8 As Double
																If flag94 Then
																	text45 = Me.rdr(1).ToString()
																	num8 = Conversions.ToDouble(Me.rdr(2).ToString())
																	Dim flag95 As Boolean = Me.rdr IsNot Nothing
																	If flag95 Then
																		Me.rdr.Close()
																	End If
																End If
																Me.auto()
																Dim flag96 As Boolean = Operators.CompareString(frmProductRec.strForm, "POSNewTuch", False) = 0
																If flag96 Then
																	Me.con = New SqlConnection(ModCS.cs)
																	Me.con.Open()
																	Dim text46 As String = "select ID,SubCategoryName  from SubCategory where SubCategoryName=@d1"
																	Me.cmd = New SqlCommand(text46)
																	Me.cmd.Parameters.AddWithValue("@d1", frmProductRec.strSubcategory_POSNewTuch)
																	Me.cmd.Connection = Me.con
																	Me.rdr = Me.cmd.ExecuteReader()
																	Dim flag97 As Boolean = Me.rdr.Read()
																	If flag97 Then
																		frmProductRec.strSubcategory_POSNewTuch = Me.rdr(0).ToString()
																		Dim flag98 As Boolean = Me.rdr IsNot Nothing
																		If flag98 Then
																			Me.rdr.Close()
																		End If
																		Return
																	End If
																End If
																Dim text47 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen, loyality_mode, loyality_value) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35)"
																Me.cmd = New SqlCommand(text47)
																Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																Me.cmd.Parameters.AddWithValue("@d1", dataGridViewRow5.Cells("ProductCode").Value.ToString())
																Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow5.Cells("ProductName").Value.ToString())
																Dim flag99 As Boolean = Operators.CompareString(frmProductRec.strForm, "POSNewTuch", False) = 0
																If flag99 Then
																	Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(frmProductRec.strSubcategory_POSNewTuch))
																Else
																	Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow5.Cells("txtSubCategoryID").Value.ToString()))
																End If
																Dim flag100 As Boolean = dataGridViewRow5.Cells("txtFeatures").Value IsNot Nothing
																If flag100 Then
																	Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtFeatures").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d4", dataGridViewRow5.Cells("ProductName").Value.ToString())
																End If
																Dim flag101 As Boolean = dataGridViewRow5.Cells("txtCostPrice").Value IsNot Nothing
																If flag101 Then
																	Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtCostPrice").Value)))
																Else
																	Me.cmd.Parameters.AddWithValue("@d5", 0)
																End If
																Dim flag102 As Boolean = dataGridViewRow5.Cells("txtDiscount").Value IsNot Nothing
																If flag102 Then
																	Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtDiscount").Value)))
																Else
																	Me.cmd.Parameters.AddWithValue("@d7", 0)
																End If
																Dim flag103 As Boolean = dataGridViewRow5.Cells("txtCGST").Value IsNot Nothing
																If flag103 Then
																	Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtCGST").Value)))
																Else
																	Me.cmd.Parameters.AddWithValue("@d8", 0)
																End If
																Me.cmd.Parameters.AddWithValue("@d11", "0")
																Me.cmd.Parameters.AddWithValue("@d12", dataGridViewRow5.Cells("cmbPurchaseUnit").Value.ToString())
																Me.cmd.Parameters.AddWithValue("@d13", dataGridViewRow5.Cells("cmbSalesUnit").Value.ToString())
																Dim flag104 As Boolean = dataGridViewRow5.Cells("txtSGST").Value IsNot Nothing
																If flag104 Then
																	Me.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtSGST").Value)))
																Else
																	Me.cmd.Parameters.AddWithValue("@d14", 0)
																End If
																Me.cmd.Parameters.AddWithValue("@d15", dataGridViewRow5.Cells("txtHSNCode").Value.ToString())
																Dim flag105 As Boolean = dataGridViewRow5.Cells("txtPartNo").Value IsNot Nothing
																If flag105 Then
																	Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtPartNo").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d16", "0")
																End If
																Dim flag106 As Boolean = dataGridViewRow5.Cells("txtCESS").Value IsNot Nothing
																If flag106 Then
																	Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtCESS").Value)))
																Else
																	Me.cmd.Parameters.AddWithValue("@d17", 0)
																End If
																Me.cmd.Parameters.AddWithValue("@d18", dataGridViewRow5.Cells("cmbAltunit").Value.ToString())
																Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow5.Cells("Conv").Value.ToString()))
																Dim flag107 As Boolean = dataGridViewRow5.Cells("txtMinStock").Value IsNot Nothing
																If flag107 Then
																	Me.cmd.Parameters.AddWithValue("@d20", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtMinStock").Value)))
																Else
																	Me.cmd.Parameters.AddWithValue("@d20", 1)
																End If
																Me.cmd.Parameters.AddWithValue("@d22", "Yes")
																Me.cmd.Parameters.AddWithValue("@d23", Me.strStax)
																Me.cmd.Parameters.AddWithValue("@d24", Me.strPtax)
																Dim flag108 As Boolean = dataGridViewRow5.Cells("ddlGDown").Value IsNot Nothing
																If flag108 Then
																	Me.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("ddlGDown").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d25", "")
																End If
																Dim flag109 As Boolean = dataGridViewRow5.Cells("ddlRack").Value IsNot Nothing
																If flag109 Then
																	Me.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("ddlRack").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d26", "")
																End If
																Dim flag110 As Boolean = dataGridViewRow5.Cells("txtDefMRP").Value IsNot Nothing
																If flag110 Then
																	Me.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtDefMRP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d27", 0)
																End If
																Dim flag111 As Boolean = dataGridViewRow5.Cells("txtRSP").Value IsNot Nothing
																If flag111 Then
																	Me.cmd.Parameters.AddWithValue("@d28", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtRSP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d28", 0)
																End If
																Dim flag112 As Boolean = dataGridViewRow5.Cells("txtWSP").Value IsNot Nothing
																If flag112 Then
																	Me.cmd.Parameters.AddWithValue("@d29", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtWSP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d29", 0)
																End If
																Me.cmd.Parameters.AddWithValue("@d30", "0")
																Me.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
																Dim flag113 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow5.Cells("txtSaleQty").Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow5.Cells("txtSaleQty").Value, 0, False)))
																If flag113 Then
																	Me.cmd.Parameters.AddWithValue("@d32", "1")
																Else
																	Me.cmd.Parameters.AddWithValue("@d32", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtSaleQty").Value))
																End If
																Me.cmd.Parameters.AddWithValue("@d33", "")
																Me.cmd.Parameters.AddWithValue("@d34", text45.ToString())
																Me.cmd.Parameters.AddWithValue("@d35", Conversion.Val(num8))
																Me.con = New SqlConnection(ModCS.cs)
																Try
																	Me.con.Open()
																	Me.cmd.Connection = Me.con
																	Me.cmd.ExecuteNonQuery()
																	Me.con.Close()
																	Me.con.Open()
																	Dim text48 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
																	Me.cmd = New SqlCommand(text48)
																	Me.cmd.Connection = Me.con
																	Me.cmd.Prepare()
																	Try
																		For Each obj5 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																			Dim dataGridViewRow7 As DataGridViewRow = CType(obj5, DataGridViewRow)
																			Dim isNewRow As Boolean = dataGridViewRow7.IsNewRow
																			If isNewRow Then
																				Dim memoryStream As MemoryStream = New MemoryStream()
																				Dim image As Image = CType(dataGridViewRow7.Cells("Photo").Value, Image)
																				Dim bitmap As Bitmap = New Bitmap(image)
																				bitmap.Save(memoryStream, ImageFormat.Jpeg)
																				Dim buffer As Byte() = memoryStream.GetBuffer()
																				Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
																				sqlParameter.Value = buffer
																				Me.cmd.Parameters.Add(sqlParameter)
																				Me.cmd.ExecuteNonQuery()
																				Me.cmd.Parameters.Clear()
																			End If
																		Next
																	Finally
																		Dim enumerator7 As IEnumerator
																		If TypeOf enumerator7 Is IDisposable Then
																			TryCast(enumerator7, IDisposable).Dispose()
																		End If
																	End Try
																	Me.con.Close()
																	Me.con.Open()
																	Dim text49 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
																	Me.cmd = New SqlCommand(text49)
																	Me.cmd.Connection = Me.con
																	Me.cmd.Prepare()
																	Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																	Dim flag114 As Boolean = dataGridViewRow5.Cells("txtOpeningStock").Value IsNot Nothing
																	If flag114 Then
																		Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtOpeningStock").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d1", 0)
																	End If
																	Dim flag115 As Boolean = dataGridViewRow5.Cells("txtDefMRP").Value IsNot Nothing
																	If flag115 Then
																		Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtDefMRP").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d2", 0)
																	End If
																	Dim flag116 As Boolean = dataGridViewRow5.Cells("txtRSP").Value IsNot Nothing
																	If flag116 Then
																		Me.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtRSP").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d3", 0)
																	End If
																	Dim flag117 As Boolean = dataGridViewRow5.Cells("txtWSP").Value IsNot Nothing
																	If flag117 Then
																		Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtWSP").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d4", 0)
																	End If
																	Dim flag118 As Boolean = dataGridViewRow5.Cells("txtBatch").Value IsNot Nothing
																	If flag118 Then
																		Me.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtBatch").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d5", "")
																	End If
																	Dim flag119 As Boolean = dataGridViewRow5.Cells("MfgDate").Value IsNot Nothing
																	If flag119 Then
																		Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("MfgDate").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d6", "")
																	End If
																	Dim flag120 As Boolean = dataGridViewRow5.Cells("ExpDate").Value IsNot Nothing
																	If flag120 Then
																		Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("ExpDate").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d7", "")
																	End If
																	Dim flag121 As Boolean = dataGridViewRow5.Cells("cmbSize").Value IsNot Nothing
																	If flag121 Then
																		Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("cmbSize").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d8", "")
																	End If
																	Dim flag122 As Boolean = dataGridViewRow5.Cells("cmbColour").Value IsNot Nothing
																	If flag122 Then
																		Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("cmbColour").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d9", "")
																	End If
																	Me.cmd.Parameters.AddWithValue("@d10", Me.txtBarcodeTempStock.Text.ToString())
																	Me.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
																	Me.cmd.Parameters.AddWithValue("@d12", "")
																	Me.cmd.Parameters.AddWithValue("@d13", "")
																	Dim flag123 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow5.Cells("cmbPurchaseTaxType").Value, "Inclusive", False)
																	Dim num9 As Double
																	If flag123 Then
																		num9 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtCostPrice").Value)), 2)), "0.00"))
																	Else
																		num9 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtCostPrice").Value)), 2)), "0.00"))
																	End If
																	Me.cmd.Parameters.AddWithValue("@d14", num9)
																	Me.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num9 * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtOpeningStock").Value)), 2)), "0.00"))
																	Dim flag124 As Boolean = dataGridViewRow5.Cells("txtIMEI1").Value IsNot Nothing
																	If flag124 Then
																		Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtIMEI1").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d16", "")
																	End If
																	Dim flag125 As Boolean = dataGridViewRow5.Cells("txtIMEI2").Value IsNot Nothing
																	If flag125 Then
																		Me.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtIMEI2").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d17", "")
																	End If
																	Me.cmd.ExecuteNonQuery()
																	Me.cmd.Parameters.Clear()
																	Me.con.Close()
																	Me.con = New SqlConnection(ModCS.cs)
																	Me.con.Open()
																	Dim text50 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur, Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20, @d21)"
																	Me.cmd = New SqlCommand(text50)
																	Me.cmd.Connection = Me.con
																	Me.cmd.Prepare()
																	Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																	Dim flag126 As Boolean = dataGridViewRow5.Cells("txtOpeningStock").Value IsNot Nothing
																	If flag126 Then
																		Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtOpeningStock").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d1", 0)
																	End If
																	Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow5.Cells("txtBarcode_TempStock").Value.ToString())
																	Dim flag127 As Boolean = dataGridViewRow5.Cells("txtRSP").Value IsNot Nothing
																	If flag127 Then
																		Me.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtRSP").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d3", 0)
																	End If
																	Dim flag128 As Boolean = dataGridViewRow5.Cells("txtWSP").Value IsNot Nothing
																	If flag128 Then
																		Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtWSP").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d4", 0)
																	End If
																	Dim flag129 As Boolean = dataGridViewRow5.Cells("txtMinStock").Value IsNot Nothing
																	If flag129 Then
																		Me.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtMinStock").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d5", 0)
																	End If
																	Dim flag130 As Boolean = dataGridViewRow5.Cells("txtDefMRP").Value IsNot Nothing
																	If flag130 Then
																		Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtDefMRP").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d6", 0)
																	End If
																	Dim flag131 As Boolean = dataGridViewRow5.Cells("txtBatch").Value IsNot Nothing
																	If flag131 Then
																		Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtBatch").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d7", "")
																	End If
																	Dim flag132 As Boolean = dataGridViewRow5.Cells("MfgDate").Value IsNot Nothing
																	If flag132 Then
																		Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("MfgDate").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d8", "")
																	End If
																	Dim flag133 As Boolean = dataGridViewRow5.Cells("ExpDate").Value IsNot Nothing
																	If flag133 Then
																		Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("ExpDate").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d9", "")
																	End If
																	Dim flag134 As Boolean = dataGridViewRow5.Cells("cmbSize").Value IsNot Nothing
																	If flag134 Then
																		Me.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("cmbSize").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d10", "")
																	End If
																	Dim flag135 As Boolean = dataGridViewRow5.Cells("cmbColour").Value IsNot Nothing
																	If flag135 Then
																		Me.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("cmbColour").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d11", "")
																	End If
																	Dim flag136 As Boolean = dataGridViewRow5.Cells("txtRSP").Value IsNot Nothing
																	If flag136 Then
																		Me.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtRSP").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d12", 0)
																	End If
																	Dim flag137 As Boolean = dataGridViewRow5.Cells("txtWSP").Value IsNot Nothing
																	If flag137 Then
																		Me.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtWSP").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d13", 0)
																	End If
																	Me.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
																	Dim flag138 As Boolean = dataGridViewRow5.Cells("txtIMEI1").Value IsNot Nothing
																	If flag138 Then
																		Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtIMEI1").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d15", "")
																	End If
																	Dim flag139 As Boolean = dataGridViewRow5.Cells("txtIMEI2").Value IsNot Nothing
																	If flag139 Then
																		Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtIMEI2").Value))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d16", "")
																	End If
																	Dim flag140 As Boolean = dataGridViewRow5.Cells("txtCostPrice").Value IsNot Nothing
																	If flag140 Then
																		Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtCostPrice").Value)))
																		Me.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("txtCostPrice").Value)))
																	Else
																		Me.cmd.Parameters.AddWithValue("@d17", 0)
																		Me.cmd.Parameters.AddWithValue("@d18", 0)
																	End If
																	Me.Generate_GiftQR(dataGridViewRow5.Cells("txtBarcode_TempStock").Value.ToString())
																	Dim memoryStream2 As MemoryStream = New MemoryStream()
																	Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
																	bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
																	Dim buffer2 As Byte() = memoryStream2.GetBuffer()
																	Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
																	sqlParameter2.Value = buffer2
																	Me.cmd.Parameters.AddWithValue("@d20", 0.0)
																	Me.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtID.Text))
																	Me.cmd.Parameters.Add(sqlParameter2)
																	Me.cmd.ExecuteNonQuery()
																	Me.cmd.Parameters.Clear()
																	Me.con.Close()
																	Me.con = New SqlConnection(ModCS.cs)
																	Me.con.Open()
																	Dim text51 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																	Me.cmd = New SqlCommand(text51)
																	Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																	Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("cmbSalesUnit").Value))
																	Me.cmd.Connection = Me.con
																	Me.cmd.ExecuteReader()
																	Me.con.Close()
																	Me.con = New SqlConnection(ModCS.cs)
																	Me.con.Open()
																	Dim text52 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																	Me.cmd = New SqlCommand(text52)
																	Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																	Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells("cmbAltunit").Value))
																	Me.cmd.Connection = Me.con
																	Me.cmd.ExecuteReader()
																	Me.con.Close()
																	MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																	Dim flag141 As Boolean = Operators.CompareString(frmProductRec.strForm, "POSNewTuch", False) = 0
																	If flag141 Then
																		MyBase.Dispose()
																		Return
																	End If
																	Me.fillProductID()
																	Me.con.Close()
																	Me.auto()
																	Me.GenerateBarcode()
																	Me.Getdata()
																	Me.GelButtonNewRecord_Click(RuntimeHelpers.GetObjectValue(sender), e)
																	Me.DataGridView1.CurrentCell = Me.DataGridView1(2, e.RowIndex)
																	Me.DataGridView1.BeginEdit(True)
																Catch ex4 As Exception
																	MessageBox.Show(String.Format("Error inserting row: {0}", ex4.Message))
																Finally
																	Me.con.Close()
																End Try
																Me.DataforNP()
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
				End If
			End If
		End Sub

		' Token: 0x0600839D RID: 33693 RVA: 0x0061722C File Offset: 0x0061542C
		Public Function printCustomBarcode(barcode As String) As DataSet
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlCommand As SqlCommand = New SqlCommand()
			Dim sqlCommand2 As SqlCommand = New SqlCommand()
			Dim dataSet As DataSet = New DataSet()
			Dim dataSet2 As DataSet = New DataSet()
			Try
				Dim text As String = "Select ProductCode,ProductName,(Category),Temp_Stock.Barcode,Temp_Stock.Qty,(PartNo),(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),(Product.CGST),(Product.SGST),QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes'  and Temp_Stock.barcode in(" + barcode + ")"
				Me.con = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = Me.con
				sqlCommand.CommandText = text
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				Me.con.Open()
				sqlDataAdapter.Fill(dataSet, "DataTable2")
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return dataSet
		End Function

		' Token: 0x0600839E RID: 33694 RVA: 0x00617318 File Offset: 0x00615518
		Public Sub DBoperation(rowNo As Integer, Operation As String)
			Dim flag As Boolean = Operators.CompareString(Operation, "Insert", False) = 0 AndAlso rowNo >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(rowNo)
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("ProductName").Value))) = 0
				If flag2 Then
					MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbCategory").Value))) = 0)
					If flag3 Then
						MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbSubCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbSubCategory").Value))) = 0)
						If flag4 Then
							MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag5 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtPartNo").Value))))) = 0) Or (dataGridViewRow.Cells("txtPartNo").Value Is Nothing)
							If flag5 Then
								MessageBox.Show("Please enter Part No", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								Dim flag6 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value))))) = 0) Or (dataGridViewRow.Cells("txtCostPrice").Value Is Nothing)
								If flag6 Then
									MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Else
									Dim flag7 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(dataGridViewRow.Cells("txtDiscount").Value.ToString())))) = 0
									If flag7 Then
										MessageBox.Show("Please enter Discount%", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Else
										Dim flag8 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbGST").Value))) = 0
										If flag8 Then
											MessageBox.Show("Please select your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Else
											Dim flag9 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("txtMinStock").Value, "", False)
											If flag9 Then
												MessageBox.Show("Please enter minimum stock", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Else
												Dim flag10 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbPurchaseUnit").Value))) = 0) Or (dataGridViewRow.Cells("cmbPurchaseUnit").Value Is Nothing)
												If flag10 Then
													MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Else
													Dim flag11 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells("cmbSalesUnit").Value.ToString())) = 0
													If flag11 Then
														MessageBox.Show("Please select sales main unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Else
														Dim flag12 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells("cmbAltunit").Value.ToString())) = 0
														If flag12 Then
															MessageBox.Show("Please select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Else
															Dim flag13 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Conv").Value))))) = 0) Or (dataGridViewRow.Cells("Conv").Value Is Nothing)
															If flag13 Then
																MessageBox.Show("Please enter conversion value", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
															Else
																Dim flag14 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow.Cells("txtSaleQty").Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow.Cells("txtSaleQty").Value, 0, False)))
																If flag14 Then
																	MessageBox.Show("Please enter default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																Else
																	Dim flag15 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtDefMRP").Value)) <= 0.0
																	If flag15 Then
																		MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																	Else
																		Dim flag16 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("txtBarcode_TempStock").Value, "", False)
																		If flag16 Then
																			MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																			Me.txtBarcode.Focus()
																		Else
																			Dim flag17 As Boolean = Me.DataGridView1.Rows.Count > 0
																			If flag17 Then
																				Try
																					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																						Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
																						Me.con = New SqlConnection(ModCS.cs)
																						Me.con.Open()
																						Dim text As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																						Me.cmd = New SqlCommand(text)
																						Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																						Me.cmd.Connection = Me.con
																						Me.rdr = Me.cmd.ExecuteReader()
																						Dim flag18 As Boolean = Me.rdr.Read()
																						If flag18 Then
																							MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																							Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																							Dim flag19 As Boolean = Me.rdr IsNot Nothing
																							If flag19 Then
																								Me.rdr.Close()
																							End If
																							Return
																						End If
																						Me.con = New SqlConnection(ModCS.cs)
																						Me.con.Open()
																						Dim text2 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																						Me.cmd = New SqlCommand(text2)
																						Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																						Me.cmd.Connection = Me.con
																						Me.rdr = Me.cmd.ExecuteReader()
																						Dim flag20 As Boolean = Me.rdr.Read()
																						If flag20 Then
																							MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																							Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																							Dim flag21 As Boolean = Me.rdr IsNot Nothing
																							If flag21 Then
																								Me.rdr.Close()
																							End If
																							Return
																						End If
																					Next
																				Finally
																					Dim enumerator As IEnumerator
																					If TypeOf enumerator Is IDisposable Then
																						TryCast(enumerator, IDisposable).Dispose()
																					End If
																				End Try
																			Else
																				Dim flag22 As Boolean = Me.DataGridView1.Rows.Count <= 0
																				If flag22 Then
																					Me.con = New SqlConnection(ModCS.cs)
																					Me.con.Open()
																					Dim text3 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																					Me.cmd = New SqlCommand(text3)
																					Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																					Me.cmd.Connection = Me.con
																					Me.rdr = Me.cmd.ExecuteReader()
																					Dim flag23 As Boolean = Me.rdr.Read()
																					If flag23 Then
																						MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																						Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																						Dim flag24 As Boolean = Me.rdr IsNot Nothing
																						If flag24 Then
																							Me.rdr.Close()
																						End If
																						Return
																					End If
																					Me.con = New SqlConnection(ModCS.cs)
																					Me.con.Open()
																					Dim text4 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																					Me.cmd = New SqlCommand(text4)
																					Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																					Me.cmd.Connection = Me.con
																					Me.rdr = Me.cmd.ExecuteReader()
																					Dim flag25 As Boolean = Me.rdr.Read()
																					If flag25 Then
																						MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																						Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																						Dim flag26 As Boolean = Me.rdr IsNot Nothing
																						If flag26 Then
																							Me.rdr.Close()
																						End If
																						Return
																					End If
																				End If
																			End If
																			Me.auto()
																			Dim text5 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33)"
																			Me.cmd = New SqlCommand(text5)
																			Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																			Me.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells("ProductCode").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells("ProductName").Value.ToString())
																			Dim flag27 As Boolean = Operators.CompareString(frmProductRec.strForm, "POSNewTuch", False) = 0
																			If flag27 Then
																				Me.cmd.Parameters.AddWithValue("@d3", frmProductRec.strSubcategory_POSNewTuch)
																			Else
																				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow.Cells("txtSubCategoryID").Value.ToString()))
																			End If
																			Dim flag28 As Boolean = dataGridViewRow.Cells("txtFeatures").Value IsNot Nothing
																			If flag28 Then
																				Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtFeatures").Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d4", dataGridViewRow.Cells("ProductName").Value.ToString())
																			End If
																			Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)))
																			Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow.Cells("txtDiscount").Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCGST").Value)))
																			Me.cmd.Parameters.AddWithValue("@d11", "0")
																			Me.cmd.Parameters.AddWithValue("@d12", dataGridViewRow.Cells("cmbPurchaseUnit").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d13", dataGridViewRow.Cells("cmbSalesUnit").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtSGST").Value)))
																			Me.cmd.Parameters.AddWithValue("@d15", dataGridViewRow.Cells("txtHSNCode").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtPartNo").Value))
																			Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCESS").Value)))
																			Me.cmd.Parameters.AddWithValue("@d18", dataGridViewRow.Cells("cmbAltunit").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow.Cells("Conv").Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d20", Conversion.Val(dataGridViewRow.Cells("txtMinStock").Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d22", "Yes")
																			Me.cmd.Parameters.AddWithValue("@d23", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSalesTaxType").Value))
																			Me.cmd.Parameters.AddWithValue("@d24", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbPurchaseTaxType").Value))
																			Dim flag29 As Boolean = dataGridViewRow.Cells("ddlGDown").Value IsNot Nothing
																			If flag29 Then
																				Me.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ddlGDown").Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d25", "")
																			End If
																			Dim flag30 As Boolean = dataGridViewRow.Cells("ddlRack").Value IsNot Nothing
																			If flag30 Then
																				Me.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ddlRack").Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d26", "")
																			End If
																			Me.cmd.Parameters.AddWithValue("@d27", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtDefMRP").Value)))
																			Me.cmd.Parameters.AddWithValue("@d28", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																			Me.cmd.Parameters.AddWithValue("@d29", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																			Me.cmd.Parameters.AddWithValue("@d30", "0")
																			Me.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
																			Dim flag31 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow.Cells("txtSaleQty").Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow.Cells("txtSaleQty").Value, 0, False)))
																			If flag31 Then
																				Me.cmd.Parameters.AddWithValue("@d32", "1")
																			Else
																				Me.cmd.Parameters.AddWithValue("@d32", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtSaleQty").Value))
																			End If
																			Me.cmd.Parameters.AddWithValue("@d33", "")
																			Me.con = New SqlConnection(ModCS.cs)
																			Try
																				Me.con.Open()
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteNonQuery()
																				Me.con.Close()
																				Me.con.Open()
																				Dim text6 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
																				Me.cmd = New SqlCommand(text6)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Try
																					For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																						Dim dataGridViewRow3 As DataGridViewRow = CType(obj2, DataGridViewRow)
																						Dim isNewRow As Boolean = dataGridViewRow3.IsNewRow
																						If isNewRow Then
																							Dim memoryStream As MemoryStream = New MemoryStream()
																							Dim image As Image = CType(dataGridViewRow3.Cells("Photo").Value, Image)
																							Dim bitmap As Bitmap = New Bitmap(image)
																							bitmap.Save(memoryStream, ImageFormat.Jpeg)
																							Dim buffer As Byte() = memoryStream.GetBuffer()
																							Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
																							sqlParameter.Value = buffer
																							Me.cmd.Parameters.Add(sqlParameter)
																							Me.cmd.ExecuteNonQuery()
																							Me.cmd.Parameters.Clear()
																						End If
																					Next
																				Finally
																					Dim enumerator2 As IEnumerator
																					If TypeOf enumerator2 Is IDisposable Then
																						TryCast(enumerator2, IDisposable).Dispose()
																					End If
																				End Try
																				Me.con.Close()
																				Me.con.Open()
																				Dim text7 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
																				Me.cmd = New SqlCommand(text7)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtDefMRP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																				Dim flag32 As Boolean = dataGridViewRow.Cells("txtBatch").Value IsNot Nothing
																				If flag32 Then
																					Me.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBatch").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d5", "")
																				End If
																				Dim flag33 As Boolean = dataGridViewRow.Cells("MfgDate").Value IsNot Nothing
																				If flag33 Then
																					Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("MfgDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d6", "")
																				End If
																				Dim flag34 As Boolean = dataGridViewRow.Cells("ExpDate").Value IsNot Nothing
																				If flag34 Then
																					Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ExpDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d7", "")
																				End If
																				Dim flag35 As Boolean = dataGridViewRow.Cells("cmbSize").Value IsNot Nothing
																				If flag35 Then
																					Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d8", "")
																				End If
																				Dim flag36 As Boolean = dataGridViewRow.Cells("cmbColour").Value IsNot Nothing
																				If flag36 Then
																					Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d9", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d10", Me.txtBarcodeTempStock.Text)
																				Me.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
																				Me.cmd.Parameters.AddWithValue("@d12", "")
																				Me.cmd.Parameters.AddWithValue("@d13", "")
																				Dim flag37 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("cmbPurchaseTaxType").Value, "Inclusive", False)
																				Dim num As Double
																				If flag37 Then
																					num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)), 2)), "0.00"))
																				Else
																					num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)), 2)), "0.00"))
																				End If
																				Me.cmd.Parameters.AddWithValue("@d14", num)
																				Me.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)), 2)), "0.00"))
																				Dim flag38 As Boolean = dataGridViewRow.Cells("txtIMEI1").Value IsNot Nothing
																				If flag38 Then
																					Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI1").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d16", "")
																				End If
																				Dim flag39 As Boolean = dataGridViewRow.Cells("txtIMEI2").Value IsNot Nothing
																				If flag39 Then
																					Me.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI2").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d17", "")
																				End If
																				Me.cmd.ExecuteNonQuery()
																				Me.cmd.Parameters.Clear()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text8 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)"
																				Me.cmd = New SqlCommand(text8)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Me.Generate_GiftQR(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))))
																				Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMinStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtDefMRP").Value)))
																				Dim flag40 As Boolean = dataGridViewRow.Cells("txtBatch").Value IsNot Nothing
																				If flag40 Then
																					Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBatch").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d7", "")
																				End If
																				Dim flag41 As Boolean = dataGridViewRow.Cells("MfgDate").Value IsNot Nothing
																				If flag41 Then
																					Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("MfgDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d8", "")
																				End If
																				Dim flag42 As Boolean = dataGridViewRow.Cells("ExpDate").Value IsNot Nothing
																				If flag42 Then
																					Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ExpDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d9", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d10", "")
																				Me.cmd.Parameters.AddWithValue("@d11", "")
																				Me.cmd.Parameters.AddWithValue("@d12", "")
																				Me.cmd.Parameters.AddWithValue("@d13", "")
																				Me.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
																				Dim flag43 As Boolean = dataGridViewRow.Cells("txtIMEI1").Value IsNot Nothing
																				If flag43 Then
																					Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI1").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d15", "")
																				End If
																				Dim flag44 As Boolean = dataGridViewRow.Cells("txtIMEI2").Value IsNot Nothing
																				If flag44 Then
																					Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI2").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d16", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)))
																				Me.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)))
																				Dim memoryStream2 As MemoryStream = New MemoryStream()
																				Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
																				bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
																				Dim buffer2 As Byte() = memoryStream2.GetBuffer()
																				Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
																				sqlParameter2.Value = buffer2
																				Me.cmd.Parameters.AddWithValue("@d20", 0.0)
																				Me.cmd.Parameters.Add(sqlParameter2)
																				Me.cmd.ExecuteNonQuery()
																				Me.cmd.Parameters.Clear()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																				Me.cmd = New SqlCommand(text9)
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSalesUnit").Value))
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteReader()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text10 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																				Me.cmd = New SqlCommand(text10)
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbAltunit").Value))
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteReader()
																				Me.con.Close()
																				MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																				Me.fillProductID()
																				Me.con.Close()
																				Me.auto()
																				Me.GenerateBarcode()
																				Me.Getdata()
																				Me.strPcode = ""
																				Me.GelButtonNewRecord.Focus()
																			Catch ex As Exception
																				MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
																			Finally
																				Me.con.Close()
																			End Try
																			Me.DataforNP()
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
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600839F RID: 33695 RVA: 0x00619428 File Offset: 0x00617628
		Public Sub fillProductID()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT RTRIM(PID) FROM Product order by PID ASC", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060083A0 RID: 33696 RVA: 0x00619570 File Offset: 0x00617770
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060083A1 RID: 33697 RVA: 0x006195F4 File Offset: 0x006177F4
		Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
			Dim flag As Boolean = e.RowIndex = Me.DataGridView1.NewRowIndex
			If flag Then
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
				Dim dataGridViewCell As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(0)
				Dim dataGridViewCell2 As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
				Dim dataGridViewCell3 As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells("txtBarcode_TempStock")
				dataGridViewCell3.Value = Me.txtBarcodeTempStock.Text
				dataGridViewCell.Value = Conversion.Val(Me.txtID.Text)
				Dim flag2 As Boolean = Operators.CompareString(Me.strPcode, Me.txtProductCode.Text, False) <> 0
				If flag2 Then
					Me.strPcode = Me.txtProductCode.Text
					dataGridViewCell2.Value = Me.strPcode
				End If
			End If
		End Sub

		' Token: 0x060083A2 RID: 33698 RVA: 0x00619724 File Offset: 0x00617924
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060083A3 RID: 33699 RVA: 0x00619798 File Offset: 0x00617998
		Private Function GenerateID() As String
			Me.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = Me.rdr.HasRows
				If hasRows Then
					Me.rdr.Read()
					text = Conversions.ToString(Me.rdr("PID"))
				End If
				Dim flag As Boolean = Me.rdr IsNot Nothing
				If flag Then
					Me.rdr.Close()
				End If
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag2 As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag2 Then
					text = "000" + text
				Else
					Dim flag3 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag3 Then
						text = "00" + text
					Else
						Dim flag4 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag4 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag5 As Boolean = Me.con.State = ConnectionState.Open
				If flag5 Then
					Me.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x060083A4 RID: 33700 RVA: 0x00012199 File Offset: 0x00010399
		Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
			e.ThrowException = False
		End Sub

		' Token: 0x060083A5 RID: 33701 RVA: 0x0061992C File Offset: 0x00617B2C
		Private Sub frmProductRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F1
			If flag3 Then
				e.Handled = True
				Me.btnShowAll.PerformClick()
			End If
		End Sub

		' Token: 0x060083A6 RID: 33702 RVA: 0x0061999C File Offset: 0x00617B9C
		Public Sub fillGdown()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(GDown) FROM Product", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.ddlGdown.Items.Clear()
				Dim flag As Boolean = Me.dtable.Rows.Count > 1
				If flag Then
					Try
						For Each obj As Object In Me.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Me.ddlGdown.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Else
					Me.FillGdown_Custom()
				End If
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060083A7 RID: 33703 RVA: 0x00619B24 File Offset: 0x00617D24
		Public Sub FillGdown_Custom()
			Dim list As List(Of String) = New List(Of String)() From { "1", "2", "3", "4", "5" }
			Me.ddlGdown.Items.AddRange(list.ToArray())
		End Sub

		' Token: 0x060083A8 RID: 33704 RVA: 0x00619B8C File Offset: 0x00617D8C
		Public Sub fillRack()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Rack) FROM Product", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.ddlRack.Items.Clear()
				Dim flag As Boolean = Me.dtable.Rows.Count > 1
				If flag Then
					Try
						For Each obj As Object In Me.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Me.ddlRack.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Else
					Me.fillRack_Custom()
				End If
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060083A9 RID: 33705 RVA: 0x00619D14 File Offset: 0x00617F14
		Public Sub fillRack_Custom()
			Dim list As List(Of String) = New List(Of String)() From { "1", "2", "3", "4", "5" }
			Me.ddlRack.Items.AddRange(list.ToArray())
		End Sub

		' Token: 0x060083AA RID: 33706 RVA: 0x0004086A File Offset: 0x0003EA6A
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060083AB RID: 33707 RVA: 0x00040886 File Offset: 0x0003EA86
		Private Sub btnReset_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
			Me.strPcode = ""
		End Sub

		' Token: 0x060083AC RID: 33708 RVA: 0x00619D7C File Offset: 0x00617F7C
		Private Sub btnExportExcel_Click_1(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Dim num As Integer = Me.DataGridView1.Columns.Count - 8
					For i As Integer = 0 To num
						Dim dataGridViewColumn As DataGridViewColumn = Me.DataGridView1.Columns(i)
						dataTable.Columns.Add(dataGridViewColumn.Name)
					Next
					Dim num2 As Integer = 0
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag2 As Boolean = CDbl(num2) >= Conversion.Val(Me.txtTopResult.Text)
							If flag2 Then
								Exit For
							End If
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj2 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj2, DataGridViewCell)
									Dim flag3 As Boolean = dataGridViewCell.ColumnIndex < 49
									If flag3 Then
										dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
									End If
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
							num2 += 1
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag4 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag4 Then
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

		' Token: 0x060083AD RID: 33709 RVA: 0x0061A040 File Offset: 0x00618240
		Private Sub btnShowAll_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes
			If flag Then
				Me.Getdata()
				Me.DataGridView1.Focus()
			End If
			Me.strPcode = ""
		End Sub

		' Token: 0x060083AE RID: 33710 RVA: 0x000F58F4 File Offset: 0x000F3AF4
		Private Sub ComboBox_Enter(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			comboBox.DroppedDown = True
		End Sub

		' Token: 0x060083AF RID: 33711 RVA: 0x0061A088 File Offset: 0x00618288
		Private Sub ComboBox_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = e.KeyChar = vbCr
			If flag Then
				Dim comboBox As ComboBox = CType(sender, ComboBox)
				Dim text As String = comboBox.Text
				Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.CurrentCell, DataGridViewComboBoxCell)
				MessageBox.Show(String.Format("Enter key pressed for '{0}' in cell ({1}, {2})", text, dataGridViewComboBoxCell.RowIndex, dataGridViewComboBoxCell.ColumnIndex))
				e.Handled = True
			End If
		End Sub

		' Token: 0x060083B0 RID: 33712 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Control_KeyUp(sender As Object, e As PreviewKeyDownEventArgs)
		End Sub

		' Token: 0x060083B1 RID: 33713 RVA: 0x0061A0F4 File Offset: 0x006182F4
		Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Try
				Dim flag As Boolean = TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell
				If flag Then
					Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
					Dim flag2 As Boolean = dataGridViewComboBoxEditingControl IsNot Nothing
					If flag2 Then
						AddHandler dataGridViewComboBoxEditingControl.Enter, AddressOf Me.ComboBox_Enter
					End If
				Else
					Dim flag3 As Boolean = TypeOf Me.DataGridView1.CurrentCell Is DataGridViewTextBoxCell
					If flag3 Then
						Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
						RemoveHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
						AddHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
					End If
				End If
			Catch ex As Exception
			End Try
			Dim flag4 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 3 AndAlso TypeOf e.Control Is ComboBox
			If flag4 Then
				Dim comboBox As ComboBox = CType(e.Control, ComboBox)
				RemoveHandler comboBox.SelectedIndexChanged, AddressOf Me.ComboBox_SelectedIndexChanged
				AddHandler comboBox.SelectedIndexChanged, AddressOf Me.ComboBox_SelectedIndexChanged
				RemoveHandler comboBox.DropDownClosed, AddressOf Me.ComboBox_DropDownClosed
				AddHandler comboBox.DropDownClosed, AddressOf Me.ComboBox_DropDownClosed
			Else
				Dim flag5 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 5 AndAlso TypeOf e.Control Is ComboBox
				If flag5 Then
					Dim comboBox2 As ComboBox = CType(e.Control, ComboBox)
					RemoveHandler comboBox2.SelectedIndexChanged, AddressOf Me.cmbSubCategory_SelectedIndexChanged
					AddHandler comboBox2.SelectedIndexChanged, AddressOf Me.cmbSubCategory_SelectedIndexChanged
					RemoveHandler comboBox2.DropDownClosed, AddressOf Me.ComboBox_DropDownClosed
					AddHandler comboBox2.DropDownClosed, AddressOf Me.ComboBox_DropDownClosed
				Else
					Dim flag6 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 23 AndAlso TypeOf e.Control Is ComboBox
					If flag6 Then
						Dim comboBox3 As ComboBox = CType(e.Control, ComboBox)
						RemoveHandler comboBox3.SelectedIndexChanged, AddressOf Me.cmbPurchaseUnit_SelectedIndexChanged
						AddHandler comboBox3.SelectedIndexChanged, AddressOf Me.cmbPurchaseUnit_SelectedIndexChanged
						RemoveHandler comboBox3.DropDownClosed, AddressOf Me.cmbPurchaseUnit_DropDownClosed
						AddHandler comboBox3.DropDownClosed, AddressOf Me.cmbPurchaseUnit_DropDownClosed
					Else
						Dim flag7 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 24 AndAlso TypeOf e.Control Is ComboBox
						If flag7 Then
							Dim comboBox4 As ComboBox = CType(e.Control, ComboBox)
							AddHandler comboBox4.SelectedIndexChanged, AddressOf Me.cmbSalesUnit_SelectedIndexChanged
						Else
							Dim flag8 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = Me.DataGridView1.Columns("cmbGST").Index AndAlso TypeOf e.Control Is ComboBox
							If flag8 Then
								Dim comboBox5 As ComboBox = CType(e.Control, ComboBox)
								RemoveHandler comboBox5.SelectedIndexChanged, AddressOf Me.cmbGST_SelectedIndexChanged
								AddHandler comboBox5.SelectedIndexChanged, AddressOf Me.cmbGST_SelectedIndexChanged
								RemoveHandler comboBox5.DropDownClosed, AddressOf Me.cmbGST_DropDownClosed
								AddHandler comboBox5.DropDownClosed, AddressOf Me.cmbGST_DropDownClosed
							Else
								Dim flag9 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = Me.DataGridView1.Columns("txtCGST").Index AndAlso TypeOf e.Control Is TextBox
								If flag9 Then
									Dim textBox As TextBox = CType(e.Control, TextBox)
									AddHandler textBox.TextChanged, AddressOf Me.txtCGST_TextChanged
								Else
									Dim flag10 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = Me.DataGridView1.Columns("txtSGST").Index AndAlso TypeOf e.Control Is TextBox
									If flag10 Then
										Dim textBox2 As TextBox = CType(e.Control, TextBox)
										AddHandler textBox2.TextChanged, AddressOf Me.txtSGST_TextChanged
									Else
										Dim flag11 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = Me.DataGridView1.Columns("txtIGST").Index AndAlso TypeOf e.Control Is TextBox
										If flag11 Then
											Dim textBox3 As TextBox = CType(e.Control, TextBox)
											AddHandler textBox3.TextChanged, AddressOf Me.txtIGST_TextChanged
										Else
											Dim flag12 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 21 AndAlso TypeOf e.Control Is Button
											If Not flag12 Then
												Dim flag13 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 32
												If flag13 Then
													Dim comboBox6 As ComboBox = CType(e.Control, ComboBox)
													RemoveHandler comboBox6.DropDownClosed, AddressOf Me.cmbGdown_DropDownClosed
													AddHandler comboBox6.DropDownClosed, AddressOf Me.cmbGdown_DropDownClosed
												Else
													Dim flag14 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 33
													If flag14 Then
														Dim comboBox7 As ComboBox = CType(e.Control, ComboBox)
														RemoveHandler comboBox7.DropDownClosed, AddressOf Me.cmbRack_DropDownClosed
														AddHandler comboBox7.DropDownClosed, AddressOf Me.cmbRack_DropDownClosed
													Else
														Dim flag15 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 46 AndAlso TypeOf e.Control Is TextBox
														If flag15 Then
															Dim textBox4 As TextBox = CType(e.Control, TextBox)
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
			End If
		End Sub

		' Token: 0x060083B2 RID: 33714 RVA: 0x00602D6C File Offset: 0x00600F6C
		Private Sub cmbGdown_LostFocus(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim list As List(Of ComboBoxItem) = New List(Of ComboBoxItem)()
			list.Add(New ComboBoxItem("Item 1", 1))
			list.Add(New ComboBoxItem("Item 2", 2))
			list.Add(New ComboBoxItem("Item 3", 3))
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			dataGridViewComboBoxEditingControl.Items.Add(list)
		End Sub

		' Token: 0x060083B3 RID: 33715 RVA: 0x00602DD4 File Offset: 0x00600FD4
		Private Sub cmbSubCategory_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 5
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 4
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.BeginEdit(True)
		End Sub

		' Token: 0x060083B4 RID: 33716 RVA: 0x00602E60 File Offset: 0x00601060
		Private Sub cmbPurchaseUnit_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 23
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 12
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.BeginEdit(True)
		End Sub

		' Token: 0x060083B5 RID: 33717 RVA: 0x00602EF0 File Offset: 0x006010F0
		Private Sub cmbGdown_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 32
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 1
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.EndEdit(CType((-1), DataGridViewDataErrorContexts))
		End Sub

		' Token: 0x060083B6 RID: 33718 RVA: 0x0061A6A8 File Offset: 0x006188A8
		Private Sub cmbRack_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 33
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 1
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			Dim flag2 As Boolean = rowIndex < editingControlDataGridView.Rows.Count AndAlso num < editingControlDataGridView.Columns.Count
			If flag2 Then
				Dim dataGridViewCell As DataGridViewCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
				Dim flag3 As Boolean = editingControlDataGridView.Rows(rowIndex).Visible AndAlso editingControlDataGridView.Columns(num).Visible
				If flag3 Then
					editingControlDataGridView.CurrentCell = dataGridViewCell
				End If
			End If
			editingControlDataGridView.EndEdit(CType((-1), DataGridViewDataErrorContexts))
		End Sub

		' Token: 0x060083B7 RID: 33719 RVA: 0x00603008 File Offset: 0x00601208
		Private Sub cmbSize_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim num As Integer = editingControlDataGridView.CurrentCell.ColumnIndex
			Dim flag As Boolean = num = 43
			If flag Then
				num += 1
			End If
			While num < editingControlDataGridView.ColumnCount AndAlso (Not editingControlDataGridView.Columns(num).Visible OrElse Not editingControlDataGridView.Rows(rowIndex).Cells(num).Visible)
				num += 1
			End While
			Dim flag2 As Boolean = num < editingControlDataGridView.ColumnCount
			If flag2 Then
				editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
				editingControlDataGridView.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060083B8 RID: 33720 RVA: 0x006030E4 File Offset: 0x006012E4
		Private Sub cmbColour_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 44
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 1
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.EndEdit(CType((-1), DataGridViewDataErrorContexts))
		End Sub

		' Token: 0x060083B9 RID: 33721 RVA: 0x0061A790 File Offset: 0x00618990
		Private Sub SetComboBoxColumnSelectedIndex(rowIndex As Integer, name As String, selectedIndex As Integer)
			Dim flag As Boolean = rowIndex >= 0 AndAlso rowIndex < Me.DataGridView1.Rows.Count
			If flag Then
				Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = TryCast(Me.DataGridView1.Rows(rowIndex).Cells(name), DataGridViewComboBoxCell)
				dataGridViewComboBoxCell.Value = RuntimeHelpers.GetObjectValue(dataGridViewComboBoxCell.Items(selectedIndex))
			End If
		End Sub

		' Token: 0x060083BA RID: 33722 RVA: 0x00603170 File Offset: 0x00601370
		Private Sub cmbGST_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 14
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 5
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.BeginEdit(True)
		End Sub

		' Token: 0x060083BB RID: 33723 RVA: 0x0061A7F8 File Offset: 0x006189F8
		Private Sub PreTranslateDGV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewTextBoxEditingControl.EditingControlDataGridView
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = editingControlDataGridView.ColumnCount - 1
				Dim num As Integer
				Dim num2 As Integer
				If flag2 Then
					num = editingControlDataGridView.CurrentCell.RowIndex + 1
					num2 = 0
					Dim flag3 As Boolean = num = editingControlDataGridView.RowCount
					If flag3 Then
						editingControlDataGridView.Rows.Add(1)
					End If
				Else
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 1
					While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
						num2 += 1
					End While
				End If
				Dim flag4 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 19
				If flag4 Then
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 4
				End If
				Dim flag5 As Boolean = TypeOf Me.DataGridView1.CurrentCell Is DataGridViewButtonCell
				If flag5 Then
					Dim name As String = Me.DataGridView1.CurrentCell.OwningColumn.Name
					If Operators.CompareString(name, "InsertButtonColumn", False) = 0 Then
						Me.DBoperation(num, "Insert")
					End If
				Else
					Me.DataGridView1.BeginEdit(True)
				End If
				While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
					num2 += 1
				End While
				Dim flag6 As Boolean = num2 < editingControlDataGridView.ColumnCount
				If flag6 Then
					editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(num).Cells(num2)
					Dim flag7 As Boolean = New Integer() { 8, 23, 32 }.Contains(num2)
					If flag7 Then
						editingControlDataGridView.BeginEdit(True)
					End If
				End If
			End If
		End Sub

		' Token: 0x060083BC RID: 33724 RVA: 0x0061A9E4 File Offset: 0x00618BE4
		Private Sub TextBox_GotFocus(sender As Object, e As EventArgs)
			Dim textBox As TextBox = CType(sender, TextBox)
			textBox.SelectionStart = textBox.TextLength
			textBox.SelectionLength = 0
		End Sub

		' Token: 0x060083BD RID: 33725 RVA: 0x0061AA10 File Offset: 0x00618C10
		Private Sub textbox_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim dataGridView As DataGridView = CType(sender, DataGridView)
				e.Handled = True
				Dim flag2 As Boolean = dataGridView.CurrentCell.ColumnIndex < dataGridView.ColumnCount - 1
				If flag2 Then
					dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex)
				Else
					Dim flag3 As Boolean = dataGridView.CurrentCell.RowIndex < dataGridView.RowCount - 1
					If flag3 Then
						dataGridView.CurrentCell = dataGridView(0, dataGridView.CurrentCell.RowIndex + 1)
					End If
				End If
			End If
		End Sub

		' Token: 0x060083BE RID: 33726 RVA: 0x0061AAB8 File Offset: 0x00618CB8
		Private Sub txtSGST_TextChanged(sender As Object, byvale As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = TryCast(sender, DataGridViewTextBoxEditingControl)
			Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtCGST"), DataGridViewTextBoxCell)
			Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtIGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxEditingControl.EditingControlFormattedValue = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value)), 2), "0.00")
			dataGridViewTextBoxCell2.Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxEditingControl.EditingControlFormattedValue))
		End Sub

		' Token: 0x060083BF RID: 33727 RVA: 0x0061AB8C File Offset: 0x00618D8C
		Private Sub txtIGST_TextChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = TryCast(sender, DataGridViewTextBoxEditingControl)
			Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtCGST"), DataGridViewTextBoxCell)
			Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtSGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxEditingControl.EditingControlFormattedValue = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell2.Value)), 2), "0.00")
		End Sub

		' Token: 0x060083C0 RID: 33728 RVA: 0x0061AC44 File Offset: 0x00618E44
		Private Sub txtCGST_TextChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = TryCast(sender, DataGridViewTextBoxEditingControl)
			Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtSGST"), DataGridViewTextBoxCell)
			Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtIGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxCell.Value = RuntimeHelpers.GetObjectValue(dataGridViewTextBoxEditingControl.EditingControlFormattedValue)
			dataGridViewTextBoxCell2.Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxEditingControl.EditingControlFormattedValue)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value))
		End Sub

		' Token: 0x060083C1 RID: 33729 RVA: 0x0061ACFC File Offset: 0x00618EFC
		Private Sub cmbPurchaseUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
			Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(24), DataGridViewComboBoxCell)
			dataGridViewComboBoxCell.Value = dataGridViewComboBoxEditingControl.EditingControlFormattedValue.ToString()
			Dim dataGridViewComboBoxCell2 As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(25), DataGridViewComboBoxCell)
			dataGridViewComboBoxCell2.Value = dataGridViewComboBoxEditingControl.EditingControlFormattedValue.ToString()
		End Sub

		' Token: 0x060083C2 RID: 33730 RVA: 0x0061AD94 File Offset: 0x00618F94
		Private Sub cmbSalesUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
			Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("cmbPurchaseUnit"), DataGridViewComboBoxCell)
			dataGridViewComboBoxEditingControl.EditingControlFormattedValue = RuntimeHelpers.GetObjectValue(dataGridViewComboBoxCell.Value)
			Dim dataGridViewComboBoxCell2 As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(25), DataGridViewComboBoxCell)
			dataGridViewComboBoxCell2.Value = RuntimeHelpers.GetObjectValue(dataGridViewComboBoxEditingControl.EditingControlFormattedValue)
		End Sub

		' Token: 0x060083C3 RID: 33731 RVA: 0x0061AE30 File Offset: 0x00619030
		Private Sub cmbGST_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
			Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtCGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxCell.Value = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewComboBoxEditingControl.EditingControlFormattedValue)) / 2.0, 2), "0.00")
			Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtSGST"), DataGridViewTextBoxCell)
			Dim dataGridViewTextBoxCell3 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtIGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxCell2.Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value))
			dataGridViewTextBoxCell3.Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell2.Value))
		End Sub

		' Token: 0x060083C4 RID: 33732 RVA: 0x0003FB88 File Offset: 0x0003DD88
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			MessageBox.Show("clicked")
			Throw New NotImplementedException()
		End Sub

		' Token: 0x060083C5 RID: 33733 RVA: 0x000098CC File Offset: 0x00007ACC
		Private Sub LastColumnComboSelectionChanged(sender As Object, e As EventArgs)
			Throw New NotImplementedException()
		End Sub

		' Token: 0x060083C6 RID: 33734 RVA: 0x00603888 File Offset: 0x00601A88
		Private Function ShouldRemoveItem(item As Object) As Boolean
			Return item.ToString().Equals("X")
		End Function

		' Token: 0x060083C7 RID: 33735 RVA: 0x0061AF58 File Offset: 0x00619158
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
				Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
				Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(0), DataGridViewTextBoxCell)
				dataGridViewTextBoxCell.Value = dataGridViewComboBoxEditingControl.EditingControlFormattedValue.ToString()
				Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(5), DataGridViewComboBoxCell)
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = "SELECT distinct RTRIM(SubCategoryName) FROM SubCategory,Category where SubCategory.Category=Category.CategoryName and CategoryName=@d1"
				Me.cmd = New SqlCommand(text)
				Me.cmd.Connection = Me.con
				Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value))
				Me.rdr = Me.cmd.ExecuteReader()
				While Me.rdr.Read()
					Dim list As List(Of Object) = New List(Of Object)()
					Try
						For Each obj As Object In dataGridViewComboBoxCell.Items
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim flag As Boolean = Not objectValue.Equals(RuntimeHelpers.GetObjectValue(Me.rdr(0)))
							If flag Then
								list.Add(RuntimeHelpers.GetObjectValue(objectValue))
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In list
							Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
							dataGridViewComboBoxCell.Items.Remove(RuntimeHelpers.GetObjectValue(objectValue2))
						Next
					Finally
						Dim enumerator2 As List(Of Object).Enumerator
						CType(enumerator2, IDisposable).Dispose()
					End Try
				End While
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Me.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060083C8 RID: 33736 RVA: 0x0061B1BC File Offset: 0x006193BC
		Private Sub ComboBox_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
			Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
			Me.DataGridView1.CurrentCell = Me.DataGridView1(columnIndex, rowIndex)
			Me.DataGridView1.EndEdit()
			AddHandler Me.DataGridView1.CellClick, AddressOf Me.DataGridView1_CellClick
		End Sub

		' Token: 0x060083C9 RID: 33737 RVA: 0x0061B230 File Offset: 0x00619430
		Private Sub DataGridView12_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = TypeOf Me.DataGridView1.Columns(e.ColumnIndex)Is DataGridViewComboBoxColumn AndAlso e.RowIndex >= 0
			If flag Then
				' The following expression was wrapped in a checked-expression
				Me.DataGridView1.CurrentCell = Me.DataGridView1(e.ColumnIndex + 1, e.RowIndex)
				Me.DataGridView1.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060083CA RID: 33738 RVA: 0x0061B2A4 File Offset: 0x006194A4
		Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = TypeOf Me.DataGridView1.Columns(e.ColumnIndex)Is DataGridViewComboBoxColumn AndAlso e.RowIndex >= 0
			If flag Then
				Me.DataGridView1.CurrentCell = Me.DataGridView1(e.ColumnIndex, e.RowIndex)
				Me.DataGridView1.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060083CB RID: 33739 RVA: 0x0061B314 File Offset: 0x00619514
		Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = TryCast(sender, ComboBox)
			Dim flag As Boolean = comboBox IsNot Nothing AndAlso TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell
			If flag Then
				Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
				Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
				Dim flag2 As Boolean = columnIndex = 3
				If flag2 Then
					Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(rowIndex).Cells("cmbSubCategory"), DataGridViewComboBoxCell)
					dataGridViewComboBoxCell.Items.Clear()
					dataGridViewComboBoxCell.Items.Add("Select")
					Dim flag3 As Boolean = comboBox.SelectedItem IsNot Nothing
					If flag3 Then
						Dim flag4 As Boolean = Operators.CompareString(comboBox.SelectedItem.ToString(), "System.Data.DataRowView", False) <> 0
						If flag4 Then
							Dim text As String = comboBox.SelectedItem.ToString()
							Dim array As DataRow() = Me.subcategories.[Select]("CategoryName = '" + text + "'")
							For Each dataRow As DataRow In array
								dataGridViewComboBoxCell.Items.Add(RuntimeHelpers.GetObjectValue(dataRow("SubcategoryName")))
							Next
							comboBox.Focus()
						End If
					End If
				Else
					Dim flag5 As Boolean = columnIndex = 5
					If flag5 Then
					End If
				End If
			End If
		End Sub

		' Token: 0x060083CC RID: 33740 RVA: 0x0061B478 File Offset: 0x00619678
		Public Sub FillSubCat()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(SubCategoryName) FROM SubCategory order by 1", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbSubCategory.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSubCategory.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060083CD RID: 33741 RVA: 0x0061B5C0 File Offset: 0x006197C0
		Public Sub FillSubCat(Val As String, CurrentCellNo As Integer)
			Dim text As String = "SELECT distinct RTRIM(SubCategoryName) FROM SubCategory,Category where SubCategory.Category=Category.CategoryName and CategoryName=@d1"
			Me.cmd = New SqlCommand(text)
			Dim flag As Boolean = Me.con.State = ConnectionState.Closed
			If flag Then
				Me.con.Open()
			End If
			Me.cmd.Connection = Me.con
			Me.cmd.Parameters.AddWithValue("@d1", Val)
			Me.rdr = Me.cmd.ExecuteReader()
			Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(CurrentCellNo).Cells(5), DataGridViewComboBoxCell)
			While Me.rdr.Read()
				dataGridViewComboBoxCell.Items.Add(RuntimeHelpers.GetObjectValue(Me.rdr(0)))
			End While
			Dim flag2 As Boolean = Me.rdr IsNot Nothing
			If flag2 Then
				Me.rdr.Close()
			End If
			Me.con.Close()
		End Sub

		' Token: 0x060083CE RID: 33742 RVA: 0x0061B6B4 File Offset: 0x006198B4
		Private Sub cmbSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
				Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
				Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(0), DataGridViewTextBoxCell)
				dataGridViewTextBoxCell.Value = dataGridViewComboBoxEditingControl.EditingControlFormattedValue.ToString()
				Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(7), DataGridViewTextBoxCell)
				Try
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Me.cmd = Me.con.CreateCommand()
					Me.cmd.CommandText = "SELECT ID from SubCategory where Category=@d1 and SubCategoryName=@d2"
					Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(3), DataGridViewComboBoxCell).Value))
					Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value))
					Me.rdr = Me.cmd.ExecuteReader()
					Dim flag As Boolean = Me.rdr.Read()
					If flag Then
						dataGridViewTextBoxCell2.Value = RuntimeHelpers.GetObjectValue(Me.rdr.GetValue(0))
					End If
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
					Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
					If flag3 Then
						Me.con.Close()
					End If
				Catch ex As Exception
				End Try
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x060083CF RID: 33743 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x060083D0 RID: 33744 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSubCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060083D1 RID: 33745 RVA: 0x0061B8B4 File Offset: 0x00619AB4
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.DataGridView1.[ReadOnly] = False
			Dim num As Integer = Me.DataGridView1.Rows.Count - 1
			Dim num2 As Integer = 2
			Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(num).Cells(num2)
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
					If isNewRow Then
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(2).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(2).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(3).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(3).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(5).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(5).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtCostPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtCostPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDiscount").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDiscount").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtMinStock").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtMinStock").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbPurchaseUnit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbPurchaseUnit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbSalesUnit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbSalesUnit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbAltunit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbAltunit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("Conv").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("Conv").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtSaleQty").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtSaleQty").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDefMRP").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDefMRP").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("RSPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("RSPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("WSPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("WSPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtBarcode_TempStock").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtBarcode_TempStock").Style.ForeColor = Color.White
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.DataGridView1.BeginEdit(True)
			Me.DataGridView1.Rows(num).Cells(8).Value = 0
			Me.DataGridView1.Rows(num).Cells(13).Value = 0.0
			Me.DataGridView1.Rows(num).Cells("txtCESS").Value = "0.00"
			Me.DataGridView1.Rows(num).Cells("txtMinStock").Value = "0.00"
			Me.DataGridView1.Rows(num).Cells("Conv").Value = 1
			Me.DataGridView1.Rows(num).Cells("txtSaleQty").Value = 1
			Me.SetComboBoxColumnSelectedIndex(num, "cmbSalesTaxType", 0)
			Me.SetComboBoxColumnSelectedIndex(num, "cmbPurchaseTaxType", 0)
			Me.default_fill_tax()
			Me.default_fill_Category_data()
			Me.default_fillUnit_Default()
			Me.default_Tax_type()
		End Sub

		' Token: 0x060083D2 RID: 33746 RVA: 0x0003FB9B File Offset: 0x0003DD9B
		Private Sub btnProductSeting_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductSeting.ShowDialog()
		End Sub

		' Token: 0x060083D3 RID: 33747 RVA: 0x0061C0EC File Offset: 0x0061A2EC
		Private Sub btnBulkImageUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim num As Integer = 0
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag2 As Boolean = Conversions.ToBoolean(Operators.AndObject(dataGridViewRow.Cells(54).Value IsNot Nothing, Operators.CompareObjectEqual(dataGridViewRow.Cells(54).Value, True, False)))
						If flag2 Then
							num += 1
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag3 As Boolean = num <= 0
				If flag3 Then
					MessageBox.Show("Please select item list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Me.getImage()
				End If
			End If
		End Sub

		' Token: 0x060083D4 RID: 33748 RVA: 0x0061C20C File Offset: 0x0061A40C
		Public Async Sub getImage()
			Try
				Dim flag As Boolean = ModFunc.CheckForInternetConnection()
				If flag Then
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim row As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim isSelected As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(row.Cells(54).Value))
							Dim flag2 As Boolean = isSelected
							If flag2 Then
								Dim result As List(Of WebImage) = Await QImage.Query(row.Cells(2).Value.ToString(), 1)
								Me.Picture.Image = result(0).Image
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim cb As String = "delete from Product_Join where ProductID=@d1"
								Me.cmd = New SqlCommand(cb)
								Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(row.Cells(0).Value.ToString()))
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteReader()
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim ck As String = "insert into Product_Join(ProductID,Photo) VALUES (" + row.Cells(0).Value.ToString() + ",@d2)"
								Me.cmd = New SqlCommand(ck)
								Me.cmd.Connection = Me.con
								Me.cmd.Prepare()
								Dim ms As MemoryStream = New MemoryStream()
								Dim img As Image = Me.Picture.Image
								Dim bmpImage As Bitmap = New Bitmap(img)
								bmpImage.Save(ms, ImageFormat.Jpeg)
								Dim data As Byte() = ms.GetBuffer()
								Dim p As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
								p.Value = data
								Me.cmd.Parameters.Add(p)
								Me.cmd.ExecuteNonQuery()
								Me.cmd.Parameters.Clear()
								row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#C9E639")
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Me.DataGridView1.Rows.Clear()
					Me.Getdata()
					Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
					Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
					Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
					Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
				Else
					MessageBox.Show("Internet Connction not found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x060083D5 RID: 33749 RVA: 0x0061C248 File Offset: 0x0061A448
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Cells(54).Value = True
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
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataGridViewRow2.Cells(54).Value = False
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

		' Token: 0x060083D6 RID: 33750 RVA: 0x0061C358 File Offset: 0x0061A558
		Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim num As Integer = Me.DataGridView1.Rows.Count - 1
			Dim num2 As Integer = 2
			Dim flag As Boolean = e.ColumnIndex = num2 AndAlso e.RowIndex = num
			If flag Then
				MessageBox.Show("Fill Details for New Product Entry!")
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(num).Cells(num2)
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
						If isNewRow Then
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(2).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(2).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(3).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(3).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(5).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(5).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtCostPrice").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtCostPrice").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDiscount").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDiscount").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtMinStock").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtMinStock").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbPurchaseUnit").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbPurchaseUnit").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbSalesUnit").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbSalesUnit").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbAltunit").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbAltunit").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("Conv").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("Conv").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtSaleQty").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtSaleQty").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDefMRP").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDefMRP").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("RSPrice").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("RSPrice").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("WSPrice").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("WSPrice").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtBarcode_TempStock").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtBarcode_TempStock").Style.ForeColor = Color.White
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.DataGridView1.Rows(num).Cells(8).Value = 0
				Me.DataGridView1.Rows(num).Cells(13).Value = 0.0
				Me.DataGridView1.Rows(num).Cells("txtCESS").Value = "0.00"
				Me.DataGridView1.Rows(num).Cells("txtMinStock").Value = "0.00"
				Me.DataGridView1.Rows(num).Cells("Conv").Value = 1
				Me.DataGridView1.Rows(num).Cells("txtSaleQty").Value = 1
				Me.SetComboBoxColumnSelectedIndex(num, "cmbSalesTaxType", 0)
				Me.SetComboBoxColumnSelectedIndex(num, "cmbPurchaseTaxType", 0)
			End If
		End Sub

		' Token: 0x060083D7 RID: 33751 RVA: 0x0061CBA4 File Offset: 0x0061ADA4
		Private Sub SetupDataGridViewColumns()
			Me.Gridmenusetting()
			Dim num As Integer = 0
			Do
				Me.DataGridView1.Columns(num).Frozen = True
				num += 1
			Loop While num <= 4
			Me.DataGridView1.ScrollBars = ScrollBars.Both
		End Sub

		' Token: 0x060083D8 RID: 33752 RVA: 0x0061CBE8 File Offset: 0x0061ADE8
		Private Sub Gridmenusetting()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				sqlDataAdapter.SelectCommand = New SqlCommand("SELECT menu_name, is_active FROM product_menu_setting", Me.con)
				Dim dataSet As DataSet = New DataSet("ds1")
				sqlDataAdapter.Fill(dataSet, "menu_setting")
				Dim dataTable As DataTable = dataSet.Tables("menu_setting")
				Try
					For Each obj As Object In dataTable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Dim text As String = dataRow("menu_name").ToString()
						Dim num As Short = Conversions.ToShort(dataRow("is_active").ToString())
						Try
							For Each obj2 As Object In Me.DataGridView1.Columns
								Dim dataGridViewColumn As DataGridViewColumn = CType(obj2, DataGridViewColumn)
								Dim flag As Boolean = Operators.CompareString(dataGridViewColumn.DataPropertyName, text, False) = 0
								If flag Then
									Dim flag2 As Boolean = num = 0S
									If flag2 Then
										dataGridViewColumn.Visible = False
									Else
										dataGridViewColumn.Visible = True
									End If
									Exit For
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060083D9 RID: 33753 RVA: 0x0061CDD0 File Offset: 0x0061AFD0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim text As String = Conversions.ToString(Me.dt.Rows(0)("Productname"))
			Dim text2 As String = Conversions.ToString(Me.dt.Rows(0)("CategoryName"))
			Dim flag As Boolean = Me.dt.Rows.Count > 0
			If flag Then
				Try
					Dim num As Integer = Me.DataGridView2.Rows.Count - 1
					For i As Integer = 1 To num
						Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
						Dim isNewRow As Boolean = dataGridViewRow.IsNewRow

							If Not isNewRow Then
								Me.txtID.Text = Me.GenerateID()
								Me.txtProductCode.Text = "P-" + Me.GenerateID()
								Me.BCodeDisplay()
								Dim text3 As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
								Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text3
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text4 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "        Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33)"
								Me.cmd = New SqlCommand(text4)
								Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
								Me.cmd.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
								Me.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)("Productname").ToString())
								Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.dt.Rows(0)("SubCategoryID").ToString()))
								Dim flag2 As Boolean = Me.dt.Rows(0)("Description").ToString() <> Nothing
								If flag2 Then
									Me.cmd.Parameters.AddWithValue("@d4", Me.dt.Rows(0)("Description").ToString())
								Else
									Me.cmd.Parameters.AddWithValue("@d4", Me.dt.Rows(0)("Productname").ToString())
								End If
								Dim flag3 As Boolean = dataGridViewRow.Cells("CostPrice").Value IsNot Nothing
								If flag3 Then
									Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d5", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.dt.Rows(0)("Discount").ToString()))
								Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.dt.Rows(0)("CGST").ToString()))
								Me.cmd.Parameters.AddWithValue("@d11", Me.txtBarcodeTempStock.Text)
								Me.cmd.Parameters.AddWithValue("@d12", Me.dt.Rows(0)("PurchaseUnit").ToString())
								Me.cmd.Parameters.AddWithValue("@d13", Me.dt.Rows(0)("SalesUnit").ToString())
								Me.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.dt.Rows(0)("SGST").ToString()))
								Me.cmd.Parameters.AddWithValue("@d15", Me.dt.Rows(0)("HSNCode").ToString())
								Me.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("PartNo").ToString())
								Me.cmd.Parameters.AddWithValue("@d17", Me.dt.Rows(0)("CESS").ToString())
								Me.cmd.Parameters.AddWithValue("@d18", Me.dt.Rows(0)("SalesAltUnit").ToString())
								Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(Me.dt.Rows(0)("Conv").ToString()))
								Me.cmd.Parameters.AddWithValue("@d20", Conversion.Val(Me.dt.Rows(0)("MinStock").ToString()))
								Me.cmd.Parameters.AddWithValue("@d22", "Yes")
								Me.cmd.Parameters.AddWithValue("@d23", Me.dt.Rows(0)("STax").ToString())
								Me.cmd.Parameters.AddWithValue("@d24", Me.dt.Rows(0)("PTax").ToString())
								Me.cmd.Parameters.AddWithValue("@d25", Me.dt.Rows(0)("GDown").ToString())
								Me.cmd.Parameters.AddWithValue("@d26", Me.dt.Rows(0)("Rack").ToString())
								Dim flag4 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag4 Then
									Me.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d27", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d28", Me.dt.Rows(0)("SPrice").ToString())
								Me.cmd.Parameters.AddWithValue("@d29", Me.dt.Rows(0)("ReorderPoint").ToString())
								Dim flag5 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag5 Then
									Me.cmd.Parameters.AddWithValue("@d30", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d30", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
								Me.cmd.Parameters.AddWithValue("@d32", Me.dt.Rows(0)("DefQty").ToString())
								Me.cmd.Parameters.AddWithValue("@d33", "")
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteNonQuery()
								Me.con.Close()
								Me.con.Open()
								Dim text5 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
								Me.cmd = New SqlCommand(text5)
								Me.cmd.Connection = Me.con
								Me.cmd.Prepare()
								Try
									For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
										Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
										Dim isNewRow2 As Boolean = dataGridViewRow2.IsNewRow
										If isNewRow2 Then
											Dim memoryStream As MemoryStream = New MemoryStream()
											Dim image As Image = CType(dataGridViewRow2.Cells("Photo").Value, Image)
											Dim bitmap As Bitmap = New Bitmap(image)
											bitmap.Save(memoryStream, ImageFormat.Jpeg)
											Dim buffer As Byte() = memoryStream.GetBuffer()
											Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
											sqlParameter.Value = buffer
											Me.cmd.Parameters.Add(sqlParameter)
											Me.cmd.ExecuteNonQuery()
											Me.cmd.Parameters.Clear()
										End If
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								Me.con.Close()
								Me.con.Open()
								Dim text6 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
								Me.cmd = New SqlCommand(text6)
								Me.cmd.Connection = Me.con
								Me.cmd.Prepare()
								Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
								Dim flag6 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag6 Then
									Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d1", 0)
								End If
								Dim flag7 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag7 Then
									Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d2", 0)
								End If
								Dim flag8 As Boolean = dataGridViewRow.Cells("txtRSP1").Value IsNot Nothing
								If flag8 Then
									Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP1").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d3", 0)
								End If
								Dim flag9 As Boolean = Operators.ConditionalCompareObjectGreater(Me.dt.Rows(0)("WPrice"), 0, False)
								If flag9 Then
									Me.cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(Me.dt.Rows(0)("WPrice"))))
								Else
									Me.cmd.Parameters.AddWithValue("@d4", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d5", Me.dt.Rows(0)("Batch").ToString())
								Me.cmd.Parameters.AddWithValue("@d6", Me.dt.Rows(0)("Mfgdate").ToString())
								Me.cmd.Parameters.AddWithValue("@d7", Me.dt.Rows(0)("Expdate").ToString())
								Dim flag10 As Boolean = dataGridViewRow.Cells("cmbSize2").Value IsNot Nothing
								If flag10 Then
									Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize2").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d8", "")
								End If
								Dim flag11 As Boolean = dataGridViewRow.Cells("cmbColour2").Value IsNot Nothing
								If flag11 Then
									Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour2").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d9", "")
								End If
								Me.cmd.Parameters.AddWithValue("@d10", Me.txtBarcodeTempStock.Text)
								Me.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
								Me.cmd.Parameters.AddWithValue("@d12", "")
								Me.cmd.Parameters.AddWithValue("@d13", "")
								Dim flag12 As Boolean = Operators.CompareString(Me.dt.Rows(0)("PTax").ToString(), "Inclusive", False) = 0
								Dim num2 As Double
								If flag12 Then
									num2 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)), 2)), "0.00"))
								Else
									num2 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)), 2)), "0.00"))
								End If
								Me.cmd.Parameters.AddWithValue("@d14", num2)
								Me.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num2 * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)), 2)), "0.00"))
								Me.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("IMEI1").ToString().Trim())
								Me.cmd.Parameters.AddWithValue("@d17", Me.dt.Rows(0)("IMEI2").ToString().Trim())
								Me.cmd.ExecuteNonQuery()
								Me.cmd.Parameters.Clear()
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text7 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "        Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur, Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
								Me.cmd = New SqlCommand(text7)
								Me.cmd.Connection = Me.con
								Me.cmd.Prepare()
								Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
								Dim flag13 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag13 Then
									Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d1", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d2", Me.txtBarcodeTempStock.Text)
								Dim flag14 As Boolean = dataGridViewRow.Cells("txtRSP1").Value IsNot Nothing
								If flag14 Then
									Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP1").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d3", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(Me.dt.Rows(0)("WPrice").ToString()))
								Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.dt.Rows(0)("StLimit").ToString()))
								Dim flag15 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag15 Then
									Me.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d6", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d7", Me.dt.Rows(0)("Batch").ToString())
								Me.cmd.Parameters.AddWithValue("@d8", Me.dt.Rows(0)("MfgDate").ToString())
								Me.cmd.Parameters.AddWithValue("@d9", Me.dt.Rows(0)("ExpDate").ToString())
								Dim flag16 As Boolean = dataGridViewRow.Cells("cmbSize2").Value IsNot Nothing
								If flag16 Then
									Me.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize2").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d10", "")
								End If
								Dim flag17 As Boolean = dataGridViewRow.Cells("cmbColour2").Value IsNot Nothing
								If flag17 Then
									Me.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour2").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d11", "")
								End If
								Me.cmd.Parameters.AddWithValue("@d12", Me.dt.Rows(0)("SalePrice").ToString())
								Me.cmd.Parameters.AddWithValue("@d13", Me.dt.Rows(0)("WSalePrice").ToString())
								Me.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
								Me.cmd.Parameters.AddWithValue("@d15", Me.dt.Rows(0)("IMEI1").ToString())
								Me.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("IMEI2").ToString())
								Me.cmd.Parameters.AddWithValue("@d17", Convert.ToDecimal(Me.dt.Rows(0)("PPrice").ToString()))
								Me.cmd.Parameters.AddWithValue("@d18", Convert.ToDecimal(Me.dt.Rows(0)("EPPrice").ToString()))
								Me.Generate_GiftQR(Me.txtBarcodeTempStock.Text)
								Dim memoryStream2 As MemoryStream = New MemoryStream()
								Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
								Dim buffer2 As Byte() = memoryStream2.GetBuffer()
								Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
								sqlParameter2.Value = buffer2
								Me.cmd.Parameters.AddWithValue("@d20", 0.0)
								Me.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView2.Rows(0).Cells("PID2").Value)))
								Me.cmd.Parameters.Add(sqlParameter2)
								Me.cmd.ExecuteNonQuery()
								Me.cmd.Parameters.Clear()
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text8 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
								Me.cmd = New SqlCommand(text8)
								Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								Me.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)("SalesUnit").ToString())
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteReader()
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
								Me.cmd = New SqlCommand(text9)
								Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								Me.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)("SalesAltUnit").ToString())
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteReader()
								Me.con.Close()
							End If

					Next
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text10 As String = "Update Temp_Stock set Qty=@d1,Variant_id=@d2 where ProductID=@d2"
					Me.cmd = New SqlCommand(text10)
					Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView2.Rows(0).Cells("txtOpeningStock2").Value)))
					Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView2.Rows(0).Cells("PID2").Value)))
					Me.cmd.Connection = Me.con
					Me.cmd.ExecuteReader()
					Me.con.Close()
				Catch ex As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				Finally
					Me.con.Close()
				End Try
				MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.pnlVariant.Visible = False
				Me.DataGridView2.Visible = False
				Me.Getdata()
			End If
		End Sub

		' Token: 0x060083DA RID: 33754 RVA: 0x0061E7B4 File Offset: 0x0061C9B4
		Private Sub gridtodatatable()
			Dim dataTable As DataTable = New DataTable()
			Try
				For Each obj As Object In Me.DataGridView2.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim type As Type = If(dataGridViewColumn.ValueType, GetType(String))
					dataTable.Columns.Add(dataGridViewColumn.HeaderText, type)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim num As Integer = Me.DataGridView2.Rows.Count - 1
			For i As Integer = 1 To num
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
				Dim flag As Boolean = Not dataGridViewRow.IsNewRow
				If flag Then
					Dim dataRow As DataRow = dataTable.NewRow()
					Dim num2 As Integer = Me.DataGridView2.Columns.Count - 1
					For j As Integer = 0 To num2
						dataRow(j) = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(j).Value)
					Next
					dataTable.Rows.Add(dataRow)
				End If
			Next
		End Sub

		' Token: 0x060083DB RID: 33755 RVA: 0x0061E8F4 File Offset: 0x0061CAF4
		Private Sub ComboBox_Validating(sender As Object, e As CancelEventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim flag As Boolean = Not comboBox.Items.Contains(comboBox.Text) AndAlso Not String.IsNullOrWhiteSpace(comboBox.Text)
			If flag Then
			End If
		End Sub

		' Token: 0x060083DC RID: 33756 RVA: 0x0061E934 File Offset: 0x0061CB34
		Private Sub DataGridView2_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Try
				Dim flag As Boolean = TypeOf e.Control Is ComboBox
				If flag Then
					Dim comboBox As ComboBox = CType(e.Control, ComboBox)
					comboBox.DropDownStyle = ComboBoxStyle.DropDown
					comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
					comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
					AddHandler comboBox.Validating, AddressOf Me.ComboBox_Validating
				End If
				Dim flag2 As Boolean = TypeOf Me.DataGridView2.CurrentCell Is DataGridViewComboBoxCell
				If flag2 Then
					Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
					Dim flag3 As Boolean = dataGridViewComboBoxEditingControl IsNot Nothing
					If flag3 Then
						AddHandler dataGridViewComboBoxEditingControl.Enter, AddressOf Me.ComboBox_Enter
					End If
				Else
					Dim flag4 As Boolean = TypeOf Me.DataGridView2.CurrentCell Is DataGridViewTextBoxCell
					If flag4 Then
						Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
						RemoveHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
						AddHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
					End If
				End If
			Catch ex As Exception
			End Try
			Dim flag5 As Boolean = Me.DataGridView2.CurrentCell.ColumnIndex = 46 AndAlso TypeOf e.Control Is TextBox
			If flag5 Then
				Dim textBox As TextBox = CType(e.Control, TextBox)
			End If
		End Sub

		' Token: 0x060083DD RID: 33757 RVA: 0x00603008 File Offset: 0x00601208
		Private Sub cmbSize2_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim num As Integer = editingControlDataGridView.CurrentCell.ColumnIndex
			Dim flag As Boolean = num = 43
			If flag Then
				num += 1
			End If
			While num < editingControlDataGridView.ColumnCount AndAlso (Not editingControlDataGridView.Columns(num).Visible OrElse Not editingControlDataGridView.Rows(rowIndex).Cells(num).Visible)
				num += 1
			End While
			Dim flag2 As Boolean = num < editingControlDataGridView.ColumnCount
			If flag2 Then
				editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
				editingControlDataGridView.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060083DE RID: 33758 RVA: 0x0061EA84 File Offset: 0x0061CC84
		Private Sub cmbColour2_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 44
			If flag Then
				' The following expression was wrapped in a checked-expression
				Dim num As Integer = editingControlDataGridView.CurrentCell.ColumnIndex + 1
			Else
				Dim num As Integer = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.EndEdit(CType((-1), DataGridViewDataErrorContexts))
		End Sub

		' Token: 0x060083DF RID: 33759 RVA: 0x0061EAF4 File Offset: 0x0061CCF4
		Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("btnAddNew").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
				Me.DataGridView2.[ReadOnly] = False
				Dim num As Integer = Me.DataGridView2.Rows.Count - 1
				Dim num2 As Integer = 35
				Me.DataGridView2.Rows(num).Cells("CostPrice").Value = Me.DataGridView2.Rows(0).Cells("CostPrice").Value.ToString()
				Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(num).Cells(num2)
				Me.DataGridView2.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060083E0 RID: 33760 RVA: 0x0061EBFC File Offset: 0x0061CDFC
		Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Dim dataGridView As DataGridView = CType(sender, DataGridView)
					e.Handled = True
					Dim flag2 As Boolean = dataGridView.CurrentCell.ColumnIndex < dataGridView.ColumnCount - 1
					If flag2 Then
						Dim flag3 As Boolean = dataGridView.CurrentCell.ColumnIndex = 11
						If flag3 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 24, dataGridView.CurrentCell.RowIndex)
						Else
							Dim flag4 As Boolean = dataGridView.CurrentCell.ColumnIndex = 35
							If flag4 Then
								dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 8, dataGridView.CurrentCell.RowIndex)
							Else
								Dim visible As Boolean = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex).Visible
								If visible Then
									dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex)
								Else
									dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex)
								End If
							End If
						End If
					Else
						Dim flag5 As Boolean = dataGridView.CurrentCell.RowIndex < dataGridView.RowCount - 1
						If flag5 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex + 1)
						End If
					End If
					Dim rowIndex As Integer = Me.DataGridView2.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.DataGridView2.CurrentCell.ColumnIndex
					Dim flag6 As Boolean = TypeOf dataGridView.CurrentCell Is DataGridViewButtonCell
					If flag6 Then
						Dim name As String = dataGridView.CurrentCell.OwningColumn.Name
						If Operators.CompareString(name, "btnAddNew", False) = 0 Then
							Me.DataGridView2_CellContentClick(Me.DataGridView2, New DataGridViewCellEventArgs(columnIndex, rowIndex))
						End If
					Else
						dataGridView.BeginEdit(True)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060083E1 RID: 33761 RVA: 0x0061EE34 File Offset: 0x0061D034
		Private Sub DataGridView2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView2 IsNot Nothing AndAlso Me.DataGridView2.Columns.Contains("txtOpeningStock2")
				If flag Then
					Dim flag2 As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("txtOpeningStock2").Index
					If flag2 Then
						Me.CalculateColumnSum()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error in CellEndEdit: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060083E2 RID: 33762 RVA: 0x0061EED0 File Offset: 0x0061D0D0
		Private Sub CalculateColumnSum()
			Dim flag As Boolean = Me.dt.Rows.Count = 1
			If flag Then
				Dim num As Decimal = 0D
				Dim text As String = "txtOpeningStock2"
				Dim num2 As Integer = Me.DataGridView2.Rows.Count - 1
				For i As Integer = 1 To num2
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
					Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
					If flag2 Then
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(text).Value)
						Dim num3 As Decimal = 0D
						Dim flag3 As Boolean = Decimal.TryParse(objectValue.ToString(), num3)
						If flag3 Then
							num = Decimal.Add(num, num3)
							Dim num4 As Decimal = Decimal.Subtract(Me.initialQty, num)
							Me.DataGridView2.Rows(0).Cells(text).Value = num4
						End If
					End If
				Next
			End If
		End Sub

		' Token: 0x060083E3 RID: 33763 RVA: 0x0061EFD0 File Offset: 0x0061D1D0
		Private Sub frmProductRec_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Me.pnlVariant.Visible = False
				Me.DataGridView2.Visible = False
			End If
		End Sub

		' Token: 0x060083E4 RID: 33764 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060083E5 RID: 33765 RVA: 0x0004089B File Offset: 0x0003EA9B
		Private Sub GelButton2_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmBarcodeLabelPrinting.txtVariant.Text = Me.Label14.Text.ToString()
			MyProject.Forms.frmBarcodeLabelPrinting.ShowDialog()
		End Sub

		' Token: 0x060083E6 RID: 33766 RVA: 0x0061F010 File Offset: 0x0061D210
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCategory.Label2.Text = "setting"
			MyProject.Forms.frmCategory.Reset()
			MyBase.Dispose()
			MyProject.Forms.frmCategory.ShowDialog()
		End Sub

		' Token: 0x060083E7 RID: 33767 RVA: 0x0061F080 File Offset: 0x0061D280
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSubCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSubCategory.Label3.Text = "setting"
			MyProject.Forms.frmSubCategory.Reset()
			MyBase.Dispose()
			MyProject.Forms.frmSubCategory.ShowDialog()
		End Sub

		' Token: 0x060083E8 RID: 33768 RVA: 0x00012250 File Offset: 0x00010450
		Private Sub Button16_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductBulkUpdate.ShowDialog()
			MyProject.Forms.frmProductBulkUpdate.Dispose()
		End Sub

		' Token: 0x060083E9 RID: 33769 RVA: 0x0061F0F0 File Offset: 0x0061D2F0
		Private Sub btnWebcam_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				MyProject.Forms.frmCamera.Label2.Text = "frmProductRec"
				Dim frmCamera As frmCamera = New frmCamera()
				frmCamera.ShowDialog()
				Dim flag2 As Boolean = ModCommonClasses.TempFileNames2.Length > 0
				If flag2 Then
					Me.Picture.Image = Image.FromFile(ModCommonClasses.TempFileNames2)
					Me.Photoname = ModCommonClasses.TempFileNames2
					Me.IsImageChanged = True
					Me.ImageExtrator()
				End If
			Else
				MessageBox.Show("No internet connection.")
			End If
		End Sub

		' Token: 0x060083EA RID: 33770 RVA: 0x0061F180 File Offset: 0x0061D380
		Public Async Sub ImageExtrator()
			Dim flag As Boolean = File.Exists(ModCommonClasses.TempFileNames2)
			If flag Then
				Me.DataGridView1.[ReadOnly] = False
				Dim newRowIndex As Integer = Me.DataGridView1.Rows.Count - 1
				Dim columnIndexToFocus As Integer = 2
				Dim ocrResult As String = Await Me.PerformOCR_(ModCommonClasses.TempFileNames2)
				Me.DataGridView1.Rows(newRowIndex).Cells(columnIndexToFocus).Value = ocrResult
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(newRowIndex).Cells(columnIndexToFocus)
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim row As DataGridViewRow = CType(obj, DataGridViewRow)
						If row.IsNewRow Then
							Me.DataGridView1.Rows(row.Index).Cells(2).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(2).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(3).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(3).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(5).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(5).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("txtCostPrice").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("txtCostPrice").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("txtDiscount").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("txtDiscount").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("txtMinStock").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("txtMinStock").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("cmbPurchaseUnit").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("cmbPurchaseUnit").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("cmbSalesUnit").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("cmbSalesUnit").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("cmbAltunit").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("cmbAltunit").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("Conv").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("Conv").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("txtSaleQty").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("txtSaleQty").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("txtDefMRP").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("txtDefMRP").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("RSPrice").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("RSPrice").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("WSPrice").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("WSPrice").Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells("txtBarcode_TempStock").Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells("txtBarcode_TempStock").Style.ForeColor = Color.White
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.DataGridView1.BeginEdit(True)
				Me.DataGridView1.Rows(newRowIndex).Cells(8).Value = 0
				Me.DataGridView1.Rows(newRowIndex).Cells(13).Value = 0.0
				Me.DataGridView1.Rows(newRowIndex).Cells("txtCESS").Value = "0.00"
				Me.DataGridView1.Rows(newRowIndex).Cells("txtMinStock").Value = "0.00"
				Me.DataGridView1.Rows(newRowIndex).Cells("Conv").Value = 1
				Me.DataGridView1.Rows(newRowIndex).Cells("txtSaleQty").Value = 1
				Me.SetComboBoxColumnSelectedIndex(newRowIndex, "cmbSalesTaxType", 0)
				Me.SetComboBoxColumnSelectedIndex(newRowIndex, "cmbPurchaseTaxType", 0)
				Me.default_fill_tax()
				Me.default_fill_Category_data()
				Me.default_fillUnit_Default()
				Me.default_Tax_type()
			Else
				MessageBox.Show("Captured image not found.")
			End If
		End Sub

		' Token: 0x060083EB RID: 33771 RVA: 0x0061F1BC File Offset: 0x0061D3BC
		Public Sub GetApiDtl()
			Dim dataTable As DataTable = New DataTable()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "select * from tbl_api_setting where isDefault='Yes' and isEnabled='Yes' "
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
			sqlDataAdapter.Fill(dataTable)
			Dim flag As Boolean = dataTable.Rows.Count > 0
			If flag Then
				Me.apiKey = dataTable.Rows(0)(2).ToString()
				Me.url = dataTable.Rows(0)(1).ToString()
			End If
			sqlConnection.Close()
		End Sub

		' Token: 0x060083EC RID: 33772 RVA: 0x0061F250 File Offset: 0x0061D450
		Public Async Function PerformOCR_(imagePath As String) As Task(Of String)
			Dim text As String
			Try
				Dim flag As Boolean = Not File.Exists(imagePath)
				If flag Then
					MessageBox.Show("Error: Image file not found!")
					text = ""
				Else
					Dim imageBytes As Byte() = File.ReadAllBytes(imagePath)
					Dim base64Image As String = Convert.ToBase64String(imageBytes)
					Dim jsonRequest As String = "{" & vbCrLf & "            ""model"": ""gpt-4o-mini""," & vbCrLf & "            ""messages"": [" & vbCrLf & "                {""role"": ""system"", ""content"": ""Identify main object of image and provide product name only (name with singular noun, not plural noun).""}," & vbCrLf & "                {""role"": ""user"", ""content"": [" & vbCrLf & "                    {""type"": ""image_url"", ""image_url"": {""url"": ""data:image/jpeg;base64," + base64Image + """}}" & vbCrLf & "                ]}" & vbCrLf & "            ]" & vbCrLf & "        }"
					Using client As HttpClient = New HttpClient()
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
						Dim response As HttpResponseMessage = Await client.PostAsync(Me.url, New StringContent(jsonRequest, Encoding.UTF8, "application/json"))
						Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
						If response.StatusCode <> HttpStatusCode.OK Then
							MessageBox.Show("API Error: " + jsonResponse)
							text = ""
						Else
							Dim result As JObject = JObject.Parse(jsonResponse)
							If result("choices") Is Nothing OrElse result("choices").Count() = 0 Then
								MessageBox.Show("Error: No response from GPT-4 Vision.")
								text = ""
							Else
								Dim extractedText As String = result("choices")(0)("message")("content").ToString()
								text = extractedText
							End If
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("OCR Error: " + ex.Message)
				text = ""
			End Try
			Return text
		End Function

		' Token: 0x060083ED RID: 33773 RVA: 0x0001407D File Offset: 0x0001227D
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmProductDefault.lblform.Text = "frmProductRec1"
			MyProject.Forms.frmProductDefault.ShowDialog()
		End Sub

		' Token: 0x04003A19 RID: 14873
		Private shouldHandleSelectedIndexChanged As Boolean

		' Token: 0x04003A1A RID: 14874
		Private con As SqlConnection

		' Token: 0x04003A1B RID: 14875
		Private cmd As SqlCommand

		' Token: 0x04003A1C RID: 14876
		Private rdr As SqlDataReader

		' Token: 0x04003A1D RID: 14877
		Private adp As SqlDataAdapter

		' Token: 0x04003A1E RID: 14878
		Private ds As DataSet

		' Token: 0x04003A1F RID: 14879
		Private dtable As DataTable

		' Token: 0x04003A20 RID: 14880
		Private categories As DataTable

		' Token: 0x04003A21 RID: 14881
		Private subcategories As DataTable

		' Token: 0x04003A22 RID: 14882
		Private items As DataTable

		' Token: 0x04003A23 RID: 14883
		Private insertBtn As String

		' Token: 0x04003A24 RID: 14884
		Private updateBtn As String

		' Token: 0x04003A25 RID: 14885
		Private strPcode As String

		' Token: 0x04003A26 RID: 14886
		Private id As Short

		' Token: 0x04003A27 RID: 14887
		Private strBarcode As String

		' Token: 0x04003A28 RID: 14888
		Private dt As DataTable

		' Token: 0x04003A29 RID: 14889
		Private initialQty As Decimal

		' Token: 0x04003A2A RID: 14890
		Private StyleId As String

		' Token: 0x04003A2B RID: 14891
		Private strStax As String

		' Token: 0x04003A2C RID: 14892
		Private strPtax As String

		' Token: 0x04003A2D RID: 14893
		Private Photoname As String

		' Token: 0x04003A2E RID: 14894
		Private IsImageChanged As Boolean

		' Token: 0x04003A2F RID: 14895
		Private apiKey As String

		' Token: 0x04003A30 RID: 14896
		Private url As String

		' Token: 0x04003A31 RID: 14897
		Public Shared strForm As String = ""

		' Token: 0x04003A32 RID: 14898
		Public Shared strSubcategory_POSNewTuch As String = ""

		' Token: 0x04003A34 RID: 14900
		Private Dad As SqlDataAdapter

		' Token: 0x04003A35 RID: 14901
		Private Dst As DataSet

		' Token: 0x04003A36 RID: 14902
		Private CurrentRow As Object

		' Token: 0x04003A37 RID: 14903
		Private isd As String
	End Class
End Namespace
