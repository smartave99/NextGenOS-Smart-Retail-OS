Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports FluentFTP
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x02000056 RID: 86
	<DesignerGenerated()>
	Public Partial Class frmEProduct
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06000FD4 RID: 4052 RVA: 0x0000EA43 File Offset: 0x0000CC43
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEProduct_Load
			Me.lstBuld = New List(Of String)()
			Me.sb = New StringBuilder()
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700066E RID: 1646
		' (get) Token: 0x06000FD7 RID: 4055 RVA: 0x0000EA7C File Offset: 0x0000CC7C
		' (set) Token: 0x06000FD8 RID: 4056 RVA: 0x000BF3DC File Offset: 0x000BD5DC
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

		' Token: 0x1700066F RID: 1647
		' (get) Token: 0x06000FD9 RID: 4057 RVA: 0x0000EA86 File Offset: 0x0000CC86
		' (set) Token: 0x06000FDA RID: 4058 RVA: 0x0000EA90 File Offset: 0x0000CC90
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x17000670 RID: 1648
		' (get) Token: 0x06000FDB RID: 4059 RVA: 0x0000EA99 File Offset: 0x0000CC99
		' (set) Token: 0x06000FDC RID: 4060 RVA: 0x000BF420 File Offset: 0x000BD620
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

		' Token: 0x17000671 RID: 1649
		' (get) Token: 0x06000FDD RID: 4061 RVA: 0x0000EAA3 File Offset: 0x0000CCA3
		' (set) Token: 0x06000FDE RID: 4062 RVA: 0x0000EAAD File Offset: 0x0000CCAD
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17000672 RID: 1650
		' (get) Token: 0x06000FDF RID: 4063 RVA: 0x0000EAB6 File Offset: 0x0000CCB6
		' (set) Token: 0x06000FE0 RID: 4064 RVA: 0x0000EAC0 File Offset: 0x0000CCC0
		Friend Overridable Property txtPid As TextBox

		' Token: 0x17000673 RID: 1651
		' (get) Token: 0x06000FE1 RID: 4065 RVA: 0x0000EAC9 File Offset: 0x0000CCC9
		' (set) Token: 0x06000FE2 RID: 4066 RVA: 0x0000EAD3 File Offset: 0x0000CCD3
		Friend Overridable Property Label20 As Label

		' Token: 0x17000674 RID: 1652
		' (get) Token: 0x06000FE3 RID: 4067 RVA: 0x0000EADC File Offset: 0x0000CCDC
		' (set) Token: 0x06000FE4 RID: 4068 RVA: 0x000BF464 File Offset: 0x000BD664
		Private _btnEcomPost As GelButton
		Friend Overridable Property btnEcomPost As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnEcomPost
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnEcomPost_Click
				Dim gelButton As GelButton = Me._btnEcomPost
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnEcomPost = value
				gelButton = Me._btnEcomPost
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000675 RID: 1653
		' (get) Token: 0x06000FE5 RID: 4069 RVA: 0x0000EAE6 File Offset: 0x0000CCE6
		' (set) Token: 0x06000FE6 RID: 4070 RVA: 0x0000EAF0 File Offset: 0x0000CCF0
		Friend Overridable Property Label19 As Label

		' Token: 0x17000676 RID: 1654
		' (get) Token: 0x06000FE7 RID: 4071 RVA: 0x0000EAF9 File Offset: 0x0000CCF9
		' (set) Token: 0x06000FE8 RID: 4072 RVA: 0x0000EB03 File Offset: 0x0000CD03
		Friend Overridable Property Label18 As Label

		' Token: 0x17000677 RID: 1655
		' (get) Token: 0x06000FE9 RID: 4073 RVA: 0x0000EB0C File Offset: 0x0000CD0C
		' (set) Token: 0x06000FEA RID: 4074 RVA: 0x0000EB16 File Offset: 0x0000CD16
		Friend Overridable Property txtEcomCID As TextBox

		' Token: 0x17000678 RID: 1656
		' (get) Token: 0x06000FEB RID: 4075 RVA: 0x0000EB1F File Offset: 0x0000CD1F
		' (set) Token: 0x06000FEC RID: 4076 RVA: 0x0000EB29 File Offset: 0x0000CD29
		Friend Overridable Property txtSubCategory As TextBox

		' Token: 0x17000679 RID: 1657
		' (get) Token: 0x06000FED RID: 4077 RVA: 0x0000EB32 File Offset: 0x0000CD32
		' (set) Token: 0x06000FEE RID: 4078 RVA: 0x0000EB3C File Offset: 0x0000CD3C
		Friend Overridable Property txtCategory As TextBox

		' Token: 0x1700067A RID: 1658
		' (get) Token: 0x06000FEF RID: 4079 RVA: 0x0000EB45 File Offset: 0x0000CD45
		' (set) Token: 0x06000FF0 RID: 4080 RVA: 0x0000EB4F File Offset: 0x0000CD4F
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x1700067B RID: 1659
		' (get) Token: 0x06000FF1 RID: 4081 RVA: 0x0000EB58 File Offset: 0x0000CD58
		' (set) Token: 0x06000FF2 RID: 4082 RVA: 0x0000EB62 File Offset: 0x0000CD62
		Friend Overridable Property txtSubCategoryID As TextBox

		' Token: 0x1700067C RID: 1660
		' (get) Token: 0x06000FF3 RID: 4083 RVA: 0x0000EB6B File Offset: 0x0000CD6B
		' (set) Token: 0x06000FF4 RID: 4084 RVA: 0x0000EB75 File Offset: 0x0000CD75
		Friend Overridable Property txtCategoryID As TextBox

		' Token: 0x1700067D RID: 1661
		' (get) Token: 0x06000FF5 RID: 4085 RVA: 0x0000EB7E File Offset: 0x0000CD7E
		' (set) Token: 0x06000FF6 RID: 4086 RVA: 0x0000EB88 File Offset: 0x0000CD88
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x1700067E RID: 1662
		' (get) Token: 0x06000FF7 RID: 4087 RVA: 0x0000EB91 File Offset: 0x0000CD91
		' (set) Token: 0x06000FF8 RID: 4088 RVA: 0x000BF4A8 File Offset: 0x000BD6A8
		Private _btnAdd As Button
		Public Overridable Property btnAdd As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAdd_Click
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

		' Token: 0x1700067F RID: 1663
		' (get) Token: 0x06000FF9 RID: 4089 RVA: 0x0000EB9B File Offset: 0x0000CD9B
		' (set) Token: 0x06000FFA RID: 4090 RVA: 0x0000EBA5 File Offset: 0x0000CDA5
		Friend Overridable Property txtDefMRP As TextBox

		' Token: 0x17000680 RID: 1664
		' (get) Token: 0x06000FFB RID: 4091 RVA: 0x0000EBAE File Offset: 0x0000CDAE
		' (set) Token: 0x06000FFC RID: 4092 RVA: 0x000BF4EC File Offset: 0x000BD6EC
		Private _btnRemove As Button
		Public Overridable Property btnRemove As Button
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

		' Token: 0x17000681 RID: 1665
		' (get) Token: 0x06000FFD RID: 4093 RVA: 0x0000EBB8 File Offset: 0x0000CDB8
		' (set) Token: 0x06000FFE RID: 4094 RVA: 0x0000EBC2 File Offset: 0x0000CDC2
		Friend Overridable Property Label14 As Label

		' Token: 0x17000682 RID: 1666
		' (get) Token: 0x06000FFF RID: 4095 RVA: 0x0000EBCB File Offset: 0x0000CDCB
		' (set) Token: 0x06001000 RID: 4096 RVA: 0x0000EBD5 File Offset: 0x0000CDD5
		Friend Overridable Property Label15 As Label

		' Token: 0x17000683 RID: 1667
		' (get) Token: 0x06001001 RID: 4097 RVA: 0x0000EBDE File Offset: 0x0000CDDE
		' (set) Token: 0x06001002 RID: 4098 RVA: 0x0000EBE8 File Offset: 0x0000CDE8
		Friend Overridable Property txtRSPrice As TextBox

		' Token: 0x17000684 RID: 1668
		' (get) Token: 0x06001003 RID: 4099 RVA: 0x0000EBF1 File Offset: 0x0000CDF1
		' (set) Token: 0x06001004 RID: 4100 RVA: 0x0000EBFB File Offset: 0x0000CDFB
		Friend Overridable Property Label17 As Label

		' Token: 0x17000685 RID: 1669
		' (get) Token: 0x06001005 RID: 4101 RVA: 0x0000EC04 File Offset: 0x0000CE04
		' (set) Token: 0x06001006 RID: 4102 RVA: 0x0000EC0E File Offset: 0x0000CE0E
		Friend Overridable Property txtDiscount As TextBox

		' Token: 0x17000686 RID: 1670
		' (get) Token: 0x06001007 RID: 4103 RVA: 0x0000EC17 File Offset: 0x0000CE17
		' (set) Token: 0x06001008 RID: 4104 RVA: 0x0000EC21 File Offset: 0x0000CE21
		Friend Overridable Property Label21 As Label

		' Token: 0x17000687 RID: 1671
		' (get) Token: 0x06001009 RID: 4105 RVA: 0x0000EC2A File Offset: 0x0000CE2A
		' (set) Token: 0x0600100A RID: 4106 RVA: 0x0000EC34 File Offset: 0x0000CE34
		Friend Overridable Property Label16 As Label

		' Token: 0x17000688 RID: 1672
		' (get) Token: 0x0600100B RID: 4107 RVA: 0x0000EC3D File Offset: 0x0000CE3D
		' (set) Token: 0x0600100C RID: 4108 RVA: 0x000BF530 File Offset: 0x000BD730
		Private _CheckBox2 As CheckBox
		Friend Overridable Property CheckBox2 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox2_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox2
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox2 = value
				checkBox = Me._CheckBox2
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000689 RID: 1673
		' (get) Token: 0x0600100D RID: 4109 RVA: 0x0000EC47 File Offset: 0x0000CE47
		' (set) Token: 0x0600100E RID: 4110 RVA: 0x000BF574 File Offset: 0x000BD774
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

		' Token: 0x1700068A RID: 1674
		' (get) Token: 0x0600100F RID: 4111 RVA: 0x0000EC51 File Offset: 0x0000CE51
		' (set) Token: 0x06001010 RID: 4112 RVA: 0x0000EC5B File Offset: 0x0000CE5B
		Friend Overridable Property Panel6 As Panel

		' Token: 0x1700068B RID: 1675
		' (get) Token: 0x06001011 RID: 4113 RVA: 0x0000EC64 File Offset: 0x0000CE64
		' (set) Token: 0x06001012 RID: 4114 RVA: 0x0000EC6E File Offset: 0x0000CE6E
		Friend Overridable Property txtUnit As TextBox

		' Token: 0x1700068C RID: 1676
		' (get) Token: 0x06001013 RID: 4115 RVA: 0x0000EC77 File Offset: 0x0000CE77
		' (set) Token: 0x06001014 RID: 4116 RVA: 0x0000EC81 File Offset: 0x0000CE81
		Friend Overridable Property txtFeatures As TextBox

		' Token: 0x1700068D RID: 1677
		' (get) Token: 0x06001015 RID: 4117 RVA: 0x0000EC8A File Offset: 0x0000CE8A
		' (set) Token: 0x06001016 RID: 4118 RVA: 0x0000EC94 File Offset: 0x0000CE94
		Friend Overridable Property Label13 As Label

		' Token: 0x1700068E RID: 1678
		' (get) Token: 0x06001017 RID: 4119 RVA: 0x0000EC9D File Offset: 0x0000CE9D
		' (set) Token: 0x06001018 RID: 4120 RVA: 0x0000ECA7 File Offset: 0x0000CEA7
		Friend Overridable Property cmbPpular As ComboBox

		' Token: 0x1700068F RID: 1679
		' (get) Token: 0x06001019 RID: 4121 RVA: 0x0000ECB0 File Offset: 0x0000CEB0
		' (set) Token: 0x0600101A RID: 4122 RVA: 0x0000ECBA File Offset: 0x0000CEBA
		Friend Overridable Property Label12 As Label

		' Token: 0x17000690 RID: 1680
		' (get) Token: 0x0600101B RID: 4123 RVA: 0x0000ECC3 File Offset: 0x0000CEC3
		' (set) Token: 0x0600101C RID: 4124 RVA: 0x0000ECCD File Offset: 0x0000CECD
		Friend Overridable Property cmbProductStatus As ComboBox

		' Token: 0x17000691 RID: 1681
		' (get) Token: 0x0600101D RID: 4125 RVA: 0x0000ECD6 File Offset: 0x0000CED6
		' (set) Token: 0x0600101E RID: 4126 RVA: 0x0000ECE0 File Offset: 0x0000CEE0
		Friend Overridable Property Label9 As Label

		' Token: 0x17000692 RID: 1682
		' (get) Token: 0x0600101F RID: 4127 RVA: 0x0000ECE9 File Offset: 0x0000CEE9
		' (set) Token: 0x06001020 RID: 4128 RVA: 0x0000ECF3 File Offset: 0x0000CEF3
		Friend Overridable Property cmbNotification As ComboBox

		' Token: 0x17000693 RID: 1683
		' (get) Token: 0x06001021 RID: 4129 RVA: 0x0000ECFC File Offset: 0x0000CEFC
		' (set) Token: 0x06001022 RID: 4130 RVA: 0x0000ED06 File Offset: 0x0000CF06
		Friend Overridable Property Label8 As Label

		' Token: 0x17000694 RID: 1684
		' (get) Token: 0x06001023 RID: 4131 RVA: 0x0000ED0F File Offset: 0x0000CF0F
		' (set) Token: 0x06001024 RID: 4132 RVA: 0x0000ED19 File Offset: 0x0000CF19
		Friend Overridable Property txtStock As TextBox

		' Token: 0x17000695 RID: 1685
		' (get) Token: 0x06001025 RID: 4133 RVA: 0x0000ED22 File Offset: 0x0000CF22
		' (set) Token: 0x06001026 RID: 4134 RVA: 0x0000ED2C File Offset: 0x0000CF2C
		Friend Overridable Property Label7 As Label

		' Token: 0x17000696 RID: 1686
		' (get) Token: 0x06001027 RID: 4135 RVA: 0x0000ED35 File Offset: 0x0000CF35
		' (set) Token: 0x06001028 RID: 4136 RVA: 0x0000ED3F File Offset: 0x0000CF3F
		Friend Overridable Property txtSellerName As TextBox

		' Token: 0x17000697 RID: 1687
		' (get) Token: 0x06001029 RID: 4137 RVA: 0x0000ED48 File Offset: 0x0000CF48
		' (set) Token: 0x0600102A RID: 4138 RVA: 0x0000ED52 File Offset: 0x0000CF52
		Friend Overridable Property Label6 As Label

		' Token: 0x17000698 RID: 1688
		' (get) Token: 0x0600102B RID: 4139 RVA: 0x0000ED5B File Offset: 0x0000CF5B
		' (set) Token: 0x0600102C RID: 4140 RVA: 0x0000ED65 File Offset: 0x0000CF65
		Friend Overridable Property Label4 As Label

		' Token: 0x17000699 RID: 1689
		' (get) Token: 0x0600102D RID: 4141 RVA: 0x0000ED6E File Offset: 0x0000CF6E
		' (set) Token: 0x0600102E RID: 4142 RVA: 0x0000ED78 File Offset: 0x0000CF78
		Friend Overridable Property Label1 As Label

		' Token: 0x1700069A RID: 1690
		' (get) Token: 0x0600102F RID: 4143 RVA: 0x0000ED81 File Offset: 0x0000CF81
		' (set) Token: 0x06001030 RID: 4144 RVA: 0x0000ED8B File Offset: 0x0000CF8B
		Public Overridable Property PictureBox1 As PictureBox

		' Token: 0x1700069B RID: 1691
		' (get) Token: 0x06001031 RID: 4145 RVA: 0x0000ED94 File Offset: 0x0000CF94
		' (set) Token: 0x06001032 RID: 4146 RVA: 0x0000ED9E File Offset: 0x0000CF9E
		Friend Overridable Property Button2 As Button

		' Token: 0x1700069C RID: 1692
		' (get) Token: 0x06001033 RID: 4147 RVA: 0x0000EDA7 File Offset: 0x0000CFA7
		' (set) Token: 0x06001034 RID: 4148 RVA: 0x0000EDB1 File Offset: 0x0000CFB1
		Public Overridable Property Picture As PictureBox

		' Token: 0x1700069D RID: 1693
		' (get) Token: 0x06001035 RID: 4149 RVA: 0x0000EDBA File Offset: 0x0000CFBA
		' (set) Token: 0x06001036 RID: 4150 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
		Friend Overridable Property BRemove As Button

		' Token: 0x1700069E RID: 1694
		' (get) Token: 0x06001037 RID: 4151 RVA: 0x0000EDCD File Offset: 0x0000CFCD
		' (set) Token: 0x06001038 RID: 4152 RVA: 0x0000EDD7 File Offset: 0x0000CFD7
		Friend Overridable Property cmbProductName As ComboBox

		' Token: 0x1700069F RID: 1695
		' (get) Token: 0x06001039 RID: 4153 RVA: 0x0000EDE0 File Offset: 0x0000CFE0
		' (set) Token: 0x0600103A RID: 4154 RVA: 0x0000EDEA File Offset: 0x0000CFEA
		Friend Overridable Property Label2 As Label

		' Token: 0x170006A0 RID: 1696
		' (get) Token: 0x0600103B RID: 4155 RVA: 0x0000EDF3 File Offset: 0x0000CFF3
		' (set) Token: 0x0600103C RID: 4156 RVA: 0x0000EDFD File Offset: 0x0000CFFD
		Friend Overridable Property txtEcomSubCID As TextBox

		' Token: 0x170006A1 RID: 1697
		' (get) Token: 0x0600103D RID: 4157 RVA: 0x0000EE06 File Offset: 0x0000D006
		' (set) Token: 0x0600103E RID: 4158 RVA: 0x0000EE10 File Offset: 0x0000D010
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170006A2 RID: 1698
		' (get) Token: 0x0600103F RID: 4159 RVA: 0x0000EE19 File Offset: 0x0000D019
		' (set) Token: 0x06001040 RID: 4160 RVA: 0x0000EE23 File Offset: 0x0000D023
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170006A3 RID: 1699
		' (get) Token: 0x06001041 RID: 4161 RVA: 0x0000EE2C File Offset: 0x0000D02C
		' (set) Token: 0x06001042 RID: 4162 RVA: 0x0000EE36 File Offset: 0x0000D036
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170006A4 RID: 1700
		' (get) Token: 0x06001043 RID: 4163 RVA: 0x0000EE3F File Offset: 0x0000D03F
		' (set) Token: 0x06001044 RID: 4164 RVA: 0x0000EE49 File Offset: 0x0000D049
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170006A5 RID: 1701
		' (get) Token: 0x06001045 RID: 4165 RVA: 0x0000EE52 File Offset: 0x0000D052
		' (set) Token: 0x06001046 RID: 4166 RVA: 0x0000EE5C File Offset: 0x0000D05C
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170006A6 RID: 1702
		' (get) Token: 0x06001047 RID: 4167 RVA: 0x0000EE65 File Offset: 0x0000D065
		' (set) Token: 0x06001048 RID: 4168 RVA: 0x0000EE6F File Offset: 0x0000D06F
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170006A7 RID: 1703
		' (get) Token: 0x06001049 RID: 4169 RVA: 0x0000EE78 File Offset: 0x0000D078
		' (set) Token: 0x0600104A RID: 4170 RVA: 0x0000EE82 File Offset: 0x0000D082
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170006A8 RID: 1704
		' (get) Token: 0x0600104B RID: 4171 RVA: 0x0000EE8B File Offset: 0x0000D08B
		' (set) Token: 0x0600104C RID: 4172 RVA: 0x0000EE95 File Offset: 0x0000D095
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170006A9 RID: 1705
		' (get) Token: 0x0600104D RID: 4173 RVA: 0x0000EE9E File Offset: 0x0000D09E
		' (set) Token: 0x0600104E RID: 4174 RVA: 0x0000EEA8 File Offset: 0x0000D0A8
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170006AA RID: 1706
		' (get) Token: 0x0600104F RID: 4175 RVA: 0x0000EEB1 File Offset: 0x0000D0B1
		' (set) Token: 0x06001050 RID: 4176 RVA: 0x0000EEBB File Offset: 0x0000D0BB
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170006AB RID: 1707
		' (get) Token: 0x06001051 RID: 4177 RVA: 0x0000EEC4 File Offset: 0x0000D0C4
		' (set) Token: 0x06001052 RID: 4178 RVA: 0x0000EECE File Offset: 0x0000D0CE
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170006AC RID: 1708
		' (get) Token: 0x06001053 RID: 4179 RVA: 0x0000EED7 File Offset: 0x0000D0D7
		' (set) Token: 0x06001054 RID: 4180 RVA: 0x0000EEE1 File Offset: 0x0000D0E1
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170006AD RID: 1709
		' (get) Token: 0x06001055 RID: 4181 RVA: 0x0000EEEA File Offset: 0x0000D0EA
		' (set) Token: 0x06001056 RID: 4182 RVA: 0x0000EEF4 File Offset: 0x0000D0F4
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170006AE RID: 1710
		' (get) Token: 0x06001057 RID: 4183 RVA: 0x0000EEFD File Offset: 0x0000D0FD
		' (set) Token: 0x06001058 RID: 4184 RVA: 0x0000EF07 File Offset: 0x0000D107
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170006AF RID: 1711
		' (get) Token: 0x06001059 RID: 4185 RVA: 0x0000EF10 File Offset: 0x0000D110
		' (set) Token: 0x0600105A RID: 4186 RVA: 0x0000EF1A File Offset: 0x0000D11A
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170006B0 RID: 1712
		' (get) Token: 0x0600105B RID: 4187 RVA: 0x0000EF23 File Offset: 0x0000D123
		' (set) Token: 0x0600105C RID: 4188 RVA: 0x0000EF2D File Offset: 0x0000D12D
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170006B1 RID: 1713
		' (get) Token: 0x0600105D RID: 4189 RVA: 0x0000EF36 File Offset: 0x0000D136
		' (set) Token: 0x0600105E RID: 4190 RVA: 0x0000EF40 File Offset: 0x0000D140
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170006B2 RID: 1714
		' (get) Token: 0x0600105F RID: 4191 RVA: 0x0000EF49 File Offset: 0x0000D149
		' (set) Token: 0x06001060 RID: 4192 RVA: 0x0000EF53 File Offset: 0x0000D153
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170006B3 RID: 1715
		' (get) Token: 0x06001061 RID: 4193 RVA: 0x0000EF5C File Offset: 0x0000D15C
		' (set) Token: 0x06001062 RID: 4194 RVA: 0x0000EF66 File Offset: 0x0000D166
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170006B4 RID: 1716
		' (get) Token: 0x06001063 RID: 4195 RVA: 0x0000EF6F File Offset: 0x0000D16F
		' (set) Token: 0x06001064 RID: 4196 RVA: 0x0000EF79 File Offset: 0x0000D179
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170006B5 RID: 1717
		' (get) Token: 0x06001065 RID: 4197 RVA: 0x0000EF82 File Offset: 0x0000D182
		' (set) Token: 0x06001066 RID: 4198 RVA: 0x0000EF8C File Offset: 0x0000D18C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170006B6 RID: 1718
		' (get) Token: 0x06001067 RID: 4199 RVA: 0x0000EF95 File Offset: 0x0000D195
		' (set) Token: 0x06001068 RID: 4200 RVA: 0x0000EF9F File Offset: 0x0000D19F
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170006B7 RID: 1719
		' (get) Token: 0x06001069 RID: 4201 RVA: 0x0000EFA8 File Offset: 0x0000D1A8
		' (set) Token: 0x0600106A RID: 4202 RVA: 0x000BF5B8 File Offset: 0x000BD7B8
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170006B8 RID: 1720
		' (get) Token: 0x0600106B RID: 4203 RVA: 0x0000EFB2 File Offset: 0x0000D1B2
		' (set) Token: 0x0600106C RID: 4204 RVA: 0x0000EFBC File Offset: 0x0000D1BC
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170006B9 RID: 1721
		' (get) Token: 0x0600106D RID: 4205 RVA: 0x0000EFC5 File Offset: 0x0000D1C5
		' (set) Token: 0x0600106E RID: 4206 RVA: 0x0000EFCF File Offset: 0x0000D1CF
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170006BA RID: 1722
		' (get) Token: 0x0600106F RID: 4207 RVA: 0x0000EFD8 File Offset: 0x0000D1D8
		' (set) Token: 0x06001070 RID: 4208 RVA: 0x0000EFE2 File Offset: 0x0000D1E2
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170006BB RID: 1723
		' (get) Token: 0x06001071 RID: 4209 RVA: 0x0000EFEB File Offset: 0x0000D1EB
		' (set) Token: 0x06001072 RID: 4210 RVA: 0x0000EFF5 File Offset: 0x0000D1F5
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170006BC RID: 1724
		' (get) Token: 0x06001073 RID: 4211 RVA: 0x0000EFFE File Offset: 0x0000D1FE
		' (set) Token: 0x06001074 RID: 4212 RVA: 0x0000F008 File Offset: 0x0000D208
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170006BD RID: 1725
		' (get) Token: 0x06001075 RID: 4213 RVA: 0x0000F011 File Offset: 0x0000D211
		' (set) Token: 0x06001076 RID: 4214 RVA: 0x0000F01B File Offset: 0x0000D21B
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170006BE RID: 1726
		' (get) Token: 0x06001077 RID: 4215 RVA: 0x0000F024 File Offset: 0x0000D224
		' (set) Token: 0x06001078 RID: 4216 RVA: 0x0000F02E File Offset: 0x0000D22E
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170006BF RID: 1727
		' (get) Token: 0x06001079 RID: 4217 RVA: 0x0000F037 File Offset: 0x0000D237
		' (set) Token: 0x0600107A RID: 4218 RVA: 0x0000F041 File Offset: 0x0000D241
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170006C0 RID: 1728
		' (get) Token: 0x0600107B RID: 4219 RVA: 0x0000F04A File Offset: 0x0000D24A
		' (set) Token: 0x0600107C RID: 4220 RVA: 0x0000F054 File Offset: 0x0000D254
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170006C1 RID: 1729
		' (get) Token: 0x0600107D RID: 4221 RVA: 0x0000F05D File Offset: 0x0000D25D
		' (set) Token: 0x0600107E RID: 4222 RVA: 0x0000F067 File Offset: 0x0000D267
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170006C2 RID: 1730
		' (get) Token: 0x0600107F RID: 4223 RVA: 0x0000F070 File Offset: 0x0000D270
		' (set) Token: 0x06001080 RID: 4224 RVA: 0x0000F07A File Offset: 0x0000D27A
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170006C3 RID: 1731
		' (get) Token: 0x06001081 RID: 4225 RVA: 0x0000F083 File Offset: 0x0000D283
		' (set) Token: 0x06001082 RID: 4226 RVA: 0x0000F08D File Offset: 0x0000D28D
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x170006C4 RID: 1732
		' (get) Token: 0x06001083 RID: 4227 RVA: 0x0000F096 File Offset: 0x0000D296
		' (set) Token: 0x06001084 RID: 4228 RVA: 0x0000F0A0 File Offset: 0x0000D2A0
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170006C5 RID: 1733
		' (get) Token: 0x06001085 RID: 4229 RVA: 0x0000F0A9 File Offset: 0x0000D2A9
		' (set) Token: 0x06001086 RID: 4230 RVA: 0x0000F0B3 File Offset: 0x0000D2B3
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x170006C6 RID: 1734
		' (get) Token: 0x06001087 RID: 4231 RVA: 0x0000F0BC File Offset: 0x0000D2BC
		' (set) Token: 0x06001088 RID: 4232 RVA: 0x0000F0C6 File Offset: 0x0000D2C6
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x170006C7 RID: 1735
		' (get) Token: 0x06001089 RID: 4233 RVA: 0x0000F0CF File Offset: 0x0000D2CF
		' (set) Token: 0x0600108A RID: 4234 RVA: 0x0000F0D9 File Offset: 0x0000D2D9
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x170006C8 RID: 1736
		' (get) Token: 0x0600108B RID: 4235 RVA: 0x0000F0E2 File Offset: 0x0000D2E2
		' (set) Token: 0x0600108C RID: 4236 RVA: 0x0000F0EC File Offset: 0x0000D2EC
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x170006C9 RID: 1737
		' (get) Token: 0x0600108D RID: 4237 RVA: 0x0000F0F5 File Offset: 0x0000D2F5
		' (set) Token: 0x0600108E RID: 4238 RVA: 0x0000F0FF File Offset: 0x0000D2FF
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x170006CA RID: 1738
		' (get) Token: 0x0600108F RID: 4239 RVA: 0x0000F108 File Offset: 0x0000D308
		' (set) Token: 0x06001090 RID: 4240 RVA: 0x0000F112 File Offset: 0x0000D312
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x170006CB RID: 1739
		' (get) Token: 0x06001091 RID: 4241 RVA: 0x0000F11B File Offset: 0x0000D31B
		' (set) Token: 0x06001092 RID: 4242 RVA: 0x0000F125 File Offset: 0x0000D325
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x170006CC RID: 1740
		' (get) Token: 0x06001093 RID: 4243 RVA: 0x0000F12E File Offset: 0x0000D32E
		' (set) Token: 0x06001094 RID: 4244 RVA: 0x0000F138 File Offset: 0x0000D338
		Friend Overridable Property Column42 As DataGridViewCheckBoxColumn

		' Token: 0x170006CD RID: 1741
		' (get) Token: 0x06001095 RID: 4245 RVA: 0x0000F141 File Offset: 0x0000D341
		' (set) Token: 0x06001096 RID: 4246 RVA: 0x0000F14B File Offset: 0x0000D34B
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x170006CE RID: 1742
		' (get) Token: 0x06001097 RID: 4247 RVA: 0x0000F154 File Offset: 0x0000D354
		' (set) Token: 0x06001098 RID: 4248 RVA: 0x0000F15E File Offset: 0x0000D35E
		Friend Overridable Property Label10 As Label

		' Token: 0x170006CF RID: 1743
		' (get) Token: 0x06001099 RID: 4249 RVA: 0x0000F167 File Offset: 0x0000D367
		' (set) Token: 0x0600109A RID: 4250 RVA: 0x000BF618 File Offset: 0x000BD818
		Private _txtSearchBarcode As TextBox
		Friend Overridable Property txtSearchBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBarcode_KeyDown
				Dim textBox As TextBox = Me._txtSearchBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSearchBarcode = value
				textBox = Me._txtSearchBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170006D0 RID: 1744
		' (get) Token: 0x0600109B RID: 4251 RVA: 0x0000F171 File Offset: 0x0000D371
		' (set) Token: 0x0600109C RID: 4252 RVA: 0x0000F17B File Offset: 0x0000D37B
		Friend Overridable Property Label5 As Label

		' Token: 0x170006D1 RID: 1745
		' (get) Token: 0x0600109D RID: 4253 RVA: 0x0000F184 File Offset: 0x0000D384
		' (set) Token: 0x0600109E RID: 4254 RVA: 0x000BF65C File Offset: 0x000BD85C
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

		' Token: 0x170006D2 RID: 1746
		' (get) Token: 0x0600109F RID: 4255 RVA: 0x0000F18E File Offset: 0x0000D38E
		' (set) Token: 0x060010A0 RID: 4256 RVA: 0x0000F198 File Offset: 0x0000D398
		Friend Overridable Property Label3 As Label

		' Token: 0x170006D3 RID: 1747
		' (get) Token: 0x060010A1 RID: 4257 RVA: 0x0000F1A1 File Offset: 0x0000D3A1
		' (set) Token: 0x060010A2 RID: 4258 RVA: 0x0000F1AB File Offset: 0x0000D3AB
		Friend Overridable Property Label11 As Label

		' Token: 0x060010A3 RID: 4259 RVA: 0x000BF6A0 File Offset: 0x000BD8A0
		Private Sub txtProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and ProductName like N'", Me.txtProductName.Text, "%' order by ProductName" }), ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060010A4 RID: 4260 RVA: 0x000BFA54 File Offset: 0x000BDC54
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Temp_Stock.Barcode like N'", Me.txtSearchBarcode.Text, "' order by ProductName" }), ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060010A5 RID: 4261 RVA: 0x0000F1B4 File Offset: 0x0000D3B4
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x060010A6 RID: 4262 RVA: 0x000BFE08 File Offset: 0x000BE008
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtPid.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtCategory.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtSubCategory.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.GetLocalCatID(dataGridViewRow.Cells(4).Value.ToString(), dataGridViewRow.Cells(5).Value.ToString())
					Me.GetECommID(dataGridViewRow.Cells(4).Value.ToString(), dataGridViewRow.Cells(5).Value.ToString())
					Me.txtFeatures.Text = dataGridViewRow.Cells(8).Value.ToString().Trim() + dataGridViewRow.Cells(4).Value.ToString().Trim() + dataGridViewRow.Cells(5).Value.ToString().Trim() + dataGridViewRow.Cells(7).Value.ToString().Trim()
					Dim text As String = dataGridViewRow.Cells(29).Value.ToString()
					Dim text2 As String = dataGridViewRow.Cells(19).Value.ToString()
					Dim text3 As String = dataGridViewRow.Cells(29).Value.ToString() + " " + dataGridViewRow.Cells(19).Value.ToString()
					Me.txtUnit.Text = text3
					Me.txtDiscount.Text = dataGridViewRow.Cells(11).Value.ToString()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT Temp_Stock.SuplName,Temp_Stock.MRP,Temp_Stock.SPrice,Temp_Stock.Barcode,Temp_Stock.Qty from Product,Temp_Stock where Product.PID=Temp_Stock.ProductID and Product.PID=@d1", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(0).Value.ToString())
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.txtSellerName.Text = Conversions.ToString(ModCommonClasses.rdr(0))
						Me.txtDefMRP.Text = Conversions.ToString(ModCommonClasses.rdr(1))
						Me.txtRSPrice.Text = Conversions.ToString(ModCommonClasses.rdr(2))
						Me.txtBarcode.Text = Conversions.ToString(ModCommonClasses.rdr(3))
						Me.txtStock.Text = Conversions.ToString(ModCommonClasses.rdr(4))
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT Photo from Product,Product_Join where Product.PID=Product_Join.ProductID and Product.PID=@d1", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(0).Value.ToString())
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim array As Byte() = CType(ModCommonClasses.rdr(0), Byte())
						Dim memoryStream As MemoryStream = New MemoryStream(array)
						Dim image As Image = Image.FromStream(memoryStream)
						Me.Picture.Image = image
						Me.DataGridView1.Rows.Add(New Object() { image })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060010A7 RID: 4263 RVA: 0x000C028C File Offset: 0x000BE48C
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x060010A8 RID: 4264 RVA: 0x000C02B4 File Offset: 0x000BE4B4
		Public Sub GetLocalCatID(CID As String, SID As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "select Category.ID AS CID,SubCategory.ID AS SID from Category INNER JOIN SubCategory ON Category.CategoryName = @d1 AND SubCategory.SubCategoryName = @d2"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", CID)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", SID)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCategoryID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.txtSubCategoryID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
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

		' Token: 0x060010A9 RID: 4265 RVA: 0x000C03EC File Offset: 0x000BE5EC
		Public Sub GetECommID(CNAME As String, SNAME As String)
			Try
				Dim stringBuilder As StringBuilder = New StringBuilder()
				stringBuilder.Clear()
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
				Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/get-category-id?"
				stringBuilder.Append(text)
				stringBuilder.Append("CNAME=" + CNAME)
				stringBuilder.Append("&SNAME=" + SNAME)
				Dim text2 As String = stringBuilder.ToString().Trim()
				Dim webRequest As WebRequest = WebRequest.Create(text2)
				Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
				httpWebRequest.Method = "GET"
				httpWebRequest.ContentType = "application/json"
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text3 As String = streamReader.ReadToEnd()
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(text3)
					Dim memoryStream As MemoryStream = New MemoryStream(bytes)
					Dim dataContractJsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(ECOMMDATA))
					Dim ecommdata As ECOMMDATA = CType(dataContractJsonSerializer.ReadObject(memoryStream), ECOMMDATA)
					Dim flag As Boolean = Conversions.ToBoolean(ecommdata.success)
					If flag Then
						Me.txtEcomCID.Text = ecommdata.CID
						Me.txtEcomSubCID.Text = ecommdata.SID
					Else
						MessageBox.Show(ecommdata.message)
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060010AA RID: 4266 RVA: 0x000C05B8 File Offset: 0x000BE7B8
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Me.DataGridView1.Rows.Remove(dataGridViewRow)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Try
				For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
					Me.DataGridView1.Rows.Remove(dataGridViewRow2)
				Next
			Finally
				Dim enumerator2 As IEnumerator
				If TypeOf enumerator2 Is IDisposable Then
					TryCast(enumerator2, IDisposable).Dispose()
				End If
			End Try
			Me.DataGridView1.Rows.Add(New Object() { Me.Picture.Image })
		End Sub

		' Token: 0x060010AB RID: 4267 RVA: 0x000C06B4 File Offset: 0x000BE8B4
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
				Me.btnRemove.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060010AC RID: 4268 RVA: 0x000C0768 File Offset: 0x000BE968
		Private Sub EcomClick(mode As String)
			Try
				Dim flag As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\Images")
				If flag Then
					Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\Images\")
				End If
				Dim flag2 As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\Images\product")
				If flag2 Then
					Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\Images\product\")
				End If
				Dim text As String = ""
				text = Guid.NewGuid().ToString() + "_tmpp.png"
				Dim text2 As String = MyProject.Application.Info.DirectoryPath + "\Images\product\" + text
				Me.Panel6.BackgroundImage = Me.Picture.Image
				Using bitmap As Bitmap = New Bitmap(Me.Panel6.Width, Me.Panel6.Height)
					Me.Panel6.DrawToBitmap(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
					bitmap.Save(text2)
				End Using
				Dim text3 As String = "../images/product/" + text
				Dim flag3 As Boolean = Me.cmbProductStatus.Text.Equals("Yes")
				Dim text4 As String
				If flag3 Then
					text4 = "1"
				Else
					text4 = "0"
				End If
				Dim flag4 As Boolean = Me.cmbPpular.Text.Equals("Publish")
				Dim text5 As String
				If flag4 Then
					text5 = "1"
				Else
					text5 = "0"
				End If
				Dim flag5 As Boolean = Operators.CompareString(mode, "B", False) = 0
				If flag5 Then
					Me.sb.Append(Me.txtPid.Text + ",")
					Me.sb.Append(Me.cmbProductName.Text + ",")
					Me.sb.Append(Me.txtSellerName.Text + ",")
					Me.sb.Append(Me.txtEcomCID.Text + ",")
					Me.sb.Append(Me.txtEcomSubCID.Text + ",")
					Me.sb.Append(Me.txtFeatures.Text + ",")
					Me.sb.Append(Me.txtUnit.Text + ",")
					Me.sb.Append(Me.txtDefMRP.Text + ",")
					Me.sb.Append(Me.txtRSPrice.Text + ",")
					Me.sb.Append(text4 + ",")
					Me.sb.Append(Me.txtStock.Text + ",")
					Me.sb.Append(text3 + ",")
					Me.sb.Append(text3 + ",")
					Me.sb.Append(Conversions.ToString(DateTime.Now) + ",")
					Me.sb.Append(Me.txtDiscount.Text + ",")
					Me.sb.Append(text5 + ",")
					Me.sb.Append(Me.txtBarcode.Text + ",")
					Me.sb.Append(mode + ",")
					Me.sb.Append(text + "|")
					Me.lstBuld.Add(Me.sb.ToString())
					Me.sb.Clear()
				Else
					Me.InsProduct(Me.txtPid.Text, Me.cmbProductName.Text, Me.txtSellerName.Text, Me.txtEcomCID.Text, Me.txtEcomSubCID.Text, Me.txtFeatures.Text, Me.txtUnit.Text, Me.txtDefMRP.Text, Me.txtRSPrice.Text, Me.cmbProductStatus.Text, Me.txtStock.Text, text3, text3, DateTime.Now, Me.txtDiscount.Text, Me.cmbPpular.Text, Me.txtBarcode.Text, mode, text)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060010AD RID: 4269 RVA: 0x000C0C9C File Offset: 0x000BEE9C
		Private Sub btnEcomPost_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.txtEcomCID.Text.Equals("") Or Me.txtEcomSubCID.Text.Equals("")
				If flag Then
					MessageBox.Show("Caregory and Sub category can not be empty")
				Else
					Me.EcomClick("i")
					MessageBox.Show("Succesfully insert")
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x060010AE RID: 4270 RVA: 0x000C0D30 File Offset: 0x000BEF30
		Public Sub InsProduct(id As String, pname As String, sname As String, cid As String, sid As String, psdesc As String, pgms As String, pprice As String, sprice As String, status As String, stock As String, pimg As String, prel As String, dtt As DateTime, discount As String, popular As String, barcode As String, mode As String, filename As String)
			Try
				Dim text As String = MyProject.Application.Info.DirectoryPath + "\Images\product\"
				Dim stringBuilder As StringBuilder = New StringBuilder()
				Dim flag As Boolean = Me.cmbProductStatus.Text.Equals("Yes")
				If flag Then
					status = "1"
				Else
					status = "0"
				End If
				Dim flag2 As Boolean = Me.cmbPpular.Text.Equals("Publish")
				If flag2 Then
					popular = "1"
				Else
					popular = "0"
				End If
				stringBuilder.Clear()
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
				Dim text2 As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/ins-product?"
				stringBuilder.Append(text2)
				stringBuilder.Append("id=" + id)
				stringBuilder.Append("&pname=" + pname)
				stringBuilder.Append("&sname=" + sname)
				stringBuilder.Append("&cid=" + cid)
				stringBuilder.Append("&sid=" + sid)
				stringBuilder.Append("&psdesc=" + psdesc)
				stringBuilder.Append("&pgms=" + pgms)
				stringBuilder.Append("&pprice=" + pprice)
				stringBuilder.Append("&sprice=" + sprice)
				stringBuilder.Append("&status=" + status)
				stringBuilder.Append("&stock=" + stock)
				stringBuilder.Append("&pimg=" + pimg)
				stringBuilder.Append("&prel=" + prel)
				stringBuilder.Append("&date=" + Conversions.ToString(dtt))
				stringBuilder.Append("&discount=" + discount)
				stringBuilder.Append("&popular=" + popular)
				stringBuilder.Append("&barcode=" + barcode)
				stringBuilder.Append("&mode=" + mode)
				Dim text3 As String = stringBuilder.ToString().Trim()
				Dim webRequest As WebRequest = WebRequest.Create(text3)
				Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
				httpWebRequest.Method = "GET"
				httpWebRequest.ContentType = "application/json"
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text4 As String = streamReader.ReadToEnd()
					Dim flag3 As Boolean = text4.Contains("true")
					If flag3 Then
						Dim text5 As String = dataTable.Rows(0)("FtpUrl").ToString()
						Dim text6 As String = dataTable.Rows(0)("FtpUser").ToString()
						Dim text7 As String = dataTable.Rows(0)("FtpPassword").ToString()
						Dim text8 As String = text + "/" + filename
						Me.UploadFileToFtp_fluent(text5, text6, text7, text8)
					Else
						Dim flag4 As Boolean = text4.Contains("Duplicate entry")
						If flag4 Then
							Dim dialogResult As DialogResult = MessageBox.Show(String.Concat(New String() { "Barcode ", barcode, vbCrLf & "and Product ", pname, " already exists, do want to update?" }), "Alert", MessageBoxButtons.YesNo)
							Dim flag5 As Boolean = dialogResult = DialogResult.Yes
							If flag5 Then
								Me.EcomClick("u")
							End If
						End If
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060010AF RID: 4271 RVA: 0x000C1124 File Offset: 0x000BF324
		Public Sub UploadFileToFtp_fluent(ftpUrl As String, ftpUsername As String, ftpPassword As String, filePath As String)
			Try
				Me.ftpClient = New FtpClient(ftpUrl, New NetworkCredential(ftpUsername, ftpPassword), 0, Nothing, Nothing)
				Me.ftpClient.Connect()
				Dim flag As Boolean = File.Exists(filePath)
				If flag Then
					Dim text As String = "/product/" + Path.GetFileName(filePath)
					Me.ftpClient.UploadFile(filePath, text, FtpRemoteExists.Overwrite, False, FtpVerify.None, Nothing)
					MessageBox.Show("File uploaded successfully.")
				Else
					MessageBox.Show("File does not exist.")
				End If
				Me.ftpClient.Disconnect()
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060010B0 RID: 4272 RVA: 0x0000F1BE File Offset: 0x0000D3BE
		Private Sub frmEProduct_Load(sender As Object, e As EventArgs)
			Me.cmbProductStatus.Text = "Yes"
			Me.cmbPpular.Text = "Publish"
			Me.Convert_Language()
		End Sub

		' Token: 0x060010B1 RID: 4273 RVA: 0x000C11E4 File Offset: 0x000BF3E4
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
						Me.UpdateControlsRecursive(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x060010B2 RID: 4274 RVA: 0x000C135C File Offset: 0x000BF55C
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

		' Token: 0x060010B3 RID: 4275 RVA: 0x000C1418 File Offset: 0x000BF618
		Private Sub UpdateControlsRecursive(parent As Control)
			Try
				For Each obj As Object In parent.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateControlsRecursive(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060010B4 RID: 4276 RVA: 0x000B726C File Offset: 0x000B546C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(dataGridViewColumn.HeaderText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(dataGridViewColumn.HeaderText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060010B5 RID: 4277 RVA: 0x000B72F4 File Offset: 0x000B54F4
		Private Sub UpdateListViewHeaders(lv As ListView)
			Try
				For Each obj As Object In lv.Columns
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
			Try
				For Each obj2 As Object In lv.Items
					Dim listViewItem As ListViewItem = CType(obj2, ListViewItem)
					Dim flag2 As Boolean = GlobalVariables.translations.ContainsKey(listViewItem.Text)
					If flag2 Then
						listViewItem.Text = GlobalVariables.translations(listViewItem.Text)
					End If
					Try
						For Each obj3 As Object In listViewItem.SubItems
							Dim listViewSubItem As ListViewItem.ListViewSubItem = CType(obj3, ListViewItem.ListViewSubItem)
							Dim flag3 As Boolean = GlobalVariables.translations.ContainsKey(listViewSubItem.Text)
							If flag3 Then
								listViewSubItem.Text = GlobalVariables.translations(listViewSubItem.Text)
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
		End Sub

		' Token: 0x060010B6 RID: 4278 RVA: 0x000C14C4 File Offset: 0x000BF6C4
		Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox2.Checked
			If checked Then
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Cells("Column42").Value = True
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Dim flag As Boolean = Not Me.CheckBox2.Checked
				If flag Then
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataGridViewRow2.Cells("Column42").Value = False
							dataGridViewRow2.DefaultCellStyle.BackColor = Color.White
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

		' Token: 0x060010B7 RID: 4279 RVA: 0x000C1600 File Offset: 0x000BF800
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim checked As Boolean = Me.CheckBox2.Checked
				If checked Then
					Me.lstBuld.Clear()
					Try
						For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("Column42").Value, True, False)
							If flag Then
								dataGridViewRow.Selected = True
								Me.PictureBox2.Visible = True
								Me.dgw.[ReadOnly] = True
								Me.RetrieveData()
								Me.EcomClick("B")
								Me.dgw.[ReadOnly] = False
								Me.PictureBox2.Visible = False
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim stringBuilder As StringBuilder = New StringBuilder()
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
					Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/ins-bulkproduct?"
					Try
						Dim text2 As String = JsonConvert.SerializeObject(Me.lstBuld)
						Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(text), HttpWebRequest)
						httpWebRequest.Method = "POST"
						httpWebRequest.ContentType = "application/json"
						httpWebRequest.ContentLength = CLng(text2.Length)
						Using streamWriter As StreamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
							streamWriter.Write(text2)
							streamWriter.Flush()
							streamWriter.Close()
						End Using
						Using httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
							Dim flag2 As Boolean = httpWebResponse.StatusCode = HttpStatusCode.OK
							If flag2 Then
								Using responseStream As Stream = httpWebResponse.GetResponseStream()
									Using streamReader As StreamReader = New StreamReader(responseStream)
										Dim text3 As String = streamReader.ReadToEnd()
										Dim list As List(Of Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(text3)
										Dim flag3 As Boolean = Conversions.ToBoolean(list(0)("success"))
										Dim text4 As String = Conversions.ToString(list(0)("message"))
										Dim objectValue As Object = RuntimeHelpers.GetObjectValue(list(0)("items"))
										Dim flag4 As Boolean = flag3
										If Not flag4 Then
											MessageBox.Show(text4)
										End If
									End Using
								End Using
							Else
								Dim text3 As String = "Error: " + httpWebResponse.StatusDescription
							End If
						End Using
					Catch ex As Exception
						Dim text3 As String = "Error: " + ex.Message
						MessageBox.Show(ex.Message)
					End Try
				Else
					MessageBox.Show("Please tick Mark all button for bulk message")
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message)
			End Try
		End Sub

		' Token: 0x060010B8 RID: 4280 RVA: 0x000C19B8 File Offset: 0x000BFBB8
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),(Product.Status),(Product.STax),(Product.PTax),(Product.GDown),(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),RTRIM(Product.Kitchen) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and SubCategoryName like N'", Me.TextBox1.Text, "%' order by ProductName" }), ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060010B9 RID: 4281 RVA: 0x000C1D6C File Offset: 0x000BFF6C
		Public Function PostDataToApi(apiUrl As String, data As List(Of String)) As String
			Dim text As String = ""
			Try
				Dim text2 As String = JsonConvert.SerializeObject(data)
				Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(apiUrl), HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "application/json"
				httpWebRequest.ContentLength = CLng(text2.Length)
				Using streamWriter As StreamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
					streamWriter.Write(text2)
					streamWriter.Flush()
					streamWriter.Close()
				End Using
				Using httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Dim flag As Boolean = httpWebResponse.StatusCode = HttpStatusCode.OK
					If flag Then
						Using responseStream As Stream = httpWebResponse.GetResponseStream()
							Using streamReader As StreamReader = New StreamReader(responseStream)
								text = streamReader.ReadToEnd()
								Dim flag2 As Boolean = text.Contains("true")
								If flag2 Then
									MessageBox.Show(text)
								End If
							End Using
						End Using
					Else
						text = "Error: " + httpWebResponse.StatusDescription
					End If
				End Using
			Catch ex As Exception
				text = "Error: " + ex.Message
			End Try
			Return text
		End Function

		' Token: 0x060010BA RID: 4282 RVA: 0x0000F1EA File Offset: 0x0000D3EA
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			FileSystem.Reset()
		End Sub

		' Token: 0x04000503 RID: 1283
		Private ftpClient As FtpClient

		' Token: 0x04000504 RID: 1284
		Private lstBuld As List(Of String)

		' Token: 0x04000505 RID: 1285
		Private sb As StringBuilder
	End Class
End Namespace
