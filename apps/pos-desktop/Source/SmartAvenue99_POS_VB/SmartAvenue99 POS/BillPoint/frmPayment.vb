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
	' Token: 0x020005B5 RID: 1461
	<DesignerGenerated()>
	Public Partial Class frmPayment
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011CC8 RID: 72904 RVA: 0x00A43EE0 File Offset: 0x00A420E0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPayment_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPayment_KeyDown
			Me.i = 0
			Me.ntid = ""
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006E94 RID: 28308
		' (get) Token: 0x06011CCB RID: 72907 RVA: 0x0007A394 File Offset: 0x00078594
		' (set) Token: 0x06011CCC RID: 72908 RVA: 0x0007A39E File Offset: 0x0007859E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006E95 RID: 28309
		' (get) Token: 0x06011CCD RID: 72909 RVA: 0x0007A3A7 File Offset: 0x000785A7
		' (set) Token: 0x06011CCE RID: 72910 RVA: 0x0007A3B1 File Offset: 0x000785B1
		Friend Overridable Property Label3 As Label

		' Token: 0x17006E96 RID: 28310
		' (get) Token: 0x06011CCF RID: 72911 RVA: 0x0007A3BA File Offset: 0x000785BA
		' (set) Token: 0x06011CD0 RID: 72912 RVA: 0x0007A3C4 File Offset: 0x000785C4
		Friend Overridable Property txtTransactionNo As TextBox

		' Token: 0x17006E97 RID: 28311
		' (get) Token: 0x06011CD1 RID: 72913 RVA: 0x0007A3CD File Offset: 0x000785CD
		' (set) Token: 0x06011CD2 RID: 72914 RVA: 0x0007A3D7 File Offset: 0x000785D7
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006E98 RID: 28312
		' (get) Token: 0x06011CD3 RID: 72915 RVA: 0x0007A3E0 File Offset: 0x000785E0
		' (set) Token: 0x06011CD4 RID: 72916 RVA: 0x0007A3EA File Offset: 0x000785EA
		Friend Overridable Property Label1 As Label

		' Token: 0x17006E99 RID: 28313
		' (get) Token: 0x06011CD5 RID: 72917 RVA: 0x0007A3F3 File Offset: 0x000785F3
		' (set) Token: 0x06011CD6 RID: 72918 RVA: 0x0007A3FD File Offset: 0x000785FD
		Friend Overridable Property Label2 As Label

		' Token: 0x17006E9A RID: 28314
		' (get) Token: 0x06011CD7 RID: 72919 RVA: 0x0007A406 File Offset: 0x00078606
		' (set) Token: 0x06011CD8 RID: 72920 RVA: 0x0007A410 File Offset: 0x00078610
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006E9B RID: 28315
		' (get) Token: 0x06011CD9 RID: 72921 RVA: 0x0007A419 File Offset: 0x00078619
		' (set) Token: 0x06011CDA RID: 72922 RVA: 0x00A46C54 File Offset: 0x00A44E54
		Private _dtpTranactionDate As DateTimePicker
		Friend Overridable Property dtpTranactionDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpTranactionDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpTranactionDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpTranactionDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpTranactionDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpTranactionDate = value
				dateTimePicker = Me._dtpTranactionDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E9C RID: 28316
		' (get) Token: 0x06011CDB RID: 72923 RVA: 0x0007A423 File Offset: 0x00078623
		' (set) Token: 0x06011CDC RID: 72924 RVA: 0x00A46CB4 File Offset: 0x00A44EB4
		Private _txtRemarks As RichTextBox
		Friend Overridable Property txtRemarks As RichTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRemarks
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RichTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRemarks_KeyDown
				Dim richTextBox As RichTextBox = Me._txtRemarks
				If richTextBox IsNot Nothing Then
					RemoveHandler richTextBox.KeyDown, keyEventHandler
				End If
				Me._txtRemarks = value
				richTextBox = Me._txtRemarks
				If richTextBox IsNot Nothing Then
					AddHandler richTextBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E9D RID: 28317
		' (get) Token: 0x06011CDD RID: 72925 RVA: 0x0007A42D File Offset: 0x0007862D
		' (set) Token: 0x06011CDE RID: 72926 RVA: 0x0007A437 File Offset: 0x00078637
		Friend Overridable Property Label12 As Label

		' Token: 0x17006E9E RID: 28318
		' (get) Token: 0x06011CDF RID: 72927 RVA: 0x0007A440 File Offset: 0x00078640
		' (set) Token: 0x06011CE0 RID: 72928 RVA: 0x0007A44A File Offset: 0x0007864A
		Friend Overridable Property txtSup_ID As TextBox

		' Token: 0x17006E9F RID: 28319
		' (get) Token: 0x06011CE1 RID: 72929 RVA: 0x0007A453 File Offset: 0x00078653
		' (set) Token: 0x06011CE2 RID: 72930 RVA: 0x0007A45D File Offset: 0x0007865D
		Friend Overridable Property txtT_ID As TextBox

		' Token: 0x17006EA0 RID: 28320
		' (get) Token: 0x06011CE3 RID: 72931 RVA: 0x0007A466 File Offset: 0x00078666
		' (set) Token: 0x06011CE4 RID: 72932 RVA: 0x0007A470 File Offset: 0x00078670
		Friend Overridable Property lblUser As Label

		' Token: 0x17006EA1 RID: 28321
		' (get) Token: 0x06011CE5 RID: 72933 RVA: 0x0007A479 File Offset: 0x00078679
		' (set) Token: 0x06011CE6 RID: 72934 RVA: 0x0007A483 File Offset: 0x00078683
		Friend Overridable Property lblSet As Label

		' Token: 0x17006EA2 RID: 28322
		' (get) Token: 0x06011CE7 RID: 72935 RVA: 0x0007A48C File Offset: 0x0007868C
		' (set) Token: 0x06011CE8 RID: 72936 RVA: 0x0007A496 File Offset: 0x00078696
		Friend Overridable Property lblUserType As Label

		' Token: 0x17006EA3 RID: 28323
		' (get) Token: 0x06011CE9 RID: 72937 RVA: 0x0007A49F File Offset: 0x0007869F
		' (set) Token: 0x06011CEA RID: 72938 RVA: 0x0007A4A9 File Offset: 0x000786A9
		Friend Overridable Property gbPartyInfo As GroupBox

		' Token: 0x17006EA4 RID: 28324
		' (get) Token: 0x06011CEB RID: 72939 RVA: 0x0007A4B2 File Offset: 0x000786B2
		' (set) Token: 0x06011CEC RID: 72940 RVA: 0x00A46CF8 File Offset: 0x00A44EF8
		Private _btnSelection As Button
		Friend Overridable Property btnSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelection_Click
				Dim button As Button = Me._btnSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelection = value
				button = Me._btnSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EA5 RID: 28325
		' (get) Token: 0x06011CED RID: 72941 RVA: 0x0007A4BC File Offset: 0x000786BC
		' (set) Token: 0x06011CEE RID: 72942 RVA: 0x0007A4C6 File Offset: 0x000786C6
		Friend Overridable Property Label10 As Label

		' Token: 0x17006EA6 RID: 28326
		' (get) Token: 0x06011CEF RID: 72943 RVA: 0x0007A4CF File Offset: 0x000786CF
		' (set) Token: 0x06011CF0 RID: 72944 RVA: 0x0007A4D9 File Offset: 0x000786D9
		Friend Overridable Property txtSupplierID As TextBox

		' Token: 0x17006EA7 RID: 28327
		' (get) Token: 0x06011CF1 RID: 72945 RVA: 0x0007A4E2 File Offset: 0x000786E2
		' (set) Token: 0x06011CF2 RID: 72946 RVA: 0x0007A4EC File Offset: 0x000786EC
		Friend Overridable Property lblBalance As Label

		' Token: 0x17006EA8 RID: 28328
		' (get) Token: 0x06011CF3 RID: 72947 RVA: 0x0007A4F5 File Offset: 0x000786F5
		' (set) Token: 0x06011CF4 RID: 72948 RVA: 0x0007A4FF File Offset: 0x000786FF
		Friend Overridable Property Label11 As Label

		' Token: 0x17006EA9 RID: 28329
		' (get) Token: 0x06011CF5 RID: 72949 RVA: 0x0007A508 File Offset: 0x00078708
		' (set) Token: 0x06011CF6 RID: 72950 RVA: 0x0007A512 File Offset: 0x00078712
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x17006EAA RID: 28330
		' (get) Token: 0x06011CF7 RID: 72951 RVA: 0x0007A51B File Offset: 0x0007871B
		' (set) Token: 0x06011CF8 RID: 72952 RVA: 0x0007A525 File Offset: 0x00078725
		Friend Overridable Property txtCity As TextBox

		' Token: 0x17006EAB RID: 28331
		' (get) Token: 0x06011CF9 RID: 72953 RVA: 0x0007A52E File Offset: 0x0007872E
		' (set) Token: 0x06011CFA RID: 72954 RVA: 0x0007A538 File Offset: 0x00078738
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x17006EAC RID: 28332
		' (get) Token: 0x06011CFB RID: 72955 RVA: 0x0007A541 File Offset: 0x00078741
		' (set) Token: 0x06011CFC RID: 72956 RVA: 0x0007A54B File Offset: 0x0007874B
		Friend Overridable Property Label26 As Label

		' Token: 0x17006EAD RID: 28333
		' (get) Token: 0x06011CFD RID: 72957 RVA: 0x0007A554 File Offset: 0x00078754
		' (set) Token: 0x06011CFE RID: 72958 RVA: 0x0007A55E File Offset: 0x0007875E
		Friend Overridable Property Label30 As Label

		' Token: 0x17006EAE RID: 28334
		' (get) Token: 0x06011CFF RID: 72959 RVA: 0x0007A567 File Offset: 0x00078767
		' (set) Token: 0x06011D00 RID: 72960 RVA: 0x0007A571 File Offset: 0x00078771
		Friend Overridable Property Label36 As Label

		' Token: 0x17006EAF RID: 28335
		' (get) Token: 0x06011D01 RID: 72961 RVA: 0x0007A57A File Offset: 0x0007877A
		' (set) Token: 0x06011D02 RID: 72962 RVA: 0x0007A584 File Offset: 0x00078784
		Friend Overridable Property Label19 As Label

		' Token: 0x17006EB0 RID: 28336
		' (get) Token: 0x06011D03 RID: 72963 RVA: 0x0007A58D File Offset: 0x0007878D
		' (set) Token: 0x06011D04 RID: 72964 RVA: 0x00A46D3C File Offset: 0x00A44F3C
		Private _txtTransactionAmount As TextBox
		Friend Overridable Property txtTransactionAmount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTransactionAmount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtTotalPaid_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTransactionAmount_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtTransactionAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtTransactionAmount = value
				textBox = Me._txtTransactionAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EB1 RID: 28337
		' (get) Token: 0x06011D05 RID: 72965 RVA: 0x0007A597 File Offset: 0x00078797
		' (set) Token: 0x06011D06 RID: 72966 RVA: 0x00A46DB8 File Offset: 0x00A44FB8
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
				Dim eventHandler As EventHandler = AddressOf Me.cmbPaymentMode_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbPaymentMode
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbPaymentMode = value
				comboBox = Me._cmbPaymentMode
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EB2 RID: 28338
		' (get) Token: 0x06011D07 RID: 72967 RVA: 0x0007A5A1 File Offset: 0x000787A1
		' (set) Token: 0x06011D08 RID: 72968 RVA: 0x0007A5AB File Offset: 0x000787AB
		Friend Overridable Property Label5 As Label

		' Token: 0x17006EB3 RID: 28339
		' (get) Token: 0x06011D09 RID: 72969 RVA: 0x0007A5B4 File Offset: 0x000787B4
		' (set) Token: 0x06011D0A RID: 72970 RVA: 0x0007A5BE File Offset: 0x000787BE
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17006EB4 RID: 28340
		' (get) Token: 0x06011D0B RID: 72971 RVA: 0x0007A5C7 File Offset: 0x000787C7
		' (set) Token: 0x06011D0C RID: 72972 RVA: 0x0007A5D1 File Offset: 0x000787D1
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17006EB5 RID: 28341
		' (get) Token: 0x06011D0D RID: 72973 RVA: 0x0007A5DA File Offset: 0x000787DA
		' (set) Token: 0x06011D0E RID: 72974 RVA: 0x0007A5E4 File Offset: 0x000787E4
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006EB6 RID: 28342
		' (get) Token: 0x06011D0F RID: 72975 RVA: 0x0007A5ED File Offset: 0x000787ED
		' (set) Token: 0x06011D10 RID: 72976 RVA: 0x00A46E34 File Offset: 0x00A45034
		Private _txtPaymentModeDetails As RichTextBox
		Friend Overridable Property txtPaymentModeDetails As RichTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPaymentModeDetails
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RichTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPaymentModeDetails_KeyDown
				Dim richTextBox As RichTextBox = Me._txtPaymentModeDetails
				If richTextBox IsNot Nothing Then
					RemoveHandler richTextBox.KeyDown, keyEventHandler
				End If
				Me._txtPaymentModeDetails = value
				richTextBox = Me._txtPaymentModeDetails
				If richTextBox IsNot Nothing Then
					AddHandler richTextBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EB7 RID: 28343
		' (get) Token: 0x06011D11 RID: 72977 RVA: 0x0007A5F7 File Offset: 0x000787F7
		' (set) Token: 0x06011D12 RID: 72978 RVA: 0x0007A601 File Offset: 0x00078801
		Friend Overridable Property Label4 As Label

		' Token: 0x17006EB8 RID: 28344
		' (get) Token: 0x06011D13 RID: 72979 RVA: 0x0007A60A File Offset: 0x0007880A
		' (set) Token: 0x06011D14 RID: 72980 RVA: 0x0007A614 File Offset: 0x00078814
		Friend Overridable Property txtTempAmt As TextBox

		' Token: 0x17006EB9 RID: 28345
		' (get) Token: 0x06011D15 RID: 72981 RVA: 0x0007A61D File Offset: 0x0007881D
		' (set) Token: 0x06011D16 RID: 72982 RVA: 0x0007A627 File Offset: 0x00078827
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17006EBA RID: 28346
		' (get) Token: 0x06011D17 RID: 72983 RVA: 0x0007A630 File Offset: 0x00078830
		' (set) Token: 0x06011D18 RID: 72984 RVA: 0x0007A63A File Offset: 0x0007883A
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17006EBB RID: 28347
		' (get) Token: 0x06011D19 RID: 72985 RVA: 0x0007A643 File Offset: 0x00078843
		' (set) Token: 0x06011D1A RID: 72986 RVA: 0x0007A64D File Offset: 0x0007884D
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17006EBC RID: 28348
		' (get) Token: 0x06011D1B RID: 72987 RVA: 0x0007A656 File Offset: 0x00078856
		' (set) Token: 0x06011D1C RID: 72988 RVA: 0x0007A660 File Offset: 0x00078860
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17006EBD RID: 28349
		' (get) Token: 0x06011D1D RID: 72989 RVA: 0x0007A669 File Offset: 0x00078869
		' (set) Token: 0x06011D1E RID: 72990 RVA: 0x00A46E78 File Offset: 0x00A45078
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

		' Token: 0x17006EBE RID: 28350
		' (get) Token: 0x06011D1F RID: 72991 RVA: 0x0007A673 File Offset: 0x00078873
		' (set) Token: 0x06011D20 RID: 72992 RVA: 0x00A46EBC File Offset: 0x00A450BC
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

		' Token: 0x17006EBF RID: 28351
		' (get) Token: 0x06011D21 RID: 72993 RVA: 0x0007A67D File Offset: 0x0007887D
		' (set) Token: 0x06011D22 RID: 72994 RVA: 0x00A46F00 File Offset: 0x00A45100
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

		' Token: 0x17006EC0 RID: 28352
		' (get) Token: 0x06011D23 RID: 72995 RVA: 0x0007A687 File Offset: 0x00078887
		' (set) Token: 0x06011D24 RID: 72996 RVA: 0x00A46F44 File Offset: 0x00A45144
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

		' Token: 0x17006EC1 RID: 28353
		' (get) Token: 0x06011D25 RID: 72997 RVA: 0x0007A691 File Offset: 0x00078891
		' (set) Token: 0x06011D26 RID: 72998 RVA: 0x00A46F88 File Offset: 0x00A45188
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

		' Token: 0x17006EC2 RID: 28354
		' (get) Token: 0x06011D27 RID: 72999 RVA: 0x0007A69B File Offset: 0x0007889B
		' (set) Token: 0x06011D28 RID: 73000 RVA: 0x00A46FCC File Offset: 0x00A451CC
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

		' Token: 0x17006EC3 RID: 28355
		' (get) Token: 0x06011D29 RID: 73001 RVA: 0x0007A6A5 File Offset: 0x000788A5
		' (set) Token: 0x06011D2A RID: 73002 RVA: 0x0007A6AF File Offset: 0x000788AF
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17006EC4 RID: 28356
		' (get) Token: 0x06011D2B RID: 73003 RVA: 0x0007A6B8 File Offset: 0x000788B8
		' (set) Token: 0x06011D2C RID: 73004 RVA: 0x0007A6C2 File Offset: 0x000788C2
		Friend Overridable Property F2 As TextBox

		' Token: 0x17006EC5 RID: 28357
		' (get) Token: 0x06011D2D RID: 73005 RVA: 0x0007A6CB File Offset: 0x000788CB
		' (set) Token: 0x06011D2E RID: 73006 RVA: 0x0007A6D5 File Offset: 0x000788D5
		Friend Overridable Property F1 As TextBox

		' Token: 0x17006EC6 RID: 28358
		' (get) Token: 0x06011D2F RID: 73007 RVA: 0x0007A6DE File Offset: 0x000788DE
		' (set) Token: 0x06011D30 RID: 73008 RVA: 0x0007A6E8 File Offset: 0x000788E8
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006EC7 RID: 28359
		' (get) Token: 0x06011D31 RID: 73009 RVA: 0x0007A6F1 File Offset: 0x000788F1
		' (set) Token: 0x06011D32 RID: 73010 RVA: 0x0007A6FB File Offset: 0x000788FB
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17006EC8 RID: 28360
		' (get) Token: 0x06011D33 RID: 73011 RVA: 0x0007A704 File Offset: 0x00078904
		' (set) Token: 0x06011D34 RID: 73012 RVA: 0x0007A70E File Offset: 0x0007890E
		Friend Overridable Property Label74 As Label

		' Token: 0x17006EC9 RID: 28361
		' (get) Token: 0x06011D35 RID: 73013 RVA: 0x0007A717 File Offset: 0x00078917
		' (set) Token: 0x06011D36 RID: 73014 RVA: 0x00A47010 File Offset: 0x00A45210
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

		' Token: 0x17006ECA RID: 28362
		' (get) Token: 0x06011D37 RID: 73015 RVA: 0x0007A721 File Offset: 0x00078921
		' (set) Token: 0x06011D38 RID: 73016 RVA: 0x0007A72B File Offset: 0x0007892B
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006ECB RID: 28363
		' (get) Token: 0x06011D39 RID: 73017 RVA: 0x0007A734 File Offset: 0x00078934
		' (set) Token: 0x06011D3A RID: 73018 RVA: 0x00A47054 File Offset: 0x00A45254
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

		' Token: 0x17006ECC RID: 28364
		' (get) Token: 0x06011D3B RID: 73019 RVA: 0x0007A73E File Offset: 0x0007893E
		' (set) Token: 0x06011D3C RID: 73020 RVA: 0x00A47098 File Offset: 0x00A45298
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

		' Token: 0x17006ECD RID: 28365
		' (get) Token: 0x06011D3D RID: 73021 RVA: 0x0007A748 File Offset: 0x00078948
		' (set) Token: 0x06011D3E RID: 73022 RVA: 0x00A470DC File Offset: 0x00A452DC
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

		' Token: 0x17006ECE RID: 28366
		' (get) Token: 0x06011D3F RID: 73023 RVA: 0x0007A752 File Offset: 0x00078952
		' (set) Token: 0x06011D40 RID: 73024 RVA: 0x00A47120 File Offset: 0x00A45320
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

		' Token: 0x17006ECF RID: 28367
		' (get) Token: 0x06011D41 RID: 73025 RVA: 0x0007A75C File Offset: 0x0007895C
		' (set) Token: 0x06011D42 RID: 73026 RVA: 0x00A47164 File Offset: 0x00A45364
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

		' Token: 0x17006ED0 RID: 28368
		' (get) Token: 0x06011D43 RID: 73027 RVA: 0x0007A766 File Offset: 0x00078966
		' (set) Token: 0x06011D44 RID: 73028 RVA: 0x0007A770 File Offset: 0x00078970
		Friend Overridable Property cmbSupplierName As TextBox

		' Token: 0x06011D45 RID: 73029 RVA: 0x00A471A8 File Offset: 0x00A453A8
		Public Sub GetSupplierBalance()
			Try
				Try
					Me.num1 = 0D
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID=@d1 group By PartyID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag As Boolean = ModCommonClasses.rdr.Read()
					If flag Then
						Me.num1 = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					Me.lblBalance.Text = Conversions.ToString(Me.num1)
					Me.lblBalance.ForeColor = Color.DarkGreen
					Dim flag2 As Boolean = Conversion.Val(Me.lblBalance.Text) >= 0.0
					If flag2 Then
						Me.str = "Cr"
						Me.lblBalance.ForeColor = Color.Red
					Else
						Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
						If flag3 Then
							Me.str = "Dr"
							Me.lblBalance.ForeColor = Color.Blue
						End If
					End If
					Me.lblBalance.Text = Conversions.ToString(Math.Abs(Conversion.Val(Me.lblBalance.Text)))
					Me.lblBalance.Text = (Me.lblBalance.Text + " " + Me.str).ToString()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011D46 RID: 73030 RVA: 0x00A473EC File Offset: 0x00A455EC
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 T_ID FROM Payment ORDER BY T_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("T_ID"))
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

		' Token: 0x06011D47 RID: 73031 RVA: 0x00A47558 File Offset: 0x00A45758
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrPayment ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06011D48 RID: 73032 RVA: 0x00A476C4 File Offset: 0x00A458C4
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c7),RTRIM(c17) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "PYMT"
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
					Me.txtInvCode1.Text = "PYMT"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011D49 RID: 73033 RVA: 0x00A4789C File Offset: 0x00A45A9C
		Public Sub auto()
			Try
				Me.txtT_ID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtTransactionNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011D4A RID: 73034 RVA: 0x00A4794C File Offset: 0x00A45B4C
		Public Sub Reset()
			Me.btnSelection.Focus()
			Me.txtAddress.Text = ""
			Me.txtCity.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtRemarks.Text = ""
			Me.txtSupplierID.Text = ""
			Me.cmbSupplierName.Text = ""
			Me.txtTransactionAmount.Text = ""
			Me.txtPaymentModeDetails.Text = ""
			Me.cmbPaymentMode.SelectedIndex = 0
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.lblBalance.Text = "0.00"
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnSelection.Enabled = True
			Me.auto()
			Me.cmbNP.SelectedIndex = -1
			Me.cmbAccountNo.SelectedIndex = -1
			Me.cmbAccountNo.Enabled = False
		End Sub

		' Token: 0x06011D4B RID: 73035 RVA: 0x00A47A7C File Offset: 0x00A45C7C
		Public Sub GetSupplierInfo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT SupplierID,Name,Address,City,ContactNo from Supplier where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSup_ID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSupplierID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.cmbSupplierName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtAddress.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtCity.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtContactNo.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011D4C RID: 73036 RVA: 0x00A47BE4 File Offset: 0x00A45DE4
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Payment where T_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtT_ID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.SupplierLedgerDelete(Me.txtTransactionNo.Text)
					ModFunc.LedgerDelete(Me.txtTransactionNo.Text, "Payment")
					ModFunc.SrPaymentDelete(Me.txtTransactionNo.Text)
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-By Cheque")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-By Online Transfer")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-PhonePe")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-Google Pay")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-Paytm")
					ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-E Wallet")
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the payment record having transaction No. '" + Me.txtTransactionNo.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillPaymentID()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillPaymentID()
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
					Me.DataforNP()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011D4D RID: 73037 RVA: 0x00A47E08 File Offset: 0x00A46008
		Private Sub txtTotalPaid_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtTransactionAmount.Text
					Dim selectionStart As Integer = Me.txtTransactionAmount.SelectionStart
					Dim selectionLength As Integer = Me.txtTransactionAmount.SelectionLength
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

		' Token: 0x06011D4E RID: 73038 RVA: 0x00A47F00 File Offset: 0x00A46100
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.dtpTranactionDate.Focus()
			MyProject.Forms.frmSupplierRecord.lblSet.Text = "Payment"
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
			MyProject.Forms.frmSupplierRecord.Dispose()
		End Sub

		' Token: 0x06011D4F RID: 73039 RVA: 0x00A47F6C File Offset: 0x00A4616C
		Private Sub frmPayment_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.DataforNP()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.Invoicecode()
			Me.auto()
			Me.fillPaymentID()
			Me.fillAccountInfo()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011D50 RID: 73040 RVA: 0x00A47FBC File Offset: 0x00A461BC
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

		' Token: 0x06011D51 RID: 73041 RVA: 0x00A4825C File Offset: 0x00A4645C
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

		' Token: 0x06011D52 RID: 73042 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011D53 RID: 73043 RVA: 0x00A48328 File Offset: 0x00A46528
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

		' Token: 0x06011D54 RID: 73044 RVA: 0x00A4848C File Offset: 0x00A4668C
		Private Sub dtpTranactionDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpTranactionDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpTranactionDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpTranactionDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpTranactionDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011D55 RID: 73045 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpTranactionDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011D56 RID: 73046 RVA: 0x00A48538 File Offset: 0x00A46738
		Private Sub cmbPaymentMode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011D57 RID: 73047 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011D58 RID: 73048 RVA: 0x00A48574 File Offset: 0x00A46774
		Private Sub cmbSupplierName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtSup_ID.Text = ""
				Me.txtSupplierID.Text = ""
				Me.txtAddress.Text = ""
				Me.txtCity.Text = ""
				Me.txtContactNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID,RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(ContactNo) from Supplier where Name=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSupplierName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSup_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtCity.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.GetSupplierBalance()
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

		' Token: 0x06011D59 RID: 73049 RVA: 0x00A48538 File Offset: 0x00A46738
		Private Sub txtTransactionAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011D5A RID: 73050 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPaymentModeDetails_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011D5B RID: 73051 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011D5C RID: 73052 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSupplierName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011D5D RID: 73053 RVA: 0x00A48760 File Offset: 0x00A46960
		Public Sub fillPaymentID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(T_ID) FROM Payment order by T_ID ASC", ModCommonClasses.con)
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

		' Token: 0x06011D5E RID: 73054 RVA: 0x00A4889C File Offset: 0x00A46A9C
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(Payment.Remarks),RTRIM(BankAcN) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Payment.T_ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtT_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtTransactionNo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpTranactionDate.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.cmbPaymentMode.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtSup_ID.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.cmbSupplierName.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtTransactionAmount.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtTempAmt.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtPaymentModeDetails.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtRemarks.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.cmbAccountNo.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.btnSave.Enabled = False
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.GetSupplierInfo()
					Me.btnSelection.Enabled = False
					Me.GetSupplierBalance()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011D5F RID: 73055 RVA: 0x0007A779 File Offset: 0x00078979
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06011D60 RID: 73056 RVA: 0x00A48B0C File Offset: 0x00A46D0C
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Payment", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Payment")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Payment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06011D61 RID: 73057 RVA: 0x00A48BE8 File Offset: 0x00A46DE8
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtT_ID.Text))
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

		' Token: 0x06011D62 RID: 73058 RVA: 0x00A48CA4 File Offset: 0x00A46EA4
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x06011D63 RID: 73059 RVA: 0x00A48CF4 File Offset: 0x00A46EF4
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtT_ID.Text))
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

		' Token: 0x06011D64 RID: 73060 RVA: 0x00A48DA0 File Offset: 0x00A46FA0
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Payment").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Payment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011D65 RID: 73061 RVA: 0x00A48E58 File Offset: 0x00A47058
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Payment").Rows(Conversions.ToInteger(Me.CurrentRow))("T_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011D66 RID: 73062 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPayment_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011D67 RID: 73063 RVA: 0x00A48EF0 File Offset: 0x00A470F0
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtTransactionAmount.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtTransactionAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtTransactionAmount, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbSupplierName.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbSupplierName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSupplierName, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbPaymentMode.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbPaymentMode, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbPaymentMode, String.Empty)
			End If
		End Sub

		' Token: 0x06011D68 RID: 73064 RVA: 0x00A48FE4 File Offset: 0x00A471E4
		Private Sub cmbPaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbPaymentMode.SelectedIndex = 1 OrElse Me.cmbPaymentMode.SelectedIndex = 2 OrElse Me.cmbPaymentMode.SelectedIndex = 3 OrElse Me.cmbPaymentMode.SelectedIndex = 4 OrElse Me.cmbPaymentMode.SelectedIndex = 5 OrElse Me.cmbPaymentMode.SelectedIndex = 6
			If flag Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x06011D69 RID: 73065 RVA: 0x00A4907C File Offset: 0x00A4727C
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

		' Token: 0x06011D6A RID: 73066 RVA: 0x0007A791 File Offset: 0x00078991
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Reset()
		End Sub

		' Token: 0x06011D6B RID: 73067 RVA: 0x00A49174 File Offset: 0x00A47374
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpTranactionDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Payment where Date between @d1 and @d2 having count(*) >= 5"
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
				Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtSupplierID.Text)) = 0
				If flag6 Then
					MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSupplierID.Focus()
				Else
					Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.cmbSupplierName.Text)) = 0
					If flag7 Then
						MessageBox.Show("Please select correct supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.cmbSupplierName.Focus()
					Else
						Dim flag8 As Boolean = Me.cmbPaymentMode.SelectedIndex = 1 OrElse Me.cmbPaymentMode.SelectedIndex = 2 OrElse Me.cmbPaymentMode.SelectedIndex = 3 OrElse Me.cmbPaymentMode.SelectedIndex = 4 OrElse Me.cmbPaymentMode.SelectedIndex = 5 OrElse Me.cmbPaymentMode.SelectedIndex = 6
						If flag8 Then
							Dim flag9 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
							If flag9 Then
								MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbAccountNo.Focus()
								Return
							End If
						End If
						Dim flag10 As Boolean = Strings.Len(Strings.Trim(Me.txtTransactionAmount.Text)) = 0
						If flag10 Then
							MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtTransactionAmount.Focus()
						Else
							Dim flag11 As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) = 0.0
							If flag11 Then
								MessageBox.Show("Transaction amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtTransactionAmount.Focus()
							Else
								Dim flag12 As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) > Conversion.Val(Me.lblBalance.Text)
								If flag12 Then
									MessageBox.Show("Transaction amount can not be more than balance", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.txtTransactionAmount.Focus()
								Else
									Try
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "insert into Payment(T_ID, TransactionID, Date, PaymentMode, SupplierID, Amount,Remarks,PaymentModeDetails,BankAcN) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtT_ID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtTransactionNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpTranactionDate.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbPaymentMode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtSup_ID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtTransactionAmount.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtRemarks.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtPaymentModeDetails.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										Dim flag13 As Boolean = Me.cmbPaymentMode.SelectedIndex = 0
										If flag13 Then
											ModFunc.LedgerSave(Me.dtpTranactionDate.Value.[Date], "Cash Account", Me.txtTransactionNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
										End If
										Dim flag14 As Boolean = (Me.cmbPaymentMode.SelectedIndex = 1) Or (Me.cmbPaymentMode.SelectedIndex = 2) Or (Me.cmbPaymentMode.SelectedIndex = 3) Or (Me.cmbPaymentMode.SelectedIndex = 4) Or (Me.cmbPaymentMode.SelectedIndex = 5) Or (Me.cmbPaymentMode.SelectedIndex = 6)
										If flag14 Then
											ModFunc.LedgerSave(Me.dtpTranactionDate.Value.[Date], "Bank Account", Me.txtTransactionNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
										End If
										Dim flag15 As Boolean = Me.cmbPaymentMode.SelectedIndex = 0
										If flag15 Then
											ModFunc.SupplierLedgerSave(Me.dtpTranactionDate.Value.[Date], "Cash Account", Me.txtTransactionNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
										End If
										Dim flag16 As Boolean = (Me.cmbPaymentMode.SelectedIndex = 1) Or (Me.cmbPaymentMode.SelectedIndex = 2) Or (Me.cmbPaymentMode.SelectedIndex = 3) Or (Me.cmbPaymentMode.SelectedIndex = 4) Or (Me.cmbPaymentMode.SelectedIndex = 5) Or (Me.cmbPaymentMode.SelectedIndex = 6)
										If flag16 Then
											ModFunc.SupplierLedgerSave(Me.dtpTranactionDate.Value.[Date], "Bank Account", Me.txtTransactionNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
										End If
										Dim flag17 As Boolean = Me.cmbPaymentMode.SelectedIndex = 1
										If flag17 Then
											ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-By Cheque", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
										End If
										Dim flag18 As Boolean = Me.cmbPaymentMode.SelectedIndex = 2
										If flag18 Then
											ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-By Online Transfer", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
										End If
										Dim flag19 As Boolean = Me.cmbPaymentMode.SelectedIndex = 3
										If flag19 Then
											ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-PhonePe", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
										End If
										Dim flag20 As Boolean = Me.cmbPaymentMode.SelectedIndex = 4
										If flag20 Then
											ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-Google Pay", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
										End If
										Dim flag21 As Boolean = Me.cmbPaymentMode.SelectedIndex = 5
										If flag21 Then
											ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-Paytm", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
										End If
										Dim flag22 As Boolean = Me.cmbPaymentMode.SelectedIndex = 6
										If flag22 Then
											ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-E Wallet", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
										End If
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text4 As String = "insert into SrPayment(ID, InvNo) Values (@d1,@d2)"
										ModCommonClasses.cmd = New SqlCommand(text4)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtTransactionNo.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteReader()
										ModCommonClasses.con.Close()
										ModFunc.LogFunc(Me.lblUser.Text, "added the new payment having transaction No. '" + Me.txtTransactionNo.Text + "'")
										MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.fillPaymentID()
										Me.btnSave.Enabled = False
										ModCommonClasses.con.Close()
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
									Me.DataforNP()
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06011D6C RID: 73068 RVA: 0x00A49D90 File Offset: 0x00A47F90
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtSupplierID.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSupplierID.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbSupplierName.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter correct supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbSupplierName.Focus()
				Else
					Dim flag3 As Boolean = Me.cmbPaymentMode.SelectedIndex = 1 OrElse Me.cmbPaymentMode.SelectedIndex = 2 OrElse Me.cmbPaymentMode.SelectedIndex = 3 OrElse Me.cmbPaymentMode.SelectedIndex = 4 OrElse Me.cmbPaymentMode.SelectedIndex = 5 OrElse Me.cmbPaymentMode.SelectedIndex = 6
					If flag3 Then
						Dim flag4 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
						If flag4 Then
							MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbAccountNo.Focus()
							Return
						End If
					End If
					Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtTransactionAmount.Text)) = 0
					If flag5 Then
						MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtTransactionAmount.Focus()
					Else
						Dim flag6 As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) = 0.0
						If flag6 Then
							MessageBox.Show("Transaction amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtTransactionAmount.Focus()
						Else
							Dim flag7 As Boolean = Conversion.Val(Me.txtTransactionAmount.Text) - Conversion.Val(Me.txtTempAmt.Text) > Conversion.Val(Me.lblBalance.Text)
							If flag7 Then
								MessageBox.Show("Transaction amount can not be more than balance", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.txtTransactionAmount.Focus()
							Else
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text As String = "Update Payment set TransactionID=@d2, Date=@d3, PaymentMode=@d4, SupplierID=@d5, Amount=@d6,Remarks=@d7,PaymentModeDetails=@d8,BankAcN=@d9 where T_ID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtT_ID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtTransactionNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpTranactionDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbPaymentMode.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtSup_ID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtTransactionAmount.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtRemarks.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtPaymentModeDetails.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbAccountNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									Dim flag8 As Boolean = Me.cmbPaymentMode.SelectedIndex = 0
									If flag8 Then
										ModFunc.LedgerUpdate(Me.dtpTranactionDate.Value.[Date], "Cash Account", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text, Me.txtTransactionNo.Text, "Payment")
									End If
									Dim flag9 As Boolean = (Me.cmbPaymentMode.SelectedIndex = 1) Or (Me.cmbPaymentMode.SelectedIndex = 2) Or (Me.cmbPaymentMode.SelectedIndex = 3) Or (Me.cmbPaymentMode.SelectedIndex = 4) Or (Me.cmbPaymentMode.SelectedIndex = 5) Or (Me.cmbPaymentMode.SelectedIndex = 6)
									If flag9 Then
										ModFunc.LedgerUpdate(Me.dtpTranactionDate.Value.[Date], "Bank Account", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text, Me.txtTransactionNo.Text, "Payment")
									End If
									Dim flag10 As Boolean = Me.cmbPaymentMode.SelectedIndex = 0
									If flag10 Then
										ModFunc.SupplierLedgerUpdate(Me.dtpTranactionDate.Value.[Date], "Cash Account", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text, Me.txtTransactionNo.Text, "Payment")
									End If
									Dim flag11 As Boolean = (Me.cmbPaymentMode.SelectedIndex = 1) Or (Me.cmbPaymentMode.SelectedIndex = 2) Or (Me.cmbPaymentMode.SelectedIndex = 3) Or (Me.cmbPaymentMode.SelectedIndex = 4) Or (Me.cmbPaymentMode.SelectedIndex = 5) Or (Me.cmbPaymentMode.SelectedIndex = 6)
									If flag11 Then
										ModFunc.SupplierLedgerUpdate(Me.dtpTranactionDate.Value.[Date], "Bank Account", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D, Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text, Me.txtTransactionNo.Text, "Payment")
									End If
									ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-By Cheque")
									ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-By Online Transfer")
									ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-PhonePe")
									ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-Google Pay")
									ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-Paytm")
									ModFunc.BankAccountLedgerDelete(Me.txtTransactionNo.Text, "Payment-E Wallet")
									Dim flag12 As Boolean = Me.cmbPaymentMode.SelectedIndex = 1
									If flag12 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-By Cheque", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
									End If
									Dim flag13 As Boolean = Me.cmbPaymentMode.SelectedIndex = 2
									If flag13 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-By Online Transfer", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
									End If
									Dim flag14 As Boolean = Me.cmbPaymentMode.SelectedIndex = 3
									If flag14 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-PhonePe", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
									End If
									Dim flag15 As Boolean = Me.cmbPaymentMode.SelectedIndex = 4
									If flag15 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-Google Pay", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
									End If
									Dim flag16 As Boolean = Me.cmbPaymentMode.SelectedIndex = 5
									If flag16 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-Paytm", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
									End If
									Dim flag17 As Boolean = Me.cmbPaymentMode.SelectedIndex = 6
									If flag17 Then
										ModFunc.BankAccountLedgerSave(Me.dtpTranactionDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtTransactionNo.Text, "Payment-E Wallet", New Decimal(Conversion.Val(Me.txtTransactionAmount.Text)), 0D)
									End If
									ModFunc.LogFunc(Me.lblUser.Text, "updated payment record having transaction No. '" + Me.txtTransactionNo.Text + "'")
									MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnUpdate.Enabled = False
									ModCommonClasses.con.Close()
									Me.DataforNP()
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06011D6D RID: 73069 RVA: 0x00A4A784 File Offset: 0x00A48984
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

		' Token: 0x06011D6E RID: 73070 RVA: 0x00A4A7EC File Offset: 0x00A489EC
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmPaymentRecord.lblSet.Text = "Payment"
			MyProject.Forms.frmPaymentRecord.Reset()
			MyProject.Forms.frmPaymentRecord.ShowDialog()
			MyProject.Forms.frmPaymentRecord.Dispose()
		End Sub

		' Token: 0x06011D6F RID: 73071 RVA: 0x00A4A84C File Offset: 0x00A48A4C
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from Payment order by T_ID DESC"
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
					Me.dtpTranactionDate.Value = Me.prevdate
				Else
					Me.dtpTranactionDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011D70 RID: 73072 RVA: 0x00A4A98C File Offset: 0x00A48B8C
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

		' Token: 0x04006B44 RID: 27460
		Private str As String

		' Token: 0x04006B45 RID: 27461
		Private OBType As String

		' Token: 0x04006B46 RID: 27462
		Private num1 As Decimal

		' Token: 0x04006B47 RID: 27463
		Private num2 As Decimal

		' Token: 0x04006B48 RID: 27464
		Private num3 As Decimal

		' Token: 0x04006B49 RID: 27465
		Private num4 As Decimal

		' Token: 0x04006B4A RID: 27466
		Private i As Integer

		' Token: 0x04006B4B RID: 27467
		Private ntid As String

		' Token: 0x04006B4C RID: 27468
		Private Dad As SqlDataAdapter

		' Token: 0x04006B4D RID: 27469
		Private Dst As DataSet

		' Token: 0x04006B4E RID: 27470
		Private CurrentRow As Object

		' Token: 0x04006B4F RID: 27471
		Private InvDateSts As String

		' Token: 0x04006B50 RID: 27472
		Private prevdate As DateTime
	End Class
End Namespace
