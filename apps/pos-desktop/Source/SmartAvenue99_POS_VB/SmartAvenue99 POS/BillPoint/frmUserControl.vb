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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.PowerPacks

Namespace BillPoint
	' Token: 0x020004E8 RID: 1256
	<DesignerGenerated()>
	Public Partial Class frmUserControl
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060100FE RID: 65790 RVA: 0x00070AF0 File Offset: 0x0006ECF0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmUserControl_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmUserControl_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700622F RID: 25135
		' (get) Token: 0x06010101 RID: 65793 RVA: 0x00070B22 File Offset: 0x0006ED22
		' (set) Token: 0x06010102 RID: 65794 RVA: 0x00070B2C File Offset: 0x0006ED2C
		Friend Overridable Property ComboBox2 As ComboBox

		' Token: 0x17006230 RID: 25136
		' (get) Token: 0x06010103 RID: 65795 RVA: 0x00070B35 File Offset: 0x0006ED35
		' (set) Token: 0x06010104 RID: 65796 RVA: 0x00070B3F File Offset: 0x0006ED3F
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17006231 RID: 25137
		' (get) Token: 0x06010105 RID: 65797 RVA: 0x00070B48 File Offset: 0x0006ED48
		' (set) Token: 0x06010106 RID: 65798 RVA: 0x00070B52 File Offset: 0x0006ED52
		Friend Overridable Property ComboBox3 As ComboBox

		' Token: 0x17006232 RID: 25138
		' (get) Token: 0x06010107 RID: 65799 RVA: 0x00070B5B File Offset: 0x0006ED5B
		' (set) Token: 0x06010108 RID: 65800 RVA: 0x00070B65 File Offset: 0x0006ED65
		Friend Overridable Property ComboBox4 As ComboBox

		' Token: 0x17006233 RID: 25139
		' (get) Token: 0x06010109 RID: 65801 RVA: 0x00070B6E File Offset: 0x0006ED6E
		' (set) Token: 0x0601010A RID: 65802 RVA: 0x00070B78 File Offset: 0x0006ED78
		Friend Overridable Property ComboBox5 As ComboBox

		' Token: 0x17006234 RID: 25140
		' (get) Token: 0x0601010B RID: 65803 RVA: 0x00070B81 File Offset: 0x0006ED81
		' (set) Token: 0x0601010C RID: 65804 RVA: 0x00070B8B File Offset: 0x0006ED8B
		Friend Overridable Property ComboBox6 As ComboBox

		' Token: 0x17006235 RID: 25141
		' (get) Token: 0x0601010D RID: 65805 RVA: 0x00070B94 File Offset: 0x0006ED94
		' (set) Token: 0x0601010E RID: 65806 RVA: 0x00070B9E File Offset: 0x0006ED9E
		Friend Overridable Property ComboBox7 As ComboBox

		' Token: 0x17006236 RID: 25142
		' (get) Token: 0x0601010F RID: 65807 RVA: 0x00070BA7 File Offset: 0x0006EDA7
		' (set) Token: 0x06010110 RID: 65808 RVA: 0x00070BB1 File Offset: 0x0006EDB1
		Friend Overridable Property ComboBox8 As ComboBox

		' Token: 0x17006237 RID: 25143
		' (get) Token: 0x06010111 RID: 65809 RVA: 0x00070BBA File Offset: 0x0006EDBA
		' (set) Token: 0x06010112 RID: 65810 RVA: 0x00070BC4 File Offset: 0x0006EDC4
		Friend Overridable Property ComboBox9 As ComboBox

		' Token: 0x17006238 RID: 25144
		' (get) Token: 0x06010113 RID: 65811 RVA: 0x00070BCD File Offset: 0x0006EDCD
		' (set) Token: 0x06010114 RID: 65812 RVA: 0x00070BD7 File Offset: 0x0006EDD7
		Friend Overridable Property ComboBox10 As ComboBox

		' Token: 0x17006239 RID: 25145
		' (get) Token: 0x06010115 RID: 65813 RVA: 0x00070BE0 File Offset: 0x0006EDE0
		' (set) Token: 0x06010116 RID: 65814 RVA: 0x00070BEA File Offset: 0x0006EDEA
		Friend Overridable Property ComboBox11 As ComboBox

		' Token: 0x1700623A RID: 25146
		' (get) Token: 0x06010117 RID: 65815 RVA: 0x00070BF3 File Offset: 0x0006EDF3
		' (set) Token: 0x06010118 RID: 65816 RVA: 0x00070BFD File Offset: 0x0006EDFD
		Friend Overridable Property ComboBox12 As ComboBox

		' Token: 0x1700623B RID: 25147
		' (get) Token: 0x06010119 RID: 65817 RVA: 0x00070C06 File Offset: 0x0006EE06
		' (set) Token: 0x0601011A RID: 65818 RVA: 0x00070C10 File Offset: 0x0006EE10
		Friend Overridable Property ComboBox13 As ComboBox

		' Token: 0x1700623C RID: 25148
		' (get) Token: 0x0601011B RID: 65819 RVA: 0x00070C19 File Offset: 0x0006EE19
		' (set) Token: 0x0601011C RID: 65820 RVA: 0x00070C23 File Offset: 0x0006EE23
		Friend Overridable Property ComboBox14 As ComboBox

		' Token: 0x1700623D RID: 25149
		' (get) Token: 0x0601011D RID: 65821 RVA: 0x00070C2C File Offset: 0x0006EE2C
		' (set) Token: 0x0601011E RID: 65822 RVA: 0x00070C36 File Offset: 0x0006EE36
		Friend Overridable Property ComboBox15 As ComboBox

		' Token: 0x1700623E RID: 25150
		' (get) Token: 0x0601011F RID: 65823 RVA: 0x00070C3F File Offset: 0x0006EE3F
		' (set) Token: 0x06010120 RID: 65824 RVA: 0x00070C49 File Offset: 0x0006EE49
		Friend Overridable Property ComboBox16 As ComboBox

		' Token: 0x1700623F RID: 25151
		' (get) Token: 0x06010121 RID: 65825 RVA: 0x00070C52 File Offset: 0x0006EE52
		' (set) Token: 0x06010122 RID: 65826 RVA: 0x00070C5C File Offset: 0x0006EE5C
		Friend Overridable Property ComboBox17 As ComboBox

		' Token: 0x17006240 RID: 25152
		' (get) Token: 0x06010123 RID: 65827 RVA: 0x00070C65 File Offset: 0x0006EE65
		' (set) Token: 0x06010124 RID: 65828 RVA: 0x00070C6F File Offset: 0x0006EE6F
		Friend Overridable Property ComboBox18 As ComboBox

		' Token: 0x17006241 RID: 25153
		' (get) Token: 0x06010125 RID: 65829 RVA: 0x00070C78 File Offset: 0x0006EE78
		' (set) Token: 0x06010126 RID: 65830 RVA: 0x00070C82 File Offset: 0x0006EE82
		Friend Overridable Property ComboBox19 As ComboBox

		' Token: 0x17006242 RID: 25154
		' (get) Token: 0x06010127 RID: 65831 RVA: 0x00070C8B File Offset: 0x0006EE8B
		' (set) Token: 0x06010128 RID: 65832 RVA: 0x00070C95 File Offset: 0x0006EE95
		Friend Overridable Property ComboBox20 As ComboBox

		' Token: 0x17006243 RID: 25155
		' (get) Token: 0x06010129 RID: 65833 RVA: 0x00070C9E File Offset: 0x0006EE9E
		' (set) Token: 0x0601012A RID: 65834 RVA: 0x00070CA8 File Offset: 0x0006EEA8
		Friend Overridable Property ComboBox21 As ComboBox

		' Token: 0x17006244 RID: 25156
		' (get) Token: 0x0601012B RID: 65835 RVA: 0x00070CB1 File Offset: 0x0006EEB1
		' (set) Token: 0x0601012C RID: 65836 RVA: 0x00070CBB File Offset: 0x0006EEBB
		Friend Overridable Property ComboBox22 As ComboBox

		' Token: 0x17006245 RID: 25157
		' (get) Token: 0x0601012D RID: 65837 RVA: 0x00070CC4 File Offset: 0x0006EEC4
		' (set) Token: 0x0601012E RID: 65838 RVA: 0x00070CCE File Offset: 0x0006EECE
		Friend Overridable Property ComboBox23 As ComboBox

		' Token: 0x17006246 RID: 25158
		' (get) Token: 0x0601012F RID: 65839 RVA: 0x00070CD7 File Offset: 0x0006EED7
		' (set) Token: 0x06010130 RID: 65840 RVA: 0x00070CE1 File Offset: 0x0006EEE1
		Friend Overridable Property ComboBox24 As ComboBox

		' Token: 0x17006247 RID: 25159
		' (get) Token: 0x06010131 RID: 65841 RVA: 0x00070CEA File Offset: 0x0006EEEA
		' (set) Token: 0x06010132 RID: 65842 RVA: 0x00070CF4 File Offset: 0x0006EEF4
		Friend Overridable Property ComboBox25 As ComboBox

		' Token: 0x17006248 RID: 25160
		' (get) Token: 0x06010133 RID: 65843 RVA: 0x00070CFD File Offset: 0x0006EEFD
		' (set) Token: 0x06010134 RID: 65844 RVA: 0x00070D07 File Offset: 0x0006EF07
		Friend Overridable Property ComboBox26 As ComboBox

		' Token: 0x17006249 RID: 25161
		' (get) Token: 0x06010135 RID: 65845 RVA: 0x00070D10 File Offset: 0x0006EF10
		' (set) Token: 0x06010136 RID: 65846 RVA: 0x00070D1A File Offset: 0x0006EF1A
		Friend Overridable Property ComboBox27 As ComboBox

		' Token: 0x1700624A RID: 25162
		' (get) Token: 0x06010137 RID: 65847 RVA: 0x00070D23 File Offset: 0x0006EF23
		' (set) Token: 0x06010138 RID: 65848 RVA: 0x00070D2D File Offset: 0x0006EF2D
		Friend Overridable Property ComboBox28 As ComboBox

		' Token: 0x1700624B RID: 25163
		' (get) Token: 0x06010139 RID: 65849 RVA: 0x00070D36 File Offset: 0x0006EF36
		' (set) Token: 0x0601013A RID: 65850 RVA: 0x00070D40 File Offset: 0x0006EF40
		Friend Overridable Property ComboBox29 As ComboBox

		' Token: 0x1700624C RID: 25164
		' (get) Token: 0x0601013B RID: 65851 RVA: 0x00070D49 File Offset: 0x0006EF49
		' (set) Token: 0x0601013C RID: 65852 RVA: 0x00070D53 File Offset: 0x0006EF53
		Friend Overridable Property ComboBox30 As ComboBox

		' Token: 0x1700624D RID: 25165
		' (get) Token: 0x0601013D RID: 65853 RVA: 0x00070D5C File Offset: 0x0006EF5C
		' (set) Token: 0x0601013E RID: 65854 RVA: 0x00070D66 File Offset: 0x0006EF66
		Friend Overridable Property ComboBox31 As ComboBox

		' Token: 0x1700624E RID: 25166
		' (get) Token: 0x0601013F RID: 65855 RVA: 0x00070D6F File Offset: 0x0006EF6F
		' (set) Token: 0x06010140 RID: 65856 RVA: 0x00070D79 File Offset: 0x0006EF79
		Friend Overridable Property ComboBox32 As ComboBox

		' Token: 0x1700624F RID: 25167
		' (get) Token: 0x06010141 RID: 65857 RVA: 0x00070D82 File Offset: 0x0006EF82
		' (set) Token: 0x06010142 RID: 65858 RVA: 0x00070D8C File Offset: 0x0006EF8C
		Friend Overridable Property ComboBox33 As ComboBox

		' Token: 0x17006250 RID: 25168
		' (get) Token: 0x06010143 RID: 65859 RVA: 0x00070D95 File Offset: 0x0006EF95
		' (set) Token: 0x06010144 RID: 65860 RVA: 0x00070D9F File Offset: 0x0006EF9F
		Friend Overridable Property ComboBox34 As ComboBox

		' Token: 0x17006251 RID: 25169
		' (get) Token: 0x06010145 RID: 65861 RVA: 0x00070DA8 File Offset: 0x0006EFA8
		' (set) Token: 0x06010146 RID: 65862 RVA: 0x00070DB2 File Offset: 0x0006EFB2
		Friend Overridable Property ComboBox35 As ComboBox

		' Token: 0x17006252 RID: 25170
		' (get) Token: 0x06010147 RID: 65863 RVA: 0x00070DBB File Offset: 0x0006EFBB
		' (set) Token: 0x06010148 RID: 65864 RVA: 0x00070DC5 File Offset: 0x0006EFC5
		Friend Overridable Property ComboBox36 As ComboBox

		' Token: 0x17006253 RID: 25171
		' (get) Token: 0x06010149 RID: 65865 RVA: 0x00070DCE File Offset: 0x0006EFCE
		' (set) Token: 0x0601014A RID: 65866 RVA: 0x00070DD8 File Offset: 0x0006EFD8
		Friend Overridable Property ComboBox37 As ComboBox

		' Token: 0x17006254 RID: 25172
		' (get) Token: 0x0601014B RID: 65867 RVA: 0x00070DE1 File Offset: 0x0006EFE1
		' (set) Token: 0x0601014C RID: 65868 RVA: 0x00070DEB File Offset: 0x0006EFEB
		Friend Overridable Property ComboBox38 As ComboBox

		' Token: 0x17006255 RID: 25173
		' (get) Token: 0x0601014D RID: 65869 RVA: 0x00070DF4 File Offset: 0x0006EFF4
		' (set) Token: 0x0601014E RID: 65870 RVA: 0x00070DFE File Offset: 0x0006EFFE
		Friend Overridable Property ComboBox39 As ComboBox

		' Token: 0x17006256 RID: 25174
		' (get) Token: 0x0601014F RID: 65871 RVA: 0x00070E07 File Offset: 0x0006F007
		' (set) Token: 0x06010150 RID: 65872 RVA: 0x00070E11 File Offset: 0x0006F011
		Friend Overridable Property ComboBox40 As ComboBox

		' Token: 0x17006257 RID: 25175
		' (get) Token: 0x06010151 RID: 65873 RVA: 0x00070E1A File Offset: 0x0006F01A
		' (set) Token: 0x06010152 RID: 65874 RVA: 0x00070E24 File Offset: 0x0006F024
		Friend Overridable Property ComboBox41 As ComboBox

		' Token: 0x17006258 RID: 25176
		' (get) Token: 0x06010153 RID: 65875 RVA: 0x00070E2D File Offset: 0x0006F02D
		' (set) Token: 0x06010154 RID: 65876 RVA: 0x00070E37 File Offset: 0x0006F037
		Friend Overridable Property ComboBox42 As ComboBox

		' Token: 0x17006259 RID: 25177
		' (get) Token: 0x06010155 RID: 65877 RVA: 0x00070E40 File Offset: 0x0006F040
		' (set) Token: 0x06010156 RID: 65878 RVA: 0x00070E4A File Offset: 0x0006F04A
		Friend Overridable Property Label1 As Label

		' Token: 0x1700625A RID: 25178
		' (get) Token: 0x06010157 RID: 65879 RVA: 0x00070E53 File Offset: 0x0006F053
		' (set) Token: 0x06010158 RID: 65880 RVA: 0x00070E5D File Offset: 0x0006F05D
		Friend Overridable Property Label2 As Label

		' Token: 0x1700625B RID: 25179
		' (get) Token: 0x06010159 RID: 65881 RVA: 0x00070E66 File Offset: 0x0006F066
		' (set) Token: 0x0601015A RID: 65882 RVA: 0x00070E70 File Offset: 0x0006F070
		Friend Overridable Property Label3 As Label

		' Token: 0x1700625C RID: 25180
		' (get) Token: 0x0601015B RID: 65883 RVA: 0x00070E79 File Offset: 0x0006F079
		' (set) Token: 0x0601015C RID: 65884 RVA: 0x00070E83 File Offset: 0x0006F083
		Friend Overridable Property Label4 As Label

		' Token: 0x1700625D RID: 25181
		' (get) Token: 0x0601015D RID: 65885 RVA: 0x00070E8C File Offset: 0x0006F08C
		' (set) Token: 0x0601015E RID: 65886 RVA: 0x00070E96 File Offset: 0x0006F096
		Friend Overridable Property Label5 As Label

		' Token: 0x1700625E RID: 25182
		' (get) Token: 0x0601015F RID: 65887 RVA: 0x00070E9F File Offset: 0x0006F09F
		' (set) Token: 0x06010160 RID: 65888 RVA: 0x00070EA9 File Offset: 0x0006F0A9
		Friend Overridable Property Label6 As Label

		' Token: 0x1700625F RID: 25183
		' (get) Token: 0x06010161 RID: 65889 RVA: 0x00070EB2 File Offset: 0x0006F0B2
		' (set) Token: 0x06010162 RID: 65890 RVA: 0x00070EBC File Offset: 0x0006F0BC
		Friend Overridable Property Label7 As Label

		' Token: 0x17006260 RID: 25184
		' (get) Token: 0x06010163 RID: 65891 RVA: 0x00070EC5 File Offset: 0x0006F0C5
		' (set) Token: 0x06010164 RID: 65892 RVA: 0x00070ECF File Offset: 0x0006F0CF
		Friend Overridable Property Label8 As Label

		' Token: 0x17006261 RID: 25185
		' (get) Token: 0x06010165 RID: 65893 RVA: 0x00070ED8 File Offset: 0x0006F0D8
		' (set) Token: 0x06010166 RID: 65894 RVA: 0x00070EE2 File Offset: 0x0006F0E2
		Friend Overridable Property Label9 As Label

		' Token: 0x17006262 RID: 25186
		' (get) Token: 0x06010167 RID: 65895 RVA: 0x00070EEB File Offset: 0x0006F0EB
		' (set) Token: 0x06010168 RID: 65896 RVA: 0x00070EF5 File Offset: 0x0006F0F5
		Friend Overridable Property Label10 As Label

		' Token: 0x17006263 RID: 25187
		' (get) Token: 0x06010169 RID: 65897 RVA: 0x00070EFE File Offset: 0x0006F0FE
		' (set) Token: 0x0601016A RID: 65898 RVA: 0x00070F08 File Offset: 0x0006F108
		Friend Overridable Property Label11 As Label

		' Token: 0x17006264 RID: 25188
		' (get) Token: 0x0601016B RID: 65899 RVA: 0x00070F11 File Offset: 0x0006F111
		' (set) Token: 0x0601016C RID: 65900 RVA: 0x00070F1B File Offset: 0x0006F11B
		Friend Overridable Property Label12 As Label

		' Token: 0x17006265 RID: 25189
		' (get) Token: 0x0601016D RID: 65901 RVA: 0x00070F24 File Offset: 0x0006F124
		' (set) Token: 0x0601016E RID: 65902 RVA: 0x00070F2E File Offset: 0x0006F12E
		Friend Overridable Property Label13 As Label

		' Token: 0x17006266 RID: 25190
		' (get) Token: 0x0601016F RID: 65903 RVA: 0x00070F37 File Offset: 0x0006F137
		' (set) Token: 0x06010170 RID: 65904 RVA: 0x00070F41 File Offset: 0x0006F141
		Friend Overridable Property Label14 As Label

		' Token: 0x17006267 RID: 25191
		' (get) Token: 0x06010171 RID: 65905 RVA: 0x00070F4A File Offset: 0x0006F14A
		' (set) Token: 0x06010172 RID: 65906 RVA: 0x00070F54 File Offset: 0x0006F154
		Friend Overridable Property Label15 As Label

		' Token: 0x17006268 RID: 25192
		' (get) Token: 0x06010173 RID: 65907 RVA: 0x00070F5D File Offset: 0x0006F15D
		' (set) Token: 0x06010174 RID: 65908 RVA: 0x00070F67 File Offset: 0x0006F167
		Friend Overridable Property Label16 As Label

		' Token: 0x17006269 RID: 25193
		' (get) Token: 0x06010175 RID: 65909 RVA: 0x00070F70 File Offset: 0x0006F170
		' (set) Token: 0x06010176 RID: 65910 RVA: 0x00070F7A File Offset: 0x0006F17A
		Friend Overridable Property Label17 As Label

		' Token: 0x1700626A RID: 25194
		' (get) Token: 0x06010177 RID: 65911 RVA: 0x00070F83 File Offset: 0x0006F183
		' (set) Token: 0x06010178 RID: 65912 RVA: 0x00070F8D File Offset: 0x0006F18D
		Friend Overridable Property Label18 As Label

		' Token: 0x1700626B RID: 25195
		' (get) Token: 0x06010179 RID: 65913 RVA: 0x00070F96 File Offset: 0x0006F196
		' (set) Token: 0x0601017A RID: 65914 RVA: 0x00070FA0 File Offset: 0x0006F1A0
		Friend Overridable Property Label19 As Label

		' Token: 0x1700626C RID: 25196
		' (get) Token: 0x0601017B RID: 65915 RVA: 0x00070FA9 File Offset: 0x0006F1A9
		' (set) Token: 0x0601017C RID: 65916 RVA: 0x00070FB3 File Offset: 0x0006F1B3
		Friend Overridable Property Label20 As Label

		' Token: 0x1700626D RID: 25197
		' (get) Token: 0x0601017D RID: 65917 RVA: 0x00070FBC File Offset: 0x0006F1BC
		' (set) Token: 0x0601017E RID: 65918 RVA: 0x00070FC6 File Offset: 0x0006F1C6
		Friend Overridable Property Label21 As Label

		' Token: 0x1700626E RID: 25198
		' (get) Token: 0x0601017F RID: 65919 RVA: 0x00070FCF File Offset: 0x0006F1CF
		' (set) Token: 0x06010180 RID: 65920 RVA: 0x00070FD9 File Offset: 0x0006F1D9
		Friend Overridable Property Label22 As Label

		' Token: 0x1700626F RID: 25199
		' (get) Token: 0x06010181 RID: 65921 RVA: 0x00070FE2 File Offset: 0x0006F1E2
		' (set) Token: 0x06010182 RID: 65922 RVA: 0x00070FEC File Offset: 0x0006F1EC
		Friend Overridable Property Label23 As Label

		' Token: 0x17006270 RID: 25200
		' (get) Token: 0x06010183 RID: 65923 RVA: 0x00070FF5 File Offset: 0x0006F1F5
		' (set) Token: 0x06010184 RID: 65924 RVA: 0x00070FFF File Offset: 0x0006F1FF
		Friend Overridable Property Label24 As Label

		' Token: 0x17006271 RID: 25201
		' (get) Token: 0x06010185 RID: 65925 RVA: 0x00071008 File Offset: 0x0006F208
		' (set) Token: 0x06010186 RID: 65926 RVA: 0x00071012 File Offset: 0x0006F212
		Friend Overridable Property Label25 As Label

		' Token: 0x17006272 RID: 25202
		' (get) Token: 0x06010187 RID: 65927 RVA: 0x0007101B File Offset: 0x0006F21B
		' (set) Token: 0x06010188 RID: 65928 RVA: 0x00071025 File Offset: 0x0006F225
		Friend Overridable Property Label26 As Label

		' Token: 0x17006273 RID: 25203
		' (get) Token: 0x06010189 RID: 65929 RVA: 0x0007102E File Offset: 0x0006F22E
		' (set) Token: 0x0601018A RID: 65930 RVA: 0x00071038 File Offset: 0x0006F238
		Friend Overridable Property Label27 As Label

		' Token: 0x17006274 RID: 25204
		' (get) Token: 0x0601018B RID: 65931 RVA: 0x00071041 File Offset: 0x0006F241
		' (set) Token: 0x0601018C RID: 65932 RVA: 0x0007104B File Offset: 0x0006F24B
		Friend Overridable Property Label28 As Label

		' Token: 0x17006275 RID: 25205
		' (get) Token: 0x0601018D RID: 65933 RVA: 0x00071054 File Offset: 0x0006F254
		' (set) Token: 0x0601018E RID: 65934 RVA: 0x0007105E File Offset: 0x0006F25E
		Friend Overridable Property Label29 As Label

		' Token: 0x17006276 RID: 25206
		' (get) Token: 0x0601018F RID: 65935 RVA: 0x00071067 File Offset: 0x0006F267
		' (set) Token: 0x06010190 RID: 65936 RVA: 0x00071071 File Offset: 0x0006F271
		Friend Overridable Property Label35 As Label

		' Token: 0x17006277 RID: 25207
		' (get) Token: 0x06010191 RID: 65937 RVA: 0x0007107A File Offset: 0x0006F27A
		' (set) Token: 0x06010192 RID: 65938 RVA: 0x00071084 File Offset: 0x0006F284
		Friend Overridable Property Label34 As Label

		' Token: 0x17006278 RID: 25208
		' (get) Token: 0x06010193 RID: 65939 RVA: 0x0007108D File Offset: 0x0006F28D
		' (set) Token: 0x06010194 RID: 65940 RVA: 0x00071097 File Offset: 0x0006F297
		Friend Overridable Property Label32 As Label

		' Token: 0x17006279 RID: 25209
		' (get) Token: 0x06010195 RID: 65941 RVA: 0x000710A0 File Offset: 0x0006F2A0
		' (set) Token: 0x06010196 RID: 65942 RVA: 0x000710AA File Offset: 0x0006F2AA
		Friend Overridable Property Label31 As Label

		' Token: 0x1700627A RID: 25210
		' (get) Token: 0x06010197 RID: 65943 RVA: 0x000710B3 File Offset: 0x0006F2B3
		' (set) Token: 0x06010198 RID: 65944 RVA: 0x000710BD File Offset: 0x0006F2BD
		Friend Overridable Property Label30 As Label

		' Token: 0x1700627B RID: 25211
		' (get) Token: 0x06010199 RID: 65945 RVA: 0x000710C6 File Offset: 0x0006F2C6
		' (set) Token: 0x0601019A RID: 65946 RVA: 0x0099D2B0 File Offset: 0x0099B4B0
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint1
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

		' Token: 0x1700627C RID: 25212
		' (get) Token: 0x0601019B RID: 65947 RVA: 0x000710D0 File Offset: 0x0006F2D0
		' (set) Token: 0x0601019C RID: 65948 RVA: 0x000710DA File Offset: 0x0006F2DA
		Friend Overridable Property Label33 As Label

		' Token: 0x1700627D RID: 25213
		' (get) Token: 0x0601019D RID: 65949 RVA: 0x000710E3 File Offset: 0x0006F2E3
		' (set) Token: 0x0601019E RID: 65950 RVA: 0x000710ED File Offset: 0x0006F2ED
		Friend Overridable Property cmbUserID As ComboBox

		' Token: 0x1700627E RID: 25214
		' (get) Token: 0x0601019F RID: 65951 RVA: 0x000710F6 File Offset: 0x0006F2F6
		' (set) Token: 0x060101A0 RID: 65952 RVA: 0x00071100 File Offset: 0x0006F300
		Friend Overridable Property txtID As TextBox

		' Token: 0x1700627F RID: 25215
		' (get) Token: 0x060101A1 RID: 65953 RVA: 0x00071109 File Offset: 0x0006F309
		' (set) Token: 0x060101A2 RID: 65954 RVA: 0x00071113 File Offset: 0x0006F313
		Friend Overridable Property Label45 As Label

		' Token: 0x17006280 RID: 25216
		' (get) Token: 0x060101A3 RID: 65955 RVA: 0x0007111C File Offset: 0x0006F31C
		' (set) Token: 0x060101A4 RID: 65956 RVA: 0x00071126 File Offset: 0x0006F326
		Friend Overridable Property Label44 As Label

		' Token: 0x17006281 RID: 25217
		' (get) Token: 0x060101A5 RID: 65957 RVA: 0x0007112F File Offset: 0x0006F32F
		' (set) Token: 0x060101A6 RID: 65958 RVA: 0x00071139 File Offset: 0x0006F339
		Friend Overridable Property Label43 As Label

		' Token: 0x17006282 RID: 25218
		' (get) Token: 0x060101A7 RID: 65959 RVA: 0x00071142 File Offset: 0x0006F342
		' (set) Token: 0x060101A8 RID: 65960 RVA: 0x0007114C File Offset: 0x0006F34C
		Friend Overridable Property Label42 As Label

		' Token: 0x17006283 RID: 25219
		' (get) Token: 0x060101A9 RID: 65961 RVA: 0x00071155 File Offset: 0x0006F355
		' (set) Token: 0x060101AA RID: 65962 RVA: 0x0007115F File Offset: 0x0006F35F
		Friend Overridable Property Label41 As Label

		' Token: 0x17006284 RID: 25220
		' (get) Token: 0x060101AB RID: 65963 RVA: 0x00071168 File Offset: 0x0006F368
		' (set) Token: 0x060101AC RID: 65964 RVA: 0x00071172 File Offset: 0x0006F372
		Friend Overridable Property Label40 As Label

		' Token: 0x17006285 RID: 25221
		' (get) Token: 0x060101AD RID: 65965 RVA: 0x0007117B File Offset: 0x0006F37B
		' (set) Token: 0x060101AE RID: 65966 RVA: 0x00071185 File Offset: 0x0006F385
		Friend Overridable Property Label39 As Label

		' Token: 0x17006286 RID: 25222
		' (get) Token: 0x060101AF RID: 65967 RVA: 0x0007118E File Offset: 0x0006F38E
		' (set) Token: 0x060101B0 RID: 65968 RVA: 0x00071198 File Offset: 0x0006F398
		Friend Overridable Property Label38 As Label

		' Token: 0x17006287 RID: 25223
		' (get) Token: 0x060101B1 RID: 65969 RVA: 0x000711A1 File Offset: 0x0006F3A1
		' (set) Token: 0x060101B2 RID: 65970 RVA: 0x000711AB File Offset: 0x0006F3AB
		Friend Overridable Property Label46 As Label

		' Token: 0x17006288 RID: 25224
		' (get) Token: 0x060101B3 RID: 65971 RVA: 0x000711B4 File Offset: 0x0006F3B4
		' (set) Token: 0x060101B4 RID: 65972 RVA: 0x000711BE File Offset: 0x0006F3BE
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006289 RID: 25225
		' (get) Token: 0x060101B5 RID: 65973 RVA: 0x000711C7 File Offset: 0x0006F3C7
		' (set) Token: 0x060101B6 RID: 65974 RVA: 0x000711D1 File Offset: 0x0006F3D1
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700628A RID: 25226
		' (get) Token: 0x060101B7 RID: 65975 RVA: 0x000711DA File Offset: 0x0006F3DA
		' (set) Token: 0x060101B8 RID: 65976 RVA: 0x000711E4 File Offset: 0x0006F3E4
		Friend Overridable Property Label49 As Label

		' Token: 0x1700628B RID: 25227
		' (get) Token: 0x060101B9 RID: 65977 RVA: 0x000711ED File Offset: 0x0006F3ED
		' (set) Token: 0x060101BA RID: 65978 RVA: 0x000711F7 File Offset: 0x0006F3F7
		Friend Overridable Property ComboBox47 As ComboBox

		' Token: 0x1700628C RID: 25228
		' (get) Token: 0x060101BB RID: 65979 RVA: 0x00071200 File Offset: 0x0006F400
		' (set) Token: 0x060101BC RID: 65980 RVA: 0x0007120A File Offset: 0x0006F40A
		Friend Overridable Property Label50 As Label

		' Token: 0x1700628D RID: 25229
		' (get) Token: 0x060101BD RID: 65981 RVA: 0x00071213 File Offset: 0x0006F413
		' (set) Token: 0x060101BE RID: 65982 RVA: 0x0007121D File Offset: 0x0006F41D
		Friend Overridable Property ComboBox48 As ComboBox

		' Token: 0x1700628E RID: 25230
		' (get) Token: 0x060101BF RID: 65983 RVA: 0x00071226 File Offset: 0x0006F426
		' (set) Token: 0x060101C0 RID: 65984 RVA: 0x00071230 File Offset: 0x0006F430
		Friend Overridable Property Label47 As Label

		' Token: 0x1700628F RID: 25231
		' (get) Token: 0x060101C1 RID: 65985 RVA: 0x00071239 File Offset: 0x0006F439
		' (set) Token: 0x060101C2 RID: 65986 RVA: 0x00071243 File Offset: 0x0006F443
		Friend Overridable Property ComboBox45 As ComboBox

		' Token: 0x17006290 RID: 25232
		' (get) Token: 0x060101C3 RID: 65987 RVA: 0x0007124C File Offset: 0x0006F44C
		' (set) Token: 0x060101C4 RID: 65988 RVA: 0x00071256 File Offset: 0x0006F456
		Friend Overridable Property Label48 As Label

		' Token: 0x17006291 RID: 25233
		' (get) Token: 0x060101C5 RID: 65989 RVA: 0x0007125F File Offset: 0x0006F45F
		' (set) Token: 0x060101C6 RID: 65990 RVA: 0x00071269 File Offset: 0x0006F469
		Friend Overridable Property ComboBox46 As ComboBox

		' Token: 0x17006292 RID: 25234
		' (get) Token: 0x060101C7 RID: 65991 RVA: 0x00071272 File Offset: 0x0006F472
		' (set) Token: 0x060101C8 RID: 65992 RVA: 0x0007127C File Offset: 0x0006F47C
		Friend Overridable Property Label37 As Label

		' Token: 0x17006293 RID: 25235
		' (get) Token: 0x060101C9 RID: 65993 RVA: 0x00071285 File Offset: 0x0006F485
		' (set) Token: 0x060101CA RID: 65994 RVA: 0x0007128F File Offset: 0x0006F48F
		Friend Overridable Property ComboBox44 As ComboBox

		' Token: 0x17006294 RID: 25236
		' (get) Token: 0x060101CB RID: 65995 RVA: 0x00071298 File Offset: 0x0006F498
		' (set) Token: 0x060101CC RID: 65996 RVA: 0x000712A2 File Offset: 0x0006F4A2
		Friend Overridable Property Label36 As Label

		' Token: 0x17006295 RID: 25237
		' (get) Token: 0x060101CD RID: 65997 RVA: 0x000712AB File Offset: 0x0006F4AB
		' (set) Token: 0x060101CE RID: 65998 RVA: 0x000712B5 File Offset: 0x0006F4B5
		Friend Overridable Property ComboBox43 As ComboBox

		' Token: 0x17006296 RID: 25238
		' (get) Token: 0x060101CF RID: 65999 RVA: 0x000712BE File Offset: 0x0006F4BE
		' (set) Token: 0x060101D0 RID: 66000 RVA: 0x000712C8 File Offset: 0x0006F4C8
		Friend Overridable Property Label52 As Label

		' Token: 0x17006297 RID: 25239
		' (get) Token: 0x060101D1 RID: 66001 RVA: 0x000712D1 File Offset: 0x0006F4D1
		' (set) Token: 0x060101D2 RID: 66002 RVA: 0x000712DB File Offset: 0x0006F4DB
		Friend Overridable Property ComboBox50 As ComboBox

		' Token: 0x17006298 RID: 25240
		' (get) Token: 0x060101D3 RID: 66003 RVA: 0x000712E4 File Offset: 0x0006F4E4
		' (set) Token: 0x060101D4 RID: 66004 RVA: 0x000712EE File Offset: 0x0006F4EE
		Friend Overridable Property Label51 As Label

		' Token: 0x17006299 RID: 25241
		' (get) Token: 0x060101D5 RID: 66005 RVA: 0x000712F7 File Offset: 0x0006F4F7
		' (set) Token: 0x060101D6 RID: 66006 RVA: 0x00071301 File Offset: 0x0006F501
		Friend Overridable Property ComboBox49 As ComboBox

		' Token: 0x1700629A RID: 25242
		' (get) Token: 0x060101D7 RID: 66007 RVA: 0x0007130A File Offset: 0x0006F50A
		' (set) Token: 0x060101D8 RID: 66008 RVA: 0x00071314 File Offset: 0x0006F514
		Friend Overridable Property Label53 As Label

		' Token: 0x1700629B RID: 25243
		' (get) Token: 0x060101D9 RID: 66009 RVA: 0x0007131D File Offset: 0x0006F51D
		' (set) Token: 0x060101DA RID: 66010 RVA: 0x00071327 File Offset: 0x0006F527
		Friend Overridable Property ComboBox51 As ComboBox

		' Token: 0x1700629C RID: 25244
		' (get) Token: 0x060101DB RID: 66011 RVA: 0x00071330 File Offset: 0x0006F530
		' (set) Token: 0x060101DC RID: 66012 RVA: 0x0007133A File Offset: 0x0006F53A
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700629D RID: 25245
		' (get) Token: 0x060101DD RID: 66013 RVA: 0x00071343 File Offset: 0x0006F543
		' (set) Token: 0x060101DE RID: 66014 RVA: 0x0007134D File Offset: 0x0006F54D
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x1700629E RID: 25246
		' (get) Token: 0x060101DF RID: 66015 RVA: 0x00071356 File Offset: 0x0006F556
		' (set) Token: 0x060101E0 RID: 66016 RVA: 0x00071360 File Offset: 0x0006F560
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x1700629F RID: 25247
		' (get) Token: 0x060101E1 RID: 66017 RVA: 0x00071369 File Offset: 0x0006F569
		' (set) Token: 0x060101E2 RID: 66018 RVA: 0x00071373 File Offset: 0x0006F573
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170062A0 RID: 25248
		' (get) Token: 0x060101E3 RID: 66019 RVA: 0x0007137C File Offset: 0x0006F57C
		' (set) Token: 0x060101E4 RID: 66020 RVA: 0x00071386 File Offset: 0x0006F586
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170062A1 RID: 25249
		' (get) Token: 0x060101E5 RID: 66021 RVA: 0x0007138F File Offset: 0x0006F58F
		' (set) Token: 0x060101E6 RID: 66022 RVA: 0x00071399 File Offset: 0x0006F599
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170062A2 RID: 25250
		' (get) Token: 0x060101E7 RID: 66023 RVA: 0x000713A2 File Offset: 0x0006F5A2
		' (set) Token: 0x060101E8 RID: 66024 RVA: 0x000713AC File Offset: 0x0006F5AC
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170062A3 RID: 25251
		' (get) Token: 0x060101E9 RID: 66025 RVA: 0x000713B5 File Offset: 0x0006F5B5
		' (set) Token: 0x060101EA RID: 66026 RVA: 0x000713BF File Offset: 0x0006F5BF
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170062A4 RID: 25252
		' (get) Token: 0x060101EB RID: 66027 RVA: 0x000713C8 File Offset: 0x0006F5C8
		' (set) Token: 0x060101EC RID: 66028 RVA: 0x000713D2 File Offset: 0x0006F5D2
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170062A5 RID: 25253
		' (get) Token: 0x060101ED RID: 66029 RVA: 0x000713DB File Offset: 0x0006F5DB
		' (set) Token: 0x060101EE RID: 66030 RVA: 0x000713E5 File Offset: 0x0006F5E5
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170062A6 RID: 25254
		' (get) Token: 0x060101EF RID: 66031 RVA: 0x000713EE File Offset: 0x0006F5EE
		' (set) Token: 0x060101F0 RID: 66032 RVA: 0x000713F8 File Offset: 0x0006F5F8
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170062A7 RID: 25255
		' (get) Token: 0x060101F1 RID: 66033 RVA: 0x00071401 File Offset: 0x0006F601
		' (set) Token: 0x060101F2 RID: 66034 RVA: 0x0007140B File Offset: 0x0006F60B
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170062A8 RID: 25256
		' (get) Token: 0x060101F3 RID: 66035 RVA: 0x00071414 File Offset: 0x0006F614
		' (set) Token: 0x060101F4 RID: 66036 RVA: 0x0007141E File Offset: 0x0006F61E
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170062A9 RID: 25257
		' (get) Token: 0x060101F5 RID: 66037 RVA: 0x00071427 File Offset: 0x0006F627
		' (set) Token: 0x060101F6 RID: 66038 RVA: 0x00071431 File Offset: 0x0006F631
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170062AA RID: 25258
		' (get) Token: 0x060101F7 RID: 66039 RVA: 0x0007143A File Offset: 0x0006F63A
		' (set) Token: 0x060101F8 RID: 66040 RVA: 0x00071444 File Offset: 0x0006F644
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170062AB RID: 25259
		' (get) Token: 0x060101F9 RID: 66041 RVA: 0x0007144D File Offset: 0x0006F64D
		' (set) Token: 0x060101FA RID: 66042 RVA: 0x00071457 File Offset: 0x0006F657
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170062AC RID: 25260
		' (get) Token: 0x060101FB RID: 66043 RVA: 0x00071460 File Offset: 0x0006F660
		' (set) Token: 0x060101FC RID: 66044 RVA: 0x0007146A File Offset: 0x0006F66A
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170062AD RID: 25261
		' (get) Token: 0x060101FD RID: 66045 RVA: 0x00071473 File Offset: 0x0006F673
		' (set) Token: 0x060101FE RID: 66046 RVA: 0x0007147D File Offset: 0x0006F67D
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170062AE RID: 25262
		' (get) Token: 0x060101FF RID: 66047 RVA: 0x00071486 File Offset: 0x0006F686
		' (set) Token: 0x06010200 RID: 66048 RVA: 0x00071490 File Offset: 0x0006F690
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170062AF RID: 25263
		' (get) Token: 0x06010201 RID: 66049 RVA: 0x00071499 File Offset: 0x0006F699
		' (set) Token: 0x06010202 RID: 66050 RVA: 0x000714A3 File Offset: 0x0006F6A3
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170062B0 RID: 25264
		' (get) Token: 0x06010203 RID: 66051 RVA: 0x000714AC File Offset: 0x0006F6AC
		' (set) Token: 0x06010204 RID: 66052 RVA: 0x000714B6 File Offset: 0x0006F6B6
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170062B1 RID: 25265
		' (get) Token: 0x06010205 RID: 66053 RVA: 0x000714BF File Offset: 0x0006F6BF
		' (set) Token: 0x06010206 RID: 66054 RVA: 0x000714C9 File Offset: 0x0006F6C9
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170062B2 RID: 25266
		' (get) Token: 0x06010207 RID: 66055 RVA: 0x000714D2 File Offset: 0x0006F6D2
		' (set) Token: 0x06010208 RID: 66056 RVA: 0x000714DC File Offset: 0x0006F6DC
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170062B3 RID: 25267
		' (get) Token: 0x06010209 RID: 66057 RVA: 0x000714E5 File Offset: 0x0006F6E5
		' (set) Token: 0x0601020A RID: 66058 RVA: 0x000714EF File Offset: 0x0006F6EF
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170062B4 RID: 25268
		' (get) Token: 0x0601020B RID: 66059 RVA: 0x000714F8 File Offset: 0x0006F6F8
		' (set) Token: 0x0601020C RID: 66060 RVA: 0x00071502 File Offset: 0x0006F702
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170062B5 RID: 25269
		' (get) Token: 0x0601020D RID: 66061 RVA: 0x0007150B File Offset: 0x0006F70B
		' (set) Token: 0x0601020E RID: 66062 RVA: 0x00071515 File Offset: 0x0006F715
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170062B6 RID: 25270
		' (get) Token: 0x0601020F RID: 66063 RVA: 0x0007151E File Offset: 0x0006F71E
		' (set) Token: 0x06010210 RID: 66064 RVA: 0x00071528 File Offset: 0x0006F728
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170062B7 RID: 25271
		' (get) Token: 0x06010211 RID: 66065 RVA: 0x00071531 File Offset: 0x0006F731
		' (set) Token: 0x06010212 RID: 66066 RVA: 0x0007153B File Offset: 0x0006F73B
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170062B8 RID: 25272
		' (get) Token: 0x06010213 RID: 66067 RVA: 0x00071544 File Offset: 0x0006F744
		' (set) Token: 0x06010214 RID: 66068 RVA: 0x0007154E File Offset: 0x0006F74E
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170062B9 RID: 25273
		' (get) Token: 0x06010215 RID: 66069 RVA: 0x00071557 File Offset: 0x0006F757
		' (set) Token: 0x06010216 RID: 66070 RVA: 0x00071561 File Offset: 0x0006F761
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170062BA RID: 25274
		' (get) Token: 0x06010217 RID: 66071 RVA: 0x0007156A File Offset: 0x0006F76A
		' (set) Token: 0x06010218 RID: 66072 RVA: 0x00071574 File Offset: 0x0006F774
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170062BB RID: 25275
		' (get) Token: 0x06010219 RID: 66073 RVA: 0x0007157D File Offset: 0x0006F77D
		' (set) Token: 0x0601021A RID: 66074 RVA: 0x00071587 File Offset: 0x0006F787
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170062BC RID: 25276
		' (get) Token: 0x0601021B RID: 66075 RVA: 0x00071590 File Offset: 0x0006F790
		' (set) Token: 0x0601021C RID: 66076 RVA: 0x0007159A File Offset: 0x0006F79A
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170062BD RID: 25277
		' (get) Token: 0x0601021D RID: 66077 RVA: 0x000715A3 File Offset: 0x0006F7A3
		' (set) Token: 0x0601021E RID: 66078 RVA: 0x000715AD File Offset: 0x0006F7AD
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x170062BE RID: 25278
		' (get) Token: 0x0601021F RID: 66079 RVA: 0x000715B6 File Offset: 0x0006F7B6
		' (set) Token: 0x06010220 RID: 66080 RVA: 0x000715C0 File Offset: 0x0006F7C0
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170062BF RID: 25279
		' (get) Token: 0x06010221 RID: 66081 RVA: 0x000715C9 File Offset: 0x0006F7C9
		' (set) Token: 0x06010222 RID: 66082 RVA: 0x000715D3 File Offset: 0x0006F7D3
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170062C0 RID: 25280
		' (get) Token: 0x06010223 RID: 66083 RVA: 0x000715DC File Offset: 0x0006F7DC
		' (set) Token: 0x06010224 RID: 66084 RVA: 0x000715E6 File Offset: 0x0006F7E6
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x170062C1 RID: 25281
		' (get) Token: 0x06010225 RID: 66085 RVA: 0x000715EF File Offset: 0x0006F7EF
		' (set) Token: 0x06010226 RID: 66086 RVA: 0x000715F9 File Offset: 0x0006F7F9
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x170062C2 RID: 25282
		' (get) Token: 0x06010227 RID: 66087 RVA: 0x00071602 File Offset: 0x0006F802
		' (set) Token: 0x06010228 RID: 66088 RVA: 0x0007160C File Offset: 0x0006F80C
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x170062C3 RID: 25283
		' (get) Token: 0x06010229 RID: 66089 RVA: 0x00071615 File Offset: 0x0006F815
		' (set) Token: 0x0601022A RID: 66090 RVA: 0x0007161F File Offset: 0x0006F81F
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x170062C4 RID: 25284
		' (get) Token: 0x0601022B RID: 66091 RVA: 0x00071628 File Offset: 0x0006F828
		' (set) Token: 0x0601022C RID: 66092 RVA: 0x00071632 File Offset: 0x0006F832
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x170062C5 RID: 25285
		' (get) Token: 0x0601022D RID: 66093 RVA: 0x0007163B File Offset: 0x0006F83B
		' (set) Token: 0x0601022E RID: 66094 RVA: 0x00071645 File Offset: 0x0006F845
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x170062C6 RID: 25286
		' (get) Token: 0x0601022F RID: 66095 RVA: 0x0007164E File Offset: 0x0006F84E
		' (set) Token: 0x06010230 RID: 66096 RVA: 0x00071658 File Offset: 0x0006F858
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x170062C7 RID: 25287
		' (get) Token: 0x06010231 RID: 66097 RVA: 0x00071661 File Offset: 0x0006F861
		' (set) Token: 0x06010232 RID: 66098 RVA: 0x0007166B File Offset: 0x0006F86B
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x170062C8 RID: 25288
		' (get) Token: 0x06010233 RID: 66099 RVA: 0x00071674 File Offset: 0x0006F874
		' (set) Token: 0x06010234 RID: 66100 RVA: 0x0007167E File Offset: 0x0006F87E
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x170062C9 RID: 25289
		' (get) Token: 0x06010235 RID: 66101 RVA: 0x00071687 File Offset: 0x0006F887
		' (set) Token: 0x06010236 RID: 66102 RVA: 0x00071691 File Offset: 0x0006F891
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x170062CA RID: 25290
		' (get) Token: 0x06010237 RID: 66103 RVA: 0x0007169A File Offset: 0x0006F89A
		' (set) Token: 0x06010238 RID: 66104 RVA: 0x000716A4 File Offset: 0x0006F8A4
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x170062CB RID: 25291
		' (get) Token: 0x06010239 RID: 66105 RVA: 0x000716AD File Offset: 0x0006F8AD
		' (set) Token: 0x0601023A RID: 66106 RVA: 0x000716B7 File Offset: 0x0006F8B7
		Friend Overridable Property Column48 As DataGridViewTextBoxColumn

		' Token: 0x170062CC RID: 25292
		' (get) Token: 0x0601023B RID: 66107 RVA: 0x000716C0 File Offset: 0x0006F8C0
		' (set) Token: 0x0601023C RID: 66108 RVA: 0x000716CA File Offset: 0x0006F8CA
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x170062CD RID: 25293
		' (get) Token: 0x0601023D RID: 66109 RVA: 0x000716D3 File Offset: 0x0006F8D3
		' (set) Token: 0x0601023E RID: 66110 RVA: 0x000716DD File Offset: 0x0006F8DD
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x170062CE RID: 25294
		' (get) Token: 0x0601023F RID: 66111 RVA: 0x000716E6 File Offset: 0x0006F8E6
		' (set) Token: 0x06010240 RID: 66112 RVA: 0x000716F0 File Offset: 0x0006F8F0
		Friend Overridable Property Column51 As DataGridViewTextBoxColumn

		' Token: 0x170062CF RID: 25295
		' (get) Token: 0x06010241 RID: 66113 RVA: 0x000716F9 File Offset: 0x0006F8F9
		' (set) Token: 0x06010242 RID: 66114 RVA: 0x00071703 File Offset: 0x0006F903
		Friend Overridable Property Column52 As DataGridViewTextBoxColumn

		' Token: 0x170062D0 RID: 25296
		' (get) Token: 0x06010243 RID: 66115 RVA: 0x0007170C File Offset: 0x0006F90C
		' (set) Token: 0x06010244 RID: 66116 RVA: 0x00071716 File Offset: 0x0006F916
		Friend Overridable Property Column53 As DataGridViewTextBoxColumn

		' Token: 0x170062D1 RID: 25297
		' (get) Token: 0x06010245 RID: 66117 RVA: 0x0007171F File Offset: 0x0006F91F
		' (set) Token: 0x06010246 RID: 66118 RVA: 0x00071729 File Offset: 0x0006F929
		Friend Overridable Property Label54 As Label

		' Token: 0x170062D2 RID: 25298
		' (get) Token: 0x06010247 RID: 66119 RVA: 0x00071732 File Offset: 0x0006F932
		' (set) Token: 0x06010248 RID: 66120 RVA: 0x0007173C File Offset: 0x0006F93C
		Friend Overridable Property ShapeContainer1 As ShapeContainer

		' Token: 0x170062D3 RID: 25299
		' (get) Token: 0x06010249 RID: 66121 RVA: 0x00071745 File Offset: 0x0006F945
		' (set) Token: 0x0601024A RID: 66122 RVA: 0x0007174F File Offset: 0x0006F94F
		Friend Overridable Property LineShape2 As LineShape

		' Token: 0x170062D4 RID: 25300
		' (get) Token: 0x0601024B RID: 66123 RVA: 0x00071758 File Offset: 0x0006F958
		' (set) Token: 0x0601024C RID: 66124 RVA: 0x00071762 File Offset: 0x0006F962
		Friend Overridable Property LineShape1 As LineShape

		' Token: 0x170062D5 RID: 25301
		' (get) Token: 0x0601024D RID: 66125 RVA: 0x0007176B File Offset: 0x0006F96B
		' (set) Token: 0x0601024E RID: 66126 RVA: 0x0099D310 File Offset: 0x0099B510
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

		' Token: 0x170062D6 RID: 25302
		' (get) Token: 0x0601024F RID: 66127 RVA: 0x00071775 File Offset: 0x0006F975
		' (set) Token: 0x06010250 RID: 66128 RVA: 0x0099D354 File Offset: 0x0099B554
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

		' Token: 0x170062D7 RID: 25303
		' (get) Token: 0x06010251 RID: 66129 RVA: 0x0007177F File Offset: 0x0006F97F
		' (set) Token: 0x06010252 RID: 66130 RVA: 0x0099D398 File Offset: 0x0099B598
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

		' Token: 0x170062D8 RID: 25304
		' (get) Token: 0x06010253 RID: 66131 RVA: 0x00071789 File Offset: 0x0006F989
		' (set) Token: 0x06010254 RID: 66132 RVA: 0x0099D3DC File Offset: 0x0099B5DC
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

		' Token: 0x06010255 RID: 66133 RVA: 0x0099D420 File Offset: 0x0099B620
		Private Sub Reset()
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.cmbUserID.SelectedIndex = -1
			Me.Getdata()
			Me.combo()
		End Sub

		' Token: 0x06010256 RID: 66134 RVA: 0x0099D470 File Offset: 0x0099B670
		Private Sub combo()
			Me.ComboBox1.SelectedIndex = 0
			Me.ComboBox2.SelectedIndex = 0
			Me.ComboBox3.SelectedIndex = 0
			Me.ComboBox4.SelectedIndex = 0
			Me.ComboBox5.SelectedIndex = 0
			Me.ComboBox6.SelectedIndex = 0
			Me.ComboBox7.SelectedIndex = 0
			Me.ComboBox8.SelectedIndex = 0
			Me.ComboBox9.SelectedIndex = 0
			Me.ComboBox10.SelectedIndex = 0
			Me.ComboBox11.SelectedIndex = 0
			Me.ComboBox12.SelectedIndex = 0
			Me.ComboBox13.SelectedIndex = 0
			Me.ComboBox14.SelectedIndex = 0
			Me.ComboBox15.SelectedIndex = 0
			Me.ComboBox16.SelectedIndex = 0
			Me.ComboBox17.SelectedIndex = 0
			Me.ComboBox18.SelectedIndex = 0
			Me.ComboBox19.SelectedIndex = 0
			Me.ComboBox20.SelectedIndex = 0
			Me.ComboBox21.SelectedIndex = 0
			Me.ComboBox22.SelectedIndex = 0
			Me.ComboBox23.SelectedIndex = 0
			Me.ComboBox24.SelectedIndex = 0
			Me.ComboBox25.SelectedIndex = 0
			Me.ComboBox26.SelectedIndex = 0
			Me.ComboBox27.SelectedIndex = 0
			Me.ComboBox28.SelectedIndex = 0
			Me.ComboBox29.SelectedIndex = 0
			Me.ComboBox30.SelectedIndex = 0
			Me.ComboBox31.SelectedIndex = 0
			Me.ComboBox32.SelectedIndex = 0
			Me.ComboBox33.SelectedIndex = 0
			Me.ComboBox34.SelectedIndex = 0
			Me.ComboBox35.SelectedIndex = 0
			Me.ComboBox36.SelectedIndex = 0
			Me.ComboBox37.SelectedIndex = 0
			Me.ComboBox38.SelectedIndex = 0
			Me.ComboBox39.SelectedIndex = 0
			Me.ComboBox40.SelectedIndex = 0
			Me.ComboBox41.SelectedIndex = 0
			Me.ComboBox42.SelectedIndex = 0
			Me.ComboBox43.SelectedIndex = 0
			Me.ComboBox44.SelectedIndex = 0
			Me.ComboBox45.SelectedIndex = 0
			Me.ComboBox46.SelectedIndex = 0
			Me.ComboBox47.SelectedIndex = 0
			Me.ComboBox48.SelectedIndex = 0
			Me.ComboBox49.SelectedIndex = 0
			Me.ComboBox50.SelectedIndex = 0
			Me.ComboBox51.SelectedIndex = 0
		End Sub

		' Token: 0x06010257 RID: 66135 RVA: 0x0099D718 File Offset: 0x0099B918
		Public Sub FillUserID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select distinct RTRIM(UserID) from Registration where UserType NOT IN ('*****') Order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.cmbUserID.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Me.cmbUserID.Items.Add(ModCommonClasses.rdr.GetValue(0).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010258 RID: 66136 RVA: 0x00071793 File Offset: 0x0006F993
		Private Sub frmUserControl_Load(sender As Object, e As EventArgs)
			Me.combo()
			Me.FillUserID()
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x06010259 RID: 66137 RVA: 0x0099D7EC File Offset: 0x0099B9EC
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

		' Token: 0x0601025A RID: 66138 RVA: 0x0099D964 File Offset: 0x0099BB64
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

		' Token: 0x0601025B RID: 66139 RVA: 0x0099DA20 File Offset: 0x0099BC20
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

		' Token: 0x0601025C RID: 66140 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601025D RID: 66141 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0601025E RID: 66142 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601025F RID: 66143 RVA: 0x0099DAEC File Offset: 0x0099BCEC
		Private Sub dgw_RowPostPaint1(sender As Object, e As DataGridViewRowPostPaintEventArgs)
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

		' Token: 0x06010260 RID: 66144 RVA: 0x0099DBD4 File Offset: 0x0099BDD4
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(UserID), RTRIM(c1), RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5), RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c10),RTRIM(c11),RTRIM(c12),RTRIM(c13),RTRIM(c14),RTRIM(c15),RTRIM(c16),RTRIM(c17),RTRIM(c18),RTRIM(c19),RTRIM(c20),RTRIM(c21),RTRIM(c22),RTRIM(c23),RTRIM(c24),RTRIM(c25),RTRIM(c26),RTRIM(c27),RTRIM(c28),RTRIM(c29),RTRIM(c30),RTRIM(c31),RTRIM(c32),RTRIM(c33),RTRIM(c34),RTRIM(c35),RTRIM(c36),RTRIM(c37),RTRIM(c38),RTRIM(c39),RTRIM(c40),RTRIM(c41),RTRIM(c42),RTRIM(c43),RTRIM(c44),RTRIM(c45),RTRIM(c46),RTRIM(c47),RTRIM(c48),RTRIM(c49),RTRIM(c50),RTRIM(c51) from UserControl order by 2", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48), ModCommonClasses.rdr(49), ModCommonClasses.rdr(50), ModCommonClasses.rdr(51), ModCommonClasses.rdr(52) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010261 RID: 66145 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmUserControl_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010262 RID: 66146 RVA: 0x000717B2 File Offset: 0x0006F9B2
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010263 RID: 66147 RVA: 0x0099DFFC File Offset: 0x0099C1FC
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbUserID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please select user id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbUserID.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select UserID from UserControl where UserID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUserID.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("Record already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into UserControl(UserID,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14,c15,c16,c17,c18,c19,c20,c21,c22,c23,c24,c25,c26,c27,c28,c29,c30,c31,c32,c33,c34,c35,c36,c37,c38,c39,c40,c41,c42,c43,c44,c45,c46,c47,c48,c49,c50,c51) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35,@d36,@d37,@d38,@d39,@d40,@d41,@d42,@d43,@d44,@d45,@d46,@d47,@d48,@d49,@d50,@d51,@d52)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUserID.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.ComboBox3.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ComboBox4.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.ComboBox5.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.ComboBox6.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox7.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.ComboBox8.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.ComboBox9.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.ComboBox10.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.ComboBox11.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.ComboBox12.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.ComboBox13.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.ComboBox14.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.ComboBox15.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.ComboBox16.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.ComboBox17.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.ComboBox18.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Me.ComboBox19.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Me.ComboBox20.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.ComboBox21.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.ComboBox22.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.ComboBox23.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Me.ComboBox24.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.ComboBox25.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Me.ComboBox26.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Me.ComboBox27.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Me.ComboBox28.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Me.ComboBox29.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d31", Me.ComboBox30.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d32", Me.ComboBox31.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox32.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d34", Me.ComboBox33.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d35", Me.ComboBox34.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d36", Me.ComboBox35.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d37", Me.ComboBox36.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d38", Me.ComboBox37.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d39", Me.ComboBox38.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d40", Me.ComboBox39.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d41", Me.ComboBox40.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d42", Me.ComboBox41.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d43", Me.ComboBox42.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d44", Me.ComboBox46.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d45", Me.ComboBox45.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d46", Me.ComboBox49.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d47", Me.ComboBox43.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d48", Me.ComboBox44.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d49", Me.ComboBox50.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d50", Me.ComboBox48.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d51", Me.ComboBox47.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d52", Me.ComboBox51.Text)
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Saved", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Reset()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06010264 RID: 66148 RVA: 0x0099E8C8 File Offset: 0x0099CAC8
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbUserID.Text)) = 0
			If flag Then
				MessageBox.Show("Please select user id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbUserID.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = If(("Update UserControl set UserID=@d1,c1=@d2,c2=@d3,c3=@d4,c4=@d5,c5=@d6,c6=@d7,c7=@d8,c8=@d9,c9=@d10,c10=@d11,c11=@d12,c12=@d13,c13=@d14,c14=@d15,c15=@d16,c16=@d17,c17=@d18,c18=@d19,c19=@d20,c20=@d21,c21=@d22,c22=@d23,c23=@d24,c24=@d25,c25=@d26,c26=@d27,c27=@d28,c28=@d29,c29=@d30,c30=@d31,c31=@d32,c32=@d33,c33=@d34,c34=@d35,c35=@d36,c36=@d37,c37=@d38,c38=@d39,c39=@d40,c40=@d41,c41=@d42,c42=@d43,c43=@d44,c44=@d45,c45=@d46,c46=@d47,c47=@d48,c48=@d49,c49=@d50,c50=@d51,c51=@d52 where ID=" + Conversions.ToString(Conversion.Val(Me.txtID.Text))), "")
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUserID.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ComboBox1.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.ComboBox3.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ComboBox4.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.ComboBox5.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.ComboBox6.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox7.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.ComboBox8.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.ComboBox9.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.ComboBox10.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.ComboBox11.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.ComboBox12.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.ComboBox13.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.ComboBox14.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.ComboBox15.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.ComboBox16.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.ComboBox17.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.ComboBox18.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Me.ComboBox19.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Me.ComboBox20.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.ComboBox21.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.ComboBox22.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.ComboBox23.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Me.ComboBox24.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.ComboBox25.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Me.ComboBox26.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Me.ComboBox27.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Me.ComboBox28.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Me.ComboBox29.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d31", Me.ComboBox30.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d32", Me.ComboBox31.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox32.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d34", Me.ComboBox33.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d35", Me.ComboBox34.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d36", Me.ComboBox35.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d37", Me.ComboBox36.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d38", Me.ComboBox37.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d39", Me.ComboBox38.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d40", Me.ComboBox39.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d41", Me.ComboBox40.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d42", Me.ComboBox41.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d43", Me.ComboBox42.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d44", Me.ComboBox46.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d45", Me.ComboBox45.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d46", Me.ComboBox49.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d47", Me.ComboBox43.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d48", Me.ComboBox44.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d49", Me.ComboBox50.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d50", Me.ComboBox48.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d51", Me.ComboBox47.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d52", Me.ComboBox51.Text)
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06010265 RID: 66149 RVA: 0x0099F068 File Offset: 0x0099D268
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from UserControl where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

		' Token: 0x06010266 RID: 66150 RVA: 0x0099F180 File Offset: 0x0099D380
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbUserID.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.ComboBox1.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.ComboBox2.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.ComboBox3.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.ComboBox4.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.ComboBox5.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.ComboBox6.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.ComboBox7.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.ComboBox8.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.ComboBox9.Text = dataGridViewRow.Cells(10).Value.ToString()
					Me.ComboBox10.Text = dataGridViewRow.Cells(11).Value.ToString()
					Me.ComboBox11.Text = dataGridViewRow.Cells(12).Value.ToString()
					Me.ComboBox12.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.ComboBox13.Text = dataGridViewRow.Cells(14).Value.ToString()
					Me.ComboBox14.Text = dataGridViewRow.Cells(15).Value.ToString()
					Me.ComboBox15.Text = dataGridViewRow.Cells(16).Value.ToString()
					Me.ComboBox16.Text = dataGridViewRow.Cells(17).Value.ToString()
					Me.ComboBox17.Text = dataGridViewRow.Cells(18).Value.ToString()
					Me.ComboBox18.Text = dataGridViewRow.Cells(19).Value.ToString()
					Me.ComboBox19.Text = dataGridViewRow.Cells(20).Value.ToString()
					Me.ComboBox20.Text = dataGridViewRow.Cells(21).Value.ToString()
					Me.ComboBox21.Text = dataGridViewRow.Cells(22).Value.ToString()
					Me.ComboBox22.Text = dataGridViewRow.Cells(23).Value.ToString()
					Me.ComboBox23.Text = dataGridViewRow.Cells(24).Value.ToString()
					Me.ComboBox24.Text = dataGridViewRow.Cells(25).Value.ToString()
					Me.ComboBox25.Text = dataGridViewRow.Cells(26).Value.ToString()
					Me.ComboBox26.Text = dataGridViewRow.Cells(27).Value.ToString()
					Me.ComboBox27.Text = dataGridViewRow.Cells(28).Value.ToString()
					Me.ComboBox28.Text = dataGridViewRow.Cells(29).Value.ToString()
					Me.ComboBox29.Text = dataGridViewRow.Cells(30).Value.ToString()
					Me.ComboBox30.Text = dataGridViewRow.Cells(31).Value.ToString()
					Me.ComboBox31.Text = dataGridViewRow.Cells(32).Value.ToString()
					Me.ComboBox32.Text = dataGridViewRow.Cells(33).Value.ToString()
					Me.ComboBox33.Text = dataGridViewRow.Cells(34).Value.ToString()
					Me.ComboBox34.Text = dataGridViewRow.Cells(35).Value.ToString()
					Me.ComboBox35.Text = dataGridViewRow.Cells(36).Value.ToString()
					Me.ComboBox36.Text = dataGridViewRow.Cells(37).Value.ToString()
					Me.ComboBox37.Text = dataGridViewRow.Cells(38).Value.ToString()
					Me.ComboBox38.Text = dataGridViewRow.Cells(39).Value.ToString()
					Me.ComboBox39.Text = dataGridViewRow.Cells(40).Value.ToString()
					Me.ComboBox40.Text = dataGridViewRow.Cells(41).Value.ToString()
					Me.ComboBox41.Text = dataGridViewRow.Cells(42).Value.ToString()
					Me.ComboBox42.Text = dataGridViewRow.Cells(43).Value.ToString()
					Me.ComboBox46.Text = dataGridViewRow.Cells(44).Value.ToString()
					Me.ComboBox45.Text = dataGridViewRow.Cells(45).Value.ToString()
					Me.ComboBox49.Text = dataGridViewRow.Cells(46).Value.ToString()
					Me.ComboBox43.Text = dataGridViewRow.Cells(47).Value.ToString()
					Me.ComboBox44.Text = dataGridViewRow.Cells(48).Value.ToString()
					Me.ComboBox50.Text = dataGridViewRow.Cells(49).Value.ToString()
					Me.ComboBox48.Text = dataGridViewRow.Cells(50).Value.ToString()
					Me.ComboBox47.Text = dataGridViewRow.Cells(51).Value.ToString()
					Me.ComboBox51.Text = dataGridViewRow.Cells(52).Value.ToString()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06010267 RID: 66151 RVA: 0x0099F948 File Offset: 0x0099DB48
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
	End Class
End Namespace
