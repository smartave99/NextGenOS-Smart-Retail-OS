Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports FireSharp
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000067 RID: 103
	<DesignerGenerated()>
	Public Partial Class Form
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001241 RID: 4673 RVA: 0x000C8CA0 File Offset: 0x000C6EA0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.ErpAnd_Load
			Me.s50 = ""
			Me.CurSym = ""
			Me.autoUpdateTimer = New Global.System.Windows.Forms.Timer()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000774 RID: 1908
		' (get) Token: 0x06001244 RID: 4676 RVA: 0x0000FEFE File Offset: 0x0000E0FE
		' (set) Token: 0x06001245 RID: 4677 RVA: 0x0000FF08 File Offset: 0x0000E108
		Friend Overridable Property TodayTitle1 As Label

		' Token: 0x17000775 RID: 1909
		' (get) Token: 0x06001246 RID: 4678 RVA: 0x0000FF11 File Offset: 0x0000E111
		' (set) Token: 0x06001247 RID: 4679 RVA: 0x0000FF1B File Offset: 0x0000E11B
		Friend Overridable Property TodayTitle2 As Label

		' Token: 0x17000776 RID: 1910
		' (get) Token: 0x06001248 RID: 4680 RVA: 0x0000FF24 File Offset: 0x0000E124
		' (set) Token: 0x06001249 RID: 4681 RVA: 0x0000FF2E File Offset: 0x0000E12E
		Friend Overridable Property TodayTitle3 As Label

		' Token: 0x17000777 RID: 1911
		' (get) Token: 0x0600124A RID: 4682 RVA: 0x0000FF37 File Offset: 0x0000E137
		' (set) Token: 0x0600124B RID: 4683 RVA: 0x0000FF41 File Offset: 0x0000E141
		Friend Overridable Property TodayTitle4 As Label

		' Token: 0x17000778 RID: 1912
		' (get) Token: 0x0600124C RID: 4684 RVA: 0x0000FF4A File Offset: 0x0000E14A
		' (set) Token: 0x0600124D RID: 4685 RVA: 0x0000FF54 File Offset: 0x0000E154
		Friend Overridable Property TodayTitle5 As Label

		' Token: 0x17000779 RID: 1913
		' (get) Token: 0x0600124E RID: 4686 RVA: 0x0000FF5D File Offset: 0x0000E15D
		' (set) Token: 0x0600124F RID: 4687 RVA: 0x0000FF67 File Offset: 0x0000E167
		Friend Overridable Property TodayTitle6 As Label

		' Token: 0x1700077A RID: 1914
		' (get) Token: 0x06001250 RID: 4688 RVA: 0x0000FF70 File Offset: 0x0000E170
		' (set) Token: 0x06001251 RID: 4689 RVA: 0x0000FF7A File Offset: 0x0000E17A
		Friend Overridable Property TodayTitle7 As Label

		' Token: 0x1700077B RID: 1915
		' (get) Token: 0x06001252 RID: 4690 RVA: 0x0000FF83 File Offset: 0x0000E183
		' (set) Token: 0x06001253 RID: 4691 RVA: 0x0000FF8D File Offset: 0x0000E18D
		Friend Overridable Property TodayTitle8 As Label

		' Token: 0x1700077C RID: 1916
		' (get) Token: 0x06001254 RID: 4692 RVA: 0x0000FF96 File Offset: 0x0000E196
		' (set) Token: 0x06001255 RID: 4693 RVA: 0x0000FFA0 File Offset: 0x0000E1A0
		Friend Overridable Property TodayTitle9 As Label

		' Token: 0x1700077D RID: 1917
		' (get) Token: 0x06001256 RID: 4694 RVA: 0x0000FFA9 File Offset: 0x0000E1A9
		' (set) Token: 0x06001257 RID: 4695 RVA: 0x0000FFB3 File Offset: 0x0000E1B3
		Friend Overridable Property TodayTitle10 As Label

		' Token: 0x1700077E RID: 1918
		' (get) Token: 0x06001258 RID: 4696 RVA: 0x0000FFBC File Offset: 0x0000E1BC
		' (set) Token: 0x06001259 RID: 4697 RVA: 0x0000FFC6 File Offset: 0x0000E1C6
		Friend Overridable Property TodayTitle11 As Label

		' Token: 0x1700077F RID: 1919
		' (get) Token: 0x0600125A RID: 4698 RVA: 0x0000FFCF File Offset: 0x0000E1CF
		' (set) Token: 0x0600125B RID: 4699 RVA: 0x0000FFD9 File Offset: 0x0000E1D9
		Friend Overridable Property TodayTitle12 As Label

		' Token: 0x17000780 RID: 1920
		' (get) Token: 0x0600125C RID: 4700 RVA: 0x0000FFE2 File Offset: 0x0000E1E2
		' (set) Token: 0x0600125D RID: 4701 RVA: 0x0000FFEC File Offset: 0x0000E1EC
		Friend Overridable Property FYTitle12 As Label

		' Token: 0x17000781 RID: 1921
		' (get) Token: 0x0600125E RID: 4702 RVA: 0x0000FFF5 File Offset: 0x0000E1F5
		' (set) Token: 0x0600125F RID: 4703 RVA: 0x0000FFFF File Offset: 0x0000E1FF
		Friend Overridable Property FYTitle11 As Label

		' Token: 0x17000782 RID: 1922
		' (get) Token: 0x06001260 RID: 4704 RVA: 0x00010008 File Offset: 0x0000E208
		' (set) Token: 0x06001261 RID: 4705 RVA: 0x00010012 File Offset: 0x0000E212
		Friend Overridable Property FYTitle10 As Label

		' Token: 0x17000783 RID: 1923
		' (get) Token: 0x06001262 RID: 4706 RVA: 0x0001001B File Offset: 0x0000E21B
		' (set) Token: 0x06001263 RID: 4707 RVA: 0x00010025 File Offset: 0x0000E225
		Friend Overridable Property FYTitle9 As Label

		' Token: 0x17000784 RID: 1924
		' (get) Token: 0x06001264 RID: 4708 RVA: 0x0001002E File Offset: 0x0000E22E
		' (set) Token: 0x06001265 RID: 4709 RVA: 0x00010038 File Offset: 0x0000E238
		Friend Overridable Property FYTitle8 As Label

		' Token: 0x17000785 RID: 1925
		' (get) Token: 0x06001266 RID: 4710 RVA: 0x00010041 File Offset: 0x0000E241
		' (set) Token: 0x06001267 RID: 4711 RVA: 0x0001004B File Offset: 0x0000E24B
		Friend Overridable Property FYTitle7 As Label

		' Token: 0x17000786 RID: 1926
		' (get) Token: 0x06001268 RID: 4712 RVA: 0x00010054 File Offset: 0x0000E254
		' (set) Token: 0x06001269 RID: 4713 RVA: 0x0001005E File Offset: 0x0000E25E
		Friend Overridable Property FYTitle6 As Label

		' Token: 0x17000787 RID: 1927
		' (get) Token: 0x0600126A RID: 4714 RVA: 0x00010067 File Offset: 0x0000E267
		' (set) Token: 0x0600126B RID: 4715 RVA: 0x00010071 File Offset: 0x0000E271
		Friend Overridable Property FYTitle5 As Label

		' Token: 0x17000788 RID: 1928
		' (get) Token: 0x0600126C RID: 4716 RVA: 0x0001007A File Offset: 0x0000E27A
		' (set) Token: 0x0600126D RID: 4717 RVA: 0x00010084 File Offset: 0x0000E284
		Friend Overridable Property FYTitle4 As Label

		' Token: 0x17000789 RID: 1929
		' (get) Token: 0x0600126E RID: 4718 RVA: 0x0001008D File Offset: 0x0000E28D
		' (set) Token: 0x0600126F RID: 4719 RVA: 0x00010097 File Offset: 0x0000E297
		Friend Overridable Property FYTitle3 As Label

		' Token: 0x1700078A RID: 1930
		' (get) Token: 0x06001270 RID: 4720 RVA: 0x000100A0 File Offset: 0x0000E2A0
		' (set) Token: 0x06001271 RID: 4721 RVA: 0x000100AA File Offset: 0x0000E2AA
		Friend Overridable Property FYTitle2 As Label

		' Token: 0x1700078B RID: 1931
		' (get) Token: 0x06001272 RID: 4722 RVA: 0x000100B3 File Offset: 0x0000E2B3
		' (set) Token: 0x06001273 RID: 4723 RVA: 0x000100BD File Offset: 0x0000E2BD
		Friend Overridable Property FYTitle1 As Label

		' Token: 0x1700078C RID: 1932
		' (get) Token: 0x06001274 RID: 4724 RVA: 0x000100C6 File Offset: 0x0000E2C6
		' (set) Token: 0x06001275 RID: 4725 RVA: 0x000100D0 File Offset: 0x0000E2D0
		Friend Overridable Property Label25 As Label

		' Token: 0x1700078D RID: 1933
		' (get) Token: 0x06001276 RID: 4726 RVA: 0x000100D9 File Offset: 0x0000E2D9
		' (set) Token: 0x06001277 RID: 4727 RVA: 0x000100E3 File Offset: 0x0000E2E3
		Friend Overridable Property Label26 As Label

		' Token: 0x1700078E RID: 1934
		' (get) Token: 0x06001278 RID: 4728 RVA: 0x000100EC File Offset: 0x0000E2EC
		' (set) Token: 0x06001279 RID: 4729 RVA: 0x000100F6 File Offset: 0x0000E2F6
		Friend Overridable Property TodayValue1 As TextBox

		' Token: 0x1700078F RID: 1935
		' (get) Token: 0x0600127A RID: 4730 RVA: 0x000100FF File Offset: 0x0000E2FF
		' (set) Token: 0x0600127B RID: 4731 RVA: 0x00010109 File Offset: 0x0000E309
		Friend Overridable Property TodayValue2 As TextBox

		' Token: 0x17000790 RID: 1936
		' (get) Token: 0x0600127C RID: 4732 RVA: 0x00010112 File Offset: 0x0000E312
		' (set) Token: 0x0600127D RID: 4733 RVA: 0x0001011C File Offset: 0x0000E31C
		Friend Overridable Property TodayValue3 As TextBox

		' Token: 0x17000791 RID: 1937
		' (get) Token: 0x0600127E RID: 4734 RVA: 0x00010125 File Offset: 0x0000E325
		' (set) Token: 0x0600127F RID: 4735 RVA: 0x0001012F File Offset: 0x0000E32F
		Friend Overridable Property TodayValue4 As TextBox

		' Token: 0x17000792 RID: 1938
		' (get) Token: 0x06001280 RID: 4736 RVA: 0x00010138 File Offset: 0x0000E338
		' (set) Token: 0x06001281 RID: 4737 RVA: 0x00010142 File Offset: 0x0000E342
		Friend Overridable Property TodayValue5 As TextBox

		' Token: 0x17000793 RID: 1939
		' (get) Token: 0x06001282 RID: 4738 RVA: 0x0001014B File Offset: 0x0000E34B
		' (set) Token: 0x06001283 RID: 4739 RVA: 0x00010155 File Offset: 0x0000E355
		Friend Overridable Property TodayValue6 As TextBox

		' Token: 0x17000794 RID: 1940
		' (get) Token: 0x06001284 RID: 4740 RVA: 0x0001015E File Offset: 0x0000E35E
		' (set) Token: 0x06001285 RID: 4741 RVA: 0x00010168 File Offset: 0x0000E368
		Friend Overridable Property TodayValue7 As TextBox

		' Token: 0x17000795 RID: 1941
		' (get) Token: 0x06001286 RID: 4742 RVA: 0x00010171 File Offset: 0x0000E371
		' (set) Token: 0x06001287 RID: 4743 RVA: 0x0001017B File Offset: 0x0000E37B
		Friend Overridable Property TodayValue8 As TextBox

		' Token: 0x17000796 RID: 1942
		' (get) Token: 0x06001288 RID: 4744 RVA: 0x00010184 File Offset: 0x0000E384
		' (set) Token: 0x06001289 RID: 4745 RVA: 0x0001018E File Offset: 0x0000E38E
		Friend Overridable Property TodayValue9 As TextBox

		' Token: 0x17000797 RID: 1943
		' (get) Token: 0x0600128A RID: 4746 RVA: 0x00010197 File Offset: 0x0000E397
		' (set) Token: 0x0600128B RID: 4747 RVA: 0x000101A1 File Offset: 0x0000E3A1
		Friend Overridable Property TodayValue10 As TextBox

		' Token: 0x17000798 RID: 1944
		' (get) Token: 0x0600128C RID: 4748 RVA: 0x000101AA File Offset: 0x0000E3AA
		' (set) Token: 0x0600128D RID: 4749 RVA: 0x000101B4 File Offset: 0x0000E3B4
		Friend Overridable Property TodayValue11 As TextBox

		' Token: 0x17000799 RID: 1945
		' (get) Token: 0x0600128E RID: 4750 RVA: 0x000101BD File Offset: 0x0000E3BD
		' (set) Token: 0x0600128F RID: 4751 RVA: 0x000101C7 File Offset: 0x0000E3C7
		Friend Overridable Property TodayValue12 As TextBox

		' Token: 0x1700079A RID: 1946
		' (get) Token: 0x06001290 RID: 4752 RVA: 0x000101D0 File Offset: 0x0000E3D0
		' (set) Token: 0x06001291 RID: 4753 RVA: 0x000101DA File Offset: 0x0000E3DA
		Friend Overridable Property FYValue1 As TextBox

		' Token: 0x1700079B RID: 1947
		' (get) Token: 0x06001292 RID: 4754 RVA: 0x000101E3 File Offset: 0x0000E3E3
		' (set) Token: 0x06001293 RID: 4755 RVA: 0x000101ED File Offset: 0x0000E3ED
		Friend Overridable Property FYValue2 As TextBox

		' Token: 0x1700079C RID: 1948
		' (get) Token: 0x06001294 RID: 4756 RVA: 0x000101F6 File Offset: 0x0000E3F6
		' (set) Token: 0x06001295 RID: 4757 RVA: 0x00010200 File Offset: 0x0000E400
		Friend Overridable Property FYValue3 As TextBox

		' Token: 0x1700079D RID: 1949
		' (get) Token: 0x06001296 RID: 4758 RVA: 0x00010209 File Offset: 0x0000E409
		' (set) Token: 0x06001297 RID: 4759 RVA: 0x00010213 File Offset: 0x0000E413
		Friend Overridable Property FYValue4 As TextBox

		' Token: 0x1700079E RID: 1950
		' (get) Token: 0x06001298 RID: 4760 RVA: 0x0001021C File Offset: 0x0000E41C
		' (set) Token: 0x06001299 RID: 4761 RVA: 0x00010226 File Offset: 0x0000E426
		Friend Overridable Property FYValue5 As TextBox

		' Token: 0x1700079F RID: 1951
		' (get) Token: 0x0600129A RID: 4762 RVA: 0x0001022F File Offset: 0x0000E42F
		' (set) Token: 0x0600129B RID: 4763 RVA: 0x00010239 File Offset: 0x0000E439
		Friend Overridable Property FYValue6 As TextBox

		' Token: 0x170007A0 RID: 1952
		' (get) Token: 0x0600129C RID: 4764 RVA: 0x00010242 File Offset: 0x0000E442
		' (set) Token: 0x0600129D RID: 4765 RVA: 0x0001024C File Offset: 0x0000E44C
		Friend Overridable Property FYValue7 As TextBox

		' Token: 0x170007A1 RID: 1953
		' (get) Token: 0x0600129E RID: 4766 RVA: 0x00010255 File Offset: 0x0000E455
		' (set) Token: 0x0600129F RID: 4767 RVA: 0x0001025F File Offset: 0x0000E45F
		Friend Overridable Property FYValue8 As TextBox

		' Token: 0x170007A2 RID: 1954
		' (get) Token: 0x060012A0 RID: 4768 RVA: 0x00010268 File Offset: 0x0000E468
		' (set) Token: 0x060012A1 RID: 4769 RVA: 0x00010272 File Offset: 0x0000E472
		Friend Overridable Property FYValue9 As TextBox

		' Token: 0x170007A3 RID: 1955
		' (get) Token: 0x060012A2 RID: 4770 RVA: 0x0001027B File Offset: 0x0000E47B
		' (set) Token: 0x060012A3 RID: 4771 RVA: 0x00010285 File Offset: 0x0000E485
		Friend Overridable Property FYValue10 As TextBox

		' Token: 0x170007A4 RID: 1956
		' (get) Token: 0x060012A4 RID: 4772 RVA: 0x0001028E File Offset: 0x0000E48E
		' (set) Token: 0x060012A5 RID: 4773 RVA: 0x00010298 File Offset: 0x0000E498
		Friend Overridable Property FYValue11 As TextBox

		' Token: 0x170007A5 RID: 1957
		' (get) Token: 0x060012A6 RID: 4774 RVA: 0x000102A1 File Offset: 0x0000E4A1
		' (set) Token: 0x060012A7 RID: 4775 RVA: 0x000102AB File Offset: 0x0000E4AB
		Friend Overridable Property FYValue12 As TextBox

		' Token: 0x170007A6 RID: 1958
		' (get) Token: 0x060012A8 RID: 4776 RVA: 0x000102B4 File Offset: 0x0000E4B4
		' (set) Token: 0x060012A9 RID: 4777 RVA: 0x000102BE File Offset: 0x0000E4BE
		Friend Overridable Property Label27 As Label

		' Token: 0x170007A7 RID: 1959
		' (get) Token: 0x060012AA RID: 4778 RVA: 0x000102C7 File Offset: 0x0000E4C7
		' (set) Token: 0x060012AB RID: 4779 RVA: 0x000102D1 File Offset: 0x0000E4D1
		Friend Overridable Property Label28 As Label

		' Token: 0x170007A8 RID: 1960
		' (get) Token: 0x060012AC RID: 4780 RVA: 0x000102DA File Offset: 0x0000E4DA
		' (set) Token: 0x060012AD RID: 4781 RVA: 0x000102E4 File Offset: 0x0000E4E4
		Friend Overridable Property Label29 As Label

		' Token: 0x170007A9 RID: 1961
		' (get) Token: 0x060012AE RID: 4782 RVA: 0x000102ED File Offset: 0x0000E4ED
		' (set) Token: 0x060012AF RID: 4783 RVA: 0x000102F7 File Offset: 0x0000E4F7
		Friend Overridable Property Label30 As Label

		' Token: 0x170007AA RID: 1962
		' (get) Token: 0x060012B0 RID: 4784 RVA: 0x00010300 File Offset: 0x0000E500
		' (set) Token: 0x060012B1 RID: 4785 RVA: 0x0001030A File Offset: 0x0000E50A
		Friend Overridable Property Label31 As Label

		' Token: 0x170007AB RID: 1963
		' (get) Token: 0x060012B2 RID: 4786 RVA: 0x00010313 File Offset: 0x0000E513
		' (set) Token: 0x060012B3 RID: 4787 RVA: 0x0001031D File Offset: 0x0000E51D
		Friend Overridable Property Label32 As Label

		' Token: 0x170007AC RID: 1964
		' (get) Token: 0x060012B4 RID: 4788 RVA: 0x00010326 File Offset: 0x0000E526
		' (set) Token: 0x060012B5 RID: 4789 RVA: 0x00010330 File Offset: 0x0000E530
		Friend Overridable Property TBoxCompName As TextBox

		' Token: 0x170007AD RID: 1965
		' (get) Token: 0x060012B6 RID: 4790 RVA: 0x00010339 File Offset: 0x0000E539
		' (set) Token: 0x060012B7 RID: 4791 RVA: 0x00010343 File Offset: 0x0000E543
		Friend Overridable Property TBoxAddress As TextBox

		' Token: 0x170007AE RID: 1966
		' (get) Token: 0x060012B8 RID: 4792 RVA: 0x0001034C File Offset: 0x0000E54C
		' (set) Token: 0x060012B9 RID: 4793 RVA: 0x00010356 File Offset: 0x0000E556
		Friend Overridable Property TBoxState As TextBox

		' Token: 0x170007AF RID: 1967
		' (get) Token: 0x060012BA RID: 4794 RVA: 0x0001035F File Offset: 0x0000E55F
		' (set) Token: 0x060012BB RID: 4795 RVA: 0x00010369 File Offset: 0x0000E569
		Friend Overridable Property TBoxGSTIN As TextBox

		' Token: 0x170007B0 RID: 1968
		' (get) Token: 0x060012BC RID: 4796 RVA: 0x00010372 File Offset: 0x0000E572
		' (set) Token: 0x060012BD RID: 4797 RVA: 0x0001037C File Offset: 0x0000E57C
		Friend Overridable Property TBoxContactNo As TextBox

		' Token: 0x170007B1 RID: 1969
		' (get) Token: 0x060012BE RID: 4798 RVA: 0x00010385 File Offset: 0x0000E585
		' (set) Token: 0x060012BF RID: 4799 RVA: 0x0001038F File Offset: 0x0000E58F
		Friend Overridable Property TBoxEmail As TextBox

		' Token: 0x170007B2 RID: 1970
		' (get) Token: 0x060012C0 RID: 4800 RVA: 0x00010398 File Offset: 0x0000E598
		' (set) Token: 0x060012C1 RID: 4801 RVA: 0x000103A2 File Offset: 0x0000E5A2
		Friend Overridable Property TodayValue13 As TextBox

		' Token: 0x170007B3 RID: 1971
		' (get) Token: 0x060012C2 RID: 4802 RVA: 0x000103AB File Offset: 0x0000E5AB
		' (set) Token: 0x060012C3 RID: 4803 RVA: 0x000103B5 File Offset: 0x0000E5B5
		Friend Overridable Property FYValue13 As TextBox

		' Token: 0x170007B4 RID: 1972
		' (get) Token: 0x060012C4 RID: 4804 RVA: 0x000103BE File Offset: 0x0000E5BE
		' (set) Token: 0x060012C5 RID: 4805 RVA: 0x000103C8 File Offset: 0x0000E5C8
		Friend Overridable Property TodayTitle13 As Label

		' Token: 0x170007B5 RID: 1973
		' (get) Token: 0x060012C6 RID: 4806 RVA: 0x000103D1 File Offset: 0x0000E5D1
		' (set) Token: 0x060012C7 RID: 4807 RVA: 0x000103DB File Offset: 0x0000E5DB
		Friend Overridable Property FYValue14 As TextBox

		' Token: 0x170007B6 RID: 1974
		' (get) Token: 0x060012C8 RID: 4808 RVA: 0x000103E4 File Offset: 0x0000E5E4
		' (set) Token: 0x060012C9 RID: 4809 RVA: 0x000103EE File Offset: 0x0000E5EE
		Friend Overridable Property TodayValue14 As TextBox

		' Token: 0x170007B7 RID: 1975
		' (get) Token: 0x060012CA RID: 4810 RVA: 0x000103F7 File Offset: 0x0000E5F7
		' (set) Token: 0x060012CB RID: 4811 RVA: 0x00010401 File Offset: 0x0000E601
		Friend Overridable Property TodayTitle14 As Label

		' Token: 0x170007B8 RID: 1976
		' (get) Token: 0x060012CC RID: 4812 RVA: 0x0001040A File Offset: 0x0000E60A
		' (set) Token: 0x060012CD RID: 4813 RVA: 0x00010414 File Offset: 0x0000E614
		Friend Overridable Property FYTitle14 As Label

		' Token: 0x170007B9 RID: 1977
		' (get) Token: 0x060012CE RID: 4814 RVA: 0x0001041D File Offset: 0x0000E61D
		' (set) Token: 0x060012CF RID: 4815 RVA: 0x00010427 File Offset: 0x0000E627
		Friend Overridable Property FYTitle13 As Label

		' Token: 0x170007BA RID: 1978
		' (get) Token: 0x060012D0 RID: 4816 RVA: 0x00010430 File Offset: 0x0000E630
		' (set) Token: 0x060012D1 RID: 4817 RVA: 0x0001043A File Offset: 0x0000E63A
		Friend Overridable Property TBoxCompId As TextBox

		' Token: 0x170007BB RID: 1979
		' (get) Token: 0x060012D2 RID: 4818 RVA: 0x00010443 File Offset: 0x0000E643
		' (set) Token: 0x060012D3 RID: 4819 RVA: 0x0001044D File Offset: 0x0000E64D
		Friend Overridable Property Label1 As Label

		' Token: 0x170007BC RID: 1980
		' (get) Token: 0x060012D4 RID: 4820 RVA: 0x00010456 File Offset: 0x0000E656
		' (set) Token: 0x060012D5 RID: 4821 RVA: 0x000CC370 File Offset: 0x000CA570
		Private _Timer1 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer1 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer1
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

		' Token: 0x170007BD RID: 1981
		' (get) Token: 0x060012D6 RID: 4822 RVA: 0x00010460 File Offset: 0x0000E660
		' (set) Token: 0x060012D7 RID: 4823 RVA: 0x0001046A File Offset: 0x0000E66A
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x170007BE RID: 1982
		' (get) Token: 0x060012D8 RID: 4824 RVA: 0x00010473 File Offset: 0x0000E673
		' (set) Token: 0x060012D9 RID: 4825 RVA: 0x0001047D File Offset: 0x0000E67D
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x170007BF RID: 1983
		' (get) Token: 0x060012DA RID: 4826 RVA: 0x00010486 File Offset: 0x0000E686
		' (set) Token: 0x060012DB RID: 4827 RVA: 0x00010490 File Offset: 0x0000E690
		Friend Overridable Property lblUser As Label

		' Token: 0x170007C0 RID: 1984
		' (get) Token: 0x060012DC RID: 4828 RVA: 0x00010499 File Offset: 0x0000E699
		' (set) Token: 0x060012DD RID: 4829 RVA: 0x000104A3 File Offset: 0x0000E6A3
		Friend Overridable Property txtDB As TextBox

		' Token: 0x170007C1 RID: 1985
		' (get) Token: 0x060012DE RID: 4830 RVA: 0x000104AC File Offset: 0x0000E6AC
		' (set) Token: 0x060012DF RID: 4831 RVA: 0x000104B6 File Offset: 0x0000E6B6
		Friend Overridable Property TodayValue15 As TextBox

		' Token: 0x170007C2 RID: 1986
		' (get) Token: 0x060012E0 RID: 4832 RVA: 0x000104BF File Offset: 0x0000E6BF
		' (set) Token: 0x060012E1 RID: 4833 RVA: 0x000104C9 File Offset: 0x0000E6C9
		Friend Overridable Property TodayValue16 As TextBox

		' Token: 0x170007C3 RID: 1987
		' (get) Token: 0x060012E2 RID: 4834 RVA: 0x000104D2 File Offset: 0x0000E6D2
		' (set) Token: 0x060012E3 RID: 4835 RVA: 0x000104DC File Offset: 0x0000E6DC
		Friend Overridable Property FYValue15 As TextBox

		' Token: 0x170007C4 RID: 1988
		' (get) Token: 0x060012E4 RID: 4836 RVA: 0x000104E5 File Offset: 0x0000E6E5
		' (set) Token: 0x060012E5 RID: 4837 RVA: 0x000104EF File Offset: 0x0000E6EF
		Friend Overridable Property FYValue16 As TextBox

		' Token: 0x170007C5 RID: 1989
		' (get) Token: 0x060012E6 RID: 4838 RVA: 0x000104F8 File Offset: 0x0000E6F8
		' (set) Token: 0x060012E7 RID: 4839 RVA: 0x00010502 File Offset: 0x0000E702
		Friend Overridable Property TodayTitle15 As Label

		' Token: 0x170007C6 RID: 1990
		' (get) Token: 0x060012E8 RID: 4840 RVA: 0x0001050B File Offset: 0x0000E70B
		' (set) Token: 0x060012E9 RID: 4841 RVA: 0x00010515 File Offset: 0x0000E715
		Friend Overridable Property TodayTitle16 As Label

		' Token: 0x170007C7 RID: 1991
		' (get) Token: 0x060012EA RID: 4842 RVA: 0x0001051E File Offset: 0x0000E71E
		' (set) Token: 0x060012EB RID: 4843 RVA: 0x00010528 File Offset: 0x0000E728
		Friend Overridable Property FYTitle16 As Label

		' Token: 0x170007C8 RID: 1992
		' (get) Token: 0x060012EC RID: 4844 RVA: 0x00010531 File Offset: 0x0000E731
		' (set) Token: 0x060012ED RID: 4845 RVA: 0x0001053B File Offset: 0x0000E73B
		Friend Overridable Property FYTitle15 As Label

		' Token: 0x170007C9 RID: 1993
		' (get) Token: 0x060012EE RID: 4846 RVA: 0x00010544 File Offset: 0x0000E744
		' (set) Token: 0x060012EF RID: 4847 RVA: 0x0001054E File Offset: 0x0000E74E
		Friend Overridable Property TodayTitle17 As Label

		' Token: 0x170007CA RID: 1994
		' (get) Token: 0x060012F0 RID: 4848 RVA: 0x00010557 File Offset: 0x0000E757
		' (set) Token: 0x060012F1 RID: 4849 RVA: 0x00010561 File Offset: 0x0000E761
		Friend Overridable Property TodayTitle18 As Label

		' Token: 0x170007CB RID: 1995
		' (get) Token: 0x060012F2 RID: 4850 RVA: 0x0001056A File Offset: 0x0000E76A
		' (set) Token: 0x060012F3 RID: 4851 RVA: 0x00010574 File Offset: 0x0000E774
		Friend Overridable Property FYTitle17 As Label

		' Token: 0x170007CC RID: 1996
		' (get) Token: 0x060012F4 RID: 4852 RVA: 0x0001057D File Offset: 0x0000E77D
		' (set) Token: 0x060012F5 RID: 4853 RVA: 0x00010587 File Offset: 0x0000E787
		Friend Overridable Property FYTitle18 As Label

		' Token: 0x170007CD RID: 1997
		' (get) Token: 0x060012F6 RID: 4854 RVA: 0x00010590 File Offset: 0x0000E790
		' (set) Token: 0x060012F7 RID: 4855 RVA: 0x0001059A File Offset: 0x0000E79A
		Friend Overridable Property TodayValue17 As TextBox

		' Token: 0x170007CE RID: 1998
		' (get) Token: 0x060012F8 RID: 4856 RVA: 0x000105A3 File Offset: 0x0000E7A3
		' (set) Token: 0x060012F9 RID: 4857 RVA: 0x000105AD File Offset: 0x0000E7AD
		Friend Overridable Property TodayValue18 As TextBox

		' Token: 0x170007CF RID: 1999
		' (get) Token: 0x060012FA RID: 4858 RVA: 0x000105B6 File Offset: 0x0000E7B6
		' (set) Token: 0x060012FB RID: 4859 RVA: 0x000105C0 File Offset: 0x0000E7C0
		Friend Overridable Property FYValue17 As TextBox

		' Token: 0x170007D0 RID: 2000
		' (get) Token: 0x060012FC RID: 4860 RVA: 0x000105C9 File Offset: 0x0000E7C9
		' (set) Token: 0x060012FD RID: 4861 RVA: 0x000105D3 File Offset: 0x0000E7D3
		Friend Overridable Property FYValue18 As TextBox

		' Token: 0x060012FE RID: 4862 RVA: 0x000CC3B4 File Offset: 0x000CA5B4
		Public Sub UserControlSettings()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(c36) from UserControl WHERE RTRIM(UserID)=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblUser.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.s50 = ModCommonClasses.rdr.GetValue(0).ToString()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060012FF RID: 4863 RVA: 0x000CC494 File Offset: 0x000CA694
		Private Sub ErpAnd_Load(sender As Object, e As EventArgs)
			Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
			Try
				For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
					Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
					Dim text As String = Conversions.ToString(managementObject("SerialNumber"))
					Me.TBoxCompId.Text = ModFunc.MD5Encrypt(Me.txtDB.Text.TrimEnd(New Char(-1) {}).ToString() + Strings.StrReverse(text))
				Next
			Finally
				Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
				If enumerator IsNot Nothing Then
					CType(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.UserControlSettings()
			Me.GetCompanyInfo()
			Me.todaysale()
			Me.todaypurchase()
			Me.todaysalereturn()
			Me.todaypurchasereturn()
			Me.todayreceipt()
			Me.todaypayment()
			Me.todayserviceadvance()
			Me.todayservicebilling()
			Me.todayincome()
			Me.todayexpenses()
			Me.TodayContra()
			Me.TodayJournal()
			Me.cashinhand()
			Me.bankinhand()
			Me.SundryCreditor()
			Me.SundryDebtor()
			Me.SalaryAdvance()
			Me.SalaryPayment()
			Me.Totalsale()
			Me.TotalPurchase()
			Me.TotalSaleReturn()
			Me.TotalPurchaseReturn()
			Me.Totalreceipt()
			Me.TotalPayment()
			Me.TotalServiceAdvance()
			Me.TotalServiceBilling()
			Me.TotalIncome()
			Me.TotalExpenses()
			Me.TotalCashInHand()
			Me.TotalCashInbank()
			Me.TotalSundryCreditor()
			Me.TotalSundryDebtor()
			Me.TotalSalaryAdvance()
			Me.TotalSalaryPayment()
			Me.TotalContra()
			Me.TotalJournal()
			Dim timer As Global.System.Windows.Forms.Timer = New Global.System.Windows.Forms.Timer()
			timer.Interval = 10000
			AddHandler timer.Tick, AddressOf Me.Timer1_Tick
			timer.Start()
			Dim flag As Boolean = Me.TBoxCompId.Text.Length > 0
			If flag Then
				Try
					Me.AutoUpdater()
				Catch ex As Exception
				End Try
			End If
		End Sub

		' Token: 0x06001300 RID: 4864 RVA: 0x000CC6B4 File Offset: 0x000CA8B4
		Private Sub AutoUpdater()
			Me.Config = New FirebaseConfig() With { .AuthSecret = NextGenOS.Licensing.CloudSettings.Secret("reports"), .BasePath = NextGenOS.Licensing.CloudSettings.Url("reports") }
			Me.Client = New FirebaseClient(Me.Config)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_name", Me.TBoxCompId.Text), Me.TBoxCompName.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_address", Me.TBoxCompId.Text), Me.TBoxAddress.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_state", Me.TBoxCompId.Text), Me.TBoxState.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_gstin", Me.TBoxCompId.Text), Me.TBoxGSTIN.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_contactno", Me.TBoxCompId.Text), Me.TBoxContactNo.Text)
			Me.Client.[Set](Of String)(String.Format("comp/{0}/comp_email", Me.TBoxCompId.Text), Me.TBoxEmail.Text)
			Me.autoUpdateTimer.Interval = 5000
			AddHandler Me.autoUpdateTimer.Tick, AddressOf Me.AutoUpdater_Event
			Me.autoUpdateTimer.Start()
		End Sub

		' Token: 0x06001301 RID: 4865 RVA: 0x000CC834 File Offset: 0x000CAA34
		Private Sub AutoUpdater_Event(sender As Object, e As EventArgs)
			Me.todayData = New Dictionary(Of String, Dictionary(Of String, String))()
			Me.todayData.Add(Me.TodayTitle1.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle1.Text }, { "color", If((Me.TodayValue1.ForeColor = Color.Green), "green", If((Me.TodayValue1.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.TodayValue1.Text } })
			Me.todayData.Add(Me.TodayTitle2.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle2.Text }, { "color", If((Me.TodayValue2.ForeColor = Color.Coral), "coral", If((Me.TodayValue2.ForeColor = Color.Coral), "coral", "")) }, { "value", " " + Me.TodayValue2.Text } })
			Me.todayData.Add(Me.TodayTitle3.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle3.Text }, { "color", If((Me.TodayValue3.ForeColor = Color.Coral), "coral", If((Me.TodayValue3.ForeColor = Color.Coral), "coral", "")) }, { "value", " " + Me.TodayValue3.Text } })
			Me.todayData.Add(Me.TodayTitle4.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle4.Text }, { "color", If((Me.TodayValue4.ForeColor = Color.Green), "green", If((Me.TodayValue4.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.TodayValue4.Text } })
			Me.todayData.Add(Me.TodayTitle5.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle5.Text }, { "color", If((Me.TodayValue5.ForeColor = Color.Green), "green", If((Me.TodayValue5.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.TodayValue5.Text } })
			Me.todayData.Add(Me.TodayTitle6.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle6.Text }, { "color", If((Me.TodayValue6.ForeColor = Color.DarkOrange), "dark-orange", If((Me.TodayValue6.ForeColor = Color.DarkOrange), "dark-orange", "")) }, { "value", " " + Me.TodayValue6.Text } })
			Me.todayData.Add(Me.TodayTitle7.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle7.Text }, { "color", If((Me.TodayValue7.ForeColor = Color.Green), "green", If((Me.TodayValue7.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.TodayValue7.Text } })
			Me.todayData.Add(Me.TodayTitle8.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle8.Text }, { "color", If((Me.TodayValue8.ForeColor = Color.Green), "green", If((Me.TodayValue8.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.TodayValue8.Text } })
			Me.todayData.Add(Me.TodayTitle9.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle9.Text }, { "color", If((Me.TodayValue9.ForeColor = Color.Green), "green", If((Me.TodayValue9.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.TodayValue9.Text } })
			Me.todayData.Add(Me.TodayTitle10.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle10.Text }, { "color", If((Me.TodayValue10.ForeColor = Color.Red), "red", If((Me.TodayValue10.ForeColor = Color.Red), "red", "")) }, { "value", " " + Me.TodayValue10.Text } })
			Me.todayData.Add(Me.TodayTitle11.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle11.Text }, { "color", If((Me.TodayValue11.ForeColor = Color.Blue), "blue", If((Me.TodayValue11.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", " " + Me.TodayValue11.Text } })
			Me.todayData.Add(Me.TodayTitle12.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle12.Text }, { "color", If((Me.TodayValue12.ForeColor = Color.DodgerBlue), "dodger-blue", If((Me.TodayValue12.ForeColor = Color.DodgerBlue), "dodger-blue", "")) }, { "value", " " + Me.TodayValue12.Text } })
			Me.todayData.Add(Me.TodayTitle13.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle13.Text }, { "color", If((Me.TodayValue13.ForeColor = Color.Green), "green", If((Me.TodayValue13.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.TodayValue13.Text } })
			Me.todayData.Add(Me.TodayTitle14.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle14.Text }, { "color", If((Me.TodayValue14.ForeColor = Color.Coral), "coral", If((Me.TodayValue14.ForeColor = Color.Coral), "coral", "")) }, { "value", " " + Me.TodayValue14.Text } })
			Me.todayData.Add(Me.TodayTitle15.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle15.Text }, { "color", If((Me.TodayValue15.ForeColor = Color.HotPink), "hot-pink", If((Me.TodayValue15.ForeColor = Color.HotPink), "hot-pink", "")) }, { "value", " " + Me.TodayValue15.Text } })
			Me.todayData.Add(Me.TodayTitle16.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle16.Text }, { "color", If((Me.TodayValue16.ForeColor = Color.HotPink), "hot-pink", If((Me.TodayValue16.ForeColor = Color.HotPink), "hot-pink", "")) }, { "value", " " + Me.TodayValue16.Text } })
			Me.todayData.Add(Me.TodayTitle17.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle17.Text }, { "color", If((Me.TodayValue17.ForeColor = Color.DarkOrange), "dark-orange", If((Me.TodayValue17.ForeColor = Color.DarkOrange), "dark-orange", "")) }, { "value", " " + Me.TodayValue17.Text } })
			Me.todayData.Add(Me.TodayTitle18.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.TodayTitle18.Text }, { "color", If((Me.TodayValue18.ForeColor = Color.DarkOrange), "dark-orange", If((Me.TodayValue18.ForeColor = Color.DarkOrange), "dark-orange", "")) }, { "value", " " + Me.TodayValue18.Text } })
			Me.fyData = New Dictionary(Of String, Dictionary(Of String, String))()
			Me.fyData.Add(Me.FYTitle1.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle1.Text }, { "color", If((Me.FYValue1.ForeColor = Color.Green), "green", If((Me.FYValue1.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.FYValue1.Text } })
			Me.fyData.Add(Me.FYTitle2.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle2.Text }, { "color", If((Me.FYValue2.ForeColor = Color.Coral), "coral", If((Me.FYValue2.ForeColor = Color.Coral), "coral", "")) }, { "value", " " + Me.FYValue2.Text } })
			Me.fyData.Add(Me.FYTitle3.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle3.Text }, { "color", If((Me.FYValue3.ForeColor = Color.Coral), "coral", If((Me.FYValue3.ForeColor = Color.Coral), "coral", "")) }, { "value", " " + Me.FYValue3.Text } })
			Me.fyData.Add(Me.FYTitle4.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle4.Text }, { "color", If((Me.FYValue4.ForeColor = Color.Green), "green", If((Me.FYValue4.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.FYValue4.Text } })
			Me.fyData.Add(Me.FYTitle5.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle5.Text }, { "color", If((Me.FYValue5.ForeColor = Color.Green), "green", If((Me.FYValue5.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.FYValue5.Text } })
			Me.fyData.Add(Me.FYTitle6.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle6.Text }, { "color", If((Me.FYValue6.ForeColor = Color.DarkOrange), "dark-orange", If((Me.FYValue6.ForeColor = Color.DarkOrange), "dark-orange", "")) }, { "value", " " + Me.FYValue6.Text } })
			Me.fyData.Add(Me.FYTitle7.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle7.Text }, { "color", If((Me.FYValue7.ForeColor = Color.Green), "green", If((Me.FYValue7.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.FYValue7.Text } })
			Me.fyData.Add(Me.FYTitle8.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle8.Text }, { "color", If((Me.FYValue8.ForeColor = Color.Green), "green", If((Me.FYValue8.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.FYValue8.Text } })
			Me.fyData.Add(Me.FYTitle9.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle9.Text }, { "color", If((Me.FYValue9.ForeColor = Color.Green), "green", If((Me.FYValue9.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.FYValue9.Text } })
			Me.fyData.Add(Me.FYTitle10.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle10.Text }, { "color", If((Me.FYValue10.ForeColor = Color.Red), "red", If((Me.FYValue10.ForeColor = Color.Red), "red", "")) }, { "value", " " + Me.FYValue10.Text } })
			Me.fyData.Add(Me.FYTitle11.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle11.Text }, { "color", If((Me.FYValue11.ForeColor = Color.Blue), "blue", If((Me.FYValue11.ForeColor = Color.DarkOrange), "darkorange", "")) }, { "value", " " + Me.FYValue11.Text } })
			Me.fyData.Add(Me.FYTitle12.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle12.Text }, { "color", If((Me.FYValue12.ForeColor = Color.DodgerBlue), "dodger-blue", If((Me.FYValue12.ForeColor = Color.DodgerBlue), "dodger-blue", "")) }, { "value", " " + Me.FYValue12.Text } })
			Me.fyData.Add(Me.FYTitle13.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle13.Text }, { "color", If((Me.FYValue13.ForeColor = Color.Green), "green", If((Me.FYValue13.ForeColor = Color.Green), "green", "")) }, { "value", " " + Me.FYValue13.Text } })
			Me.fyData.Add(Me.FYTitle14.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle14.Text }, { "color", If((Me.FYValue14.ForeColor = Color.Coral), "coral", If((Me.FYValue14.ForeColor = Color.Coral), "coral", "")) }, { "value", " " + Me.FYValue14.Text } })
			Me.fyData.Add(Me.FYTitle15.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle15.Text }, { "color", If((Me.FYValue15.ForeColor = Color.HotPink), "hot-pink", If((Me.FYValue15.ForeColor = Color.HotPink), "hot-pink", "")) }, { "value", " " + Me.FYValue15.Text } })
			Me.fyData.Add(Me.FYTitle16.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle16.Text }, { "color", If((Me.FYValue16.ForeColor = Color.HotPink), "hot-pink", If((Me.FYValue16.ForeColor = Color.HotPink), "hot-pink", "")) }, { "value", " " + Me.FYValue16.Text } })
			Me.fyData.Add(Me.FYTitle17.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle17.Text }, { "color", If((Me.FYValue17.ForeColor = Color.DarkOrange), "dark-orange", If((Me.FYValue17.ForeColor = Color.DarkOrange), "dark-orange", "")) }, { "value", " " + Me.FYValue17.Text } })
			Me.fyData.Add(Me.FYTitle18.Text.Replace(" ", "_").Replace("-", "_").ToLower(), New Dictionary(Of String, String)() From { { "title", Me.FYTitle18.Text }, { "color", If((Me.FYValue18.ForeColor = Color.DarkOrange), "dark-orange", If((Me.FYValue18.ForeColor = Color.DarkOrange), "dark-orange", "")) }, { "value", " " + Me.FYValue18.Text } })
			Dim thread As New Thread(AddressOf Me.UploadThreadEvent)
			thread.Start()
		End Sub

		' Token: 0x06001302 RID: 4866 RVA: 0x000CE404 File Offset: 0x000CC604
		Private Sub UploadThreadEvent()
			Dim flag As Boolean = Operators.CompareString(Me.s50, "Disable", False) = 0
			If Not flag Then
				Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
				If flag2 Then
					Try
						Me.Client.[Set](Of Dictionary(Of String, Dictionary(Of String, String)))(String.Format("comp/{0}/today/", Me.TBoxCompId.Text), Me.todayData)
						Me.Client.[Set](Of Dictionary(Of String, Dictionary(Of String, String)))(String.Format("comp/{0}/current_fy/", Me.TBoxCompId.Text), Me.fyData)
					Catch ex As Exception
					End Try
				End If
			End If
		End Sub

		' Token: 0x06001303 RID: 4867 RVA: 0x000CE4AC File Offset: 0x000CC6AC
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.UserControlSettings()
			Me.todaysale()
			Me.todaypurchase()
			Me.todaysalereturn()
			Me.todaypurchasereturn()
			Me.todayreceipt()
			Me.todaypayment()
			Me.todayserviceadvance()
			Me.todayservicebilling()
			Me.todayincome()
			Me.todayexpenses()
			Me.TodayContra()
			Me.TodayJournal()
			Me.cashinhand()
			Me.bankinhand()
			Me.SundryCreditor()
			Me.SundryDebtor()
			Me.SalaryAdvance()
			Me.SalaryPayment()
			Me.Totalsale()
			Me.TotalPurchase()
			Me.TotalSaleReturn()
			Me.TotalPurchaseReturn()
			Me.Totalreceipt()
			Me.TotalPayment()
			Me.TotalServiceAdvance()
			Me.TotalServiceBilling()
			Me.TotalIncome()
			Me.TotalExpenses()
			Me.TotalCashInHand()
			Me.TotalCashInbank()
			Me.TotalSundryCreditor()
			Me.TotalSundryDebtor()
			Me.TotalSalaryAdvance()
			Me.TotalSalaryPayment()
			Me.TotalContra()
			Me.TotalJournal()
		End Sub

		' Token: 0x06001304 RID: 4868 RVA: 0x000CE5C0 File Offset: 0x000CC7C0
		Public Sub GetCompanyInfo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName),RTRIM(Address),RTRIM(State),RTRIM(GSTIN),RTRIM(ContactNo),RTRIM(EmailID),RTRIM(FYFrom),RTRIM(FYTo),RTRIM(CurSym) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TBoxCompName.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.TBoxAddress.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.TBoxState.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.TBoxGSTIN.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.TBoxContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.TBoxEmail.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(6))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(7))
					Me.CurSym = NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(8), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString()
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

		' Token: 0x06001305 RID: 4869 RVA: 0x000CE7B0 File Offset: 0x000CC9B0
		Private Sub todaysale()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from InvoiceInfo where Day(InvoiceDate)=Day(GetDate()) and Month(InvoiceDate)=Month(GetDate()) and Year(InvoiceDate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue1.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue1.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001306 RID: 4870 RVA: 0x000CE8D0 File Offset: 0x000CCAD0
		Private Sub todaypurchase()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal)-Sum(PreviousDue),0) from Stock where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue2.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue2.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001307 RID: 4871 RVA: 0x000CE9F0 File Offset: 0x000CCBF0
		Private Sub todaysalereturn()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from SalesReturn where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue3.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue3.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue3.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001308 RID: 4872 RVA: 0x000CEB10 File Offset: 0x000CCD10
		Private Sub todaypurchasereturn()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from PurchaseReturn where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue4.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue4.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue4.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001309 RID: 4873 RVA: 0x000CEC30 File Offset: 0x000CCE30
		Private Sub todayreceipt()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(Amount),0) from CreditCustomerPayment where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue5.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue5.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue5.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600130A RID: 4874 RVA: 0x000CED50 File Offset: 0x000CCF50
		Private Sub todaypayment()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(Amount),0) from Payment where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue6.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue6.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue6.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600130B RID: 4875 RVA: 0x000CEE70 File Offset: 0x000CD070
		Private Sub todayserviceadvance()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(AdvanceDeposit),0) from Service where Day(ServiceCreationDate)=Day(GetDate()) and Month(ServiceCreationDate)=Month(GetDate()) and Year(ServiceCreationDate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue7.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue7.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue7.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600130C RID: 4876 RVA: 0x000CEF90 File Offset: 0x000CD190
		Private Sub todayservicebilling()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from InvoiceInfo1 where Day(InvoiceDate)=Day(GetDate()) and Month(InvoiceDate)=Month(GetDate()) and Year(InvoiceDate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue8.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue8.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue8.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600130D RID: 4877 RVA: 0x000CF0B0 File Offset: 0x000CD2B0
		Private Sub todayincome()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from Income where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue9.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue9.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue9.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600130E RID: 4878 RVA: 0x000CF1D0 File Offset: 0x000CD3D0
		Private Sub todayexpenses()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(GrandTotal),0) from Voucher where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue10.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue10.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue10.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600130F RID: 4879 RVA: 0x000CF2F0 File Offset: 0x000CD4F0
		Private Sub cashinhand()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(Credit)-Sum(Debit),0) from LedgerBook where Name='Cash Account' and Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue11.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue11.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue11.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001310 RID: 4880 RVA: 0x000CF410 File Offset: 0x000CD610
		Private Sub bankinhand()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select IsNull(Sum(Credit)-Sum(Debit),0) from LedgerBook where Name='Bank Account' and Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue12.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue12.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue12.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001311 RID: 4881 RVA: 0x000CF530 File Offset: 0x000CD730
		Private Sub SundryCreditor()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue13.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue13.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue13.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001312 RID: 4882 RVA: 0x000CF650 File Offset: 0x000CD850
		Private Sub SundryDebtor()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select isNULL(Sum(Debit),0)-IsNull(Sum(Credit),0) from CustomerLedgerBook where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue14.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue14.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue14.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001313 RID: 4883 RVA: 0x000CF770 File Offset: 0x000CD970
		Private Sub SalaryAdvance()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select isNULL(Sum(Amount),0) from AdvanceEntry where Day(Workingdate)=Day(GetDate()) and Month(Workingdate)=Month(GetDate()) and Year(Workingdate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue15.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue15.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue15.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001314 RID: 4884 RVA: 0x000CF890 File Offset: 0x000CDA90
		Private Sub SalaryPayment()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select isNULL(Sum(NetPay),0) from EmployeePayment where Day(Paymentdate)=Day(GetDate()) and Month(Paymentdate)=Month(GetDate()) and Year(Paymentdate)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue16.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue16.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue16.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001315 RID: 4885 RVA: 0x000CF9B0 File Offset: 0x000CDBB0
		Private Sub TodayContra()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select isNULL(Sum(Amount),0) from Contra where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue17.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue17.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue17.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001316 RID: 4886 RVA: 0x000CFAD0 File Offset: 0x000CDCD0
		Private Sub TodayJournal()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select isNULL(Sum(Amt),0) from Journal where Day(Date)=Day(GetDate()) and Month(Date)=Month(GetDate()) and Year(Date)=Year(GetDate())"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TodayValue18.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.TodayValue18.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.TodayValue18.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001317 RID: 4887 RVA: 0x000CFBF0 File Offset: 0x000CDDF0
		Private Sub TotalJournal()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(Amt),0) from Journal where Date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue18.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue18.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue18.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001318 RID: 4888 RVA: 0x000CFDA4 File Offset: 0x000CDFA4
		Private Sub TotalContra()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(Amount),0) from Contra where Date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue17.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue17.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue17.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001319 RID: 4889 RVA: 0x000CFF58 File Offset: 0x000CE158
		Private Sub Totalsale()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(GrandTotal),0) from invoiceinfo where invoicedate between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue1.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue1.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600131A RID: 4890 RVA: 0x000D010C File Offset: 0x000CE30C
		Private Sub TotalPurchase()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(GrandTotal)-Sum(PreviousDue),0) from Stock where Date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue2.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue2.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600131B RID: 4891 RVA: 0x000D02C0 File Offset: 0x000CE4C0
		Private Sub TotalSaleReturn()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(GrandTotal),0) from SalesReturn where date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue3.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue3.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue3.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600131C RID: 4892 RVA: 0x000D0474 File Offset: 0x000CE674
		Private Sub TotalPurchaseReturn()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(GrandTotal),0) from PurchaseReturn where date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue4.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue4.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue4.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600131D RID: 4893 RVA: 0x000D0628 File Offset: 0x000CE828
		Private Sub Totalreceipt()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(Amount),0) from CreditCustomerPayment where date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue5.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue5.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue5.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600131E RID: 4894 RVA: 0x000D07DC File Offset: 0x000CE9DC
		Private Sub TotalPayment()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(Amount),0) from Payment where date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue6.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue6.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue6.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600131F RID: 4895 RVA: 0x000D0990 File Offset: 0x000CEB90
		Private Sub TotalServiceAdvance()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(AdvanceDeposit),0) from Service where ServiceCreationDate between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "ServiceCreationDate").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "ServiceCreationDate").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue7.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue7.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue7.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001320 RID: 4896 RVA: 0x000D0B44 File Offset: 0x000CED44
		Private Sub TotalServiceBilling()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(GrandTotal),0) from InvoiceInfo1 where InvoiceDate between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue8.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue8.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue8.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001321 RID: 4897 RVA: 0x000D0CF8 File Offset: 0x000CEEF8
		Private Sub TotalIncome()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(GrandTotal),0) from Income where date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue9.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue9.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue9.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001322 RID: 4898 RVA: 0x000D0EAC File Offset: 0x000CF0AC
		Private Sub TotalExpenses()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(GrandTotal),0) from Voucher where date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue10.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue10.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue10.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001323 RID: 4899 RVA: 0x000D1060 File Offset: 0x000CF260
		Private Sub TotalCashInHand()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(Credit)-Sum(Debit),0) from LedgerBook where Name='Cash Account' and date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue11.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue11.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue11.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001324 RID: 4900 RVA: 0x000D1214 File Offset: 0x000CF414
		Private Sub TotalCashInbank()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNull(Sum(Credit)-Sum(Debit),0) from LedgerBook where Name='Bank Account' and date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue12.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue12.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue12.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001325 RID: 4901 RVA: 0x000D13C8 File Offset: 0x000CF5C8
		Private Sub TotalSundryCreditor()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue13.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue13.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue13.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001326 RID: 4902 RVA: 0x000D157C File Offset: 0x000CF77C
		Private Sub TotalSundryDebtor()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT IsNULL(Sum(Debit),0)-IsNull(Sum(Credit),0) from CustomerLedgerBook where date between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue14.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue14.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue14.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001327 RID: 4903 RVA: 0x000D1730 File Offset: 0x000CF930
		Private Sub TotalSalaryAdvance()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT isNULL(Sum(Amount),0) from AdvanceEntry where Workingdate between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue15.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue15.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue15.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001328 RID: 4904 RVA: 0x000D18E4 File Offset: 0x000CFAE4
		Private Sub TotalSalaryPayment()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT isNULL(Sum(NetPay),0) from EmployeePayment where Paymentdate between @f1  And  @f2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DTP1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DTP2.Value.[Date].AddDays(0.0)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.FYValue16.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.FYValue16.Text = Me.CurSym + " " + Strings.Format(Math.Round(Conversion.Val(Me.FYValue16.Text), 2), "0.00")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0400061E RID: 1566
		Private s50 As String

		' Token: 0x0400061F RID: 1567
		Private CurSym As String

		' Token: 0x04000620 RID: 1568
		Private autoUpdateTimer As Global.System.Windows.Forms.Timer

		' Token: 0x04000621 RID: 1569
		Private Config As IFirebaseConfig

		' Token: 0x04000622 RID: 1570
		Private Client As IFirebaseClient

		' Token: 0x04000623 RID: 1571
		Private todayData As Dictionary(Of String, Dictionary(Of String, String))

		' Token: 0x04000624 RID: 1572
		Private fyData As Dictionary(Of String, Dictionary(Of String, String))
	End Class
End Namespace
