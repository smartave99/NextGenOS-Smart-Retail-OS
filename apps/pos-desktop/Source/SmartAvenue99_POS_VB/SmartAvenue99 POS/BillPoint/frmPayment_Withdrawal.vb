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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000312 RID: 786
	<DesignerGenerated()>
	Public Partial Class frmPayment_Withdrawal
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BB82 RID: 48002 RVA: 0x00053E5A File Offset: 0x0005205A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPayment_Withdraw_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPayment_Withdrawal_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004ABB RID: 19131
		' (get) Token: 0x0600BB85 RID: 48005 RVA: 0x00053E8C File Offset: 0x0005208C
		' (set) Token: 0x0600BB86 RID: 48006 RVA: 0x00053E96 File Offset: 0x00052096
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004ABC RID: 19132
		' (get) Token: 0x0600BB87 RID: 48007 RVA: 0x00053E9F File Offset: 0x0005209F
		' (set) Token: 0x0600BB88 RID: 48008 RVA: 0x00053EA9 File Offset: 0x000520A9
		Friend Overridable Property Label3 As Label

		' Token: 0x17004ABD RID: 19133
		' (get) Token: 0x0600BB89 RID: 48009 RVA: 0x00053EB2 File Offset: 0x000520B2
		' (set) Token: 0x0600BB8A RID: 48010 RVA: 0x00053EBC File Offset: 0x000520BC
		Friend Overridable Property txtBranchName As TextBox

		' Token: 0x17004ABE RID: 19134
		' (get) Token: 0x0600BB8B RID: 48011 RVA: 0x00053EC5 File Offset: 0x000520C5
		' (set) Token: 0x0600BB8C RID: 48012 RVA: 0x00053ECF File Offset: 0x000520CF
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004ABF RID: 19135
		' (get) Token: 0x0600BB8D RID: 48013 RVA: 0x00053ED8 File Offset: 0x000520D8
		' (set) Token: 0x0600BB8E RID: 48014 RVA: 0x00053EE2 File Offset: 0x000520E2
		Friend Overridable Property Label1 As Label

		' Token: 0x17004AC0 RID: 19136
		' (get) Token: 0x0600BB8F RID: 48015 RVA: 0x00053EEB File Offset: 0x000520EB
		' (set) Token: 0x0600BB90 RID: 48016 RVA: 0x00053EF5 File Offset: 0x000520F5
		Friend Overridable Property Label7 As Label

		' Token: 0x17004AC1 RID: 19137
		' (get) Token: 0x0600BB91 RID: 48017 RVA: 0x00053EFE File Offset: 0x000520FE
		' (set) Token: 0x0600BB92 RID: 48018 RVA: 0x00053F08 File Offset: 0x00052108
		Friend Overridable Property Label6 As Label

		' Token: 0x17004AC2 RID: 19138
		' (get) Token: 0x0600BB93 RID: 48019 RVA: 0x00053F11 File Offset: 0x00052111
		' (set) Token: 0x0600BB94 RID: 48020 RVA: 0x00053F1B File Offset: 0x0005211B
		Friend Overridable Property txtIFSCCode As TextBox

		' Token: 0x17004AC3 RID: 19139
		' (get) Token: 0x0600BB95 RID: 48021 RVA: 0x00053F24 File Offset: 0x00052124
		' (set) Token: 0x0600BB96 RID: 48022 RVA: 0x00053F2E File Offset: 0x0005212E
		Friend Overridable Property txtSwiftCode As TextBox

		' Token: 0x17004AC4 RID: 19140
		' (get) Token: 0x0600BB97 RID: 48023 RVA: 0x00053F37 File Offset: 0x00052137
		' (set) Token: 0x0600BB98 RID: 48024 RVA: 0x00053F41 File Offset: 0x00052141
		Friend Overridable Property lblUser As Label

		' Token: 0x17004AC5 RID: 19141
		' (get) Token: 0x0600BB99 RID: 48025 RVA: 0x00053F4A File Offset: 0x0005214A
		' (set) Token: 0x0600BB9A RID: 48026 RVA: 0x00053F54 File Offset: 0x00052154
		Friend Overridable Property Label14 As Label

		' Token: 0x17004AC6 RID: 19142
		' (get) Token: 0x0600BB9B RID: 48027 RVA: 0x00053F5D File Offset: 0x0005215D
		' (set) Token: 0x0600BB9C RID: 48028 RVA: 0x00053F67 File Offset: 0x00052167
		Friend Overridable Property txtBank As TextBox

		' Token: 0x17004AC7 RID: 19143
		' (get) Token: 0x0600BB9D RID: 48029 RVA: 0x00053F70 File Offset: 0x00052170
		' (set) Token: 0x0600BB9E RID: 48030 RVA: 0x00053F7A File Offset: 0x0005217A
		Friend Overridable Property Label5 As Label

		' Token: 0x17004AC8 RID: 19144
		' (get) Token: 0x0600BB9F RID: 48031 RVA: 0x00053F83 File Offset: 0x00052183
		' (set) Token: 0x0600BBA0 RID: 48032 RVA: 0x00053F8D File Offset: 0x0005218D
		Friend Overridable Property Label12 As Label

		' Token: 0x17004AC9 RID: 19145
		' (get) Token: 0x0600BBA1 RID: 48033 RVA: 0x00053F96 File Offset: 0x00052196
		' (set) Token: 0x0600BBA2 RID: 48034 RVA: 0x00053FA0 File Offset: 0x000521A0
		Friend Overridable Property txtAccountName As TextBox

		' Token: 0x17004ACA RID: 19146
		' (get) Token: 0x0600BBA3 RID: 48035 RVA: 0x00053FA9 File Offset: 0x000521A9
		' (set) Token: 0x0600BBA4 RID: 48036 RVA: 0x00789B14 File Offset: 0x00787D14
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004ACB RID: 19147
		' (get) Token: 0x0600BBA5 RID: 48037 RVA: 0x00053FB3 File Offset: 0x000521B3
		' (set) Token: 0x0600BBA6 RID: 48038 RVA: 0x00053FBD File Offset: 0x000521BD
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004ACC RID: 19148
		' (get) Token: 0x0600BBA7 RID: 48039 RVA: 0x00053FC6 File Offset: 0x000521C6
		' (set) Token: 0x0600BBA8 RID: 48040 RVA: 0x00053FD0 File Offset: 0x000521D0
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17004ACD RID: 19149
		' (get) Token: 0x0600BBA9 RID: 48041 RVA: 0x00053FD9 File Offset: 0x000521D9
		' (set) Token: 0x0600BBAA RID: 48042 RVA: 0x00053FE3 File Offset: 0x000521E3
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004ACE RID: 19150
		' (get) Token: 0x0600BBAB RID: 48043 RVA: 0x00053FEC File Offset: 0x000521EC
		' (set) Token: 0x0600BBAC RID: 48044 RVA: 0x00053FF6 File Offset: 0x000521F6
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004ACF RID: 19151
		' (get) Token: 0x0600BBAD RID: 48045 RVA: 0x00053FFF File Offset: 0x000521FF
		' (set) Token: 0x0600BBAE RID: 48046 RVA: 0x00789B74 File Offset: 0x00787D74
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

		' Token: 0x17004AD0 RID: 19152
		' (get) Token: 0x0600BBAF RID: 48047 RVA: 0x00054009 File Offset: 0x00052209
		' (set) Token: 0x0600BBB0 RID: 48048 RVA: 0x00789BD4 File Offset: 0x00787DD4
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

		' Token: 0x17004AD1 RID: 19153
		' (get) Token: 0x0600BBB1 RID: 48049 RVA: 0x00054013 File Offset: 0x00052213
		' (set) Token: 0x0600BBB2 RID: 48050 RVA: 0x0005401D File Offset: 0x0005221D
		Friend Overridable Property Label2 As Label

		' Token: 0x17004AD2 RID: 19154
		' (get) Token: 0x0600BBB3 RID: 48051 RVA: 0x00054026 File Offset: 0x00052226
		' (set) Token: 0x0600BBB4 RID: 48052 RVA: 0x00789C50 File Offset: 0x00787E50
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

		' Token: 0x17004AD3 RID: 19155
		' (get) Token: 0x0600BBB5 RID: 48053 RVA: 0x00054030 File Offset: 0x00052230
		' (set) Token: 0x0600BBB6 RID: 48054 RVA: 0x0005403A File Offset: 0x0005223A
		Friend Overridable Property Label8 As Label

		' Token: 0x17004AD4 RID: 19156
		' (get) Token: 0x0600BBB7 RID: 48055 RVA: 0x00054043 File Offset: 0x00052243
		' (set) Token: 0x0600BBB8 RID: 48056 RVA: 0x0005404D File Offset: 0x0005224D
		Friend Overridable Property Label10 As Label

		' Token: 0x17004AD5 RID: 19157
		' (get) Token: 0x0600BBB9 RID: 48057 RVA: 0x00054056 File Offset: 0x00052256
		' (set) Token: 0x0600BBBA RID: 48058 RVA: 0x00789C94 File Offset: 0x00787E94
		Private _txtR_W As TextBox
		Friend Overridable Property txtR_W As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtR_W
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtR_W_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtR_W
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtR_W = value
				textBox = Me._txtR_W
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AD6 RID: 19158
		' (get) Token: 0x0600BBBB RID: 48059 RVA: 0x00054060 File Offset: 0x00052260
		' (set) Token: 0x0600BBBC RID: 48060 RVA: 0x0005406A File Offset: 0x0005226A
		Friend Overridable Property Label11 As Label

		' Token: 0x17004AD7 RID: 19159
		' (get) Token: 0x0600BBBD RID: 48061 RVA: 0x00054073 File Offset: 0x00052273
		' (set) Token: 0x0600BBBE RID: 48062 RVA: 0x00789CF4 File Offset: 0x00787EF4
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbAccountNo_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AD8 RID: 19160
		' (get) Token: 0x0600BBBF RID: 48063 RVA: 0x0005407D File Offset: 0x0005227D
		' (set) Token: 0x0600BBC0 RID: 48064 RVA: 0x00054087 File Offset: 0x00052287
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17004AD9 RID: 19161
		' (get) Token: 0x0600BBC1 RID: 48065 RVA: 0x00054090 File Offset: 0x00052290
		' (set) Token: 0x0600BBC2 RID: 48066 RVA: 0x0005409A File Offset: 0x0005229A
		Friend Overridable Property DateTo As DateTimePicker

		' Token: 0x17004ADA RID: 19162
		' (get) Token: 0x0600BBC3 RID: 48067 RVA: 0x000540A3 File Offset: 0x000522A3
		' (set) Token: 0x0600BBC4 RID: 48068 RVA: 0x000540AD File Offset: 0x000522AD
		Friend Overridable Property DateFrom As DateTimePicker

		' Token: 0x17004ADB RID: 19163
		' (get) Token: 0x0600BBC5 RID: 48069 RVA: 0x000540B6 File Offset: 0x000522B6
		' (set) Token: 0x0600BBC6 RID: 48070 RVA: 0x000540C0 File Offset: 0x000522C0
		Friend Overridable Property Label4 As Label

		' Token: 0x17004ADC RID: 19164
		' (get) Token: 0x0600BBC7 RID: 48071 RVA: 0x000540C9 File Offset: 0x000522C9
		' (set) Token: 0x0600BBC8 RID: 48072 RVA: 0x000540D3 File Offset: 0x000522D3
		Friend Overridable Property label9 As Label

		' Token: 0x17004ADD RID: 19165
		' (get) Token: 0x0600BBC9 RID: 48073 RVA: 0x000540DC File Offset: 0x000522DC
		' (set) Token: 0x0600BBCA RID: 48074 RVA: 0x000540E6 File Offset: 0x000522E6
		Friend Overridable Property groupBox5 As GroupBox

		' Token: 0x17004ADE RID: 19166
		' (get) Token: 0x0600BBCB RID: 48075 RVA: 0x000540EF File Offset: 0x000522EF
		' (set) Token: 0x0600BBCC RID: 48076 RVA: 0x00789D70 File Offset: 0x00787F70
		Private _txtAccNo As TextBox
		Friend Overridable Property txtAccNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAccNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtAccNo_TextChanged
				Dim textBox As TextBox = Me._txtAccNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtAccNo = value
				textBox = Me._txtAccNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004ADF RID: 19167
		' (get) Token: 0x0600BBCD RID: 48077 RVA: 0x000540F9 File Offset: 0x000522F9
		' (set) Token: 0x0600BBCE RID: 48078 RVA: 0x00054103 File Offset: 0x00052303
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004AE0 RID: 19168
		' (get) Token: 0x0600BBCF RID: 48079 RVA: 0x0005410C File Offset: 0x0005230C
		' (set) Token: 0x0600BBD0 RID: 48080 RVA: 0x00054116 File Offset: 0x00052316
		Friend Overridable Property Label15 As Label

		' Token: 0x17004AE1 RID: 19169
		' (get) Token: 0x0600BBD1 RID: 48081 RVA: 0x0005411F File Offset: 0x0005231F
		' (set) Token: 0x0600BBD2 RID: 48082 RVA: 0x00789DB4 File Offset: 0x00787FB4
		Private _cmbPaymentMode As ComboBox
		Friend Overridable Property cmbPaymentMode As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPaymentMode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPaymentMode_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbPaymentMode
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbPaymentMode = value
				comboBox = Me._cmbPaymentMode
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AE2 RID: 19170
		' (get) Token: 0x0600BBD3 RID: 48083 RVA: 0x00054129 File Offset: 0x00052329
		' (set) Token: 0x0600BBD4 RID: 48084 RVA: 0x00054133 File Offset: 0x00052333
		Friend Overridable Property Label13 As Label

		' Token: 0x17004AE3 RID: 19171
		' (get) Token: 0x0600BBD5 RID: 48085 RVA: 0x0005413C File Offset: 0x0005233C
		' (set) Token: 0x0600BBD6 RID: 48086 RVA: 0x00789E14 File Offset: 0x00788014
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AE4 RID: 19172
		' (get) Token: 0x0600BBD7 RID: 48087 RVA: 0x00054146 File Offset: 0x00052346
		' (set) Token: 0x0600BBD8 RID: 48088 RVA: 0x00054150 File Offset: 0x00052350
		Friend Overridable Property Label20 As Label

		' Token: 0x17004AE5 RID: 19173
		' (get) Token: 0x0600BBD9 RID: 48089 RVA: 0x00054159 File Offset: 0x00052359
		' (set) Token: 0x0600BBDA RID: 48090 RVA: 0x00054163 File Offset: 0x00052363
		Friend Overridable Property txtBalanceAmount As TextBox

		' Token: 0x17004AE6 RID: 19174
		' (get) Token: 0x0600BBDB RID: 48091 RVA: 0x0005416C File Offset: 0x0005236C
		' (set) Token: 0x0600BBDC RID: 48092 RVA: 0x00054176 File Offset: 0x00052376
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004AE7 RID: 19175
		' (get) Token: 0x0600BBDD RID: 48093 RVA: 0x0005417F File Offset: 0x0005237F
		' (set) Token: 0x0600BBDE RID: 48094 RVA: 0x00054189 File Offset: 0x00052389
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004AE8 RID: 19176
		' (get) Token: 0x0600BBDF RID: 48095 RVA: 0x00054192 File Offset: 0x00052392
		' (set) Token: 0x0600BBE0 RID: 48096 RVA: 0x0005419C File Offset: 0x0005239C
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004AE9 RID: 19177
		' (get) Token: 0x0600BBE1 RID: 48097 RVA: 0x000541A5 File Offset: 0x000523A5
		' (set) Token: 0x0600BBE2 RID: 48098 RVA: 0x000541AF File Offset: 0x000523AF
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004AEA RID: 19178
		' (get) Token: 0x0600BBE3 RID: 48099 RVA: 0x000541B8 File Offset: 0x000523B8
		' (set) Token: 0x0600BBE4 RID: 48100 RVA: 0x000541C2 File Offset: 0x000523C2
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004AEB RID: 19179
		' (get) Token: 0x0600BBE5 RID: 48101 RVA: 0x000541CB File Offset: 0x000523CB
		' (set) Token: 0x0600BBE6 RID: 48102 RVA: 0x000541D5 File Offset: 0x000523D5
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004AEC RID: 19180
		' (get) Token: 0x0600BBE7 RID: 48103 RVA: 0x000541DE File Offset: 0x000523DE
		' (set) Token: 0x0600BBE8 RID: 48104 RVA: 0x000541E8 File Offset: 0x000523E8
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004AED RID: 19181
		' (get) Token: 0x0600BBE9 RID: 48105 RVA: 0x000541F1 File Offset: 0x000523F1
		' (set) Token: 0x0600BBEA RID: 48106 RVA: 0x000541FB File Offset: 0x000523FB
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004AEE RID: 19182
		' (get) Token: 0x0600BBEB RID: 48107 RVA: 0x00054204 File Offset: 0x00052404
		' (set) Token: 0x0600BBEC RID: 48108 RVA: 0x00789E74 File Offset: 0x00788074
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

		' Token: 0x17004AEF RID: 19183
		' (get) Token: 0x0600BBED RID: 48109 RVA: 0x0005420E File Offset: 0x0005240E
		' (set) Token: 0x0600BBEE RID: 48110 RVA: 0x00054218 File Offset: 0x00052418
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17004AF0 RID: 19184
		' (get) Token: 0x0600BBEF RID: 48111 RVA: 0x00054221 File Offset: 0x00052421
		' (set) Token: 0x0600BBF0 RID: 48112 RVA: 0x0005422B File Offset: 0x0005242B
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17004AF1 RID: 19185
		' (get) Token: 0x0600BBF1 RID: 48113 RVA: 0x00054234 File Offset: 0x00052434
		' (set) Token: 0x0600BBF2 RID: 48114 RVA: 0x0005423E File Offset: 0x0005243E
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004AF2 RID: 19186
		' (get) Token: 0x0600BBF3 RID: 48115 RVA: 0x00054247 File Offset: 0x00052447
		' (set) Token: 0x0600BBF4 RID: 48116 RVA: 0x00054251 File Offset: 0x00052451
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004AF3 RID: 19187
		' (get) Token: 0x0600BBF5 RID: 48117 RVA: 0x0005425A File Offset: 0x0005245A
		' (set) Token: 0x0600BBF6 RID: 48118 RVA: 0x00789EB8 File Offset: 0x007880B8
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrint_Click
				Dim gelButton As GelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnPrint = value
				gelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AF4 RID: 19188
		' (get) Token: 0x0600BBF7 RID: 48119 RVA: 0x00054264 File Offset: 0x00052464
		' (set) Token: 0x0600BBF8 RID: 48120 RVA: 0x00789EFC File Offset: 0x007880FC
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

		' Token: 0x17004AF5 RID: 19189
		' (get) Token: 0x0600BBF9 RID: 48121 RVA: 0x0005426E File Offset: 0x0005246E
		' (set) Token: 0x0600BBFA RID: 48122 RVA: 0x00789F40 File Offset: 0x00788140
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

		' Token: 0x17004AF6 RID: 19190
		' (get) Token: 0x0600BBFB RID: 48123 RVA: 0x00054278 File Offset: 0x00052478
		' (set) Token: 0x0600BBFC RID: 48124 RVA: 0x00789F84 File Offset: 0x00788184
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

		' Token: 0x17004AF7 RID: 19191
		' (get) Token: 0x0600BBFD RID: 48125 RVA: 0x00054282 File Offset: 0x00052482
		' (set) Token: 0x0600BBFE RID: 48126 RVA: 0x00789FC8 File Offset: 0x007881C8
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AF8 RID: 19192
		' (get) Token: 0x0600BBFF RID: 48127 RVA: 0x0005428C File Offset: 0x0005248C
		' (set) Token: 0x0600BC00 RID: 48128 RVA: 0x0078A00C File Offset: 0x0078820C
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

		' Token: 0x17004AF9 RID: 19193
		' (get) Token: 0x0600BC01 RID: 48129 RVA: 0x00054296 File Offset: 0x00052496
		' (set) Token: 0x0600BC02 RID: 48130 RVA: 0x0078A050 File Offset: 0x00788250
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

		' Token: 0x0600BC03 RID: 48131 RVA: 0x0078A094 File Offset: 0x00788294
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM Payment_Withdraw"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.txtID.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.txtID.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BC04 RID: 48132 RVA: 0x000542A0 File Offset: 0x000524A0
		Public Sub Clear()
			Me.DateFrom.Value = DateAndTime.Today
			Me.DateTo.Value = DateAndTime.Today
			Me.txtAccNo.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600BC05 RID: 48133 RVA: 0x0078A198 File Offset: 0x00788398
		Public Sub Reset()
			Me.txtR_W.Text = ""
			Me.txtAccountName.Text = ""
			Me.cmbAccountNo.SelectedIndex = -1
			Me.cmbPaymentMode.SelectedIndex = 0
			Me.txtContactNo.Text = ""
			Me.txtBalanceAmount.Text = ""
			Me.txtAmount.Text = ""
			Me.dtpDate.Value = DateAndTime.Today
			Me.txtNotes.Text = ""
			Me.txtIFSCCode.Text = ""
			Me.txtSwiftCode.Text = ""
			Me.txtBranchName.Text = ""
			Me.txtBank.Text = ""
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnPrint.Enabled = False
			Me.txtR_W.Focus()
			Me.Clear()
			Me.auto()
		End Sub

		' Token: 0x0600BC06 RID: 48134 RVA: 0x0078A2BC File Offset: 0x007884BC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Payment_Withdraw.Id, RTRIM(ReceiverName),RTRIM(PhoneNo), Amount, Payment_Withdraw.Date, RTRIM(PaymentMode),RTRIM(Payment_Withdraw.Notes),RTRIM(AccountFrom) from Payment_Withdraw order by Date", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BC07 RID: 48135 RVA: 0x0078A414 File Offset: 0x00788614
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Payment_Withdraw where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					Dim text2 As String = String.Concat(New String() { "Deleted the Payment/Withdrawal record having account no. '", Me.cmbAccountNo.Text, "' and Transaction ID '", Me.txtID.Text, "'" })
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					ModFunc.BankAccountLedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Payment/Withdrawal")
					ModFunc.LedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Withdrawal")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BC08 RID: 48136 RVA: 0x0078A5D8 File Offset: 0x007887D8
		Private Sub cmbAccountNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode),IsNull(Sum(BalanceAmount),0),IsNull(Sum(Credit) - Sum(Debit),0) from BankAccountRegistration LEFT JOIN BankBranch ON BankAccountRegistration.BranchID = BankBranch.Id LEFT JOIN BankAccountLedger ON BankAccountRegistration.AccountNo = BankAccountLedger.AccNo where AccountNo=@d1 group by AccountName,BankName,BranchName,SwiftCode,IFSCCode"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtAccountName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.txtBank.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtBranchName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtSwiftCode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtIFSCCode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
					Me.txtBalanceAmount.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(6))
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

		' Token: 0x0600BC09 RID: 48137 RVA: 0x0078A784 File Offset: 0x00788984
		Public Sub fillAccountNo()
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

		' Token: 0x0600BC0A RID: 48138 RVA: 0x0078A8AC File Offset: 0x00788AAC
		Private Sub frmPayment_Withdraw_Load(sender As Object, e As EventArgs)
			Me.FYSerrch()
			Me.fillAccountNo()
			Me.Getdata()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600BC0B RID: 48139 RVA: 0x0078A944 File Offset: 0x00788B44
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

		' Token: 0x0600BC0C RID: 48140 RVA: 0x0078AABC File Offset: 0x00788CBC
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

		' Token: 0x0600BC0D RID: 48141 RVA: 0x0078AB78 File Offset: 0x00788D78
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

		' Token: 0x0600BC0E RID: 48142 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600BC0F RID: 48143 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600BC10 RID: 48144 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600BC11 RID: 48145 RVA: 0x0078AC44 File Offset: 0x00788E44
		Private Sub FYSerrch()
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

		' Token: 0x0600BC12 RID: 48146 RVA: 0x0078AD3C File Offset: 0x00788F3C
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

		' Token: 0x0600BC13 RID: 48147 RVA: 0x0078AE34 File Offset: 0x00789034
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

		' Token: 0x0600BC14 RID: 48148 RVA: 0x0078AF1C File Offset: 0x0078911C
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtR_W.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtContactNo.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtAmount.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.dtpDate.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.cmbPaymentMode.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtNotes.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.cmbAccountNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.btnSave.Enabled = False
					Me.btnDelete.Enabled = True
					Me.btnPrint.Enabled = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BC15 RID: 48149 RVA: 0x0078B0C0 File Offset: 0x007892C0
		Private Sub txtAccNo_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Payment_Withdraw.Id, RTRIM(ReceiverName),RTRIM(PhoneNo), Amount, Payment_Withdraw.Date, RTRIM(PaymentMode),RTRIM(Payment_Withdraw.Notes),RTRIM(AccountFrom) from Payment_Withdraw where AccountFrom like N'%" + Me.txtAccNo.Text + "%' order by Date", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BC16 RID: 48150 RVA: 0x000542DD File Offset: 0x000524DD
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600BC17 RID: 48151 RVA: 0x0078B220 File Offset: 0x00789420
		Private Sub dtpDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600BC18 RID: 48152 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtR_W_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BC19 RID: 48153 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BC1A RID: 48154 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BC1B RID: 48155 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BC1C RID: 48156 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPaymentMode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BC1D RID: 48157 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtNotes_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BC1E RID: 48158 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BC1F RID: 48159 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPayment_Withdrawal_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BC20 RID: 48160 RVA: 0x0078B2C0 File Offset: 0x007894C0
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtR_W.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtR_W, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtR_W, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtAmount.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAmount, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.cmbPaymentMode.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.cmbPaymentMode, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbPaymentMode, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.cmbAccountNo.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.cmbAccountNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbAccountNo, String.Empty)
			End If
		End Sub

		' Token: 0x0600BC21 RID: 48161 RVA: 0x000542F9 File Offset: 0x000524F9
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BC22 RID: 48162 RVA: 0x0078B44C File Offset: 0x0078964C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtR_W.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter receiver/withdrawer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtR_W.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtAmount.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAmount.Focus()
					Else
						Dim flag5 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
						If flag5 Then
							MessageBox.Show("Amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtAmount.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.cmbAccountNo.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please select account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbAccountNo.Focus()
							Else
								Dim flag7 As Boolean = Conversion.Val(Me.txtBalanceAmount.Text) < Conversion.Val(Me.txtAmount.Text)
								If flag7 Then
									MessageBox.Show("Transferred Amount must be less than or equal to balance amount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.txtAmount.Focus()
								Else
									Try
										Me.auto()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "insert into Payment_Withdraw( id, AccountFrom, PaymentMode, Date, Amount, ReceiverName, PhoneNo, Notes) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbAccountNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbPaymentMode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtAmount.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtR_W.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtContactNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtNotes.Text)
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										Dim text3 As String = String.Concat(New String() { "added the new Payment/Withdrawal from account no. '", Me.cmbAccountNo.Text, "' having Transaction ID '", Me.txtID.Text, "'" })
										ModFunc.LogFunc(Me.lblUser.Text, text3)
										ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Payment/Withdrawal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D)
										ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund Withdrawal", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.cmbAccountNo.Text, Me.txtAccountName.Text)
										MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.btnSave.Enabled = False
										Me.btnPrint.Enabled = True
										Me.Getdata()
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BC23 RID: 48163 RVA: 0x0078B960 File Offset: 0x00789B60
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

		' Token: 0x0600BC24 RID: 48164 RVA: 0x0078B9C8 File Offset: 0x00789BC8
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
				Dim sqlCommand2 As SqlCommand = New SqlCommand(If(("SELECT Payment_Withdraw.Id, ReceiverName,PhoneNo, Amount, Payment_Withdraw.Date,PaymentMode,Payment_Withdraw.Notes,AccountFrom from Payment_Withdraw where Payment_Withdraw.ID=" + Conversions.ToString(Conversion.Val(Me.txtID.Text))), ""), ModCommonClasses.con)
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(sqlCommand2)
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = New DataTable()
				sqlDataAdapter.Fill(dataTable)
				sqlDataAdapter2.Fill(dataTable2)
				Dim dataSet As DataSet = New DataSet()
				dataSet.Tables.Add(dataTable)
				dataSet.Tables.Add(dataTable2)
				dataSet.WriteXmlSchema("Payment_WithdrawerReceipt.xml")
				Dim rptPayment_WithdrawalReceipt As rptPayment_WithdrawalReceipt = New rptPayment_WithdrawalReceipt()
				rptPayment_WithdrawalReceipt.SetDataSource(dataSet)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptPayment_WithdrawalReceipt
				MyProject.Forms.frmReport.ShowDialog()
				rptPayment_WithdrawalReceipt.Close()
				rptPayment_WithdrawalReceipt.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BC25 RID: 48165 RVA: 0x0078BB38 File Offset: 0x00789D38
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Payment_Withdraw.Id, RTRIM(ReceiverName),RTRIM(PhoneNo), Amount, Payment_Withdraw.Date, RTRIM(PaymentMode),RTRIM(Payment_Withdraw.Notes),RTRIM(AccountFrom) from Payment_Withdraw where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BC26 RID: 48166 RVA: 0x00054303 File Offset: 0x00052503
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Clear()
		End Sub

		' Token: 0x0600BC27 RID: 48167 RVA: 0x0078BCF8 File Offset: 0x00789EF8
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
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
	End Class
End Namespace
