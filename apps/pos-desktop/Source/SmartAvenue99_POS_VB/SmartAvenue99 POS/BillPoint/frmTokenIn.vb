Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MySql.Data.MySqlClient

Namespace BillPoint
	' Token: 0x02000603 RID: 1539
	<DesignerGenerated()>
	Public Partial Class frmTokenIn
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012C08 RID: 76808 RVA: 0x000801A5 File Offset: 0x0007E3A5
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTokenIn_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007450 RID: 29776
		' (get) Token: 0x06012C0B RID: 76811 RVA: 0x000801C5 File Offset: 0x0007E3C5
		' (set) Token: 0x06012C0C RID: 76812 RVA: 0x000801CF File Offset: 0x0007E3CF
		Friend Overridable Property cmbBranchFrom As ComboBox

		' Token: 0x17007451 RID: 29777
		' (get) Token: 0x06012C0D RID: 76813 RVA: 0x000801D8 File Offset: 0x0007E3D8
		' (set) Token: 0x06012C0E RID: 76814 RVA: 0x000801E2 File Offset: 0x0007E3E2
		Friend Overridable Property ColumnHeader24 As ColumnHeader

		' Token: 0x17007452 RID: 29778
		' (get) Token: 0x06012C0F RID: 76815 RVA: 0x000801EB File Offset: 0x0007E3EB
		' (set) Token: 0x06012C10 RID: 76816 RVA: 0x000801F5 File Offset: 0x0007E3F5
		Friend Overridable Property ColumnHeader25 As ColumnHeader

		' Token: 0x17007453 RID: 29779
		' (get) Token: 0x06012C11 RID: 76817 RVA: 0x000801FE File Offset: 0x0007E3FE
		' (set) Token: 0x06012C12 RID: 76818 RVA: 0x00080208 File Offset: 0x0007E408
		Friend Overridable Property ColumnHeader26 As ColumnHeader

		' Token: 0x17007454 RID: 29780
		' (get) Token: 0x06012C13 RID: 76819 RVA: 0x00080211 File Offset: 0x0007E411
		' (set) Token: 0x06012C14 RID: 76820 RVA: 0x0008021B File Offset: 0x0007E41B
		Friend Overridable Property ColumnHeader27 As ColumnHeader

		' Token: 0x17007455 RID: 29781
		' (get) Token: 0x06012C15 RID: 76821 RVA: 0x00080224 File Offset: 0x0007E424
		' (set) Token: 0x06012C16 RID: 76822 RVA: 0x0008022E File Offset: 0x0007E42E
		Friend Overridable Property ColumnHeader28 As ColumnHeader

		' Token: 0x17007456 RID: 29782
		' (get) Token: 0x06012C17 RID: 76823 RVA: 0x00080237 File Offset: 0x0007E437
		' (set) Token: 0x06012C18 RID: 76824 RVA: 0x00080241 File Offset: 0x0007E441
		Friend Overridable Property ColumnHeader29 As ColumnHeader

		' Token: 0x17007457 RID: 29783
		' (get) Token: 0x06012C19 RID: 76825 RVA: 0x0008024A File Offset: 0x0007E44A
		' (set) Token: 0x06012C1A RID: 76826 RVA: 0x00080254 File Offset: 0x0007E454
		Friend Overridable Property ColumnHeader30 As ColumnHeader

		' Token: 0x17007458 RID: 29784
		' (get) Token: 0x06012C1B RID: 76827 RVA: 0x0008025D File Offset: 0x0007E45D
		' (set) Token: 0x06012C1C RID: 76828 RVA: 0x00080267 File Offset: 0x0007E467
		Friend Overridable Property ColumnHeader32 As ColumnHeader

		' Token: 0x17007459 RID: 29785
		' (get) Token: 0x06012C1D RID: 76829 RVA: 0x00080270 File Offset: 0x0007E470
		' (set) Token: 0x06012C1E RID: 76830 RVA: 0x0008027A File Offset: 0x0007E47A
		Friend Overridable Property ColumnHeader33 As ColumnHeader

		' Token: 0x1700745A RID: 29786
		' (get) Token: 0x06012C1F RID: 76831 RVA: 0x00080283 File Offset: 0x0007E483
		' (set) Token: 0x06012C20 RID: 76832 RVA: 0x0008028D File Offset: 0x0007E48D
		Friend Overridable Property ColumnHeader34 As ColumnHeader

		' Token: 0x1700745B RID: 29787
		' (get) Token: 0x06012C21 RID: 76833 RVA: 0x00080296 File Offset: 0x0007E496
		' (set) Token: 0x06012C22 RID: 76834 RVA: 0x000802A0 File Offset: 0x0007E4A0
		Friend Overridable Property ColumnHeader35 As ColumnHeader

		' Token: 0x1700745C RID: 29788
		' (get) Token: 0x06012C23 RID: 76835 RVA: 0x000802A9 File Offset: 0x0007E4A9
		' (set) Token: 0x06012C24 RID: 76836 RVA: 0x000802B3 File Offset: 0x0007E4B3
		Friend Overridable Property ColumnHeader36 As ColumnHeader

		' Token: 0x1700745D RID: 29789
		' (get) Token: 0x06012C25 RID: 76837 RVA: 0x000802BC File Offset: 0x0007E4BC
		' (set) Token: 0x06012C26 RID: 76838 RVA: 0x000802C6 File Offset: 0x0007E4C6
		Friend Overridable Property ColumnHeader37 As ColumnHeader

		' Token: 0x1700745E RID: 29790
		' (get) Token: 0x06012C27 RID: 76839 RVA: 0x000802CF File Offset: 0x0007E4CF
		' (set) Token: 0x06012C28 RID: 76840 RVA: 0x000802D9 File Offset: 0x0007E4D9
		Friend Overridable Property ColumnHeader38 As ColumnHeader

		' Token: 0x1700745F RID: 29791
		' (get) Token: 0x06012C29 RID: 76841 RVA: 0x000802E2 File Offset: 0x0007E4E2
		' (set) Token: 0x06012C2A RID: 76842 RVA: 0x00AC4438 File Offset: 0x00AC2638
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

		' Token: 0x17007460 RID: 29792
		' (get) Token: 0x06012C2B RID: 76843 RVA: 0x000802EC File Offset: 0x0007E4EC
		' (set) Token: 0x06012C2C RID: 76844 RVA: 0x00AC447C File Offset: 0x00AC267C
		Private _btnDToken As GelButton
		Friend Overridable Property btnDToken As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDToken
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDToken_Click
				Dim gelButton As GelButton = Me._btnDToken
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDToken = value
				gelButton = Me._btnDToken
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007461 RID: 29793
		' (get) Token: 0x06012C2D RID: 76845 RVA: 0x000802F6 File Offset: 0x0007E4F6
		' (set) Token: 0x06012C2E RID: 76846 RVA: 0x00080300 File Offset: 0x0007E500
		Friend Overridable Property Label4 As Label

		' Token: 0x17007462 RID: 29794
		' (get) Token: 0x06012C2F RID: 76847 RVA: 0x00080309 File Offset: 0x0007E509
		' (set) Token: 0x06012C30 RID: 76848 RVA: 0x00080313 File Offset: 0x0007E513
		Friend Overridable Property txtRemark As TextBox

		' Token: 0x17007463 RID: 29795
		' (get) Token: 0x06012C31 RID: 76849 RVA: 0x0008031C File Offset: 0x0007E51C
		' (set) Token: 0x06012C32 RID: 76850 RVA: 0x00080326 File Offset: 0x0007E526
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17007464 RID: 29796
		' (get) Token: 0x06012C33 RID: 76851 RVA: 0x0008032F File Offset: 0x0007E52F
		' (set) Token: 0x06012C34 RID: 76852 RVA: 0x00080339 File Offset: 0x0007E539
		Friend Overridable Property Label3 As Label

		' Token: 0x17007465 RID: 29797
		' (get) Token: 0x06012C35 RID: 76853 RVA: 0x00080342 File Offset: 0x0007E542
		' (set) Token: 0x06012C36 RID: 76854 RVA: 0x0008034C File Offset: 0x0007E54C
		Friend Overridable Property ColumnHeader76 As ColumnHeader

		' Token: 0x17007466 RID: 29798
		' (get) Token: 0x06012C37 RID: 76855 RVA: 0x00080355 File Offset: 0x0007E555
		' (set) Token: 0x06012C38 RID: 76856 RVA: 0x00AC44C0 File Offset: 0x00AC26C0
		Private _ListView2 As ListView
		Friend Overridable Property ListView2 As ListView
			<CompilerGenerated()>
			Get
				Return Me._ListView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.ListView2_MouseClick
				Dim listView As ListView = Me._ListView2
				If listView IsNot Nothing Then
					RemoveHandler listView.MouseClick, mouseEventHandler
				End If
				Me._ListView2 = value
				listView = Me._ListView2
				If listView IsNot Nothing Then
					AddHandler listView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007467 RID: 29799
		' (get) Token: 0x06012C39 RID: 76857 RVA: 0x0008035F File Offset: 0x0007E55F
		' (set) Token: 0x06012C3A RID: 76858 RVA: 0x00080369 File Offset: 0x0007E569
		Friend Overridable Property ColumnHeader39 As ColumnHeader

		' Token: 0x17007468 RID: 29800
		' (get) Token: 0x06012C3B RID: 76859 RVA: 0x00080372 File Offset: 0x0007E572
		' (set) Token: 0x06012C3C RID: 76860 RVA: 0x0008037C File Offset: 0x0007E57C
		Friend Overridable Property txtBranchCode As TextBox

		' Token: 0x17007469 RID: 29801
		' (get) Token: 0x06012C3D RID: 76861 RVA: 0x00080385 File Offset: 0x0007E585
		' (set) Token: 0x06012C3E RID: 76862 RVA: 0x0008038F File Offset: 0x0007E58F
		Friend Overridable Property txtDB As TextBox

		' Token: 0x1700746A RID: 29802
		' (get) Token: 0x06012C3F RID: 76863 RVA: 0x00080398 File Offset: 0x0007E598
		' (set) Token: 0x06012C40 RID: 76864 RVA: 0x000803A2 File Offset: 0x0007E5A2
		Friend Overridable Property ColumnHeader23 As ColumnHeader

		' Token: 0x1700746B RID: 29803
		' (get) Token: 0x06012C41 RID: 76865 RVA: 0x000803AB File Offset: 0x0007E5AB
		' (set) Token: 0x06012C42 RID: 76866 RVA: 0x000803B5 File Offset: 0x0007E5B5
		Friend Overridable Property cmbBranchAdmin As ComboBox

		' Token: 0x1700746C RID: 29804
		' (get) Token: 0x06012C43 RID: 76867 RVA: 0x000803BE File Offset: 0x0007E5BE
		' (set) Token: 0x06012C44 RID: 76868 RVA: 0x000803C8 File Offset: 0x0007E5C8
		Friend Overridable Property ColumnHeader22 As ColumnHeader

		' Token: 0x1700746D RID: 29805
		' (get) Token: 0x06012C45 RID: 76869 RVA: 0x000803D1 File Offset: 0x0007E5D1
		' (set) Token: 0x06012C46 RID: 76870 RVA: 0x000803DB File Offset: 0x0007E5DB
		Friend Overridable Property listView1 As ListView

		' Token: 0x1700746E RID: 29806
		' (get) Token: 0x06012C47 RID: 76871 RVA: 0x000803E4 File Offset: 0x0007E5E4
		' (set) Token: 0x06012C48 RID: 76872 RVA: 0x000803EE File Offset: 0x0007E5EE
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x1700746F RID: 29807
		' (get) Token: 0x06012C49 RID: 76873 RVA: 0x000803F7 File Offset: 0x0007E5F7
		' (set) Token: 0x06012C4A RID: 76874 RVA: 0x00080401 File Offset: 0x0007E601
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17007470 RID: 29808
		' (get) Token: 0x06012C4B RID: 76875 RVA: 0x0008040A File Offset: 0x0007E60A
		' (set) Token: 0x06012C4C RID: 76876 RVA: 0x00080414 File Offset: 0x0007E614
		Friend Overridable Property ColumnHeader31 As ColumnHeader

		' Token: 0x17007471 RID: 29809
		' (get) Token: 0x06012C4D RID: 76877 RVA: 0x0008041D File Offset: 0x0007E61D
		' (set) Token: 0x06012C4E RID: 76878 RVA: 0x00080427 File Offset: 0x0007E627
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x17007472 RID: 29810
		' (get) Token: 0x06012C4F RID: 76879 RVA: 0x00080430 File Offset: 0x0007E630
		' (set) Token: 0x06012C50 RID: 76880 RVA: 0x0008043A File Offset: 0x0007E63A
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17007473 RID: 29811
		' (get) Token: 0x06012C51 RID: 76881 RVA: 0x00080443 File Offset: 0x0007E643
		' (set) Token: 0x06012C52 RID: 76882 RVA: 0x0008044D File Offset: 0x0007E64D
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17007474 RID: 29812
		' (get) Token: 0x06012C53 RID: 76883 RVA: 0x00080456 File Offset: 0x0007E656
		' (set) Token: 0x06012C54 RID: 76884 RVA: 0x00080460 File Offset: 0x0007E660
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17007475 RID: 29813
		' (get) Token: 0x06012C55 RID: 76885 RVA: 0x00080469 File Offset: 0x0007E669
		' (set) Token: 0x06012C56 RID: 76886 RVA: 0x00080473 File Offset: 0x0007E673
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17007476 RID: 29814
		' (get) Token: 0x06012C57 RID: 76887 RVA: 0x0008047C File Offset: 0x0007E67C
		' (set) Token: 0x06012C58 RID: 76888 RVA: 0x00080486 File Offset: 0x0007E686
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x17007477 RID: 29815
		' (get) Token: 0x06012C59 RID: 76889 RVA: 0x0008048F File Offset: 0x0007E68F
		' (set) Token: 0x06012C5A RID: 76890 RVA: 0x00080499 File Offset: 0x0007E699
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17007478 RID: 29816
		' (get) Token: 0x06012C5B RID: 76891 RVA: 0x000804A2 File Offset: 0x0007E6A2
		' (set) Token: 0x06012C5C RID: 76892 RVA: 0x000804AC File Offset: 0x0007E6AC
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17007479 RID: 29817
		' (get) Token: 0x06012C5D RID: 76893 RVA: 0x000804B5 File Offset: 0x0007E6B5
		' (set) Token: 0x06012C5E RID: 76894 RVA: 0x000804BF File Offset: 0x0007E6BF
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x1700747A RID: 29818
		' (get) Token: 0x06012C5F RID: 76895 RVA: 0x000804C8 File Offset: 0x0007E6C8
		' (set) Token: 0x06012C60 RID: 76896 RVA: 0x000804D2 File Offset: 0x0007E6D2
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x1700747B RID: 29819
		' (get) Token: 0x06012C61 RID: 76897 RVA: 0x000804DB File Offset: 0x0007E6DB
		' (set) Token: 0x06012C62 RID: 76898 RVA: 0x000804E5 File Offset: 0x0007E6E5
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x1700747C RID: 29820
		' (get) Token: 0x06012C63 RID: 76899 RVA: 0x000804EE File Offset: 0x0007E6EE
		' (set) Token: 0x06012C64 RID: 76900 RVA: 0x000804F8 File Offset: 0x0007E6F8
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x1700747D RID: 29821
		' (get) Token: 0x06012C65 RID: 76901 RVA: 0x00080501 File Offset: 0x0007E701
		' (set) Token: 0x06012C66 RID: 76902 RVA: 0x0008050B File Offset: 0x0007E70B
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x1700747E RID: 29822
		' (get) Token: 0x06012C67 RID: 76903 RVA: 0x00080514 File Offset: 0x0007E714
		' (set) Token: 0x06012C68 RID: 76904 RVA: 0x0008051E File Offset: 0x0007E71E
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x1700747F RID: 29823
		' (get) Token: 0x06012C69 RID: 76905 RVA: 0x00080527 File Offset: 0x0007E727
		' (set) Token: 0x06012C6A RID: 76906 RVA: 0x00080531 File Offset: 0x0007E731
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x17007480 RID: 29824
		' (get) Token: 0x06012C6B RID: 76907 RVA: 0x0008053A File Offset: 0x0007E73A
		' (set) Token: 0x06012C6C RID: 76908 RVA: 0x00080544 File Offset: 0x0007E744
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x17007481 RID: 29825
		' (get) Token: 0x06012C6D RID: 76909 RVA: 0x0008054D File Offset: 0x0007E74D
		' (set) Token: 0x06012C6E RID: 76910 RVA: 0x00080557 File Offset: 0x0007E757
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x17007482 RID: 29826
		' (get) Token: 0x06012C6F RID: 76911 RVA: 0x00080560 File Offset: 0x0007E760
		' (set) Token: 0x06012C70 RID: 76912 RVA: 0x0008056A File Offset: 0x0007E76A
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x17007483 RID: 29827
		' (get) Token: 0x06012C71 RID: 76913 RVA: 0x00080573 File Offset: 0x0007E773
		' (set) Token: 0x06012C72 RID: 76914 RVA: 0x0008057D File Offset: 0x0007E77D
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x17007484 RID: 29828
		' (get) Token: 0x06012C73 RID: 76915 RVA: 0x00080586 File Offset: 0x0007E786
		' (set) Token: 0x06012C74 RID: 76916 RVA: 0x00080590 File Offset: 0x0007E790
		Friend Overridable Property Label2 As Label

		' Token: 0x17007485 RID: 29829
		' (get) Token: 0x06012C75 RID: 76917 RVA: 0x00080599 File Offset: 0x0007E799
		' (set) Token: 0x06012C76 RID: 76918 RVA: 0x00AC4504 File Offset: 0x00AC2704
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

		' Token: 0x17007486 RID: 29830
		' (get) Token: 0x06012C77 RID: 76919 RVA: 0x000805A3 File Offset: 0x0007E7A3
		' (set) Token: 0x06012C78 RID: 76920 RVA: 0x000805AD File Offset: 0x0007E7AD
		Friend Overridable Property cmbBranchTo As ComboBox

		' Token: 0x17007487 RID: 29831
		' (get) Token: 0x06012C79 RID: 76921 RVA: 0x000805B6 File Offset: 0x0007E7B6
		' (set) Token: 0x06012C7A RID: 76922 RVA: 0x000805C0 File Offset: 0x0007E7C0
		Friend Overridable Property Label1 As Label

		' Token: 0x17007488 RID: 29832
		' (get) Token: 0x06012C7B RID: 76923 RVA: 0x000805C9 File Offset: 0x0007E7C9
		' (set) Token: 0x06012C7C RID: 76924 RVA: 0x000805D3 File Offset: 0x0007E7D3
		Friend Overridable Property Label21 As Label

		' Token: 0x17007489 RID: 29833
		' (get) Token: 0x06012C7D RID: 76925 RVA: 0x000805DC File Offset: 0x0007E7DC
		' (set) Token: 0x06012C7E RID: 76926 RVA: 0x000805E6 File Offset: 0x0007E7E6
		Friend Overridable Property ColumnHeader40 As ColumnHeader

		' Token: 0x1700748A RID: 29834
		' (get) Token: 0x06012C7F RID: 76927 RVA: 0x000805EF File Offset: 0x0007E7EF
		' (set) Token: 0x06012C80 RID: 76928 RVA: 0x000805F9 File Offset: 0x0007E7F9
		Friend Overridable Property ColumnHeader41 As ColumnHeader

		' Token: 0x1700748B RID: 29835
		' (get) Token: 0x06012C81 RID: 76929 RVA: 0x00080602 File Offset: 0x0007E802
		' (set) Token: 0x06012C82 RID: 76930 RVA: 0x0008060C File Offset: 0x0007E80C
		Friend Overridable Property ColumnHeader42 As ColumnHeader

		' Token: 0x1700748C RID: 29836
		' (get) Token: 0x06012C83 RID: 76931 RVA: 0x00080615 File Offset: 0x0007E815
		' (set) Token: 0x06012C84 RID: 76932 RVA: 0x0008061F File Offset: 0x0007E81F
		Friend Overridable Property ColumnHeader43 As ColumnHeader

		' Token: 0x1700748D RID: 29837
		' (get) Token: 0x06012C85 RID: 76933 RVA: 0x00080628 File Offset: 0x0007E828
		' (set) Token: 0x06012C86 RID: 76934 RVA: 0x00080632 File Offset: 0x0007E832
		Friend Overridable Property ColumnHeader44 As ColumnHeader

		' Token: 0x1700748E RID: 29838
		' (get) Token: 0x06012C87 RID: 76935 RVA: 0x0008063B File Offset: 0x0007E83B
		' (set) Token: 0x06012C88 RID: 76936 RVA: 0x00080645 File Offset: 0x0007E845
		Friend Overridable Property ColumnHeader45 As ColumnHeader

		' Token: 0x1700748F RID: 29839
		' (get) Token: 0x06012C89 RID: 76937 RVA: 0x0008064E File Offset: 0x0007E84E
		' (set) Token: 0x06012C8A RID: 76938 RVA: 0x00080658 File Offset: 0x0007E858
		Friend Overridable Property ColumnHeader46 As ColumnHeader

		' Token: 0x17007490 RID: 29840
		' (get) Token: 0x06012C8B RID: 76939 RVA: 0x00080661 File Offset: 0x0007E861
		' (set) Token: 0x06012C8C RID: 76940 RVA: 0x0008066B File Offset: 0x0007E86B
		Friend Overridable Property ColumnHeader47 As ColumnHeader

		' Token: 0x06012C8D RID: 76941 RVA: 0x00080674 File Offset: 0x0007E874
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.GetPending()
		End Sub

		' Token: 0x06012C8E RID: 76942 RVA: 0x00AC4548 File Offset: 0x00AC2748
		Private Function GetPending() As Object
			Try
				Dim text As String = ModCS.ReadCS1()
				Dim text2 As String = Me.TextBox1.Text
				Dim text3 As String = Me.cmbBranchFrom.Text
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text4 As String = "SELECT TocknNo, COUNT(*) as ProductCount FROM P_Transfer WHERE TocknNo LIKE @paramName AND PStatus = 'o' AND PBranchTo LIKE @paramName1 GROUP BY TocknNo"
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text4, mySqlConnection)
						mySqlCommand.Parameters.AddWithValue("@paramName", text2 + "%")
						mySqlCommand.Parameters.AddWithValue("@paramName1", text3 + "%")
						mySqlCommand.CommandTimeout = 0
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.ListView2.Items.Clear()
							While mySqlDataReader.Read()
								Dim listViewItem As ListViewItem = New ListViewItem()
								listViewItem.Text = mySqlDataReader(0).ToString().Trim()
								listViewItem.SubItems.Add(mySqlDataReader(1).ToString().Trim())
								Me.ListView2.Items.Add(listViewItem)
							End While
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06012C8F RID: 76943 RVA: 0x00AC471C File Offset: 0x00AC291C
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.GetPending()
			End If
		End Sub

		' Token: 0x06012C90 RID: 76944 RVA: 0x00AC4744 File Offset: 0x00AC2944
		Private Sub frmTokenIn_Load(sender As Object, e As EventArgs)
			Try
				Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
				Try
					For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
						Dim text As String = Conversions.ToString(managementObject("SerialNumber"))
						Me.txtBranchCode.Text = ModFunc.MD5Encrypt(Me.txtDB.Text.TrimEnd(New Char(-1) {}).ToString() + Strings.StrReverse(text))
					Next
				Finally
					Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator IsNot Nothing Then
						CType(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.GetPending()
				Me.SearchInBranch()
				Me.listView1.Items.Clear()
				Me.ListView2.Items.Clear()
				Me.TextBox1.Text = ""
			Catch ex As Exception
			End Try
			Me.Convert_Language()
		End Sub

		' Token: 0x06012C91 RID: 76945 RVA: 0x00AC4854 File Offset: 0x00AC2A54
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

		' Token: 0x06012C92 RID: 76946 RVA: 0x00AC49CC File Offset: 0x00AC2BCC
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

		' Token: 0x06012C93 RID: 76947 RVA: 0x00AC4A88 File Offset: 0x00AC2C88
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

		' Token: 0x06012C94 RID: 76948 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06012C95 RID: 76949 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06012C96 RID: 76950 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012C97 RID: 76951 RVA: 0x00AC4B54 File Offset: 0x00AC2D54
		Private Sub SearchInBranch()
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = "SELECT admincode, branchname FROM branch WHERE branchcode= '" + Me.txtBranchCode.Text + "'"
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.cmbBranchFrom.Items.Clear()
							Me.cmbBranchAdmin.Items.Clear()
							While mySqlDataReader.Read()
								Me.cmbBranchFrom.Items.Add(RuntimeHelpers.GetObjectValue(mySqlDataReader(1)))
								Me.cmbBranchAdmin.Items.Add(RuntimeHelpers.GetObjectValue(mySqlDataReader(0)))
							End While
						End Using
					End Using
				End Using
				Me.cmbBranchFrom.SelectedIndex = 0
				Me.cmbBranchAdmin.SelectedIndex = 0
				Me.SearchInBranchTo()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012C98 RID: 76952 RVA: 0x00AC4CF0 File Offset: 0x00AC2EF0
		Private Sub SearchInBranchTo()
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = String.Concat(New String() { "SELECT branchname FROM branch WHERE admincode like N'", Me.cmbBranchAdmin.Text, "%' AND branchname <> '", Me.cmbBranchFrom.Text, "'" })
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.cmbBranchTo.Items.Clear()
							While mySqlDataReader.Read()
								Me.cmbBranchTo.Items.Add(RuntimeHelpers.GetObjectValue(mySqlDataReader(0)))
							End While
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012C99 RID: 76953 RVA: 0x00AC4E30 File Offset: 0x00AC3030
		Private Sub ListViewClick(tmpitem As String)
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = "Select PID,ProductCode,Barcode,Productname,HSNCode,PartNo,Description,CostPrice,MRP,SellingPrice,ReorderPoint,Discount,CGST,SGST,CESS,PurchaseUnit,Salesunit,SalesAltUnit,Conv,MinStock,GDown,Rack,DefQty,PPrice,Temp_StockMRP,SPrice,WPrice,Batch,Mfgdate,Expdate,Colour,Size,IMEI1,IMEI2,Status,QrBarcode,T_Qty,TocknNo,Category,SubCategoryName,PAdmin,PBranchFrom,PBranchTo,Remarks,PostDate,branchcode FROM P_Transfer WHERE TocknNo Like N'" + tmpitem + "%' and PStatus = 'o'"
					Using mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
						Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
							Me.listView1.Items.Clear()
							While mySqlDataReader.Read()
								Dim listViewItem As ListViewItem = New ListViewItem()
								listViewItem.Text = mySqlDataReader(0).ToString().Trim()
								listViewItem.SubItems.Add(mySqlDataReader(1).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(2).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(3).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(4).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(5).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(6).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(7).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(8).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(9).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(10).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(11).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(12).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(13).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(14).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(15).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(16).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(17).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(18).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(19).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(20).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(21).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(22).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(23).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(24).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(25).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(26).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(27).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(28).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(29).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(30).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(31).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(32).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(33).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(34).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(35).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(36).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(37).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(38).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(39).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(40).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(41).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(42).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(43).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(44).ToString().Trim())
								listViewItem.SubItems.Add(mySqlDataReader(45).ToString().Trim())
								Me.listView1.Items.Add(listViewItem)
							End While
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012C9A RID: 76954 RVA: 0x00AC5524 File Offset: 0x00AC3724
		Private Sub ListView2_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim num As Integer = Me.ListView2.Items.IndexOf(Me.ListView2.SelectedItems(0))
				Dim listViewItem As ListViewItem = Me.ListView2.Items(num)
				Me.ListViewClick(listViewItem.Text)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012C9B RID: 76955 RVA: 0x00AC55AC File Offset: 0x00AC37AC
		Private Sub btnDToken_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.listView1.Items.Count > 0
				If flag Then
					Try
						For Each obj As Object In Me.listView1.Items
							Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
							Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							Try
								sqlConnection.Open()
								Dim text As String = "insert into p_transfer_in(PID,ProductCode,Barcode,Productname,HSNCode,PartNo,Description,CostPrice,MRP,SellingPrice,ReorderPoint," & vbCrLf & "                                            Discount,CGST,SGST,CESS,PurchaseUnit,Salesunit,SalesAltUnit,Conv,MinStock,GDown," & vbCrLf & "                                            Rack,DefQty,PPrice,Temp_StockMRP,SPrice,WPrice,Batch,Mfgdate,Expdate,Colour," & vbCrLf & "                                            Size,IMEI1,IMEI2,Status,T_Qty,TocknNo,PStatus,PAdmin,PBranchFrom,PBranchTo,Remarks,PostDate,branchcode,Category,SubCategoryName) " & vbCrLf & "                                            VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10," & vbCrLf & "                                                    @d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20," & vbCrLf & "                                                    @d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30," & vbCrLf & "                                                    @d31,@d32,@d33,@d34,@d35,@d36,@d37,@d38,@d39,@d40,@d41,@d42,@d43,@d44,@d45)"
								Dim sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
								Dim text2 As String = listViewItem.SubItems(2).Text
								Dim text3 As String = listViewItem.SubItems(37).Text
								sqlCommand.Parameters.AddWithValue("@d0", listViewItem.SubItems(0).Text)
								sqlCommand.Parameters.AddWithValue("@d1", listViewItem.SubItems(1).Text)
								sqlCommand.Parameters.AddWithValue("@d2", listViewItem.SubItems(2).Text)
								sqlCommand.Parameters.AddWithValue("@d3", listViewItem.SubItems(3).Text)
								sqlCommand.Parameters.AddWithValue("@d4", listViewItem.SubItems(4).Text)
								sqlCommand.Parameters.AddWithValue("@d5", listViewItem.SubItems(5).Text)
								sqlCommand.Parameters.AddWithValue("@d6", listViewItem.SubItems(6).Text)
								sqlCommand.Parameters.AddWithValue("@d7", listViewItem.SubItems(7).Text)
								sqlCommand.Parameters.AddWithValue("@d8", listViewItem.SubItems(8).Text)
								sqlCommand.Parameters.AddWithValue("@d9", listViewItem.SubItems(9).Text)
								sqlCommand.Parameters.AddWithValue("@d10", listViewItem.SubItems(10).Text)
								sqlCommand.Parameters.AddWithValue("@d11", listViewItem.SubItems(11).Text)
								sqlCommand.Parameters.AddWithValue("@d12", listViewItem.SubItems(12).Text)
								sqlCommand.Parameters.AddWithValue("@d13", listViewItem.SubItems(13).Text)
								sqlCommand.Parameters.AddWithValue("@d14", listViewItem.SubItems(14).Text)
								sqlCommand.Parameters.AddWithValue("@d15", listViewItem.SubItems(15).Text)
								sqlCommand.Parameters.AddWithValue("@d16", listViewItem.SubItems(16).Text)
								sqlCommand.Parameters.AddWithValue("@d17", listViewItem.SubItems(17).Text)
								sqlCommand.Parameters.AddWithValue("@d18", listViewItem.SubItems(18).Text)
								sqlCommand.Parameters.AddWithValue("@d19", listViewItem.SubItems(19).Text)
								sqlCommand.Parameters.AddWithValue("@d20", listViewItem.SubItems(20).Text)
								sqlCommand.Parameters.AddWithValue("@d21", listViewItem.SubItems(21).Text)
								sqlCommand.Parameters.AddWithValue("@d22", listViewItem.SubItems(22).Text)
								sqlCommand.Parameters.AddWithValue("@d23", listViewItem.SubItems(23).Text)
								sqlCommand.Parameters.AddWithValue("@d24", listViewItem.SubItems(24).Text)
								sqlCommand.Parameters.AddWithValue("@d25", listViewItem.SubItems(25).Text)
								sqlCommand.Parameters.AddWithValue("@d26", listViewItem.SubItems(26).Text)
								sqlCommand.Parameters.AddWithValue("@d27", listViewItem.SubItems(27).Text)
								sqlCommand.Parameters.AddWithValue("@d28", listViewItem.SubItems(28).Text)
								sqlCommand.Parameters.AddWithValue("@d29", listViewItem.SubItems(29).Text)
								sqlCommand.Parameters.AddWithValue("@d30", listViewItem.SubItems(30).Text)
								sqlCommand.Parameters.AddWithValue("@d31", listViewItem.SubItems(31).Text)
								sqlCommand.Parameters.AddWithValue("@d32", listViewItem.SubItems(32).Text)
								sqlCommand.Parameters.AddWithValue("@d33", listViewItem.SubItems(33).Text)
								sqlCommand.Parameters.AddWithValue("@d34", listViewItem.SubItems(34).Text)
								sqlCommand.Parameters.AddWithValue("@d35", listViewItem.SubItems(36).Text)
								sqlCommand.Parameters.AddWithValue("@d36", listViewItem.SubItems(37).Text)
								sqlCommand.Parameters.AddWithValue("@d37", "o")
								sqlCommand.Parameters.AddWithValue("@d38", listViewItem.SubItems(40).Text)
								sqlCommand.Parameters.AddWithValue("@d39", listViewItem.SubItems(41).Text)
								sqlCommand.Parameters.AddWithValue("@d40", listViewItem.SubItems(42).Text)
								sqlCommand.Parameters.AddWithValue("@d41", listViewItem.SubItems(43).Text)
								sqlCommand.Parameters.AddWithValue("@d42", listViewItem.SubItems(44).Text)
								sqlCommand.Parameters.AddWithValue("@d43", listViewItem.SubItems(45).Text)
								sqlCommand.Parameters.AddWithValue("@d44", listViewItem.SubItems(38).Text)
								sqlCommand.Parameters.AddWithValue("@d45", listViewItem.SubItems(39).Text)
								Dim num As Integer = sqlCommand.ExecuteNonQuery()
								sqlConnection.Close()
								Me.updatetoonline(text2.ToString(), "f", listViewItem.SubItems(40).Text, listViewItem.SubItems(41).Text, listViewItem.SubItems(42).Text, listViewItem.SubItems(43).Text, listViewItem.SubItems(44).Text, listViewItem.SubItems(45).Text, text3.ToString())
							Catch ex As Exception
								MessageBox.Show(ex.Message)
								Console.WriteLine("MySQL Error: " + ex.Message)
								Console.WriteLine("Stack Trace: " + ex.StackTrace)
							End Try
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Send Post")
					Me.GetPending()
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message)
			End Try
		End Sub

		' Token: 0x06012C9C RID: 76956 RVA: 0x00AC5E30 File Offset: 0x00AC4030
		Public Function updatetoonline(barcode As String, pstatus As String, branchadmin As String, branchfrom As String, branchto As String, remark As String, dt As String, branchcode As String, TocknNo As String) As Object
			Try
				Dim text As String = ModCS.ReadCS1()
				Using mySqlConnection As MySqlConnection = New MySqlConnection(text)
					mySqlConnection.Open()
					Dim text2 As String = String.Concat(New String() { "Update p_transfer set PStatus=@d1 where barcode= '", barcode, "' and TocknNo= '", TocknNo, "'" })
					Dim mySqlCommand As MySqlCommand = New MySqlCommand(text2, mySqlConnection)
					mySqlCommand.Parameters.AddWithValue("@d1", pstatus)
					Dim num As Integer = mySqlCommand.ExecuteNonQuery()
					mySqlCommand.ExecuteReader()
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function
	End Class
End Namespace
