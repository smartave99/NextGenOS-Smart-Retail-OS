Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x0200020B RID: 523
	<DesignerGenerated()>
	Public Partial Class frmCurrentStock
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060097FB RID: 38907 RVA: 0x0004A456 File Offset: 0x00048656
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCurrentStock_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCurrentStock_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003872 RID: 14450
		' (get) Token: 0x060097FE RID: 38910 RVA: 0x0004A488 File Offset: 0x00048688
		' (set) Token: 0x060097FF RID: 38911 RVA: 0x0004A492 File Offset: 0x00048692
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003873 RID: 14451
		' (get) Token: 0x06009800 RID: 38912 RVA: 0x0004A49B File Offset: 0x0004869B
		' (set) Token: 0x06009801 RID: 38913 RVA: 0x006D48AC File Offset: 0x006D2AAC
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003874 RID: 14452
		' (get) Token: 0x06009802 RID: 38914 RVA: 0x0004A4A5 File Offset: 0x000486A5
		' (set) Token: 0x06009803 RID: 38915 RVA: 0x0004A4AF File Offset: 0x000486AF
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17003875 RID: 14453
		' (get) Token: 0x06009804 RID: 38916 RVA: 0x0004A4B8 File Offset: 0x000486B8
		' (set) Token: 0x06009805 RID: 38917 RVA: 0x006D4928 File Offset: 0x006D2B28
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003876 RID: 14454
		' (get) Token: 0x06009806 RID: 38918 RVA: 0x0004A4C2 File Offset: 0x000486C2
		' (set) Token: 0x06009807 RID: 38919 RVA: 0x0004A4CC File Offset: 0x000486CC
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17003877 RID: 14455
		' (get) Token: 0x06009808 RID: 38920 RVA: 0x0004A4D5 File Offset: 0x000486D5
		' (set) Token: 0x06009809 RID: 38921 RVA: 0x006D496C File Offset: 0x006D2B6C
		Private _txtSearch As Button
		Friend Overridable Property txtSearch As Button
			<CompilerGenerated()>
			Get
				Return Me._txtSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim button As Button = Me._txtSearch
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._txtSearch = value
				button = Me._txtSearch
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003878 RID: 14456
		' (get) Token: 0x0600980A RID: 38922 RVA: 0x0004A4DF File Offset: 0x000486DF
		' (set) Token: 0x0600980B RID: 38923 RVA: 0x0004A4E9 File Offset: 0x000486E9
		Friend Overridable Property lblSet As Label

		' Token: 0x17003879 RID: 14457
		' (get) Token: 0x0600980C RID: 38924 RVA: 0x0004A4F2 File Offset: 0x000486F2
		' (set) Token: 0x0600980D RID: 38925 RVA: 0x0004A4FC File Offset: 0x000486FC
		Friend Overridable Property Label1 As Label

		' Token: 0x1700387A RID: 14458
		' (get) Token: 0x0600980E RID: 38926 RVA: 0x0004A505 File Offset: 0x00048705
		' (set) Token: 0x0600980F RID: 38927 RVA: 0x006D49B0 File Offset: 0x006D2BB0
		Private _btnShowAll As Button
		Friend Overridable Property btnShowAll As Button
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click
				Dim button As Button = Me._btnShowAll
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnShowAll = value
				button = Me._btnShowAll
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700387B RID: 14459
		' (get) Token: 0x06009810 RID: 38928 RVA: 0x0004A50F File Offset: 0x0004870F
		' (set) Token: 0x06009811 RID: 38929 RVA: 0x0004A519 File Offset: 0x00048719
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700387C RID: 14460
		' (get) Token: 0x06009812 RID: 38930 RVA: 0x0004A522 File Offset: 0x00048722
		' (set) Token: 0x06009813 RID: 38931 RVA: 0x0004A52C File Offset: 0x0004872C
		Friend Overridable Property Label5 As Label

		' Token: 0x1700387D RID: 14461
		' (get) Token: 0x06009814 RID: 38932 RVA: 0x0004A535 File Offset: 0x00048735
		' (set) Token: 0x06009815 RID: 38933 RVA: 0x0004A53F File Offset: 0x0004873F
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700387E RID: 14462
		' (get) Token: 0x06009816 RID: 38934 RVA: 0x0004A548 File Offset: 0x00048748
		' (set) Token: 0x06009817 RID: 38935 RVA: 0x0004A552 File Offset: 0x00048752
		Friend Overridable Property chkBoxZeroQty As CheckBox

		' Token: 0x1700387F RID: 14463
		' (get) Token: 0x06009818 RID: 38936 RVA: 0x0004A55B File Offset: 0x0004875B
		' (set) Token: 0x06009819 RID: 38937 RVA: 0x0004A565 File Offset: 0x00048765
		Friend Overridable Property lblNoOfItems As Label

		' Token: 0x17003880 RID: 14464
		' (get) Token: 0x0600981A RID: 38938 RVA: 0x0004A56E File Offset: 0x0004876E
		' (set) Token: 0x0600981B RID: 38939 RVA: 0x0004A578 File Offset: 0x00048778
		Friend Overridable Property Label10 As Label

		' Token: 0x17003881 RID: 14465
		' (get) Token: 0x0600981C RID: 38940 RVA: 0x0004A581 File Offset: 0x00048781
		' (set) Token: 0x0600981D RID: 38941 RVA: 0x006D49F4 File Offset: 0x006D2BF4
		Private _btnGetData As Button
		Friend Overridable Property btnGetData As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim button As Button = Me._btnGetData
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetData = value
				button = Me._btnGetData
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003882 RID: 14466
		' (get) Token: 0x0600981E RID: 38942 RVA: 0x0004A58B File Offset: 0x0004878B
		' (set) Token: 0x0600981F RID: 38943 RVA: 0x0004A595 File Offset: 0x00048795
		Friend Overridable Property Label11 As Label

		' Token: 0x17003883 RID: 14467
		' (get) Token: 0x06009820 RID: 38944 RVA: 0x0004A59E File Offset: 0x0004879E
		' (set) Token: 0x06009821 RID: 38945 RVA: 0x0004A5A8 File Offset: 0x000487A8
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17003884 RID: 14468
		' (get) Token: 0x06009822 RID: 38946 RVA: 0x0004A5B1 File Offset: 0x000487B1
		' (set) Token: 0x06009823 RID: 38947 RVA: 0x006D4A38 File Offset: 0x006D2C38
		Private _cmbSearchType As ComboBox
		Friend Overridable Property cmbSearchType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSearchType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSearchType_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbSearchType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbSearchType = value
				comboBox = Me._cmbSearchType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003885 RID: 14469
		' (get) Token: 0x06009824 RID: 38948 RVA: 0x0004A5BB File Offset: 0x000487BB
		' (set) Token: 0x06009825 RID: 38949 RVA: 0x006D4A7C File Offset: 0x006D2C7C
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

		' Token: 0x17003886 RID: 14470
		' (get) Token: 0x06009826 RID: 38950 RVA: 0x0004A5C5 File Offset: 0x000487C5
		' (set) Token: 0x06009827 RID: 38951 RVA: 0x006D4AC0 File Offset: 0x006D2CC0
		Private _chkExp As CheckBox
		Friend Overridable Property chkExp As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkExp
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkExp_CheckedChanged
				Dim checkBox As CheckBox = Me._chkExp
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkExp = value
				checkBox = Me._chkExp
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003887 RID: 14471
		' (get) Token: 0x06009828 RID: 38952 RVA: 0x0004A5CF File Offset: 0x000487CF
		' (set) Token: 0x06009829 RID: 38953 RVA: 0x006D4B04 File Offset: 0x006D2D04
		Private _chkMfg As CheckBox
		Friend Overridable Property chkMfg As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkMfg
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkMfg_CheckedChanged
				Dim checkBox As CheckBox = Me._chkMfg
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkMfg = value
				checkBox = Me._chkMfg
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003888 RID: 14472
		' (get) Token: 0x0600982A RID: 38954 RVA: 0x0004A5D9 File Offset: 0x000487D9
		' (set) Token: 0x0600982B RID: 38955 RVA: 0x0004A5E3 File Offset: 0x000487E3
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17003889 RID: 14473
		' (get) Token: 0x0600982C RID: 38956 RVA: 0x0004A5EC File Offset: 0x000487EC
		' (set) Token: 0x0600982D RID: 38957 RVA: 0x0004A5F6 File Offset: 0x000487F6
		Friend Overridable Property Label3 As Label

		' Token: 0x1700388A RID: 14474
		' (get) Token: 0x0600982E RID: 38958 RVA: 0x0004A5FF File Offset: 0x000487FF
		' (set) Token: 0x0600982F RID: 38959 RVA: 0x0004A609 File Offset: 0x00048809
		Friend Overridable Property Label2 As Label

		' Token: 0x1700388B RID: 14475
		' (get) Token: 0x06009830 RID: 38960 RVA: 0x0004A612 File Offset: 0x00048812
		' (set) Token: 0x06009831 RID: 38961 RVA: 0x0004A61C File Offset: 0x0004881C
		Friend Overridable Property Label4 As Label

		' Token: 0x1700388C RID: 14476
		' (get) Token: 0x06009832 RID: 38962 RVA: 0x0004A625 File Offset: 0x00048825
		' (set) Token: 0x06009833 RID: 38963 RVA: 0x0004A62F File Offset: 0x0004882F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700388D RID: 14477
		' (get) Token: 0x06009834 RID: 38964 RVA: 0x0004A638 File Offset: 0x00048838
		' (set) Token: 0x06009835 RID: 38965 RVA: 0x0004A642 File Offset: 0x00048842
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700388E RID: 14478
		' (get) Token: 0x06009836 RID: 38966 RVA: 0x0004A64B File Offset: 0x0004884B
		' (set) Token: 0x06009837 RID: 38967 RVA: 0x0004A655 File Offset: 0x00048855
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700388F RID: 14479
		' (get) Token: 0x06009838 RID: 38968 RVA: 0x0004A65E File Offset: 0x0004885E
		' (set) Token: 0x06009839 RID: 38969 RVA: 0x0004A668 File Offset: 0x00048868
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003890 RID: 14480
		' (get) Token: 0x0600983A RID: 38970 RVA: 0x0004A671 File Offset: 0x00048871
		' (set) Token: 0x0600983B RID: 38971 RVA: 0x0004A67B File Offset: 0x0004887B
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003891 RID: 14481
		' (get) Token: 0x0600983C RID: 38972 RVA: 0x0004A684 File Offset: 0x00048884
		' (set) Token: 0x0600983D RID: 38973 RVA: 0x0004A68E File Offset: 0x0004888E
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003892 RID: 14482
		' (get) Token: 0x0600983E RID: 38974 RVA: 0x0004A697 File Offset: 0x00048897
		' (set) Token: 0x0600983F RID: 38975 RVA: 0x0004A6A1 File Offset: 0x000488A1
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003893 RID: 14483
		' (get) Token: 0x06009840 RID: 38976 RVA: 0x0004A6AA File Offset: 0x000488AA
		' (set) Token: 0x06009841 RID: 38977 RVA: 0x0004A6B4 File Offset: 0x000488B4
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003894 RID: 14484
		' (get) Token: 0x06009842 RID: 38978 RVA: 0x0004A6BD File Offset: 0x000488BD
		' (set) Token: 0x06009843 RID: 38979 RVA: 0x0004A6C7 File Offset: 0x000488C7
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17003895 RID: 14485
		' (get) Token: 0x06009844 RID: 38980 RVA: 0x0004A6D0 File Offset: 0x000488D0
		' (set) Token: 0x06009845 RID: 38981 RVA: 0x0004A6DA File Offset: 0x000488DA
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003896 RID: 14486
		' (get) Token: 0x06009846 RID: 38982 RVA: 0x0004A6E3 File Offset: 0x000488E3
		' (set) Token: 0x06009847 RID: 38983 RVA: 0x0004A6ED File Offset: 0x000488ED
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17003897 RID: 14487
		' (get) Token: 0x06009848 RID: 38984 RVA: 0x0004A6F6 File Offset: 0x000488F6
		' (set) Token: 0x06009849 RID: 38985 RVA: 0x0004A700 File Offset: 0x00048900
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17003898 RID: 14488
		' (get) Token: 0x0600984A RID: 38986 RVA: 0x0004A709 File Offset: 0x00048909
		' (set) Token: 0x0600984B RID: 38987 RVA: 0x0004A713 File Offset: 0x00048913
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17003899 RID: 14489
		' (get) Token: 0x0600984C RID: 38988 RVA: 0x0004A71C File Offset: 0x0004891C
		' (set) Token: 0x0600984D RID: 38989 RVA: 0x0004A726 File Offset: 0x00048926
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700389A RID: 14490
		' (get) Token: 0x0600984E RID: 38990 RVA: 0x0004A72F File Offset: 0x0004892F
		' (set) Token: 0x0600984F RID: 38991 RVA: 0x0004A739 File Offset: 0x00048939
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700389B RID: 14491
		' (get) Token: 0x06009850 RID: 38992 RVA: 0x0004A742 File Offset: 0x00048942
		' (set) Token: 0x06009851 RID: 38993 RVA: 0x0004A74C File Offset: 0x0004894C
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700389C RID: 14492
		' (get) Token: 0x06009852 RID: 38994 RVA: 0x0004A755 File Offset: 0x00048955
		' (set) Token: 0x06009853 RID: 38995 RVA: 0x0004A75F File Offset: 0x0004895F
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700389D RID: 14493
		' (get) Token: 0x06009854 RID: 38996 RVA: 0x0004A768 File Offset: 0x00048968
		' (set) Token: 0x06009855 RID: 38997 RVA: 0x0004A772 File Offset: 0x00048972
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700389E RID: 14494
		' (get) Token: 0x06009856 RID: 38998 RVA: 0x0004A77B File Offset: 0x0004897B
		' (set) Token: 0x06009857 RID: 38999 RVA: 0x0004A785 File Offset: 0x00048985
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700389F RID: 14495
		' (get) Token: 0x06009858 RID: 39000 RVA: 0x0004A78E File Offset: 0x0004898E
		' (set) Token: 0x06009859 RID: 39001 RVA: 0x0004A798 File Offset: 0x00048998
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170038A0 RID: 14496
		' (get) Token: 0x0600985A RID: 39002 RVA: 0x0004A7A1 File Offset: 0x000489A1
		' (set) Token: 0x0600985B RID: 39003 RVA: 0x0004A7AB File Offset: 0x000489AB
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170038A1 RID: 14497
		' (get) Token: 0x0600985C RID: 39004 RVA: 0x0004A7B4 File Offset: 0x000489B4
		' (set) Token: 0x0600985D RID: 39005 RVA: 0x0004A7BE File Offset: 0x000489BE
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170038A2 RID: 14498
		' (get) Token: 0x0600985E RID: 39006 RVA: 0x0004A7C7 File Offset: 0x000489C7
		' (set) Token: 0x0600985F RID: 39007 RVA: 0x0004A7D1 File Offset: 0x000489D1
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170038A3 RID: 14499
		' (get) Token: 0x06009860 RID: 39008 RVA: 0x0004A7DA File Offset: 0x000489DA
		' (set) Token: 0x06009861 RID: 39009 RVA: 0x0004A7E4 File Offset: 0x000489E4
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170038A4 RID: 14500
		' (get) Token: 0x06009862 RID: 39010 RVA: 0x0004A7ED File Offset: 0x000489ED
		' (set) Token: 0x06009863 RID: 39011 RVA: 0x0004A7F7 File Offset: 0x000489F7
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170038A5 RID: 14501
		' (get) Token: 0x06009864 RID: 39012 RVA: 0x0004A800 File Offset: 0x00048A00
		' (set) Token: 0x06009865 RID: 39013 RVA: 0x0004A80A File Offset: 0x00048A0A
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170038A6 RID: 14502
		' (get) Token: 0x06009866 RID: 39014 RVA: 0x0004A813 File Offset: 0x00048A13
		' (set) Token: 0x06009867 RID: 39015 RVA: 0x0004A81D File Offset: 0x00048A1D
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170038A7 RID: 14503
		' (get) Token: 0x06009868 RID: 39016 RVA: 0x0004A826 File Offset: 0x00048A26
		' (set) Token: 0x06009869 RID: 39017 RVA: 0x0004A830 File Offset: 0x00048A30
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170038A8 RID: 14504
		' (get) Token: 0x0600986A RID: 39018 RVA: 0x0004A839 File Offset: 0x00048A39
		' (set) Token: 0x0600986B RID: 39019 RVA: 0x0004A843 File Offset: 0x00048A43
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170038A9 RID: 14505
		' (get) Token: 0x0600986C RID: 39020 RVA: 0x0004A84C File Offset: 0x00048A4C
		' (set) Token: 0x0600986D RID: 39021 RVA: 0x0004A856 File Offset: 0x00048A56
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170038AA RID: 14506
		' (get) Token: 0x0600986E RID: 39022 RVA: 0x0004A85F File Offset: 0x00048A5F
		' (set) Token: 0x0600986F RID: 39023 RVA: 0x0004A869 File Offset: 0x00048A69
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170038AB RID: 14507
		' (get) Token: 0x06009870 RID: 39024 RVA: 0x0004A872 File Offset: 0x00048A72
		' (set) Token: 0x06009871 RID: 39025 RVA: 0x0004A87C File Offset: 0x00048A7C
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170038AC RID: 14508
		' (get) Token: 0x06009872 RID: 39026 RVA: 0x0004A885 File Offset: 0x00048A85
		' (set) Token: 0x06009873 RID: 39027 RVA: 0x0004A88F File Offset: 0x00048A8F
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170038AD RID: 14509
		' (get) Token: 0x06009874 RID: 39028 RVA: 0x0004A898 File Offset: 0x00048A98
		' (set) Token: 0x06009875 RID: 39029 RVA: 0x0004A8A2 File Offset: 0x00048AA2
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x170038AE RID: 14510
		' (get) Token: 0x06009876 RID: 39030 RVA: 0x0004A8AB File Offset: 0x00048AAB
		' (set) Token: 0x06009877 RID: 39031 RVA: 0x0004A8B5 File Offset: 0x00048AB5
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170038AF RID: 14511
		' (get) Token: 0x06009878 RID: 39032 RVA: 0x0004A8BE File Offset: 0x00048ABE
		' (set) Token: 0x06009879 RID: 39033 RVA: 0x0004A8C8 File Offset: 0x00048AC8
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x170038B0 RID: 14512
		' (get) Token: 0x0600987A RID: 39034 RVA: 0x0004A8D1 File Offset: 0x00048AD1
		' (set) Token: 0x0600987B RID: 39035 RVA: 0x0004A8DB File Offset: 0x00048ADB
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x170038B1 RID: 14513
		' (get) Token: 0x0600987C RID: 39036 RVA: 0x0004A8E4 File Offset: 0x00048AE4
		' (set) Token: 0x0600987D RID: 39037 RVA: 0x006D4B48 File Offset: 0x006D2D48
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

		' Token: 0x170038B2 RID: 14514
		' (get) Token: 0x0600987E RID: 39038 RVA: 0x0004A8EE File Offset: 0x00048AEE
		' (set) Token: 0x0600987F RID: 39039 RVA: 0x0004A8F8 File Offset: 0x00048AF8
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x06009880 RID: 39040 RVA: 0x006D4B8C File Offset: 0x006D2D8C
		Public Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.chkBoxZeroQty.Checked
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
				Else
					Dim checked As Boolean = Me.chkBoxZeroQty.Checked
					If checked Then
						ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
				End While
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim num As Integer = Me.dgw.RowCount - 1
				For i As Integer = 0 To num
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
					If flag2 Then
						Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
						Dim flag3 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
						If flag3 Then
							Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
						End If
					End If
				Next
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009881 RID: 39041 RVA: 0x006D4FF4 File Offset: 0x006D31F4
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06009882 RID: 39042 RVA: 0x006D501C File Offset: 0x006D321C
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "POS", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOS.Show()
						MyBase.Close()
						MyProject.Forms.frmPOS.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOS.txtTaxType.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOS.txtHSNCode.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOS.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOS.TextBox20.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOS.txtPurchaseRate.Text = dataGridViewRow.Cells(35).Value.ToString()
						Dim checked As Boolean = MyProject.Forms.frmPOS.RadioButton1.Checked
						If checked Then
							MyProject.Forms.frmPOS.txtSalesRate.Text = dataGridViewRow.Cells(7).Value.ToString()
						Else
							Dim checked2 As Boolean = MyProject.Forms.frmPOS.RadioButton2.Checked
							If checked2 Then
								MyProject.Forms.frmPOS.txtSalesRate.Text = dataGridViewRow.Cells(14).Value.ToString()
							Else
								MyProject.Forms.frmPOS.txtSalesRate.Text = dataGridViewRow.Cells(7).Value.ToString()
							End If
						End If
						MyProject.Forms.frmPOS.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
						Dim flag3 As Boolean = Conversion.Val(MyProject.Forms.frmPOS.txtItemOffer.Text) > 0.0
						If flag3 Then
							MyProject.Forms.frmPOS.txtDiscPer.Text = Conversions.ToString(Conversion.Val(MyProject.Forms.frmPOS.txtItemOffer.Text))
						Else
							MyProject.Forms.frmPOS.txtDiscPer.Text = dataGridViewRow.Cells(8).Value.ToString()
						End If
						MyProject.Forms.frmPOS.cmbUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmPOS.TextBox1.Text = dataGridViewRow.Cells(12).Value.ToString()
						Dim flag4 As Boolean = (Operators.CompareString(MyProject.Forms.frmPOS.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(MyProject.Forms.frmPOS.cmbCustomerState.Text, MyProject.Forms.frmPOS.txtCompanyState.Text, False) = 0)
						If flag4 Then
							MyProject.Forms.frmPOS.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
							MyProject.Forms.frmPOS.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
							MyProject.Forms.frmPOS.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag5 As Boolean = (Operators.CompareString(MyProject.Forms.frmPOS.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(MyProject.Forms.frmPOS.cmbCustomerState.Text, MyProject.Forms.frmPOS.txtCompanyState.Text, False) = 0)
							If flag5 Then
								MyProject.Forms.frmPOS.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
								MyProject.Forms.frmPOS.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
								MyProject.Forms.frmPOS.txtIGSTPer.Text = Conversions.ToString(0)
							Else
								Dim flag6 As Boolean = (Operators.CompareString(MyProject.Forms.frmPOS.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(MyProject.Forms.frmPOS.cmbCustomerState.Text, MyProject.Forms.frmPOS.txtCompanyState.Text, False) <> 0)
								If flag6 Then
									MyProject.Forms.frmPOS.txtCGSTPer.Text = Conversions.ToString(0)
									MyProject.Forms.frmPOS.txtSGSTPer.Text = Conversions.ToString(0)
									MyProject.Forms.frmPOS.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
								Else
									Dim flag7 As Boolean = (Operators.CompareString(MyProject.Forms.frmPOS.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(MyProject.Forms.frmPOS.cmbCustomerState.Text, MyProject.Forms.frmPOS.txtCompanyState.Text, False) <> 0)
									If flag7 Then
										MyProject.Forms.frmPOS.txtCGSTPer.Text = Conversions.ToString(0)
										MyProject.Forms.frmPOS.txtSGSTPer.Text = Conversions.ToString(0)
										MyProject.Forms.frmPOS.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
									End If
								End If
							End If
						End If
						MyProject.Forms.frmPOS.txtCESSPer.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmPOS.lblLastPrice.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmPOS.txtDesc.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOS.txtMinStock.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOS.lblMRP.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmPOS.txtQty.Text = dataGridViewRow.Cells(32).Value.ToString()
						MyProject.Forms.frmPOS.txtBatch1.Text = dataGridViewRow.Cells(27).Value.ToString()
						MyProject.Forms.frmPOS.txtMfg1.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmPOS.txtExp1.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmPOS.txtSize1.Text = dataGridViewRow.Cells(30).Value.ToString()
						MyProject.Forms.frmPOS.txtColour1.Text = dataGridViewRow.Cells(31).Value.ToString()
						MyProject.Forms.frmPOS.txtIMEI1.Text = dataGridViewRow.Cells(33).Value.ToString()
						MyProject.Forms.frmPOS.txtIMEI2.Text = dataGridViewRow.Cells(34).Value.ToString()
						MyProject.Forms.frmPOS.Calc()
						MyProject.Forms.frmPOS.ProductRatedata()
						MyProject.Forms.frmPOS.txtQty.Focus()
						Me.lblSet.Text = ""
						MyProject.Forms.frmPOS.dgw4.Visible = False
					End If
					Dim flag8 As Boolean = Operators.CompareString(Me.lblSet.Text, "POSTouch", False) = 0
					If flag8 Then
						MyProject.Forms.frmPOSTouch.Show()
						MyBase.Close()
						MyProject.Forms.frmPOSTouch.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtTaxType.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtHSNCode.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSTouch.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOSTouch.TextBox20.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtPurchaseRate.Text = dataGridViewRow.Cells(35).Value.ToString()
						Dim checked3 As Boolean = MyProject.Forms.frmPOSTouch.RadioButton1.Checked
						If checked3 Then
							MyProject.Forms.frmPOSTouch.txtSalesRate.Text = dataGridViewRow.Cells(7).Value.ToString()
						Else
							Dim checked4 As Boolean = MyProject.Forms.frmPOSTouch.RadioButton2.Checked
							If checked4 Then
								MyProject.Forms.frmPOSTouch.txtSalesRate.Text = dataGridViewRow.Cells(14).Value.ToString()
							Else
								MyProject.Forms.frmPOSTouch.txtSalesRate.Text = dataGridViewRow.Cells(7).Value.ToString()
							End If
						End If
						MyProject.Forms.frmPOSTouch.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
						Dim flag9 As Boolean = Conversion.Val(MyProject.Forms.frmPOSTouch.txtItemOffer.Text) > 0.0
						If flag9 Then
							MyProject.Forms.frmPOSTouch.txtDiscPer.Text = Conversions.ToString(Conversion.Val(MyProject.Forms.frmPOSTouch.txtItemOffer.Text))
						Else
							MyProject.Forms.frmPOSTouch.txtDiscPer.Text = dataGridViewRow.Cells(8).Value.ToString()
						End If
						MyProject.Forms.frmPOSTouch.cmbUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmPOSTouch.TextBox1.Text = dataGridViewRow.Cells(12).Value.ToString()
						Dim flag10 As Boolean = (Operators.CompareString(MyProject.Forms.frmPOSTouch.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbCustomerState.Text, MyProject.Forms.frmPOSTouch.txtCompanyState.Text, False) = 0)
						If flag10 Then
							MyProject.Forms.frmPOSTouch.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
							MyProject.Forms.frmPOSTouch.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag11 As Boolean = (Operators.CompareString(MyProject.Forms.frmPOSTouch.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbCustomerState.Text, MyProject.Forms.frmPOSTouch.txtCompanyState.Text, False) = 0)
							If flag11 Then
								MyProject.Forms.frmPOSTouch.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
								MyProject.Forms.frmPOSTouch.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
								MyProject.Forms.frmPOSTouch.txtIGSTPer.Text = Conversions.ToString(0)
							Else
								Dim flag12 As Boolean = (Operators.CompareString(MyProject.Forms.frmPOSTouch.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbCustomerState.Text, MyProject.Forms.frmPOSTouch.txtCompanyState.Text, False) <> 0)
								If flag12 Then
									MyProject.Forms.frmPOSTouch.txtCGSTPer.Text = Conversions.ToString(0)
									MyProject.Forms.frmPOSTouch.txtSGSTPer.Text = Conversions.ToString(0)
									MyProject.Forms.frmPOSTouch.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
								Else
									Dim flag13 As Boolean = (Operators.CompareString(MyProject.Forms.frmPOSTouch.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbCustomerState.Text, MyProject.Forms.frmPOSTouch.txtCompanyState.Text, False) <> 0)
									If flag13 Then
										MyProject.Forms.frmPOSTouch.txtCGSTPer.Text = Conversions.ToString(0)
										MyProject.Forms.frmPOSTouch.txtSGSTPer.Text = Conversions.ToString(0)
										MyProject.Forms.frmPOSTouch.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
									End If
								End If
							End If
						End If
						MyProject.Forms.frmPOSTouch.txtCESSPer.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmPOSTouch.lblLastPrice.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtDesc.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtMinStock.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSTouch.lblMRP.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtQty.Text = dataGridViewRow.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtBatch1.Text = dataGridViewRow.Cells(27).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtMfg1.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtExp1.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtSize1.Text = dataGridViewRow.Cells(30).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtColour1.Text = dataGridViewRow.Cells(31).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtIMEI1.Text = dataGridViewRow.Cells(33).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtIMEI2.Text = dataGridViewRow.Cells(34).Value.ToString()
						MyProject.Forms.frmPOSTouch.Calc()
						MyProject.Forms.frmPOSTouch.ProductRatedata()
						MyProject.Forms.frmPOSTouch.txtQty.Focus()
						Me.lblSet.Text = ""
						MyProject.Forms.frmPOSTouch.dgw4.Visible = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009883 RID: 39043 RVA: 0x0004A901 File Offset: 0x00048B01
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06009884 RID: 39044 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
		End Sub

		' Token: 0x06009885 RID: 39045 RVA: 0x006D62C0 File Offset: 0x006D44C0
		Public Sub Reset()
			Me.chkBoxZeroQty.Checked = False
			Me.cmbSearchType.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.dgw.Rows.Clear()
			Me.Calculate()
			Me.chkMfg.Checked = False
			Me.chkExp.Checked = False
		End Sub

		' Token: 0x06009886 RID: 39046 RVA: 0x0004A90B File Offset: 0x00048B0B
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06009887 RID: 39047 RVA: 0x006D632C File Offset: 0x006D452C
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
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

		' Token: 0x06009888 RID: 39048 RVA: 0x006D65D8 File Offset: 0x006D47D8
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes
			If flag Then
				Me.Getdata()
				Me.dgw.Focus()
			End If
		End Sub

		' Token: 0x06009889 RID: 39049 RVA: 0x006D6614 File Offset: 0x006D4814
		Public Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num3 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column16").Value))

						If flag Then
							Dim num2 As Double
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column16").Value))
						End If
						Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						If flag2 Then
							num3 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.TextBox2.Text = Conversions.ToString(num3)
				Me.lblNoOfItems.Text = "No.of Items : " + Conversions.ToString(Me.dgw.Rows.Count)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text), 3), "0.000")
		End Sub

		' Token: 0x0600988A RID: 39050 RVA: 0x006D67CC File Offset: 0x006D49CC
		Private Sub frmCurrentStock_Load(sender As Object, e As EventArgs)
			frmCurrentStock.DoubleBuffered(Me.dgw, True)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600988B RID: 39051 RVA: 0x006D685C File Offset: 0x006D4A5C
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) as default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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
						Me.UpdateDataGridViewHeaders(Me.dgw, GlobalVariables.translations)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600988C RID: 39052 RVA: 0x006D69DC File Offset: 0x006D4BDC
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
				End If
			End If
			Dim flag3 As Boolean = TypeOf ctrl Is TabControl
			If flag3 Then
				Dim tabControl As TabControl = CType(ctrl, TabControl)
				Try
					For Each obj As Object In tabControl.TabPages
						Dim tabPage As TabPage = CType(obj, TabPage)
						Dim text2 As String = tabPage.Text
						Dim flag4 As Boolean = translations.ContainsKey(text2)
						If flag4 Then
							tabPage.Text = translations(text2)
						End If
						Try
							For Each obj2 As Object In tabPage.Controls
								Dim control As Control = CType(obj2, Control)
								Me.UpdateAllControls(control, translations)
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End If
			Dim flag5 As Boolean = TypeOf ctrl Is MenuStrip
			If flag5 Then
				Dim menuStrip As MenuStrip = CType(ctrl, MenuStrip)
				Try
					For Each obj3 As Object In menuStrip.Items
						Dim toolStripMenuItem As ToolStripMenuItem = CType(obj3, ToolStripMenuItem)
						Me.UpdateMenuItems(toolStripMenuItem, translations)
					Next
				Finally
					Dim enumerator3 As IEnumerator
					If TypeOf enumerator3 Is IDisposable Then
						TryCast(enumerator3, IDisposable).Dispose()
					End If
				End Try
			End If
			Try
				For Each obj4 As Object In ctrl.Controls
					Dim control2 As Control = CType(obj4, Control)
					Me.UpdateAllControls(control2, translations)
				Next
			Finally
				Dim enumerator4 As IEnumerator
				If TypeOf enumerator4 Is IDisposable Then
					TryCast(enumerator4, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600988D RID: 39053 RVA: 0x00208B7C File Offset: 0x00206D7C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView, translations As Dictionary(Of String, String))
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600988E RID: 39054 RVA: 0x006D6C14 File Offset: 0x006D4E14
		Private Sub UpdateMenuItems(menuItem As ToolStripMenuItem, translations As Dictionary(Of String, String))
			Dim text As String = menuItem.Text
			Dim flag As Boolean = translations.ContainsKey(text)
			If flag Then
				menuItem.Text = translations(text)
			End If
			Try
				For Each toolStripMenuItem As ToolStripMenuItem In menuItem.DropDownItems.OfType(Of ToolStripMenuItem)()
					Me.UpdateMenuItems(toolStripMenuItem, translations)
				Next
			Finally
				Dim enumerator As IEnumerator(Of ToolStripMenuItem)
				If enumerator IsNot Nothing Then
					enumerator.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600988F RID: 39055 RVA: 0x001B3140 File Offset: 0x001B1340
		Public Shared Sub DoubleBuffered(dgw As DataGridView, setting As Boolean)
			Dim type As Type = dgw.[GetType]()
			Dim [property] As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
			[property].SetValue(dgw, setting, Nothing)
		End Sub

		' Token: 0x06009890 RID: 39056 RVA: 0x006D6C94 File Offset: 0x006D4E94
		Private Sub frmCurrentStock_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F1
			If flag3 Then
				e.Handled = True
				Me.btnShowAll.PerformClick()
				Me.dgw.Focus()
			End If
		End Sub

		' Token: 0x06009891 RID: 39057 RVA: 0x006D6D10 File Offset: 0x006D4F10
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Me.chkMfg.Checked > False) Xor Not Me.chkExp.Checked
			If flag Then
				MessageBox.Show("Please select search type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Try
					Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
					Me.dgw.RowHeadersVisible = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim checked As Boolean = Me.chkMfg.Checked
					If checked Then
						Dim flag2 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag2 Then
							Me.dgw.Rows.Clear()
							Dim text As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Mfgdate > '' and Convert(Datetime,Temp_Stock.Mfgdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Mfgdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
							Me.dgw.Rows.Clear()
							While ModCommonClasses.rdr.Read()
								Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
							End While
						Else
							Dim checked2 As Boolean = Me.chkBoxZeroQty.Checked
							If checked2 Then
								Me.dgw.Rows.Clear()
								Dim text2 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),,(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Mfgdate > '' and Convert(Datetime,Temp_Stock.Mfgdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Mfgdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
								Me.dgw.Rows.Clear()
								While ModCommonClasses.rdr.Read()
									Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
								End While
							End If
						End If
					End If
					Dim checked3 As Boolean = Me.chkExp.Checked
					If checked3 Then
						Dim flag3 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag3 Then
							Me.dgw.Rows.Clear()
							Dim text3 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),,(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
							ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
							Me.dgw.Rows.Clear()
							While ModCommonClasses.rdr.Read()
								Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
							End While
						Else
							Dim checked4 As Boolean = Me.chkBoxZeroQty.Checked
							If checked4 Then
								Me.dgw.Rows.Clear()
								Dim text4 As String = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Expdate > '' and Convert(Datetime,Temp_Stock.Expdate,103) >=@d1 and Convert(Datetime,Temp_Stock.Expdate,103) < @d2 order by ProductName"
								ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
								Me.dgw.Rows.Clear()
								While ModCommonClasses.rdr.Read()
									Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
								End While
							End If
						End If
					End If
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
					Dim num As Integer = Me.dgw.RowCount - 1
					For i As Integer = 0 To num
						Dim flag4 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
						If flag4 Then
							Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
							Dim flag5 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
							If flag5 Then
								Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
							End If
						End If
					Next
					Me.Calculate()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06009892 RID: 39058 RVA: 0x006D7C24 File Offset: 0x006D5E24
		Private Sub chkMfg_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMfg.Checked
			If checked Then
				Me.chkExp.Checked = False
			End If
		End Sub

		' Token: 0x06009893 RID: 39059 RVA: 0x006D7C50 File Offset: 0x006D5E50
		Private Sub chkExp_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkExp.Checked
			If checked Then
				Me.chkMfg.Checked = False
			End If
		End Sub

		' Token: 0x06009894 RID: 39060 RVA: 0x006D7C7C File Offset: 0x006D5E7C
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.cmbSearchType.SelectedIndex = 0
					If flag2 Then
						Dim flag3 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and ProductName like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked As Boolean = Me.chkBoxZeroQty.Checked
							If checked Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and ProductName like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag4 As Boolean = Me.cmbSearchType.SelectedIndex = 1
					If flag4 Then
						Dim flag5 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag5 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Barcode like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked2 As Boolean = Me.chkBoxZeroQty.Checked
							If checked2 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag6 As Boolean = Me.cmbSearchType.SelectedIndex = 2
					If flag6 Then
						Dim flag7 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag7 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Category like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked3 As Boolean = Me.chkBoxZeroQty.Checked
							If checked3 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Category like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag8 As Boolean = Me.cmbSearchType.SelectedIndex = 3
					If flag8 Then
						Dim flag9 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag9 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and SubCategoryName like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked4 As Boolean = Me.chkBoxZeroQty.Checked
							If checked4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and SubCategoryName like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag10 As Boolean = Me.cmbSearchType.SelectedIndex = 4
					If flag10 Then
						Dim flag11 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag11 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and PartNo like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked5 As Boolean = Me.chkBoxZeroQty.Checked
							If checked5 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and PartNo like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag12 As Boolean = Me.cmbSearchType.SelectedIndex = 5
					If flag12 Then
						Dim flag13 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag13 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.GDown like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked6 As Boolean = Me.chkBoxZeroQty.Checked
							If checked6 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.GDown like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag14 As Boolean = Me.cmbSearchType.SelectedIndex = 6
					If flag14 Then
						Dim flag15 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag15 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Rack like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked7 As Boolean = Me.chkBoxZeroQty.Checked
							If checked7 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Rack like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag16 As Boolean = Me.cmbSearchType.SelectedIndex = 7
					If flag16 Then
						Dim flag17 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag17 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Batch like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked8 As Boolean = Me.chkBoxZeroQty.Checked
							If checked8 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Batch like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag18 As Boolean = Me.cmbSearchType.SelectedIndex = 8
					If flag18 Then
						Dim flag19 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag19 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Size like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked9 As Boolean = Me.chkBoxZeroQty.Checked
							If checked9 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Size like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag20 As Boolean = Me.cmbSearchType.SelectedIndex = 9
					If flag20 Then
						Dim flag21 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag21 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Colour like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked10 As Boolean = Me.chkBoxZeroQty.Checked
							If checked10 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Colour like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag22 As Boolean = Me.cmbSearchType.SelectedIndex = 10
					If flag22 Then
						Dim flag23 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag23 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.IMEI1 like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked11 As Boolean = Me.chkBoxZeroQty.Checked
							If checked11 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.IMEI1 like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					Dim flag24 As Boolean = Me.cmbSearchType.SelectedIndex = 11
					If flag24 Then
						Dim flag25 As Boolean = Not Me.chkBoxZeroQty.Checked
						If flag25 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.IMEI2 like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						Else
							Dim checked12 As Boolean = Me.chkBoxZeroQty.Checked
							If checked12 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Temp_Stock.MRP),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),(Qty - Damage), Damage, RTRIM(Product.Description),RTRIM(Product.MinStock),RTRIM(Product.STax),RTRIM(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),(Temp_Stock.EPPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.IMEI2 like N'" + Me.TextBox1.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
							End If
						End If
					End If
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
					Dim num As Integer = Me.dgw.RowCount - 1
					For i As Integer = 0 To num
						Dim flag26 As Boolean = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Me.dgw.Rows(i).Cells(29).Value, Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing), 0, False)
						If flag26 Then
							Dim dateTime As DateTime = DateTime.ParseExact(Conversions.ToString(Me.dgw.Rows(i).Cells(29).Value), "dd/MM/yyyy", Nothing)
							Dim flag27 As Boolean = DateTime.Compare(dateTime, DateAndTime.Today) <= 0
							If flag27 Then
								Me.dgw.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
							End If
						End If
					Next
					Me.Calculate()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009895 RID: 39061 RVA: 0x0004A915 File Offset: 0x00048B15
		Private Sub cmbSearchType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
			Me.TextBox1.Text = ""
		End Sub

		' Token: 0x06009896 RID: 39062 RVA: 0x006D8754 File Offset: 0x006D6954
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmScreenlock.txtuser.Text = "sadmin"
			MyProject.Forms.frmScreenlock.Label2.Text = "Security Checked"
			MyProject.Forms.frmScreenlock.ShowDialog()
			MyProject.Forms.frmScreenlock.Dispose()
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
			If flag Then
				Me.Cursor = Cursors.WaitCursor
				Dim fileName As String = openFileDialog.FileName
				Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
				Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Export File$]", oleDbConnection)
				oleDbConnection.Open()
				ModCommonClasses.dtable = New DataTable()
				oleDbDataAdapter.Fill(ModCommonClasses.dtable)
				Dim flag2 As Boolean = MessageBox.Show("Successfully Saved" & vbCrLf & "Are you sure, do you want to insert in Temp Stock?", "Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Try
								Dim text As String = dataRow(0).ToString()
								Dim text2 As String = dataRow(0).ToString()
								Dim text3 As String = dataRow(12).ToString()
								Dim text4 As String = dataRow(5).ToString()
								Dim text5 As String = dataRow(7).ToString()
								Dim text6 As String = dataRow(14).ToString()
								Dim text7 As String = Conversions.ToString(0.0)
								Dim text8 As String = dataRow(15).ToString()
								Dim text9 As String = dataRow(25).ToString()
								Dim text10 As String = dataRow(26).ToString()
								Dim text11 As String = dataRow(27).ToString()
								Dim text12 As String = dataRow(28).ToString()
								Dim text13 As String = dataRow(29).ToString()
								Dim text14 As String = dataRow(7).ToString()
								Dim text15 As String = dataRow(14).ToString()
								Dim text16 As String = dataRow(30).ToString()
								Dim text17 As String = dataRow(31).ToString()
								Dim text18 As String = dataRow(6).ToString()
								Dim text19 As String = dataRow(35).ToString()
								Dim flag3 As Boolean = Operators.CompareString(text, "", False) = 0
								If flag3 Then
									MessageBox.Show("ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Return
								End If
								Dim flag4 As Boolean = Operators.CompareString(text4, "", False) = 0
								If flag4 Then
									MessageBox.Show("Barcode Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Return
								End If
								Try
									Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
										sqlConnection.Open()
										Dim text20 As String = "select Barcode from Temp_Stock Where Barcode=@d1"
										Using sqlCommand As SqlCommand = New SqlCommand(text20, sqlConnection)
											sqlCommand.Parameters.AddWithValue("@d1", text4)
											Dim num As Integer = Conversions.ToInteger(sqlCommand.ExecuteScalar())
											Dim flag5 As Boolean = num > 0
											If flag5 Then
												MessageBox.Show("Barcode '" + text4 + "' Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Return
											End If
											Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag6 Then
												ModCommonClasses.rdr.Close()
											End If
										End Using
									End Using
								Catch ex As Exception
									Console.WriteLine("Error: " + ex.Message)
								End Try
								SqlConnection.ClearAllPools()
								Me.Generate_GiftQR(text4)
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text21 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)"
								ModCommonClasses.cmd = New SqlCommand(text21)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", text4)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(text5))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(text6))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(0.0))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(text8))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", text9)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", text10)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", text11)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", text12)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", text13)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Opening Stock")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", text16)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", text17)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(text18))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(text19))
								Dim memoryStream As MemoryStream = New MemoryStream()
								Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap.Save(memoryStream, ImageFormat.Jpeg)
								Dim buffer As Byte() = memoryStream.GetBuffer()
								Dim sqlParameter As SqlParameter = New SqlParameter("@d20", SqlDbType.Image)
								sqlParameter.Value = buffer
								ModCommonClasses.cmd.Parameters.Add(sqlParameter)
								ModCommonClasses.cmd.CommandTimeout = 0
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text22 As String = "select ProductID from StockMovement where ProductID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text22)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.CommandTimeout = 0
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(text))
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag7 As Boolean = Not ModCommonClasses.rdr.Read()
								If flag7 Then
									ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(text))), 0D, New Decimal(Conversion.Val(text3)), 0D, DateAndTime.Today, text2)
								Else
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text23 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
									ModCommonClasses.cmd = New SqlCommand(text23)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
									ModCommonClasses.cmd.CommandTimeout = 0
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
									Dim num2 As Double
									If flag8 Then
										num2 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
									Else
										num2 = 0.0
									End If
									ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(text))), New Decimal(num2), New Decimal(Conversion.Val(text3)), 0D, DateAndTime.Today, text2)
								End If
							Catch ex2 As Exception
							End Try
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				End If
				MessageBox.Show("Successfully imported")
			End If
		End Sub

		' Token: 0x06009897 RID: 39063 RVA: 0x006D9050 File Offset: 0x006D7250
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub
	End Class
End Namespace
