Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000202 RID: 514
	<DesignerGenerated()>
	Public Partial Class frmSupplierwise_report
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060093CD RID: 37837 RVA: 0x000485A8 File Offset: 0x000467A8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170036D5 RID: 14037
		' (get) Token: 0x060093D0 RID: 37840 RVA: 0x000485DA File Offset: 0x000467DA
		' (set) Token: 0x060093D1 RID: 37841 RVA: 0x000485E4 File Offset: 0x000467E4
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170036D6 RID: 14038
		' (get) Token: 0x060093D2 RID: 37842 RVA: 0x000485ED File Offset: 0x000467ED
		' (set) Token: 0x060093D3 RID: 37843 RVA: 0x006AF450 File Offset: 0x006AD650
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170036D7 RID: 14039
		' (get) Token: 0x060093D4 RID: 37844 RVA: 0x000485F7 File Offset: 0x000467F7
		' (set) Token: 0x060093D5 RID: 37845 RVA: 0x00048601 File Offset: 0x00046801
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170036D8 RID: 14040
		' (get) Token: 0x060093D6 RID: 37846 RVA: 0x0004860A File Offset: 0x0004680A
		' (set) Token: 0x060093D7 RID: 37847 RVA: 0x00048614 File Offset: 0x00046814
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170036D9 RID: 14041
		' (get) Token: 0x060093D8 RID: 37848 RVA: 0x0004861D File Offset: 0x0004681D
		' (set) Token: 0x060093D9 RID: 37849 RVA: 0x00048627 File Offset: 0x00046827
		Friend Overridable Property Label2 As Label

		' Token: 0x170036DA RID: 14042
		' (get) Token: 0x060093DA RID: 37850 RVA: 0x00048630 File Offset: 0x00046830
		' (set) Token: 0x060093DB RID: 37851 RVA: 0x0004863A File Offset: 0x0004683A
		Friend Overridable Property Label4 As Label

		' Token: 0x170036DB RID: 14043
		' (get) Token: 0x060093DC RID: 37852 RVA: 0x00048643 File Offset: 0x00046843
		' (set) Token: 0x060093DD RID: 37853 RVA: 0x0004864D File Offset: 0x0004684D
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170036DC RID: 14044
		' (get) Token: 0x060093DE RID: 37854 RVA: 0x00048656 File Offset: 0x00046856
		' (set) Token: 0x060093DF RID: 37855 RVA: 0x00048660 File Offset: 0x00046860
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170036DD RID: 14045
		' (get) Token: 0x060093E0 RID: 37856 RVA: 0x00048669 File Offset: 0x00046869
		' (set) Token: 0x060093E1 RID: 37857 RVA: 0x00048673 File Offset: 0x00046873
		Friend Overridable Property Label1 As Label

		' Token: 0x170036DE RID: 14046
		' (get) Token: 0x060093E2 RID: 37858 RVA: 0x0004867C File Offset: 0x0004687C
		' (set) Token: 0x060093E3 RID: 37859 RVA: 0x00048686 File Offset: 0x00046886
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170036DF RID: 14047
		' (get) Token: 0x060093E4 RID: 37860 RVA: 0x0004868F File Offset: 0x0004688F
		' (set) Token: 0x060093E5 RID: 37861 RVA: 0x00048699 File Offset: 0x00046899
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170036E0 RID: 14048
		' (get) Token: 0x060093E6 RID: 37862 RVA: 0x000486A2 File Offset: 0x000468A2
		' (set) Token: 0x060093E7 RID: 37863 RVA: 0x006AF4B0 File Offset: 0x006AD6B0
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

		' Token: 0x170036E1 RID: 14049
		' (get) Token: 0x060093E8 RID: 37864 RVA: 0x000486AC File Offset: 0x000468AC
		' (set) Token: 0x060093E9 RID: 37865 RVA: 0x006AF4F4 File Offset: 0x006AD6F4
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

		' Token: 0x170036E2 RID: 14050
		' (get) Token: 0x060093EA RID: 37866 RVA: 0x000486B6 File Offset: 0x000468B6
		' (set) Token: 0x060093EB RID: 37867 RVA: 0x006AF538 File Offset: 0x006AD738
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

		' Token: 0x170036E3 RID: 14051
		' (get) Token: 0x060093EC RID: 37868 RVA: 0x000486C0 File Offset: 0x000468C0
		' (set) Token: 0x060093ED RID: 37869 RVA: 0x000486CA File Offset: 0x000468CA
		Friend Overridable Property Label3 As Label

		' Token: 0x170036E4 RID: 14052
		' (get) Token: 0x060093EE RID: 37870 RVA: 0x000486D3 File Offset: 0x000468D3
		' (set) Token: 0x060093EF RID: 37871 RVA: 0x000486DD File Offset: 0x000468DD
		Friend Overridable Property Label6 As Label

		' Token: 0x170036E5 RID: 14053
		' (get) Token: 0x060093F0 RID: 37872 RVA: 0x000486E6 File Offset: 0x000468E6
		' (set) Token: 0x060093F1 RID: 37873 RVA: 0x000486F0 File Offset: 0x000468F0
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x170036E6 RID: 14054
		' (get) Token: 0x060093F2 RID: 37874 RVA: 0x000486F9 File Offset: 0x000468F9
		' (set) Token: 0x060093F3 RID: 37875 RVA: 0x00048703 File Offset: 0x00046903
		Friend Overridable Property Label8 As Label

		' Token: 0x170036E7 RID: 14055
		' (get) Token: 0x060093F4 RID: 37876 RVA: 0x0004870C File Offset: 0x0004690C
		' (set) Token: 0x060093F5 RID: 37877 RVA: 0x006AF57C File Offset: 0x006AD77C
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170036E8 RID: 14056
		' (get) Token: 0x060093F6 RID: 37878 RVA: 0x00048716 File Offset: 0x00046916
		' (set) Token: 0x060093F7 RID: 37879 RVA: 0x00048720 File Offset: 0x00046920
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170036E9 RID: 14057
		' (get) Token: 0x060093F8 RID: 37880 RVA: 0x00048729 File Offset: 0x00046929
		' (set) Token: 0x060093F9 RID: 37881 RVA: 0x00048733 File Offset: 0x00046933
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170036EA RID: 14058
		' (get) Token: 0x060093FA RID: 37882 RVA: 0x0004873C File Offset: 0x0004693C
		' (set) Token: 0x060093FB RID: 37883 RVA: 0x00048746 File Offset: 0x00046946
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170036EB RID: 14059
		' (get) Token: 0x060093FC RID: 37884 RVA: 0x0004874F File Offset: 0x0004694F
		' (set) Token: 0x060093FD RID: 37885 RVA: 0x00048759 File Offset: 0x00046959
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170036EC RID: 14060
		' (get) Token: 0x060093FE RID: 37886 RVA: 0x00048762 File Offset: 0x00046962
		' (set) Token: 0x060093FF RID: 37887 RVA: 0x0004876C File Offset: 0x0004696C
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170036ED RID: 14061
		' (get) Token: 0x06009400 RID: 37888 RVA: 0x00048775 File Offset: 0x00046975
		' (set) Token: 0x06009401 RID: 37889 RVA: 0x0004877F File Offset: 0x0004697F
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170036EE RID: 14062
		' (get) Token: 0x06009402 RID: 37890 RVA: 0x00048788 File Offset: 0x00046988
		' (set) Token: 0x06009403 RID: 37891 RVA: 0x00048792 File Offset: 0x00046992
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170036EF RID: 14063
		' (get) Token: 0x06009404 RID: 37892 RVA: 0x0004879B File Offset: 0x0004699B
		' (set) Token: 0x06009405 RID: 37893 RVA: 0x000487A5 File Offset: 0x000469A5
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170036F0 RID: 14064
		' (get) Token: 0x06009406 RID: 37894 RVA: 0x000487AE File Offset: 0x000469AE
		' (set) Token: 0x06009407 RID: 37895 RVA: 0x000487B8 File Offset: 0x000469B8
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170036F1 RID: 14065
		' (get) Token: 0x06009408 RID: 37896 RVA: 0x000487C1 File Offset: 0x000469C1
		' (set) Token: 0x06009409 RID: 37897 RVA: 0x000487CB File Offset: 0x000469CB
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170036F2 RID: 14066
		' (get) Token: 0x0600940A RID: 37898 RVA: 0x000487D4 File Offset: 0x000469D4
		' (set) Token: 0x0600940B RID: 37899 RVA: 0x000487DE File Offset: 0x000469DE
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170036F3 RID: 14067
		' (get) Token: 0x0600940C RID: 37900 RVA: 0x000487E7 File Offset: 0x000469E7
		' (set) Token: 0x0600940D RID: 37901 RVA: 0x000487F1 File Offset: 0x000469F1
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170036F4 RID: 14068
		' (get) Token: 0x0600940E RID: 37902 RVA: 0x000487FA File Offset: 0x000469FA
		' (set) Token: 0x0600940F RID: 37903 RVA: 0x00048804 File Offset: 0x00046A04
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170036F5 RID: 14069
		' (get) Token: 0x06009410 RID: 37904 RVA: 0x0004880D File Offset: 0x00046A0D
		' (set) Token: 0x06009411 RID: 37905 RVA: 0x00048817 File Offset: 0x00046A17
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170036F6 RID: 14070
		' (get) Token: 0x06009412 RID: 37906 RVA: 0x00048820 File Offset: 0x00046A20
		' (set) Token: 0x06009413 RID: 37907 RVA: 0x0004882A File Offset: 0x00046A2A
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170036F7 RID: 14071
		' (get) Token: 0x06009414 RID: 37908 RVA: 0x00048833 File Offset: 0x00046A33
		' (set) Token: 0x06009415 RID: 37909 RVA: 0x0004883D File Offset: 0x00046A3D
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170036F8 RID: 14072
		' (get) Token: 0x06009416 RID: 37910 RVA: 0x00048846 File Offset: 0x00046A46
		' (set) Token: 0x06009417 RID: 37911 RVA: 0x00048850 File Offset: 0x00046A50
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170036F9 RID: 14073
		' (get) Token: 0x06009418 RID: 37912 RVA: 0x00048859 File Offset: 0x00046A59
		' (set) Token: 0x06009419 RID: 37913 RVA: 0x00048863 File Offset: 0x00046A63
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170036FA RID: 14074
		' (get) Token: 0x0600941A RID: 37914 RVA: 0x0004886C File Offset: 0x00046A6C
		' (set) Token: 0x0600941B RID: 37915 RVA: 0x00048876 File Offset: 0x00046A76
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170036FB RID: 14075
		' (get) Token: 0x0600941C RID: 37916 RVA: 0x0004887F File Offset: 0x00046A7F
		' (set) Token: 0x0600941D RID: 37917 RVA: 0x00048889 File Offset: 0x00046A89
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170036FC RID: 14076
		' (get) Token: 0x0600941E RID: 37918 RVA: 0x00048892 File Offset: 0x00046A92
		' (set) Token: 0x0600941F RID: 37919 RVA: 0x0004889C File Offset: 0x00046A9C
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170036FD RID: 14077
		' (get) Token: 0x06009420 RID: 37920 RVA: 0x000488A5 File Offset: 0x00046AA5
		' (set) Token: 0x06009421 RID: 37921 RVA: 0x000488AF File Offset: 0x00046AAF
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170036FE RID: 14078
		' (get) Token: 0x06009422 RID: 37922 RVA: 0x000488B8 File Offset: 0x00046AB8
		' (set) Token: 0x06009423 RID: 37923 RVA: 0x000488C2 File Offset: 0x00046AC2
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170036FF RID: 14079
		' (get) Token: 0x06009424 RID: 37924 RVA: 0x000488CB File Offset: 0x00046ACB
		' (set) Token: 0x06009425 RID: 37925 RVA: 0x000488D5 File Offset: 0x00046AD5
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17003700 RID: 14080
		' (get) Token: 0x06009426 RID: 37926 RVA: 0x000488DE File Offset: 0x00046ADE
		' (set) Token: 0x06009427 RID: 37927 RVA: 0x000488E8 File Offset: 0x00046AE8
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17003701 RID: 14081
		' (get) Token: 0x06009428 RID: 37928 RVA: 0x000488F1 File Offset: 0x00046AF1
		' (set) Token: 0x06009429 RID: 37929 RVA: 0x000488FB File Offset: 0x00046AFB
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17003702 RID: 14082
		' (get) Token: 0x0600942A RID: 37930 RVA: 0x00048904 File Offset: 0x00046B04
		' (set) Token: 0x0600942B RID: 37931 RVA: 0x0004890E File Offset: 0x00046B0E
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17003703 RID: 14083
		' (get) Token: 0x0600942C RID: 37932 RVA: 0x00048917 File Offset: 0x00046B17
		' (set) Token: 0x0600942D RID: 37933 RVA: 0x00048921 File Offset: 0x00046B21
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17003704 RID: 14084
		' (get) Token: 0x0600942E RID: 37934 RVA: 0x0004892A File Offset: 0x00046B2A
		' (set) Token: 0x0600942F RID: 37935 RVA: 0x00048934 File Offset: 0x00046B34
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17003705 RID: 14085
		' (get) Token: 0x06009430 RID: 37936 RVA: 0x0004893D File Offset: 0x00046B3D
		' (set) Token: 0x06009431 RID: 37937 RVA: 0x00048947 File Offset: 0x00046B47
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17003706 RID: 14086
		' (get) Token: 0x06009432 RID: 37938 RVA: 0x00048950 File Offset: 0x00046B50
		' (set) Token: 0x06009433 RID: 37939 RVA: 0x0004895A File Offset: 0x00046B5A
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17003707 RID: 14087
		' (get) Token: 0x06009434 RID: 37940 RVA: 0x00048963 File Offset: 0x00046B63
		' (set) Token: 0x06009435 RID: 37941 RVA: 0x0004896D File Offset: 0x00046B6D
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17003708 RID: 14088
		' (get) Token: 0x06009436 RID: 37942 RVA: 0x00048976 File Offset: 0x00046B76
		' (set) Token: 0x06009437 RID: 37943 RVA: 0x00048980 File Offset: 0x00046B80
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17003709 RID: 14089
		' (get) Token: 0x06009438 RID: 37944 RVA: 0x00048989 File Offset: 0x00046B89
		' (set) Token: 0x06009439 RID: 37945 RVA: 0x00048993 File Offset: 0x00046B93
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x1700370A RID: 14090
		' (get) Token: 0x0600943A RID: 37946 RVA: 0x0004899C File Offset: 0x00046B9C
		' (set) Token: 0x0600943B RID: 37947 RVA: 0x000489A6 File Offset: 0x00046BA6
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x1700370B RID: 14091
		' (get) Token: 0x0600943C RID: 37948 RVA: 0x000489AF File Offset: 0x00046BAF
		' (set) Token: 0x0600943D RID: 37949 RVA: 0x006AF5C0 File Offset: 0x006AD7C0
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700370C RID: 14092
		' (get) Token: 0x0600943E RID: 37950 RVA: 0x000489B9 File Offset: 0x00046BB9
		' (set) Token: 0x0600943F RID: 37951 RVA: 0x006AF604 File Offset: 0x006AD804
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

		' Token: 0x1700370D RID: 14093
		' (get) Token: 0x06009440 RID: 37952 RVA: 0x000489C3 File Offset: 0x00046BC3
		' (set) Token: 0x06009441 RID: 37953 RVA: 0x006AF648 File Offset: 0x006AD848
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

		' Token: 0x06009442 RID: 37954 RVA: 0x006AF68C File Offset: 0x006AD88C
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
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
			End Try
		End Sub

		' Token: 0x06009443 RID: 37955 RVA: 0x006AF760 File Offset: 0x006AD960
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType, RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009444 RID: 37956 RVA: 0x006AFAE8 File Offset: 0x006ADCE8
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x06009445 RID: 37957 RVA: 0x006AFB78 File Offset: 0x006ADD78
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

		' Token: 0x06009446 RID: 37958 RVA: 0x000489CD File Offset: 0x00046BCD
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x06009447 RID: 37959 RVA: 0x006AFC60 File Offset: 0x006ADE60
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Select the search category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock.InvoiceNo=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock.SupplierInvoiceNo=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Supplier.Name=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Product.ProductName=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
									ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Product.ProductCode=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
										ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
										ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
									Else
										Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 5
										If flag7 Then
											ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Barcode=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
											ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
											ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
										Else
											Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 6
											If flag8 Then
												ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Color=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
												ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
												ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
											Else
												Dim flag9 As Boolean = Me.ComboBox1.SelectedIndex = 7
												If flag9 Then
													ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Size=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
													ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
													ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
												Else
													Dim flag10 As Boolean = Me.ComboBox1.SelectedIndex = 8
													If flag10 Then
														ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Info=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
														ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
														ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
													Else
														Dim flag11 As Boolean = Me.ComboBox1.SelectedIndex = 9
														If flag11 Then
															ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.Batch=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
															ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
															ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
														Else
															Dim flag12 As Boolean = Me.ComboBox1.SelectedIndex = 10
															If flag12 Then
																ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.IMEI1=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
																ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
																ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
															Else
																Dim flag13 As Boolean = Me.ComboBox1.SelectedIndex = 11
																If flag13 Then
																	ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock_Product.IMEI2=N'" + Me.TextBox1.Text + "' order by Stock.Date", ModCommonClasses.con)
																	ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
																	ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
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
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x06009448 RID: 37960 RVA: 0x000489EF File Offset: 0x00046BEF
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06009449 RID: 37961 RVA: 0x00048A24 File Offset: 0x00046C24
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x0600944A RID: 37962 RVA: 0x006B0848 File Offset: 0x006AEA48
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.cpy = dataGridViewRow.Cells(0).Value.ToString()
				Clipboard.SetDataObject(Me.cpy)
				MessageBox.Show("Invoice Number is Copied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600944B RID: 37963 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseRecord_GSTR_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600944C RID: 37964 RVA: 0x006B08C8 File Offset: 0x006AEAC8
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x0600944D RID: 37965 RVA: 0x006B09E0 File Offset: 0x006AEBE0
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.TextBox1.Clear()
				Me.ComboBox1.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox2.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and NOT Stock.TaxType=@d3 order by Stock.Date", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
				Else
					Dim flag2 As Boolean = Me.ComboBox2.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and Stock.TaxType=@d3 order by Stock.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "NON GST")
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600944E RID: 37966 RVA: 0x006B0E54 File Offset: 0x006AF054
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.TextBox1.Clear()
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0600944F RID: 37967 RVA: 0x006B11FC File Offset: 0x006AF3FC
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06009450 RID: 37968 RVA: 0x006B124C File Offset: 0x006AF44C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x040041AF RID: 16815
		Private cpy As String
	End Class
End Namespace
