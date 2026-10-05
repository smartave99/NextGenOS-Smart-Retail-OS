Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000C3 RID: 195
	<DesignerGenerated()>
	Public Partial Class frmCustomerSupport1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001C8F RID: 7311 RVA: 0x00014AD7 File Offset: 0x00012CD7
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerSupport1_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerSupport1_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000B0F RID: 2831
		' (get) Token: 0x06001C92 RID: 7314 RVA: 0x00014B09 File Offset: 0x00012D09
		' (set) Token: 0x06001C93 RID: 7315 RVA: 0x00014B13 File Offset: 0x00012D13
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000B10 RID: 2832
		' (get) Token: 0x06001C94 RID: 7316 RVA: 0x00014B1C File Offset: 0x00012D1C
		' (set) Token: 0x06001C95 RID: 7317 RVA: 0x00014B26 File Offset: 0x00012D26
		Friend Overridable Property lblCustID As Label

		' Token: 0x17000B11 RID: 2833
		' (get) Token: 0x06001C96 RID: 7318 RVA: 0x00014B2F File Offset: 0x00012D2F
		' (set) Token: 0x06001C97 RID: 7319 RVA: 0x00014B39 File Offset: 0x00012D39
		Friend Overridable Property lblUser As Label

		' Token: 0x17000B12 RID: 2834
		' (get) Token: 0x06001C98 RID: 7320 RVA: 0x00014B42 File Offset: 0x00012D42
		' (set) Token: 0x06001C99 RID: 7321 RVA: 0x00014B4C File Offset: 0x00012D4C
		Friend Overridable Property Label1 As Label

		' Token: 0x17000B13 RID: 2835
		' (get) Token: 0x06001C9A RID: 7322 RVA: 0x00014B55 File Offset: 0x00012D55
		' (set) Token: 0x06001C9B RID: 7323 RVA: 0x00014B5F File Offset: 0x00012D5F
		Friend Overridable Property gbPartyInfo As GroupBox

		' Token: 0x17000B14 RID: 2836
		' (get) Token: 0x06001C9C RID: 7324 RVA: 0x00014B68 File Offset: 0x00012D68
		' (set) Token: 0x06001C9D RID: 7325 RVA: 0x001406B8 File Offset: 0x0013E8B8
		Private _cmbCustomerName As TextBox
		Friend Overridable Property cmbCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCustomerName_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCustomerName_KeyDown
				Dim textBox As TextBox = Me._cmbCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._cmbCustomerName = value
				textBox = Me._cmbCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000B15 RID: 2837
		' (get) Token: 0x06001C9E RID: 7326 RVA: 0x00014B72 File Offset: 0x00012D72
		' (set) Token: 0x06001C9F RID: 7327 RVA: 0x00014B7C File Offset: 0x00012D7C
		Friend Overridable Property Label10 As Label

		' Token: 0x17000B16 RID: 2838
		' (get) Token: 0x06001CA0 RID: 7328 RVA: 0x00014B85 File Offset: 0x00012D85
		' (set) Token: 0x06001CA1 RID: 7329 RVA: 0x00014B8F File Offset: 0x00012D8F
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17000B17 RID: 2839
		' (get) Token: 0x06001CA2 RID: 7330 RVA: 0x00014B98 File Offset: 0x00012D98
		' (set) Token: 0x06001CA3 RID: 7331 RVA: 0x00014BA2 File Offset: 0x00012DA2
		Friend Overridable Property lblBalance As Label

		' Token: 0x17000B18 RID: 2840
		' (get) Token: 0x06001CA4 RID: 7332 RVA: 0x00014BAB File Offset: 0x00012DAB
		' (set) Token: 0x06001CA5 RID: 7333 RVA: 0x00014BB5 File Offset: 0x00012DB5
		Friend Overridable Property Label11 As Label

		' Token: 0x17000B19 RID: 2841
		' (get) Token: 0x06001CA6 RID: 7334 RVA: 0x00014BBE File Offset: 0x00012DBE
		' (set) Token: 0x06001CA7 RID: 7335 RVA: 0x00140718 File Offset: 0x0013E918
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtContactNo_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000B1A RID: 2842
		' (get) Token: 0x06001CA8 RID: 7336 RVA: 0x00014BC8 File Offset: 0x00012DC8
		' (set) Token: 0x06001CA9 RID: 7337 RVA: 0x00014BD2 File Offset: 0x00012DD2
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x17000B1B RID: 2843
		' (get) Token: 0x06001CAA RID: 7338 RVA: 0x00014BDB File Offset: 0x00012DDB
		' (set) Token: 0x06001CAB RID: 7339 RVA: 0x00014BE5 File Offset: 0x00012DE5
		Friend Overridable Property Label26 As Label

		' Token: 0x17000B1C RID: 2844
		' (get) Token: 0x06001CAC RID: 7340 RVA: 0x00014BEE File Offset: 0x00012DEE
		' (set) Token: 0x06001CAD RID: 7341 RVA: 0x00014BF8 File Offset: 0x00012DF8
		Friend Overridable Property Label30 As Label

		' Token: 0x17000B1D RID: 2845
		' (get) Token: 0x06001CAE RID: 7342 RVA: 0x00014C01 File Offset: 0x00012E01
		' (set) Token: 0x06001CAF RID: 7343 RVA: 0x00014C0B File Offset: 0x00012E0B
		Friend Overridable Property Label36 As Label

		' Token: 0x17000B1E RID: 2846
		' (get) Token: 0x06001CB0 RID: 7344 RVA: 0x00014C14 File Offset: 0x00012E14
		' (set) Token: 0x06001CB1 RID: 7345 RVA: 0x00014C1E File Offset: 0x00012E1E
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000B1F RID: 2847
		' (get) Token: 0x06001CB2 RID: 7346 RVA: 0x00014C27 File Offset: 0x00012E27
		' (set) Token: 0x06001CB3 RID: 7347 RVA: 0x00140778 File Offset: 0x0013E978
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

		' Token: 0x17000B20 RID: 2848
		' (get) Token: 0x06001CB4 RID: 7348 RVA: 0x00014C31 File Offset: 0x00012E31
		' (set) Token: 0x06001CB5 RID: 7349 RVA: 0x00014C3B File Offset: 0x00012E3B
		Friend Overridable Property btnDelete As GelButton

		' Token: 0x17000B21 RID: 2849
		' (get) Token: 0x06001CB6 RID: 7350 RVA: 0x00014C44 File Offset: 0x00012E44
		' (set) Token: 0x06001CB7 RID: 7351 RVA: 0x001407BC File Offset: 0x0013E9BC
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

		' Token: 0x17000B22 RID: 2850
		' (get) Token: 0x06001CB8 RID: 7352 RVA: 0x00014C4E File Offset: 0x00012E4E
		' (set) Token: 0x06001CB9 RID: 7353 RVA: 0x00140800 File Offset: 0x0013EA00
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

		' Token: 0x17000B23 RID: 2851
		' (get) Token: 0x06001CBA RID: 7354 RVA: 0x00014C58 File Offset: 0x00012E58
		' (set) Token: 0x06001CBB RID: 7355 RVA: 0x00014C62 File Offset: 0x00012E62
		Friend Overridable Property txtIssue As RichTextBox

		' Token: 0x17000B24 RID: 2852
		' (get) Token: 0x06001CBC RID: 7356 RVA: 0x00014C6B File Offset: 0x00012E6B
		' (set) Token: 0x06001CBD RID: 7357 RVA: 0x00014C75 File Offset: 0x00012E75
		Friend Overridable Property Label12 As Label

		' Token: 0x17000B25 RID: 2853
		' (get) Token: 0x06001CBE RID: 7358 RVA: 0x00014C7E File Offset: 0x00012E7E
		' (set) Token: 0x06001CBF RID: 7359 RVA: 0x00140844 File Offset: 0x0013EA44
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000B26 RID: 2854
		' (get) Token: 0x06001CC0 RID: 7360 RVA: 0x00014C88 File Offset: 0x00012E88
		' (set) Token: 0x06001CC1 RID: 7361 RVA: 0x00014C92 File Offset: 0x00012E92
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17000B27 RID: 2855
		' (get) Token: 0x06001CC2 RID: 7362 RVA: 0x00014C9B File Offset: 0x00012E9B
		' (set) Token: 0x06001CC3 RID: 7363 RVA: 0x00014CA5 File Offset: 0x00012EA5
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17000B28 RID: 2856
		' (get) Token: 0x06001CC4 RID: 7364 RVA: 0x00014CAE File Offset: 0x00012EAE
		' (set) Token: 0x06001CC5 RID: 7365 RVA: 0x00014CB8 File Offset: 0x00012EB8
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17000B29 RID: 2857
		' (get) Token: 0x06001CC6 RID: 7366 RVA: 0x00014CC1 File Offset: 0x00012EC1
		' (set) Token: 0x06001CC7 RID: 7367 RVA: 0x00014CCB File Offset: 0x00012ECB
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000B2A RID: 2858
		' (get) Token: 0x06001CC8 RID: 7368 RVA: 0x00014CD4 File Offset: 0x00012ED4
		' (set) Token: 0x06001CC9 RID: 7369 RVA: 0x00014CDE File Offset: 0x00012EDE
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17000B2B RID: 2859
		' (get) Token: 0x06001CCA RID: 7370 RVA: 0x00014CE7 File Offset: 0x00012EE7
		' (set) Token: 0x06001CCB RID: 7371 RVA: 0x00014CF1 File Offset: 0x00012EF1
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17000B2C RID: 2860
		' (get) Token: 0x06001CCC RID: 7372 RVA: 0x00014CFA File Offset: 0x00012EFA
		' (set) Token: 0x06001CCD RID: 7373 RVA: 0x00014D04 File Offset: 0x00012F04
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000B2D RID: 2861
		' (get) Token: 0x06001CCE RID: 7374 RVA: 0x00014D0D File Offset: 0x00012F0D
		' (set) Token: 0x06001CCF RID: 7375 RVA: 0x00014D17 File Offset: 0x00012F17
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000B2E RID: 2862
		' (get) Token: 0x06001CD0 RID: 7376 RVA: 0x00014D20 File Offset: 0x00012F20
		' (set) Token: 0x06001CD1 RID: 7377 RVA: 0x00014D2A File Offset: 0x00012F2A
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000B2F RID: 2863
		' (get) Token: 0x06001CD2 RID: 7378 RVA: 0x00014D33 File Offset: 0x00012F33
		' (set) Token: 0x06001CD3 RID: 7379 RVA: 0x00014D3D File Offset: 0x00012F3D
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17000B30 RID: 2864
		' (get) Token: 0x06001CD4 RID: 7380 RVA: 0x00014D46 File Offset: 0x00012F46
		' (set) Token: 0x06001CD5 RID: 7381 RVA: 0x00014D50 File Offset: 0x00012F50
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000B31 RID: 2865
		' (get) Token: 0x06001CD6 RID: 7382 RVA: 0x00014D59 File Offset: 0x00012F59
		' (set) Token: 0x06001CD7 RID: 7383 RVA: 0x00014D63 File Offset: 0x00012F63
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000B32 RID: 2866
		' (get) Token: 0x06001CD8 RID: 7384 RVA: 0x00014D6C File Offset: 0x00012F6C
		' (set) Token: 0x06001CD9 RID: 7385 RVA: 0x00014D76 File Offset: 0x00012F76
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000B33 RID: 2867
		' (get) Token: 0x06001CDA RID: 7386 RVA: 0x00014D7F File Offset: 0x00012F7F
		' (set) Token: 0x06001CDB RID: 7387 RVA: 0x00014D89 File Offset: 0x00012F89
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000B34 RID: 2868
		' (get) Token: 0x06001CDC RID: 7388 RVA: 0x00014D92 File Offset: 0x00012F92
		' (set) Token: 0x06001CDD RID: 7389 RVA: 0x00014D9C File Offset: 0x00012F9C
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17000B35 RID: 2869
		' (get) Token: 0x06001CDE RID: 7390 RVA: 0x00014DA5 File Offset: 0x00012FA5
		' (set) Token: 0x06001CDF RID: 7391 RVA: 0x00014DAF File Offset: 0x00012FAF
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17000B36 RID: 2870
		' (get) Token: 0x06001CE0 RID: 7392 RVA: 0x00014DB8 File Offset: 0x00012FB8
		' (set) Token: 0x06001CE1 RID: 7393 RVA: 0x00014DC2 File Offset: 0x00012FC2
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17000B37 RID: 2871
		' (get) Token: 0x06001CE2 RID: 7394 RVA: 0x00014DCB File Offset: 0x00012FCB
		' (set) Token: 0x06001CE3 RID: 7395 RVA: 0x00014DD5 File Offset: 0x00012FD5
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17000B38 RID: 2872
		' (get) Token: 0x06001CE4 RID: 7396 RVA: 0x00014DDE File Offset: 0x00012FDE
		' (set) Token: 0x06001CE5 RID: 7397 RVA: 0x00014DE8 File Offset: 0x00012FE8
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17000B39 RID: 2873
		' (get) Token: 0x06001CE6 RID: 7398 RVA: 0x00014DF1 File Offset: 0x00012FF1
		' (set) Token: 0x06001CE7 RID: 7399 RVA: 0x00014DFB File Offset: 0x00012FFB
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000B3A RID: 2874
		' (get) Token: 0x06001CE8 RID: 7400 RVA: 0x00014E04 File Offset: 0x00013004
		' (set) Token: 0x06001CE9 RID: 7401 RVA: 0x00014E0E File Offset: 0x0001300E
		Friend Overridable Property Column12 As DataGridViewImageColumn

		' Token: 0x17000B3B RID: 2875
		' (get) Token: 0x06001CEA RID: 7402 RVA: 0x00014E17 File Offset: 0x00013017
		' (set) Token: 0x06001CEB RID: 7403 RVA: 0x00014E21 File Offset: 0x00013021
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17000B3C RID: 2876
		' (get) Token: 0x06001CEC RID: 7404 RVA: 0x00014E2A File Offset: 0x0001302A
		' (set) Token: 0x06001CED RID: 7405 RVA: 0x00014E34 File Offset: 0x00013034
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17000B3D RID: 2877
		' (get) Token: 0x06001CEE RID: 7406 RVA: 0x00014E3D File Offset: 0x0001303D
		' (set) Token: 0x06001CEF RID: 7407 RVA: 0x00014E47 File Offset: 0x00013047
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17000B3E RID: 2878
		' (get) Token: 0x06001CF0 RID: 7408 RVA: 0x00014E50 File Offset: 0x00013050
		' (set) Token: 0x06001CF1 RID: 7409 RVA: 0x00014E5A File Offset: 0x0001305A
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17000B3F RID: 2879
		' (get) Token: 0x06001CF2 RID: 7410 RVA: 0x00014E63 File Offset: 0x00013063
		' (set) Token: 0x06001CF3 RID: 7411 RVA: 0x00014E6D File Offset: 0x0001306D
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17000B40 RID: 2880
		' (get) Token: 0x06001CF4 RID: 7412 RVA: 0x00014E76 File Offset: 0x00013076
		' (set) Token: 0x06001CF5 RID: 7413 RVA: 0x00014E80 File Offset: 0x00013080
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17000B41 RID: 2881
		' (get) Token: 0x06001CF6 RID: 7414 RVA: 0x00014E89 File Offset: 0x00013089
		' (set) Token: 0x06001CF7 RID: 7415 RVA: 0x00014E93 File Offset: 0x00013093
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17000B42 RID: 2882
		' (get) Token: 0x06001CF8 RID: 7416 RVA: 0x00014E9C File Offset: 0x0001309C
		' (set) Token: 0x06001CF9 RID: 7417 RVA: 0x00014EA6 File Offset: 0x000130A6
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17000B43 RID: 2883
		' (get) Token: 0x06001CFA RID: 7418 RVA: 0x00014EAF File Offset: 0x000130AF
		' (set) Token: 0x06001CFB RID: 7419 RVA: 0x00014EB9 File Offset: 0x000130B9
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17000B44 RID: 2884
		' (get) Token: 0x06001CFC RID: 7420 RVA: 0x00014EC2 File Offset: 0x000130C2
		' (set) Token: 0x06001CFD RID: 7421 RVA: 0x00014ECC File Offset: 0x000130CC
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17000B45 RID: 2885
		' (get) Token: 0x06001CFE RID: 7422 RVA: 0x00014ED5 File Offset: 0x000130D5
		' (set) Token: 0x06001CFF RID: 7423 RVA: 0x00014EDF File Offset: 0x000130DF
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17000B46 RID: 2886
		' (get) Token: 0x06001D00 RID: 7424 RVA: 0x00014EE8 File Offset: 0x000130E8
		' (set) Token: 0x06001D01 RID: 7425 RVA: 0x00014EF2 File Offset: 0x000130F2
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17000B47 RID: 2887
		' (get) Token: 0x06001D02 RID: 7426 RVA: 0x00014EFB File Offset: 0x000130FB
		' (set) Token: 0x06001D03 RID: 7427 RVA: 0x00014F05 File Offset: 0x00013105
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17000B48 RID: 2888
		' (get) Token: 0x06001D04 RID: 7428 RVA: 0x00014F0E File Offset: 0x0001310E
		' (set) Token: 0x06001D05 RID: 7429 RVA: 0x00014F18 File Offset: 0x00013118
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000B49 RID: 2889
		' (get) Token: 0x06001D06 RID: 7430 RVA: 0x00014F21 File Offset: 0x00013121
		' (set) Token: 0x06001D07 RID: 7431 RVA: 0x00014F2B File Offset: 0x0001312B
		Friend Overridable Property cmbSupport As ComboBox

		' Token: 0x17000B4A RID: 2890
		' (get) Token: 0x06001D08 RID: 7432 RVA: 0x00014F34 File Offset: 0x00013134
		' (set) Token: 0x06001D09 RID: 7433 RVA: 0x00014F3E File Offset: 0x0001313E
		Friend Overridable Property Label5 As Label

		' Token: 0x17000B4B RID: 2891
		' (get) Token: 0x06001D0A RID: 7434 RVA: 0x00014F47 File Offset: 0x00013147
		' (set) Token: 0x06001D0B RID: 7435 RVA: 0x00014F51 File Offset: 0x00013151
		Friend Overridable Property txtTokenNo As TextBox

		' Token: 0x17000B4C RID: 2892
		' (get) Token: 0x06001D0C RID: 7436 RVA: 0x00014F5A File Offset: 0x0001315A
		' (set) Token: 0x06001D0D RID: 7437 RVA: 0x00014F64 File Offset: 0x00013164
		Friend Overridable Property Label2 As Label

		' Token: 0x17000B4D RID: 2893
		' (get) Token: 0x06001D0E RID: 7438 RVA: 0x00014F6D File Offset: 0x0001316D
		' (set) Token: 0x06001D0F RID: 7439 RVA: 0x00014F77 File Offset: 0x00013177
		Friend Overridable Property lblUserType As Label

		' Token: 0x17000B4E RID: 2894
		' (get) Token: 0x06001D10 RID: 7440 RVA: 0x00014F80 File Offset: 0x00013180
		' (set) Token: 0x06001D11 RID: 7441 RVA: 0x00014F8A File Offset: 0x0001318A
		Friend Overridable Property lbl_Id As Label

		' Token: 0x17000B4F RID: 2895
		' (get) Token: 0x06001D12 RID: 7442 RVA: 0x00014F93 File Offset: 0x00013193
		' (set) Token: 0x06001D13 RID: 7443 RVA: 0x00014F9D File Offset: 0x0001319D
		Friend Overridable Property lblSoftwareName As Label

		' Token: 0x17000B50 RID: 2896
		' (get) Token: 0x06001D14 RID: 7444 RVA: 0x00014FA6 File Offset: 0x000131A6
		' (set) Token: 0x06001D15 RID: 7445 RVA: 0x00014FB0 File Offset: 0x000131B0
		Friend Overridable Property lblValidity As Label

		' Token: 0x17000B51 RID: 2897
		' (get) Token: 0x06001D16 RID: 7446 RVA: 0x00014FB9 File Offset: 0x000131B9
		' (set) Token: 0x06001D17 RID: 7447 RVA: 0x00014FC3 File Offset: 0x000131C3
		Friend Overridable Property lblMessage As Label

		' Token: 0x17000B52 RID: 2898
		' (get) Token: 0x06001D18 RID: 7448 RVA: 0x00014FCC File Offset: 0x000131CC
		' (set) Token: 0x06001D19 RID: 7449 RVA: 0x001408A4 File Offset: 0x0013EAA4
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000B53 RID: 2899
		' (get) Token: 0x06001D1A RID: 7450 RVA: 0x00014FD6 File Offset: 0x000131D6
		' (set) Token: 0x06001D1B RID: 7451 RVA: 0x00014FE0 File Offset: 0x000131E0
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17000B54 RID: 2900
		' (get) Token: 0x06001D1C RID: 7452 RVA: 0x00014FE9 File Offset: 0x000131E9
		' (set) Token: 0x06001D1D RID: 7453 RVA: 0x00014FF3 File Offset: 0x000131F3
		Friend Overridable Property Label18 As Label

		' Token: 0x17000B55 RID: 2901
		' (get) Token: 0x06001D1E RID: 7454 RVA: 0x00014FFC File Offset: 0x000131FC
		' (set) Token: 0x06001D1F RID: 7455 RVA: 0x00015006 File Offset: 0x00013206
		Friend Overridable Property Label21 As Label

		' Token: 0x17000B56 RID: 2902
		' (get) Token: 0x06001D20 RID: 7456 RVA: 0x0001500F File Offset: 0x0001320F
		' (set) Token: 0x06001D21 RID: 7457 RVA: 0x00015019 File Offset: 0x00013219
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17000B57 RID: 2903
		' (get) Token: 0x06001D22 RID: 7458 RVA: 0x00015022 File Offset: 0x00013222
		' (set) Token: 0x06001D23 RID: 7459 RVA: 0x0001502C File Offset: 0x0001322C
		Friend Overridable Property cmbUser As ComboBox

		' Token: 0x17000B58 RID: 2904
		' (get) Token: 0x06001D24 RID: 7460 RVA: 0x00015035 File Offset: 0x00013235
		' (set) Token: 0x06001D25 RID: 7461 RVA: 0x0001503F File Offset: 0x0001323F
		Friend Overridable Property Label3 As Label

		' Token: 0x17000B59 RID: 2905
		' (get) Token: 0x06001D26 RID: 7462 RVA: 0x00015048 File Offset: 0x00013248
		' (set) Token: 0x06001D27 RID: 7463 RVA: 0x00015052 File Offset: 0x00013252
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000B5A RID: 2906
		' (get) Token: 0x06001D28 RID: 7464 RVA: 0x0001505B File Offset: 0x0001325B
		' (set) Token: 0x06001D29 RID: 7465 RVA: 0x00015065 File Offset: 0x00013265
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000B5B RID: 2907
		' (get) Token: 0x06001D2A RID: 7466 RVA: 0x0001506E File Offset: 0x0001326E
		' (set) Token: 0x06001D2B RID: 7467 RVA: 0x00015078 File Offset: 0x00013278
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000B5C RID: 2908
		' (get) Token: 0x06001D2C RID: 7468 RVA: 0x00015081 File Offset: 0x00013281
		' (set) Token: 0x06001D2D RID: 7469 RVA: 0x0001508B File Offset: 0x0001328B
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000B5D RID: 2909
		' (get) Token: 0x06001D2E RID: 7470 RVA: 0x00015094 File Offset: 0x00013294
		' (set) Token: 0x06001D2F RID: 7471 RVA: 0x0001509E File Offset: 0x0001329E
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17000B5E RID: 2910
		' (get) Token: 0x06001D30 RID: 7472 RVA: 0x000150A7 File Offset: 0x000132A7
		' (set) Token: 0x06001D31 RID: 7473 RVA: 0x000150B1 File Offset: 0x000132B1
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17000B5F RID: 2911
		' (get) Token: 0x06001D32 RID: 7474 RVA: 0x000150BA File Offset: 0x000132BA
		' (set) Token: 0x06001D33 RID: 7475 RVA: 0x000150C4 File Offset: 0x000132C4
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000B60 RID: 2912
		' (get) Token: 0x06001D34 RID: 7476 RVA: 0x000150CD File Offset: 0x000132CD
		' (set) Token: 0x06001D35 RID: 7477 RVA: 0x000150D7 File Offset: 0x000132D7
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000B61 RID: 2913
		' (get) Token: 0x06001D36 RID: 7478 RVA: 0x000150E0 File Offset: 0x000132E0
		' (set) Token: 0x06001D37 RID: 7479 RVA: 0x000150EA File Offset: 0x000132EA
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17000B62 RID: 2914
		' (get) Token: 0x06001D38 RID: 7480 RVA: 0x000150F3 File Offset: 0x000132F3
		' (set) Token: 0x06001D39 RID: 7481 RVA: 0x000150FD File Offset: 0x000132FD
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x17000B63 RID: 2915
		' (get) Token: 0x06001D3A RID: 7482 RVA: 0x00015106 File Offset: 0x00013306
		' (set) Token: 0x06001D3B RID: 7483 RVA: 0x00015110 File Offset: 0x00013310
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x17000B64 RID: 2916
		' (get) Token: 0x06001D3C RID: 7484 RVA: 0x00015119 File Offset: 0x00013319
		' (set) Token: 0x06001D3D RID: 7485 RVA: 0x00015123 File Offset: 0x00013323
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x17000B65 RID: 2917
		' (get) Token: 0x06001D3E RID: 7486 RVA: 0x0001512C File Offset: 0x0001332C
		' (set) Token: 0x06001D3F RID: 7487 RVA: 0x00015136 File Offset: 0x00013336
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x17000B66 RID: 2918
		' (get) Token: 0x06001D40 RID: 7488 RVA: 0x0001513F File Offset: 0x0001333F
		' (set) Token: 0x06001D41 RID: 7489 RVA: 0x00015149 File Offset: 0x00013349
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x17000B67 RID: 2919
		' (get) Token: 0x06001D42 RID: 7490 RVA: 0x00015152 File Offset: 0x00013352
		' (set) Token: 0x06001D43 RID: 7491 RVA: 0x0001515C File Offset: 0x0001335C
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17000B68 RID: 2920
		' (get) Token: 0x06001D44 RID: 7492 RVA: 0x00015165 File Offset: 0x00013365
		' (set) Token: 0x06001D45 RID: 7493 RVA: 0x0001516F File Offset: 0x0001336F
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17000B69 RID: 2921
		' (get) Token: 0x06001D46 RID: 7494 RVA: 0x00015178 File Offset: 0x00013378
		' (set) Token: 0x06001D47 RID: 7495 RVA: 0x00015182 File Offset: 0x00013382
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17000B6A RID: 2922
		' (get) Token: 0x06001D48 RID: 7496 RVA: 0x0001518B File Offset: 0x0001338B
		' (set) Token: 0x06001D49 RID: 7497 RVA: 0x00015195 File Offset: 0x00013395
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17000B6B RID: 2923
		' (get) Token: 0x06001D4A RID: 7498 RVA: 0x0001519E File Offset: 0x0001339E
		' (set) Token: 0x06001D4B RID: 7499 RVA: 0x000151A8 File Offset: 0x000133A8
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17000B6C RID: 2924
		' (get) Token: 0x06001D4C RID: 7500 RVA: 0x000151B1 File Offset: 0x000133B1
		' (set) Token: 0x06001D4D RID: 7501 RVA: 0x000151BB File Offset: 0x000133BB
		Friend Overridable Property btnJoin As DataGridViewButtonColumn

		' Token: 0x17000B6D RID: 2925
		' (get) Token: 0x06001D4E RID: 7502 RVA: 0x000151C4 File Offset: 0x000133C4
		' (set) Token: 0x06001D4F RID: 7503 RVA: 0x000151CE File Offset: 0x000133CE
		Friend Overridable Property btnFollow As DataGridViewButtonColumn

		' Token: 0x17000B6E RID: 2926
		' (get) Token: 0x06001D50 RID: 7504 RVA: 0x000151D7 File Offset: 0x000133D7
		' (set) Token: 0x06001D51 RID: 7505 RVA: 0x000151E1 File Offset: 0x000133E1
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000B6F RID: 2927
		' (get) Token: 0x06001D52 RID: 7506 RVA: 0x000151EA File Offset: 0x000133EA
		' (set) Token: 0x06001D53 RID: 7507 RVA: 0x001408E8 File Offset: 0x0013EAE8
		Private _txtCustomer As TextBox
		Friend Overridable Property txtCustomer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomer_TextChanged
				Dim textBox As TextBox = Me._txtCustomer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomer = value
				textBox = Me._txtCustomer
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000B70 RID: 2928
		' (get) Token: 0x06001D54 RID: 7508 RVA: 0x000151F4 File Offset: 0x000133F4
		' (set) Token: 0x06001D55 RID: 7509 RVA: 0x000151FE File Offset: 0x000133FE
		Friend Overridable Property Label7 As Label

		' Token: 0x17000B71 RID: 2929
		' (get) Token: 0x06001D56 RID: 7510 RVA: 0x00015207 File Offset: 0x00013407
		' (set) Token: 0x06001D57 RID: 7511 RVA: 0x00015211 File Offset: 0x00013411
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17000B72 RID: 2930
		' (get) Token: 0x06001D58 RID: 7512 RVA: 0x0001521A File Offset: 0x0001341A
		' (set) Token: 0x06001D59 RID: 7513 RVA: 0x0014092C File Offset: 0x0013EB2C
		Private _txtMobile As TextBox
		Friend Overridable Property txtMobile As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMobile
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtMobile_TextChanged
				Dim textBox As TextBox = Me._txtMobile
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtMobile = value
				textBox = Me._txtMobile
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000B73 RID: 2931
		' (get) Token: 0x06001D5A RID: 7514 RVA: 0x00015224 File Offset: 0x00013424
		' (set) Token: 0x06001D5B RID: 7515 RVA: 0x0001522E File Offset: 0x0001342E
		Friend Overridable Property Label4 As Label

		' Token: 0x17000B74 RID: 2932
		' (get) Token: 0x06001D5C RID: 7516 RVA: 0x00015237 File Offset: 0x00013437
		' (set) Token: 0x06001D5D RID: 7517 RVA: 0x00015241 File Offset: 0x00013441
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17000B75 RID: 2933
		' (get) Token: 0x06001D5E RID: 7518 RVA: 0x0001524A File Offset: 0x0001344A
		' (set) Token: 0x06001D5F RID: 7519 RVA: 0x00015254 File Offset: 0x00013454
		Friend Overridable Property Label8 As Label

		' Token: 0x17000B76 RID: 2934
		' (get) Token: 0x06001D60 RID: 7520 RVA: 0x0001525D File Offset: 0x0001345D
		' (set) Token: 0x06001D61 RID: 7521 RVA: 0x00140970 File Offset: 0x0013EB70
		Private _DataGridView3 As DataGridView
		Friend Overridable Property DataGridView3 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView3_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView3_KeyDown
				Dim dataGridView As DataGridView = Me._DataGridView3
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._DataGridView3 = value
				dataGridView = Me._DataGridView3
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000B77 RID: 2935
		' (get) Token: 0x06001D62 RID: 7522 RVA: 0x00015267 File Offset: 0x00013467
		' (set) Token: 0x06001D63 RID: 7523 RVA: 0x001409D0 File Offset: 0x0013EBD0
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView2_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView2_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000B78 RID: 2936
		' (get) Token: 0x06001D64 RID: 7524 RVA: 0x00015271 File Offset: 0x00013471
		' (set) Token: 0x06001D65 RID: 7525 RVA: 0x0001527B File Offset: 0x0001347B
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x17000B79 RID: 2937
		' (get) Token: 0x06001D66 RID: 7526 RVA: 0x00015284 File Offset: 0x00013484
		' (set) Token: 0x06001D67 RID: 7527 RVA: 0x0001528E File Offset: 0x0001348E
		Friend Overridable Property DataGridViewTextBoxColumn56 As DataGridViewTextBoxColumn

		' Token: 0x17000B7A RID: 2938
		' (get) Token: 0x06001D68 RID: 7528 RVA: 0x00015297 File Offset: 0x00013497
		' (set) Token: 0x06001D69 RID: 7529 RVA: 0x000152A1 File Offset: 0x000134A1
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17000B7B RID: 2939
		' (get) Token: 0x06001D6A RID: 7530 RVA: 0x000152AA File Offset: 0x000134AA
		' (set) Token: 0x06001D6B RID: 7531 RVA: 0x000152B4 File Offset: 0x000134B4
		Friend Overridable Property DataGridViewTextBoxColumn58 As DataGridViewTextBoxColumn

		' Token: 0x17000B7C RID: 2940
		' (get) Token: 0x06001D6C RID: 7532 RVA: 0x000152BD File Offset: 0x000134BD
		' (set) Token: 0x06001D6D RID: 7533 RVA: 0x000152C7 File Offset: 0x000134C7
		Friend Overridable Property DataGridViewTextBoxColumn59 As DataGridViewTextBoxColumn

		' Token: 0x17000B7D RID: 2941
		' (get) Token: 0x06001D6E RID: 7534 RVA: 0x000152D0 File Offset: 0x000134D0
		' (set) Token: 0x06001D6F RID: 7535 RVA: 0x000152DA File Offset: 0x000134DA
		Friend Overridable Property DataGridViewTextBoxColumn60 As DataGridViewTextBoxColumn

		' Token: 0x17000B7E RID: 2942
		' (get) Token: 0x06001D70 RID: 7536 RVA: 0x000152E3 File Offset: 0x000134E3
		' (set) Token: 0x06001D71 RID: 7537 RVA: 0x000152ED File Offset: 0x000134ED
		Friend Overridable Property DataGridViewTextBoxColumn61 As DataGridViewTextBoxColumn

		' Token: 0x17000B7F RID: 2943
		' (get) Token: 0x06001D72 RID: 7538 RVA: 0x000152F6 File Offset: 0x000134F6
		' (set) Token: 0x06001D73 RID: 7539 RVA: 0x00015300 File Offset: 0x00013500
		Friend Overridable Property DataGridViewTextBoxColumn62 As DataGridViewTextBoxColumn

		' Token: 0x17000B80 RID: 2944
		' (get) Token: 0x06001D74 RID: 7540 RVA: 0x00015309 File Offset: 0x00013509
		' (set) Token: 0x06001D75 RID: 7541 RVA: 0x00015313 File Offset: 0x00013513
		Friend Overridable Property DataGridViewTextBoxColumn63 As DataGridViewTextBoxColumn

		' Token: 0x17000B81 RID: 2945
		' (get) Token: 0x06001D76 RID: 7542 RVA: 0x0001531C File Offset: 0x0001351C
		' (set) Token: 0x06001D77 RID: 7543 RVA: 0x00015326 File Offset: 0x00013526
		Friend Overridable Property DataGridViewTextBoxColumn64 As DataGridViewTextBoxColumn

		' Token: 0x17000B82 RID: 2946
		' (get) Token: 0x06001D78 RID: 7544 RVA: 0x0001532F File Offset: 0x0001352F
		' (set) Token: 0x06001D79 RID: 7545 RVA: 0x00015339 File Offset: 0x00013539
		Friend Overridable Property DataGridViewTextBoxColumn65 As DataGridViewTextBoxColumn

		' Token: 0x17000B83 RID: 2947
		' (get) Token: 0x06001D7A RID: 7546 RVA: 0x00015342 File Offset: 0x00013542
		' (set) Token: 0x06001D7B RID: 7547 RVA: 0x0001534C File Offset: 0x0001354C
		Friend Overridable Property DataGridViewTextBoxColumn66 As DataGridViewTextBoxColumn

		' Token: 0x17000B84 RID: 2948
		' (get) Token: 0x06001D7C RID: 7548 RVA: 0x00015355 File Offset: 0x00013555
		' (set) Token: 0x06001D7D RID: 7549 RVA: 0x0001535F File Offset: 0x0001355F
		Friend Overridable Property DataGridViewTextBoxColumn67 As DataGridViewTextBoxColumn

		' Token: 0x17000B85 RID: 2949
		' (get) Token: 0x06001D7E RID: 7550 RVA: 0x00015368 File Offset: 0x00013568
		' (set) Token: 0x06001D7F RID: 7551 RVA: 0x00015372 File Offset: 0x00013572
		Friend Overridable Property DataGridViewTextBoxColumn68 As DataGridViewTextBoxColumn

		' Token: 0x17000B86 RID: 2950
		' (get) Token: 0x06001D80 RID: 7552 RVA: 0x0001537B File Offset: 0x0001357B
		' (set) Token: 0x06001D81 RID: 7553 RVA: 0x00015385 File Offset: 0x00013585
		Friend Overridable Property DataGridViewTextBoxColumn69 As DataGridViewTextBoxColumn

		' Token: 0x17000B87 RID: 2951
		' (get) Token: 0x06001D82 RID: 7554 RVA: 0x0001538E File Offset: 0x0001358E
		' (set) Token: 0x06001D83 RID: 7555 RVA: 0x00015398 File Offset: 0x00013598
		Friend Overridable Property DataGridViewTextBoxColumn70 As DataGridViewTextBoxColumn

		' Token: 0x17000B88 RID: 2952
		' (get) Token: 0x06001D84 RID: 7556 RVA: 0x000153A1 File Offset: 0x000135A1
		' (set) Token: 0x06001D85 RID: 7557 RVA: 0x000153AB File Offset: 0x000135AB
		Friend Overridable Property DataGridViewTextBoxColumn71 As DataGridViewTextBoxColumn

		' Token: 0x17000B89 RID: 2953
		' (get) Token: 0x06001D86 RID: 7558 RVA: 0x000153B4 File Offset: 0x000135B4
		' (set) Token: 0x06001D87 RID: 7559 RVA: 0x000153BE File Offset: 0x000135BE
		Friend Overridable Property DataGridViewTextBoxColumn72 As DataGridViewTextBoxColumn

		' Token: 0x17000B8A RID: 2954
		' (get) Token: 0x06001D88 RID: 7560 RVA: 0x000153C7 File Offset: 0x000135C7
		' (set) Token: 0x06001D89 RID: 7561 RVA: 0x000153D1 File Offset: 0x000135D1
		Friend Overridable Property DataGridViewTextBoxColumn73 As DataGridViewTextBoxColumn

		' Token: 0x17000B8B RID: 2955
		' (get) Token: 0x06001D8A RID: 7562 RVA: 0x000153DA File Offset: 0x000135DA
		' (set) Token: 0x06001D8B RID: 7563 RVA: 0x000153E4 File Offset: 0x000135E4
		Friend Overridable Property DataGridViewTextBoxColumn74 As DataGridViewTextBoxColumn

		' Token: 0x17000B8C RID: 2956
		' (get) Token: 0x06001D8C RID: 7564 RVA: 0x000153ED File Offset: 0x000135ED
		' (set) Token: 0x06001D8D RID: 7565 RVA: 0x000153F7 File Offset: 0x000135F7
		Friend Overridable Property DataGridViewTextBoxColumn75 As DataGridViewTextBoxColumn

		' Token: 0x17000B8D RID: 2957
		' (get) Token: 0x06001D8E RID: 7566 RVA: 0x00015400 File Offset: 0x00013600
		' (set) Token: 0x06001D8F RID: 7567 RVA: 0x0001540A File Offset: 0x0001360A
		Friend Overridable Property DataGridViewTextBoxColumn76 As DataGridViewTextBoxColumn

		' Token: 0x17000B8E RID: 2958
		' (get) Token: 0x06001D90 RID: 7568 RVA: 0x00015413 File Offset: 0x00013613
		' (set) Token: 0x06001D91 RID: 7569 RVA: 0x0001541D File Offset: 0x0001361D
		Friend Overridable Property DataGridViewTextBoxColumn77 As DataGridViewTextBoxColumn

		' Token: 0x17000B8F RID: 2959
		' (get) Token: 0x06001D92 RID: 7570 RVA: 0x00015426 File Offset: 0x00013626
		' (set) Token: 0x06001D93 RID: 7571 RVA: 0x00015430 File Offset: 0x00013630
		Friend Overridable Property DataGridViewTextBoxColumn78 As DataGridViewTextBoxColumn

		' Token: 0x17000B90 RID: 2960
		' (get) Token: 0x06001D94 RID: 7572 RVA: 0x00015439 File Offset: 0x00013639
		' (set) Token: 0x06001D95 RID: 7573 RVA: 0x00015443 File Offset: 0x00013643
		Friend Overridable Property DataGridViewTextBoxColumn79 As DataGridViewTextBoxColumn

		' Token: 0x17000B91 RID: 2961
		' (get) Token: 0x06001D96 RID: 7574 RVA: 0x0001544C File Offset: 0x0001364C
		' (set) Token: 0x06001D97 RID: 7575 RVA: 0x00015456 File Offset: 0x00013656
		Friend Overridable Property DataGridViewTextBoxColumn80 As DataGridViewTextBoxColumn

		' Token: 0x17000B92 RID: 2962
		' (get) Token: 0x06001D98 RID: 7576 RVA: 0x0001545F File Offset: 0x0001365F
		' (set) Token: 0x06001D99 RID: 7577 RVA: 0x00015469 File Offset: 0x00013669
		Friend Overridable Property DataGridViewTextBoxColumn81 As DataGridViewTextBoxColumn

		' Token: 0x17000B93 RID: 2963
		' (get) Token: 0x06001D9A RID: 7578 RVA: 0x00015472 File Offset: 0x00013672
		' (set) Token: 0x06001D9B RID: 7579 RVA: 0x0001547C File Offset: 0x0001367C
		Friend Overridable Property DataGridViewTextBoxColumn82 As DataGridViewTextBoxColumn

		' Token: 0x17000B94 RID: 2964
		' (get) Token: 0x06001D9C RID: 7580 RVA: 0x00015485 File Offset: 0x00013685
		' (set) Token: 0x06001D9D RID: 7581 RVA: 0x0001548F File Offset: 0x0001368F
		Friend Overridable Property DataGridViewTextBoxColumn83 As DataGridViewTextBoxColumn

		' Token: 0x17000B95 RID: 2965
		' (get) Token: 0x06001D9E RID: 7582 RVA: 0x00015498 File Offset: 0x00013698
		' (set) Token: 0x06001D9F RID: 7583 RVA: 0x000154A2 File Offset: 0x000136A2
		Friend Overridable Property DataGridViewTextBoxColumn84 As DataGridViewTextBoxColumn

		' Token: 0x17000B96 RID: 2966
		' (get) Token: 0x06001DA0 RID: 7584 RVA: 0x000154AB File Offset: 0x000136AB
		' (set) Token: 0x06001DA1 RID: 7585 RVA: 0x000154B5 File Offset: 0x000136B5
		Friend Overridable Property DataGridViewTextBoxColumn85 As DataGridViewTextBoxColumn

		' Token: 0x17000B97 RID: 2967
		' (get) Token: 0x06001DA2 RID: 7586 RVA: 0x000154BE File Offset: 0x000136BE
		' (set) Token: 0x06001DA3 RID: 7587 RVA: 0x000154C8 File Offset: 0x000136C8
		Friend Overridable Property DataGridViewTextBoxColumn86 As DataGridViewTextBoxColumn

		' Token: 0x17000B98 RID: 2968
		' (get) Token: 0x06001DA4 RID: 7588 RVA: 0x000154D1 File Offset: 0x000136D1
		' (set) Token: 0x06001DA5 RID: 7589 RVA: 0x000154DB File Offset: 0x000136DB
		Friend Overridable Property DataGridViewTextBoxColumn87 As DataGridViewTextBoxColumn

		' Token: 0x17000B99 RID: 2969
		' (get) Token: 0x06001DA6 RID: 7590 RVA: 0x000154E4 File Offset: 0x000136E4
		' (set) Token: 0x06001DA7 RID: 7591 RVA: 0x000154EE File Offset: 0x000136EE
		Friend Overridable Property DataGridViewTextBoxColumn88 As DataGridViewTextBoxColumn

		' Token: 0x17000B9A RID: 2970
		' (get) Token: 0x06001DA8 RID: 7592 RVA: 0x000154F7 File Offset: 0x000136F7
		' (set) Token: 0x06001DA9 RID: 7593 RVA: 0x00015501 File Offset: 0x00013701
		Friend Overridable Property DataGridViewTextBoxColumn89 As DataGridViewTextBoxColumn

		' Token: 0x17000B9B RID: 2971
		' (get) Token: 0x06001DAA RID: 7594 RVA: 0x0001550A File Offset: 0x0001370A
		' (set) Token: 0x06001DAB RID: 7595 RVA: 0x00015514 File Offset: 0x00013714
		Friend Overridable Property DataGridViewTextBoxColumn90 As DataGridViewTextBoxColumn

		' Token: 0x17000B9C RID: 2972
		' (get) Token: 0x06001DAC RID: 7596 RVA: 0x0001551D File Offset: 0x0001371D
		' (set) Token: 0x06001DAD RID: 7597 RVA: 0x00015527 File Offset: 0x00013727
		Friend Overridable Property DataGridViewTextBoxColumn91 As DataGridViewTextBoxColumn

		' Token: 0x17000B9D RID: 2973
		' (get) Token: 0x06001DAE RID: 7598 RVA: 0x00015530 File Offset: 0x00013730
		' (set) Token: 0x06001DAF RID: 7599 RVA: 0x0001553A File Offset: 0x0001373A
		Friend Overridable Property DataGridViewTextBoxColumn92 As DataGridViewTextBoxColumn

		' Token: 0x17000B9E RID: 2974
		' (get) Token: 0x06001DB0 RID: 7600 RVA: 0x00015543 File Offset: 0x00013743
		' (set) Token: 0x06001DB1 RID: 7601 RVA: 0x0001554D File Offset: 0x0001374D
		Friend Overridable Property DataGridViewTextBoxColumn93 As DataGridViewTextBoxColumn

		' Token: 0x17000B9F RID: 2975
		' (get) Token: 0x06001DB2 RID: 7602 RVA: 0x00015556 File Offset: 0x00013756
		' (set) Token: 0x06001DB3 RID: 7603 RVA: 0x00015560 File Offset: 0x00013760
		Friend Overridable Property DataGridViewTextBoxColumn94 As DataGridViewTextBoxColumn

		' Token: 0x17000BA0 RID: 2976
		' (get) Token: 0x06001DB4 RID: 7604 RVA: 0x00015569 File Offset: 0x00013769
		' (set) Token: 0x06001DB5 RID: 7605 RVA: 0x00015573 File Offset: 0x00013773
		Friend Overridable Property DataGridViewTextBoxColumn95 As DataGridViewTextBoxColumn

		' Token: 0x17000BA1 RID: 2977
		' (get) Token: 0x06001DB6 RID: 7606 RVA: 0x0001557C File Offset: 0x0001377C
		' (set) Token: 0x06001DB7 RID: 7607 RVA: 0x00015586 File Offset: 0x00013786
		Friend Overridable Property DataGridViewTextBoxColumn96 As DataGridViewTextBoxColumn

		' Token: 0x17000BA2 RID: 2978
		' (get) Token: 0x06001DB8 RID: 7608 RVA: 0x0001558F File Offset: 0x0001378F
		' (set) Token: 0x06001DB9 RID: 7609 RVA: 0x00015599 File Offset: 0x00013799
		Friend Overridable Property DataGridViewTextBoxColumn97 As DataGridViewTextBoxColumn

		' Token: 0x17000BA3 RID: 2979
		' (get) Token: 0x06001DBA RID: 7610 RVA: 0x000155A2 File Offset: 0x000137A2
		' (set) Token: 0x06001DBB RID: 7611 RVA: 0x000155AC File Offset: 0x000137AC
		Friend Overridable Property DataGridViewTextBoxColumn98 As DataGridViewTextBoxColumn

		' Token: 0x17000BA4 RID: 2980
		' (get) Token: 0x06001DBC RID: 7612 RVA: 0x000155B5 File Offset: 0x000137B5
		' (set) Token: 0x06001DBD RID: 7613 RVA: 0x000155BF File Offset: 0x000137BF
		Friend Overridable Property DataGridViewTextBoxColumn99 As DataGridViewTextBoxColumn

		' Token: 0x17000BA5 RID: 2981
		' (get) Token: 0x06001DBE RID: 7614 RVA: 0x000155C8 File Offset: 0x000137C8
		' (set) Token: 0x06001DBF RID: 7615 RVA: 0x000155D2 File Offset: 0x000137D2
		Friend Overridable Property DataGridViewTextBoxColumn100 As DataGridViewTextBoxColumn

		' Token: 0x17000BA6 RID: 2982
		' (get) Token: 0x06001DC0 RID: 7616 RVA: 0x000155DB File Offset: 0x000137DB
		' (set) Token: 0x06001DC1 RID: 7617 RVA: 0x000155E5 File Offset: 0x000137E5
		Friend Overridable Property Label6 As Label

		' Token: 0x17000BA7 RID: 2983
		' (get) Token: 0x06001DC2 RID: 7618 RVA: 0x000155EE File Offset: 0x000137EE
		' (set) Token: 0x06001DC3 RID: 7619 RVA: 0x000155F8 File Offset: 0x000137F8
		Friend Overridable Property DataGridView4 As DataGridView

		' Token: 0x17000BA8 RID: 2984
		' (get) Token: 0x06001DC4 RID: 7620 RVA: 0x00015601 File Offset: 0x00013801
		' (set) Token: 0x06001DC5 RID: 7621 RVA: 0x0001560B File Offset: 0x0001380B
		Friend Overridable Property DataGridViewTextBoxColumn101 As DataGridViewTextBoxColumn

		' Token: 0x17000BA9 RID: 2985
		' (get) Token: 0x06001DC6 RID: 7622 RVA: 0x00015614 File Offset: 0x00013814
		' (set) Token: 0x06001DC7 RID: 7623 RVA: 0x0001561E File Offset: 0x0001381E
		Friend Overridable Property DataGridViewTextBoxColumn102 As DataGridViewTextBoxColumn

		' Token: 0x17000BAA RID: 2986
		' (get) Token: 0x06001DC8 RID: 7624 RVA: 0x00015627 File Offset: 0x00013827
		' (set) Token: 0x06001DC9 RID: 7625 RVA: 0x00015631 File Offset: 0x00013831
		Friend Overridable Property DataGridViewTextBoxColumn103 As DataGridViewTextBoxColumn

		' Token: 0x17000BAB RID: 2987
		' (get) Token: 0x06001DCA RID: 7626 RVA: 0x0001563A File Offset: 0x0001383A
		' (set) Token: 0x06001DCB RID: 7627 RVA: 0x00015644 File Offset: 0x00013844
		Friend Overridable Property DataGridViewTextBoxColumn104 As DataGridViewTextBoxColumn

		' Token: 0x17000BAC RID: 2988
		' (get) Token: 0x06001DCC RID: 7628 RVA: 0x0001564D File Offset: 0x0001384D
		' (set) Token: 0x06001DCD RID: 7629 RVA: 0x00015657 File Offset: 0x00013857
		Friend Overridable Property DataGridViewTextBoxColumn105 As DataGridViewTextBoxColumn

		' Token: 0x17000BAD RID: 2989
		' (get) Token: 0x06001DCE RID: 7630 RVA: 0x00015660 File Offset: 0x00013860
		' (set) Token: 0x06001DCF RID: 7631 RVA: 0x0001566A File Offset: 0x0001386A
		Friend Overridable Property DataGridViewTextBoxColumn106 As DataGridViewTextBoxColumn

		' Token: 0x17000BAE RID: 2990
		' (get) Token: 0x06001DD0 RID: 7632 RVA: 0x00015673 File Offset: 0x00013873
		' (set) Token: 0x06001DD1 RID: 7633 RVA: 0x0001567D File Offset: 0x0001387D
		Friend Overridable Property lblCount As Label

		' Token: 0x17000BAF RID: 2991
		' (get) Token: 0x06001DD2 RID: 7634 RVA: 0x00015686 File Offset: 0x00013886
		' (set) Token: 0x06001DD3 RID: 7635 RVA: 0x00015690 File Offset: 0x00013890
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17000BB0 RID: 2992
		' (get) Token: 0x06001DD4 RID: 7636 RVA: 0x00015699 File Offset: 0x00013899
		' (set) Token: 0x06001DD5 RID: 7637 RVA: 0x000156A3 File Offset: 0x000138A3
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17000BB1 RID: 2993
		' (get) Token: 0x06001DD6 RID: 7638 RVA: 0x000156AC File Offset: 0x000138AC
		' (set) Token: 0x06001DD7 RID: 7639 RVA: 0x000156B6 File Offset: 0x000138B6
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x17000BB2 RID: 2994
		' (get) Token: 0x06001DD8 RID: 7640 RVA: 0x000156BF File Offset: 0x000138BF
		' (set) Token: 0x06001DD9 RID: 7641 RVA: 0x000156C9 File Offset: 0x000138C9
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x17000BB3 RID: 2995
		' (get) Token: 0x06001DDA RID: 7642 RVA: 0x000156D2 File Offset: 0x000138D2
		' (set) Token: 0x06001DDB RID: 7643 RVA: 0x000156DC File Offset: 0x000138DC
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x17000BB4 RID: 2996
		' (get) Token: 0x06001DDC RID: 7644 RVA: 0x000156E5 File Offset: 0x000138E5
		' (set) Token: 0x06001DDD RID: 7645 RVA: 0x000156EF File Offset: 0x000138EF
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17000BB5 RID: 2997
		' (get) Token: 0x06001DDE RID: 7646 RVA: 0x000156F8 File Offset: 0x000138F8
		' (set) Token: 0x06001DDF RID: 7647 RVA: 0x00015702 File Offset: 0x00013902
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17000BB6 RID: 2998
		' (get) Token: 0x06001DE0 RID: 7648 RVA: 0x0001570B File Offset: 0x0001390B
		' (set) Token: 0x06001DE1 RID: 7649 RVA: 0x00015715 File Offset: 0x00013915
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x17000BB7 RID: 2999
		' (get) Token: 0x06001DE2 RID: 7650 RVA: 0x0001571E File Offset: 0x0001391E
		' (set) Token: 0x06001DE3 RID: 7651 RVA: 0x00015728 File Offset: 0x00013928
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x17000BB8 RID: 3000
		' (get) Token: 0x06001DE4 RID: 7652 RVA: 0x00015731 File Offset: 0x00013931
		' (set) Token: 0x06001DE5 RID: 7653 RVA: 0x0001573B File Offset: 0x0001393B
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17000BB9 RID: 3001
		' (get) Token: 0x06001DE6 RID: 7654 RVA: 0x00015744 File Offset: 0x00013944
		' (set) Token: 0x06001DE7 RID: 7655 RVA: 0x0001574E File Offset: 0x0001394E
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17000BBA RID: 3002
		' (get) Token: 0x06001DE8 RID: 7656 RVA: 0x00015757 File Offset: 0x00013957
		' (set) Token: 0x06001DE9 RID: 7657 RVA: 0x00015761 File Offset: 0x00013961
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17000BBB RID: 3003
		' (get) Token: 0x06001DEA RID: 7658 RVA: 0x0001576A File Offset: 0x0001396A
		' (set) Token: 0x06001DEB RID: 7659 RVA: 0x00015774 File Offset: 0x00013974
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17000BBC RID: 3004
		' (get) Token: 0x06001DEC RID: 7660 RVA: 0x0001577D File Offset: 0x0001397D
		' (set) Token: 0x06001DED RID: 7661 RVA: 0x00015787 File Offset: 0x00013987
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17000BBD RID: 3005
		' (get) Token: 0x06001DEE RID: 7662 RVA: 0x00015790 File Offset: 0x00013990
		' (set) Token: 0x06001DEF RID: 7663 RVA: 0x0001579A File Offset: 0x0001399A
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17000BBE RID: 3006
		' (get) Token: 0x06001DF0 RID: 7664 RVA: 0x000157A3 File Offset: 0x000139A3
		' (set) Token: 0x06001DF1 RID: 7665 RVA: 0x000157AD File Offset: 0x000139AD
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x17000BBF RID: 3007
		' (get) Token: 0x06001DF2 RID: 7666 RVA: 0x000157B6 File Offset: 0x000139B6
		' (set) Token: 0x06001DF3 RID: 7667 RVA: 0x000157C0 File Offset: 0x000139C0
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x17000BC0 RID: 3008
		' (get) Token: 0x06001DF4 RID: 7668 RVA: 0x000157C9 File Offset: 0x000139C9
		' (set) Token: 0x06001DF5 RID: 7669 RVA: 0x000157D3 File Offset: 0x000139D3
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x17000BC1 RID: 3009
		' (get) Token: 0x06001DF6 RID: 7670 RVA: 0x000157DC File Offset: 0x000139DC
		' (set) Token: 0x06001DF7 RID: 7671 RVA: 0x000157E6 File Offset: 0x000139E6
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x17000BC2 RID: 3010
		' (get) Token: 0x06001DF8 RID: 7672 RVA: 0x000157EF File Offset: 0x000139EF
		' (set) Token: 0x06001DF9 RID: 7673 RVA: 0x000157F9 File Offset: 0x000139F9
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x17000BC3 RID: 3011
		' (get) Token: 0x06001DFA RID: 7674 RVA: 0x00015802 File Offset: 0x00013A02
		' (set) Token: 0x06001DFB RID: 7675 RVA: 0x0001580C File Offset: 0x00013A0C
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x17000BC4 RID: 3012
		' (get) Token: 0x06001DFC RID: 7676 RVA: 0x00015815 File Offset: 0x00013A15
		' (set) Token: 0x06001DFD RID: 7677 RVA: 0x0001581F File Offset: 0x00013A1F
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x17000BC5 RID: 3013
		' (get) Token: 0x06001DFE RID: 7678 RVA: 0x00015828 File Offset: 0x00013A28
		' (set) Token: 0x06001DFF RID: 7679 RVA: 0x00015832 File Offset: 0x00013A32
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x17000BC6 RID: 3014
		' (get) Token: 0x06001E00 RID: 7680 RVA: 0x0001583B File Offset: 0x00013A3B
		' (set) Token: 0x06001E01 RID: 7681 RVA: 0x00015845 File Offset: 0x00013A45
		Friend Overridable Property DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn

		' Token: 0x17000BC7 RID: 3015
		' (get) Token: 0x06001E02 RID: 7682 RVA: 0x0001584E File Offset: 0x00013A4E
		' (set) Token: 0x06001E03 RID: 7683 RVA: 0x00015858 File Offset: 0x00013A58
		Friend Overridable Property DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn

		' Token: 0x17000BC8 RID: 3016
		' (get) Token: 0x06001E04 RID: 7684 RVA: 0x00015861 File Offset: 0x00013A61
		' (set) Token: 0x06001E05 RID: 7685 RVA: 0x0001586B File Offset: 0x00013A6B
		Friend Overridable Property DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn

		' Token: 0x17000BC9 RID: 3017
		' (get) Token: 0x06001E06 RID: 7686 RVA: 0x00015874 File Offset: 0x00013A74
		' (set) Token: 0x06001E07 RID: 7687 RVA: 0x0001587E File Offset: 0x00013A7E
		Friend Overridable Property DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn

		' Token: 0x17000BCA RID: 3018
		' (get) Token: 0x06001E08 RID: 7688 RVA: 0x00015887 File Offset: 0x00013A87
		' (set) Token: 0x06001E09 RID: 7689 RVA: 0x00015891 File Offset: 0x00013A91
		Friend Overridable Property DataGridViewTextBoxColumn45 As DataGridViewTextBoxColumn

		' Token: 0x17000BCB RID: 3019
		' (get) Token: 0x06001E0A RID: 7690 RVA: 0x0001589A File Offset: 0x00013A9A
		' (set) Token: 0x06001E0B RID: 7691 RVA: 0x000158A4 File Offset: 0x00013AA4
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x17000BCC RID: 3020
		' (get) Token: 0x06001E0C RID: 7692 RVA: 0x000158AD File Offset: 0x00013AAD
		' (set) Token: 0x06001E0D RID: 7693 RVA: 0x000158B7 File Offset: 0x00013AB7
		Friend Overridable Property DataGridViewTextBoxColumn47 As DataGridViewTextBoxColumn

		' Token: 0x17000BCD RID: 3021
		' (get) Token: 0x06001E0E RID: 7694 RVA: 0x000158C0 File Offset: 0x00013AC0
		' (set) Token: 0x06001E0F RID: 7695 RVA: 0x000158CA File Offset: 0x00013ACA
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17000BCE RID: 3022
		' (get) Token: 0x06001E10 RID: 7696 RVA: 0x000158D3 File Offset: 0x00013AD3
		' (set) Token: 0x06001E11 RID: 7697 RVA: 0x000158DD File Offset: 0x00013ADD
		Friend Overridable Property DataGridViewTextBoxColumn49 As DataGridViewTextBoxColumn

		' Token: 0x17000BCF RID: 3023
		' (get) Token: 0x06001E12 RID: 7698 RVA: 0x000158E6 File Offset: 0x00013AE6
		' (set) Token: 0x06001E13 RID: 7699 RVA: 0x000158F0 File Offset: 0x00013AF0
		Friend Overridable Property DataGridViewTextBoxColumn50 As DataGridViewTextBoxColumn

		' Token: 0x17000BD0 RID: 3024
		' (get) Token: 0x06001E14 RID: 7700 RVA: 0x000158F9 File Offset: 0x00013AF9
		' (set) Token: 0x06001E15 RID: 7701 RVA: 0x00015903 File Offset: 0x00013B03
		Friend Overridable Property DataGridViewTextBoxColumn51 As DataGridViewTextBoxColumn

		' Token: 0x17000BD1 RID: 3025
		' (get) Token: 0x06001E16 RID: 7702 RVA: 0x0001590C File Offset: 0x00013B0C
		' (set) Token: 0x06001E17 RID: 7703 RVA: 0x00015916 File Offset: 0x00013B16
		Friend Overridable Property DataGridViewTextBoxColumn52 As DataGridViewTextBoxColumn

		' Token: 0x17000BD2 RID: 3026
		' (get) Token: 0x06001E18 RID: 7704 RVA: 0x0001591F File Offset: 0x00013B1F
		' (set) Token: 0x06001E19 RID: 7705 RVA: 0x00015929 File Offset: 0x00013B29
		Friend Overridable Property DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn

		' Token: 0x17000BD3 RID: 3027
		' (get) Token: 0x06001E1A RID: 7706 RVA: 0x00015932 File Offset: 0x00013B32
		' (set) Token: 0x06001E1B RID: 7707 RVA: 0x0001593C File Offset: 0x00013B3C
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x17000BD4 RID: 3028
		' (get) Token: 0x06001E1C RID: 7708 RVA: 0x00015945 File Offset: 0x00013B45
		' (set) Token: 0x06001E1D RID: 7709 RVA: 0x0001594F File Offset: 0x00013B4F
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x17000BD5 RID: 3029
		' (get) Token: 0x06001E1E RID: 7710 RVA: 0x00015958 File Offset: 0x00013B58
		' (set) Token: 0x06001E1F RID: 7711 RVA: 0x00015962 File Offset: 0x00013B62
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x17000BD6 RID: 3030
		' (get) Token: 0x06001E20 RID: 7712 RVA: 0x0001596B File Offset: 0x00013B6B
		' (set) Token: 0x06001E21 RID: 7713 RVA: 0x00015975 File Offset: 0x00013B75
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x17000BD7 RID: 3031
		' (get) Token: 0x06001E22 RID: 7714 RVA: 0x0001597E File Offset: 0x00013B7E
		' (set) Token: 0x06001E23 RID: 7715 RVA: 0x00015988 File Offset: 0x00013B88
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x17000BD8 RID: 3032
		' (get) Token: 0x06001E24 RID: 7716 RVA: 0x00015991 File Offset: 0x00013B91
		' (set) Token: 0x06001E25 RID: 7717 RVA: 0x0001599B File Offset: 0x00013B9B
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x17000BD9 RID: 3033
		' (get) Token: 0x06001E26 RID: 7718 RVA: 0x000159A4 File Offset: 0x00013BA4
		' (set) Token: 0x06001E27 RID: 7719 RVA: 0x000159AE File Offset: 0x00013BAE
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17000BDA RID: 3034
		' (get) Token: 0x06001E28 RID: 7720 RVA: 0x000159B7 File Offset: 0x00013BB7
		' (set) Token: 0x06001E29 RID: 7721 RVA: 0x000159C1 File Offset: 0x00013BC1
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17000BDB RID: 3035
		' (get) Token: 0x06001E2A RID: 7722 RVA: 0x000159CA File Offset: 0x00013BCA
		' (set) Token: 0x06001E2B RID: 7723 RVA: 0x000159D4 File Offset: 0x00013BD4
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17000BDC RID: 3036
		' (get) Token: 0x06001E2C RID: 7724 RVA: 0x000159DD File Offset: 0x00013BDD
		' (set) Token: 0x06001E2D RID: 7725 RVA: 0x000159E7 File Offset: 0x00013BE7
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x17000BDD RID: 3037
		' (get) Token: 0x06001E2E RID: 7726 RVA: 0x000159F0 File Offset: 0x00013BF0
		' (set) Token: 0x06001E2F RID: 7727 RVA: 0x000159FA File Offset: 0x00013BFA
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x17000BDE RID: 3038
		' (get) Token: 0x06001E30 RID: 7728 RVA: 0x00015A03 File Offset: 0x00013C03
		' (set) Token: 0x06001E31 RID: 7729 RVA: 0x00015A0D File Offset: 0x00013C0D
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x17000BDF RID: 3039
		' (get) Token: 0x06001E32 RID: 7730 RVA: 0x00015A16 File Offset: 0x00013C16
		' (set) Token: 0x06001E33 RID: 7731 RVA: 0x00015A20 File Offset: 0x00013C20
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x17000BE0 RID: 3040
		' (get) Token: 0x06001E34 RID: 7732 RVA: 0x00015A29 File Offset: 0x00013C29
		' (set) Token: 0x06001E35 RID: 7733 RVA: 0x00015A33 File Offset: 0x00013C33
		Friend Overridable Property lblBill_dtl As Label

		' Token: 0x17000BE1 RID: 3041
		' (get) Token: 0x06001E36 RID: 7734 RVA: 0x00015A3C File Offset: 0x00013C3C
		' (set) Token: 0x06001E37 RID: 7735 RVA: 0x00140A30 File Offset: 0x0013EC30
		Private _DataGridView5 As DataGridView
		Friend Overridable Property DataGridView5 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView5_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView5_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView5
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView5 = value
				dataGridView = Me._DataGridView5
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000BE2 RID: 3042
		' (get) Token: 0x06001E38 RID: 7736 RVA: 0x00015A46 File Offset: 0x00013C46
		' (set) Token: 0x06001E39 RID: 7737 RVA: 0x00015A50 File Offset: 0x00013C50
		Friend Overridable Property DataGridViewTextBoxColumn107 As DataGridViewTextBoxColumn

		' Token: 0x17000BE3 RID: 3043
		' (get) Token: 0x06001E3A RID: 7738 RVA: 0x00015A59 File Offset: 0x00013C59
		' (set) Token: 0x06001E3B RID: 7739 RVA: 0x00015A63 File Offset: 0x00013C63
		Friend Overridable Property DataGridViewTextBoxColumn108 As DataGridViewTextBoxColumn

		' Token: 0x17000BE4 RID: 3044
		' (get) Token: 0x06001E3C RID: 7740 RVA: 0x00015A6C File Offset: 0x00013C6C
		' (set) Token: 0x06001E3D RID: 7741 RVA: 0x00015A76 File Offset: 0x00013C76
		Friend Overridable Property DataGridViewTextBoxColumn109 As DataGridViewTextBoxColumn

		' Token: 0x17000BE5 RID: 3045
		' (get) Token: 0x06001E3E RID: 7742 RVA: 0x00015A7F File Offset: 0x00013C7F
		' (set) Token: 0x06001E3F RID: 7743 RVA: 0x00015A89 File Offset: 0x00013C89
		Friend Overridable Property DataGridViewTextBoxColumn110 As DataGridViewTextBoxColumn

		' Token: 0x17000BE6 RID: 3046
		' (get) Token: 0x06001E40 RID: 7744 RVA: 0x00015A92 File Offset: 0x00013C92
		' (set) Token: 0x06001E41 RID: 7745 RVA: 0x00015A9C File Offset: 0x00013C9C
		Friend Overridable Property DataGridViewTextBoxColumn111 As DataGridViewTextBoxColumn

		' Token: 0x17000BE7 RID: 3047
		' (get) Token: 0x06001E42 RID: 7746 RVA: 0x00015AA5 File Offset: 0x00013CA5
		' (set) Token: 0x06001E43 RID: 7747 RVA: 0x00015AAF File Offset: 0x00013CAF
		Friend Overridable Property DataGridViewTextBoxColumn112 As DataGridViewTextBoxColumn

		' Token: 0x17000BE8 RID: 3048
		' (get) Token: 0x06001E44 RID: 7748 RVA: 0x00015AB8 File Offset: 0x00013CB8
		' (set) Token: 0x06001E45 RID: 7749 RVA: 0x00015AC2 File Offset: 0x00013CC2
		Friend Overridable Property DataGridViewTextBoxColumn113 As DataGridViewTextBoxColumn

		' Token: 0x17000BE9 RID: 3049
		' (get) Token: 0x06001E46 RID: 7750 RVA: 0x00015ACB File Offset: 0x00013CCB
		' (set) Token: 0x06001E47 RID: 7751 RVA: 0x00015AD5 File Offset: 0x00013CD5
		Friend Overridable Property DataGridViewTextBoxColumn114 As DataGridViewTextBoxColumn

		' Token: 0x17000BEA RID: 3050
		' (get) Token: 0x06001E48 RID: 7752 RVA: 0x00015ADE File Offset: 0x00013CDE
		' (set) Token: 0x06001E49 RID: 7753 RVA: 0x00015AE8 File Offset: 0x00013CE8
		Friend Overridable Property DataGridViewTextBoxColumn115 As DataGridViewTextBoxColumn

		' Token: 0x17000BEB RID: 3051
		' (get) Token: 0x06001E4A RID: 7754 RVA: 0x00015AF1 File Offset: 0x00013CF1
		' (set) Token: 0x06001E4B RID: 7755 RVA: 0x00015AFB File Offset: 0x00013CFB
		Friend Overridable Property DataGridViewTextBoxColumn116 As DataGridViewTextBoxColumn

		' Token: 0x17000BEC RID: 3052
		' (get) Token: 0x06001E4C RID: 7756 RVA: 0x00015B04 File Offset: 0x00013D04
		' (set) Token: 0x06001E4D RID: 7757 RVA: 0x00015B0E File Offset: 0x00013D0E
		Friend Overridable Property DataGridViewTextBoxColumn117 As DataGridViewTextBoxColumn

		' Token: 0x17000BED RID: 3053
		' (get) Token: 0x06001E4E RID: 7758 RVA: 0x00015B17 File Offset: 0x00013D17
		' (set) Token: 0x06001E4F RID: 7759 RVA: 0x00015B21 File Offset: 0x00013D21
		Friend Overridable Property DataGridViewTextBoxColumn118 As DataGridViewTextBoxColumn

		' Token: 0x17000BEE RID: 3054
		' (get) Token: 0x06001E50 RID: 7760 RVA: 0x00015B2A File Offset: 0x00013D2A
		' (set) Token: 0x06001E51 RID: 7761 RVA: 0x00015B34 File Offset: 0x00013D34
		Friend Overridable Property DataGridViewTextBoxColumn119 As DataGridViewTextBoxColumn

		' Token: 0x17000BEF RID: 3055
		' (get) Token: 0x06001E52 RID: 7762 RVA: 0x00015B3D File Offset: 0x00013D3D
		' (set) Token: 0x06001E53 RID: 7763 RVA: 0x00015B47 File Offset: 0x00013D47
		Friend Overridable Property DataGridViewTextBoxColumn120 As DataGridViewTextBoxColumn

		' Token: 0x17000BF0 RID: 3056
		' (get) Token: 0x06001E54 RID: 7764 RVA: 0x00015B50 File Offset: 0x00013D50
		' (set) Token: 0x06001E55 RID: 7765 RVA: 0x00015B5A File Offset: 0x00013D5A
		Friend Overridable Property DataGridViewTextBoxColumn121 As DataGridViewTextBoxColumn

		' Token: 0x17000BF1 RID: 3057
		' (get) Token: 0x06001E56 RID: 7766 RVA: 0x00015B63 File Offset: 0x00013D63
		' (set) Token: 0x06001E57 RID: 7767 RVA: 0x00015B6D File Offset: 0x00013D6D
		Friend Overridable Property DataGridViewTextBoxColumn122 As DataGridViewTextBoxColumn

		' Token: 0x17000BF2 RID: 3058
		' (get) Token: 0x06001E58 RID: 7768 RVA: 0x00015B76 File Offset: 0x00013D76
		' (set) Token: 0x06001E59 RID: 7769 RVA: 0x00015B80 File Offset: 0x00013D80
		Friend Overridable Property DataGridViewTextBoxColumn123 As DataGridViewTextBoxColumn

		' Token: 0x17000BF3 RID: 3059
		' (get) Token: 0x06001E5A RID: 7770 RVA: 0x00015B89 File Offset: 0x00013D89
		' (set) Token: 0x06001E5B RID: 7771 RVA: 0x00015B93 File Offset: 0x00013D93
		Friend Overridable Property DataGridViewTextBoxColumn124 As DataGridViewTextBoxColumn

		' Token: 0x17000BF4 RID: 3060
		' (get) Token: 0x06001E5C RID: 7772 RVA: 0x00015B9C File Offset: 0x00013D9C
		' (set) Token: 0x06001E5D RID: 7773 RVA: 0x00015BA6 File Offset: 0x00013DA6
		Friend Overridable Property DataGridViewTextBoxColumn125 As DataGridViewTextBoxColumn

		' Token: 0x17000BF5 RID: 3061
		' (get) Token: 0x06001E5E RID: 7774 RVA: 0x00015BAF File Offset: 0x00013DAF
		' (set) Token: 0x06001E5F RID: 7775 RVA: 0x00015BB9 File Offset: 0x00013DB9
		Friend Overridable Property DataGridViewTextBoxColumn126 As DataGridViewTextBoxColumn

		' Token: 0x17000BF6 RID: 3062
		' (get) Token: 0x06001E60 RID: 7776 RVA: 0x00015BC2 File Offset: 0x00013DC2
		' (set) Token: 0x06001E61 RID: 7777 RVA: 0x00015BCC File Offset: 0x00013DCC
		Friend Overridable Property DataGridViewTextBoxColumn127 As DataGridViewTextBoxColumn

		' Token: 0x17000BF7 RID: 3063
		' (get) Token: 0x06001E62 RID: 7778 RVA: 0x00015BD5 File Offset: 0x00013DD5
		' (set) Token: 0x06001E63 RID: 7779 RVA: 0x00015BDF File Offset: 0x00013DDF
		Friend Overridable Property Label13 As Label

		' Token: 0x17000BF8 RID: 3064
		' (get) Token: 0x06001E64 RID: 7780 RVA: 0x00015BE8 File Offset: 0x00013DE8
		' (set) Token: 0x06001E65 RID: 7781 RVA: 0x00015BF2 File Offset: 0x00013DF2
		Friend Overridable Property Label9 As Label

		' Token: 0x17000BF9 RID: 3065
		' (get) Token: 0x06001E66 RID: 7782 RVA: 0x00015BFB File Offset: 0x00013DFB
		' (set) Token: 0x06001E67 RID: 7783 RVA: 0x00140A90 File Offset: 0x0013EC90
		Private _DataGridView6 As DataGridView
		Friend Overridable Property DataGridView6 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView6_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView6
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView6 = value
				dataGridView = Me._DataGridView6
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000BFA RID: 3066
		' (get) Token: 0x06001E68 RID: 7784 RVA: 0x00015C05 File Offset: 0x00013E05
		' (set) Token: 0x06001E69 RID: 7785 RVA: 0x00015C0F File Offset: 0x00013E0F
		Friend Overridable Property DataGridViewTextBoxColumn128 As DataGridViewTextBoxColumn

		' Token: 0x17000BFB RID: 3067
		' (get) Token: 0x06001E6A RID: 7786 RVA: 0x00015C18 File Offset: 0x00013E18
		' (set) Token: 0x06001E6B RID: 7787 RVA: 0x00015C22 File Offset: 0x00013E22
		Friend Overridable Property DataGridViewTextBoxColumn129 As DataGridViewTextBoxColumn

		' Token: 0x17000BFC RID: 3068
		' (get) Token: 0x06001E6C RID: 7788 RVA: 0x00015C2B File Offset: 0x00013E2B
		' (set) Token: 0x06001E6D RID: 7789 RVA: 0x00015C35 File Offset: 0x00013E35
		Friend Overridable Property DataGridViewTextBoxColumn130 As DataGridViewTextBoxColumn

		' Token: 0x17000BFD RID: 3069
		' (get) Token: 0x06001E6E RID: 7790 RVA: 0x00015C3E File Offset: 0x00013E3E
		' (set) Token: 0x06001E6F RID: 7791 RVA: 0x00015C48 File Offset: 0x00013E48
		Friend Overridable Property DataGridViewTextBoxColumn131 As DataGridViewTextBoxColumn

		' Token: 0x17000BFE RID: 3070
		' (get) Token: 0x06001E70 RID: 7792 RVA: 0x00015C51 File Offset: 0x00013E51
		' (set) Token: 0x06001E71 RID: 7793 RVA: 0x00015C5B File Offset: 0x00013E5B
		Friend Overridable Property DataGridViewTextBoxColumn132 As DataGridViewTextBoxColumn

		' Token: 0x17000BFF RID: 3071
		' (get) Token: 0x06001E72 RID: 7794 RVA: 0x00015C64 File Offset: 0x00013E64
		' (set) Token: 0x06001E73 RID: 7795 RVA: 0x00015C6E File Offset: 0x00013E6E
		Friend Overridable Property DataGridViewTextBoxColumn133 As DataGridViewTextBoxColumn

		' Token: 0x17000C00 RID: 3072
		' (get) Token: 0x06001E74 RID: 7796 RVA: 0x00015C77 File Offset: 0x00013E77
		' (set) Token: 0x06001E75 RID: 7797 RVA: 0x00015C81 File Offset: 0x00013E81
		Friend Overridable Property DataGridViewTextBoxColumn134 As DataGridViewTextBoxColumn

		' Token: 0x17000C01 RID: 3073
		' (get) Token: 0x06001E76 RID: 7798 RVA: 0x00015C8A File Offset: 0x00013E8A
		' (set) Token: 0x06001E77 RID: 7799 RVA: 0x00015C94 File Offset: 0x00013E94
		Friend Overridable Property DataGridViewTextBoxColumn135 As DataGridViewTextBoxColumn

		' Token: 0x17000C02 RID: 3074
		' (get) Token: 0x06001E78 RID: 7800 RVA: 0x00015C9D File Offset: 0x00013E9D
		' (set) Token: 0x06001E79 RID: 7801 RVA: 0x00015CA7 File Offset: 0x00013EA7
		Friend Overridable Property DataGridViewTextBoxColumn136 As DataGridViewTextBoxColumn

		' Token: 0x17000C03 RID: 3075
		' (get) Token: 0x06001E7A RID: 7802 RVA: 0x00015CB0 File Offset: 0x00013EB0
		' (set) Token: 0x06001E7B RID: 7803 RVA: 0x00015CBA File Offset: 0x00013EBA
		Friend Overridable Property DataGridViewTextBoxColumn137 As DataGridViewTextBoxColumn

		' Token: 0x17000C04 RID: 3076
		' (get) Token: 0x06001E7C RID: 7804 RVA: 0x00015CC3 File Offset: 0x00013EC3
		' (set) Token: 0x06001E7D RID: 7805 RVA: 0x00015CCD File Offset: 0x00013ECD
		Friend Overridable Property DataGridViewTextBoxColumn138 As DataGridViewTextBoxColumn

		' Token: 0x17000C05 RID: 3077
		' (get) Token: 0x06001E7E RID: 7806 RVA: 0x00015CD6 File Offset: 0x00013ED6
		' (set) Token: 0x06001E7F RID: 7807 RVA: 0x00015CE0 File Offset: 0x00013EE0
		Friend Overridable Property DataGridViewTextBoxColumn139 As DataGridViewTextBoxColumn

		' Token: 0x17000C06 RID: 3078
		' (get) Token: 0x06001E80 RID: 7808 RVA: 0x00015CE9 File Offset: 0x00013EE9
		' (set) Token: 0x06001E81 RID: 7809 RVA: 0x00015CF3 File Offset: 0x00013EF3
		Friend Overridable Property DataGridViewTextBoxColumn140 As DataGridViewTextBoxColumn

		' Token: 0x17000C07 RID: 3079
		' (get) Token: 0x06001E82 RID: 7810 RVA: 0x00015CFC File Offset: 0x00013EFC
		' (set) Token: 0x06001E83 RID: 7811 RVA: 0x00015D06 File Offset: 0x00013F06
		Friend Overridable Property DataGridViewTextBoxColumn141 As DataGridViewTextBoxColumn

		' Token: 0x17000C08 RID: 3080
		' (get) Token: 0x06001E84 RID: 7812 RVA: 0x00015D0F File Offset: 0x00013F0F
		' (set) Token: 0x06001E85 RID: 7813 RVA: 0x00015D19 File Offset: 0x00013F19
		Friend Overridable Property DataGridViewTextBoxColumn142 As DataGridViewTextBoxColumn

		' Token: 0x17000C09 RID: 3081
		' (get) Token: 0x06001E86 RID: 7814 RVA: 0x00015D22 File Offset: 0x00013F22
		' (set) Token: 0x06001E87 RID: 7815 RVA: 0x00015D2C File Offset: 0x00013F2C
		Friend Overridable Property DataGridViewTextBoxColumn143 As DataGridViewTextBoxColumn

		' Token: 0x17000C0A RID: 3082
		' (get) Token: 0x06001E88 RID: 7816 RVA: 0x00015D35 File Offset: 0x00013F35
		' (set) Token: 0x06001E89 RID: 7817 RVA: 0x00015D3F File Offset: 0x00013F3F
		Friend Overridable Property DataGridViewTextBoxColumn144 As DataGridViewTextBoxColumn

		' Token: 0x17000C0B RID: 3083
		' (get) Token: 0x06001E8A RID: 7818 RVA: 0x00015D48 File Offset: 0x00013F48
		' (set) Token: 0x06001E8B RID: 7819 RVA: 0x00015D52 File Offset: 0x00013F52
		Friend Overridable Property DataGridViewTextBoxColumn145 As DataGridViewTextBoxColumn

		' Token: 0x17000C0C RID: 3084
		' (get) Token: 0x06001E8C RID: 7820 RVA: 0x00015D5B File Offset: 0x00013F5B
		' (set) Token: 0x06001E8D RID: 7821 RVA: 0x00015D65 File Offset: 0x00013F65
		Friend Overridable Property DataGridViewTextBoxColumn146 As DataGridViewTextBoxColumn

		' Token: 0x17000C0D RID: 3085
		' (get) Token: 0x06001E8E RID: 7822 RVA: 0x00015D6E File Offset: 0x00013F6E
		' (set) Token: 0x06001E8F RID: 7823 RVA: 0x00015D78 File Offset: 0x00013F78
		Friend Overridable Property DataGridViewTextBoxColumn147 As DataGridViewTextBoxColumn

		' Token: 0x17000C0E RID: 3086
		' (get) Token: 0x06001E90 RID: 7824 RVA: 0x00015D81 File Offset: 0x00013F81
		' (set) Token: 0x06001E91 RID: 7825 RVA: 0x00015D8B File Offset: 0x00013F8B
		Friend Overridable Property DataGridViewTextBoxColumn148 As DataGridViewTextBoxColumn

		' Token: 0x17000C0F RID: 3087
		' (get) Token: 0x06001E92 RID: 7826 RVA: 0x00015D94 File Offset: 0x00013F94
		' (set) Token: 0x06001E93 RID: 7827 RVA: 0x00015D9E File Offset: 0x00013F9E
		Friend Overridable Property DataGridViewTextBoxColumn149 As DataGridViewTextBoxColumn

		' Token: 0x17000C10 RID: 3088
		' (get) Token: 0x06001E94 RID: 7828 RVA: 0x00015DA7 File Offset: 0x00013FA7
		' (set) Token: 0x06001E95 RID: 7829 RVA: 0x00015DB1 File Offset: 0x00013FB1
		Friend Overridable Property DataGridViewTextBoxColumn150 As DataGridViewTextBoxColumn

		' Token: 0x17000C11 RID: 3089
		' (get) Token: 0x06001E96 RID: 7830 RVA: 0x00015DBA File Offset: 0x00013FBA
		' (set) Token: 0x06001E97 RID: 7831 RVA: 0x00015DC4 File Offset: 0x00013FC4
		Friend Overridable Property DataGridViewTextBoxColumn151 As DataGridViewTextBoxColumn

		' Token: 0x17000C12 RID: 3090
		' (get) Token: 0x06001E98 RID: 7832 RVA: 0x00015DCD File Offset: 0x00013FCD
		' (set) Token: 0x06001E99 RID: 7833 RVA: 0x00015DD7 File Offset: 0x00013FD7
		Friend Overridable Property DataGridViewTextBoxColumn152 As DataGridViewTextBoxColumn

		' Token: 0x17000C13 RID: 3091
		' (get) Token: 0x06001E9A RID: 7834 RVA: 0x00015DE0 File Offset: 0x00013FE0
		' (set) Token: 0x06001E9B RID: 7835 RVA: 0x00015DEA File Offset: 0x00013FEA
		Friend Overridable Property DataGridViewTextBoxColumn153 As DataGridViewTextBoxColumn

		' Token: 0x17000C14 RID: 3092
		' (get) Token: 0x06001E9C RID: 7836 RVA: 0x00015DF3 File Offset: 0x00013FF3
		' (set) Token: 0x06001E9D RID: 7837 RVA: 0x00015DFD File Offset: 0x00013FFD
		Friend Overridable Property DataGridViewTextBoxColumn154 As DataGridViewTextBoxColumn

		' Token: 0x17000C15 RID: 3093
		' (get) Token: 0x06001E9E RID: 7838 RVA: 0x00015E06 File Offset: 0x00014006
		' (set) Token: 0x06001E9F RID: 7839 RVA: 0x00015E10 File Offset: 0x00014010
		Friend Overridable Property DataGridViewTextBoxColumn155 As DataGridViewTextBoxColumn

		' Token: 0x17000C16 RID: 3094
		' (get) Token: 0x06001EA0 RID: 7840 RVA: 0x00015E19 File Offset: 0x00014019
		' (set) Token: 0x06001EA1 RID: 7841 RVA: 0x00015E23 File Offset: 0x00014023
		Friend Overridable Property DataGridViewTextBoxColumn156 As DataGridViewTextBoxColumn

		' Token: 0x17000C17 RID: 3095
		' (get) Token: 0x06001EA2 RID: 7842 RVA: 0x00015E2C File Offset: 0x0001402C
		' (set) Token: 0x06001EA3 RID: 7843 RVA: 0x00015E36 File Offset: 0x00014036
		Friend Overridable Property DataGridViewTextBoxColumn157 As DataGridViewTextBoxColumn

		' Token: 0x17000C18 RID: 3096
		' (get) Token: 0x06001EA4 RID: 7844 RVA: 0x00015E3F File Offset: 0x0001403F
		' (set) Token: 0x06001EA5 RID: 7845 RVA: 0x00015E49 File Offset: 0x00014049
		Friend Overridable Property DataGridViewTextBoxColumn158 As DataGridViewTextBoxColumn

		' Token: 0x17000C19 RID: 3097
		' (get) Token: 0x06001EA6 RID: 7846 RVA: 0x00015E52 File Offset: 0x00014052
		' (set) Token: 0x06001EA7 RID: 7847 RVA: 0x00015E5C File Offset: 0x0001405C
		Friend Overridable Property DataGridViewTextBoxColumn159 As DataGridViewTextBoxColumn

		' Token: 0x17000C1A RID: 3098
		' (get) Token: 0x06001EA8 RID: 7848 RVA: 0x00015E65 File Offset: 0x00014065
		' (set) Token: 0x06001EA9 RID: 7849 RVA: 0x00140AD4 File Offset: 0x0013ECD4
		Private _DataGridView7 As DataGridView
		Friend Overridable Property DataGridView7 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView7_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView7
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView7 = value
				dataGridView = Me._DataGridView7
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000C1B RID: 3099
		' (get) Token: 0x06001EAA RID: 7850 RVA: 0x00015E6F File Offset: 0x0001406F
		' (set) Token: 0x06001EAB RID: 7851 RVA: 0x00015E79 File Offset: 0x00014079
		Friend Overridable Property DataGridViewTextBoxColumn160 As DataGridViewTextBoxColumn

		' Token: 0x17000C1C RID: 3100
		' (get) Token: 0x06001EAC RID: 7852 RVA: 0x00015E82 File Offset: 0x00014082
		' (set) Token: 0x06001EAD RID: 7853 RVA: 0x00015E8C File Offset: 0x0001408C
		Friend Overridable Property DataGridViewTextBoxColumn161 As DataGridViewTextBoxColumn

		' Token: 0x17000C1D RID: 3101
		' (get) Token: 0x06001EAE RID: 7854 RVA: 0x00015E95 File Offset: 0x00014095
		' (set) Token: 0x06001EAF RID: 7855 RVA: 0x00015E9F File Offset: 0x0001409F
		Friend Overridable Property DataGridViewTextBoxColumn162 As DataGridViewTextBoxColumn

		' Token: 0x17000C1E RID: 3102
		' (get) Token: 0x06001EB0 RID: 7856 RVA: 0x00015EA8 File Offset: 0x000140A8
		' (set) Token: 0x06001EB1 RID: 7857 RVA: 0x00015EB2 File Offset: 0x000140B2
		Friend Overridable Property DataGridViewTextBoxColumn163 As DataGridViewTextBoxColumn

		' Token: 0x17000C1F RID: 3103
		' (get) Token: 0x06001EB2 RID: 7858 RVA: 0x00015EBB File Offset: 0x000140BB
		' (set) Token: 0x06001EB3 RID: 7859 RVA: 0x00015EC5 File Offset: 0x000140C5
		Friend Overridable Property DataGridViewTextBoxColumn164 As DataGridViewTextBoxColumn

		' Token: 0x17000C20 RID: 3104
		' (get) Token: 0x06001EB4 RID: 7860 RVA: 0x00015ECE File Offset: 0x000140CE
		' (set) Token: 0x06001EB5 RID: 7861 RVA: 0x00015ED8 File Offset: 0x000140D8
		Friend Overridable Property DataGridViewTextBoxColumn165 As DataGridViewTextBoxColumn

		' Token: 0x17000C21 RID: 3105
		' (get) Token: 0x06001EB6 RID: 7862 RVA: 0x00015EE1 File Offset: 0x000140E1
		' (set) Token: 0x06001EB7 RID: 7863 RVA: 0x00015EEB File Offset: 0x000140EB
		Friend Overridable Property DataGridViewTextBoxColumn166 As DataGridViewTextBoxColumn

		' Token: 0x17000C22 RID: 3106
		' (get) Token: 0x06001EB8 RID: 7864 RVA: 0x00015EF4 File Offset: 0x000140F4
		' (set) Token: 0x06001EB9 RID: 7865 RVA: 0x00015EFE File Offset: 0x000140FE
		Friend Overridable Property DataGridViewTextBoxColumn167 As DataGridViewTextBoxColumn

		' Token: 0x17000C23 RID: 3107
		' (get) Token: 0x06001EBA RID: 7866 RVA: 0x00015F07 File Offset: 0x00014107
		' (set) Token: 0x06001EBB RID: 7867 RVA: 0x00015F11 File Offset: 0x00014111
		Friend Overridable Property DataGridViewTextBoxColumn168 As DataGridViewTextBoxColumn

		' Token: 0x17000C24 RID: 3108
		' (get) Token: 0x06001EBC RID: 7868 RVA: 0x00015F1A File Offset: 0x0001411A
		' (set) Token: 0x06001EBD RID: 7869 RVA: 0x00015F24 File Offset: 0x00014124
		Friend Overridable Property DataGridViewTextBoxColumn169 As DataGridViewTextBoxColumn

		' Token: 0x17000C25 RID: 3109
		' (get) Token: 0x06001EBE RID: 7870 RVA: 0x00015F2D File Offset: 0x0001412D
		' (set) Token: 0x06001EBF RID: 7871 RVA: 0x00015F37 File Offset: 0x00014137
		Friend Overridable Property DataGridViewTextBoxColumn170 As DataGridViewTextBoxColumn

		' Token: 0x17000C26 RID: 3110
		' (get) Token: 0x06001EC0 RID: 7872 RVA: 0x00015F40 File Offset: 0x00014140
		' (set) Token: 0x06001EC1 RID: 7873 RVA: 0x00015F4A File Offset: 0x0001414A
		Friend Overridable Property DataGridViewTextBoxColumn171 As DataGridViewTextBoxColumn

		' Token: 0x17000C27 RID: 3111
		' (get) Token: 0x06001EC2 RID: 7874 RVA: 0x00015F53 File Offset: 0x00014153
		' (set) Token: 0x06001EC3 RID: 7875 RVA: 0x00015F5D File Offset: 0x0001415D
		Friend Overridable Property DataGridViewTextBoxColumn172 As DataGridViewTextBoxColumn

		' Token: 0x17000C28 RID: 3112
		' (get) Token: 0x06001EC4 RID: 7876 RVA: 0x00015F66 File Offset: 0x00014166
		' (set) Token: 0x06001EC5 RID: 7877 RVA: 0x00015F70 File Offset: 0x00014170
		Friend Overridable Property DataGridViewTextBoxColumn173 As DataGridViewTextBoxColumn

		' Token: 0x17000C29 RID: 3113
		' (get) Token: 0x06001EC6 RID: 7878 RVA: 0x00015F79 File Offset: 0x00014179
		' (set) Token: 0x06001EC7 RID: 7879 RVA: 0x00015F83 File Offset: 0x00014183
		Friend Overridable Property DataGridViewTextBoxColumn174 As DataGridViewTextBoxColumn

		' Token: 0x17000C2A RID: 3114
		' (get) Token: 0x06001EC8 RID: 7880 RVA: 0x00015F8C File Offset: 0x0001418C
		' (set) Token: 0x06001EC9 RID: 7881 RVA: 0x00015F96 File Offset: 0x00014196
		Friend Overridable Property DataGridViewTextBoxColumn175 As DataGridViewTextBoxColumn

		' Token: 0x17000C2B RID: 3115
		' (get) Token: 0x06001ECA RID: 7882 RVA: 0x00015F9F File Offset: 0x0001419F
		' (set) Token: 0x06001ECB RID: 7883 RVA: 0x00015FA9 File Offset: 0x000141A9
		Friend Overridable Property DataGridViewTextBoxColumn176 As DataGridViewTextBoxColumn

		' Token: 0x17000C2C RID: 3116
		' (get) Token: 0x06001ECC RID: 7884 RVA: 0x00015FB2 File Offset: 0x000141B2
		' (set) Token: 0x06001ECD RID: 7885 RVA: 0x00015FBC File Offset: 0x000141BC
		Friend Overridable Property DataGridViewTextBoxColumn177 As DataGridViewTextBoxColumn

		' Token: 0x17000C2D RID: 3117
		' (get) Token: 0x06001ECE RID: 7886 RVA: 0x00015FC5 File Offset: 0x000141C5
		' (set) Token: 0x06001ECF RID: 7887 RVA: 0x00015FCF File Offset: 0x000141CF
		Friend Overridable Property DataGridViewTextBoxColumn178 As DataGridViewTextBoxColumn

		' Token: 0x17000C2E RID: 3118
		' (get) Token: 0x06001ED0 RID: 7888 RVA: 0x00015FD8 File Offset: 0x000141D8
		' (set) Token: 0x06001ED1 RID: 7889 RVA: 0x00015FE2 File Offset: 0x000141E2
		Friend Overridable Property DataGridViewTextBoxColumn179 As DataGridViewTextBoxColumn

		' Token: 0x17000C2F RID: 3119
		' (get) Token: 0x06001ED2 RID: 7890 RVA: 0x00015FEB File Offset: 0x000141EB
		' (set) Token: 0x06001ED3 RID: 7891 RVA: 0x00015FF5 File Offset: 0x000141F5
		Friend Overridable Property DataGridViewTextBoxColumn180 As DataGridViewTextBoxColumn

		' Token: 0x17000C30 RID: 3120
		' (get) Token: 0x06001ED4 RID: 7892 RVA: 0x00015FFE File Offset: 0x000141FE
		' (set) Token: 0x06001ED5 RID: 7893 RVA: 0x00016008 File Offset: 0x00014208
		Friend Overridable Property DataGridViewTextBoxColumn181 As DataGridViewTextBoxColumn

		' Token: 0x17000C31 RID: 3121
		' (get) Token: 0x06001ED6 RID: 7894 RVA: 0x00016011 File Offset: 0x00014211
		' (set) Token: 0x06001ED7 RID: 7895 RVA: 0x0001601B File Offset: 0x0001421B
		Friend Overridable Property DataGridViewTextBoxColumn182 As DataGridViewTextBoxColumn

		' Token: 0x17000C32 RID: 3122
		' (get) Token: 0x06001ED8 RID: 7896 RVA: 0x00016024 File Offset: 0x00014224
		' (set) Token: 0x06001ED9 RID: 7897 RVA: 0x0001602E File Offset: 0x0001422E
		Friend Overridable Property DataGridViewTextBoxColumn183 As DataGridViewTextBoxColumn

		' Token: 0x17000C33 RID: 3123
		' (get) Token: 0x06001EDA RID: 7898 RVA: 0x00016037 File Offset: 0x00014237
		' (set) Token: 0x06001EDB RID: 7899 RVA: 0x00016041 File Offset: 0x00014241
		Friend Overridable Property DataGridViewTextBoxColumn184 As DataGridViewTextBoxColumn

		' Token: 0x17000C34 RID: 3124
		' (get) Token: 0x06001EDC RID: 7900 RVA: 0x0001604A File Offset: 0x0001424A
		' (set) Token: 0x06001EDD RID: 7901 RVA: 0x00016054 File Offset: 0x00014254
		Friend Overridable Property DataGridView8 As DataGridView

		' Token: 0x17000C35 RID: 3125
		' (get) Token: 0x06001EDE RID: 7902 RVA: 0x0001605D File Offset: 0x0001425D
		' (set) Token: 0x06001EDF RID: 7903 RVA: 0x00016067 File Offset: 0x00014267
		Friend Overridable Property DataGridViewTextBoxColumn185 As DataGridViewTextBoxColumn

		' Token: 0x17000C36 RID: 3126
		' (get) Token: 0x06001EE0 RID: 7904 RVA: 0x00016070 File Offset: 0x00014270
		' (set) Token: 0x06001EE1 RID: 7905 RVA: 0x0001607A File Offset: 0x0001427A
		Friend Overridable Property DataGridViewTextBoxColumn186 As DataGridViewTextBoxColumn

		' Token: 0x17000C37 RID: 3127
		' (get) Token: 0x06001EE2 RID: 7906 RVA: 0x00016083 File Offset: 0x00014283
		' (set) Token: 0x06001EE3 RID: 7907 RVA: 0x0001608D File Offset: 0x0001428D
		Friend Overridable Property DataGridViewTextBoxColumn187 As DataGridViewTextBoxColumn

		' Token: 0x17000C38 RID: 3128
		' (get) Token: 0x06001EE4 RID: 7908 RVA: 0x00016096 File Offset: 0x00014296
		' (set) Token: 0x06001EE5 RID: 7909 RVA: 0x000160A0 File Offset: 0x000142A0
		Friend Overridable Property DataGridViewTextBoxColumn188 As DataGridViewTextBoxColumn

		' Token: 0x17000C39 RID: 3129
		' (get) Token: 0x06001EE6 RID: 7910 RVA: 0x000160A9 File Offset: 0x000142A9
		' (set) Token: 0x06001EE7 RID: 7911 RVA: 0x000160B3 File Offset: 0x000142B3
		Friend Overridable Property DataGridViewTextBoxColumn189 As DataGridViewTextBoxColumn

		' Token: 0x17000C3A RID: 3130
		' (get) Token: 0x06001EE8 RID: 7912 RVA: 0x000160BC File Offset: 0x000142BC
		' (set) Token: 0x06001EE9 RID: 7913 RVA: 0x000160C6 File Offset: 0x000142C6
		Friend Overridable Property DataGridViewTextBoxColumn190 As DataGridViewTextBoxColumn

		' Token: 0x17000C3B RID: 3131
		' (get) Token: 0x06001EEA RID: 7914 RVA: 0x000160CF File Offset: 0x000142CF
		' (set) Token: 0x06001EEB RID: 7915 RVA: 0x000160D9 File Offset: 0x000142D9
		Friend Overridable Property DataGridViewTextBoxColumn191 As DataGridViewTextBoxColumn

		' Token: 0x17000C3C RID: 3132
		' (get) Token: 0x06001EEC RID: 7916 RVA: 0x000160E2 File Offset: 0x000142E2
		' (set) Token: 0x06001EED RID: 7917 RVA: 0x000160EC File Offset: 0x000142EC
		Friend Overridable Property DataGridViewTextBoxColumn192 As DataGridViewTextBoxColumn

		' Token: 0x17000C3D RID: 3133
		' (get) Token: 0x06001EEE RID: 7918 RVA: 0x000160F5 File Offset: 0x000142F5
		' (set) Token: 0x06001EEF RID: 7919 RVA: 0x000160FF File Offset: 0x000142FF
		Friend Overridable Property DataGridViewTextBoxColumn193 As DataGridViewTextBoxColumn

		' Token: 0x17000C3E RID: 3134
		' (get) Token: 0x06001EF0 RID: 7920 RVA: 0x00016108 File Offset: 0x00014308
		' (set) Token: 0x06001EF1 RID: 7921 RVA: 0x00016112 File Offset: 0x00014312
		Friend Overridable Property DataGridViewTextBoxColumn194 As DataGridViewTextBoxColumn

		' Token: 0x17000C3F RID: 3135
		' (get) Token: 0x06001EF2 RID: 7922 RVA: 0x0001611B File Offset: 0x0001431B
		' (set) Token: 0x06001EF3 RID: 7923 RVA: 0x00016125 File Offset: 0x00014325
		Friend Overridable Property DataGridViewTextBoxColumn195 As DataGridViewTextBoxColumn

		' Token: 0x17000C40 RID: 3136
		' (get) Token: 0x06001EF4 RID: 7924 RVA: 0x0001612E File Offset: 0x0001432E
		' (set) Token: 0x06001EF5 RID: 7925 RVA: 0x00016138 File Offset: 0x00014338
		Friend Overridable Property DataGridViewTextBoxColumn196 As DataGridViewTextBoxColumn

		' Token: 0x17000C41 RID: 3137
		' (get) Token: 0x06001EF6 RID: 7926 RVA: 0x00016141 File Offset: 0x00014341
		' (set) Token: 0x06001EF7 RID: 7927 RVA: 0x0001614B File Offset: 0x0001434B
		Friend Overridable Property DataGridViewTextBoxColumn197 As DataGridViewTextBoxColumn

		' Token: 0x17000C42 RID: 3138
		' (get) Token: 0x06001EF8 RID: 7928 RVA: 0x00016154 File Offset: 0x00014354
		' (set) Token: 0x06001EF9 RID: 7929 RVA: 0x0001615E File Offset: 0x0001435E
		Friend Overridable Property DataGridViewTextBoxColumn198 As DataGridViewTextBoxColumn

		' Token: 0x17000C43 RID: 3139
		' (get) Token: 0x06001EFA RID: 7930 RVA: 0x00016167 File Offset: 0x00014367
		' (set) Token: 0x06001EFB RID: 7931 RVA: 0x00016171 File Offset: 0x00014371
		Friend Overridable Property DataGridViewTextBoxColumn199 As DataGridViewTextBoxColumn

		' Token: 0x17000C44 RID: 3140
		' (get) Token: 0x06001EFC RID: 7932 RVA: 0x0001617A File Offset: 0x0001437A
		' (set) Token: 0x06001EFD RID: 7933 RVA: 0x00016184 File Offset: 0x00014384
		Friend Overridable Property DataGridViewTextBoxColumn200 As DataGridViewTextBoxColumn

		' Token: 0x17000C45 RID: 3141
		' (get) Token: 0x06001EFE RID: 7934 RVA: 0x0001618D File Offset: 0x0001438D
		' (set) Token: 0x06001EFF RID: 7935 RVA: 0x00016197 File Offset: 0x00014397
		Friend Overridable Property DataGridViewTextBoxColumn201 As DataGridViewTextBoxColumn

		' Token: 0x17000C46 RID: 3142
		' (get) Token: 0x06001F00 RID: 7936 RVA: 0x000161A0 File Offset: 0x000143A0
		' (set) Token: 0x06001F01 RID: 7937 RVA: 0x000161AA File Offset: 0x000143AA
		Friend Overridable Property DataGridViewTextBoxColumn202 As DataGridViewTextBoxColumn

		' Token: 0x17000C47 RID: 3143
		' (get) Token: 0x06001F02 RID: 7938 RVA: 0x000161B3 File Offset: 0x000143B3
		' (set) Token: 0x06001F03 RID: 7939 RVA: 0x000161BD File Offset: 0x000143BD
		Friend Overridable Property DataGridViewTextBoxColumn203 As DataGridViewTextBoxColumn

		' Token: 0x17000C48 RID: 3144
		' (get) Token: 0x06001F04 RID: 7940 RVA: 0x000161C6 File Offset: 0x000143C6
		' (set) Token: 0x06001F05 RID: 7941 RVA: 0x000161D0 File Offset: 0x000143D0
		Friend Overridable Property DataGridViewTextBoxColumn204 As DataGridViewTextBoxColumn

		' Token: 0x17000C49 RID: 3145
		' (get) Token: 0x06001F06 RID: 7942 RVA: 0x000161D9 File Offset: 0x000143D9
		' (set) Token: 0x06001F07 RID: 7943 RVA: 0x000161E3 File Offset: 0x000143E3
		Friend Overridable Property DataGridViewTextBoxColumn205 As DataGridViewTextBoxColumn

		' Token: 0x17000C4A RID: 3146
		' (get) Token: 0x06001F08 RID: 7944 RVA: 0x000161EC File Offset: 0x000143EC
		' (set) Token: 0x06001F09 RID: 7945 RVA: 0x000161F6 File Offset: 0x000143F6
		Friend Overridable Property DataGridViewTextBoxColumn206 As DataGridViewTextBoxColumn

		' Token: 0x17000C4B RID: 3147
		' (get) Token: 0x06001F0A RID: 7946 RVA: 0x000161FF File Offset: 0x000143FF
		' (set) Token: 0x06001F0B RID: 7947 RVA: 0x00016209 File Offset: 0x00014409
		Friend Overridable Property DataGridViewTextBoxColumn207 As DataGridViewTextBoxColumn

		' Token: 0x17000C4C RID: 3148
		' (get) Token: 0x06001F0C RID: 7948 RVA: 0x00016212 File Offset: 0x00014412
		' (set) Token: 0x06001F0D RID: 7949 RVA: 0x0001621C File Offset: 0x0001441C
		Friend Overridable Property DataGridViewTextBoxColumn208 As DataGridViewTextBoxColumn

		' Token: 0x17000C4D RID: 3149
		' (get) Token: 0x06001F0E RID: 7950 RVA: 0x00016225 File Offset: 0x00014425
		' (set) Token: 0x06001F0F RID: 7951 RVA: 0x0001622F File Offset: 0x0001442F
		Friend Overridable Property DataGridViewTextBoxColumn209 As DataGridViewTextBoxColumn

		' Token: 0x17000C4E RID: 3150
		' (get) Token: 0x06001F10 RID: 7952 RVA: 0x00016238 File Offset: 0x00014438
		' (set) Token: 0x06001F11 RID: 7953 RVA: 0x00016242 File Offset: 0x00014442
		Friend Overridable Property DataGridViewTextBoxColumn210 As DataGridViewTextBoxColumn

		' Token: 0x17000C4F RID: 3151
		' (get) Token: 0x06001F12 RID: 7954 RVA: 0x0001624B File Offset: 0x0001444B
		' (set) Token: 0x06001F13 RID: 7955 RVA: 0x00016255 File Offset: 0x00014455
		Friend Overridable Property DataGridViewTextBoxColumn211 As DataGridViewTextBoxColumn

		' Token: 0x17000C50 RID: 3152
		' (get) Token: 0x06001F14 RID: 7956 RVA: 0x0001625E File Offset: 0x0001445E
		' (set) Token: 0x06001F15 RID: 7957 RVA: 0x00016268 File Offset: 0x00014468
		Friend Overridable Property DataGridViewTextBoxColumn212 As DataGridViewTextBoxColumn

		' Token: 0x17000C51 RID: 3153
		' (get) Token: 0x06001F16 RID: 7958 RVA: 0x00016271 File Offset: 0x00014471
		' (set) Token: 0x06001F17 RID: 7959 RVA: 0x0001627B File Offset: 0x0001447B
		Friend Overridable Property DataGridViewTextBoxColumn213 As DataGridViewTextBoxColumn

		' Token: 0x17000C52 RID: 3154
		' (get) Token: 0x06001F18 RID: 7960 RVA: 0x00016284 File Offset: 0x00014484
		' (set) Token: 0x06001F19 RID: 7961 RVA: 0x0001628E File Offset: 0x0001448E
		Friend Overridable Property DataGridViewTextBoxColumn214 As DataGridViewTextBoxColumn

		' Token: 0x17000C53 RID: 3155
		' (get) Token: 0x06001F1A RID: 7962 RVA: 0x00016297 File Offset: 0x00014497
		' (set) Token: 0x06001F1B RID: 7963 RVA: 0x000162A1 File Offset: 0x000144A1
		Friend Overridable Property DataGridViewTextBoxColumn215 As DataGridViewTextBoxColumn

		' Token: 0x17000C54 RID: 3156
		' (get) Token: 0x06001F1C RID: 7964 RVA: 0x000162AA File Offset: 0x000144AA
		' (set) Token: 0x06001F1D RID: 7965 RVA: 0x000162B4 File Offset: 0x000144B4
		Friend Overridable Property DataGridViewTextBoxColumn216 As DataGridViewTextBoxColumn

		' Token: 0x17000C55 RID: 3157
		' (get) Token: 0x06001F1E RID: 7966 RVA: 0x000162BD File Offset: 0x000144BD
		' (set) Token: 0x06001F1F RID: 7967 RVA: 0x000162C7 File Offset: 0x000144C7
		Friend Overridable Property DataGridView9 As DataGridView

		' Token: 0x17000C56 RID: 3158
		' (get) Token: 0x06001F20 RID: 7968 RVA: 0x000162D0 File Offset: 0x000144D0
		' (set) Token: 0x06001F21 RID: 7969 RVA: 0x000162DA File Offset: 0x000144DA
		Friend Overridable Property DataGridViewTextBoxColumn217 As DataGridViewTextBoxColumn

		' Token: 0x17000C57 RID: 3159
		' (get) Token: 0x06001F22 RID: 7970 RVA: 0x000162E3 File Offset: 0x000144E3
		' (set) Token: 0x06001F23 RID: 7971 RVA: 0x000162ED File Offset: 0x000144ED
		Friend Overridable Property DataGridViewTextBoxColumn218 As DataGridViewTextBoxColumn

		' Token: 0x17000C58 RID: 3160
		' (get) Token: 0x06001F24 RID: 7972 RVA: 0x000162F6 File Offset: 0x000144F6
		' (set) Token: 0x06001F25 RID: 7973 RVA: 0x00016300 File Offset: 0x00014500
		Friend Overridable Property DataGridViewTextBoxColumn219 As DataGridViewTextBoxColumn

		' Token: 0x17000C59 RID: 3161
		' (get) Token: 0x06001F26 RID: 7974 RVA: 0x00016309 File Offset: 0x00014509
		' (set) Token: 0x06001F27 RID: 7975 RVA: 0x00016313 File Offset: 0x00014513
		Friend Overridable Property DataGridViewTextBoxColumn220 As DataGridViewTextBoxColumn

		' Token: 0x17000C5A RID: 3162
		' (get) Token: 0x06001F28 RID: 7976 RVA: 0x0001631C File Offset: 0x0001451C
		' (set) Token: 0x06001F29 RID: 7977 RVA: 0x00016326 File Offset: 0x00014526
		Friend Overridable Property DataGridViewTextBoxColumn221 As DataGridViewTextBoxColumn

		' Token: 0x17000C5B RID: 3163
		' (get) Token: 0x06001F2A RID: 7978 RVA: 0x0001632F File Offset: 0x0001452F
		' (set) Token: 0x06001F2B RID: 7979 RVA: 0x00016339 File Offset: 0x00014539
		Friend Overridable Property DataGridViewTextBoxColumn222 As DataGridViewTextBoxColumn

		' Token: 0x17000C5C RID: 3164
		' (get) Token: 0x06001F2C RID: 7980 RVA: 0x00016342 File Offset: 0x00014542
		' (set) Token: 0x06001F2D RID: 7981 RVA: 0x0001634C File Offset: 0x0001454C
		Friend Overridable Property DataGridViewTextBoxColumn223 As DataGridViewTextBoxColumn

		' Token: 0x17000C5D RID: 3165
		' (get) Token: 0x06001F2E RID: 7982 RVA: 0x00016355 File Offset: 0x00014555
		' (set) Token: 0x06001F2F RID: 7983 RVA: 0x0001635F File Offset: 0x0001455F
		Friend Overridable Property DataGridViewTextBoxColumn224 As DataGridViewTextBoxColumn

		' Token: 0x17000C5E RID: 3166
		' (get) Token: 0x06001F30 RID: 7984 RVA: 0x00016368 File Offset: 0x00014568
		' (set) Token: 0x06001F31 RID: 7985 RVA: 0x00016372 File Offset: 0x00014572
		Friend Overridable Property DataGridViewTextBoxColumn225 As DataGridViewTextBoxColumn

		' Token: 0x17000C5F RID: 3167
		' (get) Token: 0x06001F32 RID: 7986 RVA: 0x0001637B File Offset: 0x0001457B
		' (set) Token: 0x06001F33 RID: 7987 RVA: 0x00016385 File Offset: 0x00014585
		Friend Overridable Property DataGridViewTextBoxColumn226 As DataGridViewTextBoxColumn

		' Token: 0x17000C60 RID: 3168
		' (get) Token: 0x06001F34 RID: 7988 RVA: 0x0001638E File Offset: 0x0001458E
		' (set) Token: 0x06001F35 RID: 7989 RVA: 0x00016398 File Offset: 0x00014598
		Friend Overridable Property DataGridViewTextBoxColumn227 As DataGridViewTextBoxColumn

		' Token: 0x17000C61 RID: 3169
		' (get) Token: 0x06001F36 RID: 7990 RVA: 0x000163A1 File Offset: 0x000145A1
		' (set) Token: 0x06001F37 RID: 7991 RVA: 0x000163AB File Offset: 0x000145AB
		Friend Overridable Property DataGridViewTextBoxColumn228 As DataGridViewTextBoxColumn

		' Token: 0x17000C62 RID: 3170
		' (get) Token: 0x06001F38 RID: 7992 RVA: 0x000163B4 File Offset: 0x000145B4
		' (set) Token: 0x06001F39 RID: 7993 RVA: 0x000163BE File Offset: 0x000145BE
		Friend Overridable Property DataGridViewTextBoxColumn229 As DataGridViewTextBoxColumn

		' Token: 0x17000C63 RID: 3171
		' (get) Token: 0x06001F3A RID: 7994 RVA: 0x000163C7 File Offset: 0x000145C7
		' (set) Token: 0x06001F3B RID: 7995 RVA: 0x000163D1 File Offset: 0x000145D1
		Friend Overridable Property DataGridViewTextBoxColumn230 As DataGridViewTextBoxColumn

		' Token: 0x17000C64 RID: 3172
		' (get) Token: 0x06001F3C RID: 7996 RVA: 0x000163DA File Offset: 0x000145DA
		' (set) Token: 0x06001F3D RID: 7997 RVA: 0x000163E4 File Offset: 0x000145E4
		Friend Overridable Property DataGridViewTextBoxColumn231 As DataGridViewTextBoxColumn

		' Token: 0x17000C65 RID: 3173
		' (get) Token: 0x06001F3E RID: 7998 RVA: 0x000163ED File Offset: 0x000145ED
		' (set) Token: 0x06001F3F RID: 7999 RVA: 0x000163F7 File Offset: 0x000145F7
		Friend Overridable Property DataGridViewTextBoxColumn232 As DataGridViewTextBoxColumn

		' Token: 0x17000C66 RID: 3174
		' (get) Token: 0x06001F40 RID: 8000 RVA: 0x00016400 File Offset: 0x00014600
		' (set) Token: 0x06001F41 RID: 8001 RVA: 0x0001640A File Offset: 0x0001460A
		Friend Overridable Property DataGridViewTextBoxColumn233 As DataGridViewTextBoxColumn

		' Token: 0x17000C67 RID: 3175
		' (get) Token: 0x06001F42 RID: 8002 RVA: 0x00016413 File Offset: 0x00014613
		' (set) Token: 0x06001F43 RID: 8003 RVA: 0x0001641D File Offset: 0x0001461D
		Friend Overridable Property DataGridViewTextBoxColumn234 As DataGridViewTextBoxColumn

		' Token: 0x17000C68 RID: 3176
		' (get) Token: 0x06001F44 RID: 8004 RVA: 0x00016426 File Offset: 0x00014626
		' (set) Token: 0x06001F45 RID: 8005 RVA: 0x00016430 File Offset: 0x00014630
		Friend Overridable Property DataGridViewTextBoxColumn235 As DataGridViewTextBoxColumn

		' Token: 0x17000C69 RID: 3177
		' (get) Token: 0x06001F46 RID: 8006 RVA: 0x00016439 File Offset: 0x00014639
		' (set) Token: 0x06001F47 RID: 8007 RVA: 0x00016443 File Offset: 0x00014643
		Friend Overridable Property DataGridViewTextBoxColumn236 As DataGridViewTextBoxColumn

		' Token: 0x17000C6A RID: 3178
		' (get) Token: 0x06001F48 RID: 8008 RVA: 0x0001644C File Offset: 0x0001464C
		' (set) Token: 0x06001F49 RID: 8009 RVA: 0x00016456 File Offset: 0x00014656
		Friend Overridable Property DataGridViewTextBoxColumn237 As DataGridViewTextBoxColumn

		' Token: 0x17000C6B RID: 3179
		' (get) Token: 0x06001F4A RID: 8010 RVA: 0x0001645F File Offset: 0x0001465F
		' (set) Token: 0x06001F4B RID: 8011 RVA: 0x00016469 File Offset: 0x00014669
		Friend Overridable Property DataGridViewTextBoxColumn238 As DataGridViewTextBoxColumn

		' Token: 0x17000C6C RID: 3180
		' (get) Token: 0x06001F4C RID: 8012 RVA: 0x00016472 File Offset: 0x00014672
		' (set) Token: 0x06001F4D RID: 8013 RVA: 0x0001647C File Offset: 0x0001467C
		Friend Overridable Property DataGridViewTextBoxColumn239 As DataGridViewTextBoxColumn

		' Token: 0x17000C6D RID: 3181
		' (get) Token: 0x06001F4E RID: 8014 RVA: 0x00016485 File Offset: 0x00014685
		' (set) Token: 0x06001F4F RID: 8015 RVA: 0x0001648F File Offset: 0x0001468F
		Friend Overridable Property DataGridViewTextBoxColumn240 As DataGridViewTextBoxColumn

		' Token: 0x17000C6E RID: 3182
		' (get) Token: 0x06001F50 RID: 8016 RVA: 0x00016498 File Offset: 0x00014698
		' (set) Token: 0x06001F51 RID: 8017 RVA: 0x000164A2 File Offset: 0x000146A2
		Friend Overridable Property DataGridViewTextBoxColumn241 As DataGridViewTextBoxColumn

		' Token: 0x06001F52 RID: 8018 RVA: 0x00140B18 File Offset: 0x0013ED18
		Private Sub cmbCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}), "", False) > 0
				If flag Then
					Me.getcustomerdata()
					Me.KeepFirstRowSelected()
				Else
					Me.dgw.Visible = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06001F53 RID: 8019 RVA: 0x00140B94 File Offset: 0x0013ED94
		Private Sub KeepFirstRowSelected()
			Dim flag As Boolean = Me.dgw.Rows.Count > 0
			If flag Then
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Selected = False
						dataGridViewRow.DefaultCellStyle.BackColor = Color.White
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.Rows(0)
				dataGridViewRow2.Selected = True
				dataGridViewRow2.DefaultCellStyle.BackColor = Color.LightBlue
				Me.dgw.CurrentCell = dataGridViewRow2.Cells(0)
			End If
		End Sub

		' Token: 0x06001F54 RID: 8020 RVA: 0x00140C70 File Offset: 0x0013EE70
		Private Sub LoadUsers()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT RTRIM(UserID) AS UserName " & vbCrLf & "                                   FROM Registration " & vbCrLf & "                                   WHERE RTRIM(UserType)='Sales Person'" & vbCrLf & "                                   ORDER BY UserID"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.cmbUser.DataSource = dataTable.Copy()
							Me.cmbUser.DisplayMember = "UserName"
							Me.cmbUser.ValueMember = "UserName"
							Me.cmbUser.SelectedIndex = -1
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading users: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06001F55 RID: 8021 RVA: 0x00140D84 File Offset: 0x0013EF84
		Public Sub getcustomerdata()
			Try
				Me.dgw.Visible = True
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim flag As Boolean = Operators.CompareString(Me.txtContactNo.Text.Trim(), "", False) <> 0
					Dim sqlCommand As SqlCommand
					If flag Then
						Dim text As String = vbCrLf & "                SELECT TOP 5 " & vbCrLf & "                    RTRIM(ID), RTRIM(CustomerID), RTRIM([Name]), RTRIM(Address), RTRIM(City), RTRIM(State), RTRIM(ZipCode)," & vbCrLf & "                    RTRIM(ContactNo), RTRIM(EmailID), RTRIM(GSTIN), RTRIM(CIN), RTRIM(PAN), RTRIM(AccountName), RTRIM(AccountNumber)," & vbCrLf & "                    RTRIM(Bank), RTRIM(Branch), RTRIM(IFSCCode), RTRIM(Remarks), RTRIM(Optype), RTRIM(Opbal), Photo, RTRIM(Tcs)," & vbCrLf & "                    RTRIM(CardNo), RTRIM(Status), RTRIM(Limit), RTRIM(Lstatus), RTRIM(Route), RTRIM(Taround), RTRIM(DiscPer)," & vbCrLf & "                    RTRIM(DiscStatus), RTRIM(OpLoyalitytype), RTRIM(OpbalLoyality), is_loyalityDisable, shippingAddress" & vbCrLf & "                FROM Customer" & vbCrLf & "                WHERE ContactNo LIKE @contactNo" & vbCrLf & "                ORDER BY [Name];"
						sqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@contactNo", Me.txtContactNo.Text + "%")
					Else
						Dim flag2 As Boolean = Operators.CompareString(Me.cmbCustomerName.Text.Trim(), "", False) <> 0
						If Not flag2 Then
							MessageBox.Show("Please enter Contact No or Customer Name to search.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Return
						End If
						Dim text As String = vbCrLf & "                SELECT TOP 5 " & vbCrLf & "                    RTRIM(ID), RTRIM(CustomerID), RTRIM([Name]), RTRIM(Address), RTRIM(City), RTRIM(State), RTRIM(ZipCode)," & vbCrLf & "                    RTRIM(ContactNo), RTRIM(EmailID), RTRIM(GSTIN), RTRIM(CIN), RTRIM(PAN), RTRIM(AccountName), RTRIM(AccountNumber)," & vbCrLf & "                    RTRIM(Bank), RTRIM(Branch), RTRIM(IFSCCode), RTRIM(Remarks), RTRIM(Optype), RTRIM(Opbal), Photo, RTRIM(Tcs)," & vbCrLf & "                    RTRIM(CardNo), RTRIM(Status), RTRIM(Limit), RTRIM(Lstatus), RTRIM(Route), RTRIM(Taround), RTRIM(DiscPer)," & vbCrLf & "                    RTRIM(DiscStatus), RTRIM(OpLoyalitytype), RTRIM(OpbalLoyality), is_loyalityDisable, shippingAddress" & vbCrLf & "                FROM Customer" & vbCrLf & "                WHERE [Name] LIKE @custName" & vbCrLf & "                ORDER BY [Name];"
						sqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@custName", Me.cmbCustomerName.Text + "%")
					End If
					ModCommonClasses.rdr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33) })
					End While
					Me.dgw.ClearSelection()
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F56 RID: 8022 RVA: 0x0014115C File Offset: 0x0013F35C
		Private Sub txtContactNo_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtContactNo.Text.TrimEnd(New Char(-1) {}), "", False) > 0
			If flag Then
				Me.getcustomerdata()
			Else
				Me.dgw.Visible = False
			End If
		End Sub

		' Token: 0x06001F57 RID: 8023 RVA: 0x000164AB File Offset: 0x000146AB
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06001F58 RID: 8024 RVA: 0x001411AC File Offset: 0x0013F3AC
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Me.dgw.SelectedRows.Count > 0
					Dim dataGridViewRow As DataGridViewRow
					If flag2 Then
						dataGridViewRow = Me.dgw.SelectedRows(0)
					Else
						dataGridViewRow = Me.dgw.Rows(0)
					End If
					Dim flag3 As Boolean = dataGridViewRow IsNot Nothing
					If flag3 Then
						Me.lblCustID.Text = dataGridViewRow.Cells(0).Value.ToString()
						Me.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						Me.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.GetCustomerBalance()
						Me.dgw.Visible = False
						Me.txtIssue.Focus()
					End If
				End If
				Me.SearchByCustomerName()
				Me.Getdata_Quotation(Me.lblCustID.Text)
				Me.Getdata_Billing(Me.lblCustID.Text)
				Me.Getdata_SalesReturn(Me.lblCustID.Text)
				Me.Getdata_Sales_Product(Me.lblCustID.Text)
				Me.Getdata_SalesReturn_Product(Me.lblCustID.Text)
				Me.Fetch_CustomerReceiptData()
				Me.lblCount.Text = "Total Support Log(s) : " + Conversions.ToString(Me.GetTokenCountByCustId(Me.lblCustID.Text))
				Me.GetBillDetailsByCustId(Me.lblCustID.Text)
			Catch ex As Exception
				MessageBox.Show("RetrieveData error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F59 RID: 8025 RVA: 0x001413F0 File Offset: 0x0013F5F0
		Private Function GetTokenCountByCustId(strCustomerId As String) As Integer
			Dim num As Integer = 0
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT COUNT(support_token_no) AS TokenCount FROM CustomerSupportForm WHERE CustomerId = @CustomerId"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@CustomerId", strCustomerId)
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
						Dim flag As Boolean = objectValue IsNot Nothing AndAlso Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue))
						If flag Then
							num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue))
						End If
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
			Return num
		End Function

		' Token: 0x06001F5A RID: 8026 RVA: 0x001414E8 File Offset: 0x0013F6E8
		Private Sub GetBillDetailsByCustId(strCustomerId As String)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "                SELECT  " & vbCrLf & "                    MIN(CONVERT(char(10), InvoiceDate, 105)) AS FirstInvoiceDate," & vbCrLf & "                    MAX(CONVERT(char(10), InvoiceDate, 105)) AS LastInvoiceDate," & vbCrLf & "                    (SELECT TOP 1 GrandTotal " & vbCrLf & "                     FROM InvoiceInfo " & vbCrLf & "                     WHERE Customer_ID = @CustomerId" & vbCrLf & "                     ORDER BY InvoiceDate DESC, InvoiceNo DESC) AS LastGrandTotal" & vbCrLf & "                FROM InvoiceInfo" & vbCrLf & "                WHERE Customer_ID = @CustomerId;"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@CustomerId", strCustomerId)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								Dim text2 As String = If(Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("FirstInvoiceDate"))), "", sqlDataReader("FirstInvoiceDate").ToString())
								Dim text3 As String = If(Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("LastInvoiceDate"))), "", sqlDataReader("LastInvoiceDate").ToString())
								Dim text4 As String = If(Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("LastGrandTotal"))), "0.00", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(sqlDataReader("LastGrandTotal"))).ToString("N2"))
								Me.lblBill_dtl.Text = String.Concat(New String() { "First Invoice: ", text2, " | Last Invoice: ", text3, " | Last Paid Amount: ", text4 })
							Else
								Me.lblBill_dtl.Text = "No invoices found for this customer."
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06001F5B RID: 8027 RVA: 0x001416F4 File Offset: 0x0013F8F4
		Public Sub SearchByCustomerName()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, SupportType, CustomerId,CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportForm "
					text += "WHERE CustomerName LIKE @CustomerName "
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@CustomerName", "%" + Me.cmbCustomerName.Text + "%")
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16), sqlDataReader(17), sqlDataReader(18) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F5C RID: 8028 RVA: 0x00141964 File Offset: 0x0013FB64
		Public Sub Getdata_Quotation(strCustomer_Id As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2, Invoiceinfo_Quotation.lead_id   from Invoiceinfo_Quotation " & vbCrLf & "LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID " & vbCrLf & "Left join CustomerSupportForm on CustomerSupportForm.support_token_no  = Invoiceinfo_Quotation.lead_id " & vbCrLf & "where Customer.ID=@d1 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2, Invoiceinfo_Quotation.lead_id   from Invoiceinfo_Quotation " & vbCrLf & "LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID " & vbCrLf & "Left join CustomerSupportForm on CustomerSupportForm.support_token_no  = Invoiceinfo_Quotation.lead_id " & vbCrLf & "where Customer.ID=@d1 and Operator=@d2 order by InvoiceDate", ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.VarChar).Value = strCustomer_Id
				Dim flag2 As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) <> 0
				If flag2 Then
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.VarChar).Value = Me.lblUser.Text
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView3.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.DataGridView3.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView3.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F5D RID: 8029 RVA: 0x00141E1C File Offset: 0x0014001C
		Private Sub ApplyRowColor(row As DataGridViewRow, status As String)
			Dim flag As Boolean = Operators.CompareString(status, "Pending", False) = 0
			If flag Then
				row.DefaultCellStyle.BackColor = Color.Red
				row.DefaultCellStyle.ForeColor = Color.White
			Else
				row.DefaultCellStyle.BackColor = Color.LightGreen
				row.DefaultCellStyle.ForeColor = Color.Black
			End If
		End Sub

		' Token: 0x06001F5E RID: 8030 RVA: 0x00141E88 File Offset: 0x00140088
		Public Sub Getdata_Billing(strCustomer_Id As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt  from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where Customer.ID=@d1 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", strCustomer_Id)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView2.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F5F RID: 8031 RVA: 0x00142260 File Offset: 0x00140460
		Public Sub Fetch_CustomerReceiptData()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = New SqlCommand("Select Date, RTRIM(Name), RTRIM(LedgerNo), RTRIM(Label), Debit, Credit from CustomerLedgerBook where PartyID=@d1 order by Date DESC", ModCommonClasses.con1)
				ModCommonClasses.cmd1.CommandTimeout = 0
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView4.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Me.DataGridView4.Rows.Add(New Object() { ModCommonClasses.rdr1(0), ModCommonClasses.rdr1(1), ModCommonClasses.rdr1(2), ModCommonClasses.rdr1(3), ModCommonClasses.rdr1(4), ModCommonClasses.rdr1(5) })
				End While
				ModCommonClasses.con1.Close()
				Me.DataGridView4.ClearSelection()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06001F60 RID: 8032 RVA: 0x001423AC File Offset: 0x001405AC
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06001F61 RID: 8033 RVA: 0x001423D4 File Offset: 0x001405D4
		Private Sub frmCustomerSupport1_Load(sender As Object, e As EventArgs)
			MyBase.KeyPreview = True
			Me.Reset()
			Me.LoadUsers()
			Me.CompanyInfoDisplay()
			Dim registrydata As frmSplash.LicenseDataNew = MyProject.Forms.frmSplash.getRegistrydata()
			Me.lblSoftwareName.Text = registrydata.company
			Me.strSupport_number = "+91" + registrydata.phone
			Me.LoadCustomerSupportLogs("")
		End Sub

		' Token: 0x06001F62 RID: 8034 RVA: 0x00142444 File Offset: 0x00140644
		Private Sub LoadCustomerSupportLogs(Optional statusFilter As String = "")
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, SupportType, CustomerId, CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportForm "
					Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
					If flag Then
						text += "WHERE Status = @status OR Join_user = @join_user "
					Else
						Dim flag2 As Boolean = Operators.CompareString(statusFilter, "", False) <> 0
						If flag2 Then
							Dim flag3 As Boolean = Operators.CompareString(statusFilter, "Process1", False) = 0
							If flag3 Then
								text += "WHERE Status in @status "
							Else
								text += "WHERE Status = @status "
							End If
						End If
					End If
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim flag4 As Boolean = Operators.CompareString(Me.lblUserType.Text, "Sales Person", False) = 0
						If flag4 Then
							sqlCommand.Parameters.AddWithValue("@status", "Open")
							sqlCommand.Parameters.AddWithValue("@join_user", Me.lblUser.Text)
						Else
							Dim flag5 As Boolean = Operators.CompareString(statusFilter, "", False) <> 0
							If flag5 Then
								Dim text2 As String = "Process, Postpone"
								Dim flag6 As Boolean = Operators.CompareString(statusFilter, "Process1", False) = 0
								If flag6 Then
									sqlCommand.Parameters.AddWithValue("@status", text2)
								Else
									sqlCommand.Parameters.AddWithValue("@status", statusFilter)
								End If
							End If
						End If
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16), sqlDataReader(17), sqlDataReader(18) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F63 RID: 8035 RVA: 0x001427C4 File Offset: 0x001409C4
		Public Sub CompanyInfoDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(ID), RTRIM(CompanyName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(GSTIN), RTRIM(State), RTRIM(FYFrom), RTRIM(FYTo), RTRIM(AndroidID), RTRIM(CurSym) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.lblValidity.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(8))
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F64 RID: 8036 RVA: 0x00142898 File Offset: 0x00140A98
		Public Sub auto()
			Try
				Me.lbl_Id.Text = Me.GenerateID()
				Me.txtTokenNo.Text = "T-" + Me.lbl_Id.Text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F65 RID: 8037 RVA: 0x00142910 File Offset: 0x00140B10
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 LogID FROM CustomerSupportForm ORDER BY LogID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("LogID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06001F66 RID: 8038 RVA: 0x00142A7C File Offset: 0x00140C7C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Strings.Len(Strings.Trim(Me.txtIssue.Text)) = 0) Or (Me.txtIssue.Text = Nothing)
			If flag Then
				MessageBox.Show("Please enter Issue. ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtIssue.Focus()
			Else
				Dim flag2 As Boolean = Me.cmbSupport.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(Me.cmbSupport.Text)
				If flag2 Then
					MessageBox.Show("Please select Support.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSupport.Focus()
				Else
					Dim flag3 As Boolean = Me.cmbUser.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(Me.cmbUser.Text)
					If flag3 Then
						MessageBox.Show("Please select Alloted User.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbUser.Focus()
					Else
						Me.DataInsert()
					End If
				End If
			End If
		End Sub

		' Token: 0x06001F67 RID: 8039 RVA: 0x00142B70 File Offset: 0x00140D70
		Public Sub DataInsert()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "                INSERT INTO CustomerSupportForm" & vbCrLf & "                (support_token_no, CustomerName, RegisteredMobileNumber, CallingNumber, CurrentIssue, " & vbCrLf & "                 SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, EmailAddress, SupportType, CustomerId, join_user) " & vbCrLf & "                VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14);" & vbCrLf & "                SELECT CAST(SCOPE_IDENTITY() AS INT);"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.Add("@d0", SqlDbType.NVarChar, 50).Value = Me.txtTokenNo.Text
						sqlCommand.Parameters.Add("@d1", SqlDbType.NVarChar, 200).Value = Me.cmbCustomerName.Text
						sqlCommand.Parameters.Add("@d2", SqlDbType.NVarChar, 20).Value = Me.txtContactNo.Text
						sqlCommand.Parameters.Add("@d3", SqlDbType.NVarChar, 20).Value = DBNull.Value
						sqlCommand.Parameters.Add("@d4", SqlDbType.NVarChar, 500).Value = Me.txtIssue.Text
						sqlCommand.Parameters.Add("@d5", SqlDbType.NVarChar, 100).Value = DBNull.Value
						sqlCommand.Parameters.Add("@d6", SqlDbType.NVarChar, 50).Value = DBNull.Value
						sqlCommand.Parameters.Add("@d7", SqlDbType.NVarChar, 20).Value = "Open"
						sqlCommand.Parameters.Add("@d8", SqlDbType.NVarChar, -1).Value = DBNull.Value
						sqlCommand.Parameters.Add("@d9", SqlDbType.NVarChar, -1).Value = DBNull.Value
						sqlCommand.Parameters.Add("@d10", SqlDbType.NVarChar, -1).Value = DBNull.Value
						sqlCommand.Parameters.Add("@d11", SqlDbType.NVarChar, 200).Value = DBNull.Value
						sqlCommand.Parameters.Add("@d12", SqlDbType.NVarChar, 50).Value = Me.cmbSupport.Text
						sqlCommand.Parameters.Add("@d13", SqlDbType.Int).Value = Convert.ToInt32(Me.lblCustID.Text)
						sqlCommand.Parameters.Add("@d14", SqlDbType.NVarChar, 50).Value = Me.cmbUser.Text
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
						Me.lblMessage.Visible = True
						Me.lblMessage.Text = String.Concat(New String() { "✅ Your support request has been received." & vbCrLf & "Support Token Number: ", Me.txtTokenNo.Text, vbCrLf & "Submitted: ", DateAndTime.Now.ToString("dd MMM yyyy HH:mm"), vbCrLf & "We'll update you here. For urgent issues call ", Me.strSupport_number, "." })
						Me.btnSave.Enabled = False
						Me.btnNew.Enabled = True
					End Using
				End Using
				MessageBox.Show("Token generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.LoadCustomerSupportLogs("")
			Catch ex As Exception
				MessageBox.Show("Error inserting support log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F68 RID: 8040 RVA: 0x000164B5 File Offset: 0x000146B5
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06001F69 RID: 8041 RVA: 0x00142F00 File Offset: 0x00141100
		Public Sub Reset()
			Me.txtAddress.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtIssue.Text = ""
			Me.txtCustomerID.Text = ""
			Me.cmbCustomerName.Text = ""
			Me.txtTokenNo.Text = ""
			Me.lblMessage.Text = ""
			Me.cmbSupport.SelectedIndex = 0
			Me.lblBalance.Text = "0.00"
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.lbl_Id.Text = ""
			Me.lblCustID.Text = ""
			Me.lblBill_dtl.Text = ""
			Me.lblCount.Text = ""
			Me.auto()
			Me.LoadCustomerSupportLogs("")
			Me.dgw.Visible = False
			Me.cmbCustomerName.Focus()
			Me.DataGridView2.Rows.Clear()
			Me.DataGridView3.Rows.Clear()
			Me.DataGridView4.Rows.Clear()
		End Sub

		' Token: 0x06001F6A RID: 8042 RVA: 0x00143070 File Offset: 0x00141270
		Private Sub cmbCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbCustomerName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid customer name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If
				Me.getcustomerdata()
				Me.dgw.Visible = True
				Dim flag3 As Boolean = Me.dgw.Rows.Count = 1
				If flag3 Then
					Me.dgw.Focus()
					Me.RetrieveData()
				Else
					Dim flag4 As Boolean = Me.dgw.Rows.Count > 1
					If flag4 Then
						Me.dgw.Focus()
						SendKeys.Send("{ENTER}")
					End If
				End If
				e.SuppressKeyPress = True
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.Down
			If flag5 Then
				Dim visible As Boolean = Me.dgw.Visible
				If visible Then
					Me.dgw.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x06001F6B RID: 8043 RVA: 0x0014317C File Offset: 0x0014137C
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid mobile number", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If
				Me.getcustomerdata()
				Me.dgw.Visible = True
				Dim flag3 As Boolean = Me.dgw.Rows.Count = 1
				If flag3 Then
					Me.dgw.Focus()
					Me.RetrieveData()
				Else
					Dim flag4 As Boolean = Me.dgw.Rows.Count > 1
					If flag4 Then
						Me.dgw.Focus()
						SendKeys.Send("{ENTER}")
					End If
				End If
				e.SuppressKeyPress = True
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.Down
			If flag5 Then
				Dim visible As Boolean = Me.dgw.Visible
				If visible Then
					Me.dgw.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x06001F6C RID: 8044 RVA: 0x00143288 File Offset: 0x00141488
		Private Sub txtCustomer_TextChanged(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, SupportType, CustomerId,CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportForm "
					text += "WHERE CustomerName LIKE @CustomerName "
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@CustomerName", "%" + Me.txtCustomer.Text + "%")
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16), sqlDataReader(17), sqlDataReader(18) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F6D RID: 8045 RVA: 0x001434F8 File Offset: 0x001416F8
		Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT TOP " + Me.txtTopResult.Text + " LogID, support_token_no, LogTimestamp, CurrentIssue, SupportType, CustomerId,CustomerName, RegisteredMobileNumber, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, Join_date, Join_user, Close_date,CASE " & vbCrLf & "        WHEN Status IN ('Closed', 'Closed_Offline') THEN '00h 00m'" & vbCrLf & "        ELSE " & vbCrLf & "            CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) / 60 AS VARCHAR(5)) + 'h ' +" & vbCrLf & "            RIGHT('0' + CAST(DATEDIFF(MINUTE, Join_date, GETDATE()) % 60 AS VARCHAR(2)), 2) + 'm'" & vbCrLf & "    END AS waiting_time, CallingNumber FROM CustomerSupportForm "
					text += "WHERE RegisteredMobileNumber LIKE @RegisteredMobileNumber "
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@RegisteredMobileNumber", "%" + Me.txtMobile.Text + "%")
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16), sqlDataReader(17), sqlDataReader(18) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F6E RID: 8046 RVA: 0x000164BF File Offset: 0x000146BF
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_Support()
		End Sub

		' Token: 0x06001F6F RID: 8047 RVA: 0x00143768 File Offset: 0x00141968
		Public Sub RetrieveData_Support()
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Me.DataGridView1.SelectedRows.Count > 0
					Dim dataGridViewRow As DataGridViewRow
					If flag2 Then
						dataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Else
						dataGridViewRow = Me.DataGridView1.Rows(0)
					End If
					Dim flag3 As Boolean = dataGridViewRow IsNot Nothing
					If flag3 Then
						Me.lbl_Id.Text = dataGridViewRow.Cells(0).Value.ToString()
						Me.txtTokenNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.txtIssue.Text = dataGridViewRow.Cells(3).Value.ToString()
						Me.cmbSupport.Text = dataGridViewRow.Cells(4).Value.ToString()
						Me.lblCustID.Text = dataGridViewRow.Cells(5).Value.ToString()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select RTRIM(CustomerID) AS CustomerID, RTRIM([Name]) AS [Name]," & vbCrLf & "                        RTRIM(Address) AS Address from Customer where ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblCustID.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							Me.txtCustomerID.Text = ModCommonClasses.rdr(0).ToString()
							Me.txtAddress.Text = ModCommonClasses.rdr(2).ToString()
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
							ModCommonClasses.con.Close()
						End If
						Me.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
						Me.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						Me.cmbUser.Text = dataGridViewRow.Cells(15).Value.ToString()
						Me.Getdata_Quotation(Me.lblCustID.Text)
						Me.Getdata_Billing(Me.lblCustID.Text)
						Me.Fetch_CustomerReceiptData()
						Me.btnNew.Enabled = True
						Me.btnSave.Enabled = False
						Me.btnUpdate.Enabled = True
						Me.btnDelete.Enabled = True
						Me.dgw.Visible = False
						Me.txtIssue.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("RetrieveData error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F70 RID: 8048 RVA: 0x00143A98 File Offset: 0x00141C98
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Strings.Len(Strings.Trim(Me.txtIssue.Text)) = 0) Or (Me.txtIssue.Text = Nothing)
			If flag Then
				MessageBox.Show("Please enter Issue. ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtIssue.Focus()
			Else
				Dim flag2 As Boolean = Me.cmbSupport.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(Me.cmbSupport.Text)
				If flag2 Then
					MessageBox.Show("Please select Support.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSupport.Focus()
				Else
					Dim flag3 As Boolean = Me.cmbUser.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(Me.cmbUser.Text)
					If flag3 Then
						MessageBox.Show("Please select Alloted User.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbUser.Focus()
					Else
						Me.DataUpdate()
					End If
				End If
			End If
		End Sub

		' Token: 0x06001F71 RID: 8049 RVA: 0x00143B8C File Offset: 0x00141D8C
		Public Sub DataUpdate()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "            UPDATE CustomerSupportForm" & vbCrLf & "            SET " & vbCrLf & "                CustomerName = @d1," & vbCrLf & "                RegisteredMobileNumber = @d2,               " & vbCrLf & "                CurrentIssue = @d4,                " & vbCrLf & "                SupportType = @d12," & vbCrLf & "                CustomerId = @d13," & vbCrLf & "                join_user = @d14" & vbCrLf & "            WHERE LogID = @LogID"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.Add("@d1", SqlDbType.NVarChar, 200).Value = Me.cmbCustomerName.Text
						sqlCommand.Parameters.Add("@d2", SqlDbType.NVarChar, 20).Value = Me.txtContactNo.Text
						sqlCommand.Parameters.Add("@d4", SqlDbType.NVarChar, 500).Value = Me.txtIssue.Text
						sqlCommand.Parameters.Add("@d12", SqlDbType.NVarChar, 50).Value = Me.cmbSupport.Text
						sqlCommand.Parameters.Add("@d13", SqlDbType.Int).Value = Convert.ToInt32(Me.lblCustID.Text)
						sqlCommand.Parameters.Add("@d14", SqlDbType.NVarChar, 50).Value = Me.cmbUser.Text
						sqlCommand.Parameters.Add("@LogID", SqlDbType.Int).Value = Convert.ToInt32(Me.lbl_Id.Text)
						Dim num As Integer = sqlCommand.ExecuteNonQuery()
						Dim flag As Boolean = num > 0
						If flag Then
							MessageBox.Show("Support log updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Else
							MessageBox.Show("No record updated. Please check the LogID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						End If
					End Using
				End Using
				Me.LoadCustomerSupportLogs("")
			Catch ex As Exception
				MessageBox.Show("Error updating support log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F72 RID: 8050 RVA: 0x000164C9 File Offset: 0x000146C9
		Private Sub DataGridView3_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_LQ()
		End Sub

		' Token: 0x06001F73 RID: 8051 RVA: 0x00143DB8 File Offset: 0x00141FB8
		Public Sub RetrieveData_LQ()
			Try
				Dim flag As Boolean = Me.DataGridView3.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView3.SelectedRows(0)
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUserType.Text = Me.lblUserType.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.Show()
					MyProject.Forms.frmPOSNewTuch_Quotation.Label207.Text = "edit"
					MyProject.Forms.frmPOSNewTuch_Quotation.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.Label202.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch_Quotation.txtCompanyState.Text
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.CAddress = dataGridViewRow.Cells(40).Value.ToString()
					Dim flag3 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag3 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtByReturn.Text = dataGridViewRow.Cells(42).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotalLoyality_points.Text = dataGridViewRow.Cells(43).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblTPoints1.Text = dataGridViewRow.Cells(44).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblTPointsAmt1.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox43.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblQ_Status.Text = dataGridViewRow.Cells(46).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.btnSave.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnPrint.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Button5.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Button6.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.txtOffer.Text = "0.00"
					MyProject.Forms.frmPOSNewTuch_Quotation.btnUpdate.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.btnDelete.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.lblSet.Text = "Not Allowed"
					MyProject.Forms.frmPOSNewTuch_Quotation.btnAdd.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnCustomerSelection.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox15.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Label82.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(InvoiceInfo_Product_Quotation.Barcode),InvoiceInfo_Product_Quotation.Qty, InvoiceInfo_Product_Quotation.SalesRate,InvoiceInfo_Product_Quotation.DiscountPer, InvoiceInfo_Product_Quotation.Discount, InvoiceInfo_Product_Quotation.CGSTPer, InvoiceInfo_Product_Quotation.CGSTAmt, InvoiceInfo_Product_Quotation.SGSTPer, InvoiceInfo_Product_Quotation.SGSTAmt, InvoiceInfo_Product_Quotation.IGSTPer,InvoiceInfo_Product_Quotation. IGSTAmt, InvoiceInfo_Product_Quotation.CESSPer,InvoiceInfo_Product_Quotation. CESSAmt,InvoiceInfo_Product_Quotation. TotalAmount,InvoiceInfo_Product_Quotation. PurchaseRate,InvoiceInfo_Product_Quotation. Margin,InvoiceInfo_Product_Quotation.Descr,InvoiceInfo_Product_Quotation.Qty,RTRIM(InvoiceInfo_Product_Quotation.IM1),RTRIM(InvoiceInfo_Product_Quotation.IM2),(InvoiceInfo_Product_Quotation.MRP),(InvoiceInfo_Product_Quotation.TaxableAmt),(InvoiceInfo_Product_Quotation.AltQty),(InvoiceInfo_Product_Quotation.AltUnit),(InvoiceInfo_Product_Quotation.STaxType),(InvoiceInfo_Product_Quotation.TotalMRP),(InvoiceInfo_Product_Quotation.PromoQty),RTRIM(InvoiceInfo_Product_Quotation.MainUnit),RTRIM(InvoiceInfo_Product_Quotation.Batch),RTRIM(InvoiceInfo_Product_Quotation.Mfg),RTRIM(InvoiceInfo_Product_Quotation.Exp),RTRIM(InvoiceInfo_Product_Quotation.Size),RTRIM(InvoiceInfo_Product_Quotation.Colour),InvoiceInfo_Product_Quotation.SalesManID,InvoiceInfo_Product_Quotation.SalesMan,InvoiceInfo_Product_Quotation.SalesManPur,InvoiceInfo_Product_Quotation.SalesManComm ,InvoiceInfo_Product_Quotation.StockID, InvoiceInfo_Product_Quotation.LoyalityPoints from InvoiceInfo_Quotation,InvoiceInfo_Product_Quotation,Product where InvoiceInfo_Quotation.Inv_ID=InvoiceInfo_Product_Quotation.InvoiceID and Product.PID=InvoiceInfo_Product_Quotation.ProductID and InvoiceInfo_Quotation.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), MyProject.Forms.frmPOSNewTuch_Quotation.GetProductImage(CInt(Convert.ToInt16(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0))))), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
					End While
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceinfo_Product_Quotation.Barcode),Invoiceinfo_Product_Quotation.Qty, Invoiceinfo_Product_Quotation.SalesRate,Invoiceinfo_Product_Quotation.DiscountPer, Invoiceinfo_Product_Quotation.Discount, Invoiceinfo_Product_Quotation.CGSTPer, Invoiceinfo_Product_Quotation.CGSTAmt, Invoiceinfo_Product_Quotation.SGSTPer, Invoiceinfo_Product_Quotation.SGSTAmt, Invoiceinfo_Product_Quotation.IGSTPer,Invoiceinfo_Product_Quotation. IGSTAmt, Invoiceinfo_Product_Quotation.CESSPer,Invoiceinfo_Product_Quotation. CESSAmt,Invoiceinfo_Product_Quotation. TotalAmount,Invoiceinfo_Product_Quotation. PurchaseRate,Invoiceinfo_Product_Quotation. Margin from Invoiceinfo_Quotation,Invoiceinfo_Product_Quotation,Product where Invoiceinfo_Quotation.Inv_ID=Invoiceinfo_Product_Quotation.InvoiceID and Product.PID=Invoiceinfo_Product_Quotation.ProductID and Invoiceinfo_Quotation.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView3.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
					ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Visible = True
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
					End While
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSNewTuch_Quotation.CustomerBalance_Loyality()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calc()
					MyProject.Forms.frmPOSNewTuch_Quotation.Compute()
					MyProject.Forms.frmPOSNewTuch_Quotation.alldiscountcalc()
					MyProject.Forms.frmPOSNewTuch_Quotation.Bankcondn()
					MyProject.Forms.frmPOSNewTuch_Quotation.totitemnqty()
					MyProject.Forms.frmPOSNewTuch_Quotation.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calculate12345()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calculate143()
					Dim flag4 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbBSundry.Text, "TCS", False) = 0
					If flag4 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.[ReadOnly] = True
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.Text = "0"
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.CTypeStatus()
					MyProject.Forms.frmPOSNewTuch_Quotation.BrokerRetrive()
					MyProject.Forms.frmPOSNewTuch_Quotation.CheckBox11.Checked = False
					MyProject.Forms.frmPOSNewTuch_Quotation.txtInvoiceNo.[ReadOnly] = True
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F74 RID: 8052 RVA: 0x001450E0 File Offset: 0x001432E0
		Private Sub DataGridView3_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_LQ()
			End If
		End Sub

		' Token: 0x06001F75 RID: 8053 RVA: 0x00145108 File Offset: 0x00143308
		Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x06001F76 RID: 8054 RVA: 0x000164D3 File Offset: 0x000146D3
		Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x06001F77 RID: 8055 RVA: 0x00145130 File Offset: 0x00143330
		Public Sub RetrieveData1()
			Try
				Dim flag As Boolean = Me.DataGridView2.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.SelectedRows(0)
					MyProject.Forms.frmPOSNewTuch.Show()
					MyProject.Forms.frmPOSNewTuch.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.Label202.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch.txtCompanyState.Text
					Else
						MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					End If
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
					MyProject.Forms.frmPOSNewTuch.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.CAddress = dataGridViewRow.Cells(40).Value.ToString()
					Dim flag3 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag3 Then
						MyProject.Forms.frmPOSNewTuch.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSNewTuch.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSNewTuch.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtByReturn.Text = dataGridViewRow.Cells(42).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTotalLoyality_points.Text = dataGridViewRow.Cells(43).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.lblTPoints1.Text = dataGridViewRow.Cells(44).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.lblTPointsAmt1.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.TextBox43.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.btnSave.Enabled = False
					MyProject.Forms.frmPOSNewTuch.btnPrint.Enabled = True
					MyProject.Forms.frmPOSNewTuch.Button5.Enabled = True
					MyProject.Forms.frmPOSNewTuch.Button6.Enabled = True
					MyProject.Forms.frmPOSNewTuch.txtOffer.Text = "0.00"
					Dim flag4 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
					If flag4 Then
						MyProject.Forms.frmPOSNewTuch.btnUpdate.Enabled = True
						MyProject.Forms.frmPOSNewTuch.btnDelete.Enabled = True
					Else
						MyProject.Forms.frmPOSNewTuch.btnUpdate.Enabled = False
						MyProject.Forms.frmPOSNewTuch.btnDelete.Enabled = False
					End If
					MyProject.Forms.frmPOSNewTuch.lblSet.Text = "Not Allowed"
					MyProject.Forms.frmPOSNewTuch.btnAdd.Enabled = True
					MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch.txtContactNo.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Enabled = False
					MyProject.Forms.frmPOSNewTuch.btnCustomerSelection.Enabled = False
					MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch.TextBox15.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch.Label82.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin,Invoice_Product.Descr,Invoice_Product.Qty,RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),(Invoice_Product.MRP),(Invoice_Product.TaxableAmt),(Invoice_Product.AltQty),(Invoice_Product.AltUnit),(Invoice_Product.STaxType),(Invoice_Product.TotalMRP),(Invoice_Product.PromoQty),RTRIM(Invoice_Product.MainUnit),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour),Invoice_Product.SalesManID,Invoice_Product.SalesMan,Invoice_Product.SalesManPur,Invoice_Product.SalesManComm ,Invoice_Product.StockID, Invoice_Product.LoyalityPoints from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
					End While
					MyProject.Forms.frmPOSNewTuch.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoice_Product.Barcode),Invoice_Product.Qty, Invoice_Product.SalesRate,Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer,Invoice_Product. IGSTAmt, Invoice_Product.CESSPer,Invoice_Product. CESSAmt,Invoice_Product. TotalAmount,Invoice_Product. PurchaseRate,Invoice_Product. Margin from InvoiceInfo,Invoice_Product,Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and Product.PID=Invoice_Product.ProductID and InvoiceInfo.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView3.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "SELECT RTRIM(Invoice_Payment.PaymentMode),Invoice_Payment.TotalPaid,PaymentDate,RTRIM(Invoice_Payment.BankAc) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView2.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text4 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
					ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView5.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView5.Visible = True
						MyProject.Forms.frmPOSNewTuch.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
					End While
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSNewTuch.CustomerBalance_Loyality()
					MyProject.Forms.frmPOSNewTuch.Calc()
					MyProject.Forms.frmPOSNewTuch.Compute()
					MyProject.Forms.frmPOSNewTuch.alldiscountcalc()
					MyProject.Forms.frmPOSNewTuch.Bankcondn()
					MyProject.Forms.frmPOSNewTuch.totitemnqty()
					MyProject.Forms.frmPOSNewTuch.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSNewTuch.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSNewTuch.Calculate12345()
					MyProject.Forms.frmPOSNewTuch.Calculate143()
					Dim flag5 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text, "TCS", False) = 0
					If flag5 Then
						MyProject.Forms.frmPOSNewTuch.txtTCSdbl.[ReadOnly] = True
					Else
						MyProject.Forms.frmPOSNewTuch.txtTCSdbl.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch.txtTCSdbl.Text = "0"
					End If
					MyProject.Forms.frmPOSNewTuch.CTypeStatus()
					MyProject.Forms.frmPOSNewTuch.BrokerRetrive()
					MyProject.Forms.frmPOSNewTuch.CheckBox11.Checked = False
					MyProject.Forms.frmPOSNewTuch.txtInvoiceNo.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch.GridGetCustomer.Visible = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F78 RID: 8056 RVA: 0x0014653C File Offset: 0x0014473C
		Public Sub Getdata_SalesReturn(strCustomerId As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SR_ID, RTRIM(SRNo),SalesReturn.Date,RTRIM(TaxType),SalesID,RTRIM(InvoiceNo),InvoiceDate, RTRIM(Customer.CustomerID),RTRIM(Name),SalesReturn.SubTotal,SalesReturn.CGST,SalesReturn.SGST,SalesReturn.IGST,SalesReturn.CESS,SalesReturn.FreightCharges,SalesReturn.OtherCharges,SalesReturn.Total,SalesReturn.RoundOff,RTRIM(SalesReturn.GrandTotal),SalesReturn.PaymentMode,SalesReturn.BillSundry FROM InvoiceInfo,SalesReturn,Customer where InvoiceInfo.Inv_ID=SalesReturn.SalesID and Customer.ID=InvoiceInfo.Customer_ID and InvoiceInfo.Customer_ID= @CustomerId order by SalesReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@CustomerId", strCustomerId)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView5.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView5.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F79 RID: 8057 RVA: 0x00146778 File Offset: 0x00144978
		Private Sub DataGridView5_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_SalesReturn()
			End If
		End Sub

		' Token: 0x06001F7A RID: 8058 RVA: 0x001467A0 File Offset: 0x001449A0
		Public Sub RetrieveData_SalesReturn()
			Try
				Dim flag As Boolean = Me.DataGridView5.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView5.SelectedRows(0)
					MyProject.Forms.frmSalesReturn.Show()
					MyProject.Forms.frmSalesReturn.txtSRID.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtSRNO.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmSalesReturn.dtpSRDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtGSTnonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtSalesID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtSalesInvoiceNo.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmSalesReturn.dtpSalesDate.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtCustomerID.Text = dataGridViewRow.Cells(7).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtCustomerName.Text = dataGridViewRow.Cells(8).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtSubTotal.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtCGST.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtSGST.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtIGST.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtCESS.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtFreightCharges.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtBillDiscount.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtTotal.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtRoundOff.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmSalesReturn.txtGrandTotal.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmSalesReturn.cmbPmtMode.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmSalesReturn.cmbBSundry.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmSalesReturn.btnDelete.Enabled = False
					MyProject.Forms.frmSalesReturn.DataGridView1.Enabled = True
					MyProject.Forms.frmSalesReturn.btnAdd.Enabled = False
					MyProject.Forms.frmSalesReturn.btnRemove.Enabled = False
					MyProject.Forms.frmSalesReturn.lblSet.Text = "Not Allowed"
					MyProject.Forms.frmSalesReturn.btnDelete.Enabled = True
					MyProject.Forms.frmSalesReturn.btnSelection.Enabled = False
					MyProject.Forms.frmSalesReturn.btnPrint.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(SalesReturn_Join.Barcode),SalesReturn_Join.Qty, SalesReturn_Join.SalesRate,SalesReturn_Join. DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer,SalesReturn_Join. IGSTAmt, SalesReturn_Join.CESSPer,SalesReturn_Join. CESSAmt,ReturnQty,SalesReturn_Join. TotalAmount,SalesReturn_Join.PurchaseRate,SalesReturn_Join.Margin, RTRIM(SalesReturn_Join.STaxType), RTRIM(SalesReturn_Join.TaxableAmt) FROM SalesReturn_Join INNER JOIN SalesReturn ON SalesReturn_Join.SalesReturnID = SalesReturn.SR_ID INNER JOIN Product ON Product.PID = SalesReturn_Join.ProductID and SR_ID=", dataGridViewRow.Cells(0).Value), ""))
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmSalesReturn.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmSalesReturn.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
					End While
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_saleReturn a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmSalesReturn.DataGridView5F.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmSalesReturn.DataGridView5F.Visible = True
						MyProject.Forms.frmSalesReturn.DataGridView5F.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
					End While
					ModCommonClasses.con.Close()
					MyProject.Forms.frmSalesReturn.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					MyProject.Forms.frmSalesReturn.Calc()
					MyProject.Forms.frmSalesReturn.Compute()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06001F7B RID: 8059 RVA: 0x000164DD File Offset: 0x000146DD
		Private Sub DataGridView5_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_SalesReturn()
		End Sub

		' Token: 0x06001F7C RID: 8060 RVA: 0x00146FD0 File Offset: 0x001451D0
		Public Sub Getdata_Sales_Product(strCustomerId As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.Customer_ID= @CustomerId order by Invoiceinfo.InvoiceDate desc", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@CustomerId", strCustomerId)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView6.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView6.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView6.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F7D RID: 8061 RVA: 0x001472C8 File Offset: 0x001454C8
		Public Sub Getdata_SalesReturn_Product(strCustomerId As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount,RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and InvoiceInfo.Customer_ID= @CustomerId order by SalesReturn.Date desc", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@CustomerId", strCustomerId)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView7.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView7.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView7.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F7E RID: 8062 RVA: 0x00147544 File Offset: 0x00145744
		Private Sub DataGridView6_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView6.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView6.SelectedRows(0)
					Me.DataGridView8.Visible = True
					Me.DataGridView9.Visible = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.InvoiceNo= @InvoiceNo", ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.cmd.Parameters.AddWithValue("@InvoiceNo", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView8.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView8.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
					End While
					ModCommonClasses.con.Close()
					Me.DataGridView8.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F7F RID: 8063 RVA: 0x00147898 File Offset: 0x00145A98
		Private Sub DataGridView7_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView7.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView7.SelectedRows(0)
					Me.DataGridView8.Visible = False
					Me.DataGridView9.Visible = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount,RTRIM(SalesReturn_Join.Barcode) FROM SalesReturn INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SalesReturn.SRNo=@SRNo", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@SRNo", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView9.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView9.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
					End While
					ModCommonClasses.con.Close()
					Me.DataGridView9.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001F80 RID: 8064 RVA: 0x00147B70 File Offset: 0x00145D70
		Private Sub frmCustomerSupport1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.DataGridView8.Visible = False
				Me.DataGridView9.Visible = False
			End If
		End Sub

		' Token: 0x04000CBE RID: 3262
		Private strSupport_number As String
	End Class
End Namespace
