Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005E2 RID: 1506
	<DesignerGenerated()>
	Public Partial Class frmRegistration
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012827 RID: 75815 RVA: 0x00AA7610 File Offset: 0x00AA5810
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmRegistration_Load
			AddHandler MyBase.Closing, AddressOf Me.frmRegistration_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmRegistration_KeyDown
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x170072D8 RID: 29400
		' (get) Token: 0x0601282A RID: 75818 RVA: 0x0007EF1B File Offset: 0x0007D11B
		' (set) Token: 0x0601282B RID: 75819 RVA: 0x0007EF25 File Offset: 0x0007D125
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170072D9 RID: 29401
		' (get) Token: 0x0601282C RID: 75820 RVA: 0x0007EF2E File Offset: 0x0007D12E
		' (set) Token: 0x0601282D RID: 75821 RVA: 0x0007EF38 File Offset: 0x0007D138
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170072DA RID: 29402
		' (get) Token: 0x0601282E RID: 75822 RVA: 0x0007EF41 File Offset: 0x0007D141
		' (set) Token: 0x0601282F RID: 75823 RVA: 0x0007EF4B File Offset: 0x0007D14B
		Friend Overridable Property Label3 As Label

		' Token: 0x170072DB RID: 29403
		' (get) Token: 0x06012830 RID: 75824 RVA: 0x0007EF54 File Offset: 0x0007D154
		' (set) Token: 0x06012831 RID: 75825 RVA: 0x00AA9E7C File Offset: 0x00AA807C
		Private _txtUserID As TextBox
		Friend Overridable Property txtUserID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtUserID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtUserID_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtUserID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtUserID = value
				textBox = Me._txtUserID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072DC RID: 29404
		' (get) Token: 0x06012832 RID: 75826 RVA: 0x0007EF5E File Offset: 0x0007D15E
		' (set) Token: 0x06012833 RID: 75827 RVA: 0x0007EF68 File Offset: 0x0007D168
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170072DD RID: 29405
		' (get) Token: 0x06012834 RID: 75828 RVA: 0x0007EF71 File Offset: 0x0007D171
		' (set) Token: 0x06012835 RID: 75829 RVA: 0x00AA9EDC File Offset: 0x00AA80DC
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
				Dim dataGridViewCellFormattingEventHandler As DataGridViewCellFormattingEventHandler = AddressOf Me.dgw_CellFormatting
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.dgw_EditingControlShowing
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072DE RID: 29406
		' (get) Token: 0x06012836 RID: 75830 RVA: 0x0007EF7B File Offset: 0x0007D17B
		' (set) Token: 0x06012837 RID: 75831 RVA: 0x0007EF85 File Offset: 0x0007D185
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170072DF RID: 29407
		' (get) Token: 0x06012838 RID: 75832 RVA: 0x0007EF8E File Offset: 0x0007D18E
		' (set) Token: 0x06012839 RID: 75833 RVA: 0x0007EF98 File Offset: 0x0007D198
		Friend Overridable Property Label1 As Label

		' Token: 0x170072E0 RID: 29408
		' (get) Token: 0x0601283A RID: 75834 RVA: 0x0007EFA1 File Offset: 0x0007D1A1
		' (set) Token: 0x0601283B RID: 75835 RVA: 0x0007EFAB File Offset: 0x0007D1AB
		Friend Overridable Property Label7 As Label

		' Token: 0x170072E1 RID: 29409
		' (get) Token: 0x0601283C RID: 75836 RVA: 0x0007EFB4 File Offset: 0x0007D1B4
		' (set) Token: 0x0601283D RID: 75837 RVA: 0x0007EFBE File Offset: 0x0007D1BE
		Friend Overridable Property Label6 As Label

		' Token: 0x170072E2 RID: 29410
		' (get) Token: 0x0601283E RID: 75838 RVA: 0x0007EFC7 File Offset: 0x0007D1C7
		' (set) Token: 0x0601283F RID: 75839 RVA: 0x0007EFD1 File Offset: 0x0007D1D1
		Friend Overridable Property Label5 As Label

		' Token: 0x170072E3 RID: 29411
		' (get) Token: 0x06012840 RID: 75840 RVA: 0x0007EFDA File Offset: 0x0007D1DA
		' (set) Token: 0x06012841 RID: 75841 RVA: 0x00AA9F7C File Offset: 0x00AA817C
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtContactNo_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072E4 RID: 29412
		' (get) Token: 0x06012842 RID: 75842 RVA: 0x0007EFE4 File Offset: 0x0007D1E4
		' (set) Token: 0x06012843 RID: 75843 RVA: 0x00AA9FF8 File Offset: 0x00AA81F8
		Private _txtEmailID As TextBox
		Friend Overridable Property txtEmailID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmailID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtEmailID_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtEmailID_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtEmailID = value
				textBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072E5 RID: 29413
		' (get) Token: 0x06012844 RID: 75844 RVA: 0x0007EFEE File Offset: 0x0007D1EE
		' (set) Token: 0x06012845 RID: 75845 RVA: 0x00AAA074 File Offset: 0x00AA8274
		Private _txtName As TextBox
		Friend Overridable Property txtName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtName = value
				textBox = Me._txtName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072E6 RID: 29414
		' (get) Token: 0x06012846 RID: 75846 RVA: 0x0007EFF8 File Offset: 0x0007D1F8
		' (set) Token: 0x06012847 RID: 75847 RVA: 0x00AAA0D4 File Offset: 0x00AA82D4
		Private _txtPassword As TextBox
		Friend Overridable Property txtPassword As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPassword
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPassword_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtPassword
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtPassword = value
				textBox = Me._txtPassword
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072E7 RID: 29415
		' (get) Token: 0x06012848 RID: 75848 RVA: 0x0007F002 File Offset: 0x0007D202
		' (set) Token: 0x06012849 RID: 75849 RVA: 0x0007F00C File Offset: 0x0007D20C
		Friend Overridable Property Label4 As Label

		' Token: 0x170072E8 RID: 29416
		' (get) Token: 0x0601284A RID: 75850 RVA: 0x0007F015 File Offset: 0x0007D215
		' (set) Token: 0x0601284B RID: 75851 RVA: 0x0007F01F File Offset: 0x0007D21F
		Friend Overridable Property Label2 As Label

		' Token: 0x170072E9 RID: 29417
		' (get) Token: 0x0601284C RID: 75852 RVA: 0x0007F028 File Offset: 0x0007D228
		' (set) Token: 0x0601284D RID: 75853 RVA: 0x00AAA134 File Offset: 0x00AA8334
		Private _cmbUserType As ComboBox
		Friend Overridable Property cmbUserType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbUserType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbUserType_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbUserType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbUserType = value
				comboBox = Me._cmbUserType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072EA RID: 29418
		' (get) Token: 0x0601284E RID: 75854 RVA: 0x0007F032 File Offset: 0x0007D232
		' (set) Token: 0x0601284F RID: 75855 RVA: 0x0007F03C File Offset: 0x0007D23C
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x170072EB RID: 29419
		' (get) Token: 0x06012850 RID: 75856 RVA: 0x0007F045 File Offset: 0x0007D245
		' (set) Token: 0x06012851 RID: 75857 RVA: 0x0007F04F File Offset: 0x0007D24F
		Friend Overridable Property lblUser As Label

		' Token: 0x170072EC RID: 29420
		' (get) Token: 0x06012852 RID: 75858 RVA: 0x0007F058 File Offset: 0x0007D258
		' (set) Token: 0x06012853 RID: 75859 RVA: 0x0007F062 File Offset: 0x0007D262
		Friend Overridable Property Label8 As Label

		' Token: 0x170072ED RID: 29421
		' (get) Token: 0x06012854 RID: 75860 RVA: 0x0007F06B File Offset: 0x0007D26B
		' (set) Token: 0x06012855 RID: 75861 RVA: 0x0007F075 File Offset: 0x0007D275
		Friend Overridable Property chkActive As CheckBox

		' Token: 0x170072EE RID: 29422
		' (get) Token: 0x06012856 RID: 75862 RVA: 0x0007F07E File Offset: 0x0007D27E
		' (set) Token: 0x06012857 RID: 75863 RVA: 0x00AAA194 File Offset: 0x00AA8394
		Private _btnCheckAvailability As Button
		Friend Overridable Property btnCheckAvailability As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCheckAvailability
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnCheckAvailability_Click
				Dim button As Button = Me._btnCheckAvailability
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnCheckAvailability = value
				button = Me._btnCheckAvailability
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072EF RID: 29423
		' (get) Token: 0x06012858 RID: 75864 RVA: 0x0007F088 File Offset: 0x0007D288
		' (set) Token: 0x06012859 RID: 75865 RVA: 0x0007F092 File Offset: 0x0007D292
		Friend Overridable Property txtEmail As TextBox

		' Token: 0x170072F0 RID: 29424
		' (get) Token: 0x0601285A RID: 75866 RVA: 0x0007F09B File Offset: 0x0007D29B
		' (set) Token: 0x0601285B RID: 75867 RVA: 0x0007F0A5 File Offset: 0x0007D2A5
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x170072F1 RID: 29425
		' (get) Token: 0x0601285C RID: 75868 RVA: 0x0007F0AE File Offset: 0x0007D2AE
		' (set) Token: 0x0601285D RID: 75869 RVA: 0x00AAA1D8 File Offset: 0x00AA83D8
		Private _Button9 As Button
		Friend Overridable Property Button9 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button9_Click
				Dim button As Button = Me._Button9
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button9 = value
				button = Me._Button9
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072F2 RID: 29426
		' (get) Token: 0x0601285E RID: 75870 RVA: 0x0007F0B8 File Offset: 0x0007D2B8
		' (set) Token: 0x0601285F RID: 75871 RVA: 0x00AAA21C File Offset: 0x00AA841C
		Private _Button10 As Button
		Friend Overridable Property Button10 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button10_Click
				Dim button As Button = Me._Button10
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button10 = value
				button = Me._Button10
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072F3 RID: 29427
		' (get) Token: 0x06012860 RID: 75872 RVA: 0x0007F0C2 File Offset: 0x0007D2C2
		' (set) Token: 0x06012861 RID: 75873 RVA: 0x0007F0CC File Offset: 0x0007D2CC
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170072F4 RID: 29428
		' (get) Token: 0x06012862 RID: 75874 RVA: 0x0007F0D5 File Offset: 0x0007D2D5
		' (set) Token: 0x06012863 RID: 75875 RVA: 0x0007F0DF File Offset: 0x0007D2DF
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x170072F5 RID: 29429
		' (get) Token: 0x06012864 RID: 75876 RVA: 0x0007F0E8 File Offset: 0x0007D2E8
		' (set) Token: 0x06012865 RID: 75877 RVA: 0x0007F0F2 File Offset: 0x0007D2F2
		Public Overridable Property PictureBox1 As PictureBox

		' Token: 0x170072F6 RID: 29430
		' (get) Token: 0x06012866 RID: 75878 RVA: 0x0007F0FB File Offset: 0x0007D2FB
		' (set) Token: 0x06012867 RID: 75879 RVA: 0x00AAA260 File Offset: 0x00AA8460
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

		' Token: 0x170072F7 RID: 29431
		' (get) Token: 0x06012868 RID: 75880 RVA: 0x0007F105 File Offset: 0x0007D305
		' (set) Token: 0x06012869 RID: 75881 RVA: 0x00AAA2A4 File Offset: 0x00AA84A4
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

		' Token: 0x170072F8 RID: 29432
		' (get) Token: 0x0601286A RID: 75882 RVA: 0x0007F10F File Offset: 0x0007D30F
		' (set) Token: 0x0601286B RID: 75883 RVA: 0x00AAA2E8 File Offset: 0x00AA84E8
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

		' Token: 0x170072F9 RID: 29433
		' (get) Token: 0x0601286C RID: 75884 RVA: 0x0007F119 File Offset: 0x0007D319
		' (set) Token: 0x0601286D RID: 75885 RVA: 0x0007F123 File Offset: 0x0007D323
		Friend Overridable Property Label10 As Label

		' Token: 0x170072FA RID: 29434
		' (get) Token: 0x0601286E RID: 75886 RVA: 0x0007F12C File Offset: 0x0007D32C
		' (set) Token: 0x0601286F RID: 75887 RVA: 0x0007F136 File Offset: 0x0007D336
		Friend Overridable Property txtSign As TextBox

		' Token: 0x170072FB RID: 29435
		' (get) Token: 0x06012870 RID: 75888 RVA: 0x0007F13F File Offset: 0x0007D33F
		' (set) Token: 0x06012871 RID: 75889 RVA: 0x0007F149 File Offset: 0x0007D349
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x170072FC RID: 29436
		' (get) Token: 0x06012872 RID: 75890 RVA: 0x0007F152 File Offset: 0x0007D352
		' (set) Token: 0x06012873 RID: 75891 RVA: 0x0007F15C File Offset: 0x0007D35C
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170072FD RID: 29437
		' (get) Token: 0x06012874 RID: 75892 RVA: 0x0007F165 File Offset: 0x0007D365
		' (set) Token: 0x06012875 RID: 75893 RVA: 0x0007F16F File Offset: 0x0007D36F
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170072FE RID: 29438
		' (get) Token: 0x06012876 RID: 75894 RVA: 0x0007F178 File Offset: 0x0007D378
		' (set) Token: 0x06012877 RID: 75895 RVA: 0x0007F182 File Offset: 0x0007D382
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170072FF RID: 29439
		' (get) Token: 0x06012878 RID: 75896 RVA: 0x0007F18B File Offset: 0x0007D38B
		' (set) Token: 0x06012879 RID: 75897 RVA: 0x0007F195 File Offset: 0x0007D395
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17007300 RID: 29440
		' (get) Token: 0x0601287A RID: 75898 RVA: 0x0007F19E File Offset: 0x0007D39E
		' (set) Token: 0x0601287B RID: 75899 RVA: 0x0007F1A8 File Offset: 0x0007D3A8
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17007301 RID: 29441
		' (get) Token: 0x0601287C RID: 75900 RVA: 0x0007F1B1 File Offset: 0x0007D3B1
		' (set) Token: 0x0601287D RID: 75901 RVA: 0x0007F1BB File Offset: 0x0007D3BB
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17007302 RID: 29442
		' (get) Token: 0x0601287E RID: 75902 RVA: 0x0007F1C4 File Offset: 0x0007D3C4
		' (set) Token: 0x0601287F RID: 75903 RVA: 0x0007F1CE File Offset: 0x0007D3CE
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17007303 RID: 29443
		' (get) Token: 0x06012880 RID: 75904 RVA: 0x0007F1D7 File Offset: 0x0007D3D7
		' (set) Token: 0x06012881 RID: 75905 RVA: 0x0007F1E1 File Offset: 0x0007D3E1
		Friend Overridable Property Column8 As DataGridViewImageColumn

		' Token: 0x17007304 RID: 29444
		' (get) Token: 0x06012882 RID: 75906 RVA: 0x0007F1EA File Offset: 0x0007D3EA
		' (set) Token: 0x06012883 RID: 75907 RVA: 0x0007F1F4 File Offset: 0x0007D3F4
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17007305 RID: 29445
		' (get) Token: 0x06012884 RID: 75908 RVA: 0x0007F1FD File Offset: 0x0007D3FD
		' (set) Token: 0x06012885 RID: 75909 RVA: 0x00AAA32C File Offset: 0x00AA852C
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

		' Token: 0x17007306 RID: 29446
		' (get) Token: 0x06012886 RID: 75910 RVA: 0x0007F207 File Offset: 0x0007D407
		' (set) Token: 0x06012887 RID: 75911 RVA: 0x00AAA370 File Offset: 0x00AA8570
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

		' Token: 0x17007307 RID: 29447
		' (get) Token: 0x06012888 RID: 75912 RVA: 0x0007F211 File Offset: 0x0007D411
		' (set) Token: 0x06012889 RID: 75913 RVA: 0x0007F21B File Offset: 0x0007D41B
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17007308 RID: 29448
		' (get) Token: 0x0601288A RID: 75914 RVA: 0x0007F224 File Offset: 0x0007D424
		' (set) Token: 0x0601288B RID: 75915 RVA: 0x00AAA3B4 File Offset: 0x00AA85B4
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

		' Token: 0x17007309 RID: 29449
		' (get) Token: 0x0601288C RID: 75916 RVA: 0x0007F22E File Offset: 0x0007D42E
		' (set) Token: 0x0601288D RID: 75917 RVA: 0x00AAA3F8 File Offset: 0x00AA85F8
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
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

		' Token: 0x1700730A RID: 29450
		' (get) Token: 0x0601288E RID: 75918 RVA: 0x0007F238 File Offset: 0x0007D438
		' (set) Token: 0x0601288F RID: 75919 RVA: 0x00AAA43C File Offset: 0x00AA863C
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

		' Token: 0x1700730B RID: 29451
		' (get) Token: 0x06012890 RID: 75920 RVA: 0x0007F242 File Offset: 0x0007D442
		' (set) Token: 0x06012891 RID: 75921 RVA: 0x00AAA480 File Offset: 0x00AA8680
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

		' Token: 0x06012892 RID: 75922 RVA: 0x00AAA4C4 File Offset: 0x00AA86C4
		Public Sub Reset()
			Me.PictureBox1.Image = Resources.photo
			Me.txtContactNo.Text = ""
			Me.txtEmailID.Text = ""
			Me.txtName.Text = ""
			Me.txtPassword.Text = ""
			Me.txtUserID.Text = ""
			Me.txtSign.Text = ""
			Me.cmbUserType.SelectedIndex = -1
			Me.chkActive.Checked = True
			Me.txtUserID.Focus()
			Me.dgw.ClearSelection()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.txtUserID.[ReadOnly] = False
			Me.txtUserID.Enabled = True
		End Sub

		' Token: 0x06012893 RID: 75923 RVA: 0x00AAA5BC File Offset: 0x00AA87BC
		Private Sub DeleteRecord()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, Me.txtUserID.Text, False) = 0
				If flag Then
					MessageBox.Show("Currently logged in user can not be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag2 As Boolean = (Operators.CompareString(Me.txtUserID.Text, "admin", False) = 0) Or (Operators.CompareString(Me.txtUserID.Text, "Admin", False) = 0)
					If flag2 Then
						MessageBox.Show("Admin account can not be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "delete from Registration where userid=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtUserID.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
						Dim flag3 As Boolean = num > 0
						If flag3 Then
							Dim text2 As String = "deleted the user '" + Me.txtUserID.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text2)
							MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Getdata()
							Me.Reset()
						Else
							MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Reset()
						End If
						Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag4 Then
							ModCommonClasses.con.Close()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012894 RID: 75924 RVA: 0x00AAA79C File Offset: 0x00AA899C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(userid), RTRIM(UserType), RTRIM(Password), RTRIM(Name), RTRIM(EmailID), RTRIM(ContactNo),RTRIM(Active),JoiningDate, Photo, Sign from Registration order by JoiningDate", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012895 RID: 75925 RVA: 0x00AAA914 File Offset: 0x00AA8B14
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

		' Token: 0x06012896 RID: 75926 RVA: 0x0007F24C File Offset: 0x0007D44C
		Private Sub frmRegistration_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x06012897 RID: 75927 RVA: 0x00AAA9FC File Offset: 0x00AA8BFC
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

		' Token: 0x06012898 RID: 75928 RVA: 0x00AAAB74 File Offset: 0x00AA8D74
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

		' Token: 0x06012899 RID: 75929 RVA: 0x00AAAC30 File Offset: 0x00AA8E30
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

		' Token: 0x0601289A RID: 75930 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601289B RID: 75931 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0601289C RID: 75932 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601289D RID: 75933 RVA: 0x00AAACFC File Offset: 0x00AA8EFC
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Me.txtUserID.[ReadOnly] = True
					Me.txtUserID.Enabled = False
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtUserID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.TextBox1.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbUserType.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtPassword.Text = ModFunc.Decrypt(dataGridViewRow.Cells(2).Value.ToString())
					Me.txtName.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtContactNo.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtEmailID.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtEmail.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtSign.Text = dataGridViewRow.Cells(9).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(6).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.chkActive.Checked = True
					Else
						Me.chkActive.Checked = False
					End If
					Dim array As Byte() = CType(dataGridViewRow.Cells(8).Value, Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.PictureBox1.Image = Image.FromStream(memoryStream)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601289E RID: 75934 RVA: 0x00AAAF5C File Offset: 0x00AA915C
		Private Sub btnCheckAvailability_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtUserID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtUserID.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select userid from registration where userid=@d1"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtUserID.Text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("User ID not available", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						MessageBox.Show("User ID available", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0601289F RID: 75935 RVA: 0x00AAB0BC File Offset: 0x00AA92BC
		Private Sub dgw_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
			Dim flag As Boolean = e.ColumnIndex = 2 AndAlso e.Value IsNot Nothing
			If flag Then
				Me.dgw.Rows(e.RowIndex).Tag = RuntimeHelpers.GetObjectValue(e.Value)
				e.Value = New String("●"c, e.Value.ToString().Length)
			End If
		End Sub

		' Token: 0x060128A0 RID: 75936 RVA: 0x00AAB130 File Offset: 0x00AA9330
		Private Sub dgw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Dim flag As Boolean = Me.dgw.CurrentCell.ColumnIndex = 2
			If flag Then
				Dim textBox As TextBox = TryCast(e.Control, TextBox)
				Dim flag2 As Boolean = textBox IsNot Nothing
				If flag2 Then
					textBox.UseSystemPasswordChar = True
				End If
			Else
				Dim textBox2 As TextBox = TryCast(e.Control, TextBox)
				Dim flag3 As Boolean = textBox2 IsNot Nothing
				If flag3 Then
					textBox2.UseSystemPasswordChar = False
				End If
			End If
		End Sub

		' Token: 0x060128A1 RID: 75937 RVA: 0x00AAB198 File Offset: 0x00AA9398
		Private Sub txtEmailID_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim text As String = "@"
			Dim flag As Boolean = e.KeyChar <> vbBack
			If flag Then
				Dim flag2 As Boolean = (Strings.Asc(e.KeyChar) < 97) Or (Strings.Asc(e.KeyChar) > 122)
				If flag2 Then
					Dim flag3 As Boolean = (Strings.Asc(e.KeyChar) <> 46) And (Strings.Asc(e.KeyChar) <> 95)
					If flag3 Then
						Dim flag4 As Boolean = (Strings.Asc(e.KeyChar) < 48) Or (Strings.Asc(e.KeyChar) > 57)
						If flag4 Then
							Dim flag5 As Boolean = text.IndexOf(e.KeyChar) = -1
							If flag5 Then
								e.Handled = True
							Else
								Dim flag6 As Boolean = Me.txtEmailID.Text.Contains("@") And (Operators.CompareString(Conversions.ToString(e.KeyChar), "@", False) = 0)
								If flag6 Then
									e.Handled = True
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060128A2 RID: 75938 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtEmailID_Validating(sender As Object, e As CancelEventArgs)
		End Sub

		' Token: 0x060128A3 RID: 75939 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x060128A4 RID: 75940 RVA: 0x00AAB2A0 File Offset: 0x00AA94A0
		Private Sub Button9_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Conversions.ToString(Me.txtPassword.PasswordChar), "♥", False) = 0
			If flag Then
				Me.txtPassword.PasswordChar = vbNullChar
				Me.Button9.Visible = False
				Me.Button10.Visible = True
			End If
		End Sub

		' Token: 0x060128A5 RID: 75941 RVA: 0x0007F25D File Offset: 0x0007D45D
		Private Sub Button10_Click(sender As Object, e As EventArgs)
			Me.txtPassword.PasswordChar = "♥"c
			Me.Button9.Visible = True
			Me.Button10.Visible = False
		End Sub

		' Token: 0x060128A6 RID: 75942 RVA: 0x00AAB2FC File Offset: 0x00AA94FC
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.PictureBox1.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060128A7 RID: 75943 RVA: 0x0007F28B File Offset: 0x0007D48B
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.PictureBox1.Image = Resources.photo
		End Sub

		' Token: 0x060128A8 RID: 75944 RVA: 0x00AAB39C File Offset: 0x00AA959C
		Private Sub BStartCapture_Click(sender As Object, e As EventArgs)
			Dim frmCamera As frmCamera = New frmCamera()
			frmCamera.ShowDialog()
			Dim flag As Boolean = ModCommonClasses.TempFileNames2.Length > 0
			If flag Then
				Me.PictureBox1.Image = Image.FromFile(ModCommonClasses.TempFileNames2)
				Me.Photoname = ModCommonClasses.TempFileNames2
				Me.IsImageChanged = True
			End If
		End Sub

		' Token: 0x060128A9 RID: 75945 RVA: 0x00AAB3F4 File Offset: 0x00AA95F4
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.txtSign.Text = Me.OpenFileDialog1.FileName
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060128AA RID: 75946 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtUserID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060128AB RID: 75947 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbUserType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060128AC RID: 75948 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060128AD RID: 75949 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060128AE RID: 75950 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmailID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060128AF RID: 75951 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060128B0 RID: 75952 RVA: 0x0007F29F File Offset: 0x0007D49F
		Private Sub Button2_Click_1(sender As Object, e As EventArgs)
			Me.txtSign.Clear()
		End Sub

		' Token: 0x060128B1 RID: 75953 RVA: 0x00AAB480 File Offset: 0x00AA9680
		Private Sub frmRegistration_Closing(sender As Object, e As CancelEventArgs)
			Dim frmMainMenu As frmMainMenu = CType(Application.OpenForms("frmMainMenu"), frmMainMenu)
			frmMainMenu.lblUser.Text = Me.lblUser.Text
		End Sub

		' Token: 0x060128B2 RID: 75954 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmRegistration_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060128B3 RID: 75955 RVA: 0x00AAB4BC File Offset: 0x00AA96BC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtUserID.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtUserID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtUserID, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtPassword.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtPassword, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtPassword, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtName.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtName, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtEmailID.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtEmailID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtEmailID, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag6 As Boolean = String.IsNullOrEmpty(Me.cmbUserType.Text.Trim())
			If flag6 Then
				Me.ErrorProvider1.SetError(Me.cmbUserType, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbUserType, String.Empty)
			End If
		End Sub

		' Token: 0x060128B4 RID: 75956 RVA: 0x0007F2AE File Offset: 0x0007D4AE
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060128B5 RID: 75957 RVA: 0x00AAB698 File Offset: 0x00AA9898
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtUserID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtUserID.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbUserType.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please select user type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbUserType.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.txtPassword.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtPassword.Focus()
					Else
						Dim flag4 As Boolean = Me.txtPassword.TextLength < 5
						If flag4 Then
							MessageBox.Show("The Password Should be of Atleast 5 Characters", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.txtPassword.Focus()
							Me.txtPassword.Text = ""
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtName.Text, "", False) = 0
							If flag5 Then
								MessageBox.Show("Please enter name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtName.Focus()
							Else
								Dim flag6 As Boolean = Operators.CompareString(Me.txtEmailID.Text, "", False) = 0
								If flag6 Then
									MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtEmailID.Focus()
								Else
									Dim flag7 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
									If flag7 Then
										MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtContactNo.Focus()
									Else
										Try
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text As String = "select userid from registration where userid=@d1"
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtUserID.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
											If flag8 Then
												MessageBox.Show("user id Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.txtUserID.Text = ""
												Me.txtUserID.Focus()
												Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag9 Then
													ModCommonClasses.rdr.Close()
												End If
											Else
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text2 As String = "select EmailID from registration where EmailID=@d1"
												ModCommonClasses.cmd = New SqlCommand(text2)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtEmailID.Text)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag10 As Boolean = ModCommonClasses.rdr.Read()
												If flag10 Then
													MessageBox.Show("Email id Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Dim flag11 As Boolean = ModCommonClasses.rdr IsNot Nothing
													If flag11 Then
														ModCommonClasses.rdr.Close()
													End If
												Else
													ModCommonClasses.con.Close()
													Dim checked As Boolean = Me.chkActive.Checked
													If checked Then
														Me.st1 = "Yes"
													Else
														Me.st1 = "No"
													End If
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text3 As String = "insert into Registration(userid, UserType, Password, Name, ContactNo, EmailID,JoiningDate,Active,Photo,Sign) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)"
													ModCommonClasses.cmd = New SqlCommand(text3)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtUserID.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbUserType.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", ModFunc.Encrypt(Me.txtPassword.Text.Trim()))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtName.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtContactNo.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtEmailID.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d7", DateAndTime.Now)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.st1)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.txtSign.Text)
													Dim memoryStream As MemoryStream = New MemoryStream()
													Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
													bitmap.Save(memoryStream, ImageFormat.Jpeg)
													Dim buffer As Byte() = memoryStream.GetBuffer()
													Dim sqlParameter As SqlParameter = New SqlParameter("@d9", SqlDbType.VarBinary)
													sqlParameter.Value = buffer
													ModCommonClasses.cmd.Parameters.Add(sqlParameter)
													ModCommonClasses.cmd.ExecuteReader()
													ModCommonClasses.con.Close()
													Dim text4 As String = "added the new user '" + Me.txtUserID.Text + "'"
													ModFunc.LogFunc(Me.lblUser.Text, text4)
													MessageBox.Show("Successfully Registered", "User", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Me.btnSave.Enabled = False
													Me.Getdata()
												End If
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
		End Sub

		' Token: 0x060128B6 RID: 75958 RVA: 0x00AABCAC File Offset: 0x00AA9EAC
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtUserID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtUserID.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbUserType.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please select user type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbUserType.Focus()
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.txtPassword.Text, "", False) = 0
						If flag3 Then
							MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtPassword.Focus()
						Else
							Dim flag4 As Boolean = Me.txtPassword.TextLength < 5
							If flag4 Then
								MessageBox.Show("The Password Should be of Atleast 5 Characters", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.txtPassword.Focus()
								Me.txtPassword.Text = ""
							Else
								Dim flag5 As Boolean = Operators.CompareString(Me.txtName.Text, "", False) = 0
								If flag5 Then
									MessageBox.Show("Please enter name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtName.Focus()
								Else
									Dim flag6 As Boolean = Operators.CompareString(Me.txtEmailID.Text, "", False) = 0
									If flag6 Then
										MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtEmailID.Focus()
									Else
										Dim flag7 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
										If flag7 Then
											MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtContactNo.Focus()
										Else
											Dim checked As Boolean = Me.chkActive.Checked
											If checked Then
												Me.st1 = "Yes"
											Else
												Me.st1 = "No"
											End If
											Dim flag8 As Boolean = Operators.CompareString(Me.txtEmail.Text, Me.txtEmailID.Text, False) <> 0
											If flag8 Then
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text As String = "select EmailID from registration where EmailID=@d1"
												ModCommonClasses.cmd = New SqlCommand(text)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtEmailID.Text)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
												If flag9 Then
													MessageBox.Show("Email id Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
													If flag10 Then
														ModCommonClasses.rdr.Close()
													End If
													Return
												End If
												ModCommonClasses.con.Close()
											End If
											Dim checked2 As Boolean = Me.chkActive.Checked
											If checked2 Then
												Me.st1 = "Yes"
											Else
												Me.st1 = "No"
											End If
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text2 As String = "update registration set userid=@d1, usertype=@d2,password=@d3,name=@d4,contactno=@d5,emailid=@d6,Active=@d8,Photo=@d9,Sign=@d10 where userid=@d7"
											ModCommonClasses.cmd = New SqlCommand(text2)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtUserID.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbUserType.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", ModFunc.Encrypt(Me.txtPassword.Text.Trim()))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtName.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtContactNo.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtEmailID.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.TextBox1.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.st1)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.txtSign.Text)
											Dim memoryStream As MemoryStream = New MemoryStream()
											Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
											bitmap.Save(memoryStream, ImageFormat.Jpeg)
											Dim buffer As Byte() = memoryStream.GetBuffer()
											Dim sqlParameter As SqlParameter = New SqlParameter("@d9", SqlDbType.VarBinary)
											sqlParameter.Value = buffer
											ModCommonClasses.cmd.Parameters.Add(sqlParameter)
											ModCommonClasses.cmd.ExecuteReader()
											ModCommonClasses.con.Close()
											Dim text3 As String = "updated the user '" + Me.txtUserID.Text + "' details"
											ModFunc.LogFunc(Me.lblUser.Text, text3)
											MessageBox.Show("Successfully Updated", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.btnUpdate.Enabled = False
											Me.Getdata()
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060128B7 RID: 75959 RVA: 0x00AAC240 File Offset: 0x00AAA440
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04006F9D RID: 28573
		Private st1 As String

		' Token: 0x04006F9E RID: 28574
		Private Photoname As String

		' Token: 0x04006F9F RID: 28575
		Private IsImageChanged As Boolean
	End Class
End Namespace
