Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005DF RID: 1503
	<DesignerGenerated()>
	Public Partial Class frmSubCategory
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601272C RID: 75564 RVA: 0x00A9E070 File Offset: 0x00A9C270
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCategory_Load
			AddHandler MyBase.Closing, AddressOf Me.frmSubCategory_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmSubCategory_KeyDown
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007283 RID: 29315
		' (get) Token: 0x0601272F RID: 75567 RVA: 0x0007E991 File Offset: 0x0007CB91
		' (set) Token: 0x06012730 RID: 75568 RVA: 0x0007E99B File Offset: 0x0007CB9B
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17007284 RID: 29316
		' (get) Token: 0x06012731 RID: 75569 RVA: 0x0007E9A4 File Offset: 0x0007CBA4
		' (set) Token: 0x06012732 RID: 75570 RVA: 0x00AA031C File Offset: 0x00A9E51C
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007285 RID: 29317
		' (get) Token: 0x06012733 RID: 75571 RVA: 0x0007E9AE File Offset: 0x0007CBAE
		' (set) Token: 0x06012734 RID: 75572 RVA: 0x0007E9B8 File Offset: 0x0007CBB8
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17007286 RID: 29318
		' (get) Token: 0x06012735 RID: 75573 RVA: 0x0007E9C1 File Offset: 0x0007CBC1
		' (set) Token: 0x06012736 RID: 75574 RVA: 0x0007E9CB File Offset: 0x0007CBCB
		Friend Overridable Property Label1 As Label

		' Token: 0x17007287 RID: 29319
		' (get) Token: 0x06012737 RID: 75575 RVA: 0x0007E9D4 File Offset: 0x0007CBD4
		' (set) Token: 0x06012738 RID: 75576 RVA: 0x0007E9DE File Offset: 0x0007CBDE
		Friend Overridable Property Label2 As Label

		' Token: 0x17007288 RID: 29320
		' (get) Token: 0x06012739 RID: 75577 RVA: 0x0007E9E7 File Offset: 0x0007CBE7
		' (set) Token: 0x0601273A RID: 75578 RVA: 0x0007E9F1 File Offset: 0x0007CBF1
		Friend Overridable Property txtID As TextBox

		' Token: 0x17007289 RID: 29321
		' (get) Token: 0x0601273B RID: 75579 RVA: 0x0007E9FA File Offset: 0x0007CBFA
		' (set) Token: 0x0601273C RID: 75580 RVA: 0x0007EA04 File Offset: 0x0007CC04
		Friend Overridable Property lblUser As Label

		' Token: 0x1700728A RID: 29322
		' (get) Token: 0x0601273D RID: 75581 RVA: 0x0007EA0D File Offset: 0x0007CC0D
		' (set) Token: 0x0601273E RID: 75582 RVA: 0x00AA037C File Offset: 0x00A9E57C
		Private _txtSearchByCategory As TextBox
		Friend Overridable Property txtSearchByCategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchByCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchByCategory_TextChanged
				Dim textBox As TextBox = Me._txtSearchByCategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchByCategory = value
				textBox = Me._txtSearchByCategory
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700728B RID: 29323
		' (get) Token: 0x0601273F RID: 75583 RVA: 0x0007EA17 File Offset: 0x0007CC17
		' (set) Token: 0x06012740 RID: 75584 RVA: 0x00AA03C0 File Offset: 0x00A9E5C0
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbCategory_Format
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCategory_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validated, eventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validated, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700728C RID: 29324
		' (get) Token: 0x06012741 RID: 75585 RVA: 0x0007EA21 File Offset: 0x0007CC21
		' (set) Token: 0x06012742 RID: 75586 RVA: 0x00AA043C File Offset: 0x00A9E63C
		Private _txtSearchBySubCategory As TextBox
		Friend Overridable Property txtSearchBySubCategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchBySubCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchBySubCategory_TextChanged
				Dim textBox As TextBox = Me._txtSearchBySubCategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchBySubCategory = value
				textBox = Me._txtSearchBySubCategory
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700728D RID: 29325
		' (get) Token: 0x06012743 RID: 75587 RVA: 0x0007EA2B File Offset: 0x0007CC2B
		' (set) Token: 0x06012744 RID: 75588 RVA: 0x0007EA35 File Offset: 0x0007CC35
		Friend Overridable Property Label4 As Label

		' Token: 0x1700728E RID: 29326
		' (get) Token: 0x06012745 RID: 75589 RVA: 0x0007EA3E File Offset: 0x0007CC3E
		' (set) Token: 0x06012746 RID: 75590 RVA: 0x00AA0480 File Offset: 0x00A9E680
		Private _cmbSubCategory As ComboBox
		Friend Overridable Property cmbSubCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSubCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSubCategory_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSubCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validated, eventHandler
				End If
				Me._cmbSubCategory = value
				comboBox = Me._cmbSubCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validated, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700728F RID: 29327
		' (get) Token: 0x06012747 RID: 75591 RVA: 0x0007EA48 File Offset: 0x0007CC48
		' (set) Token: 0x06012748 RID: 75592 RVA: 0x00AA04E0 File Offset: 0x00A9E6E0
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007290 RID: 29328
		' (get) Token: 0x06012749 RID: 75593 RVA: 0x0007EA52 File Offset: 0x0007CC52
		' (set) Token: 0x0601274A RID: 75594 RVA: 0x0007EA5C File Offset: 0x0007CC5C
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17007291 RID: 29329
		' (get) Token: 0x0601274B RID: 75595 RVA: 0x0007EA65 File Offset: 0x0007CC65
		' (set) Token: 0x0601274C RID: 75596 RVA: 0x0007EA6F File Offset: 0x0007CC6F
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17007292 RID: 29330
		' (get) Token: 0x0601274D RID: 75597 RVA: 0x0007EA78 File Offset: 0x0007CC78
		' (set) Token: 0x0601274E RID: 75598 RVA: 0x0007EA82 File Offset: 0x0007CC82
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17007293 RID: 29331
		' (get) Token: 0x0601274F RID: 75599 RVA: 0x0007EA8B File Offset: 0x0007CC8B
		' (set) Token: 0x06012750 RID: 75600 RVA: 0x0007EA95 File Offset: 0x0007CC95
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17007294 RID: 29332
		' (get) Token: 0x06012751 RID: 75601 RVA: 0x0007EA9E File Offset: 0x0007CC9E
		' (set) Token: 0x06012752 RID: 75602 RVA: 0x0007EAA8 File Offset: 0x0007CCA8
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17007295 RID: 29333
		' (get) Token: 0x06012753 RID: 75603 RVA: 0x0007EAB1 File Offset: 0x0007CCB1
		' (set) Token: 0x06012754 RID: 75604 RVA: 0x00AA0524 File Offset: 0x00A9E724
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007296 RID: 29334
		' (get) Token: 0x06012755 RID: 75605 RVA: 0x0007EABB File Offset: 0x0007CCBB
		' (set) Token: 0x06012756 RID: 75606 RVA: 0x00AA0568 File Offset: 0x00A9E768
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007297 RID: 29335
		' (get) Token: 0x06012757 RID: 75607 RVA: 0x0007EAC5 File Offset: 0x0007CCC5
		' (set) Token: 0x06012758 RID: 75608 RVA: 0x00AA05AC File Offset: 0x00A9E7AC
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007298 RID: 29336
		' (get) Token: 0x06012759 RID: 75609 RVA: 0x0007EACF File Offset: 0x0007CCCF
		' (set) Token: 0x0601275A RID: 75610 RVA: 0x00AA05F0 File Offset: 0x00A9E7F0
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007299 RID: 29337
		' (get) Token: 0x0601275B RID: 75611 RVA: 0x0007EAD9 File Offset: 0x0007CCD9
		' (set) Token: 0x0601275C RID: 75612 RVA: 0x0007EAE3 File Offset: 0x0007CCE3
		Public Overridable Property Picture As PictureBox

		' Token: 0x1700729A RID: 29338
		' (get) Token: 0x0601275D RID: 75613 RVA: 0x0007EAEC File Offset: 0x0007CCEC
		' (set) Token: 0x0601275E RID: 75614 RVA: 0x00AA0634 File Offset: 0x00A9E834
		Private _BStartCapture As Button
		Friend Overridable Property BStartCapture As Button
			<CompilerGenerated()>
			Get
				Return Me._BStartCapture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BStartCapture_Click
				Dim button As Button = Me._BStartCapture
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BStartCapture = value
				button = Me._BStartCapture
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700729B RID: 29339
		' (get) Token: 0x0601275F RID: 75615 RVA: 0x0007EAF6 File Offset: 0x0007CCF6
		' (set) Token: 0x06012760 RID: 75616 RVA: 0x00AA0678 File Offset: 0x00A9E878
		Private _Browse As Button
		Friend Overridable Property Browse As Button
			<CompilerGenerated()>
			Get
				Return Me._Browse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Browse_Click
				Dim button As Button = Me._Browse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Browse = value
				button = Me._Browse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700729C RID: 29340
		' (get) Token: 0x06012761 RID: 75617 RVA: 0x0007EB00 File Offset: 0x0007CD00
		' (set) Token: 0x06012762 RID: 75618 RVA: 0x00AA06BC File Offset: 0x00A9E8BC
		Private _BRemove As Button
		Friend Overridable Property BRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._BRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BRemove_Click
				Dim button As Button = Me._BRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BRemove = value
				button = Me._BRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700729D RID: 29341
		' (get) Token: 0x06012763 RID: 75619 RVA: 0x0007EB0A File Offset: 0x0007CD0A
		' (set) Token: 0x06012764 RID: 75620 RVA: 0x0007EB14 File Offset: 0x0007CD14
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x1700729E RID: 29342
		' (get) Token: 0x06012765 RID: 75621 RVA: 0x0007EB1D File Offset: 0x0007CD1D
		' (set) Token: 0x06012766 RID: 75622 RVA: 0x00AA0700 File Offset: 0x00A9E900
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

		' Token: 0x1700729F RID: 29343
		' (get) Token: 0x06012767 RID: 75623 RVA: 0x0007EB27 File Offset: 0x0007CD27
		' (set) Token: 0x06012768 RID: 75624 RVA: 0x0007EB31 File Offset: 0x0007CD31
		Friend Overridable Property lblSource As Label

		' Token: 0x170072A0 RID: 29344
		' (get) Token: 0x06012769 RID: 75625 RVA: 0x0007EB3A File Offset: 0x0007CD3A
		' (set) Token: 0x0601276A RID: 75626 RVA: 0x0007EB44 File Offset: 0x0007CD44
		Friend Overridable Property txtSelectedCategory As TextBox

		' Token: 0x170072A1 RID: 29345
		' (get) Token: 0x0601276B RID: 75627 RVA: 0x0007EB4D File Offset: 0x0007CD4D
		' (set) Token: 0x0601276C RID: 75628 RVA: 0x0007EB57 File Offset: 0x0007CD57
		Friend Overridable Property lblCurrentCellIndex As Label

		' Token: 0x170072A2 RID: 29346
		' (get) Token: 0x0601276D RID: 75629 RVA: 0x0007EB60 File Offset: 0x0007CD60
		' (set) Token: 0x0601276E RID: 75630 RVA: 0x0007EB6A File Offset: 0x0007CD6A
		Friend Overridable Property lblSource1 As Label

		' Token: 0x170072A3 RID: 29347
		' (get) Token: 0x0601276F RID: 75631 RVA: 0x0007EB73 File Offset: 0x0007CD73
		' (set) Token: 0x06012770 RID: 75632 RVA: 0x0007EB7D File Offset: 0x0007CD7D
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170072A4 RID: 29348
		' (get) Token: 0x06012771 RID: 75633 RVA: 0x0007EB86 File Offset: 0x0007CD86
		' (set) Token: 0x06012772 RID: 75634 RVA: 0x0007EB90 File Offset: 0x0007CD90
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170072A5 RID: 29349
		' (get) Token: 0x06012773 RID: 75635 RVA: 0x0007EB99 File Offset: 0x0007CD99
		' (set) Token: 0x06012774 RID: 75636 RVA: 0x0007EBA3 File Offset: 0x0007CDA3
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170072A6 RID: 29350
		' (get) Token: 0x06012775 RID: 75637 RVA: 0x0007EBAC File Offset: 0x0007CDAC
		' (set) Token: 0x06012776 RID: 75638 RVA: 0x0007EBB6 File Offset: 0x0007CDB6
		Friend Overridable Property Column4 As DataGridViewImageColumn

		' Token: 0x170072A7 RID: 29351
		' (get) Token: 0x06012777 RID: 75639 RVA: 0x0007EBBF File Offset: 0x0007CDBF
		' (set) Token: 0x06012778 RID: 75640 RVA: 0x0007EBC9 File Offset: 0x0007CDC9
		Friend Overridable Property IsDefault As DataGridViewTextBoxColumn

		' Token: 0x170072A8 RID: 29352
		' (get) Token: 0x06012779 RID: 75641 RVA: 0x0007EBD2 File Offset: 0x0007CDD2
		' (set) Token: 0x0601277A RID: 75642 RVA: 0x0007EBDC File Offset: 0x0007CDDC
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x170072A9 RID: 29353
		' (get) Token: 0x0601277B RID: 75643 RVA: 0x0007EBE5 File Offset: 0x0007CDE5
		' (set) Token: 0x0601277C RID: 75644 RVA: 0x0007EBEF File Offset: 0x0007CDEF
		Friend Overridable Property Label3 As Label

		' Token: 0x170072AA RID: 29354
		' (get) Token: 0x0601277D RID: 75645 RVA: 0x0007EBF8 File Offset: 0x0007CDF8
		' (set) Token: 0x0601277E RID: 75646 RVA: 0x00AA0744 File Offset: 0x00A9E944
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

		' Token: 0x170072AB RID: 29355
		' (get) Token: 0x0601277F RID: 75647 RVA: 0x0007EC02 File Offset: 0x0007CE02
		' (set) Token: 0x06012780 RID: 75648 RVA: 0x00AA0788 File Offset: 0x00A9E988
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

		' Token: 0x06012781 RID: 75649 RVA: 0x00AA07CC File Offset: 0x00A9E9CC
		Public Sub fillCombo()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
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
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012782 RID: 75650 RVA: 0x00AA0908 File Offset: 0x00A9EB08
		Public Sub fillSubGategoryName()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(SubCategoryName) FROM SubCategory", Me.con)
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
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012783 RID: 75651 RVA: 0x00AA0A44 File Offset: 0x00A9EC44
		Public Sub Reset()
			Me.Label3.Text = ""
			Me.cmbCategory.SelectedIndex = -1
			Me.txtSearchByCategory.Text = ""
			Me.txtSearchBySubCategory.Text = ""
			Me.cmbSubCategory.Text = ""
			Me.cmbSubCategory.SelectedIndex = -1
			Me.CheckBox1.Checked = False
			Me.cmbSubCategory.Focus()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.Getdata()
			Me.auto()
			Me.fillSubGategoryName()
		End Sub

		' Token: 0x06012784 RID: 75652 RVA: 0x00AA0B08 File Offset: 0x00A9ED08
		Private Sub DeleteRecord()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = "select SubCategoryID from Product,SubCategory where Product.SubCategoryID=SubCategory.ID and SubCategoryID=@d1"
				Me.cmd = New SqlCommand(text)
				Me.cmd.Connection = Me.con
				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Product Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
				Else
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text2 As String = "delete from SubCategory where ID=@d1"
					Me.cmd = New SqlCommand(text2)
					Me.cmd.Connection = Me.con
					Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
					Dim num As Integer = Me.cmd.ExecuteNonQuery()
					Dim flag3 As Boolean = num > 0
					If flag3 Then
						Me.LogFunc(Me.lblUser.Text, String.Concat(New String() { "deleted the subcategory '", Me.cmbSubCategory.Text, "' having Category '", Me.cmbCategory.Text, "'" }))
						MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
					If flag4 Then
						Me.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012785 RID: 75653 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub LogFunc(text As String, v As String)
		End Sub

		' Token: 0x06012786 RID: 75654 RVA: 0x00AA0D54 File Offset: 0x00A9EF54
		Public Sub Getdata()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SubCategoryName), RTRIM(Category),SCPhoto, IsDefault from SubCategory order by IsDefault desc", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While Me.rdr.Read()
					Me.dgw.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4) })
				End While
				Me.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012787 RID: 75655 RVA: 0x00AA0E7C File Offset: 0x00A9F07C
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

		' Token: 0x06012788 RID: 75656 RVA: 0x00AA0F64 File Offset: 0x00A9F164
		Private Sub auto()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM SubCategory"
				Me.cmd = New SqlCommand(text)
				Me.cmd.Connection = Me.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.txtID.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(Me.cmd.ExecuteScalar(), 1))
					Me.txtID.Text = num.ToString()
				End If
				Me.cmd.Dispose()
				Me.con.Close()
				Me.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012789 RID: 75657 RVA: 0x00AA1074 File Offset: 0x00A9F274
		Private Sub frmCategory_Load(sender As Object, e As EventArgs)
			Me.fillCombo()
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0601278A RID: 75658 RVA: 0x00AA1104 File Offset: 0x00A9F304
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
										End If
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0601278B RID: 75659 RVA: 0x00AA13A4 File Offset: 0x00A9F5A4
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is RadioButton
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

		' Token: 0x0601278C RID: 75660 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601278D RID: 75661 RVA: 0x00AA1458 File Offset: 0x00A9F658
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.cmbSubCategory.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbCategory.Text = dataGridViewRow.Cells(2).Value.ToString()
					Dim array As Byte() = CType(dataGridViewRow.Cells(3).Value, Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(4).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.CheckBox1.Checked = True
					Else
						Me.CheckBox1.Checked = False
					End If
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601278E RID: 75662 RVA: 0x00AA15CC File Offset: 0x00A9F7CC
		Private Sub txtSearchByCategory_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(SubCategoryName), RTRIM(Category),SCPhoto from SubCategory where Category like N'%" + Me.txtSearchByCategory.Text + "%' order by Category", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While Me.rdr.Read()
					Me.dgw.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3) })
				End While
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601278F RID: 75663 RVA: 0x00AA16F0 File Offset: 0x00A9F8F0
		Private Sub txtSearchBySubCategory_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(SubCategoryName), RTRIM(Category),SCPhoto from SubCategory where SubCategoryName like N'%" + Me.txtSearchBySubCategory.Text + "%' order by SubCategoryName", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While Me.rdr.Read()
					Me.dgw.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3) })
				End While
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012790 RID: 75664 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbCategory_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06012791 RID: 75665 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSubCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012792 RID: 75666 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012793 RID: 75667 RVA: 0x00AA1814 File Offset: 0x00A9FA14
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
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

		' Token: 0x06012794 RID: 75668 RVA: 0x00AA1AC0 File Offset: 0x00A9FCC0
		Private Sub frmSubCategory_Closing(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblSource.Text, "ProductRec", False) = 0
			If Not flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.lblSource.Text, "ProductRec1", False) = 0
				If flag2 Then
					MyProject.Forms.frmProductRec1.FillSubCat(Me.txtSelectedCategory.Text, Convert.ToInt32(Me.lblCurrentCellIndex.Text))
				Else
					MyProject.Forms.frmProduct.fillCategory()
				End If
			End If
		End Sub

		' Token: 0x06012795 RID: 75669 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSubCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06012796 RID: 75670 RVA: 0x00AA1B4C File Offset: 0x00A9FD4C
		Private Sub TV(sender As Object, e As EventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbSubCategory.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbSubCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSubCategory, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbCategory.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCategory, String.Empty)
			End If
		End Sub

		' Token: 0x06012797 RID: 75671 RVA: 0x0007EC0C File Offset: 0x0007CE0C
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06012798 RID: 75672 RVA: 0x00AA1BF4 File Offset: 0x00A9FDF4
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text As String = "select * from Company"
			Me.cmd = New SqlCommand(text)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag As Boolean = Not Me.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Me.con.Close()
			Else
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbSubCategory.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSubCategory.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbCategory.Focus()
					Else
						Try
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text2 As String = "select SubCategoryName,Category from SubCategory where SubCategoryName=@d1 and Category=@d2"
							Me.cmd = New SqlCommand(text2)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
							Me.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag5 As Boolean = Me.rdr.Read()
							If flag5 Then
								MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.cmbSubCategory.Text = ""
								Me.cmbSubCategory.Focus()
								Dim flag6 As Boolean = Me.rdr IsNot Nothing
								If flag6 Then
									Me.rdr.Close()
								End If
								Return
							End If
							Dim checked As Boolean = Me.CheckBox1.Checked
							If checked Then
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text3 As String = "select IsDefault from SubCategory where IsDefault='Yes'"
								Me.cmd = New SqlCommand(text3)
								Me.cmd.Connection = Me.con
								Me.rdr = Me.cmd.ExecuteReader()
								Dim flag7 As Boolean = Me.rdr.Read()
								If flag7 Then
									MessageBox.Show("Sub Category is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag8 As Boolean = Me.rdr IsNot Nothing
									If flag8 Then
										Me.rdr.Close()
									End If
									Return
								End If
							End If
							Dim checked2 As Boolean = Me.CheckBox1.Checked
							If checked2 Then
								Me.st2 = "Yes"
							Else
								Me.st2 = "No"
							End If
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text4 As String = "insert into SubCategory(SubCategoryName,Category,ID,SCPhoto, IsDefault) VALUES (@d1,@d2," + Me.txtID.Text + ",@d3, @d4)"
							Me.cmd = New SqlCommand(text4)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
							Me.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
							Dim memoryStream As MemoryStream = New MemoryStream()
							Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim buffer As Byte() = memoryStream.GetBuffer()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.Image)
							sqlParameter.Value = buffer
							Me.cmd.Parameters.Add(sqlParameter)
							Me.cmd.Parameters.AddWithValue("@d4", Me.st2)
							Me.cmd.ExecuteReader()
							Me.con.Close()
							Me.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new subcategory '", Me.cmbSubCategory.Text, "' having Category '", Me.cmbCategory.Text, "'" }))
							Me.txtSelectedCategory.Text = Me.cmbCategory.Text
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnSave.Enabled = False
							Me.Getdata()
							Me.fillSubGategoryName()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
						MyProject.Forms.frmProductRec.Label16.Text = Me.cmbSubCategory.Text
						Dim flag9 As Boolean = Operators.CompareString(Me.Label3.Text, "setting", False) = 0
						If flag9 Then
							MyBase.Dispose()
							MyProject.Forms.frmProductRec.ShowDialog()
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06012799 RID: 75673 RVA: 0x00AA215C File Offset: 0x00AA035C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbSubCategory.Text)) = 0
				If flag Then
					MessageBox.Show("Please enter Sub Category name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSubCategory.Focus()
				Else
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
					If flag2 Then
						MessageBox.Show("Please select Category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbCategory.Focus()
					Else
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text As String = "select IsDefault from SubCategory where IsDefault='Yes'"
							Me.cmd = New SqlCommand(text)
							Me.cmd.Connection = Me.con
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag3 As Boolean = Me.rdr.Read()
							If flag3 Then
								MessageBox.Show("Sub Category is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag4 As Boolean = Me.rdr IsNot Nothing
								If flag4 Then
									Me.rdr.Close()
								End If
								Return
							End If
						End If
						Dim checked2 As Boolean = Me.CheckBox1.Checked
						If checked2 Then
							Me.st2 = "Yes"
						Else
							Me.st2 = "No"
						End If
						Me.con.Close()
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text2 As String = If(("update SubCategory set SubCategoryName=@d1,Category=@d2,SCPhoto=@d3, IsDefault=@d4 where ID=" + Me.txtID.Text), "")
						Me.cmd = New SqlCommand(text2)
						Me.cmd.Connection = Me.con
						Me.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
						Me.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
						Me.cmd.Connection = Me.con
						Dim memoryStream As MemoryStream = New MemoryStream()
						Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
						bitmap.Save(memoryStream, ImageFormat.Jpeg)
						Dim buffer As Byte() = memoryStream.GetBuffer()
						Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.Image)
						sqlParameter.Value = buffer
						Me.cmd.Parameters.Add(sqlParameter)
						Me.cmd.Parameters.AddWithValue("@d4", Me.st2)
						Me.cmd.ExecuteReader()
						Me.con.Close()
						Me.LogFunc(Me.lblUser.Text, String.Concat(New String() { "updated the sub category '", Me.cmbSubCategory.Text, "' having Category '", Me.cmbCategory.Text, "'" }))
						MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnUpdate.Enabled = False
						Me.Getdata()
						Me.fillSubGategoryName()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601279A RID: 75674 RVA: 0x00AA24D4 File Offset: 0x00AA06D4
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601279B RID: 75675 RVA: 0x00AA253C File Offset: 0x00AA073C
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Picture.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0601279C RID: 75676 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0601279D RID: 75677 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub BStartCapture_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0601279E RID: 75678 RVA: 0x00AA25DC File Offset: 0x00AA07DC
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Export File$]", oleDbConnection)
					oleDbConnection.Open()
					Me.dtable = New DataTable()
					oleDbDataAdapter.Fill(Me.dtable)
					Try
						For Each obj As Object In Me.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							SqlConnection.ClearAllPools()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text As String = "INSERT INTO SubCategory(ID, SubCategoryName, Category,SCPhoto) VALUES (@d1, @d2, @d3,@d4)"
							Me.cmd = New SqlCommand(text)
							Me.cmd.Parameters.AddWithValue("@d1", dataRow(0).ToString().TrimEnd(New Char(-1) {}))
							Me.cmd.Parameters.AddWithValue("@d2", dataRow(1).ToString().TrimEnd(New Char(-1) {}))
							Me.cmd.Parameters.AddWithValue("@d3", dataRow(2).ToString().TrimEnd(New Char(-1) {}))
							Me.cmd.Connection = Me.con
							Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
							Dim memoryStream As MemoryStream = New MemoryStream()
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim array As Byte() = memoryStream.ToArray()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d4", SqlDbType.Image)
							sqlParameter.Value = array
							Me.cmd.Parameters.Add(sqlParameter)
							Me.cmd.ExecuteReader()
							Me.con.Close()
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Successfully imported")
					Me.Getdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message + "ONCLICK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601279F RID: 75679 RVA: 0x0007EC16 File Offset: 0x0007CE16
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSubCategoryNew.ShowDialog()
		End Sub

		' Token: 0x060127A0 RID: 75680 RVA: 0x0007EC16 File Offset: 0x0007CE16
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSubCategoryNew.ShowDialog()
		End Sub

		' Token: 0x04006F26 RID: 28454
		Private s As String

		' Token: 0x04006F27 RID: 28455
		Private st2 As String

		' Token: 0x04006F28 RID: 28456
		Private Photoname As String

		' Token: 0x04006F29 RID: 28457
		Private IsImageChanged As Boolean

		' Token: 0x04006F2A RID: 28458
		Private con As SqlConnection

		' Token: 0x04006F2B RID: 28459
		Private cmd As SqlCommand

		' Token: 0x04006F2C RID: 28460
		Private rdr As SqlDataReader

		' Token: 0x04006F2D RID: 28461
		Private adp As SqlDataAdapter

		' Token: 0x04006F2E RID: 28462
		Private ds As DataSet

		' Token: 0x04006F2F RID: 28463
		Private dtable As DataTable
	End Class
End Namespace
