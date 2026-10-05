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
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004CC RID: 1228
	<DesignerGenerated()>
	Public Partial Class frmIncome
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F989 RID: 63881 RVA: 0x0095763C File Offset: 0x0095583C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmIncome_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmIncome_KeyDown
			Me.ntid = ""
			Me.Dst = New DataSet()
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005F96 RID: 24470
		' (get) Token: 0x0600F98C RID: 63884 RVA: 0x0006D84F File Offset: 0x0006BA4F
		' (set) Token: 0x0600F98D RID: 63885 RVA: 0x0006D859 File Offset: 0x0006BA59
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005F97 RID: 24471
		' (get) Token: 0x0600F98E RID: 63886 RVA: 0x0006D862 File Offset: 0x0006BA62
		' (set) Token: 0x0600F98F RID: 63887 RVA: 0x0095A598 File Offset: 0x00958798
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005F98 RID: 24472
		' (get) Token: 0x0600F990 RID: 63888 RVA: 0x0006D86C File Offset: 0x0006BA6C
		' (set) Token: 0x0600F991 RID: 63889 RVA: 0x0006D876 File Offset: 0x0006BA76
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17005F99 RID: 24473
		' (get) Token: 0x0600F992 RID: 63890 RVA: 0x0006D87F File Offset: 0x0006BA7F
		' (set) Token: 0x0600F993 RID: 63891 RVA: 0x0006D889 File Offset: 0x0006BA89
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x17005F9A RID: 24474
		' (get) Token: 0x0600F994 RID: 63892 RVA: 0x0006D892 File Offset: 0x0006BA92
		' (set) Token: 0x0600F995 RID: 63893 RVA: 0x0006D89C File Offset: 0x0006BA9C
		Friend Overridable Property Label31 As Label

		' Token: 0x17005F9B RID: 24475
		' (get) Token: 0x0600F996 RID: 63894 RVA: 0x0006D8A5 File Offset: 0x0006BAA5
		' (set) Token: 0x0600F997 RID: 63895 RVA: 0x0006D8AF File Offset: 0x0006BAAF
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17005F9C RID: 24476
		' (get) Token: 0x0600F998 RID: 63896 RVA: 0x0006D8B8 File Offset: 0x0006BAB8
		' (set) Token: 0x0600F999 RID: 63897 RVA: 0x0095A5F8 File Offset: 0x009587F8
		Private _cmbtxtName As ComboBox
		Friend Overridable Property cmbtxtName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbtxtName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbtxtName_Format
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbtxtName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbtxtName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbtxtName = value
				comboBox = Me._cmbtxtName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005F9D RID: 24477
		' (get) Token: 0x0600F99A RID: 63898 RVA: 0x0006D8C2 File Offset: 0x0006BAC2
		' (set) Token: 0x0600F99B RID: 63899 RVA: 0x0095A674 File Offset: 0x00958874
		Private _txtDetails As TextBox
		Friend Overridable Property txtDetails As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDetails
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDetails_KeyDown
				Dim textBox As TextBox = Me._txtDetails
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDetails = value
				textBox = Me._txtDetails
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005F9E RID: 24478
		' (get) Token: 0x0600F99C RID: 63900 RVA: 0x0006D8CC File Offset: 0x0006BACC
		' (set) Token: 0x0600F99D RID: 63901 RVA: 0x0006D8D6 File Offset: 0x0006BAD6
		Friend Overridable Property Label3 As Label

		' Token: 0x17005F9F RID: 24479
		' (get) Token: 0x0600F99E RID: 63902 RVA: 0x0006D8DF File Offset: 0x0006BADF
		' (set) Token: 0x0600F99F RID: 63903 RVA: 0x0095A6B8 File Offset: 0x009588B8
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FA0 RID: 24480
		' (get) Token: 0x0600F9A0 RID: 63904 RVA: 0x0006D8E9 File Offset: 0x0006BAE9
		' (set) Token: 0x0600F9A1 RID: 63905 RVA: 0x0006D8F3 File Offset: 0x0006BAF3
		Friend Overridable Property txtVoucherNo As TextBox

		' Token: 0x17005FA1 RID: 24481
		' (get) Token: 0x0600F9A2 RID: 63906 RVA: 0x0006D8FC File Offset: 0x0006BAFC
		' (set) Token: 0x0600F9A3 RID: 63907 RVA: 0x0006D906 File Offset: 0x0006BB06
		Friend Overridable Property Label2 As Label

		' Token: 0x17005FA2 RID: 24482
		' (get) Token: 0x0600F9A4 RID: 63908 RVA: 0x0006D90F File Offset: 0x0006BB0F
		' (set) Token: 0x0600F9A5 RID: 63909 RVA: 0x0006D919 File Offset: 0x0006BB19
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005FA3 RID: 24483
		' (get) Token: 0x0600F9A6 RID: 63910 RVA: 0x0006D922 File Offset: 0x0006BB22
		' (set) Token: 0x0600F9A7 RID: 63911 RVA: 0x0095A718 File Offset: 0x00958918
		Private _btnRemove As Button
		Friend Overridable Property btnRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemove_Click
				Dim button As Button = Me._btnRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRemove = value
				button = Me._btnRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FA4 RID: 24484
		' (get) Token: 0x0600F9A8 RID: 63912 RVA: 0x0006D92C File Offset: 0x0006BB2C
		' (set) Token: 0x0600F9A9 RID: 63913 RVA: 0x0095A75C File Offset: 0x0095895C
		Private _txtNotes As TextBox
		Friend Overridable Property txtNotes As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNotes
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNotes_KeyDown
				Dim textBox As TextBox = Me._txtNotes
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNotes = value
				textBox = Me._txtNotes
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FA5 RID: 24485
		' (get) Token: 0x0600F9AA RID: 63914 RVA: 0x0006D936 File Offset: 0x0006BB36
		' (set) Token: 0x0600F9AB RID: 63915 RVA: 0x0006D940 File Offset: 0x0006BB40
		Friend Overridable Property Label8 As Label

		' Token: 0x17005FA6 RID: 24486
		' (get) Token: 0x0600F9AC RID: 63916 RVA: 0x0006D949 File Offset: 0x0006BB49
		' (set) Token: 0x0600F9AD RID: 63917 RVA: 0x0006D953 File Offset: 0x0006BB53
		Friend Overridable Property Label11 As Label

		' Token: 0x17005FA7 RID: 24487
		' (get) Token: 0x0600F9AE RID: 63918 RVA: 0x0006D95C File Offset: 0x0006BB5C
		' (set) Token: 0x0600F9AF RID: 63919 RVA: 0x0095A7A0 File Offset: 0x009589A0
		Private _btnAdd As Button
		Friend Overridable Property btnAdd As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button7_Click
				Dim button As Button = Me._btnAdd
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAdd = value
				button = Me._btnAdd
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FA8 RID: 24488
		' (get) Token: 0x0600F9B0 RID: 63920 RVA: 0x0006D966 File Offset: 0x0006BB66
		' (set) Token: 0x0600F9B1 RID: 63921 RVA: 0x0006D970 File Offset: 0x0006BB70
		Friend Overridable Property Label12 As Label

		' Token: 0x17005FA9 RID: 24489
		' (get) Token: 0x0600F9B2 RID: 63922 RVA: 0x0006D979 File Offset: 0x0006BB79
		' (set) Token: 0x0600F9B3 RID: 63923 RVA: 0x0095A7E4 File Offset: 0x009589E4
		Private _txtAmount As TextBox
		Friend Overridable Property txtAmount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAmount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtAmount_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAmount_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAmount = value
				textBox = Me._txtAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FAA RID: 24490
		' (get) Token: 0x0600F9B4 RID: 63924 RVA: 0x0006D983 File Offset: 0x0006BB83
		' (set) Token: 0x0600F9B5 RID: 63925 RVA: 0x0006D98D File Offset: 0x0006BB8D
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005FAB RID: 24491
		' (get) Token: 0x0600F9B6 RID: 63926 RVA: 0x0006D996 File Offset: 0x0006BB96
		' (set) Token: 0x0600F9B7 RID: 63927 RVA: 0x0006D9A0 File Offset: 0x0006BBA0
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005FAC RID: 24492
		' (get) Token: 0x0600F9B8 RID: 63928 RVA: 0x0006D9A9 File Offset: 0x0006BBA9
		' (set) Token: 0x0600F9B9 RID: 63929 RVA: 0x0006D9B3 File Offset: 0x0006BBB3
		Friend Overridable Property Label1 As Label

		' Token: 0x17005FAD RID: 24493
		' (get) Token: 0x0600F9BA RID: 63930 RVA: 0x0006D9BC File Offset: 0x0006BBBC
		' (set) Token: 0x0600F9BB RID: 63931 RVA: 0x0006D9C6 File Offset: 0x0006BBC6
		Friend Overridable Property txtVoucherID As TextBox

		' Token: 0x17005FAE RID: 24494
		' (get) Token: 0x0600F9BC RID: 63932 RVA: 0x0006D9CF File Offset: 0x0006BBCF
		' (set) Token: 0x0600F9BD RID: 63933 RVA: 0x0006D9D9 File Offset: 0x0006BBD9
		Friend Overridable Property lblUser As Label

		' Token: 0x17005FAF RID: 24495
		' (get) Token: 0x0600F9BE RID: 63934 RVA: 0x0006D9E2 File Offset: 0x0006BBE2
		' (set) Token: 0x0600F9BF RID: 63935 RVA: 0x0095A860 File Offset: 0x00958A60
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

		' Token: 0x17005FB0 RID: 24496
		' (get) Token: 0x0600F9C0 RID: 63936 RVA: 0x0006D9EC File Offset: 0x0006BBEC
		' (set) Token: 0x0600F9C1 RID: 63937 RVA: 0x0095A8A4 File Offset: 0x00958AA4
		Private _cmbParticulars As ComboBox
		Friend Overridable Property cmbParticulars As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbParticulars
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbParticulars_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.cmbParticulars_SelectedIndexChanged
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbParticulars
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbParticulars = value
				comboBox = Me._cmbParticulars
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FB1 RID: 24497
		' (get) Token: 0x0600F9C2 RID: 63938 RVA: 0x0006D9F6 File Offset: 0x0006BBF6
		' (set) Token: 0x0600F9C3 RID: 63939 RVA: 0x0006DA00 File Offset: 0x0006BC00
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17005FB2 RID: 24498
		' (get) Token: 0x0600F9C4 RID: 63940 RVA: 0x0006DA09 File Offset: 0x0006BC09
		' (set) Token: 0x0600F9C5 RID: 63941 RVA: 0x0006DA13 File Offset: 0x0006BC13
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17005FB3 RID: 24499
		' (get) Token: 0x0600F9C6 RID: 63942 RVA: 0x0006DA1C File Offset: 0x0006BC1C
		' (set) Token: 0x0600F9C7 RID: 63943 RVA: 0x0006DA26 File Offset: 0x0006BC26
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17005FB4 RID: 24500
		' (get) Token: 0x0600F9C8 RID: 63944 RVA: 0x0006DA2F File Offset: 0x0006BC2F
		' (set) Token: 0x0600F9C9 RID: 63945 RVA: 0x0006DA39 File Offset: 0x0006BC39
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17005FB5 RID: 24501
		' (get) Token: 0x0600F9CA RID: 63946 RVA: 0x0006DA42 File Offset: 0x0006BC42
		' (set) Token: 0x0600F9CB RID: 63947 RVA: 0x0006DA4C File Offset: 0x0006BC4C
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005FB6 RID: 24502
		' (get) Token: 0x0600F9CC RID: 63948 RVA: 0x0006DA55 File Offset: 0x0006BC55
		' (set) Token: 0x0600F9CD RID: 63949 RVA: 0x0095A920 File Offset: 0x00958B20
		Private _btnNext As Button
		Friend Overridable Property btnNext As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNext
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNext_Click
				Dim button As Button = Me._btnNext
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNext = value
				button = Me._btnNext
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FB7 RID: 24503
		' (get) Token: 0x0600F9CE RID: 63950 RVA: 0x0006DA5F File Offset: 0x0006BC5F
		' (set) Token: 0x0600F9CF RID: 63951 RVA: 0x0095A964 File Offset: 0x00958B64
		Private _btnFirst As Button
		Friend Overridable Property btnFirst As Button
			<CompilerGenerated()>
			Get
				Return Me._btnFirst
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnFirst_Click
				Dim button As Button = Me._btnFirst
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnFirst = value
				button = Me._btnFirst
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FB8 RID: 24504
		' (get) Token: 0x0600F9D0 RID: 63952 RVA: 0x0006DA69 File Offset: 0x0006BC69
		' (set) Token: 0x0600F9D1 RID: 63953 RVA: 0x0095A9A8 File Offset: 0x00958BA8
		Private _txtPrev As Button
		Friend Overridable Property txtPrev As Button
			<CompilerGenerated()>
			Get
				Return Me._txtPrev
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.txtPrev_Click
				Dim button As Button = Me._txtPrev
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._txtPrev = value
				button = Me._txtPrev
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FB9 RID: 24505
		' (get) Token: 0x0600F9D2 RID: 63954 RVA: 0x0006DA73 File Offset: 0x0006BC73
		' (set) Token: 0x0600F9D3 RID: 63955 RVA: 0x0095A9EC File Offset: 0x00958BEC
		Private _btnLast As Button
		Friend Overridable Property btnLast As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLast
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLast_Click
				Dim button As Button = Me._btnLast
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLast = value
				button = Me._btnLast
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FBA RID: 24506
		' (get) Token: 0x0600F9D4 RID: 63956 RVA: 0x0006DA7D File Offset: 0x0006BC7D
		' (set) Token: 0x0600F9D5 RID: 63957 RVA: 0x0095AA30 File Offset: 0x00958C30
		Private _txtNP As TextBox
		Friend Overridable Property txtNP As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNP_KeyDown
				Dim textBox As TextBox = Me._txtNP
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNP = value
				textBox = Me._txtNP
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FBB RID: 24507
		' (get) Token: 0x0600F9D6 RID: 63958 RVA: 0x0006DA87 File Offset: 0x0006BC87
		' (set) Token: 0x0600F9D7 RID: 63959 RVA: 0x0095AA74 File Offset: 0x00958C74
		Private _Button34 As Button
		Friend Overridable Property Button34 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button34
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button34_Click
				Dim button As Button = Me._Button34
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button34 = value
				button = Me._Button34
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FBC RID: 24508
		' (get) Token: 0x0600F9D8 RID: 63960 RVA: 0x0006DA91 File Offset: 0x0006BC91
		' (set) Token: 0x0600F9D9 RID: 63961 RVA: 0x0006DA9B File Offset: 0x0006BC9B
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x17005FBD RID: 24509
		' (get) Token: 0x0600F9DA RID: 63962 RVA: 0x0006DAA4 File Offset: 0x0006BCA4
		' (set) Token: 0x0600F9DB RID: 63963 RVA: 0x0095AAB8 File Offset: 0x00958CB8
		Private _Button35 As Button
		Friend Overridable Property Button35 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button35
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button35_Click
				Dim button As Button = Me._Button35
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button35 = value
				button = Me._Button35
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FBE RID: 24510
		' (get) Token: 0x0600F9DC RID: 63964 RVA: 0x0006DAAE File Offset: 0x0006BCAE
		' (set) Token: 0x0600F9DD RID: 63965 RVA: 0x0006DAB8 File Offset: 0x0006BCB8
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17005FBF RID: 24511
		' (get) Token: 0x0600F9DE RID: 63966 RVA: 0x0006DAC1 File Offset: 0x0006BCC1
		' (set) Token: 0x0600F9DF RID: 63967 RVA: 0x0006DACB File Offset: 0x0006BCCB
		Friend Overridable Property F2 As TextBox

		' Token: 0x17005FC0 RID: 24512
		' (get) Token: 0x0600F9E0 RID: 63968 RVA: 0x0006DAD4 File Offset: 0x0006BCD4
		' (set) Token: 0x0600F9E1 RID: 63969 RVA: 0x0006DADE File Offset: 0x0006BCDE
		Friend Overridable Property F1 As TextBox

		' Token: 0x17005FC1 RID: 24513
		' (get) Token: 0x0600F9E2 RID: 63970 RVA: 0x0006DAE7 File Offset: 0x0006BCE7
		' (set) Token: 0x0600F9E3 RID: 63971 RVA: 0x0095AAFC File Offset: 0x00958CFC
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox1_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FC2 RID: 24514
		' (get) Token: 0x0600F9E4 RID: 63972 RVA: 0x0006DAF1 File Offset: 0x0006BCF1
		' (set) Token: 0x0600F9E5 RID: 63973 RVA: 0x0006DAFB File Offset: 0x0006BCFB
		Friend Overridable Property Label7 As Label

		' Token: 0x17005FC3 RID: 24515
		' (get) Token: 0x0600F9E6 RID: 63974 RVA: 0x0006DB04 File Offset: 0x0006BD04
		' (set) Token: 0x0600F9E7 RID: 63975 RVA: 0x0006DB0E File Offset: 0x0006BD0E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005FC4 RID: 24516
		' (get) Token: 0x0600F9E8 RID: 63976 RVA: 0x0006DB17 File Offset: 0x0006BD17
		' (set) Token: 0x0600F9E9 RID: 63977 RVA: 0x0006DB21 File Offset: 0x0006BD21
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005FC5 RID: 24517
		' (get) Token: 0x0600F9EA RID: 63978 RVA: 0x0006DB2A File Offset: 0x0006BD2A
		' (set) Token: 0x0600F9EB RID: 63979 RVA: 0x0006DB34 File Offset: 0x0006BD34
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005FC6 RID: 24518
		' (get) Token: 0x0600F9EC RID: 63980 RVA: 0x0006DB3D File Offset: 0x0006BD3D
		' (set) Token: 0x0600F9ED RID: 63981 RVA: 0x0006DB47 File Offset: 0x0006BD47
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005FC7 RID: 24519
		' (get) Token: 0x0600F9EE RID: 63982 RVA: 0x0006DB50 File Offset: 0x0006BD50
		' (set) Token: 0x0600F9EF RID: 63983 RVA: 0x0006DB5A File Offset: 0x0006BD5A
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17005FC8 RID: 24520
		' (get) Token: 0x0600F9F0 RID: 63984 RVA: 0x0006DB63 File Offset: 0x0006BD63
		' (set) Token: 0x0600F9F1 RID: 63985 RVA: 0x0006DB6D File Offset: 0x0006BD6D
		Friend Overridable Property Label74 As Label

		' Token: 0x17005FC9 RID: 24521
		' (get) Token: 0x0600F9F2 RID: 63986 RVA: 0x0006DB76 File Offset: 0x0006BD76
		' (set) Token: 0x0600F9F3 RID: 63987 RVA: 0x0095AB78 File Offset: 0x00958D78
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FCA RID: 24522
		' (get) Token: 0x0600F9F4 RID: 63988 RVA: 0x0006DB80 File Offset: 0x0006BD80
		' (set) Token: 0x0600F9F5 RID: 63989 RVA: 0x0095ABBC File Offset: 0x00958DBC
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

		' Token: 0x17005FCB RID: 24523
		' (get) Token: 0x0600F9F6 RID: 63990 RVA: 0x0006DB8A File Offset: 0x0006BD8A
		' (set) Token: 0x0600F9F7 RID: 63991 RVA: 0x0095AC00 File Offset: 0x00958E00
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

		' Token: 0x17005FCC RID: 24524
		' (get) Token: 0x0600F9F8 RID: 63992 RVA: 0x0006DB94 File Offset: 0x0006BD94
		' (set) Token: 0x0600F9F9 RID: 63993 RVA: 0x0095AC44 File Offset: 0x00958E44
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

		' Token: 0x17005FCD RID: 24525
		' (get) Token: 0x0600F9FA RID: 63994 RVA: 0x0006DB9E File Offset: 0x0006BD9E
		' (set) Token: 0x0600F9FB RID: 63995 RVA: 0x0095AC88 File Offset: 0x00958E88
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

		' Token: 0x17005FCE RID: 24526
		' (get) Token: 0x0600F9FC RID: 63996 RVA: 0x0006DBA8 File Offset: 0x0006BDA8
		' (set) Token: 0x0600F9FD RID: 63997 RVA: 0x0095ACCC File Offset: 0x00958ECC
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

		' Token: 0x0600F9FE RID: 63998 RVA: 0x0095AD10 File Offset: 0x00958F10
		Public Sub Incomename()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Income", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbtxtName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbtxtName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600F9FF RID: 63999 RVA: 0x0095AE44 File Offset: 0x00959044
		Public Sub Reset()
			Me.txtVoucherID.Text = ""
			Me.cmbtxtName.Text = ""
			Me.cmbtxtName.SelectedIndex = -1
			Me.txtDetails.Text = ""
			Me.cmbParticulars.Items.Clear()
			Me.cmbParticulars.Text = ""
			Me.txtNotes.Text = ""
			Me.txtVoucherNo.Text = ""
			Me.txtAmount.Text = ""
			Me.txtGrandTotal.Text = ""
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.DataGridView1.Rows.Clear()
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
			Me.Clear()
			Me.auto()
			Me.dtpDate.Focus()
			Me.Fillachead()
			Me.fillName()
			Me.cmbNP.SelectedIndex = -1
			Me.ComboBox1.SelectedIndex = -1
			Me.cmbAccountNo.SelectedIndex = -1
			Me.cmbAccountNo.Enabled = False
		End Sub

		' Token: 0x0600FA00 RID: 64000 RVA: 0x0095AFB4 File Offset: 0x009591B4
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbParticulars.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please enter particulars", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbParticulars.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.txtAmount.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please enter amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAmount.Focus()
					Else
						Dim flag3 As Boolean = Me.DataGridView1.Rows.Count = 0
						If flag3 Then
							Me.DataGridView1.Rows.Add(New Object() { Me.cmbParticulars.Text, Conversion.Val(Me.txtAmount.Text), Me.txtNotes.Text })
							Dim num As Double = Me.GrandTotal()
							num = Math.Round(num, 2)
							Me.txtGrandTotal.Text = Conversions.ToString(num)
							Me.Clear()
							Me.cmbParticulars.Focus()
							Me.cmbParticulars.SelectedIndex = -1
						Else
							Me.DataGridView1.Rows.Add(New Object() { Me.cmbParticulars.Text, Conversion.Val(Me.txtAmount.Text), Me.txtNotes.Text })
							Dim num2 As Double = Me.GrandTotal()
							num2 = Math.Round(num2, 2)
							Me.txtGrandTotal.Text = Conversions.ToString(num2)
							Me.cmbParticulars.SelectedIndex = -1
							Me.Clear()
							Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2)
						End If
					End If
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600FA01 RID: 64001 RVA: 0x0095B204 File Offset: 0x00959404
		Public Sub Clear()
			Me.cmbParticulars.Text = ""
			Me.txtAmount.Text = ""
			Me.txtNotes.Text = ""
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
		End Sub

		' Token: 0x0600FA02 RID: 64002 RVA: 0x0095B260 File Offset: 0x00959460
		Public Function GrandTotal() As Double
			Dim num As Double = 0.0
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(1).Value))
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Return num
		End Function

		' Token: 0x0600FA03 RID: 64003 RVA: 0x0095B324 File Offset: 0x00959524
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Income ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
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
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600FA04 RID: 64004 RVA: 0x0095B490 File Offset: 0x00959690
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrIncome ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
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
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600FA05 RID: 64005 RVA: 0x0095B5FC File Offset: 0x009597FC
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c8),RTRIM(c18) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "INCM"
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.txtInvCode1.Text, "", False) = 0
				If flag4 Then
					Me.txtInvCode1.Text = "INCM"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA06 RID: 64006 RVA: 0x0095B7D4 File Offset: 0x009599D4
		Public Sub auto()
			Try
				Me.txtVoucherID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtVoucherNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA07 RID: 64007 RVA: 0x0095B884 File Offset: 0x00959A84
		Public Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from Income where ID=" + Me.txtVoucherID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag Then
					ModCommonClasses.con.Close()
				End If
				Dim flag2 As Boolean = num > 0
				If flag2 Then
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = If(("delete from Income_OtherDetails where IncomeID=" + Me.txtVoucherID.Text), "")
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					ModFunc.LedgerDelete(Me.txtVoucherNo.Text, "Income")
					ModFunc.SrIncomeDelete(Me.txtVoucherNo.Text)
					ModFunc.BankAccountLedgerDelete(Me.txtVoucherNo.Text, "Income-Bank")
					Dim text3 As String = "deleted the income voucher having voucher no.'" + Me.txtVoucherNo.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text3)
					MessageBox.Show("Successfully Deleted", "Income", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillIncomeID()
					Me.Reset()
					Me.Reset()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillIncomeID()
					Me.Reset()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.DataforNP()
		End Sub

		' Token: 0x0600FA08 RID: 64008 RVA: 0x0006DBB2 File Offset: 0x0006BDB2
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Me.btnRemove.Enabled = True
		End Sub

		' Token: 0x0600FA09 RID: 64009 RVA: 0x0095BAA4 File Offset: 0x00959CA4
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Try
				Try
					For Each obj As Object In Me.DataGridView1.SelectedRows
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.DataGridView1.Rows.Remove(dataGridViewRow)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim num As Double = Me.GrandTotal()
				num = Math.Round(num, 2)
				Me.txtGrandTotal.Text = Conversions.ToString(num)
				Me.btnRemove.Enabled = False
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA0A RID: 64010 RVA: 0x0006DBC2 File Offset: 0x0006BDC2
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600FA0B RID: 64011 RVA: 0x0095BB90 File Offset: 0x00959D90
		Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtAmount.Text
					Dim selectionStart As Integer = Me.txtAmount.SelectionStart
					Dim selectionLength As Integer = Me.txtAmount.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x0600FA0C RID: 64012 RVA: 0x0095BC88 File Offset: 0x00959E88
		Private Sub frmIncome_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.DataforNP()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.Invoicecode()
			Me.auto()
			Me.Fillachead()
			Me.fillName()
			Me.fillIncomeID()
			Me.fillAccountInfo()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FA0D RID: 64013 RVA: 0x0095BD50 File Offset: 0x00959F50
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

		' Token: 0x0600FA0E RID: 64014 RVA: 0x0095BFF0 File Offset: 0x0095A1F0
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

		' Token: 0x0600FA0F RID: 64015 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FA10 RID: 64016 RVA: 0x0095C0BC File Offset: 0x0095A2BC
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(0).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(9, 2)
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

		' Token: 0x0600FA11 RID: 64017 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbtxtName_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0600FA12 RID: 64018 RVA: 0x0095C220 File Offset: 0x0095A420
		Private Sub dtpDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FA13 RID: 64019 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FA14 RID: 64020 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbtxtName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FA15 RID: 64021 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDetails_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FA16 RID: 64022 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbParticulars_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FA17 RID: 64023 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FA18 RID: 64024 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtNotes_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FA19 RID: 64025 RVA: 0x0095C2CC File Offset: 0x0095A4CC
		Public Sub Fillachead()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(a1) from AccountHead where a3='Inc' order by a1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbParticulars.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbParticulars.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA1A RID: 64026 RVA: 0x0095AD10 File Offset: 0x00958F10
		Public Sub fillName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Income", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbtxtName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbtxtName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600FA1B RID: 64027 RVA: 0x0095C3D0 File Offset: 0x0095A5D0
		Private Sub cmbParticulars_SelectedIndexChanged(sender As Object, e As EventArgs)
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
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = "SELECT a2 from AccountHead where a1=@d1 and a3=@d2 "
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbParticulars.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", "Inc")
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						Me.txtNotes.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					End If
					Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag4 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag5 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag5 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA1C RID: 64028 RVA: 0x0095C5A4 File Offset: 0x0095A7A4
		Public Sub fillIncomeID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(ID) FROM Income order by ID ASC", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA1D RID: 64029 RVA: 0x0095C6E0 File Offset: 0x0095A8E0
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(Income.Id) as [Income ID], RTRIM(IncomeNo) as [Income No.],Convert(DateTime,Date,103) as [Income Date], RTRIM(Name) as [Name],RTRIM(Details) as [Details],RTRIM(Income.GrandTotal) as [Grand Total],RTRIM(PMode),RTRIM(BankAcNum) from Income where Income.ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtVoucherID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtVoucherNo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpDate.Value = Conversions.ToDate(ModCommonClasses.rdr.GetValue(2).ToString())
					Me.cmbtxtName.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtDetails.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtGrandTotal.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.ComboBox1.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.cmbAccountNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.btnSave.Enabled = False
					Me.btnDelete.Enabled = True
					Me.btnUpdate.Enabled = True
					Me.btnRemove.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Select RTRIM(Particulars),RTRIM(Amount),RTRIM(Note) from Income,Income_OtherDetails where Income.Id=Income_OtherDetails.IncomeID and Income.ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FA1E RID: 64030 RVA: 0x0006DBDE File Offset: 0x0006BDDE
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x0600FA1F RID: 64031 RVA: 0x0095C9A4 File Offset: 0x0095ABA4
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Income", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Income")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Income").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600FA20 RID: 64032 RVA: 0x0095CA80 File Offset: 0x0095AC80
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtVoucherID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex < Me.cmbNP.Items.Count - 1
				If flag Then
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex + 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("Last Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FA21 RID: 64033 RVA: 0x0095CB3C File Offset: 0x0095AD3C
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtVoucherID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex > 0
				If flag Then
					' The following expression was wrapped in a checked-expression
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex - 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("First Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FA22 RID: 64034 RVA: 0x0095CBE8 File Offset: 0x0095ADE8
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Income").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Income").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FA23 RID: 64035 RVA: 0x0095CCA0 File Offset: 0x0095AEA0
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Income").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FA24 RID: 64036 RVA: 0x0095CD38 File Offset: 0x0095AF38
		Public Sub Speaker()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = 0 To num
					Dim num2 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column2").Value))
					Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(num2)))
					Me.a1 = Me.DataGridView1.Rows(i).Cells("Column1").Value.ToString()
					NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { Me.a1 + " " + Me.txtRsToWords.Text }, Nothing, Nothing, Nothing, True)
				Next
				NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "Thank You" }, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FA25 RID: 64037 RVA: 0x0095CE80 File Offset: 0x0095B080
		Private Sub Button34_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("You have not added the products into grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Speaker()
			End If
		End Sub

		' Token: 0x0600FA26 RID: 64038 RVA: 0x0095CEC4 File Offset: 0x0095B0C4
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x0600FA27 RID: 64039 RVA: 0x0095CF14 File Offset: 0x0095B114
		Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600FA28 RID: 64040 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmIncome_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FA29 RID: 64041 RVA: 0x0095CFFC File Offset: 0x0095B1FC
		Public Sub InvoiceHead()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(LIDS) from InvoiceHead"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.InvDateSts = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.InvDateSts = "No"
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

		' Token: 0x0600FA2A RID: 64042 RVA: 0x0095D0F4 File Offset: 0x0095B2F4
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from Income order by Id DESC"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.prevdate = Conversions.ToDate(ModCommonClasses.rdr.GetValue(0).ToString())
				Else
					Me.prevdate = DateAndTime.Today
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.InvDateSts, "Yes", False) = 0
				If flag4 Then
					Me.dtpDate.Value = Me.prevdate
				Else
					Me.dtpDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA2B RID: 64043 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FA2C RID: 64044 RVA: 0x0095D234 File Offset: 0x0095B434
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtAmount.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAmount, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbtxtName.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbtxtName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbtxtName, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbParticulars.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbParticulars, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbParticulars, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.ComboBox1.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.ComboBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.ComboBox1, String.Empty)
			End If
		End Sub

		' Token: 0x0600FA2D RID: 64045 RVA: 0x0095D374 File Offset: 0x0095B574
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 1
			If flag Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x0600FA2E RID: 64046 RVA: 0x0095D3C0 File Offset: 0x0095B5C0
		Public Sub fillAccountInfo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbAccountNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbAccountNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600FA2F RID: 64047 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FA30 RID: 64048 RVA: 0x0095D4E8 File Offset: 0x0095B6E8
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Income where Date between @d1 and @d2 having count(*) >= 5"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dateTime
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dateTime2
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					MessageBox.Show("You are not allowed to enter more than 5 vouchers for current month in trial version, Please buy register version to use without any limitation." & vbCrLf & "Thank You !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If
				ModCommonClasses.con.Close()
			End If
			Me.auto()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text2 As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text2)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag4 As Boolean = Not ModCommonClasses.rdr.Read()
			If flag4 Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag5 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Try
					Dim flag6 As Boolean = Operators.CompareString(Me.cmbtxtName.Text, "", False) = 0
					If flag6 Then
						MessageBox.Show("Please enter voucher name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbtxtName.Focus()
					Else
						Dim flag7 As Boolean = Me.DataGridView1.Rows.Count = 0
						If flag7 Then
							MessageBox.Show("sorry no data added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = -1
							If flag8 Then
								MessageBox.Show("Please enter payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.ComboBox1.Focus()
							Else
								Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 1
								If flag9 Then
									Dim flag10 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
									If flag10 Then
										MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.cmbAccountNo.Focus()
										Return
									End If
								End If
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "insert into Income(Id, IncomeNo, Date, Name, Details, GrandTotal, PMode, BankAcNum) Values (@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d9)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtVoucherID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtVoucherNo.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbtxtName.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtDetails.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtGrandTotal.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox1.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "insert into Income_OtherDetails(IncomeID, Particulars, Amount, Note, Date, PModeD) VALUES (" + Me.txtVoucherID.Text + ",@d1,@d2,@d3,@d4,@d5)"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Prepare()
								Try
									For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
										Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
										Dim flag11 As Boolean = Not dataGridViewRow.IsNewRow
										If flag11 Then
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ComboBox1.Text)
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.cmd.Parameters.Clear()
										End If
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text5 As String = "insert into SrIncome(ID, InvNo) Values (@d1,@d2)"
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtVoucherNo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								Me.DataforNP()
								Dim text6 As String = "added the new income voucher having voucher no.'" + Me.txtVoucherNo.Text + "'"
								ModFunc.LogFunc(Me.lblUser.Text, text6)
								Dim flag12 As Boolean = Me.ComboBox1.SelectedIndex = 0
								If flag12 Then
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtVoucherNo.Text, "Income", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), "", Me.cmbtxtName.Text)
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbtxtName.Text, Me.txtVoucherNo.Text, "Income", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, "", Me.cmbtxtName.Text)
								End If
								Dim flag13 As Boolean = Me.ComboBox1.SelectedIndex = 1
								If flag13 Then
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtVoucherNo.Text, "Income", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), "", Me.cmbtxtName.Text)
									ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbtxtName.Text, Me.txtVoucherNo.Text, "Income", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, "", Me.cmbtxtName.Text)
								End If
								Dim flag14 As Boolean = Me.ComboBox1.SelectedIndex = 1
								If flag14 Then
									ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtVoucherNo.Text, "Income-Bank", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)))
								End If
								Me.btnSave.Enabled = False
								MessageBox.Show("Successfully Saved", "Income", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.fillIncomeID()
							End If
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600FA31 RID: 64049 RVA: 0x0006DBF6 File Offset: 0x0006BDF6
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600FA32 RID: 64050 RVA: 0x0095DE84 File Offset: 0x0095C084
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbtxtName.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please enter voucher name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbtxtName.Focus()
				Else
					Dim flag2 As Boolean = Me.DataGridView1.Rows.Count = 0
					If flag2 Then
						MessageBox.Show("sorry no data added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = -1
						If flag3 Then
							MessageBox.Show("Please enter payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.ComboBox1.Focus()
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 1
							If flag4 Then
								Dim flag5 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
								If flag5 Then
									MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbAccountNo.Focus()
									Return
								End If
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "Update Income set IncomeNo=@d2, Date=@d3,Name=@d4,Details=@d5,GrandTotal=@d7,PMode=@d8,BankAcNum=@d9 where ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtVoucherID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtVoucherNo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbtxtName.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtDetails.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtGrandTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox1.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = If(("delete from Income_OtherDetails where IncomeID=" + Me.txtVoucherID.Text), "")
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into Income_OtherDetails(IncomeID, Particulars, Amount, Note, Date,PModeD) VALUES (" + Me.txtVoucherID.Text + ",@d1,@d2,@d3,@d4,@d5)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							Try
								For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
									Dim flag6 As Boolean = Not dataGridViewRow.IsNewRow
									If flag6 Then
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ComboBox1.Text)
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.cmd.Parameters.Clear()
									End If
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							ModCommonClasses.con.Close()
							Dim text4 As String = "updated the income voucher having voucher no.'" + Me.txtVoucherNo.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text4)
							Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 0
							If flag7 Then
								ModFunc.LedgerDelete(Me.txtVoucherNo.Text, "Income")
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtVoucherNo.Text, "Income", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), "", Me.cmbtxtName.Text)
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbtxtName.Text, Me.txtVoucherNo.Text, "Income", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, "", Me.cmbtxtName.Text)
							End If
							Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 1
							If flag8 Then
								ModFunc.LedgerDelete(Me.txtVoucherNo.Text, "Income")
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtVoucherNo.Text, "Income", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), "", Me.cmbtxtName.Text)
								ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbtxtName.Text, Me.txtVoucherNo.Text, "Income", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, "", Me.cmbtxtName.Text)
							End If
							ModFunc.BankAccountLedgerDelete(Me.txtVoucherNo.Text, "Income-Bank")
							Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 1
							If flag9 Then
								ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtVoucherNo.Text, "Income-Bank", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)))
							End If
							Me.btnUpdate.Enabled = False
							MessageBox.Show("Successfully Updated", "Income", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FA33 RID: 64051 RVA: 0x0095E624 File Offset: 0x0095C824
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

		' Token: 0x0600FA34 RID: 64052 RVA: 0x0095E68C File Offset: 0x0095C88C
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmIncomeRecord.Reset()
			MyProject.Forms.frmIncomeRecord.Label3.Text = "IR"
			MyProject.Forms.frmIncomeRecord.Button2.Visible = False
			MyProject.Forms.frmIncomeRecord.ShowDialog()
			MyProject.Forms.frmIncomeRecord.Dispose()
		End Sub

		' Token: 0x04005FBD RID: 24509
		Private ntid As String

		' Token: 0x04005FBE RID: 24510
		Private Dad As SqlDataAdapter

		' Token: 0x04005FBF RID: 24511
		Private Dst As DataSet

		' Token: 0x04005FC0 RID: 24512
		Private CurrentRow As Object

		' Token: 0x04005FC1 RID: 24513
		Private voice As Object

		' Token: 0x04005FC2 RID: 24514
		Private a1 As String

		' Token: 0x04005FC3 RID: 24515
		Private InvDateSts As String

		' Token: 0x04005FC4 RID: 24516
		Private prevdate As DateTime
	End Class
End Namespace
