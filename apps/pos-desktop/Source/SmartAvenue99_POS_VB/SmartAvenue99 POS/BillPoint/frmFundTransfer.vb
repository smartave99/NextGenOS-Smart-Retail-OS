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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000311 RID: 785
	<DesignerGenerated()>
	Public Partial Class frmFundTransfer
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BAD3 RID: 47827 RVA: 0x0005392D File Offset: 0x00051B2D
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmFundTransfer_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmFundTransfer_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004A76 RID: 19062
		' (get) Token: 0x0600BAD6 RID: 47830 RVA: 0x0005395F File Offset: 0x00051B5F
		' (set) Token: 0x0600BAD7 RID: 47831 RVA: 0x00053969 File Offset: 0x00051B69
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004A77 RID: 19063
		' (get) Token: 0x0600BAD8 RID: 47832 RVA: 0x00053972 File Offset: 0x00051B72
		' (set) Token: 0x0600BAD9 RID: 47833 RVA: 0x0005397C File Offset: 0x00051B7C
		Friend Overridable Property Label3 As Label

		' Token: 0x17004A78 RID: 19064
		' (get) Token: 0x0600BADA RID: 47834 RVA: 0x00053985 File Offset: 0x00051B85
		' (set) Token: 0x0600BADB RID: 47835 RVA: 0x0005398F File Offset: 0x00051B8F
		Friend Overridable Property txtBranchName As TextBox

		' Token: 0x17004A79 RID: 19065
		' (get) Token: 0x0600BADC RID: 47836 RVA: 0x00053998 File Offset: 0x00051B98
		' (set) Token: 0x0600BADD RID: 47837 RVA: 0x000539A2 File Offset: 0x00051BA2
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004A7A RID: 19066
		' (get) Token: 0x0600BADE RID: 47838 RVA: 0x000539AB File Offset: 0x00051BAB
		' (set) Token: 0x0600BADF RID: 47839 RVA: 0x000539B5 File Offset: 0x00051BB5
		Friend Overridable Property Label1 As Label

		' Token: 0x17004A7B RID: 19067
		' (get) Token: 0x0600BAE0 RID: 47840 RVA: 0x000539BE File Offset: 0x00051BBE
		' (set) Token: 0x0600BAE1 RID: 47841 RVA: 0x000539C8 File Offset: 0x00051BC8
		Friend Overridable Property Label7 As Label

		' Token: 0x17004A7C RID: 19068
		' (get) Token: 0x0600BAE2 RID: 47842 RVA: 0x000539D1 File Offset: 0x00051BD1
		' (set) Token: 0x0600BAE3 RID: 47843 RVA: 0x000539DB File Offset: 0x00051BDB
		Friend Overridable Property Label6 As Label

		' Token: 0x17004A7D RID: 19069
		' (get) Token: 0x0600BAE4 RID: 47844 RVA: 0x000539E4 File Offset: 0x00051BE4
		' (set) Token: 0x0600BAE5 RID: 47845 RVA: 0x000539EE File Offset: 0x00051BEE
		Friend Overridable Property txtIFSCCode As TextBox

		' Token: 0x17004A7E RID: 19070
		' (get) Token: 0x0600BAE6 RID: 47846 RVA: 0x000539F7 File Offset: 0x00051BF7
		' (set) Token: 0x0600BAE7 RID: 47847 RVA: 0x00053A01 File Offset: 0x00051C01
		Friend Overridable Property txtSwiftCode As TextBox

		' Token: 0x17004A7F RID: 19071
		' (get) Token: 0x0600BAE8 RID: 47848 RVA: 0x00053A0A File Offset: 0x00051C0A
		' (set) Token: 0x0600BAE9 RID: 47849 RVA: 0x00053A14 File Offset: 0x00051C14
		Friend Overridable Property lblUser As Label

		' Token: 0x17004A80 RID: 19072
		' (get) Token: 0x0600BAEA RID: 47850 RVA: 0x00053A1D File Offset: 0x00051C1D
		' (set) Token: 0x0600BAEB RID: 47851 RVA: 0x00053A27 File Offset: 0x00051C27
		Friend Overridable Property Label14 As Label

		' Token: 0x17004A81 RID: 19073
		' (get) Token: 0x0600BAEC RID: 47852 RVA: 0x00053A30 File Offset: 0x00051C30
		' (set) Token: 0x0600BAED RID: 47853 RVA: 0x00053A3A File Offset: 0x00051C3A
		Friend Overridable Property txtBank As TextBox

		' Token: 0x17004A82 RID: 19074
		' (get) Token: 0x0600BAEE RID: 47854 RVA: 0x00053A43 File Offset: 0x00051C43
		' (set) Token: 0x0600BAEF RID: 47855 RVA: 0x00053A4D File Offset: 0x00051C4D
		Friend Overridable Property Label5 As Label

		' Token: 0x17004A83 RID: 19075
		' (get) Token: 0x0600BAF0 RID: 47856 RVA: 0x00053A56 File Offset: 0x00051C56
		' (set) Token: 0x0600BAF1 RID: 47857 RVA: 0x00053A60 File Offset: 0x00051C60
		Friend Overridable Property Label12 As Label

		' Token: 0x17004A84 RID: 19076
		' (get) Token: 0x0600BAF2 RID: 47858 RVA: 0x00053A69 File Offset: 0x00051C69
		' (set) Token: 0x0600BAF3 RID: 47859 RVA: 0x00053A73 File Offset: 0x00051C73
		Friend Overridable Property txtAccountName As TextBox

		' Token: 0x17004A85 RID: 19077
		' (get) Token: 0x0600BAF4 RID: 47860 RVA: 0x00053A7C File Offset: 0x00051C7C
		' (set) Token: 0x0600BAF5 RID: 47861 RVA: 0x007849B4 File Offset: 0x00782BB4
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A86 RID: 19078
		' (get) Token: 0x0600BAF6 RID: 47862 RVA: 0x00053A86 File Offset: 0x00051C86
		' (set) Token: 0x0600BAF7 RID: 47863 RVA: 0x00053A90 File Offset: 0x00051C90
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004A87 RID: 19079
		' (get) Token: 0x0600BAF8 RID: 47864 RVA: 0x00053A99 File Offset: 0x00051C99
		' (set) Token: 0x0600BAF9 RID: 47865 RVA: 0x00053AA3 File Offset: 0x00051CA3
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17004A88 RID: 19080
		' (get) Token: 0x0600BAFA RID: 47866 RVA: 0x00053AAC File Offset: 0x00051CAC
		' (set) Token: 0x0600BAFB RID: 47867 RVA: 0x00053AB6 File Offset: 0x00051CB6
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004A89 RID: 19081
		' (get) Token: 0x0600BAFC RID: 47868 RVA: 0x00053ABF File Offset: 0x00051CBF
		' (set) Token: 0x0600BAFD RID: 47869 RVA: 0x00053AC9 File Offset: 0x00051CC9
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004A8A RID: 19082
		' (get) Token: 0x0600BAFE RID: 47870 RVA: 0x00053AD2 File Offset: 0x00051CD2
		' (set) Token: 0x0600BAFF RID: 47871 RVA: 0x00784A14 File Offset: 0x00782C14
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A8B RID: 19083
		' (get) Token: 0x0600BB00 RID: 47872 RVA: 0x00053ADC File Offset: 0x00051CDC
		' (set) Token: 0x0600BB01 RID: 47873 RVA: 0x00784A74 File Offset: 0x00782C74
		Private _txtAmount As TextBox
		Friend Overridable Property txtAmount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAmount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtAmount_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAmount_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAmount = value
				textBox = Me._txtAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A8C RID: 19084
		' (get) Token: 0x0600BB02 RID: 47874 RVA: 0x00053AE6 File Offset: 0x00051CE6
		' (set) Token: 0x0600BB03 RID: 47875 RVA: 0x00053AF0 File Offset: 0x00051CF0
		Friend Overridable Property Label2 As Label

		' Token: 0x17004A8D RID: 19085
		' (get) Token: 0x0600BB04 RID: 47876 RVA: 0x00053AF9 File Offset: 0x00051CF9
		' (set) Token: 0x0600BB05 RID: 47877 RVA: 0x00784AF0 File Offset: 0x00782CF0
		Private _txtNotes As TextBox
		Friend Overridable Property txtNotes As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNotes
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNotes_KeyDown
				Dim textBox As TextBox = Me._txtNotes
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNotes = value
				textBox = Me._txtNotes
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A8E RID: 19086
		' (get) Token: 0x0600BB06 RID: 47878 RVA: 0x00053B03 File Offset: 0x00051D03
		' (set) Token: 0x0600BB07 RID: 47879 RVA: 0x00053B0D File Offset: 0x00051D0D
		Friend Overridable Property Label8 As Label

		' Token: 0x17004A8F RID: 19087
		' (get) Token: 0x0600BB08 RID: 47880 RVA: 0x00053B16 File Offset: 0x00051D16
		' (set) Token: 0x0600BB09 RID: 47881 RVA: 0x00053B20 File Offset: 0x00051D20
		Friend Overridable Property Label10 As Label

		' Token: 0x17004A90 RID: 19088
		' (get) Token: 0x0600BB0A RID: 47882 RVA: 0x00053B29 File Offset: 0x00051D29
		' (set) Token: 0x0600BB0B RID: 47883 RVA: 0x00053B33 File Offset: 0x00051D33
		Friend Overridable Property txtOperator As TextBox

		' Token: 0x17004A91 RID: 19089
		' (get) Token: 0x0600BB0C RID: 47884 RVA: 0x00053B3C File Offset: 0x00051D3C
		' (set) Token: 0x0600BB0D RID: 47885 RVA: 0x00053B46 File Offset: 0x00051D46
		Friend Overridable Property Label11 As Label

		' Token: 0x17004A92 RID: 19090
		' (get) Token: 0x0600BB0E RID: 47886 RVA: 0x00053B4F File Offset: 0x00051D4F
		' (set) Token: 0x0600BB0F RID: 47887 RVA: 0x00784B34 File Offset: 0x00782D34
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbAccountNo_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A93 RID: 19091
		' (get) Token: 0x0600BB10 RID: 47888 RVA: 0x00053B59 File Offset: 0x00051D59
		' (set) Token: 0x0600BB11 RID: 47889 RVA: 0x00053B63 File Offset: 0x00051D63
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17004A94 RID: 19092
		' (get) Token: 0x0600BB12 RID: 47890 RVA: 0x00053B6C File Offset: 0x00051D6C
		' (set) Token: 0x0600BB13 RID: 47891 RVA: 0x00053B76 File Offset: 0x00051D76
		Friend Overridable Property DateTo As DateTimePicker

		' Token: 0x17004A95 RID: 19093
		' (get) Token: 0x0600BB14 RID: 47892 RVA: 0x00053B7F File Offset: 0x00051D7F
		' (set) Token: 0x0600BB15 RID: 47893 RVA: 0x00053B89 File Offset: 0x00051D89
		Friend Overridable Property DateFrom As DateTimePicker

		' Token: 0x17004A96 RID: 19094
		' (get) Token: 0x0600BB16 RID: 47894 RVA: 0x00053B92 File Offset: 0x00051D92
		' (set) Token: 0x0600BB17 RID: 47895 RVA: 0x00053B9C File Offset: 0x00051D9C
		Friend Overridable Property Label4 As Label

		' Token: 0x17004A97 RID: 19095
		' (get) Token: 0x0600BB18 RID: 47896 RVA: 0x00053BA5 File Offset: 0x00051DA5
		' (set) Token: 0x0600BB19 RID: 47897 RVA: 0x00053BAF File Offset: 0x00051DAF
		Friend Overridable Property label9 As Label

		' Token: 0x17004A98 RID: 19096
		' (get) Token: 0x0600BB1A RID: 47898 RVA: 0x00053BB8 File Offset: 0x00051DB8
		' (set) Token: 0x0600BB1B RID: 47899 RVA: 0x00053BC2 File Offset: 0x00051DC2
		Friend Overridable Property groupBox5 As GroupBox

		' Token: 0x17004A99 RID: 19097
		' (get) Token: 0x0600BB1C RID: 47900 RVA: 0x00053BCB File Offset: 0x00051DCB
		' (set) Token: 0x0600BB1D RID: 47901 RVA: 0x00784BB0 File Offset: 0x00782DB0
		Private _txtAccNo As TextBox
		Friend Overridable Property txtAccNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAccNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtAccNo_TextChanged
				Dim textBox As TextBox = Me._txtAccNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtAccNo = value
				textBox = Me._txtAccNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A9A RID: 19098
		' (get) Token: 0x0600BB1E RID: 47902 RVA: 0x00053BD5 File Offset: 0x00051DD5
		' (set) Token: 0x0600BB1F RID: 47903 RVA: 0x00053BDF File Offset: 0x00051DDF
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004A9B RID: 19099
		' (get) Token: 0x0600BB20 RID: 47904 RVA: 0x00053BE8 File Offset: 0x00051DE8
		' (set) Token: 0x0600BB21 RID: 47905 RVA: 0x00053BF2 File Offset: 0x00051DF2
		Friend Overridable Property GroupBox6 As GroupBox

		' Token: 0x17004A9C RID: 19100
		' (get) Token: 0x0600BB22 RID: 47906 RVA: 0x00053BFB File Offset: 0x00051DFB
		' (set) Token: 0x0600BB23 RID: 47907 RVA: 0x00053C05 File Offset: 0x00051E05
		Friend Overridable Property txtBank1 As TextBox

		' Token: 0x17004A9D RID: 19101
		' (get) Token: 0x0600BB24 RID: 47908 RVA: 0x00053C0E File Offset: 0x00051E0E
		' (set) Token: 0x0600BB25 RID: 47909 RVA: 0x00784BF4 File Offset: 0x00782DF4
		Private _cmbAccountNo1 As ComboBox
		Friend Overridable Property cmbAccountNo1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbAccountNo1_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo1_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbAccountNo1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbAccountNo1 = value
				comboBox = Me._cmbAccountNo1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A9E RID: 19102
		' (get) Token: 0x0600BB26 RID: 47910 RVA: 0x00053C18 File Offset: 0x00051E18
		' (set) Token: 0x0600BB27 RID: 47911 RVA: 0x00053C22 File Offset: 0x00051E22
		Friend Overridable Property Label13 As Label

		' Token: 0x17004A9F RID: 19103
		' (get) Token: 0x0600BB28 RID: 47912 RVA: 0x00053C2B File Offset: 0x00051E2B
		' (set) Token: 0x0600BB29 RID: 47913 RVA: 0x00053C35 File Offset: 0x00051E35
		Friend Overridable Property Label15 As Label

		' Token: 0x17004AA0 RID: 19104
		' (get) Token: 0x0600BB2A RID: 47914 RVA: 0x00053C3E File Offset: 0x00051E3E
		' (set) Token: 0x0600BB2B RID: 47915 RVA: 0x00053C48 File Offset: 0x00051E48
		Friend Overridable Property txtSwiftCode1 As TextBox

		' Token: 0x17004AA1 RID: 19105
		' (get) Token: 0x0600BB2C RID: 47916 RVA: 0x00053C51 File Offset: 0x00051E51
		' (set) Token: 0x0600BB2D RID: 47917 RVA: 0x00053C5B File Offset: 0x00051E5B
		Friend Overridable Property txtIFSCCode1 As TextBox

		' Token: 0x17004AA2 RID: 19106
		' (get) Token: 0x0600BB2E RID: 47918 RVA: 0x00053C64 File Offset: 0x00051E64
		' (set) Token: 0x0600BB2F RID: 47919 RVA: 0x00053C6E File Offset: 0x00051E6E
		Friend Overridable Property Label16 As Label

		' Token: 0x17004AA3 RID: 19107
		' (get) Token: 0x0600BB30 RID: 47920 RVA: 0x00053C77 File Offset: 0x00051E77
		' (set) Token: 0x0600BB31 RID: 47921 RVA: 0x00053C81 File Offset: 0x00051E81
		Friend Overridable Property txtBranchName1 As TextBox

		' Token: 0x17004AA4 RID: 19108
		' (get) Token: 0x0600BB32 RID: 47922 RVA: 0x00053C8A File Offset: 0x00051E8A
		' (set) Token: 0x0600BB33 RID: 47923 RVA: 0x00053C94 File Offset: 0x00051E94
		Friend Overridable Property Label17 As Label

		' Token: 0x17004AA5 RID: 19109
		' (get) Token: 0x0600BB34 RID: 47924 RVA: 0x00053C9D File Offset: 0x00051E9D
		' (set) Token: 0x0600BB35 RID: 47925 RVA: 0x00053CA7 File Offset: 0x00051EA7
		Friend Overridable Property Label18 As Label

		' Token: 0x17004AA6 RID: 19110
		' (get) Token: 0x0600BB36 RID: 47926 RVA: 0x00053CB0 File Offset: 0x00051EB0
		' (set) Token: 0x0600BB37 RID: 47927 RVA: 0x00053CBA File Offset: 0x00051EBA
		Friend Overridable Property txtAccountName1 As TextBox

		' Token: 0x17004AA7 RID: 19111
		' (get) Token: 0x0600BB38 RID: 47928 RVA: 0x00053CC3 File Offset: 0x00051EC3
		' (set) Token: 0x0600BB39 RID: 47929 RVA: 0x00053CCD File Offset: 0x00051ECD
		Friend Overridable Property Label19 As Label

		' Token: 0x17004AA8 RID: 19112
		' (get) Token: 0x0600BB3A RID: 47930 RVA: 0x00053CD6 File Offset: 0x00051ED6
		' (set) Token: 0x0600BB3B RID: 47931 RVA: 0x00053CE0 File Offset: 0x00051EE0
		Friend Overridable Property Label20 As Label

		' Token: 0x17004AA9 RID: 19113
		' (get) Token: 0x0600BB3C RID: 47932 RVA: 0x00053CE9 File Offset: 0x00051EE9
		' (set) Token: 0x0600BB3D RID: 47933 RVA: 0x00053CF3 File Offset: 0x00051EF3
		Friend Overridable Property txtBalanceAmount As TextBox

		' Token: 0x17004AAA RID: 19114
		' (get) Token: 0x0600BB3E RID: 47934 RVA: 0x00053CFC File Offset: 0x00051EFC
		' (set) Token: 0x0600BB3F RID: 47935 RVA: 0x00053D06 File Offset: 0x00051F06
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004AAB RID: 19115
		' (get) Token: 0x0600BB40 RID: 47936 RVA: 0x00053D0F File Offset: 0x00051F0F
		' (set) Token: 0x0600BB41 RID: 47937 RVA: 0x00053D19 File Offset: 0x00051F19
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004AAC RID: 19116
		' (get) Token: 0x0600BB42 RID: 47938 RVA: 0x00053D22 File Offset: 0x00051F22
		' (set) Token: 0x0600BB43 RID: 47939 RVA: 0x00053D2C File Offset: 0x00051F2C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004AAD RID: 19117
		' (get) Token: 0x0600BB44 RID: 47940 RVA: 0x00053D35 File Offset: 0x00051F35
		' (set) Token: 0x0600BB45 RID: 47941 RVA: 0x00053D3F File Offset: 0x00051F3F
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004AAE RID: 19118
		' (get) Token: 0x0600BB46 RID: 47942 RVA: 0x00053D48 File Offset: 0x00051F48
		' (set) Token: 0x0600BB47 RID: 47943 RVA: 0x00053D52 File Offset: 0x00051F52
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004AAF RID: 19119
		' (get) Token: 0x0600BB48 RID: 47944 RVA: 0x00053D5B File Offset: 0x00051F5B
		' (set) Token: 0x0600BB49 RID: 47945 RVA: 0x00053D65 File Offset: 0x00051F65
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004AB0 RID: 19120
		' (get) Token: 0x0600BB4A RID: 47946 RVA: 0x00053D6E File Offset: 0x00051F6E
		' (set) Token: 0x0600BB4B RID: 47947 RVA: 0x00053D78 File Offset: 0x00051F78
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17004AB1 RID: 19121
		' (get) Token: 0x0600BB4C RID: 47948 RVA: 0x00053D81 File Offset: 0x00051F81
		' (set) Token: 0x0600BB4D RID: 47949 RVA: 0x00053D8B File Offset: 0x00051F8B
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17004AB2 RID: 19122
		' (get) Token: 0x0600BB4E RID: 47950 RVA: 0x00053D94 File Offset: 0x00051F94
		' (set) Token: 0x0600BB4F RID: 47951 RVA: 0x00053D9E File Offset: 0x00051F9E
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17004AB3 RID: 19123
		' (get) Token: 0x0600BB50 RID: 47952 RVA: 0x00053DA7 File Offset: 0x00051FA7
		' (set) Token: 0x0600BB51 RID: 47953 RVA: 0x00053DB1 File Offset: 0x00051FB1
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004AB4 RID: 19124
		' (get) Token: 0x0600BB52 RID: 47954 RVA: 0x00053DBA File Offset: 0x00051FBA
		' (set) Token: 0x0600BB53 RID: 47955 RVA: 0x00053DC4 File Offset: 0x00051FC4
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004AB5 RID: 19125
		' (get) Token: 0x0600BB54 RID: 47956 RVA: 0x00053DCD File Offset: 0x00051FCD
		' (set) Token: 0x0600BB55 RID: 47957 RVA: 0x00784C70 File Offset: 0x00782E70
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

		' Token: 0x17004AB6 RID: 19126
		' (get) Token: 0x0600BB56 RID: 47958 RVA: 0x00053DD7 File Offset: 0x00051FD7
		' (set) Token: 0x0600BB57 RID: 47959 RVA: 0x00784CB4 File Offset: 0x00782EB4
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

		' Token: 0x17004AB7 RID: 19127
		' (get) Token: 0x0600BB58 RID: 47960 RVA: 0x00053DE1 File Offset: 0x00051FE1
		' (set) Token: 0x0600BB59 RID: 47961 RVA: 0x00784CF8 File Offset: 0x00782EF8
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

		' Token: 0x17004AB8 RID: 19128
		' (get) Token: 0x0600BB5A RID: 47962 RVA: 0x00053DEB File Offset: 0x00051FEB
		' (set) Token: 0x0600BB5B RID: 47963 RVA: 0x00784D3C File Offset: 0x00782F3C
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AB9 RID: 19129
		' (get) Token: 0x0600BB5C RID: 47964 RVA: 0x00053DF5 File Offset: 0x00051FF5
		' (set) Token: 0x0600BB5D RID: 47965 RVA: 0x00784D80 File Offset: 0x00782F80
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004ABA RID: 19130
		' (get) Token: 0x0600BB5E RID: 47966 RVA: 0x00053DFF File Offset: 0x00051FFF
		' (set) Token: 0x0600BB5F RID: 47967 RVA: 0x00784DC4 File Offset: 0x00782FC4
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

		' Token: 0x0600BB60 RID: 47968 RVA: 0x00784E08 File Offset: 0x00783008
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM FundTransfer"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.txtID.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.txtID.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BB61 RID: 47969 RVA: 0x00053E09 File Offset: 0x00052009
		Public Sub Clear()
			Me.DateFrom.Value = DateAndTime.Today
			Me.DateTo.Value = DateAndTime.Today
			Me.txtAccNo.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600BB62 RID: 47970 RVA: 0x00784F0C File Offset: 0x0078310C
		Public Sub Reset()
			Me.txtOperator.Text = ""
			Me.txtAccountName.Text = ""
			Me.txtAccountName1.Text = ""
			Me.cmbAccountNo.SelectedIndex = -1
			Me.cmbAccountNo1.SelectedIndex = -1
			Me.txtAmount.Text = ""
			Me.dtpDate.Value = DateAndTime.Today
			Me.txtNotes.Text = ""
			Me.txtIFSCCode.Text = ""
			Me.txtSwiftCode.Text = ""
			Me.txtBranchName.Text = ""
			Me.txtBank.Text = ""
			Me.txtIFSCCode1.Text = ""
			Me.txtSwiftCode1.Text = ""
			Me.txtBranchName1.Text = ""
			Me.txtBalanceAmount.Text = ""
			Me.txtBank1.Text = ""
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.txtOperator.Text = Me.lblUser.Text
			Me.txtAmount.Focus()
			Me.Clear()
			Me.auto()
		End Sub

		' Token: 0x0600BB63 RID: 47971 RVA: 0x00785080 File Offset: 0x00783280
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT FundTransfer.Id, RTRIM(Operator), Amount, FundTransfer.Date, RTRIM(FundTransfer.Notes),RTRIM(AccountTransFrom), RTRIM(AccountTransTo) from FundTransfer order by Date", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BB64 RID: 47972 RVA: 0x007851BC File Offset: 0x007833BC
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from FundTransfer where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					Dim text2 As String = "Deleted the fund Transfer record having Transaction ID '" + Me.txtID.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					ModFunc.BankAccountLedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund To Transfer")
					ModFunc.BankAccountLedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund By Transfer")
					ModFunc.LedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "To Transfer-Withdraw")
					ModFunc.LedgerDelete(Conversions.ToString(Conversion.Val(Me.txtID.Text)), "By Transfer-Diposit")
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

		' Token: 0x0600BB65 RID: 47973 RVA: 0x0078539C File Offset: 0x0078359C
		Private Sub cmbAccountNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode),IsNull(Sum(Credit)-Sum(Debit),0) from BankAccountRegistration LEFT JOIN BankBranch ON BankAccountRegistration.BranchID = BankBranch.Id LEFT JOIN BankAccountLedger ON BankAccountRegistration.AccountNo = BankAccountLedger.AccNo where AccountNo=@d1 group by AccountName,BankName,BranchName,SwiftCode,IFSCCode"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtAccountName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.txtBank.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtBranchName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtSwiftCode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtIFSCCode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
					Me.txtBalanceAmount.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(5))
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

		' Token: 0x0600BB66 RID: 47974 RVA: 0x00785548 File Offset: 0x00783748
		Public Sub fillAccountNo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbAccountNo.Items.Clear()
				Me.cmbAccountNo1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbAccountNo.Items.Add(dataRow(0).ToString())
						Me.cmbAccountNo1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600BB67 RID: 47975 RVA: 0x007856B8 File Offset: 0x007838B8
		Private Sub frmFundTransfer_Load(sender As Object, e As EventArgs)
			Me.FYSerrch()
			Me.fillAccountNo()
			Me.Getdata()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600BB68 RID: 47976 RVA: 0x00785750 File Offset: 0x00783950
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

		' Token: 0x0600BB69 RID: 47977 RVA: 0x007858C8 File Offset: 0x00783AC8
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

		' Token: 0x0600BB6A RID: 47978 RVA: 0x00785984 File Offset: 0x00783B84
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

		' Token: 0x0600BB6B RID: 47979 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600BB6C RID: 47980 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600BB6D RID: 47981 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600BB6E RID: 47982 RVA: 0x00785A50 File Offset: 0x00783C50
		Private Sub FYSerrch()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
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

		' Token: 0x0600BB6F RID: 47983 RVA: 0x00785B48 File Offset: 0x00783D48
		Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtAmount.Text
					Dim selectionStart As Integer = Me.txtAmount.SelectionStart
					Dim selectionLength As Integer = Me.txtAmount.SelectionLength
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

		' Token: 0x0600BB70 RID: 47984 RVA: 0x00785C40 File Offset: 0x00783E40
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

		' Token: 0x0600BB71 RID: 47985 RVA: 0x00785D28 File Offset: 0x00783F28
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtOperator.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtAmount.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.dtpDate.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtNotes.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.cmbAccountNo.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.cmbAccountNo1.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.btnSave.Enabled = False
					Me.btnDelete.Enabled = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BB72 RID: 47986 RVA: 0x00785E9C File Offset: 0x0078409C
		Private Sub txtAccNo_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT FundTransfer.Id, RTRIM(Operator), Amount, FundTransfer.Date, RTRIM(FundTransfer.Notes),RTRIM(AccountTransFrom), RTRIM(AccountTransTo) from FundTransfer where AccountTransFrom like N'%", Me.txtAccNo.Text, "%' or AccountTransTo like N'%", Me.txtAccNo.Text, "%' order by Date" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BB73 RID: 47987 RVA: 0x00786010 File Offset: 0x00784210
		Private Sub cmbAccountNo1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(AccountName),RTRIM(BankName),RTRIM(BranchName),RTRIM(SwiftCode),RTRIM(IFSCCode) from BankBranch,BankAccountRegistration where BankBranch.ID=BankAccountRegistration.BranchID and AccountNo=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbAccountNo1.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtAccountName1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.txtBank1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtBranchName1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtSwiftCode1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtIFSCCode1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
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

		' Token: 0x0600BB74 RID: 47988 RVA: 0x007861A0 File Offset: 0x007843A0
		Private Sub dtpDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600BB75 RID: 47989 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BB76 RID: 47990 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BB77 RID: 47991 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtNotes_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BB78 RID: 47992 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BB79 RID: 47993 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BB7A RID: 47994 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmFundTransfer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BB7B RID: 47995 RVA: 0x00786240 File Offset: 0x00784440
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtAmount.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAmount, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbAccountNo1.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbAccountNo1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbAccountNo1, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbAccountNo.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbAccountNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbAccountNo, String.Empty)
			End If
		End Sub

		' Token: 0x0600BB7C RID: 47996 RVA: 0x00053E46 File Offset: 0x00052046
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BB7D RID: 47997 RVA: 0x00786334 File Offset: 0x00784534
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtOperator.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter operator", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtOperator.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtAmount.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAmount.Focus()
					Else
						Dim flag5 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
						If flag5 Then
							MessageBox.Show("Amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtAmount.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.cmbAccountNo.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please select account no. from", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbAccountNo.Focus()
							Else
								Dim flag7 As Boolean = Operators.CompareString(Me.cmbAccountNo1.Text, "", False) = 0
								If flag7 Then
									MessageBox.Show("Please select account no. to", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbAccountNo1.Focus()
								Else
									Dim flag8 As Boolean = Conversion.Val(Me.txtBalanceAmount.Text) < Conversion.Val(Me.txtAmount.Text)
									If flag8 Then
										MessageBox.Show("Transferred Amount must be less than or equal to balance amount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.txtAmount.Focus()
									Else
										Dim flag9 As Boolean = Operators.CompareString(Me.cmbAccountNo.Text, Me.cmbAccountNo1.Text, False) = 0
										If flag9 Then
											MessageBox.Show("Both the accounts must be different", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Else
											Try
												Me.auto()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text2 As String = "insert into FundTransfer(Id, AccountTransFrom, AccountTransTo, Amount, Date, Operator, Notes) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
												ModCommonClasses.cmd = New SqlCommand(text2)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbAccountNo.Text)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbAccountNo1.Text)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtAmount.Text))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpDate.Value.[Date])
												ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtOperator.Text)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtNotes.Text)
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												Dim text3 As String = String.Concat(New String() { "added the new fund Transfer from account no. '", Me.cmbAccountNo.Text, "' to account no. '", Me.cmbAccountNo.Text, "' having Transaction ID '", Me.txtID.Text, "'" })
												ModFunc.LogFunc(Me.lblUser.Text, text3)
												ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund To Transfer", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D)
												ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo1.Text, Conversions.ToString(Conversion.Val(Me.txtID.Text)), "Fund By Transfer", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)))
												ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Conversions.ToString(Conversion.Val(Me.txtID.Text)), "To Transfer-Withdraw", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.cmbAccountNo.Text, Me.txtAccountName.Text)
												ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Conversions.ToString(Conversion.Val(Me.txtID.Text)), "By Transfer-Diposit", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.cmbAccountNo.Text, Me.txtAccountName1.Text)
												MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Me.btnSave.Enabled = False
												Me.Getdata()
											Catch ex As Exception
												MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											End Try
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BB7E RID: 47998 RVA: 0x00786974 File Offset: 0x00784B74
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

		' Token: 0x0600BB7F RID: 47999 RVA: 0x007869DC File Offset: 0x00784BDC
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT FundTransfer.Id, RTRIM(Operator), Amount, FundTransfer.Date, RTRIM(FundTransfer.Notes),RTRIM(AccountTransFrom), RTRIM(AccountTransTo) from FundTransfer where Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BB80 RID: 48000 RVA: 0x00786B8C File Offset: 0x00784D8C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView1.Columns
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
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
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

		' Token: 0x0600BB81 RID: 48001 RVA: 0x00053E50 File Offset: 0x00052050
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.Clear()
		End Sub
	End Class
End Namespace
