Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports FireSharp
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000DE RID: 222
	<DesignerGenerated()>
	Public Partial Class frmCustomerMobileRpt
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002745 RID: 10053 RVA: 0x0018C3EC File Offset: 0x0018A5EC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerMobileRpt_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerMobileRpt_KeyDown
			Me.autoUpdateTimer = New Global.System.Windows.Forms.Timer()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000F6D RID: 3949
		' (get) Token: 0x06002748 RID: 10056 RVA: 0x00019E13 File Offset: 0x00018013
		' (set) Token: 0x06002749 RID: 10057 RVA: 0x00019E1D File Offset: 0x0001801D
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000F6E RID: 3950
		' (get) Token: 0x0600274A RID: 10058 RVA: 0x00019E26 File Offset: 0x00018026
		' (set) Token: 0x0600274B RID: 10059 RVA: 0x00019E30 File Offset: 0x00018030
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000F6F RID: 3951
		' (get) Token: 0x0600274C RID: 10060 RVA: 0x00019E39 File Offset: 0x00018039
		' (set) Token: 0x0600274D RID: 10061 RVA: 0x0018F57C File Offset: 0x0018D77C
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
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

		' Token: 0x17000F70 RID: 3952
		' (get) Token: 0x0600274E RID: 10062 RVA: 0x00019E43 File Offset: 0x00018043
		' (set) Token: 0x0600274F RID: 10063 RVA: 0x00019E4D File Offset: 0x0001804D
		Friend Overridable Property Label16 As Label

		' Token: 0x17000F71 RID: 3953
		' (get) Token: 0x06002750 RID: 10064 RVA: 0x00019E56 File Offset: 0x00018056
		' (set) Token: 0x06002751 RID: 10065 RVA: 0x00019E60 File Offset: 0x00018060
		Friend Overridable Property Label11 As Label

		' Token: 0x17000F72 RID: 3954
		' (get) Token: 0x06002752 RID: 10066 RVA: 0x00019E69 File Offset: 0x00018069
		' (set) Token: 0x06002753 RID: 10067 RVA: 0x00019E73 File Offset: 0x00018073
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17000F73 RID: 3955
		' (get) Token: 0x06002754 RID: 10068 RVA: 0x00019E7C File Offset: 0x0001807C
		' (set) Token: 0x06002755 RID: 10069 RVA: 0x00019E86 File Offset: 0x00018086
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17000F74 RID: 3956
		' (get) Token: 0x06002756 RID: 10070 RVA: 0x00019E8F File Offset: 0x0001808F
		' (set) Token: 0x06002757 RID: 10071 RVA: 0x0018F5C0 File Offset: 0x0018D7C0
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
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F75 RID: 3957
		' (get) Token: 0x06002758 RID: 10072 RVA: 0x00019E99 File Offset: 0x00018099
		' (set) Token: 0x06002759 RID: 10073 RVA: 0x00019EA3 File Offset: 0x000180A3
		Friend Overridable Property lblUser As Label

		' Token: 0x17000F76 RID: 3958
		' (get) Token: 0x0600275A RID: 10074 RVA: 0x00019EAC File Offset: 0x000180AC
		' (set) Token: 0x0600275B RID: 10075 RVA: 0x00019EB6 File Offset: 0x000180B6
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000F77 RID: 3959
		' (get) Token: 0x0600275C RID: 10076 RVA: 0x00019EBF File Offset: 0x000180BF
		' (set) Token: 0x0600275D RID: 10077 RVA: 0x00019EC9 File Offset: 0x000180C9
		Friend Overridable Property Label6 As Label

		' Token: 0x17000F78 RID: 3960
		' (get) Token: 0x0600275E RID: 10078 RVA: 0x00019ED2 File Offset: 0x000180D2
		' (set) Token: 0x0600275F RID: 10079 RVA: 0x00019EDC File Offset: 0x000180DC
		Friend Overridable Property Label3 As Label

		' Token: 0x17000F79 RID: 3961
		' (get) Token: 0x06002760 RID: 10080 RVA: 0x00019EE5 File Offset: 0x000180E5
		' (set) Token: 0x06002761 RID: 10081 RVA: 0x0018F63C File Offset: 0x0018D83C
		Private _btnNew As Button
		Friend Overridable Property btnNew As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim button As Button = Me._btnNew
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNew = value
				button = Me._btnNew
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F7A RID: 3962
		' (get) Token: 0x06002762 RID: 10082 RVA: 0x00019EEF File Offset: 0x000180EF
		' (set) Token: 0x06002763 RID: 10083 RVA: 0x0018F680 File Offset: 0x0018D880
		Private _btnSave As Button
		Friend Overridable Property btnSave As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim button As Button = Me._btnSave
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSave = value
				button = Me._btnSave
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F7B RID: 3963
		' (get) Token: 0x06002764 RID: 10084 RVA: 0x00019EF9 File Offset: 0x000180F9
		' (set) Token: 0x06002765 RID: 10085 RVA: 0x00019F03 File Offset: 0x00018103
		Friend Overridable Property Label5 As Label

		' Token: 0x17000F7C RID: 3964
		' (get) Token: 0x06002766 RID: 10086 RVA: 0x00019F0C File Offset: 0x0001810C
		' (set) Token: 0x06002767 RID: 10087 RVA: 0x00019F16 File Offset: 0x00018116
		Friend Overridable Property Label4 As Label

		' Token: 0x17000F7D RID: 3965
		' (get) Token: 0x06002768 RID: 10088 RVA: 0x00019F1F File Offset: 0x0001811F
		' (set) Token: 0x06002769 RID: 10089 RVA: 0x00019F29 File Offset: 0x00018129
		Friend Overridable Property Label2 As Label

		' Token: 0x17000F7E RID: 3966
		' (get) Token: 0x0600276A RID: 10090 RVA: 0x00019F32 File Offset: 0x00018132
		' (set) Token: 0x0600276B RID: 10091 RVA: 0x00019F3C File Offset: 0x0001813C
		Friend Overridable Property txtCID As TextBox

		' Token: 0x17000F7F RID: 3967
		' (get) Token: 0x0600276C RID: 10092 RVA: 0x00019F45 File Offset: 0x00018145
		' (set) Token: 0x0600276D RID: 10093 RVA: 0x0018F6C4 File Offset: 0x0018D8C4
		Private _txtCustID As TextBox
		Friend Overridable Property txtCustID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustID_TextChanged
				Dim textBox As TextBox = Me._txtCustID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustID = value
				textBox = Me._txtCustID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F80 RID: 3968
		' (get) Token: 0x0600276E RID: 10094 RVA: 0x00019F4F File Offset: 0x0001814F
		' (set) Token: 0x0600276F RID: 10095 RVA: 0x00019F59 File Offset: 0x00018159
		Friend Overridable Property txtCustContact As TextBox

		' Token: 0x17000F81 RID: 3969
		' (get) Token: 0x06002770 RID: 10096 RVA: 0x00019F62 File Offset: 0x00018162
		' (set) Token: 0x06002771 RID: 10097 RVA: 0x00019F6C File Offset: 0x0001816C
		Friend Overridable Property txtCustAddress As TextBox

		' Token: 0x17000F82 RID: 3970
		' (get) Token: 0x06002772 RID: 10098 RVA: 0x00019F75 File Offset: 0x00018175
		' (set) Token: 0x06002773 RID: 10099 RVA: 0x0018F708 File Offset: 0x0018D908
		Private _cmbCustomerName As ComboBox
		Friend Overridable Property cmbCustomerName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCustomerName_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCustomerName = value
				comboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F83 RID: 3971
		' (get) Token: 0x06002774 RID: 10100 RVA: 0x00019F7F File Offset: 0x0001817F
		' (set) Token: 0x06002775 RID: 10101 RVA: 0x00019F89 File Offset: 0x00018189
		Friend Overridable Property Label1 As Label

		' Token: 0x17000F84 RID: 3972
		' (get) Token: 0x06002776 RID: 10102 RVA: 0x00019F92 File Offset: 0x00018192
		' (set) Token: 0x06002777 RID: 10103 RVA: 0x00019F9C File Offset: 0x0001819C
		Friend Overridable Property Label7 As Label

		' Token: 0x17000F85 RID: 3973
		' (get) Token: 0x06002778 RID: 10104 RVA: 0x00019FA5 File Offset: 0x000181A5
		' (set) Token: 0x06002779 RID: 10105 RVA: 0x00019FAF File Offset: 0x000181AF
		Friend Overridable Property txtAndroidID As TextBox

		' Token: 0x17000F86 RID: 3974
		' (get) Token: 0x0600277A RID: 10106 RVA: 0x00019FB8 File Offset: 0x000181B8
		' (set) Token: 0x0600277B RID: 10107 RVA: 0x00019FC2 File Offset: 0x000181C2
		Friend Overridable Property PictureBox3 As PictureBox

		' Token: 0x17000F87 RID: 3975
		' (get) Token: 0x0600277C RID: 10108 RVA: 0x00019FCB File Offset: 0x000181CB
		' (set) Token: 0x0600277D RID: 10109 RVA: 0x00019FD5 File Offset: 0x000181D5
		Friend Overridable Property Label15 As Label

		' Token: 0x17000F88 RID: 3976
		' (get) Token: 0x0600277E RID: 10110 RVA: 0x00019FDE File Offset: 0x000181DE
		' (set) Token: 0x0600277F RID: 10111 RVA: 0x00019FE8 File Offset: 0x000181E8
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x17000F89 RID: 3977
		' (get) Token: 0x06002780 RID: 10112 RVA: 0x00019FF1 File Offset: 0x000181F1
		' (set) Token: 0x06002781 RID: 10113 RVA: 0x00019FFB File Offset: 0x000181FB
		Friend Overridable Property Label14 As Label

		' Token: 0x17000F8A RID: 3978
		' (get) Token: 0x06002782 RID: 10114 RVA: 0x0001A004 File Offset: 0x00018204
		' (set) Token: 0x06002783 RID: 10115 RVA: 0x0001A00E File Offset: 0x0001820E
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17000F8B RID: 3979
		' (get) Token: 0x06002784 RID: 10116 RVA: 0x0001A017 File Offset: 0x00018217
		' (set) Token: 0x06002785 RID: 10117 RVA: 0x0001A021 File Offset: 0x00018221
		Friend Overridable Property Label13 As Label

		' Token: 0x17000F8C RID: 3980
		' (get) Token: 0x06002786 RID: 10118 RVA: 0x0001A02A File Offset: 0x0001822A
		' (set) Token: 0x06002787 RID: 10119 RVA: 0x0001A034 File Offset: 0x00018234
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17000F8D RID: 3981
		' (get) Token: 0x06002788 RID: 10120 RVA: 0x0001A03D File Offset: 0x0001823D
		' (set) Token: 0x06002789 RID: 10121 RVA: 0x0001A047 File Offset: 0x00018247
		Friend Overridable Property Label12 As Label

		' Token: 0x17000F8E RID: 3982
		' (get) Token: 0x0600278A RID: 10122 RVA: 0x0001A050 File Offset: 0x00018250
		' (set) Token: 0x0600278B RID: 10123 RVA: 0x0001A05A File Offset: 0x0001825A
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17000F8F RID: 3983
		' (get) Token: 0x0600278C RID: 10124 RVA: 0x0001A063 File Offset: 0x00018263
		' (set) Token: 0x0600278D RID: 10125 RVA: 0x0001A06D File Offset: 0x0001826D
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17000F90 RID: 3984
		' (get) Token: 0x0600278E RID: 10126 RVA: 0x0001A076 File Offset: 0x00018276
		' (set) Token: 0x0600278F RID: 10127 RVA: 0x0001A080 File Offset: 0x00018280
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17000F91 RID: 3985
		' (get) Token: 0x06002790 RID: 10128 RVA: 0x0001A089 File Offset: 0x00018289
		' (set) Token: 0x06002791 RID: 10129 RVA: 0x0001A093 File Offset: 0x00018293
		Friend Overridable Property Label10 As Label

		' Token: 0x17000F92 RID: 3986
		' (get) Token: 0x06002792 RID: 10130 RVA: 0x0001A09C File Offset: 0x0001829C
		' (set) Token: 0x06002793 RID: 10131 RVA: 0x0001A0A6 File Offset: 0x000182A6
		Friend Overridable Property Label9 As Label

		' Token: 0x17000F93 RID: 3987
		' (get) Token: 0x06002794 RID: 10132 RVA: 0x0001A0AF File Offset: 0x000182AF
		' (set) Token: 0x06002795 RID: 10133 RVA: 0x0001A0B9 File Offset: 0x000182B9
		Friend Overridable Property Label8 As Label

		' Token: 0x17000F94 RID: 3988
		' (get) Token: 0x06002796 RID: 10134 RVA: 0x0001A0C2 File Offset: 0x000182C2
		' (set) Token: 0x06002797 RID: 10135 RVA: 0x0001A0CC File Offset: 0x000182CC
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17000F95 RID: 3989
		' (get) Token: 0x06002798 RID: 10136 RVA: 0x0001A0D5 File Offset: 0x000182D5
		' (set) Token: 0x06002799 RID: 10137 RVA: 0x0001A0DF File Offset: 0x000182DF
		Friend Overridable Property Label23 As Label

		' Token: 0x17000F96 RID: 3990
		' (get) Token: 0x0600279A RID: 10138 RVA: 0x0001A0E8 File Offset: 0x000182E8
		' (set) Token: 0x0600279B RID: 10139 RVA: 0x0001A0F2 File Offset: 0x000182F2
		Friend Overridable Property TextBox11 As TextBox

		' Token: 0x17000F97 RID: 3991
		' (get) Token: 0x0600279C RID: 10140 RVA: 0x0001A0FB File Offset: 0x000182FB
		' (set) Token: 0x0600279D RID: 10141 RVA: 0x0001A105 File Offset: 0x00018305
		Friend Overridable Property Label22 As Label

		' Token: 0x17000F98 RID: 3992
		' (get) Token: 0x0600279E RID: 10142 RVA: 0x0001A10E File Offset: 0x0001830E
		' (set) Token: 0x0600279F RID: 10143 RVA: 0x0001A118 File Offset: 0x00018318
		Friend Overridable Property Label21 As Label

		' Token: 0x17000F99 RID: 3993
		' (get) Token: 0x060027A0 RID: 10144 RVA: 0x0001A121 File Offset: 0x00018321
		' (set) Token: 0x060027A1 RID: 10145 RVA: 0x0001A12B File Offset: 0x0001832B
		Friend Overridable Property TextBox10 As TextBox

		' Token: 0x17000F9A RID: 3994
		' (get) Token: 0x060027A2 RID: 10146 RVA: 0x0001A134 File Offset: 0x00018334
		' (set) Token: 0x060027A3 RID: 10147 RVA: 0x0001A13E File Offset: 0x0001833E
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17000F9B RID: 3995
		' (get) Token: 0x060027A4 RID: 10148 RVA: 0x0001A147 File Offset: 0x00018347
		' (set) Token: 0x060027A5 RID: 10149 RVA: 0x0001A151 File Offset: 0x00018351
		Friend Overridable Property TextBox12 As TextBox

		' Token: 0x17000F9C RID: 3996
		' (get) Token: 0x060027A6 RID: 10150 RVA: 0x0001A15A File Offset: 0x0001835A
		' (set) Token: 0x060027A7 RID: 10151 RVA: 0x0001A164 File Offset: 0x00018364
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17000F9D RID: 3997
		' (get) Token: 0x060027A8 RID: 10152 RVA: 0x0001A16D File Offset: 0x0001836D
		' (set) Token: 0x060027A9 RID: 10153 RVA: 0x0001A177 File Offset: 0x00018377
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000F9E RID: 3998
		' (get) Token: 0x060027AA RID: 10154 RVA: 0x0001A180 File Offset: 0x00018380
		' (set) Token: 0x060027AB RID: 10155 RVA: 0x0001A18A File Offset: 0x0001838A
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000F9F RID: 3999
		' (get) Token: 0x060027AC RID: 10156 RVA: 0x0001A193 File Offset: 0x00018393
		' (set) Token: 0x060027AD RID: 10157 RVA: 0x0001A19D File Offset: 0x0001839D
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000FA0 RID: 4000
		' (get) Token: 0x060027AE RID: 10158 RVA: 0x0001A1A6 File Offset: 0x000183A6
		' (set) Token: 0x060027AF RID: 10159 RVA: 0x0001A1B0 File Offset: 0x000183B0
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000FA1 RID: 4001
		' (get) Token: 0x060027B0 RID: 10160 RVA: 0x0001A1B9 File Offset: 0x000183B9
		' (set) Token: 0x060027B1 RID: 10161 RVA: 0x0001A1C3 File Offset: 0x000183C3
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000FA2 RID: 4002
		' (get) Token: 0x060027B2 RID: 10162 RVA: 0x0001A1CC File Offset: 0x000183CC
		' (set) Token: 0x060027B3 RID: 10163 RVA: 0x0001A1D6 File Offset: 0x000183D6
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000FA3 RID: 4003
		' (get) Token: 0x060027B4 RID: 10164 RVA: 0x0001A1DF File Offset: 0x000183DF
		' (set) Token: 0x060027B5 RID: 10165 RVA: 0x0001A1E9 File Offset: 0x000183E9
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000FA4 RID: 4004
		' (get) Token: 0x060027B6 RID: 10166 RVA: 0x0001A1F2 File Offset: 0x000183F2
		' (set) Token: 0x060027B7 RID: 10167 RVA: 0x0001A1FC File Offset: 0x000183FC
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000FA5 RID: 4005
		' (get) Token: 0x060027B8 RID: 10168 RVA: 0x0001A205 File Offset: 0x00018405
		' (set) Token: 0x060027B9 RID: 10169 RVA: 0x0001A20F File Offset: 0x0001840F
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17000FA6 RID: 4006
		' (get) Token: 0x060027BA RID: 10170 RVA: 0x0001A218 File Offset: 0x00018418
		' (set) Token: 0x060027BB RID: 10171 RVA: 0x0001A222 File Offset: 0x00018422
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000FA7 RID: 4007
		' (get) Token: 0x060027BC RID: 10172 RVA: 0x0001A22B File Offset: 0x0001842B
		' (set) Token: 0x060027BD RID: 10173 RVA: 0x0001A235 File Offset: 0x00018435
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000FA8 RID: 4008
		' (get) Token: 0x060027BE RID: 10174 RVA: 0x0001A23E File Offset: 0x0001843E
		' (set) Token: 0x060027BF RID: 10175 RVA: 0x0001A248 File Offset: 0x00018448
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000FA9 RID: 4009
		' (get) Token: 0x060027C0 RID: 10176 RVA: 0x0001A251 File Offset: 0x00018451
		' (set) Token: 0x060027C1 RID: 10177 RVA: 0x0001A25B File Offset: 0x0001845B
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000FAA RID: 4010
		' (get) Token: 0x060027C2 RID: 10178 RVA: 0x0001A264 File Offset: 0x00018464
		' (set) Token: 0x060027C3 RID: 10179 RVA: 0x0001A26E File Offset: 0x0001846E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000FAB RID: 4011
		' (get) Token: 0x060027C4 RID: 10180 RVA: 0x0001A277 File Offset: 0x00018477
		' (set) Token: 0x060027C5 RID: 10181 RVA: 0x0001A281 File Offset: 0x00018481
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000FAC RID: 4012
		' (get) Token: 0x060027C6 RID: 10182 RVA: 0x0001A28A File Offset: 0x0001848A
		' (set) Token: 0x060027C7 RID: 10183 RVA: 0x0001A294 File Offset: 0x00018494
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000FAD RID: 4013
		' (get) Token: 0x060027C8 RID: 10184 RVA: 0x0001A29D File Offset: 0x0001849D
		' (set) Token: 0x060027C9 RID: 10185 RVA: 0x0001A2A7 File Offset: 0x000184A7
		Friend Overridable Property Column17 As DataGridViewImageColumn

		' Token: 0x17000FAE RID: 4014
		' (get) Token: 0x060027CA RID: 10186 RVA: 0x0001A2B0 File Offset: 0x000184B0
		' (set) Token: 0x060027CB RID: 10187 RVA: 0x0018F74C File Offset: 0x0018D94C
		Private _LinkLabel2 As LinkLabel
		Friend Overridable Property LinkLabel2 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel2_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel2 = value
				linkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FAF RID: 4015
		' (get) Token: 0x060027CC RID: 10188 RVA: 0x0001A2BA File Offset: 0x000184BA
		' (set) Token: 0x060027CD RID: 10189 RVA: 0x0018F790 File Offset: 0x0018D990
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

		' Token: 0x17000FB0 RID: 4016
		' (get) Token: 0x060027CE RID: 10190 RVA: 0x0001A2C4 File Offset: 0x000184C4
		' (set) Token: 0x060027CF RID: 10191 RVA: 0x0018F7D4 File Offset: 0x0018D9D4
		Private _LinkLabel3 As LinkLabel
		Friend Overridable Property LinkLabel3 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel3_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel3 = value
				linkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FB1 RID: 4017
		' (get) Token: 0x060027D0 RID: 10192 RVA: 0x0001A2CE File Offset: 0x000184CE
		' (set) Token: 0x060027D1 RID: 10193 RVA: 0x0018F818 File Offset: 0x0018DA18
		Private _LinkLabel4 As LinkLabel
		Friend Overridable Property LinkLabel4 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel4_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel4
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel4 = value
				linkLabel = Me._LinkLabel4
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FB2 RID: 4018
		' (get) Token: 0x060027D2 RID: 10194 RVA: 0x0001A2D8 File Offset: 0x000184D8
		' (set) Token: 0x060027D3 RID: 10195 RVA: 0x0018F85C File Offset: 0x0018DA5C
		Private _LinkLabel5 As LinkLabel
		Friend Overridable Property LinkLabel5 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel5_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel5
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel5 = value
				linkLabel = Me._LinkLabel5
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FB3 RID: 4019
		' (get) Token: 0x060027D4 RID: 10196 RVA: 0x0001A2E2 File Offset: 0x000184E2
		' (set) Token: 0x060027D5 RID: 10197 RVA: 0x0001A2EC File Offset: 0x000184EC
		Friend Overridable Property Label18 As Label

		' Token: 0x17000FB4 RID: 4020
		' (get) Token: 0x060027D6 RID: 10198 RVA: 0x0001A2F5 File Offset: 0x000184F5
		' (set) Token: 0x060027D7 RID: 10199 RVA: 0x0001A2FF File Offset: 0x000184FF
		Friend Overridable Property Label17 As Label

		' Token: 0x17000FB5 RID: 4021
		' (get) Token: 0x060027D8 RID: 10200 RVA: 0x0001A308 File Offset: 0x00018508
		' (set) Token: 0x060027D9 RID: 10201 RVA: 0x0001A312 File Offset: 0x00018512
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x060027DA RID: 10202 RVA: 0x0018F8A0 File Offset: 0x0018DAA0
		Private Sub frmCustomerMobileRpt_Load(sender As Object, e As EventArgs)
			Me.FillCustomers()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Try
				Dim qrcodeEncoder As QRCodeEncoder = New QRCodeEncoder()
				qrcodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
				qrcodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
				Me.PictureBox1.Image = qrcodeEncoder.Encode("https://drive.google.com/file/d/1GMIwqFRxkSN0WHnlxMK1K5Eo0uYZNyqZ/view?usp=sharing", Encoding.UTF8)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060027DB RID: 10203 RVA: 0x0018F980 File Offset: 0x0018DB80
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

		' Token: 0x060027DC RID: 10204 RVA: 0x0018FA68 File Offset: 0x0018DC68
		Public Sub FillCustomers()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(Name) from Customer where Name not in ('Cash') order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbCustomerName.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbCustomerName.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060027DD RID: 10205 RVA: 0x0018FB5C File Offset: 0x0018DD5C
		Private Sub cmbCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ID, RTRIM(CustomerID),RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN), RTRIM(EmailID), RTRIM(PAN),RTRIM(Tcs),RTRIM(CardNo),RTRIM(Status),RTRIM(Limit),RTRIM(Lstatus),RTRIM(Address),DiscPer,RTRIM(DiscStatus) from Customer where Name=@d1 order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.txtCustID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtCustContact.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtCustAddress.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.TextBox9.Text = ModCommonClasses.rdr.GetValue(8).ToString()
				Else
					Me.TextBox9.Text = "Not Provided"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.AndroidIDGenerate()
		End Sub

		' Token: 0x060027DE RID: 10206 RVA: 0x0018FCE8 File Offset: 0x0018DEE8
		Private Sub AndroidIDGenerate()
			Me.txtAndroidID.Text = ModFunc.MD5Encrypt(Me.txtCustID.Text.TrimEnd(New Char(-1) {}).ToString() + Me.txtCustContact.Text.TrimEnd(New Char(-1) {}).ToString())
			Try
				Dim qrcodeEncoder As QRCodeEncoder = New QRCodeEncoder()
				qrcodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
				qrcodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
				Me.PictureBox3.Image = qrcodeEncoder.Encode(Me.txtAndroidID.Text, Encoding.UTF8)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060027DF RID: 10207 RVA: 0x0018FDA0 File Offset: 0x0018DFA0
		Private Sub Coupon_Details()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = ModCommonClasses.con1.CreateCommand()
				ModCommonClasses.cmd1.CommandText = "SELECT (OfferAmt),(ValidFrom),(ValidUpto),RTRIM(OfferStatus),RTRIM(CouponCode),RTRIM(CouponStatus),(IssueDate) from Coupondb where CustomerID=@d1 order by IssueDate DESC"
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.txtCustID.Text.ToString())
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr1.Read()
				If flag Then
					Me.TextBox1.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Nothing, GetType(Math), "Round", New Object() { ModCommonClasses.rdr1.GetValue(0), 2 }, Nothing, Nothing, Nothing)), "0.00")
					Me.TextBox2.Text = ModCommonClasses.rdr1.GetValue(1).ToString().Substring(0, 10)
					Me.TextBox4.Text = ModCommonClasses.rdr1.GetValue(2).ToString().Substring(0, 10)
					Me.TextBox5.Text = ModCommonClasses.rdr1.GetValue(3).ToString()
					Me.TextBox6.Text = ModCommonClasses.rdr1.GetValue(4).ToString()
					Me.TextBox7.Text = ModCommonClasses.rdr1.GetValue(5).ToString()
					Me.TextBox8.Text = ModCommonClasses.rdr1.GetValue(6).ToString().Substring(0, 10)
				Else
					Me.TextBox1.Text = "0.00"
					Me.TextBox2.Text = "NA"
					Me.TextBox4.Text = "NA"
					Me.TextBox5.Text = "NA"
					Me.TextBox6.Text = "NA"
					Me.TextBox7.Text = "NA"
					Me.TextBox8.Text = "NA"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr1.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con1.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con1.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060027E0 RID: 10208 RVA: 0x0001A31B File Offset: 0x0001851B
		Private Sub txtCustID_TextChanged(sender As Object, e As EventArgs)
			Me.Coupon_Details()
			Me.Loyalty_Details()
		End Sub

		' Token: 0x060027E1 RID: 10209 RVA: 0x00190034 File Offset: 0x0018E234
		Private Sub Loyalty_Details()
			Try
				ModCommonClasses.con29 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con29.Open()
				Dim text As String = "SELECT isNULL(Sum(Addpoint),0)-IsNull(Sum(Usepoint),0) from LPoint where Custid=@d1 group By Custid"
				ModCommonClasses.cmd555 = New SqlCommand(text, ModCommonClasses.con29)
				ModCommonClasses.cmd555.Parameters.AddWithValue("@d1", Me.txtCustID.Text.ToString())
				ModCommonClasses.rdr5551 = ModCommonClasses.cmd555.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr5551.Read()
				If flag Then
					Me.TextBox10.Text = ModCommonClasses.rdr5551.GetValue(0).ToString()
				Else
					Me.TextBox10.Text = "0"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr5551 IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr5551.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con29.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con29.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060027E2 RID: 10210 RVA: 0x00190158 File Offset: 0x0018E358
		Private Sub savedata()
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtCustID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please retrieve customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCustomerName.Focus()
				Else
					Dim flag4 As Boolean = Me.cmbCustomerName.SelectedIndex = -1
					If flag4 Then
						MessageBox.Show("Please select valid customer name !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Select a from Customer_Mobile where a=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAndroidID.Text.ToString())
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "Update Customer_Mobile set b=@d2,c=@d3,d=@d4,e=@d5,f=@d6,g=@d7,h=@d8,i=@d9,j=@d10,k=@d11,l=@d12,m=@d13,n=@d14,o=@d15,p=@d16 where a=@d1"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAndroidID.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbCustomerName.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtCID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtCustID.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtCustAddress.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtCustContact.Text).ToString()
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.TextBox1.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.TextBox2.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.TextBox4.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.TextBox5.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.TextBox6.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.TextBox7.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.TextBox8.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.TextBox9.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(Me.TextBox10.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.TextBox11.Text.ToString())
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
								ModCommonClasses.con.Close()
								Me.Reset()
								Me.Getdata()
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "Insert into Customer_Mobile(a, b, c, d, e, f, g, h, i, j, k, l, m , n, o, p) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtAndroidID.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbCustomerName.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtCID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtCustID.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtCustAddress.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtCustContact.Text).ToString()
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.TextBox1.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.TextBox2.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.TextBox4.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.TextBox5.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.TextBox6.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.TextBox7.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.TextBox8.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.TextBox9.Text.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(Me.TextBox10.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.TextBox11.Text.ToString())
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.Reset()
								Me.Getdata()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060027E3 RID: 10211 RVA: 0x00190908 File Offset: 0x0018EB08
		Private Sub Reset()
			Me.cmbCustomerName.SelectedIndex = -1
			Me.cmbCustomerName.Text = ""
			Me.cmbCustomerName.Focus()
			Me.txtCID.Text = ""
			Me.txtCustID.Text = ""
			Me.txtCustAddress.Text = ""
			Me.txtCustContact.Text = ""
			Me.txtAndroidID.Text = ""
			Me.TextBox1.Text = "0.00"
			Me.TextBox2.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox5.Text = ""
			Me.TextBox6.Text = ""
			Me.TextBox7.Text = ""
			Me.TextBox8.Text = ""
			Me.TextBox9.Text = ""
			Me.TextBox10.Text = ""
			Me.TextBox11.Text = ""
			Me.PictureBox3.Image = Nothing
			Me.Getdata()
		End Sub

		' Token: 0x060027E4 RID: 10212 RVA: 0x0001A32C File Offset: 0x0001852C
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.TextBox3.Text = ""
		End Sub

		' Token: 0x060027E5 RID: 10213 RVA: 0x00190A54 File Offset: 0x0018EC54
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(a), RTRIM(b), RTRIM(c), RTRIM(d), RTRIM(e), RTRIM(f), (g), RTRIM(h), RTRIM(i), RTRIM(j), RTRIM(k), RTRIM(l), RTRIM(m), RTRIM(n), RTRIM(o), RTRIM(p) from Customer_Mobile order by b", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060027E6 RID: 10214 RVA: 0x00190C3C File Offset: 0x0018EE3C
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.dgw.Columns("Column17").Index
			If flag Then
				Try
					Dim flag2 As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag2 Then
						Me.DeleteRecord()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060027E7 RID: 10215 RVA: 0x00190CCC File Offset: 0x0018EECC
		Private Sub DeleteRecord()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Customer_Mobile where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(0).Value.ToString())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
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

		' Token: 0x060027E8 RID: 10216 RVA: 0x00190E00 File Offset: 0x0018F000
		Private Sub AutoUpdater()
			Me.Config = New FirebaseConfig() With { .AuthSecret = "9TSon0zKBvGgAX5r8KI1tvv3y4NQdKGntYlrBm3B", .BasePath = "https://androidbillsoftreport-default-rtdb.asia-southeast1.firebasedatabase.app" }
			Me.Client = New FirebaseClient(Me.Config)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_name", Me.txtAndroidID.Text), Me.cmbCustomerName.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_address", Me.txtAndroidID.Text), Me.txtCustAddress.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_state", Me.txtAndroidID.Text), "")
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_gstin", Me.txtAndroidID.Text), Me.TextBox11.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_contactno", Me.txtAndroidID.Text), Me.txtCustContact.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_email", Me.txtAndroidID.Text), "")
			Me.autoUpdateTimer.Interval = 1000
			AddHandler Me.autoUpdateTimer.Tick, AddressOf Me.AutoUpdater_Event
			Me.autoUpdateTimer.Start()
		End Sub

		' Token: 0x060027E9 RID: 10217 RVA: 0x00190F74 File Offset: 0x0018F174
		Private Sub AutoUpdater_Event(sender As Object, e As EventArgs)
			Me.todayData = New Dictionary(Of String, Dictionary(Of String, String))()
			Me.todayData.Add("Coupon Discount Amount".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Discount Amount" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox1.Text.ToString() } })
			Me.todayData.Add("Coupon Valid From".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Valid From" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox2.Text.ToString() } })
			Me.todayData.Add("Coupon Valid Upto".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Valid Upto" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox4.Text.ToString() } })
			Me.todayData.Add("Offer Status".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Offer Status" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox5.Text.ToString() } })
			Me.todayData.Add("Coupon Code".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Code" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox6.Text.ToString() } })
			Me.todayData.Add("Coupon Status".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Status" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox7.Text.ToString() } })
			Me.todayData.Add("Coupon Issue Date".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Coupon Issue Date" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox8.Text.ToString() } })
			Me.todayData.Add("Loyalty Card No".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Loyalty Card No" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox9.Text.ToString() } })
			Me.todayData.Add("Loyalty Point".Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", "Loyalty Point" }, { "color", If((Me.TextBox12.ForeColor = Color.Blue), "blue", If((Me.TextBox12.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", Me.TextBox10.Text.ToString() } })
			Dim thread As New Thread(AddressOf Me.UploadThreadEvent)
			thread.Start()
		End Sub

		' Token: 0x060027EA RID: 10218 RVA: 0x001915F4 File Offset: 0x0018F7F4
		Private Sub UploadThreadEvent()
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Try
					Me.Client.[Set](Of Dictionary(Of String, Dictionary(Of String, String)))(String.Format("comp/{0}/today/", Me.txtAndroidID.Text), Me.todayData)
				Catch ex As Exception
				End Try
			End If
		End Sub

		' Token: 0x060027EB RID: 10219 RVA: 0x00191658 File Offset: 0x0018F858
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please select category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.ComboBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(a), RTRIM(b), RTRIM(c), RTRIM(d), RTRIM(e), RTRIM(f), (g), RTRIM(h), RTRIM(i), RTRIM(j), RTRIM(k), RTRIM(l), RTRIM(m), RTRIM(n), RTRIM(o), RTRIM(p) from Customer_Mobile where d like N'" + Me.TextBox3.Text + "%' order by b", ModCommonClasses.con)
					End If
					Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag3 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(a), RTRIM(b), RTRIM(c), RTRIM(d), RTRIM(e), RTRIM(f), (g), RTRIM(h), RTRIM(i), RTRIM(j), RTRIM(k), RTRIM(l), RTRIM(m), RTRIM(n), RTRIM(o), RTRIM(p) from Customer_Mobile where b like N'" + Me.TextBox3.Text + "%' order by b", ModCommonClasses.con)
					End If
					Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
					If flag4 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(a), RTRIM(b), RTRIM(c), RTRIM(d), RTRIM(e), RTRIM(f), (g), RTRIM(h), RTRIM(i), RTRIM(j), RTRIM(k), RTRIM(l), RTRIM(m), RTRIM(n), RTRIM(o), RTRIM(p) from Customer_Mobile where f like N'" + Me.TextBox3.Text + "%' order by b", ModCommonClasses.con)
					End If
					Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
					If flag5 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(a), RTRIM(b), RTRIM(c), RTRIM(d), RTRIM(e), RTRIM(f), (g), RTRIM(h), RTRIM(i), RTRIM(j), RTRIM(k), RTRIM(l), RTRIM(m), RTRIM(n), RTRIM(o), RTRIM(p) from Customer_Mobile where a like N'" + Me.TextBox3.Text + "%' order by b", ModCommonClasses.con)
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060027EC RID: 10220 RVA: 0x0019195C File Offset: 0x0018FB5C
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Try
						Dim qrcodeEncoder As QRCodeEncoder = New QRCodeEncoder()
						qrcodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
						qrcodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
						Me.PictureBox3.Image = qrcodeEncoder.Encode(dataGridViewRow.Cells(1).Value.ToString(), Encoding.UTF8)
					Catch ex As Exception
					End Try
				End If
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x060027ED RID: 10221 RVA: 0x00191A20 File Offset: 0x0018FC20
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Try
				Me.AutoUpdater()
				Me.AutoUpdater()
			Catch ex As Exception
			End Try
			Me.savedata()
		End Sub

		' Token: 0x060027EE RID: 10222 RVA: 0x00191A68 File Offset: 0x0018FC68
		Private Sub frmCustomerMobileRpt_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyProject.Forms.Form2.Close()
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060027EF RID: 10223 RVA: 0x00191AC4 File Offset: 0x0018FCC4
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.Form2.PictureBox1.Image = Me.PictureBox3.Image
			Try
				Dim screen As Screen = Screen.AllScreens(1)
				MyProject.Forms.Form2.StartPosition = FormStartPosition.Manual
				MyProject.Forms.Form2.Location = screen.Bounds.Location + CType(New Point(100, 100), Size)
				MyProject.Forms.Form2.Show()
			Catch ex As Exception
				MessageBox.Show("Extend display monitor not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060027F0 RID: 10224 RVA: 0x0001A354 File Offset: 0x00018554
		Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.Form2.Close()
		End Sub

		' Token: 0x060027F1 RID: 10225 RVA: 0x00191B84 File Offset: 0x0018FD84
		Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "Trial", False) <> 0
			If flag Then
				Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
				If flag2 Then
					Process.Start("https://drive.google.com/file/d/1MEsc02hz0A3-b8sjyViGO22NMemFemap/view?usp=sharing")
				End If
			Else
				MessageBox.Show("You are not allowed to download in Trial edition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060027F2 RID: 10226 RVA: 0x00191BE0 File Offset: 0x0018FDE0
		Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.Form2.PictureBox1.Image = Me.PictureBox1.Image
			Try
				Dim screen As Screen = Screen.AllScreens(1)
				MyProject.Forms.Form2.StartPosition = FormStartPosition.Manual
				MyProject.Forms.Form2.Location = screen.Bounds.Location + CType(New Point(100, 100), Size)
				MyProject.Forms.Form2.Show()
			Catch ex As Exception
				MessageBox.Show("Extend display monitor not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060027F3 RID: 10227 RVA: 0x0001A354 File Offset: 0x00018554
		Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.Form2.Close()
		End Sub

		' Token: 0x040010A6 RID: 4262
		Private num1 As Double

		' Token: 0x040010A7 RID: 4263
		Private autoUpdateTimer As Global.System.Windows.Forms.Timer

		' Token: 0x040010A8 RID: 4264
		Private Config As IFirebaseConfig

		' Token: 0x040010A9 RID: 4265
		Private Client As IFirebaseClient

		' Token: 0x040010AA RID: 4266
		Private todayData As Dictionary(Of String, Dictionary(Of String, String))

		' Token: 0x040010AB RID: 4267
		Private fyData As Dictionary(Of String, Dictionary(Of String, String))
	End Class
End Namespace
