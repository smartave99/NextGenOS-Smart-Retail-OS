Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004CB RID: 1227
	<DesignerGenerated()>
	Public Partial Class frmHoldrecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F908 RID: 63752 RVA: 0x0006D407 File Offset: 0x0006B607
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.FrmHoldrecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmHoldrecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005F60 RID: 24416
		' (get) Token: 0x0600F90B RID: 63755 RVA: 0x0006D439 File Offset: 0x0006B639
		' (set) Token: 0x0600F90C RID: 63756 RVA: 0x0006D443 File Offset: 0x0006B643
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005F61 RID: 24417
		' (get) Token: 0x0600F90D RID: 63757 RVA: 0x0006D44C File Offset: 0x0006B64C
		' (set) Token: 0x0600F90E RID: 63758 RVA: 0x0006D456 File Offset: 0x0006B656
		Friend Overridable Property Label1 As Label

		' Token: 0x17005F62 RID: 24418
		' (get) Token: 0x0600F90F RID: 63759 RVA: 0x0006D45F File Offset: 0x0006B65F
		' (set) Token: 0x0600F910 RID: 63760 RVA: 0x0006D469 File Offset: 0x0006B669
		Friend Overridable Property Label2 As Label

		' Token: 0x17005F63 RID: 24419
		' (get) Token: 0x0600F911 RID: 63761 RVA: 0x0006D472 File Offset: 0x0006B672
		' (set) Token: 0x0600F912 RID: 63762 RVA: 0x0006D47C File Offset: 0x0006B67C
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005F64 RID: 24420
		' (get) Token: 0x0600F913 RID: 63763 RVA: 0x0006D485 File Offset: 0x0006B685
		' (set) Token: 0x0600F914 RID: 63764 RVA: 0x0006D48F File Offset: 0x0006B68F
		Friend Overridable Property Label3 As Label

		' Token: 0x17005F65 RID: 24421
		' (get) Token: 0x0600F915 RID: 63765 RVA: 0x0006D498 File Offset: 0x0006B698
		' (set) Token: 0x0600F916 RID: 63766 RVA: 0x0006D4A2 File Offset: 0x0006B6A2
		Friend Overridable Property txtHold As TextBox

		' Token: 0x17005F66 RID: 24422
		' (get) Token: 0x0600F917 RID: 63767 RVA: 0x0006D4AB File Offset: 0x0006B6AB
		' (set) Token: 0x0600F918 RID: 63768 RVA: 0x00953EB0 File Offset: 0x009520B0
		Private _btnunhold As Button
		Friend Overridable Property btnunhold As Button
			<CompilerGenerated()>
			Get
				Return Me._btnunhold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnunhold_Click
				Dim button As Button = Me._btnunhold
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnunhold = value
				button = Me._btnunhold
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005F67 RID: 24423
		' (get) Token: 0x0600F919 RID: 63769 RVA: 0x0006D4B5 File Offset: 0x0006B6B5
		' (set) Token: 0x0600F91A RID: 63770 RVA: 0x00953EF4 File Offset: 0x009520F4
		Private _btnhold As Button
		Friend Overridable Property btnhold As Button
			<CompilerGenerated()>
			Get
				Return Me._btnhold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnhold_Click
				Dim button As Button = Me._btnhold
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnhold = value
				button = Me._btnhold
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005F68 RID: 24424
		' (get) Token: 0x0600F91B RID: 63771 RVA: 0x0006D4BF File Offset: 0x0006B6BF
		' (set) Token: 0x0600F91C RID: 63772 RVA: 0x0006D4C9 File Offset: 0x0006B6C9
		Friend Overridable Property lblUser As Label

		' Token: 0x17005F69 RID: 24425
		' (get) Token: 0x0600F91D RID: 63773 RVA: 0x0006D4D2 File Offset: 0x0006B6D2
		' (set) Token: 0x0600F91E RID: 63774 RVA: 0x00953F38 File Offset: 0x00952138
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005F6A RID: 24426
		' (get) Token: 0x0600F91F RID: 63775 RVA: 0x0006D4DC File Offset: 0x0006B6DC
		' (set) Token: 0x0600F920 RID: 63776 RVA: 0x00953F7C File Offset: 0x0095217C
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

		' Token: 0x17005F6B RID: 24427
		' (get) Token: 0x0600F921 RID: 63777 RVA: 0x0006D4E6 File Offset: 0x0006B6E6
		' (set) Token: 0x0600F922 RID: 63778 RVA: 0x00953FC0 File Offset: 0x009521C0
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseDoubleClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005F6C RID: 24428
		' (get) Token: 0x0600F923 RID: 63779 RVA: 0x0006D4F0 File Offset: 0x0006B6F0
		' (set) Token: 0x0600F924 RID: 63780 RVA: 0x0095403C File Offset: 0x0095223C
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
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

		' Token: 0x17005F6D RID: 24429
		' (get) Token: 0x0600F925 RID: 63781 RVA: 0x0006D4FA File Offset: 0x0006B6FA
		' (set) Token: 0x0600F926 RID: 63782 RVA: 0x0006D504 File Offset: 0x0006B704
		Friend Overridable Property Label4 As Label

		' Token: 0x17005F6E RID: 24430
		' (get) Token: 0x0600F927 RID: 63783 RVA: 0x0006D50D File Offset: 0x0006B70D
		' (set) Token: 0x0600F928 RID: 63784 RVA: 0x0006D517 File Offset: 0x0006B717
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005F6F RID: 24431
		' (get) Token: 0x0600F929 RID: 63785 RVA: 0x0006D520 File Offset: 0x0006B720
		' (set) Token: 0x0600F92A RID: 63786 RVA: 0x0006D52A File Offset: 0x0006B72A
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005F70 RID: 24432
		' (get) Token: 0x0600F92B RID: 63787 RVA: 0x0006D533 File Offset: 0x0006B733
		' (set) Token: 0x0600F92C RID: 63788 RVA: 0x0006D53D File Offset: 0x0006B73D
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005F71 RID: 24433
		' (get) Token: 0x0600F92D RID: 63789 RVA: 0x0006D546 File Offset: 0x0006B746
		' (set) Token: 0x0600F92E RID: 63790 RVA: 0x0006D550 File Offset: 0x0006B750
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17005F72 RID: 24434
		' (get) Token: 0x0600F92F RID: 63791 RVA: 0x0006D559 File Offset: 0x0006B759
		' (set) Token: 0x0600F930 RID: 63792 RVA: 0x0006D563 File Offset: 0x0006B763
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005F73 RID: 24435
		' (get) Token: 0x0600F931 RID: 63793 RVA: 0x0006D56C File Offset: 0x0006B76C
		' (set) Token: 0x0600F932 RID: 63794 RVA: 0x0006D576 File Offset: 0x0006B776
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005F74 RID: 24436
		' (get) Token: 0x0600F933 RID: 63795 RVA: 0x0006D57F File Offset: 0x0006B77F
		' (set) Token: 0x0600F934 RID: 63796 RVA: 0x0006D589 File Offset: 0x0006B789
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005F75 RID: 24437
		' (get) Token: 0x0600F935 RID: 63797 RVA: 0x0006D592 File Offset: 0x0006B792
		' (set) Token: 0x0600F936 RID: 63798 RVA: 0x0006D59C File Offset: 0x0006B79C
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17005F76 RID: 24438
		' (get) Token: 0x0600F937 RID: 63799 RVA: 0x0006D5A5 File Offset: 0x0006B7A5
		' (set) Token: 0x0600F938 RID: 63800 RVA: 0x0006D5AF File Offset: 0x0006B7AF
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17005F77 RID: 24439
		' (get) Token: 0x0600F939 RID: 63801 RVA: 0x0006D5B8 File Offset: 0x0006B7B8
		' (set) Token: 0x0600F93A RID: 63802 RVA: 0x0006D5C2 File Offset: 0x0006B7C2
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17005F78 RID: 24440
		' (get) Token: 0x0600F93B RID: 63803 RVA: 0x0006D5CB File Offset: 0x0006B7CB
		' (set) Token: 0x0600F93C RID: 63804 RVA: 0x0006D5D5 File Offset: 0x0006B7D5
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17005F79 RID: 24441
		' (get) Token: 0x0600F93D RID: 63805 RVA: 0x0006D5DE File Offset: 0x0006B7DE
		' (set) Token: 0x0600F93E RID: 63806 RVA: 0x0006D5E8 File Offset: 0x0006B7E8
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17005F7A RID: 24442
		' (get) Token: 0x0600F93F RID: 63807 RVA: 0x0006D5F1 File Offset: 0x0006B7F1
		' (set) Token: 0x0600F940 RID: 63808 RVA: 0x0006D5FB File Offset: 0x0006B7FB
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17005F7B RID: 24443
		' (get) Token: 0x0600F941 RID: 63809 RVA: 0x0006D604 File Offset: 0x0006B804
		' (set) Token: 0x0600F942 RID: 63810 RVA: 0x0006D60E File Offset: 0x0006B80E
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17005F7C RID: 24444
		' (get) Token: 0x0600F943 RID: 63811 RVA: 0x0006D617 File Offset: 0x0006B817
		' (set) Token: 0x0600F944 RID: 63812 RVA: 0x0006D621 File Offset: 0x0006B821
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17005F7D RID: 24445
		' (get) Token: 0x0600F945 RID: 63813 RVA: 0x0006D62A File Offset: 0x0006B82A
		' (set) Token: 0x0600F946 RID: 63814 RVA: 0x0006D634 File Offset: 0x0006B834
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17005F7E RID: 24446
		' (get) Token: 0x0600F947 RID: 63815 RVA: 0x0006D63D File Offset: 0x0006B83D
		' (set) Token: 0x0600F948 RID: 63816 RVA: 0x0006D647 File Offset: 0x0006B847
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17005F7F RID: 24447
		' (get) Token: 0x0600F949 RID: 63817 RVA: 0x0006D650 File Offset: 0x0006B850
		' (set) Token: 0x0600F94A RID: 63818 RVA: 0x0006D65A File Offset: 0x0006B85A
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17005F80 RID: 24448
		' (get) Token: 0x0600F94B RID: 63819 RVA: 0x0006D663 File Offset: 0x0006B863
		' (set) Token: 0x0600F94C RID: 63820 RVA: 0x0006D66D File Offset: 0x0006B86D
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17005F81 RID: 24449
		' (get) Token: 0x0600F94D RID: 63821 RVA: 0x0006D676 File Offset: 0x0006B876
		' (set) Token: 0x0600F94E RID: 63822 RVA: 0x0006D680 File Offset: 0x0006B880
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17005F82 RID: 24450
		' (get) Token: 0x0600F94F RID: 63823 RVA: 0x0006D689 File Offset: 0x0006B889
		' (set) Token: 0x0600F950 RID: 63824 RVA: 0x0006D693 File Offset: 0x0006B893
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17005F83 RID: 24451
		' (get) Token: 0x0600F951 RID: 63825 RVA: 0x0006D69C File Offset: 0x0006B89C
		' (set) Token: 0x0600F952 RID: 63826 RVA: 0x0006D6A6 File Offset: 0x0006B8A6
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17005F84 RID: 24452
		' (get) Token: 0x0600F953 RID: 63827 RVA: 0x0006D6AF File Offset: 0x0006B8AF
		' (set) Token: 0x0600F954 RID: 63828 RVA: 0x0006D6B9 File Offset: 0x0006B8B9
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17005F85 RID: 24453
		' (get) Token: 0x0600F955 RID: 63829 RVA: 0x0006D6C2 File Offset: 0x0006B8C2
		' (set) Token: 0x0600F956 RID: 63830 RVA: 0x0006D6CC File Offset: 0x0006B8CC
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17005F86 RID: 24454
		' (get) Token: 0x0600F957 RID: 63831 RVA: 0x0006D6D5 File Offset: 0x0006B8D5
		' (set) Token: 0x0600F958 RID: 63832 RVA: 0x0006D6DF File Offset: 0x0006B8DF
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17005F87 RID: 24455
		' (get) Token: 0x0600F959 RID: 63833 RVA: 0x0006D6E8 File Offset: 0x0006B8E8
		' (set) Token: 0x0600F95A RID: 63834 RVA: 0x0006D6F2 File Offset: 0x0006B8F2
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17005F88 RID: 24456
		' (get) Token: 0x0600F95B RID: 63835 RVA: 0x0006D6FB File Offset: 0x0006B8FB
		' (set) Token: 0x0600F95C RID: 63836 RVA: 0x0006D705 File Offset: 0x0006B905
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17005F89 RID: 24457
		' (get) Token: 0x0600F95D RID: 63837 RVA: 0x0006D70E File Offset: 0x0006B90E
		' (set) Token: 0x0600F95E RID: 63838 RVA: 0x0006D718 File Offset: 0x0006B918
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17005F8A RID: 24458
		' (get) Token: 0x0600F95F RID: 63839 RVA: 0x0006D721 File Offset: 0x0006B921
		' (set) Token: 0x0600F960 RID: 63840 RVA: 0x0006D72B File Offset: 0x0006B92B
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17005F8B RID: 24459
		' (get) Token: 0x0600F961 RID: 63841 RVA: 0x0006D734 File Offset: 0x0006B934
		' (set) Token: 0x0600F962 RID: 63842 RVA: 0x0006D73E File Offset: 0x0006B93E
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17005F8C RID: 24460
		' (get) Token: 0x0600F963 RID: 63843 RVA: 0x0006D747 File Offset: 0x0006B947
		' (set) Token: 0x0600F964 RID: 63844 RVA: 0x0006D751 File Offset: 0x0006B951
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17005F8D RID: 24461
		' (get) Token: 0x0600F965 RID: 63845 RVA: 0x0006D75A File Offset: 0x0006B95A
		' (set) Token: 0x0600F966 RID: 63846 RVA: 0x0006D764 File Offset: 0x0006B964
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17005F8E RID: 24462
		' (get) Token: 0x0600F967 RID: 63847 RVA: 0x0006D76D File Offset: 0x0006B96D
		' (set) Token: 0x0600F968 RID: 63848 RVA: 0x0006D777 File Offset: 0x0006B977
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17005F8F RID: 24463
		' (get) Token: 0x0600F969 RID: 63849 RVA: 0x0006D780 File Offset: 0x0006B980
		' (set) Token: 0x0600F96A RID: 63850 RVA: 0x0006D78A File Offset: 0x0006B98A
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17005F90 RID: 24464
		' (get) Token: 0x0600F96B RID: 63851 RVA: 0x0006D793 File Offset: 0x0006B993
		' (set) Token: 0x0600F96C RID: 63852 RVA: 0x0006D79D File Offset: 0x0006B99D
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17005F91 RID: 24465
		' (get) Token: 0x0600F96D RID: 63853 RVA: 0x0006D7A6 File Offset: 0x0006B9A6
		' (set) Token: 0x0600F96E RID: 63854 RVA: 0x0006D7B0 File Offset: 0x0006B9B0
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17005F92 RID: 24466
		' (get) Token: 0x0600F96F RID: 63855 RVA: 0x0006D7B9 File Offset: 0x0006B9B9
		' (set) Token: 0x0600F970 RID: 63856 RVA: 0x0006D7C3 File Offset: 0x0006B9C3
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x17005F93 RID: 24467
		' (get) Token: 0x0600F971 RID: 63857 RVA: 0x0006D7CC File Offset: 0x0006B9CC
		' (set) Token: 0x0600F972 RID: 63858 RVA: 0x0006D7D6 File Offset: 0x0006B9D6
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x17005F94 RID: 24468
		' (get) Token: 0x0600F973 RID: 63859 RVA: 0x0006D7DF File Offset: 0x0006B9DF
		' (set) Token: 0x0600F974 RID: 63860 RVA: 0x0006D7E9 File Offset: 0x0006B9E9
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x17005F95 RID: 24469
		' (get) Token: 0x0600F975 RID: 63861 RVA: 0x0006D7F2 File Offset: 0x0006B9F2
		' (set) Token: 0x0600F976 RID: 63862 RVA: 0x0006D7FC File Offset: 0x0006B9FC
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x0600F977 RID: 63863 RVA: 0x00954080 File Offset: 0x00952280
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select HID, RTRIM(Hold_ID), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceHold.Remarks),RTRIM(Narration),RTRIM(Eway),RTRIM(TillID),RTRIM(Operator),RTRIM(BillSundry),RTRIM(OfferAmt),RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(CType),Tender,Refund,BillCash,CouponAmount,GiftAmt from InvoiceHold LEFT Join Customer ON InvoiceHold.Customer_ID = Customer.ID Left Join Salesman ON InvoiceHold.SalesmanID=Salesman.SM_ID WHERE TillID=@T1 order by InvoiceDate"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@T1", Dns.GetHostName().TrimEnd(New Char(-1) {}).ToString())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F978 RID: 63864 RVA: 0x00954400 File Offset: 0x00952600
		Private Sub FrmHoldrecord_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.fillHoldNo()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600F979 RID: 63865 RVA: 0x00954488 File Offset: 0x00952688
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					MyBase.Close()
					MyProject.Forms.frmPOS.FillCustomers()
					MyProject.Forms.frmPOS.txtHold.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOS.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOS.txtTaxType.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOS.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOS.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOS.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOS.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					MyProject.Forms.frmPOS.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					MyProject.Forms.frmPOS.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOS.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOS.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOS.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOS.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOS.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOS.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOS.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOS.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOS.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOS.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOS.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOS.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOS.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOS.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOS.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOS.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOS.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOS.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOS.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOS.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOS.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOS.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOS.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOS.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOS.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag2 Then
						MyProject.Forms.frmPOS.cb1.Checked = True
					Else
						MyProject.Forms.frmPOS.cb1.Checked = False
					End If
					MyProject.Forms.frmPOS.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOS.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOS.Button5.Enabled = True
					MyProject.Forms.frmPOS.Button6.Enabled = True
					MyProject.Forms.frmPOS.txtOffer.Text = "0.00"
					MyProject.Forms.frmPOS.auto()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceholdproduct.Barcode),Invoiceholdproduct.Qty, Invoiceholdproduct.SalesRate,Invoiceholdproduct.DiscountPer, Invoiceholdproduct.Discount, Invoiceholdproduct.CGSTPer, Invoiceholdproduct.CGSTAmt, Invoiceholdproduct.SGSTPer, Invoiceholdproduct.SGSTAmt, Invoiceholdproduct.IGSTPer,Invoiceholdproduct.IGSTAmt, Invoiceholdproduct.CESSPer,Invoiceholdproduct.CESSAmt,Invoiceholdproduct.TotalAmount,Invoiceholdproduct.PurchaseRate,Invoiceholdproduct.Margin,Invoiceholdproduct.Descr,Invoiceholdproduct.Qty,RTRIM(Invoiceholdproduct.IM1),RTRIM(Invoiceholdproduct.IM2),(Invoiceholdproduct.MRP),(Invoiceholdproduct.TaxableAmt),(Invoiceholdproduct.AltQty),(Invoiceholdproduct.AltUnit),(Invoiceholdproduct.STaxType),(Invoiceholdproduct.TotalMRP),(Invoiceholdproduct.PromoQty),RTRIM(Invoiceholdproduct.MainUnit),RTRIM(Invoiceholdproduct.Batch),RTRIM(Invoiceholdproduct.Mfg),RTRIM(Invoiceholdproduct.Exp),RTRIM(Invoiceholdproduct.Size),RTRIM(Invoiceholdproduct.Colour) from Invoicehold,Invoiceholdproduct,Product where Invoicehold.Hold_ID=Invoiceholdproduct.Hold_ID and Product.PID=Invoiceholdproduct.ProductID and Invoicehold.Hold_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", MyProject.Forms.frmPOS.txtHold.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOS.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOS.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
					MyProject.Forms.frmPOS.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOS.Calc()
					MyProject.Forms.frmPOS.Compute()
					MyProject.Forms.frmPOS.alldiscountcalc()
					MyProject.Forms.frmPOS.Bankcondn()
					MyProject.Forms.frmPOS.totitemnqty()
					MyProject.Forms.frmPOS.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOS.btnListReset1.PerformClick()
					MyProject.Forms.frmPOS.SalesmanCommn()
					MyProject.Forms.frmPOS.Calculate143()
					MyProject.Forms.frmPOS.tcsconn()
					MyProject.Forms.frmPOS.tcsconn1()
					MyProject.Forms.frmPOS.CTypeStatusforHold()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F97A RID: 63866 RVA: 0x00954FD0 File Offset: 0x009531D0
		Public Sub RetrieveData1()
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					MyBase.Close()
					MyProject.Forms.frmPOSTouch.txtHold.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSTouch.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtTaxType.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSTouch.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOSTouch.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOSTouch.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag2 Then
						MyProject.Forms.frmPOSTouch.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSTouch.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSTouch.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSTouch.Button5.Enabled = True
					MyProject.Forms.frmPOSTouch.Button6.Enabled = True
					MyProject.Forms.frmPOSTouch.txtOffer.Text = "0.00"
					MyProject.Forms.frmPOSTouch.auto()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceholdproduct.Barcode),Invoiceholdproduct.Qty, Invoiceholdproduct.SalesRate,Invoiceholdproduct.DiscountPer, Invoiceholdproduct.Discount, Invoiceholdproduct.CGSTPer, Invoiceholdproduct.CGSTAmt, Invoiceholdproduct.SGSTPer, Invoiceholdproduct.SGSTAmt, Invoiceholdproduct.IGSTPer,Invoiceholdproduct.IGSTAmt, Invoiceholdproduct.CESSPer,Invoiceholdproduct.CESSAmt,Invoiceholdproduct.TotalAmount,Invoiceholdproduct.PurchaseRate,Invoiceholdproduct.Margin,Invoiceholdproduct.Descr,Invoiceholdproduct.Qty,RTRIM(Invoiceholdproduct.IM1),RTRIM(Invoiceholdproduct.IM2),(Invoiceholdproduct.MRP),(Invoiceholdproduct.TaxableAmt),(Invoiceholdproduct.AltQty),(Invoiceholdproduct.AltUnit),(Invoiceholdproduct.STaxType),(Invoiceholdproduct.TotalMRP),(Invoiceholdproduct.PromoQty),RTRIM(Invoiceholdproduct.MainUnit),RTRIM(Invoiceholdproduct.Batch),RTRIM(Invoiceholdproduct.Mfg),RTRIM(Invoiceholdproduct.Exp),RTRIM(Invoiceholdproduct.Size),RTRIM(Invoiceholdproduct.Colour),Invoiceholdproduct.SalesManID,Invoiceholdproduct.SalesMan,Invoiceholdproduct.SalesManPur,Invoiceholdproduct.SalesManComm,Invoiceholdproduct.StockID from Invoicehold,Invoiceholdproduct,Product where Invoicehold.Hold_ID=Invoiceholdproduct.Hold_ID and Product.PID=Invoiceholdproduct.ProductID and Invoicehold.Hold_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", MyProject.Forms.frmPOSTouch.txtHold.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim flag3 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(38).ToString(), "", False) <> 0
						Dim num As Decimal
						If flag3 Then
							num = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(38).ToString())
						Else
							num = Conversions.ToDecimal("0.00")
						End If
						Dim flag4 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(39).ToString(), "", False) <> 0
						Dim num2 As Decimal
						If flag4 Then
							num2 = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(39).ToString())
						Else
							num2 = 0D
						End If
						MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), num, num2, MyProject.Forms.frmPOSTouch.GetProductImage(CInt(Convert.ToInt16(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0))))), ModCommonClasses.rdr(40) })
					End While
					MyProject.Forms.frmPOSTouch.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSTouch.Calc()
					MyProject.Forms.frmPOSTouch.Compute()
					MyProject.Forms.frmPOSTouch.alldiscountcalc()
					MyProject.Forms.frmPOSTouch.Bankcondn()
					MyProject.Forms.frmPOSTouch.totitemnqty()
					MyProject.Forms.frmPOSTouch.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSTouch.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSTouch.SalesmanCommn()
					MyProject.Forms.frmPOSTouch.Calculate143()
					MyProject.Forms.frmPOSTouch.tcsconn()
					MyProject.Forms.frmPOSTouch.tcsconn1()
					MyProject.Forms.frmPOSTouch.CTypeStatusforHold()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F97B RID: 63867 RVA: 0x00955C1C File Offset: 0x00953E1C
		Public Sub RetrieveData1New()
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					MyBase.Close()
					MyProject.Forms.frmPOSNewTuch.txtHold.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTaxType.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag2 Then
						MyProject.Forms.frmPOSNewTuch.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSNewTuch.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSNewTuch.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.Button5.Enabled = True
					MyProject.Forms.frmPOSNewTuch.Button6.Enabled = True
					MyProject.Forms.frmPOSNewTuch.txtOffer.Text = "0.00"
					MyProject.Forms.frmPOSNewTuch.auto()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceholdproduct.Barcode),Invoiceholdproduct.Qty, Invoiceholdproduct.SalesRate,Invoiceholdproduct.DiscountPer, Invoiceholdproduct.Discount, Invoiceholdproduct.CGSTPer, Invoiceholdproduct.CGSTAmt, Invoiceholdproduct.SGSTPer, Invoiceholdproduct.SGSTAmt, Invoiceholdproduct.IGSTPer,Invoiceholdproduct.IGSTAmt, Invoiceholdproduct.CESSPer,Invoiceholdproduct.CESSAmt,Invoiceholdproduct.TotalAmount,Invoiceholdproduct.PurchaseRate,Invoiceholdproduct.Margin,Invoiceholdproduct.Descr,Invoiceholdproduct.Qty,RTRIM(Invoiceholdproduct.IM1),RTRIM(Invoiceholdproduct.IM2),(Invoiceholdproduct.MRP),(Invoiceholdproduct.TaxableAmt),(Invoiceholdproduct.AltQty),(Invoiceholdproduct.AltUnit),(Invoiceholdproduct.STaxType),(Invoiceholdproduct.TotalMRP),(Invoiceholdproduct.PromoQty),RTRIM(Invoiceholdproduct.MainUnit),RTRIM(Invoiceholdproduct.Batch),RTRIM(Invoiceholdproduct.Mfg),RTRIM(Invoiceholdproduct.Exp),RTRIM(Invoiceholdproduct.Size),RTRIM(Invoiceholdproduct.Colour),Invoiceholdproduct.SalesManID,Invoiceholdproduct.SalesMan,Invoiceholdproduct.SalesManPur,Invoiceholdproduct.SalesManComm ,Invoiceholdproduct.StockID  from Invoicehold,Invoiceholdproduct,Product where Invoicehold.Hold_ID=Invoiceholdproduct.Hold_ID and Product.PID=Invoiceholdproduct.ProductID and Invoicehold.Hold_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", MyProject.Forms.frmPOSNewTuch.txtHold.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					MyProject.Forms.frmPOSNewTuch.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSNewTuch.Calc()
					MyProject.Forms.frmPOSNewTuch.Compute()
					MyProject.Forms.frmPOSNewTuch.alldiscountcalc()
					MyProject.Forms.frmPOSNewTuch.Bankcondn()
					MyProject.Forms.frmPOSNewTuch.totitemnqty()
					MyProject.Forms.frmPOSNewTuch.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSNewTuch.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSNewTuch.SalesmanCommn()
					MyProject.Forms.frmPOSNewTuch.Calculate143()
					MyProject.Forms.frmPOSNewTuch.tcsconn()
					MyProject.Forms.frmPOSNewTuch.tcsconn1()
					MyProject.Forms.frmPOSNewTuch.CTypeStatusforHold()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F97C RID: 63868 RVA: 0x009567B4 File Offset: 0x009549B4
		Private Sub btnunhold_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag Then
				Try
					Dim flag2 As Boolean = MessageBox.Show("Do you really want to delete all hold records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "delete from InvoiceHold where Hold_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtHold.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
						Dim flag3 As Boolean = num > 0
						If flag3 Then
						End If
						Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag4 Then
							ModCommonClasses.con.Close()
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "delete from InvoiceHoldProduct where Hold_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtHold.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						num = ModCommonClasses.cmd.ExecuteNonQuery()
						Dim flag5 As Boolean = num > 0
						If flag5 Then
						End If
						Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag6 Then
							ModCommonClasses.con.Close()
						End If
						Dim text3 As String = "deleted hold bill (Products) having Hold No. '" + Me.txtHold.Text + "'"
						ModFunc.LogFunc(Me.lblUser.Text, text3)
						MessageBox.Show("Successfully Deleted", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				MessageBox.Show("No Records Found", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600F97D RID: 63869 RVA: 0x009569C8 File Offset: 0x00954BC8
		Public Sub fillHoldNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Hold_ID) FROM InvoiceHold WHERE InvoiceHold.TillID='" + Dns.GetHostName() + "'", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600F97E RID: 63870 RVA: 0x00956B08 File Offset: 0x00954D08
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select HID, RTRIM(Hold_ID), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceHold.Remarks),RTRIM(Narration),RTRIM(Eway),RTRIM(TillID),RTRIM(Operator),RTRIM(BillSundry),RTRIM(OfferAmt),RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(CType),Tender,Refund,BillCash,CouponAmount,GiftAmt from InvoiceHold LEFT Join Customer ON InvoiceHold.Customer_ID = Customer.ID Left Join Salesman ON InvoiceHold.SalesmanID=Salesman.SM_ID where Hold_ID='" + Me.ComboBox1.Text + "' order by InvoiceDate"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F97F RID: 63871 RVA: 0x0006D805 File Offset: 0x0006BA05
		Private Sub Reset()
			Me.txtHold.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.GetData()
			Me.fillHoldNo()
		End Sub

		' Token: 0x0600F980 RID: 63872 RVA: 0x0006D834 File Offset: 0x0006BA34
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600F981 RID: 63873 RVA: 0x00956E74 File Offset: 0x00955074
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtHold.Text = dataGridViewRow.Cells(1).Value.ToString()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F982 RID: 63874 RVA: 0x00956EF4 File Offset: 0x009550F4
		Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label4.Text, "POS", False) = 0
			If flag Then
				Me.RetrieveData()
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label4.Text, "POSTouch", False) = 0
			If flag2 Then
				Me.RetrieveData1()
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.Label4.Text, "POSTouchNew", False) = 0
			If flag3 Then
				Me.RetrieveData1New()
			End If
		End Sub

		' Token: 0x0600F983 RID: 63875 RVA: 0x00956F74 File Offset: 0x00955174
		Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600F984 RID: 63876 RVA: 0x0095705C File Offset: 0x0095525C
		Private Sub btnhold_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag Then
				Try
					Dim flag2 As Boolean = MessageBox.Show("Do you really want to delete all hold records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "DELETE FROM InvoiceHold"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.cmd.ExecuteNonQuery()
						text = "DELETE FROM InvoiceHoldProduct"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.cmd.ExecuteNonQuery()
						MyBase.Close()
						Dim text2 As String = "deleted all hold records"
						ModFunc.LogFunc(Me.lblUser.Text, text2)
						MessageBox.Show("Successfully all Hold Records Deleted", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				MessageBox.Show("No Records Found", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600F985 RID: 63877 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmHoldrecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F986 RID: 63878 RVA: 0x00957188 File Offset: 0x00955388
		Public Sub GetData1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select HID, RTRIM(Hold_ID), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceHold.Remarks),RTRIM(Narration),RTRIM(Eway),RTRIM(TillID),RTRIM(Operator),RTRIM(BillSundry),RTRIM(OfferAmt),RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(CType),Tender,Refund,BillCash,CouponAmount,GiftAmt from InvoiceHold LEFT Join Customer ON InvoiceHold.Customer_ID = Customer.ID Left Join Salesman ON InvoiceHold.SalesmanID=Salesman.SM_ID order by InvoiceDate"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@T1", Dns.GetHostName().TrimEnd(New Char(-1) {}).ToString())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F987 RID: 63879 RVA: 0x00957508 File Offset: 0x00955708
		Public Sub fillHoldNo1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Hold_ID) FROM InvoiceHold", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600F988 RID: 63880 RVA: 0x0006D83E File Offset: 0x0006BA3E
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.GetData1()
			Me.fillHoldNo1()
		End Sub
	End Class
End Namespace
