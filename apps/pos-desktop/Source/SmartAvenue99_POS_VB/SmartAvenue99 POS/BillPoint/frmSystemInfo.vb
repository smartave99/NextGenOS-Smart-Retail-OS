Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004E0 RID: 1248
	<DesignerGenerated()>
	Public Partial Class frmSystemInfo
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FE57 RID: 65111 RVA: 0x00980DB4 File Offset: 0x0097EFB4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.MainForm_Load
			AddHandler MyBase.Closed, AddressOf Me.frmSystemInfo_Closed
			AddHandler MyBase.KeyDown, AddressOf Me.frmSystemInfo_KeyDown
			Me.h = Dns.GetHostByName(Dns.GetHostName())
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700612C RID: 24876
		' (get) Token: 0x0600FE5A RID: 65114 RVA: 0x0006F75C File Offset: 0x0006D95C
		' (set) Token: 0x0600FE5B RID: 65115 RVA: 0x0006F766 File Offset: 0x0006D966
		Friend Overridable Property MenuStrip1 As MenuStrip

		' Token: 0x1700612D RID: 24877
		' (get) Token: 0x0600FE5C RID: 65116 RVA: 0x0006F76F File Offset: 0x0006D96F
		' (set) Token: 0x0600FE5D RID: 65117 RVA: 0x0006F779 File Offset: 0x0006D979
		Friend Overridable Property FileToolStripMenuItem As ToolStripMenuItem

		' Token: 0x1700612E RID: 24878
		' (get) Token: 0x0600FE5E RID: 65118 RVA: 0x0006F782 File Offset: 0x0006D982
		' (set) Token: 0x0600FE5F RID: 65119 RVA: 0x0098342C File Offset: 0x0098162C
		Private _SaveToFileToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SaveToFileToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SaveToFileToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SaveToFileToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SaveToFileToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SaveToFileToolStripMenuItem = value
				toolStripMenuItem = Me._SaveToFileToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700612F RID: 24879
		' (get) Token: 0x0600FE60 RID: 65120 RVA: 0x0006F78C File Offset: 0x0006D98C
		' (set) Token: 0x0600FE61 RID: 65121 RVA: 0x0006F796 File Offset: 0x0006D996
		Friend Overridable Property ToolStripMenuItem1 As ToolStripSeparator

		' Token: 0x17006130 RID: 24880
		' (get) Token: 0x0600FE62 RID: 65122 RVA: 0x0006F79F File Offset: 0x0006D99F
		' (set) Token: 0x0600FE63 RID: 65123 RVA: 0x00983470 File Offset: 0x00981670
		Private _ExitToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ExitToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ExitToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ExitToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ExitToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ExitToolStripMenuItem = value
				toolStripMenuItem = Me._ExitToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006131 RID: 24881
		' (get) Token: 0x0600FE64 RID: 65124 RVA: 0x0006F7A9 File Offset: 0x0006D9A9
		' (set) Token: 0x0600FE65 RID: 65125 RVA: 0x0006F7B3 File Offset: 0x0006D9B3
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006132 RID: 24882
		' (get) Token: 0x0600FE66 RID: 65126 RVA: 0x0006F7BC File Offset: 0x0006D9BC
		' (set) Token: 0x0600FE67 RID: 65127 RVA: 0x0006F7C6 File Offset: 0x0006D9C6
		Friend Overridable Property TabControl1 As TabControl

		' Token: 0x17006133 RID: 24883
		' (get) Token: 0x0600FE68 RID: 65128 RVA: 0x0006F7CF File Offset: 0x0006D9CF
		' (set) Token: 0x0600FE69 RID: 65129 RVA: 0x0006F7D9 File Offset: 0x0006D9D9
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x17006134 RID: 24884
		' (get) Token: 0x0600FE6A RID: 65130 RVA: 0x0006F7E2 File Offset: 0x0006D9E2
		' (set) Token: 0x0600FE6B RID: 65131 RVA: 0x0006F7EC File Offset: 0x0006D9EC
		Friend Overridable Property TabPage2 As TabPage

		' Token: 0x17006135 RID: 24885
		' (get) Token: 0x0600FE6C RID: 65132 RVA: 0x0006F7F5 File Offset: 0x0006D9F5
		' (set) Token: 0x0600FE6D RID: 65133 RVA: 0x0006F7FF File Offset: 0x0006D9FF
		Friend Overridable Property txtProcessorFamily As TextBox

		' Token: 0x17006136 RID: 24886
		' (get) Token: 0x0600FE6E RID: 65134 RVA: 0x0006F808 File Offset: 0x0006DA08
		' (set) Token: 0x0600FE6F RID: 65135 RVA: 0x0006F812 File Offset: 0x0006DA12
		Friend Overridable Property txtProcessorExtClock As TextBox

		' Token: 0x17006137 RID: 24887
		' (get) Token: 0x0600FE70 RID: 65136 RVA: 0x0006F81B File Offset: 0x0006DA1B
		' (set) Token: 0x0600FE71 RID: 65137 RVA: 0x0006F825 File Offset: 0x0006DA25
		Friend Overridable Property Label9 As Label

		' Token: 0x17006138 RID: 24888
		' (get) Token: 0x0600FE72 RID: 65138 RVA: 0x0006F82E File Offset: 0x0006DA2E
		' (set) Token: 0x0600FE73 RID: 65139 RVA: 0x0006F838 File Offset: 0x0006DA38
		Friend Overridable Property Label8 As Label

		' Token: 0x17006139 RID: 24889
		' (get) Token: 0x0600FE74 RID: 65140 RVA: 0x0006F841 File Offset: 0x0006DA41
		' (set) Token: 0x0600FE75 RID: 65141 RVA: 0x0006F84B File Offset: 0x0006DA4B
		Friend Overridable Property Label7 As Label

		' Token: 0x1700613A RID: 24890
		' (get) Token: 0x0600FE76 RID: 65142 RVA: 0x0006F854 File Offset: 0x0006DA54
		' (set) Token: 0x0600FE77 RID: 65143 RVA: 0x0006F85E File Offset: 0x0006DA5E
		Friend Overridable Property txtProcessorClockSpeed As TextBox

		' Token: 0x1700613B RID: 24891
		' (get) Token: 0x0600FE78 RID: 65144 RVA: 0x0006F867 File Offset: 0x0006DA67
		' (set) Token: 0x0600FE79 RID: 65145 RVA: 0x0006F871 File Offset: 0x0006DA71
		Friend Overridable Property txtProcessorDataWidth As TextBox

		' Token: 0x1700613C RID: 24892
		' (get) Token: 0x0600FE7A RID: 65146 RVA: 0x0006F87A File Offset: 0x0006DA7A
		' (set) Token: 0x0600FE7B RID: 65147 RVA: 0x0006F884 File Offset: 0x0006DA84
		Friend Overridable Property Label6 As Label

		' Token: 0x1700613D RID: 24893
		' (get) Token: 0x0600FE7C RID: 65148 RVA: 0x0006F88D File Offset: 0x0006DA8D
		' (set) Token: 0x0600FE7D RID: 65149 RVA: 0x0006F897 File Offset: 0x0006DA97
		Friend Overridable Property Label5 As Label

		' Token: 0x1700613E RID: 24894
		' (get) Token: 0x0600FE7E RID: 65150 RVA: 0x0006F8A0 File Offset: 0x0006DAA0
		' (set) Token: 0x0600FE7F RID: 65151 RVA: 0x0006F8AA File Offset: 0x0006DAAA
		Friend Overridable Property txtProcessorL2CacheSize As TextBox

		' Token: 0x1700613F RID: 24895
		' (get) Token: 0x0600FE80 RID: 65152 RVA: 0x0006F8B3 File Offset: 0x0006DAB3
		' (set) Token: 0x0600FE81 RID: 65153 RVA: 0x0006F8BD File Offset: 0x0006DABD
		Friend Overridable Property txtProcessorManufacturer As TextBox

		' Token: 0x17006140 RID: 24896
		' (get) Token: 0x0600FE82 RID: 65154 RVA: 0x0006F8C6 File Offset: 0x0006DAC6
		' (set) Token: 0x0600FE83 RID: 65155 RVA: 0x0006F8D0 File Offset: 0x0006DAD0
		Friend Overridable Property Label4 As Label

		' Token: 0x17006141 RID: 24897
		' (get) Token: 0x0600FE84 RID: 65156 RVA: 0x0006F8D9 File Offset: 0x0006DAD9
		' (set) Token: 0x0600FE85 RID: 65157 RVA: 0x0006F8E3 File Offset: 0x0006DAE3
		Friend Overridable Property txtProcessorDescription As TextBox

		' Token: 0x17006142 RID: 24898
		' (get) Token: 0x0600FE86 RID: 65158 RVA: 0x0006F8EC File Offset: 0x0006DAEC
		' (set) Token: 0x0600FE87 RID: 65159 RVA: 0x0006F8F6 File Offset: 0x0006DAF6
		Friend Overridable Property Label3 As Label

		' Token: 0x17006143 RID: 24899
		' (get) Token: 0x0600FE88 RID: 65160 RVA: 0x0006F8FF File Offset: 0x0006DAFF
		' (set) Token: 0x0600FE89 RID: 65161 RVA: 0x0006F909 File Offset: 0x0006DB09
		Friend Overridable Property txtProcessorID As TextBox

		' Token: 0x17006144 RID: 24900
		' (get) Token: 0x0600FE8A RID: 65162 RVA: 0x0006F912 File Offset: 0x0006DB12
		' (set) Token: 0x0600FE8B RID: 65163 RVA: 0x0006F91C File Offset: 0x0006DB1C
		Friend Overridable Property Label2 As Label

		' Token: 0x17006145 RID: 24901
		' (get) Token: 0x0600FE8C RID: 65164 RVA: 0x0006F925 File Offset: 0x0006DB25
		' (set) Token: 0x0600FE8D RID: 65165 RVA: 0x0006F92F File Offset: 0x0006DB2F
		Friend Overridable Property txtProcessorName As TextBox

		' Token: 0x17006146 RID: 24902
		' (get) Token: 0x0600FE8E RID: 65166 RVA: 0x0006F938 File Offset: 0x0006DB38
		' (set) Token: 0x0600FE8F RID: 65167 RVA: 0x0006F942 File Offset: 0x0006DB42
		Friend Overridable Property Label1 As Label

		' Token: 0x17006147 RID: 24903
		' (get) Token: 0x0600FE90 RID: 65168 RVA: 0x0006F94B File Offset: 0x0006DB4B
		' (set) Token: 0x0600FE91 RID: 65169 RVA: 0x0006F955 File Offset: 0x0006DB55
		Friend Overridable Property txtBoardSerialNumber As TextBox

		' Token: 0x17006148 RID: 24904
		' (get) Token: 0x0600FE92 RID: 65170 RVA: 0x0006F95E File Offset: 0x0006DB5E
		' (set) Token: 0x0600FE93 RID: 65171 RVA: 0x0006F968 File Offset: 0x0006DB68
		Friend Overridable Property Label13 As Label

		' Token: 0x17006149 RID: 24905
		' (get) Token: 0x0600FE94 RID: 65172 RVA: 0x0006F971 File Offset: 0x0006DB71
		' (set) Token: 0x0600FE95 RID: 65173 RVA: 0x0006F97B File Offset: 0x0006DB7B
		Friend Overridable Property txtBoardDescription As TextBox

		' Token: 0x1700614A RID: 24906
		' (get) Token: 0x0600FE96 RID: 65174 RVA: 0x0006F984 File Offset: 0x0006DB84
		' (set) Token: 0x0600FE97 RID: 65175 RVA: 0x0006F98E File Offset: 0x0006DB8E
		Friend Overridable Property Label12 As Label

		' Token: 0x1700614B RID: 24907
		' (get) Token: 0x0600FE98 RID: 65176 RVA: 0x0006F997 File Offset: 0x0006DB97
		' (set) Token: 0x0600FE99 RID: 65177 RVA: 0x0006F9A1 File Offset: 0x0006DBA1
		Friend Overridable Property txtBoardManufacturer As TextBox

		' Token: 0x1700614C RID: 24908
		' (get) Token: 0x0600FE9A RID: 65178 RVA: 0x0006F9AA File Offset: 0x0006DBAA
		' (set) Token: 0x0600FE9B RID: 65179 RVA: 0x0006F9B4 File Offset: 0x0006DBB4
		Friend Overridable Property Label11 As Label

		' Token: 0x1700614D RID: 24909
		' (get) Token: 0x0600FE9C RID: 65180 RVA: 0x0006F9BD File Offset: 0x0006DBBD
		' (set) Token: 0x0600FE9D RID: 65181 RVA: 0x0006F9C7 File Offset: 0x0006DBC7
		Friend Overridable Property txtBoardName As TextBox

		' Token: 0x1700614E RID: 24910
		' (get) Token: 0x0600FE9E RID: 65182 RVA: 0x0006F9D0 File Offset: 0x0006DBD0
		' (set) Token: 0x0600FE9F RID: 65183 RVA: 0x0006F9DA File Offset: 0x0006DBDA
		Friend Overridable Property Label10 As Label

		' Token: 0x1700614F RID: 24911
		' (get) Token: 0x0600FEA0 RID: 65184 RVA: 0x0006F9E3 File Offset: 0x0006DBE3
		' (set) Token: 0x0600FEA1 RID: 65185 RVA: 0x0006F9ED File Offset: 0x0006DBED
		Friend Overridable Property TabPage3 As TabPage

		' Token: 0x17006150 RID: 24912
		' (get) Token: 0x0600FEA2 RID: 65186 RVA: 0x0006F9F6 File Offset: 0x0006DBF6
		' (set) Token: 0x0600FEA3 RID: 65187 RVA: 0x0006FA00 File Offset: 0x0006DC00
		Friend Overridable Property Label22 As Label

		' Token: 0x17006151 RID: 24913
		' (get) Token: 0x0600FEA4 RID: 65188 RVA: 0x0006FA09 File Offset: 0x0006DC09
		' (set) Token: 0x0600FEA5 RID: 65189 RVA: 0x0006FA13 File Offset: 0x0006DC13
		Friend Overridable Property Label20 As Label

		' Token: 0x17006152 RID: 24914
		' (get) Token: 0x0600FEA6 RID: 65190 RVA: 0x0006FA1C File Offset: 0x0006DC1C
		' (set) Token: 0x0600FEA7 RID: 65191 RVA: 0x0006FA26 File Offset: 0x0006DC26
		Friend Overridable Property Label18 As Label

		' Token: 0x17006153 RID: 24915
		' (get) Token: 0x0600FEA8 RID: 65192 RVA: 0x0006FA2F File Offset: 0x0006DC2F
		' (set) Token: 0x0600FEA9 RID: 65193 RVA: 0x0006FA39 File Offset: 0x0006DC39
		Friend Overridable Property Label16 As Label

		' Token: 0x17006154 RID: 24916
		' (get) Token: 0x0600FEAA RID: 65194 RVA: 0x0006FA42 File Offset: 0x0006DC42
		' (set) Token: 0x0600FEAB RID: 65195 RVA: 0x0006FA4C File Offset: 0x0006DC4C
		Friend Overridable Property Label23 As Label

		' Token: 0x17006155 RID: 24917
		' (get) Token: 0x0600FEAC RID: 65196 RVA: 0x0006FA55 File Offset: 0x0006DC55
		' (set) Token: 0x0600FEAD RID: 65197 RVA: 0x0006FA5F File Offset: 0x0006DC5F
		Friend Overridable Property Label25 As Label

		' Token: 0x17006156 RID: 24918
		' (get) Token: 0x0600FEAE RID: 65198 RVA: 0x0006FA68 File Offset: 0x0006DC68
		' (set) Token: 0x0600FEAF RID: 65199 RVA: 0x0006FA72 File Offset: 0x0006DC72
		Friend Overridable Property Label27 As Label

		' Token: 0x17006157 RID: 24919
		' (get) Token: 0x0600FEB0 RID: 65200 RVA: 0x0006FA7B File Offset: 0x0006DC7B
		' (set) Token: 0x0600FEB1 RID: 65201 RVA: 0x0006FA85 File Offset: 0x0006DC85
		Friend Overridable Property Label32 As Label

		' Token: 0x17006158 RID: 24920
		' (get) Token: 0x0600FEB2 RID: 65202 RVA: 0x0006FA8E File Offset: 0x0006DC8E
		' (set) Token: 0x0600FEB3 RID: 65203 RVA: 0x0006FA98 File Offset: 0x0006DC98
		Friend Overridable Property Label33 As Label

		' Token: 0x17006159 RID: 24921
		' (get) Token: 0x0600FEB4 RID: 65204 RVA: 0x0006FAA1 File Offset: 0x0006DCA1
		' (set) Token: 0x0600FEB5 RID: 65205 RVA: 0x0006FAAB File Offset: 0x0006DCAB
		Friend Overridable Property Label34 As Label

		' Token: 0x1700615A RID: 24922
		' (get) Token: 0x0600FEB6 RID: 65206 RVA: 0x0006FAB4 File Offset: 0x0006DCB4
		' (set) Token: 0x0600FEB7 RID: 65207 RVA: 0x0006FABE File Offset: 0x0006DCBE
		Friend Overridable Property Label35 As Label

		' Token: 0x1700615B RID: 24923
		' (get) Token: 0x0600FEB8 RID: 65208 RVA: 0x0006FAC7 File Offset: 0x0006DCC7
		' (set) Token: 0x0600FEB9 RID: 65209 RVA: 0x0006FAD1 File Offset: 0x0006DCD1
		Friend Overridable Property TextBox11 As TextBox

		' Token: 0x1700615C RID: 24924
		' (get) Token: 0x0600FEBA RID: 65210 RVA: 0x0006FADA File Offset: 0x0006DCDA
		' (set) Token: 0x0600FEBB RID: 65211 RVA: 0x0006FAE4 File Offset: 0x0006DCE4
		Friend Overridable Property TextBox10 As TextBox

		' Token: 0x1700615D RID: 24925
		' (get) Token: 0x0600FEBC RID: 65212 RVA: 0x0006FAED File Offset: 0x0006DCED
		' (set) Token: 0x0600FEBD RID: 65213 RVA: 0x0006FAF7 File Offset: 0x0006DCF7
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x1700615E RID: 24926
		' (get) Token: 0x0600FEBE RID: 65214 RVA: 0x0006FB00 File Offset: 0x0006DD00
		' (set) Token: 0x0600FEBF RID: 65215 RVA: 0x0006FB0A File Offset: 0x0006DD0A
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x1700615F RID: 24927
		' (get) Token: 0x0600FEC0 RID: 65216 RVA: 0x0006FB13 File Offset: 0x0006DD13
		' (set) Token: 0x0600FEC1 RID: 65217 RVA: 0x0006FB1D File Offset: 0x0006DD1D
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17006160 RID: 24928
		' (get) Token: 0x0600FEC2 RID: 65218 RVA: 0x0006FB26 File Offset: 0x0006DD26
		' (set) Token: 0x0600FEC3 RID: 65219 RVA: 0x0006FB30 File Offset: 0x0006DD30
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17006161 RID: 24929
		' (get) Token: 0x0600FEC4 RID: 65220 RVA: 0x0006FB39 File Offset: 0x0006DD39
		' (set) Token: 0x0600FEC5 RID: 65221 RVA: 0x0006FB43 File Offset: 0x0006DD43
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17006162 RID: 24930
		' (get) Token: 0x0600FEC6 RID: 65222 RVA: 0x0006FB4C File Offset: 0x0006DD4C
		' (set) Token: 0x0600FEC7 RID: 65223 RVA: 0x0006FB56 File Offset: 0x0006DD56
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17006163 RID: 24931
		' (get) Token: 0x0600FEC8 RID: 65224 RVA: 0x0006FB5F File Offset: 0x0006DD5F
		' (set) Token: 0x0600FEC9 RID: 65225 RVA: 0x0006FB69 File Offset: 0x0006DD69
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17006164 RID: 24932
		' (get) Token: 0x0600FECA RID: 65226 RVA: 0x0006FB72 File Offset: 0x0006DD72
		' (set) Token: 0x0600FECB RID: 65227 RVA: 0x0006FB7C File Offset: 0x0006DD7C
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17006165 RID: 24933
		' (get) Token: 0x0600FECC RID: 65228 RVA: 0x0006FB85 File Offset: 0x0006DD85
		' (set) Token: 0x0600FECD RID: 65229 RVA: 0x0006FB8F File Offset: 0x0006DD8F
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006166 RID: 24934
		' (get) Token: 0x0600FECE RID: 65230 RVA: 0x0006FB98 File Offset: 0x0006DD98
		' (set) Token: 0x0600FECF RID: 65231 RVA: 0x0006FBA2 File Offset: 0x0006DDA2
		Friend Overridable Property TextBox12 As TextBox

		' Token: 0x17006167 RID: 24935
		' (get) Token: 0x0600FED0 RID: 65232 RVA: 0x0006FBAB File Offset: 0x0006DDAB
		' (set) Token: 0x0600FED1 RID: 65233 RVA: 0x0006FBB5 File Offset: 0x0006DDB5
		Friend Overridable Property Label14 As Label

		' Token: 0x17006168 RID: 24936
		' (get) Token: 0x0600FED2 RID: 65234 RVA: 0x0006FBBE File Offset: 0x0006DDBE
		' (set) Token: 0x0600FED3 RID: 65235 RVA: 0x009834B4 File Offset: 0x009816B4
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

		' Token: 0x0600FED4 RID: 65236 RVA: 0x009834F8 File Offset: 0x009816F8
		Private Sub clear()
			Me.txtProcessorName.Text = ""
			Me.txtProcessorID.Text = ""
			Me.txtProcessorDescription.Text = ""
			Me.txtProcessorManufacturer.Text = ""
			Me.txtProcessorL2CacheSize.Text = ""
			Me.txtProcessorClockSpeed.Text = ""
			Me.txtProcessorDataWidth.Text = ""
			Me.txtProcessorExtClock.Text = ""
			Me.txtProcessorFamily.Text = ""
			Me.txtBoardDescription.Text = ""
			Me.txtBoardManufacturer.Text = ""
			Me.txtBoardName.Text = ""
			Me.txtBoardSerialNumber.Text = ""
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox5.Text = ""
			Me.TextBox6.Text = ""
			Me.TextBox7.Text = ""
			Me.TextBox8.Text = ""
			Me.TextBox9.Text = ""
			Me.TextBox10.Text = ""
			Me.TextBox11.Text = ""
			Me.TextBox12.Text = ""
		End Sub

		' Token: 0x0600FED5 RID: 65237 RVA: 0x009836B0 File Offset: 0x009818B0
		<Obsolete()>
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub MainForm_Load(sender As Object, e As EventArgs)
			Me.clear()
			Me.Timer1.Enabled = True
			Try
				Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("Select * from Win32_Processor")
				Try
					For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
						Me.txtProcessorName.Text = managementObject("Name").ToString()
						Me.txtProcessorID.Text = managementObject("ProcessorID").ToString()
						Me.txtProcessorDescription.Text = managementObject("Description").ToString()
						Me.txtProcessorManufacturer.Text = managementObject("Manufacturer").ToString()
						Me.txtProcessorL2CacheSize.Text = managementObject("L2CacheSize").ToString()
						Me.txtProcessorClockSpeed.Text = managementObject("CurrentClockSpeed").ToString() + " Mhz"
						Me.txtProcessorDataWidth.Text = managementObject("DataWidth").ToString()
						Me.txtProcessorExtClock.Text = managementObject("ExtClock").ToString() + " Mhz"
						Me.txtProcessorFamily.Text = managementObject("Family").ToString()
					Next
				Finally
					Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator IsNot Nothing Then
						CType(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim managementObjectSearcher2 As ManagementObjectSearcher = New ManagementObjectSearcher("Select * from Win32_BaseBoard")
				Try
					For Each managementBaseObject2 As ManagementBaseObject In managementObjectSearcher2.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject2, ManagementObject)
						Me.txtBoardDescription.Text = managementObject("Description").ToString()
						Me.txtBoardManufacturer.Text = managementObject("Manufacturer").ToString()
						Me.txtBoardName.Text = managementObject("Name").ToString()
						Me.txtBoardSerialNumber.Text = managementObject("SerialNumber").ToString()
					Next
				Finally
					Dim enumerator2 As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator2 IsNot Nothing Then
						CType(enumerator2, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
				ProjectData.EndApp()
			End Try
			Try
				Me.ipaddress = CType(Me.h.AddressList.GetValue(0), IPAddress).ToString()
				Me.hostname = Dns.GetHostName()
				Me.TextBox9.Text = Me.ipaddress
				Me.TextBox1.Text = Me.hostname
				Me.TextBox2.Text = Environment.UserName
				Me.mc = New ManagementClass("Win32_NetworkAdapterConfiguration")
				Dim instances As ManagementObjectCollection = Me.mc.GetInstances()
				Try
					For Each managementBaseObject3 As ManagementBaseObject In instances
						Me.mo = CType(managementBaseObject3, ManagementObject)
						Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(Me.mo("IPEnabled"), True, False)
						If flag Then
							Me.TextBox11.Text = Conversions.ToString(Me.mo("MacAddress"))
						End If
					Next
				Finally
					Dim enumerator3 As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator3 IsNot Nothing Then
						CType(enumerator3, IDisposable).Dispose()
					End If
				End Try
				Me.TextBox10.Text = Me.GetPublicIP().ToString()
			Catch ex2 As Exception
			End Try
			Me.TextBox3.Text = Conversions.ToString(MyProject.Computer.Info.AvailablePhysicalMemory)
			Me.TextBox4.Text = Conversions.ToString(MyProject.Computer.Info.TotalPhysicalMemory)
			Me.TextBox5.Text = MyProject.Computer.Info.OSFullName
			Me.TextBox6.Text = MyProject.Computer.Info.OSPlatform
			Me.TextBox7.Text = MyProject.Computer.Info.OSVersion
			Me.TextBox8.Text = MyProject.Computer.Screen.WorkingArea.ToString()
			Me.TextBox3.Text = Me.TextBox3.Text + " KB"
			Me.TextBox4.Text = Me.TextBox4.Text + " KB"
		End Sub

		' Token: 0x0600FED6 RID: 65238 RVA: 0x00983BB0 File Offset: 0x00981DB0
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.TextBox12.Text = DateTime.Now.ToString("dd-MMM-yyyy | hh:mm:ss tt | dddd")
		End Sub

		' Token: 0x0600FED7 RID: 65239 RVA: 0x00983BDC File Offset: 0x00981DDC
		Public Function GetPublicIP() As String
			Dim text As String = ""
			Dim webRequest As WebRequest = WebRequest.Create("http://checkip.dyndns.org/")
			Using response As WebResponse = webRequest.GetResponse()
				Using streamReader As StreamReader = New StreamReader(response.GetResponseStream())
					text = streamReader.ReadToEnd()
				End Using
			End Using
			Dim num As Integer = text.IndexOf("Address: ") + 9
			Dim num2 As Integer = text.LastIndexOf("</body>")
			text = text.Substring(num, num2 - num)
			Return text
		End Function

		' Token: 0x0600FED8 RID: 65240 RVA: 0x00983C84 File Offset: 0x00981E84
		Private Sub SaveToFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Dim fileStream As FileStream = New FileStream("temp.txt", FileMode.Create, FileAccess.Write)
				Dim streamWriter As StreamWriter = New StreamWriter(fileStream)
				streamWriter.Write("****** Processor Information ******")
				streamWriter.WriteLine()
				streamWriter.WriteLine()
				streamWriter.WriteLine("Name")
				streamWriter.WriteLine(Me.txtProcessorName.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("ID")
				streamWriter.WriteLine(Me.txtProcessorID.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Description")
				streamWriter.WriteLine(Me.txtProcessorDescription.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Manufacturer")
				streamWriter.WriteLine(Me.txtProcessorManufacturer.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("L2 Cache Size")
				streamWriter.WriteLine(Me.txtProcessorL2CacheSize.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Clock Speed")
				streamWriter.WriteLine(Me.txtProcessorClockSpeed.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Data Width")
				streamWriter.WriteLine(Me.txtProcessorDataWidth.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Ext Clock")
				streamWriter.WriteLine(Me.txtProcessorExtClock.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Family")
				streamWriter.WriteLine(Me.txtProcessorFamily.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("****** MotherBoard Information *****")
				streamWriter.WriteLine()
				streamWriter.WriteLine("Name")
				streamWriter.WriteLine(Me.txtBoardDescription.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Manufacturer")
				streamWriter.WriteLine(Me.txtBoardManufacturer.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Description")
				streamWriter.WriteLine(Me.txtBoardDescription.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Serial Number")
				streamWriter.WriteLine(Me.txtBoardSerialNumber.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("****** My PC *****")
				streamWriter.WriteLine()
				streamWriter.WriteLine("Computer Name")
				streamWriter.WriteLine(Me.TextBox1.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("User Name")
				streamWriter.WriteLine(Me.TextBox2.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("RAM Avail Memory")
				streamWriter.WriteLine(Me.TextBox3.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("RAM Full Memory")
				streamWriter.WriteLine(Me.TextBox4.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Operating System")
				streamWriter.WriteLine(Me.TextBox5.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Platform")
				streamWriter.WriteLine(Me.TextBox6.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Version")
				streamWriter.WriteLine(Me.TextBox7.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Screen Resolution")
				streamWriter.WriteLine(Me.TextBox8.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Local IP Address")
				streamWriter.WriteLine(Me.TextBox9.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Online IP Address")
				streamWriter.WriteLine(Me.TextBox10.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("MAC Address")
				streamWriter.WriteLine(Me.TextBox11.Text)
				streamWriter.WriteLine()
				streamWriter.WriteLine("Date / Time")
				streamWriter.WriteLine(Me.TextBox12.Text)
				streamWriter.WriteLine()
				streamWriter.Flush()
				streamWriter.Close()
				Dim saveFileDialog As SaveFileDialog = Me.SaveFileDialog1
				saveFileDialog.AddExtension = True
				saveFileDialog.OverwritePrompt = True
				saveFileDialog.DefaultExt = "txt"
				saveFileDialog.InitialDirectory = MyProject.Computer.FileSystem.SpecialDirectories.MyDocuments
				saveFileDialog.FileName = "SystemInfo"
				saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files|*.*"
				saveFileDialog.FilterIndex = 1
				saveFileDialog.Title = "SystemInfo - Save file"
				Dim flag As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
				If flag Then
					MyProject.Computer.FileSystem.MoveFile("temp.txt", saveFileDialog.FileName, True)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
			End Try
		End Sub

		' Token: 0x0600FED9 RID: 65241 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub frmSystemInfo_Closed(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600FEDA RID: 65242 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600FEDB RID: 65243 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSystemInfo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0400619D RID: 24989
		Private hostname As String

		' Token: 0x0400619E RID: 24990
		Private ipaddress As String

		' Token: 0x0400619F RID: 24991
		<Obsolete()>
		Private h As IPHostEntry

		' Token: 0x040061A0 RID: 24992
		Private mc As ManagementClass

		' Token: 0x040061A1 RID: 24993
		Private mo As ManagementObject
	End Class
End Namespace
