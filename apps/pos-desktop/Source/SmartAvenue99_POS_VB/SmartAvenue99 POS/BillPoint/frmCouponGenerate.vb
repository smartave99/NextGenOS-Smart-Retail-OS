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
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020000D4 RID: 212
	<DesignerGenerated()>
	Public Partial Class frmCouponGenerate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060025E6 RID: 9702 RVA: 0x001807D8 File Offset: 0x0017E9D8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCouponGenerate_Load
			AddHandler MyBase.FormClosed, AddressOf Me.frmCouponGenerate_FormClosed
			AddHandler MyBase.KeyDown, AddressOf Me.frmCouponGenerate_KeyDown
			Me.sts = ""
			Me.sts2 = ""
			Me.otptext = ""
			Me.giftcode = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000EF5 RID: 3829
		' (get) Token: 0x060025E9 RID: 9705 RVA: 0x000194E6 File Offset: 0x000176E6
		' (set) Token: 0x060025EA RID: 9706 RVA: 0x000194F0 File Offset: 0x000176F0
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000EF6 RID: 3830
		' (get) Token: 0x060025EB RID: 9707 RVA: 0x000194F9 File Offset: 0x000176F9
		' (set) Token: 0x060025EC RID: 9708 RVA: 0x00019503 File Offset: 0x00017703
		Friend Overridable Property Label1 As Label

		' Token: 0x17000EF7 RID: 3831
		' (get) Token: 0x060025ED RID: 9709 RVA: 0x0001950C File Offset: 0x0001770C
		' (set) Token: 0x060025EE RID: 9710 RVA: 0x00019516 File Offset: 0x00017716
		Friend Overridable Property lblUser As Label

		' Token: 0x17000EF8 RID: 3832
		' (get) Token: 0x060025EF RID: 9711 RVA: 0x0001951F File Offset: 0x0001771F
		' (set) Token: 0x060025F0 RID: 9712 RVA: 0x00019529 File Offset: 0x00017729
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17000EF9 RID: 3833
		' (get) Token: 0x060025F1 RID: 9713 RVA: 0x00019532 File Offset: 0x00017732
		' (set) Token: 0x060025F2 RID: 9714 RVA: 0x0001953C File Offset: 0x0001773C
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17000EFA RID: 3834
		' (get) Token: 0x060025F3 RID: 9715 RVA: 0x00019545 File Offset: 0x00017745
		' (set) Token: 0x060025F4 RID: 9716 RVA: 0x0001954F File Offset: 0x0001774F
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17000EFB RID: 3835
		' (get) Token: 0x060025F5 RID: 9717 RVA: 0x00019558 File Offset: 0x00017758
		' (set) Token: 0x060025F6 RID: 9718 RVA: 0x00019562 File Offset: 0x00017762
		Friend Overridable Property Label12 As Label

		' Token: 0x17000EFC RID: 3836
		' (get) Token: 0x060025F7 RID: 9719 RVA: 0x0001956B File Offset: 0x0001776B
		' (set) Token: 0x060025F8 RID: 9720 RVA: 0x00183CD0 File Offset: 0x00181ED0
		Private _DateTimePicker2 As DateTimePicker
		Friend Overridable Property DateTimePicker2 As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._DateTimePicker2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DateTimePicker2_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._DateTimePicker2
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._DateTimePicker2 = value
				dateTimePicker = Me._DateTimePicker2
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EFD RID: 3837
		' (get) Token: 0x060025F9 RID: 9721 RVA: 0x00019575 File Offset: 0x00017775
		' (set) Token: 0x060025FA RID: 9722 RVA: 0x0001957F File Offset: 0x0001777F
		Friend Overridable Property Label9 As Label

		' Token: 0x17000EFE RID: 3838
		' (get) Token: 0x060025FB RID: 9723 RVA: 0x00019588 File Offset: 0x00017788
		' (set) Token: 0x060025FC RID: 9724 RVA: 0x00183D14 File Offset: 0x00181F14
		Private _DateTimePicker1 As DateTimePicker
		Friend Overridable Property DateTimePicker1 As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._DateTimePicker1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DateTimePicker1_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._DateTimePicker1
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._DateTimePicker1 = value
				dateTimePicker = Me._DateTimePicker1
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000EFF RID: 3839
		' (get) Token: 0x060025FD RID: 9725 RVA: 0x00019592 File Offset: 0x00017792
		' (set) Token: 0x060025FE RID: 9726 RVA: 0x0001959C File Offset: 0x0001779C
		Friend Overridable Property Label8 As Label

		' Token: 0x17000F00 RID: 3840
		' (get) Token: 0x060025FF RID: 9727 RVA: 0x000195A5 File Offset: 0x000177A5
		' (set) Token: 0x06002600 RID: 9728 RVA: 0x000195AF File Offset: 0x000177AF
		Friend Overridable Property Label7 As Label

		' Token: 0x17000F01 RID: 3841
		' (get) Token: 0x06002601 RID: 9729 RVA: 0x000195B8 File Offset: 0x000177B8
		' (set) Token: 0x06002602 RID: 9730 RVA: 0x00183D58 File Offset: 0x00181F58
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox2_KeyPress
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F02 RID: 3842
		' (get) Token: 0x06002603 RID: 9731 RVA: 0x000195C2 File Offset: 0x000177C2
		' (set) Token: 0x06002604 RID: 9732 RVA: 0x00183D9C File Offset: 0x00181F9C
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
				Dim dataGridViewCellMouseEventHandler As DataGridViewCellMouseEventHandler = AddressOf Me.dgw_RowHeaderMouseClick
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentDoubleClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.RowHeaderMouseClick, dataGridViewCellMouseEventHandler
					RemoveHandler dataGridView.CellContentDoubleClick, dataGridViewCellEventHandler2
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.RowHeaderMouseClick, dataGridViewCellMouseEventHandler
					AddHandler dataGridView.CellContentDoubleClick, dataGridViewCellEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17000F03 RID: 3843
		' (get) Token: 0x06002605 RID: 9733 RVA: 0x000195CC File Offset: 0x000177CC
		' (set) Token: 0x06002606 RID: 9734 RVA: 0x00183E3C File Offset: 0x0018203C
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

		' Token: 0x17000F04 RID: 3844
		' (get) Token: 0x06002607 RID: 9735 RVA: 0x000195D6 File Offset: 0x000177D6
		' (set) Token: 0x06002608 RID: 9736 RVA: 0x000195E0 File Offset: 0x000177E0
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000F05 RID: 3845
		' (get) Token: 0x06002609 RID: 9737 RVA: 0x000195E9 File Offset: 0x000177E9
		' (set) Token: 0x0600260A RID: 9738 RVA: 0x000195F3 File Offset: 0x000177F3
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17000F06 RID: 3846
		' (get) Token: 0x0600260B RID: 9739 RVA: 0x000195FC File Offset: 0x000177FC
		' (set) Token: 0x0600260C RID: 9740 RVA: 0x00019606 File Offset: 0x00017806
		Friend Overridable Property lblCouponCode As Label

		' Token: 0x17000F07 RID: 3847
		' (get) Token: 0x0600260D RID: 9741 RVA: 0x0001960F File Offset: 0x0001780F
		' (set) Token: 0x0600260E RID: 9742 RVA: 0x00019619 File Offset: 0x00017819
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17000F08 RID: 3848
		' (get) Token: 0x0600260F RID: 9743 RVA: 0x00019622 File Offset: 0x00017822
		' (set) Token: 0x06002610 RID: 9744 RVA: 0x0001962C File Offset: 0x0001782C
		Friend Overridable Property lblCName As Label

		' Token: 0x17000F09 RID: 3849
		' (get) Token: 0x06002611 RID: 9745 RVA: 0x00019635 File Offset: 0x00017835
		' (set) Token: 0x06002612 RID: 9746 RVA: 0x0001963F File Offset: 0x0001783F
		Friend Overridable Property lblCContact As Label

		' Token: 0x17000F0A RID: 3850
		' (get) Token: 0x06002613 RID: 9747 RVA: 0x00019648 File Offset: 0x00017848
		' (set) Token: 0x06002614 RID: 9748 RVA: 0x00183E80 File Offset: 0x00182080
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

		' Token: 0x17000F0B RID: 3851
		' (get) Token: 0x06002615 RID: 9749 RVA: 0x00019652 File Offset: 0x00017852
		' (set) Token: 0x06002616 RID: 9750 RVA: 0x00183EC4 File Offset: 0x001820C4
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F0C RID: 3852
		' (get) Token: 0x06002617 RID: 9751 RVA: 0x0001965C File Offset: 0x0001785C
		' (set) Token: 0x06002618 RID: 9752 RVA: 0x00183F08 File Offset: 0x00182108
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

		' Token: 0x17000F0D RID: 3853
		' (get) Token: 0x06002619 RID: 9753 RVA: 0x00019666 File Offset: 0x00017866
		' (set) Token: 0x0600261A RID: 9754 RVA: 0x00183F4C File Offset: 0x0018214C
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

		' Token: 0x17000F0E RID: 3854
		' (get) Token: 0x0600261B RID: 9755 RVA: 0x00019670 File Offset: 0x00017870
		' (set) Token: 0x0600261C RID: 9756 RVA: 0x0001967A File Offset: 0x0001787A
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x17000F0F RID: 3855
		' (get) Token: 0x0600261D RID: 9757 RVA: 0x00019683 File Offset: 0x00017883
		' (set) Token: 0x0600261E RID: 9758 RVA: 0x0001968D File Offset: 0x0001788D
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17000F10 RID: 3856
		' (get) Token: 0x0600261F RID: 9759 RVA: 0x00019696 File Offset: 0x00017896
		' (set) Token: 0x06002620 RID: 9760 RVA: 0x000196A0 File Offset: 0x000178A0
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000F11 RID: 3857
		' (get) Token: 0x06002621 RID: 9761 RVA: 0x000196A9 File Offset: 0x000178A9
		' (set) Token: 0x06002622 RID: 9762 RVA: 0x00183F90 File Offset: 0x00182190
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

		' Token: 0x17000F12 RID: 3858
		' (get) Token: 0x06002623 RID: 9763 RVA: 0x000196B3 File Offset: 0x000178B3
		' (set) Token: 0x06002624 RID: 9764 RVA: 0x000196BD File Offset: 0x000178BD
		Friend Overridable Property Label16 As Label

		' Token: 0x17000F13 RID: 3859
		' (get) Token: 0x06002625 RID: 9765 RVA: 0x000196C6 File Offset: 0x000178C6
		' (set) Token: 0x06002626 RID: 9766 RVA: 0x000196D0 File Offset: 0x000178D0
		Friend Overridable Property Label11 As Label

		' Token: 0x17000F14 RID: 3860
		' (get) Token: 0x06002627 RID: 9767 RVA: 0x000196D9 File Offset: 0x000178D9
		' (set) Token: 0x06002628 RID: 9768 RVA: 0x000196E3 File Offset: 0x000178E3
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17000F15 RID: 3861
		' (get) Token: 0x06002629 RID: 9769 RVA: 0x000196EC File Offset: 0x000178EC
		' (set) Token: 0x0600262A RID: 9770 RVA: 0x00183FD4 File Offset: 0x001821D4
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

		' Token: 0x17000F16 RID: 3862
		' (get) Token: 0x0600262B RID: 9771 RVA: 0x000196F6 File Offset: 0x000178F6
		' (set) Token: 0x0600262C RID: 9772 RVA: 0x00019700 File Offset: 0x00017900
		Friend Overridable Property Label18 As Label

		' Token: 0x17000F17 RID: 3863
		' (get) Token: 0x0600262D RID: 9773 RVA: 0x00019709 File Offset: 0x00017909
		' (set) Token: 0x0600262E RID: 9774 RVA: 0x00019713 File Offset: 0x00017913
		Friend Overridable Property Label17 As Label

		' Token: 0x17000F18 RID: 3864
		' (get) Token: 0x0600262F RID: 9775 RVA: 0x0001971C File Offset: 0x0001791C
		' (set) Token: 0x06002630 RID: 9776 RVA: 0x00019726 File Offset: 0x00017926
		Friend Overridable Property DateTimePicker4 As DateTimePicker

		' Token: 0x17000F19 RID: 3865
		' (get) Token: 0x06002631 RID: 9777 RVA: 0x0001972F File Offset: 0x0001792F
		' (set) Token: 0x06002632 RID: 9778 RVA: 0x00019739 File Offset: 0x00017939
		Friend Overridable Property DateTimePicker3 As DateTimePicker

		' Token: 0x17000F1A RID: 3866
		' (get) Token: 0x06002633 RID: 9779 RVA: 0x00019742 File Offset: 0x00017942
		' (set) Token: 0x06002634 RID: 9780 RVA: 0x0001974C File Offset: 0x0001794C
		Friend Overridable Property Label20 As Label

		' Token: 0x17000F1B RID: 3867
		' (get) Token: 0x06002635 RID: 9781 RVA: 0x00019755 File Offset: 0x00017955
		' (set) Token: 0x06002636 RID: 9782 RVA: 0x0001975F File Offset: 0x0001795F
		Friend Overridable Property Label19 As Label

		' Token: 0x17000F1C RID: 3868
		' (get) Token: 0x06002637 RID: 9783 RVA: 0x00019768 File Offset: 0x00017968
		' (set) Token: 0x06002638 RID: 9784 RVA: 0x00019772 File Offset: 0x00017972
		Friend Overridable Property ListView1 As ListView

		' Token: 0x17000F1D RID: 3869
		' (get) Token: 0x06002639 RID: 9785 RVA: 0x0001977B File Offset: 0x0001797B
		' (set) Token: 0x0600263A RID: 9786 RVA: 0x00019785 File Offset: 0x00017985
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17000F1E RID: 3870
		' (get) Token: 0x0600263B RID: 9787 RVA: 0x0001978E File Offset: 0x0001798E
		' (set) Token: 0x0600263C RID: 9788 RVA: 0x00019798 File Offset: 0x00017998
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17000F1F RID: 3871
		' (get) Token: 0x0600263D RID: 9789 RVA: 0x000197A1 File Offset: 0x000179A1
		' (set) Token: 0x0600263E RID: 9790 RVA: 0x000197AB File Offset: 0x000179AB
		Friend Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17000F20 RID: 3872
		' (get) Token: 0x0600263F RID: 9791 RVA: 0x000197B4 File Offset: 0x000179B4
		' (set) Token: 0x06002640 RID: 9792 RVA: 0x000197BE File Offset: 0x000179BE
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17000F21 RID: 3873
		' (get) Token: 0x06002641 RID: 9793 RVA: 0x000197C7 File Offset: 0x000179C7
		' (set) Token: 0x06002642 RID: 9794 RVA: 0x000197D1 File Offset: 0x000179D1
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x17000F22 RID: 3874
		' (get) Token: 0x06002643 RID: 9795 RVA: 0x000197DA File Offset: 0x000179DA
		' (set) Token: 0x06002644 RID: 9796 RVA: 0x000197E4 File Offset: 0x000179E4
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17000F23 RID: 3875
		' (get) Token: 0x06002645 RID: 9797 RVA: 0x000197ED File Offset: 0x000179ED
		' (set) Token: 0x06002646 RID: 9798 RVA: 0x000197F7 File Offset: 0x000179F7
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17000F24 RID: 3876
		' (get) Token: 0x06002647 RID: 9799 RVA: 0x00019800 File Offset: 0x00017A00
		' (set) Token: 0x06002648 RID: 9800 RVA: 0x0001980A File Offset: 0x00017A0A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000F25 RID: 3877
		' (get) Token: 0x06002649 RID: 9801 RVA: 0x00019813 File Offset: 0x00017A13
		' (set) Token: 0x0600264A RID: 9802 RVA: 0x00184018 File Offset: 0x00182218
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F26 RID: 3878
		' (get) Token: 0x0600264B RID: 9803 RVA: 0x0001981D File Offset: 0x00017A1D
		' (set) Token: 0x0600264C RID: 9804 RVA: 0x0018405C File Offset: 0x0018225C
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

		' Token: 0x17000F27 RID: 3879
		' (get) Token: 0x0600264D RID: 9805 RVA: 0x00019827 File Offset: 0x00017A27
		' (set) Token: 0x0600264E RID: 9806 RVA: 0x001840A0 File Offset: 0x001822A0
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

		' Token: 0x17000F28 RID: 3880
		' (get) Token: 0x0600264F RID: 9807 RVA: 0x00019831 File Offset: 0x00017A31
		' (set) Token: 0x06002650 RID: 9808 RVA: 0x001840E4 File Offset: 0x001822E4
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000F29 RID: 3881
		' (get) Token: 0x06002651 RID: 9809 RVA: 0x0001983B File Offset: 0x00017A3B
		' (set) Token: 0x06002652 RID: 9810 RVA: 0x00019845 File Offset: 0x00017A45
		Friend Overridable Property Label2 As Label

		' Token: 0x17000F2A RID: 3882
		' (get) Token: 0x06002653 RID: 9811 RVA: 0x0001984E File Offset: 0x00017A4E
		' (set) Token: 0x06002654 RID: 9812 RVA: 0x00184128 File Offset: 0x00182328
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

		' Token: 0x17000F2B RID: 3883
		' (get) Token: 0x06002655 RID: 9813 RVA: 0x00019858 File Offset: 0x00017A58
		' (set) Token: 0x06002656 RID: 9814 RVA: 0x0018416C File Offset: 0x0018236C
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

		' Token: 0x17000F2C RID: 3884
		' (get) Token: 0x06002657 RID: 9815 RVA: 0x00019862 File Offset: 0x00017A62
		' (set) Token: 0x06002658 RID: 9816 RVA: 0x001841B0 File Offset: 0x001823B0
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

		' Token: 0x17000F2D RID: 3885
		' (get) Token: 0x06002659 RID: 9817 RVA: 0x0001986C File Offset: 0x00017A6C
		' (set) Token: 0x0600265A RID: 9818 RVA: 0x00019876 File Offset: 0x00017A76
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000F2E RID: 3886
		' (get) Token: 0x0600265B RID: 9819 RVA: 0x0001987F File Offset: 0x00017A7F
		' (set) Token: 0x0600265C RID: 9820 RVA: 0x00019889 File Offset: 0x00017A89
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17000F2F RID: 3887
		' (get) Token: 0x0600265D RID: 9821 RVA: 0x00019892 File Offset: 0x00017A92
		' (set) Token: 0x0600265E RID: 9822 RVA: 0x0001989C File Offset: 0x00017A9C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000F30 RID: 3888
		' (get) Token: 0x0600265F RID: 9823 RVA: 0x000198A5 File Offset: 0x00017AA5
		' (set) Token: 0x06002660 RID: 9824 RVA: 0x000198AF File Offset: 0x00017AAF
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000F31 RID: 3889
		' (get) Token: 0x06002661 RID: 9825 RVA: 0x000198B8 File Offset: 0x00017AB8
		' (set) Token: 0x06002662 RID: 9826 RVA: 0x000198C2 File Offset: 0x00017AC2
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000F32 RID: 3890
		' (get) Token: 0x06002663 RID: 9827 RVA: 0x000198CB File Offset: 0x00017ACB
		' (set) Token: 0x06002664 RID: 9828 RVA: 0x000198D5 File Offset: 0x00017AD5
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000F33 RID: 3891
		' (get) Token: 0x06002665 RID: 9829 RVA: 0x000198DE File Offset: 0x00017ADE
		' (set) Token: 0x06002666 RID: 9830 RVA: 0x000198E8 File Offset: 0x00017AE8
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000F34 RID: 3892
		' (get) Token: 0x06002667 RID: 9831 RVA: 0x000198F1 File Offset: 0x00017AF1
		' (set) Token: 0x06002668 RID: 9832 RVA: 0x000198FB File Offset: 0x00017AFB
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000F35 RID: 3893
		' (get) Token: 0x06002669 RID: 9833 RVA: 0x00019904 File Offset: 0x00017B04
		' (set) Token: 0x0600266A RID: 9834 RVA: 0x0001990E File Offset: 0x00017B0E
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000F36 RID: 3894
		' (get) Token: 0x0600266B RID: 9835 RVA: 0x00019917 File Offset: 0x00017B17
		' (set) Token: 0x0600266C RID: 9836 RVA: 0x00019921 File Offset: 0x00017B21
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000F37 RID: 3895
		' (get) Token: 0x0600266D RID: 9837 RVA: 0x0001992A File Offset: 0x00017B2A
		' (set) Token: 0x0600266E RID: 9838 RVA: 0x00019934 File Offset: 0x00017B34
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000F38 RID: 3896
		' (get) Token: 0x0600266F RID: 9839 RVA: 0x0001993D File Offset: 0x00017B3D
		' (set) Token: 0x06002670 RID: 9840 RVA: 0x00019947 File Offset: 0x00017B47
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000F39 RID: 3897
		' (get) Token: 0x06002671 RID: 9841 RVA: 0x00019950 File Offset: 0x00017B50
		' (set) Token: 0x06002672 RID: 9842 RVA: 0x0001995A File Offset: 0x00017B5A
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17000F3A RID: 3898
		' (get) Token: 0x06002673 RID: 9843 RVA: 0x00019963 File Offset: 0x00017B63
		' (set) Token: 0x06002674 RID: 9844 RVA: 0x0001996D File Offset: 0x00017B6D
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000F3B RID: 3899
		' (get) Token: 0x06002675 RID: 9845 RVA: 0x00019976 File Offset: 0x00017B76
		' (set) Token: 0x06002676 RID: 9846 RVA: 0x00019980 File Offset: 0x00017B80
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000F3C RID: 3900
		' (get) Token: 0x06002677 RID: 9847 RVA: 0x00019989 File Offset: 0x00017B89
		' (set) Token: 0x06002678 RID: 9848 RVA: 0x00019993 File Offset: 0x00017B93
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000F3D RID: 3901
		' (get) Token: 0x06002679 RID: 9849 RVA: 0x0001999C File Offset: 0x00017B9C
		' (set) Token: 0x0600267A RID: 9850 RVA: 0x000199A6 File Offset: 0x00017BA6
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000F3E RID: 3902
		' (get) Token: 0x0600267B RID: 9851 RVA: 0x000199AF File Offset: 0x00017BAF
		' (set) Token: 0x0600267C RID: 9852 RVA: 0x000199B9 File Offset: 0x00017BB9
		Friend Overridable Property Column1 As DataGridViewCheckBoxColumn

		' Token: 0x17000F3F RID: 3903
		' (get) Token: 0x0600267D RID: 9853 RVA: 0x000199C2 File Offset: 0x00017BC2
		' (set) Token: 0x0600267E RID: 9854 RVA: 0x000199CC File Offset: 0x00017BCC
		Friend Overridable Property Column17 As DataGridViewImageColumn

		' Token: 0x17000F40 RID: 3904
		' (get) Token: 0x0600267F RID: 9855 RVA: 0x000199D5 File Offset: 0x00017BD5
		' (set) Token: 0x06002680 RID: 9856 RVA: 0x000199DF File Offset: 0x00017BDF
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17000F41 RID: 3905
		' (get) Token: 0x06002681 RID: 9857 RVA: 0x000199E8 File Offset: 0x00017BE8
		' (set) Token: 0x06002682 RID: 9858 RVA: 0x000199F2 File Offset: 0x00017BF2
		Friend Overridable Property QrImage As DataGridViewImageColumn

		' Token: 0x06002683 RID: 9859 RVA: 0x001841F4 File Offset: 0x001823F4
		Private Sub frmCouponGenerate_Load(sender As Object, e As EventArgs)
			Me.CheckBox2.Checked = False
			Me.CheckBox2.TabStop = False
			Me.CheckBox1.TabStop = False
			Me.GetCompanyState()
			Me.Getdata()
			Me.statusdisplay()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06002684 RID: 9860 RVA: 0x001842B4 File Offset: 0x001824B4
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

		' Token: 0x06002685 RID: 9861 RVA: 0x0018442C File Offset: 0x0018262C
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

		' Token: 0x06002686 RID: 9862 RVA: 0x001844E8 File Offset: 0x001826E8
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

		' Token: 0x06002687 RID: 9863 RVA: 0x000B726C File Offset: 0x000B546C
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

		' Token: 0x06002688 RID: 9864 RVA: 0x000B72F4 File Offset: 0x000B54F4
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

		' Token: 0x06002689 RID: 9865 RVA: 0x00184594 File Offset: 0x00182794
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

		' Token: 0x0600268A RID: 9866 RVA: 0x0018467C File Offset: 0x0018287C
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(State), RTRIM(companyName),RTRIM(FYFrom),RTRIM(FYTo),RTRIM(Bankholder),RTRIM(Bankacno),RTRIM(Bankname),RTRIM(Bankifsc),RTRIM(GSTIN),Logo,RTRIM(Address),RTRIM(ContactNo),RTRIM(EmailID) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtcompname = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.DTP1.Value = Conversions.ToDate(ModCommonClasses.rdr.GetValue(2))
					Me.DTP2.Value = Conversions.ToDate(ModCommonClasses.rdr.GetValue(3))
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

		' Token: 0x0600268B RID: 9867 RVA: 0x001847A0 File Offset: 0x001829A0
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

		' Token: 0x0600268C RID: 9868 RVA: 0x00184830 File Offset: 0x00182A30
		Private Sub DeleteRecord()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Coupondb where ID=@d1"
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

		' Token: 0x0600268D RID: 9869 RVA: 0x00184964 File Offset: 0x00182B64
		Public Sub Reset()
			Me.TextBox2.Text = "0.00"
			Me.TextBox1.Text = ""
			Me.DateTimePicker1.Value = DateAndTime.Now
			Me.DateTimePicker2.Value = DateAndTime.Now
			Me.CheckBox1.Checked = MyBase.Enabled
			Me.dgw.ClearSelection()
			Me.CheckBox2.Checked = False
			Me.lblCouponCode.Text = ""
			Me.lblCName.Text = ""
			Me.lblCContact.Text = ""
			For Each r As DataGridViewRow In Me.dgw.Rows
				r.Cells("Column18").Value = String.Empty
			Next
			Me.Getdata()
			Me.ComboBox1.SelectedIndex = -1
			Me.TextBox3.Text = ""
			Me.DateTimePicker3.Enabled = True
			Me.DateTimePicker4.Enabled = True
			Me.TextBox3.Enabled = True
			Me.ListView1.Items.Clear()
		End Sub

		' Token: 0x0600268E RID: 9870 RVA: 0x00184AB0 File Offset: 0x00182CB0
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate), CouponCodeQr from Coupondb order by CID", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), False, Nothing, "", ModCommonClasses.rdr(15) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600268F RID: 9871 RVA: 0x00184C98 File Offset: 0x00182E98
		Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox2.Checked
			If checked Then
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Cells(15).Value = True
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
							dataGridViewRow2.Cells(15).Value = False
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

		' Token: 0x06002690 RID: 9872 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbDiscountType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002691 RID: 9873 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002692 RID: 9874 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub DateTimePicker2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06002693 RID: 9875 RVA: 0x001326D8 File Offset: 0x001308D8
		Public Sub WAPPIMAGE()
			Dim flag As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\WhatsApp")
			If flag Then
				Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\WhatsApp\")
			End If
			Dim text As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp"
			For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(text2)
			Next
		End Sub

		' Token: 0x06002694 RID: 9876 RVA: 0x00184DA8 File Offset: 0x00182FA8
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Try
				Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
				saveFileDialog.Title = "Save Image"
				saveFileDialog.CheckPathExists = True
				saveFileDialog.DefaultExt = "png"
				saveFileDialog.Filter = "Image (*.png)|*.png|All files (*.*)|*.*"
				saveFileDialog.FilterIndex = 0
				saveFileDialog.RestoreDirectory = True
				Dim flag As Boolean = saveFileDialog.ShowDialog() = DialogResult.OK
				If flag Then
					Using bitmap As Bitmap = New Bitmap(Me.Panel4.Width, Me.Panel4.Height)
						Me.Panel4.DrawToBitmap(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
						bitmap.Save(saveFileDialog.FileName)
					End Using
					MessageBox.Show("Successfully Image Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub

		' Token: 0x06002695 RID: 9877 RVA: 0x00184EB4 File Offset: 0x001830B4
		Public Sub statusdisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT c1, c2 FROM WappApi"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.sts = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.sts = "91"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002696 RID: 9878 RVA: 0x00184FA8 File Offset: 0x001831A8
		Private Async Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim count As Integer = 0
					Try
						For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim row As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag3 As Boolean = Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(Operators.AndObject(row.Cells(15).Value IsNot Nothing, Operators.CompareObjectEqual(row.Cells(15).Value, True, False))))
							If flag3 Then
								count += 1
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim flag4 As Boolean = count <= 0
					If flag4 Then
						MessageBox.Show("Please select customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Me.Timer1.Enabled = True
							Dim path As String = ""
							Try
								For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
									Dim row2 As DataGridViewRow = CType(obj2, DataGridViewRow)
									Try
										Dim flag5 As Boolean = Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(row2.Cells(15).Value))
										If flag5 Then
											Dim data As Byte() = CType(row2.Cells(18).Value, Byte())
											Dim ms As MemoryStream = New MemoryStream(data)
											Me.PictureBox1.Image = Image.FromStream(ms)
											Me.lblCouponCode.Text = "Coupon Code : " + row2.Cells(12).Value.ToString() + ", Balance :  " + row2.Cells(8).Value.ToString()
											Me.lblCName.Text = "Name :  " + row2.Cells(3).Value.ToString() + vbCrLf & "Contact No. " + row2.Cells(5).Value.ToString()
											Me.lblCContact.Text = "Validity : " + row2.Cells(9).Value.ToString().Substring(0, 10) + " To " + row2.Cells(10).Value.ToString().Substring(0, 10)
											Me.WAPPIMAGE()
											Using bmp As Bitmap = New Bitmap(Me.Panel4.Width, Me.Panel4.Height)
												Me.Panel4.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
												bmp.Save(MyProject.Application.Info.DirectoryPath + "\WhatsApp\Report.png")
											End Using
											Dim phone As String = row2.Cells(5).Value.ToString()
											Dim message As String = String.Format("_Best wishes from : *{0}*_", Me.txtcompname)
											Dim attach As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp\Report.png"
											Dim dt As DataTable = New DataTable()
											dt = clsfun.ExecDataTable("Select c1,WApi,FtpUrl,FtpUser,FtpPassword,FileUrl from WappApi where c2='Enabled'")
											Dim client As WebClient = New WebClient()
											Dim countryCode As String = dt.Rows(0)("c1").ToString()
											client.Credentials = New NetworkCredential(dt.Rows(0)("FtpUser").ToString(), dt.Rows(0)("FtpPassword").ToString())
											Dim filename As String = attach.Split(New Char() { "/"c }).Last()
											Dim flag6 As Boolean = filename.Contains(".pdf")
											If flag6 Then
												Me.Name = "Report.pdf"
											Else
												Dim flag7 As Boolean = filename.Contains(".png")
												If flag7 Then
													Me.Name = "Report.png"
												Else
													Me.Name = "Report.jpg"
												End If
											End If
											Dim tmpDir As String = MyProject.Application.Info.DirectoryPath + "\PDF Reports\" + frmLogin.InstanceID
											Me.Timer1.Enabled = True
											Dim flag8 As Boolean = clswhatsApp.CreateFtpFolder(tmpDir, frmLogin.InstanceID, dt, Me.Name, path, attach, client, countryCode + phone, message, "")
											If flag8 Then
												row2.Cells(17).Value = "Success"
											End If
										End If
									Catch ex2 As Exception
										Dim ex As Exception = ex2
										MessageBox.Show(ex.Message)
									End Try
									Await Task.Delay(10000)
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
						Catch ex3 As Exception
							MessageBox.Show("Engine is not active")
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06002697 RID: 9879 RVA: 0x00184FF0 File Offset: 0x001831F0
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Panel6.BackgroundImage = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x06002698 RID: 9880 RVA: 0x000199FB File Offset: 0x00017BFB
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Panel6.BackgroundImage = Resources.GiftCard
		End Sub

		' Token: 0x06002699 RID: 9881 RVA: 0x00185090 File Offset: 0x00183290
		Private Sub frmCouponGenerate_FormClosed(sender As Object, e As FormClosedEventArgs)
			Try
				Dim text As String = MyProject.Application.Info.DirectoryPath + "\WhatsApp"
				For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
					File.Delete(text2)
				Next
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600269A RID: 9882 RVA: 0x0018510C File Offset: 0x0018330C
		Private Sub dgw_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.lblCouponCode.Text = "Coupon Code : " + dataGridViewRow.Cells(12).Value.ToString() + ", Balance :  " + dataGridViewRow.Cells(8).Value.ToString()
					Me.lblCName.Text = "Name :  " + dataGridViewRow.Cells(3).Value.ToString() + vbCrLf & "Contact No. " + dataGridViewRow.Cells(5).Value.ToString()
					Me.lblCContact.Text = "Validity : " + dataGridViewRow.Cells(9).Value.ToString().Substring(0, 10) + " To " + dataGridViewRow.Cells(10).Value.ToString().Substring(0, 10)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600269B RID: 9883 RVA: 0x00185264 File Offset: 0x00183464
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 6
			If flag Then
				Me.TextBox3.Enabled = False
				Me.DateTimePicker3.Enabled = True
				Me.DateTimePicker4.Enabled = True
			Else
				Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 7
				If flag2 Then
					Me.TextBox3.Enabled = False
					Me.DateTimePicker3.Enabled = True
					Me.DateTimePicker4.Enabled = True
				Else
					Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 8
					If flag3 Then
						Me.TextBox3.Enabled = False
						Me.DateTimePicker3.Enabled = True
						Me.DateTimePicker4.Enabled = True
					Else
						Me.TextBox3.Enabled = True
						Me.DateTimePicker3.Enabled = False
						Me.DateTimePicker4.Enabled = False
					End If
				End If
			End If
		End Sub

		' Token: 0x0600269C RID: 9884 RVA: 0x00185354 File Offset: 0x00183554
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please select category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.ComboBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 6
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where ValidFrom between @d1 and @d2 order by ValidFrom", ModCommonClasses.con)
						ModCommonClasses.cmd.CommandTimeout = 0
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker3.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker4.Value.[Date].AddDays(0.0)
					End If
					Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 7
					If flag3 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where ValidUpto between @d1 and @d2 order by ValidUpto", ModCommonClasses.con)
						ModCommonClasses.cmd.CommandTimeout = 0
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker3.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker4.Value.[Date].AddDays(0.0)
					End If
					Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 8
					If flag4 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where IssueDate between @d1 and @d2 order by IssueDate", ModCommonClasses.con)
						ModCommonClasses.cmd.CommandTimeout = 0
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker3.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker4.Value.[Date].AddDays(1.0)
					End If
					Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag5 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where CustomerID like N'" + Me.TextBox3.Text + "%' order by IssueDate", ModCommonClasses.con)
					End If
					Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 1
					If flag6 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where Name like N'" + Me.TextBox3.Text + "%' order by IssueDate", ModCommonClasses.con)
					End If
					Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 2
					If flag7 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where Contact like N'" + Me.TextBox3.Text + "%' order by IssueDate", ModCommonClasses.con)
					End If
					Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 3
					If flag8 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where OfferStatus like N'" + Me.TextBox3.Text + "%' order by IssueDate", ModCommonClasses.con)
					End If
					Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 4
					If flag9 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where CouponCode like N'" + Me.TextBox3.Text + "%' order by IssueDate", ModCommonClasses.con)
					End If
					Dim flag10 As Boolean = Me.ComboBox1.SelectedIndex = 5
					If flag10 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), (CID), RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(Contact), RTRIM(DiscType), (DiscPernAmt), (OfferAmt), (ValidFrom), (ValidUpto), RTRIM(OfferStatus), RTRIM(CouponCode), RTRIM(CouponStatus), (IssueDate) from Coupondb where CouponStatus like N'" + Me.TextBox3.Text + "%' order by IssueDate", ModCommonClasses.con)
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600269D RID: 9885 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCouponGenerate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600269E RID: 9886 RVA: 0x001858F0 File Offset: 0x00183AF0
		Private Sub Getdata_in_ListView()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.ContactNo FROM Customer where not Customer.Name='Cash' order by Customer.Name ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.Auto_Couopon_Generate()
					listViewItem.SubItems.Add(Me.otptext).ToString().Trim()
					listViewItem.SubItems.Add("NOT USED")
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.chkSelectAll.Checked = True
		End Sub

		' Token: 0x0600269F RID: 9887 RVA: 0x00185AEC File Offset: 0x00183CEC
		Private Sub Auto_Couopon_Generate()
			Dim text As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			Dim text2 As String = DateAndTime.Now.ToString("ss")
			Dim text3 As String = "1234567890"
			Dim text4 As String = text3
			text4 = text4 + Convert.ToString(text + text2) + text3
			Dim num As Integer = Integer.Parse(Conversions.ToString(6))
			Dim text5 As String = String.Empty
			Dim num2 As Integer = num - 1
			For i As Integer = 0 To num2
				Dim text6 As String = String.Empty
				Do
					Dim num3 As Integer = New Random().[Next](0, text4.Length)
					text6 = text4.ToCharArray()(num3).ToString()
				Loop While text5.IndexOf(text6) <> -1
				text5 += text6
			Next
			Me.otptext = text5
		End Sub

		' Token: 0x060026A0 RID: 9888 RVA: 0x00185BB4 File Offset: 0x00183DB4
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.ListView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.ListView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.ListView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.ListView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x060026A1 RID: 9889 RVA: 0x00185CA0 File Offset: 0x00183EA0
		Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.TextBox2.Text
					Dim selectionStart As Integer = Me.TextBox2.SelectionStart
					Dim selectionLength As Integer = Me.TextBox2.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x060026A2 RID: 9890 RVA: 0x00019A0F File Offset: 0x00017C0F
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Getdata_in_ListView()
		End Sub

		' Token: 0x060026A3 RID: 9891 RVA: 0x00185D98 File Offset: 0x00183F98
		Private Sub Delete_All_Record()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Coupondb"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				MessageBox.Show("Successfully Deleted All Record", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.Getdata()
				Me.Reset()
				Dim flag As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060026A4 RID: 9892 RVA: 0x00185E64 File Offset: 0x00184064
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.Delete_All_Record()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060026A5 RID: 9893 RVA: 0x00019A19 File Offset: 0x00017C19
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060026A6 RID: 9894 RVA: 0x00185ECC File Offset: 0x001840CC
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060026A7 RID: 9895 RVA: 0x00185F50 File Offset: 0x00184150
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
				Dim flag3 As Boolean = Me.ListView1.CheckedItems.Count = 0
				If flag3 Then
					MessageBox.Show("Please select the customer name", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag4 As Boolean = Conversion.Val(Me.TextBox2.Text) <= 0.0
					If flag4 Then
						MessageBox.Show("Please enter offer amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox2.Focus()
					Else
						Try
							For Each obj As Object In Me.ListView1.Items
								Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
								Dim checked As Boolean = listViewItem.Checked
								If checked Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "Select CouponCode from Coupondb where CouponCode=@d1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", listViewItem.SubItems(5).Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
									If flag5 Then
										MessageBox.Show("Coupon Code Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag6 Then
											ModCommonClasses.rdr.Close()
										End If
										Return
									End If
									ModCommonClasses.con.Close()
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "Insert into Coupondb(CID, CustomerID, Name, Address, Contact, DiscType, DiscPernAmt, OfferAmt, ValidFrom, ValidUpto, OfferStatus, CouponCode, CouponStatus , IssueDate,CouponCodeQr) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						Dim num As Integer = 0
						Dim num2 As Integer = Me.ListView1.CheckedItems.Count - 1
						Dim num3 As Integer = num
						While True
							Dim num4 As Integer = num3
							Dim num5 As Integer = num2
							Dim flag7 As Boolean = num4 > num5
							If flag7 Then
								Exit While
							End If
							ModCommonClasses.cmd.Parameters.Clear()
							Me.Generate_GiftQR(Me.ListView1.CheckedItems(num3).SubItems(5).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.ListView1.CheckedItems(num3).SubItems(0).Text))))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.ListView1.CheckedItems(num3).SubItems(1).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ListView1.CheckedItems(num3).SubItems(2).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.ListView1.CheckedItems(num3).SubItems(3).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ListView1.CheckedItems(num3).SubItems(4).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "Amt")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.TextBox2.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.TextBox2.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.DateTimePicker1.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.DateTimePicker2.Value.[Date])
							Dim checked2 As Boolean = Me.CheckBox1.Checked
							If checked2 Then
								Me.os = "Enabled"
							Else
								Dim flag8 As Boolean = Not Me.CheckBox1.Checked
								If flag8 Then
									Me.os = "Disabled"
								End If
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.os).ToString()
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.ListView1.CheckedItems(num3).SubItems(5).Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "NOT USED")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", DateAndTime.Now)
							Dim memoryStream As MemoryStream = New MemoryStream()
							Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim buffer As Byte() = memoryStream.GetBuffer()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d15", SqlDbType.Image)
							sqlParameter.Value = buffer
							ModCommonClasses.cmd.Parameters.Add(sqlParameter)
							ModCommonClasses.cmd.ExecuteNonQuery()
							num3 += 1
						End While
						ModCommonClasses.con.Close()
						Dim num6 As Integer = 0
						Dim num7 As Integer = Me.ListView1.CheckedItems.Count - 1
						Dim num8 As Integer = num6
						While True
							Dim num9 As Integer = num8
							Dim num10 As Integer = num7
							Dim flag9 As Boolean = num9 > num10
							If flag9 Then
								Exit While
							End If
							ModFunc.LogFunc(Me.lblUser.Text, "added the new offer '" + Me.ListView1.CheckedItems(num8).SubItems(1).Text + "'")
							num8 += 1
						End While
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
						Me.Reset()
					End If
				End If
			End If
		End Sub

		' Token: 0x060026A8 RID: 9896 RVA: 0x00019A35 File Offset: 0x00017C35
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.btnSave.Enabled = True
			Me.Reset()
		End Sub

		' Token: 0x060026A9 RID: 9897 RVA: 0x00186640 File Offset: 0x00184840
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.ContactNo FROM Customer where not Customer.Name='Cash' and Name like N'" + Me.TextBox1.Text + "%' order by Customer.Name ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.Auto_Couopon_Generate()
					listViewItem.SubItems.Add(Me.otptext).ToString().Trim()
					listViewItem.SubItems.Add("NOT USED")
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.chkSelectAll.Checked = True
		End Sub

		' Token: 0x060026AA RID: 9898 RVA: 0x00186854 File Offset: 0x00184A54
		Private Sub dgw_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = 11
			Dim flag2 As Boolean = flag
			If flag2 Then
				Try
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Update Coupondb Set OfferStatus=@d1 where ID=@d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(11).Value.ToString(), "Disabled", False) = 0
					If flag3 Then
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Enabled")
					End If
					Dim flag4 As Boolean = Operators.CompareString(dataGridViewRow.Cells(11).Value.ToString(), "Enabled", False) = 0
					If flag4 Then
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Disabled")
					End If
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(0).Value.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
					Dim flag5 As Boolean = num > 0
					If flag5 Then
						MessageBox.Show("Successfully Offer Status Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag6 Then
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x04000FBA RID: 4026
		Private num1 As Double

		' Token: 0x04000FBB RID: 4027
		Private cba As String

		' Token: 0x04000FBC RID: 4028
		Private txtcompname As String

		' Token: 0x04000FBD RID: 4029
		Private os As String

		' Token: 0x04000FBE RID: 4030
		Private strx As String

		' Token: 0x04000FBF RID: 4031
		Private sts As String

		' Token: 0x04000FC0 RID: 4032
		Private sts2 As String

		' Token: 0x04000FC1 RID: 4033
		Private otptext As String

		' Token: 0x04000FC2 RID: 4034
		Private giftcode As String
	End Class
End Namespace
