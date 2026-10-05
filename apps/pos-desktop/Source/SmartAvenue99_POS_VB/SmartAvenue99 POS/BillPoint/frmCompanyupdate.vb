Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports CrystalDecisions.CrystalReports.Engine
Imports DevNet.GS
Imports GelButtons
Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Sdk.Sfc
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MyDBLibrary
Imports MySql.Data.MySqlClient

Namespace BillPoint
	' Token: 0x020004B1 RID: 1201
	<DesignerGenerated()>
	Public Partial Class frmCompanyupdate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F109 RID: 61705 RVA: 0x0090C288 File Offset: 0x0090A488
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCompanyupdate_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCompanyupdate_KeyDown
			Me.translations = New Dictionary(Of String, String)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005C5D RID: 23645
		' (get) Token: 0x0600F10C RID: 61708 RVA: 0x000697E0 File Offset: 0x000679E0
		' (set) Token: 0x0600F10D RID: 61709 RVA: 0x000697EA File Offset: 0x000679EA
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005C5E RID: 23646
		' (get) Token: 0x0600F10E RID: 61710 RVA: 0x000697F3 File Offset: 0x000679F3
		' (set) Token: 0x0600F10F RID: 61711 RVA: 0x000697FD File Offset: 0x000679FD
		Friend Overridable Property txtEmail As TextBox

		' Token: 0x17005C5F RID: 23647
		' (get) Token: 0x0600F110 RID: 61712 RVA: 0x00069806 File Offset: 0x00067A06
		' (set) Token: 0x0600F111 RID: 61713 RVA: 0x00069810 File Offset: 0x00067A10
		Friend Overridable Property lblSet As Label

		' Token: 0x17005C60 RID: 23648
		' (get) Token: 0x0600F112 RID: 61714 RVA: 0x00069819 File Offset: 0x00067A19
		' (set) Token: 0x0600F113 RID: 61715 RVA: 0x00069823 File Offset: 0x00067A23
		Friend Overridable Property lblUser As Label

		' Token: 0x17005C61 RID: 23649
		' (get) Token: 0x0600F114 RID: 61716 RVA: 0x0006982C File Offset: 0x00067A2C
		' (set) Token: 0x0600F115 RID: 61717 RVA: 0x00069836 File Offset: 0x00067A36
		Friend Overridable Property txtID As TextBox

		' Token: 0x17005C62 RID: 23650
		' (get) Token: 0x0600F116 RID: 61718 RVA: 0x0006983F File Offset: 0x00067A3F
		' (set) Token: 0x0600F117 RID: 61719 RVA: 0x00069849 File Offset: 0x00067A49
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005C63 RID: 23651
		' (get) Token: 0x0600F118 RID: 61720 RVA: 0x00069852 File Offset: 0x00067A52
		' (set) Token: 0x0600F119 RID: 61721 RVA: 0x0090F838 File Offset: 0x0090DA38
		Private _cmbState As ComboBox
		Friend Overridable Property cmbState As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbState
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbState_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbState = value
				comboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C64 RID: 23652
		' (get) Token: 0x0600F11A RID: 61722 RVA: 0x0006985C File Offset: 0x00067A5C
		' (set) Token: 0x0600F11B RID: 61723 RVA: 0x0090F898 File Offset: 0x0090DA98
		Private _btnBrowse As Button
		Public Overridable Property btnBrowse As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBrowse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBrowse_Click
				Dim button As Button = Me._btnBrowse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBrowse = value
				button = Me._btnBrowse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C65 RID: 23653
		' (get) Token: 0x0600F11C RID: 61724 RVA: 0x00069866 File Offset: 0x00067A66
		' (set) Token: 0x0600F11D RID: 61725 RVA: 0x00069870 File Offset: 0x00067A70
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17005C66 RID: 23654
		' (get) Token: 0x0600F11E RID: 61726 RVA: 0x00069879 File Offset: 0x00067A79
		' (set) Token: 0x0600F11F RID: 61727 RVA: 0x0090F8DC File Offset: 0x0090DADC
		Private _txtAddress As TextBox
		Friend Overridable Property txtAddress As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAddress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAddress_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAddress
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAddress = value
				textBox = Me._txtAddress
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C67 RID: 23655
		' (get) Token: 0x0600F120 RID: 61728 RVA: 0x00069883 File Offset: 0x00067A83
		' (set) Token: 0x0600F121 RID: 61729 RVA: 0x0090F93C File Offset: 0x0090DB3C
		Private _txtCIN As TextBox
		Friend Overridable Property txtCIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCIN_KeyDown
				Dim textBox As TextBox = Me._txtCIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCIN = value
				textBox = Me._txtCIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C68 RID: 23656
		' (get) Token: 0x0600F122 RID: 61730 RVA: 0x0006988D File Offset: 0x00067A8D
		' (set) Token: 0x0600F123 RID: 61731 RVA: 0x00069897 File Offset: 0x00067A97
		Friend Overridable Property Label8 As Label

		' Token: 0x17005C69 RID: 23657
		' (get) Token: 0x0600F124 RID: 61732 RVA: 0x000698A0 File Offset: 0x00067AA0
		' (set) Token: 0x0600F125 RID: 61733 RVA: 0x0090F980 File Offset: 0x0090DB80
		Private _txtGSTIN As TextBox
		Friend Overridable Property txtGSTIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtGSTIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtGSTIN_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtGSTIN_TextChanged
				Dim textBox As TextBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtGSTIN = value
				textBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C6A RID: 23658
		' (get) Token: 0x0600F126 RID: 61734 RVA: 0x000698AA File Offset: 0x00067AAA
		' (set) Token: 0x0600F127 RID: 61735 RVA: 0x000698B4 File Offset: 0x00067AB4
		Friend Overridable Property Label7 As Label

		' Token: 0x17005C6B RID: 23659
		' (get) Token: 0x0600F128 RID: 61736 RVA: 0x000698BD File Offset: 0x00067ABD
		' (set) Token: 0x0600F129 RID: 61737 RVA: 0x000698C7 File Offset: 0x00067AC7
		Friend Overridable Property Label6 As Label

		' Token: 0x17005C6C RID: 23660
		' (get) Token: 0x0600F12A RID: 61738 RVA: 0x000698D0 File Offset: 0x00067AD0
		' (set) Token: 0x0600F12B RID: 61739 RVA: 0x000698DA File Offset: 0x00067ADA
		Friend Overridable Property Label5 As Label

		' Token: 0x17005C6D RID: 23661
		' (get) Token: 0x0600F12C RID: 61740 RVA: 0x000698E3 File Offset: 0x00067AE3
		' (set) Token: 0x0600F12D RID: 61741 RVA: 0x0090F9E0 File Offset: 0x0090DBE0
		Private _txtEmailID As TextBox
		Friend Overridable Property txtEmailID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmailID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtEmailID_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtEmailID = value
				textBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C6E RID: 23662
		' (get) Token: 0x0600F12E RID: 61742 RVA: 0x000698ED File Offset: 0x00067AED
		' (set) Token: 0x0600F12F RID: 61743 RVA: 0x0090FA40 File Offset: 0x0090DC40
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

		' Token: 0x17005C6F RID: 23663
		' (get) Token: 0x0600F130 RID: 61744 RVA: 0x000698F7 File Offset: 0x00067AF7
		' (set) Token: 0x0600F131 RID: 61745 RVA: 0x00069901 File Offset: 0x00067B01
		Friend Overridable Property Label4 As Label

		' Token: 0x17005C70 RID: 23664
		' (get) Token: 0x0600F132 RID: 61746 RVA: 0x0006990A File Offset: 0x00067B0A
		' (set) Token: 0x0600F133 RID: 61747 RVA: 0x00069914 File Offset: 0x00067B14
		Friend Overridable Property Label2 As Label

		' Token: 0x17005C71 RID: 23665
		' (get) Token: 0x0600F134 RID: 61748 RVA: 0x0006991D File Offset: 0x00067B1D
		' (set) Token: 0x0600F135 RID: 61749 RVA: 0x00069927 File Offset: 0x00067B27
		Friend Overridable Property Label3 As Label

		' Token: 0x17005C72 RID: 23666
		' (get) Token: 0x0600F136 RID: 61750 RVA: 0x00069930 File Offset: 0x00067B30
		' (set) Token: 0x0600F137 RID: 61751 RVA: 0x0090FAA0 File Offset: 0x0090DCA0
		Private _txtCompanyName As TextBox
		Friend Overridable Property txtCompanyName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCompanyName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCompanyName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtCompanyName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtCompanyName = value
				textBox = Me._txtCompanyName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C73 RID: 23667
		' (get) Token: 0x0600F138 RID: 61752 RVA: 0x0006993A File Offset: 0x00067B3A
		' (set) Token: 0x0600F139 RID: 61753 RVA: 0x0090FB00 File Offset: 0x0090DD00
		Private _Panel2 As Panel
		Friend Overridable Property Panel2 As Panel
			<CompilerGenerated()>
			Get
				Return Me._Panel2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Dim paintEventHandler As PaintEventHandler = AddressOf Me.Panel2_Paint
				Dim panel As Panel = Me._Panel2
				If panel IsNot Nothing Then
					RemoveHandler panel.Paint, paintEventHandler
				End If
				Me._Panel2 = value
				panel = Me._Panel2
				If panel IsNot Nothing Then
					AddHandler panel.Paint, paintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C74 RID: 23668
		' (get) Token: 0x0600F13A RID: 61754 RVA: 0x00069944 File Offset: 0x00067B44
		' (set) Token: 0x0600F13B RID: 61755 RVA: 0x0006994E File Offset: 0x00067B4E
		Friend Overridable Property txtCompanyID As TextBox

		' Token: 0x17005C75 RID: 23669
		' (get) Token: 0x0600F13C RID: 61756 RVA: 0x00069957 File Offset: 0x00067B57
		' (set) Token: 0x0600F13D RID: 61757 RVA: 0x00069961 File Offset: 0x00067B61
		Friend Overridable Property Label1 As Label

		' Token: 0x17005C76 RID: 23670
		' (get) Token: 0x0600F13E RID: 61758 RVA: 0x0006996A File Offset: 0x00067B6A
		' (set) Token: 0x0600F13F RID: 61759 RVA: 0x00069974 File Offset: 0x00067B74
		Friend Overridable Property txtCName As TextBox

		' Token: 0x17005C77 RID: 23671
		' (get) Token: 0x0600F140 RID: 61760 RVA: 0x0006997D File Offset: 0x00067B7D
		' (set) Token: 0x0600F141 RID: 61761 RVA: 0x00069987 File Offset: 0x00067B87
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17005C78 RID: 23672
		' (get) Token: 0x0600F142 RID: 61762 RVA: 0x00069990 File Offset: 0x00067B90
		' (set) Token: 0x0600F143 RID: 61763 RVA: 0x0006999A File Offset: 0x00067B9A
		Friend Overridable Property txtDB As TextBox

		' Token: 0x17005C79 RID: 23673
		' (get) Token: 0x0600F144 RID: 61764 RVA: 0x000699A3 File Offset: 0x00067BA3
		' (set) Token: 0x0600F145 RID: 61765 RVA: 0x0090FB44 File Offset: 0x0090DD44
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCity_KeyDown
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C7A RID: 23674
		' (get) Token: 0x0600F146 RID: 61766 RVA: 0x000699AD File Offset: 0x00067BAD
		' (set) Token: 0x0600F147 RID: 61767 RVA: 0x0090FB88 File Offset: 0x0090DD88
		Private _txtWeb As TextBox
		Friend Overridable Property txtWeb As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWeb
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtWeb_KeyDown
				Dim textBox As TextBox = Me._txtWeb
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtWeb = value
				textBox = Me._txtWeb
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C7B RID: 23675
		' (get) Token: 0x0600F148 RID: 61768 RVA: 0x000699B7 File Offset: 0x00067BB7
		' (set) Token: 0x0600F149 RID: 61769 RVA: 0x000699C1 File Offset: 0x00067BC1
		Friend Overridable Property Label13 As Label

		' Token: 0x17005C7C RID: 23676
		' (get) Token: 0x0600F14A RID: 61770 RVA: 0x000699CA File Offset: 0x00067BCA
		' (set) Token: 0x0600F14B RID: 61771 RVA: 0x000699D4 File Offset: 0x00067BD4
		Friend Overridable Property Label14 As Label

		' Token: 0x17005C7D RID: 23677
		' (get) Token: 0x0600F14C RID: 61772 RVA: 0x000699DD File Offset: 0x00067BDD
		' (set) Token: 0x0600F14D RID: 61773 RVA: 0x000699E7 File Offset: 0x00067BE7
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005C7E RID: 23678
		' (get) Token: 0x0600F14E RID: 61774 RVA: 0x000699F0 File Offset: 0x00067BF0
		' (set) Token: 0x0600F14F RID: 61775 RVA: 0x0090FBCC File Offset: 0x0090DDCC
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

		' Token: 0x17005C7F RID: 23679
		' (get) Token: 0x0600F150 RID: 61776 RVA: 0x000699FA File Offset: 0x00067BFA
		' (set) Token: 0x0600F151 RID: 61777 RVA: 0x0090FC10 File Offset: 0x0090DE10
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

		' Token: 0x17005C80 RID: 23680
		' (get) Token: 0x0600F152 RID: 61778 RVA: 0x00069A04 File Offset: 0x00067C04
		' (set) Token: 0x0600F153 RID: 61779 RVA: 0x0090FC54 File Offset: 0x0090DE54
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

		' Token: 0x17005C81 RID: 23681
		' (get) Token: 0x0600F154 RID: 61780 RVA: 0x00069A0E File Offset: 0x00067C0E
		' (set) Token: 0x0600F155 RID: 61781 RVA: 0x0090FC98 File Offset: 0x0090DE98
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

		' Token: 0x17005C82 RID: 23682
		' (get) Token: 0x0600F156 RID: 61782 RVA: 0x00069A18 File Offset: 0x00067C18
		' (set) Token: 0x0600F157 RID: 61783 RVA: 0x00069A22 File Offset: 0x00067C22
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17005C83 RID: 23683
		' (get) Token: 0x0600F158 RID: 61784 RVA: 0x00069A2B File Offset: 0x00067C2B
		' (set) Token: 0x0600F159 RID: 61785 RVA: 0x00069A35 File Offset: 0x00067C35
		Friend Overridable Property Label19 As Label

		' Token: 0x17005C84 RID: 23684
		' (get) Token: 0x0600F15A RID: 61786 RVA: 0x00069A3E File Offset: 0x00067C3E
		' (set) Token: 0x0600F15B RID: 61787 RVA: 0x00069A48 File Offset: 0x00067C48
		Friend Overridable Property Label18 As Label

		' Token: 0x17005C85 RID: 23685
		' (get) Token: 0x0600F15C RID: 61788 RVA: 0x00069A51 File Offset: 0x00067C51
		' (set) Token: 0x0600F15D RID: 61789 RVA: 0x00069A5B File Offset: 0x00067C5B
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17005C86 RID: 23686
		' (get) Token: 0x0600F15E RID: 61790 RVA: 0x00069A64 File Offset: 0x00067C64
		' (set) Token: 0x0600F15F RID: 61791 RVA: 0x0090FCDC File Offset: 0x0090DEDC
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

		' Token: 0x17005C87 RID: 23687
		' (get) Token: 0x0600F160 RID: 61792 RVA: 0x00069A6E File Offset: 0x00067C6E
		' (set) Token: 0x0600F161 RID: 61793 RVA: 0x00069A78 File Offset: 0x00067C78
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x17005C88 RID: 23688
		' (get) Token: 0x0600F162 RID: 61794 RVA: 0x00069A81 File Offset: 0x00067C81
		' (set) Token: 0x0600F163 RID: 61795 RVA: 0x00069A8B File Offset: 0x00067C8B
		Friend Overridable Property PictureBox3 As PictureBox

		' Token: 0x17005C89 RID: 23689
		' (get) Token: 0x0600F164 RID: 61796 RVA: 0x00069A94 File Offset: 0x00067C94
		' (set) Token: 0x0600F165 RID: 61797 RVA: 0x00069A9E File Offset: 0x00067C9E
		Friend Overridable Property PictureBox4 As PictureBox

		' Token: 0x17005C8A RID: 23690
		' (get) Token: 0x0600F166 RID: 61798 RVA: 0x00069AA7 File Offset: 0x00067CA7
		' (set) Token: 0x0600F167 RID: 61799 RVA: 0x00069AB1 File Offset: 0x00067CB1
		Friend Overridable Property Button23 As Button

		' Token: 0x17005C8B RID: 23691
		' (get) Token: 0x0600F168 RID: 61800 RVA: 0x00069ABA File Offset: 0x00067CBA
		' (set) Token: 0x0600F169 RID: 61801 RVA: 0x00069AC4 File Offset: 0x00067CC4
		Friend Overridable Property Label17 As Label

		' Token: 0x17005C8C RID: 23692
		' (get) Token: 0x0600F16A RID: 61802 RVA: 0x00069ACD File Offset: 0x00067CCD
		' (set) Token: 0x0600F16B RID: 61803 RVA: 0x0090FD20 File Offset: 0x0090DF20
		Private _txtCurrencySymb As TextBox
		Friend Overridable Property txtCurrencySymb As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCurrencySymb
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtCurrencySymb_KeyPress
				Dim textBox As TextBox = Me._txtCurrencySymb
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtCurrencySymb = value
				textBox = Me._txtCurrencySymb
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C8D RID: 23693
		' (get) Token: 0x0600F16C RID: 61804 RVA: 0x00069AD7 File Offset: 0x00067CD7
		' (set) Token: 0x0600F16D RID: 61805 RVA: 0x00069AE1 File Offset: 0x00067CE1
		Friend Overridable Property lbl_Result As Label

		' Token: 0x17005C8E RID: 23694
		' (get) Token: 0x0600F16E RID: 61806 RVA: 0x00069AEA File Offset: 0x00067CEA
		' (set) Token: 0x0600F16F RID: 61807 RVA: 0x00069AF4 File Offset: 0x00067CF4
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17005C8F RID: 23695
		' (get) Token: 0x0600F170 RID: 61808 RVA: 0x00069AFD File Offset: 0x00067CFD
		' (set) Token: 0x0600F171 RID: 61809 RVA: 0x00069B07 File Offset: 0x00067D07
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17005C90 RID: 23696
		' (get) Token: 0x0600F172 RID: 61810 RVA: 0x00069B10 File Offset: 0x00067D10
		' (set) Token: 0x0600F173 RID: 61811 RVA: 0x0090FD64 File Offset: 0x0090DF64
		Private _btnprint As GelButton
		Friend Overridable Property btnprint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnprint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnprint_Click
				Dim gelButton As GelButton = Me._btnprint
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnprint = value
				gelButton = Me._btnprint
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C91 RID: 23697
		' (get) Token: 0x0600F174 RID: 61812 RVA: 0x00069B1A File Offset: 0x00067D1A
		' (set) Token: 0x0600F175 RID: 61813 RVA: 0x0090FDA8 File Offset: 0x0090DFA8
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

		' Token: 0x17005C92 RID: 23698
		' (get) Token: 0x0600F176 RID: 61814 RVA: 0x00069B24 File Offset: 0x00067D24
		' (set) Token: 0x0600F177 RID: 61815 RVA: 0x0090FDEC File Offset: 0x0090DFEC
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

		' Token: 0x17005C93 RID: 23699
		' (get) Token: 0x0600F178 RID: 61816 RVA: 0x00069B2E File Offset: 0x00067D2E
		' (set) Token: 0x0600F179 RID: 61817 RVA: 0x00069B38 File Offset: 0x00067D38
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005C94 RID: 23700
		' (get) Token: 0x0600F17A RID: 61818 RVA: 0x00069B41 File Offset: 0x00067D41
		' (set) Token: 0x0600F17B RID: 61819 RVA: 0x00069B4B File Offset: 0x00067D4B
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17005C95 RID: 23701
		' (get) Token: 0x0600F17C RID: 61820 RVA: 0x00069B54 File Offset: 0x00067D54
		' (set) Token: 0x0600F17D RID: 61821 RVA: 0x00069B5E File Offset: 0x00067D5E
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005C96 RID: 23702
		' (get) Token: 0x0600F17E RID: 61822 RVA: 0x00069B67 File Offset: 0x00067D67
		' (set) Token: 0x0600F17F RID: 61823 RVA: 0x00069B71 File Offset: 0x00067D71
		Friend Overridable Property Label15 As Label

		' Token: 0x17005C97 RID: 23703
		' (get) Token: 0x0600F180 RID: 61824 RVA: 0x00069B7A File Offset: 0x00067D7A
		' (set) Token: 0x0600F181 RID: 61825 RVA: 0x00069B84 File Offset: 0x00067D84
		Friend Overridable Property txtBcode As TextBox

		' Token: 0x17005C98 RID: 23704
		' (get) Token: 0x0600F182 RID: 61826 RVA: 0x00069B8D File Offset: 0x00067D8D
		' (set) Token: 0x0600F183 RID: 61827 RVA: 0x00069B97 File Offset: 0x00067D97
		Friend Overridable Property Label16 As Label

		' Token: 0x17005C99 RID: 23705
		' (get) Token: 0x0600F184 RID: 61828 RVA: 0x00069BA0 File Offset: 0x00067DA0
		' (set) Token: 0x0600F185 RID: 61829 RVA: 0x00069BAA File Offset: 0x00067DAA
		Friend Overridable Property txtAdminCode As TextBox

		' Token: 0x17005C9A RID: 23706
		' (get) Token: 0x0600F186 RID: 61830 RVA: 0x00069BB3 File Offset: 0x00067DB3
		' (set) Token: 0x0600F187 RID: 61831 RVA: 0x0090FE30 File Offset: 0x0090E030
		Private _btnbranchUpdate As GelButton
		Friend Overridable Property btnbranchUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnbranchUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnbranchUpdate_Click
				Dim gelButton As GelButton = Me._btnbranchUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnbranchUpdate = value
				gelButton = Me._btnbranchUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C9B RID: 23707
		' (get) Token: 0x0600F188 RID: 61832 RVA: 0x00069BBD File Offset: 0x00067DBD
		' (set) Token: 0x0600F189 RID: 61833 RVA: 0x00069BC7 File Offset: 0x00067DC7
		Friend Overridable Property Label21 As Label

		' Token: 0x17005C9C RID: 23708
		' (get) Token: 0x0600F18A RID: 61834 RVA: 0x00069BD0 File Offset: 0x00067DD0
		' (set) Token: 0x0600F18B RID: 61835 RVA: 0x00069BDA File Offset: 0x00067DDA
		Friend Overridable Property Label20 As Label

		' Token: 0x17005C9D RID: 23709
		' (get) Token: 0x0600F18C RID: 61836 RVA: 0x00069BE3 File Offset: 0x00067DE3
		' (set) Token: 0x0600F18D RID: 61837 RVA: 0x00069BED File Offset: 0x00067DED
		Friend Overridable Property Label22 As Label

		' Token: 0x17005C9E RID: 23710
		' (get) Token: 0x0600F18E RID: 61838 RVA: 0x00069BF6 File Offset: 0x00067DF6
		' (set) Token: 0x0600F18F RID: 61839 RVA: 0x00069C00 File Offset: 0x00067E00
		Friend Overridable Property Label24 As Label

		' Token: 0x17005C9F RID: 23711
		' (get) Token: 0x0600F190 RID: 61840 RVA: 0x00069C09 File Offset: 0x00067E09
		' (set) Token: 0x0600F191 RID: 61841 RVA: 0x00069C13 File Offset: 0x00067E13
		Friend Overridable Property Label10 As Label

		' Token: 0x17005CA0 RID: 23712
		' (get) Token: 0x0600F192 RID: 61842 RVA: 0x00069C1C File Offset: 0x00067E1C
		' (set) Token: 0x0600F193 RID: 61843 RVA: 0x00069C26 File Offset: 0x00067E26
		Friend Overridable Property txtLoyality As TextBox

		' Token: 0x17005CA1 RID: 23713
		' (get) Token: 0x0600F194 RID: 61844 RVA: 0x00069C2F File Offset: 0x00067E2F
		' (set) Token: 0x0600F195 RID: 61845 RVA: 0x0090FE74 File Offset: 0x0090E074
		Private _btnUpgrade As GelButton
		Friend Overridable Property btnUpgrade As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpgrade
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpgrade_Click
				Dim gelButton As GelButton = Me._btnUpgrade
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpgrade = value
				gelButton = Me._btnUpgrade
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CA2 RID: 23714
		' (get) Token: 0x0600F196 RID: 61846 RVA: 0x00069C39 File Offset: 0x00067E39
		' (set) Token: 0x0600F197 RID: 61847 RVA: 0x00069C43 File Offset: 0x00067E43
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x17005CA3 RID: 23715
		' (get) Token: 0x0600F198 RID: 61848 RVA: 0x00069C4C File Offset: 0x00067E4C
		' (set) Token: 0x0600F199 RID: 61849 RVA: 0x00069C56 File Offset: 0x00067E56
		Friend Overridable Property lblProgress As Label

		' Token: 0x0600F19A RID: 61850 RVA: 0x0090FEB8 File Offset: 0x0090E0B8
		Private Sub frmCompanyupdate_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.txtCompanyName.Focus()
			Me.ComboBox1.Visible = True
			Me.Label19.Visible = True
			Me.TextBox5.Visible = True
			Me.Button1.Visible = True
			Me.PictureBox2.Visible = True
			Me.PictureBox3.Visible = True
			Try
				Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
				Try
					For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
						Dim text As String = Conversions.ToString(managementObject("SerialNumber"))
						Me.TextBox5.Text = ModFunc.MD5Encrypt(Me.txtDB.Text.TrimEnd(New Char(-1) {}).ToString() + Strings.StrReverse(text))
						Try
							Dim qrcodeEncoder As QRCodeEncoder = New QRCodeEncoder()
							qrcodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
							qrcodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
							Me.PictureBox3.Image = qrcodeEncoder.Encode(Me.TextBox5.Text, Encoding.UTF8)
						Catch ex As Exception
						End Try
					Next
				Finally
					Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator IsNot Nothing Then
						CType(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex2 As Exception
			End Try
			Me.checkUpgrade()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F19B RID: 61851 RVA: 0x00910050 File Offset: 0x0090E250
		Public Sub checkUpgrade()
			Try
				Dim flag As Boolean = ModFunc.CheckForInternetConnection()
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(DBName), RTRIM(Online_DBName), RTRIM(company_id) FROM RaintechMaster WHERE company_id=@d1 and is_active=1 ", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox5.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						Me.btnUpgrade.Enabled = False
					Else
						Me.btnUpgrade.Enabled = True
					End If
					ModCommonClasses.con.Close()
				Else
					Me.btnUpgrade.Enabled = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F19C RID: 61852 RVA: 0x0091014C File Offset: 0x0090E34C
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						Me.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not Me.translations.ContainsKey(text2)
								If flag Then
									Me.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, Me.translations)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600F19D RID: 61853 RVA: 0x009102C0 File Offset: 0x0090E4C0
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

		' Token: 0x0600F19E RID: 61854 RVA: 0x0091037C File Offset: 0x0090E57C
		Public Sub Getdata()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(companyName), RTRIM(Address),RTRIM(State), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(GSTIN), RTRIM(CIN), Logo, RTRIM(City), RTRIM(Web), RTRIM(Bankholder),RTRIM(Bankacno),RTRIM(Bankname),RTRIM(Bankifsc),RTRIM(AndroidID),RTRIM(CurSym),RTRIM(BCode),RTRIM(AdminCode), Loyality_perpoint from company", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtID.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0))))
					Me.txtCompanyName.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtCName.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.cmbState.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtEmailID.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtCIN.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtCity.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtWeb.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.TextBox1.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.TextBox2.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.TextBox3.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.TextBox4.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.ComboBox1.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.txtCurrencySymb.Text = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.txtBcode.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.txtAdminCode.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.txtLoyality.Text = ModCommonClasses.rdr.GetValue(19).ToString()
					Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(8), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.PictureBox1.Image = Image.FromStream(memoryStream)
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F19F RID: 61855 RVA: 0x009106A8 File Offset: 0x0090E8A8
		Private Sub btnBrowse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.PictureBox1.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600F1A0 RID: 61856 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCompanyName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1A1 RID: 61857 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x0600F1A2 RID: 61858 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1A3 RID: 61859 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1A4 RID: 61860 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmailID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1A5 RID: 61861 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtGSTIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1A6 RID: 61862 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1A7 RID: 61863 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtWeb_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1A8 RID: 61864 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCity_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1A9 RID: 61865 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCompanyupdate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F1AA RID: 61866 RVA: 0x00910748 File Offset: 0x0090E948
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtEmailID.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtEmailID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtEmailID, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtCompanyName.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtCompanyName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCompanyName, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtAddress.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAddress, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.cmbState.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.cmbState, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbState, String.Empty)
			End If
		End Sub

		' Token: 0x0600F1AB RID: 61867 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1AC RID: 61868 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1AD RID: 61869 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1AE RID: 61870 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F1AF RID: 61871 RVA: 0x00069C5F File Offset: 0x00067E5F
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Clipboard.SetDataObject(Me.TextBox5.Text)
			MessageBox.Show("Company ID Copied Successfully" & vbCrLf, "Company Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
		End Sub

		' Token: 0x0600F1B0 RID: 61872 RVA: 0x009108D4 File Offset: 0x0090EAD4
		Private Sub txtCurrencySymb_KeyPress(sender As Object, e As KeyPressEventArgs)
			Me.txtCurrencySymb.MaxLength = 3
			Dim flag As Boolean = Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600F1B1 RID: 61873 RVA: 0x00910920 File Offset: 0x0090EB20
		Private Async Sub txtGSTIN_TextChanged(sender As Object, e As EventArgs)
			Dim validator As GSTINValidator = New GSTINValidator()
			Try
				Dim result As Dictionary(Of String, String) = Await validator.ValidateGSTINAsync(Me.txtGSTIN.Text)
				If result.ContainsKey("Error") Then
					Me.lbl_Result.ForeColor = Color.Red
					Me.lbl_Result.Text = "Invalid GSTIN!"
				Else
					Dim dictionary As Dictionary(Of String, String) = result
					Dim text As String = "State"
					Dim text2 As String = ""
					Dim strState As String = If(dictionary.TryGetValue(text, text2), result("State"), "NA")
					If Operators.CompareString(strState, "Not Available", False) = 0 Then
						Me.lbl_Result.ForeColor = Color.Red
						Me.lbl_Result.Text = "Invalid GSTIN!"
					Else
						Me.lbl_Result.ForeColor = Color.Green
						Me.lbl_Result.Text = "Valid GSTIN."
					End If
				End If
			Catch ex As Exception
				Me.lbl_Result.ForeColor = Color.Red
				Me.lbl_Result.Text = ex.Message
			End Try
		End Sub

		' Token: 0x0600F1B2 RID: 61874 RVA: 0x00910968 File Offset: 0x0090EB68
		Private Sub btnprint_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtCompanyName.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Record not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim reportDocument As ReportDocument = New rptCompanyEnvolve()
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				Dim textObject As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text15"), TextObject)
				textObject.Text = Me.txtCompanyName.Text
				Dim textObject2 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text16"), TextObject)
				textObject2.Text = Me.txtAddress.Text
				Dim textObject3 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text17"), TextObject)
				textObject3.Text = Me.cmbState.Text
				Dim textObject4 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text19"), TextObject)
				textObject4.Text = "Email :" + Me.txtEmailID.Text
				Dim textObject5 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text20"), TextObject)
				textObject5.Text = "Contact :" + Me.txtContactNo.Text
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub

		' Token: 0x0600F1B3 RID: 61875 RVA: 0x00069C86 File Offset: 0x00067E86
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.txtCompanyName.Focus()
		End Sub

		' Token: 0x0600F1B4 RID: 61876 RVA: 0x00910B30 File Offset: 0x0090ED30
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtCurrencySymb.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter currency symbol", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtCurrencySymb.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtCompanyName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please enter company name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCompanyName.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.txtAddress.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAddress.Focus()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.cmbState.Text, "", False) = 0
						If flag4 Then
							MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbState.Focus()
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
							If flag5 Then
								MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtContactNo.Focus()
							Else
								Dim flag6 As Boolean = Operators.CompareString(Me.txtEmailID.Text, "", False) = 0
								If flag6 Then
									MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtEmailID.Focus()
								Else
									Dim flag7 As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) = 0
									If flag7 Then
										MessageBox.Show("You are not allowed to use Android mobile app in trial mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									End If
									Try
										ModCommonClasses.con.Close()
										Dim flag8 As Boolean = Operators.CompareString(Me.txtCompanyName.Text, "", False) = 0
										flag8 = Operators.CompareString(Me.txtCompanyName.Text, Me.txtCName.Text, False) <> 0
										Dim flag9 As Boolean = flag8
										If flag9 Then
											ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
											ModCommonClasses.con.Open()
											Dim text As String = "select CompanyName from RaintechMaster where CompanyName=@d1"
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompanyName.Text.TrimEnd(New Char(-1) {}).ToString())
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.CommandTimeout = 0
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											flag8 = ModCommonClasses.rdr.Read()
											Dim flag10 As Boolean = flag8
											If flag10 Then
												MessageBox.Show("Company Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.txtCompanyName.Text = ""
												Me.txtCompanyName.Focus()
												flag8 = ModCommonClasses.rdr IsNot Nothing
												Dim flag11 As Boolean = flag8
												If flag11 Then
													ModCommonClasses.rdr.Close()
												End If
												Return
											End If
											ModCommonClasses.con.Close()
										End If
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "Update Company set CompanyName=@d1,Address=@d2,State=@d3,ContactNo=@d4,EmailID=@d5,GSTIN=@d6,CIN=@d7,City=@d8,Web=@d9,Bankholder=@d10,Bankacno=@d11,Bankname=@d12,Bankifsc=@d13,AndroidID=@d14,CurSym=@d15,Logo=@d16,BCode=@d17,Loyality_perpoint=@d18 where ID=@dx"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@dx", Conversion.Val(Me.txtID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompanyName.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAddress.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbState.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtContactNo.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtEmailID.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtGSTIN.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtCIN.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtCity.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.txtWeb.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.TextBox1.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.TextBox2.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.TextBox3.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.TextBox4.Text.ToString())
										Dim flag12 As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) = 0
										If flag12 Then
											ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "Disabled")
										Else
											ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.ComboBox1.Text.ToString())
										End If
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.txtCurrencySymb.Text.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.txtBcode.Text.ToString())
										Dim flag13 As Boolean = Me.txtLoyality.Text = Nothing
										If flag13 Then
											ModCommonClasses.cmd.Parameters.AddWithValue("@d18", 0)
										Else
											ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.txtLoyality.Text)
										End If
										Dim memoryStream As MemoryStream = New MemoryStream()
										Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
										bitmap.Save(memoryStream, ImageFormat.Jpeg)
										Dim buffer As Byte() = memoryStream.GetBuffer()
										Dim sqlParameter As SqlParameter = New SqlParameter("@d16", SqlDbType.Image)
										sqlParameter.Value = buffer
										ModCommonClasses.cmd.Parameters.Add(sqlParameter)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.ExecuteReader()
										ModCommonClasses.con.Close()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
										ModCommonClasses.con.Open()
										Dim text3 As String = "update RaintechMaster set companyname=@d1 where dbname=@d2"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompanyName.Text.TrimEnd(New Char(-1) {}).ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtDB.Text.TrimEnd(New Char(-1) {}).ToString())
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text4 As String = "update Customer set State=@d1 where ID='1' and Name='Cash'"
										ModCommonClasses.cmd = New SqlCommand(text4)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbState.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										MessageBox.Show("Successfully Saved", "Company Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

		' Token: 0x0600F1B5 RID: 61877 RVA: 0x009113AC File Offset: 0x0090F5AC
		Private Sub btnbranchUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = String.IsNullOrEmpty(Me.txtAdminCode.Text)
				If flag Then
					MessageBox.Show("Please enter admin code.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAdminCode.Focus()
				Else
					Dim text As String = ModCS.ReadCS1()
					Dim text2 As String = Me.txtAdminCode.Text
					Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
						mySqlConnection.Open()
						Dim text3 As String = "SELECT COUNT(*) FROM branch_admin WHERE admin_code = @valueToCheck"
						Using mySqlCommand As MySqlCommand = New MySqlCommand(text3, mySqlConnection)
							mySqlCommand.Parameters.AddWithValue("@valueToCheck", text2)
							Dim num As Integer = Conversions.ToInteger(mySqlCommand.ExecuteScalar())
							Dim flag2 As Boolean = num > 0
							If flag2 Then
								Me.CheckBranchCode()
							Else
								MessageBox.Show("Invalid Admin Code")
							End If
						End Using
					End Using
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F1B6 RID: 61878 RVA: 0x009114C4 File Offset: 0x0090F6C4
		Public Function CheckBranchCode() As Boolean
			Try
				Dim text As String = ModCS.ReadCS1()
				Dim text2 As String = Me.TextBox5.Text
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text3 As String = "SELECT COUNT(*) FROM branch WHERE branchcode = @valueToCheck"
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text3, mySqlConnection)
						mySqlCommand.Parameters.AddWithValue("@valueToCheck", text2)
						Dim num As Integer = Conversions.ToInteger(mySqlCommand.ExecuteScalar())
						Dim flag As Boolean = num > 0
						If flag Then
							MessageBox.Show("Branch Already Exists")
						Else
							Me.insBranch()
							Me.OflineUpdateAdmin()
						End If
					End Using
				End Using
			Catch ex As Exception
			End Try
			Dim flag2 As Boolean
			Return flag2
		End Function

		' Token: 0x0600F1B7 RID: 61879 RVA: 0x009115AC File Offset: 0x0090F7AC
		Public Function OflineUpdateAdmin() As Object
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update Company set AdminCode=@d1 where ID=@dx"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@dx", Conversion.Val(Me.txtID.Text))
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAdminCode.Text.ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.CommandTimeout = 0
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
			MessageBox.Show("Admin Code Update")
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600F1B8 RID: 61880 RVA: 0x00911674 File Offset: 0x0090F874
		Public Function insBranch() As Object
			Dim text As String = ModCS.ReadCS1()
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtAddress.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter Address ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtAddress.Focus()
			End If
			Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtCity.Text)) = 0
			If flag2 Then
				MessageBox.Show("Please enter City ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtCity.Focus()
			End If
			Dim mySqlConnection As MySqlConnection = New MySqlConnection(text)
			Try
				mySqlConnection.Open()
				Dim text2 As String = "INSERT INTO branch(branchcode, admincode, branchname, branchstate,branchaddress,branchmobno,branchcity,branchgst,branchstatus)" & vbCrLf & "                VALUES (@d1, @d2, @d3, @d4,@d5, @d6, @d7, @d8, @d9)"
				Dim mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
				mySqlCommand.Parameters.AddWithValue("@d1", Me.TextBox5.Text)
				mySqlCommand.Parameters.AddWithValue("@d2", Me.txtAdminCode.Text)
				mySqlCommand.Parameters.AddWithValue("@d3", Me.txtCompanyName.Text.TrimEnd(New Char(-1) {}))
				mySqlCommand.Parameters.AddWithValue("@d4", Me.cmbState.Text.TrimEnd(New Char(-1) {}))
				mySqlCommand.Parameters.AddWithValue("@d5", Me.txtAddress.Text.TrimEnd(New Char(-1) {}))
				mySqlCommand.Parameters.AddWithValue("@d6", Me.txtContactNo.Text.TrimEnd(New Char(-1) {}))
				mySqlCommand.Parameters.AddWithValue("@d7", Me.txtCity.Text.TrimEnd(New Char(-1) {}))
				mySqlCommand.Parameters.AddWithValue("@d8", Me.txtGSTIN.Text.TrimEnd(New Char(-1) {}))
				mySqlCommand.Parameters.AddWithValue("@d9", "true")
				Dim num As Integer = mySqlCommand.ExecuteNonQuery()
				Console.WriteLine("Rows affected: " + Conversions.ToString(num))
			Catch ex As MySqlException
				Console.WriteLine("MySQL Error: " + ex.Message)
				Console.WriteLine("MySQL ErrorCode: " + Conversions.ToString(ex.Number))
				Console.WriteLine("Stack Trace: " + ex.StackTrace)
			Finally
				mySqlConnection.Close()
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600F1B9 RID: 61881 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)
		End Sub

		' Token: 0x0600F1BA RID: 61882 RVA: 0x00911924 File Offset: 0x0090FB24
		Private Sub btnUpgrade_Click(sender As Object, e As EventArgs)
			Dim text As String = ""
			Dim text2 As String = ""
			Dim text3 As String = ""
			Me.lblProgress.Visible = True
			Me.ProgressBar1.Visible = True
			Try
				ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(DBName), RTRIM(Online_DBName), RTRIM(company_id) FROM RaintechMaster WHERE company_id=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox5.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					text3 = ModCommonClasses.rdr.GetString(0)
					text2 = ModCommonClasses.rdr.GetString(1)
					text = ModCommonClasses.rdr.GetString(2)
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
			If flag2 Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(DBName), RTRIM(Online_DBName), RTRIM(company_id) FROM RaintechMaster WHERE company_id=@d1 and is_active=1 ", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox5.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						MessageBox.Show("You have already Upgraded your system!")
						Return
					End If
					ModCommonClasses.con.Close()
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM RaintechMaster WHERE company_id = @cid", ModCommonClasses.con)
				sqlCommand.Parameters.AddWithValue("@cid", Me.TextBox5.Text)
				Dim num As Integer = Conversions.ToInteger(sqlCommand.ExecuteScalar())
				Dim flag4 As Boolean = num > 0
				If flag4 Then
					Dim sqlCommand2 As SqlCommand = New SqlCommand("UPDATE RaintechMaster SET is_active = 0 WHERE company_id = @cid", ModCommonClasses.con)
					sqlCommand2.Parameters.AddWithValue("@cid", Me.TextBox5.Text)
					sqlCommand2.ExecuteNonQuery()
				End If
				ModCommonClasses.con.Close()
				Me.ProgressBar1.Value = 0
				Me.lblProgress.Text = "0%"
				Application.DoEvents()
				Me.ProgressBar1.Value = 10
				Me.lblProgress.Text = "10% - Inserting into master table..."
				Application.DoEvents()
				ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				ModCommonClasses.con.Open()
				Dim text4 As String = "insert into RaintechMaster(ID,CompanyName,DBName, Online_DBName, company_id) VALUES (@d1,@d2,@d3,@d4,@d5)"
				ModCommonClasses.cmd = New SqlCommand(text4)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCompanyID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCompanyName.Text).ToString()
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "Raintech_DB" + Conversions.ToString(Conversion.Val(Me.txtCompanyID.Text)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d5", text.ToString())
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				Me.ProgressBar1.Value = 30
				Me.lblProgress.Text = "30% - Creating online database..."
				Application.DoEvents()
				Me.CreateDatabaseIfNotExists(GlobalVariables.serverConnStrWithoutDB, text2)
				Me.ProgressBar1.Value = 50
				Me.lblProgress.Text = "50% - Updating local DB sync columns..."
				Application.DoEvents()
				Me.AddAndPopulateSyncGuidAndIsRemoteColumn(ModCS.ReadCS())
				Me.ProgressBar1.Value = 70
				Me.lblProgress.Text = "70% - Creating schema on remote server..."
				Application.DoEvents()
				Dim dbhelper As DBHelper = New DBHelper()
				Dim text5 As String = dbhelper.UpdateConnectionStringFromGrid(text2)
				Me.DatabaseScheme_Create(ModCS.ReadCS(), text5, text3)
				Me.ProgressBar1.Value = 90
				Me.lblProgress.Text = "90% - Migrating data..."
				Application.DoEvents()
				Me.Migrate_Data(ModCS.ReadCS(), text5)
				Me.ProgressBar1.Value = 100
				Me.lblProgress.Text = "100% - Synchronization completed!"
				Application.DoEvents()
			Else
				MessageBox.Show("Please Check your internet connection!")
			End If
		End Sub

		' Token: 0x0600F1BB RID: 61883 RVA: 0x00204688 File Offset: 0x00202888
		Public Function CreateDatabaseIfNotExists(serverConnStrWithoutDB As String, databaseName As String) As Boolean
			Dim flag2 As Boolean
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(serverConnStrWithoutDB)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand(String.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName), sqlConnection)
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
					Dim flag As Boolean = objectValue Is Nothing
					If flag Then
						Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("CREATE DATABASE [{0}]", databaseName), sqlConnection)
						sqlCommand2.ExecuteNonQuery()
						flag2 = True
					Else
						MessageBox.Show("✅ Already Exist!," + databaseName)
						flag2 = False
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("DB Check/Create Error: " + ex.Message)
				flag2 = False
			End Try
			Return flag2
		End Function

		' Token: 0x0600F1BC RID: 61884 RVA: 0x00911E08 File Offset: 0x00910008
		Public Sub AddAndPopulateSyncGuidAndIsRemoteColumn(connectionString As String)
			Using sqlConnection As SqlConnection = New SqlConnection(connectionString)
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", sqlConnection)
				Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
				Dim list As List(Of String) = New List(Of String)()
				While sqlDataReader.Read()
					list.Add(sqlDataReader("TABLE_NAME").ToString())
				End While
				sqlDataReader.Close()
				Try
					For Each text As String In list
						Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = 'is_remote'", text), sqlConnection)
						Dim flag As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar())) > 0
						Dim flag2 As Boolean = Not flag
						If flag2 Then
							Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("ALTER TABLE [{0}] ADD is_remote BIT DEFAULT 0", text), sqlConnection)
							sqlCommand3.ExecuteNonQuery()
							Console.WriteLine(String.Format("✅ Added is_remote to table: {0}", text))
						Else
							Console.WriteLine(String.Format("ℹ️ is_remote already exists in table: {0}", text))
						End If
						Dim sqlCommand4 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = 'SyncGuid'", text), sqlConnection)
						Dim flag3 As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand4.ExecuteScalar())) > 0
						Dim flag4 As Boolean = Not flag3
						If flag4 Then
							Dim sqlCommand5 As SqlCommand = New SqlCommand(String.Format("ALTER TABLE [{0}] ADD SyncGuid UNIQUEIDENTIFIER DEFAULT NEWID()", text), sqlConnection)
							sqlCommand5.ExecuteNonQuery()
							Console.WriteLine(String.Format("✅ Added SyncGuid to table: {0}", text))
						Else
							Console.WriteLine(String.Format("ℹ️ SyncGuid already exists in table: {0}", text))
						End If
						Dim sqlCommand6 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET SyncGuid = NEWID() WHERE SyncGuid IS NULL", text), sqlConnection)
						Dim num As Integer = sqlCommand6.ExecuteNonQuery()
						Dim flag5 As Boolean = num > 0
						If flag5 Then
							Console.WriteLine(String.Format("🔄 Updated {0} NULL SyncGuid values in: {1}", num, text))
						End If
						Dim sqlCommand7 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = 'Version'", text), sqlConnection)
						Dim flag6 As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand7.ExecuteScalar())) > 0
						Dim flag7 As Boolean = Not flag6
						If flag7 Then
							Dim sqlCommand8 As SqlCommand = New SqlCommand(String.Format("ALTER TABLE [{0}] ADD Version ROWVERSION", text), sqlConnection)
							sqlCommand8.ExecuteNonQuery()
							Console.WriteLine(String.Format("✅ Added Version (ROWVERSION) to table: {0}", text))
						Else
							Console.WriteLine(String.Format("ℹ️ Version column already exists in table: {0}", text))
						End If
					Next
				Finally
					Dim enumerator As List(Of String).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
				sqlConnection.Close()
			End Using
		End Sub

		' Token: 0x0600F1BD RID: 61885 RVA: 0x009120A0 File Offset: 0x009102A0
		Public Sub DatabaseScheme_Create(localConnStr As String, remoteConnStr As String, datbaseName As String)
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(localConnStr)
				Dim server As Server = New Server(New ServerConnection(sqlConnection))
				Dim database As Microsoft.SqlServer.Management.Smo.Database = server.Databases(datbaseName)
				Dim sqlConnection2 As SqlConnection = New SqlConnection(remoteConnStr)
				Dim server2 As Server = New Server(New ServerConnection(sqlConnection2))
				Dim scripter As Scripter = New Scripter(server)
				scripter.Options.ScriptData = False
				scripter.Options.ScriptSchema = True
				scripter.Options.WithDependencies = False
				scripter.Options.DriAll = True
				scripter.Options.Indexes = True
				scripter.Options.SchemaQualify = True
				scripter.Options.IncludeHeaders = True
				Dim list As List(Of Urn) = New List(Of Urn)()
				Try
					For Each obj As Object In database.Tables
						Dim table As Microsoft.SqlServer.Management.Smo.Table = CType(obj, Microsoft.SqlServer.Management.Smo.Table)
						Dim flag As Boolean = Not table.IsSystemObject
						If flag Then
							list.Add(table.Urn)
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim stringCollection As StringCollection = scripter.Script(list.ToArray())
				Dim list2 As List(Of String) = stringCollection.Cast(Of String)().ToList()
				Try
					For Each text As String In list2
						Dim flag2 As Boolean = Not String.IsNullOrWhiteSpace(text)
						If flag2 Then
							Dim text2 As String = Regex.Replace(text, "(?i)(\[Version\]\s+)([^\s,]+)", "$1NVARCHAR(200)")
							server2.ConnectionContext.ExecuteNonQuery(text2)
						End If
					Next
				Finally
					Dim enumerator2 As List(Of String).Enumerator
					CType(enumerator2, IDisposable).Dispose()
				End Try
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600F1BE RID: 61886 RVA: 0x009122B4 File Offset: 0x009104B4
		Public Sub Migrate_Data(localConnStr As String, onlineConnStr As String)
			Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(localConnStr)
					Using sqlConnection2 As SqlConnection = New SqlConnection(onlineConnStr)
						sqlConnection.Open()
						sqlConnection2.Open()
						Dim tableMigrationOrder As List(Of String) = frmCompanyupdate.GetTableMigrationOrder(sqlConnection)
						Try
							For Each text As String In tableMigrationOrder
								Me.MigrateInitialRows(text, dictionary, sqlConnection, sqlConnection2)
								Console.WriteLine("Migrating: " + text)
							Next
						Finally
							Dim enumerator As List(Of String).Enumerator
							CType(enumerator, IDisposable).Dispose()
						End Try
						MessageBox.Show("✅ Sync completed successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("❌ Error during sync: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F1BF RID: 61887 RVA: 0x009123D4 File Offset: 0x009105D4
		Public Shared Function GetTableMigrationOrder(con As SqlConnection) As List(Of String)
			Dim dependencies As New Dictionary(Of String, List(Of String))()
			Dim allTables As New HashSet(Of String)()
			Dim sqlCommand As New SqlCommand("SELECT fk.name AS FK_Name, tp.name AS ParentTable, tr.name AS ChildTable FROM sys.foreign_keys fk INNER JOIN sys.tables tp ON fk.referenced_object_id = tp.object_id INNER JOIN sys.tables tr ON fk.parent_object_id = tr.object_id", con)
			Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
				While sqlDataReader.Read()
					Dim parentTable As String = sqlDataReader("ParentTable").ToString()
					Dim childTable As String = sqlDataReader("ChildTable").ToString()
					If Not dependencies.ContainsKey(childTable) Then
						dependencies(childTable) = New List(Of String)()
					End If
					dependencies(childTable).Add(parentTable)
					allTables.Add(parentTable)
					allTables.Add(childTable)
				End While
			End Using
			Dim sqlCommand2 As New SqlCommand("SELECT name FROM sys.tables", con)
			Using sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
				While sqlDataReader2.Read()
					allTables.Add(sqlDataReader2("name").ToString())
				End While
			End Using
			Dim visited As New HashSet(Of String)()
			Dim result As New List(Of String)()
			Dim visitAction As Action(Of String) = Nothing
			visitAction = Sub(t As String)
				If Not visited.Contains(t) Then
					visited.Add(t)
					If dependencies.ContainsKey(t) Then
						For Each dep As String In dependencies(t)
							visitAction(dep)
						Next
					End If
					result.Add(t)
				End If
			End Sub
			For Each table As String In allTables
				visitAction(table)
			Next
			Return result.Distinct().ToList()
		End Function

		' Token: 0x0600F1C0 RID: 61888 RVA: 0x009125A4 File Offset: 0x009107A4
		Private Sub MigrateInitialRows(tableName As String, tableKeys As Dictionary(Of String, String), localCon As SqlConnection, remoteCon As SqlConnection)
			' The following expression was wrapped in a checked-statement
			Try
				Dim dictionary As Dictionary(Of String, Type) = New Dictionary(Of String, Type)()
				Dim hashSet As HashSet(Of String) = New HashSet(Of String)()
				Using sqlCommand As SqlCommand = New SqlCommand(String.Format("SELECT TOP 0 * FROM [{0}]", tableName), remoteCon)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly)
						Dim schemaTable As DataTable = sqlDataReader.GetSchemaTable()
						Try
							For Each obj As Object In schemaTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text As String = dataRow("ColumnName").ToString()
								dictionary(text) = CType(dataRow("DataType"), Type)
								Dim flag As Boolean = schemaTable.Columns.Contains("IsIdentity") AndAlso Conversions.ToBoolean(dataRow("IsIdentity"))
								If flag Then
									hashSet.Add(text)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
				Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("SELECT * FROM [{0}] WHERE ISNULL(is_remote, 0) = 0", tableName), localCon)
				Dim sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
				While sqlDataReader2.Read()
					Dim flag2 As Boolean = (Operators.CompareString(tableName, "EmailCache", False) <> 0) And (Operators.CompareString(tableName, "Language_set", False) <> 0)
					If flag2 Then
						Dim cols As New List(Of String)()
						Dim list As List(Of String) = New List(Of String)()
						Dim list2 As List(Of SqlParameter) = New List(Of SqlParameter)()
						Dim text2 As String = sqlDataReader2("SyncGuid").ToString()
						Dim num As Integer = sqlDataReader2.FieldCount - 1
						For i As Integer = 0 To num
							Dim name As String = sqlDataReader2.GetName(i)
							Dim flag3 As Boolean = Operators.CompareString(name.ToLower(), "is_remote", False) <> 0
							If flag3 Then
								cols.Add("[" + name + "]")
								list.Add("@" + name)
								Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlDataReader2(name))
								Dim sqlParameter As SqlParameter = New SqlParameter("@" + name, RuntimeHelpers.GetObjectValue(If((objectValue IsNot Nothing AndAlso objectValue IsNot DBNull.Value), objectValue, DBNull.Value)))
								Dim flag4 As Boolean = objectValue IsNot Nothing AndAlso objectValue IsNot DBNull.Value
								If flag4 Then
									Dim flag5 As Boolean = dictionary.ContainsKey(name)
									If flag5 Then
										Dim type As Type = dictionary(name)
										Dim flag6 As Boolean = Operators.CompareString(name, "Version", False) = 0 AndAlso type Is GetType(String) AndAlso TypeOf objectValue Is Byte()
										If flag6 Then
											Dim array As Byte() = CType(objectValue, Byte())
											sqlParameter.Value = BitConverter.ToString(array).Replace("-", "")
											sqlParameter.SqlDbType = SqlDbType.NVarChar
										End If
									End If
								End If
								list2.Add(sqlParameter)
							End If
						Next
						Try
							Dim flag7 As Boolean = False
							Dim flag8 As Boolean = hashSet.Any(Function(ic As String) cols.Any(Function(col As String) col.Trim("["c, "]"c).Equals(ic, StringComparison.OrdinalIgnoreCase)))
							If flag8 Then
								Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] ON", tableName), remoteCon)
								sqlCommand3.ExecuteNonQuery()
								flag7 = True
							End If
							Dim text3 As String = String.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tableName, String.Join(",", cols), String.Join(",", list))
							Dim sqlCommand4 As SqlCommand = New SqlCommand(text3, remoteCon)
							sqlCommand4.Parameters.AddRange(list2.ToArray())
							sqlCommand4.ExecuteNonQuery()
							Dim flag9 As Boolean = flag7
							If flag9 Then
								Dim sqlCommand5 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] OFF", tableName), remoteCon)
								sqlCommand5.ExecuteNonQuery()
							End If
							Using sqlCommand6 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET is_remote = 1 WHERE SyncGuid = @sync", tableName), localCon)
								sqlCommand6.Parameters.AddWithValue("@sync", text2)
								sqlCommand6.ExecuteNonQuery()
							End Using
						Catch ex As Exception
							Debug.WriteLine(String.Format("❌ Error inserting into {0}: {1}", tableName, ex.Message))
						End Try
					End If
				End While
				sqlDataReader2.Close()
			Catch ex2 As Exception
				MessageBox.Show("❌ Error in initial migration for table " + tableName + ": " + ex2.Message)
			End Try
		End Sub

		' Token: 0x04005C46 RID: 23622
		Private translations As Dictionary(Of String, String)
	End Class
End Namespace
