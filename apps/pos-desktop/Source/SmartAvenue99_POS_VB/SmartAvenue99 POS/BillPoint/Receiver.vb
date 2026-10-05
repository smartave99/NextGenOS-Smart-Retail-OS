Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports FireSharp
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000476 RID: 1142
	<DesignerGenerated()>
	Public Partial Class Receiver
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600E843 RID: 59459 RVA: 0x008CF174 File Offset: 0x008CD374
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.ErpAnd_Load
			AddHandler MyBase.Shown, AddressOf Me.Form_Shown
			Me.autoUpdateTimer = New Timer()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005914 RID: 22804
		' (get) Token: 0x0600E846 RID: 59462 RVA: 0x000662B3 File Offset: 0x000644B3
		' (set) Token: 0x0600E847 RID: 59463 RVA: 0x000662BD File Offset: 0x000644BD
		Friend Overridable Property TodayTitle1 As Label

		' Token: 0x17005915 RID: 22805
		' (get) Token: 0x0600E848 RID: 59464 RVA: 0x000662C6 File Offset: 0x000644C6
		' (set) Token: 0x0600E849 RID: 59465 RVA: 0x000662D0 File Offset: 0x000644D0
		Friend Overridable Property TodayTitle2 As Label

		' Token: 0x17005916 RID: 22806
		' (get) Token: 0x0600E84A RID: 59466 RVA: 0x000662D9 File Offset: 0x000644D9
		' (set) Token: 0x0600E84B RID: 59467 RVA: 0x000662E3 File Offset: 0x000644E3
		Friend Overridable Property TodayTitle3 As Label

		' Token: 0x17005917 RID: 22807
		' (get) Token: 0x0600E84C RID: 59468 RVA: 0x000662EC File Offset: 0x000644EC
		' (set) Token: 0x0600E84D RID: 59469 RVA: 0x000662F6 File Offset: 0x000644F6
		Friend Overridable Property TodayTitle4 As Label

		' Token: 0x17005918 RID: 22808
		' (get) Token: 0x0600E84E RID: 59470 RVA: 0x000662FF File Offset: 0x000644FF
		' (set) Token: 0x0600E84F RID: 59471 RVA: 0x00066309 File Offset: 0x00064509
		Friend Overridable Property TodayTitle5 As Label

		' Token: 0x17005919 RID: 22809
		' (get) Token: 0x0600E850 RID: 59472 RVA: 0x00066312 File Offset: 0x00064512
		' (set) Token: 0x0600E851 RID: 59473 RVA: 0x0006631C File Offset: 0x0006451C
		Friend Overridable Property TodayTitle6 As Label

		' Token: 0x1700591A RID: 22810
		' (get) Token: 0x0600E852 RID: 59474 RVA: 0x00066325 File Offset: 0x00064525
		' (set) Token: 0x0600E853 RID: 59475 RVA: 0x0006632F File Offset: 0x0006452F
		Friend Overridable Property TodayTitle7 As Label

		' Token: 0x1700591B RID: 22811
		' (get) Token: 0x0600E854 RID: 59476 RVA: 0x00066338 File Offset: 0x00064538
		' (set) Token: 0x0600E855 RID: 59477 RVA: 0x00066342 File Offset: 0x00064542
		Friend Overridable Property TodayTitle8 As Label

		' Token: 0x1700591C RID: 22812
		' (get) Token: 0x0600E856 RID: 59478 RVA: 0x0006634B File Offset: 0x0006454B
		' (set) Token: 0x0600E857 RID: 59479 RVA: 0x00066355 File Offset: 0x00064555
		Friend Overridable Property TodayTitle9 As Label

		' Token: 0x1700591D RID: 22813
		' (get) Token: 0x0600E858 RID: 59480 RVA: 0x0006635E File Offset: 0x0006455E
		' (set) Token: 0x0600E859 RID: 59481 RVA: 0x00066368 File Offset: 0x00064568
		Friend Overridable Property TodayTitle10 As Label

		' Token: 0x1700591E RID: 22814
		' (get) Token: 0x0600E85A RID: 59482 RVA: 0x00066371 File Offset: 0x00064571
		' (set) Token: 0x0600E85B RID: 59483 RVA: 0x0006637B File Offset: 0x0006457B
		Friend Overridable Property TodayTitle11 As Label

		' Token: 0x1700591F RID: 22815
		' (get) Token: 0x0600E85C RID: 59484 RVA: 0x00066384 File Offset: 0x00064584
		' (set) Token: 0x0600E85D RID: 59485 RVA: 0x0006638E File Offset: 0x0006458E
		Friend Overridable Property TodayTitle12 As Label

		' Token: 0x17005920 RID: 22816
		' (get) Token: 0x0600E85E RID: 59486 RVA: 0x00066397 File Offset: 0x00064597
		' (set) Token: 0x0600E85F RID: 59487 RVA: 0x000663A1 File Offset: 0x000645A1
		Friend Overridable Property FYTitle12 As Label

		' Token: 0x17005921 RID: 22817
		' (get) Token: 0x0600E860 RID: 59488 RVA: 0x000663AA File Offset: 0x000645AA
		' (set) Token: 0x0600E861 RID: 59489 RVA: 0x000663B4 File Offset: 0x000645B4
		Friend Overridable Property FYTitle11 As Label

		' Token: 0x17005922 RID: 22818
		' (get) Token: 0x0600E862 RID: 59490 RVA: 0x000663BD File Offset: 0x000645BD
		' (set) Token: 0x0600E863 RID: 59491 RVA: 0x000663C7 File Offset: 0x000645C7
		Friend Overridable Property FYTitle10 As Label

		' Token: 0x17005923 RID: 22819
		' (get) Token: 0x0600E864 RID: 59492 RVA: 0x000663D0 File Offset: 0x000645D0
		' (set) Token: 0x0600E865 RID: 59493 RVA: 0x000663DA File Offset: 0x000645DA
		Friend Overridable Property FYTitle9 As Label

		' Token: 0x17005924 RID: 22820
		' (get) Token: 0x0600E866 RID: 59494 RVA: 0x000663E3 File Offset: 0x000645E3
		' (set) Token: 0x0600E867 RID: 59495 RVA: 0x000663ED File Offset: 0x000645ED
		Friend Overridable Property FYTitle8 As Label

		' Token: 0x17005925 RID: 22821
		' (get) Token: 0x0600E868 RID: 59496 RVA: 0x000663F6 File Offset: 0x000645F6
		' (set) Token: 0x0600E869 RID: 59497 RVA: 0x00066400 File Offset: 0x00064600
		Friend Overridable Property FYTitle7 As Label

		' Token: 0x17005926 RID: 22822
		' (get) Token: 0x0600E86A RID: 59498 RVA: 0x00066409 File Offset: 0x00064609
		' (set) Token: 0x0600E86B RID: 59499 RVA: 0x00066413 File Offset: 0x00064613
		Friend Overridable Property FYTitle6 As Label

		' Token: 0x17005927 RID: 22823
		' (get) Token: 0x0600E86C RID: 59500 RVA: 0x0006641C File Offset: 0x0006461C
		' (set) Token: 0x0600E86D RID: 59501 RVA: 0x00066426 File Offset: 0x00064626
		Friend Overridable Property FYTitle5 As Label

		' Token: 0x17005928 RID: 22824
		' (get) Token: 0x0600E86E RID: 59502 RVA: 0x0006642F File Offset: 0x0006462F
		' (set) Token: 0x0600E86F RID: 59503 RVA: 0x00066439 File Offset: 0x00064639
		Friend Overridable Property FYTitle4 As Label

		' Token: 0x17005929 RID: 22825
		' (get) Token: 0x0600E870 RID: 59504 RVA: 0x00066442 File Offset: 0x00064642
		' (set) Token: 0x0600E871 RID: 59505 RVA: 0x0006644C File Offset: 0x0006464C
		Friend Overridable Property FYTitle3 As Label

		' Token: 0x1700592A RID: 22826
		' (get) Token: 0x0600E872 RID: 59506 RVA: 0x00066455 File Offset: 0x00064655
		' (set) Token: 0x0600E873 RID: 59507 RVA: 0x0006645F File Offset: 0x0006465F
		Friend Overridable Property FYTitle2 As Label

		' Token: 0x1700592B RID: 22827
		' (get) Token: 0x0600E874 RID: 59508 RVA: 0x00066468 File Offset: 0x00064668
		' (set) Token: 0x0600E875 RID: 59509 RVA: 0x00066472 File Offset: 0x00064672
		Friend Overridable Property FYTitle1 As Label

		' Token: 0x1700592C RID: 22828
		' (get) Token: 0x0600E876 RID: 59510 RVA: 0x0006647B File Offset: 0x0006467B
		' (set) Token: 0x0600E877 RID: 59511 RVA: 0x00066485 File Offset: 0x00064685
		Friend Overridable Property Label25 As Label

		' Token: 0x1700592D RID: 22829
		' (get) Token: 0x0600E878 RID: 59512 RVA: 0x0006648E File Offset: 0x0006468E
		' (set) Token: 0x0600E879 RID: 59513 RVA: 0x00066498 File Offset: 0x00064698
		Friend Overridable Property Label26 As Label

		' Token: 0x1700592E RID: 22830
		' (get) Token: 0x0600E87A RID: 59514 RVA: 0x000664A1 File Offset: 0x000646A1
		' (set) Token: 0x0600E87B RID: 59515 RVA: 0x000664AB File Offset: 0x000646AB
		Friend Overridable Property TodayValue1 As TextBox

		' Token: 0x1700592F RID: 22831
		' (get) Token: 0x0600E87C RID: 59516 RVA: 0x000664B4 File Offset: 0x000646B4
		' (set) Token: 0x0600E87D RID: 59517 RVA: 0x000664BE File Offset: 0x000646BE
		Friend Overridable Property TodayValue2 As TextBox

		' Token: 0x17005930 RID: 22832
		' (get) Token: 0x0600E87E RID: 59518 RVA: 0x000664C7 File Offset: 0x000646C7
		' (set) Token: 0x0600E87F RID: 59519 RVA: 0x000664D1 File Offset: 0x000646D1
		Friend Overridable Property TodayValue3 As TextBox

		' Token: 0x17005931 RID: 22833
		' (get) Token: 0x0600E880 RID: 59520 RVA: 0x000664DA File Offset: 0x000646DA
		' (set) Token: 0x0600E881 RID: 59521 RVA: 0x000664E4 File Offset: 0x000646E4
		Friend Overridable Property TodayValue4 As TextBox

		' Token: 0x17005932 RID: 22834
		' (get) Token: 0x0600E882 RID: 59522 RVA: 0x000664ED File Offset: 0x000646ED
		' (set) Token: 0x0600E883 RID: 59523 RVA: 0x000664F7 File Offset: 0x000646F7
		Friend Overridable Property TodayValue5 As TextBox

		' Token: 0x17005933 RID: 22835
		' (get) Token: 0x0600E884 RID: 59524 RVA: 0x00066500 File Offset: 0x00064700
		' (set) Token: 0x0600E885 RID: 59525 RVA: 0x0006650A File Offset: 0x0006470A
		Friend Overridable Property TodayValue6 As TextBox

		' Token: 0x17005934 RID: 22836
		' (get) Token: 0x0600E886 RID: 59526 RVA: 0x00066513 File Offset: 0x00064713
		' (set) Token: 0x0600E887 RID: 59527 RVA: 0x0006651D File Offset: 0x0006471D
		Friend Overridable Property TodayValue7 As TextBox

		' Token: 0x17005935 RID: 22837
		' (get) Token: 0x0600E888 RID: 59528 RVA: 0x00066526 File Offset: 0x00064726
		' (set) Token: 0x0600E889 RID: 59529 RVA: 0x00066530 File Offset: 0x00064730
		Friend Overridable Property TodayValue8 As TextBox

		' Token: 0x17005936 RID: 22838
		' (get) Token: 0x0600E88A RID: 59530 RVA: 0x00066539 File Offset: 0x00064739
		' (set) Token: 0x0600E88B RID: 59531 RVA: 0x00066543 File Offset: 0x00064743
		Friend Overridable Property TodayValue9 As TextBox

		' Token: 0x17005937 RID: 22839
		' (get) Token: 0x0600E88C RID: 59532 RVA: 0x0006654C File Offset: 0x0006474C
		' (set) Token: 0x0600E88D RID: 59533 RVA: 0x00066556 File Offset: 0x00064756
		Friend Overridable Property TodayValue10 As TextBox

		' Token: 0x17005938 RID: 22840
		' (get) Token: 0x0600E88E RID: 59534 RVA: 0x0006655F File Offset: 0x0006475F
		' (set) Token: 0x0600E88F RID: 59535 RVA: 0x00066569 File Offset: 0x00064769
		Friend Overridable Property TodayValue11 As TextBox

		' Token: 0x17005939 RID: 22841
		' (get) Token: 0x0600E890 RID: 59536 RVA: 0x00066572 File Offset: 0x00064772
		' (set) Token: 0x0600E891 RID: 59537 RVA: 0x0006657C File Offset: 0x0006477C
		Friend Overridable Property TodayValue12 As TextBox

		' Token: 0x1700593A RID: 22842
		' (get) Token: 0x0600E892 RID: 59538 RVA: 0x00066585 File Offset: 0x00064785
		' (set) Token: 0x0600E893 RID: 59539 RVA: 0x0006658F File Offset: 0x0006478F
		Friend Overridable Property FYValue1 As TextBox

		' Token: 0x1700593B RID: 22843
		' (get) Token: 0x0600E894 RID: 59540 RVA: 0x00066598 File Offset: 0x00064798
		' (set) Token: 0x0600E895 RID: 59541 RVA: 0x000665A2 File Offset: 0x000647A2
		Friend Overridable Property FYValue2 As TextBox

		' Token: 0x1700593C RID: 22844
		' (get) Token: 0x0600E896 RID: 59542 RVA: 0x000665AB File Offset: 0x000647AB
		' (set) Token: 0x0600E897 RID: 59543 RVA: 0x000665B5 File Offset: 0x000647B5
		Friend Overridable Property FYValue3 As TextBox

		' Token: 0x1700593D RID: 22845
		' (get) Token: 0x0600E898 RID: 59544 RVA: 0x000665BE File Offset: 0x000647BE
		' (set) Token: 0x0600E899 RID: 59545 RVA: 0x000665C8 File Offset: 0x000647C8
		Friend Overridable Property FYValue4 As TextBox

		' Token: 0x1700593E RID: 22846
		' (get) Token: 0x0600E89A RID: 59546 RVA: 0x000665D1 File Offset: 0x000647D1
		' (set) Token: 0x0600E89B RID: 59547 RVA: 0x000665DB File Offset: 0x000647DB
		Friend Overridable Property FYValue5 As TextBox

		' Token: 0x1700593F RID: 22847
		' (get) Token: 0x0600E89C RID: 59548 RVA: 0x000665E4 File Offset: 0x000647E4
		' (set) Token: 0x0600E89D RID: 59549 RVA: 0x000665EE File Offset: 0x000647EE
		Friend Overridable Property FYValue6 As TextBox

		' Token: 0x17005940 RID: 22848
		' (get) Token: 0x0600E89E RID: 59550 RVA: 0x000665F7 File Offset: 0x000647F7
		' (set) Token: 0x0600E89F RID: 59551 RVA: 0x00066601 File Offset: 0x00064801
		Friend Overridable Property FYValue7 As TextBox

		' Token: 0x17005941 RID: 22849
		' (get) Token: 0x0600E8A0 RID: 59552 RVA: 0x0006660A File Offset: 0x0006480A
		' (set) Token: 0x0600E8A1 RID: 59553 RVA: 0x00066614 File Offset: 0x00064814
		Friend Overridable Property FYValue8 As TextBox

		' Token: 0x17005942 RID: 22850
		' (get) Token: 0x0600E8A2 RID: 59554 RVA: 0x0006661D File Offset: 0x0006481D
		' (set) Token: 0x0600E8A3 RID: 59555 RVA: 0x00066627 File Offset: 0x00064827
		Friend Overridable Property FYValue9 As TextBox

		' Token: 0x17005943 RID: 22851
		' (get) Token: 0x0600E8A4 RID: 59556 RVA: 0x00066630 File Offset: 0x00064830
		' (set) Token: 0x0600E8A5 RID: 59557 RVA: 0x0006663A File Offset: 0x0006483A
		Friend Overridable Property FYValue10 As TextBox

		' Token: 0x17005944 RID: 22852
		' (get) Token: 0x0600E8A6 RID: 59558 RVA: 0x00066643 File Offset: 0x00064843
		' (set) Token: 0x0600E8A7 RID: 59559 RVA: 0x0006664D File Offset: 0x0006484D
		Friend Overridable Property FYValue11 As TextBox

		' Token: 0x17005945 RID: 22853
		' (get) Token: 0x0600E8A8 RID: 59560 RVA: 0x00066656 File Offset: 0x00064856
		' (set) Token: 0x0600E8A9 RID: 59561 RVA: 0x00066660 File Offset: 0x00064860
		Friend Overridable Property FYValue12 As TextBox

		' Token: 0x17005946 RID: 22854
		' (get) Token: 0x0600E8AA RID: 59562 RVA: 0x00066669 File Offset: 0x00064869
		' (set) Token: 0x0600E8AB RID: 59563 RVA: 0x00066673 File Offset: 0x00064873
		Friend Overridable Property Label27 As Label

		' Token: 0x17005947 RID: 22855
		' (get) Token: 0x0600E8AC RID: 59564 RVA: 0x0006667C File Offset: 0x0006487C
		' (set) Token: 0x0600E8AD RID: 59565 RVA: 0x00066686 File Offset: 0x00064886
		Friend Overridable Property Label28 As Label

		' Token: 0x17005948 RID: 22856
		' (get) Token: 0x0600E8AE RID: 59566 RVA: 0x0006668F File Offset: 0x0006488F
		' (set) Token: 0x0600E8AF RID: 59567 RVA: 0x00066699 File Offset: 0x00064899
		Friend Overridable Property Label29 As Label

		' Token: 0x17005949 RID: 22857
		' (get) Token: 0x0600E8B0 RID: 59568 RVA: 0x000666A2 File Offset: 0x000648A2
		' (set) Token: 0x0600E8B1 RID: 59569 RVA: 0x000666AC File Offset: 0x000648AC
		Friend Overridable Property Label30 As Label

		' Token: 0x1700594A RID: 22858
		' (get) Token: 0x0600E8B2 RID: 59570 RVA: 0x000666B5 File Offset: 0x000648B5
		' (set) Token: 0x0600E8B3 RID: 59571 RVA: 0x000666BF File Offset: 0x000648BF
		Friend Overridable Property Label31 As Label

		' Token: 0x1700594B RID: 22859
		' (get) Token: 0x0600E8B4 RID: 59572 RVA: 0x000666C8 File Offset: 0x000648C8
		' (set) Token: 0x0600E8B5 RID: 59573 RVA: 0x000666D2 File Offset: 0x000648D2
		Friend Overridable Property Label32 As Label

		' Token: 0x1700594C RID: 22860
		' (get) Token: 0x0600E8B6 RID: 59574 RVA: 0x000666DB File Offset: 0x000648DB
		' (set) Token: 0x0600E8B7 RID: 59575 RVA: 0x000666E5 File Offset: 0x000648E5
		Friend Overridable Property TBoxCompName As TextBox

		' Token: 0x1700594D RID: 22861
		' (get) Token: 0x0600E8B8 RID: 59576 RVA: 0x000666EE File Offset: 0x000648EE
		' (set) Token: 0x0600E8B9 RID: 59577 RVA: 0x000666F8 File Offset: 0x000648F8
		Friend Overridable Property TBoxAddress As TextBox

		' Token: 0x1700594E RID: 22862
		' (get) Token: 0x0600E8BA RID: 59578 RVA: 0x00066701 File Offset: 0x00064901
		' (set) Token: 0x0600E8BB RID: 59579 RVA: 0x0006670B File Offset: 0x0006490B
		Friend Overridable Property TBoxState As TextBox

		' Token: 0x1700594F RID: 22863
		' (get) Token: 0x0600E8BC RID: 59580 RVA: 0x00066714 File Offset: 0x00064914
		' (set) Token: 0x0600E8BD RID: 59581 RVA: 0x0006671E File Offset: 0x0006491E
		Friend Overridable Property TBoxGSTIN As TextBox

		' Token: 0x17005950 RID: 22864
		' (get) Token: 0x0600E8BE RID: 59582 RVA: 0x00066727 File Offset: 0x00064927
		' (set) Token: 0x0600E8BF RID: 59583 RVA: 0x00066731 File Offset: 0x00064931
		Friend Overridable Property TBoxContactNo As TextBox

		' Token: 0x17005951 RID: 22865
		' (get) Token: 0x0600E8C0 RID: 59584 RVA: 0x0006673A File Offset: 0x0006493A
		' (set) Token: 0x0600E8C1 RID: 59585 RVA: 0x00066744 File Offset: 0x00064944
		Friend Overridable Property TBoxEmail As TextBox

		' Token: 0x17005952 RID: 22866
		' (get) Token: 0x0600E8C2 RID: 59586 RVA: 0x0006674D File Offset: 0x0006494D
		' (set) Token: 0x0600E8C3 RID: 59587 RVA: 0x00066757 File Offset: 0x00064957
		Friend Overridable Property TodayValue13 As TextBox

		' Token: 0x17005953 RID: 22867
		' (get) Token: 0x0600E8C4 RID: 59588 RVA: 0x00066760 File Offset: 0x00064960
		' (set) Token: 0x0600E8C5 RID: 59589 RVA: 0x0006676A File Offset: 0x0006496A
		Friend Overridable Property FYValue13 As TextBox

		' Token: 0x17005954 RID: 22868
		' (get) Token: 0x0600E8C6 RID: 59590 RVA: 0x00066773 File Offset: 0x00064973
		' (set) Token: 0x0600E8C7 RID: 59591 RVA: 0x0006677D File Offset: 0x0006497D
		Friend Overridable Property TodayTitle13 As Label

		' Token: 0x17005955 RID: 22869
		' (get) Token: 0x0600E8C8 RID: 59592 RVA: 0x00066786 File Offset: 0x00064986
		' (set) Token: 0x0600E8C9 RID: 59593 RVA: 0x00066790 File Offset: 0x00064990
		Friend Overridable Property FYValue14 As TextBox

		' Token: 0x17005956 RID: 22870
		' (get) Token: 0x0600E8CA RID: 59594 RVA: 0x00066799 File Offset: 0x00064999
		' (set) Token: 0x0600E8CB RID: 59595 RVA: 0x000667A3 File Offset: 0x000649A3
		Friend Overridable Property TodayValue14 As TextBox

		' Token: 0x17005957 RID: 22871
		' (get) Token: 0x0600E8CC RID: 59596 RVA: 0x000667AC File Offset: 0x000649AC
		' (set) Token: 0x0600E8CD RID: 59597 RVA: 0x000667B6 File Offset: 0x000649B6
		Friend Overridable Property TodayTitle14 As Label

		' Token: 0x17005958 RID: 22872
		' (get) Token: 0x0600E8CE RID: 59598 RVA: 0x000667BF File Offset: 0x000649BF
		' (set) Token: 0x0600E8CF RID: 59599 RVA: 0x000667C9 File Offset: 0x000649C9
		Friend Overridable Property FYTitle14 As Label

		' Token: 0x17005959 RID: 22873
		' (get) Token: 0x0600E8D0 RID: 59600 RVA: 0x000667D2 File Offset: 0x000649D2
		' (set) Token: 0x0600E8D1 RID: 59601 RVA: 0x000667DC File Offset: 0x000649DC
		Friend Overridable Property FYTitle13 As Label

		' Token: 0x1700595A RID: 22874
		' (get) Token: 0x0600E8D2 RID: 59602 RVA: 0x000667E5 File Offset: 0x000649E5
		' (set) Token: 0x0600E8D3 RID: 59603 RVA: 0x000667EF File Offset: 0x000649EF
		Friend Overridable Property TBoxCompId As TextBox

		' Token: 0x1700595B RID: 22875
		' (get) Token: 0x0600E8D4 RID: 59604 RVA: 0x000667F8 File Offset: 0x000649F8
		' (set) Token: 0x0600E8D5 RID: 59605 RVA: 0x00066802 File Offset: 0x00064A02
		Friend Overridable Property Label1 As Label

		' Token: 0x1700595C RID: 22876
		' (get) Token: 0x0600E8D6 RID: 59606 RVA: 0x0006680B File Offset: 0x00064A0B
		' (set) Token: 0x0600E8D7 RID: 59607 RVA: 0x00066815 File Offset: 0x00064A15
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x1700595D RID: 22877
		' (get) Token: 0x0600E8D8 RID: 59608 RVA: 0x0006681E File Offset: 0x00064A1E
		' (set) Token: 0x0600E8D9 RID: 59609 RVA: 0x00066828 File Offset: 0x00064A28
		Friend Overridable Property Label2 As Label

		' Token: 0x1700595E RID: 22878
		' (get) Token: 0x0600E8DA RID: 59610 RVA: 0x00066831 File Offset: 0x00064A31
		' (set) Token: 0x0600E8DB RID: 59611 RVA: 0x0006683B File Offset: 0x00064A3B
		Friend Overridable Property Label3 As Label

		' Token: 0x1700595F RID: 22879
		' (get) Token: 0x0600E8DC RID: 59612 RVA: 0x00066844 File Offset: 0x00064A44
		' (set) Token: 0x0600E8DD RID: 59613 RVA: 0x0006684E File Offset: 0x00064A4E
		Friend Overridable Property TodayTitle16 As Label

		' Token: 0x17005960 RID: 22880
		' (get) Token: 0x0600E8DE RID: 59614 RVA: 0x00066857 File Offset: 0x00064A57
		' (set) Token: 0x0600E8DF RID: 59615 RVA: 0x00066861 File Offset: 0x00064A61
		Friend Overridable Property TodayTitle15 As Label

		' Token: 0x17005961 RID: 22881
		' (get) Token: 0x0600E8E0 RID: 59616 RVA: 0x0006686A File Offset: 0x00064A6A
		' (set) Token: 0x0600E8E1 RID: 59617 RVA: 0x00066874 File Offset: 0x00064A74
		Friend Overridable Property FYTitle15 As Label

		' Token: 0x17005962 RID: 22882
		' (get) Token: 0x0600E8E2 RID: 59618 RVA: 0x0006687D File Offset: 0x00064A7D
		' (set) Token: 0x0600E8E3 RID: 59619 RVA: 0x00066887 File Offset: 0x00064A87
		Friend Overridable Property FYTitle16 As Label

		' Token: 0x17005963 RID: 22883
		' (get) Token: 0x0600E8E4 RID: 59620 RVA: 0x00066890 File Offset: 0x00064A90
		' (set) Token: 0x0600E8E5 RID: 59621 RVA: 0x0006689A File Offset: 0x00064A9A
		Friend Overridable Property TodayValue15 As TextBox

		' Token: 0x17005964 RID: 22884
		' (get) Token: 0x0600E8E6 RID: 59622 RVA: 0x000668A3 File Offset: 0x00064AA3
		' (set) Token: 0x0600E8E7 RID: 59623 RVA: 0x000668AD File Offset: 0x00064AAD
		Friend Overridable Property TodayValue16 As TextBox

		' Token: 0x17005965 RID: 22885
		' (get) Token: 0x0600E8E8 RID: 59624 RVA: 0x000668B6 File Offset: 0x00064AB6
		' (set) Token: 0x0600E8E9 RID: 59625 RVA: 0x000668C0 File Offset: 0x00064AC0
		Friend Overridable Property FYValue15 As TextBox

		' Token: 0x17005966 RID: 22886
		' (get) Token: 0x0600E8EA RID: 59626 RVA: 0x000668C9 File Offset: 0x00064AC9
		' (set) Token: 0x0600E8EB RID: 59627 RVA: 0x000668D3 File Offset: 0x00064AD3
		Friend Overridable Property FYValue16 As TextBox

		' Token: 0x17005967 RID: 22887
		' (get) Token: 0x0600E8EC RID: 59628 RVA: 0x000668DC File Offset: 0x00064ADC
		' (set) Token: 0x0600E8ED RID: 59629 RVA: 0x000668E6 File Offset: 0x00064AE6
		Friend Overridable Property TodayValue17 As TextBox

		' Token: 0x17005968 RID: 22888
		' (get) Token: 0x0600E8EE RID: 59630 RVA: 0x000668EF File Offset: 0x00064AEF
		' (set) Token: 0x0600E8EF RID: 59631 RVA: 0x000668F9 File Offset: 0x00064AF9
		Friend Overridable Property FYValue17 As TextBox

		' Token: 0x17005969 RID: 22889
		' (get) Token: 0x0600E8F0 RID: 59632 RVA: 0x00066902 File Offset: 0x00064B02
		' (set) Token: 0x0600E8F1 RID: 59633 RVA: 0x0006690C File Offset: 0x00064B0C
		Friend Overridable Property TodayValue18 As TextBox

		' Token: 0x1700596A RID: 22890
		' (get) Token: 0x0600E8F2 RID: 59634 RVA: 0x00066915 File Offset: 0x00064B15
		' (set) Token: 0x0600E8F3 RID: 59635 RVA: 0x0006691F File Offset: 0x00064B1F
		Friend Overridable Property FYValue18 As TextBox

		' Token: 0x1700596B RID: 22891
		' (get) Token: 0x0600E8F4 RID: 59636 RVA: 0x00066928 File Offset: 0x00064B28
		' (set) Token: 0x0600E8F5 RID: 59637 RVA: 0x00066932 File Offset: 0x00064B32
		Friend Overridable Property TodayTitle17 As Label

		' Token: 0x1700596C RID: 22892
		' (get) Token: 0x0600E8F6 RID: 59638 RVA: 0x0006693B File Offset: 0x00064B3B
		' (set) Token: 0x0600E8F7 RID: 59639 RVA: 0x00066945 File Offset: 0x00064B45
		Friend Overridable Property FYTitle17 As Label

		' Token: 0x1700596D RID: 22893
		' (get) Token: 0x0600E8F8 RID: 59640 RVA: 0x0006694E File Offset: 0x00064B4E
		' (set) Token: 0x0600E8F9 RID: 59641 RVA: 0x00066958 File Offset: 0x00064B58
		Friend Overridable Property FYTitle18 As Label

		' Token: 0x1700596E RID: 22894
		' (get) Token: 0x0600E8FA RID: 59642 RVA: 0x00066961 File Offset: 0x00064B61
		' (set) Token: 0x0600E8FB RID: 59643 RVA: 0x0006696B File Offset: 0x00064B6B
		Friend Overridable Property TodayTitle18 As Label

		' Token: 0x0600E8FC RID: 59644 RVA: 0x00066974 File Offset: 0x00064B74
		Private Sub ErpAnd_Load(sender As Object, e As EventArgs)
			Me.AutoUpdater()
		End Sub

		' Token: 0x0600E8FD RID: 59645 RVA: 0x008D442C File Offset: 0x008D262C
		Private Sub AutoUpdater()
			Me.Config = New FirebaseConfig() With { .AuthSecret = "9TSon0zKBvGgAX5r8KI1tvv3y4NQdKGntYlrBm3B", .BasePath = "https://androidbillsoftreport-default-rtdb.asia-southeast1.firebasedatabase.app" }
			Me.Client = New FirebaseClient(Me.Config)
			Me.TBoxCompName.Text = Me.Client.[Get](String.Format("comp/{0}/comp_name", Me.TBoxCompId.Text)).ResultAs(Of String)()
			Me.TBoxAddress.Text = Me.Client.[Get](String.Format("comp/{0}/comp_address", Me.TBoxCompId.Text)).ResultAs(Of String)()
			Me.TBoxState.Text = Me.Client.[Get](String.Format("comp/{0}/comp_state", Me.TBoxCompId.Text)).ResultAs(Of String)()
			Me.TBoxGSTIN.Text = Me.Client.[Get](String.Format("comp/{0}/comp_gstin", Me.TBoxCompId.Text)).ResultAs(Of String)()
			Me.TBoxContactNo.Text = Me.Client.[Get](String.Format("comp/{0}/comp_contactno", Me.TBoxCompId.Text)).ResultAs(Of String)()
			Me.TBoxEmail.Text = Me.Client.[Get](String.Format("comp/{0}/comp_email", Me.TBoxCompId.Text)).ResultAs(Of String)()
			Me.todayData = New Dictionary(Of String, Dictionary(Of String, String))()
			Me.fyData = New Dictionary(Of String, Dictionary(Of String, String))()
			Me.autoUpdateTimer.Interval = 10000
			AddHandler Me.autoUpdateTimer.Tick, AddressOf Me.AutoUpdater_Event
			Me.autoUpdateTimer.Start()
		End Sub

		' Token: 0x0600E8FE RID: 59646 RVA: 0x008D45E0 File Offset: 0x008D27E0
		Private Sub AutoUpdater_Event(sender As Object, e As EventArgs)
			Try
				Me.todayData = Me.Client.[Get](String.Format("comp/{0}/today", Me.TBoxCompId.Text)).ResultAs(Of Dictionary(Of String, Dictionary(Of String, String)))()
			Catch ex As Exception
			End Try
			Try
				Me.fyData = Me.Client.[Get](String.Format("comp/{0}/current_fy", Me.TBoxCompId.Text)).ResultAs(Of Dictionary(Of String, Dictionary(Of String, String)))()
			Catch ex2 As Exception
			End Try
			Dim flag As Boolean = Me.todayData Is Nothing
			If Not flag Then
				Dim flag2 As Boolean = Me.fyData Is Nothing
				If Not flag2 Then
					Try
						Try
							For Each keyValuePair As KeyValuePair(Of String, Dictionary(Of String, String)) In Me.todayData
								Dim flag3 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle1.Text, False) = 0
								If flag3 Then
									Me.TodayValue1.Text = keyValuePair.Value("value")
									Dim flag4 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
									If flag4 Then
										Me.TodayValue1.ForeColor = Color.Red
									Else
										Dim flag5 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
										If flag5 Then
											Me.TodayValue1.ForeColor = Color.Green
										Else
											Dim flag6 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
											If flag6 Then
												Me.TodayValue1.ForeColor = Color.Blue
											Else
												Dim flag7 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
												If flag7 Then
													Me.TodayValue1.ForeColor = Color.DarkOrange
												Else
													Dim flag8 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
													If flag8 Then
														Me.TodayValue1.ForeColor = Color.HotPink
													Else
														Dim flag9 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
														If flag9 Then
															Me.TodayValue1.ForeColor = Color.Coral
														Else
															Dim flag10 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
															If flag10 Then
																Me.TodayValue1.ForeColor = Color.DodgerBlue
															Else
																Me.TodayValue1.ForeColor = Color.Black
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								Else
									Dim flag11 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle2.Text, False) = 0
									If flag11 Then
										Me.TodayValue2.Text = keyValuePair.Value("value")
										Dim flag12 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
										If flag12 Then
											Me.TodayValue2.ForeColor = Color.Red
										Else
											Dim flag13 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
											If flag13 Then
												Me.TodayValue2.ForeColor = Color.Green
											Else
												Dim flag14 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
												If flag14 Then
													Me.TodayValue2.ForeColor = Color.Blue
												Else
													Dim flag15 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
													If flag15 Then
														Me.TodayValue2.ForeColor = Color.DarkOrange
													Else
														Dim flag16 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
														If flag16 Then
															Me.TodayValue2.ForeColor = Color.HotPink
														Else
															Dim flag17 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
															If flag17 Then
																Me.TodayValue2.ForeColor = Color.Coral
															Else
																Dim flag18 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																If flag18 Then
																	Me.TodayValue2.ForeColor = Color.DodgerBlue
																Else
																	Me.TodayValue2.ForeColor = Color.Black
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									Else
										Dim flag19 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle3.Text, False) = 0
										If flag19 Then
											Me.TodayValue3.Text = keyValuePair.Value("value")
											Dim flag20 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
											If flag20 Then
												Me.TodayValue3.ForeColor = Color.Red
											Else
												Dim flag21 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
												If flag21 Then
													Me.TodayValue3.ForeColor = Color.Green
												Else
													Dim flag22 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
													If flag22 Then
														Me.TodayValue3.ForeColor = Color.Blue
													Else
														Dim flag23 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
														If flag23 Then
															Me.TodayValue3.ForeColor = Color.DarkOrange
														Else
															Dim flag24 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
															If flag24 Then
																Me.TodayValue3.ForeColor = Color.HotPink
															Else
																Dim flag25 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																If flag25 Then
																	Me.TodayValue3.ForeColor = Color.Coral
																Else
																	Dim flag26 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																	If flag26 Then
																		Me.TodayValue3.ForeColor = Color.DodgerBlue
																	Else
																		Me.TodayValue3.ForeColor = Color.Black
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										Else
											Dim flag27 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle4.Text, False) = 0
											If flag27 Then
												Me.TodayValue4.Text = keyValuePair.Value("value")
												Dim flag28 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
												If flag28 Then
													Me.TodayValue4.ForeColor = Color.Red
												Else
													Dim flag29 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
													If flag29 Then
														Me.TodayValue4.ForeColor = Color.Green
													Else
														Dim flag30 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
														If flag30 Then
															Me.TodayValue4.ForeColor = Color.Blue
														Else
															Dim flag31 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
															If flag31 Then
																Me.TodayValue4.ForeColor = Color.DarkOrange
															Else
																Dim flag32 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																If flag32 Then
																	Me.TodayValue4.ForeColor = Color.HotPink
																Else
																	Dim flag33 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																	If flag33 Then
																		Me.TodayValue4.ForeColor = Color.Coral
																	Else
																		Dim flag34 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																		If flag34 Then
																			Me.TodayValue4.ForeColor = Color.DodgerBlue
																		Else
																			Me.TodayValue4.ForeColor = Color.Black
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											Else
												Dim flag35 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle5.Text, False) = 0
												If flag35 Then
													Me.TodayValue5.Text = keyValuePair.Value("value")
													Dim flag36 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
													If flag36 Then
														Me.TodayValue5.ForeColor = Color.Red
													Else
														Dim flag37 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
														If flag37 Then
															Me.TodayValue5.ForeColor = Color.Green
														Else
															Dim flag38 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
															If flag38 Then
																Me.TodayValue5.ForeColor = Color.Blue
															Else
																Dim flag39 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																If flag39 Then
																	Me.TodayValue5.ForeColor = Color.DarkOrange
																Else
																	Dim flag40 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																	If flag40 Then
																		Me.TodayValue5.ForeColor = Color.HotPink
																	Else
																		Dim flag41 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																		If flag41 Then
																			Me.TodayValue5.ForeColor = Color.Coral
																		Else
																			Dim flag42 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																			If flag42 Then
																				Me.TodayValue5.ForeColor = Color.DodgerBlue
																			Else
																				Me.TodayValue5.ForeColor = Color.Black
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												Else
													Dim flag43 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle6.Text, False) = 0
													If flag43 Then
														Me.TodayValue6.Text = keyValuePair.Value("value")
														Dim flag44 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
														If flag44 Then
															Me.TodayValue6.ForeColor = Color.Red
														Else
															Dim flag45 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
															If flag45 Then
																Me.TodayValue6.ForeColor = Color.Green
															Else
																Dim flag46 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																If flag46 Then
																	Me.TodayValue6.ForeColor = Color.Blue
																Else
																	Dim flag47 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																	If flag47 Then
																		Me.TodayValue6.ForeColor = Color.DarkOrange
																	Else
																		Dim flag48 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																		If flag48 Then
																			Me.TodayValue6.ForeColor = Color.HotPink
																		Else
																			Dim flag49 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																			If flag49 Then
																				Me.TodayValue6.ForeColor = Color.Coral
																			Else
																				Dim flag50 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																				If flag50 Then
																					Me.TodayValue6.ForeColor = Color.DodgerBlue
																				Else
																					Me.TodayValue6.ForeColor = Color.Black
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													Else
														Dim flag51 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle7.Text, False) = 0
														If flag51 Then
															Me.TodayValue7.Text = keyValuePair.Value("value")
															Dim flag52 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
															If flag52 Then
																Me.TodayValue7.ForeColor = Color.Red
															Else
																Dim flag53 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																If flag53 Then
																	Me.TodayValue7.ForeColor = Color.Green
																Else
																	Dim flag54 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																	If flag54 Then
																		Me.TodayValue7.ForeColor = Color.Blue
																	Else
																		Dim flag55 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																		If flag55 Then
																			Me.TodayValue7.ForeColor = Color.DarkOrange
																		Else
																			Dim flag56 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																			If flag56 Then
																				Me.TodayValue7.ForeColor = Color.HotPink
																			Else
																				Dim flag57 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																				If flag57 Then
																					Me.TodayValue7.ForeColor = Color.Coral
																				Else
																					Dim flag58 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																					If flag58 Then
																						Me.TodayValue7.ForeColor = Color.DodgerBlue
																					Else
																						Me.TodayValue7.ForeColor = Color.Black
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														Else
															Dim flag59 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle8.Text, False) = 0
															If flag59 Then
																Me.TodayValue8.Text = keyValuePair.Value("value")
																Dim flag60 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																If flag60 Then
																	Me.TodayValue8.ForeColor = Color.Red
																Else
																	Dim flag61 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																	If flag61 Then
																		Me.TodayValue8.ForeColor = Color.Green
																	Else
																		Dim flag62 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																		If flag62 Then
																			Me.TodayValue8.ForeColor = Color.Blue
																		Else
																			Dim flag63 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																			If flag63 Then
																				Me.TodayValue8.ForeColor = Color.DarkOrange
																			Else
																				Dim flag64 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																				If flag64 Then
																					Me.TodayValue8.ForeColor = Color.HotPink
																				Else
																					Dim flag65 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																					If flag65 Then
																						Me.TodayValue8.ForeColor = Color.Coral
																					Else
																						Dim flag66 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																						If flag66 Then
																							Me.TodayValue8.ForeColor = Color.DodgerBlue
																						Else
																							Me.TodayValue8.ForeColor = Color.Black
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															Else
																Dim flag67 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle9.Text, False) = 0
																If flag67 Then
																	Me.TodayValue9.Text = keyValuePair.Value("value")
																	Dim flag68 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																	If flag68 Then
																		Me.TodayValue9.ForeColor = Color.Red
																	Else
																		Dim flag69 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																		If flag69 Then
																			Me.TodayValue9.ForeColor = Color.Green
																		Else
																			Dim flag70 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																			If flag70 Then
																				Me.TodayValue9.ForeColor = Color.Blue
																			Else
																				Dim flag71 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																				If flag71 Then
																					Me.TodayValue9.ForeColor = Color.DarkOrange
																				Else
																					Dim flag72 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																					If flag72 Then
																						Me.TodayValue9.ForeColor = Color.HotPink
																					Else
																						Dim flag73 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																						If flag73 Then
																							Me.TodayValue9.ForeColor = Color.Coral
																						Else
																							Dim flag74 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																							If flag74 Then
																								Me.TodayValue9.ForeColor = Color.DodgerBlue
																							Else
																								Me.TodayValue9.ForeColor = Color.Black
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																Else
																	Dim flag75 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle10.Text, False) = 0
																	If flag75 Then
																		Me.TodayValue10.Text = keyValuePair.Value("value")
																		Dim flag76 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																		If flag76 Then
																			Me.TodayValue10.ForeColor = Color.Red
																		Else
																			Dim flag77 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																			If flag77 Then
																				Me.TodayValue10.ForeColor = Color.Green
																			Else
																				Dim flag78 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																				If flag78 Then
																					Me.TodayValue10.ForeColor = Color.Blue
																				Else
																					Dim flag79 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																					If flag79 Then
																						Me.TodayValue10.ForeColor = Color.DarkOrange
																					Else
																						Dim flag80 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																						If flag80 Then
																							Me.TodayValue10.ForeColor = Color.HotPink
																						Else
																							Dim flag81 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																							If flag81 Then
																								Me.TodayValue10.ForeColor = Color.Coral
																							Else
																								Dim flag82 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																								If flag82 Then
																									Me.TodayValue10.ForeColor = Color.DodgerBlue
																								Else
																									Me.TodayValue10.ForeColor = Color.Black
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	Else
																		Dim flag83 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle11.Text, False) = 0
																		If flag83 Then
																			Me.TodayValue11.Text = keyValuePair.Value("value")
																			Dim flag84 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																			If flag84 Then
																				Me.TodayValue11.ForeColor = Color.Red
																			Else
																				Dim flag85 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																				If flag85 Then
																					Me.TodayValue11.ForeColor = Color.Green
																				Else
																					Dim flag86 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																					If flag86 Then
																						Me.TodayValue11.ForeColor = Color.Blue
																					Else
																						Dim flag87 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																						If flag87 Then
																							Me.TodayValue11.ForeColor = Color.DarkOrange
																						Else
																							Dim flag88 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																							If flag88 Then
																								Me.TodayValue11.ForeColor = Color.HotPink
																							Else
																								Dim flag89 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																								If flag89 Then
																									Me.TodayValue11.ForeColor = Color.Coral
																								Else
																									Dim flag90 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																									If flag90 Then
																										Me.TodayValue11.ForeColor = Color.DodgerBlue
																									Else
																										Me.TodayValue11.ForeColor = Color.Black
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		Else
																			Dim flag91 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle12.Text, False) = 0
																			If flag91 Then
																				Me.TodayValue12.Text = keyValuePair.Value("value")
																				Dim flag92 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																				If flag92 Then
																					Me.TodayValue12.ForeColor = Color.Red
																				Else
																					Dim flag93 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																					If flag93 Then
																						Me.TodayValue12.ForeColor = Color.Green
																					Else
																						Dim flag94 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																						If flag94 Then
																							Me.TodayValue12.ForeColor = Color.Blue
																						Else
																							Dim flag95 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																							If flag95 Then
																								Me.TodayValue12.ForeColor = Color.DarkOrange
																							Else
																								Dim flag96 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																								If flag96 Then
																									Me.TodayValue12.ForeColor = Color.HotPink
																								Else
																									Dim flag97 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																									If flag97 Then
																										Me.TodayValue12.ForeColor = Color.Coral
																									Else
																										Dim flag98 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																										If flag98 Then
																											Me.TodayValue12.ForeColor = Color.DodgerBlue
																										Else
																											Me.TodayValue12.ForeColor = Color.Black
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			Else
																				Dim flag99 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle13.Text, False) = 0
																				If flag99 Then
																					Me.TodayValue13.Text = keyValuePair.Value("value")
																					Dim flag100 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																					If flag100 Then
																						Me.TodayValue13.ForeColor = Color.Red
																					Else
																						Dim flag101 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																						If flag101 Then
																							Me.TodayValue13.ForeColor = Color.Green
																						Else
																							Dim flag102 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																							If flag102 Then
																								Me.TodayValue13.ForeColor = Color.Blue
																							Else
																								Dim flag103 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																								If flag103 Then
																									Me.TodayValue13.ForeColor = Color.DarkOrange
																								Else
																									Dim flag104 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																									If flag104 Then
																										Me.TodayValue13.ForeColor = Color.HotPink
																									Else
																										Dim flag105 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																										If flag105 Then
																											Me.TodayValue13.ForeColor = Color.Coral
																										Else
																											Dim flag106 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																											If flag106 Then
																												Me.TodayValue13.ForeColor = Color.DodgerBlue
																											Else
																												Me.TodayValue13.ForeColor = Color.Black
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				Else
																					Dim flag107 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle14.Text, False) = 0
																					If flag107 Then
																						Me.TodayValue14.Text = keyValuePair.Value("value")
																						Dim flag108 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																						If flag108 Then
																							Me.TodayValue14.ForeColor = Color.Red
																						Else
																							Dim flag109 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																							If flag109 Then
																								Me.TodayValue14.ForeColor = Color.Green
																							Else
																								Dim flag110 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																								If flag110 Then
																									Me.TodayValue14.ForeColor = Color.Blue
																								Else
																									Dim flag111 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																									If flag111 Then
																										Me.TodayValue14.ForeColor = Color.DarkOrange
																									Else
																										Dim flag112 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																										If flag112 Then
																											Me.TodayValue14.ForeColor = Color.HotPink
																										Else
																											Dim flag113 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																											If flag113 Then
																												Me.TodayValue14.ForeColor = Color.Coral
																											Else
																												Dim flag114 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																												If flag114 Then
																													Me.TodayValue14.ForeColor = Color.DodgerBlue
																												Else
																													Me.TodayValue14.ForeColor = Color.Black
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					Else
																						Dim flag115 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle15.Text, False) = 0
																						If flag115 Then
																							Me.TodayValue15.Text = keyValuePair.Value("value")
																							Dim flag116 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																							If flag116 Then
																								Me.TodayValue15.ForeColor = Color.Red
																							Else
																								Dim flag117 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																								If flag117 Then
																									Me.TodayValue15.ForeColor = Color.Green
																								Else
																									Dim flag118 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																									If flag118 Then
																										Me.TodayValue15.ForeColor = Color.Blue
																									Else
																										Dim flag119 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																										If flag119 Then
																											Me.TodayValue15.ForeColor = Color.DarkOrange
																										Else
																											Dim flag120 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																											If flag120 Then
																												Me.TodayValue15.ForeColor = Color.HotPink
																											Else
																												Dim flag121 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																												If flag121 Then
																													Me.TodayValue15.ForeColor = Color.Coral
																												Else
																													Dim flag122 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																													If flag122 Then
																														Me.TodayValue15.ForeColor = Color.DodgerBlue
																													Else
																														Me.TodayValue15.ForeColor = Color.Black
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						Else
																							Dim flag123 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle16.Text, False) = 0
																							If flag123 Then
																								Me.TodayValue16.Text = keyValuePair.Value("value")
																								Dim flag124 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																								If flag124 Then
																									Me.TodayValue16.ForeColor = Color.Red
																								Else
																									Dim flag125 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																									If flag125 Then
																										Me.TodayValue16.ForeColor = Color.Green
																									Else
																										Dim flag126 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																										If flag126 Then
																											Me.TodayValue16.ForeColor = Color.Blue
																										Else
																											Dim flag127 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																											If flag127 Then
																												Me.TodayValue16.ForeColor = Color.DarkOrange
																											Else
																												Dim flag128 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																												If flag128 Then
																													Me.TodayValue16.ForeColor = Color.HotPink
																												Else
																													Dim flag129 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																													If flag129 Then
																														Me.TodayValue16.ForeColor = Color.Coral
																													Else
																														Dim flag130 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																														If flag130 Then
																															Me.TodayValue16.ForeColor = Color.DodgerBlue
																														Else
																															Me.TodayValue16.ForeColor = Color.Black
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							Else
																								Dim flag131 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle17.Text, False) = 0
																								If flag131 Then
																									Me.TodayValue17.Text = keyValuePair.Value("value")
																									Dim flag132 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																									If flag132 Then
																										Me.TodayValue17.ForeColor = Color.Red
																									Else
																										Dim flag133 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																										If flag133 Then
																											Me.TodayValue17.ForeColor = Color.Green
																										Else
																											Dim flag134 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																											If flag134 Then
																												Me.TodayValue17.ForeColor = Color.Blue
																											Else
																												Dim flag135 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																												If flag135 Then
																													Me.TodayValue17.ForeColor = Color.DarkOrange
																												Else
																													Dim flag136 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																													If flag136 Then
																														Me.TodayValue17.ForeColor = Color.HotPink
																													Else
																														Dim flag137 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																														If flag137 Then
																															Me.TodayValue17.ForeColor = Color.Coral
																														Else
																															Dim flag138 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																															If flag138 Then
																																Me.TodayValue17.ForeColor = Color.DodgerBlue
																															Else
																																Me.TodayValue17.ForeColor = Color.Black
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								Else
																									Dim flag139 As Boolean = Operators.CompareString(keyValuePair.Value("title"), Me.TodayTitle18.Text, False) = 0
																									If flag139 Then
																										Me.TodayValue18.Text = keyValuePair.Value("value")
																										Dim flag140 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "red", False) = 0
																										If flag140 Then
																											Me.TodayValue18.ForeColor = Color.Red
																										Else
																											Dim flag141 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "green", False) = 0
																											If flag141 Then
																												Me.TodayValue18.ForeColor = Color.Green
																											Else
																												Dim flag142 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "blue", False) = 0
																												If flag142 Then
																													Me.TodayValue18.ForeColor = Color.Blue
																												Else
																													Dim flag143 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dark-orange", False) = 0
																													If flag143 Then
																														Me.TodayValue18.ForeColor = Color.DarkOrange
																													Else
																														Dim flag144 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "hot-pink", False) = 0
																														If flag144 Then
																															Me.TodayValue18.ForeColor = Color.HotPink
																														Else
																															Dim flag145 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "coral", False) = 0
																															If flag145 Then
																																Me.TodayValue18.ForeColor = Color.Coral
																															Else
																																Dim flag146 As Boolean = Operators.CompareString(keyValuePair.Value("color"), "dodger-blue", False) = 0
																																If flag146 Then
																																	Me.TodayValue18.ForeColor = Color.DodgerBlue
																																Else
																																	Me.TodayValue18.ForeColor = Color.Black
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							Next
						Finally
							Dim enumerator As Dictionary(Of String, Dictionary(Of String, String)).Enumerator
							CType(enumerator, IDisposable).Dispose()
						End Try
					Catch ex3 As Exception
					End Try
					Try
						Try
							For Each keyValuePair2 As KeyValuePair(Of String, Dictionary(Of String, String)) In Me.fyData
								Dim flag147 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle1.Text, False) = 0
								If flag147 Then
									Me.FYValue1.Text = keyValuePair2.Value("value")
									Dim flag148 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
									If flag148 Then
										Me.FYValue1.ForeColor = Color.Red
									Else
										Dim flag149 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
										If flag149 Then
											Me.FYValue1.ForeColor = Color.Green
										Else
											Dim flag150 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
											If flag150 Then
												Me.FYValue1.ForeColor = Color.Blue
											Else
												Dim flag151 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
												If flag151 Then
													Me.FYValue1.ForeColor = Color.DarkOrange
												Else
													Dim flag152 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
													If flag152 Then
														Me.FYValue1.ForeColor = Color.HotPink
													Else
														Dim flag153 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
														If flag153 Then
															Me.FYValue1.ForeColor = Color.Coral
														Else
															Dim flag154 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
															If flag154 Then
																Me.FYValue1.ForeColor = Color.DodgerBlue
															Else
																Me.FYValue1.ForeColor = Color.Black
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								Else
									Dim flag155 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle2.Text, False) = 0
									If flag155 Then
										Me.FYValue2.Text = keyValuePair2.Value("value")
										Dim flag156 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
										If flag156 Then
											Me.FYValue2.ForeColor = Color.Red
										Else
											Dim flag157 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
											If flag157 Then
												Me.FYValue2.ForeColor = Color.Green
											Else
												Dim flag158 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
												If flag158 Then
													Me.FYValue2.ForeColor = Color.Blue
												Else
													Dim flag159 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
													If flag159 Then
														Me.FYValue2.ForeColor = Color.DarkOrange
													Else
														Dim flag160 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
														If flag160 Then
															Me.FYValue2.ForeColor = Color.HotPink
														Else
															Dim flag161 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
															If flag161 Then
																Me.FYValue2.ForeColor = Color.Coral
															Else
																Dim flag162 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																If flag162 Then
																	Me.FYValue2.ForeColor = Color.DodgerBlue
																Else
																	Me.FYValue2.ForeColor = Color.Black
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									Else
										Dim flag163 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle3.Text, False) = 0
										If flag163 Then
											Me.FYValue3.Text = keyValuePair2.Value("value")
											Dim flag164 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
											If flag164 Then
												Me.FYValue3.ForeColor = Color.Red
											Else
												Dim flag165 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
												If flag165 Then
													Me.FYValue3.ForeColor = Color.Green
												Else
													Dim flag166 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
													If flag166 Then
														Me.FYValue3.ForeColor = Color.Blue
													Else
														Dim flag167 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
														If flag167 Then
															Me.FYValue3.ForeColor = Color.DarkOrange
														Else
															Dim flag168 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
															If flag168 Then
																Me.FYValue3.ForeColor = Color.HotPink
															Else
																Dim flag169 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																If flag169 Then
																	Me.FYValue3.ForeColor = Color.Coral
																Else
																	Dim flag170 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																	If flag170 Then
																		Me.FYValue3.ForeColor = Color.DodgerBlue
																	Else
																		Me.FYValue3.ForeColor = Color.Black
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										Else
											Dim flag171 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle4.Text, False) = 0
											If flag171 Then
												Me.FYValue4.Text = keyValuePair2.Value("value")
												Dim flag172 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
												If flag172 Then
													Me.FYValue4.ForeColor = Color.Red
												Else
													Dim flag173 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
													If flag173 Then
														Me.FYValue4.ForeColor = Color.Green
													Else
														Dim flag174 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
														If flag174 Then
															Me.FYValue4.ForeColor = Color.Blue
														Else
															Dim flag175 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
															If flag175 Then
																Me.FYValue4.ForeColor = Color.DarkOrange
															Else
																Dim flag176 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																If flag176 Then
																	Me.FYValue4.ForeColor = Color.HotPink
																Else
																	Dim flag177 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																	If flag177 Then
																		Me.FYValue4.ForeColor = Color.Coral
																	Else
																		Dim flag178 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																		If flag178 Then
																			Me.FYValue4.ForeColor = Color.DodgerBlue
																		Else
																			Me.FYValue4.ForeColor = Color.Black
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											Else
												Dim flag179 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle5.Text, False) = 0
												If flag179 Then
													Me.FYValue5.Text = keyValuePair2.Value("value")
													Dim flag180 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
													If flag180 Then
														Me.FYValue5.ForeColor = Color.Red
													Else
														Dim flag181 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
														If flag181 Then
															Me.FYValue5.ForeColor = Color.Green
														Else
															Dim flag182 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
															If flag182 Then
																Me.FYValue5.ForeColor = Color.Blue
															Else
																Dim flag183 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																If flag183 Then
																	Me.FYValue5.ForeColor = Color.DarkOrange
																Else
																	Dim flag184 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																	If flag184 Then
																		Me.FYValue5.ForeColor = Color.HotPink
																	Else
																		Dim flag185 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																		If flag185 Then
																			Me.FYValue5.ForeColor = Color.Coral
																		Else
																			Dim flag186 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																			If flag186 Then
																				Me.FYValue5.ForeColor = Color.DodgerBlue
																			Else
																				Me.FYValue5.ForeColor = Color.Black
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												Else
													Dim flag187 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle6.Text, False) = 0
													If flag187 Then
														Me.FYValue6.Text = keyValuePair2.Value("value")
														Dim flag188 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
														If flag188 Then
															Me.FYValue6.ForeColor = Color.Red
														Else
															Dim flag189 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
															If flag189 Then
																Me.FYValue6.ForeColor = Color.Green
															Else
																Dim flag190 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																If flag190 Then
																	Me.FYValue6.ForeColor = Color.Blue
																Else
																	Dim flag191 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																	If flag191 Then
																		Me.FYValue6.ForeColor = Color.DarkOrange
																	Else
																		Dim flag192 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																		If flag192 Then
																			Me.FYValue6.ForeColor = Color.HotPink
																		Else
																			Dim flag193 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																			If flag193 Then
																				Me.FYValue6.ForeColor = Color.Coral
																			Else
																				Dim flag194 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																				If flag194 Then
																					Me.FYValue6.ForeColor = Color.DodgerBlue
																				Else
																					Me.FYValue6.ForeColor = Color.Black
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													Else
														Dim flag195 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle7.Text, False) = 0
														If flag195 Then
															Me.FYValue7.Text = keyValuePair2.Value("value")
															Dim flag196 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
															If flag196 Then
																Me.FYValue7.ForeColor = Color.Red
															Else
																Dim flag197 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																If flag197 Then
																	Me.FYValue7.ForeColor = Color.Green
																Else
																	Dim flag198 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																	If flag198 Then
																		Me.FYValue7.ForeColor = Color.Blue
																	Else
																		Dim flag199 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																		If flag199 Then
																			Me.FYValue7.ForeColor = Color.DarkOrange
																		Else
																			Dim flag200 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																			If flag200 Then
																				Me.FYValue7.ForeColor = Color.HotPink
																			Else
																				Dim flag201 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																				If flag201 Then
																					Me.FYValue7.ForeColor = Color.Coral
																				Else
																					Dim flag202 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																					If flag202 Then
																						Me.FYValue7.ForeColor = Color.DodgerBlue
																					Else
																						Me.FYValue7.ForeColor = Color.Black
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														Else
															Dim flag203 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle8.Text, False) = 0
															If flag203 Then
																Me.FYValue8.Text = keyValuePair2.Value("value")
																Dim flag204 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																If flag204 Then
																	Me.FYValue8.ForeColor = Color.Red
																Else
																	Dim flag205 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																	If flag205 Then
																		Me.FYValue8.ForeColor = Color.Green
																	Else
																		Dim flag206 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																		If flag206 Then
																			Me.FYValue8.ForeColor = Color.Blue
																		Else
																			Dim flag207 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																			If flag207 Then
																				Me.FYValue8.ForeColor = Color.DarkOrange
																			Else
																				Dim flag208 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																				If flag208 Then
																					Me.FYValue8.ForeColor = Color.HotPink
																				Else
																					Dim flag209 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																					If flag209 Then
																						Me.FYValue8.ForeColor = Color.Coral
																					Else
																						Dim flag210 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																						If flag210 Then
																							Me.FYValue8.ForeColor = Color.DodgerBlue
																						Else
																							Me.FYValue8.ForeColor = Color.Black
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															Else
																Dim flag211 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle9.Text, False) = 0
																If flag211 Then
																	Me.FYValue9.Text = keyValuePair2.Value("value")
																	Dim flag212 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																	If flag212 Then
																		Me.FYValue9.ForeColor = Color.Red
																	Else
																		Dim flag213 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																		If flag213 Then
																			Me.FYValue9.ForeColor = Color.Green
																		Else
																			Dim flag214 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																			If flag214 Then
																				Me.FYValue9.ForeColor = Color.Blue
																			Else
																				Dim flag215 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																				If flag215 Then
																					Me.FYValue9.ForeColor = Color.DarkOrange
																				Else
																					Dim flag216 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																					If flag216 Then
																						Me.FYValue9.ForeColor = Color.HotPink
																					Else
																						Dim flag217 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																						If flag217 Then
																							Me.FYValue9.ForeColor = Color.Coral
																						Else
																							Dim flag218 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																							If flag218 Then
																								Me.FYValue9.ForeColor = Color.DodgerBlue
																							Else
																								Me.FYValue9.ForeColor = Color.Black
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																Else
																	Dim flag219 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle10.Text, False) = 0
																	If flag219 Then
																		Me.FYValue10.Text = keyValuePair2.Value("value")
																		Dim flag220 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																		If flag220 Then
																			Me.FYValue10.ForeColor = Color.Red
																		Else
																			Dim flag221 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																			If flag221 Then
																				Me.FYValue10.ForeColor = Color.Green
																			Else
																				Dim flag222 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																				If flag222 Then
																					Me.FYValue10.ForeColor = Color.Blue
																				Else
																					Dim flag223 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																					If flag223 Then
																						Me.FYValue10.ForeColor = Color.DarkOrange
																					Else
																						Dim flag224 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																						If flag224 Then
																							Me.FYValue10.ForeColor = Color.HotPink
																						Else
																							Dim flag225 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																							If flag225 Then
																								Me.FYValue10.ForeColor = Color.Coral
																							Else
																								Dim flag226 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																								If flag226 Then
																									Me.FYValue10.ForeColor = Color.DodgerBlue
																								Else
																									Me.FYValue10.ForeColor = Color.Black
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	Else
																		Dim flag227 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle11.Text, False) = 0
																		If flag227 Then
																			Me.FYValue11.Text = keyValuePair2.Value("value")
																			Dim flag228 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																			If flag228 Then
																				Me.FYValue11.ForeColor = Color.Red
																			Else
																				Dim flag229 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																				If flag229 Then
																					Me.FYValue11.ForeColor = Color.Green
																				Else
																					Dim flag230 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																					If flag230 Then
																						Me.FYValue11.ForeColor = Color.Blue
																					Else
																						Dim flag231 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																						If flag231 Then
																							Me.FYValue11.ForeColor = Color.DarkOrange
																						Else
																							Dim flag232 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																							If flag232 Then
																								Me.FYValue11.ForeColor = Color.HotPink
																							Else
																								Dim flag233 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																								If flag233 Then
																									Me.FYValue11.ForeColor = Color.Coral
																								Else
																									Dim flag234 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																									If flag234 Then
																										Me.FYValue11.ForeColor = Color.DodgerBlue
																									Else
																										Me.FYValue11.ForeColor = Color.Black
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		Else
																			Dim flag235 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle12.Text, False) = 0
																			If flag235 Then
																				Me.FYValue12.Text = keyValuePair2.Value("value")
																				Dim flag236 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																				If flag236 Then
																					Me.FYValue12.ForeColor = Color.Red
																				Else
																					Dim flag237 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																					If flag237 Then
																						Me.FYValue12.ForeColor = Color.Green
																					Else
																						Dim flag238 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																						If flag238 Then
																							Me.FYValue12.ForeColor = Color.Blue
																						Else
																							Dim flag239 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																							If flag239 Then
																								Me.FYValue12.ForeColor = Color.DarkOrange
																							Else
																								Dim flag240 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																								If flag240 Then
																									Me.FYValue12.ForeColor = Color.HotPink
																								Else
																									Dim flag241 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																									If flag241 Then
																										Me.FYValue12.ForeColor = Color.Coral
																									Else
																										Dim flag242 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																										If flag242 Then
																											Me.FYValue12.ForeColor = Color.DodgerBlue
																										Else
																											Me.FYValue12.ForeColor = Color.Black
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			Else
																				Dim flag243 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle13.Text, False) = 0
																				If flag243 Then
																					Me.FYValue13.Text = keyValuePair2.Value("value")
																					Dim flag244 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																					If flag244 Then
																						Me.FYValue13.ForeColor = Color.Red
																					Else
																						Dim flag245 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																						If flag245 Then
																							Me.FYValue13.ForeColor = Color.Green
																						Else
																							Dim flag246 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																							If flag246 Then
																								Me.FYValue13.ForeColor = Color.Blue
																							Else
																								Dim flag247 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																								If flag247 Then
																									Me.FYValue13.ForeColor = Color.DarkOrange
																								Else
																									Dim flag248 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																									If flag248 Then
																										Me.FYValue13.ForeColor = Color.HotPink
																									Else
																										Dim flag249 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																										If flag249 Then
																											Me.FYValue13.ForeColor = Color.Coral
																										Else
																											Dim flag250 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																											If flag250 Then
																												Me.FYValue13.ForeColor = Color.DodgerBlue
																											Else
																												Me.FYValue13.ForeColor = Color.Black
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				Else
																					Dim flag251 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle14.Text, False) = 0
																					If flag251 Then
																						Me.FYValue14.Text = keyValuePair2.Value("value")
																						Dim flag252 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																						If flag252 Then
																							Me.FYValue14.ForeColor = Color.Red
																						Else
																							Dim flag253 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																							If flag253 Then
																								Me.FYValue14.ForeColor = Color.Green
																							Else
																								Dim flag254 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																								If flag254 Then
																									Me.FYValue14.ForeColor = Color.Blue
																								Else
																									Dim flag255 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																									If flag255 Then
																										Me.FYValue14.ForeColor = Color.DarkOrange
																									Else
																										Dim flag256 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																										If flag256 Then
																											Me.FYValue14.ForeColor = Color.HotPink
																										Else
																											Dim flag257 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																											If flag257 Then
																												Me.FYValue14.ForeColor = Color.Coral
																											Else
																												Dim flag258 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																												If flag258 Then
																													Me.FYValue14.ForeColor = Color.DodgerBlue
																												Else
																													Me.FYValue14.ForeColor = Color.Black
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					Else
																						Dim flag259 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle15.Text, False) = 0
																						If flag259 Then
																							Me.FYValue15.Text = keyValuePair2.Value("value")
																							Dim flag260 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																							If flag260 Then
																								Me.FYValue15.ForeColor = Color.Red
																							Else
																								Dim flag261 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																								If flag261 Then
																									Me.FYValue15.ForeColor = Color.Green
																								Else
																									Dim flag262 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																									If flag262 Then
																										Me.FYValue15.ForeColor = Color.Blue
																									Else
																										Dim flag263 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																										If flag263 Then
																											Me.FYValue15.ForeColor = Color.DarkOrange
																										Else
																											Dim flag264 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																											If flag264 Then
																												Me.FYValue15.ForeColor = Color.HotPink
																											Else
																												Dim flag265 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																												If flag265 Then
																													Me.FYValue15.ForeColor = Color.Coral
																												Else
																													Dim flag266 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																													If flag266 Then
																														Me.FYValue15.ForeColor = Color.DodgerBlue
																													Else
																														Me.FYValue15.ForeColor = Color.Black
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						Else
																							Dim flag267 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle16.Text, False) = 0
																							If flag267 Then
																								Me.FYValue16.Text = keyValuePair2.Value("value")
																								Dim flag268 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																								If flag268 Then
																									Me.FYValue16.ForeColor = Color.Red
																								Else
																									Dim flag269 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																									If flag269 Then
																										Me.FYValue16.ForeColor = Color.Green
																									Else
																										Dim flag270 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																										If flag270 Then
																											Me.FYValue16.ForeColor = Color.Blue
																										Else
																											Dim flag271 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																											If flag271 Then
																												Me.FYValue16.ForeColor = Color.DarkOrange
																											Else
																												Dim flag272 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																												If flag272 Then
																													Me.FYValue16.ForeColor = Color.HotPink
																												Else
																													Dim flag273 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																													If flag273 Then
																														Me.FYValue16.ForeColor = Color.Coral
																													Else
																														Dim flag274 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																														If flag274 Then
																															Me.FYValue16.ForeColor = Color.DodgerBlue
																														Else
																															Me.FYValue16.ForeColor = Color.Black
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							Else
																								Dim flag275 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle17.Text, False) = 0
																								If flag275 Then
																									Me.FYValue17.Text = keyValuePair2.Value("value")
																									Dim flag276 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																									If flag276 Then
																										Me.FYValue17.ForeColor = Color.Red
																									Else
																										Dim flag277 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																										If flag277 Then
																											Me.FYValue17.ForeColor = Color.Green
																										Else
																											Dim flag278 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																											If flag278 Then
																												Me.FYValue17.ForeColor = Color.Blue
																											Else
																												Dim flag279 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																												If flag279 Then
																													Me.FYValue17.ForeColor = Color.DarkOrange
																												Else
																													Dim flag280 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																													If flag280 Then
																														Me.FYValue17.ForeColor = Color.HotPink
																													Else
																														Dim flag281 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																														If flag281 Then
																															Me.FYValue17.ForeColor = Color.Coral
																														Else
																															Dim flag282 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																															If flag282 Then
																																Me.FYValue17.ForeColor = Color.DodgerBlue
																															Else
																																Me.FYValue17.ForeColor = Color.Black
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								Else
																									Dim flag283 As Boolean = Operators.CompareString(keyValuePair2.Value("title"), Me.FYTitle18.Text, False) = 0
																									If flag283 Then
																										Me.FYValue18.Text = keyValuePair2.Value("value")
																										Dim flag284 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "red", False) = 0
																										If flag284 Then
																											Me.FYValue18.ForeColor = Color.Red
																										Else
																											Dim flag285 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "green", False) = 0
																											If flag285 Then
																												Me.FYValue18.ForeColor = Color.Green
																											Else
																												Dim flag286 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "blue", False) = 0
																												If flag286 Then
																													Me.FYValue18.ForeColor = Color.Blue
																												Else
																													Dim flag287 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dark-orange", False) = 0
																													If flag287 Then
																														Me.FYValue18.ForeColor = Color.DarkOrange
																													Else
																														Dim flag288 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "hot-pink", False) = 0
																														If flag288 Then
																															Me.FYValue18.ForeColor = Color.HotPink
																														Else
																															Dim flag289 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "coral", False) = 0
																															If flag289 Then
																																Me.FYValue18.ForeColor = Color.Coral
																															Else
																																Dim flag290 As Boolean = Operators.CompareString(keyValuePair2.Value("color"), "dodger-blue", False) = 0
																																If flag290 Then
																																	Me.FYValue18.ForeColor = Color.DodgerBlue
																																Else
																																	Me.FYValue18.ForeColor = Color.Black
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							Next
						Finally
							Dim enumerator2 As Dictionary(Of String, Dictionary(Of String, String)).Enumerator
							CType(enumerator2, IDisposable).Dispose()
						End Try
					Catch ex4 As Exception
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600E8FF RID: 59647 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Form_Shown(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x040059A6 RID: 22950
		Private autoUpdateTimer As Timer

		' Token: 0x040059A7 RID: 22951
		Private Config As IFirebaseConfig

		' Token: 0x040059A8 RID: 22952
		Private Client As IFirebaseClient

		' Token: 0x040059A9 RID: 22953
		Private todayData As Dictionary(Of String, Dictionary(Of String, String))

		' Token: 0x040059AA RID: 22954
		Private fyData As Dictionary(Of String, Dictionary(Of String, String))
	End Class
End Namespace
